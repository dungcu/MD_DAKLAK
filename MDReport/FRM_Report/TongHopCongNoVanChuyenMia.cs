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
    public partial class TongHopCongNoVanChuyenMia : Form
    {
        public TongHopCongNoVanChuyenMia()
        {
            InitializeComponent();
        }

        private void TongHopDienTichHuyen_Load(object sender, EventArgs e)
        {
            //load comboVutrong:
            try
            {
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery("Select ID,Ten from tbl_VuTrong Where IsActive=1 order by ID", null, null);
                
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
                DateTime dtTu = dtTuNgay.Value;
                DateTime dtDen = dtDenNgay.Value;
                string Tu = dtTu.ToString("yyyy-MM-dd") + " 00:00:00";
                string Den = dtDen.ToString("yyyy-MM-dd") + " 23:59:59";
                Frm_ReportViewer frm = new Frm_ReportViewer();
                string[] paraNames = new string[] { "@VuTrongID", "@TuNgay", "@DenNgay" };
                string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString(),Tu, Den };
                CommonClass.ShowReport("VanChuyen\\BieuTongHopCongNoVanChuyenMia.rpt", "", paraNames, paraValues, null);
            }
          
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}