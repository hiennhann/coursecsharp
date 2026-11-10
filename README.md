# Ngôn ngữ lập trình C#

**Giảng viên hướng dẫn:** TS. Đỗ Như Tài  
**Sinh viên:** Nguyễn Văn Hiền Nhân  
**MSSV:** 3123411207

Kho lưu trữ các bài thực hành và bài tập trong quá trình học lập trình C# và .NET. Nội dung được sắp xếp theo từng buổi/lab, gồm các chương trình C# và bài tập thực hành.

## Nội dung

| Thư mục | Nội dung khái quát |
| --- | --- |
| [`Lab02`](Lab02/) | Bài tập C# cơ bản và hướng đối tượng (OOP), gồm các bài thực hành riêng lẻ. |
| [`Lab03`](Lab03/) | Bài thực hành LINQ. |
| [`Lab04`](Lab04/) | Các bài tập thực hành C# được chia theo từng nhóm bài. |
| [`Lab05`](Lab05/) | Các bài thực hành C#; có phần bài tập kèm dữ liệu/cơ sở dữ liệu SQL. |
| [`Lab06`](Lab06/) | Các bài thực hành C# theo nhóm bài, có thư mục dữ liệu cơ sở dữ liệu. |

> Danh sách và nội dung bài tập có thể được cập nhật theo tiến độ học tập.

## Công nghệ

- **C# / .NET**: ngôn ngữ và nền tảng chính của các bài tập.
- **SQL**: một số bài có tệp script hoặc dữ liệu liên quan đến cơ sở dữ liệu.

## Yêu cầu

- Cài đặt [.NET SDK](https://dotnet.microsoft.com/download) phù hợp với phiên bản được khai báo trong tệp `.csproj` của từng bài.
- Dùng Visual Studio, Visual Studio Code hoặc IDE tương thích với .NET.
- Với bài có cơ sở dữ liệu, cần cài đặt/cấu hình hệ quản trị cơ sở dữ liệu tương ứng và xem các tệp `.sql` hoặc thư mục `database` đi kèm.

## Cách chạy

Mở terminal tại thư mục chứa dự án (`.csproj`) và chạy:

```bash
dotnet restore
dotnet run
```

Nếu muốn chạy một bài cụ thể, chuyển vào đúng thư mục dự án trước. Ví dụ:

```bash
cd Lab03/BaiThucHanhLINQ
dotnet run
```

Có thể mở tệp `.slnx` trong thư mục lab bằng IDE hỗ trợ định dạng này để xem các dự án liên quan.

## Ghi chú

- Mỗi thư mục bài tập có thể là một dự án độc lập; hãy kiểm tra `.csproj` trước khi chạy.
- Một số thư mục `bin` và `obj` là sản phẩm được tạo ra khi build dự án.

---

**Ngôn ngữ chính:** C#  
**Chủ đề bổ trợ:** SQL
