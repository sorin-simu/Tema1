using System.Windows.Forms;
using BusinessLogic.Services;

namespace LoginApp.Forms
{
    public partial class UserReportsForm : Form
    {
        private readonly UserService _userService;
        private readonly AdvertismentService _advertismentService;
        public UserReportsForm()
        {
            _userService = new UserService();
            _advertismentService = new AdvertismentService();
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //var users = _userService.GetAllUsers();
            //users.ForEach(u => listBox1.Items.Add(u));
            //_advertismentService.GetNumberOfAdvertismentsPerUser(userId);

        }
    }
}
