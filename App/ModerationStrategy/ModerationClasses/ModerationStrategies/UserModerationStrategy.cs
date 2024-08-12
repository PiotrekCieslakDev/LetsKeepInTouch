using DataAccessLayerInterfaces;
using Domains.ReportClasses;
using Domains.ResultClasses;
using LogicLayer.ModerationClasses.ModerationRepositoriesInitializators;
using LogicLayer.ModerationClasses.ModerationReviews;
using LogicLayer.Services;
using LogicLayerInterfaces;

namespace LogicLayer.ModerationClasses.ModerationStrategies
{
    internal class UserModerationStrategy : IModerationStrategy
    {
        private readonly IUserRepository _userRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IPostRepository _postRepository;

        public UserModerationStrategy(IUserRepository userRepository, IReportRepository reportRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _reportRepository = reportRepository;
            _postRepository = postRepository;
        }

        public Result ReviewReport(ModerationReview moderationReview, ModerationRepositories moderationRepositories)
        {
            if (moderationReview is not UserModerationReview userModerationReview)
            {
                throw new Exception("Moderation review is not user moderation review");
            }
            if (moderationRepositories is not UserModerationRepositories userModerationRepositories)
            {
                throw new Exception("Moderation repositories are not user moderation repositories");
            }

            Result resultOfWholeReviewing = new Result(false, "Something went wrong");
           
            if (moderationReview.ReportToBeReviewed is UserReport userReportToBeReviewed)
            {
                if (userReportToBeReviewed != null)
                {
                    resultOfWholeReviewing = userReportToBeReviewed.ReviewReport(userModerationReview.BanAuthor);

                    if (_userRepository.UpdateUserInDb(userReportToBeReviewed.ReportedUser).IsSuccess)
                    {
                        if (userModerationReview.RestrictAllPostsMadeByUser)
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
            }

            return resultOfWholeReviewing;
        }
    }
}
