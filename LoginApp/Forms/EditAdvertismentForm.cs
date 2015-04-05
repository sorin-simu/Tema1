using System;
using System.Windows.Forms;
using BusinessLogic.Services;
using DataAccess.Models;

namespace LoginApp.Forms
{
    public partial class EditAdvertismentForm : Form
    {
        private readonly Advertisment _advertisment;
        private readonly AdvertismentService _advertismentService;
        public EditAdvertismentForm(Advertisment adv)
        {
            _advertismentService = new AdvertismentService();
            _advertisment = adv;
            InitializeComponent();
            textBoxTitle.Text = adv.Title;
            textBoxDescription.Text = adv.Description;
            textBoxPicture.Text = adv.Picture;
            textBoxAttr.Text = adv.ExtraFields;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var newAdvertisment = _advertisment;
            newAdvertisment.Title = textBoxTitle.Text;
            newAdvertisment.Description = textBoxDescription.Text;
            newAdvertisment.Picture = textBoxPicture.Text;
            newAdvertisment.ExtraFields = textBoxAttr.Text;
            _advertismentService.EditAdvertisment(newAdvertisment);
            Close();
        }
    }
}
