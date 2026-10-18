
using System.Drawing;
using System.Windows.Forms;

namespace BaiTH6B
{
    partial class FormDanhSachDiem
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblMonHoc, lblTongDiem;
        private ComboBox cboMonHoc;
        private Button btnLoc;
        private ListView lvDiem;
        private TextBox txtTongDiem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMonHoc = new Label();
            lblTongDiem = new Label();

            cboMonHoc = new ComboBox();
            btnLoc = new Button();
            lvDiem = new ListView();
            txtTongDiem = new TextBox();

            SuspendLayout();

            // Môn học
            lblMonHoc.Text = "Môn học";
            lblMonHoc.Location = new Point(30, 30);
            lblMonHoc.AutoSize = true;

            cboMonHoc.Location = new Point(130, 27);
            cboMonHoc.Size = new Size(220, 28);
            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;

            // Nút lọc
            btnLoc.Text = "Lọc dữ liệu";
            btnLoc.Location = new Point(390, 25);
            btnLoc.Size = new Size(110, 35);
            btnLoc.Click += btnLoc_Click;

            // ListView
            lvDiem.Location = new Point(30, 85);
            lvDiem.Size = new Size(740, 330);

            lvDiem.View = View.Details;
            lvDiem.GridLines = true;
            lvDiem.FullRowSelect = true;

            lvDiem.Columns.Add("STT", 50);
            lvDiem.Columns.Add("Tên sinh viên", 180);
            lvDiem.Columns.Add("Ngày sinh", 130);
            lvDiem.Columns.Add("Tên môn học", 260);
            lvDiem.Columns.Add("Điểm", 100);

            // Tổng điểm
            lblTongDiem.Text = "Tổng điểm";
            lblTongDiem.Location = new Point(510, 440);
            lblTongDiem.AutoSize = true;

            txtTongDiem.Location = new Point(610, 437);
            txtTongDiem.Size = new Size(160, 27);
            txtTongDiem.ReadOnly = true;

            // Form
            ClientSize = new Size(810, 500);
            Text = "Danh sách điểm theo môn học";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.AddRange(new Control[]
            {
                lblMonHoc, cboMonHoc, btnLoc,
                lvDiem, lblTongDiem, txtTongDiem
            });

            Load += FormDanhSachDiem_Load;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
