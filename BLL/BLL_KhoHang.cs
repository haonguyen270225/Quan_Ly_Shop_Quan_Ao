using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_KhoHang
    {
        private DAL_KhoHang dal_KhoHang = new DAL_KhoHang();
        public List<KhoHang> LoadingKhoHang()
        {
            List<KhoHang> listKhoHang = new List<KhoHang>();
            listKhoHang = dal_KhoHang.LoadingKhoHang();
            return listKhoHang;
        }
    }
}
