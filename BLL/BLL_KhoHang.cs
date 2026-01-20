using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_KhoHang
    {
        private DAL_KhoHang dal_KhoHang = new DAL_KhoHang();
        public List<KhoHang> LoadingKhoHang()
        {
            List<KhoHang> listKhoHang = new List<KhoHang>();
            listKhoHang = dal_KhoHang.LoadingKhoHang();
            return listKhoHang;
        }

        public bool Xoa_KhoHangByID(int iD , out string thongBao)
        {
            if(dal_KhoHang.Xoa_KhoHangByID(iD) == 0)
            {
                thongBao = "Đã xóa hàng thành công !";
                return true;
            }
            else
            {
                thongBao = "Lỗi không timg thấy hàng để xóa \n Vui lòng thử lại !";
                return false;
            }
        }

        public bool Xoa_KhoHangByMaHang(string maHang, out string thongBao)
        {
            if (dal_KhoHang.Xoa_KhoHangByID(maHang) == 0)
            {
                thongBao = "Đã xóa hàng thành công !";
                return true;
            }
            else
            {
                thongBao = "Lỗi không timg thấy hàng để xóa \n Vui lòng thử lại !";
                return false;
            }
        }
    }
}
