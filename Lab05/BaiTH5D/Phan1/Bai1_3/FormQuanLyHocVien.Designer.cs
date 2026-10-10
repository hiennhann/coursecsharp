using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5D
{
    partial class FormQuanLyHocVien
    {
        private System.ComponentModel.IContainer components = null;

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuCapNhat, mnuKetThuc;
        private ToolStripMenuItem mnuNhapMoi, mnuChuyenB, mnuChuyenA, mnuXoa;
        private Label lblLopA, lblLopB;
        public ListBox lstLopA, lstLopB; // Để public để Form phụ có thể truy cập

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            this.mnuCapNhat = new ToolStripMenuItem();
            this.mnuNhapMoi = new ToolStripMenuItem();
            this.mnuChuyenB = new ToolStripMenuItem();
            this.mnuChuyenA = new ToolStripMenuItem();
            this.mnuXoa = new ToolStripMenuItem();
            this.mnuKetThuc = new ToolStripMenuItem();
            
            this.lblLopA = new Label(); this.lblLopB = new Label();
            this.lstLopA = new ListBox(); this.lstLopB = new ListBox();

            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // MenuStrip
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.mnuCapNhat, this.mnuKetThuc });
            
            this.mnuCapNhat.Text = "Cập nhật";
            this.mnuNhapMoi.Text = "Nhập học viên mới"; this.mnuNhapMoi.Click += new System.EventHandler(this.mnuNhapMoi_Click);
            this.mnuChuyenB.Text = "Chuyển sang lớp B"; this.mnuChuyenB.Click += new System.EventHandler(this.mnuChuyenB_Click);
            this.mnuChuyenA.Text = "Chuyển sang lớp A"; this.mnuChuyenA.Click += new System.EventHandler(this.mnuChuyenA_Click);
            this.mnuXoa.Text = "Xóa học viên"; this.mnuXoa.Click += new System.EventHandler(this.mnuXoa_Click);
            this.mnuCapNhat.DropDownItems.AddRange(new ToolStripItem[] { this.mnuNhapMoi, this.mnuChuyenB, this.mnuChuyenA, this.mnuXoa });

            this.mnuKetThuc.Text = "Kết thúc";
            this.mnuKetThuc.Click += new System.EventHandler(this.mnuKetThuc_Click);

            // Controls Lớp A & B
            this.lblLopA.Text = "Lớp A"; this.lblLopA.Location = new Point(30, 40); this.lblLopA.AutoSize = true;
            this.lstLopA.Location = new Point(30, 65); this.lstLopA.Size = new Size(200, 250);
            this.lstLopA.SelectionMode = SelectionMode.MultiExtended;

            this.lblLopB.Text = "Lớp B"; this.lblLopB.Location = new Point(260, 40); this.lblLopB.AutoSize = true;
            this.lstLopB.Location = new Point(260, 65); this.lstLopB.Size = new Size(200, 250);
            this.lstLopB.SelectionMode = SelectionMode.MultiExtended;

            // Form
            this.ClientSize = new Size(500, 350);
            this.Text = "Quản lý học viên";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MainMenuStrip = this.menuStrip1;
            
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblLopA); this.Controls.Add(this.lstLopA);
            this.Controls.Add(this.lblLopB); this.Controls.Add(this.lstLopB);

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}