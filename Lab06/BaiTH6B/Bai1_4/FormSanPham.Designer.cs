
using System.Drawing;
using System.Windows.Forms;

namespace BaiTH6B
{
    partial class FormSanPham
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTenSP;
        private TextBox txtTenSP;
        private Button btnThem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTenSP = new Label();
            txtTenSP = new TextBox();
            btnThem = new Button();

            SuspendLayout();

            // Tên sản phẩm.
            lblTenSP.Text = "Tên sản phẩm";
            lblTenSP.Location = new Point(30, 45);
            lblTenSP.AutoSize = true;

            txtTenSP.Location = new Point(155, 42);
            txtTenSP.Size = new Size(230, 27);

            // Nút thêm sản phẩm.
            btnThem.Text = "Thêm";
            btnThem.Location = new Point(155, 110);
            btnThem.Size = new Size(110, 40);
            btnThem.Click += btnThem_Click;

            // Form.
            ClientSize = new Size(440, 200);
            Text = "Thêm sản phẩm";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(lblTenSP);
            Controls.Add(txtTenSP);
            Controls.Add(btnThem);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
