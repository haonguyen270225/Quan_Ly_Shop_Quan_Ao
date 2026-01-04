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
        private DAL_LoadingThongTinTaiKhoan dal_LoadingThongTinTaiKhoan = new DAL_LoadingThongTinTaiKhoan();
        public TaiKhoan LoadingThongTinTaiKhoan(TaiKhoan taiKhoan)
        {
            return dal_LoadingThongTinTaiKhoan.LoadingThongTinTaiKhoan(taiKhoan.UserName, taiKhoan.PassWord);
        }
    }
}
