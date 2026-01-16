using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public  class DAL_TaiKhoan : DAL_DataAccess 
    {
        public  int DAL_CheckLogic(TaiKhoan taiKhoan)
        {
            SqlConnection conn = DAL_DataAccess.Conn();

            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT dbo.CheckLogin(@UserName, @PassWord)", conn);

            sqlCommand.Parameters.AddWithValue("@UserName" , taiKhoan.UserName);
            sqlCommand.Parameters.AddWithValue("@PassWord", taiKhoan.PassWord);

            int ketQua = (int)sqlCommand.ExecuteScalar();

            conn.Close();
            return ketQua;
        }


        public int ThayDoiMatKhau(int iD, string matKhauMoi)
        {
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(
                                            @"declare @ketQua int;
                                            exec @ketQua = sp_ThayDoiMatKhau
	                                        @ID = @iD,
	                                        @NewPassWord = @matKhauMoi;
                                            SELECT @ketQua AS KetQua;", conn);

            sqlCommand.Parameters.AddWithValue("@iD", iD);
            sqlCommand.Parameters.AddWithValue("@matKhauMoi", matKhauMoi);

            int kq = (int)sqlCommand.ExecuteScalar();
            conn.Close();
            return kq;
        }

    }
}
