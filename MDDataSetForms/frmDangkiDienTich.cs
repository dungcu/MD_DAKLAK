using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Janus.Windows.GridEX;
using System.Windows.Forms;
using MDSolutionEntities;
using MDSolution;


namespace DACASUCO.MDDataSetForms
{
    public partial class frmDangkiDienTich : Form
    {
        //private clsDangkiDienTich oDKDT = new clsDangkiDienTich();
        private NodeDonVi nDonVi = new NodeDonVi();
        public frmDangkiDienTich()
        {
            InitializeComponent();
            //LoadccbHienTrang();
            //LoadccbKieuTrong();
            //LoadccbLoaiDat();
            //LoadccbThon();
            CommonClass.loadTreeDonVi(treeDonVi);
        }
        #region
        //private void treeDonVi_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    //string TTHD = "";
        //    //try
        //    //{
        //    //    if (this.grdHopDong.GetValue("ParentID").ToString() != "")
        //    //    { TTHD = GetHopDong(this.grdHopDong.GetValue("ParentID").ToString()); }
        //    //    else { TTHD = ""; }
        //    //}
        //    //catch { TTHD = ""; }
        //    //switch (nDonVi.Type)
        //    //{
        //    //    case DonviTypeHD.Xa: uiPanel2.Text = "Chủ hộ của chủ hợp đồng:" + TTHD + " ,trong xã : " + treeDonVi.SelectedNode.Text + ""; break;
        //    //    case DonviTypeHD.Thon: uiPanel2.Text = "Chủ hộ của chủ hợp đồng:" + TTHD + " ,trong thôn : " + treeDonVi.SelectedNode.Text + ""; break;
        //    //    case DonviTypeHD.ChuHopDong: uiPanel2.Text = "Chủ hộ của chủ hợp đồng : " + treeDonVi.SelectedNode.Text + ""; break;
        //    //    default: uiPanel2.Text = "Chủ hộ"; break;
        //    //}
        //}

        //private void treeDonVi_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == '\r')
        //    {
        //        nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
        //        //if (!nDonVi.HasLoadChildren && nDonVi.Type == DonviType.Thon)
        //        //{
        //        //    CommonClass.LoadChildrenHopDong(treeDonVi.SelectedNode);
        //        //    nDonVi.HasLoadChildren = true;
        //        //}
        //        //uiPanel5.Text = "Thửa ruộng (" + nDonVi.DonViName + ")";
        //        ////uiPanel2.Text = "Hợp đồng(" + nDonVi.DonViName + ")";
        //        //this.DoLoadGridHopDong(-1);
        //        LoadccbHopDong();
        //    }
        //}

        //private void treeDonVi_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    //= treeDonVi.SelectedNode.Text;
        //    nDonVi = (NodeDonVi)e.Node.Tag;
           
        //    LoadccbHopDong();
        //}
        //private void LoadccbHopDong()
        //{
        //    try
        //    {
        //        string strSQLWhere="";
        //        DataSet ds;                
        //        switch (nDonVi.Type)
        //        {
        //            case DonviTypeHD.Xa: strSQLWhere = " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
        //            case DonviTypeHD.Thon: strSQLWhere = " AND ThonID=" + nDonVi.DonViID; break;
        //            default: strSQLWhere = ""; break;
        //        }
        //        if (!string.IsNullOrEmpty(strSQLWhere))
        //        {
        //            ds = clsHopDong.GetListbyWhere("ID,MaHopDong", "trangthai = 1 AND ParentID = 0 " + strSQLWhere, "", null, null);
        //            if (ds.Tables.Count > 0)
        //            {

        //                DataRow oR = ds.Tables[0].NewRow();
        //                this.uiComboBoxMaHopDong.DataSource = ds.Tables[0];

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void uiComboBoxMaHopDong_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LoadccbChuHo();
        //}
        //private void LoadccbChuHo()
        //{
        //    try
        //    {
        //        DataSet ds;                
        //        ds = clsHopDong.GetListbyWhere("ID,MaHopDong", "trangthai = 1 AND ParentID="+uiComboBoxMaHopDong.SelectedValue.ToString(), "", null, null);
        //        if (ds.Tables.Count > 0)
        //        {
        //            //ds.Tables[0].Rows.Add(new object[] { -1, "-- Thôn --" });
        //            DataRow oR = ds.Tables[0].NewRow();
        //            this.uiComboBoxMaChuHo.DataSource = ds.Tables[0];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        ////private void LoadccbMaThuaRuong()
        ////{
        ////    try
        ////    {
        ////        DataSet ds;
        ////        ds = clsThuaRuong.GetListbyWhere("ID,MaThuaRuong", "HopDongID=" + uiComboBoxMaChuHo.SelectedValue.ToString(), "", null, null);
        ////        if (ds.Tables.Count > 0)
        ////        {

        ////            DataRow oR = ds.Tables[0].NewRow();
        ////            this.uiComboBoxMaThuaRuong.DataSource = ds.Tables[0];

        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        MessageBox.Show(ex.Message);
        ////    }
        ////}

        //private void uiComboBoxMaChuHo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LoadDangkyDienTich();
        //}
       
