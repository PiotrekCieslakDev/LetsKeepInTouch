using Database.DataRepositories;
using Domains.ReportClasses;
using Domains.ResultClasses;
using Domains.UserClasses;
using Enums;
using LogicLayer.ReportStrategies;
using LogicLayer.ReportStrategies.SortAndFilterReports;
using LogicLayer.Services;
using LogicLayer.UserStrategies.UsersSortingFiltering;
using Microsoft.IdentityModel.Tokens;
using WindowsApp.ReportForms;

namespace WindowsApp
{
    public partial class MainForm : Form
    {
        UserService _userService = new UserService(new UserRepository());
        ReportService _reportService = new ReportService(new ReportRepository(), new PostRepository(), new UserRepository(), new NotificationRepository());

        User _loggedInUser;
        User? _userToBeUpdated;

        public MainForm(User loggedInUser)
        {
            InitializeComponent();

            _loggedInUser = loggedInUser;
            RefreshMyAccountFields();
        }

        #region Users Management Tab
        private void btnUsersSearch_Click(object sender, EventArgs e)
        {
            List<UserRole> userRoles = new List<UserRole>();
            if (chbxAdmin.Checked)
            {
                userRoles.Add(UserRole.Admin);
            }
            if (chbxRegular.Checked)
            {
                userRoles.Add(UserRole.Regular);
            }
            if (chbxVerified.Checked)
            {
                userRoles.Add(UserRole.Verified);
            }

            UserRole[] chosenUserRoles = userRoles.ToArray();

            List<User> users = null;
            List<ISortFilterUser> sortFilterUserStrategies = new List<ISortFilterUser>();

            if (tbxUsersSearch.Text != string.Empty)
            {
                SearchUsersByNamesAndEmail searchUsersByNamesAndEmail = new SearchUsersByNamesAndEmail(tbxUsersSearch.Text);
                sortFilterUserStrategies.Add(searchUsersByNamesAndEmail);
            }

            if (chbxBanned.Checked != chbxNotbanned.Checked)
            {
                if (chbxBanned.Checked)
                {
                    sortFilterUserStrategies.Add(new FilterUsersByBanStatus(chbxBanned.Checked));
                }
                else
                {
                    sortFilterUserStrategies.Add(new FilterUsersByBanStatus(false));
                }
            }

            if (userRoles.Count > 0)
            {
                sortFilterUserStrategies.Add(new FilterUsersByRole(chosenUserRoles));
            }
            users = _userService.GetAllUsers(sortFilterUserStrategies.ToArray());

            FillInUserListBoxWithRange(users);
        }

        private void FillInUserListBoxWithRange(List<User> givenUsers)
        {
            lbxUsers.Items.Clear();
            lbxUsers.Items.AddRange(givenUsers.ToArray());
        }

