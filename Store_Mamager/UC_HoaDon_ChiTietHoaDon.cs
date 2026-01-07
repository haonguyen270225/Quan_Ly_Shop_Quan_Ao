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
namespace Store_Manager
{
    public partial class UC_HoaDon_ChiTietHoaDon : UserControl
    {
        public UC_HoaDon_ChiTietHoaDon()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        }

        #region KhaiBao
        public static int dem = 0;
        public List<KhoHang> listSanPham = new List<KhoHang>();
        #endregion

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
                MessageBox.Show("GroupBox clicked!"); // khi double Clic chuột;
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


    }
}
