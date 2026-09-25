using System;

namespace ThucHanh_File2
{
    public class Bai08
    {
        // Từ khóa 'ref' (reference) cho phép hàm thay đổi trực tiếp giá trị của biến gốc bên ngoài.
        // QUY TẮC CỦA REF: Biến truyền vào bắt buộc phải được khởi tạo (có giá trị) TỪ TRƯỚC.
        public static void HoanVi(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 8: HOÁN VỊ BẰNG REF ---");
            
            // Biến dùng cho 'ref' bắt buộc phải gán giá trị trước khi gọi hàm
            double x = 5.5; 
            double y = 10.2;
            
            Console.WriteLine($"Trước khi hoán vị: x = {x}, y = {y}");
            
            // Khi gọi hàm cũng bắt buộc phải viết kèm chữ 'ref'
            HoanVi(ref x, ref y);
            
            Console.WriteLine($"Sau khi hoán vị: x = {x}, y = {y}");
        }
    }
}