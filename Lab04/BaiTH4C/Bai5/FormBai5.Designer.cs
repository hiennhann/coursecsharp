using System.Drawing;
using System.Windows.Forms;

namespace BaiTH4C
{
    partial class FormBai5
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle, lblHuongDan;
        private TextBox txtNhapSo, txtKetQua;
        private Button btnThucHien, btnXoa, btnThoat;
        private ErrorProvider errorProvider1;

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
            this.components = new System.ComponentModel.Container();
            
            this.lblTitle = new Label();
            this.lblHuongDan = new Label();
            this.txtNhapSo = new TextBox();
            this.txtKetQua = new TextBox();
            this.btnThucHien = new Button();
            this.btnXoa = new Button();
            this.btnThoat = new Button();
            this.errorProvider1 = new ErrorProvider(this.components);

            this.SuspendLayout();

            // Tiêu đề
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Times New Roman", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Red;
            this.lblTitle.Location = new Point(80, 20);
            this.lblTitle.Text = "Đọc Số Thành Chữ";

            // Label Hướng dẫn
            this.lblHuongDan.AutoSize = true;
            this.lblHuongDan.Location = new Point(30, 70);
            this.lblHuongDan.Font = new Font("Times New Roman", 12F);
            this.lblHuongDan.Text = "Nhập dãy số(từ 1 đến 999)";

            // TextBox Nhập số
            this.txtNhapSo.Location = new Point(260, 68);
            this.txtNhapSo.Size = new Size(100, 26);
            this.txtNhapSo.Font = new Font("Times New Roman", 12F);
            this.txtNhapSo.KeyPress += new KeyPressEventHandler(this.txt_KeyPress); // Bắt lỗi chỉ cho nhập số
            this.txtNhapSo.KeyDown += new KeyEventHandler(this.txtNhapSo_KeyDown); // Hỗ trợ Enter

            // Button Thực Hiện
            this.btnThucHien.Location = new Point(40, 110);
            this.btnThucHien.Size = new Size(90, 32);
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);

            // Button Xóa
            this.btnXoa.Location = new Point(150, 110);
            this.btnXoa.Size = new Size(90, 32);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // Button Thoát
            this.btnThoat.Location = new Point(260, 110);
            this.btnThoat.Size = new Size(90, 32);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // TextBox Kết quả đọc chữ
            this.txtKetQua.Location = new Point(30, 160);
            this.txtKetQua.Size = new Size(330, 26);
            this.txtKetQua.Font = new Font("Times New Roman", 12F);
            this.txtKetQua.ReadOnly = true; 
            this.txtKetQua.BackColor = Color.PeachPuff; // Màu nền cam nhạt giống đề bài
            this.txtKetQua.ForeColor = Color.Blue;      // Chữ màu xanh giống đề bài

            // Form
            this.ClientSize = new Size(400, 220); // Kích thước rộng rãi
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblHuongDan);
            this.Controls.Add(this.txtNhapSo);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.txtKetQua);
            
            this.Name = "FormBai5";
            this.Text = "Tâm Gà - Đọc Chữ Số";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += new FormClosingEventHandler(this.FormBai5_FormClosing);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}