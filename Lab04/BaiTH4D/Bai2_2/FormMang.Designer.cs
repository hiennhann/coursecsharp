using System.Drawing;
using System.Windows.Forms;

namespace BaiTH4D // Hoặc BaiTH4C tùy project của bạn
{
    partial class FormMang
    {
        private System.ComponentModel.IContainer components = null;

        // Các control chính
        private Label lblTitle, lblNhap, lblKetQua;
        private TextBox txtNhapMang, txtKetQuaMang;
        private Button btnThucHien, btnReset, btnThoat;

        // Các GroupBox phân khu
        private GroupBox grpSapXep, grpTimKiem, grpXoa, grpThem, grpTong, grpMaxMin, grpThayThe;

        // Sắp xếp
        private RadioButton rdoTang, rdoGiam;

        // Tìm kiếm
        private RadioButton rdoTimGiaTri, rdoTimViTri;
        private TextBox txtTimGiaTri, txtTimViTri, txtKetQuaTim;
        private Label lblKetQuaTim;

        // Xóa
        private RadioButton rdoXoaGiaTri, rdoXoaViTri;
        private TextBox txtXoaGiaTri, txtXoaViTri;

        // Thêm
        private Label lblThemGiaTri, lblThemViTri;
        private TextBox txtThemGiaTri, txtThemViTri;

        // Tổng
        private Label lblTongMang, lblTongChan, lblTongLe;
        private TextBox txtTongMang, txtTongChan, txtTongLe;
        private Button btnTong;

        // Max Min
        private Label lblMax, lblMin;
        private TextBox txtMax, txtMin;
        private Button btnTimMaxMin;

        // Thay thế
        private RadioButton rdoThayGiaTri, rdoThayViTri;
        private TextBox txtThayGiaTri, txtThayViTri, txtSoThayThe;
        private Label lblSoThayThe;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Khởi tạo các Control (Rút gọn bớt các dòng lặp lại)
            this.lblTitle = new Label(); this.lblNhap = new Label(); this.lblKetQua = new Label();
            this.txtNhapMang = new TextBox(); this.txtKetQuaMang = new TextBox();
            this.btnThucHien = new Button(); this.btnReset = new Button(); this.btnThoat = new Button();
            
            this.grpSapXep = new GroupBox(); this.rdoTang = new RadioButton(); this.rdoGiam = new RadioButton();
            
            this.grpTimKiem = new GroupBox(); this.rdoTimGiaTri = new RadioButton(); this.rdoTimViTri = new RadioButton();
            this.txtTimGiaTri = new TextBox(); this.txtTimViTri = new TextBox(); this.txtKetQuaTim = new TextBox(); this.lblKetQuaTim = new Label();
            
            this.grpXoa = new GroupBox(); this.rdoXoaGiaTri = new RadioButton(); this.rdoXoaViTri = new RadioButton();
            this.txtXoaGiaTri = new TextBox(); this.txtXoaViTri = new TextBox();
            
            this.grpThem = new GroupBox(); this.lblThemGiaTri = new Label(); this.lblThemViTri = new Label();
            this.txtThemGiaTri = new TextBox(); this.txtThemViTri = new TextBox();
            
            this.grpTong = new GroupBox(); this.lblTongMang = new Label(); this.lblTongChan = new Label(); this.lblTongLe = new Label();
            this.txtTongMang = new TextBox(); this.txtTongChan = new TextBox(); this.txtTongLe = new TextBox(); this.btnTong = new Button();
            
            this.grpMaxMin = new GroupBox(); this.lblMax = new Label(); this.lblMin = new Label();
            this.txtMax = new TextBox(); this.txtMin = new TextBox(); this.btnTimMaxMin = new Button();
            
            this.grpThayThe = new GroupBox(); this.rdoThayGiaTri = new RadioButton(); this.rdoThayViTri = new RadioButton();
            this.txtThayGiaTri = new TextBox(); this.txtThayViTri = new TextBox(); this.txtSoThayThe = new TextBox(); this.lblSoThayThe = new Label();

            this.SuspendLayout();

            // Form
            this.ClientSize = new Size(620, 560);
            this.Text = "Mảng Số Nguyên";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += new FormClosingEventHandler(this.FormMang_FormClosing);

            // Tiêu đề & Nhập liệu
            lblTitle.Text = "Mảng Số Nguyên"; lblTitle.Font = new Font("Arial", 18F, FontStyle.Bold); lblTitle.ForeColor = Color.Red; lblTitle.Location = new Point(200, 10); lblTitle.AutoSize = true;
            lblNhap.Text = "Nhập mảng:"; lblNhap.Location = new Point(20, 60); lblNhap.AutoSize = true;
            txtNhapMang.Location = new Point(110, 57); txtNhapMang.Size = new Size(380, 22);
            btnReset.Text = "Reset"; btnReset.Location = new Point(500, 55); btnReset.Size = new Size(80, 25); btnReset.Click += new System.EventHandler(this.btnReset_Click);

