using DataAccessLayerInterfaces;

namespace LogicLayer.ModerationClasses.ModerationRepositoriesInitializators
{
    public class UserModerationRepositories : ModerationRepositories
    {
        internal readonly IUserRepository _userRepository;
        internal readonly IPostRepository _postRepository;
        internal readonly INotificationRepository _notificationRepository;

        public UserModerationRepositories(IReportRepository reportRepository, IUserRepository userRepository, IPostRepository postRepository, INotificationRepository notificationRepository) : base(reportRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _notificationRepository = notificationRepository;
        }
    }
}
