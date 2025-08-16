using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using MDSolution;
using DACASUCO.MDReport;
using CrystalDecisions.CrystalReports.Engine;
//using DACASUCO.MDReport.ThanhToan;

namespace DACASUCO.MDForms.ThanhToan
{
    public partial class frm_ThanhToan2013_BangTinhLaiCongNoDauTu : Form
    {
        public frm_ThanhToan2013_BangTinhLaiCongNoDauTu()
        {
            InitializeComponent();
        }

        private void txtMaHD_Leave(object sender, EventArgs e)
        {
            
        }
        public DataTable dtHopDong { get; set; }
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
                LoadGrid(dv[0]["ID"].ToString());

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
            LoadGrid("-1");
        }
        void LoadGrid(string  HopDongID)
        {
            string sql = "[ThanhToan_BangTinhLaiCNTH] {0},{1},{2}";
            long TramID = 0;
            if (cbTram.SelectedIndex > 0)
            {
                TramID = long.Parse(cbTram.SelectedValue.ToString());
            }
            sql = string.Format(sql, MDSolution.DACASUCO_App.VuTrongID, TramID.ToString(),HopDongID);
            DataView dv=MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null).Tables[0].DefaultView ;
            dv.RowFilter = "(1=1) ";
            if (!dtTuNgay.IsNullDate )
                dv.RowFilter +=" AND (NgayDenHan>=#"+dtTuNgay.Value.ToString("MM/dd/yyyy")+ "#)";
            if (!dtDenNgay.IsNullDate )
                dv.RowFilter +=" AND (NgayDenHan<=#"+dtDenNgay.Value.AddDays(1).ToString("MM/dd/yyyy")+ "#)";
            grvNoDauTu.SetDataBinding(dv, "");


        }
        frm_ThanhToan2013_TimKiem frmSearch = new frm_ThanhToan2013_TimKiem();
        private void uiButton5_Click(object sender, EventArgs e)
        {
            if (dtHopDong == null)
            {
                dtHopDong = MDSolutionEntities.DBModule.ExecuteQuery("select ID, MaHopDong ,HoTen,Diachi,dbo.BoDauTiengViet(HoTen) as HoTenKhongDau from tbl_HopDong ", null, null).Tables[0];

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

        private void uiButton2_Click(object sender, EventArgs e)
        {
            //Tìm kiếm:
            SearchHD();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (dtHopDong == null)
            {
                dtHopDong = MDSolutionEntities.DBModule.ExecuteQuery("select ID, MaHopDong ,HoTen,Diachi,dbo.BoDauTiengViet(HoTen) as HoTenKhongDau from tbl_HopDong ", null, null).Tables[0];

            }
            string strReportDir = Application.StartupPath + "\\Reports\\";
            DataView dv = dtHopDong.DefaultView;
            dv.RowFilter = "MaHopDong ='" + txtMaHD.Text + "'";
            if (dv.Count == 1)
            {

                txtTenChuMia.Text = dv[0]["HoTen"].ToString();
                txtDiaChi.Text = dv[0]["Diachi"].ToString();
                string HDID = dv[0]["ID"].ToString();
                long TramID = 0;
                if (cbTram.SelectedIndex > 0)
                {
                    TramID = long.Parse(cbTram.SelectedValue.ToString());
                }
                Frm_ReportViewer frm = new Frm_ReportViewer();
                string Tram = cbTram.Text;
                string[] paramNames = new string[] { "@VuTrongID", "@TramID","@HopDongID", "TuNgay", "DenNgay","Tram","NienVu" };
                string[] paraValues = new string[] { MDSolution.DACASUCO_App.VuTrongID.ToString(), TramID.ToString(),HDID, dtTuNgay.IsNullDate ? "01/01/1901" : dtTuNgay.Value.ToString("MM/dd/yyyy"), dtDenNgay.IsNullDate ? "01/01/9999" : dtDenNgay.Value.ToString("MM/dd/yyyy"),Tram,DACASUCO_App.TenVuTrong };
                CommonClass.ShowReport("ThanhToan\\ThanhToan_BangTinhLaiCongNoTH.rpt", "Bảng tính lãi CNTH", paramNames, paraValues, null);
                /*
                frmShowRP2 frm = new frmShowRP2();
                ThanhToan_BangTinhLaiCongNoTH rp = new ThanhToan_BangTinhLaiCongNoTH();
                
                //rp.FileName = strReportDir + "ThanhToan\\ThanhToan_BangTinhLaiCongNoTH.rpt";
                //rp.Load(strReportDir + "ThanhToan\\ThanhToan_BangTinhLaiCongNoTH.rpt");

                // frm.VuTrongIDName = "{View_12.VuTrongID}";
                //rp.SetParameterValue("@VuTrongID", MDSolution.DACASUCO_App.VuTrongID);
                //rp.SetParameterValue("@HopDongID", dv[0]["ID"]);
                //rp.SetParameterValue("TuNgay", dtTuNgay.Value);
                //rp.SetParameterValue("DenNgay", dtDenNgay.Value);
                rp.Database.Tables[0].SetDataSource((System.Data.DataView)grvNoDauTu.DataSource);
                // rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.RP = rp;
                frm.RPtitle = "Các hộ vượt năng suất";
                frm.Show();*/

            }
           
        }

        private void frm_ThanhToan2013_BangTinhLaiCongNoDauTu_Load(object sender, EventArgs e)
        {
            LoadCBTram();
        }
        private void LoadCBTram()
        {
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery("Select ID, Ten from tbl_TramNongVu", null, null);
            DataRow dr = ds.Tables[0].NewRow();
            dr["ID"] = 0;
            dr["Ten"] = "Tất cả các Trạm";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cbTram.DataSource = ds.Tables[0];
            cbTram.ValueMember = "ID";
            cbTram.DisplayMember = "Ten";
        }

        private void cbTram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTenChuMia.Text != "")
            {
                LoadGrid(frmSearch.ID);
            }
        }

        private void txtTenChuMia_TextChanged(object sender, EventArgs e)
        {
            if (txtTenChuMia.Text != "")
            {
                LoadGrid(frmSearch.ID);
            }
        }

    }
}
