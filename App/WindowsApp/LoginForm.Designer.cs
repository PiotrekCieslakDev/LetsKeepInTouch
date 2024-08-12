namespace WindowsApp
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbxIdentifier = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tbxPassword = new TextBox();
            LoginBtn = new Button();
            SuspendLayout();
            // 
            // tbxIdentifier
            // 
            tbxIdentifier.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            tbxIdentifier.Location = new Point(34, 109);
            tbxIdentifier.Name = "tbxIdentifier";
            tbxIdentifier.Size = new Size(366, 43);
            tbxIdentifier.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(24, 75);
            label1.Name = "label1";
            label1.Size = new Size(203, 31);
            label1.TabIndex = 1;
            label1.Text = "Email or username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(26, 187);
            label2.Name = "label2";
            label2.Size = new Size(115, 31);
            label2.TabIndex = 3;
            label2.Text = "Password:";
            // 
            // tbxPassword
            // 
            tbxPassword.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            tbxPassword.Location = new Point(36, 221);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.PasswordChar = '*';
            tbxPassword.Size = new Size(366, 43);
            tbxPassword.TabIndex = 2;
            // 
            // LoginBtn
            // 
            LoginBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            LoginBtn.Location = new Point(96, 326);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(244, 57);
            LoginBtn.TabIndex = 4;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(429, 450);
            Controls.Add(LoginBtn);
            Controls.Add(label2);
            Controls.Add(tbxPassword);
            Controls.Add(label1);
            Controls.Add(tbxIdentifier);
            Name = "LoginForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxIdentifier;
        private Label label1;
        private Label label2;
        private TextBox tbxPassword;
        private Button LoginBtn;
    }
}