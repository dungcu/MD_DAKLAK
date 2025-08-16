using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms
{
    public partial class frmPermissionOnControls : Form
    {
        private long oID;
        private DataSet gridDataSource;
        private clsUser oUser;
        public frmPermissionOnControls()
        {
            InitializeComponent();
        }
        public frmPermissionOnControls(long iID)
        {
            oID = iID;
            InitializeComponent();
            this.loadTTChung();
            this.LoadglvPhanQuyen();
        }
        private void loadTTChung()
        {
            if (oID > 0)
            {
                oUser = new clsUser(oID);
                oUser.Load(null, null);
                lblUser.Text = oUser.HoTen;
            }
        }
        private void LoadglvPhanQuyen()
        {
            string txtNameFilter = this.txtNameFilter.Text;
            bool withExcludedControls = this.chkDisplayExcludeControls.Checked;
            string strSQL = "SELECT * FROM sys_Controls WHERE 1=1 ";
            if (!withExcludedControls) {
                strSQL += "AND isExclude=0";
            }
            if (txtNameFilter!="")
            {
                strSQL += "AND (ctlName like N'" + txtNameFilter + "%' OR ctlText like N'" + txtNameFilter + "%')";
            }
            this.gridDataSource = DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                foreach (DataRow row in this.gridDataSource.Tables[0].Rows)
                {
                    //DataRowView row = item as DataRowView;

                    if (row != null)
                    {
                        string ctlName = row["ctlName"].ToString();
                        if (oUser.RolesControl.Contains(ctlName))
                        {
                            row.BeginEdit();
                            row["isEnabled"] = 1;
                            row.EndEdit();
                            //row["isEnabled"] = 1;
                        }
                        // do something
                    }

                }

                // this.gdVPhanquyen.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");
                this.gdVDMTD01.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");
                //this.gdVPhanquyen.RetrieveStructure();// DataBindings();
                //gdVPhanquyen.MoveFirst();

            }
        }
        private void doSave()
        {
            string Roles = "&";
            string ctlName = "";
            int isExclude = 0;
            string ctlForm = "";
            string ctlGroup = "";
            try
            {
                gdVDMTD01.MoveFirst();
                for (int i = 0; i < gdVDMTD01.RecordCount; i++)
                {
                    ctlName = gdVDMTD01.GetValue("ctlName").ToString();
                    isExclude = int.Parse(gdVDMTD01.GetValue("isExclude").ToString());
                    ctlForm = gdVDMTD01.GetValue("ctlForm").ToString();
                    ctlGroup = gdVDMTD01.GetValue("ctlGroup").ToString();
                    ctlName = gdVDMTD01.GetValue("ctlName").ToString();
                    string sql = "UPDATE sys_Controls SET isExclude=" + isExclude.ToString() + ", ctlForm=N'" + ctlForm.ToString() + "', ctlGroup=N'" + ctlGroup + "' WHERE ctlName='" + ctlName + "'";
                    DBModule.ExecuteNonQuery(sql, null, null);

                    if (this.gdVDMTD01.GetValue("isEnabled").ToString() == "1")
                    {
                        Roles += ctlName + "&";
                    }


                    gdVDMTD01.MoveNext();
                }

                oUser.RolesControl = Roles;
                oUser.IsAdvance = 1;
                oUser.Save(null, null);
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

        private void chkDisplayExcludeControls_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadglvPhanQuyen();            
        }

        private void txtNameFilter_TextChanged(object sender, EventArgs e)
        {
            this.LoadglvPhanQuyen();
        }

       
        
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
    }
}
