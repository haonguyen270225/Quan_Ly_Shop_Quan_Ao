using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDon
    {
        public int ID { get; set; }

        public int SoLuong { get; set; }
        public double TongTien { get; set; }
        public int IDMaHang { get; set; }
        public int IDHoaDon { get; set; }

        public ChiTietHoaDon() 
        {
            this.ID = 0;
            this.SoLuong = 0;
            this.TongTien = 0;
            this.IDMaHang = 0;
            this.IDHoaDon = 0;
        }
    }
}
