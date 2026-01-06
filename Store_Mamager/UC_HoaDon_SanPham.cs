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

namespace Store_Manager
{
    public partial class UC_HoaDon_SanPham : UserControl
    {
        public UC_HoaDon_SanPham()
        {
            InitializeComponent();
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F); // hoặc giữ nguyên nhưng...
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
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

        private void UC_HoaDon_SanPham_MouseEnter(object sender, EventArgs e)
        {
            
            this.BackColor = Color.Gray;
            UC_Card_HienThi.Padding = new Padding(30);
            pictureBox2.Padding = new Padding(30);
        }

        private void UC_HoaDon_SanPham_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
            UC_Card_HienThi.Padding = new Padding(30);
            pictureBox2.Padding = new Padding(30);
        }

        private void UC_HoaDon_SanPham_Load(object sender, EventArgs e)
        {
            UC_Card_HienThi.Padding = new Padding(30);
            UC_Card_HienThi.BackColor = Color.DarkGray;
            this.Padding = new Padding(30);
            pictureBox2.Padding = new Padding(30);
            RoundPictureBox(pictureBox2, 20);
        }
    }
}
