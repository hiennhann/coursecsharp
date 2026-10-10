using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5D
{
    partial class FormNhapHocVien
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHoTen, lblLop;
        private TextBox txtHoTen;
        private ComboBox cboLop;
        private Button btnCapNhat, btnTroVe;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHoTen = new Label(); this.lblLop = new Label();
            this.txtHoTen = new TextBox();
            this.cboLop = new ComboBox();
            this.btnCapNhat = new Button(); this.btnTroVe = new Button();
            this.SuspendLayout();

            this.lblHoTen.Text = "Họ và Tên"; this.lblHoTen.Location = new Point(30, 30); this.lblHoTen.AutoSize = true;
            this.txtHoTen.Location = new Point(120, 27); this.txtHoTen.Size = new Size(200, 22);

            this.lblLop.Text = "Lớp"; this.lblLop.Location = new Point(30, 70); this.lblLop.AutoSize = true;
            this.cboLop.Location = new Point(120, 67); this.cboLop.Size = new Size(200, 24);
            this.cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLop.Items.AddRange(new object[] { "Lớp A", "Lớp B" });
            this.cboLop.SelectedIndex = 0;

            this.btnCapNhat.Text = "Cập nhật"; this.btnCapNhat.Location = new Point(120, 110); this.btnCapNhat.Size = new Size(90, 30);
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);

            this.btnTroVe.Text = "Trở về"; this.btnTroVe.Location = new Point(230, 110); this.btnTroVe.Size = new Size(90, 30);
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);

            this.ClientSize = new Size(360, 180);
            this.Text = "Nhập học viên mới";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Controls.Add(this.lblHoTen); this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblLop); this.Controls.Add(this.cboLop);
            this.Controls.Add(this.btnCapNhat); this.Controls.Add(this.btnTroVe);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}