---- Lọc KhoHang theo size ;
--create procedure sp_LocSizeKhoHang
--	@MaSize varchar(5) 
--as
--begin 
--	select kh.IDSize , MaHang ,   TenHang , SoLuongTon , Gia , IDSize , IDLoaiSanPham
--	from [dbo].[KhoHang] as kh
--	inner join [dbo].[Size] as s
--	on s.ID = kh.IDSize
--	where s.MaSize = @MaSize;
--end


-- Cách dùng :
exec sp_LocSizeKhoHang @MaSize = 'M';
