using BLL;
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
using System.Windows.Forms.Design;

namespace Store_Manager
{
    public partial class frm_HoaDonChiTiet : Form
    {
        #region KhaiBao
        NhanVien cTHD_NhanVien = new NhanVien();
        KhachHang cTHD_KhachHang = new KhachHang();
        HoaDon cTHD_HoaDon = new HoaDon();
        List<KhoHang> cTHD_ListKhoHang = new List<KhoHang>();
        List<ChiTietHoaDon> cTHD_ListChiTietHoDon = new List<ChiTietHoaDon>();
        BLL_KhachHang bll_KhachHang = new BLL_KhachHang();
        BLL_HoaDon bll_HoaDon = new BLL_HoaDon();
        BLL_ChiTietHoaDon bll_ChiTietHoaDon = new BLL_ChiTietHoaDon();
        string cTHD_MaKhuyenMai = "";
        string cTHD_MaHoaDon = "";

        public event EventHandler HoaDonChiTietClosed;
        #endregion
        public frm_HoaDonChiTiet(KhachHang khachHang , NhanVien nhanVien , HoaDon hoaDon ,  List<KhoHang> listKhoHang , List<ChiTietHoaDon> listChiTietHoaDon , string maKhuyenMai , string maHoaDon)
        {
            InitializeComponent();
            L_HoVaTenKhachHang.Text = khachHang.HoVaTen;
            L_ThongTinNhanVien.Text = nhanVien.MaNhanVien + " - " + nhanVien.HoVaTen;
            L_MaKhuyenMai.Text = maKhuyenMai;
            L_SDT.Text = khachHang.SDT;
            L_TongThu.Text = hoaDon.TongThu.ToString("N0");
            L_MaKhuyenMai.Text = maKhuyenMai;
            L_ThongTinNhanVien.Text = "Mã nhân viên : " + nhanVien.MaNhanVien + " - " + nhanVien.HoVaTen;

            cTHD_NhanVien = nhanVien;
            cTHD_KhachHang = khachHang;
            cTHD_HoaDon = hoaDon;
            cTHD_ListChiTietHoDon = listChiTietHoaDon ;
            cTHD_ListKhoHang = listKhoHang;
            cTHD_MaKhuyenMai = maKhuyenMai;
            cTHD_MaHoaDon = maHoaDon;
            LodingData(listChiTietHoaDon, listKhoHang);
        }

        private void LodingData(List<ChiTietHoaDon> listChiTietHoaDon , List<KhoHang> listKhoHang)
        {
           

            DataTable dt = new DataTable();
            dt.Columns.Add("STT");
            dt.Columns.Add("TenHang");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("Gia");
            dt.Columns.Add("TongTien");

            int i = 1;
            foreach(ChiTietHoaDon cTHD in listChiTietHoaDon)
            {
                DataRow dr = dt.NewRow();
                dr["STT"] = i++;
                foreach(KhoHang kH in listKhoHang)
                {
                    if(cTHD.IDMaHang == kH.ID)
                    {
                        dr["TenHang"] = kH.TenHang;
                        dr["Gia"] = kH.Gia.ToString("N2") + "  đ";
                        break;
                    }
                }
                dr["SoLuong"] = cTHD.SoLuong;
                dr["TongTien"] = cTHD.TongTien.ToString("N2") + "  đ";
                dt.Rows.Add(dr);
                DGV_DanhSachChiTietHoaDon.DataSource = dt;
            }
        }
        private void ThemHoaDon(KhachHang khachHang, NhanVien nhanVien, HoaDon hoaDon, List<KhoHang> listKhoHang, List<ChiTietHoaDon> listChiTietHoaDon, string maKhuyenMai)
        {
            hoaDon.Ngay = DateTime.Today;
            hoaDon.Gio = DateTime.Now.TimeOfDay;
            hoaDon.MaHoaDon = cTHD_MaHoaDon;

            bll_KhachHang.ThemKhachHang(khachHang);
            List<KhachHang> tmp = new List<KhachHang>();
            int iD = bll_KhachHang.LoadingKhachHang().Last().ID;
            hoaDon.IDKhachHang = iD;
            hoaDon.IDNhanVien = nhanVien.ID;
            bll_HoaDon.ThemHoaDon(hoaDon);

            // Thêm chi tiết hóa đơn !
            for (int i = 0; i < listChiTietHoaDon.Count; i++)
            {
                listChiTietHoaDon[i].IDHoaDon = bll_HoaDon.LoadingHoaDon().Last().ID;
                bll_ChiTietHoaDon.Add(listChiTietHoaDon[i]);
            }
        }
        
        private void B_QuayLai_Click(object sender, EventArgs e)
        {
            DialogResult kQ = MessageBox.Show("Bạn có muốn thoát !", "Xác nhận thoát !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kQ == DialogResult.Yes) 
            {
                this.Close();
            }
        }

        private void B_Luu_Click(object sender, EventArgs e)
        {
            ThemHoaDon(cTHD_KhachHang, cTHD_NhanVien, cTHD_HoaDon, cTHD_ListKhoHang, cTHD_ListChiTietHoDon, cTHD_MaKhuyenMai);
            HoaDonChiTietClosed?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
