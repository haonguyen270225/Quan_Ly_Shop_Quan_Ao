CREATE PROCEDURE sp_Xoa_NhanVienVaTaiKhoan
    @IDNhanVien INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Xóa tài khoản trước (bảng con)
        DELETE FROM TaiKhoan
        WHERE IDNhanVien = @IDNhanVien;

        -- Xóa nhân viên (bảng cha)
        DELETE FROM NhanVien
        WHERE ID = @IDNhanVien;

        COMMIT TRANSACTION;

        RETURN 0;  -- Thành công
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RETURN 1;  -- Thất bại
    END CATCH
END
GO



