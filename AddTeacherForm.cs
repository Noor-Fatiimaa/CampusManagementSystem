using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class AddTeacherForm : Form
    {
        public AddTeacherForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check if any field is empty
            if (txtFullName.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" ||
                txtDepartment.Text == "" || txtSubject.Text == "" || txtSalary.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                // Create database helper object
                DatabaseHelper db = new DatabaseHelper();

                using (SQLiteConnection con = db.GetConnection())
                {
                    con.Open();

                    // Insert teacher data into Teachers table
                    string query = @"INSERT INTO Teachers 
                    (FullName, Email, Phone, Department, Subject, Salary)
                    VALUES
                    (@FullName, @Email, @Phone, @Department, @Subject, @Salary)";

                    SQLiteCommand cmd = new SQLiteCommand(query, con);

                    // Add values from textboxes into SQL parameters
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                    cmd.Parameters.AddWithValue("@Subject", txtSubject.Text);
                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Teacher Added Successfully!");

                    // Clear all fields after saving
                    txtFullName.Clear();
                    txtEmail.Clear();
                    txtPhone.Clear();
                    txtDepartment.Clear();
                    txtSubject.Clear();
                    txtSalary.Clear();
                }
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddTeacherForm_Load(object sender, EventArgs e)
        {

        }
    }
}