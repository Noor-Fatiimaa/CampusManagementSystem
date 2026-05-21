using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    partial class AddPaymentForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle, lblSubTitle, lblSection;
        private Label lblStudent, lblAmount, lblPaymentDate, lblPaymentMethod, lblRemarks;
        private ComboBox cmbStudent, cmbPaymentMethod;
        private TextBox txtAmount, txtRemarks;
        private DateTimePicker dtpPaymentDate;
        private Button btnSave;
        private Panel cardOuter, card;

        Color cardBg = Color.White;
        Color border = Color.FromArgb(203, 213, 225);
        Color textDark = Color.FromArgb(15, 23, 42);

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
            lblSection = new Label();

            lblStudent = new Label();
            lblAmount = new Label();
            lblPaymentDate = new Label();
            lblPaymentMethod = new Label();
            lblRemarks = new Label();

            cmbStudent = new ComboBox();
            txtAmount = new TextBox();
            dtpPaymentDate = new DateTimePicker();
            cmbPaymentMethod = new ComboBox();
            txtRemarks = new TextBox();
            btnSave = new Button();

            cardOuter = new Panel();
            card = new Panel();

            cardOuter.SuspendLayout();
            card.SuspendLayout();
            SuspendLayout();

            // Form
            ClientSize = new Size(984, 661);
            MinimumSize = new Size(1000, 700);
            Font = new Font("Segoe UI", 9.5F);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Payment";
            BackColor = Color.FromArgb(245, 247, 251);
            Load += AddPaymentForm_Load;

            // Title
            lblTitle.Text = "Add New Payment";
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(70, 45);

            // Subtitle
            lblSubTitle.Text = "Record student fee payment with amount, date, and payment method.";
            lblSubTitle.Font = new Font("Segoe UI", 11F);
            lblSubTitle.AutoSize = true;
            lblSubTitle.Location = new Point(74, 98);

            // Card Outer
            cardOuter.BackColor = Color.Transparent;
            cardOuter.Location = new Point(70, 145);
            cardOuter.Size = new Size(850, 470);
            cardOuter.Paint += PaintCard;
            cardOuter.Controls.Add(card);

            // Card
            card.BackColor = Color.White;
            card.Location = new Point(20, 20);
            card.Size = new Size(810, 430);

            // Section
            lblSection.Text = "Payment Information";
            lblSection.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSection.AutoSize = true;
            lblSection.Location = new Point(35, 25);

            // Labels
            CreateLabel(lblStudent, "Student", 35, 80);
            CreateLabel(lblAmount, "Amount", 425, 80);
            CreateLabel(lblPaymentDate, "Payment Date", 35, 160);
            CreateLabel(lblPaymentMethod, "Payment Method", 425, 160);
            CreateLabel(lblRemarks, "Remarks", 35, 240);

            // Student ComboBox
            cmbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudent.Font = new Font("Segoe UI", 11F);
            cmbStudent.BackColor = Color.FromArgb(248, 250, 252);
            cmbStudent.Location = new Point(35, 110);
            cmbStudent.Size = new Size(360, 28);

            // Amount TextBox
            txtAmount.Font = new Font("Segoe UI", 11F);
            txtAmount.Location = new Point(425, 110);
            txtAmount.Size = new Size(360, 28);
            txtAmount.BorderStyle = BorderStyle.FixedSingle;
            txtAmount.BackColor = Color.FromArgb(248, 250, 252);
            txtAmount.PlaceholderText = "Enter amount";

            // Payment Date
            dtpPaymentDate.Font = new Font("Segoe UI", 11F);
            dtpPaymentDate.Location = new Point(35, 190);
            dtpPaymentDate.Size = new Size(360, 27);

            // Payment Method
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Font = new Font("Segoe UI", 11F);
            cmbPaymentMethod.BackColor = Color.FromArgb(248, 250, 252);
            cmbPaymentMethod.Location = new Point(425, 190);
            cmbPaymentMethod.Size = new Size(360, 28);

            // Remarks
            txtRemarks.Font = new Font("Segoe UI", 11F);
            txtRemarks.Location = new Point(35, 270);
            txtRemarks.Size = new Size(750, 70);
            txtRemarks.Multiline = true;
            txtRemarks.BorderStyle = BorderStyle.FixedSingle;
            txtRemarks.BackColor = Color.FromArgb(248, 250, 252);
            txtRemarks.PlaceholderText = "Enter remarks";

            // Save Button
            btnSave.Text = "Save Payment";
            btnSave.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Cursor = Cursors.Hand;
            btnSave.Location = new Point(610, 360);
            btnSave.Size = new Size(175, 48);
            btnSave.Click += btnSave_Click;

            // Add controls to card
            card.Controls.Add(lblSection);
            card.Controls.Add(lblStudent);
            card.Controls.Add(lblAmount);
            card.Controls.Add(lblPaymentDate);
            card.Controls.Add(lblPaymentMethod);
            card.Controls.Add(lblRemarks);
            card.Controls.Add(cmbStudent);
            card.Controls.Add(txtAmount);
            card.Controls.Add(dtpPaymentDate);
            card.Controls.Add(cmbPaymentMethod);
            card.Controls.Add(txtRemarks);
            card.Controls.Add(btnSave);

            // Add controls to form
            Controls.Add(lblTitle);
            Controls.Add(lblSubTitle);
            Controls.Add(cardOuter);

            cardOuter.ResumeLayout(false);
            card.ResumeLayout(false);
            card.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void CreateLabel(Label lbl, string text, int x, int y)
        {
            lbl.Text = text;
            lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl.ForeColor = textDark;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            lbl.BackColor = Color.Transparent;
        }

        private void PaintCard(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

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