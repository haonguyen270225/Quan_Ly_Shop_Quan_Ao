using BLL;
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
    public partial class frm_TrangChu : Form
    {
        public frm_TrangChu()
        {
            InitializeComponent();

            Control[] buttons = new Control[]
            {
                B_HoaDon,
                B_DoanhThu,
                B_KhachHang,
            };

            foreach (var btn in buttons)
            {
                if (btn != null)
                {
                    btn.Click += CommonButton_Click;  // Gán sự kiện Click chung
                }
            }
        }

        private void CommonButton_Click(object sender, EventArgs e)
        {
            if (sender is Control ctrl)  // Dùng Control thay vì Button
            {
                switch (ctrl.Name)
                {
                    case nameof(B_HoaDon):
                  
                        GB_HoaDonDaBan.BaseColor = Color.Goldenrod;
                        GB_DoanhThuHomNay.BaseColor = Color.DimGray;
                        GB_DanhSachKhachHang.BaseColor = Color.DimGray;
                        break;
                    case nameof(B_DoanhThu):
                        GB_HoaDonDaBan.BaseColor = Color.DimGray;
                        GB_DoanhThuHomNay.BaseColor = Color.Goldenrod;
                        GB_DanhSachKhachHang.BaseColor = Color.DimGray;
                        break;
                    case nameof(B_KhachHang):
                        GB_HoaDonDaBan.BaseColor = Color.DimGray;
                        GB_DoanhThuHomNay.BaseColor = Color.DimGray;
                        GB_DanhSachKhachHang.BaseColor = Color.Goldenrod;
                        break;
                }
            }
        }




        private void tabPage1_Selected(object sender, TabControlEventArgs e)
        {
            if(tabPage1.SelectedTab == tab_DangXuat)
            {
                this.Close();
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

 

        private void frm_TrangChu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quan_Ly_Shop_Quan_AoDataSet.HoaDon' table. You can move, or remove it, as needed.
            this.hoaDonTableAdapter.Fill(this.quan_Ly_Shop_Quan_AoDataSet.HoaDon);

        }
    }
}
