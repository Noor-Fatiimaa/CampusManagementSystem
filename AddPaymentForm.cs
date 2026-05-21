using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class AddPaymentForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();

        public AddPaymentForm()
        {
            InitializeComponent();
            this.Load += AddPaymentForm_Load;
        }

        private void AddPaymentForm_Load(object sender, EventArgs e)
        {
            // Load students and payment methods when form opens
            LoadStudents();

            cmbPaymentMethod.Items.Clear();
            cmbPaymentMethod.Items.Add("Cash");
            cmbPaymentMethod.Items.Add("Card");
            cmbPaymentMethod.Items.Add("Bank Transfer");
            cmbPaymentMethod.Items.Add("Online");

            cmbPaymentMethod.SelectedIndex = 0;
        }

        private void LoadStudents()
        {
            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                // Fetch all students from database
                string query = "SELECT Id, FullName FROM Students";

                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader reader = cmd.ExecuteReader();

                cmbStudent.Items.Clear();

                // Add students into combo box
                while (reader.Read())
                {
                    cmbStudent.Items.Add(
                        new ComboBoxItem(
                            reader["FullName"].ToString(),
                            reader["Id"].ToString()
                        )
                    );
                }

                if (cmbStudent.Items.Count > 0)
                {
                    cmbStudent.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No students found");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate required payment fields
            if (cmbStudent.SelectedItem == null)
            {
                MessageBox.Show("Please select student");
                return;
            }

            if (txtAmount.Text == "")
            {
                MessageBox.Show("Please enter amount");
                return;
            }

            if (cmbPaymentMethod.SelectedItem == null)
            {
                MessageBox.Show("Please select payment method");
                return;
            }

            ComboBoxItem selectedStudent =
                (ComboBoxItem)cmbStudent.SelectedItem;

            using (SQLiteConnection con = db.GetConnection())
            {
                con.Open();

                // Insert payment record into Payments table
                string query = @"
                INSERT INTO Payments
                (StudentId, Amount, PaymentDate, PaymentMethod, Remarks)
                VALUES
                (@studentId, @amount, @paymentDate, @paymentMethod, @remarks)";

                SQLiteCommand cmd = new SQLiteCommand(query, con);

                // Pass form values safely using parameters
                cmd.Parameters.AddWithValue(
                    "@studentId",
                    Convert.ToInt32(selectedStudent.Value)
                );

                cmd.Parameters.AddWithValue(
                    "@amount",
                    txtAmount.Text
                );

                cmd.Parameters.AddWithValue(
                    "@paymentDate",
                    dtpPaymentDate.Value.ToString("yyyy-MM-dd")
                );

                cmd.Parameters.AddWithValue(
                    "@paymentMethod",
                    cmbPaymentMethod.Text
                );

                cmd.Parameters.AddWithValue(
                    "@remarks",
                    txtRemarks.Text
                );

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Payment Added Successfully");

            // Clear input fields after saving
            txtAmount.Clear();
            txtRemarks.Clear();
        }

        private void AddPaymentForm_Load_1(object sender, EventArgs e)
        {

        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ComboBoxItem(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}