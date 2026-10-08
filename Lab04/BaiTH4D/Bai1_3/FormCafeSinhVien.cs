using System;
using System.Windows.Forms;

namespace BaiTH4D
{
    public partial class FormCafeSinhVien : Form
    {
        // Biến lưu trữ tổng kết cuối ngày
        private int tongSoKhach = 0;
        private double tongDoanhThu = 0;

        // Biến tạm cho hóa đơn hiện tại
        private int soKhachHienTai = 0;
        private double tienHienTai = 0;

        public FormCafeSinhVien()
        {
            InitializeComponent();
        }

        // Khởi tạo trạng thái ban đầu khi load Form
        private void FormCafeSinhVien_Load(object sender, EventArgs e)
        {
            txtTenKH.Focus();
            btnTinhTien.Enabled = false;
            btnNhapLai.Enabled = false;
            btnThanhToan.Enabled = false;
        }

        // Bắt lỗi chỉ cho nhập số vào ô Số khách hàng
        private void txtSoKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Bật nút Tính Tiền khi đã điền đủ thông tin
        private void KiemTraNhapLieu(object sender, EventArgs e)
        {
            btnTinhTien.Enabled = !string.IsNullOrWhiteSpace(txtTenKH.Text) && !string.IsNullOrWhiteSpace(txtSoKH.Text);
        }

        // Nút Tính Tiền
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            double tongTienPhuC = 0;

            // Tính tiền đồ uống (RadioButtons)
            foreach (Control ctrl in grpNuocUong.Controls)
            {
                if (ctrl is RadioButton rdo && rdo.Checked)
                {
                    tongTienPhuC += Convert.ToDouble(rdo.Tag);
                    break; // RadioButton chỉ chọn 1
                }
            }

            // Tính tiền thức ăn (CheckBoxes - có thể chọn nhiều món)
            foreach (Control ctrl in grpThucAn.Controls)
            {
                if (ctrl is CheckBox chk && chk.Checked)
                {
                    tongTienPhuC += Convert.ToDouble(chk.Tag);
                }
            }

            // Tính giảm giá sinh viên
            if (chkSinhVien.Checked)
            {
                tongTienPhuC = tongTienPhuC * 0.8; // Giảm 20%
            }

            // Lưu hóa đơn tạm thời
            tienHienTai = tongTienPhuC;
            soKhachHienTai = int.Parse(txtSoKH.Text);

            // Hiển thị thông báo
            MessageBox.Show($"Khách hàng: {txtTenKH.Text}\nSố tiền cần thanh toán: {tienHienTai:N0} VNĐ", "Hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Bật các nút chức năng tiếp theo
            btnNhapLai.Enabled = true;
            btnThanhToan.Enabled = true;
        }

        // Nút Nhập Lại
        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            // Xóa TextBox
            txtTenKH.Clear();
            txtSoKH.Clear();
            chkSinhVien.Checked = false;

            // Bỏ chọn đồ uống
            foreach (Control ctrl in grpNuocUong.Controls)
                if (ctrl is RadioButton rdo) rdo.Checked = false;

            // Bỏ chọn đồ ăn
            foreach (Control ctrl in grpThucAn.Controls)
                if (ctrl is CheckBox chk) chk.Checked = false;

            // Đặt lại trạng thái nút
            btnNhapLai.Enabled = false;
            btnThanhToan.Enabled = false;
            txtTenKH.Focus();
        }

        // Nút Thanh Toán (Chốt bill và cộng dồn)
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Cộng dồn vào tổng kết
            tongSoKhach += soKhachHienTai;
            tongDoanhThu += tienHienTai;

            // Cập nhật giao diện thống kê
            txtTongKhach.Text = tongSoKhach.ToString();
            txtTongTien.Text = $"{tongDoanhThu:N0} VNĐ";

            // Sẵn sàng nhập khách mới
            btnNhapLai_Click(sender, e);
            btnThanhToan.Enabled = false;
        }

        // Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Bắt sự kiện tắt Form
        private void FormCafeSinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn thoát khỏi chương trình hay không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}