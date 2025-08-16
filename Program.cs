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
            try
            {
                MDSolutionEntities.DBModule.PathConfig = Application.StartupPath;
                MDSolutionEntities.DBModule.BuildDatabaseParameters();
                int check = MDSolutionEntities.DBModule.ExecuteNonQuery("SELECT ID FROM sys_User WHERE ID = 1", null, null);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                DACASUCO_App.Initialize();                
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại thiết lập kết nối với máy chủ dữ liệu", "Có lỗi khi kết nối với máy chủ dữ liệu");
                frmDataConnection frm = new frmDataConnection();
                frm.ShowDialog();                
                Application.Exit();

            }
        }
    }
}