using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaiTH4C
{
    public partial class FormRapPhim : Form
    {
        public FormRapPhim()
        {
            InitializeComponent();
            TaoDanhSachGhe(); // Gọi hàm tự động tạo ghế khi form load
        }

        // Hàm tự động tạo 15 ghế bằng vòng lặp
        private void TaoDanhSachGhe()
        {
            int buttonWidth = 50;
            int buttonHeight = 40;
            int margin = 10;
            int dem = 1;

            // 3 Hàng
            for (int row = 0; row < 3; row++)
            {
                // 5 Cột
                for (int col = 0; col < 5; col++)
                {
                    Button btnGhe = new Button();
                    btnGhe.Text = dem.ToString();
                    btnGhe.Width = buttonWidth;
                    btnGhe.Height = buttonHeight;
                    
                    // Tính toán tọa độ để xếp ghế cạnh nhau
                    btnGhe.Left = col * (buttonWidth + margin);
                    btnGhe.Top = row * (buttonHeight + margin);
                    
                    // Gắn màu mặc định là Trắng (Ghế chưa bán)
                    btnGhe.BackColor = Color.White;
                    btnGhe.Font = new Font("Arial", 10F, FontStyle.Bold);

                    // Phân loại lô và gắn Tag để lưu giá vé
                    if (row == 0) btnGhe.Tag = 1000;      // Lô A (ghế 1-5)
                    else if (row == 1) btnGhe.Tag = 1500; // Lô B (ghế 6-10)
                    else btnGhe.Tag = 2000;               // Lô C (ghế 11-15)

                    // Gắn chung 1 sự kiện Click cho tất cả 15 ghế
                    btnGhe.Click += new EventHandler(Ghe_Click);

                    // Thêm ghế vào Panel
                    panelGhe.Controls.Add(btnGhe);
                    dem++;
                }
            }
        }

        // Sự kiện khi người dùng click vào bất kỳ ghế nào
        private void Ghe_Click(object sender, EventArgs e)
        {
            Button btnChon = sender as Button;

            // Nếu ghế đã bán (Màu Vàng) -> Báo lỗi
            if (btnChon.BackColor == Color.Yellow)
            {
                MessageBox.Show("Ghế này đã được bán! Vui lòng chọn ghế khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu ghế đang chọn (Màu Xanh) -> Hủy chọn đổi về Trắng
            if (btnChon.BackColor == Color.Blue)
            {
                btnChon.BackColor = Color.White;
                btnChon.ForeColor = Color.Black; // Chữ đen
            }
            // Nếu ghế chưa chọn (Màu Trắng) -> Đổi sang Xanh (Đang chọn)
            else if (btnChon.BackColor == Color.White)
            {
                btnChon.BackColor = Color.Blue;
                btnChon.ForeColor = Color.White; // Chữ trắng cho dễ nhìn trên nền xanh
            }
        }

        // Sự kiện Nút CHỌN (Thanh toán)
        private void btnChon_Click(object sender, EventArgs e)
        {
            int tongTien = 0;
            bool coGheDuocChon = false;

            // Duyệt qua tất cả các ghế trong Panel
            foreach (Control ctrl in panelGhe.Controls)
            {
                if (ctrl is Button btnGhe)
                {
                    // Nếu ghế đang ở trạng thái Xanh (Đang chọn mua)
                    if (btnGhe.BackColor == Color.Blue)
                    {
                        coGheDuocChon = true;
                        btnGhe.BackColor = Color.Yellow; // Chốt vé (Đổi sang Vàng)
                        btnGhe.ForeColor = Color.Black;
                        
                        // Lấy giá vé đã lưu trong Tag ra để cộng dồn
                        tongTien += Convert.ToInt32(btnGhe.Tag);
                    }
                }
            }

            if (coGheDuocChon)
            {
                lblThanhTienGiaTri.Text = tongTien.ToString();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn ghế nào để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Sự kiện Nút HỦY BỎ
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panelGhe.Controls)
            {
                if (ctrl is Button btnGhe)
                {
                    // Trả tất cả ghế đang chọn (Xanh) về lại Trắng
                    if (btnGhe.BackColor == Color.Blue)
                    {
                        btnGhe.BackColor = Color.White;
                        btnGhe.ForeColor = Color.Black;
                    }
                }
            }
            lblThanhTienGiaTri.Text = "0"; // Reset tổng tiền
        }

        // Sự kiện Nút KẾT THÚC
        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng bán vé?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Đóng toàn bộ ứng dụng
            }
        }
    }
}