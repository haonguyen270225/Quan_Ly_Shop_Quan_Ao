using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class BLL_ThongTinNhanVien
    {
        
        private DAL_ThongTinNhanVien thongTinNhanVien = new DAL_ThongTinNhanVien();
        
        public  List<NhanVien>  LoadingThongTinNhanVien()
        {
           // List<NhanVien> listNhanVien = new List<NhanVien>();          
            return new List<NhanVien>(thongTinNhanVien.NhanVienAccess()); 
        }
    }
}
