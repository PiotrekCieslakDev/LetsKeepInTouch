using DataAccessLayerInterfaces;
using Domains.PostClasses;
using Domains.ReportClasses;
using Domains.ResultClasses;
using Domains.UserClasses;
using LogicLayer.ModerationClasses.ModerationRepositoriesInitializators;
using LogicLayer.ModerationClasses.ModerationReviews;
using LogicLayer.ModerationClasses.ModerationStrategies;
using LogicLayer.PostStrategies.PostsListSortingAndFiltering;
using LogicLayer.ReportStrategies.SortAndFilterReports;
using LogicLayerInterfaces;

namespace LogicLayer.Services
{
    public class ReportService : IReportService
    {
        private PostService _postService;
        private UserService _userService;
        private IReportRepository _reportRepository;

        private List<Report> _reports = new List<Report>();

        public ReportService(IReportRepository reportRepository, IPostRepository postRepository, IUserRepository userRepository, INotificationRepository notificationRepository)
        {
            _postService = new PostService(postRepository, userRepository, notificationRepository);
            _userService = new UserService(userRepository);
            _reportRepository = reportRepository;
        }

        public List<Report> GetAllReports()
        {
            return _reportRepository.GetAllReports();
        }
        public List<PostReport> GetAllPostReports()
        {
            return _reportRepository.GetAllPostReports();
        }
        public List<UserReport> GetAllUserReports()
        {
            return _reportRepository.GetAllUserReports();
        }
        public Report GetReportById(Guid reportId)
        {
            return _reportRepository.GetReportById(reportId);
        }
        public List<Report> GetUsersReports(Guid userId)
        {
            return _reportRepository.GetReportsByReportedUserId(userId);
        }

        public List<Report> SearchAndFilterReportsFromAllPostsFromRepository(ISortFilterReports[] sortFilterParameters)
        {
            List<Report>? retrivedPosts = _reportRepository.GetAllReports();
            if (retrivedPosts == null)
            {
                return new List<Report>();
            }
            if (sortFilterParameters != null && sortFilterParameters.Any())
            {
                foreach (ISortFilterReports sortingFilteringProcess in sortFilterParameters)
                {
                    retrivedPosts = sortingFilteringProcess.SortAndFilter(retrivedPosts);
                }
            }
            return retrivedPosts;
        }

        public Result CreateReport(Report reportToBeCreated)
        {
            return _reportRepository.CreateReport(reportToBeCreated);
        }

        public Result ReviewReport(IModerationStrategy moderationStrategy, Report report)
        {
            return moderationStrategy.ReviewReport(report);
        }


        //Former implementation -- might want to use it
        //public Result Moderate()

        //public Result ReviewUserReport(Guid reportId, bool ban, bool restrictAllPostsMadeByUser)
        //{
        //    Result resultOfWholeReviewing = new Result(false, "Something went wrong");
        //    UserReport? userReportToBeReviewed = _reportRepository.GetReportById(reportId) as UserReport;

        //    if (userReportToBeReviewed != null)
        //    {
        //        if (ban)
        //        {
        //            User userToBeReviewed = userReportToBeReviewed.ReportedUser;

        //            Result resultOfTogglingUserBan = _userService.ToggleUserBan(userToBeReviewed.Id, ban);

        //            if (resultOfTogglingUserBan.IsSuccess)
        //            {
        //                if (restrictAllPostsMadeByUser)
        //                {
        //                    Result resultOfRestrictingAllPostsMadeByUser = _postService.RestrictAllPostsMadeByUserByTheirId(userToBeReviewed.Id);

        //                    if (resultOfRestrictingAllPostsMadeByUser.IsSuccess)
        //                    {
        //                        resultOfWholeReviewing = new Result(true, "User has been banned and all their posts has been restricted.");
        //                    }
        //                    else
        //                    {
        //                        resultOfWholeReviewing = new Result(false, "User has been banned and BUT NOT ALL OF THEIR POSTS HAVE BEEN RESTRICTED due to issue. Please try again and report to ADMIN.");
        //                    }
        //                }
        //                resultOfWholeReviewing = new Result(true, "User has been banned.");
        //            }
        //            else
        //            {
        //                resultOfWholeReviewing = new Result(false, "User has not been banned due to issue. Try again");
        //            }
        //        }
        //        else
        //        {
        //            resultOfWholeReviewing = new Result(true, "User has not been banned, their posts were not restricted.");
        //        }
        //    }
        //    else
        //    {
        //        return resultOfWholeReviewing = new Result(false, "Report could not be found by ID");
        //    }

