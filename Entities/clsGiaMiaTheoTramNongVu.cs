
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsGiaMiaTheoTramNongVu
    {
        public long ID = -1;
        public long tram_nong_vu_id = -1;
        public long gio_ap_dung = 0;
        public DateTime ngay_ap_dung = DateTime.Now;
        public long gia_mua_mia = 0;
        //public long GiaMiaChay = 0;
        public long ho_tro_gia_mia = 0;
        public long gia_thanh_toan = 0;
        public long gia_thanh_toan_css = 0;
        public long vu_trong_id = -1;
        public string ghi_chu = "";

        public clsGiaMiaTheoTramNongVu()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsGiaMiaTheoTramNongVu(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                strSQL = "Insert into tbl_Gia_Mia_Theo_Tram_Nong_Vu" +
                "(tram_nong_vu_id, gio_ap_dung, ngay_ap_dung, gia_mua_mia, ho_tro_gia_mia, gia_thanh_toan,gia_thanh_toan_css, vu_trong_id, ghi_chu) Values(" +
                    tram_nong_vu_id.ToString() + ","
                    + gio_ap_dung.ToString() + ","
                    + MDSolutionEntities.DBModule.RefineDatetime(ngay_ap_dung, true) + ","
                    + gia_mua_mia.ToString()
                    + "," + ho_tro_gia_mia.ToString()
                    + "," + gia_thanh_toan.ToString()
                    + "," + gia_thanh_toan_css.ToString()
                    + "," + vu_trong_id.ToString()
                    + ",N'" + MDSolutionEntities.DBModule.RefineString(ghi_chu) + "')";
            }
            else // edit object, we update old record in database
            {
                strSQL = "UPDATE tbl_Gia_Mia_Theo_Tram_Nong_Vu SET "
                      + " tram_nong_vu_id = " + tram_nong_vu_id.ToString()
                      + ", gio_ap_dung = " + gio_ap_dung.ToString()
                      + ", ngay_ap_dung = " + MDSolutionEntities.DBModule.RefineDatetime(ngay_ap_dung, true)
                      + ", gia_mua_mia = " + gia_mua_mia.ToString()
                      + ", ho_tro_gia_mia = " + ho_tro_gia_mia.ToString()
                      + ", gia_thanh_toan = " + gia_thanh_toan.ToString()
                      + ", gia_thanh_toan_css = " + gia_thanh_toan_css.ToString()
                      + ", vu_trong_id = " + vu_trong_id.ToString()
                      + ", ghi_chu=N'" + MDSolutionEntities.DBModule.RefineString(ghi_chu) + "' Where id = " + ID.ToString();
            }
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            if (ID < 0)
            {
                strSQL = "SELECT IDENT_CURRENT('tbl_Gia_Mia_Theo_Tram_Nong_Vu')";
                long.TryParse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null), out ID);
            }
           
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_Gia_Mia_Theo_Tram_Nong_Vu where ID=" + ID.ToString();
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_Gia_Mia_Theo_Tram_Nong_Vu where ID=" + iID.ToString();
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            //build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_Gia_Mia_Theo_Tram_Nong_Vu where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("tram_nong_vu_id"))
                    tram_nong_vu_id = long.Parse(dr["tram_nong_vu_id"].ToString());
                if (!dr.IsNull("gio_ap_dung"))
                    gio_ap_dung = long.Parse(dr["gio_ap_dung"].ToString());
                if (!dr.IsNull("ngay_ap_dung"))
                    ngay_ap_dung = DateTime.Parse(dr["ngay_ap_dung"].ToString());
                if (!dr.IsNull("gia_mua_mia"))
                    gia_mua_mia = long.Parse(dr["gia_mua_mia"].ToString());
                    if (!dr.IsNull("ho_tro_gia_mia"))
                    ho_tro_gia_mia = long.Parse(dr["ho_tro_gia_mia"].ToString());
                if (!dr.IsNull("gia_thanh_toan"))
                    gia_thanh_toan = long.Parse(dr["gia_thanh_toan"].ToString());
                if (!dr.IsNull("gia_thanh_toan_css"))
                    gia_thanh_toan_css = long.Parse(dr["gia_thanh_toan_css"].ToString());
                if (!dr.IsNull("vu_trong_id"))
                    vu_trong_id = long.Parse(dr["vu_trong_id"].ToString());
                if (!dr.IsNull("ghi_chu"))
                    ghi_chu = dr["ghi_chu"].ToString();
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_Gia_Mia_Theo_Tram_Nong_Vu ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);

            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_Gia_Mia_Theo_Tram_Nong_Vu WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion
    }
}