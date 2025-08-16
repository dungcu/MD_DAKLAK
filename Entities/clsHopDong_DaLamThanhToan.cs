
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsHopDong_DaLamThanhToan
    {
			public long ID = -1;        
			public long HopDongID = -1;        
			public long VuTrongID = -1;        
			public DateTime NgayLamThanhToan = DateTime.Now;        
        public clsHopDong_DaLamThanhToan()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsHopDong_DaLamThanhToan(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(HopDong_DaLamThanhToan), "tbl_HopDong_DaLamThanhToan", cn, trans);
				//ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsHopDong_DaLamThanhToan), "tbl_HopDong_DaLamThanhToan", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_HopDong_DaLamThanhToan" +
				"(HopDongID,VuTrongID,NgayLamThanhToan) Values(" +
					HopDongID.ToString()+","+VuTrongID.ToString()+","+MDSolutionEntities.DBModule.RefineDatetime(NgayLamThanhToan)+")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_HopDong_DaLamThanhToan set " +
					"HopDongID="+HopDongID.ToString()+","+"VuTrongID="+VuTrongID.ToString()+","+"NgayLamThanhToan="+MDSolutionEntities.DBModule.RefineDatetime(NgayLamThanhToan)+
                    " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_HopDong_DaLamThanhToan", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_HopDong_DaLamThanhToan where ID=" + ID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_HopDong_DaLamThanhToan where ID=" + iID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_HopDong_DaLamThanhToan where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());
					if(!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
					if(!dr.IsNull("NgayLamThanhToan"))
                    NgayLamThanhToan = DateTime.Parse(dr["NgayLamThanhToan"].ToString());
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_HopDong_DaLamThanhToan ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_HopDong_DaLamThanhToan WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
    }
}