using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging.Design;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_ChucVu
    {
        private DAL_ChucVu dal_ChucVu = new DAL_ChucVu();
        public List<ChucVu> LoadingChucVu()
        {
            return dal_ChucVu.LoadingChucVu();
        }
    }
}
