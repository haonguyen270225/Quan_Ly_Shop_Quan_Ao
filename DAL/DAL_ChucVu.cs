using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_ChucVu
    {
        public List<ChucVu> LoadingChucVu()
        {
            List<ChucVu> listChucVu = new List<ChucVu>();
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT [ID] , [TenChucVu] , [MoTa] FROM [Quan_Ly_Shop_Quan_Ao].[dbo].[ChucVu]", conn);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ChucVu tmp = new ChucVu();
                    tmp.ID = Convert.ToInt32(dataReader["ID"]);
                    tmp.TenChucVu = dataReader["TenChucVu"].ToString();
                    tmp.MoTa = dataReader["MoTa"].ToString();
                    listChucVu.Add(tmp);
                }
            }
            conn.Close();
            return listChucVu;
        }
    }
}
