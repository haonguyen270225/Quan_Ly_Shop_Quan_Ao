alter table [dbo].[LoaiSanPham]
add GioiTinh tinyint not null default(2) -- nam nữ điều mua được ! 1 - nam , 0 - nữ;

update [dbo].[LoaiSanPham]
set GioiTinh = 0
where ID = 6 or ID = 8;