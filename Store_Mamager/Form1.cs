using MaterialSkin;
using MaterialSkin.Controls;
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
namespace Store_Mamager
{
    
    public partial class Form1 : MaterialForm
    {
        TaiKhoan taiKhoan = new TaiKhoan();
        BLL_TaiKhoan bLLTaiKhoa = new BLL_TaiKhoan();
        public Form1()
        {
            //InitializeComponent();
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme
            (
            Primary.Blue700,     // Thanh tiêu đề
            Primary.Blue900,     // Thanh trên khi focus
            Primary.Yellow700,     // Màu phụ
            Accent.Red400, // Accent (button, checkbox)
            TextShade.WHITE      // Màu chữ
            );

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

      

      

        private void M_TB_UserName_Click(object sender, EventArgs e)
        {
            M_TB_UserName.Text = "";
        }

        private void M_TB_PassWord_Click(object sender, EventArgs e)
        {
            M_TB_PassWord.Text = "";
        }

        private void M_TB_DangNhap_Click(object sender, EventArgs e)
        {
            taiKhoan.PassWord = M_TB_PassWord.Text;
            taiKhoan.UserName = M_TB_UserName.Text;

            EP_CheckLogin.BlinkRate = 100;
            int ck = bLLTaiKhoa.BLL_CheckLogin(taiKhoan);
            switch (ck)
            {
                case -1:
                    EP_CheckLogin.Clear();
                    EP_CheckLogin.SetError(M_TB_UserName, "UserName không được để trống !");
                    break;
                case -2:
                    EP_CheckLogin.Clear();
                    EP_CheckLogin.SetError(M_TB_PassWord, "PassWord không được để trống !");
                    break;
                case 0:
                    EP_CheckLogin.Clear();
                    MessageBox.Show("PassWord hoặc UserName không đúng !");
                    break;
                case 1:
                    EP_CheckLogin.Clear();
                    MessageBox.Show(" Đăng nhập thành công !");
                    break;
            }
        }

        private void M_TB_UserName_MouseLeave(object sender, EventArgs e)
        {
            if(M_TB_UserName.Text == "UserName" || M_TB_UserName.Text == "")
            {
                M_TB_UserName.Text = "UserName";
            }
        }

        private void M_TB_PassWord_MouseLeave(object sender, EventArgs e)
        {
            if (M_TB_PassWord.Text == "PassWord" || M_TB_PassWord.Text == "")
            {
                M_TB_PassWord.Text = "PassWord";
            }
        }

        private void M_TB_UserName_Click_1(object sender, EventArgs e)
        {
            if(M_TB_UserName.Text == "UserName")
            {
                M_TB_UserName.Text = "";
            }
        }

        private void M_TB_PassWord_Click_1(object sender, EventArgs e)
        {
            if(M_TB_PassWord.Text == "PassWord")
            {
                M_TB_PassWord.Text = "";
            }
        }

        private void M_TB_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
