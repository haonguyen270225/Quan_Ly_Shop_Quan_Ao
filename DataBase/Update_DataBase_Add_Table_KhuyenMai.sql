create table KhuyenMai
(
	ID int  identity(1,1) primary key,
	MaKhuyenMai varchar(50) not null unique,
	ThongTin nvarchar not null,
)

ALTER TABLE KhuyenMai
ALTER COLUMN ThongTin NVARCHAR(MAX) NOT NULL;

INSERT INTO KhuyenMai (MaKhuyenMai, ThongTin)
VALUES
('TET2026', N'Giảm giá 10% cho tất cả sản phẩm nhân dịp Tết Nguyên Đán'),

('SV2026', N'Giảm giá 15% cho sinh viên khi xuất trình thẻ sinh viên hợp lệ'),

('TONKHO05', N'Giảm giá 5% cho các sản phẩm tồn kho trên 60 ngày'),

('KHAITRUONG', N'Giảm giá 20% nhân dịp khai trương cửa hàng'),

('KHACHVIP', N'Giảm giá 12% dành cho khách hàng thân thiết');

ALTER TABLE KhuyenMai
ADD GiaTri INT NOT NULL DEFAULT 0;

UPDATE KhuyenMai
SET GiaTri = 10
WHERE MaKhuyenMai = 'TET2026';

UPDATE KhuyenMai
SET GiaTri = 15
WHERE MaKhuyenMai = 'SV2026';

UPDATE KhuyenMai
SET GiaTri = 5
WHERE MaKhuyenMai = 'TONKHO05';

UPDATE KhuyenMai
SET GiaTri = 20
WHERE MaKhuyenMai = 'KHAITRUONG';

UPDATE KhuyenMai
SET GiaTri = 12
WHERE MaKhuyenMai = 'KHACHVIP';
