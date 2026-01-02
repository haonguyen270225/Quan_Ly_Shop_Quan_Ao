using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Manager;

namespace Store_Manager
{
    public partial class frm_TrangChu02 : Form
    {
        public frm_TrangChu02()
        {
            InitializeComponent();

        }

        private void frm_TrangChu02_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; // phóng to form;
        }

        private void airTabPage1_Selected(object sender, TabControlEventArgs e)
        {
            if(airTabPage1.SelectedTab == tab_DangXuat)
            {
                this.Close();
            }
        }
    }
}


