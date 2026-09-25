using System;

namespace ThucHanh_OOP_File3
{
    // Xây dựng lớp Phân số
    public class PhanSo
    {
        public int TuSo { get; set; }
        public int MauSo { get; set; }

        // Constructor mặc định và khởi tạo (gộp chung bằng default parameter)
        public PhanSo(int tu = 0, int mau = 1)
        {
            if (mau == 0) throw new ArgumentException("Mẫu số không được bằng 0!");
            
            // Ép mẫu số luôn dương để tiện so sánh và rút gọn sau này
            TuSo = mau < 0 ? -tu : tu;
            MauSo = mau < 0 ? -mau : mau;
            RutGon();
        }

        // Copy Constructor[cite: 2]
        public PhanSo(PhanSo p) : this(p.TuSo, p.MauSo) { }

        // Hàm hỗ trợ tìm Ước chung lớn nhất (UCLN) để rút gọn
        private void RutGon()
        {
            int a = Math.Abs(TuSo);
            int b = Math.Abs(MauSo);
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            int ucln = a == 0 ? 1 : a;
            TuSo /= ucln;
            MauSo /= ucln;
        }

        // Override hàm ToString() để xuất phân số[cite: 2]
        public override string ToString()
        {
            if (TuSo == 0) return "0";
            if (MauSo == 1) return $"{TuSo}";
            return $"{TuSo}/{MauSo}";
        }

        // --- ĐA NĂNG TOÁN TỬ MỘT NGÔI ---
        public static PhanSo operator +(PhanSo a) => new PhanSo(a.TuSo, a.MauSo);
        public static PhanSo operator -(PhanSo a) => new PhanSo(-a.TuSo, a.MauSo);

        // --- ĐA NĂNG TOÁN TỬ HAI NGÔI ---
        public static PhanSo operator +(PhanSo a, PhanSo b) => new PhanSo(a.TuSo * b.MauSo + b.TuSo * a.MauSo, a.MauSo * b.MauSo);
        public static PhanSo operator -(PhanSo a, PhanSo b) => new PhanSo(a.TuSo * b.MauSo - b.TuSo * a.MauSo, a.MauSo * b.MauSo);
        public static PhanSo operator *(PhanSo a, PhanSo b) => new PhanSo(a.TuSo * b.TuSo, a.MauSo * b.MauSo);
        public static PhanSo operator /(PhanSo a, PhanSo b) => new PhanSo(a.TuSo * b.MauSo, a.MauSo * b.TuSo);

        // --- ĐA NĂNG TOÁN TỬ SO SÁNH ---
        // Vì mẫu số đã được ép luôn dương ở Constructor, nên ta dùng phép nhân chéo để so sánh độ lớn
        public static bool operator ==(PhanSo a, PhanSo b) => a.TuSo * b.MauSo == b.TuSo * a.MauSo;
        public static bool operator !=(PhanSo a, PhanSo b) => !(a == b);
        public static bool operator >(PhanSo a, PhanSo b) => a.TuSo * b.MauSo > b.TuSo * a.MauSo;
        public static bool operator <(PhanSo a, PhanSo b) => a.TuSo * b.MauSo < b.TuSo * a.MauSo;
        public static bool operator >=(PhanSo a, PhanSo b) => a.TuSo * b.MauSo >= b.TuSo * a.MauSo;
        public static bool operator <=(PhanSo a, PhanSo b) => a.TuSo * b.MauSo <= b.TuSo * a.MauSo;

        // C# bắt buộc override Equals và GetHashCode nếu đã overload toán tử == và !=
        public override bool Equals(object obj) => obj is PhanSo p && this == p;
        public override int GetHashCode() => HashCode.Combine(TuSo, MauSo);
    }

    public class Bai1_4
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 1.4: LỚP PHÂN SỐ ---");
            
            PhanSo p1 = new PhanSo(3, 7);
            PhanSo p2 = new PhanSo(2, 9);
            
            Console.WriteLine($"p1 = {p1}, p2 = {p2}");
            Console.WriteLine($"p1 + p2 = {p1 + p2}");
            Console.WriteLine($"p1 * p2 = {p1 * p2}");
            Console.WriteLine($"p1 có lớn hơn p2 không? {(p1 > p2 ? "Có" : "Không")}");
        }
    }
}