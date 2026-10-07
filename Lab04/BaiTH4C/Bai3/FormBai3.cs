using System;
using System.Windows.Forms;

namespace BaiTH4C
{
    public partial class FormBai3 : Form
    {
        public FormBai3()
        {
            InitializeComponent();
        }

        // Chặn người dùng nhập chữ (Chỉ cho phép số và phím điều khiển như Backspace)
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        // Thuật toán tìm Ước Chung Lớn Nhất
        private int TimUCLN(int a, int b)
        {
            if (a == 0 || b == 0) return a + b;
            while (a != b)
            {
                if (a > b) a -= b;
                else b -= a;
            }
            return a;
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool hopLe = true;
            int a = 0, b = 0;

            // Kiểm tra TextBox a
            if (string.IsNullOrWhiteSpace(txtA.Text))
            {
                errorProvider1.SetError(txtA, "Vui lòng nhập số a!");
                hopLe = false;
            }
            else if (!int.TryParse(txtA.Text, out a) || a <= 0)
            {
                errorProvider1.SetError(txtA, "Số a phải là số nguyên dương lớn hơn 0!");
                hopLe = false;
            }

            // Kiểm tra TextBox b
            if (string.IsNullOrWhiteSpace(txtB.Text))
            {
                errorProvider1.SetError(txtB, "Vui lòng nhập số b!");
                hopLe = false;
            }
            else if (!int.TryParse(txtB.Text, out b) || b <= 0)
            {
                errorProvider1.SetError(txtB, "Số b phải là số nguyên dương lớn hơn 0!");
                hopLe = false;
            }

            // Nếu dữ liệu hợp lệ thì tiến hành tính toán
            if (hopLe)
            {
                int ucln = TimUCLN(a, b);
                int bcnn = (a * b) / ucln;

                txtUCLN.Text = ucln.ToString();
                txtBCNN.Text = bcnn.ToString();
            }
            else
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ, vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Tiếp Tục: Xóa trắng form để nhập lại
        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtUCLN.Clear();
            txtBCNN.Clear();
            errorProvider1.Clear();
            txtA.Focus(); // Đưa con trỏ chuột về ô a
        }

        // Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close(); // Sẽ gọi đến sự kiện FormClosing ở dưới
        }

        // Hỏi xác nhận trước khi đóng Form
        private void FormBai3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; 
            }
        }
    }
}