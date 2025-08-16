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
    public partial class ChiTietDauTuTungTram : Form
    {
        public ChiTietDauTuTungTram()
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

            //load ComboBoxTranNongVu:
            try
            {
                DataSet dstram = new DataSet();
                clsTramNongVu.GetList("", out dstram, null, null);
                ComboBoxTranNongVu.DataSource = dstram.Tables[0];
                ComboBoxTranNongVu.DisplayMember = "Ten";
                ComboBoxTranNongVu.ValueMember = "ID";
                ComboBoxTranNongVu.SelectedValue = "Trạm nông vụ";

            }
            catch { }
            //load ComboBoxTranNongVu:
            
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            //In báo cáo   
            if (ComboBoxTranNongVu.SelectedIndex == -1)
            {
                labelLoi.Text = "Bạn phải chọn trạm nông vụ";
            }
            else
            {
                labelLoi.Text = "";
                Frm_ReportViewer frm = new Frm_ReportViewer();
                string[] paramNames = new string[] { "TramNongVuID","VuTrongID" };
                string[] paraValues = new string[] {  ComboBoxTranNongVu.SelectedValue.ToString(),ComboVuTrong.SelectedValue .ToString() };
                CommonClass.ShowReport("DauTu\\BieuTongHopCongNoDauTuChiTietTungTram.rpt", "", paramNames, paraValues, null);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

          
    }
}