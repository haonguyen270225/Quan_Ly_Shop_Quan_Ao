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
       private  DAL_LoadingHoaDon dal_LoadingHoaDon = new DAL_LoadingHoaDon();
       public List<HoaDon> LoadingHoaDon()
        {
            return dal_LoadingHoaDon.LoadingHoaDon();
        }
    

    }
}
