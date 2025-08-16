using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MDSolutionEntities;
using System.Configuration;

namespace MDSolution
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            //frmSplashScreen splash = new frmSplashScreen();
            //splash.Show();
            //splash.Update();

            try
            {


                //Trạm ko có mạng LAN=> dùng tearmview VPN:
                //System.Diagnostics.Process[] pname = System.Diagnostics.Process.GetProcessesByName("TeamViewer");
                //if (pname.Length == 0)
                //{
                //    System.Diagnostics.Process.Start("TeamViewer8.bat");
                //    System.Threading.Thread.Sleep(3000);
                //}


                MDSolutionEntities.DBModule.PathConfig = Application.StartupPath;
                MDSolutionEntities.DBModule.BuildDatabaseParameters();
                int check = MDSolutionEntities.DBModule.ExecuteNonQuery("SELECT ID FROM sys_User WHERE ID = 1", null, null);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                DACASUCO_App.Initialize();
                //DACASUCO_App.Initialize();
                //splash.Close();
                //splash.Dispose();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại thiết lập kết nối với máy chủ dữ liệu", "Có lỗi khi kết nối với máy chủ dữ liệu");
                frmDataConnection frm = new frmDataConnection();
                frm.ShowDialog();
                //Gọi form để thực hiện lại việc kết nối với máy chủ dữ liệu
                //Kiểm tra kết quả trả về 
                //OK
                //Application.Restart();
                //ELSE
                Application.Exit();

            }
        }
    }
}