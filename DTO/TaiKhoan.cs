using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DTO
{
    public class TaiKhoan
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public int IDNhanVien { get; set; }

        public byte[] HinhAnh { get; set; }

        public TaiKhoan()
        {
            this.UserName = "";
            this.PassWord = "";
            this.ID = 0;
            this.IDNhanVien = 0;
            this.HinhAnh = null;
        }
    }
    
}