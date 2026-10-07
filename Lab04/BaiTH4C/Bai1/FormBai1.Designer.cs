using System.Drawing;
using System.Windows.Forms;

namespace Lab04 // Nhớ đổi tên namespace cho khớp với project của bạn nếu cần
{
    partial class FormBai1
    {
        // Khai báo các biến control giao diện
        private System.ComponentModel.IContainer components = null;
        private Label lblA, lblB, lblKetQua;
        private TextBox txtA, txtB, txtKetQua;
        private Button btnCong, btnTru, btnNhan, btnChia;
        private ErrorProvider errorProvider1;

        // Hàm dọn dẹp tài nguyên
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Hàm khởi tạo toàn bộ giao diện
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblA = new Label();
            this.lblB = new Label();
            this.lblKetQua = new Label();
            this.txtA = new TextBox();
            this.txtB = new TextBox();
            this.txtKetQua = new TextBox();
            this.btnCong = new Button();
            this.btnTru = new Button();
            this.btnNhan = new Button();
            this.btnChia = new Button();
            this.errorProvider1 = new ErrorProvider(this.components);

            this.SuspendLayout();

            // Lable a, b, Kết quả
            this.lblA.Location = new Point(20, 20);
            this.lblA.Size = new Size(30, 20);
            this.lblA.Text = "a =";

            this.lblB.Location = new Point(160, 20);
            this.lblB.Size = new Size(30, 20);
            this.lblB.Text = "b =";

            this.lblKetQua.Location = new Point(20, 60);
            this.lblKetQua.Size = new Size(50, 20);
            this.lblKetQua.Text = "Kết quả";

            // TextBox a, b, Kết quả
            this.txtA.Location = new Point(50, 18);
            this.txtA.Size = new Size(80, 20);
            this.txtA.KeyPress += new KeyPressEventHandler(this.txt_KeyPress); 

            this.txtB.Location = new Point(190, 18);
            this.txtB.Size = new Size(80, 20);
            this.txtB.KeyPress += new KeyPressEventHandler(this.txt_KeyPress); 

            this.txtKetQua.Location = new Point(80, 58);
            this.txtKetQua.Size = new Size(190, 20);
            this.txtKetQua.ReadOnly = true; 

            // Các nút bấm +, -, x, /
            this.btnCong.Location = new Point(20, 100);
            this.btnCong.Size = new Size(50, 30);
            this.btnCong.Text = "+";
            this.btnCong.Click += new System.EventHandler(this.btnCong_Click);

            this.btnTru.Location = new Point(85, 100);
            this.btnTru.Size = new Size(50, 30);
            this.btnTru.Text = "-";
            this.btnTru.Click += new System.EventHandler(this.btnTru_Click);

            this.btnNhan.Location = new Point(150, 100);
            this.btnNhan.Size = new Size(50, 30);
            this.btnNhan.Text = "x";
            this.btnNhan.Click += new System.EventHandler(this.btnNhan_Click);

            this.btnChia.Location = new Point(215, 100);
            this.btnChia.Size = new Size(50, 30);
            this.btnChia.Text = "/";
            this.btnChia.Click += new System.EventHandler(this.btnChia_Click);

            // Cấu hình Form chính
            this.ClientSize = new Size(300, 150);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.btnCong);
            this.Controls.Add(this.btnTru);
            this.Controls.Add(this.btnNhan);
            this.Controls.Add(this.btnChia);
            this.Name = "FormBai1";
            this.Text = "Cộng trừ nhân chia";
            this.FormClosing += new FormClosingEventHandler(this.FormBai1_FormClosing); 

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}