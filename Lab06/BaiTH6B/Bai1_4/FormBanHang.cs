
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BaiTH6B
{
    public partial class FormBanHang : Form
    {
        private readonly string connectionString =
            @"Data Source=NGVHNNA\SQLEXPRESS;
              Initial Catalog=QLCuaHang;
              Integrated Security=True;
              Encrypt=True;
              TrustServerCertificate=True";

        // Lưu mã hóa đơn đang thao tác.
        private int? maHoaDonHienTai = null;

        // Ngày tạo hóa đơn, dùng để xác định dòng tồn kho.
        private DateTime ngayHoaDon;

        // Đối tượng chứa thông tin một sản phẩm trong ComboBox.
        private sealed class SanPhamLuaChon
        {
            public int MaSP { get; }
            public string TenSP { get; }

            public SanPhamLuaChon(int maSP, string tenSP)
            {
                MaSP = maSP;
                TenSP = tenSP;
            }

            public override string ToString()
            {
                return $"{MaSP} - {TenSP}";
            }
        }

        public FormBanHang()
        {
            InitializeComponent();

            // Khi chưa tạo hóa đơn, khóa các chức năng bán hàng.
            CapNhatTrangThai(false);
        }

        private void FormBanHang_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message);
            }
        }

        // Lấy sản phẩm từ SQL Server đưa lên ComboBox.
        private void LoadSanPham()
        {
            cboSanPham.Items.Clear();

            using SqlConnection conn =
                new SqlConnection(connectionString);

            string sql = "SELECT MaSP, TenSP FROM SANPHAM ORDER BY MaSP";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int maSP = Convert.ToInt32(reader["MaSP"]);
                string tenSP = reader["TenSP"].ToString()!;

                cboSanPham.Items.Add(
                    new SanPhamLuaChon(maSP, tenSP));
            }

            cboSanPham.SelectedIndex = -1;
        }

        // Bật hoặc tắt các Control dựa vào trạng thái hóa đơn.
        private void CapNhatTrangThai(bool dangCoHoaDon)
        {
            btnTaoHoaDon.Enabled = !dangCoHoaDon;

            cboSanPham.Enabled = dangCoHoaDon;
            txtSoLuong.Enabled = dangCoHoaDon;

            btnThem.Enabled = dangCoHoaDon;
            btnHuy.Enabled = dangCoHoaDon;
            btnThanhToan.Enabled = dangCoHoaDon;
        }

        // Xóa trạng thái hóa đơn hiện tại trên Form.
        private void DatLaiForm()
        {
            maHoaDonHienTai = null;

            txtMaHD.Clear();
            txtSoLuong.Clear();

            cboSanPham.SelectedIndex = -1;
            lvChiTiet.Items.Clear();

            CapNhatTrangThai(false);
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            if (maHoaDonHienTai.HasValue)
            {
                MessageBox.Show(
                    "Hãy thanh toán hoặc hủy hóa đơn hiện tại!");
                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                // Tình trạng thanh toán ban đầu bằng 0.
                // OUTPUT trả về mã hóa đơn vừa tự tăng.
                string sql = @"
                    INSERT INTO HOADON
                        (NgayTao, TinhTrangThanhToan)
                    OUTPUT INSERTED.MaHD
                    VALUES(SYSDATETIME(), 0)";

                using SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();

                int maHD = Convert.ToInt32(cmd.ExecuteScalar());

                maHoaDonHienTai = maHD;
                ngayHoaDon = DateTime.Today;

                txtMaHD.Text = maHD.ToString();

                // Cho phép thao tác khi đã có hóa đơn.
                CapNhatTrangThai(true);

                MessageBox.Show(
                    $"Đã tạo hóa đơn mới! Mã hóa đơn: {maHD}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo hóa đơn: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!maHoaDonHienTai.HasValue)
            {
                MessageBox.Show("Vui lòng tạo hóa đơn trước!");
                return;
            }

            if (cboSanPham.SelectedItem is not SanPhamLuaChon sp)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong)
                || soLuong <= 0)
            {
                MessageBox.Show("Số lượng bán phải là số nguyên lớn hơn 0!");
                return;
            }

            // Chỉ xử lý bán hàng trong ngày tạo hóa đơn.
            if (ngayHoaDon.Date != DateTime.Today)
            {
                MessageBox.Show(
                    "Hóa đơn được tạo từ ngày trước. " +
                    "Hãy thanh toán hoặc hủy hóa đơn hiện tại.");
                return;
            }

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                conn.Open();

                // Transaction bảo đảm:
                // Thêm chi tiết và cập nhật tồn kho cùng thành công.
                using SqlTransaction transaction =
                    conn.BeginTransaction();

                try
                {
                    int maHD = maHoaDonHienTai.Value;
                    int maSP = sp.MaSP;

                    // Kiểm tra hóa đơn còn ở trạng thái chưa thanh toán.
                    string sqlHD = @"
                        SELECT COUNT(*)
                        FROM HOADON
                        WHERE MaHD = @MaHD
                          AND TinhTrangThanhToan = 0";

                    using (SqlCommand cmdHD =
                        new SqlCommand(sqlHD, conn, transaction))
                    {
                        cmdHD.Parameters.Add("@MaHD", SqlDbType.Int)
                            .Value = maHD;

                        int soHD = Convert.ToInt32(
                            cmdHD.ExecuteScalar());

                        if (soHD == 0)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Hóa đơn không còn hợp lệ!");
                            return;
                        }
                    }

                    // Lấy số lượng tồn trong ngày.
                    // UPDLOCK giúp khóa dòng tồn kho khi đang bán.
                    string sqlTon = @"
                        SELECT SLDau + SLNhap - SLBan
                        FROM TONKHO WITH (UPDLOCK, HOLDLOCK)
                        WHERE MaSP = @MaSP
                          AND NgayTon = @NgayTon";

                    object? ketQuaTon;

                    using (SqlCommand cmdTon =
                        new SqlCommand(sqlTon, conn, transaction))
                    {
                        cmdTon.Parameters.Add("@MaSP", SqlDbType.Int)
                            .Value = maSP;

                        cmdTon.Parameters.Add("@NgayTon", SqlDbType.Date)
                            .Value = ngayHoaDon;

                        ketQuaTon = cmdTon.ExecuteScalar();
                    }

                    if (ketQuaTon == null ||
                        ketQuaTon == DBNull.Value)
                    {
                        transaction.Rollback();
                        MessageBox.Show(
                            "Chưa có dữ liệu tồn kho của sản phẩm hôm nay!");
                        return;
                    }

                    int soTon = Convert.ToInt32(ketQuaTon);

                    // Theo đề, số lượng bán phải nhỏ hơn tồn kho.
                    if (soLuong >= soTon)
                    {
                        transaction.Rollback();
                        MessageBox.Show(
                            $"Số lượng bán phải nhỏ hơn tồn kho ({soTon})!");
                        return;
                    }

                    // Kiểm tra cặp MaHD + MaSP không được trùng.
                    string sqlTrung = @"
                        SELECT COUNT(*)
                        FROM CHITIET_HOADON
                        WHERE MaHD = @MaHD AND MaSP = @MaSP";

                    using (SqlCommand cmdTrung =
                        new SqlCommand(sqlTrung, conn, transaction))
                    {
                        cmdTrung.Parameters.Add("@MaHD", SqlDbType.Int)
                            .Value = maHD;

                        cmdTrung.Parameters.Add("@MaSP", SqlDbType.Int)
                            .Value = maSP;

                        int trung = Convert.ToInt32(
                            cmdTrung.ExecuteScalar());

                        if (trung > 0)
                        {
                            transaction.Rollback();
                            MessageBox.Show(
                                "Sản phẩm đã có trong hóa đơn!");
                            return;
                        }
                    }

                    // Thêm sản phẩm vào chi tiết hóa đơn.
                    string sqlCT = @"
                        INSERT INTO CHITIET_HOADON
                            (MaHD, MaSP, SoLuong)
                        VALUES(@MaHD, @MaSP, @SoLuong)";

                    using (SqlCommand cmdCT =
                        new SqlCommand(sqlCT, conn, transaction))
                    {
                        cmdCT.Parameters.Add("@MaHD", SqlDbType.Int)
                            .Value = maHD;

                        cmdCT.Parameters.Add("@MaSP", SqlDbType.Int)
                            .Value = maSP;

                        cmdCT.Parameters.Add("@SoLuong", SqlDbType.Int)
                            .Value = soLuong;

                        cmdCT.ExecuteNonQuery();
                    }

                    // Cộng số lượng đã bán vào SLBan.
                    // Số tồn còn lại sẽ giảm.
                    string sqlCapNhat = @"
                        UPDATE TONKHO
                        SET SLBan = SLBan + @SoLuong
                        WHERE MaSP = @MaSP
                          AND NgayTon = @NgayTon";

                    using (SqlCommand cmdCapNhat =
                        new SqlCommand(sqlCapNhat, conn, transaction))
                    {
                        cmdCapNhat.Parameters.Add(
                            "@SoLuong", SqlDbType.Int).Value = soLuong;

                        cmdCapNhat.Parameters.Add(
                            "@MaSP", SqlDbType.Int).Value = maSP;

                        cmdCapNhat.Parameters.Add(
                            "@NgayTon", SqlDbType.Date).Value = ngayHoaDon;

                        cmdCapNhat.ExecuteNonQuery();
                    }

                    // Lưu tất cả các thay đổi.
                    transaction.Commit();

                    MessageBox.Show("Thêm sản phẩm vào hóa đơn thành công!");

                    txtSoLuong.Clear();
                    cboSanPham.SelectedIndex = -1;

                    // Hiển thị chi tiết hóa đơn sau khi thêm.
                    LoadChiTietHoaDon();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi bán hàng: " + ex.Message);
            }
        }

        private void LoadChiTietHoaDon()
        {
            lvChiTiet.Items.Clear();

            if (!maHoaDonHienTai.HasValue)
                return;

            using SqlConnection conn =
                new SqlConnection(connectionString);

            string sql = @"
                SELECT
                    ct.MaSP,
                    sp.TenSP,
                    ct.SoLuong
                FROM CHITIET_HOADON ct
                INNER JOIN SANPHAM sp
                    ON ct.MaSP = sp.MaSP
                WHERE ct.MaHD = @MaHD
                ORDER BY ct.MaSP";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@MaHD", SqlDbType.Int)
                .Value = maHoaDonHienTai.Value;

            conn.Open();

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item =
                    new ListViewItem(reader["MaSP"].ToString());

                item.SubItems.Add(reader["TenSP"].ToString());
                item.SubItems.Add(reader["SoLuong"].ToString());

                lvChiTiet.Items.Add(item);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (!maHoaDonHienTai.HasValue)
                return;

            DialogResult chon = MessageBox.Show(
                "Bạn có muốn hủy toàn bộ hóa đơn này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (chon != DialogResult.Yes)
                return;

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                conn.Open();

                using SqlTransaction transaction =
                    conn.BeginTransaction();

                try
                {
                    int maHD = maHoaDonHienTai.Value;

                    // Khóa và kiểm tra hóa đơn chưa thanh toán.
                    string sqlKiemTra = @"
                        SELECT COUNT(*)
                        FROM HOADON WITH (UPDLOCK, HOLDLOCK)
                        WHERE MaHD = @MaHD
                          AND TinhTrangThanhToan = 0";

                    using (SqlCommand cmd =
                        new SqlCommand(sqlKiemTra, conn, transaction))
                    {
                        cmd.Parameters.Add("@MaHD", SqlDbType.Int)
                            .Value = maHD;

                        if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Không thể hủy hóa đơn này!");
                            return;
                        }
                    }

                    // Hoàn lại số lượng đã ghi nhận bán.
                    string sqlHoanTon = @"
                        UPDATE tk
                        SET tk.SLBan = tk.SLBan - ct.SoLuong
                        FROM TONKHO tk
                        INNER JOIN CHITIET_HOADON ct
                            ON tk.MaSP = ct.MaSP
                        WHERE ct.MaHD = @MaHD
                          AND tk.NgayTon = @NgayTon";

                    using (SqlCommand cmd =
                        new SqlCommand(sqlHoanTon, conn, transaction))
                    {
                        cmd.Parameters.Add("@MaHD", SqlDbType.Int)
                            .Value = maHD;

                        cmd.Parameters.Add("@NgayTon", SqlDbType.Date)
                            .Value = ngayHoaDon;

                        cmd.ExecuteNonQuery();
                    }

                    // Xóa các chi tiết của hóa đơn.
                    string sqlXoaCT = @"
                        DELETE FROM CHITIET_HOADON
                        WHERE MaHD = @MaHD";

                    using (SqlCommand cmd =
                        new SqlCommand(sqlXoaCT, conn, transaction))
                    {
                        cmd.Parameters.Add("@MaHD", SqlDbType.Int)
                            .Value = maHD;

                        cmd.ExecuteNonQuery();
                    }

                    // Xóa hóa đơn chính.
                    string sqlXoaHD = @"
                        DELETE FROM HOADON
                        WHERE MaHD = @MaHD
                          AND TinhTrangThanhToan = 0";

                    using (SqlCommand cmd =
                        new SqlCommand(sqlXoaHD, conn, transaction))
                    {
                        cmd.Parameters.Add("@MaHD", SqlDbType.Int)
                            .Value = maHD;

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show("Đã hủy hóa đơn!");
                    DatLaiForm();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hủy hóa đơn: " + ex.Message);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (!maHoaDonHienTai.HasValue)
                return;

            try
            {
                using SqlConnection conn =
                    new SqlConnection(connectionString);

                conn.Open();

                using SqlTransaction transaction =
                    conn.BeginTransaction();

                try
                {
                    int maHD = maHoaDonHienTai.Value;

                    // Không cho thanh toán hóa đơn không có sản phẩm.
                    string sqlDem = @"
                        SELECT COUNT(*)
                        FROM CHITIET_HOADON
                        WHERE MaHD = @MaHD";

                    using (SqlCommand cmd =
                        new SqlCommand(sqlDem, conn, transaction))
                    {
                        cmd.Parameters.Add("@MaHD", SqlDbType.Int)
                            .Value = maHD;

                        int soDong = Convert.ToInt32(
                            cmd.ExecuteScalar());

                        if (soDong == 0)
                        {
                            transaction.Rollback();
                            MessageBox.Show(
                                "Hóa đơn chưa có sản phẩm!");
                            return;
                        }
                    }

                    // Đổi trạng thái thanh toán từ 0 sang 1.
                    string sqlThanhToan = @"
                        UPDATE HOADON
                        SET TinhTrangThanhToan = 1
                        WHERE MaHD = @MaHD
                          AND TinhTrangThanhToan = 0";

                    int soDongCapNhat;

                    using (SqlCommand cmd =
                        new SqlCommand(sqlThanhToan, conn, transaction))
                    {
                        cmd.Parameters.Add("@MaHD", SqlDbType.Int)
                            .Value = maHD;

                        soDongCapNhat = cmd.ExecuteNonQuery();
                    }

                    if (soDongCapNhat == 0)
                    {
                        transaction.Rollback();
                        MessageBox.Show(
                            "Hóa đơn không còn ở trạng thái chưa thanh toán!");
                        return;
                    }

                    transaction.Commit();

                    MessageBox.Show(
                        $"Thanh toán hóa đơn {maHD} thành công!");

                    DatLaiForm();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message);
            }
        }

        // Không đóng Form khi hóa đơn còn đang xử lý.
        private void FormBanHang_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            if (maHoaDonHienTai.HasValue)
            {
                MessageBox.Show(
                    "Vui lòng thanh toán hoặc hủy hóa đơn trước khi đóng Form!");

                e.Cancel = true;
            }
        }
    }
}
