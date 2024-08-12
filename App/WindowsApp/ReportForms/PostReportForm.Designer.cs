namespace WindowsApp.ReportForms
{
    partial class PostReportForm
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
            lblPostAuthor = new Label();
            lblDateOfPosting = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            label1 = new Label();
            lblDeleted = new Label();
            lblRestricted = new Label();
            label4 = new Label();
            lblPostId = new Label();
            label6 = new Label();
            rchtbxPostContent = new RichTextBox();
            lblReviewed = new Label();
            label3 = new Label();
            lblUserBan = new Label();
            label7 = new Label();
            groupBox1 = new GroupBox();
            chbxRestrictAllPostsByThisAuthor = new CheckBox();
            btnConfirmReview = new Button();
            chbxBanAuthor = new CheckBox();
            chbxRestrictPost = new CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblPostAuthor
            // 
            lblPostAuthor.AutoSize = true;
            lblPostAuthor.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblPostAuthor.Location = new Point(22, 24);
            lblPostAuthor.Name = "lblPostAuthor";
            lblPostAuthor.Size = new Size(116, 31);
            lblPostAuthor.TabIndex = 0;
            lblPostAuthor.Text = "<Author>";
            // 
            // lblDateOfPosting
            // 
            lblDateOfPosting.AutoSize = true;
            lblDateOfPosting.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblDateOfPosting.Location = new Point(22, 65);
            lblDateOfPosting.Name = "lblDateOfPosting";
            lblDateOfPosting.Size = new Size(204, 31);
            lblDateOfPosting.TabIndex = 1;
            lblDateOfPosting.Text = "<Date of posting>";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(22, 106);
            label1.Name = "label1";
            label1.Size = new Size(99, 31);
            label1.TabIndex = 2;
            label1.Text = "Deleted:";
            // 
            // lblDeleted
            // 
            lblDeleted.AutoSize = true;
            lblDeleted.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblDeleted.Location = new Point(143, 106);
            lblDeleted.Name = "lblDeleted";
            lblDeleted.Size = new Size(126, 31);
            lblDeleted.TabIndex = 3;
            lblDeleted.Text = "<Deleted>";
            // 
            // lblRestricted
            // 
            lblRestricted.AutoSize = true;
            lblRestricted.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblRestricted.Location = new Point(143, 147);
            lblRestricted.Name = "lblRestricted";
            lblRestricted.Size = new Size(148, 31);
            lblRestricted.TabIndex = 5;
            lblRestricted.Text = "<Restricted>";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(22, 147);
            label4.Name = "label4";
            label4.Size = new Size(121, 31);
            label4.TabIndex = 4;
            label4.Text = "Restricted:";
            // 
            // lblPostId
            // 
            lblPostId.AutoSize = true;
            lblPostId.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblPostId.Location = new Point(541, 65);
            lblPostId.Name = "lblPostId";
            lblPostId.Size = new Size(115, 31);
            lblPostId.TabIndex = 7;
            lblPostId.Text = "<Post id>";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(416, 65);
            label6.Name = "label6";
            label6.Size = new Size(88, 31);
            label6.TabIndex = 6;
            label6.Text = "Post id:";
            // 
            // rchtbxPostContent
            // 
            rchtbxPostContent.Location = new Point(22, 197);
            rchtbxPostContent.Name = "rchtbxPostContent";
            rchtbxPostContent.Size = new Size(656, 403);
            rchtbxPostContent.TabIndex = 8;
            rchtbxPostContent.Text = "";
            // 
            // lblReviewed
            // 
            lblReviewed.AutoSize = true;
            lblReviewed.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblReviewed.Location = new Point(541, 106);
            lblReviewed.Name = "lblReviewed";
            lblReviewed.Size = new Size(143, 31);
            lblReviewed.TabIndex = 10;
            lblReviewed.Text = "<Reviewed>";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(416, 106);
            label3.Name = "label3";
            label3.Size = new Size(116, 31);
            label3.TabIndex = 9;
            label3.Text = "Reviewed:";
            // 
            // lblUserBan
            // 
            lblUserBan.AutoSize = true;
            lblUserBan.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblUserBan.Location = new Point(541, 147);
            lblUserBan.Name = "lblUserBan";
            lblUserBan.Size = new Size(137, 31);
            lblUserBan.TabIndex = 12;
            lblUserBan.Text = "<User ban>";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(416, 147);
            label7.Name = "label7";
            label7.Size = new Size(110, 31);
            label7.TabIndex = 11;
            label7.Text = "User ban:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chbxRestrictAllPostsByThisAuthor);
            groupBox1.Controls.Add(btnConfirmReview);
            groupBox1.Controls.Add(chbxBanAuthor);
            groupBox1.Controls.Add(chbxRestrictPost);
            groupBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(684, 182);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(371, 418);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Review report";
            // 
            // chbxRestrictAllPostsByThisAuthor
            // 
            chbxRestrictAllPostsByThisAuthor.AutoSize = true;
            chbxRestrictAllPostsByThisAuthor.Location = new Point(15, 207);
            chbxRestrictAllPostsByThisAuthor.Name = "chbxRestrictAllPostsByThisAuthor";
            chbxRestrictAllPostsByThisAuthor.Size = new Size(350, 35);
            chbxRestrictAllPostsByThisAuthor.TabIndex = 3;
            chbxRestrictAllPostsByThisAuthor.Text = "Restrict all posts by this author";
            chbxRestrictAllPostsByThisAuthor.UseVisualStyleBackColor = true;
            // 
            // btnConfirmReview
            // 
            btnConfirmReview.Location = new Point(69, 275);
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
            chbxBanAuthor.Location = new Point(15, 166);
            chbxBanAuthor.Name = "chbxBanAuthor";
            chbxBanAuthor.Size = new Size(150, 35);
            chbxBanAuthor.TabIndex = 1;
            chbxBanAuthor.Text = "Ban Author";
            chbxBanAuthor.UseVisualStyleBackColor = true;
            // 
            // chbxRestrictPost
            // 
            chbxRestrictPost.AutoSize = true;
            chbxRestrictPost.Location = new Point(15, 125);
            chbxRestrictPost.Name = "chbxRestrictPost";
            chbxRestrictPost.Size = new Size(161, 35);
            chbxRestrictPost.TabIndex = 0;
            chbxRestrictPost.Text = "Restrict Post";
            chbxRestrictPost.UseVisualStyleBackColor = true;
            // 
            // PostReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1058, 612);
            Controls.Add(groupBox1);
            Controls.Add(lblUserBan);
            Controls.Add(label7);
            Controls.Add(lblReviewed);
            Controls.Add(label3);
            Controls.Add(rchtbxPostContent);
            Controls.Add(lblPostId);
            Controls.Add(label6);
            Controls.Add(lblRestricted);
            Controls.Add(label4);
            Controls.Add(lblDeleted);
            Controls.Add(label1);
            Controls.Add(lblDateOfPosting);
            Controls.Add(lblPostAuthor);
            Name = "PostReportForm";
            Text = "PostReport";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPostAuthor;
        private Label lblDateOfPosting;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label label1;
        private Label lblDeleted;
        private Label lblRestricted;
        private Label label4;
        private Label lblPostId;
        private Label label6;
        private RichTextBox rchtbxPostContent;
        private Label lblReviewed;
        private Label label3;
        private Label lblUserBan;
        private Label label7;
        private GroupBox groupBox1;
        private CheckBox chbxBanAuthor;
        private CheckBox chbxRestrictPost;
        private Button btnConfirmReview;
        private CheckBox chbxRestrictAllPostsByThisAuthor;
    }
}