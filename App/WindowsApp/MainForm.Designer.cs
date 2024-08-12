namespace WindowsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tpgMyProfile = new TabPage();
            groupBox1 = new GroupBox();
            btnChangeMyAccountPassword = new Button();
            label13 = new Label();
            label15 = new Label();
            tbxConfirmPassword = new TextBox();
            tbxOldPassword = new TextBox();
            label14 = new Label();
            tbxNewPassword = new TextBox();
            btnUpdateMyAccount = new Button();
            label4 = new Label();
            tbxMyAccountLastname = new TextBox();
            label3 = new Label();
            tbxMyAccountFirstname = new TextBox();
            label2 = new Label();
            tbxMyAccountEmail = new TextBox();
            label1 = new Label();
            tbxMyAccountUsername = new TextBox();
            tpgUsers = new TabPage();
            lbxUsers = new ListBox();
            chbxNotbanned = new CheckBox();
            btnUsersSearch = new Button();
            chbxBanned = new CheckBox();
            chbxVerified = new CheckBox();
            chbxRegular = new CheckBox();
            chbxAdmin = new CheckBox();
            lblUsersSearch = new Label();
            tbxUsersSearch = new TextBox();
            tpgUserManagement = new TabPage();
            btnUsersDelete = new Button();
            rdbtnVerified = new RadioButton();
            rdbtnRegular = new RadioButton();
            label11 = new Label();
            rdbtnAdmin = new RadioButton();
            chbxDeactivated = new CheckBox();
            chbxBan = new CheckBox();
            btnSearchUserForManagement = new Button();
            btnCreateUser = new Button();
            btnUpdateUser = new Button();
            label10 = new Label();
            tbxSearchUserToManagement = new TextBox();
            label9 = new Label();
            tbxUsersPassword = new TextBox();
            label5 = new Label();
            tbxUsersLastname = new TextBox();
            label6 = new Label();
            tbxUsersFirstname = new TextBox();
            label7 = new Label();
            tbxUsersEmail = new TextBox();
            label8 = new Label();
            tbxUsersUsername = new TextBox();
            tpbReports = new TabPage();
            lbxReports = new ListBox();
            btnSearchReports = new Button();
            chbxReportsReviewed = new CheckBox();
            chbxReportsNotReviewed = new CheckBox();
            chbxPostReports = new CheckBox();
            chbxUserReports = new CheckBox();
            label12 = new Label();
            tbxReportUserSearch = new TextBox();
            tabControl1.SuspendLayout();
            tpgMyProfile.SuspendLayout();
            groupBox1.SuspendLayout();
            tpgUsers.SuspendLayout();
            tpgUserManagement.SuspendLayout();
            tpbReports.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpgMyProfile);
            tabControl1.Controls.Add(tpgUsers);
            tabControl1.Controls.Add(tpgUserManagement);
            tabControl1.Controls.Add(tpbReports);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1088, 600);
            tabControl1.TabIndex = 0;
            // 
            // tpgMyProfile
            // 
            tpgMyProfile.Controls.Add(groupBox1);
            tpgMyProfile.Controls.Add(btnUpdateMyAccount);
            tpgMyProfile.Controls.Add(label4);
            tpgMyProfile.Controls.Add(tbxMyAccountLastname);
            tpgMyProfile.Controls.Add(label3);
            tpgMyProfile.Controls.Add(tbxMyAccountFirstname);
            tpgMyProfile.Controls.Add(label2);
            tpgMyProfile.Controls.Add(tbxMyAccountEmail);
            tpgMyProfile.Controls.Add(label1);
            tpgMyProfile.Controls.Add(tbxMyAccountUsername);
            tpgMyProfile.Location = new Point(4, 29);
            tpgMyProfile.Name = "tpgMyProfile";
            tpgMyProfile.Padding = new Padding(3);
            tpgMyProfile.Size = new Size(1080, 567);
            tpgMyProfile.TabIndex = 0;
            tpgMyProfile.Text = "My profile";
            tpgMyProfile.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnChangeMyAccountPassword);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(tbxConfirmPassword);
            groupBox1.Controls.Add(tbxOldPassword);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(tbxNewPassword);
            groupBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(23, 255);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(551, 293);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Change Password";
            // 
            // btnChangeMyAccountPassword
            // 
            btnChangeMyAccountPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnChangeMyAccountPassword.Location = new Point(235, 216);
            btnChangeMyAccountPassword.Name = "btnChangeMyAccountPassword";
            btnChangeMyAccountPassword.Size = new Size(285, 57);
            btnChangeMyAccountPassword.TabIndex = 10;
            btnChangeMyAccountPassword.Text = "Change password";
            btnChangeMyAccountPassword.UseVisualStyleBackColor = true;
            btnChangeMyAccountPassword.Click += btnChangeMyAccountPassword_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(13, 156);
            label13.Name = "label13";
            label13.Size = new Size(204, 31);
            label13.TabIndex = 15;
            label13.Text = "Confirm password:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(13, 57);
            label15.Name = "label15";
            label15.Size = new Size(160, 31);
            label15.TabIndex = 11;
            label15.Text = "Old password:";
            // 
            // tbxConfirmPassword
            // 
            tbxConfirmPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbxConfirmPassword.Location = new Point(223, 153);
            tbxConfirmPassword.Name = "tbxConfirmPassword";
            tbxConfirmPassword.PasswordChar = '*';
            tbxConfirmPassword.Size = new Size(322, 38);
            tbxConfirmPassword.TabIndex = 14;
            // 
            // tbxOldPassword
            // 
            tbxOldPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbxOldPassword.Location = new Point(223, 50);
            tbxOldPassword.Name = "tbxOldPassword";
            tbxOldPassword.PasswordChar = '*';
            tbxOldPassword.Size = new Size(322, 38);
            tbxOldPassword.TabIndex = 10;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(13, 107);
            label14.Name = "label14";
            label14.Size = new Size(169, 31);
            label14.TabIndex = 13;
            label14.Text = "New password:";
            // 
            // tbxNewPassword
            // 
            tbxNewPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbxNewPassword.Location = new Point(223, 104);
            tbxNewPassword.Name = "tbxNewPassword";
            tbxNewPassword.PasswordChar = '*';
            tbxNewPassword.Size = new Size(322, 38);
            tbxNewPassword.TabIndex = 12;
            // 
            // btnUpdateMyAccount
            // 
            btnUpdateMyAccount.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdateMyAccount.Location = new Point(521, 64);
            btnUpdateMyAccount.Name = "btnUpdateMyAccount";
            btnUpdateMyAccount.Size = new Size(241, 57);
            btnUpdateMyAccount.TabIndex = 8;
            btnUpdateMyAccount.Text = "Update details";
            btnUpdateMyAccount.UseVisualStyleBackColor = true;
            btnUpdateMyAccount.Click += btnUpdateMyAccount_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(23, 189);
            label4.Name = "label4";
            label4.Size = new Size(117, 31);
            label4.TabIndex = 7;
            label4.Text = "Lastname:";
            // 
            // tbxMyAccountLastname
            // 
            tbxMyAccountLastname.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbxMyAccountLastname.Location = new Point(151, 186);
            tbxMyAccountLastname.Name = "tbxMyAccountLastname";
            tbxMyAccountLastname.Size = new Size(322, 38);
            tbxMyAccountLastname.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(23, 140);
            label3.Name = "label3";
            label3.Size = new Size(119, 31);
            label3.TabIndex = 5;
            label3.Text = "Firstname:";
            // 
            // tbxMyAccountFirstname
            // 
            tbxMyAccountFirstname.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbxMyAccountFirstname.Location = new Point(151, 137);
            tbxMyAccountFirstname.Name = "tbxMyAccountFirstname";
            tbxMyAccountFirstname.Size = new Size(322, 38);
            tbxMyAccountFirstname.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(23, 90);
            label2.Name = "label2";
            label2.Size = new Size(75, 31);
            label2.TabIndex = 3;
            label2.Text = "Email:";
            // 
            // tbxMyAccountEmail
            // 
            tbxMyAccountEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbxMyAccountEmail.Location = new Point(151, 87);
            tbxMyAccountEmail.Name = "tbxMyAccountEmail";
            tbxMyAccountEmail.Size = new Size(322, 38);
            tbxMyAccountEmail.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(23, 40);
            label1.Name = "label1";
            label1.Size = new Size(122, 31);
            label1.TabIndex = 1;
            label1.Text = "Username:";
            // 
            // tbxMyAccountUsername
            // 
            tbxMyAccountUsername.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbxMyAccountUsername.Location = new Point(151, 37);
            tbxMyAccountUsername.Name = "tbxMyAccountUsername";
            tbxMyAccountUsername.Size = new Size(322, 38);
            tbxMyAccountUsername.TabIndex = 0;
            // 
            // tpgUsers
            // 
            tpgUsers.Controls.Add(lbxUsers);
            tpgUsers.Controls.Add(chbxNotbanned);
            tpgUsers.Controls.Add(btnUsersSearch);
            tpgUsers.Controls.Add(chbxBanned);
            tpgUsers.Controls.Add(chbxVerified);
            tpgUsers.Controls.Add(chbxRegular);
            tpgUsers.Controls.Add(chbxAdmin);
            tpgUsers.Controls.Add(lblUsersSearch);
            tpgUsers.Controls.Add(tbxUsersSearch);
            tpgUsers.Location = new Point(4, 29);
            tpgUsers.Name = "tpgUsers";
            tpgUsers.Padding = new Padding(3);
            tpgUsers.Size = new Size(1080, 567);
            tpgUsers.TabIndex = 1;
            tpgUsers.Text = "Users";
            tpgUsers.UseVisualStyleBackColor = true;
            // 
            // lbxUsers
            // 
            lbxUsers.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxUsers.FormattingEnabled = true;
            lbxUsers.ItemHeight = 28;
            lbxUsers.Location = new Point(395, 6);
            lbxUsers.Name = "lbxUsers";
            lbxUsers.Size = new Size(679, 536);
            lbxUsers.TabIndex = 11;
            lbxUsers.SelectedIndexChanged += lbxUsers_SelectedIndexChanged;
            // 
            // chbxNotbanned
            // 
            chbxNotbanned.AutoSize = true;
            chbxNotbanned.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chbxNotbanned.Location = new Point(131, 203);
            chbxNotbanned.Name = "chbxNotbanned";
            chbxNotbanned.Size = new Size(139, 32);
            chbxNotbanned.TabIndex = 10;
            chbxNotbanned.Text = "Not banned";
            chbxNotbanned.UseVisualStyleBackColor = true;
            // 
            // btnUsersSearch
            // 
            btnUsersSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnUsersSearch.Location = new Point(54, 294);
            btnUsersSearch.Name = "btnUsersSearch";
            btnUsersSearch.Size = new Size(221, 55);
            btnUsersSearch.TabIndex = 9;
            btnUsersSearch.Text = "Search";
            btnUsersSearch.UseVisualStyleBackColor = true;
            btnUsersSearch.Click += btnUsersSearch_Click;
            // 
            // chbxBanned
            // 
            chbxBanned.AutoSize = true;
            chbxBanned.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chbxBanned.Location = new Point(25, 203);
            chbxBanned.Name = "chbxBanned";
            chbxBanned.Size = new Size(99, 32);
            chbxBanned.TabIndex = 8;
            chbxBanned.Text = "Banned";
            chbxBanned.UseVisualStyleBackColor = true;
            // 
            // chbxVerified
            // 
            chbxVerified.AutoSize = true;
            chbxVerified.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chbxVerified.Location = new Point(130, 148);
            chbxVerified.Name = "chbxVerified";
            chbxVerified.Size = new Size(100, 32);
            chbxVerified.TabIndex = 6;
            chbxVerified.Text = "Verified";
            chbxVerified.UseVisualStyleBackColor = true;
            // 
            // chbxRegular
            // 
            chbxRegular.AutoSize = true;
            chbxRegular.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chbxRegular.Location = new Point(24, 148);
            chbxRegular.Name = "chbxRegular";
            chbxRegular.Size = new Size(100, 32);
            chbxRegular.TabIndex = 5;
            chbxRegular.Text = "Regular";
            chbxRegular.UseVisualStyleBackColor = true;
            // 
            // chbxAdmin
            // 
            chbxAdmin.AutoSize = true;
            chbxAdmin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chbxAdmin.Location = new Point(25, 101);
            chbxAdmin.Name = "chbxAdmin";
            chbxAdmin.Size = new Size(92, 32);
            chbxAdmin.TabIndex = 4;
            chbxAdmin.Text = "Admin";
            chbxAdmin.UseVisualStyleBackColor = true;
            // 
            // lblUsersSearch
            // 
            lblUsersSearch.AutoSize = true;
            lblUsersSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsersSearch.Location = new Point(25, 35);
            lblUsersSearch.Name = "lblUsersSearch";
            lblUsersSearch.Size = new Size(87, 31);
            lblUsersSearch.TabIndex = 3;
            lblUsersSearch.Text = "Search:";
            // 
            // tbxUsersSearch
            // 
            tbxUsersSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbxUsersSearch.Location = new Point(144, 32);
            tbxUsersSearch.Name = "tbxUsersSearch";
            tbxUsersSearch.Size = new Size(245, 38);
            tbxUsersSearch.TabIndex = 2;
            // 
            // tpgUserManagement
            // 
            tpgUserManagement.Controls.Add(btnUsersDelete);
            tpgUserManagement.Controls.Add(rdbtnVerified);
            tpgUserManagement.Controls.Add(rdbtnRegular);
            tpgUserManagement.Controls.Add(label11);
            tpgUserManagement.Controls.Add(rdbtnAdmin);
            tpgUserManagement.Controls.Add(chbxDeactivated);
            tpgUserManagement.Controls.Add(chbxBan);
            tpgUserManagement.Controls.Add(btnSearchUserForManagement);
            tpgUserManagement.Controls.Add(btnCreateUser);
            tpgUserManagement.Controls.Add(btnUpdateUser);
            tpgUserManagement.Controls.Add(label10);
            tpgUserManagement.Controls.Add(tbxSearchUserToManagement);
            tpgUserManagement.Controls.Add(label9);
            tpgUserManagement.Controls.Add(tbxUsersPassword);
            tpgUserManagement.Controls.Add(label5);
            tpgUserManagement.Controls.Add(tbxUsersLastname);
            tpgUserManagement.Controls.Add(label6);
            tpgUserManagement.Controls.Add(tbxUsersFirstname);
            tpgUserManagement.Controls.Add(label7);
            tpgUserManagement.Controls.Add(tbxUsersEmail);
            tpgUserManagement.Controls.Add(label8);
            tpgUserManagement.Controls.Add(tbxUsersUsername);
            tpgUserManagement.Location = new Point(4, 29);
            tpgUserManagement.Name = "tpgUserManagement";
            tpgUserManagement.Padding = new Padding(3);
            tpgUserManagement.Size = new Size(1080, 567);
            tpgUserManagement.TabIndex = 3;
            tpgUserManagement.Text = "Users management";
            tpgUserManagement.UseVisualStyleBackColor = true;
            tpgUserManagement.Click += tpgUserManagement_Click;
            // 
            // btnUsersDelete
            // 
            btnUsersDelete.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnUsersDelete.Location = new Point(330, 450);
            btnUsersDelete.Name = "btnUsersDelete";
            btnUsersDelete.Size = new Size(139, 49);
            btnUsersDelete.TabIndex = 29;
            btnUsersDelete.Text = "Delete";
            btnUsersDelete.UseVisualStyleBackColor = true;
            btnUsersDelete.Click += btnUsersDelete_Click;
            // 
            // rdbtnVerified
            // 
            rdbtnVerified.AutoSize = true;
            rdbtnVerified.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            rdbtnVerified.Location = new Point(377, 342);
            rdbtnVerified.Name = "rdbtnVerified";
            rdbtnVerified.Size = new Size(113, 35);
            rdbtnVerified.TabIndex = 28;
            rdbtnVerified.TabStop = true;
            rdbtnVerified.Text = "Verified";
            rdbtnVerified.UseVisualStyleBackColor = true;
            // 
            // rdbtnRegular
            // 
            rdbtnRegular.AutoSize = true;
            rdbtnRegular.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            rdbtnRegular.Location = new Point(258, 342);
            rdbtnRegular.Name = "rdbtnRegular";
            rdbtnRegular.Size = new Size(113, 35);
            rdbtnRegular.TabIndex = 27;
            rdbtnRegular.TabStop = true;
            rdbtnRegular.Text = "Regular";
            rdbtnRegular.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(21, 344);
            label11.Name = "label11";
            label11.Size = new Size(110, 31);
            label11.TabIndex = 26;
            label11.Text = "User role:";
            // 
            // rdbtnAdmin
            // 
            rdbtnAdmin.AutoSize = true;
            rdbtnAdmin.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            rdbtnAdmin.Location = new Point(149, 342);
            rdbtnAdmin.Name = "rdbtnAdmin";
            rdbtnAdmin.Size = new Size(103, 35);
            rdbtnAdmin.TabIndex = 25;
            rdbtnAdmin.TabStop = true;
            rdbtnAdmin.Text = "Admin";
            rdbtnAdmin.UseVisualStyleBackColor = true;
            // 
            // chbxDeactivated
            // 
            chbxDeactivated.AutoSize = true;
            chbxDeactivated.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            chbxDeactivated.Location = new Point(258, 392);
            chbxDeactivated.Name = "chbxDeactivated";
            chbxDeactivated.Size = new Size(158, 35);
            chbxDeactivated.TabIndex = 24;
            chbxDeactivated.Text = "Deacitvated";
            chbxDeactivated.UseVisualStyleBackColor = true;
            // 
            // chbxBan
            // 
            chbxBan.AutoSize = true;
            chbxBan.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            chbxBan.Location = new Point(154, 392);
            chbxBan.Name = "chbxBan";
            chbxBan.Size = new Size(74, 35);
            chbxBan.TabIndex = 23;
            chbxBan.Text = "Ban";
            chbxBan.UseVisualStyleBackColor = true;
            // 
            // btnSearchUserForManagement
            // 
            btnSearchUserForManagement.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearchUserForManagement.Location = new Point(492, 20);
            btnSearchUserForManagement.Name = "btnSearchUserForManagement";
            btnSearchUserForManagement.Size = new Size(139, 49);
            btnSearchUserForManagement.TabIndex = 22;
            btnSearchUserForManagement.Text = "Search";
            btnSearchUserForManagement.UseVisualStyleBackColor = true;
            btnSearchUserForManagement.Click += btnSearchUserForManagement_Click;
            // 
            // btnCreateUser
            // 
            btnCreateUser.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreateUser.Location = new Point(171, 450);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(139, 49);
            btnCreateUser.TabIndex = 21;
            btnCreateUser.Text = "Create";
            btnCreateUser.UseVisualStyleBackColor = true;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdateUser.Location = new Point(10, 450);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(139, 49);
            btnUpdateUser.TabIndex = 20;
            btnUpdateUser.Text = "Update";
            btnUpdateUser.UseVisualStyleBackColor = true;
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(21, 29);
            label10.Name = "label10";
            label10.Size = new Size(144, 31);
            label10.TabIndex = 19;
            label10.Text = "Search by id:";
            // 
            // tbxSearchUserToManagement
            // 
            tbxSearchUserToManagement.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbxSearchUserToManagement.Location = new Point(171, 26);
            tbxSearchUserToManagement.Name = "tbxSearchUserToManagement";
            tbxSearchUserToManagement.Size = new Size(267, 38);
            tbxSearchUserToManagement.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(21, 289);
            label9.Name = "label9";
            label9.Size = new Size(115, 31);
            label9.TabIndex = 17;
            label9.Text = "Password:";
            // 
            // tbxUsersPassword
            // 
            tbxUsersPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbxUsersPassword.Location = new Point(149, 286);
            tbxUsersPassword.Name = "tbxUsersPassword";
            tbxUsersPassword.Size = new Size(289, 38);
            tbxUsersPassword.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(21, 237);
            label5.Name = "label5";
            label5.Size = new Size(117, 31);
            label5.TabIndex = 15;
            label5.Text = "Lastname:";
            // 
            // tbxUsersLastname
            // 
            tbxUsersLastname.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbxUsersLastname.Location = new Point(149, 229);
            tbxUsersLastname.Name = "tbxUsersLastname";
            tbxUsersLastname.Size = new Size(289, 38);
            tbxUsersLastname.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(21, 188);
            label6.Name = "label6";
            label6.Size = new Size(119, 31);
            label6.TabIndex = 13;
            label6.Text = "Firstname:";
            // 
            // tbxUsersFirstname
            // 
            tbxUsersFirstname.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbxUsersFirstname.Location = new Point(149, 185);
            tbxUsersFirstname.Name = "tbxUsersFirstname";
            tbxUsersFirstname.Size = new Size(289, 38);
            tbxUsersFirstname.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(21, 138);
            label7.Name = "label7";
            label7.Size = new Size(75, 31);
            label7.TabIndex = 11;
            label7.Text = "Email:";
            // 
            // tbxUsersEmail
            // 
            tbxUsersEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbxUsersEmail.Location = new Point(149, 135);
            tbxUsersEmail.Name = "tbxUsersEmail";
            tbxUsersEmail.Size = new Size(289, 38);
            tbxUsersEmail.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(21, 88);
            label8.Name = "label8";
            label8.Size = new Size(122, 31);
            label8.TabIndex = 9;
            label8.Text = "Username:";
            // 
            // tbxUsersUsername
            // 
            tbxUsersUsername.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbxUsersUsername.Location = new Point(149, 85);
            tbxUsersUsername.Name = "tbxUsersUsername";
            tbxUsersUsername.Size = new Size(289, 38);
            tbxUsersUsername.TabIndex = 8;
            // 
            // tpbReports
            // 
            tpbReports.Controls.Add(lbxReports);
            tpbReports.Controls.Add(btnSearchReports);
            tpbReports.Controls.Add(chbxReportsReviewed);
            tpbReports.Controls.Add(chbxReportsNotReviewed);
            tpbReports.Controls.Add(chbxPostReports);
            tpbReports.Controls.Add(chbxUserReports);
            tpbReports.Controls.Add(label12);
            tpbReports.Controls.Add(tbxReportUserSearch);
            tpbReports.Location = new Point(4, 29);
            tpbReports.Name = "tpbReports";
            tpbReports.Size = new Size(1080, 567);
            tpbReports.TabIndex = 2;
            tpbReports.Text = "Reports";
            tpbReports.UseVisualStyleBackColor = true;
            // 
            // lbxReports
            // 
            lbxReports.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxReports.FormattingEnabled = true;
            lbxReports.ItemHeight = 28;
            lbxReports.Location = new Point(14, 110);
            lbxReports.Name = "lbxReports";
            lbxReports.Size = new Size(1063, 424);
            lbxReports.TabIndex = 8;
            lbxReports.SelectedIndexChanged += lbxReports_SelectedIndexChanged;
            // 
            // btnSearchReports
            // 
            btnSearchReports.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearchReports.Location = new Point(893, 32);
            btnSearchReports.Name = "btnSearchReports";
            btnSearchReports.Size = new Size(174, 52);
            btnSearchReports.TabIndex = 7;
            btnSearchReports.Text = "Search";
            btnSearchReports.UseVisualStyleBackColor = true;
            btnSearchReports.Click += btnSearchReports_Click;
            // 
            // chbxReportsReviewed
            // 
            chbxReportsReviewed.AutoSize = true;
            chbxReportsReviewed.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            chbxReportsReviewed.Location = new Point(535, 12);
            chbxReportsReviewed.Name = "chbxReportsReviewed";
            chbxReportsReviewed.Size = new Size(133, 35);
            chbxReportsReviewed.TabIndex = 6;
            chbxReportsReviewed.Text = "Reviewed";
            chbxReportsReviewed.UseVisualStyleBackColor = true;
            // 
            // chbxReportsNotReviewed
            // 
            chbxReportsNotReviewed.AutoSize = true;
            chbxReportsNotReviewed.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            chbxReportsNotReviewed.Location = new Point(535, 48);
            chbxReportsNotReviewed.Name = "chbxReportsNotReviewed";
            chbxReportsNotReviewed.Size = new Size(172, 35);
            chbxReportsNotReviewed.TabIndex = 5;
            chbxReportsNotReviewed.Text = "Not reviewed";
            chbxReportsNotReviewed.UseVisualStyleBackColor = true;
            // 
            // chbxPostReports
            // 
            chbxPostReports.AutoSize = true;
            chbxPostReports.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            chbxPostReports.Location = new Point(325, 48);
            chbxPostReports.Name = "chbxPostReports";
            chbxPostReports.Size = new Size(158, 35);
            chbxPostReports.TabIndex = 4;
            chbxPostReports.Text = "Post reports";
            chbxPostReports.UseVisualStyleBackColor = true;
            // 
            // chbxUserReports
            // 
            chbxUserReports.AutoSize = true;
            chbxUserReports.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            chbxUserReports.Location = new Point(325, 12);
            chbxUserReports.Name = "chbxUserReports";
            chbxUserReports.Size = new Size(161, 35);
            chbxUserReports.TabIndex = 3;
            chbxUserReports.Text = "User reports";
            chbxUserReports.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(14, 12);
            label12.Name = "label12";
            label12.Size = new Size(65, 31);
            label12.TabIndex = 2;
            label12.Text = "User:";
            // 
            // tbxReportUserSearch
            // 
            tbxReportUserSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbxReportUserSearch.Location = new Point(14, 46);
            tbxReportUserSearch.Name = "tbxReportUserSearch";
            tbxReportUserSearch.Size = new Size(227, 38);
            tbxReportUserSearch.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1112, 624);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "MainForm";
            tabControl1.ResumeLayout(false);
            tpgMyProfile.ResumeLayout(false);
            tpgMyProfile.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tpgUsers.ResumeLayout(false);
            tpgUsers.PerformLayout();
            tpgUserManagement.ResumeLayout(false);
            tpgUserManagement.PerformLayout();
            tpbReports.ResumeLayout(false);
            tpbReports.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tpgMyProfile;
        private Label label4;
        private TextBox tbxMyAccountLastname;
        private Label label3;
        private TextBox tbxMyAccountFirstname;
        private Label label2;
        private TextBox tbxMyAccountEmail;
        private Label label1;
        private TextBox tbxMyAccountUsername;
        private TabPage tpgUsers;
        private TabPage tpbReports;
        private Button btnUsersSearch;
        private CheckBox chbxBanned;
        private CheckBox chbxVerified;
        private CheckBox chbxRegular;
        private CheckBox chbxAdmin;
        private Label lblUsersSearch;
        private TextBox tbxUsersSearch;
        private CheckBox chbxNotbanned;
        private TabPage tpgUserManagement;
        private Label label10;
        private TextBox tbxSearchUserToManagement;
        private Label label9;
        private TextBox tbxUsersPassword;
        private Label label5;
        private TextBox tbxUsersLastname;
        private Label label6;
        private TextBox tbxUsersFirstname;
        private Label label7;
        private TextBox tbxUsersEmail;
        private Label label8;
        private TextBox tbxUsersUsername;
        private Button btnCreateUser;
        private Button btnUpdateUser;
        private RadioButton rdbtnVerified;
        private RadioButton rdbtnRegular;
        private Label label11;
        private RadioButton rdbtnAdmin;
        private CheckBox chbxDeactivated;
        private CheckBox chbxBan;
        private Button btnSearchUserForManagement;
        private Button btnUsersDelete;
        private TextBox tbxReportUserSearch;
        private Label label12;
        private CheckBox chbxPostReports;
        private CheckBox chbxUserReports;
        private Button btnSearchReports;
        private CheckBox chbxReportsReviewed;
        private CheckBox chbxReportsNotReviewed;
        private Button btnUpdateMyAccount;
        private GroupBox groupBox1;
        private Label label13;
        private Label label15;
        private TextBox tbxConfirmPassword;
        private TextBox tbxOldPassword;
        private Label label14;
        private TextBox tbxNewPassword;
        private Button btnChangeMyAccountPassword;
        private ListBox lbxReports;
        private ListBox lbxUsers;
    }
}