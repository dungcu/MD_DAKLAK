
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsHopDong
    {
        public long ID = -1;
        public long ParentID = 0;
        public string MaHopDong = "";
        public DateTime NgaySinh = DateTime.MinValue;
        public string SoCMT = "";
        public DateTime NgayCap = DateTime.MinValue;
        public string NoiCap = "";
        public string DiaChi = "";
        public string SoDT = "";
        public long ThonID = -1;
        public string NguoiThuaKe1Ten = "";
        public string NguoiThuaKe1DiaChi = "";
        public string NguoiThuaKe1CMT = "";
        public string NguoiThuaKe2Ten = "";
        public string NguoiThuaKe2DiaChi = "";
        public string NguoiThuaKe2CMT = "";
        public long TrangThai = 0;
        public string HoTen = "";
        public string SoTaiKhoan = "";
        public long NganHangID = -1;
        public DateTime NgayKyHopDong = DateTime.MinValue;
        //De quan ly nguoi sua, ngay gio sua thong tin 

        public string NoteModify = "";
        
        public clsHopDong()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsHopDong(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.MDSolutionEntities.DBModule.GetNewID(typeof(HopDong), "tbl_HopDong", cn, trans);
                ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsHopDong), "tbl_HopDong", cn, trans);
                //NgayTao = DateTime.Now;        
                //NgaySua = DateTime.Now;        
                // build SQL statement


                strSQL = "Insert into tbl_HopDong" +
                "(ID,MaHopDong,NgaySinh,SoCMT,NgayCap,NoiCap,ThonID,NguoiThuaKe1Ten,NguoiThuaKe1DiaChi,NguoiThuaKe1CMT,NguoiThuaKe2Ten,NguoiThuaKe2DiaChi,NguoiThuaKe2CMT,TrangThai,HoTen,NgayKyHopDong,ParentID,SoTaiKhoan,NganHangID, CreatedBy, ModifyBy, DateAdd, DataModify, NoteModify) Values(" +
                    ID.ToString() + "," + "N'" + MDSolutionEntities.DBModule.RefineString(MaHopDong) + "'" + "," + MDSolutionEntities.DBModule.RefineDatetime(NgaySinh, true) + "," + "N'" + MDSolutionEntities.DBModule.RefineString(SoCMT) + "'" + "," + MDSolutionEntities.DBModule.RefineDatetime(NgayCap, true) + "," + "N'" + MDSolutionEntities.DBModule.RefineString(NoiCap) + "'" + "," + ThonID.ToString() + "," + "N'" + MDSolutionEntities.DBModule.RefineString(NguoiThuaKe1Ten) + "'" + "," + "N'" + MDSolutionEntities.DBModule.RefineString(NguoiThuaKe1DiaChi) + "'" + "," + "N'" + MDSolutionEntities.DBModule.RefineString(NguoiThuaKe1CMT) + "'" + "," + "N'" + MDSolutionEntities.DBModule.RefineString(NguoiThuaKe2Ten) + "'" + "," + "N'" + MDSolutionEntities.DBModule.RefineString(NguoiThuaKe2DiaChi) + "'" + "," + "N'" + MDSolutionEntities.DBModule.RefineString(NguoiThuaKe2CMT) + "'" + "," + TrangThai.ToString() + "," + "N'" + MDSolutionEntities.DBModule.RefineString(HoTen) + "'" + "," + MDSolutionEntities.DBModule.RefineDatetime(NgayKyHopDong, true) + "," + ParentID.ToString() + ",N'" + SoTaiKhoan + "'," + NganHangID.ToString() + 
                    ", " + DACASUCO_App.User.ID.ToString() +
                ", " + DACASUCO_App.User.ID.ToString() +
                ", getdate()" +
                ", getdate() " +
                ", N'" + MDSolutionEntities.DBModule.RefineString(NoteModify) + "')";

            }
            else // edit object, we update old record in database
            {

                strSQL = "Update tbl_HopDong set " +
                    "MaHopDong=" + "N'" + MDSolutionEntities.DBModule.RefineString(MaHopDong) + "'" + "," + "NgaySinh=" + MDSolutionEntities.DBModule.RefineDatetime(NgaySinh,true) + "," + "SoCMT=" + "N'" + MDSolutionEntities.DBModule.RefineString(SoCMT) + "'" + "," + "NgayCap=" + MDSolutionEntities.DBModule.RefineDatetime(NgayCap,true) + "," + "NoiCap=" + "N'" + MDSolutionEntities.DBModule.RefineString(NoiCap) + "'" + "," + "ThonID=" + ThonID.ToString() + "," + "NguoiThuaKe1Ten=" + "N'" + MDSolutionEntities.DBModule.RefineString(NguoiThuaKe1Ten) + "'" + "," + "NguoiThuaKe1DiaChi=" + "N'" + MDSolutionEntities.DBModule.RefineString(NguoiThuaKe1DiaChi) + "'" + "," + "NguoiThuaKe1CMT=" + "N'" + MDSolutionEntities.DBModule.RefineString(NguoiThuaKe1CMT) + "'" + "," + "NguoiThuaKe2Ten=" + "N'" + MDSolutionEntities.DBModule.RefineString(NguoiThuaKe2Ten) + "'" + "," + "NguoiThuaKe2DiaChi=" + "N'" + MDSolutionEntities.DBModule.RefineString(NguoiThuaKe2DiaChi) + "'" + "," + "NguoiThuaKe2CMT=" + "N'" + MDSolutionEntities.DBModule.RefineString(NguoiThuaKe2CMT) + "'" + "," + "TrangThai=" + TrangThai.ToString() + "," + "HoTen=" + "N'" + MDSolutionEntities.DBModule.RefineString(HoTen) + "'" + "," + "NgayKyHopDong=" + MDSolutionEntities.DBModule.RefineDatetime(NgayKyHopDong,true) + ", ParentID=" + ParentID.ToString() +
                    ", SoTaiKhoan=N'" + SoTaiKhoan + "' , NganHangID=" + NganHangID.ToString() + 
                    
                    ", ModifyBy = " + DACASUCO_App.User.ID.ToString() +
                ", DataModify = getdate() " +
                ", NoteModify = '" + MDSolutionEntities.DBModule.RefineString(NoteModify) + "'" +
                " Where ID = " + ID.ToString();                    
            }
            // run SQL statement

            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_HopDong", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HopDong where ID=" + ID.ToString();
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HopDong where ID=" + iID.ToString();
            // run SQL statement
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_HopDong where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("ParentID"))
                    ParentID = long.Parse(dr["ParentID"].ToString());
                if (!dr.IsNull("MaHopDong"))
                    MaHopDong = dr["MaHopDong"].ToString();
                if (!dr.IsNull("NgaySinh"))
                    NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString());
                if (!dr.IsNull("SoCMT"))
                    SoCMT = dr["SoCMT"].ToString();
                if (!dr.IsNull("NgayCap"))
                    NgayCap = DateTime.Parse(dr["NgayCap"].ToString());
                if (!dr.IsNull("NoiCap"))
                    NoiCap = dr["NoiCap"].ToString();
                if (!dr.IsNull("ThonID"))
                    ThonID = long.Parse(dr["ThonID"].ToString());
                if (!dr.IsNull("NguoiThuaKe1Ten"))
                    NguoiThuaKe1Ten = dr["NguoiThuaKe1Ten"].ToString();
                if (!dr.IsNull("NguoiThuaKe1DiaChi"))
                    NguoiThuaKe1DiaChi = dr["NguoiThuaKe1DiaChi"].ToString();
                if (!dr.IsNull("NguoiThuaKe1CMT"))
                    NguoiThuaKe1CMT = dr["NguoiThuaKe1CMT"].ToString();
                if (!dr.IsNull("NguoiThuaKe2Ten"))
                    NguoiThuaKe2Ten = dr["NguoiThuaKe2Ten"].ToString();
                if (!dr.IsNull("NguoiThuaKe2DiaChi"))
                    NguoiThuaKe2DiaChi = dr["NguoiThuaKe2DiaChi"].ToString();
                if (!dr.IsNull("NguoiThuaKe2CMT"))
                    NguoiThuaKe2CMT = dr["NguoiThuaKe2CMT"].ToString();
                if (!dr.IsNull("TrangThai"))
                    TrangThai = long.Parse(dr["TrangThai"].ToString());
                if (!dr.IsNull("HoTen"))
                    HoTen = dr["HoTen"].ToString();
                if (!dr.IsNull("SoTaiKhoan"))
                    SoTaiKhoan = dr["SoTaiKhoan"].ToString();
                if (!dr.IsNull("NganHangID"))
                    NganHangID = long.Parse(dr["NganHangID"].ToString());
                if (!dr.IsNull("NgayKyHopDong"))
                    NgayKyHopDong = DateTime.Parse(dr["NgayKyHopDong"].ToString());
                if (!dr.IsNull("SoDT"))
                    SoCMT = dr["SoDT"].ToString();
                if (!dr.IsNull("DiaChi"))
                    DiaChi = dr["DiaChi"].ToString();
            }

        }
        public void Load(string MaHopDong, OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_HopDong where MaHopDong='" + MaHopDong + "'";
            // run SQL statement
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("ParentID"))
                    ParentID = long.Parse(dr["ParentID"].ToString());
                if (!dr.IsNull("MaHopDong"))
                    MaHopDong = dr["MaHopDong"].ToString();
                if (!dr.IsNull("NgaySinh"))
                    NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString());
                if (!dr.IsNull("SoCMT"))
                    SoCMT = dr["SoCMT"].ToString();
                if (!dr.IsNull("NgayCap"))
                    NgayCap = DateTime.Parse(dr["NgayCap"].ToString());
                if (!dr.IsNull("NoiCap"))
                    NoiCap = dr["NoiCap"].ToString();
                if (!dr.IsNull("ThonID"))
                    ThonID = long.Parse(dr["ThonID"].ToString());
                if (!dr.IsNull("NguoiThuaKe1Ten"))
                    NguoiThuaKe1Ten = dr["NguoiThuaKe1Ten"].ToString();
                if (!dr.IsNull("NguoiThuaKe1DiaChi"))
                    NguoiThuaKe1DiaChi = dr["NguoiThuaKe1DiaChi"].ToString();
                if (!dr.IsNull("NguoiThuaKe1CMT"))
                    NguoiThuaKe1CMT = dr["NguoiThuaKe1CMT"].ToString();
                if (!dr.IsNull("NguoiThuaKe2Ten"))
                    NguoiThuaKe2Ten = dr["NguoiThuaKe2Ten"].ToString();
                if (!dr.IsNull("NguoiThuaKe2DiaChi"))
                    NguoiThuaKe2DiaChi = dr["NguoiThuaKe2DiaChi"].ToString();
                if (!dr.IsNull("NguoiThuaKe2CMT"))
                    NguoiThuaKe2CMT = dr["NguoiThuaKe2CMT"].ToString();
                if (!dr.IsNull("TrangThai"))
                    TrangThai = long.Parse(dr["TrangThai"].ToString());
                if (!dr.IsNull("HoTen"))
                    HoTen = dr["HoTen"].ToString();
                if (!dr.IsNull("SoTaiKhoan"))
                    SoTaiKhoan = dr["SoTaiKhoan"].ToString();
                if (!dr.IsNull("NganHangID"))
                    NganHangID = long.Parse(dr["NganHangID"].ToString());
                if (!dr.IsNull("NgayKyHopDong"))
                    NgayKyHopDong = DateTime.Parse(dr["NgayKyHopDong"].ToString());
                if (!dr.IsNull("DiaChi"))
                    DiaChi = dr["DiaChi"].ToString();
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_HopDong ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + MDSolutionEntities.DBModule.RefineString(OrderBy);

            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_HopDong WHERE 1=1 ";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        public string GetTinhTrangHopDongTrongVu(long VuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            try
            {
                string strSQL = "SELECT DotThanhToan FROM tbl_HopDong_DaLamThanhToan WHERE HopDongID=" + this.ID.ToString() + " AND VuTrongID=" + VuTrongID.ToString();
                string ret = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
                if (ret != null && ret != "")
                {
                    return "2-" + ret;
                }
                else
                {
                    strSQL = "SELECT DotThanhToan FROM tbl_HopDong_ChoLamThanhToan WHERE HopDongID=" + this.ID.ToString() + " AND VuTrongID=" + VuTrongID.ToString();
                    ret = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
                    if (ret != null && ret != "")
                    {
                        return "1-" + ret;
                    }
                    else
                    {
                        return "0";
                    }
                }
            }
            catch
            {
                return "0";
            }
        }
        public static DateTime GetNgayTinhCongNo(long iHopDongID, long iVuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            DateTime dtret = DateTime.Now;

            string strSQL = "SELECT NgayTinhCongNo FROM tbl_NgayTinhCongNo WHERE HopDongID=" + iHopDongID.ToString() + " AND VuTrongID=" + iVuTrongID.ToString();

            string ret = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
            if (ret != null && ret != "")
            {
                dtret = DateTime.Parse(ret);
            }


            return dtret;
        }
        public static long GetTongTienDauTuConLai(long iHopDongID, long iVuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "[sp_Get_TongTien_DauTu_ConLai] " + iHopDongID.ToString() + "," + iVuTrongID.ToString();
            return long.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null));
        }
        public static long GetTongCacKhoanTienCo(long iHopDongID, long iVuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "[sp_Get_TongTien_CacKhoan_Co] " + iHopDongID.ToString() + "," + iVuTrongID.ToString();
            return long.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null));
        }
        #endregion
        #region extention functions
        public static long GetTongTienDauTuPhaiTra(long iHopDongID, long iVuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "[sp_Get_TongTien_DauTu_PhaiTra] " + iHopDongID.ToString() + "," + iVuTrongID.ToString();
            return long.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null));
        }
        public static long GetTongCacKhoanTienCoThuDuoc(long iHopDongID, long iVuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "[sp_Get_TongTien_CacKhoan_ThuDuoc] " + iHopDongID.ToString() + "," + iVuTrongID.ToString();
            return long.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null));
        }
        public static DataSet GetDanhSachHopDongTheoDieuKien(long lID, string strDieuKienTimKiem, DonviType dvType, string dvID, Boolean timchinhxac)
        {

            string strSQLWhere = " trangthai = 1 AND ParentID>0";
            if (lID > 0)
            {
                strSQLWhere += "AND ID= " + lID.ToString() ;
            }
            else
            {
                switch (dvType)
                {
                    case DonviType.Cum: strSQLWhere += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID IN (SELECT ID FROM tbl_Xa WHERE CumID="+dvID+"))"; break;
                    case DonviType.Xa: strSQLWhere += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + dvID + ")"; break;
                    case DonviType.Thon: strSQLWhere += " AND ThonID=" + dvID; break;
                    case DonviType.ChuHopDong: strSQLWhere += " AND ParentID=" + dvID; break;
                    default: strSQLWhere +=" AND ID=0"; break;
                }

                if ((timchinhxac) && (strDieuKienTimKiem != ""))
                {

                    strSQLWhere += " AND (MaHopDong= N'" + MDSolutionEntities.DBModule.RefineString(strDieuKienTimKiem) + "' OR HoTen= N'" + MDSolutionEntities.DBModule.RefineString(strDieuKienTimKiem) + "' )";

                }
                else
                {

                    strSQLWhere += " AND (MaHopDong like N'%" + MDSolutionEntities.DBModule.RefineString(strDieuKienTimKiem) + "%' OR HoTen like N'%" + MDSolutionEntities.DBModule.RefineString(strDieuKienTimKiem) + "%' )";

                }
            }
            return clsHopDong.GetListbyWhere("", strSQLWhere, "", null, null);
        }

        public static DataSet GetDanhSachDenHopDong(long lID, string strDieuKienTimKiem, DonviType dvType, string dvID, Boolean timchinhxac)
        {

            string strSQLWhere = " trangthai = 1";//+ " AND ParentID=0"
            if (lID > 0)
            {
                strSQLWhere += "AND ID= " + lID.ToString();
            }
            else
            {
                switch (dvType)
                {
                    case DonviType.Cum: strSQLWhere += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID IN (SELECT ID FROM tbl_Xa WHERE CumID=" + dvID + "))"; break;
                    case DonviType.Xa: strSQLWhere += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + dvID + ")"; break;
                    case DonviType.Thon: strSQLWhere += " AND ThonID=" + dvID; break;
                    case DonviType.ChuHopDong: strSQLWhere += " AND ParentID=" + dvID; break;
                    default: break;
                }

                if ((timchinhxac) && (strDieuKienTimKiem != ""))
                {

                    strSQLWhere += " AND (MaHopDong= N'" + MDSolutionEntities.DBModule.RefineString(strDieuKienTimKiem) + "' OR HoTen= N'" + MDSolutionEntities.DBModule.RefineString(strDieuKienTimKiem) + "' )";

                }
                else
                {
                    strSQLWhere += " AND (MaHopDong like N'%" + MDSolutionEntities.DBModule.RefineString(strDieuKienTimKiem) + "%' OR HoTen like N'%" + MDSolutionEntities.DBModule.RefineString(strDieuKienTimKiem) + "%' )";
                }
            }
            return clsHopDong.GetListbyWhere("", strSQLWhere, "", null, null);
        }

        public static DataSet GetDanhSachDenHopDong(long lID, string strDieuKienTimKiem, DonviType dvType, string dvID, Boolean timchinhxac, string CacTramID)
        { // su dung cho phan quyen theo tram.

            string strSQLWhere = " trangthai = 1";//+ " AND ParentID=0"
            if (lID > 0)
            {
                strSQLWhere += "AND ID= " + lID.ToString();
            }
            else
            {
                switch (dvType)
                {
                    case DonviType.Cum: strSQLWhere += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID IN (SELECT ID FROM tbl_Xa WHERE CumID=" + dvID + "))"; break;
                    case DonviType.Xa: strSQLWhere += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + dvID + ")"; break;
                    case DonviType.Thon: strSQLWhere += " AND ThonID=" + dvID; break;
                    case DonviType.ChuHopDong: strSQLWhere += " AND ParentID=" + dvID; break;
                    default: if (CacTramID != "") strSQLWhere += "  AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID IN (SELECT ID FROM tbl_Xa WHERE CumID in(" + CacTramID + ")))"; break;
                }

                if ((timchinhxac) && (strDieuKienTimKiem != ""))
                {

                    strSQLWhere += " AND (MaHopDong= N'" + MDSolutionEntities.DBModule.RefineString(strDieuKienTimKiem) + "' OR HoTen= N'" + MDSolutionEntities.DBModule.RefineString(strDieuKienTimKiem) + "' )";
                }
                else
                {
                    strSQLWhere += " AND (MaHopDong like N'%" + MDSolutionEntities.DBModule.RefineString(strDieuKienTimKiem) + "%' OR HoTen like N'%" + MDSolutionEntities.DBModule.RefineString(strDieuKienTimKiem) + "%' )";
                }
            }
            return clsHopDong.GetListbyWhere("", strSQLWhere, "", null, null);
        }

        public static void UpdateHopDongVuTrong(long HopDongID, long VuTrongID, long trangthai, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = " DELETE FROM tbl_HopDongVuTrong WHERE HopDongID=" + HopDongID.ToString() + " AND VuTrongID=" + VuTrongID.ToString();
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            if (trangthai == 1)
            {
                strSQL = " INSERT INTO tbl_HopDongVuTrong(HopDongID, VuTrongID) VALUES(" + HopDongID.ToString() + "," + VuTrongID.ToString() + ")";
                MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            }
        }
        #endregion
    }
}