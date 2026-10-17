namespace BaiTH6A
{
    partial class FormDiem
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.Label lblMaMH;
        private System.Windows.Forms.Label lblDiem;

        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.TextBox txtDiem;

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
            lblMaSV = new System.Windows.Forms.Label();
            lblMaMH = new System.Windows.Forms.Label();
            lblDiem = new System.Windows.Forms.Label();

            txtMaSV = new System.Windows.Forms.TextBox();
            txtMaMH = new System.Windows.Forms.TextBox();
            txtDiem = new System.Windows.Forms.TextBox();

            btnThem = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();

            SuspendLayout();

            // Mã sinh viên
            lblMaSV.AutoSize = true;
            lblMaSV.Location =
                new System.Drawing.Point(30, 30);
            lblMaSV.Text = "Mã sinh viên";

            txtMaSV.Location =
                new System.Drawing.Point(140, 27);
            txtMaSV.Size =
                new System.Drawing.Size(220, 27);

            // Mã môn học
            lblMaMH.AutoSize = true;
            lblMaMH.Location =
                new System.Drawing.Point(30, 75);
            lblMaMH.Text = "Mã môn học";

            txtMaMH.Location =
                new System.Drawing.Point(140, 72);
            txtMaMH.Size =
                new System.Drawing.Size(220, 27);

            // Điểm
            lblDiem.AutoSize = true;
            lblDiem.Location =
                new System.Drawing.Point(30, 120);
            lblDiem.Text = "Điểm";

            txtDiem.Location =
                new System.Drawing.Point(140, 117);
            txtDiem.Size =
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

            Controls.Add(lblMaSV);
            Controls.Add(txtMaSV);

            Controls.Add(lblMaMH);
            Controls.Add(txtMaMH);

            Controls.Add(lblDiem);
            Controls.Add(txtDiem);

            Controls.Add(btnThem);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);

            Name = "FormDiem";

            StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            Text = "Quản lý điểm";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}