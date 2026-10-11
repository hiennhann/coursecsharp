using System.Windows.Forms;
using BaiTH5C;

namespace BaiTH5D
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            ConfigureExerciseMenu();
        }

        private void ConfigureExerciseMenu()
        {
            ToolStripMenuItem menuBaiTH5C = new ToolStripMenuItem("Bài TH5C");
            menuBaiTH5C.DropDownItems.Add(CreateMenuItem("Bài 1.2 - Tìm ước số", () => OpenChildForm<FormUocSo>()));
            menuBaiTH5C.DropDownItems.Add(CreateMenuItem("Bài 1.3 - Xử lý chuỗi", () => OpenChildForm<FormChuoi>()));
            menuBaiTH5C.DropDownItems.Add(CreateMenuItem("Bài 1.4 - Từ điển", () => OpenChildForm<FormTuDien>()));
            menuBaiTH5C.DropDownItems.Add(CreateMenuItem("Bài 2.2 - Quản lý sinh viên", () => OpenChildForm<FormSinhVien>()));
            menuBaiTH5C.DropDownItems.Add(CreateMenuItem("Bài 2.4 - Xử lý ListBox", () => OpenChildForm<FormListBoxXuLy>()));
            menuBaiTH5C.DropDownItems.Add(CreateMenuItem("Bài 3.4 - Danh bạ", () => OpenChildForm<FormDanhBa>()));

            ToolStripMenuItem menuBaiTH5D = new ToolStripMenuItem("Bài TH5D");
            ToolStripMenuItem menuPhan1 = new ToolStripMenuItem("Phần 1");
            menuPhan1.DropDownItems.Add(CreateMenuItem("Bài 1.2 - Quản lý sinh viên", () => OpenChildForm<FormBaiTap1>()));
            menuPhan1.DropDownItems.Add(CreateMenuItem("Bài 1.3 - Quản lý học viên", () => OpenChildForm<FormQuanLyHocVien>()));
            menuPhan1.DropDownItems.Add(CreateMenuItem("Bài 1.4 - Đồng hồ", () => OpenChildForm<FormDongHo>()));
            menuPhan1.DropDownItems.Add(CreateMenuItem("Bài 2.2 - Quản lý tài khoản", () => OpenChildForm<FormBaiTap2>()));

            ToolStripMenuItem menuPhan2 = new ToolStripMenuItem("Phần 2");
            menuPhan2.DropDownItems.Add(CreateMenuItem("Bài 1.2 - Quản lý môn học", () => OpenChildForm<FormMonHoc>()));
            menuPhan2.DropDownItems.Add(CreateMenuItem("Bài 1.3 - Quản lý sinh viên (ADO)", () => OpenChildForm<FormSinhVienADO>()));
            menuPhan2.DropDownItems.Add(CreateMenuItem("Bài 1.4 - Quản lý lớp (ADO)", () => OpenChildForm<FormLopADO>()));
            menuPhan2.DropDownItems.Add(CreateMenuItem("Bài 2.3 - Quản lý điểm (ADO)", () => OpenChildForm<FormDiemADO>()));

            menuBaiTH5D.DropDownItems.Add(menuPhan1);
            menuBaiTH5D.DropDownItems.Add(menuPhan2);

            menuStrip1.Items.Add(menuBaiTH5C);
            menuStrip1.Items.Add(menuBaiTH5D);
        }

        private static ToolStripMenuItem CreateMenuItem(string text, Action openForm)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(text);
            menuItem.Click += (_, _) => openForm();
            return menuItem;
        }

        private void OpenChildForm<TForm>() where TForm : Form, new()
        {
            foreach (Form child in MdiChildren)
            {
                if (child is TForm)
                {
                    child.Activate();
                    return;
                }
            }

            TForm form = new TForm
            {
                MdiParent = this
            };
            form.Show();
        }
    }
}