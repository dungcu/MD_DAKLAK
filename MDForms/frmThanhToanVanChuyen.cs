using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using Janus.Windows.GridEX;
using DACASUCO.MDForms;
using DACASUCO.MDReport;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.SCREventLog;
using CrystalDecisions.Shared;


namespace MDSolution
{
    public partial class frmThanhToanVanChuyen : Form
    {
        static frmThanhToanVanChuyen _theformThanhToanVanChuyen;
        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmThanhToanVanChuyen OneInstanceFrm
        {
            get
            {
                if (null == _theformThanhToanVanChuyen || _theformThanhToanVanChuyen.IsDisposed)
                {
                    _theformThanhToanVanChuyen = new frmThanhToanVanChuyen();
                }

                return _theformThanhToanVanChuyen;
            }
        }

        private NodeHopDongVanChuyen nHDVC;//= new NodeHopDongVanChuyen();
        private clsHopDongVanChuyen oHDVC = new clsHopDongVanChuyen();
        DataSet DSXE;
        string SoHD = "";
        string KHHD = "";
        DateTime Ngay = DateTime.Now;
        string DVCC = "";
        string DC = "";
        string MST = "";
        string LoaiHD = "Không VAT";
        string HTTT = "Tiền mặt";

        long SoPhieu = 0;// So phieu TT
        long SoCT = 0;//So chung tu khi nop tien the chan luc TT
        double SoTienVC = 0;//Tong tien van chuyen cua xe
        double TienTheChan = 0;// tien the chan nop khi thanh toan
        double TongTienTC = 0;//tong tien the chan, do co the nop lam nhieu lan
        long TTTC = 0;//Thanh toan the chan
        double TienThucThu = 0;
        double TienVAT = 0;
        bool ThemTC = false;
        string SoXeTC = "";
        long HDVC_ID = 0;
        DataSet DS_CB = null;
        public frmThanhToanVanChuyen()
        {
            InitializeComponent();

        }
        public frmThanhToanVanChuyen(string HopDongVCID)
        {
            InitializeComponent();
            LoadCBHDVC();

        }
        private void LoadCBHDVC()
        {
            string sql = "";
            if (txtXeVC.Text == "")
            {
                cboHDVC.DataSource = null;
                sql = "Select ID,TenChuHopDong from tbl_HopDongVanChuyen Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " Order BY TenChuHopDong";
                DS_CB = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                DataRow dr = DS_CB.Tables[0].NewRow();
                dr["ID"] = 0;
                dr["TenChuHopDong"] = "";
                DS_CB.Tables[0].Rows.InsertAt(dr, 0);
                cboHDVC.DisplayMember = "TenChuHopDong";
                cboHDVC.ValueMember = "ID";
                cboHDVC.DataSource = DS_CB.Tables[0];
                cboHDVC.SelectedValue = 0;
            }
            else
            {
                if (rdSoXe.Checked)
                {
                    cboHDVC.DataSource = null;
                    sql = "Select HopDongVanChuyenID,TenChuHopDong from V_TK_XeVC where SoXe Like N'%" + txtXeVC.Text + "%' AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " Order BY TenChuHopDong";
                    DS_CB = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    DataRow dr = DS_CB.Tables[0].NewRow();
                    dr["HopDongVanChuyenID"] = 0;
                    dr["TenChuHopDong"] = "";
                    DS_CB.Tables[0].Rows.InsertAt(dr, 0);
                    cboHDVC.DisplayMember = "TenChuHopDong";
                    cboHDVC.ValueMember = "HopDongVanChuyenID";
                    cboHDVC.DataSource = DS_CB.Tables[0];
                    cboHDVC.SelectedValue = 0;
                }
                else if (rdHDVC.Checked)
                {
                    cboHDVC.DataSource = null;
                    sql = "Select ID,TenChuHopDong from tbl_HopDongVanChuyen Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " AND dbo.BoDauTiengViet(TenChuHopDong) LIKE N'%" + txtXeVC.Text + "%' Order BY TenChuHopDong";
                    DS_CB = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    DataRow dr = DS_CB.Tables[0].NewRow();
                    dr["ID"] = 0;
                    dr["TenChuHopDong"] = "";
                    DS_CB.Tables[0].Rows.InsertAt(dr, 0);
                    cboHDVC.DisplayMember = "TenChuHopDong";
                    cboHDVC.ValueMember = "ID";
                    cboHDVC.DataSource = DS_CB.Tables[0];
                    cboHDVC.SelectedValue = 0;
                }
            }
        }
        private void LoadGHDVC(long HDVCID)
        {
            if (HDVCID > 0)
            {
                DataSet ds = null;
                try
                {
                    string sql = "Select ID, SoXe,HopDongVanChuyenID, LoaiXe from tbl_XeVanChuyen Where HopDongVanChuyenID=" + HDVCID.ToString() + " And VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();// +" AND NKT is NULL";
                    ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                }
                catch
                {
                    GHDVC.DataSource = null;
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GHDVC.SetDataBinding(ds.Tables[0], "");
                }
            }
        }


