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
        private DAL_NhanVien dal_NhanVien = new DAL_NhanVien();
        public NhanVien ThongTinTaiKhoanDangNhap(TaiKhoan taiKhoan)
        {
            return dal_NhanVien.Loading_NhanVienDangNhap(taiKhoan);
        }
    }
}
