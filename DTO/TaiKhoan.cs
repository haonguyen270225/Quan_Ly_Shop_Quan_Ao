using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public int ID { get; set; }

        public int IDNhanVien { get; set; }
    }
}
