using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5D
{
    partial class FormBaiTap1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblHoTen, lblMaSV, lblGioiTinh, lblNgoaiNgu, lblDanToc;
        private TextBox txtHoTen, txtMaSV;
        private RadioButton rdoNam, rdoNu;
        private CheckBox chkAnh, chkPhap, chkHoa;
        private ComboBox cboDanToc;
        private ListView lstvSinhVien;
        private ColumnHeader colHoTen, colMaSV, colGioiTinh, colNgoaiNgu, colDanToc;
        private Button btnThem, btnXoa, btnSua;
        private ContextMenuStrip ctxMenu;
        private ToolStripMenuItem mnuXoa;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblHoTen = new Label(); this.lblMaSV = new Label();
            this.lblGioiTinh = new Label(); this.lblNgoaiNgu = new Label(); this.lblDanToc = new Label();
            this.txtHoTen = new TextBox(); this.txtMaSV = new TextBox();
            this.rdoNam = new RadioButton(); this.rdoNu = new RadioButton();
            this.chkAnh = new CheckBox(); this.chkPhap = new CheckBox(); this.chkHoa = new CheckBox();
            this.cboDanToc = new ComboBox();
            
            this.lstvSinhVien = new ListView();
            this.colHoTen = new ColumnHeader(); this.colMaSV = new ColumnHeader();
            this.colGioiTinh = new ColumnHeader(); this.colNgoaiNgu = new ColumnHeader(); this.colDanToc = new ColumnHeader();
            
            this.btnThem = new Button(); this.btnXoa = new Button(); this.btnSua = new Button();
            
            this.ctxMenu = new ContextMenuStrip(this.components);
            this.mnuXoa = new ToolStripMenuItem();

            this.SuspendLayout();

            // Form
            this.ClientSize = new Size(650, 500);
            this.Text = "frmBaitap1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormBaiTap1_Load);
            this.FormClosing += new FormClosingEventHandler(this.FormBaiTap1_FormClosing);

            // Nhập liệu
            this.lblHoTen.Text = "Họ và Tên"; this.lblHoTen.Location = new Point(40, 30); this.lblHoTen.AutoSize = true;
            this.txtHoTen.Location = new Point(140, 27); this.txtHoTen.Size = new Size(250, 22);

            this.lblMaSV.Text = "Mã sinh viên"; this.lblMaSV.Location = new Point(40, 70); this.lblMaSV.AutoSize = true;
            this.txtMaSV.Location = new Point(140, 67); this.txtMaSV.Size = new Size(250, 22);

            this.lblGioiTinh.Text = "Giới tính"; this.lblGioiTinh.Location = new Point(40, 110); this.lblGioiTinh.AutoSize = true;
            this.rdoNam.Text = "Nam"; this.rdoNam.Location = new Point(140, 108); this.rdoNam.AutoSize = true; this.rdoNam.Checked = true;
            this.rdoNu.Text = "Nữ"; this.rdoNu.Location = new Point(220, 108); this.rdoNu.AutoSize = true;

            this.lblNgoaiNgu.Text = "Ngoại ngữ"; this.lblNgoaiNgu.Location = new Point(40, 150); this.lblNgoaiNgu.AutoSize = true;
            this.chkAnh.Text = "Anh"; this.chkAnh.Location = new Point(140, 148); this.chkAnh.AutoSize = true;
            this.chkPhap.Text = "Pháp"; this.chkPhap.Location = new Point(220, 148); this.chkPhap.AutoSize = true;
            this.chkHoa.Text = "Hoa"; this.chkHoa.Location = new Point(300, 148); this.chkHoa.AutoSize = true;

            this.lblDanToc.Text = "Dân tộc"; this.lblDanToc.Location = new Point(40, 190); this.lblDanToc.AutoSize = true;
            this.cboDanToc.Location = new Point(140, 187); this.cboDanToc.Size = new Size(150, 24);
            this.cboDanToc.DropDownStyle = ComboBoxStyle.DropDownList;

            // ListView
            this.lstvSinhVien.Location = new Point(20, 230);
            this.lstvSinhVien.Size = new Size(600, 200);
            this.lstvSinhVien.View = View.Details; // Hiển thị dạng bảng
            this.lstvSinhVien.FullRowSelect = true; // Chọn cả dòng
            this.lstvSinhVien.GridLines = true; // Hiển thị lưới
            this.lstvSinhVien.Columns.AddRange(new ColumnHeader[] { this.colHoTen, this.colMaSV, this.colGioiTinh, this.colNgoaiNgu, this.colDanToc });
            this.lstvSinhVien.SelectedIndexChanged += new System.EventHandler(this.lstvSinhVien_SelectedIndexChanged);
            
            // Gắn ContextMenuStrip (Menu chuột phải) vào ListView
            this.lstvSinhVien.ContextMenuStrip = this.ctxMenu;

            this.colHoTen.Text = "Họ tên"; this.colHoTen.Width = 150;
            this.colMaSV.Text = "Mã sinh viên"; this.colMaSV.Width = 100;
            this.colGioiTinh.Text = "Giới tính"; this.colGioiTinh.Width = 80;
            this.colNgoaiNgu.Text = "Ngoại ngữ"; this.colNgoaiNgu.Width = 150;
            this.colDanToc.Text = "Dân tộc"; this.colDanToc.Width = 100;

            // Nút bấm
            this.btnThem.Text = "Thêm"; this.btnThem.Location = new Point(120, 445); this.btnThem.Size = new Size(100, 35); this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa.Text = "Xóa"; this.btnXoa.Location = new Point(260, 445); this.btnXoa.Size = new Size(100, 35); this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnSua.Text = "Sửa"; this.btnSua.Location = new Point(400, 445); this.btnSua.Size = new Size(100, 35); this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // ContextMenu (Menu chuột phải)
            this.mnuXoa.Text = "Xóa sinh viên này";
            this.mnuXoa.Click += new System.EventHandler(this.btnXoa_Click); // Dùng chung sự kiện Xóa của nút
            this.ctxMenu.Items.Add(this.mnuXoa);

            // Thêm vào Form
            this.Controls.Add(this.lblHoTen); this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblMaSV); this.Controls.Add(this.txtMaSV);
            this.Controls.Add(this.lblGioiTinh); this.Controls.Add(this.rdoNam); this.Controls.Add(this.rdoNu);
            this.Controls.Add(this.lblNgoaiNgu); this.Controls.Add(this.chkAnh); this.Controls.Add(this.chkPhap); this.Controls.Add(this.chkHoa);
            this.Controls.Add(this.lblDanToc); this.Controls.Add(this.cboDanToc);
            this.Controls.Add(this.lstvSinhVien);
            this.Controls.Add(this.btnThem); this.Controls.Add(this.btnXoa); this.Controls.Add(this.btnSua);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}