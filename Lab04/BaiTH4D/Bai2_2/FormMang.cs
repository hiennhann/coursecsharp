using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BaiTH4D
{
    // Class lưu trữ và xử lý mảng 1 chiều theo yêu cầu
    public class Mang1Chieu
    {
        public List<int> Data { get; set; } = new List<int>();

        // Chuyển chuỗi nhập vào thành List<int>
        public bool NhapMang(string input)
        {
            Data.Clear();
            string[] items = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items)
            {
                if (int.TryParse(item, out int num))
                    Data.Add(num);
                else
                    return false; // Trả về false nếu có chữ cái
            }
            return Data.Count > 0;
        }

        public string XuatMang() => string.Join(" ", Data);

        public void SapXepTang() => Data.Sort();
        public void SapXepGiam() => Data.Sort((a, b) => b.CompareTo(a));

        public int TimViTriCuaGiaTri(int giaTri) => Data.IndexOf(giaTri);
        public int TimGiaTriTaiViTri(int viTri) => (viTri >= 0 && viTri < Data.Count) ? Data[viTri] : -1;

        public bool XoaGiaTri(int giaTri) => Data.Remove(giaTri);
        public void XoaTaiViTri(int viTri)
        {
            if (viTri >= 0 && viTri < Data.Count) Data.RemoveAt(viTri);
        }

        public void ThemGiaTri(int giaTri, int viTri)
        {
            if (viTri >= 0 && viTri <= Data.Count) Data.Insert(viTri, giaTri);
            else Data.Add(giaTri); // Nếu nhập lố vị trí, thêm vào cuối
        }

        public void ThayTheViTri(int viTri, int soMoi)
        {
            if (viTri >= 0 && viTri < Data.Count) Data[viTri] = soMoi;
        }

        public void ThayTheGiaTri(int soCu, int soMoi)
        {
            for (int i = 0; i < Data.Count; i++)
                if (Data[i] == soCu) Data[i] = soMoi;
        }

        public int Tong() => Data.Sum();
        public int TongChan() => Data.Where(x => x % 2 == 0).Sum();
        public int TongLe() => Data.Where(x => x % 2 != 0).Sum();
        public int Max() => Data.Count > 0 ? Data.Max() : 0;
        public int Min() => Data.Count > 0 ? Data.Min() : 0;
    }

    // Code xử lý Giao diện
    public partial class FormMang : Form
    {
        private Mang1Chieu mang = new Mang1Chieu();

        public FormMang()
        {
            InitializeComponent();
        }

        // Đọc mảng từ TextBox trước khi làm bất cứ việc gì
        private bool DocMang()
        {
            if (!mang.NhapMang(txtNhapMang.Text))
            {
                MessageBox.Show("Mảng nhập không hợp lệ (chỉ nhập số, cách nhau bởi khoảng trắng).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Nút "Thực Hiện" tổng hợp chung cho Sắp xếp, Tìm kiếm, Xóa, Thêm, Thay thế
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (!DocMang()) return;

            try
            {
                // 1. Nhóm Sắp Xếp
                if (rdoTang.Checked) mang.SapXepTang();
                else if (rdoGiam.Checked) mang.SapXepGiam();

                // 2. Nhóm Tìm Kiếm
                if (rdoTimGiaTri.Checked && int.TryParse(txtTimGiaTri.Text, out int giatriTim))
                {
                    int viTri = mang.TimViTriCuaGiaTri(giatriTim);
                    txtKetQuaTim.Text = viTri != -1 ? $"Vị trí {viTri}" : "Không thấy";
                }
                else if (rdoTimViTri.Checked && int.TryParse(txtTimViTri.Text, out int vitriTim))
                {
                    int kq = mang.TimGiaTriTaiViTri(vitriTim);
                    txtKetQuaTim.Text = kq != -1 ? kq.ToString() : "Lỗi VT";
                }

                // 3. Nhóm Xóa
                if (rdoXoaGiaTri.Checked && int.TryParse(txtXoaGiaTri.Text, out int giatriXoa))
                    mang.XoaGiaTri(giatriXoa);
                else if (rdoXoaViTri.Checked && int.TryParse(txtXoaViTri.Text, out int vitriXoa))
                    mang.XoaTaiViTri(vitriXoa);

                // 4. Nhóm Thêm (Không dùng radio mà dùng trực tiếp textbox)
                if (int.TryParse(txtThemGiaTri.Text, out int giaTriThem) && int.TryParse(txtThemViTri.Text, out int viTriThem))
                    mang.ThemGiaTri(giaTriThem, viTriThem);

                // 5. Nhóm Thay Thế
                if (int.TryParse(txtSoThayThe.Text, out int soMoi))
                {
                    if (rdoThayGiaTri.Checked && int.TryParse(txtThayGiaTri.Text, out int soCu))
                        mang.ThayTheGiaTri(soCu, soMoi);
                    else if (rdoThayViTri.Checked && int.TryParse(txtThayViTri.Text, out int vitriThay))
                        mang.ThayTheViTri(vitriThay, soMoi);
                }

                // Cập nhật lại TextBox Kết quả sau khi thao tác
                txtKetQuaMang.Text = mang.XuatMang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng kiểm tra lại dữ liệu nhập ở các ô chức năng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Nút Tính Tổng riêng biệt
        private void btnTong_Click(object sender, EventArgs e)
        {
            if (DocMang())
            {
                txtTongMang.Text = mang.Tong().ToString();
                txtTongChan.Text = mang.TongChan().ToString();
                txtTongLe.Text = mang.TongLe().ToString();
            }
        }

        // Nút Max-Min riêng biệt
        private void btnTimMaxMin_Click(object sender, EventArgs e)
        {
            if (DocMang())
            {
                txtMax.Text = mang.Max().ToString();
                txtMin.Text = mang.Min().ToString();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNhapMang.Clear(); txtKetQuaMang.Clear();
            txtTimGiaTri.Clear(); txtTimViTri.Clear(); txtKetQuaTim.Clear();
            txtXoaGiaTri.Clear(); txtXoaViTri.Clear();
            txtThemGiaTri.Clear(); txtThemViTri.Clear();
            txtTongMang.Clear(); txtTongChan.Clear(); txtTongLe.Clear();
            txtMax.Clear(); txtMin.Clear();
            txtThayGiaTri.Clear(); txtThayViTri.Clear(); txtSoThayThe.Clear();
            txtNhapMang.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e) => this.Close();

        private void FormMang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }
    }
}