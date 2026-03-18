using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HoaDon
    {
        public List<HoaDon> LoadingHoaDon()
        {
            List<HoaDon> listHoaDon = new List<HoaDon>();
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT [ID],[MaHoaDon],[Ngay],[Gio],[TongThu],[IDNhanVien],[IDKhachHang] FROM [Quan_Ly_Shop_Quan_Ao].[dbo].[HoaDon]", conn);

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    HoaDon tmp = new HoaDon();
                    tmp.ID = Convert.ToInt32(dataReader["ID"]);
                    tmp.MaHoaDon = dataReader["MaHoaDon"].ToString();
                    tmp.Ngay = Convert.ToDateTime(dataReader["Ngay"]);
                    tmp.Gio = (TimeSpan)dataReader["Gio"];
                    tmp.TongThu = Convert.ToDouble(dataReader["TongThu"]);
                    tmp.IDNhanVien = Convert.ToInt32(dataReader["IDNhanVien"]);
                    tmp.IDKhachHang = Convert.ToInt32(dataReader["IDKhachHang"]);
                    listHoaDon.Add(tmp);
                }
            }
            conn.Close();
            return listHoaDon;
        }

        public void ThemHoaDon(HoaDon hoaDon)
        {
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"
           INSERT INTO [dbo].[HoaDon]
           ([MaHoaDon]
           ,[Ngay]
           ,[Gio]
           ,[TongThu]
           ,[IDNhanVien]
           ,[IDKhachHang])  
           VALUES
           (@MaHoaDon
           ,@Ngay
           ,@Gio
           ,@TongThu
           ,@IDNhanVien
           ,@IDKhachHang)", conn);
            sqlCommand.Parameters.AddWithValue("@MaHoaDon", hoaDon.MaHoaDon);
            sqlCommand.Parameters.AddWithValue("@Ngay", hoaDon.Ngay);
            sqlCommand.Parameters.AddWithValue("@Gio", hoaDon.Gio);
            sqlCommand.Parameters.AddWithValue("@TongThu", hoaDon.TongThu);
            sqlCommand.Parameters.AddWithValue("@IDNhanVien", hoaDon.IDNhanVien);
            sqlCommand.Parameters.AddWithValue("@IDKhachHang", hoaDon.IDKhachHang);
            sqlCommand.ExecuteNonQuery();
            conn.Close();
        }

        public int DemHoaDon_ByNhanVien(int iDNhanVien)
        {
            int kQ = 0;
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT dbo.DemHoaDon_ByIDNhanVien(@IDNhanVien) AS SoLuongHoaDon;", conn );
            sqlCommand.Parameters.AddWithValue("@IDNhanVien" , iDNhanVien);

            kQ = (int)sqlCommand.ExecuteScalar(); // sử dụng hàm tính toán;
            conn.Close();
            return kQ;
        }



        public decimal TongDoangThu_TheoNgay(DateTime ngay)
        {
            decimal tong = 0;
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT dbo.fn_TongDoanhThu_TheoNgay(@Ngay);", conn);
            sqlCommand.Parameters.AddWithValue("@Ngay", ngay.Date);
            
            tong = (decimal)sqlCommand.ExecuteScalar();
            conn.Close();
            return tong;
        }
    }
}
