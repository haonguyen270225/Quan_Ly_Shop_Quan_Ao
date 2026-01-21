using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiSanPham
    {
        public int ID { get; set; }
        public string  MaLoaiSanPham { get; set; }
        public string TenLoai { get; set; }

        public int GioiTinh { get; set; }
        public LoaiSanPham() 
        {
            this.ID = -1;
            this.MaLoaiSanPham= "";
            this.TenLoai = "";
            this.GioiTinh = -1; // Giới Tính : 1- đồ cho nam , 2 -- đồ  cho cả nam và nữ , 0 0 đồ cho nữ ; 
        }
    }
}
