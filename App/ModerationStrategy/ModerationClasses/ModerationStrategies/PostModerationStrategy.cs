using DataAccessLayerInterfaces;
using Domains.ReportClasses;
using Domains.ResultClasses;
using LogicLayer.ModerationClasses.ModerationRepositoriesInitializators;
using LogicLayer.ModerationClasses.ModerationReviews;
using LogicLayer.Services;
using LogicLayerInterfaces;

namespace LogicLayer.ModerationClasses.ModerationStrategies
{
    public class PostModerationStrategy : IModerationStrategy
    {
        private readonly IUserRepository _userRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IPostRepository _postRepository;

        public PostModerationStrategy(IUserRepository userRepository, IReportRepository reportRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _reportRepository = reportRepository;
            _postRepository = postRepository;
        }

        public Result ReviewReport(ModerationReview moderationReview, ModerationRepositories moderationRepositories)
        {
            if (moderationReview is not PostModerationReview postModerationReview)
            {
                throw new Exception("Moderation review is not post moderation review");
            }
            if (moderationRepositories is not PostModerationRepositories postModerationRepositories)
            {
                throw new Exception("Moderation repositories are not post moderation repositories");
            }

            Result resultOfWholeReviewing = new Result(false, "Something went wrong.");

            if (postModerationReview.ReportToBeReviewed is PostReport postReportToBeReviewed)
            {
                if (postReportToBeReviewed != null)
                {
                    resultOfWholeReviewing = postReportToBeReviewed.ReviewReport(postModerationReview.BanAuthor, postModerationReview.RestrictPost);

                    if (_postRepository.TogglePostRestriction(postReportToBeReviewed.ReportedPost.Id, postModerationReview.RestrictPost).IsSuccess && _userRepository.UpdateUserInDb(postReportToBeReviewed.ReportedPost.Author).IsSuccess)
                    {
                        if (postModerationReview.RestrictAllPostsMadeByUser)
                        {
                            if (_postRepository.RestrictAllPostsMadeByUserByTheirId(postReportToBeReviewed.ReportedPost.Author.Id).IsSuccess)
                            {
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
            }

            return resultOfWholeReviewing;
        }
    }
}
