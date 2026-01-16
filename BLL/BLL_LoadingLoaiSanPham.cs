using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_LoadingLoaiSanPham
    {
        private DAL_LoaiSanPham dal_LoadingLoaiSanPham = new DAL_LoaiSanPham();

        public List<LoaiSanPham> LoadingLoaiSanPham()
        {
            return dal_LoadingLoaiSanPham.LoadingLoaiSanPham();
        }

        public List<KhoHang> LocLoaiSanPham(string tenLoai , List<LoaiSanPham> listLoaiSanPham , List<KhoHang>  listKhoHang)
        {
             List<KhoHang> tmpKhoHang = new List<KhoHang>();
             if(tenLoai == "Mã quần áo !")
            {
                return null;
            }
            else
            {
                int iD = -1;
                foreach(var item in listLoaiSanPham)
                {
                    if (item.TenLoai == tenLoai)
                    {
                        iD = item.ID;
                    }
                }
                foreach(var item in listKhoHang)
                {
                    if (item.IDLoaiSanPham == iD)
                    {
                        tmpKhoHang.Add(item);
                    }
                }
                return tmpKhoHang;
            }
        }
    }
}
