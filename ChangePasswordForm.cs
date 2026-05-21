using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class ChangePasswordForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();

        TextBox txtUsername, txtOldPassword, txtNewPassword;
        Button btnUpdate;

        public ChangePasswordForm()
        {
            InitializeComponent();
            BuildUI();
        }

        private void BuildUI()
        {
            // Form design settings
            Text = "Change Password";
            Size = new Size(450, 400);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(15, 23, 42);

            Label title = new Label()
            {
                Text = "Change Password",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Location = new Point(80, 30),
                AutoSize = true
            };

            // Create username textbox
            txtUsername = CreateTextBox("Username", 80);

            // Create old password textbox
            txtOldPassword = CreateTextBox("Old Password", 140);
            txtOldPassword.PasswordChar = '*';

            // Create new password textbox
            txtNewPassword = CreateTextBox("New Password", 200);
            txtNewPassword.PasswordChar = '*';

            // Update password button
            btnUpdate = new Button()
            {
                Text = "Update Password",
                Location = new Point(80, 270),
                Size = new Size(280, 45),
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };

            btnUpdate.FlatAppearance.BorderSize = 0;

            // Button click event
            btnUpdate.Click += BtnUpdate_Click;

            Controls.Add(title);
            Controls.Add(txtUsername);
            Controls.Add(txtOldPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(btnUpdate);
        }

        private TextBox CreateTextBox(string placeholder, int y)
        {
            // Create reusable textbox
            TextBox txt = new TextBox()
            {
                Location = new Point(80, y),
                Size = new Size(280, 35),
                Font = new Font("Segoe UI", 11),
                PlaceholderText = placeholder
            };

            return txt;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Validate all fields
            if (txtUsername.Text == "" || txtOldPassword.Text == "" || txtNewPassword.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                // Check old password from database
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username=@username AND Password=@oldPassword";

                SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@username", txtUsername.Text);
                checkCmd.Parameters.AddWithValue("@oldPassword", txtOldPassword.Text);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count == 0)
                {
                    MessageBox.Show("Old password is incorrect.");
                    return;
                }

                // Update new password
                string updateQuery = "UPDATE Users SET Password=@newPassword WHERE Username=@username";

                SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, con);
                updateCmd.Parameters.AddWithValue("@newPassword", txtNewPassword.Text);
                updateCmd.Parameters.AddWithValue("@username", txtUsername.Text);

                updateCmd.ExecuteNonQuery();

                MessageBox.Show("Password updated successfully.");
                this.Close();
            }
        }
    }
}