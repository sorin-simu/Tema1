using System;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class ErrorForm : Form
    {
        private Form _parentForm;
        public ErrorForm(string errorString,Form parentForm)
        {
            InitializeComponent();
            lblError.Text = errorString;
            _parentForm = parentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _parentForm.Show();
            Close();
        }


    }
}
