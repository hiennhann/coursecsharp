using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5D
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            this.SuspendLayout();

            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Size = new Size(1000, 24);

            this.ClientSize = new Size(1000, 700);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Text = "Lab05 - Trình quản lý bài tập";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}