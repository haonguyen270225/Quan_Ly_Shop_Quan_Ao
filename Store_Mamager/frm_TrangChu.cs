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
        }

        
        private void foreverForm1_Click(object sender, EventArgs e)
        {

        }

        private void tab_DangXuat_Click(object sender, EventArgs e)
        {
            
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

        private void bigLabel3_Click(object sender, EventArgs e)
        {

        }

        private void foreverGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void foreverGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void frm_TrangChu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quan_Ly_Shop_Quan_AoDataSet.HoaDon' table. You can move, or remove it, as needed.
            this.hoaDonTableAdapter.Fill(this.quan_Ly_Shop_Quan_AoDataSet.HoaDon);

        }
    }
}
