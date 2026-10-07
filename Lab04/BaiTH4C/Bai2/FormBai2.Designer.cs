using System.Drawing;
using System.Windows.Forms;

namespace BaiTH4C 
{
    partial class FormBai2
    {
        private System.ComponentModel.IContainer components = null;
        
        private Label lblTitle, lblTenDangNhap, lblEmail, lblMatKhau, lblXacNhan;
        private Label lblSao1, lblSao2, lblSao3;
        private TextBox txtTenDangNhap, txtEmail, txtMatKhau, txtXacNhanMatKhau;
        private Button btnDangKy;
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
            this.lblTenDangNhap = new Label();
            this.lblEmail = new Label();
            this.lblMatKhau = new Label();
            this.lblXacNhan = new Label();
            this.lblSao1 = new Label();
            this.lblSao2 = new Label();
            this.lblSao3 = new Label();
            
            this.txtTenDangNhap = new TextBox();
            this.txtEmail = new TextBox();
            this.txtMatKhau = new TextBox();
            this.txtXacNhanMatKhau = new TextBox();
            
            this.btnDangKy = new Button();
            this.errorProvider1 = new ErrorProvider(this.components);

            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Arial", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.DodgerBlue;
            this.lblTitle.Location = new Point(110, 20);
            this.lblTitle.Text = "Đăng ký tài khoản";

            // Labels
            this.lblTenDangNhap.Location = new Point(30, 70);
            this.lblTenDangNhap.Text = "Tên đăng nhập";
            this.lblTenDangNhap.AutoSize = true;

            this.lblEmail.Location = new Point(30, 110);
            this.lblEmail.Text = "Địa chỉ email";
            this.lblEmail.AutoSize = true;

            this.lblMatKhau.Location = new Point(30, 150);
            this.lblMatKhau.Text = "Mật khẩu";
            this.lblMatKhau.AutoSize = true;

            this.lblXacNhan.Location = new Point(30, 190);
            this.lblXacNhan.Text = "Xác nhận mật khẩu";
            this.lblXacNhan.AutoSize = true;

            // Dấu (*) bắt buộc
            this.lblSao1.Text = "(*)";
            this.lblSao1.Location = new Point(320, 68);
            this.lblSao1.AutoSize = true;

            this.lblSao2.Text = "(*)";
            this.lblSao2.Location = new Point(320, 108);
            this.lblSao2.AutoSize = true;

            this.lblSao3.Text = "(*)";
            this.lblSao3.Location = new Point(320, 148);
            this.lblSao3.AutoSize = true;

            // TextBoxes
            this.txtTenDangNhap.Location = new Point(150, 67);
            this.txtTenDangNhap.Size = new Size(160, 20);

            this.txtEmail.Location = new Point(150, 107);
            this.txtEmail.Size = new Size(160, 20);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave); // Yêu cầu: kiểm tra khi ra khỏi textbox

            this.txtMatKhau.Location = new Point(150, 147);
            this.txtMatKhau.Size = new Size(160, 20);
            this.txtMatKhau.UseSystemPasswordChar = true; // Ẩn mật khẩu

            this.txtXacNhanMatKhau.Location = new Point(150, 187);
            this.txtXacNhanMatKhau.Size = new Size(160, 20);
            this.txtXacNhanMatKhau.UseSystemPasswordChar = true; // Ẩn mật khẩu
            this.txtXacNhanMatKhau.KeyDown += new KeyEventHandler(this.txtXacNhanMatKhau_KeyDown); // Yêu cầu: Nhấn Enter

            // Button Đăng ký
            this.btnDangKy.Location = new Point(150, 230);
            this.btnDangKy.Size = new Size(160, 35);
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.ForeColor = Color.DodgerBlue;
            this.btnDangKy.Font = new Font("Arial", 9F, FontStyle.Bold);
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);

            // Cấu hình Form
            this.ClientSize = new Size(380, 290);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTenDangNhap);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.lblXacNhan);
            this.Controls.Add(this.lblSao1);
            this.Controls.Add(this.lblSao2);
            this.Controls.Add(this.lblSao3);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtXacNhanMatKhau);
            this.Controls.Add(this.btnDangKy);
            
            this.Name = "FormBai2";
            this.Text = "Đăng ký tài khoản";
            this.FormClosing += new FormClosingEventHandler(this.FormBai2_FormClosing);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}