SELECT TOP (1000) [ID]
      ,[UserName]
      ,[PassWord]
      ,[IDNhanVien]
      ,[HinhAnh]
  FROM [Quan_Ly_Shop_Quan_Ao].[dbo].[TaiKhoan]


--CREATE PROCEDURE sp_ResetTaiKhoan
--    @IDNhanVien INT
--AS
--BEGIN
--    SET NOCOUNT ON;

--    UPDATE TaiKhoan
--    SET 
--        UserName = 'UserName123456' + '',
--        PassWord = 'PassWord123456'
--    WHERE IDNhanVien = @IDNhanVien
--    INNER JOINT [dbo].[NhanVien] nV ON ;

--    IF @@ROWCOUNT > 0
--        RETURN 0;   -- Thành công
--    ELSE
--        RETURN 1;   -- Không có dữ liệu để cập nhật
--END
--GO

CREATE PROCEDURE sp_ResetTaiKhoan
    @IDNhanVien INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE tk
    SET 
        UserName = CAST(tk.IDNhanVien AS NVARCHAR(20)) + N'_' + 'UserName',
        PassWord = CAST(tk.IDNhanVien AS NVARCHAR(20)) + N'_' + nv.MaNhanVien
    FROM TaiKhoan tk
    INNER JOIN NhanVien nv ON tk.IDNhanVien = nv.ID
    WHERE tk.IDNhanVien = @IDNhanVien;

    IF @@ROWCOUNT > 0
        RETURN 0;   -- Thành công
    ELSE
        RETURN 1;   -- Không có dữ liệu để cập nhật
END
GO

DECLARE @Result INT;
EXEC @Result = sp_ResetTaiKhoan @IDNhanVien = 5;
SELECT @Result AS KetQua;