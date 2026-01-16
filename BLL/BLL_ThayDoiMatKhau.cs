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
        private DAL_TaiKhoan dal_TaiKhoan = new DAL_TaiKhoan();
        
        public int ThayDoiMatKhau(TaiKhoan taiKhoan , string matKhauMoi)
        {
            return dal_TaiKhoan.ThayDoiMatKhau(taiKhoan.ID, matKhauMoi);
        }
    }

}
