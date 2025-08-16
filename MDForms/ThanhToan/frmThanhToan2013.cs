using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using Janus.Windows.GridEX;
using MDSolution;
using DACASUCO.MDReport;

namespace DACASUCO.MDForms.ThanhToan
{
    public partial class frmThanhToan2013 : Form
    {
        public DataTable dtHopDong { get; set; }
        public DataTable dtLichSuTT { get; set; }

        public frmThanhToan2013()
        {
            InitializeComponent();
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {

        }
        void LoadPhieuThanhToanDetail(string PhieuTTID, Boolean isNew)
        {
            LoadThanhToanTienMia(HopDongID, PhieuTTID, isNew);
            LoadNoDauTu(HopDongID, PhieuTTID, isNew);
            ShowThanhToanHis("", "", HopDongID, true, PhieuTTID, isNew);
        }
        public string HopDongID { get; set; }

        private void txtMaHD_Leave(object sender, EventArgs e)
        {
            SearchHD();
        }
        void SearchHD()
        {
            if (dtHopDong == null)
            {
                dtHopDong = MDSolutionEntities.DBModule.ExecuteQuery("select ID, MaHopDong ,HoTen,isnull(Diachi,'') as Diachi,dbo.BoDauTiengViet(HoTen) as HoTenKhongDau from tbl_HopDong ", null, null).Tables[0];

            }

            DataView dv = dtHopDong.DefaultView;
            dv.RowFilter = "MaHopDong ='" + txtMaHD.Text + "'";
            if (dv.Count == 1)
            {
                txtTenChuMia.Text = dv[0]["HoTen"].ToString();
                txtDiaChi.Text = dv[0]["Diachi"].ToString();
                HopDongID = dv[0]["ID"].ToString();
                LoadPhieuThanhToan(HopDongID);

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
            SoPhieuID = -1;
            txtSoPhieu.Text = "";
            HopDongID = "-1";

            if (dtNgayTT.Nullable == true)
            {

                dtNgayTT.Value = DateTime.Now;
            }
            //else
            //{

            //    dtNgayTT.Value
            //}
            grvThanhToanTienMia.SetDataBinding(null, "");
            grvNoDauTu.SetDataBinding(null, "");
            grvLichSuThanhToan.SetDataBinding(null, "");
            LoadPhieuThanhToan("-1");
        }
        public int SoPhieuID { get; set; }
        public int CurentStep { get; set; }
        void LoadPhieuThanhToan(string HopDongID)
        {
            string sql = @"SELECT [ID]
                                  ,[SoPhieu]
                                  ,[HopDongID]
                                  ,[NgayLamTT]
                                  ,[TongTienMia]
                                  ,[TienTruGoc]
                                  ,[TienTruLai]
                                  ,[TienNhanVe]
                                  ,[GhiChu]
                                  ,[DaThanhToan]
                                  ,[VuTrongID]
                                  ,[Step]         
                          FROM tbl_ThanhToan_PhieuTT
                        WHERE [HopDongID]=" + HopDongID.ToString() + @" 
                        AND (DaThanhToan=0 or DaThanhToan is null) AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() +
                       " Order by SoPhieu";
            try
            {
                //Nếu tồn tại phiếu chưa tt:
                DataTable dt = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null).Tables[0];
                SoPhieuID = (int)dt.Rows[0]["ID"];
                txtSoPhieu.Text = dt.Rows[0]["SoPhieu"].ToString();
                dtNgayTT.Value = (DateTime)dt.Rows[0]["NgayLamTT"];
                Boolean isNew = true;
                //LoadThanhToanTienMia(HopDongID, SoPhieuID.ToString(), isNew);
                LoadNoDauTu(HopDongID, SoPhieuID.ToString(), isNew);
                ShowThanhToanHis("", "", HopDongID, true, SoPhieuID.ToString(), isNew);
                //ShowThanhToanHis("", "", HopDongID, false, SoPhieuID.ToString(), isNew);
                CurentStep = (int)dt.Rows[0]["Step"];

                SetCurentStep(CurentStep);
            }
            catch
            {
                SoPhieuID = -1;

            }
            LoadThanhToanTienMia(HopDongID, SoPhieuID.ToString(), true);
            LoadNoDauTu(HopDongID, SoPhieuID.ToString(), true);

        }
        void LoadPhieuThanhToan(int SoPhieuID, string MaHD, string TenHD, string DiaChi)
        {
            string sql = @"SELECT [ID]
                                  ,[SoPhieu]
                                  ,[HopDongID]
                                  ,[NgayLamTT]
                                  ,[TongTienMia]
                                  ,[TienTruGoc]
                                  ,[TienTruLai]
                                  ,[TienNhanVe]
                                  ,[GhiChu]
                                  ,[DaThanhToan]
                                  ,[VuTrongID]
                                  ,[Step]         
                          FROM tbl_ThanhToan_PhieuTT
                        WHERE [ID]=" + SoPhieuID.ToString();
            try
            {
                txtMaHD.Text = MaHD;
                txtTenChuMia.Text = TenHD;
                txtDiaChi.Text = DiaChi;
                //Nếu tồn tại phiếu chưa tt:
                DataTable dt = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null).Tables[0];
                this.SoPhieuID = (int)dt.Rows[0]["ID"];
                txtSoPhieu.Text = dt.Rows[0]["SoPhieu"].ToString();
                HopDongID = dt.Rows[0]["HopDongID"].ToString();

                dtNgayTT.Value = (DateTime)dt.Rows[0]["NgayLamTT"];
                Boolean isNew = true;
                //LoadThanhToanTienMia(HopDongID, SoPhieuID.ToString(), isNew);
                LoadNoDauTu(HopDongID, SoPhieuID.ToString(), isNew);
                ShowThanhToanHis("", "", HopDongID, true, SoPhieuID.ToString(), isNew);
                //ShowThanhToanHis("", "", HopDongID, false, SoPhieuID.ToString(), isNew);
                CurentStep = (int)dt.Rows[0]["Step"];

                //SetCurentStep(int.Parse(dt.Rows[0]["DaThanhToan"].ToString()) == 1 ? 0 : CurentStep);
                SetCurentStep(CurentStep);
                btnDelete.Enabled = CurentStep < 6;

            }
            catch
            {
                SoPhieuID = -1;

            }
            LoadThanhToanTienMia(HopDongID, SoPhieuID.ToString(), true);
            LoadNoDauTu(HopDongID, SoPhieuID.ToString(), true);

        }
        void LoadThanhToanTienMia(string HopDongID, string PhieuTTID, Boolean isNew)
        {
            string sql = @"SELECT        ID, HopDongID, CASE WHEN MuaTheoCCS = 1 THEN ([TongTrongLuong] - [TrongLuongXe] - [TrongLuongTapVat]) * isnull
                             ((SELECT        TOP 1 CCS
                         FROM            tbl_ccs
                         WHERE        SoPhieuCan = SoPhieuNhap), 10) / 10 ELSE ([TongTrongLuong] - [TrongLuongXe] - [TrongLuongTapVat]) END AS TrongLuongMia, TyLeTapVat, TrongLuongTapVat, DonGiaMia, NgayVanChuyen, TienMia, 
                         SoPhieuNhap AS MaCan, SoXe, CASE WHEN DaThanhToan = 0 OR
                         DaThanhToan IS NULL THEN 0 ELSE 1 END AS isChecked, DaThanhToan, MaHDDT, DonGiaVanChuyen, 
                         CASE WHEN TyLeTapVat > 0 THEN dbo.HoTroVanChuyen(MaHDDT, NgayVanChuyen, TongTrongLuong, TrongLuongXe, TyLeTapVat, DonGiaVanChuyen, VuTrongID) ELSE 0 END AS TienTruVanChuyen, ISNULL(TrongLuongTapVat, 0) * ISNULL(DonGiaVanChuyen, 0) / 1000 AS TienVanChuyen, ISNULL(TienMia, 0)-  CASE WHEN TyLeTapVat > 0 THEN dbo.HoTroVanChuyen(MaHDDT, NgayVanChuyen, TongTrongLuong, TrongLuongXe, TyLeTapVat, DonGiaVanChuyen, VuTrongID) ELSE 0 END
                         AS TienThanhToan
                        FROM            dbo.tbl_NhapMia
                        WHERE [HopDongID]=" + HopDongID.ToString() + @" 
                        AND (DaThanhToan=" + (isNew ? "0 or DaThanhToan is null" : PhieuTTID).ToString() + " or DaThanhToan = " + PhieuTTID + " or DaThanhToan = -" + PhieuTTID.Replace("-", "") + " ) AND [TienMia]>0 AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() +
                        " Order by MaCan";
            grvThanhToanTienMia.SetDataBinding(MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null).Tables[0], "");
            grvThanhToanTienMia.RootTable.Columns["Select"].Visible = isNew;
            foreach (GridEXRow gr in grvThanhToanTienMia.GetRows())
            {
                gr.CheckState = (int)gr.Cells["isChecked"].Value == 1 ? RowCheckState.Checked : RowCheckState.Unchecked;
            }
            decimal dTongTienTT = 0;
            long dTongTruCuoc = 0;
            foreach (Janus.Windows.GridEX.GridEXRow row in grvThanhToanTienMia.GetCheckedRows())
            {

                dTongTienTT += (decimal)row.Cells["TienThanhToan"].Value;
                dTongTruCuoc += long.Parse(row.Cells["TienTruVanChuyen"].Value.ToString());

            }
            txtTruCuocTapChat.Text = dTongTruCuoc.ToString("###,##0");
            txtTongTienMiaTT.Text = dTongTienTT.ToString("###,##0");
            if (dTongTienTT == 0) Calc();
            SoDuHienTai = dTongTienTT;
        }