        private void FillUsersDataInUsersManagementTab(User userToFill)
        {
            tbxUsersEmail.Text = userToFill.Email;
            tbxUsersUsername.Text = userToFill.UserName;
            tbxUsersFirstname.Text = userToFill.FirstName;
            tbxUsersLastname.Text = userToFill.LastName;
            chbxBan.Checked = userToFill.Ban;
            chbxDeactivated.Checked = userToFill.Deactivated;
            switch (userToFill.UserRole)
            {
                case UserRole.Admin:
                    rdbtnAdmin.Checked = true;
                    break;
                case UserRole.Regular:
                    rdbtnRegular.Checked = true;
                    break;
                case UserRole.Verified:
                    rdbtnVerified.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void btnSearchUserForManagement_Click(object sender, EventArgs e)
        {
            if (tbxSearchUserToManagement.Text != string.Empty)
            {
                Guid idToBeSearched = Guid.Empty;
                if (Guid.TryParse(tbxSearchUserToManagement.Text, out idToBeSearched))
                {
                    _userToBeUpdated = _userService.GetUserById(idToBeSearched);

                    if (_userToBeUpdated != null)
                    {
                        FillUsersDataInUsersManagementTab(_userToBeUpdated);
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect ID");
                }
            }
            else
            {
                MessageBox.Show("Insert user's ID to be searched");
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxUsersEmail.Text) ||
                string.IsNullOrEmpty(tbxUsersUsername.Text) ||
                string.IsNullOrEmpty(tbxUsersFirstname.Text) ||
                string.IsNullOrEmpty(tbxUsersLastname.Text))
            {
                MessageBox.Show("Fill in all required fields");
            }
            else
            {
                UserRole newUsersUserRole = _userToBeUpdated.UserRole;
                if (rdbtnAdmin.Checked)
                {
                    newUsersUserRole = UserRole.Admin;
                }
                else if (rdbtnVerified.Checked)
                {
                    newUsersUserRole = UserRole.Verified;
                }
                else if (!rdbtnRegular.Checked)
                {
                    newUsersUserRole = UserRole.Regular;
                }

                _userToBeUpdated.UpdateUser(tbxUsersUsername.Text, tbxUsersEmail.Text, tbxUsersFirstname.Text, tbxUsersLastname.Text, newUsersUserRole, chbxBan.Checked, chbxDeactivated.Checked);
                if (tbxUsersPassword.Text != string.Empty)
                {
                    _userToBeUpdated.ChangePasswordByAdmin(tbxUsersPassword.Text, _loggedInUser.IsAdmin());
                }

                Result result = _userService.UpdateUser(_userToBeUpdated);

                MessageBox.Show(result.Message);

                if (result.IsSuccess)
                {
                    CleanUsersManagementFields();
                }
                else
                {
                    MessageBox.Show("Something went wrong. Try again.");
                }

            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxUsersEmail.Text) ||
                string.IsNullOrEmpty(tbxUsersUsername.Text) ||
                string.IsNullOrEmpty(tbxUsersFirstname.Text) ||
                string.IsNullOrEmpty(tbxUsersLastname.Text) ||
                string.IsNullOrEmpty(tbxUsersPassword.Text))
            {
                MessageBox.Show("Fill in all required fields");
            }
            else
            {
                UserRole newUsersUserRole = UserRole.Regular;
                if (rdbtnAdmin.Checked)
                {
                    newUsersUserRole = UserRole.Admin;
                }
                else if (rdbtnVerified.Checked)
                {
                    newUsersUserRole = UserRole.Verified;
                }

                User newUser = new User(tbxUsersFirstname.Text, tbxUsersLastname.Text, tbxUsersUsername.Text, tbxUsersEmail.Text, tbxUsersPassword.Text, newUsersUserRole);

                Result result = _userService.CreateUser(newUser);

                MessageBox.Show(result.Message);

                if (result.IsSuccess)
                {
                    CleanUsersManagementFields();
                }
                else
                {
                    MessageBox.Show("Something went wrong. Try again.");
                }

            }
        }

        private void btnUsersDelete_Click(object sender, EventArgs e)
        {
            if (_userToBeUpdated != null)
            {
                DialogResult dialogResult = MessageBox.Show($"Do you want to delete this user:\n{_userToBeUpdated.GetFullNameWithUserNameAndEmail()}", "Confirm deletion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Result resultOfDeleting = _userService.DeleteUser(_userToBeUpdated.Id);
                    MessageBox.Show(resultOfDeleting.Message);
                }
            }
            else
            {
                MessageBox.Show("Select to be deleted");
            }
        }

        private void CleanUsersManagementFields()
        {
            tbxUsersEmail.Text = string.Empty;
            tbxUsersUsername.Text = string.Empty;
            tbxUsersFirstname.Text = string.Empty;
            tbxUsersLastname.Text = string.Empty;
            chbxBan.Checked = false;
            chbxDeactivated.Checked = false;
            rdbtnAdmin.Checked = false;
            rdbtnVerified.Checked = false;
            rdbtnRegular.Checked = false;
        }
        #endregion

        #region Report Management Tab
        private void btnSearchReports_Click(object sender, EventArgs e)
        {
            List<ISortFilterReports> sortFilterReportStrategies = new List<ISortFilterReports>();

            if (tbxReportUserSearch.Text != string.Empty)
            {
                sortFilterReportStrategies.Add(new FilterReportsByUserIdentifier(tbxReportUserSearch.Text));
            }
            if (chbxReportsNotReviewed.Checked != chbxReportsReviewed.Checked)
            {
                if (chbxReportsReviewed.Checked)
                {
                    sortFilterReportStrategies.Add(new SearchReviewedReportsOnly());
                }
                else
                {
                    sortFilterReportStrategies.Add(new SearchNotReviewedReportsOnly());
                }
            }
            if (chbxUserReports.Checked || chbxPostReports.Checked)
            {
                if (chbxPostReports.Checked)
                {
                    sortFilterReportStrategies.Add(new SearchPostReportsOnly());
                }
                else if (chbxUserReports.Checked)
                {
                    sortFilterReportStrategies.Add(new SearchUserReportsOnly());
                }
            }

            List<Report> processedReports = _reportService.SearchAndFilterReportsFromAllPostsFromRepository(sortFilterReportStrategies.ToArray());

            FillInReportListBoxWithRange(processedReports);
        }
        #endregion

        #region MyAccountTab
        private void RefreshMyAccountFields()
        {
            tbxMyAccountFirstname.Text = _loggedInUser.FirstName;
            tbxMyAccountLastname.Text = _loggedInUser.LastName;
            tbxMyAccountEmail.Text = _loggedInUser.Email;
            tbxMyAccountUsername.Text = _loggedInUser.UserName;
        }

        private void btnUpdateMyAccount_Click(object sender, EventArgs e)
        {
            if (tbxMyAccountFirstname.Text.IsNullOrEmpty() || tbxMyAccountLastname.Text.IsNullOrEmpty() || tbxMyAccountUsername.Text.IsNullOrEmpty() || tbxMyAccountEmail.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Error. Fill in all the required fields");
            }
            else
            {
                _loggedInUser.UpdateDetails(tbxMyAccountFirstname.Text, tbxMyAccountLastname.Text, tbxMyAccountUsername.Text, tbxMyAccountEmail.Text);
                Result result = _userService.UpdateUser(_loggedInUser);
                MessageBox.Show(result.Message);
            }
        }

        private void btnChangeMyAccountPassword_Click(object sender, EventArgs e)
        {
            if (tbxNewPassword.Text.IsNullOrEmpty() || tbxOldPassword.Text.IsNullOrEmpty() || tbxConfirmPassword.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Error. Fill in all the required fields");
            }
            else
            {
                if (!(tbxNewPassword.Text.Length <= 8))
                {
                    MessageBox.Show("New password must be at least 8 characters");
                }
                else
                {
                    if (tbxNewPassword.Text != tbxConfirmPassword.Text)
                    {
                        MessageBox.Show("Passwords must match");
                    }
                    else
                    {
                        Result resultOfPasswordChangingInLogic = _loggedInUser.ChangePasswordByItsUser(tbxOldPassword.Text, tbxNewPassword.Text, _loggedInUser.Id);
                        if (!resultOfPasswordChangingInLogic.IsSuccess)
                        {
                            MessageBox.Show(resultOfPasswordChangingInLogic.Message);
                        }
                        else
                        {
                            Result resultOfUpdatingInDatabase = _userService.UpdateUser(_loggedInUser);
                            MessageBox.Show(resultOfUpdatingInDatabase.Message);
                        }
                    }
                }
            }
        }
        #endregion

        private void lbxReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            Report? selectedReport = (Report)lbxReports.SelectedItem;
            if (selectedReport != null)
            {
                if (selectedReport is PostReport selectedPostReport)
                {
                    PostReportForm postReportForm = new PostReportForm(_loggedInUser, selectedPostReport);
                    postReportForm.ShowDialog();
                }
                else if (selectedReport is UserReport selectedUserReport)
                {
                    UserReportForm userReportForm = new UserReportForm(_loggedInUser, selectedUserReport);
                    userReportForm.ShowDialog();
                }
            }
        }

        private void FillInReportListBoxWithRange(List<Report> givenReports)
        {
            lbxReports.Items.Clear();
            lbxReports.Items.AddRange(givenReports.ToArray());
        }

        private void lbxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userToBeUpdated = (User)lbxUsers.SelectedItem;
            if (_userToBeUpdated != null)
            {
                FillUsersDataInUsersManagementTab(_userToBeUpdated);
            }
        }

        private void tpgUserManagement_Click(object sender, EventArgs e)
        {

        }
    }
}
