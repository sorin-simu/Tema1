using System;
using System.Windows.Forms;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Models;

namespace LoginApp.Forms
{
    public partial class EditDeleteAdvertismentForm : Form
    {
        private readonly IAdvertismentService _advertismentService ;
        private Advertisment _advertisment;
        public EditDeleteAdvertismentForm()
        {
            _advertismentService = new AdvertismentService();
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var advertisment = _advertismentService.GetAdvertismentByTitle(textBoxTitle.Text);
            if (advertisment == null)
            {
                var errorForm = new ErrorForm("Advertisment not found.", this);
                errorForm.Show();
            }
            else
            {
                lblOK.Show();
                btnDelete.Show();
                btnEdit.Show();
                _advertisment = advertisment;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _advertismentService.DeleteAdvertisment(_advertisment.Id);
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var editAdvertismentForm = new EditAdvertismentForm(_advertisment);
            editAdvertismentForm.Show();

        }


    }
}
