using BLL;
using DTO;
using Microsoft.Reporting.WinForms;
using Store_Manager.Quan_Ly_Shop_Quan_AoDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Store_Manager
{
    public partial class BaoCao : Form
    {
        BLL_KhachHang bll_KhachHang = new BLL_KhachHang();
        List<KhachHang> listKhachHang = new List<KhachHang>();
        public BaoCao()
        {
            InitializeComponent();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {

           listKhachHang = bll_KhachHang.LoadingKhachHang();
           reportViewer1.LocalReport.ReportPath = @"Report1.rdlc";

            ReportDataSource rds = new ReportDataSource("KhachHangSet", listKhachHang);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }
    }
}
