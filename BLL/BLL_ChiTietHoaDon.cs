using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_ChiTietHoaDon
    {
        DAL_ChiTietHoaDon dal_ChiTietHoaDon = new DAL_ChiTietHoaDon();
        public List<ChiTietHoaDon> LoadingChiTietHoaDon()
        {
            return dal_ChiTietHoaDon.LoadingChiTietHoaDon();
        }

        public void Add(ChiTietHoaDon cTHD)
        {
            dal_ChiTietHoaDon.ThemChiTietHoaDon(cTHD);
        }
    }
}
