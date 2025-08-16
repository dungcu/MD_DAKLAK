using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using MDSolution;

namespace DACASUCO.MDDataSetForms
{
    public partial class DangKyDauTu : Form
    {
        private NodeDonVi nDonVi = new NodeDonVi();
        private DataSet gridThonSource;
        public DangKyDauTu()
        {
            InitializeComponent();
            CommonClass.loadTreeDonVi(treeDonVi);
        }
        #region
        private void treeDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                //if (!nDonVi.HasLoadChildren && nDonVi.Type == DonviType.Thon)
                //{
                //    CommonClass.LoadChildrenHopDong(treeDonVi.SelectedNode);
                //    nDonVi.HasLoadChildren = true;
                //}
                this.DoLoadGridHopDong(-1);
            }
        }

        private void treeDonVi_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nDonVi = (NodeDonVi)e.Node.Tag;
            //if (!nDonVi.HasLoadChildren && nDonVi.Type == DonviType.Thon)
            //{
            //    CommonClass.LoadChildrenHopDong(e.Node);
            //    nDonVi.HasLoadChildren = true;
            //}
            this.DoLoadGridHopDong(-1);
        }
        private void DoLoadGridHopDong(long lID)
        {
            this.LoadThonSource();
            this.CreateDataSourceAndBindGrid(lID);
            this.grdHopDong.Focus();

        }
        private void LoadThonSource()
        {
            string strSQL = "SELECT * FROM tbl_Thon";
            switch (nDonVi.Type)
            {
                case DonviTypeHD.Xa: strSQL += " WHERE ID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviTypeHD.Thon: strSQL += " WHERE ID=" + nDonVi.DonViID; break;
                default: break;
            }
            this.gridThonSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridThonSource.Tables.Count > 0)
            {
                this.grdHopDong.DropDowns["Thon"].SetDataBinding(this.gridThonSource.Tables[0], "");
            }
        }
        private void CreateDataSourceAndBindGrid(long lID)
        {
            DataSet ds;
            ds = clsHopDong.GetDanhSachDenHopDong(lID, this.edtTimKiem.Text, nDonVi.Type, nDonVi.DonViID, this.chkTimkiemchinhxac.Checked);
            if (ds.Tables.Count > 0)
            {
                this.grdHopDong.SetDataBinding(ds.Tables[0], "");
            }

        }
        private void LoadDDLHinhThucDauTuGridDauTu()
        {
            try
            {
                DataSet ds = clsDanhMucDauTu.GetListbyWhere("", " ID in (SELECT DanhMucDauTuID FROM [tbl_DanhMucDauTu_VuTrong] WHERE VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + ")", " ThuTu", null, null);
                this.gridEXDangKyDauTu.DropDowns["ddlDanhMucDauTu"].SetDataBinding(ds.Tables[0], "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể load danh mục đầu tư");
            }

        }
         #endregion
    }
}