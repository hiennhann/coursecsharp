
using System.Drawing;
using System.Windows.Forms;

namespace BaiTH6B
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        // Thanh menu
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuTaoTonKho;
        private ToolStripMenuItem mnuThemSanPham;
        private ToolStripMenuItem mnuBanHang;

        // Các Control hiển thị tồn kho
        private Label lblTieuDe;
        private Label lblTongSanPham;
        private Label lblTongTonKho;

        private DataGridView dgvTonKho;
        private Button btnLamMoi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();

            mnuTaoTonKho = new ToolStripMenuItem();
            mnuThemSanPham = new ToolStripMenuItem();
            mnuBanHang = new ToolStripMenuItem();

            lblTieuDe = new Label();
            lblTongSanPham = new Label();
            lblTongTonKho = new Label();

            dgvTonKho = new DataGridView();
            btnLamMoi = new Button();

            ((System.ComponentModel.ISupportInitialize)
                dgvTonKho).BeginInit();

            SuspendLayout();

            // THANH MENU
            menuStrip1.Items.AddRange(new ToolStripItem[]
            {
                mnuTaoTonKho,
                mnuThemSanPham,
                mnuBanHang
            });

            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Size = new Size(950, 28);

            // Menu Tạo tồn kho
            mnuTaoTonKho.Text = "Tạo tồn kho";
            mnuTaoTonKho.Click += mnuTaoTonKho_Click;

            // Menu Thêm sản phẩm
            mnuThemSanPham.Text = "Thêm sản phẩm";
            mnuThemSanPham.Click += mnuThemSanPham_Click;

            // Menu Bán hàng
            mnuBanHang.Text = "Bán hàng";
            mnuBanHang.Click += mnuBanHang_Click;

            // TIÊU ĐỀ
            lblTieuDe.Text = "DANH SÁCH HÀNG TỒN KHO";
            lblTieuDe.Location = new Point(30, 55);
            lblTieuDe.AutoSize = true;

            lblTieuDe.Font = new Font(
                "Segoe UI",
                15,
                FontStyle.Bold
            );

            // NÚT LÀM MỚI
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Location = new Point(810, 55);
            btnLamMoi.Size = new Size(105, 38);

            // Giữ vị trí ở góc phải khi phóng to Form.
            btnLamMoi.Anchor =
                AnchorStyles.Top | AnchorStyles.Right;

            btnLamMoi.Click += btnLamMoi_Click;

            // BẢNG TỒN KHO
            dgvTonKho.Location = new Point(30, 115);
            dgvTonKho.Size = new Size(885, 340);

            // Tự co giãn theo kích thước Form.
            dgvTonKho.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            // Chỉ cho phép xem dữ liệu.
            dgvTonKho.ReadOnly = true;

            // Không cho thêm hoặc xóa trực tiếp trên bảng.
            dgvTonKho.AllowUserToAddRows = false;
            dgvTonKho.AllowUserToDeleteRows = false;

            // Không cho chỉnh sửa kích thước hàng.
            dgvTonKho.AllowUserToResizeRows = false;

            // Chọn cả hàng khi click.
            dgvTonKho.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Không chọn nhiều hàng cùng lúc.
            dgvTonKho.MultiSelect = false;

            // Tự giãn độ rộng các cột.
            dgvTonKho.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvTonKho.RowHeadersVisible = false;

            dgvTonKho.ColumnHeadersHeight = 38;
            dgvTonKho.RowTemplate.Height = 32;

            dgvTonKho.BackgroundColor = Color.White;
            dgvTonKho.BorderStyle = BorderStyle.FixedSingle;

            // Định nghĩa các cột dữ liệu.
            dgvTonKho.Columns.Add("MaSP", "Mã SP");
            dgvTonKho.Columns.Add("TenSP", "Tên sản phẩm");
            dgvTonKho.Columns.Add("NgayTon", "Ngày tồn");
            dgvTonKho.Columns.Add("SLDau", "Tồn đầu");
            dgvTonKho.Columns.Add("SLNhap", "SL nhập");
            dgvTonKho.Columns.Add("SLBan", "SL bán");
            dgvTonKho.Columns.Add("SoLuongCon", "Còn lại");

            // Điều chỉnh độ rộng các cột.
            dgvTonKho.Columns["MaSP"].FillWeight = 65;
            dgvTonKho.Columns["TenSP"].FillWeight = 180;
            dgvTonKho.Columns["NgayTon"].FillWeight = 110;
            dgvTonKho.Columns["SLDau"].FillWeight = 85;
            dgvTonKho.Columns["SLNhap"].FillWeight = 85;
            dgvTonKho.Columns["SLBan"].FillWeight = 85;
            dgvTonKho.Columns["SoLuongCon"].FillWeight = 90;

            // Căn giữa các cột số.
            dgvTonKho.Columns["MaSP"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvTonKho.Columns["NgayTon"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvTonKho.Columns["SLDau"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvTonKho.Columns["SLNhap"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvTonKho.Columns["SLBan"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvTonKho.Columns["SoLuongCon"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // THỐNG KÊ DƯỚI BẢNG
            lblTongSanPham.Text = "Tổng sản phẩm: 0";
            lblTongSanPham.Location = new Point(30, 480);
            lblTongSanPham.AutoSize = true;

            lblTongSanPham.Anchor =
                AnchorStyles.Bottom | AnchorStyles.Left;

            lblTongSanPham.Font = new Font(
                "Segoe UI", 10, FontStyle.Bold);

            lblTongTonKho.Text = "Tổng tồn kho: 0";
            lblTongTonKho.Location = new Point(700, 480);
            lblTongTonKho.AutoSize = true;

            lblTongTonKho.Anchor =
                AnchorStyles.Bottom | AnchorStyles.Right;

            lblTongTonKho.Font = new Font(
                "Segoe UI", 10, FontStyle.Bold);

            ClientSize = new Size(950, 540);

            Text = "Quản lý cửa hàng";
            StartPosition = FormStartPosition.CenterScreen;

            MinimumSize = new Size(800, 480);

            MainMenuStrip = menuStrip1;

            Controls.Add(menuStrip1);
            Controls.Add(lblTieuDe);
            Controls.Add(btnLamMoi);
            Controls.Add(dgvTonKho);
            Controls.Add(lblTongSanPham);
            Controls.Add(lblTongTonKho);

            // Tự động tải dữ liệu khi mở Form.
            Load += FormMain_Load;

            ((System.ComponentModel.ISupportInitialize)
                dgvTonKho).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
