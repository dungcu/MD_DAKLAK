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
    public partial class BieuTongHopVanChuyenCHDVC : Form
    {
        public BieuTongHopVanChuyenCHDVC()
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
                ComboVuTrong.Items.Clear();
                ComboVuTrong.DataSource = ds.Tables[0];
                ComboVuTrong.DisplayMember = "Ten";
                ComboVuTrong.ValueMember = "ID";
                
                // giong mia

                DataSet ds1 = new DataSet();
                clsHopDongVanChuyen.GetList("", out ds1, null, null);    
                //clsGiongMia.GetList("", out ds1, null, null);                
                ComboChuHopDong.DataSource = ds1.Tables[0];
                ComboChuHopDong.DisplayMember = "TenChuHopDong";
                ComboChuHopDong.ValueMember = "ID";                
                //ComboVuTrong.SelectedValue = MDSolutionEntitiesStatic.VuTrongID;
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
            string[] paraNames = new string[] { "@VuTrongID", "@ChuHDVCID" };
            string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString(), ComboChuHopDong.SelectedValue.ToString() };
            CommonClass.ShowReport(uiComboBoxChonBC.SelectedValue.ToString(), "", paraNames, paraValues, null);
            }
          
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}