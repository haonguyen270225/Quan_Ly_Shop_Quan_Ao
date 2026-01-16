USE [Quan_Ly_Shop_Quan_Ao]
GO

--INSERT INTO [dbo].[ChiTietHoaDon]
--           ([SoLuong]
--           ,[TongTien]
--           ,[IDMaHang]
--           ,[IDHoaDon])
--     VALUES
--           (<SoLuong, int,>
--           ,<TongTien, decimal(18,2),>
--           ,<IDMaHang, int,>
--           ,<IDHoaDon, int,>)
--GO


CREATE PROCEDURE sp_ThemChiTietHoaDon
    @SoLuong    INT,
    @TongTien   DECIMAL(18,2),
    @IDMaHang   INT,
    @IDHoaDon   INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[ChiTietHoaDon]
           (SoLuong
           ,TongTien
           ,IDMaHang
           ,IDHoaDon)
    VALUES
           (@SoLuong
           ,@TongTien
           ,@IDMaHang
           ,@IDHoaDon);
END
GO

