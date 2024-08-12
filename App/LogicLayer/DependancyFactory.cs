using DataAccessLayerInterfaces;
using Database.DataRepositories;

namespace LogicLayer
{
    public class DependancyFactory
    {
        public readonly IPostRepository _postRepository;
        public readonly IUserRepository _userRepository;
        public readonly IReportRepository _reportRepository;
        public readonly INotificationRepository _notificationRepository;

        public DependancyFactory()
        {
            _postRepository = new PostRepository();
            _userRepository = new UserRepository();
            _reportRepository = new ReportRepository();
            _notificationRepository = new NotificationRepository(); 
        }
    }
}
