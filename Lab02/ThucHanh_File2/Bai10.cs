using System;

namespace ThucHanh_File2
{
    public class Bai10
    {
        // Phương thức kiểm tra chuỗi đối xứng trả về kiểu bool
        public static bool KiemTraDoiXung(string s)
        {
            // Chuyển toàn bộ chuỗi về chữ thường để không phân biệt hoa/thường (VD: "Anna" -> "anna")
            s = s.ToLower();
            
            int left = 0;
            int right = s.Length - 1;
            
            // Kỹ thuật 2 con trỏ: Con trỏ left chạy từ đầu, con trỏ right chạy từ cuối ngược lại
            while (left < right)
            {
                // Nếu phát hiện 1 cặp ký tự ở 2 đầu không giống nhau, kết luận ngay là sai
                if (s[left] != s[right])
                {
                    return false; 
                }
                left++;
                right--;
            }
            
            // Vượt qua hết vòng lặp nghĩa là các cặp ký tự đều khớp
            return true;
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 10: KIỂM TRA CHUỖI ĐỐI XỨNG ---");
            Console.Write("Nhập chuỗi cần kiểm tra: ");
            string chuoi = Console.ReadLine();

            if (KiemTraDoiXung(chuoi))
            {
                Console.WriteLine($"'{chuoi}' LÀ chuỗi đối xứng.");
            }
            else
            {
                Console.WriteLine($"'{chuoi}' KHÔNG PHẢI là chuỗi đối xứng.");
            }
        }
    }
}