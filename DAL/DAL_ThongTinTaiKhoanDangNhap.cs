using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class DAL_ThongTinTaiKhoanDangNhap
    {
       // private NhanVien nhanVien = new NhanVien();
        
        public NhanVien ThongTinTaiKhoanDangNhap(TaiKhoan taiKhoan)
        {
            NhanVien nhanVien = new NhanVien();
            SqlConnection conn = DAL_DataAccess.Connec();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT * FROM dbo.ThongTinTaiKhoan(@UserName, @PassWord);", conn);
            
            sqlCommand.Parameters.AddWithValue("@UserName" , taiKhoan.UserName);
            sqlCommand.Parameters.AddWithValue("@PassWord", taiKhoan.PassWord);

            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    nhanVien.ID = dataReader.GetInt32(0);
                    nhanVien.MaNhanVien = dataReader.GetValue(1).ToString();
                    nhanVien.HoVaTen = dataReader.GetValue(2).ToString();
                    nhanVien.SDT = dataReader.GetValue(3).ToString();
                    nhanVien.Email = dataReader.GetValue(4).ToString();
                    nhanVien.CCCD = dataReader.GetValue(5).ToString();
                    nhanVien.DiaChi = dataReader.GetValue(6).ToString();
                    nhanVien.ChucVu = dataReader.GetValue(7).ToString();
                    nhanVien.GioiTinh = dataReader.GetInt32(8);
                    nhanVien.HinhThucLamViec = dataReader.GetInt32(9);
                }
            }

            conn.Close();
            return nhanVien;
        }

    }
}
