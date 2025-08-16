
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsVuTrong
    {
			public long ID = -1;        
			public string Ten = "";        
			public DateTime NgayBatDau = DateTime.Now;        
			public DateTime NgayKetThuc = DateTime.Now;        
			public long VuTruoc = 0;        
			public long IsActive = 0;        
			public long IsDefault = 0;        
        public clsVuTrong()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsVuTrong(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(VuTrong), "tbl_VuTrong", cn, trans);
				//ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsVuTrong), "tbl_VuTrong", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Select ISNULL(Max(OrderThanhToan) + 1,1) From tbl_VuTrong";
                string order = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                strSQL = "Insert into tbl_VuTrong" +
                "(Ten,NgayBatDau,NgayKetThuc,VuTruoc,IsActive,IsDefault,OrderThanhToan) Values(" +
                    "N'" + MDSolutionEntities.DBModule.RefineString(Ten) + "'" + "," + MDSolutionEntities.DBModule.RefineDatetime(NgayBatDau) + "," + MDSolutionEntities.DBModule.RefineDatetime(NgayKetThuc) + "," + VuTruoc.ToString() + "," + IsActive.ToString() + "," + IsDefault.ToString() + "," + order + ")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_VuTrong set " +
					"Ten="+"N'" + MDSolutionEntities.DBModule.RefineString(Ten) + "'"+","+"NgayBatDau="+MDSolutionEntities.DBModule.RefineDatetime(NgayBatDau)+","+"NgayKetThuc="+MDSolutionEntities.DBModule.RefineDatetime(NgayKetThuc)+","+"VuTruoc="+VuTruoc.ToString()+","+"IsActive="+IsActive.ToString()+","+"IsDefault="+IsDefault.ToString()+
                    " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
			
			if( ID <= 0 )
				ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult("SELECT Max(ID) FROM tbl_VuTrong", cn, trans));
				
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_VuTrong where ID=" + ID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_VuTrong where ID=" + iID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_VuTrong where ID=" + ID.ToString();
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
					if(!dr.IsNull("NgayBatDau"))
                    NgayBatDau = DateTime.Parse(dr["NgayBatDau"].ToString());
					if(!dr.IsNull("NgayKetThuc"))
                    NgayKetThuc = DateTime.Parse(dr["NgayKetThuc"].ToString());
					if(!dr.IsNull("VuTruoc"))
                    VuTruoc = long.Parse(dr["VuTruoc"].ToString());
					if(!dr.IsNull("IsActive"))
                    IsActive = long.Parse(dr["IsActive"].ToString());
					if(!dr.IsNull("IsDefault"))
                    IsDefault = long.Parse(dr["IsDefault"].ToString());
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_VuTrong ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_VuTrong WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
        #region Extention Functions
        public void UpdateDefault(OleDbConnection cn, OleDbTransaction trans)
        {
            if (this.IsDefault == 1)
            {
                string strSQL = "Update tbl_VuTrong Set IsDefault=0 WHERE IsDefault=1 AND ID <>" + this.ID.ToString();
                MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans); 
            }
        }
        public static string GetDefaultVuTrongTen(OleDbConnection cn, OleDbTransaction trans)
        {
            
                string strSQL = "SELECT TOP 1 Ten FROM tbl_VuTrong WHERE IsDefault=1";
                return MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
            
            
        }
        #endregion

    }
}