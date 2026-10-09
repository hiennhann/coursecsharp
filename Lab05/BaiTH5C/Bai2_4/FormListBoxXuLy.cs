using System;
using System.Windows.Forms;

namespace BaiTH5C
{
    public partial class FormListBoxXuLy : Form
    {
        public FormListBoxXuLy()
        {
            InitializeComponent();
        }

        // --- NHẬP LIỆU ---
        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNhap.Text, out int soDuaVao))
            {
                lstSo.Items.Add(soDuaVao);
                txtNhap.Clear();
                txtNhap.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số tự nhiên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhap.SelectAll();
                txtNhap.Focus();
            }
        }

        // Bắt phím Enter ở ô nhập
        private void txtNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnNhap_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        // --- XỬ LÝ NÚT BẤM ---

        // 1. Tính tổng các phần tử
        private void btnTong_Click(object sender, EventArgs e)
        {
            int tong = 0;
            foreach (var item in lstSo.Items)
            {
                tong += (int)item;
            }
            MessageBox.Show($"Tổng các phần tử trong ListBox là: {tong}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 2. Xóa phần tử đầu và cuối
        private void btnXoaDauCuoi_Click(object sender, EventArgs e)
        {
            if (lstSo.Items.Count > 1)
            {
                lstSo.Items.RemoveAt(lstSo.Items.Count - 1); // Xóa cuối trước để không bị lệch Index
                lstSo.Items.RemoveAt(0); // Sau đó xóa đầu
            }
            else if (lstSo.Items.Count == 1)
            {
                lstSo.Items.Clear(); // Nếu chỉ có 1 phần tử thì xóa sạch
            }
        }

        // 3. Xóa các phần tử đang được chọn
        private void btnXoaChon_Click(object sender, EventArgs e)
        {
            // Phải duyệt từ dưới lên trên khi xóa nhiều mục
            for (int i = lstSo.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstSo.Items.RemoveAt(lstSo.SelectedIndices[i]);
            }
        }

        // 4. Tăng mỗi phần tử lên 2
        private void btnTang2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                int giaTriCu = (int)lstSo.Items[i];
                lstSo.Items[i] = giaTriCu + 2;
            }
        }

        // 5. Thay bằng bình phương
        private void btnBinhPhuong_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                int giaTriCu = (int)lstSo.Items[i];
                lstSo.Items[i] = giaTriCu * giaTriCu;
            }
        }

        // 6. Tự động bôi đen (chọn) các số chẵn
        private void btnChonChan_Click(object sender, EventArgs e)
        {
            lstSo.ClearSelected(); // Xóa chọn cũ
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                if ((int)lstSo.Items[i] % 2 == 0)
                {
                    lstSo.SetSelected(i, true); // Đánh dấu màu xanh (Selected)
                }
            }
        }

        // 7. Tự động bôi đen (chọn) các số lẻ
        private void btnChonLe_Click(object sender, EventArgs e)
        {
            lstSo.ClearSelected(); 
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                if ((int)lstSo.Items[i] % 2 != 0)
                {
                    lstSo.SetSelected(i, true); 
                }
            }
        }

        // --- KẾT THÚC ---
        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}