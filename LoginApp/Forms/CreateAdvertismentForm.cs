using System;
using System.Windows.Forms;
using BusinessLogic.Services;
using DataAccess.Models;

namespace LoginApp.Forms
{
    public partial class CreateAdvertismentForm : Form
    {
        private readonly AdvertismentService _advertismentService;
        private readonly UserService _userService;
        private readonly string _username;
        private string _extraFields;
        private int _type;
        public CreateAdvertismentForm(string username)
        {
            _advertismentService = new AdvertismentService();
            _userService = new UserService();
            _username = username;
            InitializeComponent();
        }

        private void btnType1_Click(object sender, EventArgs e)
        {
            lbl11.Show();lbl12.Show();lbl13.Show();
            textBox11.Show();textBox12.Show();textBox13.Show();
            _extraFields = "";
            lbl21.Hide(); textBox21.Hide();
            _type = 1;//(int)EnumTypes.AdvertismentType.RealEstates;
        }

        private void btnType2_Click(object sender, EventArgs e)
        {
        lbl11.Hide(); lbl12.Hide(); lbl13.Hide();
            textBox11.Hide(); textBox12.Hide(); textBox13.Hide();
            _extraFields = "";
            lbl21.Show();textBox21.Show();
            _type = 2; //(int)EnumTypes.AdvertismentType.ProvideServices;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (_type)
            {
                case 1://(int)EnumTypes.AdvertismentType.RealEstates;
                    _extraFields = "/" + lbl11.Text + textBox11.Text + "/" + lbl12.Text + textBox12.Text + "/" + lbl13.Text + textBox13.Text + "/";
                    break;
                case 2://(int)EnumTypes.AdvertismentType.ProvideServices;
                    _extraFields = "/" + lbl21.Text + textBox21.Text + "/";
                    break;
            }
            var newAdvertisment = new Advertisment
            {
                UserId = _userService.GetUserByName(_username).Id,
                Title = textBoxTitle.Text,
                Description = textBoxDescription.Text,
                Type = _type,
                ExtraFields = _extraFields
            };
            _advertismentService.CreateAdvertisment(newAdvertisment);
            if (textBoxTitle.Text == "" || textBoxDescription.Text == "")
            {
                Hide();
                var errorForm = new ErrorForm("Title and Description fields must be filled.", this);
                errorForm.Show();
            }
            else
            {
                Close();
            }
        }
      }
 }
