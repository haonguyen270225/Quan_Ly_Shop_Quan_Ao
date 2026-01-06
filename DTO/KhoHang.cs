using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhoHang
    {
        public int ID { get; set; }
        public string MaHang {  get; set; }

        public string TenHang {  get; set; }

        public int SoLuongTon {  get; set; }

        public double Gia { get; set; }
        public int IDSize { get; set; }
        public int IDLoaiSanPham {  get; set; }

        public KhoHang()
        {
            this.ID = -1;
            this.MaHang = "";
            this.TenHang = "";
            this.SoLuongTon = -1;
            this.Gia = -1;
            this.IDSize = -1;
            this.IDLoaiSanPham = -1;
        }
    }
}
