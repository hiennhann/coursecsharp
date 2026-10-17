CREATE DATABASE QLSinhVien;
GO

USE QLSinhVien;
GO

CREATE TABLE Khoa
(
    MaKhoa VARCHAR(10) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);

CREATE TABLE Lop
(
    MaLop VARCHAR(10) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaKhoa VARCHAR(10),

    CONSTRAINT FK_Lop_Khoa
        FOREIGN KEY (MaKhoa)
        REFERENCES Khoa(MaKhoa)
);

CREATE TABLE SinhVien
(
    MaSinhVien VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    MaLop VARCHAR(10),

    CONSTRAINT FK_SinhVien_Lop
        FOREIGN KEY (MaLop)
        REFERENCES Lop(MaLop)
);

CREATE TABLE MonHoc
(
    MaMonHoc VARCHAR(10) PRIMARY KEY,
    TenMonHoc NVARCHAR(100) NOT NULL
);

CREATE TABLE Diem
(
    MaSinhVien VARCHAR(10),
    MaMonHoc VARCHAR(10),
    Diem FLOAT,

    PRIMARY KEY(MaSinhVien, MaMonHoc),

    FOREIGN KEY(MaSinhVien)
        REFERENCES SinhVien(MaSinhVien),

    FOREIGN KEY(MaMonHoc)
        REFERENCES MonHoc(MaMonHoc)
);

-- dữ liệu mẫu
INSERT INTO Khoa VALUES
('CNTT', N'Công nghệ thông tin'),
('QTKD', N'Quản trị kinh doanh'),
('KT', N'Kế toán'),
('NN', N'Ngoại ngữ'),
('DL', N'Du lịch');

INSERT INTO Lop VALUES
('DCT1221', N'Công nghệ thông tin 1', 'CNTT'),
('DCT1222', N'Công nghệ thông tin 2', 'CNTT'),
('DQT1221', N'Quản trị kinh doanh 1', 'QTKD'),
('DKT1221', N'Kế toán 1', 'KT'),
('DNN1221', N'Ngoại ngữ 1', 'NN');

INSERT INTO SinhVien VALUES
('SV001', N'Nguyễn Văn An',  '2005-01-10', 'DCT1221'),
('SV002', N'Trần Minh Bình', '2005-02-15', 'DCT1221'),
('SV003', N'Lê Hoàng Nam',   '2005-03-20', 'DCT1222'),
('SV004', N'Phạm Minh Anh',  '2005-04-25', 'DQT1221'),
('SV005', N'Võ Thanh Tùng',  '2005-05-12', 'DKT1221');

INSERT INTO MonHoc VALUES
('MH001', N'Lập trình C#'),
('MH002', N'Cơ sở dữ liệu'),
('MH003', N'Cấu trúc dữ liệu'),
('MH004', N'Mạng máy tính'),
('MH005', N'Công nghệ phần mềm');