using System;

namespace ThucHanh_OOP_File3
{
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Yob { get; set; } // Năm sinh
        public int Yod { get; set; } // Năm mất

        // Default Constructor
        public Person() { }

        // Copy Constructor: Tạo ra một bản sao (clone) từ một object Person khác
        public Person(Person other)
        {
            this.Id = other.Id;
            this.Name = other.Name;
            this.Yob = other.Yob;
            this.Yod = other.Yod;
        }

        public void Input()
        {
            Console.Write("Nhập ID: "); Id = Console.ReadLine();
            Console.Write("Nhập Tên: "); Name = Console.ReadLine();
            Console.Write("Nhập Năm sinh: "); Yob = int.Parse(Console.ReadLine());
            Console.Write("Nhập Năm mất (nếu còn sống nhập 0): "); 
            Yod = int.Parse(Console.ReadLine());
        }

        public void Output()
        {
            string status = IsLiving() ? "Còn sống" : $"Đã mất năm {Yod}";
            Console.WriteLine($"[{Id}] {Name} - Sinh năm: {Yob} - Tình trạng: {status}");
        }

        // Hàm kiểm tra sống chết dựa vào Yod
        public bool IsLiving() => Yod == 0;
    }

    public class Bai1_3
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 1.3: LỚP PERSON ---");
            
            Person p1 = new Person();
            p1.Input();
            p1.Output();

            Console.WriteLine("\n--- Test Copy Constructor ---");
            Person p2 = new Person(p1); // Clone p1 sang p2
            p2.Name = p2.Name + " (Bản sao)";
            p2.Output();
        }
    }
}