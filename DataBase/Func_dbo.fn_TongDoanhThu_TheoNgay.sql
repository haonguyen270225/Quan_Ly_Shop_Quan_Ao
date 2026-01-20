CREATE FUNCTION dbo.fn_TongDoanhThu_TheoNgay
(
	@Ngay DATE 
)
RETURNS 
	DECIMAL(18,2)
AS
BEGIN
	DECLARE @Tong DECIMAL(18,2);
	SELECT @Tong = ISNULL(SUM(TongThu), 0)
	FROM HoaDon
	WHERE CAST(Ngay AS DATE) = @Ngay; 
RETURN @Tong;
END