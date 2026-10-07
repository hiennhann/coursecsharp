using System.Drawing;
using System.Windows.Forms;

namespace BaiTH4C
{
    // Cờ partial chỉ ra đây là một phần của class FormBai4 (phần giao diện do Designer quản lý)
    partial class FormBai4
    {
        // Biến chứa các component/tài nguyên cần được quản lý để giải phóng bộ nhớ
        private System.ComponentModel.IContainer components = null;

        // Khai báo các biến điều khiển (controls) sẽ sử dụng trên Form
        private Label lblTitle, lblNhapSo, lblDayVuaNhap, lblTongDay, lblTongChan, lblTongLe;
        private TextBox txtNhapSo, txtDayVuaNhap, txtTongDay, txtTongChan, txtTongLe;
        private Button btnNhap, btnTinhTong, btnTiepTuc, btnThoat;
        private ErrorProvider errorProvider1;

        // Hàm Dispose dùng để dọn dẹp, giải phóng bộ nhớ khi Form bị đóng
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // Hủy các component đang sử dụng
            }
            base.Dispose(disposing);
        }

        // Hàm InitializeComponent chứa toàn bộ code khởi tạo, cấu hình vị trí, kích thước, và sự kiện cho các control
        private void InitializeComponent()
        {
            // 1. KHỞI TẠO CÁC ĐỐI TƯỢNG CONTROL
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new Label();
            this.lblNhapSo = new Label();
            this.lblDayVuaNhap = new Label();
            this.lblTongDay = new Label();
            this.lblTongChan = new Label();
            this.lblTongLe = new Label();
            this.txtNhapSo = new TextBox();
            this.txtDayVuaNhap = new TextBox();
            this.txtTongDay = new TextBox();
            this.txtTongChan = new TextBox();
            this.txtTongLe = new TextBox();
            this.btnNhap = new Button();
            this.btnTinhTong = new Button();
            this.btnTiepTuc = new Button();
            this.btnThoat = new Button();
            this.errorProvider1 = new ErrorProvider(this.components);
            
            this.SuspendLayout();

            // 2. CẤU HÌNH THUỘC TÍNH CHO CÁC LABEL (Nhãn văn bản)
            // Cấu hình tiêu đề chính
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Times New Roman", 16F, FontStyle.Bold); // Chữ to, in đậm
            this.lblTitle.ForeColor = Color.Red; // Chữ màu đỏ
            this.lblTitle.Location = new Point(45, 20); // Vị trí tọa độ (X, Y)
            this.lblTitle.Text = "Nhập Dãy Số và Tính Tổng";

            // Cấu hình các Label hiển thị mô tả
            this.lblNhapSo.AutoSize = true;
            this.lblNhapSo.Location = new Point(40, 70);
            this.lblNhapSo.Text = "Nhập số :";

            this.lblDayVuaNhap.AutoSize = true;
            this.lblDayVuaNhap.Location = new Point(40, 110);
            this.lblDayVuaNhap.Text = "Dãy vừa nhập :";

            this.lblTongDay.AutoSize = true;
            this.lblTongDay.Location = new Point(40, 190);
            this.lblTongDay.Text = "Tổng các phần tử trong dãy :";

            this.lblTongChan.AutoSize = true;
            this.lblTongChan.Location = new Point(40, 230);
            this.lblTongChan.Text = "Tổng Chẵn :";

            this.lblTongLe.AutoSize = true;
            this.lblTongLe.Location = new Point(195, 230);
            this.lblTongLe.Text = "Tổng Lẻ :";

            // Ô để người dùng nhập một số
            this.txtNhapSo.Location = new Point(140, 68);
            this.txtNhapSo.Size = new Size(80, 24);
            // Gắn sự kiện (Event) KeyDown: Gọi hàm txtNhapSo_KeyDown khi người dùng gõ phím (ví dụ: nhấn Enter để nhập)
            this.txtNhapSo.KeyDown += new KeyEventHandler(this.txtNhapSo_KeyDown); 

            // Các ô hiển thị kết quả 
            this.txtDayVuaNhap.Location = new Point(140, 108);
            this.txtDayVuaNhap.Size = new Size(180, 24);
            this.txtDayVuaNhap.ReadOnly = true; 

            this.txtTongDay.Location = new Point(240, 188); 
            this.txtTongDay.ReadOnly = true;

            this.txtTongChan.Location = new Point(125, 228);
            this.txtTongChan.Size = new Size(60, 24);
            this.txtTongChan.ReadOnly = true;

            this.txtTongLe.Location = new Point(260, 228);
            this.txtTongLe.Size = new Size(60, 24);
            this.txtTongLe.ReadOnly = true;

            // Nút nhập
            this.btnNhap.Location = new Point(240, 65);
            this.btnNhap.Size = new Size(80, 30);
            this.btnNhap.Text = "Nhập";
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click); // Gắn sự kiện click chuột

            // Nút tính tổng
            this.btnTinhTong.Location = new Point(140, 145);
            this.btnTinhTong.Size = new Size(180, 30);
            this.btnTinhTong.Text = "Tính Tổng";
            this.btnTinhTong.Click += new System.EventHandler(this.btnTinhTong_Click); 
            
            // Nút tiếp Tục
            this.btnTiepTuc.Location = new Point(100, 280);
            this.btnTiepTuc.Size = new Size(80, 30);
            this.btnTiepTuc.Text = "Tiếp Tục";
            this.btnTiepTuc.Click += new System.EventHandler(this.btnTiepTuc_Click);

            // Nút thoát 
            this.btnThoat.Location = new Point(210, 280);
            this.btnThoat.Size = new Size(80, 30);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            this.ClientSize = new Size(380, 340); // Thiết lập kích thước của Form

            // Add các đối tượng control
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblNhapSo);
            this.Controls.Add(this.lblDayVuaNhap);
            this.Controls.Add(this.lblTongDay);
            this.Controls.Add(this.lblTongChan);
            this.Controls.Add(this.lblTongLe);
            this.Controls.Add(this.txtNhapSo);
            this.Controls.Add(this.txtDayVuaNhap);
            this.Controls.Add(this.txtTongDay);
            this.Controls.Add(this.txtTongChan);
            this.Controls.Add(this.txtTongLe);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.btnTinhTong);
            this.Controls.Add(this.btnTiepTuc);
            this.Controls.Add(this.btnThoat);
            
            // Thiết lập các thuộc tính chung của Form
            this.Name = "FormBai4";
            this.Text = "Dãy số và Tính Tổng"; 
            this.StartPosition = FormStartPosition.CenterScreen; 
            // Gắn sự kiện khi Form đang đóng 
            this.FormClosing += new FormClosingEventHandler(this.FormBai4_FormClosing);
            
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}