using System;

namespace ThucHanh_File2
{
    public class Bai07
    {
        // Phương thức bool sẽ kết thúc ngay lập tức khi gặp từ khóa 'return'
        public static bool KiemTraNguyenTo(int n)
        {
            // Số nhỏ hơn 2 không bao giờ là số nguyên tố
            if (n < 2) return false;
            
            // Thuật toán tối ưu: Chỉ cần chạy vòng lặp kiểm tra từ 2 đến căn bậc 2 của n.
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                // Nếu n chia hết cho bất kỳ số i nào, chứng tỏ nó không phải số nguyên tố.
                if (n % i == 0) return false;
            }
            
            // Vượt qua được toàn bộ vòng lặp mà không bị chia hết thì chắc chắn là số nguyên tố
            return true; 
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 7: KIỂM TRA SỐ NGUYÊN TỐ ---");
            Console.Write("Nhập một số nguyên dương n: ");
            int n = int.Parse(Console.ReadLine());

            // Có thể bỏ hàm trả về bool trực tiếp vào biểu thức điều kiện của lệnh if
            if (KiemTraNguyenTo(n))
            {
                Console.WriteLine($"{n} là số nguyên tố.");
            }
            else
            {
                Console.WriteLine($"{n} không phải là số nguyên tố.");
            }
        }
    }
}