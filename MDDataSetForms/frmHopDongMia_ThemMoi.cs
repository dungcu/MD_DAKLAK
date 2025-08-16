using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using MDSolution;

namespace DACASUCO.MDDataSetForms
{
    public partial class frmHopDongMia_ThemMoi : Form
    {
        private int lThonID = 0;

        //private DACASUCO.MDDataSet.HopDongTrongMiaDataSet.TreeHopDongRow oCurrentDonVi ;

        public frmHopDongMia_ThemMoi()
        {
            InitializeComponent();
        }
        
        private void frmHopDongMia_ThemMoi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hopDongTrongMiaDataSet.tbl_NganHang' table. You can move, or remove it, as needed.
            this.tbl_NganHangTableAdapter.Fill(this.hopDongTrongMiaDataSet.tbl_NganHang);
            // TODO: This line of code loads data into the 'donViDataSet.TreeDonVi' table. You can move, or remove it, as needed.
            this.treeDonViTableAdapter.Fill(this.donViDataSet.TreeDonVi);                        

        }
        
        private string GetMaHopDong(int iThonID)
        {
            try
            {
                string strXaID = "";
                // nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                //int iXaID = 0;
                
                strXaID = treeDonViGridEX.GetValue("XaID").ToString();
                string strSQL = "SELECT [MaXa] FROM tbl_Xa Where [ID]=" + strXaID;
                string maXa = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                string strMaxID = "";
                int batdau = maXa.Trim().Length + 1;
                strSQL = "SELECT max(cast(ltrim(rtrim(substring(mahopdong," + batdau.ToString() + ", 10))) as numeric(10))) FROM tbl_HopDong WHERE ThonID in (SELECT [id] FROM tbl_Thon WHERE XaID =" + strXaID + ") ";
                strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (strMaxID == "") strMaxID = "0";
                int intMaxID = int.Parse(strMaxID);
                intMaxID++;
                return maXa + intMaxID.ToString();
            }
            catch
            {
                return "";
            }

        }
        
        private void DoSave()
        {                     
                this.tbl_HopDongBindingSource.EndEdit();
                MDDataSet.HopDongTrongMiaDataSet.tbl_HopDongDataTable changes = (MDDataSet.HopDongTrongMiaDataSet.tbl_HopDongDataTable)this.hopDongTrongMiaDataSet.tbl_HopDong.GetChanges();
                if (changes != null)
                {
                    //Fill default value;
                    foreach (MDDataSet.HopDongTrongMiaDataSet.tbl_HopDongRow detail in changes.Rows)
                    {
                        DataRowState dstate = detail.RowState;
                        if (detail.RowState == DataRowState.Deleted)
                        {
                        }
                        else if (detail.RowState == DataRowState.Added)
                        {
                            //detail.ID = System.Convert.ToInt32(MDSolutionEntities.DBModule.GetNewID(typeof(clsHopDong), "tbl_HopDong", null, null));                        
                            detail.MaHopDong = maHopDongEditBox.Text;
                            detail.CreatedBy = System.Convert.ToInt32(DACASUCO_App.User.ID);
                            detail.ModifyBy = System.Convert.ToInt32(DACASUCO_App.User.ID);
                            detail.DataModify = DateTime.Now;
                            detail.ModifyBy = System.Convert.ToInt32(DACASUCO_App.User.ID);
                        }
                        else if (detail.RowState == DataRowState.Modified)
                        {
                            if (detail.MaHopDong != maHopDongEditBox.Text)
                                detail.MaHopDong = maHopDongEditBox.Text;
                            detail.DataModify = DateTime.Now;
                            detail.ModifyBy = System.Convert.ToInt32(DACASUCO_App.User.ID);
                        }
                    }
                    this.tbl_HopDongTableAdapter.Update(this.hopDongTrongMiaDataSet.tbl_HopDong);
            }

            //foreach(DataRow dr in 
        }
        private void treeDonViGridEX_SelectionChanged(object sender, EventArgs e)
        {
            DonVi_SelectionChanged();
        }        
        private void DonVi_SelectionChanged()
        {
            try
            {
                if (int.TryParse(treeDonViGridEX.GetValue("ID").ToString(), out lThonID))
                {
                    uiPanelHopDongListEdit.Enabled = true;
                    uiPanelHopDongListEdit.Text = "Thôn:"+treeDonViGridEX.GetValue("TenThon").ToString();
                    Load_HopDongGridEX();
                }
                else
                {
                    uiPanelHopDongListEdit.Enabled = false;
                }
            }
            catch
            {
                uiPanelHopDongListEdit.Enabled = false;
            }
        }
        private void Load_HopDongGridEX()
        {
            this.tbl_HopDongTableAdapter.FillByThonID(this.hopDongTrongMiaDataSet.tbl_HopDong, lThonID);
            if (this.hopDongTrongMiaDataSet.tbl_HopDong.Count <= 0)
            {
                this.uiButtonDelete.Enabled = false;
                this.uiButtonEdit.Enabled = false;
                this.uiButtonNew.Enabled = true;

                this.uiGroupBoxbtnConfirm.Enabled = false;

                this.uiGroupBoxHopDong.Enabled = false;
                this.uiGroupBoxHopDongList.Enabled = true;
                this.uiGroupBoxBackGround.Enabled = true;
            }
            else
            {
                this.uiButtonDelete.Enabled = true;
                this.uiButtonNew.Enabled = true;
                this.uiButtonEdit.Enabled = true;

                this.uiGroupBoxbtnConfirm.Enabled = false;

                this.uiGroupBoxHopDong.Enabled = false;
                this.uiGroupBoxHopDongList.Enabled = true;
                this.uiGroupBoxBackGround.Enabled = true;
            }

        }        
      

