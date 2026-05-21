using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    partial class ViewReportsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblSubTitle;

        private Panel card1;
        private Panel card2;
        private Panel card3;
        private Panel card4;
        private Panel card5;

        private Label lblStudents;
        private Label lblTeachers;
        private Label lblCourses;
        private Label lblPayments;
        private Label lblEarnings;

        private Button btnPrintStudents;
        private Button btnPrintTeachers;
        private Button btnPrintCourses;
        private Button btnPrintPayments;

        Color navy = Color.FromArgb(15, 23, 42);
        Color blue = Color.FromArgb(37, 99, 235);
        Color pageBg = Color.FromArgb(219, 234, 254);
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

            card1 = new Panel();
            card2 = new Panel();
            card3 = new Panel();
            card4 = new Panel();
            card5 = new Panel();

            lblStudents = new Label();
            lblTeachers = new Label();
            lblCourses = new Label();
            lblPayments = new Label();
            lblEarnings = new Label();

            btnPrintStudents = new Button();
            btnPrintTeachers = new Button();
            btnPrintCourses = new Button();
            btnPrintPayments = new Button();

            SuspendLayout();

            BackColor = pageBg;
            ClientSize = new Size(1250, 749);
            Font = new Font("Segoe UI", 10F);
            Name = "ViewReportsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reports";
            Load += ViewReportsForm_Load;

            lblTitle.Text = "Campus Reports";
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblTitle.ForeColor = textDark;
            lblTitle.Location = new Point(55, 35);
            Controls.Add(lblTitle);

            lblSubTitle.Text = "Overview and printable analytics of campus management system.";
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 11F);
            lblSubTitle.ForeColor = muted;
            lblSubTitle.Location = new Point(60, 95);
            Controls.Add(lblSubTitle);

            SetupCard(card1, 60, 150);
            SetupCard(card2, 305, 150);
            SetupCard(card3, 550, 150);
            SetupCard(card4, 795, 150);
            SetupCard(card5, 1040, 150);

            SetupCardLabel(lblStudents, card1);
            SetupCardLabel(lblTeachers, card2);
            SetupCardLabel(lblCourses, card3);
            SetupCardLabel(lblPayments, card4);
            SetupCardLabel(lblEarnings, card5);

            SetupButton(btnPrintStudents, "Download Students PDF", 145, 380);
            SetupButton(btnPrintTeachers, "Download Teachers PDF", 395, 380);
            SetupButton(btnPrintCourses, "Download Courses PDF", 645, 380);
            SetupButton(btnPrintPayments, "Download Payments PDF", 895, 380);

            btnPrintStudents.Click += btnPrintStudents_Click;
            btnPrintTeachers.Click += btnPrintTeachers_Click;
            btnPrintCourses.Click += btnPrintCourses_Click;
            btnPrintPayments.Click += btnPrintPayments_Click;

            Controls.Add(card1);
            Controls.Add(card2);
            Controls.Add(card3);
            Controls.Add(card4);
            Controls.Add(card5);

            Controls.Add(btnPrintStudents);
            Controls.Add(btnPrintTeachers);
            Controls.Add(btnPrintCourses);
            Controls.Add(btnPrintPayments);

            ResumeLayout(false);
            PerformLayout();
        }

        private void SetupCard(Panel card, int x, int y)
        {
            card.Size = new Size(210, 155);
            card.Location = new Point(x, y);
            card.BackColor = Color.White;
            card.Paint += Card_Paint;
        }

        private void SetupCardLabel(Label lbl, Panel parent)
        {
            lbl.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbl.ForeColor = textDark;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Dock = DockStyle.Fill;
            parent.Controls.Add(lbl);
        }

        private void SetupButton(Button btn, string text, int x, int y)
        {
            btn.Text = text;
            btn.Size = new Size(210, 55);
            btn.Location = new Point(x, y);
            btn.BackColor = navy;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.MouseOverBackColor = blue;
            RoundControl(btn, 16);
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle shadowRect = new Rectangle(8, 8, panel.Width - 16, panel.Height - 16);
            using (GraphicsPath shadowPath = RoundPath(shadowRect, 20))
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(25, 15, 23, 42)))
            {
                e.Graphics.FillPath(shadowBrush, shadowPath);
            }

            Rectangle mainRect = new Rectangle(0, 0, panel.Width - 10, panel.Height - 10);
            using (GraphicsPath path = RoundPath(mainRect, 20))
            using (SolidBrush brush = new SolidBrush(Color.White))
            using (Pen pen = new Pen(Color.FromArgb(203, 213, 225), 1))
            {
                e.Graphics.FillPath(brush, path);
                e.Graphics.DrawPath(pen, path);
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