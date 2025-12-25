using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Mamager
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            //InitializeComponent();
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme
            (
            Primary.Blue700,     // Thanh tiêu đề
            Primary.Blue900,     // Thanh trên khi focus
            Primary.Blue500,     // Màu phụ
            Accent.LightBlue200, // Accent (button, checkbox)
            TextShade.WHITE      // Màu chữ
            );

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Heello ");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
