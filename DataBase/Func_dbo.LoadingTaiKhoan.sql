
create function dbo.LayThongTinTaiKhoan
(
  @UserName varchar(50),
  @PasssWord varchar(50)
)
returns table
as
return
(
	SELECT TOP (1000) [ID]
      ,[UserName]
      ,[PassWord]
      ,[IDNhanVien]
      ,[HinhAnh]
    FROM [Quan_Ly_Shop_Quan_Ao].[dbo].[TaiKhoan] as tk
    where tk.UserName = @UserName and tk.PassWord = @PasssWord
);

 -- Cách dùng
SELECT * FROM  dbo.LoadingTaiKhoan('binh.tran', '123456');
