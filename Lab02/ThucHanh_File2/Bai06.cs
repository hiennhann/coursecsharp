using System;

namespace ThucHanh_File2
{
    public class Bai06
    {
        // Phương thức nhận vào 3 số nguyên (bản sao giá trị) và trả về (return) một số nguyên.
        public static int TimMax3(int a, int b, int c)
        {
            // Math.Max chỉ so sánh được 2 số cùng lúc, nên ta lồng 2 hàm Math.Max vào nhau.
            return Math.Max(a, Math.Max(b, c));
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 6: TÌM MAX 3 SỐ ---");
            Console.Write("Nhập số a: "); int a = int.Parse(Console.ReadLine());
            Console.Write("Nhập số b: "); int b = int.Parse(Console.ReadLine());
            Console.Write("Nhập số c: "); int c = int.Parse(Console.ReadLine());

            // Gọi phương thức và lưu giá trị trả về vào biến max
            int max = TimMax3(a, b, c);
            Console.WriteLine($"Giá trị lớn nhất là: {max}");
        }
    }
}