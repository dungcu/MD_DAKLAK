using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace MDSolution
{
    class clsDanhMucDT_DonViCU
    {
        public long ID = -1;
        public long DanhMucDauTuID = -1;
        public long DonViCUID = -1;
        public clsDanhMucDT_DonViCU()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsDanhMucDT_DonViCU(long lID)
        {
            ID = lID;
        }
        public static void UpdateDanhMucDauTu_DonVi(long DanhMucDauTuID, long DonViCUID, long trangthai, OleDbConnection cn, OleDbTransaction trans)
        {
            if (trangthai == 1)
            {

                string strSQL = " INSERT INTO tbl_DanhMucDT_DonViCU(DanhMucDauTuID, DonViCungUngID) VALUES(" + DanhMucDauTuID.ToString() + "," + DonViCUID.ToString() + ")";
                MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
            }
        }
        public static void DeleteDanhMucDauTu_DonVi(long DanhMucDauTuID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = " DELETE FROM tbl_DanhMucDT_DonViCU WHERE DanhMucDauTuID=" + DanhMucDauTuID.ToString();
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete_DonVi(long DonViCungUngID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = " DELETE FROM tbl_DanhMucDT_DonViCU WHERE DonViCungUngID=" + DonViCungUngID.ToString();
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
    }

}
