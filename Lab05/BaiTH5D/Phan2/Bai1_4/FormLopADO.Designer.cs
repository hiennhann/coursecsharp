using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5D
{
    partial class FormLopADO
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMaKhoa, lblMaLop, lblTenLop;
        private TextBox txtMaLop, txtTenLop;
        private ComboBox cboMaKhoa; // Thay TextBox bằng ComboBox để chống lỗi khóa ngoại
        private Button btnThem, btnXoa, btnSua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaKhoa = new Label(); this.lblMaLop = new Label(); this.lblTenLop = new Label();
            this.cboMaKhoa = new ComboBox();
            this.txtMaLop = new TextBox(); this.txtTenLop = new TextBox();
            this.btnThem = new Button(); this.btnXoa = new Button(); this.btnSua = new Button();
            this.SuspendLayout();

            this.lblMaKhoa.Text = "Mã khoa"; this.lblMaKhoa.Location = new Point(30, 30); this.lblMaKhoa.AutoSize = true;
            this.cboMaKhoa.Location = new Point(100, 27); this.cboMaKhoa.Size = new Size(200, 24);
            this.cboMaKhoa.DropDownStyle = ComboBoxStyle.DropDownList;

            this.lblMaLop.Text = "Mã lớp"; this.lblMaLop.Location = new Point(30, 70); this.lblMaLop.AutoSize = true;
            this.txtMaLop.Location = new Point(100, 67); this.txtMaLop.Size = new Size(200, 22);

            this.lblTenLop.Text = "Tên lớp"; this.lblTenLop.Location = new Point(30, 110); this.lblTenLop.AutoSize = true;
            this.txtTenLop.Location = new Point(100, 107); this.txtTenLop.Size = new Size(200, 22);

            this.btnThem.Text = "Thêm"; this.btnThem.Location = new Point(30, 160); this.btnThem.Size = new Size(80, 30); this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa.Text = "Xóa"; this.btnXoa.Location = new Point(125, 160); this.btnXoa.Size = new Size(80, 30); this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua.Text = "Sửa"; this.btnSua.Location = new Point(220, 160); this.btnSua.Size = new Size(80, 30); this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.ClientSize = new Size(340, 220);
            this.Text = "frmLop";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormLopADO_Load); // Load Mã Khoa tự động

            this.Controls.Add(this.lblMaKhoa); this.Controls.Add(this.cboMaKhoa);
            this.Controls.Add(this.lblMaLop); this.Controls.Add(this.txtMaLop);
            this.Controls.Add(this.lblTenLop); this.Controls.Add(this.txtTenLop);
            this.Controls.Add(this.btnThem); this.Controls.Add(this.btnXoa); this.Controls.Add(this.btnSua);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}