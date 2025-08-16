using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using Janus.Windows.GridEX;

namespace DACASUCO.MDForms.ThanhToan
{
    public partial class frmThanhToan_QuanLyNhapTienMat : Form
    {
        public DataTable dtHopDong { get; set; }
        public DataTable dtLichSuTT { get; set; }
        public string HopDongID { get; set; }
        public int SoPhieuID { get; set; }
        public frmThanhToan_QuanLyNhapTienMat()
        {
            InitializeComponent();
        }

        private void txtMaHD_Leave(object sender, EventArgs e)
        {
            SearchHD();
        }
        void SearchHD()
        {
            if (dtHopDong == null)
            {
                dtHopDong = MDSolutionEntities.DBModule.ExecuteQuery("select ID, MaHopDong ,HoTen,Diachi,dbo.BoDauTiengViet(HoTen) as HoTenKhongDau from tbl_HopDong ", null, null).Tables[0];

            }

            DataView dv = dtHopDong.DefaultView;
            dv.RowFilter = "MaHopDong ='" + txtMaHD.Text + "'";
            if (dv.Count == 1)
            {
                txtTenChuMia.Text = dv[0]["HoTen"].ToString();
                txtDiaChi.Text = dv[0]["Diachi"].ToString();
                HopDongID = dv[0]["ID"].ToString();
                LoadNoDauTu(HopDongID);

                //Thong tin tren phieu tt
                //string SoPhieuID =SoPhieuID .ToString();
                //Boolean isNew = ddlSoPhieu.SelectedValue.ToString().Split('_')[1] == "0";
                //LoadPhieuThanhToanDetail(SoPhieuID ,isNew );


            }
            else
            {
                ReLoad();
            }

        }
        void ReLoad()
        {
            txtTenChuMia.Text = "";
            txtDiaChi.Text = "";
            HopDongID = "-1";
            grvNoDauTu.SetDataBinding(null, "");
            grvLichSuThanhToan.SetDataBinding(null, "");
         
        }
        void LoadNoDauTu(string HopDongID)
        {
            grvNoDauTu.SetDataBinding(MDSolutionEntities.DBModule.ExecuteQuery("ThanhToan_DanhSachDauTu " + MDSolution.DACASUCO_App.VuTrongID.ToString() + "," + HopDongID + ",-1", null, null).Tables[0], "");
            btnShowHis.Enabled = grvNoDauTu.GetRows().Length > 0;
            btnThemMoiTruNoDT.Enabled = false;
            btnCancelShowHis.Enabled = false;
        }
        frm_ThanhToan2013_TimKiem frmSearch = new frm_ThanhToan2013_TimKiem();
        private void uiButton5_Click(object sender, EventArgs e)
        {
            if (dtHopDong == null)
            {
                dtHopDong = MDSolutionEntities.DBModule.ExecuteQuery("select ID, MaHopDong ,HoTen,Diachi,dbo.BoDauTiengViet(HoTen) as HoTenKhongDau from tbl_HopDong ", null, null).Tables[0];

            }
            frmSearch.dtDataSearch = dtHopDong;
            frmSearch.txtMaHD.Text = this.txtMaHD.Text;
            frmSearch.txtTenChuMia.Text = this.txtTenChuMia.Text;

            frmSearch.txtMaHD.Focus();
            frmSearch.Search();
            frmSearch.StartPosition = FormStartPosition.CenterScreen;
            frmSearch.ShowDialog();
            this.txtMaHD.Text = frmSearch.MaHD;
            this.SearchHD();
        }
        GridEXRow RowSelected;
        Int64 DauTuID = -1;
        int LaNoCu = -1;
        private void btnShowHis_Click(object sender, EventArgs e)
        {
            if (grvNoDauTu.GetRow().RowType == RowType.Record && !string.IsNullOrEmpty(HopDongID))
            {
                //string SoPhieuID = SoPhieuID .ToString();
                Boolean isNew = true;
                DauTuID = (Int64)grvNoDauTu.GetRow().Cells["ID"].Value;
                LaNoCu = (int)grvNoDauTu.GetRow().Cells["LaNoCu"].Value;
                ShowThanhToanHis(grvNoDauTu.GetRow().Cells["ID"].Value.ToString(), "0", HopDongID, false, "-1", isNew);
                lbThanhToanHis.Text = string.Format(sLableThongBao, grvNoDauTu.GetRow().Cells["SoHDDT"].Value);
                RowSelected = grvNoDauTu.GetRow();
                btnThemMoiTruNoDT.Enabled = true;
                btnCancelShowHis.Enabled = true;
            }
        }
        
