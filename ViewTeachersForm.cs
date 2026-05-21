using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class ViewTeachersForm : Form
    {
        public ViewTeachersForm()
        {
            InitializeComponent();

            // Load teachers when form opens
            LoadTeachers();
        }

        private void LoadTeachers()
        {
            try
            {
                // Create database helper object
                DatabaseHelper db = new DatabaseHelper();

                using (SQLiteConnection con = db.GetConnection())
                {
                    con.Open();

                    // Fetch all teacher records from database
                    string query = @"SELECT 
                                    Id, 
                                    FullName, 
                                    Email, 
                                    Phone, 
                                    Department, 
                                    Subject, 
                                    Salary 
                                    FROM Teachers";

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Show teachers data in DataGridView
                    dgvTeachers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Refresh teachers list
            LoadTeachers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Check if teacher is selected
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a teacher to edit.");
                return;
            }

            int teacherId = Convert.ToInt32(dgvTeachers.SelectedRows[0].Cells["Id"].Value);

            // Open edit teacher form
            EditTeacherForm editForm = new EditTeacherForm(teacherId);
            editForm.ShowDialog();

            LoadTeachers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if teacher is selected
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a teacher to delete.");
                return;
            }

            int teacherId = Convert.ToInt32(dgvTeachers.SelectedRows[0].Cells["Id"].Value);

            // Confirm before deleting teacher
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this teacher?",
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

                    // Delete selected teacher from database
                    string query = "DELETE FROM Teachers WHERE Id=@Id";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", teacherId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Teacher Deleted Successfully!");

                // Reload updated teachers list
                LoadTeachers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ViewTeachersForm_Load(object sender, EventArgs e)
        {
        }
    }
}