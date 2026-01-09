using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
namespace Store_Manager
{
    public partial class UC_ChiTietSanPham : UserControl
    {
        #region KhaiBao
        public int soLuong { get; private set; } = 1;
        public double tongThu_ChiTietSanPham { get; private set; }
        private static int sTT = 1;
       // public static double tongThu { get; private set; } = 0;
        public KhoHang chiTietSanPham { get; private set; }

        public event Action<UC_ChiTietSanPham> Xoa;

        #endregion

        public UC_ChiTietSanPham(KhoHang sanPham)
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            dataChiTietSanPham(sanPham);
            this.chiTietSanPham = sanPham;
        }

       
        private void dataChiTietSanPham(KhoHang sanPham)
        {
            ChiTietSanPham_L_TenHang.Text = sanPham.TenHang.ToString();
            ChiTietSanPham_L_Gia.Text = sanPham.Gia.ToString("N0");
            ChiTietSanPham_L_ThanhTien.Text = sanPham.Gia.ToString("N0");
            ChiTietSanPham_SoLuong.Text = soLuong.ToString();
            tongThu_ChiTietSanPham = Convert.ToDouble(ChiTietSanPham_L_ThanhTien.Text.ToString());
        } 

        public void TangSoLuong()
        {
            this.soLuong += 1;
            ChiTietSanPham_SoLuong.Text = soLuong.ToString();
            ChiTietSanPham_L_ThanhTien.Text = (soLuong * chiTietSanPham.Gia).ToString("N0");
            tongThu_ChiTietSanPham = Convert.ToDouble(ChiTietSanPham_L_ThanhTien.Text.ToString());
        }

        #region GiaoDien
        private void UC_HoaDon_ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            EnableHover(
                  pn: HoaDon_ChiTietHoaDon_P,
                //  Color.FromArgb(230, 240, 255),
                Color.OliveDrab,
                Color.FromArgb(63, 63, 70)
             );
            EnableClick(HoaDon_ChiTietHoaDon_P, (s, cv) =>
            {
                //if(HoaDon_ChiTietHoaDon_CB_STT.Checked  == false)
                //{
                //    HoaDon_ChiTietHoaDon_CB_STT.Checked = true;
                //    HoaDon_ChiTietHoaDon_P.BackColor = Color.OliveDrab;
                //}
                //else
                //{
                //    HoaDon_ChiTietHoaDon_CB_STT.Checked = false;
                //    HoaDon_ChiTietHoaDon_P.BackColor = Color.FromArgb(63, 63, 70);
                //}
            });
        }

        public void EnableClick(Control pn, MouseEventHandler onDoubleClick)
        {
            pn.MouseDoubleClick += onDoubleClick;

            foreach (Control c in pn.Controls)
            {
                c.MouseDoubleClick += onDoubleClick;
            }
        }

        
        public void EnableHover(Control pn, Color hoverColor, Color normalColor)
        {
            void enter(object s, EventArgs e) => pn.BackColor = hoverColor;
            void leave(object s, EventArgs e) => pn.BackColor = normalColor;
            pn.MouseEnter += enter; pn.MouseLeave += leave;
            foreach (Control c in pn.Controls) { c.MouseEnter += enter; c.MouseLeave += leave; }
        }
        #endregion
        private void HoaDon_ChiTietHoaDon_B_Xoa_Click(object sender, EventArgs e)
        {
           tongThu_ChiTietSanPham -= Convert.ToDouble(ChiTietSanPham_L_ThanhTien.Text.ToString());
           Xoa?.Invoke(this);
        }

    }
}



#region demo
//private void HoaDon_ChiTietHoaDon_B_Xoa_Click(object sender, EventArgs e)
//{
//    FlowLayoutPanel fLP = this.Parent as FlowLayoutPanel;
//    fLP.Controls.Remove(this);
//    this.Dispose(); // Giải Phóng Tài Nguyên;
//}

#endregion
