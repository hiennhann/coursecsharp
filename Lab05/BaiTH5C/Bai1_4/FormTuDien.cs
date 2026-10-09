using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BaiTH5C
{
    public partial class FormTuDien : Form
    {
        // Khai báo 2 bộ từ điển ảo
        private Dictionary<string, string> dictAnhViet = new Dictionary<string, string>();
        private Dictionary<string, string> dictVietAnh = new Dictionary<string, string>();

        public FormTuDien()
        {
            InitializeComponent();
        }

        private void FormTuDien_Load(object sender, EventArgs e)
        {
            // 1. Nạp dữ liệu giả lập cho từ điển Anh - Việt
            dictAnhViet.Add("student", "Sinh viên, học sinh");
            dictAnhViet.Add("teacher", "Giáo viên");
            dictAnhViet.Add("worker", "Công nhân");
            dictAnhViet.Add("hat", "Cái mũ, nón");
            dictAnhViet.Add("head", "Cái đầu");
            dictAnhViet.Add("mouse", "Con chuột");
            dictAnhViet.Add("cat", "Con mèo");
            dictAnhViet.Add("dog", "Con chó");
            dictAnhViet.Add("snake", "Con rắn");
            dictAnhViet.Add("frog", "Con ếch");
            dictAnhViet.Add("sheep", "Con cừu");

            // 2. Nạp dữ liệu giả lập cho từ điển Việt - Anh
            dictVietAnh.Add("sinh viên", "student");
            dictVietAnh.Add("giáo viên", "teacher");
            dictVietAnh.Add("con chuột", "mouse");
            dictVietAnh.Add("con mèo", "cat");
            dictVietAnh.Add("trường học", "school");

            // 3. Đưa danh sách các từ khóa vào ComboBox tương ứng
            foreach (var item in dictAnhViet.Keys)
            {
                cboAnhViet.Items.Add(item);
            }

            foreach (var item in dictVietAnh.Keys)
            {
                cboVietAnh.Items.Add(item);
            }
        }

        // --- XỬ LÝ TAB ANH - VIỆT ---

        // Hàm tra từ Anh - Việt
        private void TraTuAnhViet()
        {
            string tuCanTra = cboAnhViet.Text.ToLower().Trim();
            if (dictAnhViet.ContainsKey(tuCanTra))
            {
                txtNghiaViet.Text = dictAnhViet[tuCanTra];
            }
            else
            {
                txtNghiaViet.Text = "Không tìm thấy từ này trong từ điển!";
            }
        }

        // Bắt sự kiện nhấn phím Enter
        private void cboAnhViet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TraTuAnhViet();
                e.SuppressKeyPress = true; // Tắt tiếng "bíp" của Windows
            }
        }

        // Bắt sự kiện click đúp chuột vào từ
        private void cboAnhViet_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraTuAnhViet();
        }


        // --- XỬ LÝ TAB VIỆT - ANH ---

        // Hàm tra từ Việt - Anh
        private void TraTuVietAnh()
        {
            string tuCanTra = cboVietAnh.Text.ToLower().Trim();
            if (dictVietAnh.ContainsKey(tuCanTra))
            {
                txtNghiaAnh.Text = dictVietAnh[tuCanTra];
            }
            else
            {
                txtNghiaAnh.Text = "Word not found in dictionary!";
            }
        }

        private void cboVietAnh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TraTuVietAnh();
                e.SuppressKeyPress = true;
            }
        }

        private void cboVietAnh_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraTuVietAnh();
        }

        // --- Thoát ---
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}