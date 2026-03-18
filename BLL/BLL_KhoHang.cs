using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

        public bool UpdateHinhAnh(string maHang , byte[] hinhAnh ,out string thongBao , List<KhoHang> listKhoHang)
        {

            bool kQ = false;
            foreach(KhoHang item in listKhoHang)
            {
                if(maHang == item.MaHang)
                {
                    kQ = true;
                    break;
                }
            }
            if(kQ == false)
            {
                thongBao = "Sản phẩm không có trong danh sách để cập nhật hình ảnh !";
                return false;
            }
            if(dal_KhoHang.UpdateHinhAnh(maHang, hinhAnh) == 1)
            {
                thongBao = "Cập nhật hinh ảnh không thành công ! \n Vui lòng thử lại !";
                return false;
            }
            else
            {
                thongBao = "Đã cập nhật hình ảnh ! \n Có mã : " + maHang;
                return true;
            }
        }


        public bool DeleteKhoHang_ByMaHang(string maHang , out string thongBao)
        {
            if(maHang == null || maHang.Length == 0)
            {
                thongBao = "Delete kho hàng không thành công ! \n Vui lòng thử lại !";
                return false;
            }
            else
            {
                if(dal_KhoHang.DeleteKhoHang_ByMaHang(maHang) == 1)
                {
                    thongBao = "Trong kho hàng không có mã hàng :" + maHang + "\n Vui lòng nhấn Loading và thử lại !";
                    return false;
                }
                else
                {
                    thongBao = "Đã xóa mã hàng : " + maHang;
                    return true;
                }
            }
        }

        public bool Insert_KhoHang(KhoHang khoHang ,  out string thongBao)
        {
            thongBao = "";
            if(dal_KhoHang.Insert_KhoHang(khoHang) == 1)
            {
                thongBao = "Thêm sản phẩm không thành công ! \n Vui lòng thử lại !";
                return false;
            }
            else
            {
                thongBao = "Thêm sản phẩm vào kho hàng thành công !";
                return true;
            }
        }


        public bool Upadte_KhoHang(KhoHang khoHang , out string thongBao)
        {
            thongBao = "";
            if (dal_KhoHang.Update_KhoHang(khoHang) == 1)
            {
                thongBao = "Cập nhật sản phẩm có mã : " + khoHang.MaHang + "  không thành công ! \n Vui lòng thử lại !";
                return false;
            }
            else
            {
                thongBao = "Cập nhật sản phẩm có mã : " + khoHang.MaHang + "  thành công ! ";
                return true;
            }
        }
    }
}
