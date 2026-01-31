CREATE PROCEDURE sp_Them_NhanVienVaTaiKhoan
    @MaNhanVien   VARCHAR(10),
    @HoTen        NVARCHAR(50),
    @SDT          VARCHAR(15),
    @Email        VARCHAR(50),
    @CCCD         VARCHAR(15),
    @DiaChi       NVARCHAR(50),
    @IDChucVu      INT,
    @GioiTinh     INT,
    @HinhThucLamViec INT,
    @HinhAnh      VARBINARY(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;


        -- 1. Thêm Nhân Viên (IDNhanVien là IDENTITY)
        INSERT INTO NhanVien (MaNhanVien , HoVaTen , SDT , Email , CCCD , DiaCHi , IDChucVu , GioiTinh , HinhThucLamViec)
        VALUES (@MaNhanVien, @HoTen, @SDT, @Email, @CCCD , @DiaChi , @IDChucVu , @GioiTinh , @HinhThucLamViec);

        -- 2. Lấy ID tự tăng vừa sinh
        DECLARE @IDNhanVien INT;
        SET @IDNhanVien = SCOPE_IDENTITY();

        -- 3. Thêm Tài Khoản mặc định gắn với IDNhanVien
        INSERT INTO TaiKhoan (UserName , PassWord , IDNhanVien , HinhAnh)
        VALUES ('UserName123456', 'PassWord123456', @IDNhanVien , @HinhAnh);

        COMMIT TRANSACTION;
        RETURN 0;   --  Thành công
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT ERROR_MESSAGE();
        RETURN 1;   --  Thất bại
    END CATCH
END
GO

-- Ví dụ :
DECLARE @KQ INT;

EXEC @KQ = sp_Them_NhanVienVaTaiKhoan
    @MaNhanVien = 'NV002',
    @HoTen = N'Nguyễn Văn Minh',
    @SDT = '0987654321',
    @Email = 'MinhAN@gmail.com',
    @CCCD = '012345008901',
    @DiaChi = N'Hà Nội',
    @ChucVu = N'Nhân viên Kho',
    @GioiTinh = 1,
    @HinhThucLamViec = 1,
    @HinhAnh = NULL;

SELECT @KQ AS KetQua;