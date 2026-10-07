using System.Drawing;
using System.Windows.Forms;

namespace BaiTH4C
{
    partial class FormMayTinh
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private TextBox txtDisplay;
        private Button btn1, btn2, btn3, btn4;
        private Button btn5, btn6, btn7, btn8;
        private Button btn9, btn0, btnBang, btnC;
        private Button btnCong, btnTru, btnNhan, btnChia;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.txtDisplay = new TextBox();
            
            this.btn1 = new Button(); this.btn2 = new Button(); this.btn3 = new Button(); this.btn4 = new Button();
            this.btn5 = new Button(); this.btn6 = new Button(); this.btn7 = new Button(); this.btn8 = new Button();
            this.btn9 = new Button(); this.btn0 = new Button(); this.btnBang = new Button(); this.btnC = new Button();
            this.btnCong = new Button(); this.btnTru = new Button(); this.btnNhan = new Button(); this.btnChia = new Button();

            this.SuspendLayout();

            // Tiêu đề
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Times New Roman", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Red;
            this.lblTitle.Location = new Point(25, 10);
            this.lblTitle.Text = "Máy Tính Bỏ Túi";

            // Màn hình hiển thị
            this.txtDisplay.Location = new Point(20, 50);
            this.txtDisplay.Size = new Size(220, 30);
            this.txtDisplay.Font = new Font("Arial", 14F, FontStyle.Bold);
            this.txtDisplay.ForeColor = Color.Blue;
            this.txtDisplay.TextAlign = HorizontalAlignment.Right; // Chữ căn lề phải
            this.txtDisplay.ReadOnly = true;
            this.txtDisplay.Text = "0";
            this.txtDisplay.BackColor = Color.White;

            // --- Cấu hình 16 Nút Bấm ---
            int w = 50, h = 40, space = 6;
            int col1 = 20, col2 = col1 + w + space, col3 = col2 + w + space, col4 = col3 + w + space;
            int row1 = 100, row2 = row1 + h + space, row3 = row2 + h + space, row4 = row3 + h + space;
            Font btnFont = new Font("Arial", 12F, FontStyle.Regular);

            // Hàng 1: 1 2 3 4
            SetupButton(this.btn1, "1", col1, row1, w, h, btnFont, btnNumber_Click);
            SetupButton(this.btn2, "2", col2, row1, w, h, btnFont, btnNumber_Click);
            SetupButton(this.btn3, "3", col3, row1, w, h, btnFont, btnNumber_Click);
            SetupButton(this.btn4, "4", col4, row1, w, h, btnFont, btnNumber_Click);

            // Hàng 2: 5 6 7 8
            SetupButton(this.btn5, "5", col1, row2, w, h, btnFont, btnNumber_Click);
            SetupButton(this.btn6, "6", col2, row2, w, h, btnFont, btnNumber_Click);
            SetupButton(this.btn7, "7", col3, row2, w, h, btnFont, btnNumber_Click);
            SetupButton(this.btn8, "8", col4, row2, w, h, btnFont, btnNumber_Click);

            // Hàng 3: 9 0 = C
            SetupButton(this.btn9, "9", col1, row3, w, h, btnFont, btnNumber_Click);
            SetupButton(this.btn0, "0", col2, row3, w, h, btnFont, btnNumber_Click);
            SetupButton(this.btnBang, "=", col3, row3, w, h, btnFont, btnBang_Click);
            SetupButton(this.btnC, "C", col4, row3, w, h, btnFont, btnXoa_Click);

            // Hàng 4: + - * /
            SetupButton(this.btnCong, "+", col1, row4, w, h, btnFont, btnOperator_Click);
            SetupButton(this.btnTru, "-", col2, row4, w, h, btnFont, btnOperator_Click);
            SetupButton(this.btnNhan, "*", col3, row4, w, h, btnFont, btnOperator_Click);
            SetupButton(this.btnChia, "/", col4, row4, w, h, btnFont, btnOperator_Click);

            // Form
            this.ClientSize = new Size(260, 310);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtDisplay);
            this.Name = "FormMayTinh";
            this.Text = "Máy Tính Bỏ Túi";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Hàm hỗ trợ vẽ nút bấm nhanh gọn
        private void SetupButton(Button btn, string text, int x, int y, int w, int h, Font f, System.EventHandler clickEvent)
        {
            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Size = new Size(w, h);
            btn.Font = f;
            btn.Click += clickEvent;
            this.Controls.Add(btn);
        }
    }
}