using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    public partial class ViewReportsForm : Form
    {
        // Database helper object
        DatabaseHelper db = new DatabaseHelper();

        // Print document object
        private PrintDocument printDocument = new PrintDocument();

        // DataTable to store report data
        private DataTable reportTable = new DataTable();

        // Store current report title
        private string currentReportTitle = "";

        public ViewReportsForm()
        {
            InitializeComponent();

            // Load dashboard report cards
            LoadReports();

            // Attach print page event
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void LoadReports()
        {
            // Display total counts on dashboard cards
            lblStudents.Text = "👨‍🎓 Total Students\n\n" + GetCount("Students");
            lblTeachers.Text = "👩‍🏫 Total Teachers\n\n" + GetCount("Teachers");
            lblCourses.Text = "📚 Total Courses\n\n" + GetCount("Courses");
            lblPayments.Text = "💳 Total Payments\n\n" + GetCount("Payments");
            lblEarnings.Text = "💰 Total Earnings\n\nRs. " + GetTotalEarnings();
        }

        private int GetCount(string table)
        {
            try
            {
                using (SQLiteConnection con = db.GetConnection())
                {
                    con.Open();

                    // Get total records count from table
                    SQLiteCommand cmd = new SQLiteCommand($"SELECT COUNT(*) FROM {table}", con);

                    return Convert.ToInt32(cmd.ExecuteScalar());
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

                    // Calculate total payment earnings
                    SQLiteCommand cmd = new SQLiteCommand("SELECT IFNULL(SUM(Amount),0) FROM Payments", con);

                    return Convert.ToDouble(cmd.ExecuteScalar());
                }
            }
            catch
            {
                return 0;
            }
        }

        private void PrintReport(string tableName)
        {
            try
            {
                // Set current report title
                currentReportTitle = tableName + " Report";

                reportTable.Clear();
                reportTable.Columns.Clear();

                using (SQLiteConnection con = db.GetConnection())
                {
                    con.Open();

                    // Load selected table data
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter($"SELECT * FROM {tableName}", con);

                    adapter.Fill(reportTable);
                }

                // Show print preview window
                PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.Document = printDocument;
                preview.Width = 1100;
                preview.Height = 750;
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Graphics object for printing
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            int pageWidth = e.PageBounds.Width;
            int margin = 50;
            int y = 45;

            // Theme colors
            Color navy = Color.FromArgb(15, 23, 42);
            Color lightBlue = Color.FromArgb(219, 234, 254);
            Color tableHeader = Color.FromArgb(30, 41, 59);
            Color border = Color.FromArgb(203, 213, 225);
            Color textDark = Color.FromArgb(15, 23, 42);
            Color muted = Color.FromArgb(71, 85, 105);

            // Fonts for report
            Font titleFont = new Font("Segoe UI", 24, FontStyle.Bold);
            Font subTitleFont = new Font("Segoe UI", 12);
            Font sectionFont = new Font("Segoe UI", 15, FontStyle.Bold);
            Font headerFont = new Font("Segoe UI", 9, FontStyle.Bold);
            Font cellFont = new Font("Segoe UI", 8);
            Font footerFont = new Font("Segoe UI", 9, FontStyle.Italic);

            g.FillRectangle(Brushes.White, e.PageBounds);

            // Draw report header
            Rectangle headerRect = new Rectangle(margin, y, pageWidth - 100, 95);

            using (GraphicsPath path = RoundedRect(headerRect, 18))
            using (SolidBrush brush = new SolidBrush(navy))
                g.FillPath(brush, path);

            g.DrawString("Campus Management System", titleFont, Brushes.White, margin + 25, y + 15);

            g.DrawString(currentReportTitle, subTitleFont, new SolidBrush(lightBlue), margin + 28, y + 58);

            // Show report generation date
            string dateText = "Generated: " + DateTime.Now.ToString("dd MMM yyyy, hh:mm tt");

            SizeF dateSize = g.MeasureString(dateText, subTitleFont);

            g.DrawString(dateText, subTitleFont, Brushes.White, pageWidth - margin - dateSize.Width - 25, y + 35);

            y += 125;

            // Draw summary section
            Rectangle summaryRect = new Rectangle(margin, y, pageWidth - 100, 70);

            using (GraphicsPath path = RoundedRect(summaryRect, 14))
            using (SolidBrush brush = new SolidBrush(lightBlue))
                g.FillPath(brush, path);

            g.DrawString("Report Summary", sectionFont, new SolidBrush(textDark), margin + 20, y + 12);

            g.DrawString("Total Records: " + reportTable.Rows.Count, subTitleFont, new SolidBrush(muted), margin + 22, y + 42);

            y += 100;

            // Show message if no records exist
            if (reportTable.Rows.Count == 0)
            {
                g.DrawString("No records found.", sectionFont, new SolidBrush(textDark), margin, y);
                return;
            }

            int tableX = margin;
            int tableWidth = pageWidth - 100;
            int rowHeight = 32;
            int headerHeight = 38;

            int maxColumns = Math.Min(reportTable.Columns.Count, 6);
            int colWidth = tableWidth / maxColumns;

            // Draw table header
            Rectangle tableHeaderRect = new Rectangle(tableX, y, tableWidth, headerHeight);

            using (GraphicsPath path = RoundedRect(tableHeaderRect, 10))
            using (SolidBrush brush = new SolidBrush(tableHeader))
                g.FillPath(brush, path);

            for (int i = 0; i < maxColumns; i++)
            {
                RectangleF rect = new RectangleF(tableX + i * colWidth + 8, y + 10, colWidth - 12, headerHeight);

                g.DrawString(reportTable.Columns[i].ColumnName, headerFont, Brushes.White, rect);
            }

            y += headerHeight;

            int rowsPerPage = 18;
            int rowsToPrint = Math.Min(reportTable.Rows.Count, rowsPerPage);

            // Print table rows
            for (int r = 0; r < rowsToPrint; r++)
            {
                Color rowColor = r % 2 == 0 ? Color.White : Color.FromArgb(248, 250, 252);

                using (SolidBrush rowBrush = new SolidBrush(rowColor))
                    g.FillRectangle(rowBrush, tableX, y, tableWidth, rowHeight);

                using (Pen pen = new Pen(border))
                    g.DrawRectangle(pen, tableX, y, tableWidth, rowHeight);

                for (int c = 0; c < maxColumns; c++)
                {
                    string value = reportTable.Rows[r][c].ToString();

                    RectangleF textRect = new RectangleF(
                        tableX + c * colWidth + 8,
                        y + 8,
                        colWidth - 12,
                        rowHeight
                    );

                    g.DrawString(value, cellFont, new SolidBrush(textDark), textRect);
                }

                y += rowHeight;
            }

            // Show note if records exceed preview limit
            if (reportTable.Rows.Count > rowsPerPage)
            {
                y += 15;

                g.DrawString("Note: Preview shows first " + rowsPerPage + " records only.", footerFont, new SolidBrush(muted), margin, y);
            }

            // Footer text
            string footer = "Campus Management System | Modern Academic Report";

            SizeF footerSize = g.MeasureString(footer, footerFont);

            g.DrawString(footer, footerFont, new SolidBrush(muted), (pageWidth - footerSize.Width) / 2, e.PageBounds.Height - 55);
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            // Create rounded rectangle shape
            int diameter = radius * 2;

            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();

            return path;
        }

        private void btnPrintStudents_Click(object sender, EventArgs e)
        {
            // Print students report
            PrintReport("Students");
        }

        private void btnPrintTeachers_Click(object sender, EventArgs e)
        {
            // Print teachers report
            PrintReport("Teachers");
        }

        private void btnPrintCourses_Click(object sender, EventArgs e)
        {
            // Print courses report
            PrintReport("Courses");
        }

        private void btnPrintPayments_Click(object sender, EventArgs e)
        {
            // Print payments report
            PrintReport("Payments");
        }

        private void ViewReportsForm_Load(object sender, EventArgs e)
        {
        }
    }
}