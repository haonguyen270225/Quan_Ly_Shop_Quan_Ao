using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class BLL_LoadingChiTietHoaDon
    {
        DAL_LoadingChiTietHoaDon dal_LoadingChiTietHoaDon = new DAL_LoadingChiTietHoaDon();
        public List<ChiTietHoaDon> LoadingChiTietHoaDon()
        {
            return dal_LoadingChiTietHoaDon.LoadingChiTietHoaDon();
        }
    }
}
