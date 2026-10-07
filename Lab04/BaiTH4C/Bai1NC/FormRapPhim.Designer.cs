using System.Drawing;
using System.Windows.Forms;

namespace BaiTH4C
{
    partial class FormRapPhim
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblManAnh, lblThanhTienText, lblThanhTienGiaTri;
        private Panel panelGhe;
        private Button btnChon, btnHuyBo, btnKetThuc;

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
            this.lblManAnh = new Label();
            this.lblThanhTienText = new Label();
            this.lblThanhTienGiaTri = new Label();
            this.panelGhe = new Panel();
            this.btnChon = new Button();
            this.btnHuyBo = new Button();
            this.btnKetThuc = new Button();

            this.SuspendLayout();

            // Tiêu đề MÀN ẢNH
            this.lblManAnh.AutoSize = true;
            this.lblManAnh.Font = new Font("Arial", 16F, FontStyle.Bold);
            this.lblManAnh.ForeColor = Color.DarkOrange;
            this.lblManAnh.Location = new Point(140, 20);
            this.lblManAnh.Text = "MÀN ẢNH";

            // Panel chứa 15 ghế (để dễ quản lý tọa độ)
            this.panelGhe.Location = new Point(40, 60);
            this.panelGhe.Size = new Size(320, 200);

            // Label Thành Tiền
            this.lblThanhTienText.AutoSize = true;
            this.lblThanhTienText.Location = new Point(40, 280);
            this.lblThanhTienText.Font = new Font("Arial", 10F);
            this.lblThanhTienText.Text = "Thành Tiền:";

            // Nơi hiển thị số tiền (Hiển thị giống 1 TextBox dạng ReadOnly)
            this.lblThanhTienGiaTri.Location = new Point(130, 275);
            this.lblThanhTienGiaTri.Size = new Size(200, 30);
            this.lblThanhTienGiaTri.BorderStyle = BorderStyle.FixedSingle;
            this.lblThanhTienGiaTri.BackColor = Color.White;
            this.lblThanhTienGiaTri.TextAlign = ContentAlignment.MiddleRight;
            this.lblThanhTienGiaTri.Font = new Font("Arial", 11F, FontStyle.Bold);
            this.lblThanhTienGiaTri.Text = "0";

            // Các nút bấm điều khiển
            this.btnChon.Location = new Point(50, 330);
            this.btnChon.Size = new Size(80, 30);
            this.btnChon.Text = "Chọn";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);

            this.btnHuyBo.Location = new Point(160, 330);
            this.btnHuyBo.Size = new Size(80, 30);
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);

            this.btnKetThuc.Location = new Point(270, 330);
            this.btnKetThuc.Size = new Size(80, 30);
            this.btnKetThuc.Text = "Kết thúc";
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);

            // Form
            this.ClientSize = new Size(400, 400);
            this.Controls.Add(this.lblManAnh);
            this.Controls.Add(this.panelGhe);
            this.Controls.Add(this.lblThanhTienText);
            this.Controls.Add(this.lblThanhTienGiaTri);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnKetThuc);
            this.Name = "FormRapPhim";
            this.Text = "BÁN VÉ RẠP CHIẾU BÓNG";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}