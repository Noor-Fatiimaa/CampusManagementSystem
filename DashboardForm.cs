using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class DashboardForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        private string userRole;

        Panel sidebar, content, cardPanel, chartPanel, activityPanel;
        Button activeBtn;

        Color dark = Color.FromArgb(15, 23, 42);
        Color dark2 = Color.FromArgb(30, 41, 59);
        Color gold = Color.FromArgb(245, 158, 11);
        Color page = Color.FromArgb(241, 245, 249);
        Color blue = Color.FromArgb(59, 130, 246);
        Color green = Color.FromArgb(16, 185, 129);
        Color purple = Color.FromArgb(139, 92, 246);
        Color text = Color.FromArgb(15, 23, 42);
        Color muted = Color.FromArgb(100, 116, 139);

        public DashboardForm(string role)
        {
            InitializeComponent();
            userRole = role;
            BuildDashboard();
        }

        private void BuildDashboard()
        {
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1250, 720);
            BackColor = page;
            Font = new Font("Segoe UI", 10);

            sidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 250,
                BackColor = dark
            };

            content = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = page
            };

            Controls.Add(content);
            Controls.Add(sidebar);

            BuildSidebar();
            BuildContent();
        }

        private void BuildSidebar()
        {
            sidebar.Controls.Clear();

            Label logo = new Label
            {
                Text = "🎓  Campus CMS\n" + userRole.ToUpper() + " PANEL",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(22, 25),
                Size = new Size(210, 60)
            };
            sidebar.Controls.Add(logo);

            AddSection("OVERVIEW", 105);
            AddMenu("🏠  Dashboard", 135, true, null);

            AddSection("MANAGEMENT", 195);

            if (userRole == "Admin")
            {
                AddMenu("🎓  Students", 225, false, null, new[]
                {
                    ("➕ Add Student", "AddStudentForm"),
                    ("📄 View Students", "ViewStudentsForm")
                });

                AddMenu("👩‍🏫  Teachers", 270, false, null, new[]
                {
                    ("➕ Add Teacher", "AddTeacherForm"),
                    ("📄 View Teachers", "ViewTeachersForm")
                });

                AddMenu("📚  Courses", 315, false, null, new[]
                {
                    ("➕ Add Course", "AddCourseForm"),
                    ("📄 View Courses", "ViewCoursesForm")
                });

                AddMenu("📋  Attendance", 360, false, null, new[]
                {
                    ("➕ Mark Attendance", "MarkAttendanceForm"),
                    ("📄 View Attendance", "ViewAttendanceForm")
                });

                AddSection("FINANCE", 420);

                AddMenu("💳  Payments", 450, false, null, new[]
                {
                    ("➕ Add Payment", "AddPaymentForm"),
                    ("📄 View Payments", "ViewPaymentsForm")
                });

                AddMenu("📊  Reports", 495, false, null, new[]
                {
                    ("📈 View Reports", "ViewReportsForm")
                });

                AddMenu("⚙️  Settings", 540, false, "SettingsForm");
            }
            else if (userRole == "Teacher")
            {
                AddMenu("🎓  Students", 225, false, null, new[]
                {
                    ("➕ Add Student", "AddStudentForm"),
                    ("📄 View Students", "ViewStudentsForm")
                });

                AddMenu("📋  Attendance", 270, false, null, new[]
                {
                    ("➕ Mark Attendance", "MarkAttendanceForm"),
                    ("📄 View Attendance", "ViewAttendanceForm")
                });
            }
            else if (userRole == "Accountant")
            {
                AddSection("FINANCE", 225);

                AddMenu("💳  Payments", 255, false, null, new[]
                {
                    ("➕ Add Payment", "AddPaymentForm"),
                    ("📄 View Payments", "ViewPaymentsForm")
                });

                AddMenu("📊  Reports", 300, false, null, new[]
                {
                    ("📈 View Reports", "ViewReportsForm")
                });
            }

            AddLogoutButton();
        }

        private void AddLogoutButton()
        {
            Button logout = new Button
            {
                Text = "🚪  Logout",
                Size = new Size(210, 45),
                Location = new Point(20, 650),
                Anchor = AnchorStyles.Left | AnchorStyles.Bottom,
                BackColor = dark2,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            logout.FlatAppearance.BorderSize = 0;

            logout.Click += (s, e) =>
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to logout?",
                    "Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    LoginForm login = new LoginForm();
                    login.Show();
                    this.Close();
                }
            };

            sidebar.Controls.Add(logout);
        }

        private void AddSection(string title, int y)
        {
            sidebar.Controls.Add(new Label
            {
                Text = title,
                ForeColor = Color.FromArgb(148, 163, 184),
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                Location = new Point(22, y),
                AutoSize = true
            });
        }

        private void AddMenu(string title, int y, bool active, string formName, (string text, string formName)[] subMenus = null)
        {
            Button btn = new Button
            {
                Text = "  " + title,
                Size = new Size(210, 40),
                Location = new Point(20, y),
                BackColor = active ? Color.FromArgb(55, 48, 37) : dark,
                ForeColor = active ? gold : Color.FromArgb(203, 213, 225),
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = dark2;

            if (active) activeBtn = btn;

            btn.Click += (s, e) =>
            {
                SetActive(btn);

                if (subMenus != null)
                {
                    ShowSubMenu(btn, subMenus);
                }
                else if (formName != null)
                {
                    OpenForm(formName);
                    RefreshDashboard();
                }
                else
                {
                    BuildContent();
                }
            };

            sidebar.Controls.Add(btn);
        }

        private void ShowSubMenu(Button parent, (string text, string formName)[] items)
        {
            ContextMenuStrip menu = new ContextMenuStrip
            {
                Font = new Font("Segoe UI", 10),
                BackColor = Color.White
            };

            foreach (var item in items)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem(item.text);

                mi.Click += (s, e) =>
                {
                    OpenForm(item.formName);
                    RefreshDashboard();
                };

                menu.Items.Add(mi);
            }

            menu.Show(parent, new Point(parent.Width - 5, 0));
        }

        private void SetActive(Button btn)
        {
            if (activeBtn != null)
            {
                activeBtn.BackColor = dark;
                activeBtn.ForeColor = Color.FromArgb(203, 213, 225);
            }

            btn.BackColor = Color.FromArgb(55, 48, 37);
            btn.ForeColor = gold;
            activeBtn = btn;
        }

        private void OpenForm(string formName)
        {
            Type t = Type.GetType("CampusManagementSystem2." + formName);

            if (t == null)
            {
                MessageBox.Show(formName + " not found.");
                return;
            }

            Form f = (Form)Activator.CreateInstance(t);
            f.ShowDialog();
        }

        private void BuildContent()
        {
            content.Controls.Clear();

            Label title = new Label
            {
                Text = "Dashboard Overview",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = text,
                Location = new Point(35, 28),
                AutoSize = true
            };
            content.Controls.Add(title);

            Label date = new Label
            {
                Text = DateTime.Now.ToString("dddd, dd MMM yyyy"),
                Font = new Font("Segoe UI", 11),
                ForeColor = muted,
                Location = new Point(900, 43),
                AutoSize = true
            };
            content.Controls.Add(date);

            cardPanel = new Panel
            {
                Location = new Point(35, 105),
                Size = new Size(960, 145),
                BackColor = page
            };
            content.Controls.Add(cardPanel);

            chartPanel = new Panel
            {
                Location = new Point(35, 285),
                Size = new Size(660, 355),
                BackColor = Color.White
            };
            chartPanel.Paint += DrawChart;
            content.Controls.Add(chartPanel);

            activityPanel = new Panel
            {
                Location = new Point(730, 285),
                Size = new Size(370, 355),
                BackColor = Color.White
            };
            activityPanel.Paint += PanelBorderPaint;
            content.Controls.Add(activityPanel);

            RefreshDashboard();
        }

        private void RefreshDashboard()
        {
            if (cardPanel == null) return;

            cardPanel.Controls.Clear();

            CreateStatCard("Total Students", GetCount("Students").ToString(), "🎓", blue, 0);
            CreateStatCard("Total Teachers", GetCount("Teachers").ToString(), "👩‍🏫", gold, 225);
            CreateStatCard("Active Courses", GetCount("Courses").ToString(), "📚", green, 450);
            CreateStatCard("Total Payments", GetCount("Payments").ToString(), "💳", purple, 675);

            LoadActivity();

            if (chartPanel != null)
                chartPanel.Invalidate();
        }

        private void CreateStatCard(string title, string value, string icon, Color accent, int x)
        {
            Panel card = new Panel
            {
                Location = new Point(x, 0),
                Size = new Size(205, 130),
                BackColor = Color.White
            };
            card.Paint += PanelBorderPaint;

            Panel line = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 5,
                BackColor = accent
            };

            Label iconLbl = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI Emoji", 21),
                Location = new Point(20, 15),
                Size = new Size(50, 40)
            };

            Label valueLbl = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = text,
                Location = new Point(22, 55),
                Size = new Size(160, 38)
            };

            Label titleLbl = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9),
                ForeColor = muted,
                Location = new Point(24, 95),
                Size = new Size(160, 22)
            };

            card.Controls.Add(line);
            card.Controls.Add(iconLbl);
            card.Controls.Add(valueLbl);
            card.Controls.Add(titleLbl);

            cardPanel.Controls.Add(card);
        }

        private void LoadActivity()
        {
            if (activityPanel == null) return;

            activityPanel.Controls.Clear();

            Label heading = new Label
            {
                Text = "Recent Activity",
                Font = new Font("Segoe UI", 17, FontStyle.Bold),
                ForeColor = text,
                Location = new Point(25, 25),
                AutoSize = true
            };
            activityPanel.Controls.Add(heading);

            Label small = new Label
            {
                Text = "Current system overview",
                Font = new Font("Segoe UI", 9),
                ForeColor = muted,
                Location = new Point(27, 58),
                AutoSize = true
            };
            activityPanel.Controls.Add(small);

            AddActivityBox("Students", GetCount("Students") + " total records", "🎓", blue, 95);
            AddActivityBox("Teachers", GetCount("Teachers") + " total records", "👩‍🏫", gold, 155);
            AddActivityBox("Courses", GetCount("Courses") + " active courses", "📚", green, 215);
            AddActivityBox("Earnings", "Rs. " + GetTotalEarnings(), "💰", purple, 275);
        }

        private void AddActivityBox(string title, string desc, string icon, Color color, int y)
        {
            Panel box = new Panel
            {
                Location = new Point(25, y),
                Size = new Size(315, 45),
                BackColor = Color.FromArgb(248, 250, 252)
            };
            box.Paint += PanelBorderPaint;

            Label iconLbl = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI Emoji", 15),
                Location = new Point(10, 8),
                Size = new Size(35, 30),
                ForeColor = color
            };

            Label lbl = new Label
            {
                Text = title + "  -  " + desc,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = text,
                Location = new Point(50, 13),
                Size = new Size(250, 25)
            };

            box.Controls.Add(iconLbl);
            box.Controls.Add(lbl);
            activityPanel.Controls.Add(box);
        }

        private void DrawChart(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            PanelBorderPaint(sender, e);

            int students = GetCount("Students");
            int teachers = GetCount("Teachers");
            int courses = GetCount("Courses");
            int payments = GetCount("Payments");

            int[] values = { students, teachers, courses, payments };
            string[] labels = { "Students", "Teachers", "Courses", "Payments" };
            Color[] colors = { blue, gold, green, purple };

            int max = Math.Max(1, Math.Max(Math.Max(students, teachers), Math.Max(courses, payments)));

            g.DrawString("Real Data Analytics", new Font("Segoe UI", 17, FontStyle.Bold), new SolidBrush(text), 30, 25);

            int baseY = chartPanel.Height - 70;
            int startX = 80;
            int gap = 125;
            int barWidth = 65;

            using (Pen axisPen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                g.DrawLine(axisPen, 55, baseY, chartPanel.Width - 40, baseY);
            }

            for (int i = 0; i < values.Length; i++)
            {
                int barHeight = (int)((values[i] / (double)max) * 210);

                if (values[i] == 0)
                    barHeight = 8;
                else if (barHeight < 18)
                    barHeight = 18;

                int x = startX + i * gap;
                int y = baseY - barHeight;

                using (SolidBrush brush = new SolidBrush(colors[i]))
                {
                    g.FillRectangle(brush, x, y, barWidth, barHeight);
                }

                g.DrawString(values[i].ToString(), new Font("Segoe UI", 10, FontStyle.Bold), new SolidBrush(text), x + 22, y - 25);
                g.DrawString(labels[i], new Font("Segoe UI", 8), new SolidBrush(muted), x - 5, baseY + 15);
            }
        }

        private void PanelBorderPaint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;

            if (panel == null) return;

            using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private int GetCount(string table)
        {
            try
            {
                using (SQLiteConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = $"SELECT COUNT(*) FROM {table}";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        private double GetTotalEarnings()
        {
            try
            {
                using (SQLiteConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = "SELECT IFNULL(SUM(Amount), 0) FROM Payments";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        return Convert.ToDouble(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
        }
    }
}