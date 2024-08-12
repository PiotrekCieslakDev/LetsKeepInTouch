using Domains.PostClasses;
using Domains.ResultClasses;
using Domains.UserClasses;

namespace Domains.ReportClasses
{
    public class PostReport : Report
    {
        private Post _reportedPost;

        public PostReport(User reporter, string reportComment, Post reportedPost) : base(reporter, reportComment)
        {
            _reportedPost = reportedPost;
        }

        public PostReport(Guid id, User reporter, DateTime timeStamp, bool reviewed, string reportComment, Post reportedPost) : base(id, reporter, timeStamp, reviewed, reportComment)
        {
            _reportedPost = reportedPost;
        }

        public Post ReportedPost { get => _reportedPost; }

        public override string GetInfoAboutReport()
        {
            return $"{_reviewed}: {_reportedPost.Author}'s post was reported by {_reporter} on {_timeStamp.Date}";
        }

        public override string ToString()
        {
            string reviewedString = "Not reviewed";
            if (_reviewed)
            {
                reviewedString = "Reviewed";
            }
            return String.Format($"{reviewedString}: {_reportedPost.Author.GetFullNameWithUserNameAndEmail()}'s post was reported by {_reporter.GetFullNameWithUserName()} on {_timeStamp.Date.ToShortDateString()}");
        }

        public Result ReviewReport(bool banUser, bool restrictPost)
        {
            Result userOp = _reportedPost.Author.BanUser(banUser);
            Result postOp = _reportedPost.RestrictPost(restrictPost);

            _reviewed = true;

            if (userOp.IsSuccess && postOp.IsSuccess)
            {
                return new Result(true, $"{userOp.Message} {postOp.Message}");
            }
            else
            {
                _reviewed = false;
                return new Result(false, "Something went wrong");
            }
        }
    }
}
