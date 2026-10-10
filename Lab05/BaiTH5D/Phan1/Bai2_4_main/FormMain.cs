using System;
using System.Windows.Forms;

namespace BaiTH5D
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        // Hàm hỗ trợ kiểm tra Form con đã mở chưa
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        // Hàm hỗ trợ active Form nếu nó đã mở sẵn
        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }

        // Gọi Bài 1: Quản lý sinh viên ListView
        private void mnuBai1_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("FormBaiTap1"))
            {
                FormBaiTap1 frm = new FormBaiTap1();
                frm.MdiParent = this; // Nhét vào trong Form Cha
                frm.Name = "FormBaiTap1";
                frm.Show();
            }
            else
            {
                ActiveChildForm("FormBaiTap1");
            }
        }

        // Gọi Bài 2: Quản lý tài khoản
        private void mnuBai2_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("FormBaiTap2"))
            {
                FormBaiTap2 frm = new FormBaiTap2();
                frm.MdiParent = this;
                frm.Name = "FormBaiTap2";
                frm.Show();
            }
            else
            {
                ActiveChildForm("FormBaiTap2");
            }
        }

        // Gọi Bài Quản lý học viên
        private void mnuBai3_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("FormQuanLyHocVien"))
            {
                FormQuanLyHocVien frm = new FormQuanLyHocVien();
                frm.MdiParent = this;
                frm.Name = "FormQuanLyHocVien";
                frm.Show();
            }
            else
            {
                ActiveChildForm("FormQuanLyHocVien");
            }
        }

        // Gọi Bài Đồng hồ
        private void mnuDongHo_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("FormDongHo"))
            {
                FormDongHo frm = new FormDongHo();
                frm.MdiParent = this;
                frm.Name = "FormDongHo";
                frm.Show();
            }
            else
            {
                ActiveChildForm("FormDongHo");
            }
        }
    }
}