using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace DACASUCO.MDDialoge
{
    public partial class dlgXeChuaCanBi : Form
    {
        // Thiet lap vu trong
        string VuTrongID = MDSolution.DACASUCO_App.VuTrongID.ToString();
        // Thiet lap vu trong

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
        public dlgXeChuaCanBi()
        {
            InitializeComponent();
            LoadGrid();
        }
        public void LoadGrid()
        {
            string strSQL = "";
            strSQL = @"SELECT        dbo.tbl_XeVanChuyen.ID, dbo.tbl_XeVanChuyen.SoXe, dbo.tbl_HopDongVanChuyen.TenChuHopDong,  dbo.tbl_HopDongVanChuyen.DiaChi
FROM            dbo.tbl_XeVanChuyen INNER JOIN
                         dbo.tbl_HopDongVanChuyen ON dbo.tbl_XeVanChuyen.HopDongVanChuyenID = dbo.tbl_HopDongVanChuyen.ID WHERE dbo.tbl_XeVanChuyen.VuTrongID=" + VuTrongID;

            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL,null,null);
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

        
    }
}