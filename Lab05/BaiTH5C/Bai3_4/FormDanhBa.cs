using System;
using System.Windows.Forms;

namespace BaiTH5C
{
    public partial class FormDanhBa : Form
    {
        public FormDanhBa()
        {
            InitializeComponent();
        }

        // 1. Tự động sinh danh sách A-Z khi vừa mở Form
        private void FormDanhBa_Load(object sender, EventArgs e)
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                // Thêm Node với Key và Text đều là chữ cái (VD: "A", "B", "C")
                trvDanhBa.Nodes.Add(c.ToString(), c.ToString());
            }
        }

        // 2. Nút Thêm vào danh bạ
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            // Bắt lỗi nếu để trống First Name
            if (string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("First Name không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }

            // Lấy chữ cái đầu tiên của First Name và in hoa lên
            string chuCaiDau = firstName.Substring(0, 1).ToUpper();

            // Tìm node gốc có chứa chữ cái này
            TreeNode[] danhSachNodeTimDuoc = trvDanhBa.Nodes.Find(chuCaiDau, false);

            if (danhSachNodeTimDuoc.Length > 0)
            {
                // Lấy ra đúng cái Node chữ cái đó (ví dụ node 'B')
                TreeNode nodeChuCai = danhSachNodeTimDuoc[0];

                // Ghép chuỗi theo định dạng bài yêu cầu: "Bình, Ngô Thanh"
                string thongTinLuu = $"{firstName}, {lastName}";

                // Thêm người này làm con của Node chữ cái
                nodeChuCai.Nodes.Add(thongTinLuu);

                // Tự động xổ nhánh đó ra cho người dùng dễ nhìn
                nodeChuCai.Expand();
                
                // Xóa form nhập liệu
                txtFirstName.Clear();
                txtLastName.Clear();
                txtFirstName.Focus();
            }
            else
            {
                // Phòng trường hợp người dùng gõ ký tự đặc biệt (VD: @, 1, 2)
                MessageBox.Show("First Name phải bắt đầu bằng chữ cái từ A đến Z!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. Nút Thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}