using DataAccessLayerInterfaces;
using Domains.ReportClasses;
using Domains.ResultClasses;
using LogicLayer.ModerationClasses.ModerationRepositoriesInitializators;
using LogicLayer.ModerationClasses.ModerationReviews;
using LogicLayer.Services;

namespace LogicLayer.ModerationClasses.ModerationStrategies
{
    public class UserModerationStrategy : IModerationStrategy
    {
        private readonly IReportRepository _reportRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        private readonly UserModerationReview _userModerationReview;

        public UserModerationStrategy(UserModerationRepositories userModerationRepositories, UserModerationReview userModerationReview)
        {
            _reportRepository = userModerationRepositories._reportRepository;
            _postRepository = userModerationRepositories._postRepository;
            _userRepository = userModerationRepositories._userRepository;

            _userModerationReview = userModerationReview;
        }

        public Result ReviewReport(Report reportToBeReviewed)
        {
            Result resultOfWholeReviewing = new Result(false, "Something went wrong");
            UserReport? userReportToBeReviewed = reportToBeReviewed as UserReport;

            if (userReportToBeReviewed != null)
            {
                resultOfWholeReviewing = userReportToBeReviewed.ReviewReport(_userModerationReview.BanAuthor);

                if (_userRepository.UpdateUserInDb(userReportToBeReviewed.ReportedUser).IsSuccess)
                {
                    if (_userModerationReview.RestrictAllPostsMadeByUser)
                    {
                        Result resultOfRestrictingAllPostsMadeByUser = _postRepository.RestrictAllPostsMadeByUserByTheirId(userReportToBeReviewed.ReportedUser.Id);

                        if (resultOfRestrictingAllPostsMadeByUser.IsSuccess)
                        {
                            resultOfWholeReviewing.Message += " All of the user's posts has been restricted.";
                        }
                        else
                        {
                            resultOfWholeReviewing.IsSuccess = false;
                            resultOfWholeReviewing.Message += " BUT NOT ALL OFF THE POSTS HAS BEEN RESTRICTED.";
                        }
                    }
                }
                else
                {
                    resultOfWholeReviewing = new Result(false, "Updating user failed.");
                }
            }
            else
            {
                return resultOfWholeReviewing = new Result(false, "Report could not be found by ID");
            }

            if (resultOfWholeReviewing.IsSuccess)
            {
                userReportToBeReviewed.Review();

                Result tickingUserReportAsReported = _reportRepository.UpdateReport(userReportToBeReviewed);

                if (tickingUserReportAsReported.IsSuccess)
                {
                    resultOfWholeReviewing.Message += " Review tagged as reviewed";
                }
                else
                {
                    resultOfWholeReviewing.Message += " THE REVIEW HAS NOT BEEN TAGGED AS REVIEWD. TRY DOING IT MANUALLY AND CONTACT ADMIN!";
                }
            }

            return resultOfWholeReviewing;
        }
    }
}
