using DataAccessLayerInterfaces;
using Domains.ReportClasses;
using Domains.ResultClasses;
using LogicLayer.ModerationClasses.ModerationRepositoriesInitializators;
using LogicLayer.ModerationClasses.ModerationReviews;
using LogicLayer.Services;

namespace LogicLayer.ModerationClasses.ModerationStrategies
{
    public class PostModerationStrategy : IModerationStrategy
    {
        private readonly IReportRepository _reportRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        private readonly PostModerationReview _postModerationReview;

        public PostModerationStrategy(PostModerationRepositories postModerationRepositories, PostModerationReview postModerationReview)
        {
            _reportRepository = postModerationRepositories._reportRepository;
            _postRepository = postModerationRepositories._postRepository;
            _userRepository = postModerationRepositories._userRepository;

            _postModerationReview = postModerationReview;
        }

        public Result ReviewReport(Report reportToBeReviewed)
        {
            Result resultOfWholeReviewing = new Result(false, "Something went wrong.");

            PostReport? postReportToBeReviewed = reportToBeReviewed as PostReport;

            if (postReportToBeReviewed != null)
            {
                resultOfWholeReviewing = postReportToBeReviewed.ReviewReport(_postModerationReview.BanAuthor, _postModerationReview.RestrictPost);

                if (_postRepository.TogglePostRestriction(postReportToBeReviewed.ReportedPost.Id, _postModerationReview.RestrictPost).IsSuccess && _userRepository.UpdateUserInDb(postReportToBeReviewed.ReportedPost.Author).IsSuccess)
                {
                    if (_postModerationReview.RestrictAllPostsMadeByUser)
                    {
                        if (_postRepository.RestrictAllPostsMadeByUserByTheirId(postReportToBeReviewed.ReportedPost.Author.Id).IsSuccess)
                        {
                            resultOfWholeReviewing.IsSuccess = true;
                            resultOfWholeReviewing.Message += " All of their post have been restricted.";
                        }
                        else
                        {
                            resultOfWholeReviewing.IsSuccess = false;
                            resultOfWholeReviewing.Message += " BUT SOMETHING WENT WRONG DURING RESTRICTING REST OF THE USER'S POSTS.TRY AGAIN LATER";
                        }
                    }
                }
                else
                {
                    return new Result(false, "Failed updating restriction and ban");
                }
            }
            else
            {
                return new Result(false, "Could not find report by its id. CRITICAL ISSUE");
            }

            if (resultOfWholeReviewing.IsSuccess)
            {
                postReportToBeReviewed.Review();

                Result tickingUserReportAsReported = _reportRepository.UpdateReport(postReportToBeReviewed);

                if (tickingUserReportAsReported.IsSuccess)
                {
                    resultOfWholeReviewing.Message += " Review tagged as reviewed";
                }
                else
                {
                    resultOfWholeReviewing.Message += " BUT THE REVIEW HAS NOT BEEN TAGGED AS REVIEWD. TRY DOING IT MANUALLY AND CONTACT ADMIN!";
                }
            }

            return resultOfWholeReviewing;
        }
    }
}
