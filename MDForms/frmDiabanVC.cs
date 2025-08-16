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
    public partial class frmDiabanVC : Form
    {
        
        string VuTrongID = MDSolution.DACASUCO_App.VuTrongID.ToString();
        DataSet ds = null;
        DataSet ds1 = null;
        //----------------------------------
        public frmDiabanVC()
        {
            InitializeComponent();
                       
        }
        private void frmDiabanVC_Load(object sender, EventArgs e)
        {
            
            Load_cbChuHDVC();
            Load_cbTram();
            chk_All.Checked = true;
        }

        private void Load_cbTram()
        {
            string sql = "Select ID,Ten from tbl_Cum Order by Ten";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            DataRow dr = ds.Tables[0].NewRow();
            dr["ID"] = 0;
            dr["Ten"] = "";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cbTram.DataSource = ds.Tables[0];
            cbTram.ValueMember = "ID";
            cbTram.DisplayMember = "Ten";

        }
        private void Load_Avaiable(bool chk)
        {
            string strSQL = "";
            if (chk == false)
            {
                strSQL = "Select tbl_XeVanChuyen.ID as ID,tbl_XeVanChuyen.SoXe as SoXe, tbl_XeVanChuyen.LoaiXe as LoaiXe,tbl_HopDongVanChuyen.TenChuHopDong as ChuHDVC,tbl_HopDongVanChuyen.MaHopDong as MaHopDong"
                    +" FROM dbo.tbl_HopDongVanChuyen INNER JOIN tbl_XeVanChuyen ON tbl_HopDongVanChuyen.ID = tbl_XeVanChuyen.HopDongVanChuyenID"
                    + " Where (TramID = -1 OR TramID is null) AND tbl_XeVanChuyen.NKT is NULL AND tbl_XeVanChuyen.HopDongVanChuyenID=" + cbChuHDVC.SelectedValue.ToString()+" AND tbl_XeVanChuyen.VuTrongID="+VuTrongID;

            }
            else
            {
                strSQL = "Select tbl_XeVanChuyen.ID as ID,tbl_XeVanChuyen.SoXe as SoXe, tbl_XeVanChuyen.LoaiXe as LoaiXe,tbl_HopDongVanChuyen.TenChuHopDong as ChuHDVC,tbl_HopDongVanChuyen.MaHopDong as MaHopDong"
                    + " FROM dbo.tbl_HopDongVanChuyen INNER JOIN tbl_XeVanChuyen ON tbl_HopDongVanChuyen.ID = tbl_XeVanChuyen.HopDongVanChuyenID Where (TramID=-1 OR TramID is null) AND tbl_XeVanChuyen.NKT is NULL AND tbl_XeVanChuyen.VuTrongID="+VuTrongID;
            }
            try
            {
                ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            }
            catch
            {
                ds = null;
            }
            dgAvailable.DataSource = ds.Tables[0];
        }

        private void Load_Assigned(long TramID)
        {
            string sql = "Select tbl_XeVanChuyen.ID as ID,tbl_XeVanChuyen.SoXe as SoXe,tbl_XeVanChuyen.LoaiXe as LoaiXe,tbl_HopDongVanChuyen.TenChuHopDong as ChuHDVC,tbl_HopDongVanChuyen.MaHopDong as MaHopDong"
                    + " FROM dbo.tbl_HopDongVanChuyen INNER JOIN tbl_XeVanChuyen ON tbl_HopDongVanChuyen.ID = tbl_XeVanChuyen.HopDongVanChuyenID Where tbl_XeVanChuyen.NKT is NULL AND TramID=" + TramID.ToString() + " AND tbl_XeVanChuyen.VuTrongID=" +VuTrongID;

            try
            {
                ds1 = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            }
            catch
            {
                ds1 = null;
            }
            dgAssigned.DataSource = ds1.Tables[0];
        }

        private void Load_cbChuHDVC()
        {
            try
            {
                string sql = "Select ID,TenChuHopDong from tbl_HopDongVanChuyen Where VuTrongID="+VuTrongID+" Order By TenChuHopDong ASC";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                DataRow dr = ds.Tables[0].NewRow();
                dr["ID"] = 0;
                dr["TenChuHopDong"] = "";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cbChuHDVC.DataSource = ds.Tables[0];
                cbChuHDVC.ValueMember = "ID";
                cbChuHDVC.DisplayMember = "TenChuHopDong";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

                
        private void cmdChuyen_Click(object sender, EventArgs e)
        {

            if (cbTram.SelectedIndex == 0)
            {
                MessageBox.Show("Bạn chưa chọn Trạm để gán xe!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Refresh();
            if (dgAvailable.GetCheckedRows().LongLength < 1)
            {
                MessageBox.Show("Bạn chưa chọn Xe vận chuyển để gán!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try
            {

                foreach (GridEXRow JRA in dgAvailable.GetCheckedRows())
                {

                    string sql = "Update tbl_XeVanChuyen set TramID=" + cbTram.SelectedValue.ToString() + " Where SoXe=N'" + JRA.Cells["SoXe"].Value.ToString() + "' AND VuTrongID="+VuTrongID;
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);

                }

            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Load_Assigned(long.Parse(cbTram.SelectedValue.ToString()));
           Load_Avaiable(true);
           chk_All.Checked = true;

        }

        private void chk_All_CheckedChanged(object sender, EventArgs e)
        {
            Load_Avaiable(chk_All.Checked);
            if (chk_All.Checked) cbChuHDVC.SelectedIndex=0;
        }

        private void cbChuHDVC_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Avaiable(false);
            chk_All.Checked = false;
        }

        private void cbTram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTram.SelectedIndex > 0)
            {
                Load_Assigned(long.Parse(cbTram.SelectedValue.ToString()));
            }
        }

        private void cmdBo1_Click(object sender, EventArgs e)
        {

            this.Refresh();
           
            if (dgAssigned.GetCheckedRows().LongLength < 1)
            {
                MessageBox.Show("Bạn chưa chọn Xe vận chuyển để hủy gán!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                foreach (GridEXRow JRA in dgAssigned.GetCheckedRows())
                {

                    string sql = "Update tbl_XeVanChuyen set TramID=-1 Where SoXe=N'" + JRA.Cells["SoXe"].Value.ToString() + "' AND VuTrongID="+VuTrongID;
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);

                }
                cbChuHDVC.SelectedIndex = 0;
                chk_All.Checked = true;
            }

            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (chk_All.Checked) Load_Avaiable(true); else Load_Avaiable(false);
            Load_Assigned(long.Parse(cbTram.SelectedValue.ToString()));
        }

        private void cmd_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoXe_TextChanged(object sender, EventArgs e)
        {
           
               if (rdDaPB.Checked)
                {
                    
                        Janus.Windows.GridEX.GridEXFilterCondition con = new Janus.Windows.GridEX.GridEXFilterCondition();
                        con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(dgAssigned.RootTable.Columns["SoXe"], Janus.Windows.GridEX.ConditionOperator.Contains, txtSoXe.Text));
                        dgAssigned.RootTable.ApplyFilter(con);
                    

                }
                if (rdChuaPB.Checked)
                {
                   
                        Janus.Windows.GridEX.GridEXFilterCondition con = new Janus.Windows.GridEX.GridEXFilterCondition();
                        con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(dgAvailable.RootTable.Columns["SoXe"], Janus.Windows.GridEX.ConditionOperator.Contains, txtSoXe.Text));
                        dgAvailable.RootTable.ApplyFilter(con);
                    
                
            }
            
        }

        private void txtSoXe_Click(object sender, EventArgs e)
        {
            txtSoXe.Text = "";
        }

     
      
        }

}

    
