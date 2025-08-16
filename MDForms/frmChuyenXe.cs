using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using Janus.Windows.GridEX;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.SCREventLog;
using CrystalDecisions.Shared;
namespace MDSolution
{
    public partial class frmChuyenXe : Form
    {

        string VuTrongID = MDSolution.DACASUCO_App.VuTrongID.ToString();
        DataSet DSXE = null;
        DataSet DS_CB = null;
        int CuMoi = 1;
        int SLPhieu = 0;
        //----------------------------------
        public frmChuyenXe()
        {
            InitializeComponent();

        }
        private void frmChuyenXe_Load(object sender, EventArgs e)
        {

            Load_cbChuHDVC1();
            Load_cbChuHDVC2();
          
        }


        private void Load_PhieuCan(bool MTBC)
        {
            string HTMua="";
            if (MTBC == false)
            {
                HTMua = " AND MuaTaiBanCan=0";
            }
           if (cbSoXe.SelectedIndex > 0)
            {
                string strSQL = "SELECT * FROM V_VanChuyenMia WHERE DaThanhToanVC =0 AND  XeID = " + cbSoXe.SelectedValue.ToString() + " AND VuTrongID=" +VuTrongID+ " AND HopDongVanChuyenID=" + cbChuHDVC_Di.SelectedValue.ToString() + HTMua + " Order by SoPhieuNhap ASC";
                DSXE = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                if (DSXE.Tables[0].Rows.Count > 0)
                {
                    // int i = DSXE.Tables[0].Rows.Count;
                    this.gdvChiTietVC.SetDataBinding(DSXE.Tables[0], "");
                }
                else
                {
                    this.gdvChiTietVC.DataSource = null;
                }

            }
            else
            {
                this.gdvChiTietVC.DataSource = null;
            }

        }

