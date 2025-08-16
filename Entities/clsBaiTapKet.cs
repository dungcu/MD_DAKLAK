
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsBaiTapKet
    {
			public long ID = -1;        
			public string TenBai = "";        
			public long ThonID = -1;
            public long XaID = -1;  
			public long KhoangCach = 0;        
			public long DonGia = 0;        
			public string GhiChu = "";        
        public clsBaiTapKet()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsBaiTapKet(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(BaiTapKet), "tbl_BaiTapKet", cn, trans);
				ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsBaiTapKet), "tbl_BaiTapKet", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_BaiTapKet" +
				"(ID,TenBai,ThonID,KhoangCach,DonGia,GhiChu,XaID) Values(" +
                    ID.ToString() + "," + "N'" + MDSolutionEntities.DBModule.RefineString(TenBai) + "'" + "," + ThonID.ToString() + "," + KhoangCach.ToString() + "," + DonGia.ToString() + "," + "N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'" + "," + XaID.ToString() + ")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_BaiTapKet set " +
					"TenBai="+"N'" + MDSolutionEntities.DBModule.RefineString(TenBai) + "'"+","+"ThonID="+ThonID.ToString()+","+"KhoangCach="+KhoangCach.ToString()+","+"DonGia="+DonGia.ToString()+","+"GhiChu="+"N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'"+","+"XaID="+XaID.ToString()+
                    " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_BaiTapKet", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_BaiTapKet where ID=" + ID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_BaiTapKet where ID=" + iID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_BaiTapKet where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("TenBai"))
                    TenBai = dr["TenBai"].ToString();
					if(!dr.IsNull("ThonID"))
                    ThonID = long.Parse(dr["ThonID"].ToString());
                    if (!dr.IsNull("XaID"))
                    XaID = long.Parse(dr["XaID"].ToString());
					if(!dr.IsNull("KhoangCach"))
                    KhoangCach = long.Parse(dr["KhoangCach"].ToString());
					if(!dr.IsNull("DonGia"))
                    DonGia = long.Parse(dr["DonGia"].ToString());
					if(!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_BaiTapKet ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_BaiTapKet WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
    }
}