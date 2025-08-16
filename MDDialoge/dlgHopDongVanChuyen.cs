using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace DACASUCO.MDDialoge
{
    public partial class dlgHopDongVanChuyen : Form
    {
        public delegate void PassID(string value);
        public PassID passID;

        private void SendID()
        {
            if (passID != null)
            {
                try
                {
                    passID(this.gdVHopDongVanChuyen.GetValue("ID").ToString());
                }
                catch
                {
                    passID("-1");
                }
            }
        }
        public dlgHopDongVanChuyen()
        {
            InitializeComponent();
            LoadHopDongVanChuyen();
        }
        public void LoadHopDongVanChuyen()
        {
            DataSet ds = clsHopDongVanChuyen.GetListbyWhere("", "", "", null, null);
            if (ds.Tables.Count > 0)
            {
                this.gdVHopDongVanChuyen.SetDataBinding(ds.Tables[0], "");
            }
        }
       
        private void gdVHopDongVanChuyen_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            //frmNhapMia.MaKVC = this.gdVHopDongVanChuyen.GetValue("MaHopDong").ToString().Trim();
            this.SendID();
            this.DialogResult = DialogResult.OK;
            Close();           
          
        }

        private void gdVHopDongVanChuyen_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {

        }

        private void gdVHopDongVanChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //frmNhapMia.MaKVC = this.gdVHopDongVanChuyen.GetValue("MaHopDong").ToString().Trim();
                this.SendID();
                this.DialogResult = DialogResult.OK;
                Close();   
            }
            if (e.KeyCode == Keys.Escape)
            {                
                Close();
            }
        }

        private void dlgHopDongVanChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Escape)
            {
                Close();
            }
        }

        
    }
}