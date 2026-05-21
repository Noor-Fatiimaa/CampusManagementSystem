using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    partial class AddStudentForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtFullName;
        private TextBox txtFatherName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtClass;
        private TextBox txtAddress;
        private ComboBox cmbGender;
        private Button btnSave;
        private Button btnClear;

        private Color navy = Color.FromArgb(15, 23, 42);
        private Color blue = Color.FromArgb(37, 99, 235);
        private Color blueHover = Color.FromArgb(29, 78, 216);
        private Color pageBg = Color.FromArgb(219, 234, 254);
        private Color cardBg = Color.White;
        private Color border = Color.FromArgb(203, 213, 225);
        private Color textDark = Color.FromArgb(15, 23, 42);
        private Color muted = Color.FromArgb(71, 85, 105);

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            Text = "Add Student";
            Size = new Size(1000, 700);
            MinimumSize = new Size(1000, 700);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = pageBg;
            Font = new Font("Segoe UI", 9.5f);
            Load += AddStudentForm_Load;

            Label title = new Label
            {
                Text = "Add New Student",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = textDark,
                AutoSize = true,
                Location = new Point(70, 45),
                BackColor = Color.Transparent
            };
            Controls.Add(title);

            Label subTitle = new Label
            {
                Text = "Create a new student profile with complete academic information.",
                Font = new Font("Segoe UI", 11),
                ForeColor = muted,
                AutoSize = true,
                Location = new Point(74, 98),
                BackColor = Color.Transparent
            };
            Controls.Add(subTitle);

            Panel cardOuter = new Panel
            {
                Size = new Size(850, 470),
                Location = new Point(70, 145),
                BackColor = Color.Transparent
            };
            cardOuter.Paint += PaintCard;
            Controls.Add(cardOuter);

            Panel card = new Panel
            {
                Size = new Size(810, 430),
                Location = new Point(20, 20),
                BackColor = Color.White
            };
            cardOuter.Controls.Add(card);

            Label section = new Label
            {
                Text = "Student Information",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = navy,
                AutoSize = true,
                Location = new Point(25, 15),
                BackColor = Color.Transparent
            };
            card.Controls.Add(section);

            txtFullName = CreateTextBox(card, "Full Name", 25, 70);
            txtFatherName = CreateTextBox(card, "Father Name", 425, 70);

            txtEmail = CreateTextBox(card, "Email Address", 25, 150);
            txtPhone = CreateTextBox(card, "Phone Number", 425, 150);

            cmbGender = CreateComboBox(card, "Gender", 25, 230);
            txtClass = CreateTextBox(card, "Class Name", 425, 230);

            txtAddress = CreateTextBox(card, "Address", 25, 310);
            txtAddress.Width = 760;

            btnClear = new Button
            {
                Text = "Clear",
                Size = new Size(135, 48),
                Location = new Point(475, 370),
                BackColor = Color.FromArgb(241, 245, 249),
                ForeColor = navy,
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(226, 232, 240);
            btnClear.Click += BtnClear_Click;
            RoundControl(btnClear, 14);
            card.Controls.Add(btnClear);

            btnSave = new Button
            {
                Text = "Save Student",
                Size = new Size(175, 48),
                Location = new Point(630, 370),
                BackColor = blue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseOverBackColor = blueHover;
            btnSave.Click += BtnSave_Click;
            RoundControl(btnSave, 14);
            card.Controls.Add(btnSave);
        }

        private TextBox CreateTextBox(Panel parent, string labelText, int x, int y)
        {
            Label lbl = new Label
            {
                Text = labelText,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = textDark,
                Location = new Point(x, y),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            parent.Controls.Add(lbl);

            TextBox txt = new TextBox
            {
                Font = new Font("Segoe UI", 11),
                Size = new Size(360, 36),
                Location = new Point(x, y + 27),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(248, 250, 252),
                ForeColor = textDark
            };

            txt.Enter += (s, e) => txt.BackColor = Color.White;
            txt.Leave += (s, e) => txt.BackColor = Color.FromArgb(248, 250, 252);

            parent.Controls.Add(txt);
            return txt;
        }

        private ComboBox CreateComboBox(Panel parent, string labelText, int x, int y)
        {
            Label lbl = new Label
            {
                Text = labelText,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = textDark,
                Location = new Point(x, y),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            parent.Controls.Add(lbl);

            ComboBox cmb = new ComboBox
            {
                Font = new Font("Segoe UI", 11),
                Size = new Size(360, 36),
                Location = new Point(x, y + 27),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(248, 250, 252),
                ForeColor = textDark
            };

            cmb.Items.Add("Male");
            cmb.Items.Add("Female");
            cmb.Items.Add("Other");
            cmb.SelectedIndex = -1;

            parent.Controls.Add(cmb);
            return cmb;
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