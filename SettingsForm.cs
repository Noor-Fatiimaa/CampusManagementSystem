using System;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Set form title
            lblTitle.Text = "Settings";
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Open change password form
            ChangePasswordForm changePasswordForm = new ChangePasswordForm();
            changePasswordForm.ShowDialog();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            // Open manage users form
            ManageUsersForm manageUsersForm = new ManageUsersForm();
            manageUsersForm.ShowDialog();
        }
    }
}