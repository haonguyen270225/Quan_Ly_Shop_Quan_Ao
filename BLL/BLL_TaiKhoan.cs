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
        private DAL_TaiKhoan dal_TaiKhoan = new DAL_TaiKhoan();
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

            int kq = dal_TaiKhoan.DAL_CheckLogic(taiKhoan);

            return kq;
        }
        public int ThayDoiMatKhau(TaiKhoan taiKhoan, string matKhauMoi)
        {
            return dal_TaiKhoan.ThayDoiMatKhau(taiKhoan.ID, matKhauMoi);
        }

        public TaiKhoan LoadingThongTinTaiKhoan(TaiKhoan taiKhoan)
        {
            return dal_TaiKhoan.LoadingThongTinTaiKhoan(taiKhoan.UserName, taiKhoan.PassWord);
        }


        public List<TaiKhoan> LoadingThongTinTaiKhoan()
        {
            return dal_TaiKhoan.LoadingThongTinTaiKhoan();
        }
    }
}
