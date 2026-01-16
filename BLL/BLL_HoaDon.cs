using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_HoaDon
    {
        private DAL_HoaDon dal_HoaDon = new DAL_HoaDon();
        public List<HoaDon> LoadingHoaDon()
        {
            return dal_HoaDon.LoadingHoaDon();
        }

        public void ThemHoaDon(HoaDon hoaDon)
        {
            dal_HoaDon.ThemHoaDon(hoaDon);
        }
    }
}
