using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public  class BLL_XuLy_Chuoi
    {
        public static  List<KhoHang> TimKiem_DanhSanhKhoHang(List<KhoHang> khoHang , string str) 
        {
            List<KhoHang> listTmp = new List<KhoHang>();

            if (string.IsNullOrWhiteSpace(str))
                return listTmp;

            //  Ưu tiên: TenHang giống hoàn toàn
            foreach (var item in khoHang)
            {
                if (!string.IsNullOrWhiteSpace(item.TenHang) &&
                    string.Equals(item.TenHang, str, StringComparison.OrdinalIgnoreCase))
                {
                    listTmp.Add(item);
                }
            }

            if (listTmp.Count > 0)
                return listTmp;

            // Ưu tiên tiếp: MaHang giống hoàn toàn
            foreach (var item in khoHang)
            {
                if (!string.IsNullOrWhiteSpace(item.MaHang) &&
                    string.Equals(item.MaHang, str, StringComparison.OrdinalIgnoreCase))
                {
                    listTmp.Add(item);
                }
            }

            if (listTmp.Count > 0)
                return listTmp;

          
            foreach (var item in khoHang)
            {
                bool matchTen = !string.IsNullOrWhiteSpace(item.TenHang) &&
                    item.TenHang.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0;

                bool matchMa = !string.IsNullOrWhiteSpace(item.MaHang) &&
                    item.MaHang.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0;

                if (matchTen || matchMa)
                {
                    listTmp.Add(item);
                }
            }

            return listTmp;
        }
    }
}