        //private void LoadccbThon()
        //{
        //    try
        //    {
        //        DataSet ds;
        //        ds = clsThon.GetListbyWhere("", "", "", null, null);
        //        this.grdDangKiDienTich.DropDowns["DropDownThon"].SetDataBinding(ds.Tables[0], "");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //private void LoadccbLoaiDat()
        //{
        //    try
        //    {
        //        DataSet ds;
        //        ds = clsLoaiDat.GetListbyWhere("", "", "", null, null);
        //        this.grdDangKiDienTich.DropDowns["DropDownLoaiDat"].SetDataBinding(ds.Tables[0], "");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //private void LoadccbHienTrang()
        //{
        //    try
        //    {
        //        DataSet ds;
        //        ds = clsPheCanh.GetListbyWhere("", "", "", null, null);
        //        this.grdDangKiDienTich.DropDowns["DropDownHieTrang"].SetDataBinding(ds.Tables[0], "");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void LoadccbKieuTrong()
        //{
        //    try
        //    {
        //        DataSet ds;
        //        ds = clsRaiVu.GetListbyWhere("", "", "", null, null);
        //        this.grdDangKiDienTich.DropDowns["DropDownKieuTrong"].SetDataBinding(ds.Tables[0], "");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //private void LoadDangkyDienTich()
        //{
        //    DataSet ds;
        //    string strSQL = "SELECT a.*,b.MaThuaRuong,b.SoBanDieuTra,b.ThonID,b.LoaiDatID,b.PheCanhID,(b.ID) as IDThuaRuong,b.XuDong FROM tbl_DangKy_DienTich as a FULL OUTER JOIN tbl_ThuaRuong as b ON b.ID = a.[ThuaRuongID] Where a.HopDongID=" + uiComboBoxMaChuHo.SelectedValue.ToString();            

        //    ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
        //    if (ds.Tables.Count > 0)
        //    {
        //        this.grdDangKiDienTich.SetDataBinding(ds.Tables[0], "");
        //    }
        //}

        //private void grdDangKiDienTich_SelectionChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(this.grdDangKiDienTich.GetValue("ID").ToString()))
        //        {                    
        //            oDKDT = new clsDangkiDienTich();
        //        }
        //        else
        //        {
        //            oDKDT.ID = long.Parse(this.grdDangKiDienTich.GetValue("ID").ToString());
        //        }
        //    }
        //    catch
        //    {
        //        oDKDT = new clsDangkiDienTich();
        //    }
        //}

        //private void grdDangKiDienTich_AddingRecord(object sender, CancelEventArgs e)
        //{
        //    if (!SaveDKDT(true)) { e.Cancel = true; }
        //    else
        //    {
        //        MessageBox.Show("Bạn đã lưu lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
        //    }
        //}

        //private void grdDangKiDienTich_DeletingRecords(object sender, CancelEventArgs e)
        //{
            
        //}

        //private void grdDangKiDienTich_UpdatingRecord(object sender, CancelEventArgs e)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(this.grdDangKiDienTich.GetValue("ID").ToString()))
        //        {
        //            if (!SaveDKDT(true)) { e.Cancel = true; }
        //            else
        //            {
        //                MessageBox.Show("Bạn đã lưu lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            }
        //        }
        //        else
        //        {
        //            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //            {
        //                if (!SaveDKDT(false)) { e.Cancel = true; }
        //                else
        //                {
        //                    MessageBox.Show("Bạn đã sửa lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //                }
        //            }
        //            else
        //            {
        //                e.Cancel = true;
        //                LoadDangkyDienTich();
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        //oDKDT = new clsDangkiDienTich();
        //    }
            
            
        //}

        //private bool SaveDKDT(bool isAddNew)
        //{
        //    try
        //    {
        //        if (isAddNew)
        //        {
        //            oDKDT = new clsDangkiDienTich();
        //            oDKDT.ThuaRuongID = long.Parse(this.grdDangKiDienTich.GetValue("IDThuaRuong").ToString());                 
                    
        //        }
        //        else
        //        {
        //            oDKDT.Load(null, null);
        //        }
        //        oDKDT.HopDongID = long.Parse(uiComboBoxMaChuHo.SelectedValue.ToString());                
        //        oDKDT.MucDichDangKy = this.grdDangKiDienTich.GetValue("MucDichDangKy").ToString();
        //        oDKDT.RaiVuDangKyID = long.Parse(this.grdDangKiDienTich.GetValue("RaiVuDangKyID").ToString());
        //        oDKDT.DienTichDangKy = float.Parse(this.grdDangKiDienTich.GetValue("DienTichDangKy").ToString());
        //        oDKDT.GhiChu = this.grdDangKiDienTich.GetValue("GhiChu").ToString();
        //        oDKDT.ThoiGianDangKyThucHien = DateTime.Parse(this.grdDangKiDienTich.GetValue("ThoiGianDangKyThucHien").ToString());              

        //        oDKDT.Save(null, null);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }
        //}

        //private void grdDangKiDienTich_DeletingRecord(object sender, RowActionCancelEventArgs e)
        //{
        //    string message;
        //    message = String.Format("Bạn muốn xóa bản ghi này?");

        //    if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        DataRowView dr = (DataRowView)e.Row.DataRow;
        //        clsDangkiDienTich oDKDT = new clsDangkiDienTich(long.Parse(dr.Row.ItemArray[0].ToString()));
        //        oDKDT.Delete(null, null);
        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //    }
        //}
        #endregion
    }
}