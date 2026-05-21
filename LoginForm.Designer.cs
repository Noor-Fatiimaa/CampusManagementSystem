using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();

            pnlLeft = new Panel();
            pnlRight = new Panel();
            pnlCard = new Panel();
            pnlStats = new Panel();

            lblLogo = new Label();
            lblBrand = new Label();
            lblBrandSub = new Label();
            lblHeadline = new Label();
            lblSubtext = new Label();

            lblCardIcon = new Label();
            lblTitle = new Label();
            lblCardSub = new Label();
            lblUser = new Label();
            lblPass = new Label();
            lblForgot = new Label();
            lblFooter = new Label();

            SuspendLayout();

            Color navy = Color.FromArgb(15, 23, 42);
            Color navyMid = Color.FromArgb(22, 34, 62);
            Color gold = Color.FromArgb(246, 189, 79);
            Color pageBg = Color.FromArgb(248, 249, 252);
            Color white = Color.White;
            Color muted = Color.FromArgb(156, 163, 175);
            Color textDark = Color.FromArgb(15, 23, 42);

            Text = "Campus Management System";
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1100, 680);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = pageBg;
            FormBorderStyle = FormBorderStyle.Sizable;
            Font = new Font("Segoe UI", 9.5f);
            Load += LoginForm_Load;

            // LEFT PANEL
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Width = 460;
            pnlLeft.BackColor = navy;
            pnlLeft.Padding = new Padding(45, 40, 45, 40);

            lblLogo.Text = "⬡";
            lblLogo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblLogo.ForeColor = navy;
            lblLogo.BackColor = gold;
            lblLogo.Size = new Size(42, 42);
            lblLogo.Location = new Point(45, 40);
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            RoundControl(lblLogo, 12);

            lblBrand.Text = "Campus";
            lblBrand.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            lblBrand.ForeColor = white;
            lblBrand.AutoSize = true;
            lblBrand.Location = new Point(100, 42);

            lblBrandSub.Text = "Management System";
            lblBrandSub.Font = new Font("Segoe UI", 9);
            lblBrandSub.ForeColor = Color.FromArgb(148, 163, 184);
            lblBrandSub.AutoSize = true;
            lblBrandSub.Location = new Point(102, 67);

            lblHeadline.Text = "Manage your campus\nsmarter, faster.";
            lblHeadline.Font = new Font("Segoe UI", 26, FontStyle.Bold);
            lblHeadline.ForeColor = white;
            lblHeadline.Size = new Size(370, 120);
            lblHeadline.Location = new Point(45, 170);

            lblSubtext.Text = "One unified platform for students, teachers,\ncourses, attendance, reports, and payments.";
            lblSubtext.Font = new Font("Segoe UI", 11);
            lblSubtext.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubtext.Size = new Size(370, 70);
            lblSubtext.Location = new Point(48, 310);

          

         

            pnlLeft.Controls.AddRange(new Control[]
            {
                lblLogo, lblBrand, lblBrandSub,
                lblHeadline, lblSubtext, pnlStats
            });

            // RIGHT PANEL
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.BackColor = pageBg;

            pnlCard.Size = new Size(390, 455);
            pnlCard.BackColor = white;
            pnlCard.Anchor = AnchorStyles.None;
            pnlCard.Paint += (s, e) => PaintCard(e, pnlCard);

            pnlRight.Resize += (s, e) =>
            {
                pnlCard.Location = new Point(
                    (pnlRight.Width - pnlCard.Width) / 2,
                    (pnlRight.Height - pnlCard.Height) / 2
                );
            };

            lblCardIcon.Text = "🏛";
            lblCardIcon.Font = new Font("Segoe UI Emoji", 22);
            lblCardIcon.BackColor = Color.FromArgb(255, 248, 231);
            lblCardIcon.Size = new Size(58, 58);
            lblCardIcon.Location = new Point(166, 30);
            lblCardIcon.TextAlign = ContentAlignment.MiddleCenter;
            RoundControl(lblCardIcon, 16);

            lblTitle.Text = "Welcome back";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = textDark;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(112, 105);

            lblCardSub.Text = "Sign in to continue to dashboard";
            lblCardSub.Font = new Font("Segoe UI", 10);
            lblCardSub.ForeColor = muted;
            lblCardSub.AutoSize = true;
            lblCardSub.Location = new Point(92, 138);

            lblUser.Text = "USERNAME";
            lblUser.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            lblUser.ForeColor = Color.FromArgb(55, 65, 81);
            lblUser.AutoSize = true;
            lblUser.Location = new Point(40, 185);

            txtUsername.Location = new Point(40, 208);
            txtUsername.Size = new Size(310, 34);
            txtUsername.Font = new Font("Segoe UI", 11);
            txtUsername.BackColor = pageBg;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Name = "txtUsername";
            txtUsername.TabIndex = 0;

            lblPass.Text = "PASSWORD";
            lblPass.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            lblPass.ForeColor = Color.FromArgb(55, 65, 81);
            lblPass.AutoSize = true;
            lblPass.Location = new Point(40, 265);

            txtPassword.Location = new Point(40, 288);
            txtPassword.Size = new Size(310, 34);
            txtPassword.Font = new Font("Segoe UI", 11);
            txtPassword.BackColor = pageBg;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.Name = "txtPassword";
            txtPassword.TabIndex = 1;

            lblForgot.Text = "Forgot password?";
            lblForgot.Font = new Font("Segoe UI", 9, FontStyle.Bold | FontStyle.Underline);
            lblForgot.ForeColor = gold;
            lblForgot.AutoSize = true;
            lblForgot.Location = new Point(230, 330);
            lblForgot.Cursor = Cursors.Hand;
            lblForgot.Click += lblForgot_Click;

            btnLogin.Text = "SIGN IN";
            btnLogin.Location = new Point(40, 365);
            btnLogin.Size = new Size(310, 46);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.BackColor = navy;
            btnLogin.ForeColor = gold;
            btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.TabIndex = 2;
            btnLogin.Name = "btnLogin";
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = navyMid;
            btnLogin.Click += btnLogin_Click;
            RoundControl(btnLogin, 12);

            lblFooter.Text = "Campus Management System © 2026";
            lblFooter.Font = new Font("Segoe UI", 8.5f);
            lblFooter.ForeColor = muted;
            lblFooter.AutoSize = true;
            lblFooter.Location = new Point(92, 425);

            pnlCard.Controls.AddRange(new Control[]
            {
                lblCardIcon, lblTitle, lblCardSub,
                lblUser, txtUsername,
                lblPass, txtPassword,
                lblForgot, btnLogin, lblFooter
            });

            pnlRight.Controls.Add(pnlCard);

            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);

            ResumeLayout(false);
        }

        private void AddStat(Panel parent, string val, string key, int x, Color valColor, Color keyColor)
        {
            Label v = new Label
            {
                Text = val,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = valColor,
                AutoSize = true,
                Location = new Point(x, 30),
                BackColor = Color.Transparent
            };

            Label k = new Label
            {
                Text = key,
                Font = new Font("Segoe UI", 9),
                ForeColor = keyColor,
                AutoSize = true,
                Location = new Point(x, 65),
                BackColor = Color.Transparent
            };

            parent.Controls.Add(v);
            parent.Controls.Add(k);
        }

        private static void RoundControl(Control c, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            Rectangle r = c.ClientRectangle;

            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            c.Region = new Region(path);
        }

        private static void PaintCard(PaintEventArgs e, Panel card)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = RoundPath(card.ClientRectangle, 20))
            {
                using (SolidBrush br = new SolidBrush(Color.White))
                    g.FillPath(br, path);

                using (Pen pen = new Pen(Color.FromArgb(229, 232, 240), 1))
                    g.DrawPath(pen, path);
            }
        }

        private static void PaintStatsBox(PaintEventArgs e, Panel panel)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = RoundPath(panel.ClientRectangle, 18))
            {
                using (SolidBrush br = new SolidBrush(Color.FromArgb(22, 34, 62)))
                    g.FillPath(br, path);
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

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;

        private Panel pnlLeft;
        private Panel pnlRight;
        private Panel pnlCard;
        private Panel pnlStats;

        private Label lblLogo;
        private Label lblBrand;
        private Label lblBrandSub;
        private Label lblHeadline;
        private Label lblSubtext;

        private Label lblCardIcon;
        private Label lblTitle;
        private Label lblCardSub;
        private Label lblUser;
        private Label lblPass;
        private Label lblForgot;
        private Label lblFooter;
    }
}