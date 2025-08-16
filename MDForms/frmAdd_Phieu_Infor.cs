using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace DACASUCO.MDForms
{
    public partial class frmAdd_Phieu_Infor : Form
    {
       public frmAdd_Phieu_Infor()
        {
            InitializeComponent();
        }
       public frmAdd_Phieu_Infor(string CM, string DT, string SPKH, string SPThem, string SPDaCap, string SPSuDung)
        {
            InitializeComponent(); 
            this.lblChumia.Text = CM;
            this.lblDT.Text=DT;
            this.lblSPDaCap.Text = SPDaCap;
            this.lblSPSuDung.Text = SPSuDung;
            this.lblSPKH.Text = SPKH;
            this.lblSPThem.Text = SPThem;
        }
      
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
              
    }
}
