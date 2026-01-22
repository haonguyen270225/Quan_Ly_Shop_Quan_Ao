using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
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

        //GB_CTTK;
        private int GB_CTTK_Co = -1;
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

            
        }

        private void CreateLoading_TrangChu()
        {
            BLL_LoadingData();
            taiKhoan = bll_TaiKhoan.LoadingThongTinTaiKhoan(taiKhoan);
            nhanVien = bLL_NhanVien.TT_NhanVienDangNhap(taiKhoan);//bll_NhanVien.(taiKhoan);
            
            // Cập nhật hình ảnh đại diện ! 
            if (taiKhoan.HinhAnh != null && taiKhoan.HinhAnh.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(taiKhoan.HinhAnh))
                {
                    PB_TrangChu_ThongTinTaiKhoan.Image = Image.FromStream(ms);
                }
            }
            else
            {
                PB_TrangChu_ThongTinTaiKhoan.Image = Properties.Resources.CTTK_MacDinh; // hoặc ảnh mặc định
            }

            // SLHoaDon = bll_HoaDon.DemHoaDOn_ByIDNhanVien(taiKhoan.IDNhanVien);
            L_SLHoaDon.Text = bll_HoaDon.DemHoaDOn_ByIDNhanVien(taiKhoan.IDNhanVien).ToString();
            DateTime ngayCanThongKe = DateTime.Today;
            L_TongDoanhThuTheoNgay.Text = bll_HoaDon.TongDoanhThu_TheoNgay(ngayCanThongKe).ToString("N0") + "$";
            BLL_LoadingData();
            TrangChu_GB_CTTK_LoadingData_TrangChu(nhanVien, taiKhoan);
            L_HoVaTen_MaNhanVien.Text = nhanVien.HoVaTen.ToString() + " - " + nhanVien.MaNhanVien.ToString();
            L_TrangChu_HoVaTen.Text = "Xin chào : " + nhanVien.HoVaTen.ToString();
            L_TrangChu_ChuVu.Text = "Chức vụ : " + nhanVien.ChucVu.ToString();
            L_TrangChu_TieuDe.Text = ">>> Thông tin trang chủ !";
        }


        private void frm_TrangChu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quan_Ly_Shop_Quan_AoDataSet.HoaDon' table. You can move, or remove it, as needed.
            this.hoaDonTableAdapter.Fill(this.quan_Ly_Shop_Quan_AoDataSet.HoaDon);
            CreateLoading_TrangChu();
            KhoiTao_DGV_TabKhoHang(listKhoHang);
        }


        private void tabPage1_Selected(object sender, TabControlEventArgs e)
        {
            if (HoaDon_CB_LoaiSanPham.SelectedTab == tab_DangXuat)
            {
                frm_DangNhapReaLTaiizor frm = new frm_DangNhapReaLTaiizor();
                //this.Close();
                this.Hide();
                frm.Show();
            }
            if (HoaDon_CB_LoaiSanPham.SelectedTab == tab_TrangChu)
            {

                CreateLoading_TrangChu();
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
                BLL_LoadingData();
                KhoiTao_CB_TabKhoHang(listSPSize, listLoaiSanPham);
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
        //private void frm_TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    var result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if(result == DialogResult.Yes)
        //    {
        //        Application.Exit();
        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //    }
        //}

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
            GB_CTTK_Co = 0;
            GB_ChiTietTaiKhoan.BringToFront();
            GB_ChiTietTaiKhoan.Visible = true;
            CTTK_B_Thoat.Text = "Thoát !";
            CTTK_B_Thoat.ForeColor = Color.Red;
            DGV_TrangChu.Visible = false;

            SetTextBoxReadOnlyAll(GB_ChiTietTaiKhoan, true);

            TrangChu_GB_CTTK_LoadingData_TrangChu(nhanVien, taiKhoan);
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

        #region GB_TrangChu_DanhSachKhachHang
        private int SLHoaDon = 0; 
        
        #endregion



        #region GB_TrangChu_DoanhThuHomNay



        #endregion


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
        private void CapNhat_TongThu()
        {
            tongThu = 0;
            foreach (UC_ChiTietSanPham item in FLP_ChiTietSanPham.Controls)
            {
                tongThu += item.tongThu_ChiTietSanPham;
            }
            TB_TongThu.Text = tongThu.ToString("N0") + " đ";
        }
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
        // Dữ liệu HoaDon_FLP_DanhSachChiTietSanPham
        private void XoaChiTietSanPham(UC_ChiTietSanPham uc)
        {
            FLP_ChiTietSanPham.Controls.Remove(uc);
            // CapNhat_SanPham(khoHang);
            CapNhat_SanPham();
            CapNhat_ListChiTietSanPham();
            CapNhat_TongThu();
            uc.Dispose();
        }

        private void CapNhat_ListChiTietSanPham()
        {
            listChiTietSanPham.Clear();
            foreach (UC_ChiTietSanPham item in FLP_ChiTietSanPham.Controls)
            {
                listChiTietSanPham.Add(item.chiTietSanPham);
            }
        }


        private void CapNhat_SanPham()
        {
            if (FLP_ChiTietSanPham.Controls.Count == 0)
            {
                foreach (UC_SanPham item in FLP_SanPham.Controls)
                {
                    item.sL_SanPham = 0;
                }
            }
            else
            {
                foreach (UC_SanPham sP in FLP_SanPham.Controls)
                {
                    foreach (UC_ChiTietSanPham cTSP in FLP_ChiTietSanPham.Controls)
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

        private NhanVien FunTaiKhoan_NhanVien_GB_ThonTin() // Trả về NhanVien trên GB_ThongTin
        {
            //NhanVien tmp = new NhanVien();
            NhanVien tmp = new NhanVien();
            tmp.MaNhanVien = TaiKhoan_TB_MaNhanVien.Text.Trim();
            tmp.HoVaTen = TaiKhoan_TB_HoVaTen.Text.Trim();
            tmp.Email = TaiKhoan_TB_Email.Text.Trim();
            tmp.CCCD = TaiKhoan_TB_CCCD.Text.Trim();
            tmp.SDT = TaiKhoan_TB_SDT.Text.Trim();
            tmp.DiaChi = TaiKhoan_TB_DiaChi.Text.Trim();
            tmp.ID = Convert.ToInt32(TaiKhoan_L_IDNhanVien.Text);
            // ChucVu
            tmp.ChucVu = TaiKhoan_CB_ChucVu.Text.Trim();
            //GioiTinh
            if (TaiKhoan_CB_GioiTinh.SelectedIndex == 0)
            {
                tmp.GioiTinh = 0;
            }
            else
            {
                tmp.GioiTinh = 1;
            }
            //HinhThucLamViec
            if (TaiKhoan_CB_HinhThucLamViec.SelectedIndex == 0)
            {
                tmp.HinhThucLamViec = 0;
            }
            else
            {
                tmp.HinhThucLamViec = 1;
            }
            return tmp;
        }
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
                DataGridViewImageColumn dataGridViewImageColumn = new DataGridViewImageColumn(); //------
                dataGridViewImageColumn = (DataGridViewImageColumn)TaiKhoan_DGV_ListTaiKhoan.Columns[4];
                dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
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
            DataGridViewImageColumn dataGridViewImageColumn = new DataGridViewImageColumn(); //-----
            dataGridViewImageColumn = (DataGridViewImageColumn)TaiKhoan_DGV_ListTaiKhoan.Columns[4];
            dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
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
            //DataGridViewImageColumn dataGridViewImageColumn = new DataGridViewImageColumn();
            //dataGridViewImageColumn = (DataGridViewImageColumn)TaiKhoan_DGV_ListTaiKhoan.Columns[4];
            //dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

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
           
            SetTextBoxReadOnlyAll(TaiKhoan_GBThongTin, true);
            TaiKhoan_CB_ChucVu.Enabled = false;
            TaiKhoan_CB_GioiTinh.Enabled = false;
            TaiKhoan_CB_HinhThucLamViec.Enabled = false;

           
            if (taiKhoan == null || nhanVien == null)
            {
                TaiKhoan_TB_HoVaTen.Text = "";
                TaiKhoan_TB_MaNhanVien.Text = "";
                TaiKhoan_TB_CCCD.Text = "";
                TaiKhoan_TB_SDT.Text = "";
                TaiKhoan_TB_Email.Text = "";
                TaiKhoan_TB_DiaChi.Text = "";
                TaiKhoan_L_IDNhanVien.Text = "0";
                TaiKhoan_PB_AnhDaiDien.Image = Properties.Resources.CTTK_MacDinh;
                TaiKhoan_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;
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
                TaiKhoan_L_IDNhanVien.Text = nhanVien.ID.ToString();
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
            if(TaiKhoan_TB_HoVaTen.Text == "" || TaiKhoan_TB_MaNhanVien.Text == "")
            {
                return;
            }
            else
            {
                SetTextBoxReadOnlyAll(GB_ChiTietTaiKhoan, false);
                GB_CTTK_Co = 1;
                GB_ChiTietTaiKhoan.BringToFront();
                GB_ChiTietTaiKhoan.Visible = true;

                NhanVien nhanVienGB = FunTaiKhoan_NhanVien_GB_ThonTin();
                TaiKhoan_GB_CTTK_LoadingData_CapNhat(nhanVienGB);
            }
           
            
        }

        // TaiKhoan Thêm nhân viên !;
        private void TaiKhoan_B_Them_Click(object sender, EventArgs e)
        {
            SetTextBoxReadOnlyAll(GB_ChiTietTaiKhoan, false);
            GB_CTTK_Co = 2;
            MessageBox.Show("Thêm nhân viên !");
            GB_ChiTietTaiKhoan.BringToFront();
            GB_ChiTietTaiKhoan.Visible = true;
            TaiKhoan_GB_CTTK_LoadingData_Them();
             

        }

        // TaiKhoan  Xóa nhân viên !;
        private void TaiKhoan_B_Xoa_Click(object sender, EventArgs e)
        {
           var kQ =  MessageBox.Show("Bạn có muốn xóa nhân viên ! \n Họ và tên : " + TaiKhoan_TB_HoVaTen.Text + "\n Mã nhân viên : " + TaiKhoan_TB_MaNhanVien.Text, "Thông báo !" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           if(kQ == DialogResult.No)
            {
                return;
            }
            else
            {
                NhanVien nvXoa = new NhanVien();
                nvXoa = FunTaiKhoan_NhanVien_GB_ThonTin();
                if(bLL_NhanVien.Xoa_NhanVienVaTaiKhoan(nvXoa) == false)
                {
                    MessageBox.Show("Lỗi xóa thông tin nhân viên ! \n Vui lòng thử lại !" , "Lỗi !" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    BLL_LoadingData();
                    MessageBox.Show("Đã xóa thông tin nhân viên thành công !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData_DGVListTaiKhoan(listTaiKhoan  , listNhanVien);
                }
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

        #region Tab_KhoHang

        private void KhoiTao_CB_TabKhoHang(List<SPSize> listSPSize , List<LoaiSanPham> listLoaiSanPham)
        {
            if(listSPSize.Count <= 0 || listSPSize == null)
            {
                MessageBox.Show("Lỗi không thể truy cập dữ liệu sản phẩm !", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (listLoaiSanPham.Count <= 0 || listLoaiSanPham == null)
            {
                MessageBox.Show("Lỗi không thể truy cập dữ liệu sản phẩm !", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            KhoHang_CB_Loai.Items.Clear();
            KhoHang_CB_GioiTinh.Items.Clear();
            KhoHang_CB_Size.Items.Clear();
            KhoHang_CB_TimKiem.Items.Clear();
            // Tìm kiếm :
            KhoHang_CB_TimKiem.Items.Add("Tìm kiếm !");
            KhoHang_CB_TimKiem.Items.Add("Giá : 100.000 đ -> 200.000 đ");
            KhoHang_CB_TimKiem.Items.Add("Giá : 300.000 đ -> 500.000 đ");
            KhoHang_CB_TimKiem.Items.Add("Giá : Trên 500.000 đ");
            KhoHang_CB_TimKiem.Items.Add("Đồ Nam");
            KhoHang_CB_TimKiem.Items.Add("Đồ Nữ");

            HashSet<string> hashSetListSPSize = new HashSet<string>();
            foreach(SPSize item in listSPSize)
            {
                hashSetListSPSize.Add(item.MaSize);
            }
            HashSet<string> hashSetListLoaiSanPham = new HashSet<string>();
            foreach (LoaiSanPham item in listLoaiSanPham)
            {
                hashSetListLoaiSanPham.Add(item.MaLoaiSanPham + "-" + item.TenLoai);
                KhoHang_CB_TimKiem.Items.Add(item.MaLoaiSanPham + "-" + item.TenLoai);
            }

            foreach(string item in hashSetListSPSize)
            {
                KhoHang_CB_Size.Items.Add(item);
                KhoHang_CB_TimKiem.Items.Add(item);

            }

            foreach(string item in hashSetListLoaiSanPham)
            {
                KhoHang_CB_Loai.Items.Add(item);
            }
            //Giới Tính;
            KhoHang_CB_GioiTinh.Items.Add("Nữ");
            KhoHang_CB_GioiTinh.Items.Add("Nam");
            KhoHang_CB_GioiTinh.Items.Add("Cả Nam và Nữ");

            KhoHang_CB_TimKiem.SelectedIndex = 0;
            KhoHang_CB_GioiTinh.SelectedIndex = 0;
            KhoHang_CB_Size.SelectedIndex = 0;
            KhoHang_CB_Loai.SelectedIndex = 0;
        }
        private void KhoiTao_DGV_TabKhoHang(List<KhoHang> listKhoHang)
        {
            if (listKhoHang.Count <= 0 || listKhoHang == null)
            {
                MessageBox.Show("Lỗi không thể truy cập dữ liệu kho hàng !", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("STT", typeof(int));
                dataTable.Columns.Add("Mã Hàng", typeof(string));
                dataTable.Columns.Add("Tên Hàng", typeof(string));
                dataTable.Columns.Add("Số Lượng Tồn", typeof(int));
                dataTable.Columns.Add("Giá", typeof(string));
                dataTable.Columns.Add("Size", typeof(int));
                dataTable.Columns.Add("HinhAnh", typeof(byte[]));

                KhoHang_DGV_ListSanPham.AutoGenerateColumns = true;

                // Tạo cột Button Reset
                DataGridViewButtonColumn bTNXoa = new DataGridViewButtonColumn();
                bTNXoa.Name = "Delete";
                bTNXoa.HeaderText = "";
                bTNXoa.Text = "Delete";
                bTNXoa.UseColumnTextForButtonValue = true;

                KhoHang_DGV_ListSanPham.Columns.Add(bTNXoa);

                

                KhoHang_DGV_ListSanPham.CellContentClick += KhoHang_DGV_ListKhoHang_CellContentClick; // sán sự kiện !

                int i = 1;
                foreach (KhoHang item in listKhoHang)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = i++;
                    dataRow[1] = item.MaHang;
                    dataRow[2] = item.TenHang;
                    dataRow[3] = item.SoLuongTon;
                    dataRow[4] = item.Gia.ToString("N0") + "  đ";
                    dataRow[5] = item.IDSize;
                    dataRow[6] = item.HinhAnh;
                    dataTable.Rows.Add(dataRow);
                }
                KhoHang_DGV_ListSanPham.DataSource = dataTable;
                DataGridViewImageColumn dataGridViewImageColumn = new DataGridViewImageColumn(); //-----
                dataGridViewImageColumn = (DataGridViewImageColumn)KhoHang_DGV_ListSanPham.Columns["HinhAnh"];
                dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

                KhoHang_DGV_ListSanPham.DataSource = dataTable;
            }
           
        }
        //private void TaiKhoan_DGV_ListTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0 && TaiKhoan_DGV_ListTaiKhoan.Columns[e.ColumnIndex].Name == "Reset")
        //    {
        //        int id = Convert.ToInt32(TaiKhoan_DGV_ListTaiKhoan.Rows[e.RowIndex].Cells["IDNhanVien"].Value);

        //        //MessageBox.Show($"Reset mật khẩu cho tài khoản ID = {id}");
        //        // TODO: gọi hàm reset ở đây

        //        var kq = MessageBox.Show("Bán có muốn reset  tài khoản ! \n Có IDNhanVien : " + id, "Reset Tài Khoản !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //        if (kq == DialogResult.No)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            bool kQ = false;
        //            string thongBao = "";

        //            bll_TaiKhoan.TaiKhoan_Reset(id, out thongBao, out kQ);
        //            MessageBox.Show(thongBao, "Reset Tài Khoản !", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            BLL_LoadingData();
        //            ShowData_DGVListTaiKhoan(listTaiKhoan, listNhanVien);
        //        }
        //    }
        //}
        private void KhoHang_DGV_ListKhoHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && KhoHang_DGV_ListSanPham.Columns[e.ColumnIndex].Name == "Delete")
            {
                string maHang = KhoHang_DGV_ListSanPham.Rows[e.RowIndex].Cells["Mã Hàng"].Value.ToString();
                var kQ = MessageBox.Show("Bán có muốn Xóa ! \n Có Mã Hàng  : " + maHang , "Xóa kho hàng !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(kQ == DialogResult.No)
                {
                    return;
                }
                else
                {
                    string thongBao = "";
                    if(bll_KhoHang.Xoa_KhoHangByMaHang(maHang , out thongBao ) == true)
                    {
                        MessageBox.Show("Đã xóa  hàng hóa !\n Có Mã Hàng  : " + maHang, thongBao , MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        // Gọi hàm loading lai danh sách khoHang;
                        BLL_LoadingData();
                        Show_DGVListKhoHangLoading(listKhoHang);
                    }
                    else
                    {
                        MessageBox.Show(thongBao , "Lỗi !", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    }
                }
            }
        }


//        var cellValue = TaiKhoan_DGV_ListTaiKhoan.SelectedRows[0].Cells["HinhAnh"].Value;
//        int iDNhanVien = Convert.ToInt32(TaiKhoan_DGV_ListTaiKhoan.SelectedRows[0].Cells["IDNhanVien"].Value);
//            foreach (TaiKhoan tK in listTaiKhoan)
//            {
//                foreach(NhanVien nV in listNhanVien)
//                {
//                    if(iDNhanVien == nV.ID && tK.IDNhanVien == iDNhanVien)
//                    {
//                        TaiKhoan_TB_Loading(tK , nV);
//    }
//}
//            }
            
//            if (cellValue != null && cellValue != DBNull.Value)
//{
//    byte[] imgBytes = (byte[])cellValue;
//    using (MemoryStream ms = new MemoryStream(imgBytes))
//    {
//        TaiKhoan_PB_AnhDaiDien.Image = Image.FromStream(ms);
//    }
//}
//else
//{
//    TaiKhoan_PB_AnhDaiDien.Image = Properties.Resources.CTTK_MacDinh;
//}
private void KhoHang_DGV_ListSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //BLL_LoadingData();
            string cellValue = KhoHang_DGV_ListSanPham.SelectedRows[0].Cells["Mã Hàng"].Value.ToString();
            if(cellValue.ToString() == null || cellValue.ToString() == "")
            {
                MessageBox.Show("Thông tin sản phẩm lỗi ! \n Vui lòng thử lại ! ", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           // bool res = false;
            foreach (KhoHang item in listKhoHang)
            {
                if(item.MaHang == cellValue)
                {

                    KhoHang_LoadingThongTinSanPham(item);
                    return;
                }
            }
            MessageBox.Show("Thông tin sản phẩm lỗi ! \n Vui lòng thử lại ! ", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Show_DGVListKhoHangLoading(List<KhoHang> listKhoHang) 
        {
            if (listKhoHang == null)
            {
                MessageBox.Show("Lỗi truy cập danh sách kho hàng ! \n Vui lòng thử lại !" , "Lỗi !" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                return;

            }
            else if(listKhoHang.Count <= 0)
            {
                MessageBox.Show("Lỗi truy cập danh sách kho hàng rỗng  ! \n Vui lòng thử lại !", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                KhoHang_DGV_ListSanPham.DataSource = null;
                KhoHang_DGV_ListSanPham.Rows.Clear();

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("STT", typeof(int));
                dataTable.Columns.Add("Mã Hàng", typeof(string));
                dataTable.Columns.Add("Tên Hàng", typeof(string));
                dataTable.Columns.Add("Số Lượng Tồn", typeof(int));
                dataTable.Columns.Add("Giá", typeof(string));
                dataTable.Columns.Add("Size", typeof(int));
                dataTable.Columns.Add("HinhAnh", typeof(byte[]));

                int i = 1;
                foreach (KhoHang item in listKhoHang)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = i++;
                    dataRow[1] = item.MaHang;
                    dataRow[2] = item.TenHang;
                    dataRow[3] = item.SoLuongTon;
                    dataRow[4] = item.Gia.ToString("N0") + "  đ";
                    dataRow[5] = item.IDSize;
                    dataRow[6] = item.HinhAnh;
                    dataTable.Rows.Add(dataRow);
                }
                KhoHang_DGV_ListSanPham.DataSource = dataTable;
                DataGridViewImageColumn dataGridViewImageColumn = new DataGridViewImageColumn(); //-----
                dataGridViewImageColumn = (DataGridViewImageColumn)KhoHang_DGV_ListSanPham.Columns["HinhAnh"];
                dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

                KhoHang_DGV_ListSanPham.DataSource = dataTable;

            }
        }


        private void KhoHang_LoadingThongTinSanPham(KhoHang khoHang)
        {
            if(khoHang == null)
            {
                KhoHang_TB_MaHang.Text = "";
                KhoHang_TB_TenHang.Text = "";
                KhoHang_TB_Gia.Text = "";
                KhoHang_TB_SoLuongTon.Text = "0";
                KhoHang_CB_Size.SelectedIndex = 0;
                KhoHang_CB_TimKiem.SelectedIndex = 0;
                KhoHang_CB_GioiTinh.SelectedIndex = 0;
                KhoHang_CB_Loai.SelectedIndex = 0;
                
                return;
            }
            else
            {
                BLL_LoadingData();
                KhoHang_TB_MaHang.Text = khoHang.MaHang;
                KhoHang_TB_TenHang.Text = khoHang.TenHang;
                KhoHang_TB_SoLuongTon.Text = khoHang.SoLuongTon.ToString();
                KhoHang_TB_Gia.Text = khoHang.Gia.ToString("N0") + " đ";
                LoaiSanPham tmpLoai = new LoaiSanPham();
                bool kQLoai = false;
                foreach(LoaiSanPham item in listLoaiSanPham)
                {
                    if(khoHang.IDLoaiSanPham == item.ID)
                    {
                        tmpLoai = item;
                        kQLoai = true;
                        break;
                    }
                }
               if(kQLoai == false)
                {
                    MessageBox.Show("Loading Sản phẩm không thành công ! + \n Vui lòng thử lại !", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (tmpLoai.GioiTinh == 0) KhoHang_CB_GioiTinh.SelectedIndex = 0;
                    else if (tmpLoai.GioiTinh == 0) KhoHang_CB_GioiTinh.SelectedIndex = 1;
                    else KhoHang_CB_GioiTinh.SelectedIndex = 2;
                    string s = tmpLoai.MaLoaiSanPham + "-" +  tmpLoai.TenLoai;
                    KhoHang_CB_Loai.SelectedIndex = KhoHang_CB_Loai.FindStringExact(s);
                    
                }

                bool kQSize = false; 
                SPSize tmpSPSize = new SPSize();
                foreach (SPSize item in  listSPSize)
                {
                    if(khoHang.IDSize == item.ID)
                    {
                        tmpSPSize = item;
                        kQSize = true;
                        break; 
                    }
                }

                if (kQSize == false)
                {
                    MessageBox.Show("Loading Sản phẩm không thành công ! + \n Vui lòng thử lại !", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string s = tmpSPSize.MaSize.ToString();
                    KhoHang_CB_Size.SelectedIndex = KhoHang_CB_Size.FindStringExact(s);
                }

                // Hinh ảnh;
                if( khoHang.HinhAnh == null || khoHang.HinhAnh.Length <= 0 )
                {
                    KhoHang_PB_SanPham.Image = Properties.Resources.SPDefult;
                }
                else
                {
                    byte[] imgBytes = (byte[])khoHang.HinhAnh;
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        KhoHang_PB_SanPham.Image = Image.FromStream(ms);
                    }
                }
                KhoHang_PB_SanPham.SizeMode = PictureBoxSizeMode.Zoom;

            }
        }

        private void KhoHang_B_AnhMacDinh_Click(object sender, EventArgs e)
        {
            if (KhoHang_TB_MaHang.Text == "")
            {
                MessageBox.Show("Chọn sản phẩm để cập nhật hình ảnh !", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                KhoHang_PB_SanPham.Image = Properties.Resources.SPDefult;
                byte[] hinhAnh = GetBytesFromPictureBox(KhoHang_PB_SanPham);
                string thongBao = "";

                if (bll_KhoHang.UpdateHinhAnh(KhoHang_TB_MaHang.Text, hinhAnh, out thongBao, listKhoHang) == false)
                {
                    MessageBox.Show(thongBao, "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show(thongBao, "Cập nhật !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BLL_LoadingData();
                    Show_DGVListKhoHangLoading(listKhoHang);
                    return;
                }
            }
        }

        private void KhoHang_B_TrenMay_Click(object sender, EventArgs e)
        {
            if (KhoHang_TB_MaHang.Text == "")
            {
                MessageBox.Show("Chọn sản phẩm để cập nhật hình ảnh !", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (OpenFileDialog oFD = new OpenFileDialog())
                {
                    oFD.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All files (*.*)|*.*";
                    oFD.Title = "Chọn ảnh cho hồ sơ";

                    if (oFD.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            KhoHang_PB_SanPham.Image = Image.FromFile(oFD.FileName);

                            // Tùy chọn: Căn chỉnh ảnh đẹp hơn
                            KhoHang_PB_SanPham.SizeMode = PictureBoxSizeMode.Zoom;


                            KhoHang_PB_SanPham.Image = Image.FromFile(oFD.FileName);

                            KhoHang_PB_SanPham.SizeMode = PictureBoxSizeMode.Zoom;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Không thể load ảnh!\nLỗi: " + ex.Message);
                        }

                    }
                }
                byte[] hinhAnh = GetBytesFromPictureBox(KhoHang_PB_SanPham);
                string thongBao = "";

                if (bll_KhoHang.UpdateHinhAnh(KhoHang_TB_MaHang.Text, hinhAnh, out thongBao, listKhoHang) == false)
                {
                    MessageBox.Show(thongBao, "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show(thongBao, "Cập nhật !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BLL_LoadingData();
                    Show_DGVListKhoHangLoading(listKhoHang);
                    return;
                }
            }
        }

        private void KhoHang_B_Loading_Click(object sender, EventArgs e)
        {
            BLL_LoadingData();
            Show_DGVListKhoHangLoading(listKhoHang);
            //KhoHang_TB_TimKiem.Text = "";
            KhoHang_LoadingThongTinSanPham(null);

        }
        #endregion
        private void KhoHang_B_Xoa_Click(object sender, EventArgs e)
        {
            var qes = MessageBox.Show("Bạn có muốn xóa sản phẩm trong kho hàng !", "Cảnh báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (qes == DialogResult.Yes)
            {
                string thongBao = "";
                if (bll_KhoHang.DeleteKhoHang_ByMaHang(KhoHang_TB_MaHang.Text, out thongBao) == false)
                {
                    MessageBox.Show(thongBao, "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(thongBao, "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BLL_LoadingData();
                    Show_DGVListKhoHangLoading(listKhoHang);
                    KhoHang_LoadingThongTinSanPham(null);
                }
            }
            else
            {
                return;
            }

        }

        int suaVaThem = -1;// 0 - sua , 1 - them;
    
        private void KhoHang_B_Sua_Click(object sender, EventArgs e )
        {
            // Lấy thông tin san phẩm:

            if(KhoHang_TB_MaHang.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để cập nhật !", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                KhoHang khoHangUpdate = new KhoHang();
                bool kT = false;
                foreach(KhoHang item in listKhoHang)
                {
                    if(item.MaHang == KhoHang_TB_MaHang.Text)
                    {
                        khoHangUpdate = item;
                        kT = true;
                        break;
                    }
                }
                if(kT == false)
                {
                    BLL_LoadingData();
                    Show_DGVListKhoHangLoading(listKhoHang);
                    KhoHang_LoadingThongTinSanPham(null);
                    MessageBox.Show("Lỗi không tồn tại sản phẩm trong kho hàng !", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    //KhoHang_B_Them_Click(sender, e);
                    KhoHang_GB_SanPham.Visible = true;
                    KhoHang_GB_SanPham.Enabled = true;
                    KhoHang_GB_SanPham.BringToFront();
                    KhoHang_TB_GBSP_MaHang.Text = "";
                    KhoHang_TB_GBSP_TenHang.Text = "";
                    KhoHang_TB_GBSP_GiaBan.Text = "0";
                    KhoHang_TB_GBSP_SoLuong.Text = "0";

                    KhoHang_CB_GBSP_Loai.Items.Clear();
                    KhoHang_CB_GBSP_Size.Items.Clear();
                    BLL_LoadingData();
                    foreach (LoaiSanPham item in listLoaiSanPham)
                    {
                        KhoHang_CB_GBSP_Loai.Items.Add(item.MaLoaiSanPham + "-" + item.TenLoai);
                    }
                    foreach (SPSize item in listSPSize)
                    {
                        KhoHang_CB_GBSP_Size.Items.Add(item.MaSize);
                    }
                    KhoHang_CB_GBSP_Size.SelectedIndex = 0;
                    KhoHang_CB_GBSP_Loai.SelectedIndex = 0;

                    KhoHang_RB_GBSP_Nam.Checked = true;
                    KhoHang_RB_GBSP_Nu.Checked = false;
                    KhoHang_RB_GBSP_NamVaNu.Checked = false;

                    suaVaThem = 0;
                    KhoHang_TB_GBSP_MaHang.Text = khoHangUpdate.MaHang;
                    KhoHang_TB_GBSP_TenHang.Text = khoHangUpdate.TenHang;
                    KhoHang_TB_GBSP_GiaBan.Text = khoHangUpdate.Gia.ToString("N0");
                    KhoHang_TB_GBSP_SoLuong.Text = khoHangUpdate.SoLuongTon.ToString();
                    KhoHang_CB_GBSP_Loai.Text = KhoHang_CB_Loai.Text;
                    KhoHang_CB_GBSP_Size.Text = KhoHang_CB_Size.Text;

                    if(KhoHang_CB_GioiTinh.Text == "Nam")
                    {
                        KhoHang_RB_GBSP_Nam.Checked = true;
                        KhoHang_RB_GBSP_NamVaNu.Checked = false;
                        KhoHang_RB_GBSP_Nu.Checked = false;
                    }
                    else if(KhoHang_CB_GioiTinh.Text == "Nữ")
                    {
                        KhoHang_RB_GBSP_Nam.Checked = false;
                        KhoHang_RB_GBSP_NamVaNu.Checked = false;
                        KhoHang_RB_GBSP_Nu.Checked = true;
                    }
                    else
                    {
                        KhoHang_RB_GBSP_Nam.Checked = false;
                        KhoHang_RB_GBSP_NamVaNu.Checked = true;
                        KhoHang_RB_GBSP_Nu.Checked = false;
                    }
                }
            }
        }

        //private void KhoHang_B_Sua_Click(object sender, EventArgs e)
        //{

        //}
        private void KhoHang_B_GBSanPam_XacNhan_Click(object sender, EventArgs e)
        {

            if (suaVaThem == 0) //update;
            {
                
                MessageBox.Show("Goi ham cap nhat !");
                KhoHang khoHangUpdate = new KhoHang();
                BLL_LoadingData();

                for (int i = 0; i < listKhoHang.Count; i++)
                {
                    if (listKhoHang[i].MaHang == KhoHang_TB_GBSP_MaHang.Text)
                    {
                        khoHangUpdate = listKhoHang[i];
                        break;
                    }
                }

                if (KhoHang_TB_GBSP_MaHang.Text == "")
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_MaHang, "Mã hàng không được để trống !");
                    return;
                }
                else if (KhoHang_TB_GBSP_MaHang.Text.Length > 10)
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_MaHang, "Mã hàng tối đa 10 ký tự !");
                    return;
                }
                else if (KhoHang_TB_GBSP_MaHang.Text.Length < 5)
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_MaHang, "Mã hàng tối thiểu 5 ký tự !");
                    return;
                }
                else if (KhoHang_TB_GBSP_TenHang.Text == "")
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_TenHang, "Tên hàng không được để trống !");
                    return;
                }
                else if (KhoHang_TB_GBSP_TenHang.Text.Length > 50)
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_TenHang, "Tên hàng không được quá 50 ký tự !");
                    return;
                }
                else if (KhoHang_TB_GBSP_GiaBan.Text == "")
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_GiaBan, "Gía bán không được để trống !");
                    return;
                }
                else if (KhoHang_TB_GBSP_SoLuong.Text == "")
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_SoLuong, "Số lượng không được để trống !");
                    return;
                }

                foreach(KhoHang item in listKhoHang){
                    if(item.ID != khoHangUpdate.ID && item.MaHang == khoHangUpdate.MaHang)
                    {
                        KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_MaHang , "Mã sản phẩm đã bị trùng !");
                        return;
                    }
                }

                // Kiểm tra số nguyên 
                //khoHangAdd.SoLuongTon = Convert.ToInt16(KhoHang_TB_GBSP_SoLuong.Text);
                string tmpstr1 = KhoHang_TB_GBSP_SoLuong.Text.ToString().Trim();
                int soLuongTon = -1;
                bool isInterger = int.TryParse(tmpstr1, out soLuongTon);
                if (isInterger == true && soLuongTon >= 0)
                {
                    khoHangUpdate.SoLuongTon = soLuongTon;
                }
                else
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_SoLuong, "Số lượng phải là số nguyên lớn hơn hoặc bằng 0 !");
                    return;
                }

                // kiểm tra số thực !;
                string tmpstr2 = KhoHang_TB_GBSP_GiaBan.Text;
                double giaBan = 0;
                bool isDouble = double.TryParse(tmpstr2, out giaBan);
                if (isDouble == true && giaBan > 10.000)
                {
                    khoHangUpdate.Gia = giaBan;
                    //MessageBox.Show(giaBan.ToString());
                }
                else
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_GiaBan, "Gía bán phải là phân số và lớn hơn 10.000 đ !");
                    return;
                }

                //Loại Sản phẩm !
                LoaiSanPham sPLoai = new LoaiSanPham();
                string str = KhoHang_CB_GBSP_Loai.SelectedItem.ToString();
                foreach (LoaiSanPham item in listLoaiSanPham)
                {
                    string strTmp = item.MaLoaiSanPham + "-" + item.TenLoai;
                    if (str == strTmp)
                    {
                        sPLoai = item;
                        break;
                    }
                }
                khoHangUpdate.IDLoaiSanPham = sPLoai.ID;

                // Gioi tính
                SPSize sPSize = new SPSize();
                string strSize = KhoHang_CB_GBSP_Size.SelectedItem.ToString();
                foreach (SPSize item in listSPSize)
                {
                    if (item.MaSize == strSize)
                    {
                        sPSize = item;
                    }
                }
                khoHangUpdate.IDSize = sPSize.ID;

                khoHangUpdate.MaHang = KhoHang_TB_GBSP_MaHang.Text;
                khoHangUpdate.TenHang = KhoHang_TB_GBSP_TenHang.Text;
                khoHangUpdate.SoLuongTon = Convert.ToInt32(KhoHang_TB_GBSP_SoLuong.Text);
                khoHangUpdate.Gia = Convert.ToDouble(KhoHang_TB_GBSP_GiaBan.Text);
                
                string thongBaos;
              //  KhoHang_B_Sua_Click(sender, e, khoHangUpdate);
                if (bll_KhoHang.Upadte_KhoHang(khoHangUpdate, out thongBaos) == false)
                {
                    MessageBox.Show(thongBaos, "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(thongBaos, "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                KhoHang_GB_SanPham.Visible = false;
                KhoHang_GB_SanPham.Enabled = false;
                KhoHang_GB_SanPham.SendToBack();
                KhoHang_TB_GBSP_MaHang.Text = "";
                KhoHang_TB_GBSP_TenHang.Text = "";
                KhoHang_TB_GBSP_GiaBan.Text = "0";
                KhoHang_TB_GBSP_SoLuong.Text = "0";

                KhoHang_CB_GBSP_Loai.Items.Clear();
                KhoHang_CB_GBSP_Size.Items.Clear();
                suaVaThem = -1;

            }
            if(suaVaThem == 1)
            {

                if (KhoHang_TB_GBSP_MaHang.Text == "")
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_MaHang, "Mã hàng không được để trống !");
                    return;
                }
                else if (KhoHang_TB_GBSP_MaHang.Text.Length > 10)
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_MaHang, "Mã hàng tối đa 10 ký tự !");
                    return;
                }
                else if (KhoHang_TB_GBSP_MaHang.Text.Length < 5)
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_MaHang, "Mã hàng tối thiểu 5 ký tự !");
                    return;
                }
                else if (KhoHang_TB_GBSP_TenHang.Text == "")
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_TenHang, "Tên hàng không được để trống !");
                    return;
                }
                else if (KhoHang_TB_GBSP_TenHang.Text.Length > 50)
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_TenHang, "Tên hàng không được quá 50 ký tự !");
                    return;
                }
                else if (KhoHang_TB_GBSP_GiaBan.Text == "")
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_GiaBan, "Gía bán không được để trống !");
                    return;
                }
                else if (KhoHang_TB_GBSP_SoLuong.Text == "")
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_SoLuong, "Số lượng không được để trống !");
                    return;
                }

                foreach (KhoHang item in listKhoHang)
                {
                    if (item.MaHang == KhoHang_TB_GBSP_MaHang.Text)
                    {
                        KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_MaHang, "Mã hàng đa có trong kho ! \n Nhập lại mã hàng !");
                    }
                }


                KhoHang khoHangAdd = new KhoHang();
                khoHangAdd.MaHang = KhoHang_TB_GBSP_MaHang.Text;
                khoHangAdd.TenHang = KhoHang_TB_GBSP_TenHang.Text;

                //khoHangAdd.SoLuongTon = Convert.ToInt16(KhoHang_TB_GBSP_SoLuong.Text);
                string tmpstr1 = KhoHang_TB_GBSP_SoLuong.Text.ToString().Trim();
                int soLuongTon = -1;
                bool isInterger = int.TryParse(tmpstr1, out soLuongTon);
                if (isInterger == true && soLuongTon >= 0)
                {
                    khoHangAdd.SoLuongTon = soLuongTon;
                }
                else
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_SoLuong, "Số lượng phải là số nguyên lớn hơn hoặc bằng 0 !");
                    return;
                }

                string tmpstr2 = KhoHang_TB_GBSP_GiaBan.Text;
                double giaBan = 0;
                bool isDouble = double.TryParse(tmpstr2, out giaBan);
                if (isDouble == true && giaBan > 10.000)
                {
                    khoHangAdd.Gia = giaBan;
                    //MessageBox.Show(giaBan.ToString());
                }
                else
                {
                    KhoHang_EP_GBSP.SetError(KhoHang_TB_GBSP_GiaBan, "Gía bán phải là phân số và lớn hơn 10.000 đ !");
                    return;
                }


                //Loại sản phẩm !;
                LoaiSanPham sPLoai = new LoaiSanPham();
                string str = KhoHang_CB_GBSP_Loai.SelectedItem.ToString();
                foreach (LoaiSanPham item in listLoaiSanPham)
                {
                    string strTmp = item.MaLoaiSanPham + "-" + item.TenLoai;
                    if (str == strTmp)
                    {
                        sPLoai = item;
                        break;
                    }
                }
                khoHangAdd.IDLoaiSanPham = sPLoai.ID;

                // Gioi tính
                SPSize sPSize = new SPSize();
                string strSize = KhoHang_CB_GBSP_Size.SelectedItem.ToString();
                foreach (SPSize item in listSPSize)
                {
                    if (item.MaSize == strSize)
                    {
                        sPSize = item;
                    }
                }
                khoHangAdd.IDSize = sPSize.ID;

                //HinhAnh;
                khoHangAdd.HinhAnh = ImageToByteArray(Properties.Resources.SPDefult);
                //MessageBox.Show(khoHangAdd.IDSize.ToString() + "--" + khoHangAdd.IDLoaiSanPham.ToString() + khoHangAdd.TenHang.ToString());
                string thongBao = "";
                bool kQ = false;
                kQ = bll_KhoHang.Insert_KhoHang(khoHangAdd, out thongBao);
                if (kQ == false)
                {
                    MessageBox.Show(thongBao, "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(thongBao, "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                KhoHang_GB_SanPham.Visible = false;
                KhoHang_GB_SanPham.Enabled = false;
                KhoHang_GB_SanPham.SendToBack();
                KhoHang_TB_GBSP_MaHang.Text = "";
                KhoHang_TB_GBSP_TenHang.Text = "";
                KhoHang_TB_GBSP_GiaBan.Text = "0";
                KhoHang_TB_GBSP_SoLuong.Text = "0";

                KhoHang_CB_GBSP_Loai.Items.Clear();
                KhoHang_CB_GBSP_Size.Items.Clear();

                BLL_LoadingData();
                Show_DGVListKhoHangLoading(listKhoHang);
                KhoHang_LoadingThongTinSanPham(null);
                suaVaThem = -1;
            }
        }
        private void KhoHang_B_Them_Click(object sender, EventArgs e)
        {
            suaVaThem = 1;
            KhoHang_GB_SanPham.Visible = true;
            KhoHang_GB_SanPham.Enabled = true;
            KhoHang_GB_SanPham.BringToFront();
            KhoHang_TB_GBSP_MaHang.Text = "";
            KhoHang_TB_GBSP_TenHang.Text = "";
            KhoHang_TB_GBSP_GiaBan.Text = "0";
            KhoHang_TB_GBSP_SoLuong.Text = "0";

            KhoHang_CB_GBSP_Loai.Items.Clear();
            KhoHang_CB_GBSP_Size.Items.Clear();
            BLL_LoadingData();
            foreach (LoaiSanPham item in listLoaiSanPham)
            {
                KhoHang_CB_GBSP_Loai.Items.Add(item.MaLoaiSanPham + "-" + item.TenLoai);
            }
            foreach (SPSize item in listSPSize)
            {
                KhoHang_CB_GBSP_Size.Items.Add(item.MaSize);
            }
            KhoHang_CB_GBSP_Size.SelectedIndex = 0;
            KhoHang_CB_GBSP_Loai.SelectedIndex = 0;

            KhoHang_RB_GBSP_Nam.Checked = true;
            KhoHang_RB_GBSP_Nu.Checked = false;
            KhoHang_RB_GBSP_NamVaNu.Checked = false;
        }

        private void KhoHang_B_GBSanPam_Thoat_Click(object sender, EventArgs e)
        {
            var qes = MessageBox.Show("Bạn có muốn thoát !", "Thông báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (qes == DialogResult.Yes)
            {
                KhoHang_GB_SanPham.Visible = false;
                KhoHang_GB_SanPham.Enabled = false;
                KhoHang_GB_SanPham.SendToBack();
                KhoHang_TB_GBSP_MaHang.Text = "";
                KhoHang_TB_GBSP_TenHang.Text = "";
                KhoHang_TB_GBSP_GiaBan.Text = "0";
                KhoHang_TB_GBSP_SoLuong.Text = "0";

                KhoHang_CB_GBSP_Loai.Items.Clear();
                KhoHang_CB_GBSP_Size.Items.Clear();
                suaVaThem = -1;
            }
            else
            {
                return;
            }

        }



        private void KhoHang_TB_TextChanged(object sender, EventArgs e)
        {

            KhoHang_EP_GBSP.Clear();
        }

        private void KhoHang_CB_GBSP_Loai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoaiSanPham loaiSanPham = new LoaiSanPham();
            string str = KhoHang_CB_GBSP_Loai.SelectedItem.ToString();
            foreach (LoaiSanPham item in listLoaiSanPham)
            {
                string itemStr = item.MaLoaiSanPham + "-" + item.TenLoai;
                if (str == itemStr)
                {
                    loaiSanPham = item;
                    break;
                }
            }
            if (loaiSanPham.GioiTinh == 1)
            {
                //KhoHang_CB_GioiTinh_Nam.Checked = true;
                KhoHang_RB_GBSP_Nam.Checked = false;
                KhoHang_RB_GBSP_Nu.Checked = true;
                KhoHang_RB_GBSP_NamVaNu.Checked = false;
            }
            else if (loaiSanPham.GioiTinh == 0)
            {
                KhoHang_RB_GBSP_Nam.Checked = true;
                KhoHang_RB_GBSP_Nu.Checked = false;
                KhoHang_RB_GBSP_NamVaNu.Checked = false;
            }
            else
            {
                KhoHang_RB_GBSP_Nam.Checked = false;
                KhoHang_RB_GBSP_Nu.Checked = false;
                KhoHang_RB_GBSP_NamVaNu.Checked = true;
            }
        }


        #region GB_ChiTietTaiKhoan

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

       private void TrangChu_GB_CTTK_LoadingData_TrangChu(NhanVien nhanVien , TaiKhoan taiKhoan)
        {
            CTTK_B_Thoat.Text = "Thoát !";
            CTTK_B_Thoat.ForeColor = Color.Red;

            CTTK_B_QuayLai.Visible = false;
            CTTK_TB_PassWord.Visible = true;
            CTTK_TB_UserName.Visible = true;
            CTTK_L_HienThiMatKhau.Visible = true;
            CTTK_L_PassWord.Visible = true;
            CTTK_L_UserName.Visible = true;
            CTTK_FCB_HienThiMatKhau.Visible = true;
            CTTK_B_ThayDoiTaiKhoan.Visible = true;
            //Loading G_ChiTietTaiKhoan
            CTTK_TB_HoVaTen.Text = nhanVien.HoVaTen.ToString();
            CTTK_TB_MaNhanVien.Text = nhanVien.MaNhanVien.ToString();
            CTTK_TB_Email.Text = nhanVien.Email.ToString();
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


            //
            CTTK_PB_AnhDaiDien.Image = PB_TrangChu_ThongTinTaiKhoan.Image;
            CTTK_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;
            PB_TrangChu_ThongTinTaiKhoan.SizeMode = PictureBoxSizeMode.Zoom;
            CTTK_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;
            // Loading PB_HinhAnh

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
        }

       private void TaiKhoan_GB_CTTK_LoadingData_CapNhat(NhanVien nhanVien)
        {
            CTTK_B_Thoat.Text = "Cập nhật !";
            CTTK_B_Thoat.ForeColor = Color.Green;

            CTTK_B_QuayLai.Visible = true;
            CTTK_B_QuayLai.Text = "Exit !";
            CTTK_TB_PassWord.Visible = false;
            CTTK_TB_UserName.Visible = false;
            CTTK_L_HienThiMatKhau.Visible = false;
            CTTK_L_PassWord.Visible = false;
            CTTK_L_UserName.Visible = false;
            CTTK_FCB_HienThiMatKhau.Visible = false;
            CTTK_B_ThayDoiTaiKhoan.Visible = false;

            
            //Loading G_ChiTietTaiKhoan
            CTTK_TB_HoVaTen.Text = nhanVien.HoVaTen.ToString();
            CTTK_TB_MaNhanVien.Text = nhanVien.MaNhanVien.ToString();
            CTTK_TB_Email.Text = nhanVien.Email.ToString();
            CTTK_TB_DiaChi.Text = nhanVien.DiaChi.ToString();
            CTTK_TB_NgaySinh.Text = "12/07/2003";
            CTTK_TB_CCCD.Text = nhanVien.CCCD.ToString();
            CTTK_TB_SDT.Text = nhanVien.SDT.ToString();


            if (TaiKhoan_PB_AnhDaiDien.Image != null)
            {
                CTTK_PB_AnhDaiDien.Image = new Bitmap(TaiKhoan_PB_AnhDaiDien.Image);
            }
            else
            {
                CTTK_PB_AnhDaiDien.Image = null;
            }
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
        }

       private void TaiKhoan_GB_CTTK_LoadingData_Them()
        {
            CTTK_B_Thoat.Text = "Thêm mới!";
            CTTK_B_Thoat.ForeColor = Color.Green;

            CTTK_B_QuayLai.Visible = true;
            CTTK_B_QuayLai.Text = "Exit !";
            CTTK_TB_PassWord.Visible = false;
            CTTK_TB_UserName.Visible = false;
            CTTK_L_HienThiMatKhau.Visible = false;
            CTTK_L_PassWord.Visible = false;
            CTTK_L_UserName.Visible = false;
            CTTK_FCB_HienThiMatKhau.Visible = false;
            CTTK_B_ThayDoiTaiKhoan.Visible = false;


            //Loading G_ChiTietTaiKhoan
            CTTK_TB_HoVaTen.Text = "";
            CTTK_TB_MaNhanVien.Text = "";
            CTTK_TB_Email.Text = "";
            CTTK_TB_DiaChi.Text = "";
            CTTK_TB_NgaySinh.Text = "";
            CTTK_TB_CCCD.Text = "";
            CTTK_TB_SDT.Text = "";

            GB_CTTK_CB_Loading();

            // GioiTinh
            // 0 -> Nu , 1 -> Nam ;
            CTTK_CB_GioiTinh.SelectedIndex = 0;
            // HinhThucLamViec
            CTTK_CB_HinhThucLamViec.SelectedIndex = 0; // 0 -> full time
            // ChucVu
           TaiKhoan_CB_ChucVu.SelectedIndex = 0;
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

            if (GB_CTTK_Co ==  0) // GB_CTTK_TrangChu;
            {
                TrangChu_GB_CTTK_LoadingData_TrangChu(nhanVien, taiKhoan);
            }
            else if(GB_CTTK_Co == 1) // GB_CTTK_CapNhat
            {
                // Lấy thông tin nhân viên;
                MessageBox.Show("Gọi hàm cập nhật nhân viên !");
                TaiKhoan_GB_CTTK_LoadingData_CapNhat(FunTaiKhoan_NhanVien_GB_ThonTin());
            }
            else if(GB_CTTK_Co == 2)
            {
                // Nhan vien rỗng !
                MessageBox.Show("Gọi hàm thêm nhân viên !");
                TaiKhoan_GB_CTTK_LoadingData_Them();
            }
            else
            {
                MessageBox.Show("Lỗi : Thông tin nhân viên ! \n Vui lòng thử lại !", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void CTTK_B_Thoat_Click(object sender, EventArgs e)
        {
            if (GB_CTTK_Co == 0) // GB_CTTK_TrangChu
            {
                byte[] hinhAnh = GetBytesFromPictureBox(CTTK_PB_AnhDaiDien); // Cập nhật hình ảnh ?
                string thongBao = "";
                if(bll_TaiKhoan.CapNhatHinhAnh_TaoKhoan(taiKhoan.IDNhanVien, hinhAnh, out thongBao) == false)
                {
                    MessageBox.Show(thongBao, "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    GB_ChiTietTaiKhoan.SendToBack();
                    GB_ChiTietTaiKhoan.Visible = false;
                    DGV_TrangChu.Visible = true;
                    PB_TrangChu_ThongTinTaiKhoan.Image = CTTK_PB_AnhDaiDien.Image;
                    return;
                }




            }
            else if (GB_CTTK_Co == 1) // GB_CTTK_CapNhat
            {
                // gọi hàm cập nhật tài khoản
                MessageBox.Show("Gọi hàm cập nhật nhân viên !");
                NhanVien nhanVienCapNhat = new NhanVien();
                nhanVienCapNhat.MaNhanVien = CTTK_TB_MaNhanVien.Text.Trim();
                nhanVienCapNhat.HoVaTen = CTTK_TB_HoVaTen.Text.Trim();
                nhanVienCapNhat.Email = CTTK_TB_Email.Text.Trim();
                nhanVienCapNhat.CCCD = CTTK_TB_CCCD.Text.Trim();
                nhanVienCapNhat.SDT = CTTK_TB_SDT.Text.Trim();
                nhanVienCapNhat.DiaChi = CTTK_TB_DiaChi.Text.Trim();
                nhanVienCapNhat.ID = Convert.ToInt32(TaiKhoan_L_IDNhanVien.Text);
                // ChucVu
                nhanVienCapNhat.ChucVu = CTTK_CB_ChucVu.Text.Trim();
                //GioiTinh
                if(CTTK_CB_GioiTinh.SelectedIndex == 0)
                {
                    nhanVienCapNhat.GioiTinh = 0;
                }
                else
                {
                    nhanVienCapNhat.GioiTinh = 1;
                }
                //HinhThucLamViec
                if (CTTK_CB_HinhThucLamViec.SelectedIndex == 0) 
                {
                    nhanVienCapNhat.HinhThucLamViec = 0;
                }
                else
                {
                    nhanVienCapNhat.HinhThucLamViec = 1;
                }

                
                // hinhAnh;
                byte[] hinhAnh = GetBytesFromPictureBox(CTTK_PB_AnhDaiDien);
                //
                string thongBao = "";
                
                if(bLL_NhanVien.CapNhat_NhanVien(nhanVienCapNhat , listNhanVien , hinhAnh ,out thongBao) == false)
                {
                    MessageBox.Show(thongBao, "Lỗi cập nhật nhân viên !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else 
                {
                    MessageBox.Show(thongBao, "Cập nhật thành công !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GB_ChiTietTaiKhoan.SendToBack();
                    BLL_LoadingData();
                    TaiKhoan_PB_AnhDaiDien.Image = CTTK_PB_AnhDaiDien.Image;
                    TaiKhoan_GB_CTTK_LoadingData_CapNhat(nhanVien = new NhanVien());
                    ShowData_DGVListTaiKhoan(listTaiKhoan, listNhanVien);
                    
                }
                
                //bLL_NhanVien.CapNhat_NhanVien()

            }
            else if (GB_CTTK_Co == 2) // GB_CTTK_ThemNhanVien
            {
                // gọi hàm thêm nhân viên !
                MessageBox.Show("Gọi hàm thêm nhân viên !");
                NhanVien nhanVienThem = new NhanVien();
                nhanVienThem.MaNhanVien = CTTK_TB_MaNhanVien.Text.Trim();
                nhanVienThem.HoVaTen = CTTK_TB_HoVaTen.Text.Trim();
                nhanVienThem.Email = CTTK_TB_Email.Text.Trim();
                nhanVienThem.CCCD = CTTK_TB_CCCD.Text.Trim();
                nhanVienThem.SDT = CTTK_TB_SDT.Text.Trim();
                nhanVienThem.DiaChi = CTTK_TB_DiaChi.Text.Trim();
                nhanVienThem.ID = Convert.ToInt32(TaiKhoan_L_IDNhanVien.Text);
                // ChucVu
                nhanVienThem.ChucVu = CTTK_CB_ChucVu.Text.Trim();
                //GioiTinh
                if (CTTK_CB_GioiTinh.SelectedIndex == 0)
                {
                    nhanVienThem.GioiTinh = 0;
                }
                else
                {
                    nhanVienThem.GioiTinh = 1;
                }
                //HinhThucLamViec
                if (CTTK_CB_HinhThucLamViec.SelectedIndex == 0)
                {
                    nhanVienThem.HinhThucLamViec = 0;
                }
                else
                {
                    nhanVienThem.HinhThucLamViec = 1;
                }
                // HinhAnh:
                byte[] hinhAnh = GetBytesFromPictureBox(CTTK_PB_AnhDaiDien);
                //
                string thongBao = "";
                BLL_LoadingData();
                if (bLL_NhanVien.Them_NhanVienvaTaiKhoan(nhanVienThem, listNhanVien, hinhAnh,out thongBao) == false)
                {
                    MessageBox.Show(thongBao, "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    BLL_LoadingData();
                    MessageBox.Show(thongBao, "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // GB_ChiTietTaiKhoan.SendToBack();
                    TaiKhoan_GB_CTTK_LoadingData_CapNhat(nhanVien = new NhanVien());
                    ShowData_DGVListTaiKhoan(listTaiKhoan, listNhanVien);

                    //restet CTTK_PB_AnhDaiDien.Image 
                    CTTK_PB_AnhDaiDien.Image = Properties.Resources.CTTK_MacDinh;
                    CTTK_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom; //CTTK_B_AnhMacDinh_Click(this , EventArgs.Empty);
                    
                }

            }
            else
            {
                MessageBox.Show("Lỗi : Thông tin nhân viên ! \n Vui lòng thử lại !", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void CTTK_B_QuayLai_Click(object sender, EventArgs e)
        {
            var kQ = MessageBox.Show("Bạn có muốn thoát !" , "Thông báo !" , MessageBoxButtons.YesNo , MessageBoxIcon.Error);
            if(kQ == DialogResult.Yes)
            {
                GB_ChiTietTaiKhoan.SendToBack();
                TaiKhoan_GB_CTTK_LoadingData_Them();
                //restet CTTK_PB_AnhDaiDien.Image 
                CTTK_PB_AnhDaiDien.Image = Properties.Resources.CTTK_MacDinh;
                CTTK_PB_AnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                return;
            }
        }
        byte[] GetBytesFromPictureBox(PictureBox pB)
        {
            if (pB.Image == null) return null;

            using (MemoryStream ms = new MemoryStream())
            using (Bitmap bmp = new Bitmap(pB.Image))   // clone ảnh để tránh bị lock
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // ép format
                return ms.ToArray();
            }
        }
        public byte[] ImageToByteArray(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png); // hoặc Jpeg tùy bạn
                return ms.ToArray();
            }
        }
        private void TaiKhoan_BT_AnhMacDinh_Click(object sender, EventArgs e)
        {

        }
        private void TaiKhoan_BT_AnhTrenMay_Click(object sender, EventArgs e)
        {

        }

        private void KhoHang_B_InDanhSach_Click(object sender, EventArgs e)
        {

        }

        private void HoaDon_CB_LoaiSanPham_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(nhanVien.ChucVu != "Quản lý" && (e.TabPage == tab_DoanhThu || e.TabPage == tab_KhuyenMai || e.TabPage == tab_KhoHang || e.TabPage == tab_TaiKhoan) )
            {
                MessageBox.Show("Bạn không có quyền truy cập tab này!");
                e.Cancel = true;
            }
        }




        #endregion
        private void B_TrangChu_KhachHang_Click(object sender, EventArgs e)
        {
            Report_KhachHang report_KhachHang = new Report_KhachHang();
            report_KhachHang.ShowDialog();

        }

        private void B_TrangChu_DoanhThu_Click(object sender, EventArgs e)
        {

        }

        private void B_TrangChu_HoaDon_Click(object sender, EventArgs e)
        {
            Report_HoaDon report_HoaDon = new Report_HoaDon();
            report_HoaDon.ShowDialog();
        }


        private void controlBox1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                    "Bạn có chắc muốn thoát?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                  );

                if (result == DialogResult.Yes)
                {
                Application.Exit();
                }
            else
            {
                return;
            }
           
        }



        //private void KhoHang_B_Them_Click(object sender, EventArgs e)
        //{
        //    KhoHang_GB_SanPham.Visible = true;
        //    KhoHang_GB_SanPham.Enabled = true;
        //    KhoHang_GB_SanPham.BringToFront();
        //}

        //private void TaiKhoan_B_ThoatGBSanPham_Click(object sender, EventArgs e)
        //{
        //    var qes = MessageBox.Show("Bạn có muốn thoát !", "Xác nhận !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if(qes == DialogResult.Yes)
        //    {
        //        KhoHang_GB_SanPham.Visible = false;
        //        KhoHang_GB_SanPham.Enabled = false;
        //        KhoHang_GB_SanPham.SendToBack();
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
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