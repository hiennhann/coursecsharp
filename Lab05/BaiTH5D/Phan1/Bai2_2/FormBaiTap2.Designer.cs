using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5D
{
    partial class FormBaiTap2
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle, lblSoTK, lblTenKH, lblDiaChi, lblSoTien, lblTongTien;
        private TextBox txtSoTK, txtTenKH, txtDiaChi, txtSoTien, txtTongTien;
        private Button btnThem, btnLuu, btnXoa, btnThoat;
        private ListView lstvTaiKhoan;
        private ColumnHeader colSTT, colSoTK, colTenKH, colDiaChi, colSoTien;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblSoTK = new Label(); this.lblTenKH = new Label(); this.lblDiaChi = new Label(); this.lblSoTien = new Label(); this.lblTongTien = new Label();
            this.txtSoTK = new TextBox(); this.txtTenKH = new TextBox(); this.txtDiaChi = new TextBox(); this.txtSoTien = new TextBox(); this.txtTongTien = new TextBox();
            this.btnThem = new Button(); this.btnLuu = new Button(); this.btnXoa = new Button(); this.btnThoat = new Button();
            this.lstvTaiKhoan = new ListView();
            this.colSTT = new ColumnHeader(); this.colSoTK = new ColumnHeader(); this.colTenKH = new ColumnHeader(); this.colDiaChi = new ColumnHeader(); this.colSoTien = new ColumnHeader();

            this.SuspendLayout();

            // Form
            this.ClientSize = new Size(680, 520);
            this.Text = "frmBaiTap2";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormBaiTap2_Load);

            // Tiêu đề
            this.lblTitle.Text = "QUẢN LÝ THÔNG TIN TÀI KHOẢN";
            this.lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Blue;
            this.lblTitle.Location = new Point(120, 15);
            this.lblTitle.AutoSize = true;

            // Nhập liệu
            this.lblSoTK.Text = "Số tài khoản"; this.lblSoTK.Location = new Point(50, 60); this.lblSoTK.AutoSize = true;
            this.txtSoTK.Location = new Point(200, 57); this.txtSoTK.Size = new Size(420, 22);

            this.lblTenKH.Text = "Tên khách hàng"; this.lblTenKH.Location = new Point(50, 95); this.lblTenKH.AutoSize = true;
            this.txtTenKH.Location = new Point(200, 92); this.txtTenKH.Size = new Size(420, 22);

            this.lblDiaChi.Text = "Địa chỉ khách hàng"; this.lblDiaChi.Location = new Point(50, 130); this.lblDiaChi.AutoSize = true;
            this.txtDiaChi.Location = new Point(200, 127); this.txtDiaChi.Size = new Size(420, 22);

            this.lblSoTien.Text = "Số tiền trong tài khoản"; this.lblSoTien.Location = new Point(50, 165); this.lblSoTien.AutoSize = true;
            this.txtSoTien.Location = new Point(200, 162); this.txtSoTien.Size = new Size(420, 22);
            this.txtSoTien.TextAlign = HorizontalAlignment.Right;

            // Nút bấm
            this.btnThem.Text = "Thêm"; this.btnThem.Location = new Point(250, 200); this.btnThem.Size = new Size(80, 30); this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnLuu.Text = "Lưu"; this.btnLuu.Location = new Point(340, 200); this.btnLuu.Size = new Size(80, 30); this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnXoa.Text = "Xóa"; this.btnXoa.Location = new Point(430, 200); this.btnXoa.Size = new Size(80, 30); this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnThoat.Text = "Thoát"; this.btnThoat.Location = new Point(540, 200); this.btnThoat.Size = new Size(80, 30); this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // ListView
            this.lstvTaiKhoan.Location = new Point(20, 240);
            this.lstvTaiKhoan.Size = new Size(640, 220);
            this.lstvTaiKhoan.View = View.Details;
            this.lstvTaiKhoan.FullRowSelect = true;
            this.lstvTaiKhoan.GridLines = true;
            this.lstvTaiKhoan.Columns.AddRange(new ColumnHeader[] { this.colSTT, this.colSoTK, this.colTenKH, this.colDiaChi, this.colSoTien });
            this.lstvTaiKhoan.SelectedIndexChanged += new System.EventHandler(this.lstvTaiKhoan_SelectedIndexChanged);

            this.colSTT.Text = "STT"; this.colSTT.Width = 50;
            this.colSoTK.Text = "Số tài khoản"; this.colSoTK.Width = 120;
            this.colTenKH.Text = "Tên khách hàng"; this.colTenKH.Width = 150;
            this.colDiaChi.Text = "Địa chỉ"; this.colDiaChi.Width = 170;
            this.colSoTien.Text = "Số tiền"; this.colSoTien.Width = 120; this.colSoTien.TextAlign = HorizontalAlignment.Right;

            // Tổng tiền
            this.lblTongTien.Text = "Tổng tiền"; this.lblTongTien.Location = new Point(420, 475); this.lblTongTien.AutoSize = true; this.lblTongTien.Font = new Font("Arial", 9F, FontStyle.Bold);
            this.txtTongTien.Location = new Point(500, 472); this.txtTongTien.Size = new Size(160, 22);
            this.txtTongTien.ReadOnly = true; this.txtTongTien.BackColor = Color.WhiteSmoke; this.txtTongTien.TextAlign = HorizontalAlignment.Right;

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSoTK); this.Controls.Add(this.txtSoTK);
            this.Controls.Add(this.lblTenKH); this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.lblDiaChi); this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.lblSoTien); this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.btnThem); this.Controls.Add(this.btnLuu); this.Controls.Add(this.btnXoa); this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lstvTaiKhoan);
            this.Controls.Add(this.lblTongTien); this.Controls.Add(this.txtTongTien);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}