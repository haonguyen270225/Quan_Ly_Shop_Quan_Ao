using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
 
    public class NhanVien
    {
        public int ID { get; set; }
        public string MaNhanVien { get; set; }
        public string HoVaTen { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public string ChucVu { get; set; }
        public int GioiTinh { get; set; }

        public int HinhThucLamViec { get; set; }
        public NhanVien()
        {
            ID = 0;
            MaNhanVien = "";
            HoVaTen = "";
            SDT = "";
            Email = "";
            CCCD = "";
            DiaChi = "";
            ChucVu = "";
            GioiTinh = 0;
            HinhThucLamViec = 0;
        }
    }

}
