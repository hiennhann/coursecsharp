
using System.Drawing;
using System.Windows.Forms;

namespace BaiTH6B
{
    partial class FormBanHang
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblMaHD, lblSanPham, lblSoLuong, lblChiTiet;
        private TextBox txtMaHD, txtSoLuong;
        private ComboBox cboSanPham;

        private Button btnTaoHoaDon;
        private Button btnThem;
        private Button btnHuy;
        private Button btnThanhToan;

        private ListView lvChiTiet;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMaHD = new Label();
            lblSanPham = new Label();
            lblSoLuong = new Label();
            lblChiTiet = new Label();

            txtMaHD = new TextBox();
            txtSoLuong = new TextBox();
            cboSanPham = new ComboBox();

            btnTaoHoaDon = new Button();
            btnThem = new Button();
            btnHuy = new Button();
            btnThanhToan = new Button();

            lvChiTiet = new ListView();

            SuspendLayout();

            // Nút tạo hóa đơn.
            btnTaoHoaDon.Text = "Tạo hóa đơn mới";
            btnTaoHoaDon.Location = new Point(185, 25);
            btnTaoHoaDon.Size = new Size(160, 38);
            btnTaoHoaDon.Click += btnTaoHoaDon_Click;

            // Mã hóa đơn.
            lblMaHD.Text = "Mã hóa đơn";
            lblMaHD.Location = new Point(55, 90);
            lblMaHD.AutoSize = true;

            txtMaHD.Location = new Point(185, 87);
            txtMaHD.Size = new Size(230, 27);
            txtMaHD.ReadOnly = true;

            // Sản phẩm.
            lblSanPham.Text = "Sản phẩm";
            lblSanPham.Location = new Point(55, 135);
            lblSanPham.AutoSize = true;

            cboSanPham.Location = new Point(185, 132);
            cboSanPham.Size = new Size(230, 28);
            cboSanPham.DropDownStyle = ComboBoxStyle.DropDownList;

            // Số lượng.
            lblSoLuong.Text = "Số lượng";
            lblSoLuong.Location = new Point(55, 180);
            lblSoLuong.AutoSize = true;

            txtSoLuong.Location = new Point(185, 177);
            txtSoLuong.Size = new Size(230, 27);

            // Nút Thêm.
            btnThem.Text = "Thêm";
            btnThem.Location = new Point(85, 230);
            btnThem.Size = new Size(100, 38);
            btnThem.Click += btnThem_Click;

            // Nút Hủy.
            btnHuy.Text = "Hủy";
            btnHuy.Location = new Point(210, 230);
            btnHuy.Size = new Size(100, 38);
            btnHuy.Click += btnHuy_Click;

            // Danh sách sản phẩm trong hóa đơn.
            lblChiTiet.Text = "Chi tiết hóa đơn";
            lblChiTiet.Location = new Point(35, 300);
            lblChiTiet.AutoSize = true;

            lvChiTiet.Location = new Point(35, 330);
            lvChiTiet.Size = new Size(450, 155);

            lvChiTiet.View = View.Details;
            lvChiTiet.GridLines = true;
            lvChiTiet.FullRowSelect = true;

            lvChiTiet.Columns.Add("Mã SP", 90);
            lvChiTiet.Columns.Add("Tên sản phẩm", 245);
            lvChiTiet.Columns.Add("Số lượng", 95);

            // Nút Thanh toán.
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.Location = new Point(345, 510);
            btnThanhToan.Size = new Size(140, 40);
            btnThanhToan.Click += btnThanhToan_Click;

            // Form.
            ClientSize = new Size(525, 590);
            Text = "Bán hàng";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.AddRange(new Control[]
            {
                btnTaoHoaDon,
                lblMaHD, txtMaHD,
                lblSanPham, cboSanPham,
                lblSoLuong, txtSoLuong,
                btnThem, btnHuy,
                lblChiTiet, lvChiTiet,
                btnThanhToan
            });

            Load += FormBanHang_Load;
            FormClosing += FormBanHang_FormClosing;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
