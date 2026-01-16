using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class BLL_LoadingKhoHang
    {
        private DAL_KhoHang dal_LoadingKhoHang = new DAL_KhoHang();
        public List<KhoHang> LoadingKhoHang() 
        {
            List<KhoHang> listKhoHang = new List<KhoHang>();
            listKhoHang = dal_LoadingKhoHang.LoadingKhoHang();
            return listKhoHang;
        }
    }
}
