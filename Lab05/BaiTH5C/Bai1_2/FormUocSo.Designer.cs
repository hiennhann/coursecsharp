using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5C
{
    partial class FormUocSo
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblNhapSo, lblDanhSachUoc;
        private TextBox txtNhapSo;
        private ComboBox cboSo;
        private ListBox lstUocSo;
        private Button btnCapNhat, btnTong, btnSoChan, btnSoNguyenTo, btnThoat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNhapSo = new Label();
            this.lblDanhSachUoc = new Label();
            this.txtNhapSo = new TextBox();
            this.cboSo = new ComboBox();
            this.lstUocSo = new ListBox();
            this.btnCapNhat = new Button();
            this.btnTong = new Button();
            this.btnSoChan = new Button();
            this.btnSoNguyenTo = new Button();
            this.btnThoat = new Button();
            this.SuspendLayout();

            // Form
            this.ClientSize = new Size(500, 320);
            this.Text = "Combobox & Listbox";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += new FormClosingEventHandler(this.FormUocSo_FormClosing);

            // Cột trái (Nhập liệu)
            this.lblNhapSo.Text = "Nhập Số";
            this.lblNhapSo.Location = new Point(40, 30);
            this.lblNhapSo.AutoSize = true;

            this.txtNhapSo.Location = new Point(40, 60);
            this.txtNhapSo.Size = new Size(100, 22);

            // Nút Cập nhật: Phím tắt Alt + C
            this.btnCapNhat.Text = "&Cập nhật"; 
            this.btnCapNhat.Location = new Point(150, 58);
            this.btnCapNhat.Size = new Size(75, 26);
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);

            this.cboSo.Location = new Point(40, 100);
            this.cboSo.Size = new Size(185, 24);
            this.cboSo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboSo.SelectedIndexChanged += new System.EventHandler(this.cboSo_SelectedIndexChanged);

            // Nút Thoát: Phím tắt Alt + T
            this.btnThoat.Text = "&Thoát";
            this.btnThoat.Location = new Point(150, 260);
            this.btnThoat.Size = new Size(75, 30);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // Cột phải (Hiển thị và Tính toán)
            this.lblDanhSachUoc.Text = "Danh sách các ước số";
            this.lblDanhSachUoc.Location = new Point(260, 30);
            this.lblDanhSachUoc.AutoSize = true;

            this.lstUocSo.Location = new Point(260, 60);
            this.lstUocSo.Size = new Size(200, 100);

            // Nút Tổng: Phím tắt Alt + O
            this.btnTong.Text = "T&ổng các ước số";
            this.btnTong.Location = new Point(260, 170);
            this.btnTong.Size = new Size(200, 30);
            this.btnTong.Click += new System.EventHandler(this.btnTong_Click);

            // Nút Số chẵn: Phím tắt Alt + L
            this.btnSoChan.Text = "Số &lượng các ước số chẵn";
            this.btnSoChan.Location = new Point(260, 210);
            this.btnSoChan.Size = new Size(200, 30);
            this.btnSoChan.Click += new System.EventHandler(this.btnSoChan_Click);

            // Nút Nguyên tố: Phím tắt Alt + N
            this.btnSoNguyenTo.Text = "Số lượng các ước số &nguyên tố";
            this.btnSoNguyenTo.Location = new Point(260, 250);
            this.btnSoNguyenTo.Size = new Size(200, 30);
            this.btnSoNguyenTo.Click += new System.EventHandler(this.btnSoNguyenTo_Click);

            // Add Controls
            this.Controls.Add(this.lblNhapSo);
            this.Controls.Add(this.lblDanhSachUoc);
            this.Controls.Add(this.txtNhapSo);
            this.Controls.Add(this.cboSo);
            this.Controls.Add(this.lstUocSo);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnTong);
            this.Controls.Add(this.btnSoChan);
            this.Controls.Add(this.btnSoNguyenTo);
            this.Controls.Add(this.btnThoat);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}