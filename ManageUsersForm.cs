using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class ManageUsersForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();

        TextBox txtUsername, txtPassword;
        ComboBox cmbRole;
        Button btnAddUser, btnDeleteUser;
        DataGridView dgvUsers;

        public ManageUsersForm()
        {
            InitializeComponent();
            BuildUI();
            LoadUsers();
        }

        private void BuildUI()
        {
            Text = "Manage Users";
            Size = new Size(800, 550);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(15, 23, 42);

            Label title = new Label()
            {
                Text = "Manage Users",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                Location = new Point(30, 25),
                AutoSize = true
            };

            txtUsername = new TextBox()
            {
                PlaceholderText = "Username",
                Location = new Point(30, 90),
                Size = new Size(220, 35),
                Font = new Font("Segoe UI", 11)
            };

            txtPassword = new TextBox()
            {
                PlaceholderText = "Password",
                Location = new Point(270, 90),
                Size = new Size(220, 35),
                Font = new Font("Segoe UI", 11)
            };

            cmbRole = new ComboBox()
            {
                Location = new Point(510, 90),
                Size = new Size(200, 35),
                Font = new Font("Segoe UI", 11),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Teacher");
            cmbRole.Items.Add("Accountant");

            btnAddUser = new Button()
            {
                Text = "Add User",
                Location = new Point(30, 145),
                Size = new Size(150, 42),
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            btnDeleteUser = new Button()
            {
                Text = "Delete Selected",
                Location = new Point(200, 145),
                Size = new Size(160, 42),
                BackColor = Color.FromArgb(220, 38, 38),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            dgvUsers = new DataGridView()
            {
                Location = new Point(30, 210),
                Size = new Size(700, 260),
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            btnAddUser.FlatAppearance.BorderSize = 0;
            btnDeleteUser.FlatAppearance.BorderSize = 0;

            btnAddUser.Click += BtnAddUser_Click;
            btnDeleteUser.Click += BtnDeleteUser_Click;

            Controls.Add(title);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(cmbRole);
            Controls.Add(btnAddUser);
            Controls.Add(btnDeleteUser);
            Controls.Add(dgvUsers);
        }

        private void LoadUsers()
        {
            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                string query = "SELECT Id, Username, Password, Role FROM Users";

                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvUsers.DataSource = dt;
            }
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "" || cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                string query = "INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)";

                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@role", cmbRole.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("User added successfully.");
                LoadUsers();

                txtUsername.Clear();
                txtPassword.Clear();
                cmbRole.SelectedIndex = -1;
            }
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select user.");
                return;
            }

            int id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);

            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                string query = "DELETE FROM Users WHERE Id=@id";

                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("User deleted successfully.");
                LoadUsers();
            }
        }

        private void ManageUsersForm_Load(object sender, EventArgs e)
        {

        }
    }
}