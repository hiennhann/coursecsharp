using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5C
{
    partial class FormTuDien
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl tabTuDien;
        private TabPage tabAnhViet, tabVietAnh;
        
        // Controls cho tab Anh - Việt
        private Label lblTiengAnh1, lblTiengViet1;
        private ComboBox cboAnhViet;
        private TextBox txtNghiaViet;

        // Controls cho tab Việt - Anh
        private Label lblTiengViet2, lblTiengAnh2;
        private ComboBox cboVietAnh;
        private TextBox txtNghiaAnh;

        private Button btnThoat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabTuDien = new TabControl();
            this.tabAnhViet = new TabPage();
            this.tabVietAnh = new TabPage();
            
            this.lblTiengAnh1 = new Label();
            this.lblTiengViet1 = new Label();
            this.cboAnhViet = new ComboBox();
            this.txtNghiaViet = new TextBox();

            this.lblTiengViet2 = new Label();
            this.lblTiengAnh2 = new Label();
            this.cboVietAnh = new ComboBox();
            this.txtNghiaAnh = new TextBox();

            this.btnThoat = new Button();

            this.tabTuDien.SuspendLayout();
            this.tabAnhViet.SuspendLayout();
            this.tabVietAnh.SuspendLayout();
            this.SuspendLayout();

            // 1. TabControl (Vùng chứa 2 tab)
            this.tabTuDien.Location = new Point(20, 20);
            this.tabTuDien.Size = new Size(500, 360);
            this.tabTuDien.Controls.Add(this.tabAnhViet);
            this.tabTuDien.Controls.Add(this.tabVietAnh);

            // ==========================================
            // 2. TAB ANH - VIỆT
            // ==========================================
            this.tabAnhViet.Text = "ANH - VIỆT";
            this.tabAnhViet.BackColor = Color.WhiteSmoke;

            this.lblTiengAnh1.Text = "Tiếng Anh"; this.lblTiengAnh1.Location = new Point(20, 20); this.lblTiengAnh1.AutoSize = true;
            this.lblTiengViet1.Text = "Tiếng Việt"; this.lblTiengViet1.Location = new Point(240, 20); this.lblTiengViet1.AutoSize = true;

            // ComboBox giao diện Simple (Luôn mở danh sách)
            this.cboAnhViet.Location = new Point(20, 45);
            this.cboAnhViet.Size = new Size(200, 280);
            this.cboAnhViet.DropDownStyle = ComboBoxStyle.Simple; 
            this.cboAnhViet.AutoCompleteMode = AutoCompleteMode.SuggestAppend; // Gợi ý từ
            this.cboAnhViet.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cboAnhViet.KeyDown += new KeyEventHandler(this.cboAnhViet_KeyDown);
            this.cboAnhViet.SelectedIndexChanged += new System.EventHandler(this.cboAnhViet_SelectedIndexChanged);
            // Ô hiển thị nghĩa
            this.txtNghiaViet.Location = new Point(240, 45);
            this.txtNghiaViet.Size = new Size(230, 280);
            this.txtNghiaViet.Multiline = true; // Cho phép xuống dòng
            this.txtNghiaViet.ReadOnly = true;
            this.txtNghiaViet.BackColor = Color.White;

            this.tabAnhViet.Controls.Add(this.lblTiengAnh1); this.tabAnhViet.Controls.Add(this.lblTiengViet1);
            this.tabAnhViet.Controls.Add(this.cboAnhViet); this.tabAnhViet.Controls.Add(this.txtNghiaViet);

            // ==========================================
            // 3. TAB VIỆT - ANH
            // ==========================================
            this.tabVietAnh.Text = "VIỆT - ANH";
            this.tabVietAnh.BackColor = Color.WhiteSmoke;

            this.lblTiengViet2.Text = "Tiếng Việt"; this.lblTiengViet2.Location = new Point(20, 20); this.lblTiengViet2.AutoSize = true;
            this.lblTiengAnh2.Text = "Tiếng Anh"; this.lblTiengAnh2.Location = new Point(240, 20); this.lblTiengAnh2.AutoSize = true;

            this.cboVietAnh.Location = new Point(20, 45);
            this.cboVietAnh.Size = new Size(200, 280);
            this.cboVietAnh.DropDownStyle = ComboBoxStyle.Simple;
            this.cboVietAnh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboVietAnh.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cboVietAnh.KeyDown += new KeyEventHandler(this.cboVietAnh_KeyDown);
            this.cboVietAnh.SelectedIndexChanged += new System.EventHandler(this.cboVietAnh_SelectedIndexChanged);
            this.txtNghiaAnh.Location = new Point(240, 45);
            this.txtNghiaAnh.Size = new Size(230, 280);
            this.txtNghiaAnh.Multiline = true;
            this.txtNghiaAnh.ReadOnly = true;
            this.txtNghiaAnh.BackColor = Color.White;

            this.tabVietAnh.Controls.Add(this.lblTiengViet2); this.tabVietAnh.Controls.Add(this.lblTiengAnh2);
            this.tabVietAnh.Controls.Add(this.cboVietAnh); this.tabVietAnh.Controls.Add(this.txtNghiaAnh);

            // Nút Thoát
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Location = new Point(420, 395);
            this.btnThoat.Size = new Size(100, 35);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // Form
            this.ClientSize = new Size(540, 450);
            this.Text = "TỪ ĐIỂN ANH VIỆT - VIỆT ANH";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Controls.Add(this.tabTuDien);
            this.Controls.Add(this.btnThoat);
            this.Load += new System.EventHandler(this.FormTuDien_Load);

            this.tabTuDien.ResumeLayout(false);
            this.tabAnhViet.ResumeLayout(false);
            this.tabAnhViet.PerformLayout();
            this.tabVietAnh.ResumeLayout(false);
            this.tabVietAnh.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}