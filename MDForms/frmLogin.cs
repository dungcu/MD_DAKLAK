using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 
using MDSolutionEntities;
using System.Net;
using Newtonsoft.Json;
using System.Linq;
using MDSolution;


namespace MDSolution
{
    public partial class frmLogin : Form        
    {
        //private string Version = "V20032013";
                
        public frmLogin()
        {
            InitializeComponent();
            LoadccbVuTrong();
        }
       
        private void LoadccbVuTrong()
        {
            try
            {
                DataSet ds;
                ds = clsVuTrong.GetListbyWhere(""," IsActive=1", "", null, null);
                if (ds.Tables.Count > 0)
                {
                    this.cboVuTrong.DataSource = ds.Tables[0];
                }
                int VTID = clsVuTrong.GetDefaultVuTrongTen(null, null);
                this.cboVuTrong.SelectedValue = VTID;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private long DangNhap(string strUserName, string strPassword)
        {   
            string strSQL = "select ID from sys_User where 1=1 and (isActive=1 OR id=1) ";
            strSQL += "  And (rTrim(lTrim([UserName])) = rTrim(lTrim(N'" + strUserName + "')))  And rTrim(lTrim([Password])) = (rTrim(lTrim(N'" + strPassword + "')))";
            //strSQL += " and UserName='" + strUsername + "' and Password='" + strPassword + "'";
            string ret = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
            if ((string.IsNullOrEmpty(ret)) || (ret == "0"))

                return 0;
            else
                return long.Parse(ret);
 
        }
        private void cmdLogin_Click(object sender, EventArgs e)
        {
           clsUser oUser = new clsUser();
            oUser.UserName = txtUser.Text.Trim();
            oUser.Password = txtPass.Text.Trim();
            oUser.ID = this.DangNhap(oUser.UserName,oUser.Password);
            if (oUser.ID!=0)
            {
                oUser.Load(null,null);
                //if (oUser.CheckVer < 0)
                //{
                //    //Check version:
                //    string sql = "select [version] from sys_version where createdate=(select max(createdate) from sys_version)";
                //    DataSet dsVer = DBModule.ExecuteQuery(sql, null, null);
                //    string Vs = dsVer.Tables[0].Rows[0]["Version"].ToString();
                //    if (!dsVer.Tables[0].Rows[0][0].ToString().Equals(this.Version))                    
                //    {
                //        MessageBox.Show("Bạn đang dùng phiên bản phần mềm " + Vs + " là phiên bản cũ!" +"\nVui lòng liên hệ với Administrator để được nâng cấp!", "SOSUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        Application.Exit();
                //    }
                    
                //}
                DACASUCO_App.User = oUser;
                DACASUCO_MAIN.strVuTrong= cboVuTrong.Text;

                DACASUCO_App.VuTrongID = long.Parse(cboVuTrong.SelectedValue.ToString());
                DACASUCO_App.TenVuTrong = cboVuTrong.Text;
                //MDSolutionAppN.iUser = MDSolutionApp.User;
                //MDSolutionAppN.iVuTrongID = MDSolutionApp.VuTrongID;
                MDSolutionEntitiesStatic.VuTrongID = DACASUCO_App.VuTrongID;
                MDSolutionEntitiesStatic.User = oUser;

                //System log machine, user, query
                string hostName = Dns.GetHostName();
                MDSolutionEntitiesStatic.HostName = JsonConvert.SerializeObject(new string[3]{hostName, Environment.UserName ,Environment.CurrentDirectory});
                IPHostEntry heserver = Dns.GetHostEntry(hostName);
                var json = JsonConvert.SerializeObject(heserver.AddressList.Select(ip => ip.ToString()).ToArray());
                MDSolutionEntitiesStatic.IPs = json;

                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "SOSUCO", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //txtUser.Text = "admin";
            //txtPass.Text = "admin1@3";
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
           
            Close();
        }
    }
}