using System.Drawing;
using System.Windows.Forms;

namespace BaiTH4C
{
    partial class FormBai3
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle, lblA, lblB, lblUCLN, lblBCNN;
        private TextBox txtA, txtB, txtUCLN, txtBCNN;
        private Button btnThucHien, btnTiepTuc, btnThoat;
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
            this.lblA = new Label();
            this.lblB = new Label();
            this.lblUCLN = new Label();
            this.lblBCNN = new Label();
            
            this.txtA = new TextBox();
            this.txtB = new TextBox();
            this.txtUCLN = new TextBox();
            this.txtBCNN = new TextBox();
            
            this.btnThucHien = new Button();
            this.btnTiepTuc = new Button();
            this.btnThoat = new Button();
            
            this.errorProvider1 = new ErrorProvider(this.components);

            this.SuspendLayout();

            // Tiêu đề
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Red;
            this.lblTitle.Location = new Point(40, 20);
            this.lblTitle.Text = "Ước Số Chung - Bội Số Chung";

            // Labels
            this.lblA.Location = new Point(50, 70);
            this.lblA.Text = "Nhập số a :";
            this.lblA.AutoSize = true;
            this.lblA.Font = new Font("Times New Roman", 11F);

            this.lblB.Location = new Point(50, 105);
            this.lblB.Text = "Nhập số b :";
            this.lblB.AutoSize = true;
            this.lblB.Font = new Font("Times New Roman", 11F);

            this.lblUCLN.Location = new Point(50, 140);
            this.lblUCLN.Text = "Ước số chung lớn nhất :";
            this.lblUCLN.AutoSize = true;
            this.lblUCLN.Font = new Font("Times New Roman", 11F);

            this.lblBCNN.Location = new Point(50, 175);
            this.lblBCNN.Text = "Bội số chung nhỏ nhất :";
            this.lblBCNN.AutoSize = true;
            this.lblBCNN.Font = new Font("Times New Roman", 11F);

            // TextBoxes
            this.txtA.Location = new Point(200, 68);
            this.txtA.Size = new Size(100, 24);
            this.txtA.KeyPress += new KeyPressEventHandler(this.txt_KeyPress);

            this.txtB.Location = new Point(200, 103);
            this.txtB.Size = new Size(100, 24);
            this.txtB.KeyPress += new KeyPressEventHandler(this.txt_KeyPress);

            // TextBoxes UCLN và BCNN 
            this.txtUCLN.Location = new Point(240, 138);
            this.txtUCLN.Size = new Size(100, 24);
            this.txtUCLN.ReadOnly = true; 
            this.txtUCLN.BackColor = Color.WhiteSmoke;

            this.txtBCNN.Location = new Point(240, 173);
            this.txtBCNN.Size = new Size(100, 24);
            this.txtBCNN.ReadOnly = true;
            this.txtBCNN.BackColor = Color.WhiteSmoke;

            this.btnThucHien.Location = new Point(40, 220);
            this.btnThucHien.Size = new Size(90, 30); // Tăng kích thước
            this.btnThucHien.Text = "Thực Hiện";
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click); 

            this.btnTiepTuc.Location = new Point(135, 220);
            this.btnTiepTuc.Size = new Size(80, 30);
            this.btnTiepTuc.Text = "Tiếp Tục";
            this.btnTiepTuc.Click += new System.EventHandler(this.btnTiepTuc_Click);

            this.btnThoat.Location = new Point(230, 220);
            this.btnThoat.Size = new Size(80, 30);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // Form
            this.ClientSize = new Size(360, 280);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblUCLN);
            this.Controls.Add(this.lblBCNN);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtUCLN);
            this.Controls.Add(this.txtBCNN);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.btnTiepTuc);
            this.Controls.Add(this.btnThoat);
            this.Name = "FormBai3";
            this.Text = "Ước Số - Bội Số";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += new FormClosingEventHandler(this.FormBai3_FormClosing);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}