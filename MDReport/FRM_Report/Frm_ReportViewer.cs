using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using MDSolution;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.SCREventLog;
using CrystalDecisions.Shared;
namespace MDSolution
{
    public partial class Frm_ReportViewer : Form
    {
        //Test time execute:
        DateTime dts, dte;

        static public string strReportDir = Application.StartupPath + "\\Reports\\";
        public bool bHasPara;
        public string [] ParaNames;
        public object[] ParaValues;
        int ZoomLever = 100;
        public string rptFileName;
        public string rptTitle;
        ReportDocument rpt = new ReportDocument();
        /// <summary>
        /// Lấy thông tin logon vào database
        /// </summary>
        public TableLogOnInfo tblogon;
        public Frm_ReportViewer()
        {
            #region set auto logon:
            ConnectionInfo ci = new ConnectionInfo();
            ci.ServerName = MDSolutionEntities.DBModule.ServerName;
            ci.UserID = MDSolutionEntities.DBModule.UserID;
            ci.Password = MDSolutionEntities.DBModule.Password;
            ci.DatabaseName = MDSolutionEntities.DBModule.DatabaseName;
            TableLogOnInfo ti = new TableLogOnInfo();
            ti.ConnectionInfo = ci;
            tblogon = ti;
            #endregion
            InitializeComponent();
        }

        private void Frm_ReportViewer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Text = "Vui lòng chờ...";
            loadreport();

        }
        public void loadreport()
        {
            dts = DateTime.Now;
            int i;
            this.Refresh();
            rpt.FileName = strReportDir + rptFileName;
            rpt.Load(strReportDir + rptFileName);
            TableLogOnInfo crTableLogOnInfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();

            crConnectionInfo.ServerName = MDSolutionEntities.DBModule.ServerName;
            crConnectionInfo.DatabaseName = MDSolutionEntities.DBModule.DatabaseName;
            crConnectionInfo.UserID = MDSolutionEntities.DBModule.UserID;
            crConnectionInfo.Password = MDSolutionEntities.DBModule.Password;
            crTableLogOnInfo.ConnectionInfo = crConnectionInfo;

            rpt.SetDatabaseLogon(MDSolutionEntities.DBModule.UserID, MDSolutionEntities.DBModule.Password, MDSolutionEntities.DBModule.ServerName, MDSolutionEntities.DBModule.DatabaseName);
            rpt.Refresh();
            foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in rpt.Database.Tables)
            {
                crTableLogOnInfo = crTable.LogOnInfo;
                crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
                crTable.ApplyLogOnInfo(crTableLogOnInfo);
                crTable.Location = crTable.Location.Substring(crTable.Location.LastIndexOf(".") + 1);
            }