        //    if (resultOfWholeReviewing.IsSuccess)
        //    {
        //        userReportToBeReviewed.Review();

        //        Result tickingUserReportAsReported = _reportRepository.UpdateReport(userReportToBeReviewed);

        //        if (tickingUserReportAsReported.IsSuccess)
        //        {
        //            resultOfWholeReviewing.Message += " Review tagged as reviewed";
        //        }
        //        else
        //        {
        //            resultOfWholeReviewing.Message += " BUT THE REVIEW HAS NOT BEEN TAGGED AS REVIEWD. TRY DOING IT MANUALLY AND CONTACT ADMIN!";
        //        }
        //    }

        //    return resultOfWholeReviewing;
        //}

        //public Result ReviewPostReport(Guid reportId, bool restrictPost, bool ban, bool restrictAllPostsMadeByUser)
        //{
        //    Result resultOfWholeReviewing = new Result(false, "Something went wrong.");

        //    PostReport? postReportToBeReviewed = _reportRepository.GetReportById(reportId) as PostReport;

        //    if (postReportToBeReviewed != null)
        //    {
        //        if (restrictPost)
        //        {
        //            Result resultOfRestrictingPost = _postService.TogglePostRestriction(reportId, restrictPost);

        //            if (resultOfRestrictingPost.IsSuccess)
        //            {
        //                if (ban)
        //                {
        //                    User userToBeReviewed = postReportToBeReviewed.ReportedPost.Author;

        //                    Result resultOfTogglingUserBan = _userService.ToggleUserBan(userToBeReviewed.Id, ban);

        //                    if (resultOfTogglingUserBan.IsSuccess)
        //                    {
        //                        if (restrictAllPostsMadeByUser)
        //                        {
        //                            Result resultOfRestrictingAllPostsMadeByUser = _postService.RestrictAllPostsMadeByUserByTheirId(userToBeReviewed.Id);

        //                            if (resultOfRestrictingAllPostsMadeByUser.IsSuccess)
        //                            {
        //                                resultOfWholeReviewing = new Result(true, "Post has been restricted. User has been banned and all their posts has been restricted.");
        //                            }
        //                            else
        //                            {
        //                                resultOfWholeReviewing = new Result(false, "Post has been restircted. User has been banned and BUT NOT ALL OF THEIR POSTS HAVE BEEN RESTRICTED due to issue. Please try again and report to ADMIN.");
        //                            }
        //                        }
        //                        resultOfWholeReviewing = new Result(true, "User has been banned. Please try again and report to ADMIN.");
        //                    }
        //                    else
        //                    {
        //                        resultOfWholeReviewing = new Result(false, "Post was restricted, but the user has not been banned due to issue. Try again");
        //                    }
        //                }
        //                else
        //                {
        //                    resultOfWholeReviewing = new Result(true, "User has not been banned, their posts were not restricted.");
        //                }
        //            }
        //            else
        //            {
        //                resultOfWholeReviewing = new Result(false, "Something went wrong. Post was not restricted due to issue");
        //            }
        //        }
        //        else
        //        {
        //            resultOfWholeReviewing = new Result(true, "Post was not restricted. User was not banned. Their posts were not restricted");
        //        }
        //    }
        //    else
        //    {
        //        return new Result(false, "Could not find report by its id. CRITICAL ISSUE");
        //    }

        //    if (resultOfWholeReviewing.IsSuccess)
        //    {
        //        postReportToBeReviewed.Review();

        //        Result tickingUserReportAsReported = _reportRepository.UpdateReport(postReportToBeReviewed);

        //        if (tickingUserReportAsReported.IsSuccess)
        //        {
        //            resultOfWholeReviewing.Message += " Review tagged as reviewed";
        //        }
        //        else
        //        {
        //            resultOfWholeReviewing.Message += " BUT THE REVIEW HAS NOT BEEN TAGGED AS REVIEWD. TRY DOING IT MANUALLY AND CONTACT ADMIN!";
        //        }
        //    }

        //    return resultOfWholeReviewing;
        //}

        //public Result ReviewUserReport(Guid reportId, bool ban, bool restrictAllPostsMadeByUser)
        //{
        //    Result resultOfWholeReviewing = new Result(false, "Something went wrong");
        //    UserReport? userReportToBeReviewed = _reportRepository.GetReportById(reportId) as UserReport;

