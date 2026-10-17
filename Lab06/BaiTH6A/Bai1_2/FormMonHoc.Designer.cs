namespace BaiTH6A
{
    partial class FormMonHoc
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblMaMH;
        private System.Windows.Forms.Label lblTenMH;

        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.TextBox txtTenMH;

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
            lblMaMH = new System.Windows.Forms.Label();
            lblTenMH = new System.Windows.Forms.Label();

            txtMaMH = new System.Windows.Forms.TextBox();
            txtTenMH = new System.Windows.Forms.TextBox();

            btnThem = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();

            SuspendLayout();

            // LABEL MÃ MÔN HỌC
            lblMaMH.AutoSize = true;
            lblMaMH.Location =
                new System.Drawing.Point(30, 35);
            lblMaMH.Name = "lblMaMH";
            lblMaMH.Size = new System.Drawing.Size(92, 20);
            lblMaMH.Text = "Mã môn học";

            // TEXTBOX MÃ MÔN HỌC
            txtMaMH.Location =
                new System.Drawing.Point(140, 32);
            txtMaMH.Name = "txtMaMH";
            txtMaMH.Size =
                new System.Drawing.Size(220, 27);

            // LABEL TÊN MÔN HỌC
            lblTenMH.AutoSize = true;
            lblTenMH.Location =
                new System.Drawing.Point(30, 82);
            lblTenMH.Name = "lblTenMH";
            lblTenMH.Size = new System.Drawing.Size(96, 20);
            lblTenMH.Text = "Tên môn học";

            // TEXTBOX TÊN MÔN HỌC
            txtTenMH.Location =
                new System.Drawing.Point(140, 79);
            txtTenMH.Name = "txtTenMH";
            txtTenMH.Size =
                new System.Drawing.Size(220, 27);

            // BUTTON THÊM
            btnThem.Location =
                new System.Drawing.Point(45, 140);
            btnThem.Name = "btnThem";
            btnThem.Size =
                new System.Drawing.Size(90, 38);
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;

            // BUTTON XÓA
            btnXoa.Location =
                new System.Drawing.Point(155, 140);
            btnXoa.Name = "btnXoa";
            btnXoa.Size =
                new System.Drawing.Size(90, 38);
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;

            // BUTTON SỬA
            btnSua.Location =
                new System.Drawing.Point(265, 140);
            btnSua.Name = "btnSua";
            btnSua.Size =
                new System.Drawing.Size(90, 38);
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;

            // FORM
            AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            ClientSize =
                new System.Drawing.Size(405, 220);

            Controls.Add(lblMaMH);
            Controls.Add(txtMaMH);

            Controls.Add(lblTenMH);
            Controls.Add(txtTenMH);

            Controls.Add(btnThem);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);

            Name = "FormMonHoc";

            StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            Text = "Quản lý môn học";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}