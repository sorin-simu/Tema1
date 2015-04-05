using System;
using System.Windows.Forms;
using BusinessLogic.Services;

namespace LoginApp
{
    public partial class CreateUserForm : Form
    {
        private readonly UserService _userService;

        public CreateUserForm()
        {
            _userService = new UserService();
            InitializeComponent();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "" || textBoxPassword1.Text == "" || textBoxPassword2.Text == ""
                || textBoxName.Text == "" || checkedListBoxRole.Text == "")
            {
                var errorForm = new ErrorForm("Please fill all fields.", this);
                errorForm.Show();
                Hide();
            }
            else
            {
                if (textBoxPassword1.Text != textBoxPassword2.Text)
                {
                    var errorForm = new ErrorForm("Passwords don`t match.", this);
                    errorForm.Show();
                }
                else{
                _userService.CreateUser(textBoxUsername.Text, textBoxPassword1.Text, textBoxName.Text,
                        checkedListBoxRole.Text);
                    Close();
                }
            }
        }
    }
}
