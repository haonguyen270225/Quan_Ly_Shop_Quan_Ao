using BLL;
using DTO;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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

       private List<NhanVien> listNhanVien = new List<NhanVien>();
       private BLL_ThongTinNhanVien thongTinNhanVien = new BLL_ThongTinNhanVien();

       int dem = 0;
       int soTrang = 0;
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

            // load thông tin nhân viên !
            listNhanVien = thongTinNhanVien.LoadingThongTinNhanVien();

            if (listNhanVien.Count > 0  & listNhanVien != null)
            {
                MessageBox.Show("Đã có dữ liệu !");
                B_Trai.Visible = false;
                if(listNhanVien.Count >= 3)
                {
                    M_L_HoVaTen1.Text = "Họ và tên :" + listNhanVien[0].HoVaTen.ToString();
                    M_L_ChucVu1.Text = "Chức vụ :" + listNhanVien[0].ChucVu.ToString();
                    M_L_MaNhanVien1.Text = "Mã NV :" + listNhanVien[0].MaNhanVien.ToString();
                    M_L_SDT1.Text = "SDT : " + listNhanVien[0].SDT.ToString();

                    M_L_HoVaTen2.Text = "Họ và tên :" + listNhanVien[1].HoVaTen.ToString();
                    M_L_ChucVu2.Text = "Chức vụ :" + listNhanVien[1].ChucVu.ToString();
                    M_L_MaNhanVien2.Text = "Mã NV :" + listNhanVien[1].MaNhanVien.ToString();
                    M_L_SDT2.Text = "SDT : " + listNhanVien[1].SDT.ToString();

                    M_L_HoVaTen3.Text = "Họ và tên :" + listNhanVien[2].HoVaTen.ToString();
                    M_L_ChucVu3.Text = "Chức vụ :" + listNhanVien[2].ChucVu.ToString();
                    M_L_MaNhanVien3.Text = "Mã NV :" + listNhanVien[2].MaNhanVien.ToString();
                    M_L_SDT3.Text = "SDT : " + listNhanVien[2].SDT.ToString();
                    
                }
                else if(listNhanVien.Count == 2)
                {
                    M_L_HoVaTen1.Text = "Họ và tên :" + listNhanVien[0].HoVaTen.ToString();
                    M_L_ChucVu1.Text = "Chức vụ :" + listNhanVien[0].ChucVu.ToString();
                    M_L_MaNhanVien1.Text = "Mã NV :" + listNhanVien[0].MaNhanVien.ToString();
                    M_L_SDT1.Text = "SDT : " + listNhanVien[0].SDT.ToString();

                    M_L_HoVaTen2.Text = "Họ và tên :" + listNhanVien[1].HoVaTen.ToString();
                    M_L_ChucVu2.Text = "Chức vụ :" + listNhanVien[1].ChucVu.ToString();
                    M_L_MaNhanVien2.Text = "Mã NV :" + listNhanVien[1].MaNhanVien.ToString();
                    M_L_SDT2.Text = "SDT : " + listNhanVien[1].SDT.ToString();
                    
                }
                else if(listNhanVien.Count == 1)
                {
                    M_L_HoVaTen1.Text = "Họ và tên :" + listNhanVien[0].HoVaTen.ToString();
                    M_L_ChucVu1.Text = "Chức vụ :" + listNhanVien[0].ChucVu.ToString();
                    M_L_MaNhanVien1.Text = "Mã NV :" + listNhanVien[0].MaNhanVien.ToString();
                    M_L_SDT1.Text = "SDT : " + listNhanVien[0].SDT.ToString();
                }


                if(listNhanVien.Count <= 3)
                {
                    B_Trai.Visible = false;
                    B_Phai.Visible = false;
                    soTrang = 1;
                }
                else if(listNhanVien.Count > 3)
                {
                    if(listNhanVien.Count % 3 == 0)
                    {
                        soTrang = listNhanVien.Count / 3;
                    }
                    else
                    {
                        soTrang = listNhanVien.Count / 3 + 1;
                    }
                    B_Phai.Visible = true;
                }
                L_KetQua.Text = "Kết quả : " + listNhanVien.Count.ToString();

            }
            
        }


        private void m_TabC_ChucNang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(m_TabC_ChucNang.SelectedIndex == m_TabC_ChucNang.TabCount - 1)
            {
                this.Close();
            }
        }


        private void B_Phai_Click(object sender, EventArgs e)
        {
            dem++;
            if(dem == soTrang) // Kiểm tr cuối danh sách
            {
                int tmp = listNhanVien.Count;
                tmp -= 1;
                M_L_HoVaTen3.Text = "Họ và tên :" + listNhanVien[tmp].HoVaTen.ToString();
                M_L_ChucVu3.Text = "Chức vụ :" + listNhanVien[tmp].ChucVu.ToString();
                M_L_MaNhanVien3.Text = "Mã NV :" + listNhanVien[tmp].MaNhanVien.ToString();
                M_L_SDT3.Text = "SDT : " + listNhanVien[tmp].SDT.ToString();
                tmp -= 1;
                M_L_HoVaTen2.Text = "Họ và tên :" + listNhanVien[tmp].HoVaTen.ToString();
                M_L_ChucVu2.Text = "Chức vụ :" + listNhanVien[tmp].ChucVu.ToString();
                M_L_MaNhanVien2.Text = "Mã NV :" + listNhanVien[tmp].MaNhanVien.ToString();
                M_L_SDT2.Text = "SDT : " + listNhanVien[tmp].SDT.ToString();
                tmp -= 1;
                M_L_HoVaTen1.Text = "Họ và tên :" + listNhanVien[tmp].HoVaTen.ToString();
                M_L_ChucVu1.Text = "Chức vụ :" + listNhanVien[tmp].ChucVu.ToString();
                M_L_MaNhanVien1.Text = "Mã NV :" + listNhanVien[tmp].MaNhanVien.ToString();
                M_L_SDT1.Text = "SDT : " + listNhanVien[tmp].SDT.ToString();
                B_Phai.Visible = false;
                B_Trai.Visible = true;

            }
            else // chưa đến cuôi danh sách !
            {
               
                int tmp = dem * 3;
                tmp -= 1;
                M_L_HoVaTen3.Text = "Họ và tên :" + listNhanVien[tmp].HoVaTen.ToString();
                M_L_ChucVu3.Text = "Chức vụ :" + listNhanVien[tmp].ChucVu.ToString();
                M_L_MaNhanVien3.Text = "Mã NV :" + listNhanVien[tmp].MaNhanVien.ToString();
                M_L_SDT3.Text = "SDT : " + listNhanVien[tmp].SDT.ToString();
                tmp -= 1;
                M_L_HoVaTen2.Text = "Họ và tên :" + listNhanVien[tmp].HoVaTen.ToString();
                M_L_ChucVu2.Text = "Chức vụ :" + listNhanVien[tmp].ChucVu.ToString();
                M_L_MaNhanVien2.Text = "Mã NV :" + listNhanVien[tmp].MaNhanVien.ToString();
                M_L_SDT2.Text = "SDT : " + listNhanVien[tmp].SDT.ToString();
                tmp -= 1;
                M_L_HoVaTen1.Text = "Họ và tên :" + listNhanVien[tmp].HoVaTen.ToString();
                M_L_ChucVu1.Text = "Chức vụ :" + listNhanVien[tmp].ChucVu.ToString();
                M_L_MaNhanVien1.Text = "Mã NV :" + listNhanVien[tmp].MaNhanVien.ToString();
                M_L_SDT1.Text = "SDT : " + listNhanVien[tmp].SDT.ToString();
                B_Trai.Visible = true;
                B_Phai.Visible = true;
            }
           // MessageBox.Show(dem.ToString());
        }

        //private void UpdateButton()
        //{
        //    if(listNhanVien.Count > 3)
        //    {

        //    }
        //    if(dem == listNhanVien.Count)
        //    {
        //        B_Phai.Visible=false;
        //        B_Trai.Visible = true;
        //    }
        //}
        private void B_Trai_Click(object sender, EventArgs e)
        {
            dem--;
            if (dem == 1) // Kiểm tra đầu danh sách !
            {
                M_L_HoVaTen1.Text = "Họ và tên :" + listNhanVien[0].HoVaTen.ToString();
                M_L_ChucVu1.Text = "Chức vụ :" + listNhanVien[0].ChucVu.ToString();
                M_L_MaNhanVien1.Text = "Mã NV :" + listNhanVien[0].MaNhanVien.ToString();
                M_L_SDT1.Text = "SDT : " + listNhanVien[0].SDT.ToString();

                M_L_HoVaTen2.Text = "Họ và tên :" + listNhanVien[1].HoVaTen.ToString();
                M_L_ChucVu2.Text = "Chức vụ :" + listNhanVien[1].ChucVu.ToString();
                M_L_MaNhanVien2.Text = "Mã NV :" + listNhanVien[1].MaNhanVien.ToString();
                M_L_SDT2.Text = "SDT : " + listNhanVien[1].SDT.ToString();

                M_L_HoVaTen3.Text = "Họ và tên :" + listNhanVien[2].HoVaTen.ToString();
                M_L_ChucVu3.Text = "Chức vụ :" + listNhanVien[2].ChucVu.ToString();
                M_L_MaNhanVien3.Text = "Mã NV :" + listNhanVien[2].MaNhanVien.ToString();
                M_L_SDT3.Text = "SDT : " + listNhanVien[2].SDT.ToString();

                B_Trai.Visible = false;
                B_Phai.Visible = true;
            }
            else // Chưa đến đầu danh sách !
            {
                int tmp = dem * 3;
                tmp -= 1;
                M_L_HoVaTen3.Text = "Họ và tên :" + listNhanVien[tmp].HoVaTen.ToString();
                M_L_ChucVu3.Text = "Chức vụ :" + listNhanVien[tmp].ChucVu.ToString();
                M_L_MaNhanVien3.Text = "Mã NV :" + listNhanVien[tmp].MaNhanVien.ToString();
                M_L_SDT3.Text = "SDT : " + listNhanVien[tmp].SDT.ToString();
                tmp -= 1;
                M_L_HoVaTen2.Text = "Họ và tên :" + listNhanVien[tmp].HoVaTen.ToString();
                M_L_ChucVu2.Text = "Chức vụ :" + listNhanVien[tmp].ChucVu.ToString();
                M_L_MaNhanVien2.Text = "Mã NV :" + listNhanVien[tmp].MaNhanVien.ToString();
                M_L_SDT2.Text = "SDT : " + listNhanVien[tmp].SDT.ToString();
                tmp -= 1;
                M_L_HoVaTen1.Text = "Họ và tên :" + listNhanVien[tmp].HoVaTen.ToString();
                M_L_ChucVu1.Text = "Chức vụ :" + listNhanVien[tmp].ChucVu.ToString();
                M_L_MaNhanVien1.Text = "Mã NV :" + listNhanVien[tmp].MaNhanVien.ToString();
                M_L_SDT1.Text = "SDT : " + listNhanVien[tmp].SDT.ToString();
                B_Trai.Visible = true;
                B_Phai.Visible = true;
            }
        }
    }
}
