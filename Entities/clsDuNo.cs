
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsDuNo
    {
			public long ID = -1;        
			public long HopDongID = -1;        
			public string VuTrong = "";        
			public long TienDuNo = 0;        
			public long LaiSuat = 0;        
			public DateTime NgayTinhLai = DateTime.Now;        
			public string DaThanhToan = "";        
			public long VuTrongID = -1;        
        public clsDuNo()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsDuNo(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(DuNo), "tbl_DuNo", cn, trans);
				ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsDuNo), "tbl_DuNo", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_DuNo" +
				"(ID,HopDongID,VuTrong,TienDuNo,LaiSuat,NgayTinhLai,DaThanhToan,VuTrongID) Values(" +
					ID.ToString()+","+HopDongID.ToString()+","+"N'" + MDSolutionEntities.DBModule.RefineString(VuTrong) + "'"+","+TienDuNo.ToString()+","+LaiSuat.ToString()+","+MDSolutionEntities.DBModule.RefineDatetime(NgayTinhLai)+","+"N'" + MDSolutionEntities.DBModule.RefineString(DaThanhToan) + "'"+","+VuTrongID.ToString()+")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_DuNo set " +
					"HopDongID="+HopDongID.ToString()+","+"VuTrong="+"N'" + MDSolutionEntities.DBModule.RefineString(VuTrong) + "'"+","+"TienDuNo="+TienDuNo.ToString()+","+"LaiSuat="+LaiSuat.ToString()+","+"NgayTinhLai="+MDSolutionEntities.DBModule.RefineDatetime(NgayTinhLai)+","+"DaThanhToan="+"N'" + MDSolutionEntities.DBModule.RefineString(DaThanhToan) + "'"+","+"VuTrongID="+VuTrongID.ToString()+
                    " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_DuNo", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_DuNo where ID=" + ID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_DuNo where ID=" + iID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_DuNo where ID=" + ID.ToString();
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
					if(!dr.IsNull("VuTrong"))
                    VuTrong = dr["VuTrong"].ToString();
					if(!dr.IsNull("TienDuNo"))
                    TienDuNo = long.Parse(dr["TienDuNo"].ToString());
					if(!dr.IsNull("LaiSuat"))
                    LaiSuat = long.Parse(dr["LaiSuat"].ToString());
					if(!dr.IsNull("NgayTinhLai"))
                    NgayTinhLai = DateTime.Parse(dr["NgayTinhLai"].ToString());
					if(!dr.IsNull("DaThanhToan"))
                    DaThanhToan = dr["DaThanhToan"].ToString();
					if(!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_DuNo ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_DuNo WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
    }
}