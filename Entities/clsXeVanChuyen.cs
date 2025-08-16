
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsXeVanChuyen
    {
        public long ID = -1;
        public string SoXe = "";
        public string TenLaiXe = "";
        public string LoaiXe = "";
        public long TrongTai = 0;
        public string GhiChu = "";
        public long HopDongVanChuyenID = -1;
        public string MaSoXe = "";
        public long VuTrongID = -1;
        //public DateTime NBD = DateTime.Now;
        public string NKT=null;
        //De quan ly nguoi sua, ngay gio sua thong tin 
      
        public string NoteModify = "";

        public clsXeVanChuyen()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsXeVanChuyen(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(XeVanChuyen), "tbl_XeVanChuyen", cn, trans);
                ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsXeVanChuyen), "tbl_XeVanChuyen", cn, trans);
                //NgayTao = DateTime.Now;        
                //NgaySua = DateTime.Now;        
                // build SQL statement
                strSQL = "Insert into tbl_XeVanChuyen" +
                "(ID,SoXe,TenLaiXe,LoaiXe,TrongTai,GhiChu,HopDongVanChuyenID,MaSoXe,VuTrongID) Values(" +
                    ID.ToString() + "," + "N'" + MDSolutionEntities.DBModule.RefineString(SoXe) + "'" + "," + "N'" + MDSolutionEntities.DBModule.RefineString(TenLaiXe) + "'" + "," + "N'" + MDSolutionEntities.DBModule.RefineString(LoaiXe) + "'" + "," + TrongTai.ToString() + "," + "N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'" + "," + HopDongVanChuyenID.ToString() + "," + "N'" + MDSolutionEntities.DBModule.RefineString(MaSoXe) + "'" +
                  "," + VuTrongID.ToString() + ")";                
            }
            else // edit object, we update old record in database
            {
                // build SQL statement				    
                //NgaySua = DateTime.Now;        
                strSQL = "Update tbl_XeVanChuyen set " +
                    "SoXe=" + "N'" + MDSolutionEntities.DBModule.RefineString(SoXe) + "'" + "," + "TenLaiXe=" + "N'" + MDSolutionEntities.DBModule.RefineString(TenLaiXe) + "'" + "," + "LoaiXe=" + "N'" + MDSolutionEntities.DBModule.RefineString(LoaiXe) + "'" + "," + "TrongTai=" + TrongTai.ToString() + "," + "GhiChu=" + "N'" + MDSolutionEntities.DBModule.RefineString(GhiChu) + "'" + "," + "HopDongVanChuyenID=" + HopDongVanChuyenID.ToString() + "," + "MaSoXe=" + "N'" + MDSolutionEntities.DBModule.RefineString(MaSoXe) + "'"+
                       ",VutrongID="+VuTrongID.ToString()+
                " Where ID = " + ID.ToString();
            }
            // run SQL statement

            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_XeVanChuyen", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_XeVanChuyen where ID=" + ID.ToString();
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_XeVanChuyen where ID=" + iID.ToString();
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_XeVanChuyen where ID=" + ID.ToString();
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
                if (!dr.IsNull("TenLaiXe"))
                    TenLaiXe = dr["TenLaiXe"].ToString();
                if (!dr.IsNull("LoaiXe"))
                    LoaiXe = dr["LoaiXe"].ToString();
                if (!dr.IsNull("TrongTai"))
                    TrongTai = long.Parse(dr["TrongTai"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("HopDongVanChuyenID"))
                    HopDongVanChuyenID = long.Parse(dr["HopDongVanChuyenID"].ToString());
                if (!dr.IsNull("MaSoXe"))
                    MaSoXe = dr["MaSoXe"].ToString();
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("NKT"))
                    NKT = dr["NKT"].ToString();
            }

        }
        public void LoadKT(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_XeVanChuyen where ID=" + ID.ToString()+" AND NKT Is Null";
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
                if (!dr.IsNull("TenLaiXe"))
                    TenLaiXe = dr["TenLaiXe"].ToString();
                if (!dr.IsNull("LoaiXe"))
                    LoaiXe = dr["LoaiXe"].ToString();
                if (!dr.IsNull("TrongTai"))
                    TrongTai = long.Parse(dr["TrongTai"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("HopDongVanChuyenID"))
                    HopDongVanChuyenID = long.Parse(dr["HopDongVanChuyenID"].ToString());
                if (!dr.IsNull("MaSoXe"))
                    MaSoXe = dr["MaSoXe"].ToString();
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("NKT"))
                    NKT = dr["NKT"].ToString();
            }

        }
        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_XeVanChuyen ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);

            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + ",(TrongTai/1000)AS TrongTai1 FROM tbl_XeVanChuyen WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        public static DataSet GetListbyWhereNKT(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_XeVanChuyen WHERE 1=1 ";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        public static DataSet GetListXeVanChuyenByHopDongVanChuyenID(long mHDID, string OrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Select * from tbl_XeVanChuyen ";
            strSQL += "Where HopDongVanChuyenID = " + mHDID.ToString();
            // strSQL += "AND VuTrongID = " + VuTrongID.ToString();
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);

            return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion
    }
}