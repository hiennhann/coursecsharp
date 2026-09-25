using System;
using System.Collections.Generic;

namespace ThucHanh_File2
{
    public class Bai17
    {
        // 1. Sinh ngẫu nhiên mảng 2 chiều kích thước n x m trong đoạn [10, 100][cite: 1]
        public static int[,] SinhMangNgauNhien(int n, int m)
        {
            // int[,] là cú pháp khai báo mảng 2 chiều
            int[,] A = new int[n, m];
            Random rand = new Random();
            
            // Dùng 2 vòng lặp lồng nhau để duyệt qua các dòng (i) và cột (j)
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // Random.Next(10, 101) sẽ sinh số từ 10 đến 100[cite: 1]
                    A[i, j] = rand.Next(10, 101); 
                }
            }
            return A;
        }

        // 2. In mảng 2 chiều ra màn hình dưới dạng ma trận[cite: 1]
        public static void InMang2Chieu(int[,] A)
        {
            // GetLength(0) lấy số lượng dòng (n), GetLength(1) lấy số lượng cột (m)
            int rows = A.GetLength(0);
            int cols = A.GetLength(1);
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Dùng Console.Write cùng ký tự tab (\t) để các số gióng hàng thẳng nhau
                    Console.Write(A[i, j] + "\t");
                }
                Console.WriteLine(); // Xuống dòng sau khi in hết 1 dòng
            }
        }

        // 3. Trả về hai mảng: số chẵn và số lẻ bằng từ khóa 'out'[cite: 1]
        public static void PhanLoaiChanLe(int[,] A, out int[] mangChan, out int[] mangLe)
        {
            List<int> dsChan = new List<int>();
            List<int> dsLe = new List<int>();
            
            // Thuộc tính ma trận có thể dùng vòng lặp foreach để duyệt qua tất cả phần tử
            foreach (int so in A)
            {
                if (so % 2 == 0) dsChan.Add(so);
                else dsLe.Add(so);
            }
            
            mangChan = dsChan.ToArray();
            mangLe = dsLe.ToArray();
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 17: MẢNG 2 CHIỀU ---");
            
            Console.Write("Nhập số dòng (n): ");
            int n = int.Parse(Console.ReadLine());
            
            Console.Write("Nhập số cột (m): ");
            int m = int.Parse(Console.ReadLine());
            
            int[,] maTran = SinhMangNgauNhien(n, m);
            
            Console.WriteLine("\nMa trận vừa sinh ngẫu nhiên:");
            InMang2Chieu(maTran);
            
            // Gọi phương thức và hứng 2 mảng trả về
            PhanLoaiChanLe(maTran, out int[] chan, out int[] le);
            
            Console.WriteLine($"\nMảng các số chẵn: {string.Join(", ", chan)}");
            Console.WriteLine($"Mảng các số lẻ: {string.Join(", ", le)}");
        }
    }
}