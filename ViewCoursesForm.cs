using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class ViewCoursesForm : Form
    {
        public ViewCoursesForm()
        {
            InitializeComponent();

            // Load courses when form opens
            LoadCourses();
        }

        private void LoadCourses()
        {
            try
            {
                // Create database helper object
                DatabaseHelper db = new DatabaseHelper();

                using (SQLiteConnection con = db.GetConnection())
                {
                    con.Open();

                    // Fetch all course records from database
                    string query = @"SELECT 
                                    CourseId,
                                    CourseName,
                                    CourseCode,
                                    CreditHours,
                                    TeacherName
                                    FROM Courses";

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Show data in DataGridView
                    dgvCourses.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Refresh course data
            LoadCourses();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Check if a course is selected
            if (dgvCourses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a course to edit.");
                return;
            }

            int courseId = Convert.ToInt32(dgvCourses.SelectedRows[0].Cells["CourseId"].Value);

            // Open edit course form
            EditCourseForm editForm = new EditCourseForm(courseId);
            editForm.ShowDialog();

            LoadCourses();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a course is selected
            if (dgvCourses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }

            int courseId = Convert.ToInt32(dgvCourses.SelectedRows[0].Cells["CourseId"].Value);

            // Confirmation before deleting
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this course?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                DatabaseHelper db = new DatabaseHelper();

                using (SQLiteConnection con = db.GetConnection())
                {
                    con.Open();

                    // Delete selected course from database
                    string query = "DELETE FROM Courses WHERE CourseId=@CourseId";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CourseId", courseId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Course Deleted Successfully!");

                    // Reload updated data
                    LoadCourses();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ViewCoursesForm_Load(object sender, EventArgs e)
        {
        }
    }
}