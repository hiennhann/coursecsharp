using System;
using System.Windows.Forms;

namespace BaiTH4D
{
    // Class hỗ trợ giải phương trình
    public class PhuongTrinhBacHai
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public string GiaiPTBac1()
        {
            if (A == 0)
                return B == 0 ? "PT vô số nghiệm" : "PT vô nghiệm";
            return $"PT có nghiệm x = {-B / A:0.00}";
        }

        public string GiaiPTBac2()
        {
            if (A == 0) return GiaiPTBac1(); // Đưa về bậc 1 nếu a = 0

            double delta = B * B - 4 * A * C;
            if (delta < 0) return "PT vô nghiệm";
            if (delta == 0) return $"PT có nghiệm kép x1 = x2 = {-B / (2 * A):0.00}";
            
            double x1 = (-B + Math.Sqrt(delta)) / (2 * A);
            double x2 = (-B - Math.Sqrt(delta)) / (2 * A);
            return $"PT có 2 nghiệm x1 = {x1:0.00}, x2 = {x2:0.00}";
        }
    }

    public partial class FormGiaiPT : Form
    {
        public FormGiaiPT()
        {
            InitializeComponent();
        }

        // Ẩn/hiện TextBox C dựa vào RadioButton
        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBacNhat.Checked)
            {
                txtC.Enabled = false;
                txtC.Clear();
            }
            else
            {
                txtC.Enabled = true;
            }
            KiemTraNhapLieu(null, null); // Cập nhật lại trạng thái nút Giải
        }

        // Kiểm tra đã nhập đủ thông tin chưa để bật nút Giải
        private void KiemTraNhapLieu(object sender, EventArgs e)
        {
            bool hopLe = true;
            
            // Luôn cần A và B
            if (string.IsNullOrWhiteSpace(txtA.Text) || string.IsNullOrWhiteSpace(txtB.Text))
                hopLe = false;
            
            // Bậc 2 thì cần thêm C
            if (rdoBacHai.Checked && string.IsNullOrWhiteSpace(txtC.Text))
                hopLe = false;

            btnGiai.Enabled = hopLe; // Bật/tắt nút Giải
        }

        // Thực thi giải phương trình
        private void btnGiai_Click(object sender, EventArgs e)
        {
            try
            {
                PhuongTrinhBacHai pt = new PhuongTrinhBacHai();
                pt.A = double.Parse(txtA.Text);
                pt.B = double.Parse(txtB.Text);
                
                if (rdoBacNhat.Checked)
                {
                    txtKetQua.Text = pt.GiaiPTBac1();
                }
                else
                {
                    pt.C = double.Parse(txtC.Text);
                    txtKetQua.Text = pt.GiaiPTBac2();
                }
                
                btnGiai.Enabled = false; // Mờ nút Giải sau khi tính xong
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormGiaiPT_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}