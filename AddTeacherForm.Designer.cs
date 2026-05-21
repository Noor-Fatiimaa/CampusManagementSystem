using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    partial class AddTeacherForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle, lblSubTitle, section;
        private TextBox txtFullName, txtEmail, txtPhone, txtDepartment, txtSubject, txtSalary;
        private Button btnSave, btnCancel;
        private Panel cardOuter, card;

        Color navy = Color.FromArgb(15, 23, 42);
        Color blue = Color.FromArgb(37, 99, 235);
        Color blueHover = Color.FromArgb(29, 78, 216);
        Color pageBg = Color.FromArgb(241, 245, 249);
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
            cardOuter = new Panel();
            card = new Panel();
            section = new Label();
            btnSave = new Button();
            btnCancel = new Button();

            cardOuter.SuspendLayout();
            card.SuspendLayout();
            SuspendLayout();

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = pageBg;
            ClientSize = new Size(984, 661);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(1000, 700);
            Name = "AddTeacherForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Teacher";
            Load += AddTeacherForm_Load;

            // Title
            lblTitle.Text = "Add Teacher";
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = textDark;
            lblTitle.Location = new Point(45, 35);
            lblTitle.Size = new Size(350, 45);
            lblTitle.BackColor = Color.Transparent;

            // Subtitle
            lblSubTitle.Text = "Enter teacher information and save it into the system";
            lblSubTitle.Font = new Font("Segoe UI", 10.5F);
            lblSubTitle.ForeColor = muted;
            lblSubTitle.Location = new Point(48, 82);
            lblSubTitle.Size = new Size(500, 28);
            lblSubTitle.BackColor = Color.Transparent;

            // Outer Card
            cardOuter.Location = new Point(45, 130);
            cardOuter.Size = new Size(880, 440);
            cardOuter.BackColor = Color.Transparent;
            cardOuter.Paint += PaintCard;

            // Inner Card
            card.Location = new Point(12, 12);
            card.Size = new Size(850, 410);
            card.BackColor = cardBg;

            // Section Heading
            section.Text = "Teacher Details";
            section.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            section.ForeColor = navy;
            section.Location = new Point(35, 25);
            section.Size = new Size(300, 35);
            section.BackColor = Color.Transparent;

            // Textboxes
            txtFullName = CreateTextBox(card, "Full Name", 35, 75);
            txtEmail = CreateTextBox(card, "Email", 430, 75);
            txtPhone = CreateTextBox(card, "Phone", 35, 155);
            txtDepartment = CreateTextBox(card, "Department", 430, 155);
            txtSubject = CreateTextBox(card, "Subject", 35, 235);
            txtSalary = CreateTextBox(card, "Salary", 430, 235);

            // Save Button
            btnSave.Text = "Save Teacher";
            btnSave.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.BackColor = blue;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Location = new Point(430, 335);
            btnSave.Size = new Size(170, 45);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Click += btnSave_Click;
            btnSave.MouseEnter += (s, e) => btnSave.BackColor = blueHover;
            btnSave.MouseLeave += (s, e) => btnSave.BackColor = blue;

            // Cancel Button
            btnCancel.Text = "Cancel";
            btnCancel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnCancel.ForeColor = textDark;
            btnCancel.BackColor = Color.FromArgb(226, 232, 240);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(203, 213, 225);
            btnCancel.Location = new Point(620, 335);
            btnCancel.Size = new Size(120, 45);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += btnCancel_Click;

            // Add controls
            card.Controls.Add(section);
            card.Controls.Add(btnSave);
            card.Controls.Add(btnCancel);

            cardOuter.Controls.Add(card);

            Controls.Add(lblTitle);
            Controls.Add(lblSubTitle);
            Controls.Add(cardOuter);

            cardOuter.ResumeLayout(false);
            card.ResumeLayout(false);
            card.PerformLayout();
            ResumeLayout(false);
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
                Font = new Font("Segoe UI", 11F),
                Size = new Size(360, 32),
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