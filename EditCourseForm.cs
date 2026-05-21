using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class EditCourseForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        private int courseId;

        public EditCourseForm(int id)
        {
            InitializeComponent();
            courseId = id;
            LoadCourseData();
        }

        private void LoadCourseData()
        {
            try
            {
                using (SQLiteConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = "SELECT * FROM Courses WHERE CourseId=@CourseId";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CourseId", courseId);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtCourseName.Text = reader["CourseName"].ToString();
                                txtCourseCode.Text = reader["CourseCode"].ToString();
                                txtCreditHours.Text = reader["CreditHours"].ToString();
                                txtTeacherName.Text = reader["TeacherName"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCourseName.Text == "" ||
                txtCourseCode.Text == "" ||
                txtCreditHours.Text == "" ||
                txtTeacherName.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                using (SQLiteConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"UPDATE Courses 
                                     SET CourseName=@CourseName,
                                         CourseCode=@CourseCode,
                                         CreditHours=@CreditHours,
                                         TeacherName=@TeacherName
                                     WHERE CourseId=@CourseId";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CourseName", txtCourseName.Text);
                        cmd.Parameters.AddWithValue("@CourseCode", txtCourseCode.Text);
                        cmd.Parameters.AddWithValue("@CreditHours", txtCreditHours.Text);
                        cmd.Parameters.AddWithValue("@TeacherName", txtTeacherName.Text);
                        cmd.Parameters.AddWithValue("@CourseId", courseId);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Course Updated Successfully!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditCourseForm_Load(object sender, EventArgs e)
        {

        }
    }
}