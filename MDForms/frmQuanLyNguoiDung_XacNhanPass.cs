using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution
{
    public partial class frmQuanLyNguoiDung_XacNhanPass : Form
    {
        public string pass;
        public int ok = 0;
        public frmQuanLyNguoiDung_XacNhanPass()
        {
            InitializeComponent();
        }

        private void btok_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Keys.Enter.ToString());
            if (pass.Equals(txtPasConfig.Text)) ok = 1;
            this.Close();
        }

        private void frmQuanLyNguoiDung_XacNhanPass_Load(object sender, EventArgs e)
        {
            txtPasConfig.Select();
            txtPasConfig.Focus();
        }

        private void txtPasConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (pass.Equals(txtPasConfig.Text)) ok = 1;
                this.Close();
            }

        }
    }
}