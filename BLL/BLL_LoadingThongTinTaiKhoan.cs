using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class BLL_LoadingThongTinTaiKhoan
    {
        private DAL_TaiKhoan dal_TaiKhoan = new DAL_TaiKhoan();
        public TaiKhoan LoadingThongTinTaiKhoan(TaiKhoan taiKhoan)
        {
            return dal_TaiKhoan.LoadingThongTinTaiKhoan(taiKhoan.UserName, taiKhoan.PassWord);
        }
    }
}
