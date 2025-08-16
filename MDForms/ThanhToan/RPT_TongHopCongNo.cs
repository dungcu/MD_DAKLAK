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
    public partial class RPT_TongHopCongNo : Form
    {
        public RPT_TongHopCongNo()
        {
            InitializeComponent();
        }

        private void btnXemBC_Click(object sender, EventArgs e)
        {
            Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "VuTrongID", "TuNgay", "DenNgay" };
            string[] paraValues = new string[] { MDSolution.DACASUCO_App.VuTrongID.ToString(), dtTuNgay.IsNullDate ? "1/1/1990" : dtTuNgay.Value.ToString("MM/dd/yyyy") + " 00:00:01", dtDenNgay.IsNullDate ? "1/1/1990" : dtDenNgay.Value.ToString("MM/dd/yyyy") + " 23:59:59" };

            CommonClass.ShowReport("ThanhToan\\RPT_TongHopCongNo.rpt", "Bảng tổng hợp thanh tóan tiền mía", paramNames, paraValues, null);
        }
    }
}
