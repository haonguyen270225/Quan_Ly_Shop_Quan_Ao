using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_LoadingKhuyenMai
    {
        public List<KhuyenMai> LoadingKhuyenMai()
        {
            List<KhuyenMai> listKhuyenMai = new List<KhuyenMai>();
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT [ID] , [MaKhuyenMai],[ThongTin] , [GiaTri] FROM [Quan_Ly_Shop_Quan_Ao].[dbo].[KhuyenMai]", conn);

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    KhuyenMai khuyenMai = new KhuyenMai();
                    khuyenMai.ID = Convert.ToInt32(dataReader["ID"]);
                    khuyenMai.MaKhuyenMai = dataReader["MaKhuyenMai"].ToString();
                    khuyenMai.ThongTin = dataReader["ThongTin"].ToString();
                    listKhuyenMai.Add(khuyenMai);
                }
            }
            conn.Close();
            return listKhuyenMai;
        }
    }
}
