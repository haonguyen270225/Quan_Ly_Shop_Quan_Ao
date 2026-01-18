using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Store_Manager
{
    public partial class frm_TrangChu : Form
    {
        #region KhaiBao
        // Thông tin nhân viên Và TaiKhoan người dùng !
        public static TaiKhoan taiKhoan = new TaiKhoan();
        private NhanVien nhanVien = new NhanVien();



        private List<KhoHang> listKhoHang = new List<KhoHang>();
        private List<LoaiSanPham> listLoaiSanPham = new List<LoaiSanPham>();
        private List<SPSize> listSPSize = new List<SPSize>();
        private List<KhachHang> listKhachHang = new List<KhachHang>();
        private List<KhuyenMai> listKhuyenMai = new List<KhuyenMai>();
        private List<TaiKhoan> listTaiKhoan = new List<TaiKhoan>();
        private List<NhanVien> listNhanVien = new List<NhanVien>();

        private BLL_NhanVien bLL_NhanVien = new BLL_NhanVien();
        private BLL_TaiKhoan bll_TaiKhoan = new BLL_TaiKhoan();
        private BLL_KhoHang bll_KhoHang = new BLL_KhoHang();
        private BLL_LoaiSanPham bll_LoaiSanPham = new BLL_LoaiSanPham();
        private BLL_SPSize bll_SPSize = new BLL_SPSize();
        private BLL_KhuyenMai bll_KhuyenMai = new BLL_KhuyenMai();
        private BLL_KhachHang bll_KhachHang = new BLL_KhachHang();
        private BLL_HoaDon bll_HoaDon = new BLL_HoaDon();
        private BLL_ChiTietHoaDon bll_ChiTietHoaDon = new BLL_ChiTietHoaDon();

        private UC_SanPham ucSanPham;
        private UC_ChiTietSanPham ucChiTietSanPham;

        //private List<KhoHang> listSanPham;
        private List<KhoHang> listChiTietSanPham = new List<KhoHang>();
        private double tongThu = 0;
        private List<ChiTietHoaDon> listChiTietHoaDon = new List<ChiTietHoaDon>();
        private List<HoaDon> listHoaDon = new List<HoaDon>();
        #endregion

        #region Tab_TrangChu
        public frm_TrangChu()
        {
            InitializeComponent();
        }

       
        private void BLL_LoadingData()
        {
            listTaiKhoan = bll_TaiKhoan.LoadingThongTinTaiKhoan();
            listKhachHang = bll_KhachHang.LoadingKhachHang();
            listNhanVien = bLL_NhanVien.LoadingNhanVien();
            listKhuyenMai = bll_KhuyenMai.LoadingKhuyenMai();
            listSPSize = bll_SPSize.LoadingSPSize();
            listLoaiSanPham = bll_LoaiSanPham.LoadingLoaiSanPham();
            listKhoHang = bll_KhoHang.LoadingKhoHang();
            listHoaDon = bll_HoaDon.LoadingHoaDon();
            listChiTietHoaDon = bll_ChiTietHoaDon.LoadingChiTietHoaDon();

            nhanVien = bLL_NhanVien.TT_NhanVienDangNhap(taiKhoan);//bll_NhanVien.(taiKhoan);
        }
        public void CreateLoading_TrangChu()
        {
            //taiKhoan.UserName = "binh.tran";
            //taiKhoan.PassWord = "123456";
            taiKhoan = bll_TaiKhoan.LoadingThongTinTaiKhoan(taiKhoan);

            BLL_LoadingData();
            TrangChu_GB_LoadingData(nhanVien, taiKhoan);
            #region demo
            //listKhachHang = bll_KhachHang.LoadingKhachHang();
            //listHoaDon = bll_HoaDon.LoadingHoaDon();
            //listKhachHang = bll_KhachHang.LoadingKhachHang();
            //listHoaDon = bll_HoaDon.LoadingHoaDon();
            //listKhoHang = bll_KhoHang.LoadingKhoHang();
            //listChiTietHoaDon = bll_ChiTietHoaDon.LoadingChiTietHoaDon();
            #endregion
           
            
            L_HoVaTen_MaNhanVien.Text = nhanVien.HoVaTen.ToString() + " - " + nhanVien.MaNhanVien.ToString();
            L_TrangChu_HoVaTen.Text = "Xin chào : " + nhanVien.HoVaTen.ToString();
            L_TrangChu_ChuVu.Text = "Chức vụ : " + nhanVien.ChucVu.ToString();
            L_TrangChu_TieuDe.Text = ">>> Thông tin trang chủ !";
            //Loading G_ChiTietTaiKhoan
            //CTTK_TB_HoVaTen.Text = nhanVien.HoVaTen.ToString();
            //CTTK_TB_MaNhanVien.Text = nhanVien.ChucVu.ToString();
            //CTTK_TB_ChucVu.Text = nhanVien.ChucVu.ToString();
            //CTTK_TB_DiaChi.Text = nhanVien.DiaChi.ToString();
            //CTTK_TB_NgaySinh.Text = "12/07/2003";
            //CTTK_TB_CCCD.Text = nhanVien.CCCD.ToString();
            //CTTK_TB_SDT.Text = nhanVien.SDT.ToString();
            //CTTK_TB_MaNhanVien.Text = nhanVien.MaNhanVien.ToString();
            //CTTK_TB_UserName.Text = taiKhoan.UserName.ToString();
            //CTTK_TB_PassWord.UseSystemPasswordChar = true;
            //CTTK_TB_PassWord.Text = taiKhoan.PassWord.ToString();
            //if (nhanVien.GioiTinh == 1)
            //{
            //    CTTK_TB_GioiTinh.Text = "Nam";
            //}
            //else
            //{
            //    CTTK_TB_GioiTinh.Text = "Nu";
            //}

            //if (nhanVien.HinhThucLamViec == 0)
            //{
            //    CTTK_TB_HinhThucLamViec.Text = "Full Time !";
            //}
            //else
            //{
            //    CTTK_TB_HinhThucLamViec.Text = "Pass Time !";
            //}



            //// Loading PB_HinhAnh
            //PB_TrangChu_ThongTinTaiKhoan.Image.Dispose();
            //PB_TrangChu_ThongTinTaiKhoan.Image = null;
            //CTTK_PB_AnhDaiDien.Image.Dispose();
            //CTTK_PB_AnhDaiDien.Image = null;
            //if (taiKhoan?.HinhAnh != null && taiKhoan.HinhAnh.Length > 0)
            //{
            //    try
            //    {
            //        using (MemoryStream ms = new MemoryStream(taiKhoan.HinhAnh))
            //        {
            //            PB_TrangChu_ThongTinTaiKhoan.Image = Image.FromStream(ms);
            //            PB_TrangChu_ThongTinTaiKhoan.SizeMode = PictureBoxSizeMode.Zoom; // Đẹp nhất cho avatar

            //            CTTK_PB_AnhDaiDien.Image = Image.FromStream(ms);
            //            CTTK_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom; // Đẹp nhất cho avatar
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Lỗi load ảnh từ database: " + ex.Message);
            //        // Fallback về ảnh mặc định
            //        PB_TrangChu_ThongTinTaiKhoan.Image = Properties.Resources.CTTK_MacDinh;
            //        PB_TrangChu_ThongTinTaiKhoan.SizeMode = PictureBoxSizeMode.Zoom;
            //        CTTK_PB_AnhDaiDien.Image = Properties.Resources.CTTK_MacDinh;
            //        CTTK_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;
            //    }
            //}
            //else
            //{
            //    if (CTTK_PB_AnhDaiDien.Image != null)
            //    {
            //        CTTK_PB_AnhDaiDien.Image.Dispose();
            //        CTTK_PB_AnhDaiDien.Image = null;
            //    }

            //    CTTK_PB_AnhDaiDien.Image = Properties.Resources.CTTK_MacDinh;
            //    CTTK_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;

            //    PB_TrangChu_ThongTinTaiKhoan.Image = Properties.Resources.CTTK_MacDinh;
            //    PB_TrangChu_ThongTinTaiKhoan.SizeMode = PictureBoxSizeMode.Zoom;
            //}


            //GB_ChiTietTaiKhoan;
            
        }


        private void frm_TrangChu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quan_Ly_Shop_Quan_AoDataSet.HoaDon' table. You can move, or remove it, as needed.
            this.hoaDonTableAdapter.Fill(this.quan_Ly_Shop_Quan_AoDataSet.HoaDon);
            CreateLoading_TrangChu();
        }


        private void tabPage1_Selected(object sender, TabControlEventArgs e)
        {
            if (HoaDon_CB_LoaiSanPham.SelectedTab == tab_DangXuat)
            {
                this.Close();
            }
            if (HoaDon_CB_LoaiSanPham.SelectedTab == tab_TrangChu)
            {
                
                L_TrangChu_TieuDe.Text = ">>> Thông tin trang chủ !";
                
            }
            else if (HoaDon_CB_LoaiSanPham.SelectedTab == tab_HoaDon)
            {
               
                L_TrangChu_TieuDe.Text = ">>> Thêm hóa đơn !";
                listKhoHang = bll_KhoHang.LoadingKhoHang();
                listKhuyenMai = bll_KhuyenMai.LoadingKhuyenMai();
                CreateLoading_TrangDonHang();
            }
            else if(HoaDon_CB_LoaiSanPham.SelectedTab == tab_KhoHang)
            {
                
                L_TrangChu_TieuDe.Text = ">>> Danh sách kho hàng !";
            }
            else if(HoaDon_CB_LoaiSanPham.SelectedTab == tab_KhuyenMai)
            {
             
                L_TrangChu_TieuDe.Text = ">>> Danh sách khuyến mãi !";
            }
            else if(HoaDon_CB_LoaiSanPham.SelectedTab == tab_DoanhThu)
            {
                
                L_TrangChu_TieuDe.Text = ">>> Doanh thu !";
            }
            else if(HoaDon_CB_LoaiSanPham.SelectedTab == tab_TaiKhoan)
            {
                L_TrangChu_TieuDe.Text = ">>> Danh sách tài khoản !";
                if (TaiKhoan_DGV_ListTaiKhoan.Columns.Count > 0 )
                {
                    BLL_LoadingData();
                    TaiKhoan_TB_Loading(null, null);
                    ShowData_DGVListTaiKhoan(listTaiKhoan , listNhanVien);
                    return;
                }
                else
                {
                    BLL_LoadingData();
                    DGV_ListTaiKhoan_Loading(listTaiKhoan, listNhanVien);
                    TaiKhoan_TB_Loading(null, null);
                }
               
            }
        }

        private void lostButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lostButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void hopePictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thông tin nhân viên !");
        }


        private void TrangChu_B_ChiTietTaiKhoan_Click(object sender, EventArgs e)
        {
            GB_ChiTietTaiKhoan.BringToFront();
            GB_ChiTietTaiKhoan.Visible = true;
            CTTK_B_Thoat.Text = "Thoát !";
            CTTK_B_Thoat.ForeColor = Color.Red;
            DGV_TrangChu.Visible = false;

            SetTextBoxReadOnlyAll(GB_ChiTietTaiKhoan, true);

            TrangChu_GB_LoadingData(nhanVien, taiKhoan);
        }

        private void CTTK_B_Thoat_Click(object sender, EventArgs e)
        {
            GB_ChiTietTaiKhoan.SendToBack();
            GB_ChiTietTaiKhoan.Visible = false;
            DGV_TrangChu.Visible = true;
        }

        private void FCB_HienThiMatKhau_CTTK_CheckedChanged(object sender, EventArgs e)
        {
            if (CTTK_FCB_HienThiMatKhau.Checked == true)
            {
                CTTK_TB_PassWord.UseSystemPasswordChar = false;
            }
            else
            {
                CTTK_TB_PassWord.UseSystemPasswordChar = true;
            }
        }

        private void CTTK_B_ThayDoiTaiKhoan_Click(object sender, EventArgs e)
        {
            frm_ThayDoiMatKhau frm = new frm_ThayDoiMatKhau();

            frm.DaDongVaCapNhatMatKhau += () =>
            {
                CreateLoading_TrangChu(); // Thêm vào sự kiện event : public event Action DaDongVaCapNhatMatKhau;
            };
            // C2 : frm.DaDongVaCapNhatMatKhau += CreateLoading; // không ();
            frm.ShowDialog();
        }
        #endregion

        #region HoaDon


        private void LaodingSPSizeSanPham()
        {
            listSPSize = bll_SPSize.LoadingSPSize();
            HoaDon_CB_SizeSanPham.Items.Clear();
            HoaDon_CB_SizeSanPham.Items.Add("Size");
            foreach (var item in listSPSize)
            {
                HoaDon_CB_SizeSanPham.Items.Add(item.MaSize.ToString());
            }
            HoaDon_CB_SizeSanPham.SelectedIndex = 0;
        }
        private void LoadingLoaiSanPham()
        {
            HD_CB_LoaiSanPham.Items.Clear();
            HD_CB_LoaiSanPham.Items.Add("Mã quần áo !");
            listLoaiSanPham = bll_LoaiSanPham.LoadingLoaiSanPham();
            foreach (var item in listLoaiSanPham)
            {
                HD_CB_LoaiSanPham.Items.Add(item.TenLoai);
            }
            HD_CB_LoaiSanPham.SelectedIndex = 0;
        }

        private void LoadingKhuyenMai()
        {
            HoaDon_CB_MaKhuyenMai.Items.Clear();
            HoaDon_CB_MaKhuyenMai.Items.Add("Chưa áp mã !");
            foreach (var item in listKhuyenMai)
            {
                HoaDon_CB_MaKhuyenMai.Items.Add(item.MaKhuyenMai + ": " + item.ThongTin);
            }
            HoaDon_CB_MaKhuyenMai.SelectedIndex = 0;
        }

        private void AddSanPham(List<KhoHang> listKhoHang)
        {
            FLP_SanPham.Controls.Clear();
            //ucSanPham.sanPham_Dem = 0;
            if (listKhoHang.Count == 0)
            {
                return;
            }
            for (int i = 0; i < listKhoHang.Count; i++)
            {
                ucSanPham = new UC_SanPham(listKhoHang[i], i + 1);
                ucSanPham.OnAddToHoaDon += (s, sp) =>
                {
                    AddChiTietSanPham(sp);
                };
                FLP_SanPham.Controls.Add(ucSanPham);
            }
        }
        public void CreateLoading_TrangDonHang()
        {
            LaodingSPSizeSanPham();
            LoadingLoaiSanPham();
            LoadingKhuyenMai();
            AddSanPham(listKhoHang);
            //Loading_DGV_HoaDon();
        }
        #endregion


        #region Select_SanPham 

        // Xử lý sự kiện ComboBox - Menu;
        private void HoaDon_CB_SizeSanPham_SelectionChangeCommitted(object sender, EventArgs e)
        {
            HD_CB_LoaiSanPham.SelectedIndex = 0;
            string maSanPham = HoaDon_CB_SizeSanPham.SelectedItem.ToString();
            List<KhoHang> listTmp = bll_KhoHang.LoadingKhoHang();
            if (bll_SPSize.LocTheoSize(maSanPham, listSPSize, listKhoHang) == null)
            {
                AddSanPham(listTmp);
                return;
            }
            else
            {
                listTmp = bll_SPSize.LocTheoSize(maSanPham, listSPSize, listKhoHang);
                AddSanPham(listTmp);
            }
        }

        private void HD_CB_LoaiSanPham_SelectionChangeCommitted(object sender, EventArgs e)
        {
            HoaDon_CB_SizeSanPham.SelectedIndex = 0;
            string tenLoai = HD_CB_LoaiSanPham.SelectedItem.ToString();
            List<KhoHang> listTmp = bll_KhoHang.LoadingKhoHang();
            if (bll_LoaiSanPham.LocLoaiSanPham(tenLoai, listLoaiSanPham, listTmp) == null)
            {
                AddSanPham(listTmp);
                return;
            }
            else
            {
                listTmp = bll_LoaiSanPham.LocLoaiSanPham(tenLoai, listLoaiSanPham, listTmp);
                AddSanPham(listTmp);
            }
        }
        #endregion

        // Dữ liệu HoaDon_FLP_DanhSachChiTietSanPham
        private void AddChiTietSanPham(KhoHang sanPham)
        {

            foreach (UC_ChiTietSanPham item in FLP_ChiTietSanPham.Controls)
            {
                if (item.chiTietSanPham.MaHang == sanPham.MaHang)
                {
                    item.TangSoLuong();
                    // HoaDon_TongThu.Text = UC_ChiTietSanPham.tongThu.ToString("N0") + " đ";
                    CapNhat_TongThu();
                    return;
                }
            }
            ucChiTietSanPham = new UC_ChiTietSanPham(sanPham);
            //ucChiTietSanPham.Xoa += uc =>
            //{
            //    FLP_ChiTietSanPham.Controls.Remove(uc);
            //    uc.Dispose();
            //};
            ucChiTietSanPham.Xoa_ChiTietSanPham += XoaChiTietSanPham;
            FLP_ChiTietSanPham.Controls.Add(ucChiTietSanPham);
            CapNhat_ListChiTietSanPham();
            listChiTietSanPham.Add(sanPham);
            CapNhat_TongThu();
        }

        private void XoaChiTietSanPham(UC_ChiTietSanPham uc)
        {
            FLP_ChiTietSanPham.Controls.Remove(uc);
            // CapNhat_SanPham(khoHang);
            CapNhat_SanPham();
            CapNhat_ListChiTietSanPham();
            CapNhat_TongThu();
            uc.Dispose();
        }

        private void CapNhat_SanPham()
        {
            if(FLP_ChiTietSanPham.Controls.Count == 0 )
            {
                foreach (UC_SanPham item in FLP_SanPham.Controls)
                {
                    item.sL_SanPham = 0;
                }
            }
            else
            {
                foreach(UC_SanPham sP in FLP_SanPham.Controls)
                {
                    foreach(UC_ChiTietSanPham cTSP in FLP_ChiTietSanPham.Controls)
                    {
                        if (sP.sanPham.ID == cTSP.chiTietSanPham.ID)
                        {
                            sP.sL_SanPham = cTSP.soLuong;
                            break;
                        }
                        else
                        {
                            sP.sL_SanPham = 0;
                        }
                    }
                }
            }

            
        }
        private void CapNhat_TongThu()
        {
            tongThu = 0;
            foreach (UC_ChiTietSanPham item in FLP_ChiTietSanPham.Controls)
            {
                tongThu += item.tongThu_ChiTietSanPham;
            }
            TB_TongThu.Text = tongThu.ToString("N0") + " đ";
        }

        private void CapNhat_ListChiTietSanPham()
        {
            listChiTietSanPham.Clear();
            foreach (UC_ChiTietSanPham item in FLP_ChiTietSanPham.Controls)
            {
                listChiTietSanPham.Add(item.chiTietSanPham);
            }
        }

        private void HoaDon_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thông báo !", "Bạn có muốn xóa !", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (result == DialogResult.Yes)
            {
                FLP_ChiTietSanPham.Controls.Clear();
                listChiTietSanPham.Clear();
                CapNhat_ListChiTietSanPham();
                CapNhat_TongThu();
            }
            else
            {
                return;
            }
        }



        private void HoaDon_TB_TenSanPham_MouseLeave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(HoaDon_TB_TenSanPham.Text)) // Bỏ qua chuỗi rỗng , null or \t và \n or " ";)
            {
                this.ActiveControl = null;
            }
            else
            {
                return;
            }
        }



        private void parrotButton1_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(HoaDon_TB_TenSanPham.Text) // Bỏ qua chuỗi rỗng , null or \t và \n or " ";
                || HoaDon_TB_TenSanPham.Text == "Tìm kiếm tên sản phẩm  !")
            {
                FLP_SanPham.Controls.Clear();
                AddSanPham(bll_KhoHang.LoadingKhoHang());
                return;
            }
            else
            {
                List<KhoHang> listTmp = bll_KhoHang.LoadingKhoHang();
                if (XuLy_Chuoi.TimKiem_DanhSach(listTmp, HoaDon_TB_TenSanPham.Text).Count == 0)
                {
                    MessageBox.Show("Không có sản phẩm phù hợp !");
                }
                else
                {
                    FLP_SanPham.Controls.Clear();
                    listTmp = XuLy_Chuoi.TimKiem_DanhSach(listTmp, HoaDon_TB_TenSanPham.Text);
                    AddSanPham(listTmp);
                }
            }

        }



        #region frm_ThongTinKhachHang
        private void HoaDon_ThanhToan_Click(object sender, EventArgs e)
        {
            if(FLP_ChiTietSanPham.Controls.Count == 0)
            {
                return;
            }
            frm_ThongTinKhachHang frm = new frm_ThongTinKhachHang();
            frm.DaDongVaThemKachHang += (khachHang , maHoaDon) =>
            {
                ThemDanhSachKhachHang(khachHang , maHoaDon);
                
            };
            frm.ShowDialog();
        }

        private void ThemDanhSachKhachHang(KhachHang khachHang , string maHoaDon)
        {
           
            listKhachHang = bll_KhachHang.LoadingKhachHang();
            MessageBox.Show("Khach Hang : " + " - " + khachHang.MaKhachHang + " - " + khachHang.HoVaTen + " - " + khachHang.SDT + "\n" + "Mã hóa đơn :" + maHoaDon);
            LoadingChiTietHoaDon(khachHang , maHoaDon);
        }
        #endregion


        #region frm_HoaDonChiTiet
        private void LoadingChiTietHoaDon(KhachHang khachHang , string maHoaDon)
        {
           
            HoaDon hoaDon = new HoaDon();
            foreach(UC_ChiTietSanPham item in FLP_ChiTietSanPham.Controls)
            {
                hoaDon.TongThu += item.tongThu_ChiTietSanPham;
            }
            hoaDon.IDNhanVien = nhanVien.ID;
            hoaDon.IDKhachHang = listKhachHang.Count + 1;
            listChiTietHoaDon.Clear();
            foreach (UC_ChiTietSanPham item in FLP_ChiTietSanPham.Controls)
            {
                ChiTietHoaDon tmp = new ChiTietHoaDon();
                tmp.IDMaHang = item.chiTietSanPham.ID;
                tmp.SoLuong = item.soLuong;
                tmp.TongTien = item.tongThu_ChiTietSanPham;
                //tmp.IDHoaDon = listHoaDon.Count + 1;
                listChiTietHoaDon.Add(tmp);
            }
            frm_HoaDonChiTiet frm = new frm_HoaDonChiTiet(khachHang, nhanVien, hoaDon , listKhoHang, listChiTietHoaDon  , HoaDon_CB_MaKhuyenMai.Text , maHoaDon);
            frm.HoaDonChiTietClosed += (sender, e) =>
            {
                listKhoHang.Clear();
                listKhoHang = bll_KhoHang.LoadingKhoHang();
                AddSanPham(listKhoHang);
                FLP_ChiTietSanPham.Controls.Clear();
                CapNhat_TongThu();
            };
            frm.ShowDialog();
            
        }
        #endregion


        #region Chi_Tiet_Tai_Khoan
        private void CTTK_B_AnhMacDinh_Click(object sender, EventArgs e)
        {
           try
            {
                if (CTTK_PB_AnhDaiDien.Image != null)
                {
                    CTTK_PB_AnhDaiDien.Image.Dispose();
                    CTTK_PB_AnhDaiDien.Image = null;
                }
                CTTK_PB_AnhDaiDien.Image = Properties.Resources.CTTK_MacDinh;
                CTTK_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;

                PB_TrangChu_ThongTinTaiKhoan.Image = Properties.Resources.CTTK_MacDinh;
                PB_TrangChu_ThongTinTaiKhoan.SizeMode = PictureBoxSizeMode.Zoom;

            }
            catch (Exception ex) 
            {
                MessageBox.Show("Không thể load ảnh mặc định!\nLỗi: " + ex.Message);
            }
        }
        private void CTTK_B_AnhTrenMay_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog oFD = new OpenFileDialog())
            {
                oFD.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All files (*.*)|*.*";
                oFD.Title = "Chọn ảnh cho hồ sơ";

                if (oFD.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        CTTK_PB_AnhDaiDien.Image = Image.FromFile(oFD.FileName);

                        // Tùy chọn: Căn chỉnh ảnh đẹp hơn
                        CTTK_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;


                        PB_TrangChu_ThongTinTaiKhoan.Image = Image.FromFile(oFD.FileName);
                        
                        PB_TrangChu_ThongTinTaiKhoan.SizeMode = PictureBoxSizeMode.Zoom;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể load ảnh!\nLỗi: " + ex.Message);
                    }

                }

            }
        }

        #endregion


        #region Tab_TaiKhoan


        private void ShowData_DGVListTaiKhoan(List<TaiKhoan>listTaiKhoan , List<NhanVien> listNhanVien)
        {
            if (listTaiKhoan.Count <= 0 || listNhanVien.Count <= 0)
            {
                MessageBox.Show("Lỗi : Không có dữ liệu tài khoản và nhân viên ứng dụng !", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                TaiKhoan_DGV_ListTaiKhoan.DataSource = null;
                TaiKhoan_DGV_ListTaiKhoan.Rows.Clear();
             
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("IDNhanVien", typeof(int));
                dataTable.Columns.Add("UserName", typeof(string));
                dataTable.Columns.Add("PassWord", typeof(string));
                dataTable.Columns.Add("HinhAnh", typeof(byte[]));
                foreach (TaiKhoan item in listTaiKhoan)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["IDNhanVien"] = item.IDNhanVien;
                    dataRow["UserName"] = item.UserName;
                    dataRow["PassWord"] = item.PassWord;
                    dataRow["HinhAnh"] = item.HinhAnh;

                    dataTable.Rows.Add(dataRow);
                }
                TaiKhoan_DGV_ListTaiKhoan.AutoGenerateColumns = true;
                TaiKhoan_DGV_ListTaiKhoan.DataSource = dataTable;
            }
        }
        private void DGV_ListTaiKhoan_Loading(List<TaiKhoan> listTaiKhoan , List<NhanVien> listNhanVien)
        {
            #region demo
            //DataTable dataTable = new DataTable();
            //dataTable.Columns.Add("ID");
            //dataTable.Columns.Add("MaNhanVien");
            //dataTable.Columns.Add("HoVaTen");
            //dataTable.Columns.Add("ChucVu");
            //dataTable.Columns.Add("HinhAnh");
            #endregion
            
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("IDNhanVien", typeof(int));
            dataTable.Columns.Add("UserName", typeof(string));
            dataTable.Columns.Add("PassWord", typeof(string));
            dataTable.Columns.Add("HinhAnh", typeof(byte[]));

            TaiKhoan_DGV_ListTaiKhoan.AutoGenerateColumns = true;
            // Tạo cột Button Reset
            DataGridViewButtonColumn btnReset = new DataGridViewButtonColumn();
            btnReset.Name = "Reset";
            btnReset.HeaderText = "Mật khẩu";
            btnReset.Text = "Reset";
            btnReset.UseColumnTextForButtonValue = true;

            TaiKhoan_DGV_ListTaiKhoan.Columns.Add(btnReset);

            TaiKhoan_DGV_ListTaiKhoan.CellContentClick += TaiKhoan_DGV_ListTaiKhoan_CellContentClick; // sán sự kiện !

            foreach (TaiKhoan item in listTaiKhoan)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["IDNhanVien"] = item.IDNhanVien;
                dataRow["UserName"] = item.UserName;
                dataRow["PassWord"] = item.PassWord;
                dataRow["HinhAnh"] = item.HinhAnh;

                dataTable.Rows.Add(dataRow);
            }
            TaiKhoan_DGV_ListTaiKhoan.DataSource = dataTable;
        }

        private void TaiKhoan_DGV_ListTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && TaiKhoan_DGV_ListTaiKhoan.Columns[e.ColumnIndex].Name == "Reset")
            {
               int id = Convert.ToInt32(TaiKhoan_DGV_ListTaiKhoan.Rows[e.RowIndex].Cells["IDNhanVien"].Value);
                
                //MessageBox.Show($"Reset mật khẩu cho tài khoản ID = {id}");
                // TODO: gọi hàm reset ở đây

                var kq = MessageBox.Show("Bán có muốn reset  tài khoản ! \n Có IDNhanVien : "   + id, "Reset Tài Khoản !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(kq == DialogResult.No)
                {
                    return;
                }
                else
                {
                    bool kQ = false;
                    string thongBao = "";

                    bll_TaiKhoan.TaiKhoan_Reset(id, out thongBao, out kQ);
                    MessageBox.Show(thongBao , "Reset Tài Khoản !" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                    BLL_LoadingData();
                    ShowData_DGVListTaiKhoan(listTaiKhoan , listNhanVien);
                }
            }
        }


        private void TaiKhoan_DGV_ListTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BLL_LoadingData();
            // TaiKhoan
            DataGridViewImageColumn dataGridViewImageColumn = new DataGridViewImageColumn();
            dataGridViewImageColumn = (DataGridViewImageColumn)TaiKhoan_DGV_ListTaiKhoan.Columns[4];
            dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            var cellValue = TaiKhoan_DGV_ListTaiKhoan.SelectedRows[0].Cells["HinhAnh"].Value;
            int iDNhanVien = Convert.ToInt32(TaiKhoan_DGV_ListTaiKhoan.SelectedRows[0].Cells["IDNhanVien"].Value);
            foreach (TaiKhoan tK in listTaiKhoan)
            {
                foreach(NhanVien nV in listNhanVien)
                {
                    if(iDNhanVien == nV.ID && tK.IDNhanVien == iDNhanVien)
                    {
                        TaiKhoan_TB_Loading(tK , nV);
                    }
                }
            }
            
            if (cellValue != null && cellValue != DBNull.Value)
            {
                byte[] imgBytes = (byte[])cellValue;
                using (MemoryStream ms = new MemoryStream(imgBytes))
                {
                    TaiKhoan_PB_AnhDaiDien.Image = Image.FromStream(ms);
                }
            }
            else
            {
                TaiKhoan_PB_AnhDaiDien.Image = Properties.Resources.CTTK_MacDinh;
            }


        }

        private void TaiKhoan_TB_Loading(TaiKhoan taiKhoan, NhanVien nhanVien)
        {
            if (taiKhoan == null || nhanVien == null)
            {
                TaiKhoan_TB_HoVaTen.Text = "";
                TaiKhoan_TB_MaNhanVien.Text = "";
                TaiKhoan_TB_CCCD.Text = "";
                TaiKhoan_TB_SDT.Text = "";
                TaiKhoan_TB_Email.Text = "";
                TaiKhoan_TB_DiaChi.Text = "";
                TaiKhoan_CB_Loading();
            }
            else
            {
                TaiKhoan_TB_HoVaTen.Text = nhanVien.HoVaTen;
                TaiKhoan_TB_MaNhanVien.Text = nhanVien.MaNhanVien;
                TaiKhoan_TB_CCCD.Text = nhanVien.CCCD;
                TaiKhoan_TB_SDT.Text = nhanVien.SDT;
                TaiKhoan_TB_Email.Text = nhanVien.Email;
                TaiKhoan_TB_DiaChi.Text = nhanVien.DiaChi;
                // GioiTinh
                if(nhanVien.GioiTinh == 1)
                {
                    TaiKhoan_CB_GioiTinh.SelectedIndex = 1;
                }
                else
                {
                    TaiKhoan_CB_GioiTinh.SelectedIndex = 0;
                }
                // ChucVu
                foreach(var item in TaiKhoan_CB_ChucVu.Items)
                {
                    if(item.ToString().Trim() == nhanVien.ChucVu.Trim())
                    {
                        TaiKhoan_CB_ChucVu.SelectedItem = item;
                    }
                }
                //HinhThucLamViec
                if(nhanVien.HinhThucLamViec == 0)
                {
                    TaiKhoan_CB_HinhThucLamViec.SelectedIndex = 0;
                }
                else
                {
                    TaiKhoan_CB_HinhThucLamViec.SelectedIndex = 1;
                }
            }
        }


        private void TaiKhoan_CB_Loading()
        {
            

            List<NhanVien> listNV = bLL_NhanVien.LoadingNhanVien();

            TaiKhoan_CB_ChucVu.Items.Clear();

            if (listNV == null || listNV.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nhân viên!");
                return;
            }

            // Dùng HashSet để lọc trùng
            HashSet<string> chucVuSet = new HashSet<string>();

            foreach (var nv in listNV)
            {
                if (!string.IsNullOrWhiteSpace(nv.ChucVu))
                {
                    chucVuSet.Add(nv.ChucVu);
                }
            }

            foreach (var chucVu in chucVuSet)
            {
                TaiKhoan_CB_ChucVu.Items.Add(chucVu);
            }

            if (TaiKhoan_CB_ChucVu.Items.Count > 0)
            {
                TaiKhoan_CB_ChucVu.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Lỗi chức vụ!");
            }


            // loading CB_GioiTinh;
            TaiKhoan_CB_GioiTinh.Items.Clear();
            TaiKhoan_CB_GioiTinh.Items.Add("Nữ");
            TaiKhoan_CB_GioiTinh.Items.Add("Nam");
            TaiKhoan_CB_GioiTinh.SelectedIndex = 0;


            //loading CB_hinhThucLamViec
            TaiKhoan_CB_HinhThucLamViec.Items.Clear();
            TaiKhoan_CB_HinhThucLamViec.Items.Add("Full Time !");
            TaiKhoan_CB_HinhThucLamViec.Items.Add("Pass Time !");
            TaiKhoan_CB_HinhThucLamViec.SelectedIndex = 0;
        }

        private void TaiKhoan_B_Loading_Click(object sender, EventArgs e)
        {
            TaiKhoan_TB_TimKiem.Text = "";
            TaiKhoan_TB_Loading(null, null);
            BLL_LoadingData();
            ShowData_DGVListTaiKhoan(listTaiKhoan, listNhanVien);
            
        }

        private void TaiKhoan_B_XoaTimKiem_Click(object sender, EventArgs e)
        {
            TaiKhoan_TB_TimKiem.Text = "";
            BLL_LoadingData();
            ShowData_DGVListTaiKhoan(listTaiKhoan, listNhanVien);
        }



        // TaiKhoan Cập nhật thông tin nhân viên !;
        private void TaiKhoan_B_CapNhat_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Cập nhật nhân viên !");
            GB_ChiTietTaiKhoan.BringToFront();
            GB_ChiTietTaiKhoan.Visible = true;
            NhanVien nhanVienCapNhat;
            TaiKhoan taiKhoanCapNhat;

           

            
        }

        // TaiKhoan Thêm nhân viên !;
        private void TaiKhoan_B_Them_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thêm nhân viên !");
            GB_ChiTietTaiKhoan.BringToFront();
            GB_ChiTietTaiKhoan.Visible = true;
            SetTextBoxReadOnlyAll(GB_ChiTietTaiKhoan, false);
        }

       


        private void CapNhat_TaiKhoan_GBChiTieTaiKhoan(NhanVien nhanVien, TaiKhoan taiKhoan)
        {
            CTTK_B_Thoat.Text = "Cập Nhật !";
            if (nhanVien == null || taiKhoan == null || nhanVien.MaNhanVien == "" || nhanVien.HoVaTen == "" || nhanVien.SDT == ""
                || nhanVien.ChucVu == "" || taiKhoan.PassWord == "" || taiKhoan.UserName == "")
                
            {
                MessageBox.Show("Vui lòng thử lại !", "Lỗi cập nhật nhân viên !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CTTK_B_Thoat.Text = "Cập Nhật !";
                // TaiKhoan_Loading_GBGBChiTieTaiKhoan(nhanVien, taiKhoan);
                //TrangChu_GB_LoadingData(nhanVien, taiKhoan);
            }
        }


        //private void TaiKhoan_Loading_GBGBChiTieTaiKhoan(NhanVien nhanVien, TaiKhoan taiKhoan)
        //{
        //    CTTK_TB_HoVaTen.Text = nhanVien.HoVaTen.ToString();
        //    CTTK_TB_MaNhanVien.Text = nhanVien.ChucVu.ToString();
        //    CTTK_TB_ChucVu.Text = nhanVien.ChucVu.ToString();
        //    CTTK_TB_DiaChi.Text = nhanVien.DiaChi.ToString();
        //    CTTK_TB_NgaySinh.Text = "12/07/2003";
        //    CTTK_TB_CCCD.Text = nhanVien.CCCD.ToString();
        //    CTTK_TB_SDT.Text = nhanVien.SDT.ToString();
        //    CTTK_TB_MaNhanVien.Text = nhanVien.MaNhanVien.ToString();
        //    CTTK_TB_UserName.Text = taiKhoan.UserName.ToString();
        //    CTTK_TB_PassWord.UseSystemPasswordChar = true;
        //    FCB_HienThiMatKhau_CTTK.Checked = true;
        //    CTTK_TB_PassWord.Text = taiKhoan.PassWord.ToString();
        //    if (nhanVien.GioiTinh == 1)
        //    {
        //        CTTK_TB_GioiTinh.Text = "Nam";
        //    }
        //    else
        //    {
        //        CTTK_TB_GioiTinh.Text = "Nu";
        //    }

        //    if (nhanVien.HinhThucLamViec == 0)
        //    {
        //        CTTK_TB_HinhThucLamViec.Text = "Full Time !";
        //    }
        //    else
        //    {
        //        CTTK_TB_HinhThucLamViec.Text = "Pass Time !";
        //    }



        //    // Loading PB_HinhAnh
        //    PB_TrangChu_ThongTinTaiKhoan.Image.Dispose();
        //    PB_TrangChu_ThongTinTaiKhoan.Image = null;
        //    CTTK_PB_AnhDaiDien.Image.Dispose();
        //    CTTK_PB_AnhDaiDien.Image = null;
        //    if (taiKhoan?.HinhAnh != null && taiKhoan.HinhAnh.Length > 0)
        //    {
        //        try
        //        {
        //            using (MemoryStream ms = new MemoryStream(taiKhoan.HinhAnh))
        //            {
        //                PB_TrangChu_ThongTinTaiKhoan.Image = Image.FromStream(ms);
        //                PB_TrangChu_ThongTinTaiKhoan.SizeMode = PictureBoxSizeMode.Zoom; // Đẹp nhất cho avatar

        //                CTTK_PB_AnhDaiDien.Image = Image.FromStream(ms);
        //                CTTK_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom; // Đẹp nhất cho avatar
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Lỗi load ảnh từ database: " + ex.Message);
        //            // Fallback về ảnh mặc định
        //            PB_TrangChu_ThongTinTaiKhoan.Image = Properties.Resources.CTTK_MacDinh;
        //            PB_TrangChu_ThongTinTaiKhoan.SizeMode = PictureBoxSizeMode.Zoom;
        //            CTTK_PB_AnhDaiDien.Image = Properties.Resources.CTTK_MacDinh;
        //            CTTK_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;
        //        }
        //    }
        //    else
        //    {
        //        if (CTTK_PB_AnhDaiDien.Image != null)
        //        {
        //            CTTK_PB_AnhDaiDien.Image.Dispose();
        //            CTTK_PB_AnhDaiDien.Image = null;
        //        }

        //        CTTK_PB_AnhDaiDien.Image = Properties.Resources.CTTK_MacDinh;
        //        CTTK_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;

        //        PB_TrangChu_ThongTinTaiKhoan.Image = Properties.Resources.CTTK_MacDinh;
        //        PB_TrangChu_ThongTinTaiKhoan.SizeMode = PictureBoxSizeMode.Zoom;
        //    }

        //}
        #region Tab_TaiKhoan_Demo
        //private void LoadingKhuyenMai()
        //{
        //    HoaDon_CB_MaKhuyenMai.Items.Clear();
        //    HoaDon_CB_MaKhuyenMai.Items.Add("Chưa áp mã !");
        //    foreach (var item in listKhuyenMai)
        //    {
        //        HoaDon_CB_MaKhuyenMai.Items.Add(item.MaKhuyenMai + ": " + item.ThongTin);
        //    }
        //    HoaDon_CB_MaKhuyenMai.SelectedIndex = 0;
        //}

        //private void Tab_TaiKhoan_Close()
        //{
        //    BLL_LoadingData();
        //    TaiKhoan_DGV_ListTaiKhoan.DataSource = null;
        //    TaiKhoan_DGV_ListTaiKhoan.Rows.Clear();
        //    TaiKhoan_DGV_ListTaiKhoan.Columns.Clear();
        //}
        #endregion

        #endregion


        #region GB_ChiTietTaiKhoan
        //void SetTextBoxReadOnly(Control parent, bool isReadOnly = true)
        //{
        //    foreach (Control ctrl in parent.Controls)
        //    {
        //        if (ctrl is TextBox txt)
        //            txt.ReadOnly = isReadOnly;
        //        else
        //            SetTextBoxReadOnlyAll(ctrl, isReadOnly);
        //    }
        //}
        private void SetTextBoxReadOnlyAll(Control parent, bool isReadOnly)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox txt)
                    txt.ReadOnly = isReadOnly;
                else
                    SetTextBoxReadOnlyAll(ctrl, isReadOnly);
            }
        }

       private void TrangChu_GB_LoadingData(NhanVien nhanVien , TaiKhoan taiKhoan)
        {
            CTTK_TB_PassWord.Visible = true;
            CTTK_TB_UserName.Visible = true;
            CTTK_L_HienThiMatKhau.Visible = true;
            CTTK_L_PassWord.Visible = true;
            CTTK_L_UserName.Visible = true;
            CTTK_FCB_HienThiMatKhau.Visible = true;
            CTTK_B_ThayDoiTaiKhoan.Visible = true;
            //Loading G_ChiTietTaiKhoan
            CTTK_TB_HoVaTen.Text = nhanVien.HoVaTen.ToString();
            CTTK_TB_MaNhanVien.Text = nhanVien.ChucVu.ToString();
            
            CTTK_TB_DiaChi.Text = nhanVien.DiaChi.ToString();
            CTTK_TB_NgaySinh.Text = "12/07/2003";
            CTTK_TB_CCCD.Text = nhanVien.CCCD.ToString();
            CTTK_TB_SDT.Text = nhanVien.SDT.ToString();

            CTTK_TB_UserName.Text = taiKhoan.UserName.ToString();
            CTTK_TB_PassWord.UseSystemPasswordChar = true;
            CTTK_TB_PassWord.Text = taiKhoan.PassWord.ToString();

            GB_CTTK_CB_Loading();
            
            // GioiTinh
            // 0 -> Nu , 1 -> Nam ;
            if (nhanVien.GioiTinh == 0)
            {
                CTTK_CB_GioiTinh.SelectedIndex = 0;
            }
            else
            {
                CTTK_CB_GioiTinh.SelectedIndex = 1;
            }

            // HinhThucLamViec
            if (nhanVien.HinhThucLamViec == 0)
            {
                CTTK_CB_HinhThucLamViec.SelectedIndex = 0; // 0 -> full time
            }
            else
            {
                CTTK_CB_HinhThucLamViec.SelectedIndex = 1; // pass -> time;
            }

            // ChucVu
            foreach (var item in TaiKhoan_CB_ChucVu.Items)
            {
                if (item.ToString().Trim() == nhanVien.ChucVu.Trim())
                {
                    TaiKhoan_CB_ChucVu.SelectedItem = item;
                }
            }

            // Loading PB_HinhAnh
            PB_TrangChu_ThongTinTaiKhoan.Image.Dispose();
            PB_TrangChu_ThongTinTaiKhoan.Image = null;
            CTTK_PB_AnhDaiDien.Image.Dispose();
            CTTK_PB_AnhDaiDien.Image = null;
            if (taiKhoan?.HinhAnh != null && taiKhoan.HinhAnh.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(taiKhoan.HinhAnh))
                    {
                        PB_TrangChu_ThongTinTaiKhoan.Image = Image.FromStream(ms);
                        PB_TrangChu_ThongTinTaiKhoan.SizeMode = PictureBoxSizeMode.Zoom; // Đẹp nhất cho avatar

                        CTTK_PB_AnhDaiDien.Image = Image.FromStream(ms);
                        CTTK_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom; // Đẹp nhất cho avatar
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load ảnh từ database: " + ex.Message);
                    // Fallback về ảnh mặc định
                    PB_TrangChu_ThongTinTaiKhoan.Image = Properties.Resources.CTTK_MacDinh;
                    PB_TrangChu_ThongTinTaiKhoan.SizeMode = PictureBoxSizeMode.Zoom;
                    CTTK_PB_AnhDaiDien.Image = Properties.Resources.CTTK_MacDinh;
                    CTTK_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            else
            {
                if (CTTK_PB_AnhDaiDien.Image != null)
                {
                    CTTK_PB_AnhDaiDien.Image.Dispose();
                    CTTK_PB_AnhDaiDien.Image = null;
                }

                CTTK_PB_AnhDaiDien.Image = Properties.Resources.CTTK_MacDinh;
                CTTK_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;

                PB_TrangChu_ThongTinTaiKhoan.Image = Properties.Resources.CTTK_MacDinh;
                PB_TrangChu_ThongTinTaiKhoan.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

       private void TaiKhoan_GB_LoadingData(NhanVien nhanVien)
        {
            CTTK_TB_PassWord.Visible = false;
            CTTK_TB_UserName.Visible = false;
            CTTK_L_HienThiMatKhau.Visible = false;
            CTTK_L_PassWord.Visible = false;
            CTTK_L_UserName.Visible = false;
            CTTK_FCB_HienThiMatKhau.Visible = false;
            CTTK_B_ThayDoiTaiKhoan.Visible = false;

            CTTK_TB_HoVaTen.Text = nhanVien.HoVaTen.ToString();
            CTTK_TB_MaNhanVien.Text = nhanVien.ChucVu.ToString();
            //CTTK_TB_ChucVu.Text = nhanVien.ChucVu.ToString();
            CTTK_TB_DiaChi.Text = nhanVien.DiaChi.ToString();
            CTTK_TB_NgaySinh.Text = "12/07/2003";
            CTTK_TB_CCCD.Text = nhanVien.CCCD.ToString();
            CTTK_TB_SDT.Text = nhanVien.SDT.ToString();
           
        }

        private void GB_CTTK_CB_Loading()
        {
            List<NhanVien> listNV = bLL_NhanVien.LoadingNhanVien();

            CTTK_CB_ChucVu.Items.Clear();

            if (listNV == null || listNV.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nhân viên!");
                return;
            }

            // Dùng HashSet để lọc trùng
            HashSet<string> chucVuSet = new HashSet<string>();

            foreach (var nv in listNV)
            {
                if (!string.IsNullOrWhiteSpace(nv.ChucVu))
                {
                    chucVuSet.Add(nv.ChucVu);
                }
            }

            foreach (var chucVu in chucVuSet)
            {
                CTTK_CB_ChucVu.Items.Add(chucVu);
            }

            if (CTTK_CB_ChucVu.Items.Count > 0)
            {
                CTTK_CB_ChucVu.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Lỗi chức vụ!");
            }


            // loading CB_GioiTinh;
            CTTK_CB_GioiTinh.Items.Clear();
            CTTK_CB_GioiTinh.Items.Add("Nữ");
            CTTK_CB_GioiTinh.Items.Add("Nam");
            CTTK_CB_GioiTinh.SelectedIndex = 0;


            //loading CB_hinhThucLamViec
            CTTK_CB_HinhThucLamViec.Items.Clear();
            CTTK_CB_HinhThucLamViec.Items.Add("Full Time !");
            CTTK_CB_HinhThucLamViec.Items.Add("Pass Time !");
            CTTK_CB_HinhThucLamViec.SelectedIndex = 0;

        }



        private void CTTK_B_Loading_Click(object sender, EventArgs e)
        {
            TrangChu_GB_LoadingData(nhanVien, taiKhoan);
        }

        #endregion


    }
}
#region Demo
//DataTable dt = new DataTable();
//dt.Columns.Add("STT");
//    dt.Columns.Add("TenHang");
//    dt.Columns.Add("SL");
//    dt.Columns.Add("DonGia");
//    dt.Columns.Add("ThanhTien");

//    DataRow dr = dt.NewRow();
//dr["STT"] = 1;
//    dr["TenHang"] = "Quan áo ";
//    dr["DonGia"] = "190.200";
//    dr["SL"] = "10";
//    dr["ThanhTien"] = "290.900";

//    dt.Rows.Add(dr);
//private void HoaDon_CB_SizeSanPham_SelectedIndexChanged(object sender, EventArgs e)
//{
//    string maSanPham = HoaDon_CB_SizeSanPham.SelectedItem.ToString();
//    List<KhoHang> listTmp = bll_LoadingKhoHang.LoadingKhoHang();
//    if (bll_LoadingSPSize.LocTheoSize(maSanPham , listSPSize , listKhoHang) == null)
//    {
//        LoadingSamPham(listTmp);
//        return;
//    }
//    else
//    {
//        listTmp = bll_LoadingSPSize.LocTheoSize(maSanPham, listSPSize, listKhoHang);
//        LoadingSamPham(listTmp);
//    }
//}

//private void HD_CB_LoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
//{
//    HoaDon_CB_SizeSanPham.SelectedIndex = 0;
//    string tenLoai = HD_CB_LoaiSanPham.SelectedItem.ToString();
//    List<KhoHang> listTmp = bll_LoadingKhoHang.LoadingKhoHang();
//    if(bll_LoadingLoaiSanPham.LocLoaiSanPham(tenLoai , listLoaiSanPham , listTmp) == null)
//    {
//        LoadingSamPham(listTmp);
//        return;
//    }
//    else
//    {
//        listTmp = bll_LoadingLoaiSanPham.LocLoaiSanPham(tenLoai, listLoaiSanPham, listTmp);
//        LoadingSamPham(listTmp);
//    }
//}
#endregion listChiTietSanPham