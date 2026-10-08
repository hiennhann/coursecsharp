using System.Drawing;
using System.Windows.Forms;

namespace BaiTH4D
{
    partial class FormKhachSan
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle, lblTen, lblDiaChi, lblSoNgay, lblThanhTien;
        private TextBox txtTen, txtDiaChi, txtSoNgay, txtThanhTien;
        
        private GroupBox grpLoaiPhong, grpTienNghi, grpDichVu, grpTongKet;
        private RadioButton rdoDon, rdoDoi, rdoBa;
        private CheckBox chkTivi, chkInternet, chkMayNuocNong, chkKaraoke, chkAnSang;
        
        private Button btnThanhToan, btnNhapMoi, btnTongKet, btnThoat;
        private Label lblSoLuot, lblTongTien;
        private TextBox txtSoLuot, txtTongTien;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label(); this.lblTen = new Label(); this.lblDiaChi = new Label(); this.lblSoNgay = new Label(); this.lblThanhTien = new Label();
            this.txtTen = new TextBox(); this.txtDiaChi = new TextBox(); this.txtSoNgay = new TextBox(); this.txtThanhTien = new TextBox();
            
            this.grpLoaiPhong = new GroupBox(); this.rdoDon = new RadioButton(); this.rdoDoi = new RadioButton(); this.rdoBa = new RadioButton();
            this.grpTienNghi = new GroupBox(); this.chkTivi = new CheckBox(); this.chkInternet = new CheckBox(); this.chkMayNuocNong = new CheckBox();
            this.grpDichVu = new GroupBox(); this.chkKaraoke = new CheckBox(); this.chkAnSang = new CheckBox();
            
            this.btnThanhToan = new Button(); this.btnNhapMoi = new Button(); this.btnTongKet = new Button(); this.btnThoat = new Button();
            
            this.grpTongKet = new GroupBox(); this.lblSoLuot = new Label(); this.lblTongTien = new Label();
            this.txtSoLuot = new TextBox(); this.txtTongTien = new TextBox();

            this.SuspendLayout();

