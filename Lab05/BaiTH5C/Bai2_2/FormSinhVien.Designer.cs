using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5C
{
    partial class FormSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        private TreeView trvDanhSach;
        private Label lblChonLop, lblMaSV, lblHoTen, lblDiaChi, lblTenLop;
        private ComboBox cboLop;
        private TextBox txtMaSV, txtHoTen, txtDiaChi, txtTenLop;
        private Button btnCapNhat, btnXoa, btnThemLop;
        private CheckBox chkThemLop;
        private GroupBox grpThongTinSV, grpThemLop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.trvDanhSach = new TreeView();
            this.lblChonLop = new Label();
            this.cboLop = new ComboBox();
            this.grpThongTinSV = new GroupBox();
            this.lblMaSV = new Label();
            this.txtMaSV = new TextBox();
            this.lblHoTen = new Label();
            this.txtHoTen = new TextBox();
            this.lblDiaChi = new Label();
            this.txtDiaChi = new TextBox();
            this.btnCapNhat = new Button();
            this.btnXoa = new Button();
            this.chkThemLop = new CheckBox();
            this.grpThemLop = new GroupBox();
            this.lblTenLop = new Label();
            this.txtTenLop = new TextBox();
            this.btnThemLop = new Button();

            this.grpThongTinSV.SuspendLayout();
            this.grpThemLop.SuspendLayout();
            this.SuspendLayout();

            // Cây danh sách bên trái
            this.trvDanhSach.Location = new Point(20, 20);
            this.trvDanhSach.Size = new Size(250, 420);
            this.trvDanhSach.AfterSelect += new TreeViewEventHandler(this.trvDanhSach_AfterSelect);

            // Label & ComboBox Chọn Lớp
            this.lblChonLop.Text = "Chọn Lớp";
            this.lblChonLop.Location = new Point(290, 25);
            this.lblChonLop.AutoSize = true;

            this.cboLop.Location = new Point(370, 22);
            this.cboLop.Size = new Size(250, 24);
            this.cboLop.DropDownStyle = ComboBoxStyle.DropDownList;

            // GroupBox Thông tin sinh viên
            this.grpThongTinSV.Text = "Thông tin sinh viên";
            this.grpThongTinSV.Location = new Point(290, 60);
            this.grpThongTinSV.Size = new Size(350, 200);

            this.lblMaSV.Text = "Mã SV:"; this.lblMaSV.Location = new Point(20, 35); this.lblMaSV.AutoSize = true;
            this.txtMaSV.Location = new Point(100, 32); this.txtMaSV.Size = new Size(220, 22);

            this.lblHoTen.Text = "Họ Tên:"; this.lblHoTen.Location = new Point(20, 75); this.lblHoTen.AutoSize = true;
            this.txtHoTen.Location = new Point(100, 72); this.txtHoTen.Size = new Size(220, 22);

            this.lblDiaChi.Text = "Địa Chỉ:"; this.lblDiaChi.Location = new Point(20, 115); this.lblDiaChi.AutoSize = true;
            this.txtDiaChi.Location = new Point(100, 112); this.txtDiaChi.Size = new Size(220, 22);

            this.btnCapNhat.Text = "Cập Nhật"; this.btnCapNhat.Location = new Point(100, 150); this.btnCapNhat.Size = new Size(90, 30);
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);

            this.btnXoa.Text = "Xóa"; this.btnXoa.Location = new Point(210, 150); this.btnXoa.Size = new Size(90, 30);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.grpThongTinSV.Controls.Add(this.lblMaSV); this.grpThongTinSV.Controls.Add(this.txtMaSV);
            this.grpThongTinSV.Controls.Add(this.lblHoTen); this.grpThongTinSV.Controls.Add(this.txtHoTen);
            this.grpThongTinSV.Controls.Add(this.lblDiaChi); this.grpThongTinSV.Controls.Add(this.txtDiaChi);
            this.grpThongTinSV.Controls.Add(this.btnCapNhat); this.grpThongTinSV.Controls.Add(this.btnXoa);

            // Checkbox Thêm lớp
            this.chkThemLop.Text = "Thêm lớp";
            this.chkThemLop.Location = new Point(290, 275);
            this.chkThemLop.AutoSize = true;
            this.chkThemLop.CheckedChanged += new System.EventHandler(this.chkThemLop_CheckedChanged);

            // GroupBox Thêm lớp (Ban đầu ẩn đi)
            this.grpThemLop.Text = "Thông tin lớp";
            this.grpThemLop.Location = new Point(290, 310);
            this.grpThemLop.Size = new Size(350, 130);
            this.grpThemLop.Visible = false; // Thuộc tính ẩn

            this.lblTenLop.Text = "Tên lớp:"; this.lblTenLop.Location = new Point(20, 35); this.lblTenLop.AutoSize = true;
            this.txtTenLop.Location = new Point(100, 32); this.txtTenLop.Size = new Size(220, 22);

            this.btnThemLop.Text = "Thêm lớp"; this.btnThemLop.Location = new Point(100, 75); this.btnThemLop.Size = new Size(90, 30);
            this.btnThemLop.Click += new System.EventHandler(this.btnThemLop_Click);

            this.grpThemLop.Controls.Add(this.lblTenLop); this.grpThemLop.Controls.Add(this.txtTenLop);
            this.grpThemLop.Controls.Add(this.btnThemLop);

            // Form
            this.ClientSize = new Size(680, 470);
            this.Controls.Add(this.trvDanhSach);
            this.Controls.Add(this.lblChonLop);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.grpThongTinSV);
            this.Controls.Add(this.chkThemLop);
            this.Controls.Add(this.grpThemLop);
            this.Text = "Quản lý sinh viên";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormSinhVien_Load);

            this.grpThongTinSV.ResumeLayout(false);
            this.grpThongTinSV.PerformLayout();
            this.grpThemLop.ResumeLayout(false);
            this.grpThemLop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}