using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Runtime.InteropServices;
namespace BLL
{
    public class BLL_LoadingKhachHang
    {
        DAL_LoadingKhachHang dal_LoadingKhachHang = new DAL_LoadingKhachHang();

        public List<KhachHang> LoadingKhachHang()
        {
            return dal_LoadingKhachHang.LoadingKhachHang();
        }
    }
}