            for (i = 0; i < rpt.Subreports.Count; i++)
            {
                foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in rpt.Subreports[i].Database.Tables)
                {
                    crTableLogOnInfo = crTable.LogOnInfo;
                    crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
                    crTable.ApplyLogOnInfo(crTableLogOnInfo);
                    crTable.Location = crTable.Location.Substring(crTable.Location.LastIndexOf(".") + 1);

                }
                rpt.Subreports[i].SetDatabaseLogon(MDSolutionEntities.DBModule.UserID, MDSolutionEntities.DBModule.Password, MDSolutionEntities.DBModule.ServerName, MDSolutionEntities.DBModule.DatabaseName);
            }


            if (bHasPara == true)
            {
                for (i = 0; i < ParaNames.Length; i++)
                {
                    try
                    {
                        rpt.SetParameterValue(ParaNames[i], ParaValues[i]);
                    }
                    catch { }
                }
            }
            try//Kiem tra du lieu báo cáo
            {
                string s_ = rpt.Rows[0].ToString();
            }
            catch
            {
                MessageBox.Show("Báo cáo không có dư liệu", "Thông báo");
                //return;
            }

            if (rptTitle == null || rptTitle.Trim() == "")
            {
                this.Text = "Báo cáo ";
            }
            else
            {
                this.Text = rptTitle;
            }
            
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            crystalReportViewer1.Zoom(ZoomLever);
            //this.Refresh();
            //crv.ShowRefreshButton = false;

            
        }

        private void mnuDuongDanBC_Click(object sender, EventArgs e)
        {
            grouptDuongDan.Top = (this.Height - grouptDuongDan.Height) / 2;
            grouptDuongDan.Left = (this.Width - grouptDuongDan.Width) / 2;
            txtParth.Text = strReportDir + rptFileName;
            grouptDuongDan.Visible = true;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            grouptDuongDan.Visible = false;
        }

        private void crystalReportViewer1_Enter(object sender, EventArgs e)
        {
            dte = DateTime.Now;
            TimeSpan tg = dte - dts;
            textBox1.Text = tg.ToString();
        }

        private void TrangTiep_Click(object sender, EventArgs e)
        {
            
            try
            {
                crystalReportViewer1.ShowNextPage();
            }
            catch { }
        }

        private void TrangTruoc_Click(object sender, EventArgs e)
        {
            try
            {
                crystalReportViewer1.ShowPreviousPage();
            }
            catch { }
        }

        private void TrangCuoi_Click(object sender, EventArgs e)
        {
            try
            {
                crystalReportViewer1.ShowLastPage();
            }
            catch { }
        }

        private void TrangDau_Click(object sender, EventArgs e)
        {
            try
            {
                crystalReportViewer1.ShowFirstPage();
            }
            catch { }
        }

        private void In_Click(object sender, EventArgs e)
        {
            try
            {
                crystalReportViewer1.PrintReport();
            }
            catch { }
        }

        private void Zoom75_Click(object sender, EventArgs e)
        {
            try
            {
                crystalReportViewer1.Zoom(75);
            }
            catch { }
        }

        private void Zoom100_Click(object sender, EventArgs e)
        {
            try
            {
                crystalReportViewer1.Zoom(100);
            }
            catch { }
        }

        private void Zoom150_Click(object sender, EventArgs e)
        {
            try
            {
                crystalReportViewer1.Zoom(150);
            }
            catch { }
        }

        private void ZoomKhac_Click(object sender, EventArgs e)
        {
            try
            {
                uiGroupBoxZoom.Top = (this.Height - uiGroupBoxZoom.Height) / 2;
                uiGroupBoxZoom.Left = (this.Width - uiGroupBoxZoom.Width) / 2;
                 uiGroupBoxZoom.Visible = true;
            }
            catch { }
        }

        private void Zom_OK_Click(object sender, EventArgs e)
        {
            try
            {
                crystalReportViewer1.Zoom((int)numericEditBoxZoomlevel.Value);
            }
            catch { }
            uiGroupBoxZoom.Visible = false;
        }

        private void TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                uiGroupBoxSearch.Top = (this.Height - uiGroupBoxSearch.Height) / 2;
                uiGroupBoxSearch.Left = (this.Width - uiGroupBoxSearch.Width) / 2;
                uiGroupBoxSearch.Visible = true;
            }
            catch { }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void bt_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                crystalReportViewer1.SearchForText(editBoxSearch.Text);
            }
            catch { }
        }

        private void uiButtonTimKiemThoat_Click(object sender, EventArgs e)
        {
            uiGroupBoxSearch.Visible = false;
        }

        private void numericEditBoxZoomlevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Zom_OK_Click(null, null);
            }
        }

        private void editBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bt_TimKiem_Click(null, null);
            }
        }

        private void NhayToiTrang_OK_Click(object sender, EventArgs e)
        {
            try
            {
                crystalReportViewer1.ShowNthPage((int)numericEditBoxTrang.Value);
            }
            catch { }
            uiGroupBoxNhayToiTrang.Visible = false;

        }

        private void numericEditBoxTrang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                NhayToiTrang_OK_Click(null, null);
            }
        }

        private void NhayToiTrang_Click(object sender, EventArgs e)
        {
            
            try
            {
                uiGroupBoxNhayToiTrang.Top = (this.Height - uiGroupBoxNhayToiTrang.Height) / 2;
                uiGroupBoxNhayToiTrang.Left = (this.Width - uiGroupBoxNhayToiTrang.Width) / 2;
                uiGroupBoxNhayToiTrang.Visible = true;
                numericEditBoxTrang.Value = crystalReportViewer1.GetCurrentPageNumber();
                //numericEditBoxTrang.Value = crystalReportViewer1.Get;
            }
            catch { }
        }

        private void crystalReportViewer1_Click(object sender, EventArgs e)
        {
            uiGroupBoxNhayToiTrang.Visible = false;
            grouptDuongDan.Visible = false;
            uiGroupBoxZoom.Visible = false;
            uiGroupBoxSearch.Visible = false;

        }

        private void Xuatfile_Click(object sender, EventArgs e)
        {
            try
            {
                crystalReportViewer1.ExportReport();
            }
            catch { }
        }
    }
}