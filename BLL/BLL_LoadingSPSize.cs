using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
