create database Quan_Ly_Shop_Quan_Ao;

create table NhanVien
(
	ID int identity(1,1) primary key,
	MaNhanVien varchar(10) not null,
	HoVaTen nvarchar(50) not null,
	SDT varchar(15) not null UNIQUE,
	Email varchar(50) UNIQUE,
	CCCD varchar(15) not null UNIQUE,
	DiaChi nvarchar(50) not null,
	ChucVu nvarchar(50) not null default(N'Nhân viên bán hàng'),
	GioiTinh int not null  default(1),--0 - nu , 1 - nam 
)

--ALTER TABLE NhanVien
--ADD HoVaTen NVARCHAR(50) NOT NULL; -- Thêm cộp Họ và tên nhân viên 

create table TaiKhoan
(
	ID int  identity(1,1) primary key,
	UserName varchar(50) not null,
	PassWord varchar(50) not null,
	IDNhanVien int not null,
	constraint FK_TaiKhoan_NhanVien
	foreign key (IDNhanVien)
	references NhanVien(ID)
	ON DELETE CASCADE --Xóa khóa cha - tự xóa khóa con
	ON UPDATE CASCADE -- Sửa khóa cha - tự cập nhật khóa con.
)


create table KhachHang
(
	ID int identity(1,1) primary key,
	MaKhachHang varchar(10) not null unique,
	HoVaTen nvarchar(50) not null,
	SDT varchar(15) not null unique
)


CREATE TABLE Size
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaSize VARCHAR(5) NOT NULL UNIQUE
)



create table HoaDon
(
	ID int identity(1,1) primary key,
	MaHoaDon varchar(10) not null unique,
	Ngay date not null default cast(getdate() as date),
	Gio time not null default cast(getdate() as time),
	TongThu decimal(18 , 2) not null default(0),
	IDNhanVien int not null,
	IDKhachHang int not null,
	constraint FK_HoaDon_NhanVien
	foreign key (IDNhanVien)
	references NhanVien(ID)
	ON DELETE CASCADE --Xóa khóa cha - tự xóa khóa con
	ON UPDATE CASCADE ,-- Sửa khóa cha - tự cập nhật khóa con.
	constraint FK_HoaDon_KhachHang
	foreign key (IDKhachHang)
	references KhachHang(ID)
	ON DELETE CASCADE --Xóa khóa cha - tự xóa khóa con
	ON UPDATE CASCADE -- Sửa khóa cha - tự cập nhật khóa con.
)


create table LoaiSanPham
(
	ID int identity(1,1) primary key,
	MaLoaiSanPham varchar(10) not null unique,
	TenLoai nvarchar(50) not null,
)



create table KhoHang
(
	ID int identity(1,1) primary key,
	MaHang varchar(10) not null unique,
	TenHang nvarchar(50) not null,
	SoLuongTon int not null default(0),
	Gia decimal(18 , 2) not null,
	IDSize int not null,
	constraint FK_KhoHang_Size
	foreign key (IDSize)
	references Size(ID)
	ON DELETE CASCADE -- Xóa khóa cha - tự xóa khóa con
	ON UPDATE CASCADE, -- Sửa khóa cha - tự cập nhật khóa con.
	constraint CK_KhoHang_SoLuongTon check(SoLuongTon >= 0 ),
	constraint CK_KhoHang_Gia check(Gia > 0),
	IDLoaiSanPham int not null,
	constraint FK_KhoHang_LoaiSanPham
	foreign key (IDLoaiSanPham)
	references LoaiSanPham(ID)
	ON DELETE CASCADE -- Xóa khóa cha - tự xóa khóa con
	ON UPDATE CASCADE -- Sửa khóa cha - tự cập nhật khóa con.
)


create table ChiTietHoaDon
(
	ID int identity(1,1) primary key,
	SoLuong int not null,
	TongTien decimal(18 , 2) not null,
	IDMaHang int not null,          
	IDHoaDon int not null,
	constraint FK_ChiTietHoaDon_KhoHang
	foreign key (IDMaHang)
	references KhoHang(ID)
	ON DELETE CASCADE -- Xóa khóa cha - tự xóa khóa con
	ON UPDATE CASCADE, -- Sửa khóa cha - tự cập nhật khóa con.
	constraint FK_ChiTietHoaDon_HoaDon
	foreign key (IDHoaDon)
	references HoaDon(ID)
	ON DELETE CASCADE -- Xóa khóa cha - tự xóa khóa con
	ON UPDATE CASCADE, -- Sửa khóa cha - tự cập nhật khóa con.
	constraint CK_ChiTietHoaDon_SoLuong check(SoLuong > 0 ),
	constraint CK_ChiTietHoaDon_TongTien check(TongTien > 0)
)






