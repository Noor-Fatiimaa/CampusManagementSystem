using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    partial class EditCourseForm
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
            btnUpdate = new Button();
            cardOuter = new Panel();
            card = new Panel();
            cardOuter.SuspendLayout();
            card.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.Location = new Point(65, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(225, 51);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Edit Course";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 11F);
            lblSubTitle.Location = new Point(70, 95);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(249, 20);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Update selected course information.";
            // 
            // lblCourseName
            // 
            lblCourseName.AutoSize = true;
            lblCourseName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCourseName.Location = new Point(45, 35);
            lblCourseName.Name = "lblCourseName";
            lblCourseName.Size = new Size(99, 19);
            lblCourseName.TabIndex = 0;
            lblCourseName.Text = "Course Name";
            // 
            // lblCourseCode
            // 
            lblCourseCode.AutoSize = true;
            lblCourseCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCourseCode.Location = new Point(45, 110);
            lblCourseCode.Name = "lblCourseCode";
            lblCourseCode.Size = new Size(94, 19);
            lblCourseCode.TabIndex = 2;
            lblCourseCode.Text = "Course Code";
            // 
            // lblCreditHours
            // 
            lblCreditHours.AutoSize = true;
            lblCreditHours.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCreditHours.Location = new Point(45, 185);
            lblCreditHours.Name = "lblCreditHours";
            lblCreditHours.Size = new Size(94, 19);
            lblCreditHours.TabIndex = 4;
            lblCreditHours.Text = "Credit Hours";
            // 
            // lblTeacherName
            // 
            lblTeacherName.AutoSize = true;
            lblTeacherName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTeacherName.Location = new Point(45, 260);
            lblTeacherName.Name = "lblTeacherName";
            lblTeacherName.Size = new Size(105, 19);
            lblTeacherName.TabIndex = 6;
            lblTeacherName.Text = "Teacher Name";
            // 
            // txtCourseName
            // 
            txtCourseName.Font = new Font("Segoe UI", 10F);
            txtCourseName.Location = new Point(45, 62);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(480, 25);
            txtCourseName.TabIndex = 1;
            // 
            // txtCourseCode
            // 
            txtCourseCode.Font = new Font("Segoe UI", 10F);
            txtCourseCode.Location = new Point(45, 137);
            txtCourseCode.Name = "txtCourseCode";
            txtCourseCode.Size = new Size(480, 25);
            txtCourseCode.TabIndex = 3;
            // 
            // txtCreditHours
            // 
            txtCreditHours.Font = new Font("Segoe UI", 10F);
            txtCreditHours.Location = new Point(45, 212);
            txtCreditHours.Name = "txtCreditHours";
            txtCreditHours.Size = new Size(480, 25);
            txtCreditHours.TabIndex = 5;
            // 
            // txtTeacherName
            // 
            txtTeacherName.Font = new Font("Segoe UI", 10F);
            txtTeacherName.Location = new Point(45, 287);
            txtTeacherName.Name = "txtTeacherName";
            txtTeacherName.Size = new Size(480, 25);
            txtTeacherName.TabIndex = 7;
            // 
            // btnUpdate
            // 
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(45, 335);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(480, 45);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update Course";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // cardOuter
            // 
            cardOuter.BackColor = Color.Transparent;
            cardOuter.Controls.Add(card);
            cardOuter.Location = new Point(65, 145);
            cardOuter.Name = "cardOuter";
            cardOuter.Size = new Size(620, 430);
            cardOuter.TabIndex = 2;
            cardOuter.Paint += PaintCard;
            // 
            // card
            // 
            card.BackColor = Color.White;
            card.Controls.Add(lblCourseName);
            card.Controls.Add(txtCourseName);
            card.Controls.Add(lblCourseCode);
            card.Controls.Add(txtCourseCode);
            card.Controls.Add(lblCreditHours);
            card.Controls.Add(txtCreditHours);
            card.Controls.Add(lblTeacherName);
            card.Controls.Add(txtTeacherName);
            card.Controls.Add(btnUpdate);
            card.Location = new Point(20, 20);
            card.Name = "card";
            card.Size = new Size(580, 390);
            card.TabIndex = 0;
            // 
            // EditCourseForm
            // 
            ClientSize = new Size(744, 611);
            Controls.Add(lblTitle);
            Controls.Add(lblSubTitle);
            Controls.Add(cardOuter);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(760, 650);
            Name = "EditCourseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Course";
            Load += EditCourseForm_Load;
            cardOuter.ResumeLayout(false);
            card.ResumeLayout(false);
            card.PerformLayout();
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