        private void tbl_HopDongGridEX_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            
        }
               
        private Boolean Validate_InPutValues()
        {
            Boolean res = true;
            if (maHopDongEditBox.Text == "")
            {
                this.errorProvider1.SetError(this.maHopDongEditBox, "Phải nhập mã hợp đồng");
            }
            else
            {
                this.errorProvider1.SetError(this.maHopDongEditBox, "");
                res = false;
            }
            if (hoTenEditBox.Text == "")
            {
                this.errorProvider1.SetError(this.hoTenEditBox, "Phải nhập họ tên của hợp đồng");
            }
            else
            {
                this.errorProvider1.SetError(this.hoTenEditBox, "");
                res = false;
            }
            return res;

        }

        private void uiButtonEdit_Click(object sender, EventArgs e)
        {
            this.uiButtonDelete.Enabled = false;
            this.uiButtonNew.Enabled = false;
            this.uiButtonEdit.Enabled = false;

            this.uiGroupBoxbtnConfirm.Enabled = true;

            this.uiGroupBoxHopDong.Enabled = true;
            this.uiGroupBoxHopDongList.Enabled = false;
            this.uiGroupBoxBackGround.Enabled = false;

            this.maHopDongEditBox.Focus();
        }
        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            //if(this.tbl_HopDongBindingSource.
            this.errorProvider1.Clear();
            this.tbl_HopDongBindingSource.CancelEdit();
            this.uiButtonNew.Enabled = true;
            if (this.hopDongTrongMiaDataSet.tbl_HopDong.Count <= 0)
            {
                this.uiButtonDelete.Enabled = false;
                this.uiButtonEdit.Enabled = false;
            }
            else
            {
                this.uiButtonDelete.Enabled = true;
                this.uiButtonEdit.Enabled = true;
            }

            this.uiGroupBoxbtnConfirm.Enabled = false;
            this.uiGroupBoxHopDong.Enabled = false;
            this.uiGroupBoxHopDongList.Enabled = true;
            this.uiGroupBoxBackGround.Enabled = true;
        }
        private void uiButtonNew_Click(object sender, EventArgs e)
        {
            this.tbl_HopDongBindingSource.AddNew();


            this.uiButtonDelete.Enabled = false;
            this.uiButtonNew.Enabled = false;
            this.uiButtonEdit.Enabled = false;

            this.uiGroupBoxbtnConfirm.Enabled = true;

            this.uiGroupBoxHopDong.Enabled = true;
            this.uiGroupBoxHopDongList.Enabled = false;
            this.uiGroupBoxBackGround.Enabled = false;

            this.maHopDongEditBox.Text = GetMaHopDong(this.lThonID);
            this.maHopDongEditBox.Focus();

        }
        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            if (this.Validate_InPutValues())
            {
                DoSave();
                this.uiButtonNew.Enabled = true;
                if (this.hopDongTrongMiaDataSet.tbl_HopDong.Count <= 0)
                {
                    this.uiButtonDelete.Enabled = false;
                    this.uiButtonEdit.Enabled = false;
                }
                else
                {
                    this.uiButtonDelete.Enabled = true;
                    this.uiButtonEdit.Enabled = true;
                }

                this.uiGroupBoxbtnConfirm.Enabled = false;
                this.uiGroupBoxHopDong.Enabled = false;
                this.uiGroupBoxHopDongList.Enabled = true;
                this.uiGroupBoxBackGround.Enabled = true;
            }
        }
        private void uiButtonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void uiButtonDelete_Click(object sender, EventArgs e)
        {
            string message;
            message = this.tbl_HopDongGridEX.GetValue("MaHopDong").ToString() + " - " + this.tbl_HopDongGridEX.GetValue("HoTen").ToString();
            message = String.Format("Bạn có chắc chắn muốn xóa hợp đồng:\"" + message + "\"?");

            if (MessageBox.Show(message, " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                this.tbl_HopDongBindingSource.RemoveCurrent();
                DoSave();
            }
        }

        private void uiButtonRefeshTree_Click(object sender, EventArgs e)
        {            
            this.treeDonViTableAdapter.Fill(this.donViDataSet.TreeDonVi);
        }
               
    }
}