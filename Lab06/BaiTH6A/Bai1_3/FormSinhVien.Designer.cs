namespace BaiTH6A
{
    partial class FormSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblNgaySinh;

        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtNgaySinh;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMaLop = new System.Windows.Forms.Label();
            lblMaSV = new System.Windows.Forms.Label();
            lblHoTen = new System.Windows.Forms.Label();
            lblNgaySinh = new System.Windows.Forms.Label();

            txtMaLop = new System.Windows.Forms.TextBox();
            txtMaSV = new System.Windows.Forms.TextBox();
            txtHoTen = new System.Windows.Forms.TextBox();
            txtNgaySinh = new System.Windows.Forms.TextBox();

            btnThem = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();

            SuspendLayout();

            // Mã lớp
            lblMaLop.AutoSize = true;
            lblMaLop.Location =
                new System.Drawing.Point(30, 30);
            lblMaLop.Text = "Mã lớp";

            txtMaLop.Location =
                new System.Drawing.Point(140, 27);
            txtMaLop.Size =
                new System.Drawing.Size(220, 27);

            // Mã sinh viên
            lblMaSV.AutoSize = true;
            lblMaSV.Location =
                new System.Drawing.Point(30, 75);
            lblMaSV.Text = "Mã sinh viên";

            txtMaSV.Location =
                new System.Drawing.Point(140, 72);
            txtMaSV.Size =
                new System.Drawing.Size(220, 27);

            // Họ tên
            lblHoTen.AutoSize = true;
            lblHoTen.Location =
                new System.Drawing.Point(30, 120);
            lblHoTen.Text = "Họ tên";

            txtHoTen.Location =
                new System.Drawing.Point(140, 117);
            txtHoTen.Size =
                new System.Drawing.Size(220, 27);

            // Ngày sinh
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location =
                new System.Drawing.Point(30, 165);
            lblNgaySinh.Text = "Ngày sinh";

            txtNgaySinh.Location =
                new System.Drawing.Point(140, 162);
            txtNgaySinh.Size =
                new System.Drawing.Size(220, 27);

            txtNgaySinh.PlaceholderText =
                "dd/MM/yyyy";

            // Button Thêm
            btnThem.Location =
                new System.Drawing.Point(45, 220);
            btnThem.Size =
                new System.Drawing.Size(90, 38);
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;

            // Button Xóa
            btnXoa.Location =
                new System.Drawing.Point(155, 220);
            btnXoa.Size =
                new System.Drawing.Size(90, 38);
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;

            // Button Sửa
            btnSua.Location =
                new System.Drawing.Point(265, 220);
            btnSua.Size =
                new System.Drawing.Size(90, 38);
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;

            // Form
            AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 20F);

            AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            ClientSize =
                new System.Drawing.Size(405, 300);

            Controls.Add(lblMaLop);
            Controls.Add(txtMaLop);

            Controls.Add(lblMaSV);
            Controls.Add(txtMaSV);

            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);

            Controls.Add(lblNgaySinh);
            Controls.Add(txtNgaySinh);

            Controls.Add(btnThem);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);

            Name = "FormSinhVien";

            StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            Text = "Quản lý sinh viên";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}