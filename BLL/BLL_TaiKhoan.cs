using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    
    public class BLL_TaiKhoan
    {
        private DAL_TaiKhoanAccess taiKhoanAccess = new DAL_TaiKhoanAccess();
        public int BLL_CheckLogin(TaiKhoan taiKhoan)
        {

            if (taiKhoan.UserName == "")
            {
                return -1;
            }
            if(taiKhoan.PassWord == "")
            {
                return -2;
            }

            int kq = taiKhoanAccess.DAL_CheckLogic(taiKhoan);

            return kq;
        }
    }
}
