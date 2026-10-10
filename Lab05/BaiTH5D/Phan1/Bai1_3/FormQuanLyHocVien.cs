using System;
using System.Windows.Forms;

namespace BaiTH5D
{
    public partial class FormQuanLyHocVien : Form
    {
        public FormQuanLyHocVien()
        {
            InitializeComponent();
        }

        // Mở Form nhập liệu phụ[cite: 52]
        private void mnuNhapMoi_Click(object sender, EventArgs e)
        {
            // Truyền "this" (chính Form hiện tại) sang Form phụ để nó có thể đẩy dữ liệu về
            FormNhapHocVien frmNhap = new FormNhapHocVien(this);
            frmNhap.ShowDialog(); // Mở hộp thoại
        }

        // Chuyển từ A sang B[cite: 52]
        private void mnuChuyenB_Click(object sender, EventArgs e)
        {
            if (lstLopA.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên ở Lớp A trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Copy sang B
            foreach (var item in lstLopA.SelectedItems) lstLopB.Items.Add(item);
            
            // Xóa ở A (duyệt ngược)
            for (int i = lstLopA.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstLopA.Items.RemoveAt(lstLopA.SelectedIndices[i]);
            }
        }

        // Chuyển từ B sang A[cite: 52]
        private void mnuChuyenA_Click(object sender, EventArgs e)
        {
            if (lstLopB.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên ở Lớp B trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var item in lstLopB.SelectedItems) lstLopA.Items.Add(item);
            
            for (int i = lstLopB.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstLopB.Items.RemoveAt(lstLopB.SelectedIndices[i]);
            }
        }

        // Xóa học viên ở cả 2 lớp[cite: 52]
        private void mnuXoa_Click(object sender, EventArgs e)
        {
            for (int i = lstLopA.SelectedIndices.Count - 1; i >= 0; i--) lstLopA.Items.RemoveAt(lstLopA.SelectedIndices[i]);
            for (int i = lstLopB.SelectedIndices.Count - 1; i >= 0; i--) lstLopB.Items.RemoveAt(lstLopB.SelectedIndices[i]);
        }

        // Kết thúc chương trình[cite: 52]
        private void mnuKetThuc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn dừng chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}