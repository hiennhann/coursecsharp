using System.Drawing;
using System.Windows.Forms;

namespace BaiTH4D
{
    partial class FormCafeSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle, lblTenKH, lblSoKH, lblTongKhach, lblTongTien;
        private TextBox txtTenKH, txtSoKH, txtTongKhach, txtTongTien;
        private CheckBox chkSinhVien;
        
        private GroupBox grpNuocUong, grpThucAn;
        private RadioButton rdoCafeDen, rdoCafeDa, rdoCafeSua, rdoCafeSuaDa, rdoCafeKem;
        private CheckBox chkBanhMyTrung, chkBanhMyCa, chkMyTomTrung, chkMyXaoBo, chkMyCay;
        
        private Button btnTinhTien, btnNhapLai, btnThanhToan, btnThoat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label(); this.lblTenKH = new Label(); this.lblSoKH = new Label();
            this.lblTongKhach = new Label(); this.lblTongTien = new Label();
            this.txtTenKH = new TextBox(); this.txtSoKH = new TextBox();
            this.txtTongKhach = new TextBox(); this.txtTongTien = new TextBox();
            this.chkSinhVien = new CheckBox();
            
            this.grpNuocUong = new GroupBox(); this.grpThucAn = new GroupBox();
            this.rdoCafeDen = new RadioButton(); this.rdoCafeDa = new RadioButton();
            this.rdoCafeSua = new RadioButton(); this.rdoCafeSuaDa = new RadioButton(); this.rdoCafeKem = new RadioButton();
            this.chkBanhMyTrung = new CheckBox(); this.chkBanhMyCa = new CheckBox();
            this.chkMyTomTrung = new CheckBox(); this.chkMyXaoBo = new CheckBox(); this.chkMyCay = new CheckBox();
            
            this.btnTinhTien = new Button(); this.btnNhapLai = new Button();
            this.btnThanhToan = new Button(); this.btnThoat = new Button();

            this.SuspendLayout();

