using System;
using System.Windows.Forms;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;

namespace LoginApp
{
    public partial class NewPasswordForm : Form
    {
        private readonly IUserService _userService;
        private readonly string username;
        public NewPasswordForm(string username)
        {
            _userService = new UserService();
            this.username = username;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newPassword = textBoxNewPass1.Text;
            if (textBoxNewPass2.Text != textBoxNewPass1.Text)
            {
                var errorForm = new ErrorForm("Passwords don`t match.", this);
                errorForm.Show();
            }
            else
            {
                _userService.ChangePassword(username, newPassword);
                Close();
            }
        }
    }
}
