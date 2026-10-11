using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5D
{
    partial class FormMonHoc
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMaMH, lblTenMH;
        private TextBox txtMaMH, txtTenMH;
        private Button btnThem, btnXoa, btnSua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaMH = new Label();
            this.lblTenMH = new Label();
            this.txtMaMH = new TextBox();
            this.txtTenMH = new TextBox();
            this.btnThem = new Button();
            this.btnXoa = new Button();
            this.btnSua = new Button();
            this.SuspendLayout();

            this.lblMaMH.Text = "Mã mh"; this.lblMaMH.Location = new Point(30, 30); this.lblMaMH.AutoSize = true;
            this.lblTenMH.Text = "Tên mh"; this.lblTenMH.Location = new Point(30, 70); this.lblTenMH.AutoSize = true;

            this.txtMaMH.Location = new Point(90, 27); this.txtMaMH.Size = new Size(250, 22);
            this.txtTenMH.Location = new Point(90, 67); this.txtTenMH.Size = new Size(250, 22);

            this.btnThem.Text = "Thêm"; this.btnThem.Location = new Point(30, 110); this.btnThem.Size = new Size(90, 35);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnXoa.Text = "Xóa"; this.btnXoa.Location = new Point(140, 110); this.btnXoa.Size = new Size(90, 35);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnSua.Text = "Sửa"; this.btnSua.Location = new Point(250, 110); this.btnSua.Size = new Size(90, 35);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.ClientSize = new Size(380, 170);
            this.Text = "Quản lý môn học";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblMaMH); this.Controls.Add(this.lblTenMH);
            this.Controls.Add(this.txtMaMH); this.Controls.Add(this.txtTenMH);
            this.Controls.Add(this.btnThem); this.Controls.Add(this.btnXoa); this.Controls.Add(this.btnSua);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}