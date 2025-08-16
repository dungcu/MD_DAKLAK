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
    public partial class frmConfirm : Form
    {
        public long OK = 0;
        public frmConfirm()
        {
            InitializeComponent();
        }
        public frmConfirm(string CM, string HT, string PT, string Xe, string Status, string Gia)
        {
            InitializeComponent();
            lblHoTen.Text = CM;
            lblHT.Text = HT;
            lblPT.Text = PT;
            lblXe.Text = Xe;
            lblGia.Text = Gia;
            lblTinhTrang.Text = Status;
            if (Status == "Mía cháy")
            {
             lblTinhTrang.ForeColor = Color.Red;
            }
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            OK = 1;
            this.Close();
        }

        private void frmConfirm_Load(object sender, EventArgs e)
        {
            Timer tmr = new Timer();
            tmr.Interval = 500;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
            label1.ForeColor = Color.Red; //Set The Default Color As Re
        }
     
        void tmr_Tick(object sender, EventArgs e)
        {
            if (label1.ForeColor == Color.Red)
            {
                label1.ForeColor = Color.Green;
            }
            else if (label1.ForeColor == Color.Green)
            {
                label1.ForeColor = Color.Red;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            OK = 0;
            this.Close();
        }
    }       
}
