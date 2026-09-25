using System;

namespace ThucHanh_File2
{
    public class Bai02
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 2 ---");
            Console.Write("Nhap ho ten cua ban: ");
            string hoTen = Console.ReadLine();
            
            // Ký tự '$' đứng trước chuỗi cho phép bạn nhúng trực tiếp biến vào trong cặp ngoặc nhọn { }
            // Đây là cách nối chuỗi hiện đại và dễ đọc nhất trong C#.
            Console.WriteLine($"Chao ban {hoTen}!");
        }
    }
}