using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.UI.Design;
namespace BLL
{
    public class BLL_NhanVien
    {
        
        private DAL_NhanVien dal_NhanVien = new DAL_NhanVien();
        
        public  List<NhanVien>  LoadingNhanVien()
        {
           // List<NhanVien> listNhanVien = new List<NhanVien>();          
            return new List<NhanVien>(dal_NhanVien.LoadingNhanVien()); 
        }


        public static string LoadingHinhThucLamViec(int i)
        {
            if (i == 0)
            {
                return "Full time";
            }
            else
            {
                return "Pass time";
            }
        }

        public List<NhanVien> TimKiem(string maNhanVien , string hoVaTen , string chucVu , string hinhThucLamViec , List<NhanVien> listNhanVien)
        {
            List<NhanVien> listTK = new List<NhanVien>();

            // for(int i = 0; i < listNhanVien.Count; i++)
            // {
            //     if(str == listNhanVien[i].MaNhanVien)
            //     {
            //         listTK.Add(listNhanVien[i]);
            //     }
            // }
            //return listTK;

            if (maNhanVien != "" && hoVaTen != "" && chucVu == "" && hinhThucLamViec == "")
            {
                for (int i = 0; i < listNhanVien.Count; i++)
                {
                    if (maNhanVien == listNhanVien[i].MaNhanVien && hoVaTen == listNhanVien[i].HoVaTen)
                    {
                        listTK.Add(listNhanVien[i]);
                    }
                }
               
            }
            else if (maNhanVien != "" && hoVaTen == "" && chucVu == "" && hinhThucLamViec == "")
            {
                for (int i = 0; i < listNhanVien.Count; i++)
                {
                    if (maNhanVien == listNhanVien[i].MaNhanVien)
                    {
                        listTK.Add(listNhanVien[i]);
                    }
                }
               
            }
            else if (maNhanVien == "" && hoVaTen != "" && chucVu == "" && hinhThucLamViec == "")
            {
                for (int i = 0; i < listNhanVien.Count; i++)
                {
                    if (hoVaTen == listNhanVien[i].HoVaTen)
                    {
                        listTK.Add(listNhanVien[i]);
                    }
                }
                
            }
            else if (maNhanVien == "" && hoVaTen == "" && chucVu != ""  && hinhThucLamViec == "")
            {
                for (int i = 0; i < listNhanVien.Count; i++)
                {
                    if (chucVu == listNhanVien[i].ChucVu)
                    {
                        listTK.Add(listNhanVien[i]);
                    }
                }
               
            }
            else if(maNhanVien == "" && hoVaTen == "" && chucVu == "" && hinhThucLamViec != "")
            {
                int tmp;
                if(hinhThucLamViec == "Full time")
                {
                    tmp = 0;
                }
                else
                {
                    tmp = 1;
                }
                for (int i = 0; i < listNhanVien.Count; i++)
                {
                    if (tmp == listNhanVien[i].HinhThucLamViec)
                    {
                        listTK.Add(listNhanVien[i]);
                    }
                }
              
            }
            else if(maNhanVien == "" && hoVaTen == "" && chucVu != "" && hinhThucLamViec != "")
            {
                int tmp;
                if (hinhThucLamViec == "Full time")
                {
                    tmp = 0;
                }
                else
                {
                    tmp = 1;
                }
                for (int i = 0; i < listNhanVien.Count; i++)
                {
                    if (tmp == listNhanVien[i].HinhThucLamViec && chucVu == listNhanVien[i].ChucVu)
                    {
                        listTK.Add(listNhanVien[i]);
                    }
                }
               
            }
            return listTK;
        }

        public NhanVien TT_NhanVienDangNhap(TaiKhoan taiKhoan)
        {
            return dal_NhanVien.Loading_NhanVienDangNhap(taiKhoan);
        }

