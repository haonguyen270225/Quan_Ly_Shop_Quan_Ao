CREATE PROCEDURE dbo.sp_UpdateKhoHang
    @MaHang VARCHAR(10),
    @TenHang NVARCHAR(50),
    @SoLuongTon INT,
    @Gia DECIMAL(18,2),
    @IDSize INT,
    @IDLoaiSanPham INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        UPDATE KhoHang
        SET 
            TenHang = @TenHang,
            SoLuongTon = @SoLuongTon,
            Gia = @Gia,
            IDSize = @IDSize,
            IDLoaiSanPham = @IDLoaiSanPham
        WHERE MaHang = @MaHang;

        IF @@ROWCOUNT = 0
            RETURN 1; -- Không có dòng nào được cập nhật

        RETURN 0; -- Thành công
    END TRY
    BEGIN CATCH
        RETURN 1; -- Lỗi SQL
    END CATCH
END
GO