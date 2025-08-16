
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsHopDongVanChuyen
    {
			public long ID = -1;        
			public string TenChuHopDong = "";        
			public DateTime NgayHopDong = DateTime.MinValue;        
			public string DienThoai = "";        
			public string DiaChi = "";        
			public string GhiChu = "";        
			public string MaHopDong = "";
            public long VuTrongID = -1;
            public int DaTL = 0;
            public long TienTC = 0;
            public long TienCap = 0;
            public long SoSoi = 0;
            //De quan ly nguoi sua, ngay gio sua thong tin 
          
            public string NoteModify = "";
        public clsHopDongVanChuyen()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsHopDongVanChuyen(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(HopDongVanChuyen), "tbl_HopDongVanChuyen", cn, trans);
                ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsHopDongVanChuyen), "tbl_HopDongVanChuyen", cn, trans);
                //NgayTao = DateTime.Now;        
                //NgaySua = DateTime.Now;        
                // build SQL statement                
                    strSQL = "Insert into tbl_HopDongVanChuyen" +
                    "(ID,TenChuHopDong,NgayHopDong,DienThoai,DiaChi,GhiChu,MaHopDong,VuTrongID) Values(" +
                        ID.ToString() + "," + "N'" + MDSolutionEntities.DBModule.RefineString(TenChuHopDong) + "'" + "," + MDSolutionEntities.DBModule.RefineDatetime(NgayHopDong, true) + "," + "N'" + MDSolutionEntities.DBModule.RefineString(DienThoai) + "'" + "," + "N'" + MDSolutionEntities.DBModule.RefineString(DiaChi) + "'" + "," + "N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'" + "," + "N'" + MDSolutionEntities.DBModule.RefineString(MaHopDong) + "'" +
                    ", " +VuTrongID.ToString() + ")";                
            }
            else // edit object, we update old record in database
            {
                // build SQL statement				    
                //NgaySua = DateTime.Now; 
               
                    strSQL = "Update tbl_HopDongVanChuyen set " +
                        "TenChuHopDong=" + "N'" + MDSolutionEntities.DBModule.RefineString(TenChuHopDong) + "'" + "," + "NgayHopDong=" + MDSolutionEntities.DBModule.RefineDatetime(NgayHopDong, true) + "," + "DienThoai=" + "N'" + MDSolutionEntities.DBModule.RefineString(DienThoai) + "'" + "," + "DiaChi=" + "N'" + MDSolutionEntities.DBModule.RefineString(DiaChi) + "'" + "," + "GhiChu=" + "N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'" + "," + "MaHopDong=" + "N'" + MDSolutionEntities.DBModule.RefineString(MaHopDong) + "'" +
                   ", VuTrongID="+VuTrongID.ToString()+" Where ID = " + ID.ToString();
               
            }
			// run SQL statement
			
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_HopDongVanChuyen", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_HopDongVanChuyen where ID=" + ID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_HopDongVanChuyen where ID=" + iID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_HopDongVanChuyen where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("TenChuHopDong"))
                    TenChuHopDong = dr["TenChuHopDong"].ToString();
					if(!dr.IsNull("NgayHopDong"))
                    NgayHopDong = DateTime.Parse(dr["NgayHopDong"].ToString());
					if(!dr.IsNull("DienThoai"))
                    DienThoai = dr["DienThoai"].ToString();
					if(!dr.IsNull("DiaChi"))
                    DiaChi = dr["DiaChi"].ToString();
					if(!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
					if(!dr.IsNull("MaHopDong"))
                    MaHopDong = dr["MaHopDong"].ToString();
                    if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                    if (!dr.IsNull("DaTL"))
                        DaTL = int.Parse(dr["DaTL"].ToString());
                    if (!dr.IsNull("TienTC"))
                        TienTC= long.Parse(dr["TienTC"].ToString());
                    if (!dr.IsNull("TienCap"))
                        TienCap = long.Parse(dr["TienCap"].ToString());
                    if (!dr.IsNull("SoSoi"))
                        SoSoi = long.Parse(dr["SoSoi"].ToString());
			}
	
		}

        public void Load(string MaHopDong,OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_HopDongVanChuyen where MaHopDong='" + MaHopDong +"'";
            // run SQL statement
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("TenChuHopDong"))
                    TenChuHopDong = dr["TenChuHopDong"].ToString();
                if (!dr.IsNull("NgayHopDong"))
                    NgayHopDong = DateTime.Parse(dr["NgayHopDong"].ToString());
                if (!dr.IsNull("DienThoai"))
                    DienThoai = dr["DienThoai"].ToString();
                if (!dr.IsNull("DiaChi"))
                    DiaChi = dr["DiaChi"].ToString();
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("MaHopDong"))
                    MaHopDong = dr["MaHopDong"].ToString();
            }

        }
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_HopDongVanChuyen ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_HopDongVanChuyen WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
    }
}