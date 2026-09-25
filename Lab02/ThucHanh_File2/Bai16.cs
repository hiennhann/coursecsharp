using System;

namespace ThucHanh_File2
{
    public class Bai16
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 16: SẮP XẾP MẢNG HỌ TÊN ---");
            
            Console.Write("Nhập số lượng người (n): ");
            int n = int.Parse(Console.ReadLine());
            
            // Khai báo mảng kiểu chuỗi (string) để lưu họ tên[cite: 1]
            string[] danhSachHoTen = new string[n];
            
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập họ tên người thứ {i + 1}: ");
                danhSachHoTen[i] = Console.ReadLine();
            }

            // Gọi phương thức Array.Sort() có sẵn của C# để sắp xếp mảng tăng dần[cite: 1]
            Array.Sort(danhSachHoTen);

            Console.WriteLine("\n--- DANH SÁCH SAU KHI SẮP XẾP ---");
            foreach (string hoten in danhSachHoTen)
            {
                Console.WriteLine(hoten);
            }
        }
    }
}