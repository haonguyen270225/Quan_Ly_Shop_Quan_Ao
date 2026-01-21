SELECT TOP (1000) [ID]
      ,[MaHang]
      ,[TenHang]
      ,[SoLuongTon]
      ,[Gia]
      ,[IDSize]
      ,[IDLoaiSanPham]
      ,[HinhAnh]
  FROM [Quan_Ly_Shop_Quan_Ao].[dbo].[KhoHang]

CREATE PROCEDURE dbo.sp_InsertKhoHang
    @MaHang VARCHAR(10),
    @TenHang NVARCHAR(50),
    @SoLuongTon INT,
    @Gia DECIMAL(18,2),
    @IDSize INT,
    @IDLoaiSanPham INT,
    @HinhAnh VARBINARY(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO KhoHang
        (
            MaHang,
            TenHang,
            SoLuongTon,
            Gia,
            IDSize,
            IDLoaiSanPham,
            HinhAnh
        )
        VALUES
        (
            @MaHang,
            @TenHang,
            @SoLuongTon,
            @Gia,
            @IDSize,
            @IDLoaiSanPham,
            @HinhAnh
        );

        RETURN 0;  -- Thành công
    END TRY
    BEGIN CATCH
        RETURN 1;  -- Thất bại
    END CATCH
END
GO