using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    partial class EditTeacherForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblSubTitle;

        private Label lblFullName;
        private Label lblEmail;
        private Label lblPhone;
        private Label lblDepartment;
        private Label lblSubject;
        private Label lblSalary;

        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtDepartment;
        private TextBox txtSubject;
        private TextBox txtSalary;

        private Button btnUpdate;
        private Panel cardOuter;
        private Panel card;

        Color navy = Color.FromArgb(15, 23, 42);
        Color pageBg = Color.FromArgb(219, 234, 254);
        Color cardBg = Color.White;
        Color border = Color.FromArgb(203, 213, 225);
        Color textDark = Color.FromArgb(15, 23, 42);
        Color muted = Color.FromArgb(71, 85, 105);
        Color blue = Color.FromArgb(37, 99, 235);

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
            lblTitle = new Label();
            lblSubTitle = new Label();

            lblFullName = new Label();
            lblEmail = new Label();
            lblPhone = new Label();
            lblDepartment = new Label();
            lblSubject = new Label();
            lblSalary = new Label();

            txtFullName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtDepartment = new TextBox();
            txtSubject = new TextBox();
            txtSalary = new TextBox();

            btnUpdate = new Button();
            cardOuter = new Panel();
            card = new Panel();

            SuspendLayout();

            Text = "Edit Teacher";
            Size = new Size(760, 680);
            MinimumSize = new Size(760, 680);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = pageBg;
            Font = new Font("Segoe UI", 9.5f);

            lblTitle.Text = "Edit Teacher";
            lblTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblTitle.ForeColor = textDark;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(55, 35);
            Controls.Add(lblTitle);

            lblSubTitle.Text = "Update teacher information and save changes.";
            lblSubTitle.Font = new Font("Segoe UI", 11);
            lblSubTitle.ForeColor = muted;
            lblSubTitle.AutoSize = true;
            lblSubTitle.Location = new Point(60, 88);
            Controls.Add(lblSubTitle);

            cardOuter.Size = new Size(640, 470);
            cardOuter.Location = new Point(55, 135);
            cardOuter.BackColor = Color.Transparent;
            cardOuter.Paint += PaintCard;
            Controls.Add(cardOuter);

            card.Size = new Size(600, 430);
            card.Location = new Point(20, 20);
            card.BackColor = Color.White;
            cardOuter.Controls.Add(card);

            CreateLabel(lblFullName, "Full Name", 35, 30);
            CreateTextBox(txtFullName, 180, 25);

            CreateLabel(lblEmail, "Email", 35, 85);
            CreateTextBox(txtEmail, 180, 80);

            CreateLabel(lblPhone, "Phone", 35, 140);
            CreateTextBox(txtPhone, 180, 135);

            CreateLabel(lblDepartment, "Department", 35, 195);
            CreateTextBox(txtDepartment, 180, 190);

            CreateLabel(lblSubject, "Subject", 35, 250);
            CreateTextBox(txtSubject, 180, 245);

            CreateLabel(lblSalary, "Salary", 35, 305);
            CreateTextBox(txtSalary, 180, 300);

            btnUpdate.Text = "Update Teacher";
            btnUpdate.Size = new Size(380, 48);
            btnUpdate.Location = new Point(180, 360);
            btnUpdate.BackColor = blue;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnUpdate.Click += btnUpdate_Click;
            RoundControl(btnUpdate, 14);
            card.Controls.Add(btnUpdate);

            ResumeLayout(false);
        }

        private void CreateLabel(Label label, string text, int x, int y)
        {
            label.Text = text;
            label.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            label.ForeColor = navy;
            label.AutoSize = true;
            label.Location = new Point(x, y);
            label.BackColor = Color.Transparent;
            card.Controls.Add(label);
        }

        private void CreateTextBox(TextBox textbox, int x, int y)
        {
            textbox.Size = new Size(380, 34);
            textbox.Location = new Point(x, y);
            textbox.Font = new Font("Segoe UI", 10.5f);
            textbox.BorderStyle = BorderStyle.FixedSingle;
            textbox.BackColor = Color.FromArgb(248, 250, 252);
            textbox.ForeColor = textDark;
            card.Controls.Add(textbox);
        }

        private void PaintCard(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle shadowRect = new Rectangle(8, 8, panel.Width - 18, panel.Height - 18);

            using (GraphicsPath shadowPath = RoundPath(shadowRect, 22))
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(25, 15, 23, 42)))
            {
                g.FillPath(shadowBrush, shadowPath);
            }

            Rectangle mainRect = new Rectangle(0, 0, panel.Width - 10, panel.Height - 10);

            using (GraphicsPath path = RoundPath(mainRect, 22))
            {
                using (SolidBrush br = new SolidBrush(cardBg))
                    g.FillPath(br, path);

                using (Pen pen = new Pen(border, 1))
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