        private void DoLoadgdvChiTiettamung(string SoXe)
        {
            try
            {

                string strSQL = "";

                strSQL = "SELECT DISTINCT * FROM V_UngVatTuVanChuyen Where SoXe = N'" + SoXe + "' AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " Order By SoChungTu"; ;
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.gdvChitiettamung.SetDataBinding(ds.Tables[0], "");
                }
                else
                {
                    gdvChitiettamung.SetDataBinding(null, "");
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load thông tin xe vận chuyển", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DoLoadgdvChiTietvanchuyen(string SoXe)
        {
            try
            {

                string strSQL = "SELECT * FROM V_VanChuyenMia WHERE DaThanhToanVC =0 AND  SoXe = N'" + SoXe + "' AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " AND HopDongVanChuyenID=" + HDVC_ID.ToString() + " Order by SoPhieuNhap ASC";
                DSXE = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                if (DSXE.Tables[0].Rows.Count > 0)
                {
                    int i = DSXE.Tables[0].Rows.Count;
                    this.gdvChitietvanchuyen.SetDataBinding(DSXE.Tables[0], "");

                    string sql = "Select Max(Sophieu) from tbl_ThanhToanVC where VuTrongID =" + DACASUCO_App.VuTrongID;
                    try
                    {
                        SoPhieu = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null)) + 1;
                    }
                    catch
                    {
                        SoPhieu = 1;
                    }
                    txtSP.Text = SoPhieu.ToString();

                }
                else
                {
                    gdvChitietvanchuyen.SetDataBinding(null, "");
                    txtSP.Text = "";

                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load danh sách vận chuyển mía", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DoLoadUngVatTuInFo(string HopDongVCID, string SoXe, bool kt)
        {
            try
            {

                this.oHDVC.ID = long.Parse(HopDongVCID);
                this.oHDVC.Load(null, null);
                this.lblChuHopDong.Text = oHDVC.MaHopDong + " - " + oHDVC.TenChuHopDong;
                this.lblSoXe.Text = SoXe.ToUpper();
                this.DoLoadgdvChiTiettamung(SoXe);
                if (kt == true)
                {
                    this.DoLoadgdvChiTietvanchuyen(SoXe);
                }

                if ((ThemTC == true) && (SoXeTC != SoXe))
                {
                    string sql = "Delete tbl_UngVatTuVanChuyen Where SoChungTu= " + SoCT.ToString() + " And VutrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    TienTheChan = 0;
                    ThemTC = false;
                    SoHD = "";
                    KHHD = "";
                    Ngay = DateTime.Now;
                    DVCC = "";
                    DC = "";
                    MST = "";
                    LoaiHD = "Không VAT";
                    HTTT = "Tiền mặt";
                    txtVAT.Text = "0";
                }
                uibInThanhToan.Enabled = false;
                cmdHuyTT.Enabled = false;
                btThanhToan.Enabled = true;
                cmdThutienTC.Enabled = true;
                cmdHD.Enabled = true;
                txtVAT.ReadOnly = false;
                chkTC.Enabled = true;
                chkTC.Checked = false;

                if (ThemTC == false)
                {
                    cmdThutienTC.Text = "Thu tiền thế chân";
                    txtTienTC.Text = "0";
                }
                else
                {
                    chkTC.Checked = false;
                    chkTC.Enabled = false;
                }
                GridEXRow gexr = this.gdvChitiettamung.GetTotalRow();
                //SoTienVC = 0;
                TongTienTC = 0;
                TienThucThu = 0;
                TienVAT = 0;
                //SoTienVC = SoTienVCKT;
                if (gexr != null && !string.IsNullOrEmpty(gexr.Cells["DonGia"].Value.ToString()))
                {
                    TongTienTC = long.Parse(gexr.Cells["DonGia"].Value.ToString());
                }
                if (SoTienVC == 0)
                {
                    btThanhToan.Enabled = false;
                    cmdThutienTC.Enabled = false;
                    chkTC.Enabled = false;
                    chkTC.Checked = false;
                    cmdThutienTC.Enabled = false;
                }
                if (TongTienTC == 0)
                {
                    chkTC.Enabled = false;
                    chkTC.Checked = false;
                }
                double VAT = double.Parse(txtVAT.Text);
                TienVAT = Math.Round(VAT * SoTienVC / 100, 0);
                txtTienVAT.Text = TienVAT.ToString("### ### ##0");

                TienThucThu = SoTienVC + TienVAT - TienTheChan;
                editBoxTamung.Text = TongTienTC.ToString("### ### ##0");
                editBoxVanchuyen.Text = SoTienVC.ToString("### ### ##0");
                editBoxTiendu.Text = TienThucThu.ToString("### ### ##0");


            }
            catch
            {

                this.uibInThanhToan.Enabled = false;

                MessageBox.Show("Có lỗi khi lấy thông tin chủ hợp đồng", "Lỗi", MessageBoxButtons.OK);
            }

        }


        public void GetHopDongID(string value)
        {
            oHDVC.ID = long.Parse(value);
        }



        private void uibInThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                frmShowRP2 frm = new frmShowRP2();
                rptTTVC rp = new rptTTVC();
                rp.RecordSelectionFormula = "{V_VanChuyenMia.SoXe}='" + this.GHDVC.GetValue("SoXe").ToString() + "'" + " AND {V_VanChuyenMia.DaThanhToanVC}=" + txtSP.Text + " AND {tbl_ThanhToanVC.SoPhieu}=" + txtSP.Text + " AND {tbl_ThanhToanVC.VuTrongID}=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                frm.RP = rp;
                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.RPtitle = "Thanh toán xe vận chuyển";
                frm.Show();

            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
            }


        }

        private void frmThanhToanVanChuyen_Load(object sender, EventArgs e)
        {

            int widthScreen = Screen.PrimaryScreen.WorkingArea.Width;
            int heightScreen = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = widthScreen;
            this.Height = heightScreen;
            this.WindowState = FormWindowState.Maximized;
            LoadCBHDVC();
            lblSoXe.Text = "";
            txtXeVC.Select();
            btThanhToan.Enabled = false;
            cmdThutienTC.Enabled = false;
            cmdHuyTT.Enabled = false;
            chkTC.Enabled = false;
            try
            {
                cls_VanChuyen_ThongBao objvanchuyen = new cls_VanChuyen_ThongBao();
                objvanchuyen.LoadTop1(null, null);
                lbl_GiaThongBao.Text = objvanchuyen.TuGiaHoTro.ToString();
                lbl_NgayThongBao.Text = objvanchuyen.NgayApDung.ToString("dd/MM/yyyy");
                lbl_ThongBao.Text = objvanchuyen.TenThongBao.ToString();
            }
            catch
            {

                MessageBox.Show("Phải nhập thông báo thanh toán vận chuyển");
            }
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            if (txtSP.Text != "")
            {
                if (TTTC == 1)
                {
                    TienThucThu = TienThucThu + TongTienTC;
                }
                if (TienThucThu < 0)
                {
                    MessageBox.Show("Không thể thanh toán với số tiền âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (SoCT > 0)
                    {
                        string HDVCID = GHDVC.GetValue("HopDongVanChuyenID").ToString();
                        string SoXeVC = GHDVC.GetValue("SoXe").ToString();
                        string sql = "Delete tbl_UngVatTuVanChuyen Where SoChungTu= " + SoCT.ToString() + " And VutrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                        TienTheChan = 0;
                        ThemTC = false;
                        DoLoadUngVatTuInFo(HDVCID, SoXeVC, false);

                    }
                    return;
                }
                try
                {
                    string sql = "Insert Into tbl_ThanhToanVC (SoHD,DVCC, Ngay,LoaiHD,DiaChi,MST,HTTT,HopDongVCID,XeID,SoXe,ThuTienTC,SoTien,VAT,KHHD,SoCT,SoPhieu,TienBangChu,LoaiXe,TTTC,TongTienTC,TienVAT,NgayTT,TienVC,VuTrongID,UserID) Values(" +
                         "N'" + SoHD + "',N'" + DVCC + "'," + MDSolutionEntities.DBModule.RefineDatetime(Ngay) + ",N'" + LoaiHD + "',N'" + DC + "',N'" + MST + "',N'" + HTTT + "'," + cboHDVC.SelectedValue.ToString() + "," +
                         this.GHDVC.GetValue("ID").ToString() + ",N'" + this.GHDVC.GetValue("SoXe").ToString() + "'," + TienTheChan.ToString() + "," + TienThucThu.ToString() + "," +
                         txtVAT.Text + ",N'" + KHHD + "'," + SoCT.ToString() + "," + SoPhieu.ToString() + ",N'" + frmShowRP3.DocSo(TienThucThu).ToString() + "',N'" + this.GHDVC.GetValue("LoaiXe") + "'," + TTTC.ToString() + "," + TongTienTC.ToString() + "," + TienVAT.ToString() + "," + MDSolutionEntities.DBModule.RefineDatetime(dtNgay.Value) + "," + SoTienVC.ToString() + "," + MDSolution.DACASUCO_App.VuTrongID.ToString() + "," + DACASUCO_App.User.ID.ToString() + ")";
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    foreach (GridEXRow row in gdvChitietvanchuyen.GetCheckedRows()) //foreach (DataRow dr in DSXE.Tables[0].Rows)
                    {
                        sql = "Update tbl_NhapMia Set DaThanhToanVC=" + SoPhieu.ToString() + " Where SoPhieuNhap=" + row.Cells["SoPhieuNhap"].Value.ToString() + " And VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    }

                    MessageBox.Show("Đã xác nhận thành công thanh toán cho Xe " + this.GHDVC.GetValue("SoXe").ToString() + ". Số phiếu:" + txtSP.Text, "Thông báo thành công");

                    btThanhToan.Enabled = false;
                    cmdHuyTT.Enabled = true;
                    uibInThanhToan.Enabled = true;
                    cmdThutienTC.Enabled = false;
                    chkTC.Enabled = false;
                    cmdHD.Enabled = false;
                    txtVAT.ReadOnly = true;
                    ThemTC = false;
                    TienTheChan = 0;
                    txtTienTC.Text = "0";
                }
                catch
                {
                    MessageBox.Show("Lỗi khi làm thành toán", "Lỗi");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa thể xác nhận Thanh toán Vận chuyển!" + "\n\n" + "Xe " + this.GHDVC.GetValue("SoXe").ToString() + " không có dữ liệu vận chuyển", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void cmdHuyTT_Click(object sender, EventArgs e)
        {
            string HDVCID = GHDVC.GetValue("HopDongVanChuyenID").ToString();
            string SoXeVC = GHDVC.GetValue("SoXe").ToString();
            string sql = "";
            if (MessageBox.Show("Bạn muốn hủy thanh toán số phiếu " + txtSP.Text + " này?", "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            try
            {
                sql = "Delete tbl_ThanhToanVC Where SoPhieu= " + txtSP.Text + " And VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                if (SoCT > 0)
                {
                    sql = "Delete tbl_UngVatTuVanChuyen Where SoChungTu= " + SoCT.ToString() + " And VutrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                }
                foreach (GridEXRow row in gdvChitietvanchuyen.GetCheckedRows()) //foreach (DataRow dr in DSXE.Tables[0].Rows)
                {
                    sql = "Update tbl_NhapMia Set DaThanhToanVC=0 Where SoPhieuNhap=" + row.Cells["SoPhieuNhap"].Value.ToString() + " And VutrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                }
                SoTienVC = 0;
                editBoxVanchuyen.Text = "0";
                DoLoadUngVatTuInFo(HDVCID, SoXeVC, true);
                MessageBox.Show("Đã hủy thành công Số phiếu " + SoPhieu.ToString(), "Thông báo thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("Lỗi khi hủy thành toán", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GHDVC_Click(object sender, EventArgs e)
        {
            try
            {
                if (GHDVC.GetValue("HopDongVanChuyenID").ToString() != "")
                {
                    SoHD = "";
                    KHHD = "";
                    Ngay = DateTime.Now;
                    DVCC = "";
                    DC = "";
                    MST = "";
                    LoaiHD = "Không VAT";
                    HTTT = "Tiền mặt";
                    txtVAT.Text = "0";
                    DoLoadUngVatTuInFo(GHDVC.GetValue("HopDongVanChuyenID").ToString(), GHDVC.GetValue("SoXe").ToString(), true);
                }
            }
            catch
            {
                return;
            }
        }

        private void txtXeVC_TextChanged(object sender, EventArgs e)
        {
            //string sql = "Select SoXe,HopDongVanChuyenID from tbl_XeVanChuyen Where SoXe=N'" + txtXeVC.Text + "' And VuTrongId="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
            //DataSet ds=MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    cboHDVC.SelectedValue = long.Parse(ds.Tables[0].Rows[0]["HopDongVanChuyenID"].ToString());
            //    DoLoadUngVatTuInFo(cboHDVC.SelectedValue.ToString(),txtXeVC.Text,true);
            //}
            //else
            //{
            //    cboHDVC.SelectedIndex = 0;

            //}
            LoadCBHDVC();
        }

        private void cboHDVC_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboHDVC.SelectedIndex > 0)
            {
                HDVC_ID = long.Parse(cboHDVC.SelectedValue.ToString());
                LoadGHDVC(HDVC_ID);
                if (GHDVC.DataSource != null)
                {
                    string HDVCID = GHDVC.GetValue("HopDongVanChuyenID").ToString();
                    string SoXeVC = GHDVC.GetValue("SoXe").ToString();
                    DoLoadUngVatTuInFo(HDVCID, SoXeVC, true);
                }
            }
            else
            {
                GHDVC.SetDataBinding(null, "");
                txtSP.Text = "";
                lblSoXe.Text = "";
                editBoxTamung.Text = "0";
                editBoxVanchuyen.Text = "0";
                txtTienTC.Text = "0";
                cmdHuyTT.Enabled = false;
                cmdThutienTC.Enabled = false;
                btThanhToan.Enabled = false;
                uibInThanhToan.Enabled = false;
                cmdHuyTT.Enabled = false;
                lblChuHopDong.Text = "";
                lblSoXe.Text = "";
                gdvChitietvanchuyen.SetDataBinding(null, "");
                gdvChitiettamung.SetDataBinding(null, "");
                cmdHD.Enabled = false;
                txtVAT.Text = "";
                SoTienVC = 0;
                TienTheChan = 0;
                TienThucThu = 0;
                TienVAT = 0;
                TongTienTC = 0;
                ThemTC = false;
                editBoxTiendu.Text = "0";
                chkTC.Enabled = false;
            }

        }

        private void cmdThutienTC_Click(object sender, EventArgs e)
        {
            if (ThemTC == false)
            {
                if ((cboHDVC.SelectedIndex > 0) && (GHDVC.GetRows().Length > 0))
                {
                    frmTheChan frm = new frmTheChan(long.Parse(cboHDVC.SelectedValue.ToString()), true);
                    frm.cbLoai.SelectedIndex = 1;
                    frm.ShowDialog();
                    if (frm.CanCel == 1)
                    {
                        return;
                    }
                    else
                    {
                        txtTienTC.Text = frm.SoTien.ToString("### ### ##0");
                        SoCT = long.Parse(frm.txtSCT.Text);
                        TienTheChan = long.Parse(frm.SoTien.ToString());
                        cmdThutienTC.Enabled = false;
                        ThemTC = true;
                        SoXeTC = this.GHDVC.GetValue("SoXe").ToString();
                        cmdThutienTC.Text = "Hủy thu tiền thế chân";
                    }
                }

            }
            else
            {
                if (SoCT > 0)
                {
                    string sql = "Delete tbl_UngVatTuVanChuyen Where SoChungTu= " + SoCT.ToString() + " And VutrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    TienTheChan = 0;
                    ThemTC = false;
                }
            }

            DoLoadUngVatTuInFo(cboHDVC.SelectedIndex.ToString(), this.GHDVC.GetValue("SoXe").ToString(), false);
        }

        private void cmdHD_Click(object sender, EventArgs e)
        {
            frmHDVAT frm = new frmHDVAT();
            frm.ShowDialog();
            if (frm.Cancel == 0)
            {
                SoHD = frm.txtSoHD.Text;
                KHHD = frm.txtKHHD.Text;
                Ngay = frm.dtNgay.Value;
                LoaiHD = frm.cbLoaiHD.Text;
                if (LoaiHD == "Có VAT")
                {
                    txtVAT.Text = "10";
                }
                else
                {
                    txtVAT.Text = "5";
                }
                DVCC = frm.txtDV.Text;
                DC = frm.txtDC.Text;
                MST = frm.txtMST.Text;
                HTTT = frm.cbHTTT.Text;
            }

        }

        private void VAT_TextChanged(object sender, EventArgs e)
        {
            if (txtVAT.Text == "") txtVAT.Text = "0";
            double VAT = double.Parse(txtVAT.Text);
            //double TG=double.Parse(editBoxTiendu.Text.Replace(" ",""));
            TienVAT = Math.Round(VAT * SoTienVC / 100, 0);
            txtTienVAT.Text = TienVAT.ToString("### ### ##0");
            TienThucThu = SoTienVC + TienVAT - TienTheChan;
            editBoxTiendu.Text = TienThucThu.ToString("### ### ##0");

        }
        private void chkTC_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTC.Checked)
            {
                TTTC = 1;
                editBoxTiendu.Text = (TienThucThu + TongTienTC).ToString("### ### ##0");
                editBoxTamung.Text = "0";
                txtVAT.Enabled = false;
                cmdHD.Enabled = false;
                cmdThutienTC.Enabled = false;
            }
            else
            {
                TTTC = 0;
                editBoxTiendu.Text = TienThucThu.ToString("### ### ##0");
                editBoxTamung.Text = TongTienTC.ToString("### ### ##0");
                txtVAT.Enabled = true;
                cmdHD.Enabled = true;
                if (SoTienVC > 0)
                {
                    cmdThutienTC.Enabled = true;
                }
            }
        }

        private void gdvChitietvanchuyen_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
        {
            double TienVCCheck = 0;
            foreach (GridEXRow row in gdvChitietvanchuyen.GetCheckedRows())
            {

                TienVCCheck += double.Parse(row.Cells["TienVC"].Value.ToString());
            }

            SoTienVC = TienVCCheck;
            DoLoadUngVatTuInFo(cboHDVC.SelectedIndex.ToString(), this.GHDVC.GetValue("SoXe").ToString(), false);
        }

        private void txtXeVC_Click(object sender, EventArgs e)
        {
            txtXeVC.Text = "";
        }

        private void cmd_ThamSoVanChuyen_Click(object sender, EventArgs e)
        {
            frm_NhapTB_GiaVC frm = new frm_NhapTB_GiaVC();
            frm.ShowDialog();
        }


    }
}