        void LoadNoDauTu(string HopDongID, string PhieuTTID, Boolean isNew)
        {
            grvNoDauTu.SetDataBinding(MDSolutionEntities.DBModule.ExecuteQuery("ThanhToan_DanhSachDauTu " + MDSolution.DACASUCO_App.VuTrongID.ToString() + "," + HopDongID + "," + (isNew ? "-1" : PhieuTTID).ToString() + ", '" + dtNgayTT.Value.ToString("MM/dd/yyyy") + "'", null, null).Tables[0], "");
            btnShowHis.Enabled = grvNoDauTu.GetRows().Length > 0;
            btnThemMoiTruNoDT.Enabled = false;
            btnCancelShowHis.Enabled = false;
        }


        private void grvThanhToanTienMia_RowCheckStateChanged(object sender, Janus.Windows.GridEX.RowCheckStateChangeEventArgs e)
        {
            decimal dTongTienTT = 0;
            long dTongTruTC = 0;
            foreach (Janus.Windows.GridEX.GridEXRow row in grvThanhToanTienMia.GetCheckedRows())
            {

                dTongTienTT += (decimal)row.Cells["ThanhTien"].Value;
                dTongTruTC +=long.Parse(row.Cells["TienTruVanChuyen"].Value.ToString());

            }
            txtTruCuocTapChat.Text = dTongTruTC.ToString("###,##0");
            txtTongTienMiaTT.Text = dTongTienTT.ToString("###,##0");
            SoDuHienTai = dTongTienTT;
        }

