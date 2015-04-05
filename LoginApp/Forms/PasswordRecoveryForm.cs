using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Models;

namespace LoginApp
{
    public partial class PasswordRecoveryForm : Form
    {
        private readonly IUserService _userService;
        public PasswordRecoveryForm()
        {
            _userService = new UserService();
            InitializeComponent();
            lblNew.Hide();
        }

        private void btnGetPassword_Click(object sender, EventArgs e)
        {
            var password = _userService.ForgotPassword(textBoxForgotUsername.Text);
            lblNew.Show();
            lblNewPassword.Text = password;
        }
    }
}
