using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5D
{
    public partial class FormDongHo : Form
    {
        private int tongSoGiay = 0; 

        public FormDongHo()
        {
            InitializeComponent();
        }

        // Nút Bắt đầu / Dừng / Tiếp tục
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (timerDemNguoc.Enabled)
            {
                // Đang chạy -> Bấm thì Dừng (Pause)
                timerDemNguoc.Stop();
                btnBatDau.Text = "Tiếp tục";
                btnBatDau.BackColor = Color.LightGoldenrodYellow;
            }
            else
            {
                // Nếu là lần bấm Bắt đầu tiên (không phải bấm Tiếp tục)
                if (btnBatDau.Text == "Bắt đầu")
                {
                    // Đọc số i từ TextBox
                    if (!int.TryParse(txtNhapPhut.Text, out int i) || i <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập một số phút hợp lệ (> 0)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNhapPhut.SelectAll();
                        txtNhapPhut.Focus();
                        return;
                    }
                    
                    tongSoGiay = i * 60; // Quy đổi số phút i ra giây
                    HienThiThoiGian();   // Cập nhật lên màn hình ngay lập tức
                }

                // Cho Timer chạy
                timerDemNguoc.Start();
                btnBatDau.Text = "Dừng";
                btnBatDau.BackColor = Color.LightPink;
                txtNhapPhut.Enabled = false; // Khóa ô nhập lại không cho sửa lúc đang chạy
            }
        }

        // Mỗi giây trôi qua, Timer sẽ nhảy vào hàm này 1 lần
        private void timerDemNguoc_Tick(object sender, EventArgs e)
        {
            if (tongSoGiay > 0)
            {
                tongSoGiay--;
                HienThiThoiGian();
            }
            else
            {
                // Hết giờ
                timerDemNguoc.Stop();
                MessageBox.Show("Đã hết thời gian đếm ngược!", "Bing boong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetDongHo();
            }
        }

        // Nút Làm mới (Dừng ngang và thiết lập lại)
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetDongHo();
        }

        // Hàm hỗ trợ hiển thị
        private void HienThiThoiGian()
        {
            int phut = tongSoGiay / 60;
            int giay = tongSoGiay % 60;
            lblThoiGian.Text = $"{phut:D2}:{giay:D2}";
        }

        // Hàm hỗ trợ đưa form về trạng thái gốc
        private void ResetDongHo()
        {
            timerDemNguoc.Stop();
            btnBatDau.Text = "Bắt đầu";
            btnBatDau.BackColor = Color.LightCyan;
            txtNhapPhut.Enabled = true; // Mở khóa ô nhập
            lblThoiGian.Text = "00:00";
            tongSoGiay = 0;
            txtNhapPhut.Focus();
        }
    }
}