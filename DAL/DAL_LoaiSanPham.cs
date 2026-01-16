using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_LoaiSanPham
    {
        public List<LoaiSanPham> LoadingLoaiSanPham()
        {
            List<LoaiSanPham> listLoaiSanPham = new List<LoaiSanPham>();

            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT [ID],[MaLoaiSanPham],[TenLoai],[GioiTinh] FROM [Quan_Ly_Shop_Quan_Ao].[dbo].[LoaiSanPham]", conn);

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    LoaiSanPham tmp = new LoaiSanPham();
                    tmp.ID = Convert.ToInt32(dataReader["ID"]);
                    tmp.MaLoaiSanPham = dataReader["MaLoaiSanPham"].ToString();
                    tmp.TenLoai = dataReader["TenLoai"].ToString();
                    tmp.GioiTinh = Convert.ToInt32(dataReader["GioiTinh"]);
                    listLoaiSanPham.Add(tmp);
                }
            }
            conn.Close();
            return listLoaiSanPham;

        }
    }
}
