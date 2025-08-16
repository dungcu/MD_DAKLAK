
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsUngVatTuVanChuyen
    {
        public long ID = -1;
        public long HopDongVanChuyenID = -1;
        public long XeID = -1;
        public long VatTuID = -1;
        public long SoLuong = 0;
        public long DonGia = 0;
        public DateTime NgayUng = DateTime.Today;
        public long SoChungTu = -1;
        public string DaThanhToan = "";
        public long VuTrongID = -1;
        public long SoTien = 0;
        public string GhiChu = "";
        public long NoiTamUngVatTuID = -1;

        //De quan ly nguoi sua, ngay gio sua thong tin 
      
        public string NoteModify = "";
        public clsUngVatTuVanChuyen()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsUngVatTuVanChuyen(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(UngVatTuVanChuyen), "tbl_UngVatTuVanChuyen", cn, trans);
                ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsUngVatTuVanChuyen), "tbl_UngVatTuVanChuyen", cn, trans);
                // build SQL statement                
                strSQL = " Insert into tbl_UngVatTuVanChuyen" +
          "(ID,HopDongVanChuyenID,XeID,VatTuID,SoLuong,DonGia,NgayUng,SoChungTu,DaThanhToan,VuTrongID,SoTien,GhiChu, CreatedBy, ModifyBy, DateAdd, DataModify, NoteModify,NoiTamUngVaTTuID) Values(" +
              ID.ToString() + "," + HopDongVanChuyenID.ToString() + "," + XeID.ToString() + "," + VatTuID.ToString() + "," + SoLuong.ToString() + "," + DonGia.ToString() + "," + MDSolutionEntities.DBModule.RefineDatetime(NgayUng) + "," + SoChungTu.ToString()+ "," + "N'" + MDSolutionEntities.DBModule.RefineString(DaThanhToan) + "'" + "," + VuTrongID.ToString() + "," + SoTien.ToString() + "," + "N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'" +
               ", " + DACASUCO_App.User.ID.ToString() +
                    ", " + DACASUCO_App.User.ID.ToString() +
                    ", getdate()" +
                    ", getdate() " +
                    ", N'" + MDSolutionEntities.DBModule.RefineString(NoteModify) + "',"+NoiTamUngVatTuID.ToString()+")";                

            }
            else // edit object, we update old record in database
            {
                // build SQL statement				    
                //NgaySua = DateTime.Now;                   
                strSQL = "Update tbl_UngVatTuVanChuyen set " +
                    "HopDongVanChuyenID=" + HopDongVanChuyenID.ToString() + "," + "XeID=" + XeID.ToString() + "," + "VatTuID=" + VatTuID.ToString() + "," + "SoLuong=" + SoLuong.ToString() + "," + "DonGia=" + DonGia.ToString() + "," + "NgayUng=" + MDSolutionEntities.DBModule.RefineDatetime(NgayUng) + "," + "SoChungTu="  + SoChungTu.ToString() + "," + "DaThanhToan=" + "N'" + MDSolutionEntities.DBModule.RefineString(DaThanhToan) + "'" + "," + "VuTrongID=" + VuTrongID.ToString() + "," + "SoTien=" + SoTien.ToString() + "," + "GhiChu=" + "N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'" + "," + "NoiTamUngVatTuID=" + NoiTamUngVatTuID.ToString() +
                    ", ModifyBy = " + DACASUCO_App.User.ID.ToString() +
                ", DataModify = getdate() " +
                ", NoteModify = '" + MDSolutionEntities.DBModule.RefineString(NoteModify) + "'"+
                " Where ID = " + ID.ToString();

            }
            // run SQL statement

            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_UngVatTuVanChuyen", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_UngVatTuVanChuyen where ID=" + ID.ToString();
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_UngVatTuVanChuyen where ID=" + iID.ToString();
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_UngVatTuVanChuyen where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("HopDongVanChuyenID"))
                    HopDongVanChuyenID = long.Parse(dr["HopDongVanChuyenID"].ToString());
                if (!dr.IsNull("XeID"))
                    XeID = long.Parse(dr["XeID"].ToString());
                if (!dr.IsNull("VatTuID"))
                    VatTuID = long.Parse(dr["VatTuID"].ToString());
                if (!dr.IsNull("SoLuong"))
                    SoLuong = long.Parse(dr["SoLuong"].ToString());
                if (!dr.IsNull("DonGia"))
                    DonGia = long.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("NgayUng"))
                    NgayUng = DateTime.Parse(dr["NgayUng"].ToString());
                if (!dr.IsNull("SoChungTu"))
                    SoChungTu = long.Parse(dr["SoChungTu"].ToString());
                if (!dr.IsNull("DaThanhToan"))
                    DaThanhToan = dr["DaThanhToan"].ToString();
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("SoTien"))
                    SoTien = long.Parse(dr["SoTien"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("NoiTamUngVatTuID"))
                {
                    NoiTamUngVatTuID = long.Parse(dr["NoiTamUngVatTuID"].ToString());
                }
                else { NoiTamUngVatTuID = 0; }
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_UngVatTuVanChuyen ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);

            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_UngVatTuVanChuyen WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion
        #region Extend Functions
        public static DataSet GetListThongTinTUByHopDongVanChuyenID(long VuTrongID, long mHDID, string OrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Select * from V_UngVatTuVanChuyen ";
            strSQL += "Where HopDongVanChuyenID = " + mHDID.ToString();
            strSQL += "AND VuTrongID = " + VuTrongID.ToString();
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);

            return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion
    }
}