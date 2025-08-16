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
    public partial class RPT_BangTongHopThuBangTM : Form
    {
        public RPT_BangTongHopThuBangTM()
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
            string[] paramNames = new string[] {"TramID","VuTrongID" ,"TuNgay","DenNgay" };
            string[] paraValues = new string[] { cboTram.SelectedIndex < 0 ? "-1" : cboTram.SelectedValue.ToString(), MDSolution.DACASUCO_App.VuTrongID.ToString(),Tu,Den};
            if (chkTongHopTram.Checked)
            {
                CommonClass.ShowReport("ThanhToan\\RPT_BangTongHopThuBangTM_Tram.rpt", "Bảng tổng hợp thu bằng TM", paramNames, paraValues, null);
            }
            else
                CommonClass.ShowReport("ThanhToan\\RPT_BangTongHopThuBangTM.rpt", "Bảng tổng hợp thu bằng TM", paramNames, paraValues, null);
            
        }

        private void RPT_BangTongHopThuBangTM_Load(object sender, EventArgs e)
        {
            DataSet dstram = new DataSet();
            clsTramNongVu.GetList("", out dstram, null, null);
            cboTram.DataSource = dstram.Tables[0];
            cboTram.DisplayMember = "Ten";
            cboTram.ValueMember = "ID";
            cboTram.SelectedIndex = -1;

        }

        private void chkTongHopTram_CheckedChanged(object sender, EventArgs e)
        {

            if (chkTongHopTram.Checked)
            {
                cboTram.SelectedIndex = -1;
                cboTram.Enabled = false;
            }
            else
                cboTram.Enabled = true;
        }

       

    }
}
