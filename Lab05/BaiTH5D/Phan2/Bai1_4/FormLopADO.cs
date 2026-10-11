using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace BaiTH5D
{
    public partial class FormLopADO : Form
    {
        private MySqlConnection connsql;
        // Điền lại mật khẩu MySQL của bạn vào Pwd=
        private string strKetNoi = "Server=127.0.0.1;Database=QLSinhVien;Uid=root;Pwd=123456;";

        public FormLopADO()
        {
            InitializeComponent();
            connsql = new MySqlConnection(strKetNoi);
        }

        // Tự động load danh sách Mã Khoa vào ComboBox[cite: 17]
        private void FormLopADO_Load(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed) connsql.Open();
                
                string query = "SELECT MaKhoa FROM Khoa";
                MySqlCommand cmd = new MySqlCommand(query, connsql);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                cboMaKhoa.Items.Clear();
                while (reader.Read())
                {
                    cboMaKhoa.Items.Add(reader["MaKhoa"].ToString());
                }
                reader.Close();
                
                if (connsql.State == ConnectionState.Open) connsql.Close();

                if (cboMaKhoa.Items.Count > 0) cboMaKhoa.SelectedIndex = 0; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load Mã Khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chức năng Thêm Lớp[cite: 17]
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Bắt lỗi rỗng[cite: 17]
            if (string.IsNullOrWhiteSpace(cboMaKhoa.Text) || string.IsNullOrWhiteSpace(txtMaLop.Text) || string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã Khoa, Mã Lớp và Tên Lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connsql.State == ConnectionState.Closed) connsql.Open();

                string insertString = $"INSERT INTO Lop (MaLop, TenLop, MaKhoa) VALUES ('{txtMaLop.Text}', '{txtTenLop.Text}', '{cboMaKhoa.Text}')";
                MySqlCommand cmd = new MySqlCommand(insertString, connsql);
                cmd.ExecuteNonQuery();
                
                if (connsql.State == ConnectionState.Open) connsql.Close();

                MessageBox.Show("Thêm lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLop.Clear(); txtTenLop.Clear(); txtMaLop.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại (Trùng mã lớp).\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chức năng Xóa Lớp[cite: 17]
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Yêu cầu nhập Mã lớp để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connsql.State == ConnectionState.Closed) connsql.Open();

                // Chỉ dựa vào Mã lớp để xóa[cite: 17]
                string deleteString = $"DELETE FROM Lop WHERE MaLop='{txtMaLop.Text}'";
                MySqlCommand cmd = new MySqlCommand(deleteString, connsql);
                int kq = cmd.ExecuteNonQuery();
                
                if (connsql.State == ConnectionState.Open) connsql.Close();

                if (kq > 0) 
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaLop.Clear(); txtTenLop.Clear();
                }
                else 
                {
                    MessageBox.Show("Không tìm thấy Mã lớp này để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa (Có thể lớp này đang chứa sinh viên nên không cho xóa).\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chức năng Sửa Lớp[cite: 17]
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Mã lớp không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connsql.State == ConnectionState.Closed) connsql.Open();

                // Cập nhật Tên lớp và Mã khoa mới dựa trên Mã lớp[cite: 17]
                string updateString = $"UPDATE Lop SET TenLop='{txtTenLop.Text}', MaKhoa='{cboMaKhoa.Text}' WHERE MaLop='{txtMaLop.Text}'";
                MySqlCommand cmd = new MySqlCommand(updateString, connsql);
                int kq = cmd.ExecuteNonQuery();
                
                if (connsql.State == ConnectionState.Open) connsql.Close();

                if (kq > 0) MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Không tìm thấy Mã lớp này để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}