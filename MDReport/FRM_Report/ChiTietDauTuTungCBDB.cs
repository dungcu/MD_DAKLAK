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
    public partial class ChiTietDauTuTungCBDB : Form
    {
        public ChiTietDauTuTungCBDB()
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

            //load ComboBoxCBDB:
            try
            {
                DataSet dsCBDB = new DataSet();
                clsUser.GetList("", out dsCBDB, null, null);
                ComboBoxCBDB.DataSource = dsCBDB.Tables[0];
                ComboBoxCBDB.DisplayMember = "HoTen";
                ComboBoxCBDB.ValueMember = "ID";
                ComboBoxCBDB.SelectedValue = "Cán bộ địa bàn";

            }
            catch { }
            //load ComboBoxCBDB:
            
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            //In báo cáo   
            if (ComboBoxCBDB.SelectedIndex == -1)
            {
                labelLoi.Text = "Bạn phải chọn cán bộ địa bàn";
            }
            else
            {
                labelLoi.Text = "";
                Frm_ReportViewer frm = new Frm_ReportViewer();
                string[] paramNames = new string[] { "UserID","VuTrongID" };
                string[] paraValues = new string[] {  ComboBoxCBDB.SelectedValue.ToString(),ComboVuTrong.SelectedValue .ToString() };
                CommonClass.ShowReport("DauTu\\BieuTongHopCongNoDauTuChiTietTungCBDB.rpt", "", paramNames, paraValues, null);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

          
    }
}