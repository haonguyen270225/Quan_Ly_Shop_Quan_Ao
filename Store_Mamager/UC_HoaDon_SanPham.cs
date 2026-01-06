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
    public partial class UC_HoaDon_SanPham : UserControl
    {
        public UC_HoaDon_SanPham(KhoHang khoHang)
        {
            InitializeComponent();

            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F); 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            LoadingDuLieu(khoHang);
        }


        private void LoadingDuLieu(KhoHang khoHang)
        {
            UC_L_ThongTinSanPham.Text = khoHang.TenHang + "\n Mã : " + khoHang.MaHang;
            UC_L_Gia.Text = khoHang.Gia + "đ";
            UC_GB_SanPham.Text = khoHang.ID.ToString();
            //Loading Hình ảnh !
        }


        void RoundPictureBox(PictureBox pb, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pb.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pb.Width - radius, pb.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pb.Height - radius, radius, radius, 90, 90);

            path.CloseFigure();
            pb.Region = new Region(path);
        } // Bp góc ảnh;

        //private void UC_HoaDon_SanPham_MouseEnter(object sender, EventArgs e)
        //{
            
        //    this.BackColor = Color.Gray;
           
        //    UC_PB_2.Padding = new Padding(30);
        //}

        //private void UC_HoaDon_SanPham_MouseLeave(object sender, EventArgs e)
        //{
        //    this.BackColor = Color.Transparent;
        //    UC_PB_2.Padding = new Padding(30);
        //}

        private void UC_HoaDon_SanPham_Load(object sender, EventArgs e)
        {
           
            this.Padding = new Padding(10);
          //  UC_PB_2.Padding = new Padding(30);
            RoundPictureBox(UC_PB_2, 20);
            this.Margin = new Padding(0);
            EnableHover(
                  UC_GB_SanPham,
                //  Color.FromArgb(230, 240, 255),
                Color.DarkGoldenrod,
                  Color.Transparent
             );
            EnableClick(UC_GB_SanPham , ( s , cv ) =>
            {
                MessageBox.Show("GroupBox clicked!");
            });
        }


        public void EnableHover(GroupBox gB, Color hoverColor, Color normalColor)
        {
            void enter(object s, EventArgs e) => gB.BackColor = hoverColor;
            void leave(object s, EventArgs e) => gB.BackColor = normalColor;
            gB.MouseEnter += enter; gB.MouseLeave += leave; 
            foreach (Control c in gB.Controls) { c.MouseEnter += enter; c.MouseLeave += leave; }

        }

        public void EnableClick(GroupBox gb, MouseEventHandler onDoubleClick)
        {
            gb.MouseDoubleClick += onDoubleClick;

            foreach (Control c in gb.Controls)
            {
                c.MouseDoubleClick += onDoubleClick;
            }
        }


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
    }
}
