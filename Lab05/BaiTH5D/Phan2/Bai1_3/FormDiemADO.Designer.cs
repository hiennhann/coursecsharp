using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5D
{
    partial class FormDiemADO
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMaSV, lblMaMH, lblDiem;
        private ComboBox cboMaSV, cboMaMH;
        private TextBox txtDiem;
        private Button btnThem, btnXoa, btnSua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaSV = new Label(); this.lblMaMH = new Label(); this.lblDiem = new Label();
            this.cboMaSV = new ComboBox(); this.cboMaMH = new ComboBox();
            this.txtDiem = new TextBox();
            this.btnThem = new Button(); this.btnXoa = new Button(); this.btnSua = new Button();
            this.SuspendLayout();

            this.lblMaSV.Text = "Mã sv"; this.lblMaSV.Location = new Point(30, 30); this.lblMaSV.AutoSize = true;
            this.cboMaSV.Location = new Point(100, 27); this.cboMaSV.Size = new Size(200, 24);
            this.cboMaSV.DropDownStyle = ComboBoxStyle.DropDownList;

            this.lblMaMH.Text = "Mã mh"; this.lblMaMH.Location = new Point(30, 70); this.lblMaMH.AutoSize = true;
            this.cboMaMH.Location = new Point(100, 67); this.cboMaMH.Size = new Size(200, 24);
            this.cboMaMH.DropDownStyle = ComboBoxStyle.DropDownList;

            this.lblDiem.Text = "Điểm"; this.lblDiem.Location = new Point(30, 110); this.lblDiem.AutoSize = true;
            this.txtDiem.Location = new Point(100, 107); this.txtDiem.Size = new Size(200, 22);

            this.btnThem.Text = "Thêm"; this.btnThem.Location = new Point(30, 160); this.btnThem.Size = new Size(80, 30); this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa.Text = "Xóa"; this.btnXoa.Location = new Point(125, 160); this.btnXoa.Size = new Size(80, 30); this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua.Text = "Sửa"; this.btnSua.Location = new Point(220, 160); this.btnSua.Size = new Size(80, 30); this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.ClientSize = new Size(340, 220);
            this.Text = "Quản lý Điểm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormDiemADO_Load);

            this.Controls.Add(this.lblMaSV); this.Controls.Add(this.cboMaSV);
            this.Controls.Add(this.lblMaMH); this.Controls.Add(this.cboMaMH);
            this.Controls.Add(this.lblDiem); this.Controls.Add(this.txtDiem);
            this.Controls.Add(this.btnThem); this.Controls.Add(this.btnXoa); this.Controls.Add(this.btnSua);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}