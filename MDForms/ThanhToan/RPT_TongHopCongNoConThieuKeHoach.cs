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

namespace DACASUCO.MDForms.ThanhToan
{
    public partial class RPT_TongHopCongNoConThieuKeHoach : Form
    {
        public RPT_TongHopCongNoConThieuKeHoach()
        {
            InitializeComponent();
        }

        private void btnXemBC_Click(object sender, EventArgs e)
        {
            MDSolutionEntities.clsVuTrong oVT = new MDSolutionEntities.clsVuTrong(MDSolution.DACASUCO_App.VuTrongID);
            oVT.Load(null, null);
            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd") + " 00:00:00";
            string Den = dtDen.ToString("yyyy-MM-dd") + " 23:59:59";
            Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "@VuTrongID", "@TuNgay", "@DenNgay","NienVu" };
            string[] paraValues = new string[] { MDSolution.DACASUCO_App.VuTrongID.ToString(),Tu,Den,oVT.Ten };

            CommonClass.ShowReport("ThanhToan\\RPT_TongHopCongNo_HoThieuKeHoach.rpt", "Bảng tổng hợp Công nợ thiếu so với kế hoạch", paramNames, paraValues, null);
        }

        private void RPT_TongHopCongNoConThieuKeHoach_Load(object sender, EventArgs e)
        {
            dtTuNgay.Value = DateTime.Now.AddDays(-1);
            dtDenNgay.Value = DateTime.Now;
        }

    }
}
