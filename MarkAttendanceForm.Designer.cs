using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    partial class MarkAttendanceForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle, lblSubTitle, lblCourse, lblDate, lblSection;
        private ComboBox cmbCourse;
        private DateTimePicker dtAttendance;
        private Button btnLoadStudents, btnSaveAttendance;
        private DataGridView dgvAttendance;
        private Panel cardOuter, card;

        Color navy = Color.FromArgb(15, 23, 42);
        Color blue = Color.FromArgb(37, 99, 235);
        Color blueHover = Color.FromArgb(29, 78, 216);
        Color pageBg = Color.FromArgb(219, 234, 254);
        Color cardBg = Color.White;
        Color border = Color.FromArgb(203, 213, 225);
        Color textDark = Color.FromArgb(15, 23, 42);
        Color muted = Color.FromArgb(71, 85, 105);

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
            lblCourse = new Label();
            lblDate = new Label();
            lblSection = new Label();
            cmbCourse = new ComboBox();
            dtAttendance = new DateTimePicker();
            btnLoadStudents = new Button();
            btnSaveAttendance = new Button();
            dgvAttendance = new DataGridView();
            cardOuter = new Panel();
            card = new Panel();

            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            SuspendLayout();

            Text = "Mark Attendance";
            Size = new Size(1000, 720);
            MinimumSize = new Size(1000, 720);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = pageBg;
            Font = new Font("Segoe UI", 9.5f);

            lblTitle.Text = "Mark Attendance";
            lblTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblTitle.ForeColor = textDark;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(70, 45);
            lblTitle.BackColor = Color.Transparent;
            Controls.Add(lblTitle);

            lblSubTitle.Text = "Select course and date, then mark student attendance.";
            lblSubTitle.Font = new Font("Segoe UI", 11);
            lblSubTitle.ForeColor = muted;
            lblSubTitle.AutoSize = true;
            lblSubTitle.Location = new Point(74, 98);
            lblSubTitle.BackColor = Color.Transparent;
            Controls.Add(lblSubTitle);

            cardOuter.Size = new Size(850, 500);
            cardOuter.Location = new Point(70, 145);
            cardOuter.BackColor = Color.Transparent;
            cardOuter.Paint += PaintCard;
            Controls.Add(cardOuter);

            card.Size = new Size(810, 460);
            card.Location = new Point(20, 20);
            card.BackColor = Color.White;
            cardOuter.Controls.Add(card);

            lblSection.Text = "Attendance Information";
            lblSection.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblSection.ForeColor = navy;
            lblSection.AutoSize = true;
            lblSection.Location = new Point(25, 15);
            lblSection.BackColor = Color.Transparent;
            card.Controls.Add(lblSection);

            lblCourse.Text = "Course";
            lblCourse.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            lblCourse.ForeColor = textDark;
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(25, 70);
            lblCourse.BackColor = Color.Transparent;
            card.Controls.Add(lblCourse);

            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourse.Font = new Font("Segoe UI", 11);
            cmbCourse.Size = new Size(250, 36);
            cmbCourse.Location = new Point(25, 97);
            cmbCourse.BackColor = Color.FromArgb(248, 250, 252);
            cmbCourse.ForeColor = textDark;
            card.Controls.Add(cmbCourse);

            lblDate.Text = "Date";
            lblDate.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            lblDate.ForeColor = textDark;
            lblDate.AutoSize = true;
            lblDate.Location = new Point(300, 70);
            lblDate.BackColor = Color.Transparent;
            card.Controls.Add(lblDate);

            dtAttendance.Font = new Font("Segoe UI", 11);
            dtAttendance.Size = new Size(250, 36);
            dtAttendance.Location = new Point(300, 97);
            dtAttendance.CalendarForeColor = textDark;
            card.Controls.Add(dtAttendance);

            btnLoadStudents.Text = "Load Students";
            btnLoadStudents.Size = new Size(180, 42);
            btnLoadStudents.Location = new Point(590, 94);
            btnLoadStudents.BackColor = blue;
            btnLoadStudents.ForeColor = Color.White;
            btnLoadStudents.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            btnLoadStudents.FlatStyle = FlatStyle.Flat;
            btnLoadStudents.Cursor = Cursors.Hand;
            btnLoadStudents.FlatAppearance.BorderSize = 0;
            btnLoadStudents.FlatAppearance.MouseOverBackColor = blueHover;
            btnLoadStudents.Click += btnLoadStudents_Click;
            RoundControl(btnLoadStudents, 14);
            card.Controls.Add(btnLoadStudents);

            dgvAttendance.AllowUserToAddRows = false;
            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendance.BackgroundColor = Color.White;
            dgvAttendance.BorderStyle = BorderStyle.None;
            dgvAttendance.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAttendance.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAttendance.ColumnHeadersHeight = 42;
            dgvAttendance.EnableHeadersVisualStyles = false;
            dgvAttendance.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvAttendance.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAttendance.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAttendance.DefaultCellStyle.BackColor = Color.White;
            dgvAttendance.DefaultCellStyle.ForeColor = textDark;
            dgvAttendance.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvAttendance.DefaultCellStyle.SelectionForeColor = textDark;
            dgvAttendance.GridColor = Color.FromArgb(226, 232, 240);
            dgvAttendance.RowHeadersVisible = false;
            dgvAttendance.RowTemplate.Height = 35;
            dgvAttendance.Location = new Point(25, 165);
            dgvAttendance.Size = new Size(760, 220);
            card.Controls.Add(dgvAttendance);

            btnSaveAttendance.Text = "Save Attendance";
            btnSaveAttendance.Size = new Size(190, 48);
            btnSaveAttendance.Location = new Point(595, 400);
            btnSaveAttendance.BackColor = blue;
            btnSaveAttendance.ForeColor = Color.White;
            btnSaveAttendance.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            btnSaveAttendance.FlatStyle = FlatStyle.Flat;
            btnSaveAttendance.Cursor = Cursors.Hand;
            btnSaveAttendance.FlatAppearance.BorderSize = 0;
            btnSaveAttendance.FlatAppearance.MouseOverBackColor = blueHover;
            btnSaveAttendance.Click += btnSaveAttendance_Click;
            RoundControl(btnSaveAttendance, 14);
            card.Controls.Add(btnSaveAttendance);

            Load += MarkAttendanceForm_Load;

            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            ResumeLayout(false);
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