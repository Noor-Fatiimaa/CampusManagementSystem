using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class EditTeacherForm : Form
    {
        private int teacherId;
        DatabaseHelper db = new DatabaseHelper();

        public EditTeacherForm(int id)
        {
            InitializeComponent();
            teacherId = id;
            LoadTeacherData();
        }

        private void LoadTeacherData()
        {
            try
            {
                using (SQLiteConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = "SELECT * FROM Teachers WHERE Id=@Id";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", teacherId);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFullName.Text = reader["FullName"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                txtPhone.Text = reader["Phone"].ToString();
                                txtDepartment.Text = reader["Department"].ToString();
                                txtSubject.Text = reader["Subject"].ToString();
                                txtSalary.Text = reader["Salary"].ToString();
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
            if (txtFullName.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" ||
                txtDepartment.Text == "" || txtSubject.Text == "" || txtSalary.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                using (SQLiteConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"UPDATE Teachers 
                                     SET FullName=@FullName,
                                         Email=@Email,
                                         Phone=@Phone,
                                         Department=@Department,
                                         Subject=@Subject,
                                         Salary=@Salary
                                     WHERE Id=@Id";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                        cmd.Parameters.AddWithValue("@Subject", txtSubject.Text);
                        cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);
                        cmd.Parameters.AddWithValue("@Id", teacherId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Teacher Updated Successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}