            // Form
            this.ClientSize = new Size(600, 520);
            this.Text = "Thanh toán tiền";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormCafeSinhVien_Load);
            this.FormClosing += new FormClosingEventHandler(this.FormCafeSinhVien_FormClosing);

            // Tiêu đề
            lblTitle.Text = "CAFE SINH VIÊN"; lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold); lblTitle.ForeColor = Color.Orange; lblTitle.Location = new Point(200, 15); lblTitle.AutoSize = true;

            // Thông tin khách hàng
            lblTenKH.Text = "Tên khách hàng"; lblTenKH.Location = new Point(40, 65); lblTenKH.AutoSize = true;
            txtTenKH.Location = new Point(160, 62); txtTenKH.Size = new Size(380, 22);
            txtTenKH.TextChanged += new System.EventHandler(this.KiemTraNhapLieu);

            lblSoKH.Text = "Số khách hàng"; lblSoKH.Location = new Point(40, 100); lblSoKH.AutoSize = true;
            txtSoKH.Location = new Point(160, 97); txtSoKH.Size = new Size(380, 22);
            txtSoKH.KeyPress += new KeyPressEventHandler(this.txtSoKH_KeyPress);
            txtSoKH.TextChanged += new System.EventHandler(this.KiemTraNhapLieu);

            chkSinhVien.Text = "Sinh viên ?"; chkSinhVien.Location = new Point(160, 130); chkSinhVien.AutoSize = true;

            // GroupBox Nước uống
            grpNuocUong.Text = "Nước uống"; grpNuocUong.Location = new Point(40, 160); grpNuocUong.Size = new Size(240, 170);
            rdoCafeDen.Text = "Cafe đen"; rdoCafeDen.Location = new Point(20, 30); rdoCafeDen.AutoSize = true; rdoCafeDen.Tag = 20000;
            rdoCafeDa.Text = "Cafe đá"; rdoCafeDa.Location = new Point(130, 30); rdoCafeDa.AutoSize = true; rdoCafeDa.Tag = 25000;
            rdoCafeSua.Text = "Cafe sữa"; rdoCafeSua.Location = new Point(20, 70); rdoCafeSua.AutoSize = true; rdoCafeSua.Tag = 25000;
            rdoCafeKem.Text = "Cafe kem"; rdoCafeKem.Location = new Point(130, 70); rdoCafeKem.AutoSize = true; rdoCafeKem.Tag = 35000;
            rdoCafeSuaDa.Text = "Cafe sữa đá"; rdoCafeSuaDa.Location = new Point(20, 110); rdoCafeSuaDa.AutoSize = true; rdoCafeSuaDa.Tag = 30000;
            grpNuocUong.Controls.Add(rdoCafeDen); grpNuocUong.Controls.Add(rdoCafeDa); grpNuocUong.Controls.Add(rdoCafeSua); grpNuocUong.Controls.Add(rdoCafeKem); grpNuocUong.Controls.Add(rdoCafeSuaDa);

            // GroupBox Thức ăn
            grpThucAn.Text = "Thức ăn"; grpThucAn.Location = new Point(300, 160); grpThucAn.Size = new Size(240, 170);
            chkBanhMyTrung.Text = "Bánh mỳ trứng"; chkBanhMyTrung.Location = new Point(20, 30); chkBanhMyTrung.AutoSize = true; chkBanhMyTrung.Tag = 15000;
            chkMyXaoBo.Text = "Mỳ xào bò"; chkMyXaoBo.Location = new Point(140, 30); chkMyXaoBo.AutoSize = true; chkMyXaoBo.Tag = 30000;
            chkBanhMyCa.Text = "Bánh mỳ cá"; chkBanhMyCa.Location = new Point(20, 70); chkBanhMyCa.AutoSize = true; chkBanhMyCa.Tag = 15000;
            chkMyCay.Text = "Mỳ cay"; chkMyCay.Location = new Point(140, 70); chkMyCay.AutoSize = true; chkMyCay.Tag = 50000;
            chkMyTomTrung.Text = "Mỳ tôm trứng"; chkMyTomTrung.Location = new Point(20, 110); chkMyTomTrung.AutoSize = true; chkMyTomTrung.Tag = 20000;
            grpThucAn.Controls.Add(chkBanhMyTrung); grpThucAn.Controls.Add(chkMyXaoBo); grpThucAn.Controls.Add(chkBanhMyCa); grpThucAn.Controls.Add(chkMyCay); grpThucAn.Controls.Add(chkMyTomTrung);

            // Buttons
            btnTinhTien.Text = "Tính tiền"; btnTinhTien.Location = new Point(60, 350); btnTinhTien.Size = new Size(100, 30); btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            btnNhapLai.Text = "Nhập lại"; btnNhapLai.Location = new Point(180, 350); btnNhapLai.Size = new Size(100, 30); btnNhapLai.Click += new System.EventHandler(this.btnNhapLai_Click);
            btnThanhToan.Text = "Thanh toán"; btnThanhToan.Location = new Point(300, 350); btnThanhToan.Size = new Size(100, 30); btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            btnThoat.Text = "Thoát"; btnThoat.Location = new Point(420, 350); btnThoat.Size = new Size(100, 30); btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // Thống kê
            lblTongKhach.Text = "Tổng khách hàng"; lblTongKhach.Location = new Point(40, 410); lblTongKhach.AutoSize = true; lblTongKhach.Font = new Font("Arial", 9F, FontStyle.Bold);
            txtTongKhach.Location = new Point(180, 407); txtTongKhach.Size = new Size(360, 22); txtTongKhach.ReadOnly = true; txtTongKhach.BackColor = Color.WhiteSmoke;
            
            lblTongTien.Text = "Tổng tiền"; lblTongTien.Location = new Point(40, 450); lblTongTien.AutoSize = true; lblTongTien.Font = new Font("Arial", 9F, FontStyle.Bold);
            txtTongTien.Location = new Point(180, 447); txtTongTien.Size = new Size(360, 22); txtTongTien.ReadOnly = true; txtTongTien.BackColor = Color.WhiteSmoke;

            // Add controls
            this.Controls.Add(lblTitle); this.Controls.Add(lblTenKH); this.Controls.Add(lblSoKH); this.Controls.Add(lblTongKhach); this.Controls.Add(lblTongTien);
            this.Controls.Add(txtTenKH); this.Controls.Add(txtSoKH); this.Controls.Add(txtTongKhach); this.Controls.Add(txtTongTien); this.Controls.Add(chkSinhVien);
            this.Controls.Add(grpNuocUong); this.Controls.Add(grpThucAn);
            this.Controls.Add(btnTinhTien); this.Controls.Add(btnNhapLai); this.Controls.Add(btnThanhToan); this.Controls.Add(btnThoat);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}