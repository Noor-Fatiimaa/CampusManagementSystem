using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class ViewPaymentsForm : Form
    {
        // Database helper object
        DatabaseHelper db = new DatabaseHelper();

        public ViewPaymentsForm()
        {
            InitializeComponent();
        }

        private void ViewPaymentsForm_Load(object sender, EventArgs e)
        {
            // Load payment records when form opens
            LoadPayments();
        }

        private void LoadPayments()
        {
            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                // Fetch payment details with student names
                string query = @"
                SELECT 
                    Payments.PaymentId,
                    Students.FullName AS StudentName,
                    Payments.Amount,
                    Payments.PaymentDate,
                    Payments.PaymentMethod,
                    Payments.Remarks
                FROM Payments
                INNER JOIN Students ON Payments.StudentId = Students.Id";

                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Display data in DataGridView
                dgvPayments.Columns.Clear();
                dgvPayments.DataSource = dt;

                AddActionButtons();
            }
        }

        private void AddActionButtons()
        {
            // Add delete button column
            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
            deleteBtn.Name = "Delete";
            deleteBtn.HeaderText = "Delete";
            deleteBtn.Text = "Delete";
            deleteBtn.UseColumnTextForButtonValue = true;

            dgvPayments.Columns.Add(deleteBtn);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                // Search payment records by student name
                string query = @"
                SELECT 
                    Payments.PaymentId,
                    Students.FullName AS StudentName,
                    Payments.Amount,
                    Payments.PaymentDate,
                    Payments.PaymentMethod,
                    Payments.Remarks
                FROM Payments
                INNER JOIN Students ON Payments.StudentId = Students.Id
                WHERE Students.FullName LIKE @search";

                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPayments.Columns.Clear();
                dgvPayments.DataSource = dt;

                AddActionButtons();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Clear search box and reload data
            txtSearch.Clear();
            LoadPayments();
        }

        private void dgvPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Check if delete button is clicked
            if (dgvPayments.Columns[e.ColumnIndex].Name == "Delete")
            {
                int paymentId = Convert.ToInt32(
                    dgvPayments.Rows[e.RowIndex].Cells["PaymentId"].Value
                );

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this payment?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    DeletePayment(paymentId);
                    LoadPayments();
                }
            }
        }

        private void DeletePayment(int paymentId)
        {
            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                // Delete payment record from database
                string query = "DELETE FROM Payments WHERE PaymentId=@paymentId";

                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@paymentId", paymentId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Payment Deleted Successfully");
        }
    }
}