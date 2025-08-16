
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsDauTu
    {
			public long ID = -1;        
			public long HopDongID = -1;        
			public long DanhMucDauTuID = -1;        
			public long SoLuong = 0;        
			public long DonGia = 0;        
			public decimal SoTien = 0;        
			public float LaiSuat = 0;        
			public DateTime NgayDauTu = DateTime.Now;        
			public string GhiChu = "";        
			public long DotDauTu = 0;        
			public long DuNo = 0;        
			public DateTime NgayBatDauTinhLai = DateTime.Now;        
			public string DaThanhToan = "";        
			public long VuTrongID = -1;        
			public long VuTruoc = 0;        
			public long LaDuNoVuTruoc = 0;        
			public long QuanLyVaKhauHaoID = -1;
            public long DonViCungUngVatTuID = 0;
            public long LoaiHDDT_ID = -1;
            public string MaHDDT = "";
            public long SoChungTu = -1;
            public long LoaiDT = -1;
            //De quan ly nguoi sua, ngay gio sua thong tin 

            public string NoteModify = "";
        public clsDauTu()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsDauTu(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(DauTu), "tbl_DauTu", cn, trans);
				ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsDauTu), "tbl_DauTu", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_DauTu" + "(ID,HopDongID,DanhMucDauTuID,SoLuong,DonGia,SoTien,LaiSuat,NgayDauTu,GhiChu,DotDauTu,DuNo,NgayBatDauTinhLai,DaThanhToan,VuTrongID,VuTruoc,LaDuNoVuTruoc,QuanLyVaKhauHaoID,DonViCungUngVatTuID, CreatedBy, ModifyBy, DateAdd, DataModify, NoteModify,LoaiHopdong_ID,MaHDDT,SoChungTu,LoaiDT) Values(" +
                    ID.ToString() + "," + HopDongID.ToString() + "," + DanhMucDauTuID.ToString() + "," + SoLuong.ToString() + "," + DonGia.ToString() + "," + SoTien.ToString() + "," + LaiSuat.ToString() + "," + MDSolutionEntities.DBModule.RefineDatetime(NgayDauTu) + "," + "N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'" + "," + DotDauTu.ToString() + "," + DuNo.ToString() + "," + MDSolutionEntities.DBModule.RefineDatetime(NgayBatDauTinhLai) + "," + "N'" + MDSolutionEntities.DBModule.RefineString(DaThanhToan) + "'" + "," + VuTrongID.ToString() + "," + VuTruoc.ToString() + "," + LaDuNoVuTruoc.ToString() + "," + QuanLyVaKhauHaoID.ToString() + "," + DonViCungUngVatTuID.ToString() + 
                ", " + DACASUCO_App.User.ID.ToString() +
                    ", " + DACASUCO_App.User.ID.ToString() +
                    ", getdate()" +
                    ", getdate() " +
                    ", N'" + MDSolutionEntities.DBModule.RefineString(NoteModify) + "',"+LoaiHDDT_ID.ToString()+"," +"N'"+ MaHDDT.ToString()+"',"+SoChungTu.ToString()+","+LoaiDT.ToString()+")";                
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_DauTu set " +
                    "HopDongID=" + HopDongID.ToString() + "," + "DanhMucDauTuID=" + DanhMucDauTuID.ToString() + "," + "SoLuong=" + SoLuong.ToString() + "," + "DonGia=" + DonGia.ToString() + "," + "SoTien=" + SoTien.ToString() + "," + "LaiSuat=" + LaiSuat.ToString() + "," + "NgayDauTu=" + MDSolutionEntities.DBModule.RefineDatetime(NgayDauTu) + "," + "GhiChu=" + "N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'" + "," + "DotDauTu=" + DotDauTu.ToString() + "," + "DuNo=" + DuNo.ToString() + "," + "NgayBatDauTinhLai=" + MDSolutionEntities.DBModule.RefineDatetime(NgayBatDauTinhLai) + "," + "DaThanhToan=" + "N'" + MDSolutionEntities.DBModule.RefineString(DaThanhToan) + "'" + "," + "VuTrongID=" + VuTrongID.ToString() + "," + "VuTruoc=" + VuTruoc.ToString() + "," + "LaDuNoVuTruoc=" + LaDuNoVuTruoc.ToString() + "," + "QuanLyVaKhauHaoID=" + QuanLyVaKhauHaoID.ToString() + "," + "DonViCungUngVatTuID=" + DonViCungUngVatTuID.ToString() +
                    ", ModifyBy = " + DACASUCO_App.User.ID.ToString() +
                ", DataModify = getdate() " +
                ", NoteModify = '" + MDSolutionEntities.DBModule.RefineString(NoteModify) +"'"+ ","+"LoaiHopdong_ID="+"'"+LoaiHDDT_ID.ToString()+"',"+"MaHDDT="+"N'"+MaHDDT.ToString()+"',"+"SoChungTu="+SoChungTu.ToString()+ ",LoaiDT="+LoaiDT.ToString()+
                " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_DauTu", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_HoTro where DauTuID=" + ID.ToString();
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);        

			strSQL = "Delete from tbl_DauTu where ID=" + ID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_HoTro where DauTuID=" + iID.ToString();
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);       

			strSQL = "Delete from tbl_DauTu where ID=" + iID.ToString();
			// run SQL statement
			MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}
        public static void DeleteQLKH(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_DauTu where QuanLyVaKhauHaoID=" + iID.ToString();
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }	

        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_DauTu where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());
					if(!dr.IsNull("DanhMucDauTuID"))
                    DanhMucDauTuID = long.Parse(dr["DanhMucDauTuID"].ToString());
					if(!dr.IsNull("SoLuong"))
                    SoLuong = long.Parse(dr["SoLuong"].ToString());
					if(!dr.IsNull("DonGia"))
                    DonGia = long.Parse(dr["DonGia"].ToString());
					if(!dr.IsNull("SoTien"))
                    SoTien = decimal.Parse(dr["SoTien"].ToString());
					if(!dr.IsNull("LaiSuat"))
                    LaiSuat = float.Parse(dr["LaiSuat"].ToString());
					if(!dr.IsNull("NgayDauTu"))
                    NgayDauTu = DateTime.Parse(dr["NgayDauTu"].ToString());
					if(!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
					if(!dr.IsNull("DotDauTu"))
                    DotDauTu = long.Parse(dr["DotDauTu"].ToString());
					if(!dr.IsNull("DuNo"))
                    DuNo = long.Parse(dr["DuNo"].ToString());
					if(!dr.IsNull("NgayBatDauTinhLai"))
                    NgayBatDauTinhLai = DateTime.Parse(dr["NgayBatDauTinhLai"].ToString());
					if(!dr.IsNull("DaThanhToan"))
                    DaThanhToan = dr["DaThanhToan"].ToString();
					if(!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
					if(!dr.IsNull("VuTruoc"))
                    VuTruoc = long.Parse(dr["VuTruoc"].ToString());
					if(!dr.IsNull("LaDuNoVuTruoc"))
                    LaDuNoVuTruoc = long.Parse(dr["LaDuNoVuTruoc"].ToString());
					if(!dr.IsNull("QuanLyVaKhauHaoID"))
                    QuanLyVaKhauHaoID = long.Parse(dr["QuanLyVaKhauHaoID"].ToString());
                    if (!dr.IsNull("DonViCungUngVatTuID"))
                    DonViCungUngVatTuID = long.Parse(dr["DonViCungUngVatTuID"].ToString());
                    if (!dr.IsNull("LoaiDT"))
                        DonViCungUngVatTuID = long.Parse(dr["LoaiDT"].ToString());
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_DauTu ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_DauTu WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion

        public static void GetListDot(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select Distinct DotDauTu from tbl_DauTu ORDER BY DotDauTu ASC";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static void GetListDonVi(string OrderBy, out DataSet ds1, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds1 = null;
            // build SQL statement
            strSQL = "select id,ten from tbl_DonViCungUngVatTu where id<>1";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);
            ds1 = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

        }

    }
}