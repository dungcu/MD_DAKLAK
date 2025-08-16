using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using MDSolutionEntities;

namespace MDSolution.MDCommonClass
{
    class SysComputer
    {
        public string FingerPrint{get;set;}
        public string MachineName{get;set;}
        public string OSVersion{get;set;}
        public string UserName{get;set;}
        public string Version{get;set;}
        public string CurrentDirectory { get; set; }
        public string MDVersion { get; set; }
        
        public SysComputer() {
            this.FingerPrint = MDSolution.Security.FingerPrint.Value();
        }
        public void Save(OleDbConnection cn, OleDbTransaction trans) {
           string strSQL = "INSERT INTO sys_Computers ( FingerPrint, MachineName, OSVersion, UserName, Version, CurrentDirectory, MDVersion)"
                            + "VALUES ("
                            + "'" + DBModule.RefineString(FingerPrint) + "',"
                            + "N'" + DBModule.RefineString(MachineName) + "',"
                            + "N'" + DBModule.RefineString(OSVersion) + "',"
                            + "N'" + DBModule.RefineString(UserName) + "',"
                            + "N'" + DBModule.RefineString(Version) + "',"
                            + "N'" + DBModule.RefineString(CurrentDirectory) + "',"
                            + "N'" + DBModule.RefineString(MDVersion) + "'"       
                            + ")";
           DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Update(string iFingerPrint, string iMDVersion, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "UPDATE sys_Computers SET MDVersion = N'" + DBModule.RefineString(iMDVersion) + "'"
                             + " WHERE FingerPrint=" + "'" + DBModule.RefineString(iFingerPrint) + "'";
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(string iFingerPrint, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "DELETE FROM sys_Computers "
                             + " WHERE FingerPrint=" + "'" + DBModule.RefineString(iFingerPrint) + "'";
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static Boolean doCheck(string productVersion, OleDbConnection cn, OleDbTransaction trans)
        {
            Boolean ret = true;
            SysComputer sysCom = new SysComputer();
            //this.FingerPrint = fingerPrint;
            string strSQL = "";
            strSQL = "SELECT MDVersion FROM sys_Computers WHERE FingerPrint=N'" + sysCom.FingerPrint + "'";
            sysCom.MDVersion = DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
            if (sysCom.MDVersion == "")
            {
                sysCom.MachineName = Environment.MachineName;
                sysCom.OSVersion = Environment.OSVersion.ToString();
                sysCom.UserName = Environment.UserName;
                sysCom.Version = Environment.Version.ToString();
                sysCom.CurrentDirectory = Environment.CurrentDirectory;
                sysCom.MDVersion = productVersion;// System.Windows.Forms.Application.ProductVersion; 
                sysCom.Save(cn, trans); 
            }
            else if (sysCom.MDVersion != productVersion)
            {
                ret = false;
            }
            
            return ret;
        }
        public static void doResetVersion(OleDbConnection cn, OleDbTransaction trans)
        {

            SysComputer sysCom = new SysComputer();
            //this.FingerPrint = fingerPrint;
            string strSQL = "";
            strSQL = "UPDATE sys_Computers SET MDVersion='1.0.0.0' WHERE FingerPrint=N'" + sysCom.FingerPrint + "'";
            DBModule.ExecuteNonQuery(strSQL, cn, trans);

        }
    }
}
