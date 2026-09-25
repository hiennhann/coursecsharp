using System;
using System.Collections.Generic;

namespace ThucHanh_OOP_File3
{
    // Lớp Array Point có chức năng lưu trữ các Point
    public class ArrayPoint
    {
        // Sử dụng List<Point> an toàn kiểu dữ liệu thay vì ArrayList cổ điển
        private List<Point> points;

        public ArrayPoint()
        {
            points = new List<Point>();
        }

        public void Add(Point p) => points.Add(p);

        // Indexer cho phép truy cập Point thứ i[cite: 2]
        public Point this[int index]
        {
            get => points[index];
            set => points[index] = value;
        }
        
        public int Count => points.Count;
    }

    public class Bai2_1
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 2.1: ARRAY POINT ---");
            
            ArrayPoint arr = new ArrayPoint();
            arr.Add(new Point(1, 2));
            arr.Add(new Point(3, 4));

            // Demo Indexer: Gán và đọc dữ liệu y như thao tác với mảng
            arr[0] = new Point(10, 20); 
            Console.WriteLine($"Điểm tại vị trí 0: {arr[0]}"); 
        }
    }
}