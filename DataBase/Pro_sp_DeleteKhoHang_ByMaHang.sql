
--CREATE PROCEDURE sp_DeleteKhoHang_ByMaHang
--    @MaHang NVARCHAR(10)
--AS
--BEGIN
--    SET NOCOUNT ON;

--    -- Kiểm tra tồn tại
--    IF NOT EXISTS (SELECT 1 FROM KhoHang WHERE MaHang = @MaHang)
--    BEGIN
--        RETURN 1; -- Không tồn tại => không xóa được
--    END

--    -- Thực hiện xóa
--    DELETE FROM KhoHang
--    WHERE MaHang = @MaHang;

--    -- Kiểm tra kết quả
--    IF @@ROWCOUNT = 0
--        RETURN 1; -- Xóa thất bại

--    RETURN 0; -- Xóa thành công
--END



DECLARE @Result INT;
EXEC @Result = sp_DeleteKhoHang_ByMaHang @MaHang = 'MH027';
SELECT @Result AS KetQua;