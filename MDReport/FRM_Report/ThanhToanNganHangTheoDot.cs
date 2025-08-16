using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDReport.FRM_Report
{
    public partial class ThanhToanNganHangTheoDot : Form
    {
        public ThanhToanNganHangTheoDot()
        {
            InitializeComponent();
        }

        private void ThanhToanNganHangTheoDot_Load(object sender, EventArgs e)
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

                DataSet ds1 = new DataSet();
                clsThanhToanMia.GetListDotThanhToan("", out ds1, null, null);
                ComboDotDauTu.DataSource = ds1.Tables[0];
                ComboDotDauTu.DisplayMember = "DotThanhToan";
                ComboDotDauTu.ValueMember = "DotThanhToan";


                DataSet ds2 = new DataSet();
                clsCum.GetListNganHang("", out ds2, null, null);
                ComboNganHang.DataSource = ds2.Tables[0];
                ComboNganHang.DisplayMember = "Ten";
                ComboNganHang.ValueMember = "ID";

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
            string[] paramNames = new string[] { "@VuTrongID", "@DotThanhToan", "@NganHangID" };
            string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString(), ComboDotDauTu.SelectedValue.ToString(), ComboNganHang.SelectedValue.ToString() };
            CommonClass.ShowReport(uiComboBoxChonBC.SelectedValue.ToString(), "", paramNames, paraValues, null);
            }
          
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}