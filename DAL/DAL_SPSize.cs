using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_SPSize
    {
        public List<SPSize> LoadingSize()
        {
            List<SPSize> listSize = new List<SPSize>();
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT [ID] , [MaSize] FROM [Quan_Ly_Shop_Quan_Ao].[dbo].[Size]", conn);

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    SPSize tmp = new SPSize();
                    tmp.ID = Convert.ToInt32(dataReader["ID"]);
                    tmp.MaSize = dataReader["MaSize"].ToString();
                    listSize.Add(tmp);
                }
            }
            conn.Close();
            return listSize;
        }
    }
}
