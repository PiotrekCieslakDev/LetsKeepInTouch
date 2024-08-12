using Database.DataRepositories;
using LogicLayer.Services;

namespace WindowsApp
{
    internal class DependencyBuilderHelper
    {
        internal UserService UserService { get; private set; }
        internal PostService PostService { get; private set; }
        internal ReportService ReportService { get; private set; }
        internal NotificationService NotificationService { get; private set; }

        internal UserRepository UserRepository { get; private set; }
        internal PostRepository PostRepository { get; private set; }
        internal ReportRepository ReportRepository { get; private set; }
        internal NotificationRepository NotificationRepository { get; private set; }


        internal DependencyBuilderHelper()
        {
            UserService = new UserService(new UserRepository());
            PostService = new PostService(new PostRepository(), new UserRepository(), new NotificationRepository());
            ReportService = new ReportService(new ReportRepository(), new PostRepository(),new UserRepository(), new NotificationRepository());
            NotificationService = new NotificationService(new NotificationRepository());

            UserRepository = new UserRepository();
            PostRepository = new PostRepository();
            ReportRepository = new ReportRepository();
            NotificationRepository = new NotificationRepository();
        }
    }
}