INSERT INTO NhanVien
(MaNhanVien, HoVaTen , SDT, Email, CCCD, DiaChi, ChucVu, GioiTinh)
VALUES
('NV001', N'Nguyễn Văn An',  '0912345678', 'an.nguyen@gmail.com',  '012345678901', N'Hà Nội',       N'Nhân viên bán hàng', 1),
('NV002', N'Trần Văn Bình',  '0923456789', 'binh.tran@gmail.com', '012345678902', N'Hồ Chí Minh',  N'Nhân viên bán hàng', 1),
('NV003', N'Lê Thị Chi',     '0934567890', 'chi.le@gmail.com',    '012345678903', N'Đà Nẵng',      N'Quản lý',             0),
('NV004', N'Phạm Văn Dũng',  '0945678901', 'dung.pham@gmail.com', '012345678904', N'Hải Phòng',    N'Nhân viên kho',      1),
('NV005', N'Võ Thị Hà',      '0956789012', 'ha.vo@gmail.com',     '012345678905', N'Cần Thơ',      DEFAULT,               0);


INSERT INTO TaiKhoan
(UserName, PassWord, IDNhanVien)
VALUES
('an.nguyen',   '123456', 1),
('binh.tran',   '123456', 2),
('chi.le',      '123456', 3),
('dung.pham',   '123456', 4),
('ha.vo',       '123456', 5);


INSERT INTO KhachHang (MaKhachHang, HoVaTen, SDT) VALUES
('KH001', N'Nguyễn Văn An',  '0901234567'),
('KH002', N'Trần Thị Bình', '0912345678'),
('KH003', N'Lê Hoàng Nam',  '0923456789'),
('KH004', N'Phạm Thị Lan',  '0934567890'),
('KH005', N'Võ Minh Tuấn',  '0945678901'),
('KH006', N'Đặng Thị Hương','0956789012'),
('KH007', N'Bùi Quang Huy', '0967890123'),
('KH008', N'Hoàng Ngọc Mai','0978901234'),
('KH009', N'Phan Văn Long', '0989012345'),
('KH010', N'Nguyễn Thị Thu','0990123456');


INSERT INTO LoaiSanPham (MaLoaiSanPham, TenLoai) VALUES
('LSP01', N'Áo thun'),
('LSP02', N'Áo sơ mi'),
('LSP03', N'Quần jean'),
('LSP04', N'Quần tây'),
('LSP05', N'Áo khoác'),
('LSP06', N'Váy / Đầm'),
('LSP07', N'Áo hoodie'),
('LSP08', N'Áo len'),
('LSP09', N'Quần short'),
('LSP10', N'Đồ thể thao');

INSERT INTO Size (MaSize)
VALUES
('S'),
('M'),
('L'),
('XL'),
('XXL');


INSERT INTO KhoHang (MaHang, TenHang, SoLuongTon, Gia, IDSize, IDLoaiSanPham)
VALUES
-- Áo thun
('MH001', N'Áo thun basic S', 50, 199000, 1, 1),
('MH002', N'Áo thun basic M', 40, 199000, 2, 1),
('MH003', N'Áo thun basic L', 0, 199000, 3, 1), -- hết hàng
('MH004', N'Áo thun basic XL', 25, 219000, 4, 1),

-- Áo sơ mi
('MH005', N'Áo sơ mi trắng S', 30, 299000, 1, 2),
('MH006', N'Áo sơ mi trắng M', 0, 299000, 2, 2), -- hết hàng
('MH007', N'Áo sơ mi xanh L', 20, 319000, 3, 2),

-- Quần jean
('MH008', N'Quần jean xanh S', 35, 399000, 1, 3),
('MH009', N'Quần jean xanh M', 28, 399000, 2, 3),
('MH010', N'Quần jean xanh L', 0, 399000, 3, 3), -- hết hàng

-- Quần tây
('MH011', N'Quần tây đen M', 22, 449000, 2, 4),
('MH012', N'Quần tây đen L', 18, 449000, 3, 4),

-- Áo khoác
('MH013', N'Áo khoác kaki M', 15, 599000, 2, 5),
('MH014', N'Áo khoác kaki L', 0, 599000, 3, 5), -- hết hàng
('MH015', N'Áo khoác dù XL', 12, 549000, 4, 5),

