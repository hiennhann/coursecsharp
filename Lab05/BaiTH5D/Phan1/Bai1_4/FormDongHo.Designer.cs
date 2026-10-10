using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5D
{
    partial class FormDongHo
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblThoiGian, lblNhap;
        private TextBox txtNhapPhut;
        private Button btnBatDau, btnReset;
        private System.Windows.Forms.Timer timerDemNguoc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblThoiGian = new Label();
            this.lblNhap = new Label();
            this.txtNhapPhut = new TextBox();
            this.btnBatDau = new Button();
            this.btnReset = new Button();
            this.timerDemNguoc = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

            // Nhập phút
            this.lblNhap.Text = "Nhập phút đếm ngược:";
            this.lblNhap.Location = new Point(40, 23);
            this.lblNhap.AutoSize = true;

            this.txtNhapPhut.Location = new Point(200, 20);
            this.txtNhapPhut.Size = new Size(60, 22);
            this.txtNhapPhut.Text = "30"; // Mặc định là 30
            this.txtNhapPhut.TextAlign = HorizontalAlignment.Center;

            // Label hiển thị thời gian
            this.lblThoiGian.Text = "00:00";
            this.lblThoiGian.Font = new Font("Consolas", 36F, FontStyle.Bold);
            this.lblThoiGian.Location = new Point(0, 60);
            this.lblThoiGian.Size = new Size(320, 60);
            this.lblThoiGian.TextAlign = ContentAlignment.MiddleCenter;
            this.lblThoiGian.ForeColor = Color.DarkRed;

            // Nút Bắt đầu / Dừng
            this.btnBatDau.Text = "Bắt đầu";
            this.btnBatDau.Font = new Font("Arial", 11F, FontStyle.Bold);
            this.btnBatDau.Location = new Point(50, 140);
            this.btnBatDau.Size = new Size(100, 40);
            this.btnBatDau.BackColor = Color.LightCyan;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);

            // Nút Làm mới (Reset)
            this.btnReset.Text = "Làm mới";
            this.btnReset.Font = new Font("Arial", 11F, FontStyle.Bold);
            this.btnReset.Location = new Point(170, 140);
            this.btnReset.Size = new Size(100, 40);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // Cấu hình Timer
            this.timerDemNguoc.Interval = 1000;
            this.timerDemNguoc.Tick += new System.EventHandler(this.timerDemNguoc_Tick);

            // Form
            this.ClientSize = new Size(320, 210);
            this.Text = "Đồng hồ Đếm ngược";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblNhap);
            this.Controls.Add(this.txtNhapPhut);
            this.Controls.Add(this.lblThoiGian);
            this.Controls.Add(this.btnBatDau);
            this.Controls.Add(this.btnReset);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}