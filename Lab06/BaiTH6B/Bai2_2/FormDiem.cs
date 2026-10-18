
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace BaiTH6B
{
    public partial class FormDiem : Form
    {
        private readonly string connectionString =
            @"Data Source=NGVHNNA\SQLEXPRESS;
              Initial Catalog=QLSinhVien;
              Integrated Security=True;
              Encrypt=True;
              TrustServerCertificate=True";

        public FormDiem()
        {
            InitializeComponent();
        }

        // Đưa mã sinh viên và mã môn học lên ComboBox.
        private void FormDiem_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCombo("SELECT MaSinhVien FROM SinhVien",
                          "MaSinhVien", cboSinhVien);

                LoadCombo("SELECT MaMonHoc FROM MonHoc",
                          "MaMonHoc", cboMonHoc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // Hàm đọc dữ liệu SQL Server vào ComboBox.
        private void LoadCombo(
            string sql,
            string tenCot,
            ComboBox combo)
        {
            combo.Items.Clear();

            using SqlConnection conn =
                new SqlConnection(connectionString);

            using SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                combo.Items.Add(reader[tenCot].ToString()!);
            }

            combo.SelectedIndex = -1;
        }

        // Kiểm tra khóa chính / khóa ngoại bằng SqlDataReader.
        private bool TonTai(
            SqlConnection conn,
            string sql,
            string maSV,
            string maMH)
        {
            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 10)
                .Value = maSV;

            cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 10)
                .Value = maMH;

            using SqlDataReader reader = cmd.ExecuteReader();

            return reader.HasRows;
        }

        // Kiểm tra và chuyển điểm sang số.
        private bool KiemTraDiem(out double diem)
        {
            string chuoi = txtDiem.Text.Trim().Replace(',', '.');

            if (!double.TryParse(
                chuoi,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out diem))
            {
                MessageBox.Show("Điểm phải là số!");
                return false;
            }

            if (!double.IsFinite(diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm phải nằm trong khoảng 0 đến 10!");
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSinhVien.SelectedItem == null ||
                cboMonHoc.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtDiem.Text))
            {
                MessageBox.Show("Phải nhập đầy đủ thông tin!");
                return;
            }

            if (!KiemTraDiem(out double diem))
                return;

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                conn.Open();

                string maSV = cboSinhVien.SelectedItem.ToString()!;
                string maMH = cboMonHoc.SelectedItem.ToString()!;

                // Kiểm tra sinh viên đã tồn tại.
                if (!TonTai(
                    conn,
                    "SELECT 1 FROM SinhVien WHERE MaSinhVien = @MaSV",
                    maSV, maMH))
                {
                    MessageBox.Show("Mã sinh viên không tồn tại!");
                    return;
                }

                // Kiểm tra môn học đã tồn tại.
                if (!TonTai(
                    conn,
                    "SELECT 1 FROM MonHoc WHERE MaMonHoc = @MaMH",
                    maSV, maMH))
                {
                    MessageBox.Show("Mã môn học không tồn tại!");
                    return;
                }

                // Không cho thêm trùng khóa chính.
                if (TonTai(
                    conn,
                    @"SELECT 1 FROM Diem
                      WHERE MaSinhVien = @MaSV AND MaMonHoc = @MaMH",
                    maSV, maMH))
                {
                    MessageBox.Show("Sinh viên đã có điểm môn học này!");
                    return;
                }

                string sql = @"
                    INSERT INTO Diem(MaSinhVien, MaMonHoc, Diem)
                    VALUES(@MaSV, @MaMH, @Diem)";

                using SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 10)
                    .Value = maSV;

                cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 10)
                    .Value = maMH;

                cmd.Parameters.Add("@Diem", SqlDbType.Float)
                    .Value = diem;

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm điểm thành công!");
                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm điểm: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cboSinhVien.SelectedItem == null ||
                cboMonHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên và môn học!");
                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                conn.Open();

                string maSV = cboSinhVien.SelectedItem.ToString()!;
                string maMH = cboMonHoc.SelectedItem.ToString()!;

                // Chỉ xóa khi cặp khóa chính tồn tại.
                if (!TonTai(
                    conn,
                    @"SELECT 1 FROM Diem
                      WHERE MaSinhVien = @MaSV AND MaMonHoc = @MaMH",
                    maSV, maMH))
                {
                    MessageBox.Show("Không tìm thấy điểm cần xóa!");
                    return;
                }

                string sql = @"
                    DELETE FROM Diem
                    WHERE MaSinhVien = @MaSV AND MaMonHoc = @MaMH";

                using SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 10)
                    .Value = maSV;

                cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 10)
                    .Value = maMH;

                cmd.ExecuteNonQuery();

                MessageBox.Show("Xóa điểm thành công!");
                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa điểm: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboSinhVien.SelectedItem == null ||
                cboMonHoc.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtDiem.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (!KiemTraDiem(out double diem))
                return;

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                conn.Open();

                string maSV = cboSinhVien.SelectedItem.ToString()!;
                string maMH = cboMonHoc.SelectedItem.ToString()!;

                if (!TonTai(
                    conn,
                    @"SELECT 1 FROM Diem
                      WHERE MaSinhVien = @MaSV AND MaMonHoc = @MaMH",
                    maSV, maMH))
                {
                    MessageBox.Show("Không tìm thấy điểm cần sửa!");
                    return;
                }

                string sql = @"
                    UPDATE Diem SET Diem = @Diem
                    WHERE MaSinhVien = @MaSV AND MaMonHoc = @MaMH";

                using SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 10)
                    .Value = maSV;

                cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 10)
                    .Value = maMH;

                cmd.Parameters.Add("@Diem", SqlDbType.Float)
                    .Value = diem;

                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa điểm thành công!");
                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa điểm: " + ex.Message);
            }
        }

        private void XoaTrang()
        {
            cboSinhVien.SelectedIndex = -1;
            cboMonHoc.SelectedIndex = -1;
            txtDiem.Clear();
        }
    }
}
