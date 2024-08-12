using Domains.ReportClasses;
using Domains.ResultClasses;
using Domains.UserClasses;
using LogicLayer.ModerationClasses.ModerationRepositoriesInitializators;
using LogicLayer.ModerationClasses.ModerationReviews;
using LogicLayer.ModerationClasses.ModerationStrategies;
using LogicLayer.ReportStrategies.SortAndFilterReports;
using LogicLayer.Services;

namespace WindowsApp.ReportForms
{
    public partial class UserReportForm : Form
    {
        ReportService _reportService = new ReportService(new DependencyBuilderHelper().ReportRepository, new DependencyBuilderHelper().PostRepository, new DependencyBuilderHelper().UserRepository, new DependencyBuilderHelper().NotificationRepository);

        private User _loggedInAdmin;
        private UserReport _userReport;
        private List<Report> _allUsersReport;

        public UserReportForm(User loggedInAdmin, UserReport userReport)
        {
            InitializeComponent();

            _loggedInAdmin = loggedInAdmin;
            _userReport = userReport;
            GetAllUsersReport();
            FillInAllTheFields();
        }

        private void btnConfirmReview_Click(object sender, EventArgs e)
        {
            bool banReportedUser = chbxBanAuthor.Checked;
            bool restrictAllOfTheUsersPosts = chbxRestrictAllPostsByThisAuthor.Checked;

            UserModerationRepositories userModerationRepositories = new UserModerationRepositories(new DependencyBuilderHelper().ReportRepository, new DependencyBuilderHelper().UserRepository, new DependencyBuilderHelper().PostRepository, new DependencyBuilderHelper().NotificationRepository);
            UserModerationReview userModerationReview = new UserModerationReview(_loggedInAdmin, banReportedUser, restrictAllOfTheUsersPosts);
            UserModerationStrategy userModerationStrategy = new UserModerationStrategy(userModerationRepositories, userModerationReview);

            Result resultOfReviewingOperation = _reportService.ReviewReport(userModerationStrategy, _userReport);

            if (!resultOfReviewingOperation.IsSuccess)
            {
                MessageBox.Show(resultOfReviewingOperation.Message);
            }
            else
            {
                MessageBox.Show(resultOfReviewingOperation.Message);
                this.Close();
            }
        }

        private void FillInAllTheFields()
        {
            lblReportId.Text = _userReport.Id.ToString();
            lblReviewed.Text = _userReport.Reviewed.ToString();
            lblUserBan.Text = _userReport.ReportedUser.Ban.ToString();

            lblUserName.Text = _userReport.ReportedUser.UserName;
            lblEmail.Text = _userReport.ReportedUser.Email;
            lblFirstName.Text = _userReport.ReportedUser.FirstName;
            lblLastName.Text = _userReport.ReportedUser.LastName;
            lblUserRole.Text = _userReport.ReportedUser.UserRole.ToString();
            lblReportNumber.Text = _allUsersReport.Count.ToString();
        }

        private void GetAllUsersReport()
        {
            ISortFilterReports[] sortFilterReports = new ISortFilterReports[]
            {
                new FilterBySpecificUser(_userReport.ReportedUser.Id)
            };

            _allUsersReport = _reportService.SearchAndFilterReportsFromAllPostsFromRepository(sortFilterReports);
        }
    }
}
