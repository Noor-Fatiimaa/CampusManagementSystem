using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class MarkAttendanceForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();

        public MarkAttendanceForm()
        {
            InitializeComponent();
        }

        private void MarkAttendanceForm_Load(object sender, EventArgs e)
        {
            // Load courses into combo box
            LoadCourses();

            // Setup attendance table columns
            SetupDataGridView();
        }

        private void LoadCourses()
        {
            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                string query = "SELECT CourseId, CourseName FROM Courses";

                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();

                da.Fill(dt);

                // Bind course data with combo box
                cmbCourse.DataSource = dt;
                cmbCourse.DisplayMember = "CourseName";
                cmbCourse.ValueMember = "CourseId";
            }
        }

        private void SetupDataGridView()
        {
            dgvAttendance.Columns.Clear();

            dgvAttendance.Columns.Add("StudentId", "Student ID");
            dgvAttendance.Columns.Add("StudentName", "Student Name");

            // Create attendance status dropdown
            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.Name = "Status";
            statusColumn.HeaderText = "Status";
            statusColumn.Items.Add("Present");
            statusColumn.Items.Add("Absent");

            dgvAttendance.Columns.Add(statusColumn);
        }

        private void btnLoadStudents_Click(object sender, EventArgs e)
        {
            // Check if course is selected
            if (cmbCourse.SelectedValue == null)
            {
                MessageBox.Show("Please select a course");
                return;
            }

            dgvAttendance.Rows.Clear();

            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                string query = "SELECT Id, FullName FROM Students WHERE ClassName = @CourseName";

                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@CourseName", cmbCourse.Text);

                SQLiteDataReader reader = cmd.ExecuteReader();

                // Load students into DataGridView
                while (reader.Read())
                {
                    dgvAttendance.Rows.Add(
                        reader["Id"].ToString(),
                        reader["FullName"].ToString(),
                        "Present"
                    );
                }
            }

            if (dgvAttendance.Rows.Count == 0)
            {
                MessageBox.Show("No students found for this course");
            }
        }

        private void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            // Check if student data is loaded
            if (dgvAttendance.Rows.Count == 0)
            {
                MessageBox.Show("Please load students first");
                return;
            }

            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                // Save attendance row by row into database
                foreach (DataGridViewRow row in dgvAttendance.Rows)
                {
                    if (row.IsNewRow) continue;

                    string studentId = row.Cells["StudentId"].Value.ToString();
                    string status = row.Cells["Status"].Value.ToString();

                    string query = @"
                    INSERT INTO Attendance 
                    (StudentId, CourseId, TeacherId, AttendanceDate, Status)
                    VALUES 
                    (@StudentId, @CourseId, @TeacherId, @AttendanceDate, @Status)";

                    SQLiteCommand cmd = new SQLiteCommand(query, con);

                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@CourseId", cmbCourse.SelectedValue);
                    cmd.Parameters.AddWithValue("@TeacherId", DBNull.Value);
                    cmd.Parameters.AddWithValue("@AttendanceDate", dtAttendance.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Status", status);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Attendance saved successfully!");
            dgvAttendance.Rows.Clear();
        }
    }
}