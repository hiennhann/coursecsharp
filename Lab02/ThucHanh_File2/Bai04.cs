using System;

namespace ThucHanh_File2
{
    public class Bai04
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 4 ---");
            Console.Write("Nhap so nguyen x: ");
            
            // int.TryParse sẽ cố gắng chuyển chuỗi thành số.
            // Nếu thành công: Trả về true, đồng thời đẩy kết quả vào biến x (nhờ từ khóa 'out').
            // Nếu thất bại (người dùng nhập chữ): Trả về false, chương trình không bị crash.
            // Dấu '!' phía trước nghĩa là "Nếu không thành công" (phủ định).
            if (!int.TryParse(Console.ReadLine(), out int x))
            {
                // Thông báo lỗi và dùng lệnh 'return' để kết thúc hàm Main ngay lập tức, không chạy tiếp xuống dưới.
                Console.WriteLine("Loi: x khong phai la so nguyen!");
                return;
            }

            Console.Write("Nhap so nguyen y: ");
            if (!int.TryParse(Console.ReadLine(), out int y))
            {
                Console.WriteLine("Loi: y khong phai la so nguyen!");
                return;
            }

            Console.WriteLine($"Ket qua {x} mu {y} la: {Math.Pow(x, y)}");
        }
    }
}