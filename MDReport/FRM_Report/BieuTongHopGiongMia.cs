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
    public partial class BieuTongHopGiongMia : Form
    {
        public BieuTongHopGiongMia()
        {
            InitializeComponent();
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
                string[] paramNames = new string[] { "VuTrongID" };
                string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString() };
                CommonClass.ShowReport(uiComboBoxChonBC.SelectedValue.ToString(), "", paramNames, paraValues, null);
            }          
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BieuTongHopGiongMia_Load(object sender, EventArgs e)
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

        }

        private void uiComboBoxChonBC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbTitle_Click(object sender, EventArgs e)
        {

        }

       
    }
}