using Domains.ResultClasses;
using Domains.UserClasses;

namespace Domains.ReportClasses
{
    public class UserReport : Report
    {
        private User _reportedUser;

        public UserReport(User reporter, string reportComment, User reportedUser) : base(reporter, reportComment)
        {
            _reportedUser = reportedUser;
        }

        public UserReport(Guid id, User reporter, DateTime timeStamp, bool reviewed, string reportComment, User reportedUser) : base(id, reporter, timeStamp, reviewed, reportComment)
        {
            _reportedUser = reportedUser;
        }

        public User ReportedUser { get => _reportedUser; }

        public override string GetInfoAboutReport()
        {
            return $"{_reviewed}: {_reportedUser} was reported by {_reporter} on {_timeStamp.Date}";
        }

        public override string ToString()
        {
            return String.Format($"{_reviewed}: {_reportedUser} was reported by {_reporter} on {_timeStamp.Date.ToShortDateString()}");
        }

        public Result ReviewReport(bool banUser)
        {
            _reviewed = true;
            return _reportedUser.BanUser(banUser);
        }
    }
}
