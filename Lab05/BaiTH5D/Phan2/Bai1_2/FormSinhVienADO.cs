using System;
using System.Data;
using MySql.Data.MySqlClient; 
using System.Windows.Forms;

namespace BaiTH5D
{
    public partial class FormSinhVienADO : Form
    {
        private MySqlConnection connsql;
        // Đổi mật khẩu nếu cần
        private string strKetNoi = "Server=127.0.0.1;Database=QLSinhVien;Uid=root;Pwd=123456;";

        public FormSinhVienADO()
        {
            InitializeComponent();
            connsql = new MySqlConnection(strKetNoi);
        }

        // Tự động kéo danh sách Mã Lớp từ CSDL lên ComboBox
        private void FormSinhVienADO_Load(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed) connsql.Open();
                
                string query = "SELECT MaLop FROM Lop";
                MySqlCommand cmd = new MySqlCommand(query, connsql);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                cboMaLop.Items.Clear();
                while (reader.Read())
                {
                    cboMaLop.Items.Add(reader["MaLop"].ToString());
                }
                reader.Close();
                
                if (connsql.State == ConnectionState.Open) connsql.Close();

                if (cboMaLop.Items.Count > 0) cboMaLop.SelectedIndex = 0; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load Mã Lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chức năng Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboMaLop.Text) || string.IsNullOrWhiteSpace(txtMaSV.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connsql.State == ConnectionState.Closed) connsql.Open();

                string ngaySinhMySQL = dtpNgaySinh.Value.ToString("yyyy-MM-dd");

                string insertString = $"INSERT INTO SinhVien (MaSinhVien, HoTen, NgaySinh, MaLop) VALUES ('{txtMaSV.Text}', '{txtHoTen.Text}', '{ngaySinhMySQL}', '{cboMaLop.Text}')";
                MySqlCommand cmd = new MySqlCommand(insertString, connsql);
                cmd.ExecuteNonQuery();
                
                if (connsql.State == ConnectionState.Open) connsql.Close();

                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSV.Clear(); txtHoTen.Clear(); txtMaSV.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại (Trùng mã SV).\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chức năng Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Yêu cầu nhập Mã SV và Tên SV để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connsql.State == ConnectionState.Closed) connsql.Open();

                string deleteString = $"DELETE FROM SinhVien WHERE MaSinhVien='{txtMaSV.Text}' AND HoTen='{txtHoTen.Text}'";
                MySqlCommand cmd = new MySqlCommand(deleteString, connsql);
                int kq = cmd.ExecuteNonQuery();
                
                if (connsql.State == ConnectionState.Open) connsql.Close();

                if (kq > 0) MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Không tìm thấy sinh viên khớp với Mã và Tên đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chức năng Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Mã SV không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connsql.State == ConnectionState.Closed) connsql.Open();

                string ngaySinhMySQL = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
                
                string updateString = $"UPDATE SinhVien SET HoTen='{txtHoTen.Text}', NgaySinh='{ngaySinhMySQL}', MaLop='{cboMaLop.Text}' WHERE MaSinhVien='{txtMaSV.Text}'";
                MySqlCommand cmd = new MySqlCommand(updateString, connsql);
                int kq = cmd.ExecuteNonQuery();
                
                if (connsql.State == ConnectionState.Open) connsql.Close();

                if (kq > 0) MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Không tìm thấy Mã SV này để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}