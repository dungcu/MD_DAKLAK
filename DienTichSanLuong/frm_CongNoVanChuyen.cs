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
namespace MDSolution
{
    public partial class frm_CongNoVanChuyen : Form
    {
        static frm_CongNoVanChuyen _theformQuanLyMiaNhap;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_CongNoVanChuyen OneInstanceFrm
        {
            get
            {
                if (null == _theformQuanLyMiaNhap || _theformQuanLyMiaNhap.IsDisposed)
                {
                    _theformQuanLyMiaNhap = new frm_CongNoVanChuyen();
                }

                return _theformQuanLyMiaNhap;
            }
        }
        private long MuaTaiBC = -1;
        private string sql = "";
        private string NhapMiaID = "-1";
        private NodeDonVi nDonVi = new NodeDonVi();
        public frm_CongNoVanChuyen()
        {
            InitializeComponent();
        }
        private void frm_CongNoVanChuyen_Load(object sender, EventArgs e)
        {

            lblVT.Text = DACASUCO_App.TenVuTrong;
            this.WindowState = FormWindowState.Maximized;
            loadRoot();

        }

        void loadRoot()
        {

            sql = "sp_TongHopCongNoVC " + DACASUCO_App.VuTrongID.ToString() + " ,'" + dt_tungay.Value.ToString("dd/MM/yyyy") + "' ,'" + dt_denngay.Value.ToString("dd/MM/yyyy") + "'";

            //sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            //if (MuaTaiBC == -1)
            //{
            //    sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            //}
            //else
            //{
            //    sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " and MuaTaiBanCan=" + MuaTaiBC.ToString();
            //}
            //if (nKT.Value < 24)
            //{
            //    if (nBD.Value < 24)
            //    {
            //        sql += " and NgayVanChuyen >='" + Tu + " " + nBD.Value.ToString() + ":00:00' AND NgayVanChuyen <='" + Den + " " + nKT.Value.ToString() + ":00:00'";
            //    }
            //    else
            //    {
            //        sql += " and NgayVanChuyen >='" + Tu + " " + (nBD.Value - 1).ToString() + ":59:59' AND NgayVanChuyen <='" + Den + " " + nKT.Value.ToString() + ":00:00'";
            //    }
            //}
            //else
            //{
            //    if (nBD.Value < 24)
            //    {
            //        sql += " and NgayVanChuyen >='" + Tu + " " + nBD.Value.ToString() + ":00:00' AND NgayVanChuyen <='" + Den + " " + (nKT.Value - 1).ToString() + ":59:59'";
            //    }
            //    else
            //    {
            //        sql += " and NgayVanChuyen >='" + Tu + " " + (nBD.Value - 1).ToString() + ":59:59' AND NgayVanChuyen <='" + Den + " " + (nKT.Value - 1).ToString() + ":59:59'";
            //    }
            //}
            //if (check_canbi.Checked)
            //{
            //    sql += " and (TrongLuongXe >0)";
            //}

            //if (PhanQuyen_CacTramID != "")
            //{
            //    sql += " And TramID in(" + PhanQuyen_CacTramID + ")";
            //}

            //sql += " Order by HopDongID ASC ";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.dgvNhapMia.SetDataBinding(ds.Tables[0], "");

            }
            else
            {
                this.dgvNhapMia.DataSource = null;
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
                frm.RP = rp;
                frm.RPtitle = "Kết quả nhập mía " + nDonVi.DonViName.ToString();
                frm.Show();
            }
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



    }
}