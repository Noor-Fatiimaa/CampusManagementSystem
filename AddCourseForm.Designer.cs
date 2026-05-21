using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    partial class AddCourseForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblSubTitle;
        private Label lblCourseName;
        private Label lblCourseCode;
        private Label lblCreditHours;
        private Label lblTeacherName;

        private TextBox txtCourseName;
        private TextBox txtCourseCode;
        private TextBox txtCreditHours;
        private TextBox txtTeacherName;

        private Button btnSave;
        private Button btnBack;
        private Panel cardOuter;
        private Panel card;

        Color navy = Color.FromArgb(15, 23, 42);
        Color pageBg = Color.FromArgb(219, 234, 254);
        Color cardBg = Color.White;
        Color border = Color.FromArgb(203, 213, 225);
        Color textDark = Color.FromArgb(15, 23, 42);
        Color muted = Color.FromArgb(71, 85, 105);
        Color blue = Color.FromArgb(37, 99, 235);
        Color grayBtn = Color.FromArgb(241, 245, 249);

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSubTitle = new Label();

            lblCourseName = new Label();
            lblCourseCode = new Label();
            lblCreditHours = new Label();
            lblTeacherName = new Label();

            txtCourseName = new TextBox();
            txtCourseCode = new TextBox();
            txtCreditHours = new TextBox();
            txtTeacherName = new TextBox();

            btnSave = new Button();
            btnBack = new Button();

            cardOuter = new Panel();
            card = new Panel();

            SuspendLayout();

            Text = "Add Course";
            Size = new Size(760, 650);
            MinimumSize = new Size(760, 650);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = pageBg;
            Font = new Font("Segoe UI", 9.5f);

            lblTitle.Text = "Add Course";
            lblTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblTitle.ForeColor = textDark;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(65, 40);
            Controls.Add(lblTitle);

            lblSubTitle.Text = "Add new course information to the system.";
            lblSubTitle.Font = new Font("Segoe UI", 11);
            lblSubTitle.ForeColor = muted;
            lblSubTitle.AutoSize = true;
            lblSubTitle.Location = new Point(70, 95);
            Controls.Add(lblSubTitle);

            cardOuter.Size = new Size(620, 430);
            cardOuter.Location = new Point(65, 145);
            cardOuter.BackColor = Color.Transparent;
            cardOuter.Paint += PaintCard;
            Controls.Add(cardOuter);

            card.Size = new Size(580, 390);
            card.Location = new Point(20, 20);
            card.BackColor = Color.White;
            cardOuter.Controls.Add(card);

            lblCourseName.Text = "Course Name";
            lblCourseName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblCourseName.ForeColor = navy;
            lblCourseName.AutoSize = true;
            lblCourseName.Location = new Point(45, 35);
            card.Controls.Add(lblCourseName);

            txtCourseName.Size = new Size(480, 32);
            txtCourseName.Location = new Point(45, 62);
            txtCourseName.Font = new Font("Segoe UI", 10);
            card.Controls.Add(txtCourseName);

            lblCourseCode.Text = "Course Code";
            lblCourseCode.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblCourseCode.ForeColor = navy;
            lblCourseCode.AutoSize = true;
            lblCourseCode.Location = new Point(45, 110);
            card.Controls.Add(lblCourseCode);

            txtCourseCode.Size = new Size(480, 32);
            txtCourseCode.Location = new Point(45, 137);
            txtCourseCode.Font = new Font("Segoe UI", 10);
            card.Controls.Add(txtCourseCode);

            lblCreditHours.Text = "Credit Hours";
            lblCreditHours.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblCreditHours.ForeColor = navy;
            lblCreditHours.AutoSize = true;
            lblCreditHours.Location = new Point(45, 185);
            card.Controls.Add(lblCreditHours);

            txtCreditHours.Size = new Size(480, 32);
            txtCreditHours.Location = new Point(45, 212);
            txtCreditHours.Font = new Font("Segoe UI", 10);
            card.Controls.Add(txtCreditHours);

            lblTeacherName.Text = "Teacher Name";
            lblTeacherName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTeacherName.ForeColor = navy;
            lblTeacherName.AutoSize = true;
            lblTeacherName.Location = new Point(45, 260);
            card.Controls.Add(lblTeacherName);

            txtTeacherName.Size = new Size(480, 32);
            txtTeacherName.Location = new Point(45, 287);
            txtTeacherName.Font = new Font("Segoe UI", 10);
            card.Controls.Add(txtTeacherName);

            btnBack.Text = "Back";
            btnBack.Size = new Size(225, 45);
            btnBack.Location = new Point(45, 335);
            btnBack.BackColor = grayBtn;
            btnBack.ForeColor = navy;
            btnBack.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += btnBack_Click;
            RoundControl(btnBack, 14);
            card.Controls.Add(btnBack);

            btnSave.Text = "Save Course";
            btnSave.Size = new Size(225, 45);
            btnSave.Location = new Point(300, 335);
            btnSave.BackColor = blue;
            btnSave.ForeColor = Color.White;
            btnSave.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += btnSave_Click;
            RoundControl(btnSave, 14);
            card.Controls.Add(btnSave);

            Load += AddCourseForm_Load;

            ResumeLayout(false);
            PerformLayout();
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