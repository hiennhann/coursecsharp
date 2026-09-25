using System;

namespace ThucHanh_File2
{
    public class Bai09
    {
        // Từ khóa 'out' dùng để hàm có thể trả về nhiều kết quả cùng lúc (min và max).
        // QUY TẮC CỦA OUT: Biến truyền vào không cần có giá trị trước. 
        // Tuy nhiên, BẮT BUỘC phải gán giá trị cho biến 'out' ở bên trong thân hàm trước khi hàm kết thúc.
        public static void TimMinMax(double a, double b, double c, out double min, out double max)
        {
            min = Math.Min(a, Math.Min(b, c));
            max = Math.Max(a, Math.Max(b, c));
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 9: TÌM MIN MAX BẰNG OUT ---");
            
            double a = 3.5, b = -1.2, c = 8.9;
            
            // Có thể khai báo biến 'out' trực tiếp ngay bên trong tham số gọi hàm (tính năng của C# mới)
            TimMinMax(a, b, c, out double minGiaTri, out double maxGiaTri);
            
            Console.WriteLine($"Dãy số: {a}, {b}, {c}");
            Console.WriteLine($"Giá trị nhỏ nhất (min): {minGiaTri}");
            Console.WriteLine($"Giá trị lớn nhất (max): {maxGiaTri}");
        }
    }
}