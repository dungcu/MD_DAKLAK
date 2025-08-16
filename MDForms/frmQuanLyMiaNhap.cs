using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using System.Linq;
using System.Reflection;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using SQL = System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DACASUCO.MDReport;
using DACASUCO.MDForms;
namespace MDSolution
{
    public partial class frmQuanLyMiaNhap : Form
    {
        static frmQuanLyMiaNhap _theformQuanLyMiaNhap;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmQuanLyMiaNhap OneInstanceFrm
        {
            get
            {
                if (null == _theformQuanLyMiaNhap || _theformQuanLyMiaNhap.IsDisposed)
                {
                    _theformQuanLyMiaNhap = new frmQuanLyMiaNhap();
                }

                return _theformQuanLyMiaNhap;
            }
        }
        private long MuaTaiBC = -1;
        private string sql = "";
        private string NhapMiaID = "-1";
        private NodeDonVi nDonVi = new NodeDonVi();
        public frmQuanLyMiaNhap()
        {
            InitializeComponent();
            Load_PhanQuyen_CacTramID();
        }

        private void Load_PhanQuyen_CacTramID()
        {
            string strSQL = "Select CumID From sys_Roles_User_Cum Where UserID=" + DACASUCO_App.User.ID.ToString();
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                        PhanQuyen_CacTramID += ds.Tables[0].Rows[i]["CumID"].ToString();
                    else
                        PhanQuyen_CacTramID += "," + ds.Tables[0].Rows[i]["CumID"].ToString();
                }
            }
        }

        string PhanQuyen_CacTramID = "";
        private void frmQuanLyMiaNhap_Load(object sender, EventArgs e)
        {

            if (DACASUCO_App.User.ID == 1)
            {
                cmdSua.Enabled = true;
            }
            if (DACASUCO_App.User.ID == 1)
            {
                btl_cantay.Enabled = true;

            }

            int widthScreen = Screen.PrimaryScreen.WorkingArea.Width;
            int heightScreen = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = widthScreen;
            this.Height = heightScreen;
            this.WindowState = FormWindowState.Maximized;
            CommonClass.loadTreeDonVi(tvDonVi, DACASUCO_App.User.ID.ToString());
            foreach (TreeNode n in tvDonVi.Nodes)
            {
                n.Toggle();
            }

            DateTime dt;

            dt = DateTime.Now;
            dtTuNgay.Value = dt;
            lblVT.Text = DACASUCO_App.TenVuTrong;
            load_GV();
            TinhTong();

        }
        private void tvDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nDonVi = (NodeDonVi)tvDonVi.SelectedNode.Tag;
                if (nDonVi != null)
                    load_GV();
            }
        }

        void load_GV()
        {
            lbDV.Text = nDonVi.DonViName.ToString();
            txt_sophieu.Text = "";
            if (nDonVi.Type == DonviTypeHD.Root)
            {
                loadRoot();
                TinhTong();
            }
            if (nDonVi.Type == DonviTypeHD.Xa)
            {
                loadXa();
                TinhTong();
            }
            if (nDonVi.Type == DonviTypeHD.Cum)
            {
                loadTram();
                TinhTong();
            }

        }

        void ReloadGV(System.Data.DataTable dtb)
        {

            //dgvNhapMia.AutoGenerateColumns = false;
            //dgvNhapMia.Columns["SoPhieuNhap"].DataPropertyName = "SoPhieuNhap";
            //dgvNhapMia.Columns["HoTen"].DataPropertyName = "HoTen";
            //dgvNhapMia.Columns["MaHDDT"].DataPropertyName = "MaHDDT";
            //dgvNhapMia.Columns["DonGiaVanChuyen"].DataPropertyName = "DonGiaVanChuyen";
            //dgvNhapMia.Columns["TienVanChuyen"].DataPropertyName = "TienVanChuyen";
            //dgvNhapMia.Columns["SoXe"].DataPropertyName = "SoXe";
            //dgvNhapMia.Columns["NgayVanChuyen"].DataPropertyName = "NgayVanChuyen";
            //dgvNhapMia.Columns["CBDB"].DataPropertyName = "CBDB";
            //dgvNhapMia.Columns["NgayRa"].DataPropertyName = "NgayRa";
            //dgvNhapMia.Columns["TongTrongLuong"].DataPropertyName = "TongTrongLuong";
            //dgvNhapMia.Columns["TrongLuongXe"].DataPropertyName = "TrongLuongXe";
            //dgvNhapMia.Columns["TrongLuongMiaQC"].DataPropertyName = "TrongLuongMiaQC";
            //dgvNhapMia.Columns["TyLeTapVat"].DataPropertyName = "TyLeTapVat";
            //dgvNhapMia.Columns["TrongLuongTapVat"].DataPropertyName = "TrongLuongTapVat";
            //dgvNhapMia.Columns["TrongLuongMiaSach"].DataPropertyName = "TrongLuongMiaSach";
            //dgvNhapMia.Columns["TienMia"].DataPropertyName = "TienMia";
            //dgvNhapMia.Columns["IID"].DataPropertyName = "ID";
            //dgvNhapMia.Columns["ID"].DataPropertyName = "ID";
            //dgvNhapMia.Columns["CCS"].DataPropertyName = "CCS";
            //dgvNhapMia.Columns["GiaMia"].DataPropertyName = "DonGiaMia";
            //dgvNhapMia.Columns["TenBai"].DataPropertyName = "TenBai";
            //dgvNhapMia.Columns["LoaiGiong"].DataPropertyName = "LoaiGiong";
            //if (dgvNhapMia.Rows.Count > 0)
            //    dgvNhapMia.Rows.RemoveAt(0);
            //dgvNhapMia.DataSource = dtb;
            //dgvNhapMia.Show();

            //TinhTong();
        }
        void TinhTong()
        {
            double TongTL = 0;
            double TLXe = 0;
            double TLMia = 0;
            double TLMiaSach = 0;
            double TLTapVat = 0;
            double ThanhTien = 0;
            long tong_xe = 0;
            double CCS = 0;
            double TTVC = 0;
            double DGVCBQ = 0;
            double TCBQ = 0;
            long tongxeccs = 0;
            long tongxetc = 0;
            double tlmqc = 0;


            //foreach (Janus.Windows.GridEX.GridEXRow row in dgvNhapMia.GetCheckedRows())



            

            foreach (Janus.Windows.GridEX.GridEXRow dr in dgvNhapMia.GetDataRows())
            {
                //lbThanhTien.Text = dr.Cells[10].ToString();
                TongTL += double.Parse(dr.Cells["TongTrongLuong"].Value.ToString());
                TLXe += double.Parse(dr.Cells["TrongLuongXe"].Value.ToString());
                TLMia += double.Parse(dr.Cells["TrongLuongMiaQC"].Value.ToString());
                double tlms = 0;
                try
                {
                    tlms += double.Parse(dr.Cells["TrongLuongMiaSach"].Value.ToString());
                }
                catch
                {
                    tlms = 0;
                }
                TLMiaSach += tlms;
                TLTapVat += double.Parse(dr.Cells["TrongLuongTapVat"].Value.ToString());
                ThanhTien += double.Parse(dr.Cells["TienMia"].Value.ToString());
                TTVC += double.Parse(dr.Cells["TienVanChuyen"].Value.ToString());
                if (MuaTaiBC <= 0)
                {
                    if (double.Parse(dr.Cells["DonGiaVanChuyen"].Value.ToString()) > 0)
                    {
                        tlmqc += double.Parse(dr.Cells["TrongLuongMiaQC"].Value.ToString());
                    }
                }
                double chuduong = 0;
                double tc = 0;
                try
                {
                    chuduong = double.Parse(dr.Cells["CCS"].Value.ToString());

                }
                catch
                {
                    chuduong = 0;
                }
                if (chuduong > 0)
                {
                    CCS += chuduong;
                    tongxeccs += 1;
                }
                try
                {
                    tc = double.Parse(dr.Cells["TyLeTapVat"].Value.ToString());

                }
                catch
                {
                    tc = 0;
                }
                if (tc > 0)
                {
                    TCBQ += tc;
                    tongxetc += 1;
                }
                try
                {
                    tong_xe++;
                }
                catch
                {
                    tong_xe = 0;
                }

            }

            if (MuaTaiBC == 1)
            {
                DGVCBQ = 0;
            }
            else
            {
                if (tlmqc == 0)
                {
                    DGVCBQ = 0;
                }
                else
                {
                    DGVCBQ = Math.Round((TTVC / tlmqc) * 1000, 0);
                }
            }

            if (tongxeccs == 0)
            {
                CCS = 0;
            }
            else
            {
                CCS = Math.Round(CCS / tongxeccs, 2);
            }
            if (tongxetc == 0)
            {
                TCBQ = 0;
            }
            else
            {
                TCBQ = Math.Round(TCBQ / tongxetc, 2);
            }
            lblCCS.Text = CCS.ToString();
            lblTCBQ.Text = TCBQ.ToString();
            lbThanhTien.Text = ThanhTien.ToString("# ### ### ##0");
            lbTlMia.Text = TLMia.ToString("# ### ### ##0");
            lbTLMiaSach.Text = TLMiaSach.ToString("# ### ### ##0");
            lbTLTapVat.Text = TLTapVat.ToString("# ### ### ##0");
            lbTongTL.Text = TongTL.ToString("# ### ### ##0");
            lbTongTLXe.Text = TLXe.ToString("# ### ### ##0");
            lbl_tongxe.Text = tong_xe.ToString();
            lblTTVC.Text = TTVC.ToString("# ### ### ##0");
            lblDGVCBQ.Text = DGVCBQ.ToString("# ### ### ##0");
        }
        void loadRoot()
        {
            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd");
            string Den = dtDen.ToString("yyyy-MM-dd");
            if (MuaTaiBC == -1)
            {
                sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            }
            else
            {
                sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " and MuaTaiBanCan=" + MuaTaiBC.ToString();
            }
            if (nKT.Value < 24)
            {
                if (nBD.Value < 24)
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + nBD.Value.ToString() + ":00:00' AND NgayVanChuyen <='" + Den + " " + nKT.Value.ToString() + ":00:00'";
                }
                else
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + (nBD.Value - 1).ToString() + ":59:59' AND NgayVanChuyen <='" + Den + " " + nKT.Value.ToString() + ":00:00'";
                }
            }
            else
            {
                if (nBD.Value < 24)
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + nBD.Value.ToString() + ":00:00' AND NgayVanChuyen <='" + Den + " " + (nKT.Value - 1).ToString() + ":59:59'";
                }
                else
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + (nBD.Value - 1).ToString() + ":59:59' AND NgayVanChuyen <='" + Den + " " + (nKT.Value - 1).ToString() + ":59:59'";
                }
            }
            if (check_canbi.Checked)
            {
                sql += " and (TrongLuongXe >0)";
            }

            if (PhanQuyen_CacTramID != "")
            {
                sql += " And TramID in(" + PhanQuyen_CacTramID + ")";
            }
            if (chkMiaChay.Checked)
            {
                sql += " And MiaChay=1";
            }

            sql += " Order by ID ASC ";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.dgvNhapMia.SetDataBinding(ds.Tables[0], "");
                this.dgvNhapMia.RootTable.SortKeys.Add("SoPhieuNhap");

                //Janus.Windows.GridEX.GridEXSortKey s = new Janus.Windows.GridEX.GridEXSortKey();
                //s.Column = dgvNhapMia.RootTable.Columns[1];
                //dgvNhapMia.RootTable.SortKeys.Add(s);




            }
            else
            {
                this.dgvNhapMia.DataSource = null;
            }
        }


        void loadXa()
        {
            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd");
            string Den = dtDen.ToString("yyyy-MM-dd");
            if (MuaTaiBC == -1)
            {
                sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " and XaID=" + nDonVi.DonViID.ToString();
            }
            else
            {
                sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " and XaID=" + nDonVi.DonViID.ToString() + " and MuaTaiBanCan=" + MuaTaiBC.ToString();
            }
            if (nKT.Value < 24)
            {
                if (nBD.Value < 24)
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + nBD.Value.ToString() + ":00:00' AND NgayVanChuyen <='" + Den + " " + nKT.Value.ToString() + ":00:00'";
                }
                else
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + (nBD.Value - 1).ToString() + ":59:59' AND NgayVanChuyen <='" + Den + " " + nKT.Value.ToString() + ":00:00'";
                }
            }
            else
            {
                if (nBD.Value < 24)
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + nBD.Value.ToString() + ":00:00' AND NgayVanChuyen <='" + Den + " " + (nKT.Value - 1).ToString() + ":59:59'";
                }
                else
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + (nBD.Value - 1).ToString() + ":59:59' AND NgayVanChuyen <='" + Den + " " + (nKT.Value - 1).ToString() + ":59:59'";
                }
            }
            if (check_canbi.Checked)
            {
                sql += " and (TrongLuongXe >0)";
            }
            if (chkMiaChay.Checked)
            {
                sql += " And MiaChay=1";
            }
            sql += " Order by ID ASC";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            //ReloadGV(ds.Tables[0]);

            if (ds.Tables[0].Rows.Count > 0)
            {
                this.dgvNhapMia.SetDataBinding(ds.Tables[0], "");
                this.dgvNhapMia.RootTable.SortKeys.Add("ID");

            }
            else
            {
                this.dgvNhapMia.DataSource = null;
            }




        }

        void loadTram()
        {
            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd");
            string Den = dtDen.ToString("yyyy-MM-dd");
            if (MuaTaiBC == -1)
            {
                sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " and TramID=" + nDonVi.DonViID.ToString();
            }
            else
            {
                sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " and TramID=" + nDonVi.DonViID.ToString() + " and MuaTaiBanCan=" + MuaTaiBC.ToString();
            }
            if (nKT.Value < 24)
            {
                if (nBD.Value < 24)
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + nBD.Value.ToString() + ":00:00' AND NgayVanChuyen <='" + Den + " " + nKT.Value.ToString() + ":00:00'";
                }
                else
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + (nBD.Value - 1).ToString() + ":59:59' AND NgayVanChuyen <='" + Den + " " + nKT.Value.ToString() + ":00:00'";
                }
            }
            else
            {
                if (nBD.Value < 24)
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + nBD.Value.ToString() + ":00:00' AND NgayVanChuyen <='" + Den + " " + (nKT.Value - 1).ToString() + ":59:59'";
                }
                else
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + (nBD.Value - 1).ToString() + ":59:59' AND NgayVanChuyen <='" + Den + " " + (nKT.Value - 1).ToString() + ":59:59'";
                }
            }
            if (check_canbi.Checked)
            {
                sql += " and (TrongLuongXe >0)";
            }
            if (chkMiaChay.Checked)
            {
                sql += " And MiaChay=1";
            }
            sql += " Order by ID ASC";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.dgvNhapMia.SetDataBinding(ds.Tables[0], "");
                this.dgvNhapMia.RootTable.SortKeys.Add("ID");
            }
            else
            {
                this.dgvNhapMia.DataSource = null;
            }
        }


        private void tvDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (tvDonVi.SelectedNode != null)
            {
                nDonVi = (NodeDonVi)tvDonVi.SelectedNode.Tag;
                txt_sophieu.Text = "";
                //chkMiaChay.Checked = false;
                //check_canbi.Checked = false;
                load_GV();
            }
        }


        private void cmdIn_Click(object sender, EventArgs e)
        {
            if (dgvNhapMia.RowCount > 0)
            {
                MDSolution.frmShowRP2 frm = new frmShowRP2();
                rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXeVung rp = new rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXeVung();
                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                System.Data.DataTable dt = (System.Data.DataTable)dgvNhapMia.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                rp.SetParameterValue("TuNgay", dtTuNgay.Value.ToString("dd/MM/yyyy"));
                rp.SetParameterValue("DenNgay", dtDenNgay.Value.ToString("dd/MM/yyyy"));
                rp.SetParameterValue("BD", nBD.Value.ToString());
                rp.SetParameterValue("KT", nKT.Value.ToString());
                //rp.SetParameterValue("CCSBQ", lblCCS.Text);
                //rp.SetParameterValue("TCBQ", lblTCBQ.Text);
                if (chkMiaChay.Checked)
                {
                    rp.SetParameterValue("TinhTrang", "Mía CHÁY");
                }
                else
                {
                    rp.SetParameterValue("TinhTrang", "Tất cả mía không CHÁY và mía CHÁY ");
                }
                if (rdAll.Checked)
                {
                    rp.SetParameterValue("HinhThuc", "Tất cả mua tại RUỘNG và mua tại BÀN CÂN");
                }
                else if (rdMuaTaiRuong.Checked)
                {
                    rp.SetParameterValue("HinhThuc", "Mua tại RUỘNG");
                }
                else
                {
                    rp.SetParameterValue("HinhThuc", "Mua tại BÀN CÂN");
                }
                if (txt_sophieu.Text != "")
                {
                    if (ChuHDRB.Checked)
                    {
                        {
                            rp.DataDefinition.FormulaFields["DonVi"].Text = "'Chủ mía: " + this.dgvNhapMia.CurrentRow.Cells["HoTen"].Value.ToString() + "'";
                        }
                    }
                    else if (rdCBDB.Checked)
                    {
                        rp.DataDefinition.FormulaFields["DonVi"].Text = "'Cán bộ địa bàn: " + this.dgvNhapMia.CurrentRow.Cells["CBDB"].Value.ToString() + "'";
                    }
                }
                else
                {
                    if (nDonVi.Type == DonviTypeHD.Xa)
                    {
                        rp.DataDefinition.FormulaFields["DonVi"].Text = "'" + nDonVi.DonViName.ToString() + "'";
                    }
                    else if (nDonVi.Type == DonviTypeHD.Cum)
                    {
                        rp.DataDefinition.FormulaFields["DonVi"].Text = "'" + nDonVi.DonViName.ToString() + "'";
                    }
                    else if (PhanQuyen_CacTramID == "")
                    {
                        rp.DataDefinition.FormulaFields["DonVi"].Text = "'TOÀN VÙNG NGUYÊN LIỆU DACASUCO'";
                    }
                    else
                    {
                        rp.DataDefinition.FormulaFields["DonVi"].Text = "'TOÀN VÙNG NGUYÊN LIỆU CỦA TRẠM'";
                    }
                }
                frm.RP = rp;
                frm.RPtitle = "Kết quả nhập mía " + nDonVi.DonViName.ToString();
                frm.Show();
            }
        }

        private void txt_sophieu_TextChanged(object sender, EventArgs e)
        {
            if (txt_sophieu.Text == "")
            {
                LoadGVbySoPhieu(MuaTaiBC);
            }
        }

        private void check_canbi_CheckedChanged(object sender, EventArgs e)
        {
            LoadGVbySoPhieu(MuaTaiBC);
        }
        void LoadGVbySoPhieu(long HinhThucMua)
        {
            txt_sophieu.Text = "";
            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd");
            string Den = dtDen.ToString("yyyy-MM-dd");
            if (MuaTaiBC == -1)
            {
                sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            }
            else
            {
                sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " and MuaTaiBanCan=" + MuaTaiBC.ToString();
            }
            switch (nDonVi.Type)
            {
                case DonviTypeHD.Xa:
                    sql += " and XaID=" + nDonVi.DonViID.ToString();
                    break;
                case DonviTypeHD.Cum:
                    sql += " And TramID =" + nDonVi.DonViID.ToString();
                    break;
                default:
                    if (PhanQuyen_CacTramID != "")
                    {
                        sql += " And TramID in (" + PhanQuyen_CacTramID + ")";
                    }
                    break;
            }


            if (nKT.Value < 24)
            {
                if (nBD.Value < 24)
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + nBD.Value.ToString() + ":00:00' AND NgayVanChuyen <='" + Den + " " + nKT.Value.ToString() + ":00:00'";
                }
                else
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + (nBD.Value - 1).ToString() + ":59:59' AND NgayVanChuyen <='" + Den + " " + nKT.Value.ToString() + ":00:00'";
                }
            }
            else
            {
                if (nBD.Value < 24)
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + nBD.Value.ToString() + ":00:00' AND NgayVanChuyen <='" + Den + " " + (nKT.Value - 1).ToString() + ":59:59'";
                }
                else
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + (nBD.Value - 1).ToString() + ":59:59' AND NgayVanChuyen <='" + Den + " " + (nKT.Value - 1).ToString() + ":59:59'";
                }
            }

            long sophieu = 0;
            if (SoPhieuRB.Checked == true)
            {
                if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
                {
                    try
                    {
                        sophieu = long.Parse(txt_sophieu.Text);
                    }
                    catch
                    {
                        sophieu = 0;
                    }
                }
                if (sophieu > 0)
                {
                    sql += " and SoPhieuNhap like '" + sophieu.ToString() + "%'";
                }
            }
            if (ChuHDRB.Checked == true) // tim theo chu hd
            {
                if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
                {
                    sql += " OR dbo.BoDauTiengViet(HoTen) Like N'%" + txt_sophieu.Text + "%'";
                }
            }
            if (rdCBDB.Checked)
            {
                if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
                {
                    sql += " And dbo.BoDauTiengViet(CBDB) Like N'%" + txt_sophieu.Text + "%'";
                }
            }
            if (check_canbi.Checked)
            {
                sql += " and (TrongLuongXe >0)";
            }
            if (chkMiaChay.Checked)
            {
                sql += " And MiaChay=1";
            }
            sql += " Order by ID ASC";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            ReloadGV(ds.Tables[0]);
        }


        private bool chek_NgayMia_Hientai(string _IDNhapMia)
        {
            string sql = "Select NgayMia From tbl_NhapMia Where ID =" + _IDNhapMia;
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["NgayMia"].ToString());
            sql = "Select Max(NgayMia) as NgayMia From tbl_NgayMia";
            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            DateTime dt2 = Convert.ToDateTime(ds.Tables[0].Rows[0]["NgayMia"].ToString());
            if (dt != dt2)
                return false;
            else
                return true;
        }

        private bool Chek_DaThanhToan(string _IDNhapMia)
        {
            string sql = "Select DaThanhToan From tbl_NhapMia Where ID=" + _IDNhapMia;
            sql = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null);

            if (string.IsNullOrEmpty(sql) || sql == "0")
                return true;
            else
                return false;
        }

        private void dgvNhapMia_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > -1)
            //{
            //    NhapMiaID = dgvNhapMia.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            //}
        }


        private void SoPhieuRB_CheckedChanged(object sender, EventArgs e)
        {
            if (SoPhieuRB.Checked == true)
            {
                txt_sophieu.Text = "";
                txt_sophieu.Focus();
            }
        }

        private void ChuHDRB_CheckedChanged(object sender, EventArgs e)
        {
            if (ChuHDRB.Checked == true)
            {
                txt_sophieu.Focus();
                txt_sophieu.Text = "";
            }
        }


        private void txt_sophieu_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox text = (System.Windows.Forms.TextBox)sender;
            text.BackColor = Color.SkyBlue;
        }

        private void txt_sophieu_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox text = (System.Windows.Forms.TextBox)sender;
            text.BackColor = Color.White;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Delete:
                        try
                        {
                            //SendKeys.Send("{TAB}");                           
                            XoaSoPhieu();
                        }
                        catch { }
                        break;

                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool Chek_ThanhToan()
        {
            string[] strArr = DACASUCO_App.User.Roles.Split('&');
            bool BolTrCa = false;
            foreach (string str in strArr)
            {
                if (str.ToLower() == "mnu_thanhtoan")
                {
                    BolTrCa = true;
                    break;
                }
                //string a = str.ToLower();
            }
            return BolTrCa;
        }

        private void XoaSoPhieu()
        {

            MessageBox.Show("Không được xoá phiếu cân!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        private void txt_sophieu_Click(object sender, EventArgs e)
        {
            txt_sophieu.Text = "";
        }

        private void rdMuaTaiRuong_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMuaTaiRuong.Checked)
            {
                MuaTaiBC = 0;
                LoadGVbySoPhieu(MuaTaiBC);
            }
        }

        private void rdMuaTaiBC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMuaTaiBC.Checked)
            {
                MuaTaiBC = 1;
                LoadGVbySoPhieu(MuaTaiBC);
            }
        }

        private void rdAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAll.Checked)
            {
                MuaTaiBC = -1;
                LoadGVbySoPhieu(-1);
            }
        }

        private void cmdTim_Click(object sender, EventArgs e)
        {

            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd");
            string Den = dtDen.ToString("yyyy-MM-dd");
            if (MuaTaiBC == -1)
            {
                sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            }
            else
            {
                sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " and MuaTaiBancan=" + MuaTaiBC.ToString();
            }

            switch (nDonVi.Type)
            {
                case DonviTypeHD.Xa:
                    sql += " and XaID=" + nDonVi.DonViID.ToString();
                    break;
                case DonviTypeHD.Cum:
                    sql += " And TramID=" + nDonVi.DonViID.ToString();
                    break;
                default:
                    if (PhanQuyen_CacTramID != "")
                    {
                        sql += " And TramID in (" + PhanQuyen_CacTramID + ")";
                    }
                    break;
            }

            if (nKT.Value < 24)
            {
                if (nBD.Value < 24)
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + nBD.Value.ToString() + ":00:00' AND NgayVanChuyen <='" + Den + " " + nKT.Value.ToString() + ":00:00'";
                }
                else
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + (nBD.Value - 1).ToString() + ":59:59' AND NgayVanChuyen <='" + Den + " " + nKT.Value.ToString() + ":00:00'";
                }
            }
            else
            {
                if (nBD.Value < 24)
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + nBD.Value.ToString() + ":00:00' AND NgayVanChuyen <='" + Den + " " + (nKT.Value - 1).ToString() + ":59:59'";
                }
                else
                {
                    sql += " and NgayVanChuyen >='" + Tu + " " + (nBD.Value - 1).ToString() + ":59:59' AND NgayVanChuyen <='" + Den + " " + (nKT.Value - 1).ToString() + ":59:59'";
                }
            }
            long sophieu = 0;
            if (SoPhieuRB.Checked == true)
            {
                if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
                {
                    try
                    {
                        sophieu = long.Parse(txt_sophieu.Text);
                    }
                    catch
                    {
                        sophieu = 0;
                    }
                }
                if (sophieu > 0)
                {
                    sql += " and SoPhieuNhap like '" + sophieu.ToString() + "%'";
                }
            }
            if (ChuHDRB.Checked == true) // tim theo chu hd
            {
                if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
                {
                    sql += " And dbo.BoDauTiengViet(HoTen) Like N'%" + txt_sophieu.Text + "%'";
                }
            }
            if (rdCBDB.Checked)
            {
                if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
                {
                    sql += " And dbo.BoDauTiengViet(CBDB) Like N'%" + txt_sophieu.Text + "%'";
                }
            }
            if (check_canbi.Checked)
            {
                sql += " and (TrongLuongXe >0)";
            }
            if (chkMiaChay.Checked)
            {
                sql += " And MiaChay=1";
            }
            sql += " Order by ID ASC";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.dgvNhapMia.SetDataBinding(ds.Tables[0], "");
                this.dgvNhapMia.RootTable.SortKeys.Add("ID");
            }
            else
            {
                this.dgvNhapMia.DataSource = null;
            }

        }

        private void txt_sophieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                DateTime dtTu = dtTuNgay.Value;
                DateTime dtDen = dtDenNgay.Value;
                string Tu = dtTu.ToString("yyyy-MM-dd");
                string Den = dtDen.ToString("yyyy-MM-dd");
                if (MuaTaiBC == -1)
                {
                    sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                }
                else
                {
                    sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " and MuaTaiBancan=" + MuaTaiBC.ToString();
                }

                switch (nDonVi.Type)
                {
                    case DonviTypeHD.Xa:
                        sql += " and XaID=" + nDonVi.DonViID.ToString();
                        break;
                    case DonviTypeHD.Cum:
                        sql += " And TramID=" + nDonVi.DonViID.ToString();
                        break;
                    default:
                        if (PhanQuyen_CacTramID != "")
                        {
                            sql += " And TramID in (" + PhanQuyen_CacTramID + ")";
                        }
                        break;
                }

                if (nKT.Value < 24)
                {
                    if (nBD.Value < 24)
                    {
                        sql += " and NgayVanChuyen >='" + Tu + " " + nBD.Value.ToString() + ":00:00' AND NgayVanChuyen <='" + Den + " " + nKT.Value.ToString() + ":00:00'";
                    }
                    else
                    {
                        sql += " and NgayVanChuyen >='" + Tu + " " + (nBD.Value - 1).ToString() + ":59:59' AND NgayVanChuyen <='" + Den + " " + nKT.Value.ToString() + ":00:00'";
                    }
                }
                else
                {
                    if (nBD.Value < 24)
                    {
                        sql += " and NgayVanChuyen >='" + Tu + " " + nBD.Value.ToString() + ":00:00' AND NgayVanChuyen <='" + Den + " " + (nKT.Value - 1).ToString() + ":59:59'";
                    }
                    else
                    {
                        sql += " and NgayVanChuyen >='" + Tu + " " + (nBD.Value - 1).ToString() + ":59:59' AND NgayVanChuyen <='" + Den + " " + (nKT.Value - 1).ToString() + ":59:59'";
                    }
                }
                long sophieu = 0;
                if (SoPhieuRB.Checked == true)
                {
                    if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
                    {
                        try
                        {
                            sophieu = long.Parse(txt_sophieu.Text);
                        }
                        catch
                        {
                            sophieu = 0;
                        }
                    }
                    if (sophieu > 0)
                    {
                        sql += " and SoPhieuNhap like '" + sophieu.ToString() + "%'";
                    }
                }
                if (ChuHDRB.Checked == true) // tim theo chu hd
                {
                    if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
                    {
                        sql += " And dbo.BoDauTiengViet(HoTen) Like N'%" + txt_sophieu.Text + "%'";
                    }
                }
                if (rdCBDB.Checked)
                {
                    if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
                    {
                        sql += " And dbo.BoDauTiengViet(CBDB) Like N'%" + txt_sophieu.Text + "%'";
                    }
                }
                if (check_canbi.Checked)
                {
                    sql += " and (TrongLuongXe >0)";
                }
                if (chkMiaChay.Checked)
                {
                    sql += " And MiaChay=1";
                }
                sql += " Order by SoPhieuNhap ASC";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.dgvNhapMia.SetDataBinding(ds.Tables[0], "");
                    this.dgvNhapMia.RootTable.SortKeys.Add("ID");
                }
                else
                {
                    this.dgvNhapMia.DataSource = null;
                }
            }
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            NhapMiaID = this.dgvNhapMia.GetValue("ID").ToString();

            if (long.Parse(NhapMiaID) > 0)
            {
                string sql = "Select DaThanhToan from tbl_NhapMia where ID=" + NhapMiaID;
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                if ((ds.Tables[0].Rows[0]["DaThanhToan"].ToString() != "0"))
                {
                    MessageBox.Show("Số phiếu đã được thanh toán! Bạn không thể sửa được", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                frmEdit_tbl_NhapMia frm = new frmEdit_tbl_NhapMia();
                frm.ID = NhapMiaID;
                frm.ShowDialog();
                if (frm.OK == 1)
                {
                    LoadGVbySoPhieu(MuaTaiBC);
                }
            }

        }

        private void chkMiaChay_CheckedChanged(object sender, EventArgs e)
        {
            load_GV();
            //LoadGVbySoPhieu(MuaTaiBC);
        }

        private void rdCBDB_CheckedChanged(object sender, EventArgs e)
        {

            if (rdCBDB.Checked == true)
            {
                txt_sophieu.Focus();
                txt_sophieu.Text = "";
            }
        }

        private void cmd2Exel_Click(object sender, EventArgs e)
        {
            try
            {

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.IncludeFormatStyle = true;
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        // exporter.SheetName = "";
                        exporter.GridEX = dgvNhapMia;
                        exporter.Export(fs);
                        fs.Close();
                        MessageBox.Show("Đã export ra file excel!", "SOSUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "SOSUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //if (dgvNhapMia.DataSource != null)
            //{
            //    SaveFileDialog sfd = new SaveFileDialog();
            //    sfd.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            //    sfd.FilterIndex = 1;
            //    sfd.RestoreDirectory = true;
            //    sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        if (sfd.FileName.Length > 0)
            //        {
            //            Excel.Application xlApp;
            //            Excel.Workbook xlWorkBook;
            //            Excel.Worksheet xlWorkSheet;
            //            object misValue = System.Reflection.Missing.Value;

            //            xlApp = new Excel.Application();
            //            xlWorkBook = xlApp.Workbooks.Add(misValue);
            //            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //            for (int j = 0; j <= this.dgvNhapMia.ColumnCount - 1; j++)
            //            {
            //                int k = j + 1;
            //                string colName = dgvNhapMia.Columns[j].HeaderText;
            //                xlWorkSheet.Cells[1, k] = colName;

            //            }
            //            for (int r = 0; r <= dgvNhapMia.RowCount - 1; r++)
            //            {
            //                int hang = r + 1;
            //                for (int c = 0; c <= dgvNhapMia.ColumnCount - 1; c++)
            //                {
            //                    //        int cot = c + 1;

            //                    DataGridViewCell cell = dgvNhapMia[c, r];
            //                    xlWorkSheet.Cells[hang + 1, c + 1] = cell.Value;

            //                }
            //            }

            //            xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //            xlWorkBook.Close(true, misValue, misValue);
            //            xlApp.Quit();
            //            MessageBox.Show("Đã export dữ liệu ra định dạng file Excel thành công", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            releaseObject(xlWorkSheet);
            //            releaseObject(xlWorkBook);
            //            releaseObject(xlApp);
            //        }


            //    }
            //}

        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sql = "";
            DataSet ds = new DataSet();





            Frm_ReportViewer frm = new Frm_ReportViewer();
            // Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "VuTrongID" };
            string[] paraValues = new string[] { DACASUCO_App.VuTrongID.ToString() };
            //string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString() };
            CommonClass.ShowReport("", "", paramNames, paraValues, null);


            //MDReport.
            //MDReport.DauTu.rpt_TongHopCongNoDauTuTheoTram rp = new MDReport.DauTu.rpt_TongHopCongNoDauTuTheoTram();
            //rp.SetDataSource(ds.Tables[0]);
            //rp.SetParameterValue("NienVu", SoSuCo_App.TenVuTrong);
            //frm.RP = rp;
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);

            //frm.RPtitle = uiComboBoxChonBC.Text;
            //frm.Show();

        }

        private void dgvNhapMia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btl_cantay_Click(object sender, EventArgs e)
        {
            
            frmNhapMia frm = new frmNhapMia();
            frm.ShowDialog();
        }

    }
}