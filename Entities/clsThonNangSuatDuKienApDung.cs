
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsThonNangSuatDuKienApDung
    {
			public long ID = -1;        
			public DateTime NgayThucHien = DateTime.Now;        
			public float  NangSuatDuKien = 0;        
			public long ThonID = -1;        
			public long VuTrongID = -1;        
        public clsThonNangSuatDuKienApDung()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsThonNangSuatDuKienApDung(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(ThonNangSuatDuKienApDung), "tbl_ThonNangSuatDuKienApDung", cn, trans);
				ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsThonNangSuatDuKienApDung), "tbl_ThonNangSuatDuKienApDung", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_ThonNangSuatDuKienApDung" +
				"(ID,NgayThucHien,NangSuatDuKien,ThonID,VuTrongID) Values(" +
					ID.ToString()+","+MDSolutionEntities.DBModule.RefineDatetime(NgayThucHien)+","+NangSuatDuKien.ToString()+","+ThonID.ToString()+","+VuTrongID.ToString()+")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_ThonNangSuatDuKienApDung set " +
					"NgayThucHien="+MDSolutionEntities.DBModule.RefineDatetime(NgayThucHien)+","+"NangSuatDuKien="+NangSuatDuKien.ToString()+","+"ThonID="+ThonID.ToString()+","+"VuTrongID="+VuTrongID.ToString()+
                    " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            this.UpdateNangSuatSanLuongDuKienChoTungThuaRuong(cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_ThonNangSuatDuKienApDung", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_ThonNangSuatDuKienApDung where ID=" + ID.ToString();
			// run SQL statement
            this.NangSuatDuKien = 0;
            this.UpdateNangSuatSanLuongDuKienChoTungThuaRuong(cn, trans);
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
            clsThonNangSuatDuKienApDung oTNSDKAD = new clsThonNangSuatDuKienApDung(iID);            
            oTNSDKAD.Delete(cn, trans);		
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_ThonNangSuatDuKienApDung where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("NgayThucHien"))
                    NgayThucHien = DateTime.Parse(dr["NgayThucHien"].ToString());
					if(!dr.IsNull("NangSuatDuKien"))
                    NangSuatDuKien = float.Parse(dr["NangSuatDuKien"].ToString());
					if(!dr.IsNull("ThonID"))
                    ThonID = long.Parse(dr["ThonID"].ToString());
					if(!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_ThonNangSuatDuKienApDung ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_ThonNangSuatDuKienApDung WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
        #region extention functions
        public void UpdateNangSuatSanLuongDuKienChoTungThuaRuong( OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "sp_TinhToan_NangSuatSanLuongDuKien " + this.VuTrongID.ToString() +","+this.ThonID.ToString()+","+this.NangSuatDuKien.ToString();
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }	
        #endregion
    }
}