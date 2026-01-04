using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_LoadingThongTinTaiKhoan
    {
        public TaiKhoan LoadingThongTinTaiKhoan(string userName , string passWord)
        {
            TaiKhoan taiKhoan = new TaiKhoan();
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT * FROM  dbo.LoadingTaiKhoan(@userName , @passWord );", conn);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue ("Password", passWord);

            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read()) 
                {
                    taiKhoan.ID = Convert.ToInt32(dataReader["ID"]);
                    taiKhoan.UserName = dataReader["UserName"].ToString();
                    taiKhoan.PassWord = dataReader["Password"].ToString();
                    taiKhoan.IDNhanVien = Convert.ToInt32(dataReader["IDNhanVien"]);
                }
            }
            conn.Close();
            return taiKhoan;
        }


    }
}
