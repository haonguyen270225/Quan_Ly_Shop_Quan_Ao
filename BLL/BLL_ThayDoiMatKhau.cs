using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{

    public class BLL_ThayDoiMatKhau
    {
        private DAL_ThayDoiMatKhau dal_ThayDoiMatKhau = new DAL_ThayDoiMatKhau();
        
        public int ThayDoiMatKhau(TaiKhoan taiKhoan , string matKhauMoi)
        {
            return dal_ThayDoiMatKhau.ThayDoiMatKhau(taiKhoan.ID, matKhauMoi);
        }
    }

}
