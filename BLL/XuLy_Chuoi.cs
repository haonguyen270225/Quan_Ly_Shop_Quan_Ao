using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;

namespace BLL
{
    public  class XuLy_Chuoi
    {

        public static bool KiemTra_STD(string sDT)
        {
            bool kQ = true;
            foreach(char c in sDT)
            {
                 if(char.IsDigit(c) == true)
                {
                    kQ = false;
                    break;
                }
            }
            return kQ; 
        }


        public static bool KiemTra_HoVaTen(string hoVaTen)
        {
            bool kQ = true;
            foreach (char c in hoVaTen)
            {
                if (char.IsPunctuation(c) == true || char.IsDigit(c) == true)
                {
                    kQ = false;
                    break;
                }
                //char.IsPunctuation(c) -> co các dấu câu không 
                // char.IsWhiteSpace(c) -> có khoảng trắng , tab 
                
            }
            return kQ;
        }

        public static bool KiemTra_Ma(string ma)
        {
            bool kQ = true;

            foreach (char c in ma)
            {
                if(char.IsPunctuation(c) == true || char.IsWhiteSpace(c) == true)
                {
                    kQ = false;
                }
            }
           return kQ;
        }

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
