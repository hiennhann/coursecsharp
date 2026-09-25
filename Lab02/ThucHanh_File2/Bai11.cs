using System;

namespace ThucHanh_File2
{
    public class Bai11
    {
        // Phương thức thành viên trả về chuỗi đã bị đảo[cite: 2]
        public static string DaoChuoi(string s)
        {
            // LƯU Ý QUAN TRỌNG: Chuỗi (string) trong C# là kiểu dữ liệu "bất biến" (immutable).
            // Bạn không thể sửa trực tiếp ký tự bên trong nó.
            // Do đó, ta phải bẻ chuỗi đó thành một mảng các ký tự rời rạc (char array) để thao tác.
            char[] mangKyTu = s.ToCharArray();
            
            // Lớp Array trong C# cung cấp sẵn hàm Reverse để đảo ngược vị trí các phần tử trong mảng
            Array.Reverse(mangKyTu);
            
            // Lắp ráp mảng ký tự đã đảo ngược thành một chuỗi (string) hoàn toàn mới và trả về
            return new string(mangKyTu);
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 11: ĐẢO NGƯỢC CHUỖI ---");
            Console.Write("Nhập một chuỗi bất kỳ: ");
            string chuoi = Console.ReadLine();

            string chuoiDao = DaoChuoi(chuoi);
            Console.WriteLine($"Chuỗi sau khi đảo ngược là: {chuoiDao}");
        }
    }
}