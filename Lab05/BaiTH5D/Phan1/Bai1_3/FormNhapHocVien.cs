using System;
using System.Windows.Forms;

namespace BaiTH5D
{
    public partial class FormNhapHocVien : Form
    {
        // Khai báo một biến để "giữ" liên kết với Form chính
        private FormQuanLyHocVien frmChinh;

        // Cập nhật hàm tạo để nhận Form chính truyền vào
        public FormNhapHocVien(FormQuanLyHocVien formTruyenVao)
        {
            InitializeComponent();
            frmChinh = formTruyenVao;
        }

        // Xử lý nút Cập nhật[cite: 54]
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            // Đẩy dữ liệu vào thẳng ListBox của Form chính[cite: 54]
            if (cboLop.Text == "Lớp A")
            {
                frmChinh.lstLopA.Items.Add(txtHoTen.Text);
            }
            else
            {
                frmChinh.lstLopB.Items.Add(txtHoTen.Text);
            }

            // Làm sạch ô nhập
            txtHoTen.Clear();
            txtHoTen.Focus();
        }

        // Nút Trở về[cite: 54]
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}