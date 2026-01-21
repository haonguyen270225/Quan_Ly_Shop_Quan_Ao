CREATE PROCEDURE sp_UpdateHinhAnhKhoHang
    @MaHang VARCHAR(100),
    @HinhAnh VARBINARY(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM KhoHang WHERE MaHang = @MaHang)
    BEGIN
        UPDATE KhoHang
        SET HinhAnh = @HinhAnh
        WHERE MaHang = @MaHang;

        RETURN 0; -- Thành công
    END
    ELSE
    BEGIN
        RETURN 1; -- Không tìm thấy MaHang
    END
END