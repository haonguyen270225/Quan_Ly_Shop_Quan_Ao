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
using System.Web.UI.Design;
namespace Store_Manager
{
    public partial class frm_ThongTinKhachHang : Form
    {
        public frm_ThongTinKhachHang()
        {
            InitializeComponent();
        }

        #region KhaiBao
        //BLL_LoadingKhachHang bll_LoadingKhachHang = new BLL_LoadingKhachHang();
        //List<KhachHang> listKhachHang = new List<KhachHang>();
        KhachHang khachHang = new KhachHang();

        #endregion
        private void frm_ThongTinKhachHang_Load(object sender, EventArgs e)
        {
            GanSuKienEnterChoTatCaTextBox(this);
        }

        #region Bat su kien Enter TexBox
        private void GanSuKienEnterChoTatCaTextBox(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.KeyDown += TextBox_KeyDown;
                }

                if (ctrl.HasChildren) // Nếu là Panel/GroupBox...
                {
                    GanSuKienEnterChoTatCaTextBox(ctrl);
                }
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //   e.Handled = true;    // Ngăn tiếng "ding" khi nhấn Enter
                e.SuppressKeyPress = true;

                // Chuyển focus sang control tiếp theo theo TabIndex
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        #endregion

        private void B_Luu_Click(object sender, EventArgs e)
        {
            khachHang.HoVaTen = TB_HoVaTen.Text.Trim();
            khachHang.SDT = TB_HoVaTen.Text.Trim();
            khachHang.MaKhachHang = TB_MaKhachHang.Text.Trim();
            if (khachHang.HoVaTen.Length == 0 || khachHang.SDT.Length == 0 || khachHang.MaKhachHang.Length == 0)
            {
                MessageBox.Show("TexBox không được để trống !");
                return;
            }
            if (XuLy_Chuoi.KiemTra_HoVaTen(khachHang.HoVaTen) == true && XuLy_Chuoi.KiemTra_Ma(khachHang.MaKhachHang) == true && XuLy_Chuoi.KiemTra_STD(khachHang.SDT) == true)
            {
                MessageBox.Show("Hợp lê !");
                return;
            }
            else
            {
                if (XuLy_Chuoi.KiemTra_Ma(khachHang.MaKhachHang) == false)
                {
                    MessageBox.Show("Mã khách hàng  không được các ký tự đặc biệt và khoản trắng !");
                    return;
                }
                else if (XuLy_Chuoi.KiemTra_HoVaTen(khachHang.HoVaTen) == false)
                {
                    MessageBox.Show("Họ và Tên không được chứa số và các ký tự đặc biệt !");
                    return;
                }
                else if (XuLy_Chuoi.KiemTra_STD(khachHang.SDT) == false)
                {
                    MessageBox.Show("SDT phải là chữ số và không chứa khoản trắng !");
                    return;
                }
            }
        }
    }
}
