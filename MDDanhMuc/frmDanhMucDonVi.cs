using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using Janus.Windows.GridEX;

namespace MDSolution
{
    public partial class frmDanhMucDonVi : Form
    {
        private long[] themmoi=new long[5];
        private NodeDonVi nDonVi = new NodeDonVi();
        private clsXa oXa = new clsXa();
        private clsThon oThon = new clsThon();
        private DataSet gridDataSourcegdVThon;
        private DataSet dsgdVXaSource;
        private DataSet dsgdVThonSource;
        private DataSet ddlHuyenSource;
        private DataSet ddlCumSource;
        public frmDanhMucDonVi()
        {
            InitializeComponent();
            this.LoadDDLHuyen();
            this.LoadDDLCum();
            //CommonClass.loadTreeXa(tvDonVi);
            CommonClass.LoadTreeTram(tvDonVi);
            //LoadDDLHuyen();
        }
        //public frmDanhMucDonVi(string ID)
        //{
        //    InitializeComponent();
        //      CommonClass.loadTreeXa(tvDonVi);
        //      LoadDDLHuyen();
 
        //}
        private void tvDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nDonVi = (NodeDonVi)tvDonVi.SelectedNode.Tag;
                this.LoadgdVXa();
            }
        }

        private void insertXa_to_tbl_DinhMuc()
        {
            string sql = "Select ID From tbl_Xa Where ID not in (Select XaID from tbl_DinhMucXa Where VuTrongID =" + MDSolution.DACASUCO_App.VuTrongID.ToString() + ")";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    sql = "Insert into tbl_DinhMucXa (XaID,DinhMucXa,VuTrongID) Values (" + dr["ID"].ToString() + ",0," + MDSolution.DACASUCO_App.VuTrongID.ToString() + ")";
                    MDSolutionEntities.DBModule.ExecuteNonQuery(sql, null, null);
                }
            }
          
        }

        private void tvDonVi_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nDonVi = (NodeDonVi)e.Node.Tag;
            this.LoadgdVXa();
        }
        private void LoadgdVXa()
        {
            if (nDonVi.Type == DonviTypeHD.Cum)
            {
                //dsgdVXaSource = clsXa.GetListbyWhere("", " a.ID=" + nDonVi.DonViID, "", null, null);
                //dsgdVXaSource = clsXa.GetListbyWhere("", "", "", null, null);
                //string strSQL = "Select a.*,b.Ten as Cum from tbl_Xa as a inner join tbl_Cum as b ON a.CumID = b.ID Where a.CumID=" + nDonVi.DonViID;
                string strSQL = "Select a.*,b.Ten as Cum,ISNULL(c.DinhMucXa,0) as DinhMucXa1 from tbl_Xa as a inner join tbl_Cum as b ON a.CumID = b.ID Left OUTER join tbl_DinhMucXa as c on a.ID = c.XaID Where a.CumID=" + nDonVi.DonViID + " And VuTrongID =" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " Order By a.MaXa";
                dsgdVXaSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);

                if (dsgdVXaSource.Tables.Count > 0)
                {
                    this.gdVXa.SetDataBinding(dsgdVXaSource.Tables[0], "");
                    this.gdVXa.Tables[0].Columns["Cum"].DefaultValue = nDonVi.DonViName;
                    this.gdVXa.Tables[0].Columns["CumID"].DefaultValue = nDonVi.DonViID;
                    this.gdVXa.Tables[0].Columns["Cum"].Visible = true;
                    this.gdVXa.Tables[0].Columns["CumID"].Visible = false;
                }
            }
            else
            {
                //dsgdVXaSource = clsXa.GetListbyWhere("", "", "", null, null);
                //string strSQL = "Select * from tbl_Xa";
                string strSQL = "Select a.*,b.Ten as Cum,ISNULL(c.DinhMucXa,0) as DinhMucXa from tbl_Xa as a inner join tbl_Cum as b ON a.CumID = b.ID Left OUTER join tbl_DinhMucXa as c on a.ID = c.XaID Where c.VuTrongID =" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                dsgdVXaSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                if (dsgdVXaSource.Tables.Count > 0)
                {
                    this.gdVXa.SetDataBinding(dsgdVXaSource.Tables[0], "");
                    this.gdVXa.Tables[0].Columns["Cum"].Visible = false;
                    this.gdVXa.Tables[0].Columns["CumID"].Visible = true;
                    //this.gdVXa.Tables[0].Columns["Cum"].DefaultValue = nDonVi.DonViName;
                }
            }
        }

        private void LoadgdVThon()
        {
            try
            {
                string strSQL = "SELECT * FROM tbl_Thon Where tbl_Thon.XaID = " + oXa.ID.ToString();
                this.gridDataSourcegdVThon = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                if (this.gridDataSourcegdVThon.Tables.Count > 0)
                {
                    this.gdVThon.SetDataBinding(this.gridDataSourcegdVThon.Tables[0], "");
                }
            }
            catch
            {
                MessageBox.Show("Khi load thôn có lỗi");
            }
        }

        private bool SaveThon(bool isAddNew)
        {
            try
            {
                if (isAddNew)
                {
                    oThon = new clsThon();
                    oThon.XaID = long.Parse(this.gdVXa.GetValue("ID").ToString());
                }
                else
                {
                    oThon.ID = long.Parse(this.gdVThon.GetValue("ID").ToString());
                    oThon.Load(null, null);
                }
               
                if (string.IsNullOrEmpty(this.gdVThon.GetValue("Ten").ToString())) throw new Exception(" Bạn chưa nhập tên Thôn");
                {
                    string strThonNew = this.gdVThon.GetValue("Ten").ToString();
                    if (isAddNew || oThon.Ten != strThonNew)
                     if (IsExitingThon(strThonNew)) throw new Exception("Trong Xã này đã tồn tại tên thôn bạn vừa nhập");
                 oThon.Ten = strThonNew;
                }
                //oThon.Ten = this.gdVThon.GetValue("Ten").ToString();
                //if (IsExitingThon(oThon.Ten)) throw new Exception("Trong Xã này đã tồn tại tên thôn bạn vừa nhập");
                long dinhmucXa = long.Parse(this.gdVXa.GetValue("DinhMuc").ToString());

                
                //GridEXRow gexr = this.gdVThon.GetTotalRow();
                //long TDMThon = 0;
                //if (gexr != null && !string.IsNullOrEmpty(gexr.Cells["DinhMuc"].Value.ToString()))
                //    TDMThon = long.Parse(gexr.Cells["DinhMuc"].Value.ToString());
                //if (TDMThon > dinhmucXa) throw new Exception("Tổng định mức các Thôn trong một Xã không được lớn hơn tổng đinh mức của Xã đó");
                if (string.IsNullOrEmpty(this.gdVThon.GetValue("DinhMuc").ToString())) oThon.DinhMuc = 0;
                else oThon.DinhMuc = long.Parse(this.gdVThon.GetValue("DinhMuc").ToString());
                if (oThon.DinhMuc > dinhmucXa) throw new Exception("Định mức của Thôn không được lớn hơn định mức của Xã");
                oThon.Save(null, null);
                //if (TDMThon > dinhmucXa) throw new Exception("Tổng định mức các Thôn trong một Xã không được lớn hơn tổng đinh mức của Xã đó");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private bool SaveXa(bool isAddNew)
        {
            try
            {
                if (isAddNew)
                {
                    oXa = new clsXa();
                }
                else
                {
                    oXa.ID = long.Parse(this.gdVXa.GetValue("ID").ToString());
                    oXa.Load(null, null);
                }
                
                if (string.IsNullOrEmpty(this.gdVXa.GetValue("Ten").ToString())) throw new Exception(" Bạn chưa nhập tên Xã");
                //oXa.Ten = this.gdVXa.GetValue("Ten").ToString();
                //if (oXa.ID<0 && IsExitingXa(oXa.Ten)) throw new Exception("Tên xã này đã có trong hệ thống");   
                //if (IsExitingXa(oXa.Ten)) throw new Exception("Tên xã này đã có trong hệ thống");
               
                {
                    string strXaNew = this.gdVXa.GetValue("Ten").ToString();
                    if (isAddNew || oXa.Ten != strXaNew)
                        if (IsExitingXa(strXaNew)) throw new Exception("Tên Xã này đã có trong hệ thống");
                    oXa.Ten = strXaNew;
                }
                if (string.IsNullOrEmpty(this.gdVXa.GetValue("MaXa").ToString())) throw new Exception(" Bạn chưa nhập Mã Xã");
                //oXa.MaXa = this.gdVXa.GetValue("MaXa").ToString();
                //if (oXa.ID < 0 && IsExitingMaXa(oXa.MaXa)) throw new Exception("Mã Xã này đã có trong hệ thống");
                {
                    string strMaXaNew = this.gdVXa.GetValue("MaXa").ToString();
                    if (isAddNew || oXa.MaXa != strMaXaNew)
                        if (IsExitingMaXa(strMaXaNew)) throw new Exception("Mã Xã này đã có trong hệ thống");
                    oXa.MaXa = strMaXaNew;
                }
                if (string.IsNullOrEmpty(this.gdVXa.GetValue("HuyenID").ToString()))// throw new Exception(" Bạn chưa nhập Huyện");
                {
                    oXa.HuyenID = 0;
                }
                else
                {
                    oXa.HuyenID = long.Parse(this.gdVXa.GetValue("HuyenID").ToString());
                }

                if (string.IsNullOrEmpty(this.gdVXa.GetValue("CumID").ToString())) throw new Exception(" Bạn chưa nhập Trạm");
                oXa.CumID = long.Parse(this.gdVXa.GetValue("CumID").ToString());

                if (string.IsNullOrEmpty(this.gdVXa.GetValue("DinhMuc").ToString()))
                {
                    oXa.DinhMuc = 0;
                }
                else
                {
                    oXa.DinhMuc = long.Parse(this.gdVXa.GetValue("DinhMuc").ToString());
                }
                // save xa
                oXa.Save(null, null);
                if (NhapDinhMucXa == true)
                    AddDinhMucXa(oXa.ID.ToString(), oXa.DinhMuc.ToString());

                this.gdVXa.SetValue("ID", oXa.ID);
                // them vao tbl_thon tuong ung
                if (isAddNew)
                {
                    string strSQL = "Insert into tbl_thon (ID,Ten,XaID,DinhMuc,tt) values(" + oXa.ID + ",N'" + oXa.Ten + "'," + oXa.ID + ",0,0)";
                    MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                else
                {
                    string strSQL = "Update tbl_Thon SET Ten=N'" + oXa.Ten + "' Where ID =" + oXa.ID;
                    MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                //tvDonVi.Nodes.Clear();
                //CommonClass.loadTreeXa(tvDonVi);
                //tvDonVi.ExpandAll();                       
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void AddDinhMucXa(string XaID, string DinhMuc)
        {
            string sql = "Select ID From tbl_DinhMucXa Where XaID=" + XaID + " And VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            sql = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null);
            if (string.IsNullOrEmpty(sql))
            {
                string strSQL = "INSERT INTO tbl_DinhMucXa (XaID,DinhMucXa,VuTrongID) Values (" + XaID + "," + DinhMuc + "," + MDSolution.DACASUCO_App.VuTrongID.ToString() + ")";
                MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
            }
            else
            {
                string strSQL = "UpDate tbl_DinhMucXa Set DinhMucXa =" + DinhMuc + " Where ID=" + sql;
                MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
            }
        }
  
        private void gdVXa_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //if (IsExitingXa(oXa.Ten)) throw new Exception("Tên xã này đã có trong hệ thống");
                //string str = ()this.gdVXa.GetValue("ID");
                if (string.IsNullOrEmpty(this.gdVXa.GetValue("Ten").ToString())) throw new Exception("bạn phải nhập tên Xã");
                oXa.Ten = this.gdVXa.GetValue("Ten").ToString();
                oXa.ID = long.Parse(this.gdVXa.GetValue("ID").ToString());
                this.gdVThon.AllowAddNew = InheritableBoolean.True;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                this.gdVThon.AllowAddNew = InheritableBoolean.False;
                oXa.ID = -1;
            }
            this.LoadgdVThon();
        }             

        private bool IsExitingXa(string strXa)
        {
            
            string strSQL = "select Count (*) from tbl_Xa where 1=1";
            strSQL += " And (rTrim(lTrim([Ten])) = rTrim(lTrim(N'" + strXa + "')))";
            try
            {
                string ret = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (long.Parse(ret) > 0) return true;
                else return false;
            }
            catch
            {
                return true;
            }

        }
        private bool IsExitingThon(string strThon)
        {

            string strSQL = "select Count (*) from tbl_Thon where tbl_Thon.XaID = " + oXa.ID.ToString();
            strSQL += " And (rTrim(lTrim([Ten])) = rTrim(lTrim(N'" + strThon + "')))";
            try
            {
                string ret = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (long.Parse(ret) > 0) return true;
                else return false;
            }
            catch
            {
                return true;
            }

        }
        private bool IsExitingMaXa(string strMaxa)
        {
            string strSQL = " select Count (*) from tbl_Xa where 1=1";
            strSQL += " And (rTrim(lTrim([MaXa])) = rTrim(lTrim(N'" +strMaxa + "')))";
            try
            {
                string ret = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (long.Parse(ret) > 0) return true;
                else return false;
            }
            catch
            {
                return true;
            }
        }
       
        //private bool ThonIDinTableHopDong(long ThonID)
        //{
        //    string strSQL = "select count (*) from tbl_HopDong where 1=1";
        //    strSQL += " and ([ThonID] = " + ThonID.ToString() + ")";
        //    string strRet = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
        //    if (!string.IsNullOrEmpty(strRet))
        //        if (int.Parse(strRet) > 0)
        //            return true;
        //        else
        //            return false;
        //    else
        //    {
        //        MessageBox.Show("Thôn này đã tồn tại", "Thông báo");
        //        return false;
        //    }
        //}

        //private bool CanDeleteThon(long ThonID)
        //{
        //    if (ThonIDinTableHopDong(ThonID) == true)
        //    {
        //        MessageBox.Show("Thôn này đã có trong hợp đồng,Bạn không thể xóa", "Thông báo");
        //        return false;
        //    }
        //    else
        //        return true;


        //}

        
        private void LoadDDLHuyen()
        {
            string strSQL = "select ID, Ten from tbl_Huyen";
            this.ddlHuyenSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            this.gdVXa.DropDowns["ddlHuyen"].SetDataBinding(this.ddlHuyenSource.Tables[0], "");
        }
        private void LoadDDLCum()
        {
            string strSQL = " select * from tbl_Cum";
            this.ddlCumSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            this.gdVXa.DropDowns["ddlCum"].SetDataBinding(this.ddlCumSource.Tables[0], "");
        }

        private void gdVThon_AddingRecord(object sender, CancelEventArgs e)
        {
            
            try
            {
                if (!this.SaveThon(true))
                {
                    e.Cancel = true;
                }
                else
                {
                   // MessageBox.Show("Bạn đã lưu lại thành công");
                    this.gdVThon.SetValue("ID", oThon.ID);
                   
                }
                
            }

            catch
            {
                MessageBox.Show("Khi lưu có lỗi kiểm tra lại");
            }
      
           
        }

        private void gdVThon_RecordAdded(object sender, EventArgs e)
        {
           // MessageBox.Show("Thông báo đã lưu thành công ");
            this.gdVThon.Refetch();
        }

        private void gdVThon_RecordUpdated(object sender, EventArgs e)
        {

            MessageBox.Show("Bạn đã sửa lại thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.gdVThon.Refetch();
        }

        private void gdVThon_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {


            string message;

            message = String.Format("Chú ý: nếu đã có thông tin liên quan đến xã bạn xóa sẽ bị xóa theo. Bạn có thực sự muốn xóa bản ghi này?");

                    if (MessageBox.Show(message, " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clsThon.Delete(long.Parse(this.gdVThon.GetValue("ID").ToString()),null, null);                    }
                    else
                    {
                        e.Cancel = true;
                    }
                    
               
             
           
            
        }
 
        private void gdVThon_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
   
        }       

        private void gdVXa_AddingRecord(object sender, CancelEventArgs e)
        {
            try 
             {
                 if (!this.SaveXa(true))
                 {
                     e.Cancel = true;
                     
                 }
                 //nDonVi.DonViID = oXa.ID.ToString();

                 LoadgdVXa();
            }

            catch
            {
                MessageBox.Show("Khi lưu có lỗi kiểm tra lại");
            }
      
        }        
       
        private void gdVXa_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {

            string message;
           
                    message = String.Format("Chú ý: nếu đã có thông tin liên quan đến xã bạn xóa sẽ bị xóa theo. Bạn có thực sự muốn xóa bản ghi này?");

                    if (MessageBox.Show(message, " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {                        
                        //clsXa.Delete(long.Parse(this.gdVXa.GetValue("ID").ToString()), null, null);                   
                        clsXa oXa = new clsXa(long.Parse(this.gdVXa.GetValue("ID").ToString()));
                        oXa.Delete(null, null);

                        clsThon objThon = new clsThon(long.Parse(this.gdVXa.GetValue("ID").ToString()));
                        objThon.Delete(null, null);
                    }
                    else
                    {
                        e.Cancel = true;
                    }             
           
        }

        private void gdVXa_RecordsDeleted(object sender, EventArgs e)
        {        
           MessageBox.Show("Đã xóa thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
           //tvDonVi.Nodes.Clear();
           //CommonClass.loadTreeXa(tvDonVi);
           //tvDonVi.ExpandAll();
           //CommonClass.loadTreeXa(tvDonVi);
           LoadgdVXa();
          
        }        

        private void gdVXa_RecordAdded(object sender, EventArgs e)
        {
            //MessageBox.Show("Bạn đã thêm mới thành công");
            this.gdVXa.Refetch();
            
        }

        private void gdVXa_UpdatingRecord(object sender, CancelEventArgs e)
        {            
                if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!this.SaveXa(false))
                    {
                        e.Cancel = true;
                        this.gdVXa.Refetch();
                    }
                }
                else
                {
                    e.Cancel = true;
                    this.gdVXa.Refetch();
                }
            
            
            
            //try
            //{
            //    if (!this.SaveXa(false))
            //    {
            //        e.Cancel = true;
            //    }              
            //}

            //catch
            //{
            //    MessageBox.Show("Khi lưu có lỗi kiểm tra lại");
            //}
        }

        private void gdVThon_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!this.SaveThon(false))
                {
                    e.Cancel = true;
                    this.gdVThon.Refetch();
                }
            }
            else
            {
                e.Cancel = true;
                this.gdVThon.Refetch();
            }
            //try
            //{
            //    if (!this.SaveThon(false))
            //    {
            //        e.Cancel = true;

            //    }
            //}

            //catch
            //{
            //    MessageBox.Show("Khi lưu có lỗi kiểm tra lại");
            //}
      
        }

        private void gdVXa_RecordUpdated(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã sửa lại thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.gdVXa.Refetch();
        }

        private void frmDanhMucDonVi_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            // neu co them xa moi thi insert vao tbl_dinhmucxa de load ra gdrid
            insertXa_to_tbl_DinhMuc();
            gdVXa.Tables[0].Columns["DinhMuc"].Visible = false;
            gdVXa.Tables[0].Columns["HuyenID"].Visible = false;
        }

        //private void LoadDSXa_tbl_DinhMucXa()
        //{
        //    string sql = "Select Count(ID) From tbl_DinhMucXa Where VuTrongID =" + MDSolution.DACASUCO_App.VuTrongID.ToString();
        //    string DMxa_Rows = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null);
        //    sql = "Select Count(ID) From tbl_Xa";
        //    string Xa_Rows = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql,null,null);
        //    if (Xa_Rows != DMxa_Rows)
        //    {
        //        sql = "Delete From tbl_DinhMucXa Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();

        //    }
        //    else
        //    {

        //    }
        //}

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimXa();
            }
        }

        private void TimXa()
        {
            try
            {
                //string strSQL = "Select a.*,b.Ten as Cum,ISNULL(c.DinhMucXa,0) as DinhMucXa from tbl_Xa as a inner join tbl_Cum as b ON a.CumID = b.ID Left OUTER join tbl_DinhMucXa as c on a.ID = c.XaID Where a.CumID=" + nDonVi.DonViID + " And VuTrongID =" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                string sql = "Select a.*,b.Ten as Cum,ISNULL(c.DinhMucXa,0) as DinhMucXa from tbl_Xa as a inner join tbl_Cum as b ON a.CumID = b.ID Left OUTER join tbl_DinhMucXa as c on a.ID = c.XaID Where a.Ten Like N'%" + textBox1.Text + "%' Or a.MaXa Like N'" + textBox1.Text + "%'";
                //string sql = "Select * From tbl_Xa Where Ten like N'%" + textBox1.Text + "%' Or MaXa Like N'" + textBox1.Text + "&'";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                    gdVXa.DataSource = ds.Tables[0];
                else
                    gdVXa.DataSource = null;
            }
            catch
            {
                gdVXa.DataSource = null;
            }
        }

        private void gdVXa_CurrentCellChanging(object sender, CurrentCellChangingEventArgs e)
        {
            //if (e.Column.Key != "DinhMuc")
            //{
            //    MessageBox.Show("aaaa");
            //}
        }

        private void gdVXa_UpdatingCell(object sender, UpdatingCellEventArgs e)
        {
            if (NhapDinhMucXa == true)
            {
                if (e.Column.Key != "DinhMuc")
                {
                    MessageBox.Show("Bạn đang trong chức năng nhập định mức cho xã nên không thể thay đổi các thông tin khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    e.Value = e.InitialValue;
                    //gdVXa.Tables[0].Columns[0].
                }
            }
        }

        bool NhapDinhMucXa = false;
        private void button1_Click(object sender, EventArgs e)
        {
            NhapDinhMucXa = true;
            //gdVXa.Tables[0].Columns["DinhMucXa1"].Visible = true;
            gdVXa.Tables[0].Columns["DinhMuc"].Visible = true;
            button1.Enabled = false;
        }
       

        //private bool SaveXa(bool isNew)
        //{
        //    try
        //    {
        //        if (isNew)
        //        {
        //            oXa = new clsXa();

        //        }
        //        else
        //        {
        //            oXa.ID = long.Parse(this.gdVXa.GetValue("ID").ToString());
        //        }
        //        if (!string.IsNullOrEmpty(this.gdVXa.GetValue("Ten").ToString())) throw new Exception("bạn phải nhập tên Xã"); 
        //            oXa.Ten = this.gdVXa.GetValue("Ten").ToString();
        //        oXa.Save(null, null);
        //        return true;


        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}