using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    partial class ViewAttendanceForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle, lblSubTitle;
        private DataGridView dgvAttendance;
        private Button btnRefresh;
        private Panel cardOuter, card;

        Color navy = Color.FromArgb(15, 23, 42);
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
            dgvAttendance = new DataGridView();
            btnRefresh = new Button();
            cardOuter = new Panel();
            card = new Panel();

            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            SuspendLayout();

            Text = "View Attendance";
            Size = new Size(1100, 720);
            MinimumSize = new Size(1100, 720);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = pageBg;
            Font = new Font("Segoe UI", 9.5f);

            lblTitle.Text = "View Attendance";
            lblTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblTitle.ForeColor = textDark;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(70, 45);
            lblTitle.BackColor = Color.Transparent;
            Controls.Add(lblTitle);

            lblSubTitle.Text = "View and refresh all student attendance records.";
            lblSubTitle.Font = new Font("Segoe UI", 11);
            lblSubTitle.ForeColor = muted;
            lblSubTitle.AutoSize = true;
            lblSubTitle.Location = new Point(74, 98);
            lblSubTitle.BackColor = Color.Transparent;
            Controls.Add(lblSubTitle);

            btnRefresh.Text = "Refresh";
            btnRefresh.Size = new Size(135, 48);
            btnRefresh.Location = new Point(910, 60);
            btnRefresh.BackColor = Color.FromArgb(241, 245, 249);
            btnRefresh.ForeColor = navy;
            btnRefresh.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(226, 232, 240);
            btnRefresh.Click += btnRefresh_Click;
            RoundControl(btnRefresh, 14);
            Controls.Add(btnRefresh);

            cardOuter.Size = new Size(980, 500);
            cardOuter.Location = new Point(60, 145);
            cardOuter.BackColor = Color.Transparent;
            cardOuter.Paint += PaintCard;
            Controls.Add(cardOuter);

            card.Size = new Size(940, 460);
            card.Location = new Point(20, 20);
            card.BackColor = Color.White;
            cardOuter.Controls.Add(card);

            Label section = new Label
            {
                Text = "Attendance Records",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = navy,
                AutoSize = true,
                Location = new Point(25, 15),
                BackColor = Color.Transparent
            };
            card.Controls.Add(section);

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
            dgvAttendance.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvAttendance.DefaultCellStyle.ForeColor = textDark;
            dgvAttendance.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvAttendance.DefaultCellStyle.SelectionForeColor = textDark;
            dgvAttendance.GridColor = Color.FromArgb(226, 232, 240);
            dgvAttendance.Location = new Point(25, 65);
            dgvAttendance.ReadOnly = true;
            dgvAttendance.RowHeadersVisible = false;
            dgvAttendance.RowTemplate.Height = 36;
            dgvAttendance.Size = new Size(890, 365);
            card.Controls.Add(dgvAttendance);

            Load += ViewAttendanceForm_Load;

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