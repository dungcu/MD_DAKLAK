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
    public partial class frmChuyenXe_CF : Form
    {
        public long OK = 0;
        public frmChuyenXe_CF()
        {
            InitializeComponent();
        }
        public frmChuyenXe_CF(string SoXe, string Di, string Den, string Ngay, string Chay, string Phieu)
        {
            InitializeComponent();
            lblSoXe.Text = SoXe;
            lblCu.Text = Di;
            lblMoi.Text =Den;
            lblNgay.Text = Ngay;
            lblChay.Text = Chay;
            lblPhieu.Text = Phieu;
           
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            OK = 0;
            this.Close();
        }

        private void frmChuyenXe_CF_Load(object sender, EventArgs e)
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
            OK = 1;
            this.Close();
        }

       

    }       
}