        //    if (userReportToBeReviewed != null)
        //    {
        //        resultOfWholeReviewing = userReportToBeReviewed.ReviewReport(ban);

        //        if (_userService.UpdateUser(userReportToBeReviewed.ReportedUser).IsSuccess)
        //        {
        //            if (restrictAllPostsMadeByUser)
        //            {
        //                Result resultOfRestrictingAllPostsMadeByUser = _postService.RestrictAllPostsMadeByUserByTheirId(userReportToBeReviewed.ReportedUser.Id);

        //                if (resultOfRestrictingAllPostsMadeByUser.IsSuccess)
        //                {
        //                    resultOfWholeReviewing.Message += " All of the user's posts has been restricted.";
        //                }
        //                else
        //                {
        //                    resultOfWholeReviewing.IsSuccess = false;
        //                    resultOfWholeReviewing.Message += " BUT NOT ALL OFF THE POSTS HAS BEEN RESTRICTED.";
        //                }
        //            }
        //        }
        //        else
        //        {
        //            resultOfWholeReviewing = new Result(false, "Updating user failed.");
        //        }
        //    }
        //    else
        //    {
        //        return resultOfWholeReviewing = new Result(false, "Report could not be found by ID");
        //    }

        //    if (resultOfWholeReviewing.IsSuccess)
        //    {
        //        userReportToBeReviewed.Review();

        //        Result tickingUserReportAsReported = _reportRepository.UpdateReport(userReportToBeReviewed);

        //        if (tickingUserReportAsReported.IsSuccess)
        //        {
        //            resultOfWholeReviewing.Message += " Review tagged as reviewed";
        //        }
        //        else
        //        {
        //            resultOfWholeReviewing.Message += " THE REVIEW HAS NOT BEEN TAGGED AS REVIEWD. TRY DOING IT MANUALLY AND CONTACT ADMIN!";
        //        }
        //    }

        //    return resultOfWholeReviewing;
        //}
        //public Result ReviewPostReport(Guid reportId, bool restrictPost, bool ban, bool restrictAllPostsMadeByUser)
        //{
        //    Result resultOfWholeReviewing = new Result(false, "Something went wrong.");

        //    PostReport? postReportToBeReviewed = _reportRepository.GetReportById(reportId) as PostReport;

        //    if (postReportToBeReviewed != null)
        //    {
        //        resultOfWholeReviewing = postReportToBeReviewed.ReviewReport(ban, restrictPost);

        //        if (_postService.TogglePostRestriction(postReportToBeReviewed.ReportedPost.Id, restrictPost).IsSuccess && _userService.UpdateUser(postReportToBeReviewed.ReportedPost.Author).IsSuccess)
        //        {
        //            if (restrictAllPostsMadeByUser)
        //            {
        //                if (_postService.RestrictAllPostsMadeByUserByTheirId(postReportToBeReviewed.ReportedPost.Author.Id).IsSuccess)
        //                {
        //                    resultOfWholeReviewing.Message += " All of their post have been restricted.";
        //                }
        //                else
        //                {
        //                    resultOfWholeReviewing.IsSuccess = false;
        //                    resultOfWholeReviewing.Message += " BUT SOMETHING WENT WRONG DURING RESTRICTING REST OF THE USER'S POSTS.TRY AGAIN LATER";
        //                }
        //            }
        //        }
        //        else
        //        {
        //            return new Result(false, "Failed updating restriction and ban");
        //        }
        //    }
        //    else
        //    {
        //        return new Result(false, "Could not find report by its id. CRITICAL ISSUE");
        //    }

        //    if (resultOfWholeReviewing.IsSuccess)
        //    {
        //        postReportToBeReviewed.Review();

        //        Result tickingUserReportAsReported = _reportRepository.UpdateReport(postReportToBeReviewed);

        //        if (tickingUserReportAsReported.IsSuccess)
        //        {
        //            resultOfWholeReviewing.Message += " Review tagged as reviewed";
        //        }
        //        else
        //        {
        //            resultOfWholeReviewing.Message += " BUT THE REVIEW HAS NOT BEEN TAGGED AS REVIEWD. TRY DOING IT MANUALLY AND CONTACT ADMIN!";
        //        }
        //    }

        //    return resultOfWholeReviewing;
        //}
    }
}
