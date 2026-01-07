using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_LoadingSPSize
    {
        private DAL_LoadingSize dal_LoadingSize = new DAL_LoadingSize();    
        public List<SPSize> LoadingSPSize()
        {
            return dal_LoadingSize.LoadingSize();
        }



        public  List<KhoHang> LocTheoSize(string maSize , List<SPSize> listSpSize , List<KhoHang> listKhoHang)
        {
            List<KhoHang> tmp = new List<KhoHang>();
            if (maSize == "Size")
            {
                return null;
            }
            else
            {
                  int iD = -1;
                foreach(var item in listSpSize)
                {
                    if(item.MaSize == maSize)
                    {
                        iD = item.ID;
                        break;
                    }
                }
            
                foreach (var item in listKhoHang)
                {
                    if(item.IDSize == iD)
                    {
                        tmp.Add(item);
                    }
                }
             return tmp;
            }
        }
          
    }
}
