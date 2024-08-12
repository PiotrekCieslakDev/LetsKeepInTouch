using Database.DataRepositories;
using Domains.UserClasses;
using LogicLayer.Services;
using LogicLayerInterfaces;

namespace WindowsApp
{
    public partial class LoginForm : Form
    {
        ILoginService _loginService = new LoginService(new UserRepository());

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (tbxIdentifier.Text != string.Empty && tbxPassword.Text != string.Empty)
            {
                User user = _loginService.Login(tbxIdentifier.Text, tbxPassword.Text);
                if (user != null)
                {
                    if (user.IsAdmin())
                    {
                        MainForm mainForm = new MainForm(user);
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("You are not an admin");
                    }
                }
                else
                {
                    MessageBox.Show("Login or/and password incorrect.");
                }
            }
            else
            {
                MessageBox.Show("Insert login and password.");
            }
        }
    }
}