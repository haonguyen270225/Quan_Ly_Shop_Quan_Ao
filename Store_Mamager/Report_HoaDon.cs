using BLL;
using DTO;
using Microsoft.Reporting.WinForms;
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
    public partial class Report_HoaDon : Form
    {
        BLL_HoaDon bll_HoaDon = new BLL_HoaDon();
        List<HoaDon> listHoaDon = new List<HoaDon>();

        public Report_HoaDon()
        {
            InitializeComponent();
        }

        private void Preport_HoaDon_Load(object sender, EventArgs e)
        {
            listHoaDon = bll_HoaDon.LoadingHoaDon();
            reportViewer1.LocalReport.ReportPath = @"R_HoaDon.rdlc";

            ReportDataSource rds = new ReportDataSource("tb_HoaDon", listHoaDon);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
            //this.reportViewer2.RefreshReport();
        }
    }
}
