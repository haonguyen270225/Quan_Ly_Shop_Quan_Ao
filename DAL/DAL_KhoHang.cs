using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public  class DAL_KhoHang : DAL_DataAccess
    {
        public List<KhoHang> LoadingKhoHang()
        {
            List<KhoHang> listKhoHang = new List<KhoHang>();
            
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT [ID],[MaHang],[TenHang],[SoLuongTon],[Gia],[IDSize],[IDLoaiSanPham] FROM [Quan_Ly_Shop_Quan_Ao].[dbo].[KhoHang]", conn);

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    KhoHang tmp = new KhoHang();
                    tmp.TenHang = dataReader["TenHang"].ToString();
                    tmp.ID = Convert.ToInt32(dataReader["ID"]);
                    tmp.MaHang = dataReader["MaHang"].ToString();
                    tmp.SoLuongTon = Convert.ToInt32(dataReader["SoLuongTon"]);
                    tmp.Gia = Convert.ToDouble(dataReader["Gia"]);
                    tmp.IDSize = Convert.ToInt32(dataReader["IDSize"]);
                    tmp.IDLoaiSanPham = Convert.ToInt32(dataReader["IDLoaiSanPham"]);
                    listKhoHang.Add(tmp);
                }
            }
            conn.Close();
            return listKhoHang;

        } 
    }
}
