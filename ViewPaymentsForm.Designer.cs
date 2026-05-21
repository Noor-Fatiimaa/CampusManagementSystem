using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    partial class ViewPaymentsForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtSearch;
        private Button btnSearch, btnRefresh;
        private DataGridView dgvPayments;
        private Label lblTitle, lblSubTitle;
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
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            dgvPayments = new DataGridView();
            lblTitle = new Label();
            lblSubTitle = new Label();
            cardOuter = new Panel();
            card = new Panel();

            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            SuspendLayout();

            Text = "View Payments";
            Size = new Size(1100, 720);
            MinimumSize = new Size(1100, 720);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = pageBg;
            Font = new Font("Segoe UI", 9.5f);

            lblTitle.Text = "View Payments";
            lblTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblTitle.ForeColor = textDark;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(70, 45);
            lblTitle.BackColor = Color.Transparent;
            Controls.Add(lblTitle);

            lblSubTitle.Text = "Search, refresh, and view student payment records.";
            lblSubTitle.Font = new Font("Segoe UI", 11);
            lblSubTitle.ForeColor = muted;
            lblSubTitle.AutoSize = true;
            lblSubTitle.Location = new Point(74, 98);
            lblSubTitle.BackColor = Color.Transparent;
            Controls.Add(lblSubTitle);

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
                Text = "Payment Records",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = navy,
                AutoSize = true,
                Location = new Point(25, 15),
                BackColor = Color.Transparent
            };
            card.Controls.Add(section);

            txtSearch.Font = new Font("Segoe UI", 11);
            txtSearch.Location = new Point(25, 65);
            txtSearch.Size = new Size(430, 36);
            txtSearch.PlaceholderText = "Search by student name";
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.BackColor = Color.FromArgb(248, 250, 252);
            txtSearch.ForeColor = textDark;
            txtSearch.Enter += (s, e) => txtSearch.BackColor = Color.White;
            txtSearch.Leave += (s, e) => txtSearch.BackColor = Color.FromArgb(248, 250, 252);
            card.Controls.Add(txtSearch);

            btnSearch.Text = "Search";
            btnSearch.Size = new Size(130, 42);
            btnSearch.Location = new Point(475, 62);
            btnSearch.BackColor = blue;
            btnSearch.ForeColor = Color.White;
            btnSearch.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseOverBackColor = blueHover;
            btnSearch.Click += btnSearch_Click;
            RoundControl(btnSearch, 14);
            card.Controls.Add(btnSearch);

            btnRefresh.Text = "Refresh";
            btnRefresh.Size = new Size(130, 42);
            btnRefresh.Location = new Point(620, 62);
            btnRefresh.BackColor = Color.FromArgb(241, 245, 249);
            btnRefresh.ForeColor = navy;
            btnRefresh.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(226, 232, 240);
            btnRefresh.Click += btnRefresh_Click;
            RoundControl(btnRefresh, 14);
            card.Controls.Add(btnRefresh);

            dgvPayments.Location = new Point(25, 125);
            dgvPayments.Size = new Size(890, 305);
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.BackgroundColor = Color.White;
            dgvPayments.BorderStyle = BorderStyle.None;
            dgvPayments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPayments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPayments.ColumnHeadersHeight = 42;
            dgvPayments.EnableHeadersVisualStyles = false;
            dgvPayments.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPayments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvPayments.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvPayments.DefaultCellStyle.ForeColor = textDark;
            dgvPayments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvPayments.DefaultCellStyle.SelectionForeColor = textDark;
            dgvPayments.GridColor = Color.FromArgb(226, 232, 240);
            dgvPayments.RowTemplate.Height = 36;
            dgvPayments.CellClick += dgvPayments_CellClick;
            card.Controls.Add(dgvPayments);

            Load += ViewPaymentsForm_Load;

            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
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