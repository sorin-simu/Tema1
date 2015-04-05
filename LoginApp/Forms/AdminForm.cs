using System;
using System.Windows.Forms;
using LoginApp.Forms;

namespace LoginApp
{
    public partial class DashboardForm : Form
    {
        public DashboardForm(string username,string role)
        {
            InitializeComponent();
            this.username = username;
            lblUser.Text = username + " ("+role+")";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            var newPasswordForm = new NewPasswordForm(username);
            newPasswordForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
            var startForm = new StartForm();
            startForm.Show();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            var createUser = new CreateUserForm();
            createUser.Show();
        }

        private void btnUserReports_Click(object sender, EventArgs e)
        {
            var userReports = new UserReportsForm();
            userReports.Show();
        }

        
    }
}
