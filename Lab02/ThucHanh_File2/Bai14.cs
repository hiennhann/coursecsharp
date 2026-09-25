using System;

namespace ThucHanh_File2
{
    // Định nghĩa lớp NhanVien[cite: 2]
    public class NhanVien
    {
        // Các thuộc tính lưu trữ thông tin nhân viên[cite: 2]
        public string HoTen { get; set; }
        public double MucLuong { get; set; }
        public int SoNgayVang { get; set; }

        public void Nhap()
        {
            Console.Write("Nhập họ tên nhân viên: ");
            HoTen = Console.ReadLine();
            
            Console.Write("Nhập mức lương thỏa thuận: ");
            MucLuong = double.Parse(Console.ReadLine());
            
            Console.Write("Nhập số ngày vắng: ");
            SoNgayVang = int.Parse(Console.ReadLine());
        }

        // Phương thức tính toán và in kết quả lương[cite: 2]
        public void TinhVaXuatLuong()
        {
            // Theo yêu cầu, một ngày vắng sẽ bị trừ đi 100.000 VNĐ[cite: 2]
            double tienPhat = SoNgayVang * 100000;
            double luongThucLanh = MucLuong - tienPhat;

            Console.WriteLine($"\n--- BẢNG LƯƠNG NHÂN VIÊN ---");
            Console.WriteLine($"Nhân viên: {HoTen}");
            Console.WriteLine($"Mức lương gốc: {MucLuong:N0} VNĐ");
            Console.WriteLine($"Số ngày vắng: {SoNgayVang} (Bị trừ {tienPhat:N0} VNĐ)");
            
            // :N0 giúp định dạng số tiền có dấu phẩy phân cách hàng nghìn (ví dụ: 1,000,000)
            Console.WriteLine($"Lương thực lãnh: {luongThucLanh:N0} VNĐ");
        }
    }

    public class Bai14
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- BÀI 14: TÍNH LƯƠNG NHÂN VIÊN ---");
            
            // Khởi tạo đối tượng nhân viên và gọi các hàm xử lý
            NhanVien nv = new NhanVien();
            nv.Nhap();
            nv.TinhVaXuatLuong();
        }
    }
}