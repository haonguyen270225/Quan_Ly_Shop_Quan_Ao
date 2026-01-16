CREATE OR ALTER PROCEDURE sp_CapNhatHinhAnhTaiKhoan
    @ID          INT,
    @IDNhanVien INT,
    @UserName    NVARCHAR(50),          -- Điều chỉnh kích thước nếu cần
    @PassWord    NVARCHAR(50),         -- Nên dùng hashed password trong thực tế
    @HinhAnh     VARBINARY(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra tài khoản tồn tại và khớp UserName + Password
    IF NOT EXISTS (
        SELECT 1 
        FROM dbo.TaiKhoan 
        WHERE ID = @ID 
          AND IDNhanVien = @IDNhanVien
          AND UserName = @UserName 
          AND Password = @Password   -- Nếu dùng hashed, thay bằng so sánh hashed
    )
    BEGIN
        -- Thất bại: trả về 1
        SELECT 1 AS KetQua, 
               N'Tài khoản không tồn tại hoặc mật khẩu không đúng!' AS ThongBao;
        RETURN;
    END

    -- Cập nhật ảnh
    UPDATE dbo.TaiKhoan
    SET HinhAnh = @HinhAnh
    WHERE ID = @ID;

    -- Kiểm tra xem có cập nhật thành công không (thường @@ROWCOUNT = 1 nếu ID tồn tại)
    IF @@ROWCOUNT > 0
    BEGIN
        -- Thành công: trả về 0
        SELECT 0 AS KetQua, 
               N'Cập nhật hình ảnh thành công!' AS ThongBao;
    END
    ELSE
    BEGIN
        -- Trường hợp hiếm: cập nhật không ảnh hưởng dòng nào (lỗi logic)
        SELECT 1 AS KetQua, 
               N'Cập nhật thất bại (không tìm thấy bản ghi)!' AS ThongBao;
    END
END
GO