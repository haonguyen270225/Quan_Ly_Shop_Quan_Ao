using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Manager
{
    public partial class frm_HoaDonChiTiet : Form
    {
        public frm_HoaDonChiTiet(KhachHang khachHang , NhanVien nhanVien , List<KhoHang> listKhoHang , List<ChiTietHoaDon> listChiTietHoaDon)
        {
            InitializeComponent();
        }
    }
}
