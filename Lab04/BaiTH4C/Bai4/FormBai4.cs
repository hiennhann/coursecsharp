using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BaiTH4C
{
    public partial class FormBai4 : Form
    {
        // Khai báo một danh sách để lưu các số nguyên người dùng đã nhập
        private List<int> danhSachSo = new List<int>();

        public FormBai4()
        {
            InitializeComponent();
        }

        // Yêu cầu: Nhập vào một dãy số nguyên bất kỳ, xuất ra dãy vừa nhập
        private void btnNhap_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            
            // Kiểm tra xem dữ liệu nhập vào có phải số nguyên hay không
            if (int.TryParse(txtNhapSo.Text, out int soMoi))
            {
                danhSachSo.Add(soMoi); // Thêm vào danh sách
                txtDayVuaNhap.Text += soMoi.ToString() + " "; // Hiển thị ra textbox
                
                txtNhapSo.Clear(); // Xóa trắng ô nhập để sẵn sàng nhập số tiếp theo
                txtNhapSo.Focus();
            }
            else
            {
                errorProvider1.SetError(txtNhapSo, "Vui lòng nhập một số nguyên hợp lệ!");
                txtNhapSo.SelectAll();
                txtNhapSo.Focus();
            }
        }

        // Hỗ trợ người dùng nhấn phím Enter tại ô Nhập Số thay vì phải bấm nút "Nhập"
        private void txtNhapSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnNhap_Click(sender, e);
            }
        }

        // Bổ sung thêm button Tính tổng, tính tổng chẵn, lẻ
        private void btnTinhTong_Click(object sender, EventArgs e)
        {
            if (danhSachSo.Count == 0)
            {
                MessageBox.Show("Bạn chưa nhập số nào vào dãy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tong = 0;
            int tongChan = 0;
            int tongLe = 0;

            // Duyệt qua từng số trong danh sách đã lưu để cộng dồn
            foreach (int so in danhSachSo)
            {
                tong += so;
                if (so % 2 == 0)
                {
                    tongChan += so;
                }
                else
                {
                    tongLe += so;
                }
            }

            // Xuất kết quả
            txtTongDay.Text = tong.ToString();
            txtTongChan.Text = tongChan.ToString();
            txtTongLe.Text = tongLe.ToString();
        }

        // Button Tiếp tục trả lại trạng thái ban đầu của form
        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            danhSachSo.Clear(); // Xóa dữ liệu trong List
            txtDayVuaNhap.Clear();
            txtTongDay.Clear();
            txtTongChan.Clear();
            txtTongLe.Clear();
            txtNhapSo.Clear();
            errorProvider1.Clear();
            txtNhapSo.Focus();
        }

        // Button Thoát xác nhận và đóng form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close(); // Sẽ gọi đến sự kiện FormClosing
        }

        private void FormBai4_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}