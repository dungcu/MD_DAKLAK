using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using MDSolution;

namespace DACASUCO.MDReport.DakNongReport
{
    public partial class ChiTietCongNoVanChuyenMia : Form
    {
        DataSet DS_CB = null;
        //public DataTable dtHopDong { get; set; }
        public ChiTietCongNoVanChuyenMia()
        {
            InitializeComponent();
        }
      private void btnXemBC_Click(object sender, EventArgs e)
        {
            Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "@VuTrongID", "@HopDongVanChuyenID", "@XeID", "@TuNgay", "@DenNgay", "DonVi" };
            long XeID= 0;
            if (cbXe.SelectedIndex > 0) XeID = long.Parse(cbXe.SelectedValue.ToString());

            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd") + " 00:00:00";
            string Den = dtDen.ToString("yyyy-MM-dd") + " 23:59:59";
            string[] paraValues = new string[] { MDSolution.DACASUCO_App.VuTrongID.ToString(), cboHDVC.SelectedValue.ToString(), XeID.ToString(), Tu, Den, cbXe.Text.ToUpper() };

            CommonClass.ShowReport("RPDakNong\\RPT_SoChiTietCongNoVanChuyenMia.rpt", "Sổ chi tiết công nợ vận chuyển mía", paramNames, paraValues, null);
        }

        private void ChiTietCongNoVanChuyenMia_Load(object sender, EventArgs e)
        {
            dtTuNgay.Value = DateTime.Now.AddDays(-1);
            dtDenNgay.Value = DateTime.Now;
            LoadCBHDVC();
        }
        private void LoadCBXe()
        {
            if (cboHDVC.SelectedIndex>0)
            {
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery("Select ID,SoXe from tbl_XeVanChuyen Where HopDongVanChuyenID=" + cboHDVC.SelectedValue.ToString() + " order by SoXe", null, null);
                DataRow dr = ds.Tables[0].NewRow();
                dr["ID"] = 0;
                dr["SoXe"] = "Tất cả các xe";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cbXe.DataSource = ds.Tables[0];
                cbXe.ValueMember = "ID";
                cbXe.DisplayMember = "SoXe";
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtXeVC_Click(object sender, EventArgs e)
        {
            txtXeVC.Text = "";
        }

        private void cmdTim_Click(object sender, EventArgs e)
        {
            LoadCBHDVC();
        }

        private void txtXeVC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                LoadCBHDVC();
            }
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
                    sql = "Select Distinct HopDongVanChuyenID,TenChuHopDong from V_TK_XeVC where SoXe Like N'%" + txtXeVC.Text + "%' AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " Order BY TenChuHopDong";
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

        private void cboHDVC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHDVC.SelectedIndex > 0)
            {
                LoadCBXe();
            }
            else
            {
                cbXe.DataSource = null;
            }
        }

        private void txtXeVC_TextChanged(object sender, EventArgs e)
        {
            if (txtXeVC.Text == "")
            {
                LoadCBHDVC();
            }
        }

       

    }
}
