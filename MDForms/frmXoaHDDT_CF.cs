using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace MDSolution
{
    public partial class frmXoaHDDT_CF : Form
    {
        public long OK = 0;
        public frmXoaHDDT_CF()
        {
            InitializeComponent();
        }
        public frmXoaHDDT_CF(string MaHDDT, string DT, string NoCu, string DauTu, string ThuMua, string VuTrong)
        {
            InitializeComponent();
            lblMaHDDT.Text = MaHDDT;
            lblDT.Text = DT;
            lblNoCu.Text =NoCu;
            lblDauTu.Text = DauTu;
            lblThuMua.Text = ThuMua;
            lblVuTrong.Text = VuTrong;
            if (lblThuMua.Text.Trim() != "0")
            {
                lblStatus.Text = "Bạn không thể xoá HĐĐT này!";
                cmdOK.Enabled = false;
            }
           
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            OK = 0;
            this.Close();
        }

        private void frmXoaHDDT_CF_Load(object sender, EventArgs e)
        {
            Timer tmr = new Timer();
            tmr.Interval = 500;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
            lblStatus.ForeColor = Color.Red;
           
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

        private void cmdOK_Click(object sender, EventArgs e)
        {
            OK = 1;
            this.Close();
        }

       

    }       
}
