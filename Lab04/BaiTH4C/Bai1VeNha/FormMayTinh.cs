using System;
using System.Windows.Forms;

namespace BaiTH4C
{
    public partial class FormMayTinh : Form
    {
        private double giaTriLuu = 0; // Biến lưu số đầu tiên
        private string phepToan = ""; // Biến lưu phép toán (+ - * /)
        private bool dangNhapSoMoi = false; // Cờ kiểm tra xem có phải đang bắt đầu nhập số thứ 2 không

        public FormMayTinh()
        {
            InitializeComponent();
        }

        // Xử lý khi bấm các nút số (0 đến 9)
        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Xóa số 0 ở đầu hoặc xóa màn hình nếu vừa bấm phép toán xong
            if (txtDisplay.Text == "0" || dangNhapSoMoi)
            {
                txtDisplay.Clear();
            }

            dangNhapSoMoi = false;
            txtDisplay.Text += btn.Text; // Ghép thêm số vào màn hình
        }

        // Xử lý khi bấm các nút phép toán (+, -, *, /)
        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Nếu trước đó đã có 1 phép toán đang dở, ta tính luôn trước khi làm phép toán mới
            if (giaTriLuu != 0 && !dangNhapSoMoi)
            {
                btnBang.PerformClick(); // Tự động click nút Bằng (=)
            }
            else
            {
                giaTriLuu = double.Parse(txtDisplay.Text); // Lưu lại số đầu tiên
            }

            phepToan = btn.Text; // Lưu lại phép toán (+, -, *, /)
            dangNhapSoMoi = true; // Sẵn sàng để nhập số tiếp theo
        }

        // Xử lý khi bấm nút bằng (=)
        private void btnBang_Click(object sender, EventArgs e)
        {
            double giaTriHienTai = double.Parse(txtDisplay.Text);

            switch (phepToan)
            {
                case "+":
                    txtDisplay.Text = (giaTriLuu + giaTriHienTai).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (giaTriLuu - giaTriHienTai).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (giaTriLuu * giaTriHienTai).ToString();
                    break;
                case "/":
                    if (giaTriHienTai == 0)
                    {
                        MessageBox.Show("Không thể chia cho 0!", "Lỗi Toán Học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnXoa_Click(sender, e); // Reset
                        return;
                    }
                    txtDisplay.Text = (giaTriLuu / giaTriHienTai).ToString();
                    break;
                default:
                    break;
            }

            // Lưu kết quả lại để tính tiếp nếu muốn
            giaTriLuu = double.Parse(txtDisplay.Text);
            phepToan = "";
            dangNhapSoMoi = true;
        }

        // Xử lý khi bấm nút C (Xóa / Clear)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            giaTriLuu = 0;
            phepToan = "";
            dangNhapSoMoi = false;
        }
    }
}