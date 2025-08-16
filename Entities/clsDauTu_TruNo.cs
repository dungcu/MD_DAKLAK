
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsDauTu_TruNo
    {
			public long ID = -1;        
			public long DauTuID = -1;        
			public long DuNo = 0;        
			public long LaiSuat = 0;        
			public DateTime NgayTinh = DateTime.Now;        
			public long VuTrongID = -1;        
			public long HopDongID = -1;        
			public long LaDuNoVuTruoc = 0;        
			public long NhapMiaID = -1;        
			public long HoTroID = -1;        
			public long NhapTienTraNoID = -1;        
        public clsDauTu_TruNo()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsDauTu_TruNo(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(DauTu_TruNo), "tbl_DauTu_TruNo", cn, trans);
				//ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsDauTu_TruNo), "tbl_DauTu_TruNo", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_DauTu_TruNo" +
				"(DauTuID,DuNo,LaiSuat,NgayTinh,VuTrongID,HopDongID,LaDuNoVuTruoc,NhapMiaID,HoTroID,NhapTienTraNoID) Values(" +
					DauTuID.ToString()+","+DuNo.ToString()+","+LaiSuat.ToString()+","+MDSolutionEntities.DBModule.RefineDatetime(NgayTinh)+","+VuTrongID.ToString()+","+HopDongID.ToString()+","+LaDuNoVuTruoc.ToString()+","+NhapMiaID.ToString()+","+HoTroID.ToString()+","+NhapTienTraNoID.ToString()+")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_DauTu_TruNo set " +
					"DauTuID="+DauTuID.ToString()+","+"DuNo="+DuNo.ToString()+","+"LaiSuat="+LaiSuat.ToString()+","+"NgayTinh="+MDSolutionEntities.DBModule.RefineDatetime(NgayTinh)+","+"VuTrongID="+VuTrongID.ToString()+","+"HopDongID="+HopDongID.ToString()+","+"LaDuNoVuTruoc="+LaDuNoVuTruoc.ToString()+","+"NhapMiaID="+NhapMiaID.ToString()+","+"HoTroID="+HoTroID.ToString()+","+"NhapTienTraNoID="+NhapTienTraNoID.ToString()+
                    " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_DauTu_TruNo", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_DauTu_TruNo where ID=" + ID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_DauTu_TruNo where ID=" + iID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_DauTu_TruNo where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("DauTuID"))
                    DauTuID = long.Parse(dr["DauTuID"].ToString());
					if(!dr.IsNull("DuNo"))
                    DuNo = long.Parse(dr["DuNo"].ToString());
					if(!dr.IsNull("LaiSuat"))
                    LaiSuat = long.Parse(dr["LaiSuat"].ToString());
					if(!dr.IsNull("NgayTinh"))
                    NgayTinh = DateTime.Parse(dr["NgayTinh"].ToString());
					if(!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
					if(!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());
					if(!dr.IsNull("LaDuNoVuTruoc"))
                    LaDuNoVuTruoc = long.Parse(dr["LaDuNoVuTruoc"].ToString());
					if(!dr.IsNull("NhapMiaID"))
                    NhapMiaID = long.Parse(dr["NhapMiaID"].ToString());
					if(!dr.IsNull("HoTroID"))
                    HoTroID = long.Parse(dr["HoTroID"].ToString());
					if(!dr.IsNull("NhapTienTraNoID"))
                    NhapTienTraNoID = long.Parse(dr["NhapTienTraNoID"].ToString());
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_DauTu_TruNo ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_DauTu_TruNo WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
    }
}