        string sLableThongBao = "Thanh toán nợ đầu tư [{0}] theo phiếu này";
        void ShowThanhToanHis(string HDDTID, string LaNoCu, string HDID, Boolean isRefreshDB, string PhieuTTID, Boolean isNew)
        {
            lbThanhToanHis.Text = string.Format(sLableThongBao, "Tất cả các hđ");
            if (dtLichSuTT == null || isRefreshDB)
            {
                dtLichSuTT = MDSolutionEntities.DBModule.ExecuteQuery("ThanhToan_DanhSachLichSuTT " + MDSolution.DACASUCO_App.VuTrongID.ToString() + "," + HDID + ",-1", null, null).Tables[0];
            }
            DataView dv = dtLichSuTT.DefaultView;
            dv.RowFilter = "";
            if (!string.IsNullOrEmpty(HDDTID))
            {
                dv.RowFilter = "(HopDongDTID=" + HDDTID + ") ";
            }
            grvLichSuThanhToan.RootTable.FormatConditions["FormatCurent"].FilterCondition = new Janus.Windows.GridEX.GridEXFilterCondition(grvLichSuThanhToan.RootTable.Columns["SoPhieuID"], Janus.Windows.GridEX.ConditionOperator.Equal, "-1");
            grvLichSuThanhToan.SetDataBinding(dv.ToTable(), "");

        }

        private void btnThemMoiTruNoDT_Click(object sender, EventArgs e)
        {
            frmThanhToan2013_ThemTienTraNo frm = new frmThanhToan2013_ThemTienTraNo();
            frm.txtMaHDDT.Text = RowSelected.Cells["SoHDDT"].Value.ToString();
            frm.txtNoGoc.Text = RowSelected.Cells["DuNoGoc"].Text;
            frm.txtNoLai.Text = RowSelected.Cells["NoLai"].Text;
            frm.txtSoPhaiThu.Text = RowSelected.Cells["SoPhaiThu"].Text;
            frm.txtSoDaThu.Text = RowSelected.Cells["SoTienDaThu"].Text;
            frm.HopDongDTID = (Int64)RowSelected.Cells["ID"].Value;
            frm.LaNoCu = (int)RowSelected.Cells["LaNoCu"].Value;
            frm.HopDongID = int.Parse(HopDongID);
            frm.SoPhieu = 0;
            frm.txtSoDuHienTai.Text = "0";// SoDuHienTai.ToString("###,##0");
            frm.txtSoDuConLai.Text = "0";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(HopDongID))
                {
                    // string SoPhieuID =SoPhieuID .ToString();
                    Boolean isNew = true;
                    //ShowThanhToanHis(grvNoDauTu.GetRow().Cells["ID"].Value.ToString(), grvNoDauTu.GetRow().Cells["LaNoCu"].Value.ToString(), HopDongID, false, SoPhieuID.ToString(), isNew);
                    ShowThanhToanHis(RowSelected.Cells["ID"].Value.ToString(), "0", HopDongID, true, SoPhieuID.ToString(), isNew);
                    btnCancelShowHis.Enabled = true;
                    LoadNoDauTu(HopDongID);
                }
                //Calc();
            }
        }

    }
}
