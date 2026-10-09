using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5C
{
    partial class FormChuoi
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnNgauNhien, btnXoaChon, btnXoaTenSon, btnXoaHoLe;
        private Button btnHoa, btnThuong, btnHoaDauTu, btnXoaTatCa;
        private ListBox lstDanhSach;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnNgauNhien = new Button();
            this.lstDanhSach = new ListBox();
            
            this.btnXoaChon = new Button();
            this.btnXoaTenSon = new Button();
            this.btnXoaHoLe = new Button();
            this.btnHoa = new Button();
            this.btnThuong = new Button();
            this.btnHoaDauTu = new Button();
            this.btnXoaTatCa = new Button();

            this.SuspendLayout();

            // Form
            this.ClientSize = new Size(620, 460);
            this.Text = "frmChuoi - Xử lý chuỗi";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Nút tạo ngẫu nhiên
            this.btnNgauNhien.Text = "Nhập tên ngẫu nhiên";
            this.btnNgauNhien.Location = new Point(20, 20);
            this.btnNgauNhien.Size = new Size(220, 35);
            this.btnNgauNhien.Click += new System.EventHandler(this.btnNgauNhien_Click);

            // ListBox chứa danh sách
            this.lstDanhSach.Location = new Point(20, 65);
            this.lstDanhSach.Size = new Size(220, 370);
            this.lstDanhSach.Font = new Font("Arial", 10F);
            this.lstDanhSach.SelectionMode = SelectionMode.MultiExtended; // Cho phép chọn nhiều dòng
            this.lstDanhSach.DoubleClick += new System.EventHandler(this.lstDanhSach_DoubleClick);

            // Cột Nút bấm bên phải (Xếp dọc)
            int xRight = 260;
            int yPos = 65;
            int yStep = 45;
            int btnWidth = 320;
            int btnHeight = 35;

            this.btnXoaChon.Text = "Xóa Phần tử đang chọn"; 
            this.btnXoaChon.Location = new Point(xRight, yPos); this.btnXoaChon.Size = new Size(btnWidth, btnHeight);
            this.btnXoaChon.Click += new System.EventHandler(this.btnXoaChon_Click);

            this.btnXoaTenSon.Text = "Xóa phần tử có tên là Sơn"; 
            this.btnXoaTenSon.Location = new Point(xRight, yPos += yStep); this.btnXoaTenSon.Size = new Size(btnWidth, btnHeight);
            this.btnXoaTenSon.Click += new System.EventHandler(this.btnXoaTenSon_Click);

            this.btnXoaHoLe.Text = "Xóa Phần tử có họ là Lê"; 
            this.btnXoaHoLe.Location = new Point(xRight, yPos += yStep); this.btnXoaHoLe.Size = new Size(btnWidth, btnHeight);
            this.btnXoaHoLe.Click += new System.EventHandler(this.btnXoaHoLe_Click);

            this.btnHoa.Text = "Chuyển PT đang chọn thành chữ HOA"; 
            this.btnHoa.Location = new Point(xRight, yPos += yStep); this.btnHoa.Size = new Size(btnWidth, btnHeight);
            this.btnHoa.Click += new System.EventHandler(this.btnHoa_Click);

            this.btnThuong.Text = "Chuyển PT đang chọn thành chữ thường"; 
            this.btnThuong.Location = new Point(xRight, yPos += yStep); this.btnThuong.Size = new Size(btnWidth, btnHeight);
            this.btnThuong.Click += new System.EventHandler(this.btnThuong_Click);

            this.btnHoaDauTu.Text = "Chuyển PT đang chọn thành viết Hoa đầu mỗi từ"; 
            this.btnHoaDauTu.Location = new Point(xRight, yPos += yStep); this.btnHoaDauTu.Size = new Size(btnWidth, btnHeight);
            this.btnHoaDauTu.Click += new System.EventHandler(this.btnHoaDauTu_Click);

            this.btnXoaTatCa.Text = "Xóa tất cả các Phần tử"; 
            this.btnXoaTatCa.Location = new Point(xRight, yPos += yStep); this.btnXoaTatCa.Size = new Size(btnWidth, btnHeight);
            this.btnXoaTatCa.Click += new System.EventHandler(this.btnXoaTatCa_Click);

            // Add controls
            this.Controls.Add(this.btnNgauNhien);
            this.Controls.Add(this.lstDanhSach);
            this.Controls.Add(this.btnXoaChon);
            this.Controls.Add(this.btnXoaTenSon);
            this.Controls.Add(this.btnXoaHoLe);
            this.Controls.Add(this.btnHoa);
            this.Controls.Add(this.btnThuong);
            this.Controls.Add(this.btnHoaDauTu);
            this.Controls.Add(this.btnXoaTatCa);

            this.ResumeLayout(false);
        }
    }
}