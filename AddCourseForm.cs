using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class AddCourseForm : Form
    {
        public AddCourseForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check if all fields are filled
            if (txtCourseName.Text == "" || txtCourseCode.Text == "" || txtCreditHours.Text == "" || txtTeacherName.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            // Create database helper object
            DatabaseHelper db = new DatabaseHelper();

            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                // SQL query to insert course data
                string query = @"INSERT INTO Courses 
                                (CourseName, CourseCode, CreditHours, TeacherName)
                                VALUES
                                (@CourseName, @CourseCode, @CreditHours, @TeacherName)";

                SQLiteCommand cmd = new SQLiteCommand(query, con);

                // Add textbox values into query parameters
                cmd.Parameters.AddWithValue("@CourseName", txtCourseName.Text);
                cmd.Parameters.AddWithValue("@CourseCode", txtCourseCode.Text);
                cmd.Parameters.AddWithValue("@CreditHours", txtCreditHours.Text);
                cmd.Parameters.AddWithValue("@TeacherName", txtTeacherName.Text);

                // Execute query
                cmd.ExecuteNonQuery();

                MessageBox.Show("Course Added Successfully!");

                // Clear all fields after saving
                txtCourseName.Clear();
                txtCourseCode.Clear();
                txtCreditHours.Clear();
                txtTeacherName.Clear();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Close current form
            this.Close();
        }

        private void AddCourseForm_Load(object sender, EventArgs e)
        {

        }
    }
}