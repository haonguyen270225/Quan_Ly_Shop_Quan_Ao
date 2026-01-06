using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_ThongTinNhanVien 
    {
        public  List<NhanVien> NhanVienAccess()
        {
            List<NhanVien> listNhanVienTmp = new List<NhanVien>();

            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT [ID], [MaNhanVien], [HoVaTen], [SDT], [Email], [CCCD], [DiaChi], [ChucVu], [GioiTinh] , [HinhThucLamViec] FROM [Quan_Ly_Shop_Quan_Ao].[dbo].[NhanVien]" , conn);

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            if (dataReader.HasRows)
            {
               
                while (dataReader.Read())
                {
                    NhanVien tmp = new NhanVien();
                    tmp.ID  = dataReader.GetInt32(0);
                    tmp.MaNhanVien = dataReader.GetValue(1).ToString();
                    tmp.HoVaTen = dataReader.GetValue(2).ToString();
                    tmp.SDT = dataReader.GetValue(3).ToString();
                    tmp.Email = dataReader.GetValue(4).ToString();
                    tmp.CCCD = dataReader.GetValue(5).ToString();
                    tmp.DiaChi = dataReader.GetValue(6).ToString();
                    tmp.ChucVu = dataReader.GetValue(7).ToString();
                    tmp.GioiTinh = dataReader.GetInt32(8);
                    tmp.HinhThucLamViec = dataReader.GetInt32(9);
                    listNhanVienTmp.Add(tmp);
                }
            }
           
            conn.Close();

            return listNhanVienTmp;
        }
    }
}
