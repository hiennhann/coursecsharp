
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BaiTH6B
{
    public partial class FormDanhSachLop : Form
    {
        private readonly string connectionString =
            @"Data Source=NGVHNNA\SQLEXPRESS;
              Initial Catalog=QLSinhVien;
              Integrated Security=True;
              Encrypt=True;
              TrustServerCertificate=True";

        public FormDanhSachLop()
        {
            InitializeComponent();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa danh sách cũ để tránh hiển thị trùng.
                lvLop.Items.Clear();

                using SqlConnection conn =
                    new SqlConnection(connectionString);

                string sql = @"
                    SELECT MaLop, TenLop, MaKhoa
                    FROM Lop
                    ORDER BY MaLop";

                using SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();

                // SqlDataReader đọc từng dòng trong bảng Lop.
                using SqlDataReader reader = cmd.ExecuteReader();

                int stt = 1;

                while (reader.Read())
                {
                    // Tạo dòng mới cho ListView.
                    ListViewItem item =
                        new ListViewItem(stt.ToString());

                    // Thêm các cột thông tin tương ứng.
                    item.SubItems.Add(reader["MaLop"].ToString());
                    item.SubItems.Add(reader["TenLop"].ToString());
                    item.SubItems.Add(reader["MaKhoa"].ToString());

                    // Đưa dòng dữ liệu vào ListView.
                    lvLop.Items.Add(item);

                    stt++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi hiển thị dữ liệu: " + ex.Message);
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Đóng Form hiện tại.
            this.Close();
        }
    }
}
