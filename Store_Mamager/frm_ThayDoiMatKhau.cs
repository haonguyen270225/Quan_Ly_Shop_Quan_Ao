
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
using System.Security.Cryptography;
namespace Store_Manager
{
    public partial class frm_ThayDoiMatKhau : Form
    {

        #region KhaiBao
        public static TaiKhoan taiKhoan = frm_TrangChu.taiKhoan;
        private BLL_TaiKhoan bll_TaiKhoan = new BLL_TaiKhoan();

        public event Action DaDongVaCapNhatMatKhau;
        #endregion
        public frm_ThayDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frm_ThayDoiMatKhau_Load(object sender, EventArgs e)
        {
            MessageBox.Show(taiKhoan.ID.ToString() + "   " + taiKhoan.IDNhanVien.ToString());
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



        private void B_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_Luu_Click(object sender, EventArgs e)
        {
            if(TB_MatKhauCu.Text == taiKhoan.PassWord)
            {
                if(TB_MatKhauCu.Text == "" || TB_MatKhauMoi.Text == "" || TB_NhapLaiMatKhauMoi.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                }
                else
                {
                    if(TB_MatKhauMoi.Text != TB_NhapLaiMatKhauMoi.Text)
                    {
                        MessageBox.Show("Mật khẩu mới khác Nhập lại mật khẩu !");
                    }
                    else
                    {
                        int kq = bll_TaiKhoan.ThayDoiMatKhau(taiKhoan, TB_MatKhauMoi.Text.ToString());
                        if(kq == -1)
                        {
                            MessageBox.Show("Mật khẩu tối thiểu 10 ký tự");
                        }
                        else if(kq == -2)
                        {
                            MessageBox.Show("Mật khẩu tối đa 30 ký tự !");
                        }
                        else if(kq == 0)
                        {
                            MessageBox.Show("Lỗi cơ sỡ dữ liệu !");
                        }
                        else if(kq == 1)
                        {
                            frm_TrangChu.taiKhoan.PassWord = TB_MatKhauMoi.Text.ToString();
                            frm_DangNhapReaLTaiizor.taiKhoan.PassWord = TB_MatKhauMoi.Text.ToString();
                            MessageBox.Show(" Đã cập nhập mật khẩu mới :" + TB_MatKhauMoi.Text.ToString());
                            DaDongVaCapNhatMatKhau?.Invoke(); // sự kiện frm_TrangChu; GỌI (kích hoạt) tất cả các hàm đã đăng ký vào event
                                                              // ? < = > if (DaDongVaCapNhat != null)
                                                              //{
                                                              //    DaDongVaCapNhat.Invoke();
                                                              //} -> tránh lỗi NullReferenceException
                            this.Close();
                            
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng !");
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
