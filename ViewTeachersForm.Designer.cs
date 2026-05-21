using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    partial class ViewTeachersForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvTeachers;
        private Button btnRefresh;
        private Button btnEdit;
        private Button btnDelete;
        private Label lblTitle;
        private Label lblSubTitle;
        private Panel cardOuter;
        private Panel card;

        Color navy = Color.FromArgb(15, 23, 42);
        Color pageBg = Color.FromArgb(219, 234, 254);
        Color cardBg = Color.White;
        Color border = Color.FromArgb(203, 213, 225);
        Color textDark = Color.FromArgb(15, 23, 42);
        Color muted = Color.FromArgb(71, 85, 105);
        Color danger = Color.FromArgb(220, 38, 38);
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
            btnRefresh = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            cardOuter = new Panel();
            card = new Panel();
            dgvTeachers = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvTeachers).BeginInit();
            SuspendLayout();

            Text = "View Teachers";
            Size = new Size(1100, 720);
            MinimumSize = new Size(1100, 720);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = pageBg;
            Font = new Font("Segoe UI", 9.5f);

            lblTitle.Text = "Teachers List";
            lblTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblTitle.ForeColor = textDark;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(70, 45);
            lblTitle.BackColor = Color.Transparent;
            Controls.Add(lblTitle);

            lblSubTitle.Text = "View, refresh, edit, and delete teacher records from the system.";
            lblSubTitle.Font = new Font("Segoe UI", 11);
            lblSubTitle.ForeColor = muted;
            lblSubTitle.AutoSize = true;
            lblSubTitle.Location = new Point(74, 98);
            lblSubTitle.BackColor = Color.Transparent;
            Controls.Add(lblSubTitle);

            btnRefresh.Text = "Refresh";
            btnRefresh.Size = new Size(135, 48);
            btnRefresh.Location = new Point(610, 60);
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

            btnEdit.Text = "Edit";
            btnEdit.Size = new Size(135, 48);
            btnEdit.Location = new Point(760, 60);
            btnEdit.BackColor = blue;
            btnEdit.ForeColor = Color.White;
            btnEdit.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnEdit.Click += btnEdit_Click;
            RoundControl(btnEdit, 14);
            Controls.Add(btnEdit);

            btnDelete.Text = "Delete";
            btnDelete.Size = new Size(135, 48);
            btnDelete.Location = new Point(910, 60);
            btnDelete.BackColor = danger;
            btnDelete.ForeColor = Color.White;
            btnDelete.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(185, 28, 28);
            btnDelete.Click += btnDelete_Click;
            RoundControl(btnDelete, 14);
            Controls.Add(btnDelete);

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
                Text = "Teacher Records",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = navy,
                AutoSize = true,
                Location = new Point(25, 15),
                BackColor = Color.Transparent
            };
            card.Controls.Add(section);

            dgvTeachers.Location = new Point(25, 65);
            dgvTeachers.Size = new Size(890, 365);
            dgvTeachers.BackgroundColor = Color.White;
            dgvTeachers.BorderStyle = BorderStyle.None;
            dgvTeachers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTeachers.RowHeadersVisible = false;
            dgvTeachers.ReadOnly = true;
            dgvTeachers.AllowUserToAddRows = false;
            dgvTeachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeachers.MultiSelect = false;
            dgvTeachers.EnableHeadersVisualStyles = false;
            dgvTeachers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTeachers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTeachers.GridColor = Color.FromArgb(226, 232, 240);

            dgvTeachers.ColumnHeadersHeight = 42;
            dgvTeachers.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvTeachers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTeachers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvTeachers.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTeachers.DefaultCellStyle.ForeColor = textDark;
            dgvTeachers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvTeachers.DefaultCellStyle.SelectionForeColor = textDark;
            dgvTeachers.RowTemplate.Height = 36;

            card.Controls.Add(dgvTeachers);

            Load += ViewTeachersForm_Load;

            ((System.ComponentModel.ISupportInitialize)dgvTeachers).EndInit();
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