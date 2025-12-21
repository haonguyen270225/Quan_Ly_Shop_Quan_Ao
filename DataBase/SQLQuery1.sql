create table NhanVien
(
	ID int identity(1,1) primary key,
	MaNhanVien varchar(10) not null,
	SDT varchar(15) not null UNIQUE,
	Email varchar(50) UNIQUE,
	CCCD varchar(15) not null UNIQUE,
	DiaChi nvarchar(50) not null,
	ChucVu nvarchar(50) not null default(N'Nhân viên bán hàng'),
	GioiTinh int not null  default(1),--0 - nu , 1 - nam 
)

ALTER TABLE NhanVien
ADD HoVaTen NVARCHAR(50) NOT NULL; -- Thêm cộp Họ và tên nhân viên 

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


