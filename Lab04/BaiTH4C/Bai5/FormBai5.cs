using System;
using System.Windows.Forms;

namespace BaiTH4C
{
    public partial class FormBai5 : Form
    {
        public FormBai5()
        {
            InitializeComponent();
        }

        // Chặn người dùng nhập chữ
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        // Hỗ trợ bấm phím Enter tại ô nhập
        private void txtNhapSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnThucHien_Click(sender, e); // Gọi hàm Thực Hiện
            }
        }

        // Thuật toán Đọc Số Tiếng Việt (1 đến 999)
        private string DocSo(int number)
        {
            string[] units = { "", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
            string result = "";
            
            int tram = number / 100;         // Lấy số hàng trăm
            int chuc = (number % 100) / 10;  // Lấy số hàng chục
            int donvi = number % 10;         // Lấy số hàng đơn vị

            // Xử lý hàng Trăm
            if (tram > 0)
            {
                result += units[tram] + " Trăm ";
                if (chuc == 0 && donvi > 0)
                {
                    result += "Lẻ "; // Ví dụ: 105 -> Một Trăm Lẻ Năm
                }
            }

            // Xử lý hàng Chục
            if (chuc > 0)
            {
                if (chuc == 1)
                    result += "Mười "; // Không đọc là "Một Mươi"
                else
                    result += units[chuc] + " Mươi ";
            }

            // Xử lý hàng Đơn vị
            if (donvi > 0)
            {
                if (donvi == 1 && chuc > 1)
                    result += "Mốt"; // > 10, tận cùng là 1 thì đọc là Mốt (Vd: Hai mươi mốt)
                else if (donvi == 4 && chuc > 1)
                    result += "Tư";  // > 10, tận cùng là 4 thì đọc là Tư (Vd: Hai mươi tư)
                else if (donvi == 5 && chuc > 0)
                    result += "Lăm"; // Có hàng chục, tận cùng là 5 thì đọc là Lăm (Vd: Mười lăm)
                else
                    result += units[donvi]; // Các trường hợp còn lại đọc bình thường
            }

            return result.Trim();
        }

        // Sự kiện click nút Thực Hiện
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (int.TryParse(txtNhapSo.Text, out int so))
            {
                if (so >= 1 && so <= 999)
                {
                    txtKetQua.Text = DocSo(so);
                }
                else
                {
                    errorProvider1.SetError(txtNhapSo, "Vui lòng nhập số trong khoảng từ 1 đến 999!");
                    txtKetQua.Clear();
                }
            }
            else
            {
                errorProvider1.SetError(txtNhapSo, "Vui lòng nhập một số hợp lệ!");
                txtKetQua.Clear();
            }
        }

        // Sự kiện click nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtNhapSo.Clear();
            txtKetQua.Clear();
            errorProvider1.Clear();
            txtNhapSo.Focus(); // Đưa con trỏ chuột quay lại ô nhập
        }

        // Sự kiện click nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Bắt sự kiện xác nhận đóng Form
        private void FormBai5_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; 
            }
        }
    }
}