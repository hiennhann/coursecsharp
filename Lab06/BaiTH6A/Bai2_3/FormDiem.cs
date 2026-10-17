using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace BaiTH6A
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

        // Cho phép nhập 8.5 hoặc 8,5 tùy môi trường Windows.
        private bool ChuyenDiem(
            string chuoiDiem,
            out double diem)
        {
            if (double.TryParse(
                chuoiDiem,
                out diem))
            {
                return true;
            }

            return double.TryParse(
                chuoiDiem,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out diem);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Cả 3 trường phải được nhập.
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtMaMH.Text) ||
                string.IsNullOrWhiteSpace(txtDiem.Text))
            {
                MessageBox.Show(
                    "Mã sinh viên, Mã môn học và Điểm " +
                    "không được để trống!");

                return;
            }

            // Theo đề, điểm phải là số.
            if (!ChuyenDiem(
                    txtDiem.Text.Trim(),
                    out double diem))
            {
                MessageBox.Show(
                    "Điểm phải là số!");

                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                string sql = @"
                    INSERT INTO Diem
                    (
                        MaSinhVien,
                        MaMonHoc,
                        Diem
                    )
                    VALUES
                    (
                        @MaSV,
                        @MaMH,
                        @Diem
                    )";

                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.Add(
                    "@MaSV",
                    SqlDbType.VarChar,
                    10
                ).Value = txtMaSV.Text.Trim();

                cmd.Parameters.Add(
                    "@MaMH",
                    SqlDbType.VarChar,
                    10
                ).Value = txtMaMH.Text.Trim();

                cmd.Parameters.Add(
                    "@Diem",
                    SqlDbType.Float
                ).Value = diem;

                conn.Open();

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Thêm điểm thành công!");

                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Thêm điểm thất bại!\n" +
                    ex.Message);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Khi xóa cần Mã sinh viên + Mã môn học.
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtMaMH.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập Mã sinh viên và Mã môn học!");

                return;
            }

            // Theo đề, Điểm phải để trống khi xóa.
            if (!string.IsNullOrWhiteSpace(txtDiem.Text))
            {
                MessageBox.Show(
                    "Khi xóa phải để trống trường Điểm!");

                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                string sql = @"
                    DELETE FROM Diem
                    WHERE MaSinhVien = @MaSV
                    AND MaMonHoc = @MaMH";

                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.Add(
                    "@MaSV",
                    SqlDbType.VarChar,
                    10
                ).Value = txtMaSV.Text.Trim();

                cmd.Parameters.Add(
                    "@MaMH",
                    SqlDbType.VarChar,
                    10
                ).Value = txtMaMH.Text.Trim();

                conn.Open();

                int soDong = cmd.ExecuteNonQuery();

                if (soDong > 0)
                {
                    MessageBox.Show(
                        "Xóa điểm thành công!");
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy dữ liệu điểm cần xóa!");
                }

                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Xóa điểm thất bại!\n" +
                    ex.Message);
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            // Khi sửa cần đầy đủ cả 3 trường.
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtMaMH.Text) ||
                string.IsNullOrWhiteSpace(txtDiem.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin!");

                return;
            }

            if (!ChuyenDiem(
                    txtDiem.Text.Trim(),
                    out double diem))
            {
                MessageBox.Show(
                    "Điểm phải là số!");

                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                // Mã SV + Mã MH xác định dòng.
                // Chỉ thay đổi giá trị Điểm.
                string sql = @"
                    UPDATE Diem
                    SET Diem = @Diem
                    WHERE MaSinhVien = @MaSV
                    AND MaMonHoc = @MaMH";

                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.Add(
                    "@MaSV",
                    SqlDbType.VarChar,
                    10
                ).Value = txtMaSV.Text.Trim();

                cmd.Parameters.Add(
                    "@MaMH",
                    SqlDbType.VarChar,
                    10
                ).Value = txtMaMH.Text.Trim();

                cmd.Parameters.Add(
                    "@Diem",
                    SqlDbType.Float
                ).Value = diem;

                conn.Open();

                int soDong = cmd.ExecuteNonQuery();

                if (soDong > 0)
                {
                    MessageBox.Show(
                        "Sửa điểm thành công!");
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy dữ liệu điểm cần sửa!");
                }

                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Sửa điểm thất bại!\n" +
                    ex.Message);
            }
        }

        private void XoaTrang()
        {
            txtMaSV.Clear();
            txtMaMH.Clear();
            txtDiem.Clear();

            txtMaSV.Focus();
        }
    }
}