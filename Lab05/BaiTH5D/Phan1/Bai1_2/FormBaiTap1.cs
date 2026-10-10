using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BaiTH5D
{
    public partial class FormBaiTap1 : Form
    {
        public FormBaiTap1()
        {
            InitializeComponent();
        }

        // 1. Form Load: Thêm dữ liệu vào ComboBox Dân tộc[cite: 50]
        private void FormBaiTap1_Load(object sender, EventArgs e)
        {
            string[] danhSachDanToc = { "Kinh", "Hoa", "K'Me", "H'Mong", "Khác" };
            cboDanToc.Items.AddRange(danhSachDanToc);
            cboDanToc.SelectedIndex = 0; // Chọn mặc định dòng đầu tiên
        }

        // Hàm hỗ trợ: Lấy chuỗi ngoại ngữ từ các CheckBox
        private string LayChuoiNgoaiNgu()
        {
            List<string> nn = new List<string>();
            if (chkAnh.Checked) nn.Add("Anh");
            if (chkPhap.Checked) nn.Add("Pháp");
            if (chkHoa.Checked) nn.Add("Hoa");
            
            return string.Join(", ", nn); // Nối mảng bằng dấu phẩy
        }

        // 2. Thêm dữ liệu vào ListView[cite: 50]
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ Tên và Mã Sinh Viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng mã sinh viên[cite: 50]
            foreach (ListViewItem itm in lstvSinhVien.Items)
            {
                // Cột 1 (SubItems[1]) là Mã sinh viên
                if (itm.SubItems[1].Text == txtMaSV.Text)
                {
                    MessageBox.Show("Mã sinh viên này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Tạo một Item mới cho ListView
            ListViewItem item = new ListViewItem(txtHoTen.Text); // Cột 0: Họ tên
            item.SubItems.Add(txtMaSV.Text);                     // Cột 1: Mã SV
            item.SubItems.Add(rdoNam.Checked ? "Nam" : "Nữ");    // Cột 2: Giới tính
            item.SubItems.Add(LayChuoiNgoaiNgu());               // Cột 3: Ngoại ngữ
            item.SubItems.Add(cboDanToc.Text);                   // Cột 4: Dân tộc

            // Thêm vào ListView
            lstvSinhVien.Items.Add(item);
            ResetForm();
        }

        // 3. Khi click chọn 1 dòng trên ListView, đẩy dữ liệu ngược lên TextBox để xem/sửa
        private void lstvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvSinhVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lstvSinhVien.SelectedItems[0];
                
                txtHoTen.Text = item.SubItems[0].Text;
                txtMaSV.Text = item.SubItems[1].Text;
                
                // Khóa TextBox Mã Sinh Viên không cho sửa[cite: 50]
                txtMaSV.Enabled = false; 

                // Load Giới tính
                if (item.SubItems[2].Text == "Nam") rdoNam.Checked = true;
                else rdoNu.Checked = true;

                // Load Ngoại ngữ
                string ngoaiNgu = item.SubItems[3].Text;
                chkAnh.Checked = ngoaiNgu.Contains("Anh");
                chkPhap.Checked = ngoaiNgu.Contains("Pháp");
                chkHoa.Checked = ngoaiNgu.Contains("Hoa");

                // Load Dân tộc
                cboDanToc.Text = item.SubItems[4].Text;
            }
        }

        // 4. Sửa dữ liệu[cite: 50]
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lstvSinhVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lstvSinhVien.SelectedItems[0];
                
                // Cập nhật lại các SubItem (Không cập nhật SubItem[1] là Mã SV vì không cho sửa)
                item.SubItems[0].Text = txtHoTen.Text;
                item.SubItems[2].Text = rdoNam.Checked ? "Nam" : "Nữ";
                item.SubItems[3].Text = LayChuoiNgoaiNgu();
                item.SubItems[4].Text = cboDanToc.Text;

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên trong danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 5. Xóa dữ liệu (Dùng chung cho Nút bấm và Menu chuột phải)[cite: 50]
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstvSinhVien.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Xóa tất cả các dòng đang được chọn
                    foreach (ListViewItem item in lstvSinhVien.SelectedItems)
                    {
                        lstvSinhVien.Items.Remove(item);
                    }
                    ResetForm();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Hàm hỗ trợ: Làm sạch form sau khi Thêm/Sửa/Xóa
        private void ResetForm()
        {
            txtHoTen.Clear();
            txtMaSV.Clear();
            txtMaSV.Enabled = true; // Mở khóa lại ô Mã SV
            rdoNam.Checked = true;
            chkAnh.Checked = chkPhap.Checked = chkHoa.Checked = false;
            cboDanToc.SelectedIndex = 0;
            txtHoTen.Focus();
        }

        // 6. Hỏi xác nhận khi đóng form[cite: 50]
        private void FormBaiTap1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đóng chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true; // Hủy lệnh đóng
            }
        }
    }
}