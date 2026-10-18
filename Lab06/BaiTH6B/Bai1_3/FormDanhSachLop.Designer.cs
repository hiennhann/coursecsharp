
using System.Drawing;
using System.Windows.Forms;

namespace BaiTH6B
{
    partial class FormDanhSachLop
    {
        private System.ComponentModel.IContainer components = null;

        private ListView lvLop;
        private Button btnHienThi, btnThoat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lvLop = new ListView();
            btnHienThi = new Button();
            btnThoat = new Button();

            SuspendLayout();

            // Nút hiển thị dữ liệu
            btnHienThi.Text = "Hiển thị dữ liệu";
            btnHienThi.Location = new Point(30, 25);
            btnHienThi.Size = new Size(140, 35);
            btnHienThi.Click += btnHienThi_Click;

            // ListView hiển thị thông tin lớp.
            lvLop.Location = new Point(30, 80);
            lvLop.Size = new Size(600, 310);

            // Hiển thị dữ liệu theo dạng bảng.
            lvLop.View = View.Details;
            lvLop.FullRowSelect = true;
            lvLop.GridLines = true;

            // Khai báo các cột theo đề.
            lvLop.Columns.Add("STT", 60);
            lvLop.Columns.Add("Mã lớp", 120);
            lvLop.Columns.Add("Tên lớp", 270);
            lvLop.Columns.Add("Mã khoa", 130);

            // Nút thoát
            btnThoat.Text = "Thoát";
            btnThoat.Location = new Point(530, 410);
            btnThoat.Size = new Size(100, 38);
            btnThoat.Click += btnThoat_Click;

            // Form
            ClientSize = new Size(660, 475);
            Text = "Danh sách lớp";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(btnHienThi);
            Controls.Add(lvLop);
            Controls.Add(btnThoat);

            ResumeLayout(false);
        }
    }
}
