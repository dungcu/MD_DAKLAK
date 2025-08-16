using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDReport.FRM_Report
{
    public partial class TruNoCacDonViGianTiep : Form
    {
        public TruNoCacDonViGianTiep()
        {
            InitializeComponent();
        }

        private void TruNoCacDonViGianTiep_Load(object sender, EventArgs e)
        {
            //load comboVutrong:
            try
            {
                DataSet ds = new DataSet();
                clsVuTrong.GetList("", out ds, null, null);
                ComboVuTrong.DataSource = ds.Tables[0];
                ComboVuTrong.DisplayMember = "Ten";
                ComboVuTrong.ValueMember = "ID";
                ComboVuTrong.SelectedValue = MDSolutionApp.VuTrongID;


                DataSet ds2 = new DataSet();
                clsThanhToanMia.GetListDotThanhToan("", out ds2, null, null);
                ComboDotThanhToan.DataSource = ds2.Tables[0];
                ComboDotThanhToan.DisplayMember = "DotThanhToan";
                ComboDotThanhToan.ValueMember = "DotThanhToan";

                DataSet ds1 = new DataSet();
                clsDauTu.GetListDonVi("",out ds1, null, null);
                ComboDonVi.DataSource= ds1.Tables[0];
                ComboDonVi.DisplayMember = "ten";
                ComboDonVi.ValueMember = "id";
                

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
            MDReport.Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "@VuTrongID", "@DotThanhToan", "@DonViCungUngVatTu" };
            string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString(),ComboDotThanhToan.SelectedValue.ToString(),ComboDonVi.SelectedValue.ToString() 

            };
            CommonClass.ShowReport(uiComboBoxChonBC.SelectedValue.ToString(), "", paramNames, paraValues, null);
            }
          
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}