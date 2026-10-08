using System.Drawing;
using System.Windows.Forms;

namespace BaiTH4D
{
    partial class FormGiaiPT
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle, lblChon, lblA, lblB, lblC, lblKetQua;
        private RadioButton rdoBacNhat, rdoBacHai;
        private TextBox txtA, txtB, txtC, txtKetQua;
        private Button btnGiai, btnThoat;
        private Panel panelChon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblChon = new Label();
            this.lblA = new Label();
            this.lblB = new Label();
            this.lblC = new Label();
            this.lblKetQua = new Label();
            this.rdoBacNhat = new RadioButton();
            this.rdoBacHai = new RadioButton();
            this.txtA = new TextBox();
            this.txtB = new TextBox();
            this.txtC = new TextBox();
            this.txtKetQua = new TextBox();
            this.btnGiai = new Button();
            this.btnThoat = new Button();
            this.panelChon = new Panel();

            this.SuspendLayout();

            // Tiêu đề
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Times New Roman", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Red;
            this.lblTitle.Location = new Point(45, 20);
            this.lblTitle.Text = "GIẢI PHƯƠNG TRÌNH";

            // Vùng chọn loại phương trình
            this.lblChon.AutoSize = true;
            this.lblChon.Location = new Point(30, 60);
            this.lblChon.Text = "Bạn vui lòng chọn";

            this.panelChon.Location = new Point(40, 80);
            this.panelChon.Size = new Size(250, 60);
            this.panelChon.BorderStyle = BorderStyle.FixedSingle;

            this.rdoBacNhat.AutoSize = true;
            this.rdoBacNhat.Location = new Point(20, 10);
            this.rdoBacNhat.Text = "Phương trình bậc nhất";
            this.rdoBacNhat.Checked = true; // Mặc định chọn Bậc 1
            this.rdoBacNhat.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);

            this.rdoBacHai.AutoSize = true;
            this.rdoBacHai.Location = new Point(20, 35);
            this.rdoBacHai.Text = "Phương trình bậc hai";
            this.rdoBacHai.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);

            this.panelChon.Controls.Add(this.rdoBacNhat);
            this.panelChon.Controls.Add(this.rdoBacHai);

            // Nhập a, b, c
            this.lblA.Location = new Point(30, 160); this.lblA.Text = "Nhập a"; this.lblA.AutoSize = true;
            this.lblB.Location = new Point(30, 195); this.lblB.Text = "Nhập b"; this.lblB.AutoSize = true;
            this.lblC.Location = new Point(30, 230); this.lblC.Text = "Nhập c"; this.lblC.AutoSize = true;

            // Đẩy các TextBox sang phải (x = 110) để tránh bị đè
            this.txtA.Location = new Point(110, 157); this.txtA.Size = new Size(120, 22);
            this.txtA.TextChanged += new System.EventHandler(this.KiemTraNhapLieu);

            this.txtB.Location = new Point(110, 192); this.txtB.Size = new Size(120, 22);
            this.txtB.TextChanged += new System.EventHandler(this.KiemTraNhapLieu);

            this.txtC.Location = new Point(110, 227); this.txtC.Size = new Size(120, 22);
            this.txtC.TextChanged += new System.EventHandler(this.KiemTraNhapLieu);
            this.txtC.Enabled = false; 

            // Nút Giải
            this.btnGiai.Location = new Point(260, 155);
            this.btnGiai.Size = new Size(90, 40);
            this.btnGiai.Text = "Giải"; // Thêm lại chữ cho nút
            this.btnGiai.Enabled = false; // Mờ nút khi form mới load
            this.btnGiai.Click += new System.EventHandler(this.btnGiai_Click); // Nối lại sự kiện click

            // Nút Thoát
            this.btnThoat.Location = new Point(260, 205);
            this.btnThoat.Size = new Size(90, 40);
            this.btnThoat.Text = "Thoát"; // Thêm lại chữ cho nút
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click); // Nối lại sự kiện click
            // Sửa lại vị trí ô Kết quả
            this.lblKetQua.Location = new Point(30, 270); this.lblKetQua.Text = "Kết quả"; this.lblKetQua.AutoSize = true;
            this.txtKetQua.Location = new Point(110, 267);
            this.txtKetQua.Size = new Size(240, 22);
            this.txtKetQua.ReadOnly = true;

            // Form
            this.ClientSize = new Size(420, 320);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblChon);
            this.Controls.Add(this.panelChon);
            this.Controls.Add(this.lblA); this.Controls.Add(this.lblB); this.Controls.Add(this.lblC);
            this.Controls.Add(this.txtA); this.Controls.Add(this.txtB); this.Controls.Add(this.txtC);
            this.Controls.Add(this.btnGiai); this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblKetQua); this.Controls.Add(this.txtKetQua);

            this.Name = "FormGiaiPT";
            this.Text = "Giải phương trình bậc 1-2";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += new FormClosingEventHandler(this.FormGiaiPT_FormClosing);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}