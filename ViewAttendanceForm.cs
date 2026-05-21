using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class ViewAttendanceForm : Form
    {
        // Database helper object
        DatabaseHelper db = new DatabaseHelper();

        public ViewAttendanceForm()
        {
            InitializeComponent();
        }

        private void ViewAttendanceForm_Load(object sender, EventArgs e)
        {
            // Load attendance data when form opens
            LoadAttendance();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Refresh attendance records
            LoadAttendance();
        }

        private void LoadAttendance()
        {
            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                // SQL query to fetch attendance details
                string query = @"
                SELECT 
                    A.Id,
                    S.FullName AS StudentName,
                    C.CourseName AS CourseName,
                    A.AttendanceDate,
                    A.Status
                FROM Attendance A
                LEFT JOIN Students S ON A.StudentId = S.Id
                LEFT JOIN Courses C ON A.CourseId = C.CourseId
                ORDER BY A.AttendanceDate DESC";

                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Display attendance data in DataGridView
                dgvAttendance.DataSource = dt;
            }
        }
    }
}