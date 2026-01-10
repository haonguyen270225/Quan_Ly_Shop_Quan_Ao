using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        public int ID  {  get; set; }
        public string MaHoaDon { get; set; }

        public DateTime Ngay {  get; set; }

        public double TongThu { get; set; }

        public int IDNhanVien {  get; set; }
        public int IDKhachHang {  get; set; }
     
        public HoaDon(){
            this.ID = 0;
            this.MaHoaDon = "";
            this.TongThu = 0;
            this.IDKhachHang = 0;
            this.IDNhanVien = 0;
            this.Ngay = DateTime.Now;
        }
    }
}
