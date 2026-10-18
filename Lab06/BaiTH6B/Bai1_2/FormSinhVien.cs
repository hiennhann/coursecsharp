
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace BaiTH6B
{
    public partial class FormSinhVien : Form
    {
        // Kết nối SQL Server trên máy.
        private readonly string connectionString =
            @"Data Source=NGVHNNA\SQLEXPRESS;
              Initial Catalog=QLSinhVien;
              Integrated Security=True;
              Encrypt=True;
              TrustServerCertificate=True";

        public FormSinhVien()
        {
            InitializeComponent();
        }

        // Khi mở Form, lấy Mã lớp từ CSDL đưa lên ComboBox.
        private void FormSinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                cboLop.Items.Clear();

                using SqlConnection conn =
                    new SqlConnection(connectionString);

                string sql = "SELECT MaLop FROM Lop ORDER BY MaLop";

                using SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();

                // ExecuteReader đọc từng dòng dữ liệu trả về.
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cboLop.Items.Add(reader["MaLop"].ToString()!);
                }

                cboLop.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách lớp: " + ex.Message);
            }
        }

        // Kiểm tra một mã có tồn tại trong bảng hay chưa.
        // Trả về true nếu tìm thấy dữ liệu.
        private bool TonTai(
            SqlConnection conn,
            string sql,
            string ma)
        {
            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@Ma", SqlDbType.VarChar, 10)
                .Value = ma;

            using SqlDataReader reader = cmd.ExecuteReader();

            // HasRows = true nghĩa là truy vấn có kết quả.
            return reader.HasRows;
        }

        // Chuyển chuỗi ngày sinh thành DateTime.
        private bool KiemTraNgaySinh(out DateTime ngaySinh)
        {
            string[] dinhDang = { "dd/MM/yyyy", "d/M/yyyy" };

            return DateTime.TryParseExact(
                txtNgaySinh.Text.Trim(),
                dinhDang,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out ngaySinh);
        }

        // Kiểm tra tuổi theo năm sinh đúng yêu cầu đề.
        private bool Du17Tuoi(DateTime ngaySinh)
        {
            return DateTime.Now.Year - ngaySinh.Year >= 17;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtNgaySinh.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (!KiemTraNgaySinh(out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ! Ví dụ: 12/05/2005");
                return;
            }

            if (!Du17Tuoi(ngaySinh))
            {
                MessageBox.Show("Sinh viên phải từ 17 tuổi trở lên!");
                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                conn.Open();

                string maSV = txtMaSV.Text.Trim();
                string maLop = cboLop.SelectedItem.ToString()!;

                // Kiểm tra khóa chính trước khi thêm.
                if (TonTai(
                    conn,
                    "SELECT 1 FROM SinhVien WHERE MaSinhVien = @Ma",
                    maSV))
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại!");
                    return;
                }

                // Kiểm tra Mã lớp có tồn tại trong bảng Lop.
                if (!TonTai(
                    conn,
                    "SELECT 1 FROM Lop WHERE MaLop = @Ma",
                    maLop))
                {
                    MessageBox.Show("Mã lớp không tồn tại!");
                    return;
                }

                string sql = @"
                    INSERT INTO SinhVien(MaSinhVien, HoTen, NgaySinh, MaLop)
                    VALUES(@MaSV, @HoTen, @NgaySinh, @MaLop)";

                using SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 10)
                    .Value = maSV;

                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100)
                    .Value = txtHoTen.Text.Trim();

                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date)
                    .Value = ngaySinh;

                cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 10)
                    .Value = maLop;

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm sinh viên thành công!");
                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sinh viên: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên cần xóa!");
                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                conn.Open();

                string maSV = txtMaSV.Text.Trim();

                // Kiểm tra sinh viên có tồn tại hay không.
                if (!TonTai(
                    conn,
                    "SELECT 1 FROM SinhVien WHERE MaSinhVien = @Ma",
                    maSV))
                {
                    MessageBox.Show("Không tìm thấy sinh viên!");
                    return;
                }

                // Nếu sinh viên đã có điểm, không cho xóa
                // vì bảng Diem đang tham chiếu đến sinh viên.
                if (TonTai(
                    conn,
                    "SELECT 1 FROM Diem WHERE MaSinhVien = @Ma",
                    maSV))
                {
                    MessageBox.Show(
                        "Không thể xóa sinh viên vì đã có dữ liệu điểm!");
                    return;
                }

                string sql =
                    "DELETE FROM SinhVien WHERE MaSinhVien = @Ma";

                using SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@Ma", SqlDbType.VarChar, 10)
                    .Value = maSV;

                cmd.ExecuteNonQuery();

                MessageBox.Show("Xóa sinh viên thành công!");
                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa sinh viên: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtNgaySinh.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để sửa!");
                return;
            }

            if (!KiemTraNgaySinh(out DateTime ngaySinh) ||
                !Du17Tuoi(ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ hoặc chưa đủ 17 tuổi!");
                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                conn.Open();

                string maSV = txtMaSV.Text.Trim();
                string maLop = cboLop.SelectedItem.ToString()!;

                // Kiểm tra khóa chính.
                if (!TonTai(
                    conn,
                    "SELECT 1 FROM SinhVien WHERE MaSinhVien = @Ma",
                    maSV))
                {
                    MessageBox.Show("Mã sinh viên không tồn tại!");
                    return;
                }

                // Kiểm tra khóa ngoại.
                if (!TonTai(
                    conn,
                    "SELECT 1 FROM Lop WHERE MaLop = @Ma",
                    maLop))
                {
                    MessageBox.Show("Mã lớp không tồn tại!");
                    return;
                }

                string sql = @"
                    UPDATE SinhVien
                    SET HoTen = @HoTen,
                        NgaySinh = @NgaySinh,
                        MaLop = @MaLop
                    WHERE MaSinhVien = @MaSV";

                using SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 10)
                    .Value = maSV;

                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100)
                    .Value = txtHoTen.Text.Trim();

                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date)
                    .Value = ngaySinh;

                cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 10)
                    .Value = maLop;

                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa sinh viên thành công!");
                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa sinh viên: " + ex.Message);
            }
        }

        // Xóa dữ liệu trên Form sau khi xử lý.
        private void XoaTrang()
        {
            cboLop.SelectedIndex = -1;
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtNgaySinh.Clear();
            txtMaSV.Focus();
        }
    }
}
