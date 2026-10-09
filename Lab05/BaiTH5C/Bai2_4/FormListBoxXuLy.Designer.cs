using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5C
{
    partial class FormListBoxXuLy
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle, lblListbox, lblXuLy;
        private TextBox txtNhap;
        private Button btnNhap, btnKetThuc;
        private ListBox lstSo;
        
        private Button btnTong, btnXoaDauCuoi, btnXoaChon;
        private Button btnTang2, btnBinhPhuong, btnChonChan, btnChonLe;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblListbox = new Label();
            this.lblXuLy = new Label();
            this.txtNhap = new TextBox();
            this.btnNhap = new Button();
            this.lstSo = new ListBox();
            
            this.btnTong = new Button();
            this.btnXoaDauCuoi = new Button();
            this.btnXoaChon = new Button();
            this.btnTang2 = new Button();
            this.btnBinhPhuong = new Button();
            this.btnChonChan = new Button();
            this.btnChonLe = new Button();
            this.btnKetThuc = new Button();

            this.SuspendLayout();

            // Form
            this.ClientSize = new Size(540, 520);
            this.Text = "frmListbox";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Tiêu đề
            this.lblTitle.Text = "LISTBOX";
            this.lblTitle.Font = new Font("Arial", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Orange;
            this.lblTitle.Location = new Point(220, 20);
            this.lblTitle.AutoSize = true;

            // Cột bên trái
            this.lblListbox.Text = "Listbox"; this.lblListbox.Location = new Point(30, 70); this.lblListbox.AutoSize = true;
            
            this.txtNhap.Location = new Point(30, 95); this.txtNhap.Size = new Size(180, 22);
            this.txtNhap.KeyDown += new KeyEventHandler(this.txtNhap_KeyDown); // Hỗ trợ Enter

            this.btnNhap.Text = "Nhập"; this.btnNhap.Location = new Point(30, 130); this.btnNhap.Size = new Size(180, 35);
            this.btnNhap.BackColor = Color.LightSkyBlue;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);

            this.lstSo.Location = new Point(30, 180); this.lstSo.Size = new Size(180, 250);
            this.lstSo.SelectionMode = SelectionMode.MultiExtended; // Hỗ trợ chọn nhiều dòng

            // Cột bên phải (Các nút xử lý)
            this.lblXuLy.Text = "Xử lý Listbox"; this.lblXuLy.Location = new Point(260, 70); this.lblXuLy.AutoSize = true;

            int xRight = 260;
            int yPos = 95;
            int btnWidth = 250;
            int btnHeight = 35;
            int spacing = 45;

            this.btnTong.Text = "Tổng các phần tử trong List"; this.btnTong.Location = new Point(xRight, yPos); this.btnTong.Size = new Size(btnWidth, btnHeight); this.btnTong.Click += new System.EventHandler(this.btnTong_Click);
            this.btnXoaDauCuoi.Text = "Xóa Phần tử đầu và cuối"; this.btnXoaDauCuoi.Location = new Point(xRight, yPos += spacing); this.btnXoaDauCuoi.Size = new Size(btnWidth, btnHeight); this.btnXoaDauCuoi.Click += new System.EventHandler(this.btnXoaDauCuoi_Click);
            this.btnXoaChon.Text = "Xóa Phần tử đang chọn"; this.btnXoaChon.Location = new Point(xRight, yPos += spacing); this.btnXoaChon.Size = new Size(btnWidth, btnHeight); this.btnXoaChon.Click += new System.EventHandler(this.btnXoaChon_Click);
            this.btnTang2.Text = "Tăng mỗi phần tử lên 2"; this.btnTang2.Location = new Point(xRight, yPos += spacing); this.btnTang2.Size = new Size(btnWidth, btnHeight); this.btnTang2.Click += new System.EventHandler(this.btnTang2_Click);
            this.btnBinhPhuong.Text = "Thay bằng bình phương"; this.btnBinhPhuong.Location = new Point(xRight, yPos += spacing); this.btnBinhPhuong.Size = new Size(btnWidth, btnHeight); this.btnBinhPhuong.Click += new System.EventHandler(this.btnBinhPhuong_Click);
            this.btnChonChan.Text = "Chọn số chẵn"; this.btnChonChan.Location = new Point(xRight, yPos += spacing); this.btnChonChan.Size = new Size(btnWidth, btnHeight); this.btnChonChan.Click += new System.EventHandler(this.btnChonChan_Click);
            this.btnChonLe.Text = "Chọn số lẻ"; this.btnChonLe.Location = new Point(xRight, yPos += spacing); this.btnChonLe.Size = new Size(btnWidth, btnHeight); this.btnChonLe.Click += new System.EventHandler(this.btnChonLe_Click);

            // Nút Kết thúc
            this.btnKetThuc.Text = "KẾT THÚC"; this.btnKetThuc.Location = new Point(30, 445); this.btnKetThuc.Size = new Size(480, 40);
            this.btnKetThuc.BackColor = Color.LightGray;
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);

            // Thêm vào form
            this.Controls.Add(this.lblTitle); this.Controls.Add(this.lblListbox); this.Controls.Add(this.lblXuLy);
            this.Controls.Add(this.txtNhap); this.Controls.Add(this.btnNhap); this.Controls.Add(this.lstSo);
            this.Controls.Add(this.btnTong); this.Controls.Add(this.btnXoaDauCuoi); this.Controls.Add(this.btnXoaChon);
            this.Controls.Add(this.btnTang2); this.Controls.Add(this.btnBinhPhuong);
            this.Controls.Add(this.btnChonChan); this.Controls.Add(this.btnChonLe);
            this.Controls.Add(this.btnKetThuc);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}