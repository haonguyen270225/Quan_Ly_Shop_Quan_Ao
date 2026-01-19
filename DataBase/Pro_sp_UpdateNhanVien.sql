
  CREATE PROCEDURE sp_UpdateNhanVien
    @ID INT,
    @MaNhanVien NVARCHAR(10),
    @HoVaTen NVARCHAR(50),
    @SDT NVARCHAR(15),
    @Email NVARCHAR(50),
    @CCCD NVARCHAR(15),
    @DiaChi NVARCHAR(50),
    @ChucVu NVARCHAR(50),
    @GioiTinh INT,
    @HinhThucLamViec INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[NhanVien]
    SET 
        MaNhanVien = @MaNhanVien,
        HoVaTen = @HoVaTen,
        SDT = @SDT,
        Email = @Email,
        CCCD = @CCCD,
        DiaChi = @DiaChi,
        ChucVu = @ChucVu,
        GioiTinh = @GioiTinh,
        HinhThucLamViec = @HinhThucLamViec
    WHERE ID = @ID;

    IF @@ROWCOUNT > 0
        RETURN 0;   -- Cập nhật thành công
    ELSE
        RETURN 1;   -- Không tìm thấy MaNhanVien để cập nhật
END
GO