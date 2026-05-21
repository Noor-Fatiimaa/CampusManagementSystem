using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class ViewStudentsForm : Form
    {
        // Database helper object
        DatabaseHelper db = new DatabaseHelper();

        public ViewStudentsForm()
        {
            InitializeComponent();

            // Load students when form opens
            LoadStudents();
        }

        private void LoadStudents()
        {
            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                // Fetch all student records from database
                string query = @"SELECT 
                                Id,
                                FullName,
                                FatherName,
                                Email,
                                Phone,
                                Gender,
                                ClassName,
                                Address,
                                CreatedAt
                                FROM Students";

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, con);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Show students data in DataGridView
                grid.DataSource = table;
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            // Refresh students list
            LoadStudents();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // Check if student is selected
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student first.");
                return;
            }

            int studentId = Convert.ToInt32(grid.SelectedRows[0].Cells["Id"].Value);

            // Open edit student form
            EditStudentForm editForm = new EditStudentForm(studentId);
            editForm.ShowDialog();

            LoadStudents();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // Check if student is selected
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student first.");
                return;
            }

            int studentId = Convert.ToInt32(grid.SelectedRows[0].Cells["Id"].Value);

            // Confirm before deleting student
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this student?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No)
                return;

            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                // Delete selected student from database
                string query = "DELETE FROM Students WHERE Id = @Id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", studentId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Student deleted successfully!");

            // Reload updated students list
            LoadStudents();
        }

        private void ViewStudentsForm_Load(object sender, EventArgs e)
        {
        }
    }
}