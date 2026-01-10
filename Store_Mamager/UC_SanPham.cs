using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using DTO;
namespace Store_Manager
{
    public partial class UC_SanPham : UserControl
    {
        #region KhaiBao
        public event EventHandler<KhoHang> OnAddToHoaDon;
        public KhoHang sanPham { get; private set; }
        #endregion
        public UC_SanPham(KhoHang khoHang , int sTT)
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F); 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.sanPham = khoHang;
            LoadingDuLieu(khoHang , sTT);
        }

        private void LoadingDuLieu(KhoHang khoHang , int sTT)
        {
            SanPham_L.Text = khoHang.TenHang + "\n Mã : " + khoHang.MaHang;
            SanPham_L_Gia.Text = khoHang.Gia.ToString("N0") + "đ";
            SanPham_GB.Text = sTT.ToString();
        }

        private void UC_HoaDon_SanPham_Load(object sender, EventArgs e)
        {
           
            this.Padding = new Padding(10);
            this.Margin = new Padding(0);
            EnableHover(
                  SanPham_GB,
                Color.DarkGoldenrod,
                Color.Transparent
             );

            EnableDoubleClick(SanPham_GB, (s, cv) =>
            {
                GroupBox gb = (GroupBox)s;
                //MessageBox.Show("Double click sản phẩm");
                OnAddToHoaDon?.Invoke(this, sanPham);
            });
        }


        public void EnableHover(GroupBox gB, Color hoverColor, Color normalColor)
        {
            void enter(object s, EventArgs e) => gB.BackColor = hoverColor;
            void leave(object s, EventArgs e) => gB.BackColor = normalColor;
            gB.MouseEnter += enter; gB.MouseLeave += leave; 
            foreach (Control c in gB.Controls) { c.MouseEnter += enter; c.MouseLeave += leave; }

        }


        public void EnableDoubleClick(GroupBox gb, MouseEventHandler onDoubleClick)
        {
            void dbl(object s, MouseEventArgs e)
            {
                onDoubleClick?.Invoke(gb, e);
            }

            gb.MouseDoubleClick += dbl;

            foreach (Control c in gb.Controls)
            {
                c.MouseDoubleClick += dbl;
            }
        }

        #region demo

        //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;

        //public void EnableDoubleClickOnly(GroupBox gb, MouseEventHandler onDoubleClick)
        //{
        //    // Chỉ gán DoubleClick cho GroupBox
        //    gb.MouseDoubleClick += onDoubleClick;

        //    // Nếu bạn KHÔNG muốn DoubleClick trên control con (chỉ GroupBox thôi)
        //    // → Vô hiệu hóa DoubleClick của tất cả control con
        //    foreach (Control c in gb.Controls)
        //    {
        //        c.MouseDoubleClick += (sender, e) => { /* Không làm gì */ };
        //        // Hoặc nếu muốn chặn hoàn toàn:
        //        // c.MouseDoubleClick += (sender, e) => e.Handled = true;
        //    }
        //}

        //public void EnableClick(GroupBox gb, MouseEventHandler onDoubleClick)
        //{
        //    gb.MouseDoubleClick += onDoubleClick;

        //    foreach (Control c in gb.Controls)
        //    {
        //        c.MouseDoubleClick += onDoubleClick;
        //    }
        //}
        #endregion

        private void UC_PB_2_Click(object sender, EventArgs e)
        {

        }
    }
}
