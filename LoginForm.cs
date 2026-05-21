using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Create database helper object
            DatabaseHelper db = new DatabaseHelper();

            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                // Check username and password from Users table
                string query =
                    "SELECT * FROM Users WHERE Username=@username AND Password=@password";

                SQLiteCommand cmd =
                    new SQLiteCommand(query, con);

                // Pass username parameter
                cmd.Parameters.AddWithValue(
                    "@username",
                    txtUsername.Text
                );

                // Pass password parameter
                cmd.Parameters.AddWithValue(
                    "@password",
                    txtPassword.Text
                );

                SQLiteDataReader reader =
                    cmd.ExecuteReader();

                // If login successful open dashboard
                if (reader.Read())
                {
                    string role =
                        reader["Role"].ToString();

                    DashboardForm dashboard =
                        new DashboardForm(role);

                    dashboard.Show();

                    this.Hide();
                }
                else
                {
                    // Show error message for invalid login
                    MessageBox.Show(
                        "Invalid Username or Password"
                    );
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void lblForgot_Click(object sender, EventArgs e)
        {
            // Forgot password message
            MessageBox.Show(
                "Please contact administrator to reset your password.",
                "Forgot Password",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}