-- Váy / Đầm
('MH016', N'Váy hoa S', 20, 349000, 1, 6),
('MH017', N'Váy hoa M', 18, 349000, 2, 6),
('MH018', N'Đầm dự tiệc L', 10, 499000, 3, 6),

-- Áo hoodie
('MH019', N'Hoodie nỉ S', 25, 459000, 1, 7),
('MH020', N'Hoodie nỉ M', 30, 459000, 2, 7),
('MH021', N'Hoodie nỉ L', 0, 459000, 3, 7), -- hết hàng

-- Áo len
('MH022', N'Áo len cổ tròn M', 16, 379000, 2, 8),
('MH023', N'Áo len cổ tròn L', 14, 379000, 3, 8),

-- Quần short
('MH024', N'Quần short kaki S', 40, 259000, 1, 9),
('MH025', N'Quần short kaki M', 35, 259000, 2, 9),
('MH026', N'Quần short kaki L', 30, 259000, 3, 9),

-- Đồ thể thao
('MH027', N'Bộ đồ thể thao S', 20, 499000, 1, 10),
('MH028', N'Bộ đồ thể thao M', 18, 499000, 2, 10),
('MH029', N'Bộ đồ thể thao L', 15, 499000, 3, 10),
('MH030', N'Bộ đồ thể thao XL', 10, 529000, 4, 10);



CREATE TRIGGER TRG_Insert_ChiTietHoaDon_GiamKho
ON ChiTietHoaDon
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Kiểm tra số lượng tồn kho
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN KhoHang k ON i.IDMaHang = k.ID
        WHERE i.SoLuong > k.SoLuongTon
    )
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR (N'Số lượng bán vượt quá số lượng tồn kho!', 16, 1);
        RETURN;
    END

    -- 2. Trừ số lượng tồn kho
    UPDATE k
    SET k.SoLuongTon = k.SoLuongTon - i.SoLuong
    FROM KhoHang k
    JOIN inserted i ON k.ID = i.IDMaHang;
END;




INSERT INTO HoaDon (MaHoaDon, Ngay, Gio, TongThu, IDNhanVien, IDKhachHang)
VALUES
-- ===== Tháng 2 / 2024 =====
('HD240201', '2024-02-02', '08:30:00', 0, 1, 1),
('HD240202', '2024-02-03', '09:15:00', 0, 2, 2),
('HD240203', '2024-02-05', '10:00:00', 0, 3, 3),
('HD240204', '2024-02-08', '14:20:00', 0, 4, 4),
('HD240205', '2024-02-10', '15:45:00', 0, 5, 5),
('HD240206', '2024-02-12', '16:30:00', 0, 1, 6),
('HD240207', '2024-02-15', '11:10:00', 0, 2, 7),
('HD240208', '2024-02-18', '13:50:00', 0, 3, 8),
('HD240209', '2024-02-20', '09:40:00', 0, 4, 9),
('HD240210', '2024-02-25', '16:00:00', 0, 5, 10),

-- ===== Tháng 3 / 2024 =====
('HD240301', '2024-03-01', '08:45:00', 0, 1, 2),
('HD240302', '2024-03-03', '09:30:00', 0, 2, 3),
('HD240303', '2024-03-05', '10:20:00', 0, 3, 4),
('HD240304', '2024-03-07', '14:10:00', 0, 4, 5),
('HD240305', '2024-03-10', '15:00:00', 0, 5, 6),
('HD240306', '2024-03-12', '16:40:00', 0, 1, 7),
('HD240307', '2024-03-15', '11:30:00', 0, 2, 8),
('HD240308', '2024-03-18', '13:00:00', 0, 3, 9),
('HD240309', '2024-03-20', '09:10:00', 0, 4, 10),
('HD240310', '2024-03-25', '16:20:00', 0, 5, 1),

-- ===== Tháng 9 / 2024 =====
('HD240901', '2024-09-01', '08:20:00', 0, 1, 3),
('HD240902', '2024-09-03', '09:00:00', 0, 2, 4),
('HD240903', '2024-09-05', '10:45:00', 0, 3, 5),
('HD240904', '2024-09-07', '14:30:00', 0, 4, 6),
('HD240905', '2024-09-10', '15:10:00', 0, 5, 7),
('HD240906', '2024-09-12', '16:50:00', 0, 1, 8),
('HD240907', '2024-09-15', '11:00:00', 0, 2, 9),
('HD240908', '2024-09-18', '13:40:00', 0, 3, 10),
('HD240909', '2024-09-20', '09:25:00', 0, 4, 1),
('HD240910', '2024-09-25', '16:10:00', 0, 5, 2);



