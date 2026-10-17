using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BaiTH6A
{
    public partial class FormLop : Form
    {
        private readonly string connectionString =
            @"Data Source=NGVHNNA\SQLEXPRESS;
              Initial Catalog=QLSinhVien;
              Integrated Security=True;
              Encrypt=True;
              TrustServerCertificate=True";

        public FormLop()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Khi thêm phải nhập đầy đủ cả 3 trường.
            if (string.IsNullOrWhiteSpace(txtMaKhoa.Text) ||
                string.IsNullOrWhiteSpace(txtMaLop.Text) ||
                string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show(
                    "Mã khoa, Mã lớp và Tên lớp " +
                    "không được để trống!");

                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                string sql = @"
                    INSERT INTO Lop
                    (
                        MaLop,
                        TenLop,
                        MaKhoa
                    )
                    VALUES
                    (
                        @MaLop,
                        @TenLop,
                        @MaKhoa
                    )";

                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.Add(
                    "@MaLop",
                    SqlDbType.VarChar,
                    10
                ).Value = txtMaLop.Text.Trim();

                cmd.Parameters.Add(
                    "@TenLop",
                    SqlDbType.NVarChar,
                    100
                ).Value = txtTenLop.Text.Trim();

                cmd.Parameters.Add(
                    "@MaKhoa",
                    SqlDbType.VarChar,
                    10
                ).Value = txtMaKhoa.Text.Trim();

                conn.Open();

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Thêm lớp thành công!");

                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Thêm lớp thất bại!\n" +
                    ex.Message);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Khi xóa chỉ yêu cầu Mã lớp.
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập Mã lớp cần xóa!");

                return;
            }

            // Mã khoa và Tên lớp không nhập dữ liệu.
            if (!string.IsNullOrWhiteSpace(txtMaKhoa.Text) ||
                !string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show(
                    "Khi xóa chỉ nhập Mã lớp.\n" +
                    "Mã khoa và Tên lớp phải để trống!");

                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                string sql = @"
                    DELETE FROM Lop
                    WHERE MaLop = @MaLop";

                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.Add(
                    "@MaLop",
                    SqlDbType.VarChar,
                    10
                ).Value = txtMaLop.Text.Trim();

                conn.Open();

                int soDong = cmd.ExecuteNonQuery();

                if (soDong > 0)
                {
                    MessageBox.Show(
                        "Xóa lớp thành công!");
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy lớp cần xóa!");
                }

                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Xóa lớp thất bại!\n" +
                    ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Mã lớp dùng để xác định lớp cần sửa.
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show(
                    "Mã lớp không được để trống!");

                return;
            }

            // Phải nhập ít nhất Mã khoa hoặc Tên lớp.
            if (string.IsNullOrWhiteSpace(txtMaKhoa.Text) &&
                string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show(
                    "Phải nhập ít nhất Mã khoa " +
                    "hoặc Tên lớp cần sửa!");

                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                // TextBox nào trống thì giữ lại dữ liệu cũ.
                string sql = @"
                    UPDATE Lop
                    SET
                        MaKhoa =
                            COALESCE(@MaKhoa, MaKhoa),

                        TenLop =
                            COALESCE(@TenLop, TenLop)

                    WHERE MaLop = @MaLop";

                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                object maKhoa =
                    string.IsNullOrWhiteSpace(txtMaKhoa.Text)
                        ? DBNull.Value
                        : txtMaKhoa.Text.Trim();

                object tenLop =
                    string.IsNullOrWhiteSpace(txtTenLop.Text)
                        ? DBNull.Value
                        : txtTenLop.Text.Trim();

                cmd.Parameters.Add(
                    "@MaKhoa",
                    SqlDbType.VarChar,
                    10
                ).Value = maKhoa;

                cmd.Parameters.Add(
                    "@TenLop",
                    SqlDbType.NVarChar,
                    100
                ).Value = tenLop;

                cmd.Parameters.Add(
                    "@MaLop",
                    SqlDbType.VarChar,
                    10
                ).Value = txtMaLop.Text.Trim();

                conn.Open();

                int soDong = cmd.ExecuteNonQuery();

                if (soDong > 0)
                {
                    MessageBox.Show(
                        "Sửa lớp thành công!");
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy lớp cần sửa!");
                }

                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Sửa lớp thất bại!\n" +
                    ex.Message);
            }
        }

        private void XoaTrang()
        {
            txtMaKhoa.Clear();
            txtMaLop.Clear();
            txtTenLop.Clear();

            txtMaLop.Focus();
        }
    }
}