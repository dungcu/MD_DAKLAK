using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using MDSolution;
using System.Threading;

namespace DACASUCO.MDForms
{
    public partial class frmCVCF : Form
    {
       public long VT = 0;
       public long OK = 0;
       public long Xoa = 1;
       public double LaiSuat = 1;
        
        public frmCVCF()
        {
            InitializeComponent();
        }
        public frmCVCF(long VuChuyen)
        {
            InitializeComponent();
            VT = VuChuyen;
        }
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {

            OK = 1;
            cmdExit.Enabled = false;
            cmdOK.Enabled = false;
            Thread.Sleep(1000);
            string NgayTinh = MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select Convert(char(10),Getdate(),121)", null, null);
            string sql = "ChuyenVu " + VT + "," + MDSolution.DACASUCO_App.VuTrongID.ToString() + ",'" + NgayTinh + "'," + LaiSuat.ToString()+ "," + Xoa.ToString();
            MDSolutionEntities.DBModule.ExecuteNoneBackup(sql, null, null);
            lblStatus.Text = "CHUYỂN VỤ THÀNH CÔNG!";
            cmdExit.Enabled = true;
            this.cmdExit.Text = "&Close";
         }

        private void frmAdd_Phieu_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 500;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
            lblStatus.ForeColor = Color.Red;
            nLS_ValueChanged(null, null);
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            if (lblStatus.ForeColor == Color.Red)
            {
                lblStatus.ForeColor = Color.Green;
            }
            else if (lblStatus.ForeColor == Color.Green)
            {
                lblStatus.ForeColor = Color.Red;
            }
        }

      
        private void nLS_ValueChanged(object sender, EventArgs e)
        {
            double LS = 0;
            LS = (double)(nLS.Value/100);
            LS = Math.Round(LS, 2);
            txtLS.Text = LS.ToString();
            LaiSuat = LS;
        }

        private void chkXoaHDDT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkXoaHDDT.Checked)
            {
                Xoa = 1;
            }
            else
            {
                Xoa = 0;
            }
        }

     
      
    }
}
