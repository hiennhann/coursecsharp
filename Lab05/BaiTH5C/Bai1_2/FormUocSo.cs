using System;
using System.Windows.Forms;

namespace BaiTH5C
{
    public partial class FormUocSo : Form
    {
        public FormUocSo()
        {
            InitializeComponent();
        }

        // 1. Thêm số vào ComboBox
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNhapSo.Text, out int soMoi) && soMoi > 0)
            {
                // Kiểm tra xem số đã tồn tại trong ComboBox chưa
                if (!cboSo.Items.Contains(soMoi))
                {
                    cboSo.Items.Add(soMoi);
                    cboSo.SelectedItem = soMoi; // Tự động chọn số vừa nhập
                }
                else
                {
                    MessageBox.Show("Số này đã tồn tại trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                txtNhapSo.Clear();
                txtNhapSo.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số nguyên dương hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapSo.SelectAll();
                txtNhapSo.Focus();
            }
        }

        // 2. Khi chọn một số trong ComboBox -> Tìm và xuất ước số ra ListBox
        private void cboSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUocSo.Items.Clear(); // Xóa danh sách cũ

            if (cboSo.SelectedItem != null)
            {
                int soChon = (int)cboSo.SelectedItem;
                // Tìm tất cả các ước số
                for (int i = 1; i <= soChon; i++)
                {
                    if (soChon % i == 0)
                    {
                        lstUocSo.Items.Add(i);
                    }
                }
            }
        }

        // 3. Nút Tính Tổng các ước số
        private void btnTong_Click(object sender, EventArgs e)
        {
            int tong = 0;
            foreach (var item in lstUocSo.Items)
            {
                tong += (int)item;
            }
            MessageBox.Show($"Tổng các ước số là: {tong}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 4. Nút Đếm số chẵn
        private void btnSoChan_Click(object sender, EventArgs e)
        {
            int demChan = 0;
            foreach (var item in lstUocSo.Items)
            {
                if ((int)item % 2 == 0) demChan++;
            }
            MessageBox.Show($"Số lượng ước số chẵn là: {demChan}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 5. Thuật toán kiểm tra Số Nguyên Tố
        private bool IsNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        // Nút Đếm số nguyên tố
        private void btnSoNguyenTo_Click(object sender, EventArgs e)
        {
            int demSNT = 0;
            foreach (var item in lstUocSo.Items)
            {
                if (IsNguyenTo((int)item)) demSNT++;
            }
            MessageBox.Show($"Số lượng ước số nguyên tố là: {demSNT}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Thoát form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUocSo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}