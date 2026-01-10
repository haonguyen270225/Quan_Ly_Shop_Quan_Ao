using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public int ID { get; set; }
        public string MaKhachHang { get; set; }
        
        public string HoVaTen { get; set; }
        
        public string SDT {  get; set; }

        public KhachHang() 
        {
            this.ID = 0;
            this.MaKhachHang = "";
            this.SDT = "";
            this.HoVaTen = "";
        }
    }
}
