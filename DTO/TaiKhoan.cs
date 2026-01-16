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
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public int ID { get; set; }

        public int IDNhanVien { get; set; }

        public byte[] HinhAnh { get; set; }
    }

    }