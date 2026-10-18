
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BaiTH6B
{
    public partial class FormSanPham : Form
    {
        private readonly string connectionString =
            @"Data Source=NGVHNNA\SQLEXPRESS;
              Initial Catalog=QLCuaHang;
              Integrated Security=True;
              Encrypt=True;
              TrustServerCertificate=True";

        public FormSanPham()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!");
                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                conn.Open();

                // Transaction đảm bảo hai thao tác cùng thành công:
                // 1. Thêm sản phẩm.
                // 2. Tạo tồn kho ban đầu.
                using SqlTransaction transaction =
                    conn.BeginTransaction();

                try
                {
                    string sqlSanPham = @"
                        INSERT INTO SANPHAM(TenSP)
                        OUTPUT INSERTED.MaSP
                        VALUES(@TenSP)";

                    using SqlCommand cmdSanPham =
                        new SqlCommand(sqlSanPham, conn, transaction);

                    cmdSanPham.Parameters.Add(
                        "@TenSP", SqlDbType.NVarChar, 100
                    ).Value = txtTenSP.Text.Trim();

                    // Lấy mã sản phẩm vừa tự tăng.
                    int maSP = Convert.ToInt32(
                        cmdSanPham.ExecuteScalar());

                    // Khi thêm sản phẩm mới:
                    // SLDau = 0, SLNhap = 0, SLBan = 0.
                    string sqlTonKho = @"
                        INSERT INTO TONKHO
                            (MaSP, NgayTon, SLDau, SLNhap, SLBan)
                        VALUES
                            (@MaSP, @NgayTon, 0, 0, 0)";

                    using SqlCommand cmdTonKho =
                        new SqlCommand(sqlTonKho, conn, transaction);

                    cmdTonKho.Parameters.Add("@MaSP", SqlDbType.Int)
                        .Value = maSP;

                    cmdTonKho.Parameters.Add("@NgayTon", SqlDbType.Date)
                        .Value = DateTime.Today;

                    cmdTonKho.ExecuteNonQuery();

                    // Lưu cả hai thao tác.
                    transaction.Commit();

                    MessageBox.Show(
                        $"Thêm sản phẩm thành công! Mã sản phẩm: {maSP}");

                    txtTenSP.Clear();
                    txtTenSP.Focus();
                }
                catch
                {
                    // Nếu một bước lỗi thì hủy toàn bộ thay đổi.
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sản phẩm: " + ex.Message);
            }
        }
    }
}
