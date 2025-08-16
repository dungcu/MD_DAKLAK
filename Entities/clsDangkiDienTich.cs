using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

namespace MDSolution
{
    class clsDangkiDienTich
    {
        public long ID = -1;
        public string MucDichDangKy = "";
        public long HopDongID = 0;
        public long ThuaRuongID = 0;
        public long RaiVuDangKyID = 0;
        public float DienTichDangKy = 0;
        public DateTime ThoiGianDangKyThucHien = DateTime.Now;
        public string GhiChu = "";
         public clsDangkiDienTich()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsDangkiDienTich(long lID)
        {
            ID = lID;
        }
        //#region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(DanhMucDauTu), "tbl_DanhMucDauTu", cn, trans);
                ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsDangkiDienTich), "tbl_DangKy_DienTich", cn, trans);
                //NgayTao = DateTime.Now;        
                //NgaySua = DateTime.Now;        
                // build SQL statement
                strSQL = "Insert into tbl_DangKy_DienTich" +
                "(ID,HopDongID,ThuaRuongID,MucDichDangKy,DienTichDangKy,RaiVuDangKyID,ThoiGianDangKyThucHien,GhiChu) Values(" +
                    ID.ToString() + "," + HopDongID.ToString() + "," + ThuaRuongID.ToString() + "," + "N'" + MDSolutionEntities.DBModule.RefineString(MucDichDangKy) + "'" + "," + DienTichDangKy.ToString() + "," + RaiVuDangKyID.ToString() + "," + "'" + MDSolutionEntities.DBModule.RefineDatetime(ThoiGianDangKyThucHien) + "'" + "," + "N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'" + ")";
            }
            else // edit object, we update old record in database
            {
                // build SQL statement				    
                //NgaySua = DateTime.Now;        
                strSQL = "Update tbl_DangKy_DienTich set " +
                    "MucDichDangKy=" + "N'" + MDSolutionEntities.DBModule.RefineString(MucDichDangKy) + "'" + "," + "GhiChu=" + "N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'" + "," + "HopDongID=" + HopDongID.ToString() + "," + "ThuaRuongID=" + ThuaRuongID.ToString() + "," + "DienTichDangKy=" + DienTichDangKy.ToString() + "," + "RaiVuDangKyID=" + RaiVuDangKyID.ToString() + "," + "ThoiGianDangKyThucHien=" + "'" + MDSolutionEntities.DBModule.RefineDatetime(ThoiGianDangKyThucHien) + "'" +
                    " Where ID = " + ID.ToString();
            }
            // run SQL statement

            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_DanhMucDauTu", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_DangKy_DienTich where ID=" + ID.ToString();
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_DangKy_DienTich where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("MucDichDangKy"))
                    MucDichDangKy = dr["MucDichDangKy"].ToString();
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("DienTichDangKy"))
                    DienTichDangKy = float.Parse(dr["DienTichDangKy"].ToString());
                if (!dr.IsNull("RaiVuDangKyID"))
                    RaiVuDangKyID = long.Parse(dr["RaiVuDangKyID"].ToString());
                if (!dr.IsNull("ThoiGianDangKyThucHien"))
                    ThoiGianDangKyThucHien = DateTime.Parse(dr["ThoiGianDangKyThucHien"].ToString());
                if (!dr.IsNull("ThuaRuongID"))
                    ThuaRuongID = long.Parse(dr["ThuaRuongID"].ToString());
            }
            

        }

        #region
        //public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        //{
        //    string strSQL = "";
        //    // build SQL statement
        //    strSQL = "Delete from tbl_DanhMucDauTu where ID=" + iID.ToString();
        //    // run SQL statement
        //    MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        //}
       

        //public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        //{
        //    string strSQL = "";
        //    ds = null;
        //    // build SQL statement
        //    strSQL = "Select * from tbl_DanhMucDauTu ";
        //    if ((OrderBy != null) && (OrderBy != ""))
        //        strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);

        //    ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

        //}
        //public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        //{
        //    if (strFields == "") strFields = "*";
        //    string strSQL = "SELECT " + strFields + " FROM tbl_DanhMucDauTu WHERE 1=1";
        //    if (strWhere != "") strSQL += " AND " + strWhere;
        //    if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
        //    return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
        //}
        #endregion
    }
}
