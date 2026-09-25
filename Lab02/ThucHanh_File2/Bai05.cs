using System;

namespace ThucHanh_File2
{
    public class Bai05
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Khai báo sẵn x, y ở ngoài vòng lặp để các case bên trong đều dùng chung được.
            double x = 0, y = 0; 
            
            // while (true) tạo ra một vòng lặp vô hạn, giúp Menu luôn hiện lại sau khi tính toán xong.
            // Vòng lặp này chỉ dừng khi gặp lệnh 'return' hoặc 'break' đặc biệt.
            while (true)
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
                Console.WriteLine("2. Tinh x^y");
                Console.WriteLine("3. Tinh can bac 2 cua x va y");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon chuc nang: ");
                
                string chon = Console.ReadLine();
                
                // switch-case dùng để rẽ nhánh điều kiện dựa trên lựa chọn của người dùng
                switch (chon)
                {
                    case "1":
                        Console.Write("Nhap x: "); 
                        // Dùng double.TryParse để xử lý số thực (số thập phân) thay vì số nguyên int
                        double.TryParse(Console.ReadLine(), out x);
                        Console.Write("Nhap y: "); 
                        double.TryParse(Console.ReadLine(), out y);
                        break; // break dùng để thoát khỏi nhánh case này và quay lại đầu vòng lặp while
                    
                    case "2":
                        Console.WriteLine($"Ket qua {x}^{y} = {Math.Pow(x, y)}");
                        break;
                    
                    case "3":
                        // Math.Sqrt() là hàm tính căn bậc 2.
                        // Toán tử 3 ngôi (điều_kiện ? đúng : sai) là cách viết tắt của if-else.
                        // Ý nghĩa: Nếu x >= 0 thì in ra căn bậc 2, ngược lại thì báo lỗi không tính được số âm.
                        Console.WriteLine(x >= 0 ? $"Can bac 2 cua x = {Math.Sqrt(x)}" : "x am, khong tinh duoc!");
                        Console.WriteLine(y >= 0 ? $"Can bac 2 cua y = {Math.Sqrt(y)}" : "y am, khong tinh duoc!");
                        break;
                    
                    case "4":
                        // return sẽ thoát hẳn khỏi hàm Main, đồng nghĩa với việc tắt luôn chương trình.
                        return;
                    
                    default:
                        // default sẽ chạy nếu người dùng nhập số khác 1, 2, 3, 4 (VD nhập số 5 hoặc chữ)
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            }
        }
    }
}