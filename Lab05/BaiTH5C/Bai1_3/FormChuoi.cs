using System;
using System.Globalization;
using System.Windows.Forms;

namespace BaiTH5C
{
    public partial class FormChuoi : Form
    {
        // Các mảng dữ liệu theo đề bài yêu cầu
        string[] HO = { "Lê", "Nguyễn", "Lý", "Trần", "Lâm", "Hồ", "Lai", "Huỳnh", "La" };
        string[] TENLOT = { "Quang", "Thành", "Ngọc", "Anh", "Xuân", "Bảo", "Cẩm", "Thị", "Kim", "Thái", "Hồng" };
        string[] TEN = { "Hà", "Danh", "Sơn", "Mai", "Thắng", "Kỳ", "Thành", "Lâm", "Tâm", "Phụng", "Thắm" };
        
        Random rnd = new Random();

        public FormChuoi()
        {
            InitializeComponent();
        }

        // Tạo 50 tên ngẫu nhiên
        private void btnNgauNhien_Click(object sender, EventArgs e)
        {
            lstDanhSach.Items.Clear(); // Xóa cũ trước khi tạo mới
            for (int i = 0; i < 50; i++)
            {
                string ho = HO[rnd.Next(HO.Length)];
                string lot = TENLOT[rnd.Next(TENLOT.Length)];
                string ten = TEN[rnd.Next(TEN.Length)];
                
                string hoTenFull = $"{ho} {lot} {ten}";
                lstDanhSach.Items.Add(hoTenFull);
            }
        }

        // Xóa phần tử đang chọn (hỗ trợ xóa nhiều phần tử cùng lúc)
        private void btnXoaChon_Click(object sender, EventArgs e)
        {
            // Phải duyệt ngược từ dưới lên trên để không bị lỗi tụt Index khi xóa
            for (int i = lstDanhSach.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstDanhSach.Items.RemoveAt(lstDanhSach.SelectedIndices[i]);
            }
        }

        // Xóa phần tử có tên là Sơn
        private void btnXoaTenSon_Click(object sender, EventArgs e)
        {
            for (int i = lstDanhSach.Items.Count - 1; i >= 0; i--)
            {
                string item = lstDanhSach.Items[i].ToString();
                if (item.EndsWith(" Sơn") || item == "Sơn") 
                {
                    lstDanhSach.Items.RemoveAt(i);
                }
            }
        }

        // Xóa Phần tử có họ là Lê
        private void btnXoaHoLe_Click(object sender, EventArgs e)
        {
            for (int i = lstDanhSach.Items.Count - 1; i >= 0; i--)
            {
                string item = lstDanhSach.Items[i].ToString();
                if (item.StartsWith("Lê "))
                {
                    lstDanhSach.Items.RemoveAt(i);
                }
            }
        }

        // Chuyển PT đang chọn thành chữ HOA
        private void btnHoa_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstDanhSach.SelectedIndices.Count; i++)
            {
                int idx = lstDanhSach.SelectedIndices[i];
                lstDanhSach.Items[idx] = lstDanhSach.Items[idx].ToString().ToUpper();
            }
        }

        // Chuyển PT đang chọn thành chữ thường
        private void btnThuong_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstDanhSach.SelectedIndices.Count; i++)
            {
                int idx = lstDanhSach.SelectedIndices[i];
                lstDanhSach.Items[idx] = lstDanhSach.Items[idx].ToString().ToLower();
            }
        }

        // Chuyển PT đang chọn thành viết Hoa đầu mỗi từ
        private void btnHoaDauTu_Click(object sender, EventArgs e)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            for (int i = 0; i < lstDanhSach.SelectedIndices.Count; i++)
            {
                int idx = lstDanhSach.SelectedIndices[i];
                string chuoiHienTai = lstDanhSach.Items[idx].ToString();
                
                // Thuật toán: Ép về chữ thường hết -> Chuyển thành Hoa đầu từ
                lstDanhSach.Items[idx] = textInfo.ToTitleCase(chuoiHienTai.ToLower());
            }
        }

        // Xóa tất cả các Phần tử
        private void btnXoaTatCa_Click(object sender, EventArgs e)
        {
            lstDanhSach.Items.Clear();
        }

        // Double click vào tên để mở hộp thoại sửa tên
        private void lstDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (lstDanhSach.SelectedIndex != -1)
            {
                int idx = lstDanhSach.SelectedIndex;
                string tenCu = lstDanhSach.Items[idx].ToString();

                // Gọi hộp thoại mini (được định nghĩa bên dưới)
                string tenMoi = ShowInputBox("Sửa tên học viên:", "Cập nhật", tenCu);

                if (!string.IsNullOrWhiteSpace(tenMoi))
                {
                    lstDanhSach.Items[idx] = tenMoi; // Cập nhật tên mới vào ListBox
                }
            }
        }

        // Tạo thủ công một Hộp thoại (InputBox) ngay trong code để không cần tải thư viện VB.NET
        private string ShowInputBox(string text, string caption, string defaultValue)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 160,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340, Text = defaultValue };
            Button confirmation = new Button() { Text = "Lưu lại", Left = 260, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation; // Nhấn Enter tự động lưu

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}