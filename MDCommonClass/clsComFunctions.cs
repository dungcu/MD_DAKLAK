using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using System.Data;
using Janus.Windows.GridEX;
using Janus.Windows.EditControls;
namespace MDSolution
{
    public class clsComFunctions
    {
        public static string ConvertToEngland(string strVNDatatime)
        {
            string strENDateTime = strVNDatatime;
            string ngay, thang;
            if (!string.IsNullOrEmpty(strENDateTime))
            {
                ngay = strENDateTime.Substring(0, strENDateTime.IndexOf("/"));
                strENDateTime = strENDateTime.Substring(strENDateTime.IndexOf("/") + 1);
                thang = strENDateTime.Substring(0, strENDateTime.IndexOf("/"));
                strENDateTime = thang + "/" + ngay + strENDateTime.Substring(strENDateTime.IndexOf("/"));
            }
            return strENDateTime;
        }
        public static string HoTen_Format(string s)
        {
            string Result = "";
            string[] temp = s.Trim().Split(' ');
            foreach (string item in temp)
            {
                Result += item[0].ToString().ToUpper() + item.Substring(1) + " ";
            }
            return Result.Trim();
        }

        public static bool isNumber(string s)
        {
            bool result = true;
            double t = -1;
            try
            {
                t = double.Parse(s);
            }
            catch
            {
                t = -1;
            }
            if (t < 0)
            {
                result = false;
            }
            return result;
        }

        private const string cryptoKey = "md2008";

        // The Initialization Vector for the DES encryption routine
        private static readonly byte[] IV =
            new byte[8] { 240, 39, 45, 29, 0, 76, 173, 64 };

        public static string Encrypt(string s)
        {
            if (s == null || s.Length == 0) return string.Empty;

            string result = string.Empty;

            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(s);

                TripleDESCryptoServiceProvider des =
                    new TripleDESCryptoServiceProvider();

                MD5CryptoServiceProvider MD5 =
                    new MD5CryptoServiceProvider();

                des.Key =
                    MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                des.IV = IV;
                result = Convert.ToBase64String(
                    des.CreateEncryptor().TransformFinalBlock(
                        buffer, 0, buffer.Length));
            }
            catch
            {
                throw;
            }

            return result.Replace('=', '@');
        }

        /// <summary>
        /// Decrypts provided string parameter
        /// </summary>
        public static string Decrypt(string s)
        {
            s = s.Replace('@', '=');
            if (s == null || s.Length == 0) return string.Empty;

            string result = string.Empty;

            try
            {
                byte[] buffer = Convert.FromBase64String(s);

                TripleDESCryptoServiceProvider des =
                    new TripleDESCryptoServiceProvider();

                MD5CryptoServiceProvider MD5 =
                    new MD5CryptoServiceProvider();

                des.Key =
                    MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                des.IV = IV;

                result = Encoding.ASCII.GetString(
                    des.CreateDecryptor().TransformFinalBlock(
                    buffer, 0, buffer.Length));
            }
            catch
            {
                throw;
            }

            return result;
        }


        //All fucntion for set permission
        //public static DataSet controlsExcludeSet; 

