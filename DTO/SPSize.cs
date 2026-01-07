using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SPSize
    {
        public int ID { get; set; }

        public string MaSize { get; set; }


        public SPSize()
        {
            this.ID = -1;
            this.MaSize = "";
        }
    }
}
