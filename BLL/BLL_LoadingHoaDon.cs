using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class BLL_LoadingHoaDon
    {
       private  DAL_HoaDon dal_LoadingHoaDon = new DAL_HoaDon();
       public List<HoaDon> LoadingHoaDon()
        {
            return dal_LoadingHoaDon.LoadingHoaDon();
        }
    
        public void ThemHoaDon(HoaDon hoaDon)
        {
            dal_LoadingHoaDon.ThemHoaDon(hoaDon);
        }
    }
}
