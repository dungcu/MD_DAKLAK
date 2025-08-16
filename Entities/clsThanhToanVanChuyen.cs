
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsThanhToanVanChuyen
    {
			public long ID = -1;        
			public long HongDongVanChuyenID = -1;        
			public long TongTienTamUng = 0;        
			public long TongTienVanChuyen = 0;        
			public DateTime NgayThanhToan = DateTime.Now;        
			public long VuTrongID = -1;        
			public long DotThanhToanID = -1;        
        public clsThanhToanVanChuyen()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsThanhToanVanChuyen(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(ThanhToanVanChuyen), "tbl_ThanhToanVanChuyen", cn, trans);
				ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsThanhToanVanChuyen), "tbl_ThanhToanVanChuyen", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_ThanhToanVanChuyen" +
				"(ID,HongDongVanChuyenID,TongTienTamUng,TongTienVanChuyen,NgayThanhToan,VuTrongID,DotThanhToanID) Values(" +
					ID.ToString()+","+HongDongVanChuyenID.ToString()+","+TongTienTamUng.ToString()+","+TongTienVanChuyen.ToString()+","+MDSolutionEntities.DBModule.RefineDatetime(NgayThanhToan)+","+VuTrongID.ToString()+","+DotThanhToanID.ToString()+")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_ThanhToanVanChuyen set " +
					"HongDongVanChuyenID="+HongDongVanChuyenID.ToString()+","+"TongTienTamUng="+TongTienTamUng.ToString()+","+"TongTienVanChuyen="+TongTienVanChuyen.ToString()+","+"NgayThanhToan="+MDSolutionEntities.DBModule.RefineDatetime(NgayThanhToan)+","+"VuTrongID="+VuTrongID.ToString()+","+"DotThanhToanID="+DotThanhToanID.ToString()+
                    " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_ThanhToanVanChuyen", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_ThanhToanVanChuyen where ID=" + ID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_ThanhToanVanChuyen where ID=" + iID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_ThanhToanVanChuyen where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("HongDongVanChuyenID"))
                    HongDongVanChuyenID = long.Parse(dr["HongDongVanChuyenID"].ToString());
					if(!dr.IsNull("TongTienTamUng"))
                    TongTienTamUng = long.Parse(dr["TongTienTamUng"].ToString());
					if(!dr.IsNull("TongTienVanChuyen"))
                    TongTienVanChuyen = long.Parse(dr["TongTienVanChuyen"].ToString());
					if(!dr.IsNull("NgayThanhToan"))
                    NgayThanhToan = DateTime.Parse(dr["NgayThanhToan"].ToString());
					if(!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
					if(!dr.IsNull("DotThanhToanID"))
                    DotThanhToanID = long.Parse(dr["DotThanhToanID"].ToString());
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_ThanhToanVanChuyen ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_ThanhToanVanChuyen WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
        public static DataSet GetListThanhToanVCByHopDongVanChuyenID(long mHDID, string OrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Select * from tbl_ThanhToanVanChuyen ";
            strSQL += "Where HopDongVanChuyenID = " + mHDID.ToString();
            //strSQL += "AND VuTrongID = " + VuTrongID.ToString();
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);

            return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
        }
		#endregion
    }
}