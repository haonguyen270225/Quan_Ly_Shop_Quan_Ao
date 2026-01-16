using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
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
        public static TaiKhoan taiKhoan = new TaiKhoan();
        private NhanVien nhanVien = new NhanVien();
        private List<KhoHang> listKhoHang = new List<KhoHang>();
        private List<LoaiSanPham> listLoaiSanPham = new List<LoaiSanPham>();
        private List<SPSize> listSPSize = new List<SPSize>();
        private List<KhachHang> listKhachHang = new List<KhachHang>();
        private List<KhuyenMai> listKhuyenMai = new List<KhuyenMai>();

        private BLL_NhanVien bLL_NhanVien = new BLL_NhanVien();
        private BLL_TaiKhoan bll_TaiKhoan = new BLL_TaiKhoan();
        private BLL_KhoHang bll_LoadingKhoHang = new BLL_KhoHang();
        private BLL_LoaiSanPham bll_LoadingLoaiSanPham = new BLL_LoaiSanPham();
        private BLL_SPSize bll_LoadingSPSize = new BLL_SPSize();
        private BLL_KhuyenMai bll_LoadingKhuyenMai = new BLL_KhuyenMai();
        private BLL_KhachHang bll_LoadingKhachHang = new BLL_KhachHang();
        private BLL_HoaDon bll_LoadingHoaDon = new BLL_HoaDon();
        private UC_SanPham ucSanPham;
        private UC_ChiTietSanPham ucChiTietSanPham;

        //private List<KhoHang> listSanPham;
        private List<KhoHang> listChiTietSanPham = new List<KhoHang>();
        private double tongThu = 0;
        private List<ChiTietHoaDon> listChiTietHoaDon = new List<ChiTietHoaDon>();
        private List<HoaDon> listHoaDon = new List<HoaDon>();
        #endregion

        #region TrangChu
        public frm_TrangChu()
        {
            InitializeComponent();
        }

       
        public void CreateLoading_TrangChu()
        {
            //taiKhoan.UserName = "binh.tran";
            //taiKhoan.PassWord = "123456";
            taiKhoan = bll_TaiKhoan.LoadingThongTinTaiKhoan(taiKhoan);

            listKhachHang = bll_LoadingKhachHang.LoadingKhachHang();
            listHoaDon = bll_LoadingHoaDon.LoadingHoaDon();
            //MessageBox.Show(taiKhoan.ID.ToString() + "   " + taiKhoan.IDNhanVien.ToString());
            //MessageBox.Show("Gọi hàm CreateLoading()");
            nhanVien = bLL_NhanVien.TT_NhanVienDangNhap(taiKhoan);//bll_NhanVien.(taiKhoan);
            L_HoVaTen_MaNhanVien.Text = nhanVien.HoVaTen.ToString() + " - " + nhanVien.MaNhanVien.ToString();
            L_TrangChu_HoVaTen.Text = "Xin chào : " + nhanVien.HoVaTen.ToString();
            L_TrangChu_ChuVu.Text = "Chức vụ : " + nhanVien.ChucVu.ToString();
            L_TrangChu_TieuDe.Text = ">>> Thông tin trang chủ !";
            //Loading G_ChiTietTaiKhoan
            CTTK_TB_HoVaTen.Text = nhanVien.HoVaTen.ToString();
            CTTK_TB_MaNhanVien.Text = nhanVien.ChucVu.ToString();
            CTTK_TB_ChucVu.Text = nhanVien.ChucVu.ToString();
            CTTK_TB_DiaChi.Text = nhanVien.DiaChi.ToString();
            CTTK_TB_NgaySinh.Text = "12/07/2003";
            CTTK_TB_CCCD.Text = nhanVien.CCCD.ToString();
            CTTK_TB_SDT.Text = nhanVien.SDT.ToString();
            CTTK_TB_MaNhanVien.Text = nhanVien.MaNhanVien.ToString();
            CTTK_TB_UserName.Text = taiKhoan.UserName.ToString();
            CTTK_TB_PassWord.UseSystemPasswordChar = true;
            CTTK_TB_PassWord.Text = taiKhoan.PassWord.ToString();
            if (nhanVien.GioiTinh == 1)
            {
                CTTK_TB_GioiTinh.Text = "Nam";
            }
            else
            {
                CTTK_TB_GioiTinh.Text = "Nu";
            }

            if (nhanVien.HinhThucLamViec == 0)
            {
                CTTK_TB_HinhThucLamViec.Text = "Full Time !";
            }
            else
            {
                CTTK_TB_HinhThucLamViec.Text = "Pass Time !";
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
                L_TrangChu_TieuDe.Text = ">> Thêm hóa đơn !";
                listKhoHang = bll_LoadingKhoHang.LoadingKhoHang();
                listKhuyenMai = bll_LoadingKhuyenMai.LoadingKhuyenMai();
                CreateLoading_TrangDonHang();
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


        private void parrotButton1_Click(object sender, EventArgs e)
        {
            GB_ChiTietTaiKhoan.BringToFront();
            GB_ChiTietTaiKhoan.Visible = true;
            DG_TrangChu.Visible = false;
        }

        private void CTTK_B_Thoat_Click(object sender, EventArgs e)
        {
            GB_ChiTietTaiKhoan.SendToBack();
            GB_ChiTietTaiKhoan.Visible = false;
            DG_TrangChu.Visible = true;

        }

        private void FCB_HienThiMatKhau_CTTK_CheckedChanged(object sender, EventArgs e)
        {
            if (FCB_HienThiMatKhau_CTTK.Checked == true)
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
            listSPSize = bll_LoadingSPSize.LoadingSPSize();
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
            listLoaiSanPham = bll_LoadingLoaiSanPham.LoadingLoaiSanPham();
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
            List<KhoHang> listTmp = bll_LoadingKhoHang.LoadingKhoHang();
            if (bll_LoadingSPSize.LocTheoSize(maSanPham, listSPSize, listKhoHang) == null)
            {
                AddSanPham(listTmp);
                return;
            }
            else
            {
                listTmp = bll_LoadingSPSize.LocTheoSize(maSanPham, listSPSize, listKhoHang);
                AddSanPham(listTmp);
            }
        }

        private void HD_CB_LoaiSanPham_SelectionChangeCommitted(object sender, EventArgs e)
        {
            HoaDon_CB_SizeSanPham.SelectedIndex = 0;
            string tenLoai = HD_CB_LoaiSanPham.SelectedItem.ToString();
            List<KhoHang> listTmp = bll_LoadingKhoHang.LoadingKhoHang();
            if (bll_LoadingLoaiSanPham.LocLoaiSanPham(tenLoai, listLoaiSanPham, listTmp) == null)
            {
                AddSanPham(listTmp);
                return;
            }
            else
            {
                listTmp = bll_LoadingLoaiSanPham.LocLoaiSanPham(tenLoai, listLoaiSanPham, listTmp);
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
            CapNhat_ListChiTietSanPham();
            CapNhat_TongThu();
            uc.Dispose();
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
                AddSanPham(bll_LoadingKhoHang.LoadingKhoHang());
                return;
            }
            else
            {
                List<KhoHang> listTmp = bll_LoadingKhoHang.LoadingKhoHang();
                if (XuLy_Chuoi.TimKiem_DanhSanhKhoHang(listTmp, HoaDon_TB_TenSanPham.Text).Count == 0)
                {
                    MessageBox.Show("Không có sản phẩm phù hợp !");
                }
                else
                {
                    FLP_SanPham.Controls.Clear();
                    listTmp = XuLy_Chuoi.TimKiem_DanhSanhKhoHang(listTmp, HoaDon_TB_TenSanPham.Text);
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
           
            listKhachHang = bll_LoadingKhachHang.LoadingKhachHang();
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

                // Load ảnh mặc định từ Resources
                CTTK_PB_AnhDaiDien.Image = Properties.Resources.CTTK_MacDinh;

                // Tùy chỉnh hiển thị (khuyến nghị)
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