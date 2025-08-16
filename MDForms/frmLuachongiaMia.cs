using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDSolution.MDForms;

namespace MDSolution.MDForms
{
    public partial class frmLuachonGiamia : Form
    {
        public frmLuachonGiamia()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (rdGiaso.Checked == true)
            {
                this.Close();
             frmQuanLyDauTuNoCu frm = new frmQuanLyDauTuNoCu();
             frm.MdiParent = this;
             frm.Show();
             //Waited();
            }
        }
    }
}
