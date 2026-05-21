using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    partial class EditStudentForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtFullName;
        private TextBox txtFatherName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtClassName;
        private TextBox txtAddress;
        private ComboBox cmbGender;
        private Button btnUpdate;
        private Button btnCancel;
        private Panel card;

        Color navy = Color.FromArgb(15, 23, 42);
        Color pageBg = Color.FromArgb(219, 234, 254);
        Color muted = Color.FromArgb(71, 85, 105);
        Color blue = Color.FromArgb(37, 99, 235);
        Color danger = Color.FromArgb(220, 38, 38);

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtFullName = new TextBox();
            txtFatherName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtClassName = new TextBox();
            txtAddress = new TextBox();
            cmbGender = new ComboBox();
            btnUpdate = new Button();
            btnCancel = new Button();
            card = new Panel();

            SuspendLayout();

            Text = "Edit Student";
            Size = new Size(800, 650);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = pageBg;
            Font = new Font("Segoe UI", 10);

            Label title = new Label
            {
                Text = "Edit Student",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = navy,
                AutoSize = true,
                Location = new Point(70, 35)
            };
            Controls.Add(title);

            Label subTitle = new Label
            {
                Text = "Update selected student record.",
                Font = new Font("Segoe UI", 11),
                ForeColor = muted,
                AutoSize = true,
                Location = new Point(74, 88)
            };
            Controls.Add(subTitle);

            card.Size = new Size(650, 450);
            card.Location = new Point(70, 135);
            card.BackColor = Color.White;
            card.Paint += PaintCard;
            Controls.Add(card);

            int labelX = 45;
            int inputX = 210;
            int y = 35;
            int gap = 50;

            AddLabel("Full Name", labelX, y);
            SetupTextBox(txtFullName, inputX, y - 5);

            y += gap;
            AddLabel("Father Name", labelX, y);
            SetupTextBox(txtFatherName, inputX, y - 5);

            y += gap;
            AddLabel("Email", labelX, y);
            SetupTextBox(txtEmail, inputX, y - 5);

            y += gap;
            AddLabel("Phone", labelX, y);
            SetupTextBox(txtPhone, inputX, y - 5);

            y += gap;
            AddLabel("Gender", labelX, y);
            cmbGender.Location = new Point(inputX, y - 5);
            cmbGender.Size = new Size(350, 32);
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");
            card.Controls.Add(cmbGender);

            y += gap;
            AddLabel("Class", labelX, y);
            SetupTextBox(txtClassName, inputX, y - 5);

            y += gap;
            AddLabel("Address", labelX, y);
            SetupTextBox(txtAddress, inputX, y - 5);

            btnUpdate.Text = "Update";
            btnUpdate.Size = new Size(160, 45);
            btnUpdate.Location = new Point(210, 365);
            btnUpdate.BackColor = blue;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.Click += BtnUpdate_Click;
            RoundControl(btnUpdate, 14);
            card.Controls.Add(btnUpdate);

            btnCancel.Text = "Cancel";
            btnCancel.Size = new Size(160, 45);
            btnCancel.Location = new Point(400, 365);
            btnCancel.BackColor = danger;
            btnCancel.ForeColor = Color.White;
            btnCancel.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += BtnCancel_Click;
            RoundControl(btnCancel, 14);
            card.Controls.Add(btnCancel);

            ResumeLayout(false);
        }

        private void AddLabel(string text, int x, int y)
        {
            Label lbl = new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(140, 25),
                ForeColor = navy,
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold)
            };

            card.Controls.Add(lbl);
        }

        private void SetupTextBox(TextBox txt, int x, int y)
        {
            txt.Location = new Point(x, y);
            txt.Size = new Size(350, 32);
            txt.Font = new Font("Segoe UI", 10);
            card.Controls.Add(txt);
        }

        private void PaintCard(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);

            using (GraphicsPath path = RoundPath(rect, 22))
            using (SolidBrush brush = new SolidBrush(Color.White))
            using (Pen pen = new Pen(Color.FromArgb(203, 213, 225), 1))
            {
                g.FillPath(brush, path);
                g.DrawPath(pen, path);
            }
        }

        private static void RoundControl(Control c, int radius)
        {
            GraphicsPath path = RoundPath(c.ClientRectangle, radius);
            c.Region = new Region(path);
        }

        private static GraphicsPath RoundPath(Rectangle r, int radius)
        {
            GraphicsPath p = new GraphicsPath();
            int d = radius * 2;

            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();

            return p;
        }
    }
}