            lblKetQua.Text = "Kết quả :"; lblKetQua.Location = new Point(20, 95); lblKetQua.AutoSize = true;
            txtKetQuaMang.Location = new Point(110, 92); txtKetQuaMang.Size = new Size(380, 22); txtKetQuaMang.ReadOnly = true; txtKetQuaMang.BackColor = Color.WhiteSmoke;
            btnThoat.Text = "Thoát"; btnThoat.Location = new Point(500, 90); btnThoat.Size = new Size(80, 25); btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            btnThucHien.Text = "Thực Hiện"; btnThucHien.Location = new Point(20, 130); btnThucHien.Size = new Size(200, 35); btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);

            // 1. GroupBox Sắp xếp
            grpSapXep.Text = "Sắp Xếp"; grpSapXep.Location = new Point(240, 125); grpSapXep.Size = new Size(340, 45);
            rdoTang.Text = "Sắp xếp Tăng"; rdoTang.Location = new Point(20, 15); rdoTang.AutoSize = true; rdoTang.Checked = true; // Mặc định
            rdoGiam.Text = "Sắp xếp Giảm"; rdoGiam.Location = new Point(150, 15); rdoGiam.AutoSize = true;
            grpSapXep.Controls.Add(rdoTang); grpSapXep.Controls.Add(rdoGiam);

            // 2. GroupBox Tìm kiếm
            grpTimKiem.Text = "Tìm Kiếm"; grpTimKiem.Location = new Point(20, 180); grpTimKiem.Size = new Size(270, 110);
            rdoTimGiaTri.Text = "Tìm giá trị:"; rdoTimGiaTri.Location = new Point(10, 25); rdoTimGiaTri.AutoSize = true;
            txtTimGiaTri.Location = new Point(130, 23); txtTimGiaTri.Size = new Size(60, 22);
            rdoTimViTri.Text = "Tìm vị trí:"; rdoTimViTri.Location = new Point(10, 55); rdoTimViTri.AutoSize = true;
            txtTimViTri.Location = new Point(130, 53); txtTimViTri.Size = new Size(60, 22);
            lblKetQuaTim.Text = "Số tìm được là:"; lblKetQuaTim.Location = new Point(30, 85); lblKetQuaTim.AutoSize = true;
            txtKetQuaTim.Location = new Point(140, 83); txtKetQuaTim.Size = new Size(60, 22); txtKetQuaTim.ReadOnly = true;
            grpTimKiem.Controls.Add(rdoTimGiaTri); grpTimKiem.Controls.Add(txtTimGiaTri); grpTimKiem.Controls.Add(rdoTimViTri); grpTimKiem.Controls.Add(txtTimViTri); grpTimKiem.Controls.Add(lblKetQuaTim); grpTimKiem.Controls.Add(txtKetQuaTim);

            // 3. GroupBox Xóa
            grpXoa.Text = "Xóa"; grpXoa.Location = new Point(310, 180); grpXoa.Size = new Size(270, 110);
            rdoXoaGiaTri.Text = "Xóa giá trị:"; rdoXoaGiaTri.Location = new Point(10, 25); rdoXoaGiaTri.AutoSize = true;
            txtXoaGiaTri.Location = new Point(130, 23); txtXoaGiaTri.Size = new Size(60, 22);
            rdoXoaViTri.Text = "Xóa tại vị trí:"; rdoXoaViTri.Location = new Point(10, 55); rdoXoaViTri.AutoSize = true;
            txtXoaViTri.Location = new Point(130, 53); txtXoaViTri.Size = new Size(60, 22);
            grpXoa.Controls.Add(rdoXoaGiaTri); grpXoa.Controls.Add(txtXoaGiaTri); grpXoa.Controls.Add(rdoXoaViTri); grpXoa.Controls.Add(txtXoaViTri);

            // 4. GroupBox Thêm
            grpThem.Text = "Thêm"; grpThem.Location = new Point(20, 300); grpThem.Size = new Size(270, 90);
            lblThemGiaTri.Text = "Giá trị cần thêm:"; lblThemGiaTri.Location = new Point(10, 25); lblThemGiaTri.AutoSize = true;
            txtThemGiaTri.Location = new Point(130, 23); txtThemGiaTri.Size = new Size(60, 22);
            lblThemViTri.Text = "Tại vị trí:"; lblThemViTri.Location = new Point(10, 55); lblThemViTri.AutoSize = true;
            txtThemViTri.Location = new Point(130, 53); txtThemViTri.Size = new Size(60, 22);
            grpThem.Controls.Add(lblThemGiaTri); grpThem.Controls.Add(txtThemGiaTri); grpThem.Controls.Add(lblThemViTri); grpThem.Controls.Add(txtThemViTri);

