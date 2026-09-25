using System;
using System.Collections.Generic;

namespace ThucHanh_File2
{
    public class Bai15
    {
        // 1. Phương thức nhập mảng gồm n phần tử
        public static int[] NhapMang()
        {
            Console.Write("Nhập số lượng phần tử của mảng (n): ");
            int n = int.Parse(Console.ReadLine());
            
            // Khởi tạo mảng số nguyên với kích thước n
            int[] mang = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập phần tử thứ {i}: ");
                mang[i] = int.Parse(Console.ReadLine());
            }
            return mang;
        }

        // 2. Phương thức in mảng ra màn hình
        public static void InMang(int[] mang)
        {
            // Dùng string.Join để in nhanh các phần tử cách nhau bởi dấu phẩy
            Console.WriteLine("Các phần tử trong mảng: " + string.Join(", ", mang));
        }

        // 3. Phương thức tìm phần tử lớn nhất và nhỏ nhất[cite: 1]
        // Sử dụng từ khóa 'out' để trả về 2 kết quả cùng lúc
        public static void TimMinMax(int[] mang, out int min, out int max)
        {
            min = mang[0];
            max = mang[0];
            
            foreach (int so in mang)
            {
                if (so < min) min = so;
                if (so > max) max = so;
            }
        }

        // Phương thức phụ hỗ trợ kiểm tra số nguyên tố
        private static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }

        // 4. Phương thức trả về mảng các số nguyên tố[cite: 1]
        public static int[] LayMangSoNguyenTo(int[] mang)
        {
            // Dùng List (danh sách động) vì ta chưa biết trước có bao nhiêu số nguyên tố
            List<int> danhSachSNT = new List<int>();
            
            foreach (int so in mang)
            {
                if (IsPrime(so))
                {
                    danhSachSNT.Add(so);
                }
            }
            // Chuyển List về lại kiểu mảng tĩnh (Array) để trả về
            return danhSachSNT.ToArray();
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 15: MẢNG 1 CHIỀU ---");
            
            int[] mang = NhapMang();
            InMang(mang);
            
            TimMinMax(mang, out int min, out int max);
            Console.WriteLine($"\nGiá trị nhỏ nhất: {min}");
            Console.WriteLine($"Giá trị lớn nhất: {max}");
            
            int[] mangSNT = LayMangSoNguyenTo(mang);
            Console.WriteLine("\nMảng các số nguyên tố:");
            InMang(mangSNT);
        }
    }
}