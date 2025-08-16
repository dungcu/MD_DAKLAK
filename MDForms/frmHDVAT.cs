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
    public partial class frmHDVAT : Form
    {
        public int Cancel = 0;
        public frmHDVAT()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Cancel = 1;
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Cancel = 0;
            this.Close();
        }
    }
}
