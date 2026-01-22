using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
namespace DAL
{
    public  class DAL_KhoHang : DAL_DataAccess
    {
        public List<KhoHang> LoadingKhoHang()
        {
            List<KhoHang> listKhoHang = new List<KhoHang>();
            
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT [ID],[MaHang],[TenHang],[SoLuongTon],[Gia],[IDSize],[IDLoaiSanPham] , [HinhAnh] FROM [Quan_Ly_Shop_Quan_Ao].[dbo].[KhoHang]", conn);

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

                    if(dataReader["HinhAnh"] == DBNull.Value)
                    {
                        tmp.HinhAnh = null;
                    }
                    else
                    {
                        tmp.HinhAnh = (Byte[])dataReader["HinhAnh"];
                    }
                    //object obj = (Byte[])dataReader["HinhAnh"];
                    //tmp.HinhAnh = obj == DBNull.Value ? null : (byte[])obj;
                    listKhoHang.Add(tmp);
                }
            }
            conn.Close();
            return listKhoHang;

        } 

        public int Xoa_KhoHangByID(int iD)
        {
            int kQ = 1; // Xóa không thành công;
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand( @"sp_XoaKhoHang" ,conn);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", iD);

            // Tham số nhận RETURN
            SqlParameter returnParam = new SqlParameter();
            returnParam.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.Add(returnParam);

            sqlCommand.ExecuteNonQuery();
            kQ = (int)returnParam.Value;
            conn.Close();
            return kQ;
        }

        public int Xoa_KhoHangByID(string maHang)
        {
            int kQ = 1; // Xóa không thành công;
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"sp_XoaKhoHangByMaHang", conn);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@MaHang" ,maHang);

            // Tham số nhận RETURN
            SqlParameter returnParam = new SqlParameter();
            returnParam.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.Add(returnParam);

            sqlCommand.ExecuteNonQuery();
            kQ = (int)returnParam.Value;
            conn.Close();
            return kQ;
        }


        public int UpdateHinhAnh(string maHang , byte[] hinhAnh)
        {
            int kQ = 1; // cập nhật không thành công;
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"sp_UpdateHinhAnhKhoHang", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@MaHang", maHang);
            
            if(hinhAnh == null || hinhAnh.Length <= 0)
            {
                sqlCommand.Parameters.AddWithValue("@HinhAnh", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@HinhAnh" , hinhAnh);
            }

            SqlParameter returnParam = new SqlParameter();
            returnParam.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.Add(returnParam);

            sqlCommand.ExecuteNonQuery();
            kQ = (int)returnParam.Value;
            conn.Close();
            return kQ;
        }
        public int DleteKhoHang_ByMaHang(string maHang)
        {
            int kQ = 1; //-- không thể delete sản phẩm có maHang;
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("sp_DeleteKhoHang_ByMaHang", conn);
            sqlCommand.CommandType= CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@MaHang", maHang);

            // trả về int;
            SqlParameter returnParam = new SqlParameter();
            returnParam.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.Add(returnParam);

            sqlCommand.ExecuteNonQuery();
            kQ = (int)returnParam.Value;
            conn.Close();
            return kQ;
        }


        public int Insert_KhoHang(KhoHang khoHang)
        {

            int kQ = 1; //-- không thể insert sản phẩm có maHang;
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("sp_InsertKhoHang", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@MaHang",khoHang.MaHang);
            sqlCommand.Parameters.AddWithValue("@TenHang",khoHang.TenHang);
            sqlCommand.Parameters.AddWithValue("@SoLuongTon", khoHang.SoLuongTon);
            sqlCommand.Parameters.AddWithValue("@Gia", khoHang.Gia);
            sqlCommand.Parameters.AddWithValue("@IDSize", khoHang.IDSize);
            sqlCommand.Parameters.AddWithValue("@IDLoaiSanPham", khoHang.IDLoaiSanPham);
            sqlCommand.Parameters.Add("@HinhAnh", SqlDbType.VarBinary).Value =
                  khoHang.HinhAnh != null ? (object)khoHang.HinhAnh : DBNull.Value;
            // trả về int;
            SqlParameter returnParam = new SqlParameter();
            returnParam.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.Add(returnParam);

            sqlCommand.ExecuteNonQuery();
            kQ = (int)returnParam.Value;
            conn.Close();
            return kQ;
        }



        public int Update_KhoHang(KhoHang khoHang)
        {
            int kQ = 1; //-- không thể update sản phẩm có maHang;
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            
            SqlCommand sqlCommand = new SqlCommand("sp_UpdateKhoHang", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", khoHang.ID);
            sqlCommand.Parameters.AddWithValue("@MaHang", khoHang.MaHang);
            sqlCommand.Parameters.AddWithValue("@TenHang", khoHang.TenHang);
            sqlCommand.Parameters.AddWithValue("@SoLuongTon", khoHang.SoLuongTon);
            sqlCommand.Parameters.AddWithValue("@Gia", khoHang.Gia);
            sqlCommand.Parameters.AddWithValue("@IDSize", khoHang.IDSize);
            sqlCommand.Parameters.AddWithValue("@IDLoaiSanPham", khoHang.IDLoaiSanPham);
            
            // trả về int;
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
