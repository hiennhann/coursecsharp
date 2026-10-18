
using System.Drawing;
using System.Windows.Forms;

namespace BaiTH6B
{
    partial class FormSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblLop, lblMaSV, lblHoTen, lblNgaySinh;
        private ComboBox cboLop;
        private TextBox txtMaSV, txtHoTen, txtNgaySinh;
        private Button btnThem, btnXoa, btnSua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblLop = new Label();
            lblMaSV = new Label();
            lblHoTen = new Label();
            lblNgaySinh = new Label();

            cboLop = new ComboBox();
            txtMaSV = new TextBox();
            txtHoTen = new TextBox();
            txtNgaySinh = new TextBox();

            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();

            SuspendLayout();

            // Mã lớp
            lblLop.Text = "Mã lớp";
            lblLop.Location = new Point(30, 30);
            lblLop.AutoSize = true;

            cboLop.Location = new Point(145, 27);
            cboLop.Size = new Size(220, 28);
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;

            // Mã sinh viên
            lblMaSV.Text = "Mã sinh viên";
            lblMaSV.Location = new Point(30, 75);
            lblMaSV.AutoSize = true;

            txtMaSV.Location = new Point(145, 72);
            txtMaSV.Size = new Size(220, 27);

            // Họ tên
            lblHoTen.Text = "Họ tên";
            lblHoTen.Location = new Point(30, 120);
            lblHoTen.AutoSize = true;

            txtHoTen.Location = new Point(145, 117);
            txtHoTen.Size = new Size(220, 27);

            // Ngày sinh
            lblNgaySinh.Text = "Ngày sinh";
            lblNgaySinh.Location = new Point(30, 165);
            lblNgaySinh.AutoSize = true;

            txtNgaySinh.Location = new Point(145, 162);
            txtNgaySinh.Size = new Size(220, 27);
            txtNgaySinh.PlaceholderText = "dd/MM/yyyy";

            // Các nút chức năng
            btnThem.Text = "Thêm";
            btnThem.Location = new Point(45, 220);
            btnThem.Size = new Size(90, 38);
            btnThem.Click += btnThem_Click;

            btnXoa.Text = "Xóa";
            btnXoa.Location = new Point(155, 220);
            btnXoa.Size = new Size(90, 38);
            btnXoa.Click += btnXoa_Click;

            btnSua.Text = "Sửa";
            btnSua.Location = new Point(265, 220);
            btnSua.Size = new Size(90, 38);
            btnSua.Click += btnSua_Click;

            // Form
            ClientSize = new Size(410, 300);
            Text = "Quản lý sinh viên";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.AddRange(new Control[]
            {
                lblLop, cboLop,
                lblMaSV, txtMaSV,
                lblHoTen, txtHoTen,
                lblNgaySinh, txtNgaySinh,
                btnThem, btnXoa, btnSua
            });

            Load += FormSinhVien_Load;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
