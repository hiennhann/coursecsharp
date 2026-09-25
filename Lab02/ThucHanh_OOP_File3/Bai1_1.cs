using System;

namespace ThucHanh_OOP_File3
{
    public class SinhVien
    {
        public string HoTen { get; set; }
        public int NamSinh { get; set; }

        public void Nhap()
        {
            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhập năm sinh: ");
            NamSinh = int.Parse(Console.ReadLine());
        }

        // Dùng DateTime.Now.Year để luôn lấy đúng năm hiện tại của hệ thống
        public int TinhTuoi()
        {
            return DateTime.Now.Year - NamSinh;
        }
    }

    public class Bai1_1
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 1.1: TÍNH TUỔI SINH VIÊN ---");
            
            SinhVien sv = new SinhVien();
            sv.Nhap();
            Console.WriteLine($"Sinh viên {sv.HoTen} hiện tại {sv.TinhTuoi()} tuổi.");
        }
    }
}