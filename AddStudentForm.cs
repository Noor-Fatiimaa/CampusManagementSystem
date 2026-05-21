using System;
using System.Data.SQLite;
using System.Formats.Asn1;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class AddStudentForm : Form
    {
        // Database helper object used to create SQLite connection
        DatabaseHelper db = new DatabaseHelper();

        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Basic validation: full name is required
            if (txtFullName.Text.Trim() == "")
            {
                MessageBox.Show("Full Name is required");
                txtFullName.Focus();
                return;
            }

            // Insert student record into SQLite database
            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                string query = @"INSERT INTO Students
                (FullName, FatherName, Email, Phone, Gender, ClassName, Address)
                VALUES
                (@FullName, @FatherName, @Email, @Phone, @Gender, @ClassName, @Address)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    // Parameters protect from SQL injection and handle special characters
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@FatherName", txtFatherName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", cmbGender.Text);
                    cmd.Parameters.AddWithValue("@ClassName", txtClass.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Student saved successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            ClearForm();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Clears all input fields after saving or pressing Clear button
        private void ClearForm()
        {
            txtFullName.Clear();
            txtFatherName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtClass.Clear();
            txtAddress.Clear();

            cmbGender.SelectedIndex = -1;
            txtFullName.Focus();
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}