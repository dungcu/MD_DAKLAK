using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using MDSolution;

namespace DACASUCO.MDReport.FRM_Report
{
    public partial class TongHopDauTuTheoDMDT : Form
    {
        public TongHopDauTuTheoDMDT()
        {
            InitializeComponent();
        }

        private void TongHopDienTichHuyen_Load(object sender, EventArgs e)
        {
            //load comboVutrong:
            try
            {
                DataSet ds = new DataSet();
                clsVuTrong.GetList("", out ds, null, null);
                ComboVuTrong.DataSource = ds.Tables[0];
                ComboVuTrong.DisplayMember = "Ten";
                ComboVuTrong.ValueMember = "ID";
                ComboVuTrong.SelectedValue = MDSolutionEntitiesStatic.VuTrongID;

            }
            catch { }
            //load comboVutrong:            
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            //In báo cáo   
            if (ComboVuTrong.SelectedIndex == -1)
            {
                labelLoi.Text = "Bạn chưa chọn vụ trồng";
            }
            else
            {
                labelLoi.Text = "";
                Frm_ReportViewer frm = new Frm_ReportViewer();
                string[] paramNames = new string[] { "VuTrongID" };
                string[] paraValues = new string[] {  ComboVuTrong.SelectedValue .ToString() };
                CommonClass.ShowReport("DauTu\\BieuTongHopCongNoDauTuTheoDanhMucDauTu.rpt", "", paramNames, paraValues, null);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboVuTrong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

          
    }
}