using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using DACASUCO.MDForms.ThanhToan;
using MDSolution;

namespace DACASUCO.MDReport.DakNongReport
{
    public partial class RPT_SoChiTietCongNoThuMuaMia : Form
    {
        public DataTable dtHopDong { get; set; }
        public RPT_SoChiTietCongNoThuMuaMia()
        {
            InitializeComponent();
        }

        void SearchHD()
        {
            if (dtHopDong == null)
            {
                dtHopDong = MDSolutionEntities.DBModule.ExecuteQuery("select ID, MaHopDong ,HoTen,Diachi,dbo.BoDauTiengViet(HoTen) as HoTenKhongDau from tbl_HopDong ", null, null).Tables[0];

            }

            DataView dv = dtHopDong.DefaultView;
            dv.RowFilter = "ID ='" + txtMaHD.Text + "'";
            if (dv.Count == 1)
            {
                txtTenChuMia.Text = dv[0]["HoTen"].ToString();
            }
            else
            {
                //ReLoad();
            }

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
            this.txtMaHD.Text = frmSearch.ID;
            if (txtMaHD.Text != "")
            {                
                this.SearchHD();
            }
        }

        private void btnXemBC_Click_1(object sender, EventArgs e)
        {
            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd") + " 00:00:00";
            string Den = dtDen.ToString("yyyy-MM-dd") + " 23:59:59";
            Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "@VuTrongID", "@HopDongID", "@TuNgay", "@DenNgay" };
            string[] paraValues = new string[] { MDSolution.DACASUCO_App.VuTrongID.ToString(), txtMaHD.Text,Tu,Den };

            CommonClass.ShowReport("RPDakNong\\RPT_SoChiTietCongNoThuMuaMia.rpt", "Số chi tiết công nợ thu mua mía", paramNames, paraValues, null);
        }

        private void RPT_SoChiTietCongNoThuMuaMia_Load(object sender, EventArgs e)
        {
            dtTuNgay.Value = DateTime.Now.AddDays(-1);
            dtDenNgay.Value = DateTime.Now;
        }
    }
}
