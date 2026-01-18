using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_NhanVien 
    {
        public  List<NhanVien> LoadingNhanVien()
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

        public NhanVien Loading_NhanVienDangNhap(TaiKhoan taiKhoan)
        {
            NhanVien nhanVien = new NhanVien();
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT * FROM dbo.ThongTinTaiKhoan(@UserName, @PassWord);", conn);

            sqlCommand.Parameters.AddWithValue("@UserName", taiKhoan.UserName);
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

        public int CapNhat_NhanVien(NhanVien nhanVien)
        {
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            int kQ = 1;
            SqlCommand sqlCommand = new SqlCommand(@"sp_UpdateNhanVien", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@MaNhanVien", nhanVien.MaNhanVien);
            sqlCommand.Parameters.AddWithValue("@HoVaTen", nhanVien.HoVaTen);
            sqlCommand.Parameters.AddWithValue("@SDT", nhanVien.SDT);
            sqlCommand.Parameters.AddWithValue("@CCCD", nhanVien.CCCD);
            sqlCommand.Parameters.AddWithValue("@Email", nhanVien.Email);
            sqlCommand.Parameters.AddWithValue("@ChucVu", nhanVien.ChucVu);
            sqlCommand.Parameters.AddWithValue("@GioiTinh", nhanVien.GioiTinh);
            sqlCommand.Parameters.AddWithValue("@HinhThucLamViec", nhanVien.HinhThucLamViec);
            // Tham số nhận RETURN
            SqlParameter returnParam = new SqlParameter();
            returnParam.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.Add(returnParam);

            sqlCommand.ExecuteNonQuery();
            kQ = (int)returnParam.Value;
            conn.Close();
            return kQ;
        }
    }
}
