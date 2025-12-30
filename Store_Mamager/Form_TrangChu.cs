using BLL;
using DTO;
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
namespace Store_Mamager
{
    public partial class Form_TrangChu : MaterialForm
    {
        public Form_TrangChu()
        {
            InitializeComponent();
            //InitializeComponent();
           

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme
            (
            Primary.Blue900,     // Thanh tiêu đề
            Primary.Blue700,     // Thanh trên khi focus
            Primary.Green900,     // Màu phụ
            Accent.Blue700, // Accent (button, checkbox)
            TextShade.WHITE      // Màu chữ
            );
        }

        private void Form_TrangChu_Load(object sender, EventArgs e)
        {
            M_CB_ChucVu.Items.Insert(0, "-- Chức vụ --");
            M_CB_ChucVu.Items.Insert(1, "Thu ngân");
            M_CB_ChucVu.Items.Insert(2, "Quản lý kho");
            M_CB_ChucVu.Items.Insert(3, "Giao hàng");
            M_CB_ChucVu.Items.Insert(4, "Nhân viên");
            M_CB_ChucVu.Items.Insert(5, "Quản lý");
            M_CB_ChucVu.SelectedIndex = 0;
            M_CB_ChucVu.ForeColor = Color.White;
            M_CB_ThoiGianLam.Items.Insert(0, "-- Thời gian --");
            M_CB_ThoiGianLam.Items.Insert(1, "Full time");
            M_CB_ThoiGianLam.Items.Insert(2, "Pass time");
            M_CB_ThoiGianLam.SelectedIndex = 0;
            M_CB_ThoiGianLam.ForeColor = Color.White;
        }


        private void m_TabC_ChucNang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(m_TabC_ChucNang.SelectedIndex == m_TabC_ChucNang.TabCount - 1)
            {
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tab_DonHang_Click(object sender, EventArgs e)
        {

        }
    }
}
