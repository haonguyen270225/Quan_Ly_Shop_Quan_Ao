CREATE PROCEDURE sp_XoaKhoHang
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM KhoHang
    WHERE ID = @ID;

    IF @@ROWCOUNT > 0
        RETURN 0;   -- Xóa thành công
    ELSE
        RETURN 1;   -- Không có dữ liệu để xóa
END
GO