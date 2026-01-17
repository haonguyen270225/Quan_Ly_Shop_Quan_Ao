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
    }
}
