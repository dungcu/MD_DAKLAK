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
    public partial class frmXoaCM_CF : Form
    {
        public long OK = 0;
        public frmXoaCM_CF()
        {
            InitializeComponent();
        }
        public frmXoaCM_CF(string HoTen, string SoCMND, string DiaChi, string SoDT, string SLHD)
        {
            InitializeComponent();
            lblSoCMND.Text = SoCMND;
            lblDC.Text = DiaChi.Trim();
            lblSDT.Text =SoDT;
            lblSLHD.Text = SLHD;
            lblHoTen.Text = HoTen;
            if (lblSLHD.Text.Trim() == "Tồn tại HĐĐT trong các niên vụ")
            {
                lblStatus.Text = "Bạn không thể xoá Chủ mía này!";
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