        public static int insertControls(string strText, string strCtlName, string strCtlType, int parentid, string ctlForm = "", string ctlGroup = "", int isExclude = 0)
        {
            //Check exist
            int iD = 0;
            string sql;

            sql = "SELECT ID FROM sys_Controls WHERE ctlName = N'" + strCtlName + "'";
            int.TryParse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null), out iD);
            if (iD == 0)
            {
                sql = "INSERT INTO sys_Controls (ctlText, ctlName,ctlType, parentid,ctlForm) VALUES(N'" + strText.ToLowerInvariant() + "',N'" + strCtlName + "','" + strCtlType + "'," + parentid + ",'" + ctlForm + "')";
                MDSolutionEntities.DBModule.ExecuteNonQuery(sql, null, null);
                sql = "SELECT IDENT_CURRENT('sys_Controls')";
                int.TryParse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null), out iD);
            }

            return iD;
        }

        //Controls permission check
        public static void checkControlsPermission(Control control, string frmToCheckName)
        {
            if (DACASUCO_App.checkPermissionControls)
            {
                //if(empty(List)
                clsComFunctions.checkallPermission(control, frmToCheckName);
            }
        }
        public static void checkallPermission(Control control, string frmToCheckName)
        {
            //if ((control is Button) || (control is Form) || (control is DataGrid))
            //Not check Form because it will make an serious error, we could not do anything
            if ((control is Button) || (control is DataGrid) || (control is GridEX) || (control is UIButton))
            {
                // control = (Button)control;
                if (DACASUCO_App.controlsPermissionIncludeDataSet.Contains(frmToCheckName + "." + control.Name))
                {
                    if (DACASUCO_App.User.RolesControl.Contains(frmToCheckName + "." + control.Name))
                    {
                        control.Enabled = true;
                    }
                    else
                    {
                        control.Enabled = false;
                    }
                }

            }

            if (control is MenuStrip)
            {
                foreach (ToolStripItem mnu in ((MenuStrip)control).Items)
                {
                    clsComFunctions.checkallMenuStripPermission(mnu, frmToCheckName);
                }
            }

            if (control.Enabled)
                foreach (Control child in control.Controls) clsComFunctions.checkallPermission(child, frmToCheckName);

        }
        public static void checkallMenuStripPermission(ToolStripItem tsi, string frmToCheckName)
        {
            if (DACASUCO_App.controlsPermissionIncludeDataSet.Contains(frmToCheckName + "." + tsi.Name))
            {
                if (DACASUCO_App.User.RolesControl.Contains(tsi.Name))
                    tsi.Enabled = true;
                else
                    tsi.Enabled = false;
            }
            if ((tsi is ToolStripDropDownItem) && (tsi.Enabled))
            {
                foreach (ToolStripItem child in ((ToolStripDropDownItem)tsi).DropDownItems)
                {
                    clsComFunctions.checkallMenuStripPermission(child, frmToCheckName);
                }
            }

        }

        //Init permission controls tables
        public static void init_ControlsToPermissionManage()
        {
            if (DACASUCO_App.InitControls)
            {
                //string sql = "DELETE FROM sys_Controls ";
                //MDSolutionEntities.DBModule.ExecuteNonQuery(sql, null, null);
                clsComFunctions.init_checkallControl(DACASUCO_App.MDIParent, 0, DACASUCO_App.MDIParent.Name);
                clsComFunctions.init_checkallControl(frmQuanLyHopDongTrongMia.OneInstanceFrm, 0, frmQuanLyHopDongTrongMia.OneInstanceFrm.Name);
                clsComFunctions.init_checkallControl(frmThuHoach.OneInstanceFrm, 0, frmThuHoach.OneInstanceFrm.Name);

                //clsComFunctions.checkall(frmDienTichCoCauTrong.OneInstanceFrm, 0);
                // clsComFunctions.checkall(frmQuanLyDauTuNoCu.OneInstanceFrm, 0);                
            }
        }
        public static void init_checkallMenuStrip(ToolStripItem tsi, int parentid, string frmToCheckName)
        {
            int pid = parentid;
            if (tsi.Text != "")
                pid = clsComFunctions.insertControls(tsi.Text, frmToCheckName + "." + tsi.Name, "ToolStripItem", parentid, frmToCheckName);
            if (tsi is ToolStripDropDownItem)
            {
                foreach (ToolStripItem child in ((ToolStripDropDownItem)tsi).DropDownItems)
                {
                    clsComFunctions.init_checkallMenuStrip(child, pid, frmToCheckName);
                }
            }
        }
        public static void init_checkallControl(Control control, int parentid, string frmToCheckName)
        {
            int pid = parentid;
            if ((control is Button) || (control is DataGrid) || (control is GridEX) || (control is UIButton))
            {
                // control = (Button)control;
                pid = clsComFunctions.insertControls(control.Text, frmToCheckName + "." + control.Name, control.GetType().Name, parentid, frmToCheckName);
            }

            if (control is MenuStrip)
            {
                foreach (ToolStripItem mnu in ((MenuStrip)control).Items)
                {
                    clsComFunctions.init_checkallMenuStrip(mnu, parentid, frmToCheckName);
                }
            }


            foreach (Control child in control.Controls) clsComFunctions.init_checkallControl(child, pid, frmToCheckName);

        }
        //Init permission by group name
        //public static void init_ByGroup(string ctlGroup, clsUser oUser)
        //{
        //    DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery("SELECT ctlName FROM sys_Controls WHERE ctlGroup = '" + ctlGroup + "'", null, null);
        //    string Roles = "&";
        //    if (ds.Tables.Count > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            Roles += row["ctlName"] + "&"; //DACASUCO_App.controlsPermissionIncludeDataSet.Add(.ToString());
        //        }
        //        oUser.RolesControl += Roles;
        //        oUser.Save(null, null);
        //    }

        //}
        public static string init_ByGroup(string ctlGroup)
        {
            DataSet ds = DBModule.ExecuteQuery("SELECT ctlName FROM sys_Controls WHERE ctlGroup like '%" + ctlGroup + "%'", null, null);
            string Roles = "&";
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (!Roles.Contains("&" + row["ctlName"]))
                        Roles += row["ctlName"] + "&"; //SoSuCo_App.controlsPermissionIncludeDataSet.Add(.ToString());
                }
            }
            return Roles;

        }

    }
}
