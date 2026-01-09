using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class KhuyenMai
    {
        public int ID {  get; set; }
        public string MaKhuyenMai {  get; set; }
        public string ThongTin {  get; set; }

        public int GiaTri { get; set; }

        public KhuyenMai()
        {
            this.ID = 0;
            this.MaKhuyenMai = "";
            this.ThongTin = "";
            this.GiaTri = 0;
        }
    }
}