CREATE TRIGGER TRG_Insert_ChiTietHoaDon_CapNhatTongThu
ON ChiTietHoaDon
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Cộng dồn TongTien vào TongThu của HoaDon tương ứng
    UPDATE hd
    SET hd.TongThu = hd.TongThu + i.TongTien
    FROM HoaDon hd
    JOIN inserted i ON hd.ID = i.IDHoaDon;
END;



CREATE PROCEDURE SP_ThemChiTietHoaDon
    @IDHoaDon INT,
    @IDMaHang INT,
    @SoLuong INT
AS
BEGIN
    INSERT INTO ChiTietHoaDon (SoLuong, TongTien, IDMaHang, IDHoaDon)
    SELECT
        @SoLuong,
        @SoLuong * Gia,
        ID,
        @IDHoaDon
    FROM KhoHang
    WHERE ID = @IDMaHang;
END;




--EXEC SP_ThemChiTietHoaDon -- Thêm dữ liệu vào table ChiTietHoaDon
--    @IDHoaDon = 1,
--    @IDMaHang = 1,
--    @SoLuong = 3;

-- ===== HoaDon 1 → 10 =====
EXEC SP_ThemChiTietHoaDon 1, 1, 3;
EXEC SP_ThemChiTietHoaDon 1, 5, 2;

EXEC SP_ThemChiTietHoaDon 2, 2, 4;
EXEC SP_ThemChiTietHoaDon 2, 7, 3;

EXEC SP_ThemChiTietHoaDon 3, 4, 5;

EXEC SP_ThemChiTietHoaDon 4, 8, 2;
EXEC SP_ThemChiTietHoaDon 4, 11, 3;

EXEC SP_ThemChiTietHoaDon 5, 9, 6;

EXEC SP_ThemChiTietHoaDon 6, 12, 2;
EXEC SP_ThemChiTietHoaDon 6, 13, 4;

EXEC SP_ThemChiTietHoaDon 7, 15, 3;

EXEC SP_ThemChiTietHoaDon 8, 16, 5;
EXEC SP_ThemChiTietHoaDon 8, 17, 2;

EXEC SP_ThemChiTietHoaDon 9, 18, 4;

EXEC SP_ThemChiTietHoaDon 10, 19, 3;
EXEC SP_ThemChiTietHoaDon 10, 20, 2;

-- ===== HoaDon 11 → 20 =====
EXEC SP_ThemChiTietHoaDon 11, 22, 6;

EXEC SP_ThemChiTietHoaDon 12, 23, 3;
EXEC SP_ThemChiTietHoaDon 12, 24, 4;

EXEC SP_ThemChiTietHoaDon 13, 25, 5;

EXEC SP_ThemChiTietHoaDon 14, 26, 2;
EXEC SP_ThemChiTietHoaDon 14, 27, 3;

EXEC SP_ThemChiTietHoaDon 15, 28, 4;

EXEC SP_ThemChiTietHoaDon 16, 29, 6;
EXEC SP_ThemChiTietHoaDon 16, 30, 2;

EXEC SP_ThemChiTietHoaDon 17, 1, 3;

EXEC SP_ThemChiTietHoaDon 18, 2, 5;
EXEC SP_ThemChiTietHoaDon 18, 4, 2;

EXEC SP_ThemChiTietHoaDon 19, 5, 4;

EXEC SP_ThemChiTietHoaDon 20, 7, 6;

-- ===== HoaDon 21 → 30 =====
EXEC SP_ThemChiTietHoaDon 21, 8, 3;
EXEC SP_ThemChiTietHoaDon 21, 11, 2;

EXEC SP_ThemChiTietHoaDon 22, 12, 5;

EXEC SP_ThemChiTietHoaDon 23, 13, 4;
EXEC SP_ThemChiTietHoaDon 23, 15, 3;

EXEC SP_ThemChiTietHoaDon 24, 16, 6;

EXEC SP_ThemChiTietHoaDon 25, 17, 2;
EXEC SP_ThemChiTietHoaDon 25, 18, 4;

EXEC SP_ThemChiTietHoaDon 26, 19, 5;

EXEC SP_ThemChiTietHoaDon 27, 20, 3;

EXEC SP_ThemChiTietHoaDon 28, 22, 4;
EXEC SP_ThemChiTietHoaDon 28, 23, 2;

EXEC SP_ThemChiTietHoaDon 29, 24, 6;

EXEC SP_ThemChiTietHoaDon 30, 25, 3;

	DELETE FROM [dbo].[ChiTietHoaDon];