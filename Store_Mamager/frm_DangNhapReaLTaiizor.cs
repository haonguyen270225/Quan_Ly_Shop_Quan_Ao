using BLL;
using DTO;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Store_Manager
{
    public partial class frm_DangNhapReaLTaiizor : LostForm
    {
        #region KhaiBao
        public static TaiKhoan taiKhoan = new TaiKhoan();
        private BLL_TaiKhoan bll_TaiKhoan = new BLL_TaiKhoan();
        
        #endregion


        public frm_DangNhapReaLTaiizor()
        {
            InitializeComponent();
            
        }
          
        private void frm_DangNhapReaLTaiizor_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            TB_TenDangNhap.Text = "24_UserName";
            TB_PassWord.Text = "Qua lý Trung";
            TB_TenDangNhap.TabIndex = 0;
            TB_PassWord.TabIndex = 1;
            B_DangNhap.TabIndex = 2;
            B_Thoat.TabIndex = 3;

            TB_PassWord.UseSystemPasswordChar = true;
            FCB_HienThiMatKhau.Checked = false;
            FCB_HienThiMatKhau.Text = "Hiển thị mật khẩu !";

            
        }

        

        private void B_DangNhap_Click(object sender, EventArgs e)
        {
           
            taiKhoan.UserName = TB_TenDangNhap.Text;
            taiKhoan.PassWord = TB_PassWord.Text;

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
                taiKhoan = bll_TaiKhoan.LoadingThongTinTaiKhoan(taiKhoan); 
                frm_TrangChu  frm_TrangChu = new frm_TrangChu();
                frm_TrangChu.taiKhoan = taiKhoan;
                frm_TrangChu.ShowDialog();
               // Application.Exit();
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
                TB_PassWord.UseSystemPasswordChar = false;
            }
            else
            {
                TB_PassWord.UseSystemPasswordChar = true;
            }
        }

        private void LB_ThongBao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(LB_ThongBao.Visible == true)
            {
                LB_ThongBao.Visible = false;
            }
        }

        private void B_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //private void GanSuKienEnterChoTatCaTextBox(Control parent)
        //{
        //    foreach (Control ctrl in parent.Controls)
        //    {
        //        if (ctrl is TextBox txt)
        //        {
        //            txt.KeyDown += TextBox_KeyDown;
        //        }

        //        if (ctrl.HasChildren) // Nếu là Panel/GroupBox...
        //        {
        //            GanSuKienEnterChoTatCaTextBox(ctrl);
        //        }
        //    }
        //}
        //private void TextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        //   e.Handled = true;    // Ngăn tiếng "ding" khi nhấn Enter
        //        e.SuppressKeyPress = true;

        //        // Chuyển focus sang control tiếp theo theo TabIndex
        //        this.SelectNextControl((Control)sender, true, true, true, true);
        //    }
        //}
    }
}
