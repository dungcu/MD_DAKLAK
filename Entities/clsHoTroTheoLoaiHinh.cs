
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsHoTroTheoLoaiHinh
    {
			public long ID = -1;        
			public long DanhMucHoTroID = -1;        
			public DateTime NgayLamHoTro = DateTime.Now;        
			public long DonGia = 0;        
			public string GhiChu = "";        
			public long VuTrongID = -1;        
        public clsHoTroTheoLoaiHinh()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsHoTroTheoLoaiHinh(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(HoTroTheoLoaiHinh), "tbl_HoTroTheoLoaiHinh", cn, trans);
				ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsHoTroTheoLoaiHinh), "tbl_HoTroTheoLoaiHinh", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_HoTroTheoLoaiHinh" +
				"(ID,DanhMucHoTroID,NgayLamHoTro,DonGia,GhiChu,VuTrongID) Values(" +
					ID.ToString()+","+DanhMucHoTroID.ToString()+","+MDSolutionEntities.DBModule.RefineDatetime(NgayLamHoTro)+","+DonGia.ToString()+","+"N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'"+","+VuTrongID.ToString()+")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_HoTroTheoLoaiHinh set " +
					"DanhMucHoTroID="+DanhMucHoTroID.ToString()+","+"NgayLamHoTro="+MDSolutionEntities.DBModule.RefineDatetime(NgayLamHoTro)+","+"DonGia="+DonGia.ToString()+","+"GhiChu="+"N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'"+","+"VuTrongID="+VuTrongID.ToString()+
                    " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_HoTroTheoLoaiHinh", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_HoTroTheoLoaiHinh where ID=" + ID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_HoTroTheoLoaiHinh where ID=" + iID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_HoTroTheoLoaiHinh where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("DanhMucHoTroID"))
                    DanhMucHoTroID = long.Parse(dr["DanhMucHoTroID"].ToString());
					if(!dr.IsNull("NgayLamHoTro"))
                    NgayLamHoTro = DateTime.Parse(dr["NgayLamHoTro"].ToString());
					if(!dr.IsNull("DonGia"))
                    DonGia = long.Parse(dr["DonGia"].ToString());
					if(!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
					if(!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_HoTroTheoLoaiHinh ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_HoTroTheoLoaiHinh WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
    }
}