
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsXa
    {
			public long ID = -1;        
			public string Ten = "";        
			public long HuyenID = -1;        
			public long CumID = -1;        
			public long DinhMuc = 0;        
			public string MaXa = "";        
			public long CuaDonVi = 0;        
        public clsXa()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsXa(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(Xa), "tbl_Xa", cn, trans);
				ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsXa), "tbl_Xa", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_Xa" +
				"(ID,Ten,HuyenID,CumID,DinhMuc,MaXa,CuaDonVi) Values(" +
					ID.ToString()+","+"N'" + MDSolutionEntities.DBModule.RefineString(Ten) + "'"+","+HuyenID.ToString()+","+CumID.ToString()+","+DinhMuc.ToString()+","+"N'" + MDSolutionEntities.DBModule.RefineString(MaXa) + "'"+","+CuaDonVi.ToString()+")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_Xa set " +
					"Ten="+"N'" + MDSolutionEntities.DBModule.RefineString(Ten) + "'"+","+"HuyenID="+HuyenID.ToString()+","+"CumID="+CumID.ToString()+","+"DinhMuc="+DinhMuc.ToString()+","+"MaXa="+"N'" + MDSolutionEntities.DBModule.RefineString(MaXa) + "'"+","+"CuaDonVi="+CuaDonVi.ToString()+
                    " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_Xa", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_Xa where ID=" + ID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_Xa where ID=" + iID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_Xa where ID=" + ID.ToString();
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
					if(!dr.IsNull("HuyenID"))
                    HuyenID = long.Parse(dr["HuyenID"].ToString());
					if(!dr.IsNull("CumID"))
                    CumID = long.Parse(dr["CumID"].ToString());
					if(!dr.IsNull("DinhMuc"))
                    DinhMuc = long.Parse(dr["DinhMuc"].ToString());
					if(!dr.IsNull("MaXa"))
                    MaXa = dr["MaXa"].ToString();
					if(!dr.IsNull("CuaDonVi"))
                    CuaDonVi = long.Parse(dr["CuaDonVi"].ToString());
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select a.*, b.ThuTu from tbl_Xa as a LEFT JOIN tbl_Cum as b ON a.CumID=b.ID Order By b.ThuTu, a.ID ";
            //if ((OrderBy != null) && (OrderBy != ""))
            //    strSQL = strSQL + " Order By b.ThuTu, a.ID ";// +MDSolutionEntities.DBModule.RefineString(OrderBy);
            
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				//if (strFields=="")strFields = "*";
				string strSQL = "SELECT a.*, b.ThuTu FROM tbl_Xa as a LEFT JOIN tbl_Cum as b ON a.CumID= b.ID WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By b.ThuTu, a.ID " ;
				return  MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
    }
}