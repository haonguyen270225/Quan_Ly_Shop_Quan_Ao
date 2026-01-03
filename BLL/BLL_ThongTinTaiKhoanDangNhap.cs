using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_ThongTinTaiKhoanDangNhap
    {
        private DAL_ThongTinTaiKhoanDangNhap dal_ThongTinTaiKhoanDangNhap = new DAL_ThongTinTaiKhoanDangNhap();
        public NhanVien ThongTinTaiKhoanDangNhap(TaiKhoan taiKhoan)
        {
            return dal_ThongTinTaiKhoanDangNhap.ThongTinTaiKhoanDangNhap(taiKhoan);
        }
    }
}
