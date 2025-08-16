using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using Janus.Windows.GridEX;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using DACASUCO.MDForms;
using MDSolution;


namespace MDSolution
{
    public partial class frmQuanLyNguoiDung : Form
    {

        private DataSet gdVUserSource;
        private clsUser oUser = new clsUser();

        public frmQuanLyNguoiDung()
        {
            try
            {
                InitializeComponent();
                Load_ddlRoles();
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

        private void Load_ddlRoles()
        {
            DataSet ds;
            string sql = "Select ID,Ten from sys_Roles where ID >1";
            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            this.gdVUser.DropDowns["ddlRoles"].SetDataBinding(ds.Tables[0], "");
        }
        private void frmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            loadUS();
        }
        void loadUS()
        {
            LoadgdVUser();
            label1.Text = "Người dùng: " + gdVUser.GetValue("HoTen");
            label1.Text = "Tên đăng nhập:" + gdVUser.GetValue("UserName");
            string Roles = gdVUser.GetValue("Roles").ToString();
            if (Roles.Contains("MNU_DauTu"))
            {
                chk_QuanLyDauTu.Checked = true;

            }
            else
            {
                chk_QuanLyDauTu.Checked = false;
            }

            if (Roles.Contains("MNU_DienTich"))
            {
                chk_QuanLyDienTich.Checked = true;
            }
            else
            {
                chk_QuanLyDienTich.Checked = false;
            }

            if (Roles.Contains("mnu_VanChuyen"))
            {
                chk_QuanLyVanChuyen.Checked = true;
            }
            else
            {
                chk_QuanLyVanChuyen.Checked = false;
            }

            if (Roles.Contains("mnu_Thanhtoan"))
            {
                chk_ThanhToan.Checked = true;
            }
            else
            {
                chk_ThanhToan.Checked = false;
            }

            if (Roles.Contains("MNU_NhapMia"))
            {
                chk_TheoDoiNhapMia.Checked = true;
            }
            else
            {
                chk_TheoDoiNhapMia.Checked = false;
            }

            if (Roles.Contains("MNU_HeThong"))
            {

                chk_QuanTriHeThong.Checked = true;
            }
            else
            {
                chk_QuanTriHeThong.Checked = false;
            }
            if (Roles.Contains("MNU_TruongCa"))
            {

                chk_TruongCaNhapMia.Checked = true;
            }
            else
            {
                chk_TruongCaNhapMia.Checked = false;
            }
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
                // if (string.IsNullOrEmpty(this.gdVUser.GetValue("Roles").ToString())) throw new Exception("Bạn chưa phân nhóm cho người dùng");
                //ouser.Roles = long.Parse(this.gdVUser.GetValue("Roles").ToString());

                oUser.Save(null, null);
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
            //string Roles = "&";
            //int UserID = int.Parse(gdVUser.GetValue("ID").ToString());
            //if (UserID > 0)
            //{
            //    oUser.ID = UserID;
            //    oUser.Load(null, null);
            //    if (oUser.IsAdvance != 0)
            //    {
            //        DialogResult ret = MessageBox.Show("Account này đã được thay đổi quyền trong thiết lập nâng cao, bạn có muốn ghi đè quyên lên không?", " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (ret == DialogResult.Yes)
            //        {
            //            oUser.IsAdvance = 0;//remove advances
            //        }
            //        else { return; }
            //    }    

            //    string sqlStr = "Update sys_User Set RolesControl =N'' Where ID=" + UserID.ToString();
            //    MDSolutionEntities.DBModule.ExecuteNonQuery(sqlStr, null, null);
            //    if (chk_QuanLyDauTu.Checked)
            //    {
            //        Roles += "MNU_DauTu&";
            //        clsComFunctions.init_ByGroup("MNU_DauTu", oUser);
            //    }
            //    if (chk_QuanLyDienTich.Checked)
            //    {
            //        Roles += "MNU_DienTich&";
            //        clsComFunctions.init_ByGroup("MNU_DienTich", oUser);
            //    }

            //    if (chk_QuanLyVanChuyen.Checked)
            //    {
            //        Roles += "mnu_VanChuyen&";
            //        clsComFunctions.init_ByGroup("mnu_VanChuyen", oUser);
            //    }

            //    if (chk_ThanhToan.Checked)
            //    {
            //        Roles += "mnu_Thanhtoan&";
            //        clsComFunctions.init_ByGroup("MNU_DauTu", oUser);
            //    }

            //    if (chk_TheoDoiNhapMia.Checked)
            //    {
            //        Roles += "MNU_NhapMia&";
            //        clsComFunctions.init_ByGroup("MNU_NhapMia", oUser);
            //    }

            //    if (chk_QuanTriHeThong.Checked)
            //    {
            //        Roles += "MNU_HeThong&";
            //        clsComFunctions.init_ByGroup("MNU_HeThong", oUser);
            //    }

            //    if (chk_TruongCaNhapMia.Checked)
            //    {
            //        Roles += "MNU_TruongCa&";
            //        clsComFunctions.init_ByGroup("MNU_TruongCa", oUser);
            //    }

            //    if (chk_NhanVienNhapMia.Checked)
            //    {
            //        Roles += "MNU_NhanVienNhapMia";
            //        clsComFunctions.init_ByGroup("MNU_NhanVienNhapMia", oUser);
            //    }

            //    sqlStr = "Update sys_User Set Roles =N'" + Roles + "' Where ID=" + UserID.ToString();
            //    MDSolutionEntities.DBModule.ExecuteNonQuery(sqlStr, null, null);
            //    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
            //    //loadUS();
            //}
            //else
            //    MessageBox.Show("Bạn chưa chọn người dùng!", "Thông báo", MessageBoxButtons.OK);

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gdVUser_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "Người dùng: " + gdVUser.GetValue("HoTen");
                label2.Text = "Tên đăng nhập:" + gdVUser.GetValue("UserName");
                string Roles = gdVUser.GetValue("Roles").ToString();
                if (Roles.Contains("MNU_DauTu"))
                {
                    chk_QuanLyDauTu.Checked = true;

                }
                else
                {
                    chk_QuanLyDauTu.Checked = false;
                }

                if (Roles.Contains("MNU_DienTich"))
                {
                    chk_QuanLyDienTich.Checked = true;
                }
                else
                {
                    chk_QuanLyDienTich.Checked = false;
                }

                if (Roles.Contains("mnu_VanChuyen"))
                {
                    chk_QuanLyVanChuyen.Checked = true;
                }
                else
                {
                    chk_QuanLyVanChuyen.Checked = false;
                }

                if (Roles.Contains("mnu_Thanhtoan"))
                {
                    chk_ThanhToan.Checked = true;
                }
                else
                {
                    chk_ThanhToan.Checked = false;
                }

                if (Roles.Contains("MNU_NhapMia"))
                {
                    chk_TheoDoiNhapMia.Checked = true;
                }
                else
                {
                    chk_TheoDoiNhapMia.Checked = false;
                }

                if (Roles.Contains("MNU_HeThong"))
                {

                    chk_QuanTriHeThong.Checked = true;
                }
                else
                {
                    chk_QuanTriHeThong.Checked = false;
                }

                if (Roles.Contains("MNU_NhanVienNhapMia"))
                {
                    chk_NhanVienNhapMia.Checked = true;

                }
                else
                {
                    chk_NhanVienNhapMia.Checked = false;
                }

                if (Roles.Contains("MNU_TruongCa&"))
                {
                    chk_TruongCaNhapMia.Checked = true;

                }
                else
                {
                    chk_TruongCaNhapMia.Checked = false;
                }

            }
            catch { }
        }

       

        private void uiButton2_Click(object sender, EventArgs e)
        {
           // Waiting();
            
            clsComFunctions.init_ControlsToPermissionManage();
           // Waited();
            MessageBox.Show("Cập nhật các controls thành công!", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



    }
}