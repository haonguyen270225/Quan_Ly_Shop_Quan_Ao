
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
namespace Store_Manager
{
    public partial class frm_ThayDoiMatKhau : Form
    {

        #region KhaiBao
        internal TaiKhoan taiKhoan = new TaiKhoan();
        #endregion
        public frm_ThayDoiMatKhau()
        {
            InitializeComponent();
        }

        private void lostButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_ThayDoiMatKhau_Load(object sender, EventArgs e)
        {
            TB_MatKhauCu.Focus();
            // Gán chung sự kiện KeyDown cho tất cả TextBox trên form
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.KeyDown += TextBox_KeyDown;  // Gán chung 1 hàm
                }
            }

            // Nếu TextBox nằm trong Panel/GroupBox, cần đệ quy
            GanSuKienEnterChoTatCaTextBox(this);
        }

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

            //        bool SelectNextControl(
            //    Control activeControl,   // Control hiện đang có focus
            //    bool forward,            // true: nhảy tới (tiếp theo), false: nhảy lùi (trước đó)
            //    bool tabStopOnly,        // true: chỉ nhảy đến control có TabStop = true
            //    bool nested,             // true: tìm cả trong các container con (Panel, GroupBox)
            //    bool wrap                // true: nếu đang ở control cuối cùng → quay về đầu tiên
            //);
    }
}
