using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace BaiTH5D
{
    public partial class FormDiemADO : Form
    {
        private MySqlConnection connsql;
        private string strKetNoi = "Server=127.0.0.1;Database=QLSinhVien;Uid=root;Pwd=123456;";

        public FormDiemADO()
        {
            InitializeComponent();
            connsql = new MySqlConnection(strKetNoi);
        }

        // Tự động load danh sách Mã SV và Mã Môn Học lên ComboBox khi mở form
        private void FormDiemADO_Load(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed) connsql.Open();

                // Load Mã Sinh Viên
                MySqlCommand cmdSV = new MySqlCommand("SELECT MaSinhVien FROM SinhVien", connsql);
                MySqlDataReader rdrSV = cmdSV.ExecuteReader();
                cboMaSV.Items.Clear();
                while (rdrSV.Read())
                {
                    cboMaSV.Items.Add(rdrSV["MaSinhVien"].ToString());
                }
                rdrSV.Close();
                if (cboMaSV.Items.Count > 0) cboMaSV.SelectedIndex = 0;

                // Load Mã Môn Học
                MySqlCommand cmdMH = new MySqlCommand("SELECT MaMonHoc FROM MonHoc", connsql);
                MySqlDataReader rdrMH = cmdMH.ExecuteReader();
                cboMaMH.Items.Clear();
                while (rdrMH.Read())
                {
                    cboMaMH.Items.Add(rdrMH["MaMonHoc"].ToString());
                }
                rdrMH.Close();
                if (cboMaMH.Items.Count > 0) cboMaMH.SelectedIndex = 0;

                if (connsql.State == ConnectionState.Open) connsql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu ban đầu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm điểm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiem.Text))
            {
                MessageBox.Show("Vui lòng nhập điểm số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(txtDiem.Text, out float diemSo) || diemSo < 0 || diemSo > 10)
            {
                MessageBox.Show("Điểm phải là một số thực từ 0 đến 10!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connsql.State == ConnectionState.Closed) connsql.Open();

                string insertString = $"INSERT INTO Diem (MaSinhVien, MaMonHoc, Diem) VALUES ('{cboMaSV.Text}', '{cboMaMH.Text}', {diemSo})";
                MySqlCommand cmd = new MySqlCommand(insertString, connsql);
                cmd.ExecuteNonQuery();

                if (connsql.State == ConnectionState.Open) connsql.Close();

                MessageBox.Show("Thêm điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiem.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại (Sinh viên này đã có điểm môn học này rồi).\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa điểm
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed) connsql.Open();

                string deleteString = $"DELETE FROM Diem WHERE MaSinhVien='{cboMaSV.Text}' AND MaMonHoc='{cboMaMH.Text}'";
                MySqlCommand cmd = new MySqlCommand(deleteString, connsql);
                int kq = cmd.ExecuteNonQuery();

                if (connsql.State == ConnectionState.Open) connsql.Close();

                if (kq > 0) MessageBox.Show("Xóa điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Không tìm thấy dữ liệu điểm phù hợp để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa điểm
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiem.Text))
            {
                MessageBox.Show("Vui lòng nhập điểm mới cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(txtDiem.Text, out float diemSo) || diemSo < 0 || diemSo > 10)
            {
                MessageBox.Show("Điểm phải là số từ 0 đến 10!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connsql.State == ConnectionState.Closed) connsql.Open();

                string updateString = $"UPDATE Diem SET Diem={diemSo} WHERE MaSinhVien='{cboMaSV.Text}' AND MaMonHoc='{cboMaMH.Text}'";
                MySqlCommand cmd = new MySqlCommand(updateString, connsql);
                int kq = cmd.ExecuteNonQuery();

                if (connsql.State == ConnectionState.Open) connsql.Close();

                if (kq > 0) MessageBox.Show("Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Không tìm thấy dòng điểm tương ứng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}