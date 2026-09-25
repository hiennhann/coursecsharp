using System;

namespace ThucHanh_File2
{
    // Định nghĩa lớp SinhVien để đóng gói dữ liệu và hành vi của một sinh viên
    public class SinhVien
    {
        // Các thuộc tính (Properties) lưu trữ thông tin. 
        // get; set; là cú pháp viết tắt (Auto-implemented properties) giúp bảo mật dữ liệu tốt hơn là dùng biến public thông thường.
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public int NamThu { get; set; }

        // Phương thức thành viên dùng để nhập thông tin cho sinh viên[cite: 2]
        public void Nhap()
        {
            Console.Write("Nhập mã sinh viên: ");
            MaSV = Console.ReadLine();
            
            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();
            
            Console.Write("Nhập địa chỉ: ");
            DiaChi = Console.ReadLine();
            
            Console.Write("Nhập năm học thứ mấy: ");
            // Ép kiểu dữ liệu nhập vào từ chuỗi sang số nguyên
            NamThu = int.Parse(Console.ReadLine());
        }

        // Phương thức thành viên dùng để xuất thông tin ra màn hình[cite: 2]
        public void Xuat()
        {
            Console.WriteLine($"\n--- THÔNG TIN SINH VIÊN ---");
            Console.WriteLine($"Mã SV: {MaSV} | Họ tên: {HoTen}");
            Console.WriteLine($"Địa chỉ: {DiaChi} | Sinh viên năm thứ: {NamThu}");
        }
    }

    public class Bai13
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 13: LỚP SINH VIÊN ---");
            
            // Khởi tạo một đối tượng (object) mới từ lớp SinhVien
            SinhVien sv = new SinhVien();
            
            // Gọi các phương thức của đối tượng đó
            sv.Nhap();
            sv.Xuat();
        }
    }
}