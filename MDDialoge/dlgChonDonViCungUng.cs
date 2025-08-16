using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using Janus.Windows.GridEX;

namespace MDSolution.MDDialoge
{
    public partial class dlgChonDonViCungUng : Form
    {
        public bool Test = false;
        public string[] a = new string[100];
        private string DMID = "";
        public dlgChonDonViCungUng()
        {
            InitializeComponent();
            LoadGrid();
        }
        public dlgChonDonViCungUng(string DMDT_ID)
        {
            InitializeComponent();
            DMID = DMDT_ID;
            LoadGrid();
        }
        public void LoadGrid()
        {
            string strSQL = "";
            strSQL = "Select * from tbl_DonViCungUngVatTu";

            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables.Count > 0)
            {
                this.grdDVCU.SetDataBinding(ds.Tables[0], "");
            }
            
        }
        private void truyenDL()
        {
            if (!string.IsNullOrEmpty(DMID))
            {
                string strSQL1 = "Select * from tbl_DanhMucDT_DonViCU where DanhMucDauTuID=" + DMID.ToString();

                DataSet ds1 = MDSolutionEntities.DBModule.ExecuteQuery(strSQL1, null, null);              


                if (ds1.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds1.Tables[0].Rows)
                    {
                        if (!dr.IsNull("DonViCungUngID"))
                        {                            
                            foreach (GridEXRow jr in this.grdDVCU.GetUncheckedRows())
                            {
                                GridEXCell jc = jr.Cells["ID"];
                                if (dr["DonViCungUngID"].ToString() == jc.Value.ToString())
                                {                                   
                                    jr.CheckState = RowCheckState.Checked;
                                    break;
                                }
                            }
                        }
                    }                   
                    
                }
            }
        }
        private void uiButtonOk_Click(object sender, EventArgs e)
        {           
            long i = 0;
           foreach (GridEXRow jr in this.grdDVCU.GetCheckedRows())
           {
               GridEXCell jc = jr.Cells["ID"];
               string b = jc.Value.ToString();
               a[i] = b;
               i = i + 1;
               Test = true;
           }
           this.Hide();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Test = false;
            this.Close();
        }

        private void dlgChonDonViCungUng_Load(object sender, EventArgs e)
        {
            truyenDL();
        }
    }
}