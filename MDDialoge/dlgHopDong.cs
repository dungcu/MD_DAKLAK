
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using Janus.Windows.GridEX;
using MDSolution;


namespace DACASUCO.MDDialoge
{
    public partial class dlgHopDong : Form
    {
        private NodeDonVi nDonVi = new NodeDonVi();
        private DataSet gridDataSource;

        public delegate void PassID(string value);
        public PassID passID;

        private void SendID()
        {
            if (passID != null)
            {
                try{                
                    passID(this.GridEX1.GetValue("ID").ToString());
                }
                catch{
                    passID("-1");
                }
            }
        }

        public dlgHopDong()
        {
            InitializeComponent();
            CommonClass.loadTreeDonVi(treeDonVi);
            nDonVi = (NodeDonVi)treeDonVi.Nodes[0].Tag;
        }
        private DataSet LoadHopDong()
        {
            string strSQL = "SELECT * FROM tbl_HopDong WHERE 1=1";
            switch (nDonVi.Type)
            {
                case DonviTypeHD.Xa: strSQL += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviTypeHD.Thon: strSQL += " AND ThonID=" + nDonVi.DonViID; break;
                default: break;
            }
            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                strSQL += " AND (MaHopDong like N'%" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "%' OR HoTen like N'%" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "%' )";
            }
            return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
        }

        private void CreateDataSourceAndBindGrid()
        {
            gridDataSource = this.LoadHopDong();
            if (gridDataSource.Tables.Count > 0)
            {
                this.GridEX1.SetDataBinding(gridDataSource.Tables[0], "");
            }
        }

        private void treeDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                this.DoLoadGridHopDong();
            }
        }
        private void DoLoadGridHopDong()
        {
            this.CreateDataSourceAndBindGrid();
            this.GridEX1.Focus();
        }

        private void treeDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nDonVi = (NodeDonVi)e.Node.Tag;
            this.DoLoadGridHopDong();
        }

        //private void GridEX1_SelectionChanged(object sender, EventArgs e)
        //{
        //    GridEXRow currentRow = null;
        //    currentRow = this.GridEX1.GetRow();
        //    DataRowView dr;
        //    if ((currentRow != null) && (currentRow.DataRow != null))
        //    {
        //        dr = (DataRowView)currentRow.DataRow;
        //        editBox1.Text = dr.Row.ItemArray[1].ToString() + "-" + dr.Row.ItemArray[14].ToString();
        //        mHopDongID = dr.Row.ItemArray[0].ToString();
        //        gridEX2.AllowAddNew = InheritableBoolean.True;
        //    }
        //    else
        //    {
        //        editBox1.Text = "";
        //        mHopDongID = "-1";
        //        gridEX2.AllowAddNew = InheritableBoolean.False;
        //    }

        //    this.LoadDDLThuaRuongGridDauTu();
        //    this.LoadGridEX2();
        //}               

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                if (uiCheckBox1.Checked)
                {
                    nDonVi = (NodeDonVi)treeDonVi.Nodes[0].Tag;
                }
                this.DoLoadGridHopDong();
            }
        }
        private void edtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Search();
            }
        }

        private void edtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            this.SendID();
            this.Close();
        }

        private void GridEX1_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.btnChon_Click(null, EventArgs.Empty);
        }

        private void GridEX1_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }



        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBox1.SelectedIndex == 1)
        //    {
        //        //co
        //        this.gridEX2.Tables[0].Columns["ThuaRuongID"].Visible = false;
        //        this.gridEX2.Tables[0].Columns["HinhThucDauTuID"].Visible = true;
        //    }
        //    else
        //    {
        //        this.gridEX2.Tables[0].Columns["HinhThucDauTuID"].Visible = false;
        //        this.gridEX2.Tables[0].Columns["ThuaRuongID"].Visible = true;
        //    }
        //}










    }
}