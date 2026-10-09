using System.Drawing;
using System.Windows.Forms;

namespace BaiTH5C
{
    partial class FormDanhBa
    {
        private System.ComponentModel.IContainer components = null;

        private TreeView trvDanhBa;
        private Label lblFirstName, lblLastName;
        private TextBox txtFirstName, txtLastName;
        private Button btnAdd, btnExit;
        private GroupBox grpNhapLieu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.trvDanhBa = new TreeView();
            this.grpNhapLieu = new GroupBox();
            this.lblFirstName = new Label();
            this.txtFirstName = new TextBox();
            this.lblLastName = new Label();
            this.txtLastName = new TextBox();
            this.btnAdd = new Button();
            this.btnExit = new Button();

            this.grpNhapLieu.SuspendLayout();
            this.SuspendLayout();

            // Cây danh bạ bên trái
            this.trvDanhBa.Location = new Point(20, 20);
            this.trvDanhBa.Size = new Size(250, 420);
            this.trvDanhBa.Font = new Font("Arial", 10F);

            // Khung nhập liệu bên phải
            this.grpNhapLieu.Location = new Point(290, 20);
            this.grpNhapLieu.Size = new Size(320, 180);
            this.grpNhapLieu.BackColor = Color.WhiteSmoke;

            this.lblFirstName.Text = "First Name"; this.lblFirstName.Location = new Point(20, 35); this.lblFirstName.AutoSize = true;
            this.txtFirstName.Location = new Point(100, 32); this.txtFirstName.Size = new Size(190, 22);

            this.lblLastName.Text = "Last Name"; this.lblLastName.Location = new Point(20, 75); this.lblLastName.AutoSize = true;
            this.txtLastName.Location = new Point(100, 72); this.txtLastName.Size = new Size(190, 22);

            this.btnAdd.Text = "Add"; this.btnAdd.Location = new Point(190, 120); this.btnAdd.Size = new Size(100, 30);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.grpNhapLieu.Controls.Add(this.lblFirstName); this.grpNhapLieu.Controls.Add(this.txtFirstName);
            this.grpNhapLieu.Controls.Add(this.lblLastName); this.grpNhapLieu.Controls.Add(this.txtLastName);
            this.grpNhapLieu.Controls.Add(this.btnAdd);

            // Nút Exit
            this.btnExit.Text = "Exit"; this.btnExit.Location = new Point(480, 220); this.btnExit.Size = new Size(100, 35);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // Form
            this.ClientSize = new Size(640, 460);
            this.Text = "frmBTVN2 - Danh Bạ";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormDanhBa_Load);

            this.Controls.Add(this.trvDanhBa);
            this.Controls.Add(this.grpNhapLieu);
            this.Controls.Add(this.btnExit);

            this.grpNhapLieu.ResumeLayout(false);
            this.grpNhapLieu.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}