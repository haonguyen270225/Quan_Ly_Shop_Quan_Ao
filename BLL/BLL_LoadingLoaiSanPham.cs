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
        private DAL_LoadingLoaiSanPham dal_LoadingLoaiSanPham = new DAL_LoadingLoaiSanPham();

        public List<LoaiSanPham> LoadingLoaiSanPham()
        {
            return dal_LoadingLoaiSanPham.LoadingLoaiSanPham();
        }
    }
}
