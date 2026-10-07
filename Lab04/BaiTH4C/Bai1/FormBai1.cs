using System;
using System.Windows.Forms;

namespace Lab04 // Phải trùng namespace với file Designer
{
    public partial class FormBai1 : Form
    {
        public FormBai1()
        {
            // Lệnh này gọi sang file Designer để vẽ giao diện trước khi Form chạy
            InitializeComponent();
        }

        // ======================= LOGIC XỬ LÝ YÊU CẦU =======================

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Mức 2: Chặn ký tự chữ
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true; 
            }

            TextBox txt = sender as TextBox;
            if (e.KeyChar == '-' && txt.Text.IndexOf('-') > -1)
            {
                e.Handled = true;
            }
        }

        private bool KiemTraDuLieu()
        {
            // Mức 1: Bắt lỗi rỗng
            errorProvider1.Clear();
            bool hopLe = true;

            if (string.IsNullOrWhiteSpace(txtA.Text) || txtA.Text == "-")
            {
                errorProvider1.SetError(txtA, "Dữ liệu nhập vào textbox a không hợp lệ.");
                hopLe = false;
            }

            if (string.IsNullOrWhiteSpace(txtB.Text) || txtB.Text == "-")
            {
                errorProvider1.SetError(txtB, "Dữ liệu nhập vào textbox b không hợp lệ.");
                hopLe = false;
            }

            if (!hopLe)
            {
                MessageBox.Show("Dữ liệu nhập không phù hợp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return hopLe;
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                double a = Convert.ToDouble(txtA.Text);
                double b = Convert.ToDouble(txtB.Text);
                txtKetQua.Text = (a + b).ToString();
            }
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                double a = Convert.ToDouble(txtA.Text);
                double b = Convert.ToDouble(txtB.Text);
                txtKetQua.Text = (a - b).ToString();
            }
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                double a = Convert.ToDouble(txtA.Text);
                double b = Convert.ToDouble(txtB.Text);
                txtKetQua.Text = (a * b).ToString();
            }
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                double a = Convert.ToDouble(txtA.Text);
                double b = Convert.ToDouble(txtB.Text);

                if (b == 0)
                {
                    errorProvider1.SetError(txtB, "Không thể chia cho 0");
                    MessageBox.Show("Lỗi chia cho 0. Dữ liệu nhập không phù hợp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtKetQua.Text = (a / b).ToString();
                }
            }
        }

        private void FormBai1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hỏi xác nhận thoát
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; 
            }
        }
    }
}