        private void Load_cbChuHDVC1()
        {
            try
            {
                string sql = "";
                if (txtXeVC.Text == "")
                {
                    cbChuHDVC_Di.DataSource = null;
                    sql = "Select ID,TenChuHopDong from tbl_HopDongVanChuyen Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " Order BY TenChuHopDong";
                    DS_CB = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    DataRow dr = DS_CB.Tables[0].NewRow();
                    dr["ID"] = 0;
                    dr["TenChuHopDong"] = "";
                    DS_CB.Tables[0].Rows.InsertAt(dr, 0);
                    cbChuHDVC_Di.DisplayMember = "TenChuHopDong";
                    cbChuHDVC_Di.ValueMember = "ID";
                    cbChuHDVC_Di.DataSource = DS_CB.Tables[0];
                    cbChuHDVC_Di.SelectedValue = 0;
                }
                else
                {

                    cbChuHDVC_Di.DataSource = null;
                    sql = "Select Distinct HopDongVanChuyenID,TenChuHopDong from V_TK_XeVC where SoXe Like N'%" + txtXeVC.Text + "%' AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " Order BY TenChuHopDong";
                    DS_CB = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    DataRow dr = DS_CB.Tables[0].NewRow();
                    dr["HopDongVanChuyenID"] = 0;
                    dr["TenChuHopDong"] = "";
                    DS_CB.Tables[0].Rows.InsertAt(dr, 0);
                    cbChuHDVC_Di.DisplayMember = "TenChuHopDong";
                    cbChuHDVC_Di.ValueMember = "HopDongVanChuyenID";
                    cbChuHDVC_Di.DataSource = DS_CB.Tables[0];
                    cbChuHDVC_Di.SelectedValue = 0;

                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Load_cbChuHDVC2()
        {
            try
            {
                string sql = "Select ID,TenChuHopDong from tbl_HopDongVanChuyen Where VuTrongID="+VuTrongID +" Order By TenChuHopDong ASC";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                DataRow dr = ds.Tables[0].NewRow();
                dr["ID"] = 0;
                dr["TenChuHopDong"] = "";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cbHDVC_Den.DataSource = ds.Tables[0];
                cbHDVC_Den.ValueMember = "ID";
                cbHDVC_Den.DisplayMember = "TenChuHopDong";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
      
        private void LoadXeVC()
        {
            if (cbChuHDVC_Di.SelectedIndex > 0)
            {
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery("Select ID,SoXe from tbl_XeVanChuyen Where HopDongVanChuyenID=" + cbChuHDVC_Di.SelectedValue.ToString() + " Order by SoXe", null, null);
                DataRow dr = ds.Tables[0].NewRow();
                dr["ID"] = 0;
                dr["SoXe"] = "";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cbSoXe.DataSource = ds.Tables[0];
                cbSoXe.ValueMember = "ID";
                cbSoXe.DisplayMember = "SoXe";
            }
        }

  
        private void cmd_OK_Click(object sender, EventArgs e)
        {
            if ((cbChuHDVC_Di.SelectedIndex > 0) && (cbHDVC_Den.SelectedIndex > 0))
            {
               if ((cbChuHDVC_Di.SelectedValue.ToString()) == (cbHDVC_Den.SelectedValue.ToString()))
                {
                    MessageBox.Show("Các HĐVC khi chuyển xe phải khác nhau!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbHDVC_Den.Focus();
                    return;
                }
                if (cbSoXe.SelectedIndex == 0)
                {
                    MessageBox.Show("Chưa chọn xe để chuyển!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbSoXe.Focus();
                    return;
                }

                string NgayChuyen = MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select convert(char(10),getdate(),121)", null, null);
                string Noi="";
                if(CuMoi==1)
                {
                Noi="Chạy ở HĐVC cũ";
                }
                else if (CuMoi==2)
                {
                Noi="Chạy ở HĐVC mới";
                }
                else
                {
                Noi="Chạy ở cả hai HĐVC cũ và mới";
                }
                frmChuyenXe_CF frm = new frmChuyenXe_CF(cbSoXe.Text, cbChuHDVC_Di.Text, cbHDVC_Den.Text, NgayChuyen, Noi, SLPhieu.ToString());
                frm.ShowDialog();
                if (frm.OK == 1)
                {
                    string NC1 = null; string NC2 = null;
                    if (CuMoi == 1)
                    {
                        NC2 = "'" + NgayChuyen + "'";
                        NC1 = "Null";
                    }
                    else if (CuMoi == 2)
                    {
                        NC2 = "Null";
                        NC1 = "'" + NgayChuyen + "'";
                    }
                    else
                    {
                        NC1 = "Null";
                        NC2 = "Null";
                    }
                    clsXeVanChuyen XeObj = new clsXeVanChuyen(long.Parse(cbSoXe.SelectedValue.ToString()));
                    XeObj.Load(null, null);
                    string LX = XeObj.LoaiXe;
                    string GhiChu = XeObj.GhiChu;
                    // XeObj.NKT = NC1;
                    MDSolutionEntities.DBModule.ExecuteQuery("Update tbl_XeVanChuyen Set NKT=" + NC1 + " Where ID=" + cbSoXe.SelectedValue.ToString(), null, null);
                    //XeObj.Save(null, null);
                    string sql = "Select ID from tbl_XeVanChuyen where SoXe=N'" + cbSoXe.Text + "' AND HopDongVanChuyenID=" + cbHDVC_Den.SelectedValue.ToString() + " And VuTrongID=" + VuTrongID;
                    string XeID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null);
                    if (XeID == "")
                    {
                        try
                        {
                            clsXeVanChuyen oXe = new clsXeVanChuyen();
                            oXe.SoXe = cbSoXe.Text;
                            oXe.LoaiXe = LX;
                            oXe.HopDongVanChuyenID = long.Parse(cbHDVC_Den.SelectedValue.ToString());
                            oXe.GhiChu = GhiChu;
                            oXe.VuTrongID = MDSolution.DACASUCO_App.VuTrongID;
                            // oXe.NKT = NC1;
                            oXe.Save(null, null);
                            sql = "Select ID from tbl_XeVanChuyen where SoXe=N'" + cbSoXe.Text + "' AND HopDongVanChuyenID=" + cbHDVC_Den.SelectedValue.ToString() + " And VuTrongID=" + VuTrongID;
                            string IDXe = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null);
                            MDSolutionEntities.DBModule.ExecuteQuery("Update tbl_XeVanChuyen Set NKT=" + NC2 + " Where ID=" + IDXe + " AND VuTrongID=" + VuTrongID, null, null);

                            if (SLPhieu > 0)
                            {
                                foreach (GridEXRow row in gdvChiTietVC.GetCheckedRows()) //foreach (DataRow dr in DSXE.Tables[0].Rows)
                                {
                                    sql = "Update tbl_NhapMia Set XeID=" + IDXe + ",HopDongVanChuyenID=" + cbHDVC_Den.SelectedValue.ToString() + " Where SoPhieuNhap=" + row.Cells["SoPhieuNhap"].Value.ToString() + " And VutrongID=" + VuTrongID;
                                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                                }
                            }
                            MessageBox.Show("Bạn đã chuyển xe thành công!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CuMoi = 1;
                            SLPhieu = 0;
                        }
                        catch
                        {
                            MessageBox.Show("Đã có lỗi xảy ra!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {

                        try
                        {
                            //clsXeVanChuyen oXe = new clsXeVanChuyen(long.Parse(XeID.ToString()));
                            //oXe.Load(null, null);
                            MDSolutionEntities.DBModule.ExecuteQuery("Update tbl_XeVanChuyen Set NKT=" + NC2 + " Where ID=" + XeID + " AND VuTrongID=" + VuTrongID, null, null);
                            // oXe.NKT = NC2;
                            //oXe.Save(null, null);
                            if (SLPhieu > 0)
                            {
                                foreach (GridEXRow row in gdvChiTietVC.GetCheckedRows()) //foreach (DataRow dr in DSXE.Tables[0].Rows)
                                {
                                    sql = "Update tbl_NhapMia Set XeID=" + XeID + ",HopDongVanChuyenID=" + cbHDVC_Den.SelectedValue.ToString() + " Where SoPhieuNhap=" + row.Cells["SoPhieuNhap"].Value.ToString() + " And VutrongID=" + VuTrongID;
                                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                                }
                            }
                            MessageBox.Show("Bạn đã chuyển xe thành công!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CuMoi = 1;
                            SLPhieu = 0;
                        }
                        catch
                        {
                            MessageBox.Show("Đã có lỗi xảy ra!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    //CuMoi = 1;
                    SLPhieu = 0;
                }
                
            }
            else
            {
                MessageBox.Show("Chưa khai báo đủ thông tin để chuyển xe!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Load_PhieuCan(chk_MTBC.Checked);
        }

        private void cbSoXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_PhieuCan(chk_MTBC.Checked);
        }

        private void cbChuHDVC_Di_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChuHDVC_Di.SelectedIndex > 0)
            {
                LoadXeVC();
                Load_PhieuCan(chk_MTBC.Checked);
            }
            else
            {
                cbSoXe.DataSource = null;
            }
        }

        private void chk_MTBC_CheckedChanged(object sender, EventArgs e)
        {
            Load_PhieuCan(chk_MTBC.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdCu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCu.Checked == true)
            {
                CuMoi = 1;
            }
        }

        private void rdMoi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMoi.Checked == true)
            {
                CuMoi = 2;
            }
        }

        private void rdCa2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCa2.Checked == true)
            {
                CuMoi = 3;
            }
        }

        private void gdvChiTietVC_RowCheckStateChanged(object sender,RowCheckStateChangeEventArgs e)
        { 
            int SL = 0;
            foreach (GridEXRow row in gdvChiTietVC.GetCheckedRows())
            {
                SL += 1;
            }
            SLPhieu = SL;
        }

        private void cmdTim_Click(object sender, EventArgs e)
        {
            Load_cbChuHDVC1();
        }

        private void txtXeVC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Load_cbChuHDVC1();
            }
        }

        private void txtXeVC_Click(object sender, EventArgs e)
        {
            txtXeVC.Text = "";
        }

        private void txtXeVC_TextChanged(object sender, EventArgs e)
        {
            if (txtXeVC.Text == "")
            {
                Load_cbChuHDVC1();
            }
        }

       
     
       
    }
}

    
