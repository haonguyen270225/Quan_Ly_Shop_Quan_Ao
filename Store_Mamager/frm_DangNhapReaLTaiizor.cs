using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor.Forms;
using DTO;
using BLL;
using System.Security.Cryptography;
namespace Store_Manager
{
    public partial class frm_DangNhapReaLTaiizor : LostForm
    {
        #region KhaiBao
        public static TaiKhoan taiKhoan = new TaiKhoan();
        private BLL_TaiKhoan bll_TaiKhoan = new BLL_TaiKhoan();
        private BLL_LoadingThongTinTaiKhoan bLL_LoadingThongTinTaiKhoan = new BLL_LoadingThongTinTaiKhoan();
        #endregion


        public frm_DangNhapReaLTaiizor()
        {
            InitializeComponent();
        }
          
        private void frm_DangNhapReaLTaiizor_Load(object sender, EventArgs e)
        {
            TB_MatKhau.UseSystemPasswordChar = true;
            FCB_HienThiMatKhau.Checked = false;
            FCB_HienThiMatKhau.Text = "Hiển thị mật khẩu !";
        }

        private void B_DangNhap_Click(object sender, EventArgs e)
        {
           
            taiKhoan.UserName = TB_TenDangNhap.Text;
            taiKhoan.PassWord = TB_MatKhau.Text;

            if (bll_TaiKhoan.BLL_CheckLogin(taiKhoan) == -1)
            {
                MessageBox.Show("Tên đăng nhập không để trống !");
            }
            else if(bll_TaiKhoan.BLL_CheckLogin(taiKhoan) == -2)
            {
                MessageBox.Show("Mật khẩu không để trống !");
            }
            else if(bll_TaiKhoan.BLL_CheckLogin(taiKhoan) >= 1)
            {
                this.Hide();
                MessageBox.Show("Đăng nhập thành công !");
                // Store_Manager.frm_TrangChu frm = new Store_Manager.frm_TrangChu();
                //frm.ShowDialog();
                taiKhoan = bLL_LoadingThongTinTaiKhoan.LoadingThongTinTaiKhoan(taiKhoan); 
                //MessageBox.Show(taiKhoan.ID.ToString() + "   " + taiKhoan.IDNhanVien.ToString()  );
                frm_TrangChu  frm_TrangChu = new frm_TrangChu();
                frm_TrangChu.taiKhoan = taiKhoan;
                MessageBox.Show(taiKhoan.ID.ToString() + "   " + taiKhoan.IDNhanVien.ToString());
                frm_TrangChu.ShowDialog();
                 Application.Exit();
            }
            else
            {
                LB_ThongBao.Visible = true;
            }
            
        }

        private void FCB_HienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if(FCB_HienThiMatKhau.Checked == true)
            {
                TB_MatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                TB_MatKhau.UseSystemPasswordChar = true;
            }
        }

        private void LB_ThongBao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(LB_ThongBao.Visible == true)
            {
                LB_ThongBao.Visible = false;
            }
        }
    }
}
