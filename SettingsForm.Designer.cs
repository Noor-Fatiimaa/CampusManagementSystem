using System.Drawing;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel mainPanel;
        private Label lblTitle;
        private Button btnChangePassword;
        private Button btnManageUsers;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            lblTitle = new Label();
            btnChangePassword = new Button();
            btnManageUsers = new Button();

            SuspendLayout();

            // mainPanel
            mainPanel.BackColor = Color.FromArgb(15, 23, 42);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(40);

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(40, 30);
            lblTitle.Text = "Settings";

            // btnChangePassword
            btnChangePassword.BackColor = Color.FromArgb(37, 99, 235);
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.Location = new Point(45, 110);
            btnChangePassword.Size = new Size(250, 55);
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;

            // btnManageUsers
            btnManageUsers.BackColor = Color.FromArgb(30, 64, 175);
            btnManageUsers.FlatStyle = FlatStyle.Flat;
            btnManageUsers.FlatAppearance.BorderSize = 0;
            btnManageUsers.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnManageUsers.ForeColor = Color.White;
            btnManageUsers.Location = new Point(45, 185);
            btnManageUsers.Size = new Size(250, 55);
            btnManageUsers.Text = "Manage Users";
            btnManageUsers.UseVisualStyleBackColor = false;
            btnManageUsers.Click += btnManageUsers_Click;

            // add controls
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Controls.Add(btnChangePassword);
            mainPanel.Controls.Add(btnManageUsers);

            // SettingsForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(900, 600);
            Controls.Add(mainPanel);
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            Load += SettingsForm_Load;

            ResumeLayout(false);
        }
    }
}