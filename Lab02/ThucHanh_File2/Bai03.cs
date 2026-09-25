using System;

namespace ThucHanh_File2
{
    public class Bai03
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 3 ---");
            
            Console.Write("Nhap so nguyen x: ");
            // Console.ReadLine() trả về chuỗi (VD: "7"). 
            // int.Parse() sẽ ép kiểu chuỗi "7" đó thành con số nguyên 7 để tính toán.
            // Nhược điểm: Nếu nhập chữ (VD: "abc"), int.Parse sẽ làm văng lỗi (Crash) chương trình ngay lập tức.
            int x = int.Parse(Console.ReadLine());
            
            Console.Write("Nhap so nguyen y: ");
            int y = int.Parse(Console.ReadLine());
            
            // Math.Pow(x, y) là hàm tính x lũy thừa y (x^y).
            Console.WriteLine($"Ket qua {x} mu {y} la: {Math.Pow(x, y)}");
        }
    }
}