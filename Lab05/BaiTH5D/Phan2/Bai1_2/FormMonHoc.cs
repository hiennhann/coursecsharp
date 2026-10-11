using System;
using System.Data;
using MySql.Data.MySqlClient; // Đã đổi sang thư viện MySQL
using System.Windows.Forms;

namespace BaiTH5D
{
    public partial class FormMonHoc : Form
    {
        private MySqlConnection connsql;
        private string strKetNoi = "Server=127.0.0.1;Database=QLSinhVien;Uid=root;Pwd=123456;";

        public FormMonHoc()
        {
            InitializeComponent();
            connsql = new MySqlConnection(strKetNoi);
        }

        // 1. Chức năng Thêm dữ liệu[cite: 24]
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Bắt lỗi: Mã môn học, Tên môn học không được để trống[cite: 24]
            if (string.IsNullOrWhiteSpace(txtMaMH.Text) || string.IsNullOrWhiteSpace(txtTenMH.Text))
            {
                MessageBox.Show("Mã môn học và Tên môn học không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connsql.State == ConnectionState.Closed) connsql.Open();

                string insertString = $"INSERT INTO MonHoc (MaMonHoc, TenMonHoc) VALUES ('{txtMaMH.Text}', '{txtTenMH.Text}')";
                MySqlCommand cmd = new MySqlCommand(insertString, connsql);
                cmd.ExecuteNonQuery();

                if (connsql.State == ConnectionState.Open) connsql.Close();

                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaMH.Clear(); txtTenMH.Clear(); txtMaMH.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại. Có thể do trùng Mã Môn Học.\nLỗi chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Chức năng Xóa dữ liệu[cite: 24]
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Bắt lỗi: Mã môn học không được để trống[cite: 24]
            if (string.IsNullOrWhiteSpace(txtMaMH.Text))
            {
                MessageBox.Show("Mã môn học không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (connsql.State == ConnectionState.Closed) connsql.Open();

                    string deleteString = $"DELETE FROM MonHoc WHERE MaMonHoc='{txtMaMH.Text}'";
                    MySqlCommand cmd = new MySqlCommand(deleteString, connsql);
                    
                    int kq = cmd.ExecuteNonQuery(); 
                    if (connsql.State == ConnectionState.Open) connsql.Close();

                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaMH.Clear(); txtTenMH.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Mã Môn Học này để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại (Môn học này có thể đang có sinh viên tham gia học).\nLỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 3. Chức năng Sửa dữ liệu[cite: 24]
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Bắt lỗi: Mã môn học, Tên môn học không được để trống[cite: 24]
            if (string.IsNullOrWhiteSpace(txtMaMH.Text) || string.IsNullOrWhiteSpace(txtTenMH.Text))
            {
                MessageBox.Show("Mã môn học và Tên môn học không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connsql.State == ConnectionState.Closed) connsql.Open();

                string updateString = $"UPDATE MonHoc SET TenMonHoc='{txtTenMH.Text}' WHERE MaMonHoc='{txtMaMH.Text}'";
                MySqlCommand cmd = new MySqlCommand(updateString, connsql);
                
                int kq = cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open) connsql.Close();

                if (kq > 0)
                {
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Mã Môn Học này để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}