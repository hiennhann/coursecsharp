using System;
using System.Windows.Forms;

namespace BaiTH5C
{
    public partial class FormSinhVien : Form
    {
        public FormSinhVien()
        {
            InitializeComponent();
        }

        // 1. Khởi tạo dữ liệu khi mở Form
        private void FormSinhVien_Load(object sender, EventArgs e)
        {
            // Tạo sẵn danh sách các lớp như đề bài yêu cầu
            string[] danhSachLop = { "05DHTH1", "05DHTH2", "05DHTH3", "05DHTH4" };

            // Thêm một nút gốc to nhất (Root) cho đẹp mắt
            TreeNode root = new TreeNode("Danh sách lớp");
            trvDanhSach.Nodes.Add(root);

            foreach (string lop in danhSachLop)
            {
                // Thêm vào ComboBox
                cboLop.Items.Add(lop);
                // Thêm vào TreeView với Tag="LOP" để phân biệt với sinh viên
                TreeNode nodeLop = new TreeNode(lop);
                nodeLop.Tag = "LOP";
                root.Nodes.Add(nodeLop);
            }

            if (cboLop.Items.Count > 0)
                cboLop.SelectedIndex = 0; // Chọn mặc định lớp đầu tiên
                
            trvDanhSach.ExpandAll(); // Mở rộng tất cả các nhánh
        }

        // 2. Ẩn/hiện khung Thêm lớp
        private void chkThemLop_CheckedChanged(object sender, EventArgs e)
        {
            grpThemLop.Visible = chkThemLop.Checked;
            if (chkThemLop.Checked) txtTenLop.Focus();
        }

        // 3. Xử lý Thêm Lớp mới
        private void btnThemLop_Click(object sender, EventArgs e)
        {
            string tenLopMoi = txtTenLop.Text.Trim();
            if (string.IsNullOrEmpty(tenLopMoi))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra lớp đã tồn tại chưa
            if (cboLop.Items.Contains(tenLopMoi))
            {
                MessageBox.Show("Tên lớp này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thêm lớp vào ComboBox và TreeView
            cboLop.Items.Add(tenLopMoi);
            TreeNode nodeLop = new TreeNode(tenLopMoi);
            nodeLop.Tag = "LOP";
            trvDanhSach.Nodes[0].Nodes.Add(nodeLop); // Thêm vào trong nhánh "Danh sách lớp"

            MessageBox.Show("Thêm lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTenLop.Clear();
            trvDanhSach.ExpandAll();
        }

        // 4. Xử lý Cập nhật (Thêm sinh viên vào lớp)
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập đủ dữ liệu
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) || 
                string.IsNullOrWhiteSpace(txtHoTen.Text) || 
                string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sinh viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string lopChon = cboLop.SelectedItem?.ToString();
            if (lopChon == null) return;

            // Kiểm tra trùng Mã sinh viên trong toàn bộ cây
            foreach (TreeNode lop in trvDanhSach.Nodes[0].Nodes)
            {
                foreach (TreeNode sv in lop.Nodes)
                {
                    // Tên node sinh viên có dạng: "MãSV, Họ tên"
                    if (sv.Text.StartsWith(txtMaSV.Text + ","))
                    {
                        MessageBox.Show("Mã sinh viên này đã tồn tại trong danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // Tìm nhánh Lớp tương ứng trong TreeView
            TreeNode nodeLopHienTai = null;
            foreach (TreeNode lop in trvDanhSach.Nodes[0].Nodes)
            {
                if (lop.Text == lopChon)
                {
                    nodeLopHienTai = lop;
                    break;
                }
            }

            // Thêm Node sinh viên
            if (nodeLopHienTai != null)
            {
                // Node con cấp 1 (Tên hiển thị: MSV, Họ tên)
                TreeNode nodeSV = new TreeNode($"{txtMaSV.Text}, {txtHoTen.Text}");
                nodeSV.Tag = "SV"; // Đánh dấu đây là node sinh viên

                // Node con cấp 2 (Hiển thị địa chỉ)
                TreeNode nodeDiaChi = new TreeNode(txtDiaChi.Text);
                nodeSV.Nodes.Add(nodeDiaChi);

                nodeLopHienTai.Nodes.Add(nodeSV);
                nodeLopHienTai.ExpandAll(); // Mở nhánh vừa thêm
                
                // Xóa form sau khi thêm
                txtMaSV.Clear(); txtHoTen.Clear(); txtDiaChi.Clear();
                txtMaSV.Focus();
            }
        }

        // 5. Bấm vào sinh viên trên cây thì tự động lấy thông tin lên TextBox
        private void trvDanhSach_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode nodeChon = e.Node;

            // Nếu click trúng node sinh viên (có Tag là "SV")
            if (nodeChon != null && nodeChon.Tag != null && nodeChon.Tag.ToString() == "SV")
            {
                // Cắt chuỗi "MãSV, Họ tên" bằng dấu phẩy
                string[] parts = nodeChon.Text.Split(new string[] { ", " }, StringSplitOptions.None);
                
                txtMaSV.Text = parts[0];
                txtHoTen.Text = parts[1];
                txtDiaChi.Text = nodeChon.Nodes[0].Text; // Địa chỉ là node con của nó
                cboLop.Text = nodeChon.Parent.Text; // Lấy tên lớp từ node cha
            }
        }

        // 6. Xóa sinh viên
        private void btnXoa_Click(object sender, EventArgs e)
        {
            TreeNode nodeChon = trvDanhSach.SelectedNode;

            // Kiểm tra xem người dùng có đang chọn đúng Sinh viên để xóa không
            if (nodeChon == null || nodeChon.Tag == null || nodeChon.Tag.ToString() != "SV")
            {
                MessageBox.Show("Vui lòng chọn một Sinh Viên trên danh sách (cây bên trái) để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên {nodeChon.Text}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                trvDanhSach.Nodes.Remove(nodeChon);
                // Xóa trắng ô nhập liệu sau khi xóa thành công
                txtMaSV.Clear(); txtHoTen.Clear(); txtDiaChi.Clear();
            }
        }
    }
}