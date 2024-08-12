using DataAccessLayerInterfaces;
using Domains.PostClasses;
using Domains.ReportClasses;
using Domains.ResultClasses;
using Domains.UserClasses;
using LogicLayer;
using LogicLayer.ModerationClasses.ModerationRepositoriesInitializators;
using LogicLayer.ModerationClasses.ModerationReviews;
using LogicLayer.ModerationClasses.ModerationStrategies;
using LogicLayer.Services;

namespace WindowsApp.ReportForms
{
    public partial class PostReportForm : Form
    {
        IReportRepository _reportRepository = new DependencyBuilderHelper().ReportRepository;
        IPostRepository _postRepository = new DependencyBuilderHelper().PostRepository;
        IUserRepository _userRepository = new DependencyBuilderHelper().UserRepository;
        INotificationRepository _notificationRepository = new DependencyBuilderHelper().NotificationRepository;

        ReportService _reportService = new ReportService(new DependencyBuilderHelper().ReportRepository, new DependencyBuilderHelper().PostRepository, new DependencyBuilderHelper().UserRepository, new DependencyBuilderHelper().NotificationRepository);

        private PostReport _postReport;
        private User _loggedInAdmin;

        public PostReportForm(User loggedInAdmin, PostReport postReport)
        {
            InitializeComponent();

            _postReport = postReport;
            _loggedInAdmin = loggedInAdmin;
            FillAllFields();
        }

        private void FillAllFields()
        {
            lblPostId.Text = _postReport.Id.ToString();
            if (_postReport.Reviewed)
            {
                lblReviewed.Text = "True";
            }
            else
            {
                lblReviewed.Text = "False";
            }
            if (_postReport.ReportedPost.Author.Ban)
            {
                lblUserBan.Text = "True";
            }
            else
            {
                lblUserBan.Text = "False";
            }

            lblPostAuthor.Text = _postReport.ReportedPost.Author.GetFullNameWithUserNameAndEmail();
            lblDateOfPosting.Text = _postReport.ReportedPost.GetFirstPostDate().ToString();
            if (_postReport.ReportedPost.Deleted)
            {
                lblDeleted.Text = "True";
            }
            else
            {
                lblDeleted.Text = "False";
            }
            if (_postReport.ReportedPost.Restricted)
            {
                lblRestricted.Text = "True";
            }
            else
            {
                lblRestricted.Text = "False";
            }

            foreach (PostContent postContent in _postReport.ReportedPost.PostContents)
            {
                rchtbxPostContent.Text = "First version: \n";
                rchtbxPostContent.Text += postContent.CreationTime;
                rchtbxPostContent.Text += "\nContent:\n";
                rchtbxPostContent.Text += postContent.ContentText;
                rchtbxPostContent.Text += "\n\n";
            }
        }

        private void btnConfirmReview_Click(object sender, EventArgs e)
        {
            bool banAuthor = chbxBanAuthor.Checked;
            bool restrictPost = chbxRestrictPost.Checked;
            bool restrictAllPostsByThisAuthor = chbxRestrictAllPostsByThisAuthor.Checked;

            PostModerationReview postModerationReview = new PostModerationReview(_loggedInAdmin, restrictPost, banAuthor, restrictAllPostsByThisAuthor);
            PostModerationRepositories postModerationRepositories = new PostModerationRepositories(_reportRepository, _userRepository, _postRepository, _notificationRepository);

            PostModerationStrategy postModerationStrategy = new PostModerationStrategy(postModerationRepositories, postModerationReview);
            Result resultOfReviewingOperation = _reportService.ReviewReport(postModerationStrategy, _postReport);
            
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
    }
}
