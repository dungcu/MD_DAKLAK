
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsTramNongVu
    {
			public long ID = -1;        
			public string Ten = "";
            public string MaTram = "";
        public clsTramNongVu()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsTramNongVu(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
            string strSQL2 = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(TramNongVu), "tbl_TramNongVu", cn, trans);
				ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsTramNongVu), "tbl_TramNongVu", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_TramNongVu" +
				"(ID,Ten,MaTram) Values(" +
					ID.ToString()+","+"N'" + MDSolutionEntities.DBModule.RefineString(Ten) + "',"+"N'" + MDSolutionEntities.DBModule.RefineString(MaTram) + "')";
                strSQL2 = "Insert into tbl_Cum" +
                "(ID,Ten,MaTram) Values(" +
                    ID.ToString() + "," + "N'" + MDSolutionEntities.DBModule.RefineString(Ten) + "'," + "N'" + MDSolutionEntities.DBModule.RefineString(MaTram) + "')";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_TramNongVu set " +
					"Ten="+"N'" + MDSolutionEntities.DBModule.RefineString(Ten) + "', "+
                    "MaTram=" + "N'" + MDSolutionEntities.DBModule.RefineString(MaTram) + "'" +
                    " Where ID = " + ID.ToString();
                strSQL2 = "Update tbl_Cum set " +
                   "Ten=" + "N'" + MDSolutionEntities.DBModule.RefineString(Ten) + "', " +
                   "MaTram=" + "N'" + MDSolutionEntities.DBModule.RefineString(MaTram) + "'" +
                   " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL2, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_TramNongVu", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
            string strSQL2 = "";
			// build SQL statement
			strSQL = "Delete from tbl_TramNongVu where ID=" + ID.ToString();
            strSQL2 = "Delete from tbl_Cum where ID=" + ID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL2, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
            string strSQL2 = "";
			// build SQL statement
			strSQL = "Delete from tbl_TramNongVu where ID=" + iID.ToString();
            strSQL2 = "Delete from tbl_Cum where ID=" + iID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL2, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_TramNongVu where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("Ten"))
                    Ten = dr["Ten"].ToString();
                    if (!dr.IsNull("MaTram"))
                        MaTram = dr["MaTram"].ToString();
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_TramNongVu ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_TramNongVu WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
    }
}