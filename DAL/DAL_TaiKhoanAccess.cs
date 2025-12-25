using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public  class DAL_TaiKhoanAccess : DAL_DataAccess 
    {
        public  int DAL_CheckLogic(TaiKhoan taiKhoan)
        {
            SqlConnection conn = DAL_DataAccess.Connec();

            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT dbo.CheckLogin(@UserName, @PassWord)", conn);

            sqlCommand.Parameters.AddWithValue("@UserName" , taiKhoan.UserName);
            sqlCommand.Parameters.AddWithValue("@PassWord", taiKhoan.PassWord);

            int ketQua = (int)sqlCommand.ExecuteScalar();

            return ketQua;
        }

    }
}
