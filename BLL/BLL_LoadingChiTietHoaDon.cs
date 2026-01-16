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
        DAL_ChiTietHoaDon dal_LoadingChiTietHoaDon = new DAL_ChiTietHoaDon();
        public List<ChiTietHoaDon> LoadingChiTietHoaDon()
        {
            return dal_LoadingChiTietHoaDon.LoadingChiTietHoaDon();
        }
    }
}
