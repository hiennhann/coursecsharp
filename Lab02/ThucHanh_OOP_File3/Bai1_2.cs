using System;

namespace ThucHanh_OOP_File3
{
    public class Point
    {
        // Field (dữ liệu ẩn) và Property (cổng giao tiếp)
        private double x;
        private double y;
        
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        // Constructor mặc định (Default Constructor) có tham số tùy chọn
        public Point(double x = 0, double y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public void Input()
        {
            Console.Write("Nhập tọa độ X: "); X = double.Parse(Console.ReadLine());
            Console.Write("Nhập tọa độ Y: "); Y = double.Parse(Console.ReadLine());
        }

        public void Output() => Console.WriteLine(this.ToString());

        // Override hàm ToString() của hệ thống để in ra định dạng (x, y)
        public override string ToString() => $"({X}, {Y})";

        // Đa năng toán tử (Operator Overloading)
        public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
        public static Point operator -(Point a, Point b) => new Point(a.X - b.X, a.Y - b.Y);
        public static Point operator -(Point a) => new Point(-a.X, -a.Y); // Lấy âm

        // Khoảng cách - Phương thức thành viên (gọi từ object)
        public double Distance(Point other) 
            => Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));

        // Khoảng cách - Phương thức tĩnh (gọi từ tên Class)
        public static double Distance(Point a, Point b) => a.Distance(b);

        // Trung điểm - Phương thức thành viên
        public Point Midpoint(Point other) => new Point((X + other.X) / 2, (Y + other.Y) / 2);

        // Trung điểm - Phương thức tĩnh
        public static Point Midpoint(Point a, Point b) => a.Midpoint(b);
    }

    public class Bai1_2
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 1.2: LỚP POINT ---");
            Point p1 = new Point();
            Console.WriteLine("Nhập điểm A:"); p1.Input();
            
            Point p2 = new Point();
            Console.WriteLine("Nhập điểm B:"); p2.Input();

            Console.WriteLine($"A = {p1}, B = {p2}");
            Console.WriteLine($"A + B = {p1 + p2}"); // Test toán tử +
            Console.WriteLine($"Khoảng cách AB: {Point.Distance(p1, p2)}"); // Test hàm static
        }
    }
}