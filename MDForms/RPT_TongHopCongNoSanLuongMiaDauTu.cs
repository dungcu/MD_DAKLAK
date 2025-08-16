using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using DACASUCO.MDReport;
using MDSolution;

namespace DACASUCO.MDForms
{
    public partial class RPT_TongHopCongNoSanLuongMiaDauTu : Form
    {
        public RPT_TongHopCongNoSanLuongMiaDauTu()
        {
            InitializeComponent();
        }

        private void btnXemBC_Click(object sender, EventArgs e)
        {

            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd") + " 00:00:00";
            string Den = dtDen.ToString("yyyy-MM-dd") + " 23:59:59";
            Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "@VuTrongID", "@TuNgay", "@DenNgay" };
            string[] paraValues = new string[] { MDSolution.DACASUCO_App.VuTrongID.ToString(),Tu,Den };
            CommonClass.ShowReport("RPDakNong\\RPT_TongHopCongNoSanLuongMiaDauTu.rpt", "Bảng tổng hợp công nợ, sản lượng mía đầu tư", paramNames, paraValues, null);
          
        }

        private void RPT_TongHopCongNoSanLuongMiaDauTu_Load(object sender, EventArgs e)
        {
            dtTuNgay.Value = DateTime.Now.AddDays(-1);
            dtDenNgay.Value = DateTime.Now;
        }
    }
}
