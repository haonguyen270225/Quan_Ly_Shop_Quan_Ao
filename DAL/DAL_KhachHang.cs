using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhachHang
    {
        public List<KhachHang> LoadingKhachHang()
        {
            List<KhachHang> tmp = new List<KhachHang>();
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();

            SqlCommand sqlCommand = new SqlCommand(@"SELECT [ID],[MaKhachHang],[HoVaTen],[SDT] FROM [Quan_Ly_Shop_Quan_Ao].[dbo].[KhachHang]", conn);

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    KhachHang khachHang = new KhachHang();
                    khachHang.ID = Convert.ToInt32(dataReader["ID"]);
                    khachHang.MaKhachHang = dataReader["MaKhachHang"].ToString();
                    khachHang.HoVaTen = dataReader["HoVaTen"].ToString();
                    khachHang.SDT = dataReader["SDT"].ToString();
                    tmp.Add(khachHang);
                }
            }
            conn.Close();
            return tmp;
        }

        public void ThemKhachHang(KhachHang khachHang)
        {
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"sp_ThemKhachHang", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@MaKhachHang", khachHang.MaKhachHang);
            sqlCommand.Parameters.AddWithValue("@HoVaTen", khachHang.HoVaTen);
            sqlCommand.Parameters.AddWithValue("@SDT", khachHang.SDT);
            sqlCommand.ExecuteNonQuery();
            conn.Close();
        }

    }
}
