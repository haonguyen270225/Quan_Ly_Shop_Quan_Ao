using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BLL
{
    public class  BLL_Interface_HoaDon
    {
        public static KhoHang Get_KhoHang(string maKhoHang , List<KhoHang> listKhoHang)
        {
            foreach(var item in listKhoHang)
            {
                if(item.MaHang == maKhoHang)
                {
                    return item;
                }
            }
            return null;
        
        }
    }
    
}
