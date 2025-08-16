using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using System.IO;
using System.Xml;
namespace MDSolution
{
    public partial class frmDataConnection : Form
    {
        public frmDataConnection()
        {
            InitializeComponent();
        }

       
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDataConnection_Load(object sender, EventArgs e)
        {


        }
        #region
         XmlDocument xmlDoc = new XmlDocument();
         public void UpdateKey(string strKey, string newValue)
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            if (!KeyExists(strKey))
                throw new ArgumentNullException("Key", "<" + strKey +
                      "> does not exist in the configuration. Update failed.");
            XmlNode appSettingsNode =
               xmlDoc.SelectSingleNode("configuration/connectionStrings");
            // Attempt to locate the requested setting.

            foreach (XmlNode childNode in appSettingsNode)
            {
                if (childNode.Attributes["name"].Value == strKey)
                    childNode.Attributes["connectionString"].Value = newValue;
            }
            //xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory +"..\\..\\App.config");
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
          
        }
        public bool KeyExists(string strKey)
        {
            XmlNode appSettingsNode =
              xmlDoc.SelectSingleNode("configuration/connectionStrings");
            // Attempt to locate the requested setting.

            foreach (XmlNode childNode in appSettingsNode)
            {
                if (childNode.Attributes["name"].Value == strKey)
                    return true;
            }
            return false;
        }
         
        #endregion
        private void cmdConnect_Click(object sender, EventArgs e)
        {
            string Path = Application.StartupPath;
            if (!File.Exists(Path  + "/database.cfg"))
            {
                File.Delete(Path  + "/database.cfg");
            }

            TextWriter cfgdb = new StreamWriter(Path + "/database.cfg");

            if (txtServer.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên máy chủ!");
                return;
            }
            else
                cfgdb.WriteLine("ServerName=" + txtServer.Text);


            if (txtUser.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên người dùng!");
                return;
            }
            else
                cfgdb.WriteLine("UserName=" + txtUser.Text);
            
            cfgdb.WriteLine("Password=" + clsComFunctions.Encrypt(txtPassword.Text));
            if (txtDatabase.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên cơ sở dữ liệu!");
                return;
            }
            else
                cfgdb.WriteLine("DBName=" + txtDatabase.Text);

            cfgdb.WriteLine("DBType=SQLServer");
            cfgdb.Close();


            frmStatus frmstatus = new frmStatus();
            frmstatus.TopMost = true;
            frmstatus.Show();
            System.Threading.Thread.Sleep(1000);
            try
            {
                MDSolutionEntities.DBModule.PathConfig = Application.StartupPath;
                MDSolutionEntities.DBModule.BuildDatabaseParameters();
                
                //int check = MDSolutionEntities.DBModule.ExecuteNonQuery("SELECT count(*) FROM tbl_Tinh ", null, null);
                frmstatus.Close();
                //UpdateKey("MDSolution.Properties.Settings.MD08ConnectionString", "Provider=SQLOLEDB;Data Source=" + txtServer.Text + ";Integrated Security=SSPI;Initial Catalog=" + txtDatabase.Text + "; User ID =" + txtUser.Text + "; Password=" + txtPassword.Text + "");
                //UpdateKey("MDSolution.Properties.Settings.MDSolutionConnectionString", "Data Source=" + txtServer.Text + ";Initial Catalog=" + txtDatabase.Text + ";Persist Security Info=True;User ID=" + txtUser.Text + ";Password=" + txtPassword.Text + "");
                MessageBox.Show("Đã ghi lại cấu hình kết nối!", "Kết nối thành công!");
                //
                Close();
                Application.Restart();
            }
            catch
            {
                frmstatus.Close();
                MessageBox.Show("Kiểm tra lại thiết lập kết nối với máy chủ dữ liệu!", "Có lỗi khi kết nối với máy chủ dữ liệu!");

            }
          
        }

        private void btnTearmview_Click(object sender, EventArgs e)
        {
            try
            {
   

                System.Diagnostics.Process[] pname = System.Diagnostics.Process.GetProcessesByName("TeamViewer");
                if (pname.Length == 0)
                    System.Diagnostics.Process.Start("TeamViewer8.bat");

                //else
                //    MessageBox.Show("run");
                Close();
                Application.Restart();

            }
            catch { }

        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            if (txtServer.Text.Trim() != "" && txtDatabase.Text.Trim() != "" && txtUser.Text.Trim() != "" && txtPassword.Text.Trim() != "")
            {
                cmdConnect.Enabled = true;
            }
            else
            {
                cmdConnect.Enabled = false;
            }
        }

        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {
            if (txtServer.Text.Trim() != "" && txtDatabase.Text.Trim() != "" && txtUser.Text.Trim() != "" && txtPassword.Text.Trim() != "")
            {
                cmdConnect.Enabled = true;
            }
            else
            {
                cmdConnect.Enabled = false;
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (txtServer.Text.Trim() != "" && txtDatabase.Text.Trim() != "" && txtUser.Text.Trim() != "" && txtPassword.Text.Trim() != "")
            {
                cmdConnect.Enabled = true;
            }
            else
            {
                cmdConnect.Enabled = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtServer.Text.Trim() != "" && txtDatabase.Text.Trim() != "" && txtUser.Text.Trim() != "" && txtPassword.Text.Trim() != "")
            {
                cmdConnect.Enabled = true;
            }
            else
            {
                cmdConnect.Enabled = false;
            }
        }
    }
}