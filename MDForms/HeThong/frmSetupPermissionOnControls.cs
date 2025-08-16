using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
using MDSolutionEntities;
using MDSolution;

namespace DACASUCO.MDForms.HeThong
{
    public partial class frmSetupPermissionOnControls : Form
    {
        private DataSet gridDataSource;
     
        public frmSetupPermissionOnControls()
        {
            InitializeComponent();
            this.LoadglvPhanQuyen();
        }
       
      
        private void LoadglvPhanQuyen()
        {
            string strSQL = "SELECT * FROM sys_Controls WHERE 1=1 ";
            
            this.gridDataSource = DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            { 
                this.gdVDMTD01.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");
             
            }
        }
        private void doSave()
        {
            
            string ctlName = "";
            int isExclude = 0;
            string ctlForm = "";
            string ctlGroup = "";
            try
            {
                gdVDMTD01.RemoveFilters();
                gdVDMTD01.Refresh();
                gdVDMTD01.MoveFirst();
                for (int i = 0; i < gdVDMTD01.RecordCount; i++)
                {
                    //ctlName = gdVDMTD01.GetValue("ctlName").ToString();
                    isExclude = int.Parse(gdVDMTD01.GetValue("isExclude").ToString());
                    ctlForm = gdVDMTD01.GetValue("ctlForm").ToString();
                    ctlGroup = gdVDMTD01.GetValue("ctlGroup").ToString();
                    ctlName = gdVDMTD01.GetValue("ctlName").ToString();
                    string sql = "UPDATE sys_Controls SET isExclude=" + isExclude.ToString() + ", ctlForm=N'" + ctlForm.ToString() + "', ctlGroup=N'" + ctlGroup + "' WHERE ctlName='" + ctlName + "'";
                    DBModule.ExecuteNonQuery(sql, null, null);

                    gdVDMTD01.MoveNext();
                }
                
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        //Hand action control
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.doSave();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //private void gdVDMTD01_UpdatingCell(object sender, Janus.Windows.GridEX.UpdatingCellEventArgs e)
        //{
        //    string Roles = "&";
        //    string ctlName = "";
        //    try
        //    {
        //        if (e.Column.Key == "isEnabled")
        //        {
        //            ctlName = this.gdVDMTD01.GetValue("ctlName").ToString();
        //            if (e.Value.ToString() == "1")
        //            {
        //                oUser.RolesControl += ctlName + "&";
        //            }
        //            else
        //            {
        //                oUser.RolesControl = oUser.RolesControl.Replace(ctlName + "&", "");
        //            }
        //            oUser.IsAdvance = 1;
        //            oUser.Save(null, null);
        //        }

        //    }
        //    catch
        //    {
        //        MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
        //    }
        //}
       
       
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //const int WM_KEYDOWN = 0x100;
            //const int WM_SYSKEYDOWN = 0x104;

            //if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            //{
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    this.doSave();                    
                    break;
                case Keys.Escape:
                    this.Close();                    
                    break;
            }
            //}
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            // Waiting();
            MDSolution.clsComFunctions.init_ControlsToPermissionManage();
            // Waited();
            MessageBox.Show("Cập nhật các controls thành công!", DACASUCO_App.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.LoadglvPhanQuyen();
        }

        private void gdVDMTD01_UpdatingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                string ctlName = gdVDMTD01.GetValue("ctlName").ToString();
                int isExclude = int.Parse(gdVDMTD01.GetValue("isExclude").ToString());
                string ctlForm = gdVDMTD01.GetValue("ctlForm").ToString();
                string ctlGroup = gdVDMTD01.GetValue("ctlGroup").ToString();
                //string ctlName = gdVDMTD01.GetValue("ctlName").ToString();
                string sql = "UPDATE sys_Controls SET isExclude=" + isExclude.ToString() + ", ctlForm=N'" + ctlForm.ToString() + "', ctlGroup=N'" + ctlGroup + "' WHERE ctlName=N'" + ctlName + "'";
                DBModule.ExecuteNonQuery(sql, null, null);
            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
