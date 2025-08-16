
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsDanhMucDauTu
    {
        public long ID = -1;
        public string Ten = "";
        public string DonViTinh = "";
        public long HinhThucDauTu = 0;
        public long ApDungNhieu = 0;
        public long ThuTu = 0;
        public long LoaiHinhDauTuID = 0;
        public long IsActive = 0;
        public clsDanhMucDauTu()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsDanhMucDauTu(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(DanhMucDauTu), "tbl_DanhMucDauTu", cn, trans);
                ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsDanhMucDauTu), "tbl_DanhMucDauTu", cn, trans);
                //NgayTao = DateTime.Now;        
                //NgaySua = DateTime.Now;        
                // build SQL statement
                strSQL = "Insert into tbl_DanhMucDauTu" +
                "(ID,Ten,DonViTinh,HinhThucDauTu,ApDungNhieu,ThuTu,LoaiHinhDauTuID,IsActive) Values(" +
                    ID.ToString() + "," + "N'" + MDSolutionEntities.DBModule.RefineString(Ten) + "'" + "," + "N'" + MDSolutionEntities.DBModule.RefineString(DonViTinh) + "'" + "," + HinhThucDauTu.ToString() + "," + ApDungNhieu.ToString() + "," + ThuTu.ToString() + "," + LoaiHinhDauTuID.ToString() + "," + IsActive.ToString() + ")";
            }
            else // edit object, we update old record in database
            {
                // build SQL statement				    
                //NgaySua = DateTime.Now;        
                strSQL = "Update tbl_DanhMucDauTu set " +
                    "Ten=" + "N'" + MDSolutionEntities.DBModule.RefineString(Ten) + "'" + "," + "DonViTinh=" + "N'" + MDSolutionEntities.DBModule.RefineString(DonViTinh) + "'" + "," + "HinhThucDauTu=" + HinhThucDauTu.ToString() + "," + "ApDungNhieu=" + ApDungNhieu.ToString() + "," + "ThuTu=" + ThuTu.ToString() + "," + "LoaiHinhDauTuID=" + LoaiHinhDauTuID.ToString() + "," + "IsActive=" + IsActive.ToString() +
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
            strSQL = "Delete from tbl_DanhMucDauTu where ID=" + ID.ToString();
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_DanhMucDauTu where ID=" + iID.ToString();
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_DanhMucDauTu where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("Ten"))
                    Ten = dr["Ten"].ToString();
                if (!dr.IsNull("DonViTinh"))
                    DonViTinh = dr["DonViTinh"].ToString();
                if (!dr.IsNull("HinhThucDauTu"))
                    HinhThucDauTu = long.Parse(dr["HinhThucDauTu"].ToString());
                if (!dr.IsNull("ApDungNhieu"))
                    ApDungNhieu = long.Parse(dr["ApDungNhieu"].ToString());
                if (!dr.IsNull("ThuTu"))
                    ThuTu = long.Parse(dr["ThuTu"].ToString());
                if (!dr.IsNull("LoaiHinhDauTuID"))
                    LoaiHinhDauTuID = long.Parse(dr["LoaiHinhDauTuID"].ToString());
                if (!dr.IsNull("IsActive"))
                    IsActive = long.Parse(dr["IsActive"].ToString());
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_DanhMucDauTu ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);

            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_DanhMucDauTu WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion
        public static void UpdateDanhMucDauTuVuTrong(long DanhMucDauTuID, long VuTrongID, long trangthai, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = " DELETE FROM tbl_DanhMucDauTu_VuTrong WHERE DanhMucDauTuID=" + DanhMucDauTuID.ToString() + " AND VuTrongID=" + VuTrongID.ToString();
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            if (trangthai == 1)
            {
                strSQL = " INSERT INTO tbl_DanhMucDauTu_VuTrong(DanhMucDauTuID, VuTrongID) VALUES(" + DanhMucDauTuID.ToString() + "," + VuTrongID.ToString() + ")";
                MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            }
        }
        public static void UpdateAllCurrentDanhMucDauTuChoVuTrong(long VuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = " DELETE FROM tbl_DanhMucDauTu_VuTrong WHERE VuTrongID=" + VuTrongID.ToString();
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            strSQL = " INSERT INTO tbl_DanhMucDauTu_VuTrong(DanhMucDauTuID, VuTrongID) SELECT [ID]," + VuTrongID.ToString() + " FROM tbl_DanhMucDauTu WHERE IsActive=1";
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);

        }
    }
}