            // 5. GroupBox Tổng
            grpTong.Text = "Tính Tổng"; grpTong.Location = new Point(310, 300); grpTong.Size = new Size(270, 115);
            lblTongMang.Text = "Tổng mảng:"; lblTongMang.Location = new Point(10, 25); lblTongMang.AutoSize = true;
            txtTongMang.Location = new Point(100, 23); txtTongMang.Size = new Size(60, 22); txtTongMang.ReadOnly = true;
            lblTongChan.Text = "Tổng chẵn:"; lblTongChan.Location = new Point(10, 55); lblTongChan.AutoSize = true;
            txtTongChan.Location = new Point(100, 53); txtTongChan.Size = new Size(60, 22); txtTongChan.ReadOnly = true;
            lblTongLe.Text = "Tổng lẻ:"; lblTongLe.Location = new Point(10, 85); lblTongLe.AutoSize = true;
            txtTongLe.Location = new Point(100, 83); txtTongLe.Size = new Size(60, 22); txtTongLe.ReadOnly = true;
            btnTong.Text = "Tính Tổng"; btnTong.Location = new Point(180, 23); btnTong.Size = new Size(70, 80); btnTong.Click += new System.EventHandler(this.btnTong_Click);
            grpTong.Controls.Add(lblTongMang); grpTong.Controls.Add(txtTongMang); grpTong.Controls.Add(lblTongChan); grpTong.Controls.Add(txtTongChan); grpTong.Controls.Add(lblTongLe); grpTong.Controls.Add(txtTongLe); grpTong.Controls.Add(btnTong);

            // 6. GroupBox Max Min
            grpMaxMin.Text = "Max - Min"; grpMaxMin.Location = new Point(20, 400); grpMaxMin.Size = new Size(270, 90);
            lblMax.Text = "Lớn nhất:"; lblMax.Location = new Point(10, 25); lblMax.AutoSize = true;
            txtMax.Location = new Point(100, 23); txtMax.Size = new Size(60, 22); txtMax.ReadOnly = true;
            lblMin.Text = "Nhỏ nhất:"; lblMin.Location = new Point(10, 55); lblMin.AutoSize = true;
            txtMin.Location = new Point(100, 53); txtMin.Size = new Size(60, 22); txtMin.ReadOnly = true;
            btnTimMaxMin.Text = "Tìm Max-Min"; btnTimMaxMin.Location = new Point(170, 23); btnTimMaxMin.Size = new Size(90, 52); btnTimMaxMin.Click += new System.EventHandler(this.btnTimMaxMin_Click);
            grpMaxMin.Controls.Add(lblMax); grpMaxMin.Controls.Add(txtMax); grpMaxMin.Controls.Add(lblMin); grpMaxMin.Controls.Add(txtMin); grpMaxMin.Controls.Add(btnTimMaxMin);

            // 7. GroupBox Thay thế
            grpThayThe.Text = "Thay Thế"; grpThayThe.Location = new Point(310, 420); grpThayThe.Size = new Size(270, 110);
            rdoThayGiaTri.Text = "Giá trị cần thay:"; rdoThayGiaTri.Location = new Point(10, 25); rdoThayGiaTri.AutoSize = true;
            txtThayGiaTri.Location = new Point(130, 23); txtThayGiaTri.Size = new Size(60, 22);
            rdoThayViTri.Text = "Vị trí cần thay:"; rdoThayViTri.Location = new Point(10, 55); rdoThayViTri.AutoSize = true;
            txtThayViTri.Location = new Point(130, 53); txtThayViTri.Size = new Size(60, 22);
            lblSoThayThe.Text = "Số thay thế là:"; lblSoThayThe.Location = new Point(30, 85); lblSoThayThe.AutoSize = true;
            txtSoThayThe.Location = new Point(130, 83); txtSoThayThe.Size = new Size(60, 22);
            grpThayThe.Controls.Add(rdoThayGiaTri); grpThayThe.Controls.Add(txtThayGiaTri); grpThayThe.Controls.Add(rdoThayViTri); grpThayThe.Controls.Add(txtThayViTri); grpThayThe.Controls.Add(lblSoThayThe); grpThayThe.Controls.Add(txtSoThayThe);

            // Đưa tất cả vào Form
            this.Controls.Add(lblTitle); this.Controls.Add(lblNhap); this.Controls.Add(txtNhapMang); this.Controls.Add(btnReset);
            this.Controls.Add(lblKetQua); this.Controls.Add(txtKetQuaMang); this.Controls.Add(btnThoat);
            this.Controls.Add(btnThucHien);
            this.Controls.Add(grpSapXep); this.Controls.Add(grpTimKiem); this.Controls.Add(grpXoa);
            this.Controls.Add(grpThem); this.Controls.Add(grpTong); this.Controls.Add(grpMaxMin); this.Controls.Add(grpThayThe);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}