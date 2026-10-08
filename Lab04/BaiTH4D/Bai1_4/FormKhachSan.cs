using System;
using System.Windows.Forms;

namespace BaiTH4D
{
    public partial class FormKhachSan : Form
    {
        // Biến lưu trữ tổng kết bộ nhớ ngầm
        private int tongSoLuotKhach = 0;
        private double tongDoanhThu = 0;

        public FormKhachSan()
        {
            InitializeComponent();
        }

        // Form_Load: Khởi tạo trạng thái ban đầu[cite: 21]
        private void FormKhachSan_Load(object sender, EventArgs e)
        {
            txtTen.Focus();
            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;
            btnTongKet.Enabled = false;
        }

        // Chỉ cho phép nhập số vào số ngày ở[cite: 21]
        private void txtSoNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Kiểm tra điền đủ thông tin để bật nút Thanh Toán[cite: 21]
        private void KiemTraNhapLieu(object sender, EventArgs e)
        {
            btnThanhToan.Enabled = !string.IsNullOrWhiteSpace(txtTen.Text) &&
                                   !string.IsNullOrWhiteSpace(txtDiaChi.Text) &&
                                   !string.IsNullOrWhiteSpace(txtSoNgay.Text);
        }

        // Xử lý khi nhấn nút Thanh Toán[cite: 21]
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSoNgay.Text, out int soNgay) && soNgay > 0)
            {
                double tienPhong = 0;

                // 1. Tính tiền phòng[cite: 21]
                if (rdoDon.Checked) tienPhong = 300000 * soNgay;
                else if (rdoDoi.Checked) tienPhong = 350000 * soNgay;
                else if (rdoBa.Checked) tienPhong = 400000 * soNgay;

                // 2. Tính tiền tiện nghi[cite: 21]
                if (chkTivi.Checked) tienPhong += 10000;
                if (chkInternet.Checked) tienPhong += 10000;
                if (chkMayNuocNong.Checked) tienPhong += 10000;

                // 3. Tính tiền dịch vụ[cite: 21]
                if (chkKaraoke.Checked) tienPhong += 50000; // Phí 1 lần
                if (chkAnSang.Checked) tienPhong += (15000 * soNgay); // Phí theo ngày

                // Xuất kết quả ra giao diện
                txtThanhTien.Text = $"{tienPhong:N0} VNĐ";

                // Cộng dồn vào bộ nhớ[cite: 21]
                tongSoLuotKhach++;
                tongDoanhThu += tienPhong;

                // Bật các nút chức năng tiếp theo[cite: 21]
                btnNhapMoi.Enabled = true;
                btnTongKet.Enabled = true;
            }
            else
            {
                MessageBox.Show("Số ngày ở phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Xử lý nút Nhập Mới[cite: 21]
        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            // Xóa TextBox
            txtTen.Clear();
            txtDiaChi.Clear();
            txtSoNgay.Clear();
            txtThanhTien.Clear();

            // Reset RadioButton và CheckBox
            rdoDon.Checked = true;
            chkTivi.Checked = false;
            chkInternet.Checked = false;
            chkMayNuocNong.Checked = false;
            chkKaraoke.Checked = false;
            chkAnSang.Checked = false;

            // Về trạng thái ban đầu[cite: 21]
            btnNhapMoi.Enabled = false;
            txtTen.Focus();
        }

        // Xử lý nút Tổng Kết[cite: 21]
        private void btnTongKet_Click(object sender, EventArgs e)
        {
            // Ghi ra màn hình[cite: 21]
            txtSoLuot.Text = tongSoLuotKhach.ToString();
            txtTongTien.Text = tongDoanhThu.ToString("N0");

            // Khởi tạo lại giá trị 0[cite: 21]
            tongSoLuotKhach = 0;
            tongDoanhThu = 0;

            btnTongKet.Enabled = false;
        }

        // Thoát ứng dụng[cite: 21]
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hỏi xác nhận trước khi đóng[cite: 21]
        private void FormKhachSan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn thoát khỏi chương trình hay không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}