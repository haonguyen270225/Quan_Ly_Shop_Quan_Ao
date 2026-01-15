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
    public class DAL_LoadingChiTietHoaDon
    {
        public List<ChiTietHoaDon> LoadingChiTietHoaDon()
        {
            List<ChiTietHoaDon> listChiTietHoaDon = new List<ChiTietHoaDon>();
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT [ID],[SoLuong],[TongTien],[IDMaHang],[IDHoaDon] FROM [dbo].[ChiTietHoaDon]", conn);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                   ChiTietHoaDon tmp = new ChiTietHoaDon();
                    tmp.ID = Convert.ToInt32(dataReader["ID"]);
                    tmp.SoLuong = Convert.ToInt32(dataReader["SoLuong"]);
                    tmp.TongTien = Convert.ToDouble(dataReader["TongTien"]);
                    tmp.IDMaHang = Convert.ToInt32(dataReader["IDMaHang"]);
                    tmp.IDHoaDon = Convert.ToInt32(dataReader["IDHoaDon"]);
                   listChiTietHoaDon.Add(tmp);
                }
            }
            conn.Close();
            return listChiTietHoaDon;
        }
    }
}
