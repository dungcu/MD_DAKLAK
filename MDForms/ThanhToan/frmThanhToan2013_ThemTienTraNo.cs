using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace DACASUCO.MDForms.ThanhToan
{
    public partial class frmThanhToan2013_ThemTienTraNo : Form
    {
        public frmThanhToan2013_ThemTienTraNo()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                decimal TruGoc = decimal.Parse(txtTruGoc.Text.Replace(",", ""));
                decimal TruLai = decimal.Parse(txtTruLai.Text.Replace(",", ""));
//                string sSqlFormat = @"INSERT INTO [tbl_ThanhToan_LichSu]
//                                   ([HopDongDTID]
//                                   ,[LaNoCu]
//                                   ,[NgayTT]
//                                   ,[TraGoc]
//                                   ,[TraLai]
//                                   ,[SoNoConLai]
//                                   ,[VuTrongID]
//                                   ,[HopDongID]
//                                   ,[SoPhieuID])
//                             VALUES
//                                   ({0}
//                                   ,{1}
//                                   ,{2}
//                                   ,{3}
//                                   ,{4}
//                                   ,{5}
//                                   ,{6}
//                                   ,{7}
//                                   ,{8})";
//                string sSqlInsert = string.Format(sSqlFormat, HopDongDTID,LaNoCu,"getdate()",TruGoc,TruLai,txtSoDuConLai.Text.Replace(",",""),MDSolution.DACASUCO_App.VuTrongID,HopDongID ,SoPhieu );
//                MDSolutionEntities.DBModule.ExecuteNonQuery(sSqlInsert, null, null);

                
//                string sSqlUpdate = "Update tbl_DauTu_DuNo set DuNoChiuLai=DuNoChiuLai-" + TruGoc.ToString() + ",DuNoLai=DuNoLai-" + TruLai.ToString() + " where DauTuID=" + HopDongDTID.ToString();
//                MDSolutionEntities.DBModule.ExecuteNonQuery(sSqlUpdate , null, null);
                string sThanhToan_TruNoDauTu = "ThanhToan_TruNoDauTu {0},{1},{2},{3},{4},{5},{6},{7}";
                sThanhToan_TruNoDauTu = string.Format(sThanhToan_TruNoDauTu, MDSolution.DACASUCO_App.VuTrongID, HopDongID, HopDongDTID, SoPhieu, TruGoc, TruLai, txtSoDuConLai.Text.Replace(",", ""),this.LaNoCu );
                MDSolutionEntities.DBModule.ExecuteNonQuery(sThanhToan_TruNoDauTu  , null, null);


                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch {
                MessageBox.Show("Kiểm tra lại dữ liệu nhập", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public Int64  HopDongDTID{ get; set; }
        public int HopDongID { get; set; }
        public int SoPhieu { get; set; }
        public int LaNoCu{ get; set; }
        public void Calc()
        {
            try
            {
                decimal dTienTruGoc = decimal.Parse(txtTruGoc.Text.Replace(",", ""));
                decimal dDuHienTai = decimal.Parse(txtSoDuHienTai.Text.Replace(",", ""));
                decimal dTruLai = decimal.Parse(txtTruLai.Text.Replace(",", ""));
                txtSoDuConLai.Text = (dDuHienTai - dTienTruGoc - dTruLai).ToString("###,##0");
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại dữ liệu nhập!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTruGoc.Focus();
            }
        }
        private void txtTruGoc_TextChanged(object sender, EventArgs e)
        {
            Calc();
        }

        private void txtTruLai_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal dTienTruGoc = decimal.Parse(txtTruGoc.Text.Replace(",", ""));
                decimal dDuHienTai = decimal.Parse(txtSoDuHienTai.Text.Replace(",", ""));
                decimal dTruLai = decimal.Parse(txtTruLai.Text.Replace(",", ""));
                txtSoDuConLai.Text = (dDuHienTai - dTienTruGoc - dTruLai).ToString("###,##0");
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại dữ liệu nhập!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTruLai .Focus();
            }
        }

        private void txtSoDuHienTai_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click_1(object sender, EventArgs e)
        {
            txtTruGoc.Text = txtNoGoc.Text;
            txtTruLai.Text = txtNoLai.Text;
            Calc();
        }
    }
}
