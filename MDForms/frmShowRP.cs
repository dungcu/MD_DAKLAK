using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using DACASUCO.MDReport;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.SCREventLog;
using CrystalDecisions.Shared;
namespace MDSolution
{
  
    public partial class frmShowRP : Form
    {
        public static string Active;
        //private NodeDonVi nDonVi = new NodeDonVi();
        public ReportClass RP;
        public frmShowRP()
        {
            InitializeComponent();
            //CommonClass.loadTreeXa(tvDonVi);
        }

        private void frmShowRP_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                //RP.Database.Tables[0].ApplyLogOnInfo();
                crystalReportViewer1.ReportSource = RP;
            }
            catch
            {
                MessageBox.Show("Báo cáo không có dữ liệu hoạc có lỗi khi load báo cáo");

            }
            
        }
       
        
    }
}