using System;
using System.Windows.Forms;

namespace BaiTH5D
{
    public partial class FormBaiTap2 : Form
    {
        public FormBaiTap2()
        {
            InitializeComponent();
        }

        // 1. Trạng thái khi Form mới load lên
        private void FormBaiTap2_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            txtTongTien.Text = "0";
            MoKhoaTextBox(false); // Khóa không cho nhập nếu chưa bấm Thêm
        }

        // Hàm hỗ trợ khóa/mở TextBox
        private void MoKhoaTextBox(bool trangThai)
        {
            txtSoTK.Enabled = txtTenKH.Enabled = txtDiaChi.Enabled = txtSoTien.Enabled = trangThai;
        }

        // Hàm hỗ trợ làm sạch form
        private void XoaTrangTextBox()
        {
            txtSoTK.Clear(); txtTenKH.Clear(); txtDiaChi.Clear(); txtSoTien.Clear();
        }

        // 2. Hàm TỰ ĐỘNG ĐÁNH SỐ THỨ TỰ VÀ TÍNH TỔNG TIỀN[cite: 51]
        private void CapNhatSTTVaTongTien()
        {
            decimal tongTien = 0;
            for (int i = 0; i < lstvTaiKhoan.Items.Count; i++)
            {
                // Cập nhật STT (SubItem[0])
                lstvTaiKhoan.Items[i].SubItems[0].Text = (i + 1).ToString();

                // Cộng dồn tiền (SubItem[4])
                // Xóa các dấu phẩy định dạng trước khi ép kiểu để tránh lỗi
                string chuoiTien = lstvTaiKhoan.Items[i].SubItems[4].Text.Replace(",", "");
                if (decimal.TryParse(chuoiTien, out decimal tien))
                {
                    tongTien += tien;
                }
            }
            // Định dạng tổng tiền kiểu có dấu phẩy (vd: 6,400,000)
            txtTongTien.Text = tongTien.ToString("N0");
        }

        // 3. Nút Thêm / Hủy[cite: 51]
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                // Đổi thành Hủy, mở khóa nhập liệu, bật nút Lưu[cite: 51]
                btnThem.Text = "Hủy";
                btnLuu.Enabled = true;
                MoKhoaTextBox(true);
                XoaTrangTextBox();
                txtSoTK.Focus();
            }
            else
            {
                // Hủy thao tác thêm
                btnThem.Text = "Thêm";
                btnLuu.Enabled = false;
                MoKhoaTextBox(false);
                XoaTrangTextBox();
            }
        }

        // 4. Nút Lưu (Đẩy dữ liệu xuống ListView)[cite: 51]
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoTK.Text) || string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSoTien.Text, out decimal soTienNhap))
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo dòng mới
            ListViewItem item = new ListViewItem(""); // Cột STT tạo rỗng, sẽ cập nhật sau
            item.SubItems.Add(txtSoTK.Text);
            item.SubItems.Add(txtTenKH.Text);
            item.SubItems.Add(txtDiaChi.Text);
            item.SubItems.Add(soTienNhap.ToString("N0")); // Cột Tiền định dạng có dấu phẩy

            lstvTaiKhoan.Items.Add(item);

            // Cập nhật hệ thống
            CapNhatSTTVaTongTien();

            // Trả Form về trạng thái ban đầu
            btnThem.Text = "Thêm";
            btnLuu.Enabled = false;
            MoKhoaTextBox(false);
            XoaTrangTextBox();
        }

        // 5. Click vào dòng trong ListView để hiển thị thông tin lên TextBox và bật nút Xóa[cite: 51]
        private void lstvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvTaiKhoan.SelectedItems.Count > 0)
            {
                btnXoa.Enabled = true; // Bật nút Xóa[cite: 51]
                ListViewItem item = lstvTaiKhoan.SelectedItems[0];

                txtSoTK.Text = item.SubItems[1].Text;
                txtTenKH.Text = item.SubItems[2].Text;
                txtDiaChi.Text = item.SubItems[3].Text;
                // Xóa dấu phẩy để hiển thị lại số thuần túy vào ô nhập
                txtSoTien.Text = item.SubItems[4].Text.Replace(",", "");
            }
            else
            {
                btnXoa.Enabled = false; // Tắt nút Xóa nếu không chọn gì
            }
        }

        // 6. Nút Xóa[cite: 51]
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstvTaiKhoan.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Xóa item đang chọn
                    lstvTaiKhoan.Items.Remove(lstvTaiKhoan.SelectedItems[0]);
                    
                    // Đánh số lại từ đầu và tính lại tổng tiền[cite: 51]
                    CapNhatSTTVaTongTien();

                    // Khóa nút Xóa lại và xóa trắng form
                    btnXoa.Enabled = false;
                    XoaTrangTextBox();
                }
            }
        }

        // 7. Thoát Form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}