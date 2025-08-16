
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class cl_CanVatTu
    {
			public long ID = -1;
            public string SoXe = "";
            public string HoTen = "";      
            public long KhachHangID = -1;        
			public long TrongLuongBiXe = 0;        
			public long TrongLuongVatTu = -1;        
			public long TongTrongLuong = 0;
            public DateTime NgayVao = DateTime.Now;        
			public string SoPhieuNhap = "";        
			public string GioNhap = "";        
			public string GioRa = "";
            public DateTime NgayRa = DateTime.Now;
            public long LoaiVatTu = 0;  
    
        public cl_CanVatTu()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public cl_CanVatTu(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save,SaveSua, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
                       
            string strSQL = "";			
			
            if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(NhapMia), "tbl_CanVatTu", cn, trans);
				ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsNhapMia), "tbl_CanVatTu", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                //string SPN = MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select Max(SophieuNhap) from tbl_CanVatTu",null,null);
                //if (SPN=="") SPN="0";
                //int SoPhieu = int.Parse(SPN)+1;
                strSQL = "Insert into tbl_CanVatTu" +
                "(ID,SoXe,KhachHangID,TrongLuongBiXe,TrongLuongVatTu,TongTrongLuong,NgayVao,GioNhap,HoTen,LoaiVatTu,Sophieunhap) Values(" +
                    ID.ToString() + ",N'" + SoXe + "'," + KhachHangID.ToString() + "," + TrongLuongBiXe.ToString() 
                    + "," + TrongLuongVatTu.ToString() + "," + TongTrongLuong.ToString() + "," 
                    + "getdate()"+ ","  + "Convert(varchar(5),getdate(),114)"  
                    + "," + "N'" + MDSolutionEntities.DBModule.RefineString(HoTen) + "'" + ","
                      +LoaiVatTu.ToString()+ ","+SoPhieuNhap+")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_CanVatTu set " +
                    "SoXe='" + SoXe + "'," + "KhachHangID=" + KhachHangID.ToString()
                    + "," + "TrongLuongBiXe=" + TrongLuongBiXe.ToString() + ","
                    + "TrongLuongVatTu=" +TrongLuongVatTu.ToString() + ","
                    + "TongTrongLuong=" + TongTrongLuong.ToString() + ","
                    + "GioRa=" + "Convert(varchar(5),getdate(),114)" + ","+
                     "NgayRa= getdate()" + "," +
                    "LoaiVatTu=" + LoaiVatTu.ToString() +
                    " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);//"Convert(varchar(5),getdate(),114)"
			/*_
			if( ID <= 0 )
				ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_CanVatTu", cn, trans));
				*/
		}
        
        
        public void SaveSua(OleDbConnection cn, OleDbTransaction trans)
		{
                       
           string strSQL = "";			
			
           strSQL = "Update tbl_CanVatTu set "
                    + "SoXe='" + SoXe + "'," 
                    + "TrongLuongBiXe=" + TrongLuongBiXe.ToString() + ","
                    + "TrongLuongVatTu=" + TrongLuongVatTu.ToString() + ","
                    + "TongTrongLuong=" + TongTrongLuong.ToString() + ","
                    + "GioNhap=" + MDSolutionEntities.DBModule.RefineDatetime(GioNhap)+","
                    +"NgayVao="+MDSolutionEntities.DBModule.RefineDatetime(NgayVao)+","
                    + "GioRa=" + MDSolutionEntities.DBModule.RefineDatetime(GioRa) + "," 
                    + "NgayRa=" + MDSolutionEntities.DBModule.RefineDatetime(NgayRa)+ "," 
                    + "LoaiVatTu=" + LoaiVatTu.ToString()+","
                    +"HoTen=N'"+HoTen+"'"
                    + " Where ID = " + ID.ToString();
		
		   MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_CanVatTu where ID=" + ID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_CanVatTu where ID=" + iID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_CanVatTu where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                    if (!dr.IsNull("SoXe"))
                    SoXe = dr["SoXe"].ToString();

                if (!dr.IsNull("KhachHangID"))
                    KhachHangID = long.Parse(dr["KhachHangID"].ToString());
					if(!dr.IsNull("TrongLuongBiXe"))
                    TrongLuongBiXe = long.Parse(dr["TrongLuongBiXe"].ToString());
					if(!dr.IsNull("TrongLuongVatTu"))
                    TrongLuongVatTu = long.Parse(dr["TrongLuongVatTu"].ToString());
                if (!dr.IsNull("HoTen"))
                    HoTen = dr["HoTen"].ToString();
					if(!dr.IsNull("TongTrongLuong"))
                    TongTrongLuong = long.Parse(dr["TongTrongLuong"].ToString());
					if(!dr.IsNull("NgayVao"))
                    NgayVao = DateTime.Parse(dr["NgayVao"].ToString());
					
					if(!dr.IsNull("SoPhieuNhap"))
                    SoPhieuNhap = dr["SoPhieuNhap"].ToString();
                    
                    if (!dr.IsNull("LoaiVatTu"))
                    LoaiVatTu = long.Parse(dr["LoaiVatTu"].ToString());
					
                    if(!dr.IsNull("GioNhap"))
                    GioNhap = dr["GioNhap"].ToString();
					if(!dr.IsNull("GioRa"))
                    GioRa = dr["GioRa"].ToString();
					if(!dr.IsNull("NgayRa"))
                    NgayRa = DateTime.Parse(dr["NgayRa"].ToString());
					
			}
	
		}
        public void LoadThongTinPhieuNhap(OleDbConnection cn, OleDbTransaction trans)
        {
            string sql = "Select * from tbl_CanVatTu order by NgayVao DESC ";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, cn, trans);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("SoXe"))
                    SoXe = dr["SoXe"].ToString();
                if (!dr.IsNull("KhachHangID"))
                    KhachHangID = long.Parse(dr["KhachHangID"].ToString());
                if (!dr.IsNull("TrongLuongBiXe"))
                    TrongLuongBiXe = long.Parse(dr["TrongLuongBiXe"].ToString());
                if (!dr.IsNull("TrongLuongVatTu"))
                    TrongLuongVatTu = long.Parse(dr["TrongLuongVatTu"].ToString());
                if (!dr.IsNull("HoTen"))
                    HoTen = dr["HoTen"].ToString();
                if (!dr.IsNull("TongTrongLuong"))
                    TongTrongLuong = long.Parse(dr["TongTrongLuong"].ToString());
                if (!dr.IsNull("NgayVao"))
                    NgayVao = DateTime.Parse(dr["NgayVao"].ToString());
                if (!dr.IsNull("SoPhieuNhap"))
                    SoPhieuNhap = dr["SoPhieuNhap"].ToString();
                if (!dr.IsNull("LoaiVatTu"))
                    LoaiVatTu = long.Parse(dr["LoaiVatTu"].ToString());
                if (!dr.IsNull("LoaiVatTu"))
                    LoaiVatTu = long.Parse(dr["LoaiVatTu"].ToString());
                if (!dr.IsNull("GioNhap"))
                    GioNhap = dr["GioNhap"].ToString();
                if (!dr.IsNull("GioRa"))
                    GioRa = dr["GioRa"].ToString();
                if (!dr.IsNull("NgayRa"))
                    NgayRa = DateTime.Parse(dr["NgayRa"].ToString());

            }
        }

        public void Loadabc(string strXeID,OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";

           // strSQL = "Select * from tbl_CanVatTu where GioRa ='' AND  SoXe= N'" + strXeID + "' AND NgayVao >=N'" + DateTime.Now.AddDays(-7) + "' AND [SoPhieuNhap] In (select max([SoPhieuNhap]) from [tbl_CanVatTu] where SoXe= N'" + strXeID + "')";
            //string sqlSoLanCan = "select * from tbl_CanVatTu where GioRa =''AND SoXe = N'" + strXeID + "' AND NgayVao >= N'" + DateTime.Now.AddDays(-7) + "'";


            strSQL = "Select * from tbl_CanVatTu where (GioRa ='' or TongTrongLuong=0 or TrongLuongBiXe=0 ) AND SoXe=N'" + strXeID + "'";
            //if (ngay != "")
            //    strSQL += "AND NgayVao>=N'" + ngay + "'";

            // run SQL statement
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);            
            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("SoXe"))
                    SoXe = dr["SoXe"].ToString();
                if (!dr.IsNull("KhachHangID"))
                    KhachHangID = long.Parse(dr["KhachHangID"].ToString());
                if (!dr.IsNull("TrongLuongBiXe"))
                    TrongLuongBiXe = long.Parse(dr["TrongLuongBiXe"].ToString());
                if (!dr.IsNull("TrongLuongVatTu"))
                    TrongLuongVatTu = long.Parse(dr["TrongLuongVatTu"].ToString());
                if (!dr.IsNull("HoTen"))
                    HoTen = dr["HoTen"].ToString();
                if (!dr.IsNull("TongTrongLuong"))
                    TongTrongLuong = long.Parse(dr["TongTrongLuong"].ToString());
                if (!dr.IsNull("NgayVao"))
                    NgayVao = DateTime.Parse(dr["NgayVao"].ToString());
                if (!dr.IsNull("SoPhieuNhap"))
                    SoPhieuNhap = dr["SoPhieuNhap"].ToString();
                if (!dr.IsNull("LoaiVatTu"))
                    LoaiVatTu = long.Parse(dr["LoaiVatTu"].ToString());
                if (!dr.IsNull("LoaiVatTu"))
                    LoaiVatTu = long.Parse(dr["LoaiVatTu"].ToString());
                if (!dr.IsNull("GioNhap"))
                    GioNhap = dr["GioNhap"].ToString();
                if (!dr.IsNull("GioRa"))
                    GioRa = dr["GioRa"].ToString();
                if (!dr.IsNull("NgayRa"))
                    NgayRa = DateTime.Parse(dr["NgayRa"].ToString());

            }

        }
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_CanVatTu ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_CanVatTu WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By N'" + strOrderBy + "'";
				return  MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
       
        #endregion
    }
}