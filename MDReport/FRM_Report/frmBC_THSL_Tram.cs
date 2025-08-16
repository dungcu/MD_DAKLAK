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
    public partial class frmBC_THSL_Tram : Form
    {
        public frmBC_THSL_Tram()
        {
            InitializeComponent();
        }

        private void frmBC_THSL_Tram_Load(object sender, EventArgs e)
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
                clsVuTrong oVT = new clsVuTrong(long.Parse(ComboVuTrong.SelectedValue.ToString()));
                oVT.Load(null, null);
                DateTime dtTu = dtTuNgay.Value;
                DateTime dtDen = dtDenNgay.Value;
                string Tu = dtTu.ToString("yyyy-MM-dd") + " 00:00:00";
                string Den = dtDen.ToString("yyyy-MM-dd") + " 23:59:59";
                string SQL = "Select AVG(Isnull(TyLeTapVat,0)) as TCBQ, AVG(Isnull(CCS,0)) as CCSBQ from View_KetQuaCanNhapMiaNguyenLieuXe Where NgayVanChuyen>='" + Tu + "' And NgayVanChuyen<'" + Den + "' And VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(SQL, null, null);
                double TCBQ = 0;

                try
                {
                    TCBQ = Math.Round(double.Parse(ds.Tables[0].Rows[0]["TCBQ"].ToString()), 2);
                }
                catch
                {
                    TCBQ = 0;
                }
                double CCSBQ = 0;
                try
                {
                    CCSBQ = Math.Round(double.Parse(ds.Tables[0].Rows[0]["CCSBQ"].ToString()), 2);
                }
                catch
                {
                    CCSBQ = 0;
                }
                Frm_ReportViewer frm = new Frm_ReportViewer();
                string[] paraNames = new string[] { "@VuTrongID", "@TuNgay", "@DenNgay","NienVu","TCBQ","CCSBQ"};
                string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString(),Tu, Den,oVT.Ten,TCBQ.ToString(),CCSBQ.ToString()};
                CommonClass.ShowReport("RPDakNong\\RPT_BCSL_Tram.rpt", "", paraNames, paraValues, null);
            }
          
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}