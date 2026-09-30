using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            // Gọi các hàm theo đúng tiến trình bài thực hành
            Bai21();
            Bai22();
            Bai31();
            Bai32();
            Bai51();
            Bai52();
            Bai62();
        }
        
        // Bài 2.1. Truy vấn mảng số nguyên
        static void Bai21()
        {
            Console.WriteLine("\n--- BÀI 2.1: TRUY VẤN MẢNG SỐ ---");
            int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

            Console.WriteLine("a. Phần tử chia hết cho 4 và 3:");
            var cauAQ = from s in mangSo where s % 4 == 0 && s % 3 == 0 select s; // Query Syntax
            var cauAM = mangSo.Where(s => s % 4 == 0 && s % 3 == 0); // Method Syntax
            Console.WriteLine($"   - Method Syntax: {string.Join(", ", cauAM)}");

            Console.WriteLine("b. Phần tử nhỏ hơn hoặc bằng 3:");
            Console.WriteLine($"   - Kết quả: {string.Join(", ", mangSo.Where(s => s <= 3))}");

            Console.WriteLine("c. Dãy mới (chẵn chia đôi, lẻ giữ nguyên):");
            // Toán tử 3 ngôi (condition ? true : false) để xét chẵn lẻ và biến đổi phần tử
            Console.WriteLine($"   - Kết quả: {string.Join(", ", mangSo.Select(s => s % 2 == 0 ? s / 2 : s))}");
        }

        // Bài 2.2. Truy vấn mảng chuỗi
        static void Bai22()
        {
            Console.WriteLine("\n--- BÀI 2.2: TRUY VẤN MẢNG CHUỖI ---");
            string[] mangChuoi = { "đầu", "lòng", "hai", " ", "tố", "nga", "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

            Console.WriteLine("a. 4 ký tự, sắp xếp tăng dần theo ký tự đầu tiên:");
            // FirstOrDefault() lấy ký tự đầu tiên của chuỗi một cách an toàn (tránh lỗi nếu chuỗi rỗng) để làm tiêu chí sắp xếp
            Console.WriteLine($"   {string.Join(", ", mangChuoi.Where(s => s.Length == 4).OrderBy(s => s.FirstOrDefault()))}");

            Console.WriteLine("b. Biến đổi <chữ thường> - <CHỮ HOA>:");
            // Loại bỏ các chuỗi rỗng/chỉ chứa khoảng trắng trước khi biến đổi
            Console.WriteLine($"   {string.Join(", ", mangChuoi.Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => $"{s.ToLower()} - {s.ToUpper()}"))}");

            Console.WriteLine("c. Chứa ký tự 'u':");
            Console.WriteLine($"   {string.Join(", ", mangChuoi.Where(s => s.Contains("u")))}");

            Console.WriteLine("d. Các phần tử bắt đầu bằng chữ in hoa:");
            // Kiểm tra chuỗi hợp lệ, sau đó dùng char.IsUpper để kiểm tra ký tự tại vị trí index [0]
            Console.WriteLine($"   {string.Join(" ", mangChuoi.Where(s => !string.IsNullOrWhiteSpace(s) && char.IsUpper(s[0])))}");
        }

        // Bài 3.1. Thống kê mảng số
        static void Bai31()
        {
            Console.WriteLine("\n--- BÀI 3.1: THỐNG KÊ MẢNG SỐ ---");
            int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

            Console.WriteLine($"a. Tổng số PT: {mangSo.Length}, Số PT chẵn: {mangSo.Count(x => x % 2 == 0)}, Số PT lẻ: {mangSo.Count(x => x % 2 != 0)}");
            Console.WriteLine($"b. Tổng giá trị: {mangSo.Sum()}, Max: {mangSo.Max()}, Min: {mangSo.Min()}");
            // Distinct() loại bỏ các phần tử trùng lặp trước khi đếm (Count)
            Console.WriteLine($"c. Số giá trị khác nhau: {mangSo.Distinct().Count()}");
            
            Console.WriteLine("d. Phân nhóm theo số dư cho 5:");
            // GroupBy tạo ra các nhóm. Ở đây, Key của mỗi nhóm chính là phần dư (x % 5)
            foreach (var group in mangSo.GroupBy(x => x % 5))
            {
                Console.WriteLine($"   - Dư {group.Key}: {string.Join(", ", group)}");
            }
        }

        // Bài 3.2. Thống kê mảng chuỗi
        static void Bai32()
        {
            Console.WriteLine("\n--- BÀI 3.2: THỐNG KÊ MẢNG CHUỖI ---");
            string[] monAn = { "Nước canh", "Bánh mì", "Cà phê", "Bún bò Huế", "Hủ tiếu heo", "Bánh dây", "Mì xào", "Mì quảng", "Cơm tấm", "Nước Chanh", "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

            int minLen = monAn.Min(x => x.Length);
            int maxLen = monAn.Max(x => x.Length);
            Console.WriteLine($"a. Ngắn nhất: {string.Join(", ", monAn.Where(x => x.Length == minLen))} | Dài nhất: {string.Join(", ", monAn.Where(x => x.Length == maxLen))}");

            Console.WriteLine("b. Phân nhóm theo từ đầu tiên:");
            // Split(' ') cắt chuỗi thành mảng các từ, lấy phần tử [0] (từ đầu tiên) làm chìa khóa (Key) gom nhóm
            foreach (var group in monAn.GroupBy(x => x.Split(' ')[0]))
            {
                Console.WriteLine($"   - Nhóm '{group.Key}': {string.Join(", ", group)}");
            }

            Console.WriteLine($"c. Số phần tử bắt đầu bằng 'Bánh': {monAn.Count(x => x.StartsWith("Bánh"))}");
        }

        // Bài 4.1. Lớp MonHoc và dữ liệu (Giữ nguyên)
        public class MonHoc
        {
            public string MaMon { get; set; } = "";
            public string TenMon { get; set; } = "";
            public string He { get; set; } = "";
            public byte SoTiet { get; set; }
        }

        public static List<MonHoc> DS_Mon()
        {
            return new List<MonHoc>
            {
                new MonHoc { MaMon = "HP2_1", TenMon = "Nền tảng C#", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP2_2", TenMon = "Công nghệ ADO.NET", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP3_1", TenMon = "Lập trình Windows Forms", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP3_2", TenMon = "Xây dựng ứng dụng Windows Forms", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP4_1", TenMon = "Lập trình Web với HTML, CSS và JavaScript", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP4_2", TenMon = "Xây dựng ứng dụng Web với ASP.NET", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP5_1", TenMon = "Lập trình CSDL SQL Server căn bản", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP5_2", TenMon = "Lập trình CSDL SQL Server nâng cao", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "JLCB", TenMon = "Joomla cơ bản", He = "CD", SoTiet = 72 },
                new MonHoc { MaMon = "LINQ", TenMon = "Language-Integrated Query", He = "CD", SoTiet = 64 },
                new MonHoc { MaMon = "DAWEB", TenMon = "Đồ án thực tế Web với ASP.NET", He = "CD", SoTiet = 40 },
                new MonHoc { MaMon = "DAWIN", TenMon = "Đồ án thực tế Windows Forms", He = "CD", SoTiet = 40 },
                new MonHoc { MaMon = "CC++", TenMon = "Lập trình hướng đối tượng với C/C++", He = "CD", SoTiet = 128 },
                new MonHoc { MaMon = "JQUE", TenMon = "JQuery", He = "CD", SoTiet = 22 },
                new MonHoc { MaMon = "XML", TenMon = "Công nghệ XML", He = "CD", SoTiet = 32 },
                new MonHoc { MaMon = "CRYS", TenMon = "Crystal Report trong Visual Studio", He = "CD", SoTiet = 32 },
                new MonHoc { MaMon = "BWEB", TenMon = "HTML, CSS và JavaScript", He = "CD", SoTiet = 32 },
                new MonHoc { MaMon = "XYZ", TenMon = "Chưa đặt tên môn", He = "", SoTiet = 0 }
            };
        }

        // Bài 5.1. Truy vấn cơ bản
        static void Bai51()
        {
            Console.WriteLine("\n--- BÀI 5.1: TRUY VẤN LIST<MONHOC> ---");
            var ds = DS_Mon();

            Console.WriteLine("a. Môn học bắt đầu bằng 'Lập trình':");
            Console.WriteLine($"   {string.Join(", ", ds.Where(m => m.TenMon.StartsWith("Lập trình")).Select(m => m.TenMon))}");

            Console.WriteLine("b. Hệ CD (số tiết giảm dần, mã môn tăng dần):");
            // Sắp xếp đa tầng: OrderByDescending chạy trước, kết quả bằng nhau thì xét tiếp ThenBy
            Console.WriteLine($"   {string.Join("\n   ", ds.Where(m => m.He == "CD").OrderByDescending(m => m.SoTiet).ThenBy(m => m.MaMon).Select(m => $"{m.MaMon} - {m.TenMon} ({m.SoTiet} tiết)"))}");

            Console.WriteLine("c. Tên chứa 'web' (chỉ lấy Tên môn và Hệ):");
            // ToLower() quy đổi tên môn về chữ thường hết để so sánh chữ "web" không bị lệch hoa/thường
            Console.WriteLine($"   {string.Join("\n   ", ds.Where(m => m.TenMon.ToLower().Contains("web")).Select(m => $"{m.TenMon} - {m.He}"))}");

            Console.WriteLine("d. Môn thuộc hệ KTV (Mã môn tăng dần):");
            Console.WriteLine($"   {string.Join(", ", ds.Where(m => m.He == "KTV").OrderBy(m => m.MaMon).Select(m => m.MaMon))}");
        }

        // Bài 5.2. Thống kê trên List<MonHoc>
        static void Bai52()
        {
            Console.WriteLine("\n--- BÀI 5.2: THỐNG KÊ TRÊN LIST<MONHOC> ---");
            var ds = DS_Mon();

            Console.WriteLine($"a. Tổng số môn hiện có: {ds.Count}");
            Console.WriteLine($"b. Số môn bắt đầu bằng 'Lập trình': {ds.Count(m => m.TenMon.StartsWith("Lập trình"))}");
            // Sum cần chỉ định rõ là tính tổng trên thuộc tính nào (ở đây là SoTiet)
            Console.WriteLine($"c. Tổng số tiết hệ KTV: {ds.Where(m => m.He == "KTV").Sum(m => m.SoTiet)}");
            
            Console.WriteLine("d. Tổng số môn của mỗi hệ:");
            Console.WriteLine($"   {string.Join(" | ", ds.Where(m => !string.IsNullOrEmpty(m.He)).GroupBy(m => m.He).Select(g => $"{g.Key}: {g.Count()} môn"))}");

            Console.WriteLine("e. Nhóm theo Số tiết (giảm dần):");
            foreach (var g in ds.GroupBy(m => m.SoTiet).OrderByDescending(g => g.Key))
                Console.WriteLine($"   - {g.Key} tiết: {g.Count()} môn");

            // Sắp xếp giảm dần theo số tiết rồi lấy phần tử đầu tiên (First) để tìm môn nhiều tiết nhất
            var maxTiet = ds.OrderByDescending(m => m.SoTiet).First();
            Console.WriteLine($"f. Môn có số tiết cao nhất: {maxTiet.MaMon} - {maxTiet.TenMon} ({maxTiet.SoTiet} tiết)");

            Console.WriteLine("g. Thống kê theo Hệ:");
            foreach (var g in ds.Where(m => !string.IsNullOrEmpty(m.He)).GroupBy(m => m.He))
                Console.WriteLine($"   - Hệ {g.Key}: Tổng môn {g.Count()}, Tổng tiết {g.Sum(m => m.SoTiet)}, Max {g.Max(m => m.SoTiet)}, Min {g.Min(m => m.SoTiet)}");

            Console.WriteLine("h. Liệt kê môn học theo Hệ:");
            foreach (var g in ds.GroupBy(m => m.He))
                Console.WriteLine($"   - Hệ '{g.Key}': {string.Join(", ", g.Select(m => m.TenMon))}");

            Console.WriteLine("i. Liệt kê môn học theo Số tiết (tăng dần):");
            foreach (var g in ds.GroupBy(m => m.SoTiet).OrderBy(g => g.Key))
                Console.WriteLine($"   - {g.Key} tiết: {string.Join(", ", g.Select(m => m.TenMon))}");

            Console.WriteLine("j. Phân nhóm hệ KTV theo HP2..HP5:");
            // Substring(0, 3) lấy 3 ký tự đầu của Mã môn (VD: "HP2_1" -> "HP2") làm Key gom nhóm
            foreach (var g in ds.Where(m => m.He == "KTV").OrderBy(m => m.MaMon).GroupBy(m => m.MaMon.Substring(0, 3)))
                Console.WriteLine($"   - {g.Key}: {string.Join(", ", g.Select(m => m.TenMon))}");

            Console.WriteLine("k. Nhóm theo Hệ (Số tiết > 40):");
            foreach (var g in ds.Where(m => m.SoTiet > 40 && !string.IsNullOrEmpty(m.He)).OrderBy(m => m.MaMon).GroupBy(m => m.He))
                Console.WriteLine($"   - Hệ {g.Key}: {string.Join(", ", g.Select(m => m.TenMon))}");
        }

        // Bài 6.1. Xây dựng lớp He (Giữ nguyên)
        public class He
        {
            public string MaHe { get; set; } = "";
            public string TenHe { get; set; } = "";
        }

        public static List<He> DS_He()
        {
            return new List<He>
            {
                new He { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
                new He { MaHe = "CD", TenHe = "Chuyên đề" },
                new He { MaHe = "OT", TenHe = "Chứng chỉ quốc tế" }
            };
        }

        // Bài 6.2. Join và các toán tử tập hợp
        static void Bai62()
        {
            Console.WriteLine("\n--- BÀI 6.2: JOIN VÀ TOÁN TỬ TẬP HỢP ---");
            var dsMon = DS_Mon();
            var dsHe = DS_He();

            Console.WriteLine("a. Join (Tên hệ, Mã môn, Tên môn):");
            // Inner join cơ bản, nối dựa trên m.He == h.MaHe
            var cauA = dsMon.Join(dsHe, m => m.He, h => h.MaHe, (m, h) => $"{h.TenHe} | {m.MaMon} | {m.TenMon}");
            Console.WriteLine($"   {string.Join("\n   ", cauA)}");

            Console.WriteLine("b. Cả hệ chưa có môn (Left Outer Join):");
            // BƯỚC 1: GroupJoin ghép mỗi Hệ với ds Môn. DefaultIfEmpty() trả về mảng có 1 phần tử null nếu Hệ không có môn nào.
            // BƯỚC 2: SelectMany trải phẳng danh sách. Dùng toán tử 3 ngôi (m != null) để xử lý phần tử null từ hệ trống.
            var leftJoin = dsHe.GroupJoin(dsMon, h => h.MaHe, m => m.He, (h, mList) => new { HeObj = h, MonList = mList.DefaultIfEmpty() })
                               .SelectMany(x => x.MonList, (x, m) => $"{x.HeObj.TenHe} - {(m != null ? m.TenMon : "Chưa có môn học")}");
            Console.WriteLine($"   {string.Join("\n   ", leftJoin)}");

            // Lọc ra các Hệ mà KHÔNG TỒN TẠI môn nào chứa mã hệ đó (Tương tự NOT EXISTS trong SQL)
            var heChuaMon = dsHe.Where(h => !dsMon.Any(m => m.He == h.MaHe)).Select(h => $"{h.TenHe} (Chưa có môn)");
            var monChuaHe = dsMon.Where(m => !dsHe.Any(h => h.MaHe == m.He)).Select(m => $"{m.TenMon} (Chưa khai báo hệ)");

            Console.WriteLine("c. Cả hệ chưa môn và môn chưa hệ:");
            // Concat nối 2 tập kết quả lại với nhau
            Console.WriteLine($"   {string.Join("\n   ", heChuaMon.Concat(monChuaHe))}");

            Console.WriteLine("d. Chỉ hệ chưa môn và môn chưa hệ:");
            Console.WriteLine($"   {string.Join("\n   ", heChuaMon.Concat(monChuaHe))}");

            Console.WriteLine("e. 5 môn đầu tiên có số tiết giảm dần:");
            // Take(5) giới hạn lấy đúng 5 phần tử đầu tiên sau khi đã sắp xếp giảm dần
            var top5 = dsMon.Join(dsHe, m => m.He, h => h.MaHe, (m, h) => new { h.TenHe, m.MaMon, m.TenMon, m.SoTiet })
                            .OrderByDescending(x => x.SoTiet).Take(5)
                            .Select(x => $"{x.TenHe} | {x.MaMon} | {x.TenMon} | {x.SoTiet} tiết");
            Console.WriteLine($"   {string.Join("\n   ", top5)}");

            Console.WriteLine("f. Tổng số môn học của mỗi hệ:");
            // GroupJoin ở đây không cần trải phẳng như Left Join, chỉ cần Count số lượng phần tử trong ds con mList
            var tongMonHe = dsHe.GroupJoin(dsMon, h => h.MaHe, m => m.He, (h, mList) => $"{h.MaHe} ({h.TenHe}): {mList.Count()} môn");
            Console.WriteLine($"   {string.Join("\n   ", tongMonHe)}");

            Console.WriteLine($"g. Số loại số tiết khác nhau: {dsMon.Select(m => m.SoTiet).Distinct().Count()}");
            // Dùng dấu ? sau FirstOrDefault (Toán tử an toàn null) phòng hờ không tìm thấy môn nào, tránh văng lỗi Exception
            Console.WriteLine($"h. Môn học đầu tiên tên bắt đầu bằng 'Lập trình': {dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"))?.TenMon}");

            Console.WriteLine("i. Liệt kê các môn theo từng hệ, đánh số thứ tự:");
            foreach (var g in dsMon.Where(m => !string.IsNullOrEmpty(m.He)).GroupBy(m => m.He))
            {
                Console.WriteLine($"   Hệ {g.Key}:");
                int stt = 1;
                foreach (var m in g)
                {
                    Console.WriteLine($"      {stt++}. {m.TenMon}");
                }
            }
        }
    }
}