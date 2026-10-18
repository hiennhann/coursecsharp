
-- TẠO DATABASE QUẢN LÝ CỬA HÀNG

IF DB_ID(N'QLCuaHang') IS NULL
BEGIN
    CREATE DATABASE QLCuaHang;
END;
GO

USE QLCuaHang;
GO

-- 1. BẢNG SẢN PHẨM
-- MaSP tự động tăng

IF OBJECT_ID(N'dbo.SANPHAM', N'U') IS NULL
BEGIN
    CREATE TABLE SANPHAM
    (
        MaSP INT IDENTITY(1,1) PRIMARY KEY,
        TenSP NVARCHAR(100) NOT NULL
    );
END;
GO

-- 2. BẢNG HÓA ĐƠN
-- MaHD tự động tăng
-- 0: Chưa thanh toán
-- 1: Đã thanh toán

IF OBJECT_ID(N'dbo.HOADON', N'U') IS NULL
BEGIN
    CREATE TABLE HOADON
    (
        MaHD INT IDENTITY(1,1) PRIMARY KEY,
        NgayTao DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
        TinhTrangThanhToan BIT NOT NULL DEFAULT 0
    );
END;
GO

-- 3. BẢNG TỒN KHO
-- Mỗi sản phẩm có một dòng cho mỗi ngày

IF OBJECT_ID(N'dbo.TONKHO', N'U') IS NULL
BEGIN
    CREATE TABLE TONKHO
    (
        MaSP INT NOT NULL,
        NgayTon DATE NOT NULL,

        SLDau INT NOT NULL DEFAULT 0,
        SLNhap INT NOT NULL DEFAULT 0,
        SLBan INT NOT NULL DEFAULT 0,

        CONSTRAINT PK_TONKHO
            PRIMARY KEY (MaSP, NgayTon),

        CONSTRAINT FK_TONKHO_SANPHAM
            FOREIGN KEY (MaSP)
            REFERENCES SANPHAM(MaSP),

        CONSTRAINT CK_TONKHO
            CHECK
            (
                SLDau >= 0 AND
                SLNhap >= 0 AND
                SLBan >= 0 AND
                SLDau + SLNhap >= SLBan
            )
    );
END;
GO

-- 4. BẢNG CHI TIẾT HÓA ĐƠN
-- Khóa chính gồm MaHD và MaSP

IF OBJECT_ID(N'dbo.CHITIET_HOADON', N'U') IS NULL
BEGIN
    CREATE TABLE CHITIET_HOADON
    (
        MaHD INT NOT NULL,
        MaSP INT NOT NULL,
        SoLuong INT NOT NULL,

        CONSTRAINT PK_CHITIET_HOADON
            PRIMARY KEY (MaHD, MaSP),

        CONSTRAINT FK_CTHD_HOADON
            FOREIGN KEY (MaHD)
            REFERENCES HOADON(MaHD),

        CONSTRAINT FK_CTHD_SANPHAM
            FOREIGN KEY (MaSP)
            REFERENCES SANPHAM(MaSP),

        CONSTRAINT CK_CTHD_SOLUONG
            CHECK (SoLuong > 0)
    );
END;
GO

-- 5. DỮ LIỆU MẪU SẢN PHẨM

IF NOT EXISTS (SELECT 1 FROM SANPHAM)
BEGIN
    INSERT INTO SANPHAM(TenSP)
    VALUES
        (N'Bút bi'),
        (N'Vở 200 trang'),
        (N'Thước kẻ'),
        (N'Bút chì'),
        (N'Tẩy');
END;
GO

-- 6. DỮ LIỆU TỒN KHO NGÀY HÔM QUA
-- Để thử chức năng tạo tồn kho hôm nay

IF NOT EXISTS (SELECT 1 FROM TONKHO)
BEGIN
    INSERT INTO TONKHO
        (MaSP, NgayTon, SLDau, SLNhap, SLBan)
    SELECT
        MaSP,
        DATEADD(DAY, -1, CAST(GETDATE() AS DATE)),

        CASE TenSP
            WHEN N'Bút bi' THEN 30
            WHEN N'Vở 200 trang' THEN 40
            WHEN N'Thước kẻ' THEN 25
            WHEN N'Bút chì' THEN 20
            WHEN N'Tẩy' THEN 30
        END,

        CASE TenSP
            WHEN N'Bút bi' THEN 5
            WHEN N'Vở 200 trang' THEN 10
            WHEN N'Thước kẻ' THEN 0
            WHEN N'Bút chì' THEN 0
            WHEN N'Tẩy' THEN 8
        END,

        CASE TenSP
            WHEN N'Bút bi' THEN 2
            WHEN N'Vở 200 trang' THEN 3
            WHEN N'Thước kẻ' THEN 4
            WHEN N'Bút chì' THEN 0
            WHEN N'Tẩy' THEN 5
        END
    FROM SANPHAM;
END;
GO

-- 7. DỮ LIỆU HÓA ĐƠN MẪU HÔM QUA

IF NOT EXISTS (SELECT 1 FROM HOADON)
BEGIN
    DECLARE @MaHD1 INT;
    DECLARE @MaHD2 INT;

    -- Hóa đơn thứ nhất.
    INSERT INTO HOADON(NgayTao, TinhTrangThanhToan)
    VALUES (DATEADD(DAY, -1, SYSDATETIME()), 1);

    SET @MaHD1 = SCOPE_IDENTITY();

    -- Hóa đơn thứ hai.
    INSERT INTO HOADON(NgayTao, TinhTrangThanhToan)
    VALUES (DATEADD(DAY, -1, SYSDATETIME()), 1);

    SET @MaHD2 = SCOPE_IDENTITY();

    -- Chi tiết hóa đơn thứ nhất.
    INSERT INTO CHITIET_HOADON(MaHD, MaSP, SoLuong)
    SELECT @MaHD1, MaSP, 2
    FROM SANPHAM WHERE TenSP = N'Bút bi';

    INSERT INTO CHITIET_HOADON(MaHD, MaSP, SoLuong)
    SELECT @MaHD1, MaSP, 3
    FROM SANPHAM WHERE TenSP = N'Vở 200 trang';

    -- Chi tiết hóa đơn thứ hai.
    INSERT INTO CHITIET_HOADON(MaHD, MaSP, SoLuong)
    SELECT @MaHD2, MaSP, 4
    FROM SANPHAM WHERE TenSP = N'Thước kẻ';

    INSERT INTO CHITIET_HOADON(MaHD, MaSP, SoLuong)
    SELECT @MaHD2, MaSP, 5
    FROM SANPHAM WHERE TenSP = N'Tẩy';
END;
GO

-- kiểm tra dữ liệu
SELECT * FROM SANPHAM;
SELECT * FROM TONKHO;
SELECT * FROM HOADON;
SELECT * FROM CHITIET_HOADON;
GO
