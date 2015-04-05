using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoginApp.Forms;

namespace LoginApp
{
    public partial class EmployeeForm : Form
    {
        private readonly string username, role;
        public EmployeeForm(string username,string role)
        {
            InitializeComponent();
            this.username = username;
            this.role = role;
        }

        private void btnAddAdvertisment_Click(object sender, EventArgs e)
        {
            var createAdvertismentForm = new CreateAdvertismentForm(username);
            createAdvertismentForm.Show();
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

        private void btnEditAdvertisment_Click(object sender, EventArgs e)
        {
            var editDeleteAdvForm = new EditDeleteAdvertismentForm();
            editDeleteAdvForm.Show();
        }
    }
}
