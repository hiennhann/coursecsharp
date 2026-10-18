
using System.Drawing;
using System.Windows.Forms;

namespace BaiTH6B
{
    partial class FormDiem
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblSinhVien, lblMonHoc, lblDiem;
        private ComboBox cboSinhVien, cboMonHoc;
        private TextBox txtDiem;
        private Button btnThem, btnXoa, btnSua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblSinhVien = new Label();
            lblMonHoc = new Label();
            lblDiem = new Label();

            cboSinhVien = new ComboBox();
            cboMonHoc = new ComboBox();
            txtDiem = new TextBox();

            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();

            SuspendLayout();

            // Sinh viên
            lblSinhVien.Text = "Sinh viên";
            lblSinhVien.Location = new Point(30, 35);
            lblSinhVien.AutoSize = true;

            cboSinhVien.Location = new Point(135, 32);
            cboSinhVien.Size = new Size(220, 28);
            cboSinhVien.DropDownStyle = ComboBoxStyle.DropDownList;

            // Môn học
            lblMonHoc.Text = "Môn học";
            lblMonHoc.Location = new Point(30, 80);
            lblMonHoc.AutoSize = true;

            cboMonHoc.Location = new Point(135, 77);
            cboMonHoc.Size = new Size(220, 28);
            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;

            // Điểm
            lblDiem.Text = "Điểm";
            lblDiem.Location = new Point(30, 125);
            lblDiem.AutoSize = true;

            txtDiem.Location = new Point(135, 122);
            txtDiem.Size = new Size(220, 27);

            // Buttons
            btnThem.Text = "Thêm";
            btnThem.Location = new Point(45, 185);
            btnThem.Size = new Size(90, 38);
            btnThem.Click += btnThem_Click;

            btnXoa.Text = "Xóa";
            btnXoa.Location = new Point(155, 185);
            btnXoa.Size = new Size(90, 38);
            btnXoa.Click += btnXoa_Click;

            btnSua.Text = "Sửa";
            btnSua.Location = new Point(265, 185);
            btnSua.Size = new Size(90, 38);
            btnSua.Click += btnSua_Click;

            // Form
            ClientSize = new Size(405, 260);
            Text = "Quản lý điểm";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.AddRange(new Control[]
            {
                lblSinhVien, cboSinhVien,
                lblMonHoc, cboMonHoc,
                lblDiem, txtDiem,
                btnThem, btnXoa, btnSua
            });

            Load += FormDiem_Load;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
