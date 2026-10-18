
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace BaiTH6B
{
    public partial class FormDanhSachDiem : Form
    {
        private readonly string connectionString =
            @"Data Source=NGVHNNA\SQLEXPRESS;
              Initial Catalog=QLSinhVien;
              Integrated Security=True;
              Encrypt=True;
              TrustServerCertificate=True";

        public FormDanhSachDiem()
        {
            InitializeComponent();
        }

        private void FormDanhSachDiem_Load(
            object sender, EventArgs e)
        {
            try
            {
                LoadMonHoc();

                // Khi mở Form hiển thị toàn bộ điểm.
                HienThiDiem("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // Đưa Mã môn học vào ComboBox.
        private void LoadMonHoc()
        {
            cboMonHoc.Items.Clear();

            // Item rỗng đại diện cho tất cả môn học.
            cboMonHoc.Items.Add("");

            using SqlConnection conn =
                new SqlConnection(connectionString);

            string sql =
                "SELECT MaMonHoc FROM MonHoc ORDER BY MaMonHoc";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cboMonHoc.Items.Add(reader["MaMonHoc"].ToString()!);
            }

            cboMonHoc.SelectedIndex = 0;
        }

        private void HienThiDiem(string maMonHoc)
        {
            lvDiem.Items.Clear();

            // JOIN ba bảng để lấy thông tin đầy đủ:
            // SinhVien: Họ tên, Ngày sinh
            // MonHoc: Tên môn học
            // Diem: Điểm
            string sql = @"
                SELECT
                    sv.HoTen,
                    sv.NgaySinh,
                    mh.TenMonHoc,
                    d.Diem
                FROM Diem d
                INNER JOIN SinhVien sv
                    ON d.MaSinhVien = sv.MaSinhVien
                INNER JOIN MonHoc mh
                    ON d.MaMonHoc = mh.MaMonHoc
                WHERE (@MaMH = '' OR d.MaMonHoc = @MaMH)
                ORDER BY sv.HoTen, mh.TenMonHoc";

            using SqlConnection conn =
                new SqlConnection(connectionString);

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 10)
                .Value = maMonHoc;

            conn.Open();

            using SqlDataReader reader = cmd.ExecuteReader();

            int stt = 1;
            double tongDiem = 0;

            while (reader.Read())
            {
                // Lấy thông tin từng cột.
                string tenSV = reader["HoTen"].ToString()!;

                DateTime ngaySinh =
                    Convert.ToDateTime(reader["NgaySinh"]);

                string tenMonHoc =
                    reader["TenMonHoc"].ToString()!;

                double diem =
                    Convert.ToDouble(reader["Diem"]);

                // Tạo dòng dữ liệu cho ListView.
                ListViewItem item =
                    new ListViewItem(stt.ToString());

                item.SubItems.Add(tenSV);
                item.SubItems.Add(ngaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(tenMonHoc);
                item.SubItems.Add(diem.ToString("0.##"));

                lvDiem.Items.Add(item);

                // Cộng tổng điểm của những dòng đang hiển thị.
                tongDiem += diem;
                stt++;
            }

            // Hiển thị tổng điểm lên TextBox.
            txtTongDiem.Text =
                tongDiem.ToString("0.##", CultureInfo.CurrentCulture);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                // Chọn chuỗi rỗng nghĩa là xem tất cả môn học.
                string maMH = cboMonHoc.SelectedItem?.ToString() ?? "";

                HienThiDiem(maMH);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc dữ liệu: " + ex.Message);
            }
        }
    }
}
