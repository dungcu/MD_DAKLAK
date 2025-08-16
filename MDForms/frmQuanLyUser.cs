using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using Janus.Windows.GridEX;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using DACASUCO.MDForms;
using MDSolutionEntities;


namespace MDSolution
{
    public partial class frmQuanLyUser : Form
    {

        private DataSet gdVUserSource;
        private clsUser oUser = new clsUser();        
        private DataSet gridDataSource;
        private DataSet gridDataSourceTram;
        private long RolesID = -1;
        private int DauTu = 0;
        private int DienTich = 0;
        private int NoCu = 0;
        private int SuaCM = 0;
        private int SuaVT = 0;
        private int ThuHoach = 0;
        private int BaoCao = 0;
        private int XeVC = 0;
        public frmQuanLyUser()
        {
            try
            {
                InitializeComponent();
                //Load_ddl_VaiTro();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadgdVUser()
        {
            //try
            //{
            this.gdVUserSource = clsUser.GetListbyWhere("", " ID<>1", "", null, null);
            if (this.gdVUserSource.Tables.Count > 0)
            {
                //this.gdVXeVanChuyen.SetDataBinding(this.gdVXeVanChuyenSource.Tables[0], "");
                this.gdVUser.SetDataBinding(this.gdVUserSource.Tables[0], "");
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
       
        private void frmQuanLyUser_Load(object sender, EventArgs e)
        {
            LoadgdVUser();
            LoadglvRoles();
            LoadglvTrams();

        }
        void loadUS()
        {

            lblHoTen.Text = gdVUser.GetValue("HoTen").ToString();
            lblUser.Text = gdVUser.GetValue("UserName").ToString();
            string Roles = gdVUser.GetValue("RolesID").ToString();
            string RolesAdd = gdVUser.GetValue("RolesAdd").ToString().Trim();
            RolesID = long.Parse(Roles.ToString());
            //if (Roles=="0")
            //{
            //    rdQTHT.Checked = true;

            //}
            
            //if (Roles == "1")
            //{
            //    rdCBDB.Checked = true;
            //}

            //if (Roles == "2")
            //{
            //    rdPNL.Checked = true;
            //}

            //if (Roles == "3")
            //{
            //    rdCan.Checked = true;
            //}

            //if (Roles == "4")
            //{
            //    rdBaoMau.Checked = true;
            //}
            //if (Roles == "5")
            //{

            //    rdPTCCS.Checked = true;
            //}
            //if (Roles == "6")
            //{
            //    rdHT.Checked = true;
            //}
            //if (Roles == "7")
            //{
            //    rdNVVP.Checked = true;
            //}
            //if ((RolesAdd != "") && (RolesAdd.Length == 6))
            //{
            //    if (RolesAdd[0] == '1')
            //    {
            //        chkNhapDT.Checked = true;
            //    }
            //    else
            //    {
            //        chkNhapDT.Checked = false;
            //    }
            //    if (RolesAdd[1] == '1')
            //    {
            //        chkCapNhatDienTich.Checked = true;
            //    }
            //    else
            //    {
            //        chkCapNhatDienTich.Checked = false;
            //    }
            //    if (RolesAdd[2] == '1')
            //    {
            //        chkNoCu.Checked = true;
            //    }
            //    else
            //    {
            //        chkNoCu.Checked = false;
            //    }
            //    if (RolesAdd[3] == '1')
            //    {
            //        chkThuHoach.Checked = true;
            //    }
            //    else
            //    {
            //        chkThuHoach.Checked = false;
            //    }
            //    if (RolesAdd[4] == '1')
            //    {
            //        chkSuaCM.Checked = true;
            //    }
            //    else
            //    {
            //        chkSuaCM.Checked = false;
            //    }
            //    if (RolesAdd[5] == '1')
            //    {
            //        chkSuaPhieuVT.Checked = true;
            //    }
            //    else
            //    {
            //        chkSuaPhieuVT.Checked = false;
            //    }
            //}
            //else
            //{
            //    chkNhapDT.Checked = false;
            //    chkCapNhatDienTich.Checked = false;
            //    chkNoCu.Checked = false;
            //    chkThuHoach.Checked = false;
            //    chkSuaCM.Checked = false;
            //    chkSuaPhieuVT.Checked = false;
            //}
           
        }

        private void gdVUser_RecordAdded(object sender, EventArgs e)
        {
            //  MessageBox.Show("Đã thêm mới thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gdVUser_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gdVUser_RecordUpdated(object sender, EventArgs e)
        {
            //MessageBox.Show("Đã sửa thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gdVUser_AddingRecord(object sender, CancelEventArgs e)
        {

            if (!this.SaveOject(true))
            {

                string message;
                message = String.Format("Có lỗi khi thêm mới bản ghi,bạn có muốn tiếp tục");
                if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    gdVUser.CancelCurrentEdit();
                }
                //MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                //MessageBox.Show("Bạn !", "Thông báo");
                this.gdVUser.SetValue("ID", oUser.ID);
            }
            //if (!this.SaveOject(true))
            //{
            //    e.Cancel = true;
            //}
            //else
            //{
            //    //this.gridEX1.SetValue("ID", oBTK.ID);
            //    this.gdVUser.SetValue("ID", ouser.ID);
            //}
        }
        private bool SaveOject(bool isNew)
        {
            string str = gdVUser.GetValue("DonVi").ToString();

            //MessageBox.Show(DateTime.Parse(str).ToString());
            try
            {
                if (!isNew)
                {
                    oUser.ID = long.Parse(this.gdVUser.GetValue("ID").ToString());
                    oUser.Load(null, null);
                }
                else
                {
                    oUser = new clsUser();
                }

                if (string.IsNullOrEmpty(this.gdVUser.GetValue("HoTen").ToString())) throw new Exception("Họ tên không được để trống ");
                oUser.HoTen = gdVUser.GetValue("HoTen").ToString();
                //DataSet ds = clsUser.GetListbyWhere("count(ID)", "Username='" + gdVUser.GetValue("UserName").ToString() + "'", "", null, null);
                //if (isNew && (ds.Tables != null) && (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) > 0)) throw new Exception("User đã được dùng!");

                oUser.Password = gdVUser.GetValue("Password").ToString();
                //if (!isNew && (ouser.Password != gdVUser.GetValue("Password").ToString()))
                //{
                //    frmQuanLyNguoiDung_XacNhanPass frm = new frmQuanLyNguoiDung_XacNhanPass();
                //    frm.pass = gdVUser.GetValue("Password").ToString();
                //    frm.ShowDialog();
                //    if (frm.ok == 0) throw new Exception("Mật khẩu không khớp");
                //    ouser.Password = gdVUser.GetValue("Password").ToString();
                //}
                if (string.IsNullOrEmpty(this.gdVUser.GetValue("UserName").ToString())) throw new Exception("User name không được để trống ");
                oUser.UserName = gdVUser.GetValue("UserName").ToString();
                if (IsExistingUserName(isNew, oUser.UserName)) throw new Exception("User đã được dùng!");
                oUser.DonVi = gdVUser.GetValue("DonVi").ToString();
                oUser.isActive = 1;
                // if (string.IsNullOrEmpty(this.gdVUser.GetValue("Roles").ToString())) throw new Exception("Bạn chưa phân nhóm cho người dùng");
                //ouser.Roles = long.Parse(this.gdVUser.GetValue("Roles").ToString());

                oUser.Save(null, null);
                //loadUS();
                LoadgdVUser();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void gdVUser_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {

            string message;

            message = String.Format("Bạn muốn xóa bản ghi này?");

            if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView dr = (DataRowView)e.Row.DataRow;
                //clsUser oHD = new clsHopDong(long.Parse(dr.Row.ItemArray[0].ToString()));
                clsUser oUS = new clsUser(long.Parse(dr.Row.ItemArray[0].ToString()));
                oUS.Delete(null, null);
            }
            else
            {
                e.Cancel = true;
            }
            loadUS();

        }
        private bool IsExistingUserName(bool isAddnew, string ContractCode)
        {
            if (isAddnew)
            {
                string SQL = " select ID from sys_User where UserName = '" + ContractCode + "'";
                string ret = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else
            {
                string SQL = " select ID from sys_User where UserName = '" + ContractCode + "'";
                DataSet ds;
                ds = MDSolutionEntities.DBModule.ExecuteQuery(SQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow d13 = ds.Tables[0].Rows[0];

                    if (d13["ID"].ToString() != this.gdVUser.GetValue("ID").ToString())
                    { return true; }
                    else { return false; }
                }
                else { return false; }
            }
        }
        private void gdVUser_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!SaveOject(false)) { e.Cancel = true; }
                else
                {
                    MessageBox.Show("Bạn đã sửa lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.gdVLVDauTu.SetValue("ID", oDMDT.ID);
                }
            }
            else
            {
                e.Cancel = true;

                gdVUser.CancelCurrentEdit();
                SendKeys.SendWait("{ESC}");
            }
        }

        private void btGhiNhan_Click(object sender, EventArgs e)
        {
            string Roles = "&";
            string RolesControl = "&";
            int UserID = 0;
            try
            {
                UserID = int.Parse(gdVUser.GetValue("ID").ToString());
            }
            catch { }

            if (UserID > 0)
            {
                oUser.ID = UserID;
                oUser.Load(null, null);
                if (oUser.IsAdvance != 0)
                {
                    
                    DialogResult ret = MessageBox.Show("Account này đã được thay đổi quyền trong thiết lập nâng cao, bạn có muốn ghi đè quyên lên không?", DACASUCO_App.MessageCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ret == DialogResult.Yes)
                    {
                        oUser.IsAdvance = 0;//remove advances
                    }
                    else { return; }
                }

                string ctlGroup = "";
                try
                {
                    gdVDMTD01.MoveFirst();
                    for (int i = 0; i < gdVDMTD01.RecordCount; i++)
                    {
                        ctlGroup = gdVDMTD01.GetValue("ctlGroup").ToString();
                        if (ctlGroup != "")
                        {
                            if (this.gdVDMTD01.GetValue("isSet").ToString() == "1")
                            {
                                Roles += ctlGroup + "&";
                                RolesControl += clsComFunctions.init_ByGroup(ctlGroup);
                            }
                        }
                        gdVDMTD01.MoveNext();
                    }

                }
                catch
                {

                }
                // bổ sung RolesID

               // oUser.RolesID = long.Parse(cbNhiemVu.SelectedValue.ToString());
                oUser.Roles = Roles;
                oUser.RolesControl = RolesControl;
                oUser.Save(null, null);

                //Update trạm assign
                try
                {
                    string sql = "Delete from sys_Roles_User_Cum where UserID=" + oUser.ID.ToString();
                    DBModule.ExecuteQuery(sql, null, null);

                    gridTram.MoveFirst();
                    for (int i = 0; i < gridTram.RecordCount; i++)
                    {
                        if (this.gridTram.GetValue("isSet").ToString() == "1")
                        {
                            string TramID = this.gridTram.GetValue("ID").ToString();
                            sql = "Select Isnull(Max(ID),0)+1 as MaxID from sys_Roles_User_Cum";
                            long MaxID = long.Parse(DBModule.ExecuteQueryForOneResult(sql, null, null).ToString());
                            DBModule.ExecuteQuery("Insert Into sys_Roles_User_Cum(ID,UserID,CumID) Values(" + MaxID.ToString() + "," + oUser.ID.ToString() + "," + TramID + ")", null, null);
                        }
                        gridTram.MoveNext();
                    }

                }
                catch
                {

                }

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
                // loadUS();
            }
            else
                MessageBox.Show("Bạn chưa chọn người dùng!", "Thông báo", MessageBoxButtons.OK);





            //string IsAdvance = DauTu.ToString()+DienTich.ToString()+NoCu.ToString()+ThuHoach.ToString()+SuaCM.ToString()+SuaVT.ToString();
            
            //int UserID = int.Parse(gdVUser.GetValue("ID").ToString());
            //if (UserID > 0)
            //{
            //    try
            //    {
            //        string sqlStr = "Update sys_User Set RolesID =" + RolesID.ToString() + ",RolesAdd='"+IsAdvance+"' Where ID=" + UserID.ToString();
            //        MDSolutionEntities.DBModule.ExecuteNonQuery(sqlStr, null, null);
            //        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
            //        LoadgdVUser();
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Có lỗi xẩy ra!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
            //        return;
            //    }
            // }
            //else
            //    MessageBox.Show("Bạn chưa chọn người dùng!", "Thông báo", MessageBoxButtons.OK);

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //private void gdVUser_SelectionChanged(object sender, EventArgs e)
        //{
        //   // LoadgdVUser();
        //    try
        //    {
        //        lblHoTen.Text = gdVUser.GetValue("HoTen").ToString();
        //        lblUser.Text = gdVUser.GetValue("UserName").ToString();
        //        string Roles = gdVUser.GetValue("RolesID").ToString();
        //        string RolesAdd = gdVUser.GetValue("RolesAdd").ToString().Trim();
        //        RolesID = long.Parse(Roles.ToString());
        //        if (Roles == "0")
        //        {
        //            rdQTHT.Checked = true;

        //        }

        //        if (Roles == "1")
        //        {
        //            rdCBDB.Checked = true;
        //        }

        //        if (Roles == "2")
        //        {
        //            rdPNL.Checked = true;
        //        }

        //        if (Roles == "3")
        //        {
        //            rdCan.Checked = true;
        //        }

        //        if (Roles == "4")
        //        {
        //            rdBaoMau.Checked = true;
        //        }
        //        if (Roles == "5")
        //        {

        //            rdPTCCS.Checked = true;
        //        }
        //        if (Roles == "6")
        //        {

        //            rdHT.Checked = true;
        //        }
        //        if (Roles == "7")
        //        {

        //            rdNVVP.Checked = true;
        //        }
        //        if ((RolesAdd!= "") && (RolesAdd.Length == 6))
        //        {

        //            if (RolesAdd[0] == '1')
        //            {
        //                chkNhapDT.Checked = true;
        //            }
        //            else
        //            {
        //                chkNhapDT.Checked = false;
        //            }
        //            if (RolesAdd[1] == '1')
        //            {
        //                chkCapNhatDienTich.Checked = true;
        //            }
        //            else
        //            {
        //                chkCapNhatDienTich.Checked = false;
        //            }
        //            if (RolesAdd[2] == '1')
        //            {
        //                chkNoCu.Checked = true;
        //            }
        //            else
        //            {
        //                chkNoCu.Checked = false;
        //            }
        //            if (RolesAdd[3] == '1')
        //            {
        //                chkThuHoach.Checked = true;
        //            }
        //            else
        //            {
        //                chkThuHoach.Checked = false;
        //            }
        //            if (RolesAdd[4] == '1')
        //            {
        //                chkSuaCM.Checked = true;
        //            }
        //            else
        //            {
        //                chkSuaCM.Checked = false;
        //            }
        //            if (RolesAdd[5] == '1')
        //            {
        //                chkSuaPhieuVT.Checked = true;
        //            }
        //            else
        //            {
        //                chkSuaPhieuVT.Checked = false;
        //            }
        //        }
        //        else
        //        {
        //            chkNhapDT.Checked = false;
        //            chkCapNhatDienTich.Checked = false;
        //            chkNoCu.Checked = false;
        //            chkThuHoach.Checked = false;
        //            chkSuaCM.Checked = false;
        //            chkSuaPhieuVT.Checked = false;
        //        }
        //    }
        //    catch
        //    {
                
        //    }
        //}

      

       
        //private void rdCan_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdCan.Checked)
        //    {
        //        RolesID = 3;
        //    }
        //}

        //private void rdCBDB_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdCBDB.Checked)
        //    {
        //        RolesID = 1;
        //    }
        //}

        //private void rdPNL_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdPNL.Checked)
        //    {
        //        RolesID = 2;
        //    }
        //}

        //private void rdPTCCS_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdPTCCS.Checked)
        //    {
        //        RolesID = 5;
        //    }
        //}

        //private void rdBaoMau_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdBaoMau.Checked)
        //    {
        //        RolesID = 4;
        //    }
        //}

        //private void rdQTHT_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdQTHT.Checked)
        //    {
        //        RolesID = 0;
        //    }
        //}

        //private void rdHT_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdHT.Checked)
        //    {
        //        RolesID = 6;
        //    }
        //}

        //private void rdNVVP_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdNVVP.Checked)
        //    {
        //        RolesID = 7;
        //    }

        //}

        //private void chkNhapDT_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkNhapDT.Checked) DauTu = 1; else DauTu = 0;
        //}

        //private void chkCapNhatDienTich_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkCapNhatDienTich.Checked) DienTich = 1; else DienTich = 0;
        //}

        //private void chkNoCu_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkNoCu.Checked) NoCu = 1; else NoCu = 0;
        //}

        //private void chkThuHoach_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkThuHoach.Checked) ThuHoach = 1; else ThuHoach = 0;
        //}

        //private void chkSuaCM_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkSuaCM.Checked) SuaCM = 1; else SuaCM = 0;
        //}

        //private void chkSuaPhieuVT_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkSuaPhieuVT.Checked) SuaVT = 1; else SuaVT = 0;
        //}

        private void uiButtonControl_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.gdVUser.GetValue("ID").ToString()))
                {
                    long oID = long.Parse(this.gdVUser.GetValue("ID").ToString());

                    DACASUCO.MDForms.HeThong.frmPermissionOnControls aa = new DACASUCO.MDForms.HeThong.frmPermissionOnControls(oID);
                    aa.MdiParent = this.MdiParent;
                    aa.Show();
                }
            }
            catch
            {
                MessageBox.Show("Chọn người dùng để thiết lập quyền");
            }
        }
        private void gdVUser_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                long ID = long.Parse(this.gdVUser.GetValue("ID").ToString());
                clsUser oUser = new clsUser(ID);
                oUser.Load(null, null);
                //cbNhiemVu.SelectedValue = oUser.RolesID;
                label1.Text = "Người dùng: " + gdVUser.GetValue("HoTen");
                label2.Text = "Tên đăng nhập:" + gdVUser.GetValue("UserName");
                //LoadglvRoles();

                string Roles = gdVUser.GetValue("Roles").ToString();
                gdVDMTD01.MoveFirst();
                for (int i = 0; i < gdVDMTD01.RecordCount; i++)
                {
                    string ctlGroup = gdVDMTD01.GetValue("ctlGroup").ToString();
                    if (ctlGroup != "")
                    {
                        if (Roles.Contains(ctlGroup))
                        {
                            gdVDMTD01.SetValue("isSet", 1);
                        }
                        else
                        {
                            gdVDMTD01.SetValue("isSet", 0);
                        }
                    }
                    gdVDMTD01.MoveNext();
                }
                gdVDMTD01.Update();
                //Update gridTram
                LoadglvTrams_ReUpdate();

            }
            catch { }
            //try
            //{
            //    long ID = long.Parse(this.gdVUser.GetValue("ID").ToString());
            //    clsUser oUser = new clsUser(ID);
            //    oUser.Load(null, null);
            //    // bổ sung chức năng 

            //   // cbNhiemVu.SelectedValue = oUser.RolesID;
            //    label1.Text = "Người dùng: " + gdVUser.GetValue("HoTen");
            //    label2.Text = "Tên đăng nhập:" + gdVUser.GetValue("UserName");
            //    //LoadglvRoles();

            //    string Roles = gdVUser.GetValue("Roles").ToString();
            //    gdVDMTD01.MoveFirst();
            //    for (int i = 0; i < gdVDMTD01.RecordCount; i++)
            //    {
            //        string ctlGroup = gdVDMTD01.GetValue("ctlGroup").ToString();
            //        if (ctlGroup != "")
            //        {
            //            if (Roles.Contains(ctlGroup))
            //            {
            //                gdVDMTD01.SetValue("isSet", 1);
            //            }
            //            else
            //            {
            //                gdVDMTD01.SetValue("isSet", 0);
            //            }
            //        }
            //        gdVDMTD01.MoveNext();
            //    }
            //    gdVDMTD01.Update();
            //    //Update gridTram
            //    LoadglvTrams_ReUpdate();

            //}
            //catch { }
        }
        private void LoadglvTrams_ReUpdate()
        {
            int UserID = 0;
            try
            {
                UserID = int.Parse(gdVUser.GetValue("ID").ToString());
            }
            catch { }
            try
            {
                //----
                string SQL = " select CumID from sys_Roles_User_Cum where UserID = '" + UserID + "'";
                string strTrams = "";
                DataSet ds;
                ds = DBModule.ExecuteQuery(SQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        strTrams += "&" + dr["CumID"].ToString() + "&";
                    }
                }
                this.gridTram.MoveFirst();
                for (int i = 0; i < gridTram.RecordCount; i++)
                {
                    string TramID = "&" + gridTram.GetValue("ID").ToString() + "&";
                    if (TramID != "")
                    {
                        if (strTrams.Contains(TramID))
                        {
                            gridTram.SetValue("isSet", 1);
                        }
                        else
                        {
                            gridTram.SetValue("isSet", 0);
                        }
                    }
                    gridTram.MoveNext();
                }
                gridTram.Update();

            }
            catch
            {

            }

        }
        private void LoadglvTrams()
        {

            string strSQL = "SELECT ID, Ten, MaTram, isSet=0 FROM [tbl_TramNongVu] ";
            this.gridDataSourceTram = DBModule.ExecuteQuery(strSQL, null, null);

            if (this.gridDataSourceTram.Tables.Count > 0)
            {
                // this.gdVPhanquyen.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");

                this.gridTram.SetDataBinding(this.gridDataSourceTram.Tables[0], "RootTable");


                LoadglvTrams_ReUpdate();
                // gridTram.Update();
                //this.gdVPhanquyen.RetrieveStructure();// DataBindings();
                //gdVPhanquyen.MoveFirst();
            }
        }
        private void LoadglvRoles()
        {

            string strSQL = "SELECT ID, Ten, ctlGroup, isSet=0 FROM sys_Roles WHERE ID>1 ";
            this.gridDataSource = DBModule.ExecuteQuery(strSQL, null, null);

            if (this.gridDataSource.Tables.Count > 0)
            {
                // this.gdVPhanquyen.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");
                string Roles = gdVUser.GetValue("Roles").ToString();
                this.gdVDMTD01.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");
                gdVDMTD01.MoveFirst();
                for (int i = 0; i < gdVDMTD01.RecordCount; i++)
                {
                    string ctlGroup = gdVDMTD01.GetValue("ctlGroup").ToString();
                    if (ctlGroup != "")
                    {
                        if (Roles.Contains(ctlGroup))
                        {
                            gdVDMTD01.SetValue("isSet", 1);
                        }
                        else
                        {
                            gdVDMTD01.SetValue("isSet", 0);
                        }
                    }
                    gdVDMTD01.MoveNext();
                }
                gdVDMTD01.Update();
                //this.gdVPhanquyen.RetrieveStructure();// DataBindings();
                //gdVPhanquyen.MoveFirst();
            }
        }
       

    }
}