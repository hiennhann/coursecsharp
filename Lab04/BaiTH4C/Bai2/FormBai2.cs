using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BaiTH4C
{
    public partial class FormBai2 : Form
    {
        public FormBai2()
        {
            InitializeComponent();
        }

        //Kiểm tra định dạng email sau khi nhập và ra khỏi textbox
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email))
            {
                // Sử dụng Biểu thức chính quy (Regex) để kiểm tra định dạng email
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(email, pattern))
                {
                    errorProvider1.SetError(txtEmail, "Định dạng email không hợp lệ (Ví dụ: abc@gmail.com)");
                }
                else
                {
                    errorProvider1.SetError(txtEmail, ""); // Xóa lỗi nếu hợp lệ
                }
            }
        }

        // Kiểm tra toàn bộ dữ liệu trước khi đăng ký
        private bool KiemTraDuLieu()
        {
            errorProvider1.Clear();
            bool hopLe = true;

            //Bắt buộc nhập dữ liệu trên những textbox có (*)
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                errorProvider1.SetError(txtTenDangNhap, "Tên đăng nhập không được để trống!");
                hopLe = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email không được để trống!");
                hopLe = false;
            }
            else
            {
                // Kiểm tra lại regex đề phòng người dùng bấm đăng ký luôn chưa Leave
                if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    errorProvider1.SetError(txtEmail, "Định dạng email không hợp lệ!");
                    hopLe = false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                errorProvider1.SetError(txtMatKhau, "Mật khẩu không được để trống!");
                hopLe = false;
            }

            // Kiểm tra khớp mật khẩu
            if (txtMatKhau.Text != txtXacNhanMatKhau.Text)
            {
                errorProvider1.SetError(txtXacNhanMatKhau, "Mật khẩu xác nhận không khớp!");
                hopLe = false;
            }

            return hopLe;
        }

        // Xử lý sự kiện đăng ký
        private void XuLyDangKy()
        {
            if (KiemTraDuLieu())
            {
                string thongTin = $"Tên đăng nhập: {txtTenDangNhap.Text}\n" +
                                  $"Email: {txtEmail.Text}\n" +
                                  $"Mật khẩu: {txtMatKhau.Text}";
                
                MessageBox.Show(thongTin, "Thông tin đã đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Chọn button Đăng ký
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            XuLyDangKy();
        }

        //Nhấn phím Enter tại ô Xác nhận mật khẩu thì hiển thị thông tin
        private void txtXacNhanMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                XuLyDangKy();
            }
        }

        // Hỏi xác nhận trước khi đóng Form
        private void FormBai2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}