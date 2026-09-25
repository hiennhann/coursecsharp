using System;

namespace ThucHanh_File2
{
    public class Bai12
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 12: XỬ LÝ CHUỖI CƠ BẢN ---");
            
            Console.Write("Nhập một chuỗi gồm nhiều từ: ");
            string s = Console.ReadLine(); //[cite: 2]

            // 1. ToLower(): Chuyển toàn bộ chuỗi sang ký tự thường[cite: 2]
            Console.WriteLine($"Chuỗi chữ thường: {s.ToLower()}");

            // 2. ToUpper(): Chuyển toàn bộ chuỗi sang ký tự in hoa[cite: 2]
            Console.WriteLine($"Chuỗi chữ hoa: {s.ToUpper()}");

            // 3. Đếm số từ trong chuỗi[cite: 2]
            // Hàm Split dùng để "băm" chuỗi thành một mảng các chuỗi con, dựa trên ký tự phân cách (ở đây là khoảng trắng ' ').
            // Thuộc tính StringSplitOptions.RemoveEmptyEntries rất quan trọng: Nó giúp loại bỏ các phần tử rỗng 
            // trong trường hợp người dùng lỡ tay gõ nhiều dấu cách liên tiếp giữa các từ.
            string[] mangTu = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            // Độ dài của mảng (Length) chính là tổng số từ đã được đếm
            Console.WriteLine($"Số từ trong chuỗi là: {mangTu.Length}");
        }
    }
}