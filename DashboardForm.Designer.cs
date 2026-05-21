using System.Drawing;
using System.Windows.Forms;

namespace CampusManagementSystem2
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

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
            SuspendLayout();
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Campus Management System";
            Load += DashboardForm_Load;
            ResumeLayout(false);
        }
    }
}