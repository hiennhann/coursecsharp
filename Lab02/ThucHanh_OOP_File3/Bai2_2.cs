using System;
using System.Collections.Generic;

namespace ThucHanh_OOP_File3
{
    // Lớp PersonList quản lý nhiều người khác nhau[cite: 2]
    public class PersonList
    {
        private List<Person> danhSach;

        // Default constructor[cite: 2]
        public PersonList()
        {
            danhSach = new List<Person>();
        }

        // Copy constructor: Sao chép sâu (Deep copy) từng người một[cite: 2]
        public PersonList(PersonList other)
        {
            danhSach = new List<Person>();
            foreach (var p in other.danhSach)
            {
                // Gọi Copy Constructor của lớp Person (ở bài 1.3)
                danhSach.Add(new Person(p)); 
            }
        }

        // Bổ sung Indexer cho tiện truy xuất
        public Person this[int i]
        {
            get => danhSach[i];
            set => danhSach[i] = value;
        }

        // Thêm một Person vào danh sách[cite: 2]
        public void Add(Person x) => danhSach.Add(x);

        public void Input()
        {
            Console.Write("Nhập số lượng người: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNgười thứ {i + 1}:");
                Person p = new Person();
                p.Input();
                Add(p); // Gọi hàm Add[cite: 2]
            }
        }

        public void Output()
        {
            foreach (var p in danhSach)
            {
                p.Output();
            }
        }

        // Trả về PersonList những người còn sống[cite: 2]
        public PersonList LivingPeople()
        {
            PersonList ketQua = new PersonList();
            foreach (var p in danhSach)
            {
                if (p.IsLiving())
                {
                    ketQua.Add(p);
                }
            }
            return ketQua;
        }
    }

    public class Bai2_2
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 2.2: PERSON LIST ---");
            
            PersonList list = new PersonList();
            list.Input();
            
            Console.WriteLine("\n--- TẤT CẢ ---");
            list.Output();

            Console.WriteLine("\n--- NHỮNG NGƯỜI CÒN SỐNG ---");
            PersonList living = list.LivingPeople();
            living.Output();
        }
    }
}