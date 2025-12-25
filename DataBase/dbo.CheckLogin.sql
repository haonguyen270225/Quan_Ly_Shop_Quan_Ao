CREATE FUNCTION dbo.CheckLogin
(
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(100)
)
RETURNS INT
AS
BEGIN
    DECLARE @KetQua INT = 0;  -- 0: sai, 1: đúng, có thể mở rộng thêm mã lỗi
    IF EXISTS (
        SELECT 1 
        FROM TaiKhoan
        WHERE UserName = @TenDangNhap AND PassWord = @MatKhau   
    )
    BEGIN
        SET @KetQua = 1;
    END

    RETURN @KetQua;
END;

-- select dbo.CheckLogin('an.nguyen' , '123456') as KetQua; // Chú ý : Kiểm tra ở một Query riêng;