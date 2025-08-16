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
    public partial class frmXoMia : Form
    {
        bool exitst = false;
        float tg = 0;
        float tghs = 0;
        float tghspl = 0;
        public frmXoMia()
        {
            InitializeComponent();
        }

        private void frmXoMia_Load(object sender, EventArgs e)
        {
            trackXoMia.Value = 1;
            trackHS.Value = 1;
            trackHSPL.Value = 100;
            string sql = "Select * from tbl_TyLeMiaXo";
            DataSet value = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);

            Timer tmr = new Timer();
            tmr.Interval = 500;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
            lblThongbao.ForeColor = Color.Red;
           
            if (value.Tables[0].Rows.Count > 0)
            {
                try
                {
                    tg = float.Parse(value.Tables[0].Rows[0]["TyLe"].ToString());
                    trackXoMia.Value = (int)(tg * 100);
                }
                catch
                {
                    tg = 0;
                }
                try
                {
                    tghs = float.Parse(value.Tables[0].Rows[0]["HeSo"].ToString());
                   int hs = (int)(tghs * 100);
                   trackHS.Value = hs;
                }
                catch
                {
                    tghs = 0;
                
                }
                try
                {
                    tghspl = float.Parse(value.Tables[0].Rows[0]["HeSoPL"].ToString());
                    int hspl = (int)(tghspl * 100);
                    trackHSPL.Value = hspl;
                }
                catch
                {
                    tghspl = 0;
                }
                exitst = true;
            }

            txtResult.Text = tg.ToString();
            txtHS.Text = tghs.ToString();
            txtHSPL.Text = tghspl.ToString();
        }
        
        private void trackXoMia_Scroll(object sender, EventArgs e)
        {
            tg =(float)trackXoMia.Value/100;
            txtResult.Text = tg.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn thiết lập các tham số như lựa chọn ?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "";
                if (exitst)
                {
                    sql = "Update tbl_TyLeMiaXo Set TyLe=" + tg.ToString()+",HeSo="+tghs.ToString()+",HeSoPL="+tghspl.ToString();
                }
                else
                {
                    sql = "Insert into tbl_TyLeMiaXo (TyLe,HeSo,HeSoPL) Values("+tg.ToString()+","+tghs.ToString()+","+tghspl.ToString()+")";
                }
                MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackHS_Scroll(object sender, EventArgs e)
        {
            tghs = (float)trackHS.Value / 100;
            txtHS.Text = tghs.ToString();
        }

        private void trackHSPL_Scroll(object sender, EventArgs e)
        {
            tghspl = (float)trackHSPL.Value / 100;
            txtHSPL.Text = tghspl.ToString();
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            if (lblThongbao.ForeColor == Color.Red)
            {
                lblThongbao.ForeColor = Color.Green;
            }
            else if (lblThongbao.ForeColor == Color.Green)
            {
                lblThongbao.ForeColor = Color.Red;
            }
        }

    }
}
