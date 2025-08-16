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
    public partial class DoiChieuChuHopDong : Form
    {
        public DoiChieuChuHopDong()
        {
            InitializeComponent();
        }

        private void DoiChieuChuHopDong_Load(object sender, EventArgs e)
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
                MDSolutionEntities.clsNhapMia.GetListHopDong("", out ds1, null, null);
                ComboChuHopDong.DataSource = ds1.Tables[0];
                ComboChuHopDong.DisplayMember = "MaHopDong";
                ComboChuHopDong.ValueMember = "ID"; 

            }
            catch { }
            //load comboVutrong:
            
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            //In báo cáo   
            if (ComboCHD.SelectedIndex == -1)
            {
                //labelLoi.Text = "Bạn phải chọn báo cáo";
                MessageBox.Show("Bạn phải chọn báo cáo");
                ComboCHD.Focus();
            }
            else
            {
                labelLoi.Text = "";
                Frm_ReportViewer frm = new Frm_ReportViewer();
                string[] paramNames = new string[] { "@VuTrongID" ,"@HopDongID"};
                if (ComboChuHopDong.SelectedIndex == -1)
                {
                    MessageBox.Show("Bạn chưa chọn chủ hợp đồng");
                    ComboChuHopDong.Focus();

                }
                else
                {
                    string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString(), ComboChuHopDong.SelectedValue.ToString() };
                    CommonClass.ShowReport(ComboCHD.SelectedValue.ToString(), "", paramNames, paraValues, null);
                }
            }
          
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}