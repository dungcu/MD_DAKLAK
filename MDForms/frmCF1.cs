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
    public partial class frmCF1 : Form
    {
        public long OK = 0;
        public frmCF1()
        {
            InitializeComponent();
        }
        public frmCF1(string Gio, string Ngay)
        {
            InitializeComponent();
            lblGio.Text = Gio;
            lblNgay.Text = Ngay;
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            if (label3.ForeColor == Color.Red)
            {
                label3.ForeColor = Color.Green;
            }
            else if (label3.ForeColor == Color.Green)
            {
                label3.ForeColor = Color.Red;
            }
        }

        private void frmCF1_Load(object sender, EventArgs e)
        {
            Timer tmr = new Timer();
            tmr.Interval = 500;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
            label3.ForeColor = Color.Red;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            OK = 0;
            this.Close();
        }

        private void cmdCanCel_Click(object sender, EventArgs e)
        {
            OK = 1;
            this.Close();
        }

        
    }
}
