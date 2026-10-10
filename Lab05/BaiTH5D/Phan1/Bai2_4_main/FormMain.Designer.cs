using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5D
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuBai1, mnuBai2, mnuBai3, mnuDongHo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            this.mnuBai1 = new ToolStripMenuItem();
            this.mnuBai2 = new ToolStripMenuItem();
            this.mnuBai3 = new ToolStripMenuItem();
            this.mnuDongHo = new ToolStripMenuItem();
            this.SuspendLayout();

            // MenuStrip
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
            this.mnuBai1, this.mnuBai2, this.mnuBai3, this.mnuDongHo});
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Size = new Size(800, 24);

            // Các mục Menu
            this.mnuBai1.Text = "Bài 1 (ListView SV)";
            this.mnuBai1.Click += new System.EventHandler(this.mnuBai1_Click);

            this.mnuBai2.Text = "Bài 2 (Tài Khoản)";
            this.mnuBai2.Click += new System.EventHandler(this.mnuBai2_Click);

            this.mnuBai3.Text = "Bài 3 (Quản lý HV)";
            this.mnuBai3.Click += new System.EventHandler(this.mnuBai3_Click);

            this.mnuDongHo.Text = "Đồng Hồ";
            this.mnuDongHo.Click += new System.EventHandler(this.mnuDongHo_Click);

            // Form Main
            this.ClientSize = new Size(1000, 700);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true; // BẬT TÍNH NĂNG FORM CHA
            this.MainMenuStrip = this.menuStrip1;
            this.Text = "BTVN_Tuan6 - Trình quản lý bài tập";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}