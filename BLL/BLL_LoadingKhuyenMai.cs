using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO; 
namespace BLL
{
    public class BLL_LoadingKhuyenMai
    { 
        private DAL_KhuyenMai dal_LoadingKhuyenMai = new DAL_KhuyenMai();
        public List<KhuyenMai> LoadingKhuyenMai()
        {
            return dal_LoadingKhuyenMai.LoadingKhuyenMai();
        }
    }
}