        public bool CapNhat_NhanVien(NhanVien nhanVien , List<NhanVien> listNhanVien , byte[] hinhAnh ,out string thongBao)
        {
            BLL_TaiKhoan bll_TaiKhoan = new BLL_TaiKhoan();

            if (bll_TaiKhoan.CapNhatHinhAnh_TaoKhoan(nhanVien.ID , hinhAnh , out thongBao) == false)
            {
                return false;
            }
            if(Check_CapNhat_NhanVien(nhanVien, listNhanVien, out thongBao) == false)
            {
                return false;
            }
            else if ( dal_NhanVien.CapNhat_NhanVien(nhanVien) == 1)
            {
                thongBao = "DAL : Cập nhật thất bại ! \n Vui lòng thử lại !";
                return false;
            }
            else
            {
                thongBao = "Cập nhật thành công !";
                return true;
            }

        }
        public bool Check_CapNhat_NhanVien(NhanVien nhanVien ,List<NhanVien> listNhanVien, out string thongBao)
        {
            thongBao = "";
            if (nhanVien.HoVaTen.Length < 5 || nhanVien.HoVaTen.Length > 50)
            {
                thongBao = "Họ và tên : \n Tối đa : 50 ký tự . \n Tối thiểu : 5 ký tự .";
                return false;
            } 
            else if (nhanVien.MaNhanVien.Length < 5 || nhanVien.MaNhanVien.Length > 10)
            {
                thongBao = "Mã nhân viên : \n Tối đa : 10 ký tự . \n Tối thiểu : 5 ký tự !";
                return false;
            }
            else if (nhanVien.SDT.Length != 10)
            {
                thongBao = "Số điện thoại phải 10 chữ số !";
                return false;
            }
            else if (nhanVien.CCCD.Length != 12)
            {
                thongBao = "CCCD phải 12 chữ số !";
                return false;
            }
            else if (nhanVien.HoVaTen == "")
            {
                thongBao = "Họ và tên không được để trống !";
                return false;
            }
            else if (nhanVien.MaNhanVien == "")
            {
                thongBao = "Mã nhân viên không được để trống !";
                return false;
                
            }
            else if (nhanVien.ChucVu == "")
            {
                thongBao = " Chức vụ không được để trống !";
                return false;
            }
            else if (nhanVien.DiaChi == "")
            {
                thongBao = "Địa chỉ nhân viên không được để trống !";
                return false;
            }
            else if (nhanVien.SDT == "")
            {
                thongBao = "Số điện thoại không được để trống !";
                return false;
               
            }
            else if (nhanVien.CCCD == "")
            {
                thongBao = "CCCD không được để trống !";
                return false;
            }
            else if (nhanVien.Email == "")
            {
                thongBao = "Email không được để trống !";
                return false;
            }
            else if (XuLy_Chuoi.KiemTra_HoVaTen(nhanVien.HoVaTen) == false)
            {
                thongBao = "Họ và tên không chứa các ký tự đặc biệt !";
                return false;
            }
            else if (XuLy_Chuoi.KiemTra_Ma(nhanVien.MaNhanVien) == false)
            {
                thongBao = "Mã nhân viên chỉ chứa chứ cái không dấu và số!";
                return false;
            }
            else if (XuLy_Chuoi.KiemTra_STD(nhanVien.SDT) == false)
            {
                thongBao = "Số điện thoại chỉ chứa  chữ số !";
                return false;
            }
            else
            {
              
                for(int i = 0; i < listNhanVien.Count; i++)
                {
                    if (listNhanVien[i].ID == nhanVien.ID)
                    {
                        listNhanVien.RemoveAt(i);
                    }
                }
                foreach (NhanVien item in listNhanVien)
                {
                    if(item.CCCD == nhanVien.CCCD)
                    {
                        thongBao = "CCCD đã bị trùng !";
                        return false;
                    }
                    if(item.MaNhanVien == nhanVien.MaNhanVien) 
                    {
                        thongBao = "Mã nhân viên đã bị trùng !";
                        return false;
                    }
                    if(item.SDT == nhanVien.SDT)
                    {
                        thongBao = "SĐT đã bị trùng !";
                        return false;
                    }
                }
                return true;
            }
           
        }

        public bool Xoa_NhanVienVaTaiKhoan(NhanVien nhanVien)
        {
            if(dal_NhanVien.Xoa_NhanVienVaTaiKhoan(nhanVien.ID) == 1 || nhanVien == null || nhanVien.ID == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public bool Them_NhanVienvaTaiKhoan(NhanVien nhanVien , List<NhanVien> listNhanVien , byte[] hinhAnh , out string thongBao)
        {
            thongBao = "";
            if(Check_CapNhat_NhanVien(nhanVien, listNhanVien, out thongBao) == false)
            {
                return false;
            }
            //byte[] hinhAnh = ConvertImagePathToBytes(imagePath);
            if (dal_NhanVien.Them_NhanVienVaTaiKhoan(nhanVien , hinhAnh) == 1)
            {
                thongBao = "Lỗi cơ sở dữ liệu ! \n Vui lòng thử lại !";
                return false;
            }
            else
            {
                thongBao = "Đã thêm nhân viên : \n Họ và tên : " + nhanVien.HoVaTen + "\n Mã nhân  viên : " + nhanVien.MaNhanVien;
                return true;
            }
        }


        //public static byte[] ConvertImagePathToBytes(string imagePath)
        //{
        //    if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath)) //!File.Exists(imagePath) -> file không tồn tại tại đường dẫn đó ?
        //        return null;
        //    return File.ReadAllBytes(imagePath);
        //}
    }
}
