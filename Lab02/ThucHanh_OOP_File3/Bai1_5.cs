using System;

namespace ThucHanh_OOP_File3
{
    // Xây dựng lớp Đơn thức[cite: 2]
    public class DonThuc
    {
        public double HeSoA { get; set; }
        public int SoMuN { get; set; } // Phải là số nguyên không âm[cite: 2]

        public DonThuc(double a = 0, int n = 0)
        {
            HeSoA = a;
            SoMuN = Math.Max(0, n); // Chặn đứng trường hợp n âm
        }

        // Tính giá trị P(x) = a * x^n[cite: 2]
        public double TinhGiaTri(double x)
        {
            return HeSoA * Math.Pow(x, SoMuN);
        }

        // Đạo hàm Q(x) = a*n * x^(n-1)[cite: 2]
        public DonThuc DaoHam()
        {
            // Nếu là hằng số (n=0), đạo hàm ra 0
            if (SoMuN == 0) return new DonThuc(0, 0);
            
            // Nếu không, áp dụng công thức đạo hàm cơ bản
            return new DonThuc(HeSoA * SoMuN, SoMuN - 1);
        }

        public override string ToString()
        {
            if (HeSoA == 0) return "0";
            if (SoMuN == 0) return $"{HeSoA}";
            if (SoMuN == 1) return $"{HeSoA}x";
            return $"{HeSoA}x^{SoMuN}";
        }
    }

    public class Bai1_5
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 1.5: ĐƠN THỨC ---");
            
            // Đơn thức P(x) = 3x^2
            DonThuc p = new DonThuc(3, 2);
            Console.WriteLine($"P(x) = {p}");
            
            double x = 2;
            Console.WriteLine($"Tại x = {x}, P({x}) = {p.TinhGiaTri(x)}");

            // Đạo hàm
            DonThuc q = p.DaoHam();
            Console.WriteLine($"Đạo hàm P'(x) = Q(x) = {q}");
        }
    }
}