        private void panel4_SizeChanged(object sender, EventArgs e)
        {
            btnShowHis.Left = panel4.Width / 2 - btnShowHis.Width / 2;
            btnCancelShowHis.Left = panel4.Width / 2 - btnCancelShowHis.Width / 2;
        }
        string sLableThongBao = "Thanh toán nợ đầu tư [{0}] theo phiếu này";
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
                ShowThanhToanHis(grvNoDauTu.GetRow().Cells["ID"].Value.ToString(), "0", HopDongID, false, SoPhieuID.ToString(), isNew);
                lbThanhToanHis.Text = string.Format(sLableThongBao, grvNoDauTu.GetRow().Cells["SoHDDT"].Value + "/" + grvNoDauTu.GetRow().Cells["DanhMucDT"].Value);
                try
                {
                    RowSelected.Cells["SelectRow"].Image = null;
                }
                catch { }
                RowSelected = grvNoDauTu.GetRow();
                grvNoDauTu.GetRow().Cells["SelectRow"].Image = imageList1.Images[0];
                btnThemMoiTruNoDT.Enabled = true;
                btnCancelShowHis.Enabled = true;
            }
        }
        public void SetCurentStep(int step)
        {
            lbHelp.Text = "";
            pnStep1.Enabled = false;
            pnStep2.Enabled = false;
            pnStep3.Enabled = false;
            pnStep4.Enabled = false;
            G1_ThongTinChung.Enabled = false;
            G2_ThanhToan.Enabled = false;
            G3_TruNo.Enabled = false;
            G4_TongHop.Enabled = false;
            btnDelete.Enabled = true;
            switch (step)
            {
                case 1:
                    pnStep1.Enabled = true;
                    G1_ThongTinChung.Enabled = true;
                    txtMaHD.Focus();
                    btnDelete.Enabled = false;
                    lbHelp.Text = "Chọn \"Chủ mía\" cần làm thanh toán";
                    break;
                case 2:
                    pnStep2.Enabled = true;
                    G2_ThanhToan.Enabled = true;
                    G_ThanhToan.Selected = true;
                    lbHelp.Text = "Chọn \"Phiếu cân\" để làm thanh toán";

                    break;
                case 3:
                    pnStep3.Enabled = true;
                    G3_TruNo.Enabled = true;
                    G_TruNo.Selected = true;
                    lbHelp.Text = "Chọn những khoản đầu tu cần trừ nợ";

                    break;
                case 4:
                    pnStep4.Enabled = true;
                    G4_TongHop.Enabled = true;
                    lbHelp.Text = "Nhấn \"Thanh toán\" để xác nhân đã thanh toán và in phiếu";
                    btnIn.Enabled = false;
                    btnThanhToan.Enabled = true;
                    break;
                case 5:
                    pnStep4.Enabled = true;
                    G4_TongHop.Enabled = true;
                    lbHelp.Text = "";
                    btnIn.Enabled = true;
                    btnThanhToan.Enabled = false;
                    break;
                default:
                    break;
            }
        }
        void Calc()
        {
            try
            {
                string sql = "Select isnull(sum([Sotien]),0) from [tbl_TienTraNo] where SoPhieuID={0} and VuTrongID={1} and HopDongID={2}";
                sql = string.Format(sql, SoPhieuID, MDSolution.DACASUCO_App.VuTrongID, HopDongID);
                decimal TongTienNhap = 0;
                decimal.TryParse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null), out TongTienNhap);
                txtTienMat.Text = TongTienNhap.ToString("###,##0");
                DataView dv = dtLichSuTT.DefaultView;
                dv.RowFilter = "SoPhieuID=" + SoPhieuID.ToString();
                decimal TongTruGoc = 0;
                decimal TongTruLai = 0;
                foreach (DataRowView dr in dv)
                {
                    TongTruGoc += (decimal)dr["TraGoc"];
                    TongTruLai += (decimal)dr["TraLai"];
                }
                txtTruGoc.Text = TongTruGoc.ToString("###,##0");
                txtTruLai.Text = TongTruLai.ToString("###,##0");
                txtNhanVe.Text = (decimal.Parse(txtTongTienMiaTT.Text.Replace(",", "")) + TongTienNhap - TongTruGoc - TongTruLai - decimal.Parse(txtTruCuocTapChat.Text.Replace(",", ""))).ToString("###,##0");
                
            }
            catch { }
        }
        void ShowThanhToanHis(string HDDTID, string LaNoCu, string HDID, Boolean isRefreshDB, string PhieuTTID, Boolean isNew)
        {
            lbThanhToanHis.Text = string.Format(sLableThongBao, "Tất cả các hđ");
            try
            {
                RowSelected.Cells["SelectRow"].Image = null;
            }
            catch { }
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
            grvLichSuThanhToan.RootTable.FormatConditions["FormatCurent"].FilterCondition = new Janus.Windows.GridEX.GridEXFilterCondition(grvLichSuThanhToan.RootTable.Columns["SoPhieuID"], Janus.Windows.GridEX.ConditionOperator.Equal, SoPhieuID);
            grvLichSuThanhToan.SetDataBinding(dv.ToTable(), "");

        }

        private void grvLichSuThanhToan_SelectionChanged(object sender, EventArgs e)
        {
            btnShowHis.Enabled = true;
        }

        private void btnCancelShowHis_Click(object sender, EventArgs e)
        {

            //
            if (MessageBox.Show("Bạn muốn hủy thanh toán cho mục đầu tưu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                btnThemMoiTruNoDT.Enabled = false;
                lbThanhToanHis.Text = string.Format(sLableThongBao, "Tất cả các hđ");
                if (!string.IsNullOrEmpty(HopDongID) && DauTuID > 0)
                {
                    string sThanhToan_TruNoDauTu = "[ThanhToan_HuyTruNoDauTu] {0},{1},{2},{3},{4}";
                    sThanhToan_TruNoDauTu = string.Format(sThanhToan_TruNoDauTu, MDSolution.DACASUCO_App.VuTrongID, HopDongID, SoPhieuID, DauTuID, LaNoCu);
                    MDSolutionEntities.DBModule.ExecuteNonQuery(sThanhToan_TruNoDauTu, null, null);
                    //string SoPhieuID =SoPhieuID .ToString();
                    Boolean isNew = true;
                    ShowThanhToanHis("", "", HopDongID, true, SoPhieuID.ToString(), isNew);
                    DauTuID = -1;
                    LaNoCu = -1;
                    LoadNoDauTu(HopDongID.ToString(), SoPhieuID.ToString(), true);
                    Calc();
                }
            }
        }
        void grvNoDauTu_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.Record && Decimal.Parse(e.Row.Cells["NoLai"].Value.ToString()) < 1 && Decimal.Parse(e.Row.Cells["DuNoGoc"].Value.ToString()) < 1)
            {
                e.Row.RowStyle = new GridEXFormatStyle();
                e.Row.RowStyle.FontStrikeout = TriState.True;
            }
        }
        public decimal SoDuHienTai { get; set; }
        private void btnThemMoiThanhToan_Click(object sender, EventArgs e)
        {
            foreach (GridEXRow gr in grvLichSuThanhToan.GetRows())
            {
                if ((int)gr.Cells["SoPhieuID"].Value == SoPhieuID)
                {
                    if (MessageBox.Show("HĐĐT này đã trừ nợ trên phiếu này, bạn có muốn tiếp tục trừ nợ cho khoản đầu tư này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                        return;
                    break;
                }
            }
            frmThanhToan2013_ThemMoi frm = new frmThanhToan2013_ThemMoi();
            frm.txtMaHDDT.Text = RowSelected.Cells["SoHDDT"].Value.ToString();
            frm.txtNoGoc.Text = RowSelected.Cells["DuNoGoc"].Text;
            frm.txtNoLai.Text = RowSelected.Cells["NoLai"].Text;
            frm.txtSoPhaiThu.Text = RowSelected.Cells["SoPhaiThu"].Text;
            frm.txtSoDaThu.Text = RowSelected.Cells["SoTienDaThu"].Text;
            frm.HopDongDTID = (Int64)RowSelected.Cells["ID"].Value;
            frm.LaNoCu = (int)RowSelected.Cells["LaNoCu"].Value;
            frm.HopDongID = int.Parse(HopDongID);
            frm.SoPhieu = SoPhieuID;
            frm.NgayTra = dtNgayTT.Value;
            frm.txtSoDuHienTai.Text = txtNhanVe.Text;// SoDuHienTai.ToString("###,##0");
            frm.txtSoDuConLai.Text = txtNhanVe.Text;
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
                    LoadNoDauTu(HopDongID, SoPhieuID.ToString(), true);
                }
                Calc();
            }
        }


        private void txtTongTienMiaTT_TextChanged(object sender, EventArgs e)
        {
            Calc();
        }

        private void uiButton7_Click(object sender, EventArgs e)
        {
            try
            {
                int iHDID = int.Parse(HopDongID);
                if (iHDID < 0)
                {
                    MessageBox.Show("Mã hợp đồng chủ mía không hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaHD.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mã hợp đồng chủ mía không hợp lệ!" + ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHD.Focus();
                return;
            }

            if (SoPhieuID < 1)
            {//Chua có phiếu=>tao phiếu mới.
                string sqlGetSoPhieu = "Select Max(SoPhieu) from tbl_ThanhToan_PhieuTT where VuTrongID=" + DACASUCO_App.VuTrongID.ToString();
                string sSoPhieu = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sqlGetSoPhieu, null, null);
                int iSoPhieu = 1;
                if (!string.IsNullOrEmpty(sSoPhieu))
                {
                    iSoPhieu = int.Parse(sSoPhieu) + 1;
                }
                string sqlInsertSoPhieu = @"INSERT INTO [tbl_ThanhToan_PhieuTT]
                                               ([SoPhieu]
                                               ,[HopDongID]
                                               ,[NgayLamTT]
                                               ,[TongTienMia]
                                               ,[TienTruGoc]
                                               ,[TienTruLai]
                                               ,[TienNhanVe]
                                               ,[GhiChu]
                                               ,[DaThanhToan]
                                               ,[VuTrongID]
                                               ,[Step])
                                         VALUES
                                               ({0}
                                               ,{1}
                                               ,{2}
                                               ,{3}
                                               ,{4}
                                               ,{5}
                                               ,{6}
                                               ,N'{7}'
                                               ,{8}
                                               ,{9}
                                               ,{10})";
                sqlInsertSoPhieu = string.Format(sqlInsertSoPhieu, iSoPhieu, HopDongID, "'" + dtNgayTT.Value.ToString("MM/dd/yyyy") + "'", 0, 0, 0, 0, " ", 0, MDSolution.DACASUCO_App.VuTrongID, 2);
                MDSolutionEntities.DBModule.ExecuteNonQuery(sqlInsertSoPhieu, null, null);
                LoadPhieuThanhToan(HopDongID);
                dtDSPhieuTT = null;
            }
            SetCurentStep(2);
        }

        private void uiButton8_Click(object sender, EventArgs e)
        {
            if (grvThanhToanTienMia.GetCheckedRows().Length < 1)
            {
                if (MessageBox.Show("Bạn chưa chọn phiếu thanh toán mía, bạn muốn tiếp tục?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    grvThanhToanTienMia.Focus();
                    return;
                }
            }
            foreach (GridEXRow jr in this.grvThanhToanTienMia.GetCheckedRows())
            {
                GridEXCell jc = jr.Cells["ID"];
                string ID = jc.Value.ToString();
                string sqlUpdate = @"UPDATE [tbl_NhapMia] SET [DaThanhToan]=-" + SoPhieuID + " WHERE [ID]=" + ID;
                MDSolutionEntities.DBModule.ExecuteNonQuery(sqlUpdate, null, null);
            }

            string sqlUpdateTT = @"UPDATE [tbl_ThanhToan_PhieuTT] SET [Step]=3 WHERE [ID]=" + SoPhieuID;
            MDSolutionEntities.DBModule.ExecuteNonQuery(sqlUpdateTT, null, null);

            string sqlUpdateOrInsert_DauTu_DuNo = @"ThanhToan_ChuanBiDuLieuTT_DauTu_DuNo {0},{1},{2}";
            sqlUpdateOrInsert_DauTu_DuNo = string.Format(sqlUpdateOrInsert_DauTu_DuNo, MDSolution.DACASUCO_App.VuTrongID, HopDongID, "N'" + dtNgayTT.Value.ToString("MM/dd/yyyy") + "'");
            MDSolutionEntities.DBModule.ExecuteNonQuery(sqlUpdateOrInsert_DauTu_DuNo, null, null);
            SetCurentStep(3);
        }

        private void uiButton10_Click(object sender, EventArgs e)
        {
            //string sqlUpdate = @"UPDATE [tbl_NhapMia] SET [DaThanhToan]=" + SoPhieuID + " WHERE [DaThanhToan]=-" + SoPhieuID;
            //MDSolutionEntities.DBModule.ExecuteNonQuery(sqlUpdate, null, null);
            //string sqlUpdateTT = @"UPDATE [tbl_ThanhToan_PhieuTT] SET [Step]=4 WHERE [ID]=" + SoPhieuID;
            //MDSolutionEntities.DBModule.ExecuteNonQuery(sqlUpdateTT, null, null);
            //string sqlUpdate = @"UPDATE [tbl_NhapMia] SET [DaThanhToan]=" + SoPhieuID + " WHERE [DaThanhToan]=-" + SoPhieuID;
            //MDSolutionEntities.DBModule.ExecuteNonQuery(sqlUpdate, null, null);
            //1. Chuyển bước tiếp theo:
            string sqlUpdateTT = @"UPDATE [tbl_ThanhToan_PhieuTT] SET [Step]=4 WHERE [ID]=" + SoPhieuID;
            MDSolutionEntities.DBModule.ExecuteNonQuery(sqlUpdateTT, null, null);
            //2. Thêm mới những hđ đt chưa trừ nợ(trư lãi 0, gốc 0):
            /*  Boolean isInsert = false;
              foreach (Janus.Windows.GridEX.GridEXRow gr in grvNoDauTu.GetRows())
              {
                  int HDDauTuID = (int)gr.Cells["ID"].Value;
                  string sqlCheck = @"SELECT COUNT( [HopDongDTID] )      
                                      FROM [tbl_ThanhToan_LichSu]
                                      WHERE [HopDongDTID] ={0} AND [VuTrongID]={1} AND [HopDongID]={2} AND [SoPhieuID]={3}";
                  sqlCheck = string.Format(sqlCheck, HDDauTuID, MDSolution.DACASUCO_App.VuTrongID, HopDongID, SoPhieuID);
                  if (MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sqlCheck,null,null ) == "0")
                  {
                      string sThanhToan_TruNoDauTu = "ThanhToan_TruNoDauTu {0},{1},{2},{3},{4},{5},{6}";
                      sThanhToan_TruNoDauTu = string.Format(sThanhToan_TruNoDauTu, MDSolution.DACASUCO_App.VuTrongID, HopDongID, HDDauTuID, SoPhieuID, 0, 0, txtNhanVe.Text.Replace(".", ""));
                      MDSolutionEntities.DBModule.ExecuteNonQuery(sThanhToan_TruNoDauTu, null, null);
                      isInsert = true;
                  }
              }
              if (isInsert)
              {
                  ShowThanhToanHis("", "", HopDongID, true, SoPhieuID.ToString(), true );
              }
             */
            SetCurentStep(4);
        }

        private void frmThanhToan2013_Load(object sender, EventArgs e)
        {
            dtNgayTTTim.Value = DateTime.Now;
            SetCurentStep(1);
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            //1.Cập nhật bảng nhập mía dathanhtoan=sophieu:
            string sqlUpdate = @"UPDATE [tbl_NhapMia] SET [DaThanhToan]=" + SoPhieuID + " WHERE [DaThanhToan]=-" + SoPhieuID;
            MDSolutionEntities.DBModule.ExecuteNonQuery(sqlUpdate, null, null);

            //2.Cập nhật lãi tồn,set dunolai=0 cho lần thanh toán tiếp theo.
            sqlUpdate = @"UPDATE [tbl_DauTu_DuNo] SET LaiTon=LaiTon+[DuNoLai], [DuNoLai]=0,[NgayTinhLai]= '" + dtNgayTT.Value.ToString("MM/dd/yyyy") + "' where DauTuID in (select HopDongDTID from tbl_ThanhToan_LichSu where SoPhieuID=" + SoPhieuID + ")";
            MDSolutionEntities.DBModule.ExecuteNonQuery(sqlUpdate, null, null);
            //3. Cập nhật lại phiếu thanh toán.
            string sqlUpdateTT = @"UPDATE [tbl_ThanhToan_PhieuTT] SET [Step]=5,DaThanhToan=1,TongTienMia=" + txtTongTienMiaTT.Text.Replace(",", "")
                + ", TienTruGoc=" + double.Parse(txtTruGoc.Text.Replace(",", ""))
                + ", TienTruLai=" + double.Parse(txtTruLai.Text.Replace(",", ""))
                + ", CuocTapChat=" + double.Parse(txtTruCuocTapChat.Text.Replace(",", "")) 
                + ", TienNhanVe=" + double.Parse(txtNhanVe.Text.Replace(",", ""))
                + ", TienBangChu=N'" + Utils.DocSo(double.Parse(txtNhanVe.Text.Replace(",", ""))) + "'"
                + " WHERE [ID]=" + SoPhieuID;
            MDSolutionEntities.DBModule.ExecuteNonQuery(sqlUpdateTT, null, null);
            //string sql = "ThanhToan_UpdateBangTongHop {0},{1},{2}";
            //sql = string.Format(sql, MDSolution.DACASUCO_App.VuTrongID, HopDongID, SoPhieuID);
            //MDSolutionEntities.DBModule.ExecuteNonQuery(sql, null, null);
            //dtDSPhieuTT = null;


            //string sqlUpdate = @"UPDATE [tbl_NhapMia] SET [DaThanhToan]=" + SoPhieuID + " WHERE [DaThanhToan]=-" + SoPhieuID;
            //MDSolutionEntities.DBModule.ExecuteNonQuery(sqlUpdate, null, null);
            //string sqlUpdateTT = @"UPDATE [tbl_ThanhToan_PhieuTT] SET [Step]=4 WHERE [ID]=" + SoPhieuID;
            //MDSolutionEntities.DBModule.ExecuteNonQuery(sqlUpdateTT, null, null);
            //In báo cáo:
            btnIn.Enabled = true;
            btnThanhToan.Enabled = false;
            //SetCurentStep(0);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            long TongTienNhap = long.Parse(txtTienMat.Text.Replace(",", ""));
            Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "ST", "SoPhieuID", "VuTrongID" };
            string[] paraValues = new string[] { TongTienNhap.ToString(), SoPhieuID.ToString(), DACASUCO_App.VuTrongID.ToString() };
            CommonClass.ShowReport("ThanhToan\\rpt_ThanhToan2013.rpt", "Phiếu thanh toán", paramNames, paraValues, null);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            SetCurentStep(1);
            ReLoad();
            txtMaHD.Text = "";
            HopDongID = "-1";
            btnThanhToan.Enabled = true;
            btnIn.Enabled = false;

        }

        private void grvNoDauTu_SelectionChanged(object sender, EventArgs e)
        {
            btnShowHis.Enabled = true;

        }
        frm_ThanhToan2013_TimKiem frmSearch = new frm_ThanhToan2013_TimKiem();
        private void uiButton5_Click(object sender, EventArgs e)
        {
            if (dtHopDong == null)
            {
                dtHopDong = MDSolutionEntities.DBModule.ExecuteQuery("select ID, MaHopDong ,HoTen,isnull(Diachi,'') as Diachi,dbo.BoDauTiengViet(HoTen) as HoTenKhongDau from tbl_HopDong ", null, null).Tables[0];

            }
            frmSearch.dtDataSearch = dtHopDong;
            frmSearch.txtMaHD.Text = "";
            frmSearch.txtTenChuMia.Text = "";

            frmSearch.txtMaHD.Focus();
            frmSearch.Search();
            frmSearch.StartPosition = FormStartPosition.CenterScreen;
            frmSearch.ShowDialog();
            this.txtMaHD.Text = frmSearch.MaHD;
            this.SearchHD();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Check co phieu tt nao sau phieu nay?
            if (MDSolutionEntities.DBModule.ExecuteQuery("select * from tbl_ThanhToan_PhieuTT where HopDongID=" + HopDongID + " and ID>" + SoPhieuID, null, null).Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Không thể hủy phiếu thanh toán vì hợp đồng đã làm phiếu thanh toán sau phiếu này.");
                return;
            }
            frmThanhToan2013_Huy frm = new frmThanhToan2013_Huy();

            frm.dtLichSuTT = MDSolutionEntities.DBModule.ExecuteQuery("ThanhToan_DanhSachLichSuTT " + MDSolution.DACASUCO_App.VuTrongID.ToString() + "," + this.HopDongID + "," + SoPhieuID.ToString(), null, null).Tables[0];

            frm.HopDongID = int.Parse(HopDongID);
            frm.SoPhieu = SoPhieuID;

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                SetCurentStep(1);
                ReLoad();
                txtMaHD.Text = "";
                HopDongID = "-1";
                btnThanhToan.Enabled = true;
                btnIn.Enabled = false;
                SearchHD();
                dtDSPhieuTT = null;
            }
            grvDSTT.Refresh();
        }

        private void G1_ThongTinChung_Click(object sender, EventArgs e)
        {

        }
        DataTable dtDSPhieuTT;
        private void btnTimPhieu_Click(object sender, EventArgs e)
        {
            if (dtDSPhieuTT == null)
            {
                dtDSPhieuTT = MDSolutionEntities.DBModule.ExecuteQuery("select tbl_ThanhToan_PhieuTT.ID,(select sum([TongTrongLuong]-[TrongLuongXe]-[TrongLuongTapVat]) from tbl_NhapMia where DaThanhToan=tbl_ThanhToan_PhieuTT.ID )as TrongLuongMia ,DaThanhToan,SoPhieu,MaHopDong ,HoTen ,NgayLamTT,TongTienMia,TienTruGoc ,TienTruLai ,TienNhanVe ,HopDongID,isnull(Diachi,'') as Diachi, dbo.tbl_ThanhToan_PhieuTT.CuocTapChat from tbl_ThanhToan_PhieuTT join tbl_HopDong on HopDongID=tbl_HopDong.ID  where SoPhieu>-1 AND (DaHuy is null or DaHuy<>1) and VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString(), null, null).Tables[0];
            }
            if (dtHopDong == null)
            {
                dtHopDong = MDSolutionEntities.DBModule.ExecuteQuery("select ID, MaHopDong ,HoTen,isnull(Diachi,'') as Diachi,dbo.BoDauTiengViet(HoTen) as HoTenKhongDau from tbl_HopDong ", null, null).Tables[0];

            }
            DataView dvDSPhieu = dtDSPhieuTT.DefaultView;
            DataView dvHD = dtHopDong.DefaultView;
            dvDSPhieu.RowFilter = "(1=1) ";
            dvHD.RowFilter = "(1=1) ";
            if (!string.IsNullOrEmpty(txtSoPhieuTim.Text.Trim()))
            {
                int SoPhieuTim;
                if (!int.TryParse(txtSoPhieuTim.Text.Trim(), out  SoPhieuTim))
                {
                    txtSoPhieuTim.Text = "";
                }
                else
                {
                    dvDSPhieu.RowFilter += " AND ( SoPhieu =" + SoPhieuTim.ToString() + ") ";
                }
            }
            if (!dtNgayTTTim.IsNullDate)
            {
                dvDSPhieu.RowFilter += " AND ( NgayLamTT >= #" + dtNgayTTTim.Value.ToString("MM/dd/yyyy") + "#) ";

            }
            if (!dtDenNgay.IsNullDate)
            {

                dvDSPhieu.RowFilter += " AND ( NgayLamTT < #" + dtDenNgay.Value.AddDays(1).ToString("MM/dd/yyyy") + "#) ";
            }

            if (!string.IsNullOrEmpty(txtMaHDTim.Text))
                dvHD.RowFilter += " AND (MaHopDong LIKE  '%" + txtMaHDTim.Text.Replace("'", "") + "%')";
            if (!string.IsNullOrEmpty(txtHoTenTim.Text))
                dvHD.RowFilter += " AND ((HoTen LIKE  '%" + txtHoTenTim.Text.Replace("'", "") + "%') OR (HoTenKhongDau LIKE  '%" + txtHoTenTim.Text.Replace("'", "") + "%'))";

            var dtReturn =
                from objPhieuTT in dvDSPhieu.ToTable().AsEnumerable()
                join objHD in dvHD.ToTable().AsEnumerable() on objPhieuTT.Field<int>("HopDongID") equals objHD.Field<int>("ID")
                select objPhieuTT;
            try
            {
                grvDSTT.SetDataBinding(dtReturn.CopyToDataTable<DataRow>(), "");
            }
            catch { grvDSTT.SetDataBinding(null, ""); }
            grvDSTT.Refresh();
        }

        private void btnNhapTienTraNo_Click(object sender, EventArgs e)
        {
            frmThanhToan2013_NhapTienTraNo frm = new frmThanhToan2013_NhapTienTraNo();

            frm.HopDongID = int.Parse(HopDongID);
            frm.SoPhieu = SoPhieuID;
            frm.grvNoDauTu.SetDataBinding(MDSolutionEntities.DBModule.ExecuteQuery("ThanhToan_DanhSachDauTu " + MDSolution.DACASUCO_App.VuTrongID.ToString() + "," + HopDongID + ", -1", null, null).Tables[0], "");
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(HopDongID))
                {
                    LoadThanhToanTienMia(HopDongID, SoPhieuID.ToString(), true);
                    Calc();
                }

            }
        }

        private void grvDSTT_LinkClicked(object sender, ColumnActionEventArgs e)
        {
            //tabLamTT.Focus();
            LoadPhieuThanhToan((int)grvDSTT.GetRow().Cells["ID"].Value, (string)grvDSTT.GetRow().Cells["MaHopDong"].Value, (string)grvDSTT.GetRow().Cells["HoTen"].Value, (string)grvDSTT.GetRow().Cells["DiaChi"].Value);
            mainTabTT.SelectedTab = tabLamTT;
        }

        private void lkIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MDReport.Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "VuTrongID", "TuNgay", "DenNgay", "SoPhieu", "MaHD", "HoTen" };
            object[] paraValues = new object[] { MDSolution.DACASUCO_App.VuTrongID.ToString(), dtNgayTTTim.IsNullDate ? new DateTime(1901, 1, 1) : dtNgayTTTim.Value, dtDenNgay.IsNullDate ? new DateTime(9999, 1, 1) : dtDenNgay.Value, txtSoPhieuTim.Text.Length > 0 ? txtSoPhieuTim.Text : "-1", "*" + txtMaHDTim.Text + "*", "*" + txtHoTenTim.Text + "*" };
            CommonClass.ShowReport("ThanhToan\\ThanhToan_TongHop.rpt", "Danh sách thanh toán", paramNames, paraValues, null);
        }

        private void txtMaHD_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SearchHD();
            }

        }

        private void btnTinhLai_Click(object sender, EventArgs e)
        {
            dtNgayTT.Nullable = false;
            dtNgayTT.ReadOnly = false;
            dtNgayTT.Enabled = true;

            //DateTime dtNgayChotLaiVu = dtNgayTT.Value;
            ReLoad();

            //            //try
            //            //{
            //            //    dtNgayChotLaiVu = (DateTime)DBModule.ExecuteQuery("select [NgayChotTinhLaiDauTu] from [tbl_VuTrong] where ID=" + MDSolutionApp.VuTrongID, null, null).Tables[0].Rows[0][0];
            //            //}
            //            //catch (Exception exx)
            //            //{
            //            //    MessageBox.Show("Chưa thiết lập ngày chốt lãi vụ."); return;
            //            //}

            //            //if (dtNgayChotLaiVu > dtNgayLap.Value) dtNgayChotLaiVu = dtNgayLap.Value;
            //            if (grvNoDauTu.GetCheckedRows().Length == 0)
            //            {
            //                MessageBox.Show("Bạn chưa chọn dòng đầu tư nào để tính lãi", "Thông báo");
            //                return;
            //            }

            //            if (MessageBox.Show("Bạn muốn tính tiền lãi cho các khoản đầu tư đang chọn đến ngày " + dtNgayChotLaiVu.ToString("dd/MM/yyyy") + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //            {
            //                string sql = "update tbl_dautu set TienLai=dbo.Tinh_Lai_DauTu(SoTien, ISNULL(LaiSuat, 0), NgayDauTu, '" + dtNgayChotLaiVu.ToString("yyyy-MM-dd") + @"', 
            //                      DanhMucDauTuID) ,NgayChotTinhLai='" + dtNgayChotLaiVu.ToString("yyyy-MM-dd") + "' where VuTrongID=" + DACASUCO_App.VuTrongID  + " AND HopDongID=" + HopDongID + " ";
            //                string sqlDauTuIDS = "";
            //                string sql2 = "execute sp_2016_TinhLaiKhoanVayKhac {0}, '" + dtNgayChotLaiVu.ToString("yyyy-MM-dd") + @"';";
            //                string sqlExecute = "";
            //                foreach (Janus.Windows.GridEX.GridEXRow row in grvNoDauTu.GetCheckedRows())
            //                {

            //                    if (row.RowType == RowType.Record)
            //                    {
            //                        if (row.Cells["DanhMucDauTuID"].Value.ToString() == "207196")
            //                        {
            //                            sqlExecute += string.Format(sql2, row.Cells["ID"].Value);
            //                        }
            //                        else
            //                        {
            //                            if (string.IsNullOrEmpty(sqlDauTuIDS))
            //                                sqlDauTuIDS += row.Cells["ID"].Value;
            //                            else
            //                                sqlDauTuIDS += "," + row.Cells["ID"].Value;
            //                        }
            //                    }
            //                }
            //                if (!string.IsNullOrEmpty(sqlDauTuIDS))
            //                    sql += " AND ID in (" + sqlDauTuIDS + ");" + sqlExecute;
            //                else
            //                    sql = sqlExecute;
            //                DBModule.ExecuteNonQuery(sql, null, null);
            //                MessageBox.Show("Đã cập nhật thành công tiền lãi cho toàn bộ đầu tư.", "Thông báo");

            //                /// xem load phần này

            //                //LoadAll();
            //                //TinhTongCo();
            //                //TinhTongTruNo();
            //}

        }
    }
}
