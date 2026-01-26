using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChucVu
    {
        public int ID { get; set; }
        public string TenChucVu { get; set; }
        
        public string MoTa {  get; set; }

        public ChucVu() 
        {
            this.ID = 0;
            this.TenChucVu = "";
            this.MoTa = "";
        }
    }
}
