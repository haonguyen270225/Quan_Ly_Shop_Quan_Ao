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

        public DateTime Ngay { get; set; }
        public TimeSpan Gio { get; set; }
        public double TongThu { get; set; }

        public int IDNhanVien {  get; set; }
        public int IDKhachHang {  get; set; }
     
        public HoaDon(){
            this.ID = 0;
            this.MaHoaDon = "";
            this.TongThu = 0;
            this.IDKhachHang = 0;
            this.IDNhanVien = 0;
            this.Ngay = new DateTime(2026, 1, 1);
            this.Gio = new TimeSpan(0, 0, 0);
            //Ngay = DateTime.Today;                  // Ngày hôm nay, giờ = 00:00
            //Gio = DateTime.Now.TimeOfDay;          // Giờ hiện tại

            //dto.Ngay = dtpNgay.Value.Date;              // .Date để bỏ phần giờ (chỉ giữ ngày)
            //dto.Gio = dtpGio.Value.TimeOfDay;          // TimeOfDay trả về TimeSpan chỉ giờ/phút/giây
        }
    }
}
