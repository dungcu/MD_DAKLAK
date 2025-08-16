
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsVatTuVanChuyen
    {
			public long ID = -1;        
			public string Ten = "";        
			public string DonViTinh = "";        
			public string GhiChu = "";        
			public long TienMat = 0;        
			public string MaVatTu = "";        
        public clsVatTuVanChuyen()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsVatTuVanChuyen(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(VatTuVanChuyen), "tbl_VatTuVanChuyen", cn, trans);
				ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsVatTuVanChuyen), "tbl_VatTuVanChuyen", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_VatTuVanChuyen" +
				"(ID,Ten,DonViTinh,GhiChu,TienMat,MaVatTu) Values(" +
					ID.ToString()+","+"N'" + MDSolutionEntities.DBModule.RefineString(Ten) + "'"+","+"N'" + MDSolutionEntities.DBModule.RefineString(DonViTinh) + "'"+","+"N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'"+","+TienMat.ToString()+","+"N'" + MDSolutionEntities.DBModule.RefineString(MaVatTu) + "'"+")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_VatTuVanChuyen set " +
					"Ten="+"N'" + MDSolutionEntities.DBModule.RefineString(Ten) + "'"+","+"DonViTinh="+"N'" + MDSolutionEntities.DBModule.RefineString(DonViTinh) + "'"+","+"GhiChu="+"N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'"+","+"TienMat="+TienMat.ToString()+","+"MaVatTu="+"N'" + MDSolutionEntities.DBModule.RefineString(MaVatTu) + "'"+
                    " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_VatTuVanChuyen", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_VatTuVanChuyen where ID=" + ID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_VatTuVanChuyen where ID=" + iID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_VatTuVanChuyen where ID=" + ID.ToString();
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
					if(!dr.IsNull("DonViTinh"))
                    DonViTinh = dr["DonViTinh"].ToString();
					if(!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
					if(!dr.IsNull("TienMat"))
                    TienMat = long.Parse(dr["TienMat"].ToString());
					if(!dr.IsNull("MaVatTu"))
                    MaVatTu = dr["MaVatTu"].ToString();
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_VatTuVanChuyen ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_VatTuVanChuyen WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
    }
}