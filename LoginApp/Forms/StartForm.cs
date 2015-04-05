using System;
using System.Windows.Forms;
using BusinessLogic.Interfaces;
using LoginApp.Models;
using BusinessLogic.Services;

namespace LoginApp
{
    public partial class StartForm : Form
    {
        private readonly IUserService _userService;
        public StartForm()
        {
            _userService = new UserService();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var currentUser = _userService.GetUser(textBoxUsername.Text, textBoxPassword.Text);
            var userModel = new UserModel();
            if (currentUser != null)
            {
                userModel = new UserModel
                {
                    Username = currentUser.Username,
                    Name = currentUser.Name,
                    Role = currentUser.Role
                };
            }
            if (userModel.Role != null)
            {
                if (userModel.Role == "Admin")
                {
                    var  homeForm = new DashboardForm(userModel.Name, userModel.Role);
                    homeForm.Show();
                }
                if (userModel.Role == "Employee")
                {
                    var homeForm = new EmployeeForm(userModel.Name, userModel.Role);
                    homeForm.Show();
                }
            }
            else
            {
                var errorForm = new ErrorForm("Login fail",this);
                errorForm.Show();
            }

            Hide();
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            var passwordRecoveryForm = new PasswordRecoveryForm();
            passwordRecoveryForm.Show();
        }
    }
}
