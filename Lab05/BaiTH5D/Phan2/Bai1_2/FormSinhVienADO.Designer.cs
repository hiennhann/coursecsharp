using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5D
{
    partial class FormSinhVienADO
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMaLop, lblMaSV, lblHoTen, lblNgaySinh;
        private TextBox txtMaSV, txtHoTen;
        private ComboBox cboMaLop; 
        private DateTimePicker dtpNgaySinh; 
        private Button btnThem, btnXoa, btnSua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaLop = new Label(); this.lblMaSV = new Label();
            this.lblHoTen = new Label(); this.lblNgaySinh = new Label();
            this.cboMaLop = new ComboBox(); 
            this.txtMaSV = new TextBox(); this.txtHoTen = new TextBox();
            this.dtpNgaySinh = new DateTimePicker();
            this.btnThem = new Button(); this.btnXoa = new Button(); this.btnSua = new Button();
            this.SuspendLayout();

            this.lblMaLop.Text = "Mã lớp"; this.lblMaLop.Location = new Point(30, 30); this.lblMaLop.AutoSize = true;
            this.cboMaLop.Location = new Point(100, 27); this.cboMaLop.Size = new Size(200, 24);
            this.cboMaLop.DropDownStyle = ComboBoxStyle.DropDownList; // Chỉ cho chọn, không cho gõ tay

            this.lblMaSV.Text = "Mã sv"; this.lblMaSV.Location = new Point(30, 65); this.lblMaSV.AutoSize = true;
            this.txtMaSV.Location = new Point(100, 62); this.txtMaSV.Size = new Size(200, 22);

            this.lblHoTen.Text = "Họ tên"; this.lblHoTen.Location = new Point(30, 100); this.lblHoTen.AutoSize = true;
            this.txtHoTen.Location = new Point(100, 97); this.txtHoTen.Size = new Size(200, 22);

            this.lblNgaySinh.Text = "Ngày sinh"; this.lblNgaySinh.Location = new Point(30, 135); this.lblNgaySinh.AutoSize = true;
            this.dtpNgaySinh.Location = new Point(100, 132); this.dtpNgaySinh.Size = new Size(200, 22);
            this.dtpNgaySinh.Format = DateTimePickerFormat.Short;

            this.btnThem.Text = "Thêm"; this.btnThem.Location = new Point(30, 180); this.btnThem.Size = new Size(80, 30); this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa.Text = "Xóa"; this.btnXoa.Location = new Point(125, 180); this.btnXoa.Size = new Size(80, 30); this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua.Text = "Sửa"; this.btnSua.Location = new Point(220, 180); this.btnSua.Size = new Size(80, 30); this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.ClientSize = new Size(340, 240);
            this.Text = "Quản lý sinh viên";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormSinhVienADO_Load); // Bắt sự kiện form vừa mở lên
            
            this.Controls.Add(this.lblMaLop); this.Controls.Add(this.cboMaLop);
            this.Controls.Add(this.lblMaSV); this.Controls.Add(this.txtMaSV);
            this.Controls.Add(this.lblHoTen); this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblNgaySinh); this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.btnThem); this.Controls.Add(this.btnXoa); this.Controls.Add(this.btnSua);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}