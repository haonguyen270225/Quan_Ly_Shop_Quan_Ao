using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DataAccess
    {
        public static SqlConnection Connec()
        {
            // Tạo kết nối cơ sở dữ liệu .
            string strcon = @"Data Source=TUFGAMINGF15;Initial Catalog=Quan_Ly_Shop_Quan_Ao;Integrated Security = True;";
            SqlConnection sqlConnection = new SqlConnection(strcon);
            return sqlConnection;
        }
    }
}
