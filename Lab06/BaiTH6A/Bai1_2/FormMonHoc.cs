using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BaiTH6A
{
    public partial class FormMonHoc : Form
    {
        // kết nối tới SQL Server(SSMS 2022) đang chạy trên máy.
        // Server name lấy trực tiếp từ SSMS: vd: NGVHNNA\SQLEXPRESS (thay đổi theo sv name)
        private readonly string connectionString =
            @"Data Source=NGVHNNA\SQLEXPRESS;
              Initial Catalog=QLSinhVien;
              Integrated Security=True;
              Encrypt=True;
              TrustServerCertificate=True";

        public FormMonHoc()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // đều không được để trống.
            if (string.IsNullOrWhiteSpace(txtMaMH.Text) ||
                string.IsNullOrWhiteSpace(txtTenMH.Text))
            {
                MessageBox.Show(
                    "Mã môn học và Tên môn học không được để trống!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                // đối tượng kết nối SQL Server.
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                // thêm dữ liệu.
                string sql = @"
                    INSERT INTO MonHoc(MaMonHoc, TenMonHoc)
                    VALUES(@MaMH, @TenMH)";

                // dùng để gửi câu SQL đến SQL Server.
                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                // Parameter giúp tránh ghép chuỗi trực tiếp vào SQL.
                cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 10)
                    .Value = txtMaMH.Text.Trim();

                cmd.Parameters.Add("@TenMH", SqlDbType.NVarChar, 100)
                    .Value = txtTenMH.Text.Trim();

                conn.Open();

                // ExecuteNonQuery dùng cho INSERT / UPDATE / DELETE.
                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Thêm môn học thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Thêm môn học thất bại!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Khi xóa chỉ bắt buộc Mã môn học.
            if (string.IsNullOrWhiteSpace(txtMaMH.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập Mã môn học cần xóa!");

                return;
            }

            // Tên môn học không nhập khi xóa.
            if (!string.IsNullOrWhiteSpace(txtTenMH.Text))
            {
                MessageBox.Show(
                    "Khi xóa chỉ nhập Mã môn học.\n" +
                    "Tên môn học phải để trống!");

                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                string sql = @"
                    DELETE FROM MonHoc
                    WHERE MaMonHoc = @MaMH";

                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 10)
                    .Value = txtMaMH.Text.Trim();

                conn.Open();

                // ExecuteNonQuery trả về số dòng bị ảnh hưởng.
                int soDong = cmd.ExecuteNonQuery();

                if (soDong > 0)
                {
                    MessageBox.Show(
                        "Xóa môn học thành công!");
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy môn học cần xóa!");
                }

                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Xóa môn học thất bại!\n" + ex.Message);
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            // Sửa cần Mã môn học để xác định dòng và Tên môn học là giá trị mới.
            if (string.IsNullOrWhiteSpace(txtMaMH.Text) ||
                string.IsNullOrWhiteSpace(txtTenMH.Text))
            {
                MessageBox.Show(
                    "Mã môn học và Tên môn học không được để trống!");

                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                string sql = @"
                    UPDATE MonHoc
                    SET TenMonHoc = @TenMH
                    WHERE MaMonHoc = @MaMH";

                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 10)
                    .Value = txtMaMH.Text.Trim();

                cmd.Parameters.Add("@TenMH", SqlDbType.NVarChar, 100)
                    .Value = txtTenMH.Text.Trim();

                conn.Open();

                int soDong = cmd.ExecuteNonQuery();

                if (soDong > 0)
                {
                    MessageBox.Show(
                        "Sửa môn học thành công!");
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy môn học cần sửa!");
                }

                XoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Sửa môn học thất bại!\n" + ex.Message);
            }
        }

        // Xóa dữ liệu trên giao diện sau khi thao tác.
        private void XoaTrang()
        {
            txtMaMH.Clear();
            txtTenMH.Clear();

            txtMaMH.Focus();
        }
    }
}