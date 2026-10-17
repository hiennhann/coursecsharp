namespace BaiTH6A
{
    partial class FormLop
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblMaKhoa;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.Label lblTenLop;

        private System.Windows.Forms.TextBox txtMaKhoa;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.TextBox txtTenLop;

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
            lblMaKhoa = new System.Windows.Forms.Label();
            lblMaLop = new System.Windows.Forms.Label();
            lblTenLop = new System.Windows.Forms.Label();

            txtMaKhoa = new System.Windows.Forms.TextBox();
            txtMaLop = new System.Windows.Forms.TextBox();
            txtTenLop = new System.Windows.Forms.TextBox();

            btnThem = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();

            SuspendLayout();

            // Mã khoa
            lblMaKhoa.AutoSize = true;
            lblMaKhoa.Location =
                new System.Drawing.Point(30, 30);
            lblMaKhoa.Text = "Mã khoa";

            txtMaKhoa.Location =
                new System.Drawing.Point(140, 27);
            txtMaKhoa.Size =
                new System.Drawing.Size(220, 27);

            // Mã lớp
            lblMaLop.AutoSize = true;
            lblMaLop.Location =
                new System.Drawing.Point(30, 75);
            lblMaLop.Text = "Mã lớp";

            txtMaLop.Location =
                new System.Drawing.Point(140, 72);
            txtMaLop.Size =
                new System.Drawing.Size(220, 27);

            // Tên lớp
            lblTenLop.AutoSize = true;
            lblTenLop.Location =
                new System.Drawing.Point(30, 120);
            lblTenLop.Text = "Tên lớp";

            txtTenLop.Location =
                new System.Drawing.Point(140, 117);
            txtTenLop.Size =
                new System.Drawing.Size(220, 27);

            // Button Thêm
            btnThem.Location =
                new System.Drawing.Point(45, 175);
            btnThem.Size =
                new System.Drawing.Size(90, 38);
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;

            // Button Xóa
            btnXoa.Location =
                new System.Drawing.Point(155, 175);
            btnXoa.Size =
                new System.Drawing.Size(90, 38);
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;

            // Button Sửa
            btnSua.Location =
                new System.Drawing.Point(265, 175);
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
                new System.Drawing.Size(405, 250);

            Controls.Add(lblMaKhoa);
            Controls.Add(txtMaKhoa);

            Controls.Add(lblMaLop);
            Controls.Add(txtMaLop);

            Controls.Add(lblTenLop);
            Controls.Add(txtTenLop);

            Controls.Add(btnThem);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);

            Name = "FormLop";

            StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            Text = "Quản lý lớp";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}