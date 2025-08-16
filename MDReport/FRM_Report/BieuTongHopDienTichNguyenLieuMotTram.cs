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
    public partial class BieuTongHopDienTichNguyenLieuMotTram : Form
    {
        public BieuTongHopDienTichNguyenLieuMotTram()
        {
            InitializeComponent();
        }

        private void BieuTongHopDienTichNguyenLieuMotTram_Load(object sender, EventArgs e)
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

                DataSet ds1 = new DataSet();
                clsCum.GetList("", out ds1, null, null);
                //clsGiongMia.GetList("", out ds1, null, null);                
                ComboTram.DataSource = ds1.Tables[0];
                ComboTram.DisplayMember = "Ten";
                ComboTram.ValueMember = "ID"; 

            }
            catch { }
            //load comboVutrong:
            
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            //In báo cáo   
            if (uiComboBoxChonBC.SelectedIndex == -1)
            {
                labelLoi.Text = "Bạn phải chọn báo cáo";
            }
            else
            {
                labelLoi.Text = "";
            Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "@VuTrongID", "@BienTramID" };
            string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString(), ComboTram.SelectedValue.ToString() };
            CommonClass.ShowReport(uiComboBoxChonBC.SelectedValue.ToString(), "", paramNames, paraValues, null);
            }
          
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}