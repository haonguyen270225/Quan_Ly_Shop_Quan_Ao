using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_LoadingKhachHang
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
    }
}
