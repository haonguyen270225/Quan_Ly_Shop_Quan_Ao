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
using System.Security.Cryptography;
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

       private BLL_ThongTinNhanVien thongTinNhanVien = new BLL_ThongTinNhanVien();
       private List<NhanVien> listNhanVien = new List<NhanVien>();
        string userName = "Nguyễn Văn An";

       int dem = 0;
       int soTrang = 0;
        private void Form_TrangChu_Load(object sender, EventArgs e)
        {
            L_UserName.Text = userName.ToUpper();
            M_CB_ChucVu.Items.Insert(0, "-- Chức vụ --");
            M_CB_ChucVu.Items.Insert(1, "Nhân viên kho");
            M_CB_ChucVu.Items.Insert(2, "Nhân viên bán hàng");
            M_CB_ChucVu.Items.Insert(3, "Quản lý");
            M_CB_ChucVu.Items.Insert(4, "Kế toán");
            
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
                //MessageBox.Show("Đã có dữ liệu !");
                B_Trai.Visible = false;
                if(listNhanVien.Count >= 3)
                {
                    M_L_HoVaTen1.Text = "Họ và tên :" + listNhanVien[0].HoVaTen.ToString();
                    M_L_ChucVu1.Text = "Chức vụ :" + listNhanVien[0].ChucVu.ToString();
                    M_L_MaNhanVien1.Text = "Mã NV :" + listNhanVien[0].MaNhanVien.ToString();
                    M_L_SDT1.Text = "SDT : " + listNhanVien[0].SDT.ToString();
                    M_L_HTLViec1.Text = "Hình thức làm việc :" + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[0].HinhThucLamViec);

                    M_L_HoVaTen2.Text = "Họ và tên :" + listNhanVien[1].HoVaTen.ToString();
                    M_L_ChucVu2.Text = "Chức vụ :" + listNhanVien[1].ChucVu.ToString();
                    M_L_MaNhanVien2.Text = "Mã NV :" + listNhanVien[1].MaNhanVien.ToString();
                    M_L_SDT2.Text = "SDT : " + listNhanVien[1].SDT.ToString();
                    M_L_HTLViec2.Text = "Hình thức làm việc :" + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[1].HinhThucLamViec);

                    M_L_HoVaTen3.Text = "Họ và tên :" + listNhanVien[2].HoVaTen.ToString();
                    M_L_ChucVu3.Text = "Chức vụ :" + listNhanVien[2].ChucVu.ToString();
                    M_L_MaNhanVien3.Text = "Mã NV :" + listNhanVien[2].MaNhanVien.ToString();
                    M_L_SDT3.Text = "SDT : " + listNhanVien[2].SDT.ToString();
                    M_L_HTLViec3.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[2].HinhThucLamViec);

                }
                else if(listNhanVien.Count == 2)
                {
                    M_L_HoVaTen1.Text = "Họ và tên :" + listNhanVien[0].HoVaTen.ToString();
                    M_L_ChucVu1.Text = "Chức vụ :" + listNhanVien[0].ChucVu.ToString();
                    M_L_MaNhanVien1.Text = "Mã NV :" + listNhanVien[0].MaNhanVien.ToString();
                    M_L_SDT1.Text = "SDT : " + listNhanVien[0].SDT.ToString();
                    M_L_HTLViec1.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[0].HinhThucLamViec);

                    M_L_HoVaTen2.Text = "Họ và tên :" + listNhanVien[1].HoVaTen.ToString();
                    M_L_ChucVu2.Text = "Chức vụ :" + listNhanVien[1].ChucVu.ToString();
                    M_L_MaNhanVien2.Text = "Mã NV :" + listNhanVien[1].MaNhanVien.ToString();
                    M_L_SDT2.Text = "SDT : " + listNhanVien[1].SDT.ToString();
                    M_L_HTLViec2.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[1].HinhThucLamViec);
                }
                else if(listNhanVien.Count == 1)
                {
                    M_L_HoVaTen1.Text = "Họ và tên :" + listNhanVien[0].HoVaTen.ToString();
                    M_L_ChucVu1.Text = "Chức vụ :" + listNhanVien[0].ChucVu.ToString();
                    M_L_MaNhanVien1.Text = "Mã NV :" + listNhanVien[0].MaNhanVien.ToString();
                    M_L_SDT1.Text = "SDT : " + listNhanVien[0].SDT.ToString();
                    M_L_HTLViec1.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[0].HinhThucLamViec);
                }


                if(listNhanVien.Count <= 3)
                {
                    if(listNhanVien.Count == 0)
                    {
                        GB_1.Visible = false;
                        GB_2.Visible = false;
                        GB_3.Visible = false;
                    }
                    else if(listNhanVien.Count == 1)
                    {
                        GB_2.Visible = false;
                        GB_3.Visible = false;
                    }
                    else if(listNhanVien.Count == 2)
                    {
                        GB_3.Visible = false;
                    }
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
                M_L_HTLViec3.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[tmp].HinhThucLamViec);
                tmp -= 1;
                M_L_HoVaTen2.Text = "Họ và tên :" + listNhanVien[tmp].HoVaTen.ToString();
                M_L_ChucVu2.Text = "Chức vụ :" + listNhanVien[tmp].ChucVu.ToString();
                M_L_MaNhanVien2.Text = "Mã NV :" + listNhanVien[tmp].MaNhanVien.ToString();
                M_L_SDT2.Text = "SDT : " + listNhanVien[tmp].SDT.ToString();
                M_L_HTLViec2.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[tmp].HinhThucLamViec);
                tmp -= 1;
                M_L_HoVaTen1.Text = "Họ và tên :" + listNhanVien[tmp].HoVaTen.ToString();
                M_L_ChucVu1.Text = "Chức vụ :" + listNhanVien[tmp].ChucVu.ToString();
                M_L_MaNhanVien1.Text = "Mã NV :" + listNhanVien[tmp].MaNhanVien.ToString();
                M_L_SDT1.Text = "SDT : " + listNhanVien[tmp].SDT.ToString();
                M_L_HTLViec1.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[tmp].HinhThucLamViec);
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
                M_L_HTLViec3.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[tmp].HinhThucLamViec);
                tmp -= 1;
                M_L_HoVaTen2.Text = "Họ và tên :" + listNhanVien[tmp].HoVaTen.ToString();
                M_L_ChucVu2.Text = "Chức vụ :" + listNhanVien[tmp].ChucVu.ToString();
                M_L_MaNhanVien2.Text = "Mã NV :" + listNhanVien[tmp].MaNhanVien.ToString();
                M_L_SDT2.Text = "SDT : " + listNhanVien[tmp].SDT.ToString();
                M_L_HTLViec2.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[tmp].HinhThucLamViec);
                tmp -= 1;
                M_L_HoVaTen1.Text = "Họ và tên :" + listNhanVien[tmp].HoVaTen.ToString();
                M_L_ChucVu1.Text = "Chức vụ :" + listNhanVien[tmp].ChucVu.ToString();
                M_L_MaNhanVien1.Text = "Mã NV :" + listNhanVien[tmp].MaNhanVien.ToString();
                M_L_SDT1.Text = "SDT : " + listNhanVien[tmp].SDT.ToString();
                M_L_HTLViec1.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[tmp].HinhThucLamViec);
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
                M_L_HTLViec1.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[0].HinhThucLamViec);

                M_L_HoVaTen2.Text = "Họ và tên :" + listNhanVien[1].HoVaTen.ToString();
                M_L_ChucVu2.Text = "Chức vụ :" + listNhanVien[1].ChucVu.ToString();
                M_L_MaNhanVien2.Text = "Mã NV :" + listNhanVien[1].MaNhanVien.ToString();
                M_L_SDT2.Text = "SDT : " + listNhanVien[1].SDT.ToString();
                M_L_HTLViec2.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[1].HinhThucLamViec);

                M_L_HoVaTen3.Text = "Họ và tên :" + listNhanVien[2].HoVaTen.ToString();
                M_L_ChucVu3.Text = "Chức vụ :" + listNhanVien[2].ChucVu.ToString();
                M_L_MaNhanVien3.Text = "Mã NV :" + listNhanVien[2].MaNhanVien.ToString();
                M_L_SDT3.Text = "SDT : " + listNhanVien[2].SDT.ToString();
                M_L_HTLViec3.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[2].HinhThucLamViec);

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
                M_L_HTLViec3.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[tmp].HinhThucLamViec);
                tmp -= 1;
                M_L_HoVaTen2.Text = "Họ và tên :" + listNhanVien[tmp].HoVaTen.ToString();
                M_L_ChucVu2.Text = "Chức vụ :" + listNhanVien[tmp].ChucVu.ToString();
                M_L_MaNhanVien2.Text = "Mã NV :" + listNhanVien[tmp].MaNhanVien.ToString();
                M_L_SDT2.Text = "SDT : " + listNhanVien[tmp].SDT.ToString();
                M_L_HTLViec2.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[tmp].HinhThucLamViec);
                tmp -= 1;
                M_L_HoVaTen1.Text = "Họ và tên :" + listNhanVien[tmp].HoVaTen.ToString();
                M_L_ChucVu1.Text = "Chức vụ :" + listNhanVien[tmp].ChucVu.ToString();
                M_L_MaNhanVien1.Text = "Mã NV :" + listNhanVien[tmp].MaNhanVien.ToString();
                M_L_SDT1.Text = "SDT : " + listNhanVien[tmp].SDT.ToString();
                M_L_HTLViec1.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listNhanVien[tmp].HinhThucLamViec);
                B_Trai.Visible = true;
                B_Phai.Visible = true;
            }
        }

        private void LoadData(List<NhanVien> listDataNhanVien)
        {
            GB_1.Visible = GB_2.Visible = GB_3.Visible = true;
            
            // load thông tin nhân viên !
            //listNhanVien = listDataNhanVien;

            if (listDataNhanVien.Count > 0 & listDataNhanVien != null)
            {
                //MessageBox.Show("Đã có dữ liệu !");
                B_Trai.Visible = false;
                if (listDataNhanVien.Count >= 3)
                {
                    M_L_HoVaTen1.Text = "Họ và tên :" + listDataNhanVien[0].HoVaTen.ToString();
                    M_L_ChucVu1.Text = "Chức vụ :" + listDataNhanVien[0].ChucVu.ToString();
                    M_L_MaNhanVien1.Text = "Mã NV :" + listDataNhanVien[0].MaNhanVien.ToString();
                    M_L_SDT1.Text = "SDT : " + listDataNhanVien[0].SDT.ToString();
                    M_L_HTLViec1.Text = "Hình thức làm việc :" + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listDataNhanVien[0].HinhThucLamViec);

                    M_L_HoVaTen2.Text = "Họ và tên :" + listDataNhanVien[1].HoVaTen.ToString();
                    M_L_ChucVu2.Text = "Chức vụ :" + listDataNhanVien[1].ChucVu.ToString();
                    M_L_MaNhanVien2.Text = "Mã NV :" + listDataNhanVien[1].MaNhanVien.ToString();
                    M_L_SDT2.Text = "SDT : " + listDataNhanVien[1].SDT.ToString();
                    M_L_HTLViec2.Text = "Hình thức làm việc :" + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listDataNhanVien[1].HinhThucLamViec);

                    M_L_HoVaTen3.Text = "Họ và tên :" + listDataNhanVien[2].HoVaTen.ToString();
                    M_L_ChucVu3.Text = "Chức vụ :" + listDataNhanVien[2].ChucVu.ToString();
                    M_L_MaNhanVien3.Text = "Mã NV :" + listDataNhanVien[2].MaNhanVien.ToString();
                    M_L_SDT3.Text = "SDT : " + listDataNhanVien[2].SDT.ToString();
                    M_L_HTLViec3.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listDataNhanVien[2].HinhThucLamViec);

                }
                else if (listDataNhanVien.Count == 2)
                {
                    M_L_HoVaTen1.Text = "Họ và tên :" + listDataNhanVien[0].HoVaTen.ToString();
                    M_L_ChucVu1.Text = "Chức vụ :" + listDataNhanVien[0].ChucVu.ToString();
                    M_L_MaNhanVien1.Text = "Mã NV :" + listDataNhanVien[0].MaNhanVien.ToString();
                    M_L_SDT1.Text = "SDT : " + listDataNhanVien[0].SDT.ToString();
                    M_L_HTLViec1.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listDataNhanVien[0].HinhThucLamViec);

                    M_L_HoVaTen2.Text = "Họ và tên :" + listDataNhanVien[1].HoVaTen.ToString();
                    M_L_ChucVu2.Text = "Chức vụ :" + listDataNhanVien[1].ChucVu.ToString();
                    M_L_MaNhanVien2.Text = "Mã NV :" + listDataNhanVien[1].MaNhanVien.ToString();
                    M_L_SDT2.Text = "SDT : " + listDataNhanVien[1].SDT.ToString();
                    M_L_HTLViec2.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listDataNhanVien[1].HinhThucLamViec);
                }
                else if (listDataNhanVien.Count == 1)
                {
                    M_L_HoVaTen1.Text = "Họ và tên :" + listDataNhanVien[0].HoVaTen.ToString();
                    M_L_ChucVu1.Text = "Chức vụ :" + listDataNhanVien[0].ChucVu.ToString();
                    M_L_MaNhanVien1.Text = "Mã NV :" + listDataNhanVien[0].MaNhanVien.ToString();
                    M_L_SDT1.Text = "SDT : " + listDataNhanVien[0].SDT.ToString();
                    M_L_HTLViec1.Text = "Hình thức làm việc : " + BLL_ThongTinNhanVien.LoadingHinhThucLamViec(listDataNhanVien[0].HinhThucLamViec);
                }


                if (listDataNhanVien.Count <= 3)
                {
                    if (listDataNhanVien.Count == 0)
                    {
                        GB_1.Visible = false;
                        GB_2.Visible = false;
                        GB_3.Visible = false;
                    }
                    else if (listDataNhanVien.Count == 1)
                    {
                        GB_2.Visible = false;
                        GB_3.Visible = false;
                    }
                    else if (listDataNhanVien.Count == 2)
                    {
                        GB_3.Visible = false;
                    }
                    B_Trai.Visible = false;
                    B_Phai.Visible = false;
                    soTrang = 1;
                }
                else if (listDataNhanVien.Count > 3)
                {
                    if (listDataNhanVien.Count % 3 == 0)
                    {
                        soTrang = listDataNhanVien.Count / 3;
                    }
                    else
                    {
                        soTrang = listDataNhanVien.Count / 3 + 1;
                    }
                    B_Phai.Visible = true;
                }
                L_KetQua.Text = "Kết quả : " + listDataNhanVien.Count.ToString();

            }
        }

        private void M_B_TimKiem_Click(object sender, EventArgs e)
        {
            string chucVu, hinhThucLamViec;
            if (M_CB_ChucVu.SelectedIndex == 0)
            {
                chucVu = "";
            }
            else
            {
                chucVu = M_CB_ChucVu.Text;
            }
            if(M_CB_ThoiGianLam.SelectedIndex == 0)
            {
                hinhThucLamViec = "";
            }
            else
            {
                hinhThucLamViec = M_CB_ThoiGianLam.Text;
            }
            
            if (thongTinNhanVien.TimKiem(M_TB_MaNhanVien.Text , M_TB_HoVaTen.Text , chucVu , hinhThucLamViec , listNhanVien).Count == 0 )
            {
                    
                GB_1.Visible = false;
                GB_2.Visible = false;
                GB_3.Visible = false;
                L_KetQua.Text = "Kết quả : 0";
                return;
            }
            else
            {
                LoadData(thongTinNhanVien.TimKiem(M_TB_MaNhanVien.Text, M_TB_HoVaTen.Text, chucVu, hinhThucLamViec, listNhanVien));
                // L_KetQua.Text = "Kết quả : " + listNhanVien.Count.ToString();
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            LoadData(thongTinNhanVien.LoadingThongTinNhanVien());
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
