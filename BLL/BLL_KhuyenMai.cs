using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_KhuyenMai
    {
        private DAL_KhuyenMai dal_KhuyenMai = new DAL_KhuyenMai();
        public List<KhuyenMai> LoadingKhuyenMai()
        {
            return dal_KhuyenMai.LoadingKhuyenMai();
        }
    }
}
