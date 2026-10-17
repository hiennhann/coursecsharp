using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace BaiTH6A
{
    public partial class FormSinhVien : Form
    {
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

        // Hàm kiểm tra ngày nhập từ TextBox.
        // Cho phép:
        // 17/10/2005
        // 7/1/2005
        // 2005-10-17
        private bool ChuyenNgay(
            string chuoiNgay,
            out DateTime ngay)
        {
            string[] dinhDang =
            {
                "dd/MM/yyyy",
                "d/M/yyyy",
                "yyyy-MM-dd"
            };

            return DateTime.TryParseExact(
                chuoiNgay,
                dinhDang,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out ngay);
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            // đều không được để trống.
            if (string.IsNullOrWhiteSpace(txtMaLop.Text) ||
                string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtNgaySinh.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin sinh viên!");

                return;
            }

            // Kiểm tra ngày sinh.
            if (!ChuyenNgay(
                    txtNgaySinh.Text.Trim(),
                    out DateTime ngaySinh))
            {
                MessageBox.Show(
                    "Ngày sinh không hợp lệ!\n" +
                    "Ví dụ: 17/10/2005");

                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                string sql = @"
                    INSERT INTO SinhVien
                    (
                        MaSinhVien,
                        HoTen,
                        NgaySinh,
                        MaLop
                    )
                    VALUES
                    (
                        @MaSV,
                        @HoTen,
                        @NgaySinh,
                        @MaLop
                    )";

                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.Add(
                    "@MaSV",
                    SqlDbType.VarChar,
                    10
                ).Value = txtMaSV.Text.Trim();

                cmd.Parameters.Add(
                    "@HoTen",
                    SqlDbType.NVarChar,
                    100
                ).Value = txtHoTen.Text.Trim();

                cmd.Parameters.Add(
                    "@NgaySinh",
                    SqlDbType.Date
                ).Value = ngaySinh;

                cmd.Parameters.Add(
                    "@MaLop",
                    SqlDbType.VarChar,
                    10
                ).Value = txtMaLop.Text.Trim();

                conn.Open();

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Thêm sinh viên thành công!");

                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Thêm sinh viên thất bại!\n" +
                    ex.Message);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Xóa cần Mã sinh viên + Họ tên.
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show(
                    "Khi xóa phải nhập Mã sinh viên và Họ tên!");

                return;
            }

            // Mã lớp và Ngày sinh không được nhập khi xóa.
            if (!string.IsNullOrWhiteSpace(txtMaLop.Text) ||
                !string.IsNullOrWhiteSpace(txtNgaySinh.Text))
            {
                MessageBox.Show(
                    "Khi xóa phải để trống Mã lớp và Ngày sinh!");

                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                string sql = @"
                    DELETE FROM SinhVien
                    WHERE MaSinhVien = @MaSV
                    AND HoTen = @HoTen";

                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.Add(
                    "@MaSV",
                    SqlDbType.VarChar,
                    10
                ).Value = txtMaSV.Text.Trim();

                cmd.Parameters.Add(
                    "@HoTen",
                    SqlDbType.NVarChar,
                    100
                ).Value = txtHoTen.Text.Trim();

                conn.Open();

                int soDong = cmd.ExecuteNonQuery();

                if (soDong > 0)
                {
                    MessageBox.Show(
                        "Xóa sinh viên thành công!");
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy sinh viên phù hợp!");
                }

                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Xóa sinh viên thất bại!\n" +
                    ex.Message);
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            // sinh viên cần sửa.
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show(
                    "Mã sinh viên không được để trống!");

                return;
            }

            // Mã lớp, Họ tên, Ngày sinh phải có ít nhất 1 trường được nhập.
            if (string.IsNullOrWhiteSpace(txtMaLop.Text) &&
                string.IsNullOrWhiteSpace(txtHoTen.Text) &&
                string.IsNullOrWhiteSpace(txtNgaySinh.Text))
            {
                MessageBox.Show(
                    "Phải nhập ít nhất một thông tin cần sửa!");

                return;
            }

            DateTime ngaySinh = DateTime.MinValue;

            // Nếu người dùng có nhập ngày thì mới kiểm tra.
            if (!string.IsNullOrWhiteSpace(txtNgaySinh.Text))
            {
                if (!ChuyenNgay(
                        txtNgaySinh.Text.Trim(),
                        out ngaySinh))
                {
                    MessageBox.Show(
                        "Ngày sinh không hợp lệ!");

                    return;
                }
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                // Nếu tham số NULL -> giữ lại dữ liệu cũ.
                // Nếu có giá trị -> cập nhật giá trị mới.
                string sql = @"
                    UPDATE SinhVien
                    SET
                        MaLop =
                            COALESCE(@MaLop, MaLop),

                        HoTen =
                            COALESCE(@HoTen, HoTen),

                        NgaySinh =
                            COALESCE(@NgaySinh, NgaySinh)

                    WHERE MaSinhVien = @MaSV";

                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                // TextBox trống => DBNull.Value.
                object maLop =
                    string.IsNullOrWhiteSpace(txtMaLop.Text)
                        ? DBNull.Value
                        : txtMaLop.Text.Trim();

                object hoTen =
                    string.IsNullOrWhiteSpace(txtHoTen.Text)
                        ? DBNull.Value
                        : txtHoTen.Text.Trim();

                object ngaySinhMoi =
                    string.IsNullOrWhiteSpace(txtNgaySinh.Text)
                        ? DBNull.Value
                        : ngaySinh;

                cmd.Parameters.Add(
                    "@MaLop",
                    SqlDbType.VarChar,
                    10
                ).Value = maLop;

                cmd.Parameters.Add(
                    "@HoTen",
                    SqlDbType.NVarChar,
                    100
                ).Value = hoTen;

                cmd.Parameters.Add(
                    "@NgaySinh",
                    SqlDbType.Date
                ).Value = ngaySinhMoi;

                cmd.Parameters.Add(
                    "@MaSV",
                    SqlDbType.VarChar,
                    10
                ).Value = txtMaSV.Text.Trim();

                conn.Open();

                int soDong = cmd.ExecuteNonQuery();

                if (soDong > 0)
                {
                    MessageBox.Show(
                        "Sửa sinh viên thành công!");
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy Mã sinh viên!");
                }

                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Sửa sinh viên thất bại!\n" +
                    ex.Message);
            }
        }

        private void XoaTrang()
        {
            txtMaLop.Clear();
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtNgaySinh.Clear();

            txtMaSV.Focus();
        }
    }
}