CREATE FUNCTION dbo.DemHoaDon_ByIDNhanVien
(
    @IDNhanVien INT
)
RETURNS INT
AS
BEGIN
    DECLARE @SoLuong INT;

    SELECT @SoLuong = COUNT(*)
    FROM HoaDon
    WHERE IDNhanVien = @IDNhanVien;

    RETURN @SoLuong;
END
GO