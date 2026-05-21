using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class EditStudentForm : Form
    {
        private int studentId;

        DatabaseHelper db = new DatabaseHelper();

        public EditStudentForm(int id)
        {
            InitializeComponent();
            studentId = id;
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                string query = "SELECT * FROM Students WHERE Id=@Id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", studentId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFullName.Text = reader["FullName"].ToString();
                            txtFatherName.Text = reader["FatherName"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtPhone.Text = reader["Phone"].ToString();
                            cmbGender.Text = reader["Gender"].ToString();
                            txtClassName.Text = reader["ClassName"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                        }
                    }
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text.Trim() == "" ||
                txtFatherName.Text.Trim() == "" ||
                txtEmail.Text.Trim() == "" ||
                txtPhone.Text.Trim() == "" ||
                cmbGender.Text.Trim() == "" ||
                txtClassName.Text.Trim() == "" ||
                txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                string query = @"UPDATE Students 
                                 SET FullName=@FullName,
                                     FatherName=@FatherName,
                                     Email=@Email,
                                     Phone=@Phone,
                                     Gender=@Gender,
                                     ClassName=@ClassName,
                                     Address=@Address
                                 WHERE Id=@Id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@FatherName", txtFatherName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", cmbGender.Text.Trim());
                    cmd.Parameters.AddWithValue("@ClassName", txtClassName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Id", studentId);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Student updated successfully!");
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}