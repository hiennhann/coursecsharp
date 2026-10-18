
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BaiTH6B
{
    public partial class FormMain : Form
    {
        // Kết nối đến SQL Server Management Studio 2022
        private readonly string connectionString =
            @"Data Source=NGVHNNA\SQLEXPRESS;
              Initial Catalog=QLCuaHang;
              Integrated Security=True;
              Encrypt=True;
              TrustServerCertificate=True";

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Khi mở Form sẽ hiển thị dữ liệu tồn kho.
            HienThiTonKho();
        }

        private void HienThiTonKho()
        {
            try
            {
                // Xóa các dòng cũ trước khi tải lại dữ liệu.
                dgvTonKho.Rows.Clear();

                using SqlConnection conn =
                    new SqlConnection(connectionString);

                // Lấy dòng tồn kho gần nhất của mỗi sản phẩm.
                // Nếu hôm nay chưa tạo tồn kho thì lấy
                // thông tin tồn kho của ngày trước.
                string sql = @"
                    SELECT
                        sp.MaSP,
                        sp.TenSP,
                        tk.NgayTon,
                        tk.SLDau,
                        tk.SLNhap,
                        tk.SLBan,

                        (tk.SLDau + tk.SLNhap - tk.SLBan)
                            AS SoLuongCon

                    FROM SANPHAM sp

                    OUTER APPLY
                    (
                        SELECT TOP 1
                            t.NgayTon,
                            t.SLDau,
                            t.SLNhap,
                            t.SLBan

                        FROM TONKHO t

                        WHERE t.MaSP = sp.MaSP
                          AND t.NgayTon <= CAST(GETDATE() AS DATE)

                        ORDER BY t.NgayTon DESC
                    ) tk

                    ORDER BY sp.MaSP";

                using SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();

                using SqlDataReader reader = cmd.ExecuteReader();

                int tongSanPham = 0;
                int tongTonKho = 0;

                while (reader.Read())
                {
                    // Lấy thông tin sản phẩm.
                    string maSP = reader["MaSP"].ToString()!;
                    string tenSP = reader["TenSP"].ToString()!;

                    // Kiểm tra sản phẩm đã có tồn kho hay chưa.
                    bool coTonKho = reader["NgayTon"] != DBNull.Value;

                    string ngayTon = "-";
                    string slDau = "-";
                    string slNhap = "-";
                    string slBan = "-";
                    string soLuongCon = "-";

                    if (coTonKho)
                    {
                        DateTime ngay = Convert.ToDateTime(
                            reader["NgayTon"]);

                        ngayTon = ngay.ToString("dd/MM/yyyy");

                        slDau = reader["SLDau"].ToString()!;
                        slNhap = reader["SLNhap"].ToString()!;
                        slBan = reader["SLBan"].ToString()!;
                        soLuongCon = reader["SoLuongCon"].ToString()!;

                        // Cộng số lượng còn lại của từng sản phẩm.
                        tongTonKho += Convert.ToInt32(
                            reader["SoLuongCon"]);
                    }

                    // Thêm dòng mới vào DataGridView.
                    dgvTonKho.Rows.Add(
                        maSP,
                        tenSP,
                        ngayTon,
                        slDau,
                        slNhap,
                        slBan,
                        soLuongCon
                    );

                    tongSanPham++;
                }

                // Hiển thị thống kê dưới bảng.
                lblTongSanPham.Text =
                    "Tổng sản phẩm: " + tongSanPham;

                lblTongTonKho.Text =
                    "Tổng tồn kho: " + tongTonKho;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi hiển thị tồn kho!\n" + ex.Message);
            }
        }

        private void mnuTaoTonKho_Click(object sender, EventArgs e)
        {
            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                // Tồn đầu ngày mới được lấy từ
                // số tồn cuối của ngày gần nhất trước đó.
                //
                // SLDau = SLDau cũ + SLNhap cũ - SLBan cũ
                // SLNhap = 0
                // SLBan = 0
                string sql = @"
                    INSERT INTO TONKHO
                        (MaSP, NgayTon, SLDau, SLNhap, SLBan)

                    SELECT
                        sp.MaSP,
                        @NgayTon,

                        ISNULL
                        (
                            (
                                SELECT TOP 1
                                    tk.SLDau + tk.SLNhap - tk.SLBan

                                FROM TONKHO tk

                                WHERE tk.MaSP = sp.MaSP
                                  AND tk.NgayTon < @NgayTon

                                ORDER BY tk.NgayTon DESC
                            ),
                            0
                        ),

                        0,
                        0

                    FROM SANPHAM sp

                    WHERE NOT EXISTS
                    (
                        SELECT 1
                        FROM TONKHO t
                        WHERE t.MaSP = sp.MaSP
                          AND t.NgayTon = @NgayTon
                    )";

                using SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@NgayTon", SqlDbType.Date)
                    .Value = DateTime.Today;

                conn.Open();

                int soDong = cmd.ExecuteNonQuery();

                if (soDong > 0)
                {
                    MessageBox.Show(
                        $"Đã tạo tồn kho cho {soDong} sản phẩm!");
                }
                else
                {
                    MessageBox.Show(
                        "Tồn kho hôm nay đã được tạo hoặc chưa có sản phẩm!");
                }

                // Sau khi tạo tồn kho, cập nhật bảng.
                HienThiTonKho();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tạo tồn kho!\n" + ex.Message);
            }
        }
        private void mnuThemSanPham_Click(object sender, EventArgs e)
        {
            using FormSanPham form = new FormSanPham();

            // Mở Form thêm sản phẩm.
            form.ShowDialog(this);

            // Tải lại bảng khi đóng Form thêm sản phẩm.
            HienThiTonKho();
        }

        private void mnuBanHang_Click(object sender, EventArgs e)
        {
            using FormBanHang form = new FormBanHang();

            // Mở Form bán hàng.
            form.ShowDialog(this);

            // Cập nhật tồn kho sau khi bán hàng.
            HienThiTonKho();
        }


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            HienThiTonKho();
        }
    }
}
