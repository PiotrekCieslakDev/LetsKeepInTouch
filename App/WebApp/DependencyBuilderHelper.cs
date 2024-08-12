using Database.DataRepositories;
using LogicLayer.Services;
using LogicLayerInterfaces;

namespace WebApp
{
    internal class DependencyBuilderHelper
    {
        public UserService UserService { get; private set; }
        public PostService PostService { get; private set; }
        public ReportService ReportService { get; private set; }

        public DependencyBuilderHelper()
        {
            UserService = new UserService(new UserRepository());
            PostService = new PostService(new PostRepository(), new UserRepository(), new NotificationRepository());
            ReportService = new ReportService(new ReportRepository(), new PostRepository(), new UserRepository(), new NotificationRepository());
        }

    }
}
