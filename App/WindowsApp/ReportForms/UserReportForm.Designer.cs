namespace WindowsApp.ReportForms
{
    partial class UserReportForm
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
            label11 = new Label();
            label10 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            lblReportId = new Label();
            label2 = new Label();
            lblReviewed = new Label();
            lblUserBan = new Label();
            label3 = new Label();
            label4 = new Label();
            lblUserRole = new Label();
            lblLastName = new Label();
            lblFirstName = new Label();
            lblEmail = new Label();
            lblUserName = new Label();
            groupBox1 = new GroupBox();
            chbxRestrictAllPostsByThisAuthor = new CheckBox();
            btnConfirmReview = new Button();
            chbxBanAuthor = new CheckBox();
            lblReportNumber = new Label();
            label9 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(12, 361);
            label11.Name = "label11";
            label11.Size = new Size(110, 31);
            label11.TabIndex = 42;
            label11.Text = "User role:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(12, 9);
            label10.Name = "label10";
            label10.Size = new Size(113, 31);
            label10.TabIndex = 40;
            label10.Text = "Report id:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 320);
            label5.Name = "label5";
            label5.Size = new Size(117, 31);
            label5.TabIndex = 36;
            label5.Text = "Lastname:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(12, 279);
            label6.Name = "label6";
            label6.Size = new Size(119, 31);
            label6.TabIndex = 34;
            label6.Text = "Firstname:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(12, 238);
            label7.Name = "label7";
            label7.Size = new Size(75, 31);
            label7.TabIndex = 32;
            label7.Text = "Email:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(12, 197);
            label8.Name = "label8";
            label8.Size = new Size(122, 31);
            label8.TabIndex = 30;
            label8.Text = "Username:";
            // 
            // lblReportId
            // 
            lblReportId.AutoSize = true;
            lblReportId.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblReportId.Location = new Point(185, 9);
            lblReportId.Name = "lblReportId";
            lblReportId.Size = new Size(135, 31);
            lblReportId.TabIndex = 43;
            lblReportId.Text = "<report id>";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(116, 31);
            label2.TabIndex = 44;
            label2.Text = "Reviewed:";
            // 
            // lblReviewed
            // 
            lblReviewed.AutoSize = true;
            lblReviewed.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblReviewed.Location = new Point(185, 49);
            lblReviewed.Name = "lblReviewed";
            lblReviewed.Size = new Size(138, 31);
            lblReviewed.TabIndex = 45;
            lblReviewed.Text = "<reviewed>";
            // 
            // lblUserBan
            // 
            lblUserBan.AutoSize = true;
            lblUserBan.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblUserBan.Location = new Point(185, 90);
            lblUserBan.Name = "lblUserBan";
            lblUserBan.Size = new Size(134, 31);
            lblUserBan.TabIndex = 47;
            lblUserBan.Text = "<user ban>";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 90);
            label3.Name = "label3";
            label3.Size = new Size(171, 31);
            label3.TabIndex = 46;
            label3.Text = "User is banned:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 150);
            label4.Name = "label4";
            label4.Size = new Size(197, 38);
            label4.TabIndex = 48;
            label4.Text = "Reported user:";
            // 
            // lblUserRole
            // 
            lblUserRole.AutoSize = true;
            lblUserRole.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblUserRole.Location = new Point(140, 361);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(134, 31);
            lblUserRole.TabIndex = 53;
            lblUserRole.Text = "<user role>";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblLastName.Location = new Point(140, 320);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(139, 31);
            lblLastName.TabIndex = 52;
            lblLastName.Text = "<lastname>";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblFirstName.Location = new Point(140, 279);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(142, 31);
            lblFirstName.TabIndex = 51;
            lblFirstName.Text = "<firstname>";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmail.Location = new Point(140, 238);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(102, 31);
            lblEmail.TabIndex = 50;
            lblEmail.Text = "<email>";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblUserName.Location = new Point(140, 197);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(146, 31);
            lblUserName.TabIndex = 49;
            lblUserName.Text = "<username>";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chbxRestrictAllPostsByThisAuthor);
            groupBox1.Controls.Add(btnConfirmReview);
            groupBox1.Controls.Add(chbxBanAuthor);
            groupBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(605, 315);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(362, 195);
            groupBox1.TabIndex = 54;
            groupBox1.TabStop = false;
            groupBox1.Text = "Review report";
            // 
            // chbxRestrictAllPostsByThisAuthor
            // 
            chbxRestrictAllPostsByThisAuthor.AutoSize = true;
            chbxRestrictAllPostsByThisAuthor.Location = new Point(6, 78);
            chbxRestrictAllPostsByThisAuthor.Name = "chbxRestrictAllPostsByThisAuthor";
            chbxRestrictAllPostsByThisAuthor.Size = new Size(350, 35);
            chbxRestrictAllPostsByThisAuthor.TabIndex = 3;
            chbxRestrictAllPostsByThisAuthor.Text = "Restrict all posts by this author";
            chbxRestrictAllPostsByThisAuthor.UseVisualStyleBackColor = true;
            // 
            // btnConfirmReview
            // 
            btnConfirmReview.Location = new Point(80, 130);
            btnConfirmReview.Name = "btnConfirmReview";
            btnConfirmReview.Size = new Size(207, 52);
            btnConfirmReview.TabIndex = 2;
            btnConfirmReview.Text = "Confirm review";
            btnConfirmReview.UseVisualStyleBackColor = true;
            btnConfirmReview.Click += btnConfirmReview_Click;
            // 
            // chbxBanAuthor
            // 
            chbxBanAuthor.AutoSize = true;
            chbxBanAuthor.Location = new Point(6, 37);
            chbxBanAuthor.Name = "chbxBanAuthor";
            chbxBanAuthor.Size = new Size(150, 35);
            chbxBanAuthor.TabIndex = 1;
            chbxBanAuthor.Text = "Ban Author";
            chbxBanAuthor.UseVisualStyleBackColor = true;
            // 
            // lblReportNumber
            // 
            lblReportNumber.AutoSize = true;
            lblReportNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblReportNumber.Location = new Point(430, 429);
            lblReportNumber.Name = "lblReportNumber";
            lblReportNumber.Size = new Size(126, 31);
            lblReportNumber.TabIndex = 56;
            lblReportNumber.Text = "<number>";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(12, 429);
            label9.Name = "label9";
            label9.Size = new Size(421, 31);
            label9.TabIndex = 55;
            label9.Text = "How many times this user was reported:";
            // 
            // UserReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(979, 522);
            Controls.Add(lblReportNumber);
            Controls.Add(label9);
            Controls.Add(groupBox1);
            Controls.Add(lblUserRole);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(lblEmail);
            Controls.Add(lblUserName);
            Controls.Add(label4);
            Controls.Add(lblUserBan);
            Controls.Add(label3);
            Controls.Add(lblReviewed);
            Controls.Add(label2);
            Controls.Add(lblReportId);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Name = "UserReportForm";
            Text = "UserReport";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label11;
        private Label label10;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lblReportId;
        private Label label2;
        private Label lblReviewed;
        private Label lblUserBan;
        private Label label3;
        private Label label4;
        private Label lblUserRole;
        private Label lblLastName;
        private Label lblFirstName;
        private Label lblEmail;
        private Label lblUserName;
        private GroupBox groupBox1;
        private CheckBox chbxRestrictAllPostsByThisAuthor;
        private Button btnConfirmReview;
        private CheckBox chbxBanAuthor;
        private Label lblReportNumber;
        private Label label9;
    }
}