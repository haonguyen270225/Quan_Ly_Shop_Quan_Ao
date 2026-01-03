--create procedure sp_ThayDoiMatKhau
--(
--	@ID int,
--	@NewPassWord varchar(50) -- mật khẩu mới!
--)
--as 
--begin
--	set nocount on;
--	-- kiểm tra mật khẩu >= 10 ký tự;
--	if len(@NewPassWord) < 10
--	begin
--	return -1; -- mật khẩu không đủ dài !
--	end
	
--	update [dbo].[TaiKhoan]
--	set [dbo].[TaiKhoan].PassWord = @NewPassWord
--	where [dbo].[TaiKhoan].ID = @ID;

--	if @@ROWCOUNT > 0
--		return 1; -- Cập nhật thành công;
--	else
--		return 0; -- Cập nhật thất bại !;
--end

CREATE OR ALTER PROCEDURE sp_ThayDoiMatKhau
(
	@ID int,
	@NewPassWord varchar(50) -- mật khẩu mới!
)
as 
begin
	set nocount on;
	-- kiểm tra mật khẩu >= 10 ký tự;
	if len(@NewPassWord) < 10 
	begin
	return -1; -- Mật khẩu không đủ dài !
	end
	if  len(@NewPassWord) > 30
	begin
	return -2; -- Mật khẩu quá số lượng  quy định !
	end
	
	update [dbo].[TaiKhoan]
	set [dbo].[TaiKhoan].PassWord = @NewPassWord
	where [dbo].[TaiKhoan].ID = @ID;

	if @@ROWCOUNT > 0
		return 1; -- Cập nhật thành công;
	else
		return 0; -- Cập nhật thất bại !;
end


declare @ketQua int;
exec @ketQua = sp_ThayDoiMatKhau
	@ID = 1,
	@NewPassWord = 'aaaaaaaaaaaa';
SELECT @ketQua AS KetQua;