            // Form
            this.ClientSize = new Size(700, 480);
            this.Text = "fmDangkyKS";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormKhachSan_Load);
            this.FormClosing += new FormClosingEventHandler(this.FormKhachSan_FormClosing);

            // Tiêu đề
            lblTitle.Text = "KHÁCH SẠN THANH THANH - TRẢ PHÒNG"; 
            lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold); 
            lblTitle.ForeColor = Color.Orange; 
            lblTitle.Location = new Point(100, 15); lblTitle.AutoSize = true;

            // --- PHẦN BÊN TRÁI (NHẬP LIỆU) ---
            lblTen.Text = "Họ và tên:"; lblTen.Location = new Point(30, 70); lblTen.AutoSize = true;
            txtTen.Location = new Point(120, 67); txtTen.Size = new Size(250, 22);
            txtTen.TextChanged += new System.EventHandler(this.KiemTraNhapLieu);

            lblDiaChi.Text = "Địa chỉ:"; lblDiaChi.Location = new Point(30, 105); lblDiaChi.AutoSize = true;
            txtDiaChi.Location = new Point(120, 102); txtDiaChi.Size = new Size(250, 22);
            txtDiaChi.TextChanged += new System.EventHandler(this.KiemTraNhapLieu);

            lblSoNgay.Text = "Số ngày ở:"; lblSoNgay.Location = new Point(30, 140); lblSoNgay.AutoSize = true;
            txtSoNgay.Location = new Point(120, 137); txtSoNgay.Size = new Size(80, 22);
            txtSoNgay.KeyPress += new KeyPressEventHandler(this.txtSoNgay_KeyPress);
            txtSoNgay.TextChanged += new System.EventHandler(this.KiemTraNhapLieu);

            // GroupBox Loại phòng
            grpLoaiPhong.Text = "Loại phòng"; grpLoaiPhong.Location = new Point(30, 180); grpLoaiPhong.Size = new Size(130, 130);
            rdoDon.Text = "Phòng đơn"; rdoDon.Location = new Point(15, 25); rdoDon.AutoSize = true; rdoDon.Checked = true;
            rdoDoi.Text = "Phòng đôi"; rdoDoi.Location = new Point(15, 60); rdoDoi.AutoSize = true;
            rdoBa.Text = "Phòng ba"; rdoBa.Location = new Point(15, 95); rdoBa.AutoSize = true;
            grpLoaiPhong.Controls.Add(rdoDon); grpLoaiPhong.Controls.Add(rdoDoi); grpLoaiPhong.Controls.Add(rdoBa);

            // GroupBox Tiện nghi
            grpTienNghi.Text = "Tiện nghi"; grpTienNghi.Location = new Point(175, 180); grpTienNghi.Size = new Size(140, 130);
            chkTivi.Text = "Tivi"; chkTivi.Location = new Point(15, 25); chkTivi.AutoSize = true;
            chkInternet.Text = "Internet"; chkInternet.Location = new Point(15, 60); chkInternet.AutoSize = true;
            chkMayNuocNong.Text = "Máy nước nóng"; chkMayNuocNong.Location = new Point(15, 95); chkMayNuocNong.AutoSize = true;
            grpTienNghi.Controls.Add(chkTivi); grpTienNghi.Controls.Add(chkInternet); grpTienNghi.Controls.Add(chkMayNuocNong);

            // GroupBox Dịch vụ
            grpDichVu.Text = "Dịch vụ"; grpDichVu.Location = new Point(330, 180); grpDichVu.Size = new Size(120, 130);
            chkKaraoke.Text = "Karaoke"; chkKaraoke.Location = new Point(15, 40); chkKaraoke.AutoSize = true;
            chkAnSang.Text = "Ăn sáng"; chkAnSang.Location = new Point(15, 80); chkAnSang.AutoSize = true;
            grpDichVu.Controls.Add(chkKaraoke); grpDichVu.Controls.Add(chkAnSang);

            // --- PHẦN BÊN PHẢI (TÍNH TOÁN & THỐNG KÊ) ---
            btnThanhToan.Text = "Thanh toán"; btnThanhToan.Location = new Point(470, 65); btnThanhToan.Size = new Size(95, 30); btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            btnNhapMoi.Text = "Nhập mới"; btnNhapMoi.Location = new Point(575, 65); btnNhapMoi.Size = new Size(95, 30); btnNhapMoi.Click += new System.EventHandler(this.btnNhapMoi_Click);

            lblThanhTien.Text = "Thành tiền:"; lblThanhTien.Location = new Point(470, 110); lblThanhTien.AutoSize = true;
            txtThanhTien.Location = new Point(550, 107); txtThanhTien.Size = new Size(120, 22); txtThanhTien.ReadOnly = true; txtThanhTien.BackColor = Color.WhiteSmoke;

            btnTongKet.Text = "Tổng Kết"; btnTongKet.Location = new Point(470, 150); btnTongKet.Size = new Size(95, 30); btnTongKet.Click += new System.EventHandler(this.btnTongKet_Click);

            // GroupBox Tổng Kết
            grpTongKet.Text = "Thông tin tổng kết"; grpTongKet.Location = new Point(470, 190); grpTongKet.Size = new Size(200, 120);
            lblSoLuot.Text = "Số lượt người:"; lblSoLuot.Location = new Point(10, 35); lblSoLuot.AutoSize = true;
            txtSoLuot.Location = new Point(100, 32); txtSoLuot.Size = new Size(90, 22); txtSoLuot.ReadOnly = true;
            lblTongTien.Text = "Tổng số tiền:"; lblTongTien.Location = new Point(10, 75); lblTongTien.AutoSize = true;
            txtTongTien.Location = new Point(100, 72); txtTongTien.Size = new Size(90, 22); txtTongTien.ReadOnly = true;
            grpTongKet.Controls.Add(lblSoLuot); grpTongKet.Controls.Add(txtSoLuot); grpTongKet.Controls.Add(lblTongTien); grpTongKet.Controls.Add(txtTongTien);

            btnThoat.Text = "Thoát"; btnThoat.Location = new Point(575, 320); btnThoat.Size = new Size(95, 30); btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // Add toàn bộ vào Form
            this.Controls.Add(lblTitle); this.Controls.Add(lblTen); this.Controls.Add(lblDiaChi); this.Controls.Add(lblSoNgay); this.Controls.Add(lblThanhTien);
            this.Controls.Add(txtTen); this.Controls.Add(txtDiaChi); this.Controls.Add(txtSoNgay); this.Controls.Add(txtThanhTien);
            this.Controls.Add(grpLoaiPhong); this.Controls.Add(grpTienNghi); this.Controls.Add(grpDichVu);
            this.Controls.Add(btnThanhToan); this.Controls.Add(btnNhapMoi); this.Controls.Add(btnTongKet); this.Controls.Add(btnThoat);
            this.Controls.Add(grpTongKet);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}