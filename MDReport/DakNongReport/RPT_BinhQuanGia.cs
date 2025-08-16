using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using MDSolution;
namespace DACASUCO.MDReport.DakNongReport
{
    public partial class RPT_BinhQuanGia : Form
    {
        public RPT_BinhQuanGia()
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

            CommonClass.ShowReport("RPDakNong\\RPT_BinhQuanGia.rpt", "Bảng tổng hợp giá mía, giá vận chuyển bình quân", paramNames, paraValues, null);
        }

        private void RPT_BinhQuanGia_Load(object sender, EventArgs e)
        {
            dtTuNgay.Value = DateTime.Now.AddDays(-1);
            dtDenNgay.Value = DateTime.Now;
        }

        
    }
}
