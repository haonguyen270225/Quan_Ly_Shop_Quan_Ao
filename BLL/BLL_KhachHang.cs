using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_KhachHang
    {

        DAL_KhachHang dal_KhachHang = new DAL_KhachHang();


        public List<KhachHang> LoadingKhachHang()
        {
            return dal_KhachHang.LoadingKhachHang();
        }

        public void _serverThemKhachHang(KhachHang khacHang)
        {
            SqlConnection conn = DAL_DataAccess.Conn();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO [dbo].[KhachHang]
           ([MaKhachHang]
           ,[HoVaTen]
           ,[SDT]) 
            VALUES (@maKhachHang,@hoVaTen,@sDt", conn);
            sqlCommand.Parameters.AddWithValue("@maKhachHang", khacHang.MaKhachHang);
            sqlCommand.Parameters.AddWithValue("@hoVaTen", khacHang.HoVaTen);
            sqlCommand.Parameters.AddWithValue("@sDt", khacHang.SDT);
            sqlCommand.ExecuteReader();
            conn.Close();
        }

        public static string Check_ThemKhachHang(KhachHang kh, List<KhachHang> listKhachHang, List<HoaDon> listHoDon, string maHoaDon)
        {
            #region demo
            //{
            //    //kQ = true;
            //    if(khacHang.HoVaTen.Length == 0 || khacHang.SDT.Length == 0 || khacHang.MaKhachHang.Length == 0 )
            //    {
            //        kQ = false;
            //        return "Text box không được để trống !";
            //    }
            //    else if(XuLy_Chuoi.KiemTra_Ma(khacHang.MaKhachHang) == false) 
            //    {
            //         kQ = false;
            //        return "Mã khách hàng không chứa ký tự đặc biệt hoặc khoảng trắng !";
            //    }
            //    else if(XuLy_Chuoi.KiemTra_HoVaTen(khacHang.HoVaTen) == false){
            //        kQ = false;
            //        return "Họ và tên không chứa ký tự đặc biệt hoặc chữ số !";
            //    }
            //    else if (XuLy_Chuoi.KiemTra_STD(khacHang.SDT) == false )
            //    {
            //        kQ = false;
            //        return "Số điện thoại phải là chữ số !";
            //    }
            //    else
            //    {
            //        kQ = true;
            //        return "Thông tin khách hàng : " + khacHang.MaKhachHang + khacHang.HoVaTen + khacHang.SDT;
            //    }
            #endregion
            if (kh == null)
                throw new Exception("Khách hàng không hợp lệ");

            if (string.IsNullOrWhiteSpace(kh.MaKhachHang) ||
                string.IsNullOrWhiteSpace(kh.HoVaTen) ||
                string.IsNullOrWhiteSpace(kh.SDT) ||
                string.IsNullOrWhiteSpace(maHoaDon))
                throw new Exception("Text box không được để trống");
            foreach (KhachHang item in listKhachHang)
            {
                if (item.MaKhachHang == kh.MaKhachHang)
                {
                    throw new Exception("Mã khách hàng đã bị trùng !");
                }
                if (item.SDT == kh.SDT)
                {
                    throw new Exception("Số điện thoại đã bị trùng !");

                }
            }
            foreach (HoaDon item in listHoDon)
            {
                if (item.MaHoaDon == maHoaDon)
                {
                    throw new Exception("Mã hóa đơn đã bị trùng !");
                }
            }
            if (XuLy_Chuoi.KiemTra_Ma(maHoaDon) == false)
                throw new Exception("Mã hóa đơn không chứa khoảng trắng và ký tự đặc biệt !");
            if (XuLy_Chuoi.KiemTra_Ma(kh.MaKhachHang) == false)
                throw new Exception("Mã khách hàng không chứa khoảng trắng và ký tự đặc biệt !");

            if (XuLy_Chuoi.KiemTra_HoVaTen(kh.HoVaTen) == false)
                throw new Exception("Họ và tên không chứa số và ký tự đặc biệt !");

            if (XuLy_Chuoi.KiemTra_STD(kh.SDT) == false)
                throw new Exception("Số điện thoại không hợp lệ !");
            if (kh.HoVaTen.Length > 50 || kh.HoVaTen.Length < 5)
                throw new Exception("Họ và tên dài  lớn hơn 5 và nhỏ hơn 50 ký tự !");
            if (kh.MaKhachHang.Length > 10 || kh.MaKhachHang.Length < 5)
                throw new Exception("Mã khách hàng lớn hơn 5  và nhỏ hơn 10 ký tự !");
            if (kh.SDT.Length != 10)
                throw new Exception("SDT phải bằng  10 ký tự ! ");
            return null; // hợp lệ !
        }


        public void ThemKhachHang(KhachHang khachHang)
        {
            dal_KhachHang.ThemKhachHang(khachHang);
        }
    }
}
