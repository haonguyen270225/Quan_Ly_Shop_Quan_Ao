using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
namespace Store_Manager
{
    public partial class frm_TrangChu : Form
    {
        #region KhaiBao
        public static TaiKhoan taiKhoan = new TaiKhoan();
        private NhanVien nhanVien = new NhanVien();
        private List<KhoHang> listKhoHang = new List<KhoHang>();
        private BLL_ThongTinTaiKhoanDangNhap bLL_ThongTinTaiKhoanDangNhap = new BLL_ThongTinTaiKhoanDangNhap();
        private BLL_LoadingThongTinTaiKhoan bLL_LoadingThongTinTaiKhoan = new BLL_LoadingThongTinTaiKhoan();
        private BLL_LoadingKhoHang bll_LoadingKhoHang = new BLL_LoadingKhoHang();
        
        #endregion


        public void CreateLoading_TrangDonHang()
        {
            listKhoHang = bll_LoadingKhoHang.LoadingKhoHang();
            FLP_HoaDon.Controls.Clear();
            for (int i = 0; i < listKhoHang.Count ; i++)
            {
                UC_HoaDon_SanPham uc = new UC_HoaDon_SanPham(listKhoHang[i]);
                FLP_HoaDon.Controls.Add(uc);
            }
        }
        public void CreateLoading_TrangChu()
         {
            taiKhoan.UserName = "binh.tran";
            taiKhoan.PassWord = "123456";
            taiKhoan = bLL_LoadingThongTinTaiKhoan.LoadingThongTinTaiKhoan(taiKhoan);
            //MessageBox.Show(taiKhoan.ID.ToString() + "   " + taiKhoan.IDNhanVien.ToString());
            //MessageBox.Show("Gọi hàm CreateLoading()");
            nhanVien = bLL_ThongTinTaiKhoanDangNhap.ThongTinTaiKhoanDangNhap(taiKhoan);
            L_HoVaTen_MaNhanVien.Text = nhanVien.HoVaTen.ToString() + " - " + nhanVien.MaNhanVien.ToString();
            L_TrangChu_HoVaTen.Text = "Xin chào : " + nhanVien.HoVaTen.ToString();
            L_TrangChu_ChuVu.Text = "Chức vụ : " + nhanVien.ChucVu.ToString();
            L_TrangChu_TieuDe.Text = ">>> Thông tin trang chủ !";
            //Loading G_ChiTietTaiKhoan
            CTTK_TB_HoVaTen.Text = nhanVien.HoVaTen.ToString();
            CTTK_TB_ChuVu.Text = nhanVien.ChucVu.ToString();
            CTTK_TB_DiaChi.Text = nhanVien.DiaChi.ToString();
            CTTK_TB_NgaySinh.Text = "12/07/2003";
            CTTK_TB_CCCD.Text = nhanVien.CCCD.ToString();
            CTTK_TB_SDT.Text = nhanVien.SDT.ToString();
            CTTK_TB_MaNhanVien.Text = nhanVien.MaNhanVien.ToString();
            CTTK_TB_UserName.Text = taiKhoan.UserName.ToString();
            CTTK_TB_PassWord.UseSystemPasswordChar = true;
            CTTK_TB_PassWord.Text = taiKhoan.PassWord.ToString();
            
            if(nhanVien.GioiTinh == 1)
            {
                CTTK_TB_GioiTinh.Text = "Nam";
            }
            else
            {
                CTTK_TB_GioiTinh.Text = "Nu";
            }

            if(nhanVien.HinhThucLamViec == 0)
            {
                CTTK_TB_HinhThucLamViec.Text = "Full Time !";
            }
            else
            {
                CTTK_TB_HinhThucLamViec.Text = "Pass Time !";
            }
        }

       

        private void frm_TrangChu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quan_Ly_Shop_Quan_AoDataSet.HoaDon' table. You can move, or remove it, as needed.
             this.hoaDonTableAdapter.Fill(this.quan_Ly_Shop_Quan_AoDataSet.HoaDon);
            CreateLoading_TrangChu();
           
            MessageBox.Show(taiKhoan.UserName.ToString() + "    " + taiKhoan.PassWord.ToString());
            MessageBox.Show(nhanVien.HoVaTen.ToString() + "    " + nhanVien.CCCD.ToString());
          
        }

        public frm_TrangChu()
        {
            InitializeComponent();
        }

        private void tabPage1_Selected(object sender, TabControlEventArgs e)
        {
            if(tabPage1.SelectedTab == tab_DangXuat)
            {
                this.Close();
            }
            if(tabPage1.SelectedTab == tab_TrangChu)
            {
                L_TrangChu_TieuDe.Text = ">>> Thông tin trang chủ !";
            }
            else if(tabPage1.SelectedTab == tab_HoaDon)
            {
                L_TrangChu_TieuDe.Text = ">> Thêm hóa đơn !";
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

        private void tab_HoaDon_Click(object sender, EventArgs e)
        {

        }
    }
}
