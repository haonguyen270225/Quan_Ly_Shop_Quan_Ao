CREATE PROCEDURE sp_XoaKhoHangByMaHang
    @MaHang NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM KhoHang
    WHERE MaHang = @MaHang;

    IF @@ROWCOUNT > 0
        RETURN 0;   -- Xóa thành công
    ELSE
        RETURN 1;   -- Không có dữ liệu để xóa
END
GO
