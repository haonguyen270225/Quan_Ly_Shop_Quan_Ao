
  create function dbo.ThongTinTaiKhoan
  (
    @UserName varchar(50),
    @PassWord varchar(50)
  )
  returns table
  as
return
(
    SELECT TOP (1000) nv.ID
      ,nv.MaNhanVien
      ,nv.HoVaTen
      ,nv.SDT
      ,nv.Email
      ,nv.CCCD
      ,nv.DiaChi
      ,nv.IDChucVu
      ,nv.GioiTinh
      ,nv.HinhThucLamViec
  FROM [Quan_Ly_Shop_Quan_Ao].[dbo].[NhanVien] nv
  inner join [dbo].[TaiKhoan] tk on tk.IDNhanVien = nv.ID
  where tk.UserName = @UserName and tk.PassWord = @PassWord
  );
  -- Cách dùng
--SELECT * FROM dbo.ThongTinTaiKhoan('binh.tran', '123456');