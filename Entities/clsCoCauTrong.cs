
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsCoCauTrong
    {
			public long ID = -1;        
			public long ThuaRuongID = -1;        
			public long RaiVuID = -1;        
			public long VuTrongID = -1;        
			public long GiongMiaID = -1;        
			public DateTime NgayTrong = DateTime.Now;        
			public DateTime NgayThuHoachDuKien = DateTime.Now;        
			public long NangSuatDuKien = 0;        
			public long SanLuongDuKien = 0;        
			public long VuID = -1;        
			public long DienTich = 0;        
			public long MucDichID = -1;        
			public long DienTichTrongMoi = 0;        
			public long DienTichTrongLai = 0;        
			public long DienTichPheCanh = 0;        
        public clsCoCauTrong()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsCoCauTrong(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(CoCauTrong), "tbl_CoCauTrong", cn, trans);
				ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsCoCauTrong), "tbl_CoCauTrong", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_CoCauTrong" +
				"(ID,ThuaRuongID,RaiVuID,VuTrongID,GiongMiaID,NgayTrong,NgayThuHoachDuKien,NangSuatDuKien,SanLuongDuKien,VuID,DienTich,MucDichID,DienTichTrongMoi,DienTichTrongLai,DienTichPheCanh) Values(" +
					ID.ToString()+","+ThuaRuongID.ToString()+","+RaiVuID.ToString()+","+VuTrongID.ToString()+","+GiongMiaID.ToString()+","+MDSolutionEntities.DBModule.RefineDatetime(NgayTrong)+","+MDSolutionEntities.DBModule.RefineDatetime(NgayThuHoachDuKien)+","+NangSuatDuKien.ToString()+","+SanLuongDuKien.ToString()+","+VuID.ToString()+","+DienTich.ToString()+","+MucDichID.ToString()+","+DienTichTrongMoi.ToString()+","+DienTichTrongLai.ToString()+","+DienTichPheCanh.ToString()+")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_CoCauTrong set " +
					"ThuaRuongID="+ThuaRuongID.ToString()+","+"RaiVuID="+RaiVuID.ToString()+","+"VuTrongID="+VuTrongID.ToString()+","+"GiongMiaID="+GiongMiaID.ToString()+","+"NgayTrong="+MDSolutionEntities.DBModule.RefineDatetime(NgayTrong)+","+"NgayThuHoachDuKien="+MDSolutionEntities.DBModule.RefineDatetime(NgayThuHoachDuKien)+","+"NangSuatDuKien="+NangSuatDuKien.ToString()+","+"SanLuongDuKien="+SanLuongDuKien.ToString()+","+"VuID="+VuID.ToString()+","+"DienTich="+DienTich.ToString()+","+"MucDichID="+MucDichID.ToString()+","+"DienTichTrongMoi="+DienTichTrongMoi.ToString()+","+"DienTichTrongLai="+DienTichTrongLai.ToString()+","+"DienTichPheCanh="+DienTichPheCanh.ToString()+
                    " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_CoCauTrong", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_CoCauTrong where ID=" + ID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_CoCauTrong where ID=" + iID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_CoCauTrong where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("ThuaRuongID"))
                    ThuaRuongID = long.Parse(dr["ThuaRuongID"].ToString());
					if(!dr.IsNull("RaiVuID"))
                    RaiVuID = long.Parse(dr["RaiVuID"].ToString());
					if(!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
					if(!dr.IsNull("GiongMiaID"))
                    GiongMiaID = long.Parse(dr["GiongMiaID"].ToString());
					if(!dr.IsNull("NgayTrong"))
                    NgayTrong = DateTime.Parse(dr["NgayTrong"].ToString());
					if(!dr.IsNull("NgayThuHoachDuKien"))
                    NgayThuHoachDuKien = DateTime.Parse(dr["NgayThuHoachDuKien"].ToString());
					if(!dr.IsNull("NangSuatDuKien"))
                    NangSuatDuKien = long.Parse(dr["NangSuatDuKien"].ToString());
					if(!dr.IsNull("SanLuongDuKien"))
                    SanLuongDuKien = long.Parse(dr["SanLuongDuKien"].ToString());
					if(!dr.IsNull("VuID"))
                    VuID = long.Parse(dr["VuID"].ToString());
					if(!dr.IsNull("DienTich"))
                    DienTich = long.Parse(dr["DienTich"].ToString());
					if(!dr.IsNull("MucDichID"))
                    MucDichID = long.Parse(dr["MucDichID"].ToString());
					if(!dr.IsNull("DienTichTrongMoi"))
                    DienTichTrongMoi = long.Parse(dr["DienTichTrongMoi"].ToString());
					if(!dr.IsNull("DienTichTrongLai"))
                    DienTichTrongLai = long.Parse(dr["DienTichTrongLai"].ToString());
					if(!dr.IsNull("DienTichPheCanh"))
                    DienTichPheCanh = long.Parse(dr["DienTichPheCanh"].ToString());
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_CoCauTrong ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_CoCauTrong WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
        public static long TongDienTichTrong(string VuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            long temp = 0;
            // build SQL statement
            strSQL = "select sum(DienTich) as tong from tbl_CoCauTrong Where VuTrongID=" + VuTrongID;
            // run SQL statement
            DataSet ds = null;
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows[0][0].ToString() != null)
            {

                try
                {
                    temp = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    temp = 0;
                }
            }
            return temp;
        }

        public static long TongDienTichConLai(string VuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            long temp = 0;
            // build SQL statement
            strSQL = "select sum(DienTich) as tong from tbl_CoCauTrong Where VuTrongID=" + VuTrongID + " AND ThuaRuongID not in (Select ThuaRuongID from tbl_NhapMia Where VuTrongID=" + VuTrongID + ")";
            // run SQL statement
            DataSet ds = null;
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows[0][0].ToString() != null)
            {
                try
                {
                    temp = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    temp = 0;
                }
            }
            return temp;
        }


        public static long TongSanLuong(string VuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            long temp = 0;
            // build SQL statement
            strSQL = "select sum(SanLuongDuKien) from tbl_CoCauTrong Where VuTrongID=" + VuTrongID;
            // run SQL statement
            DataSet ds = null;
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows[0][0].ToString() != null)
            {
                try
                {
                    temp = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    temp = 0;
                }
            }
            return temp;
        }
        public static long TongSanLuongConLai(string VuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            long temp = 0;
            // build SQL statement
            strSQL = "select sum(SanLuongDuKien) from tbl_CoCauTrong Where VuTrongID=" + VuTrongID + " AND ThuaRuongID not in (Select ThuaRuongID from tbl_NhapMia Where VuTrongID=" + VuTrongID + ")";
            // run SQL statement
            DataSet ds = null;
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows[0][0].ToString() != null)
            {
                try
                {
                    temp = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    temp = 0;
                }
            }
            return temp;
        }	
    }

       

}