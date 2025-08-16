using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using Janus.Windows.GridEX;
using MDSolution;
using DACASUCO.MDReport;

namespace MDSolution
{
    public partial class frm_TongHop_NhapMia : Form
    {
        static frm_TongHop_NhapMia _frm_TongHop_NhapMia;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        ///         
        static public frm_TongHop_NhapMia OneInstanceFrm
        {
            get
            {
                if (null == _frm_TongHop_NhapMia || _frm_TongHop_NhapMia.IsDisposed)
                {
                    _frm_TongHop_NhapMia = new frm_TongHop_NhapMia();
                }

                return _frm_TongHop_NhapMia;
            }
        }
        int iSelect = 0;
        string TenDV = "";
        public frm_TongHop_NhapMia()
        {
            InitializeComponent();
        }

        private void Load_Tab_CM()
        {

            string sql = "SELECT * FROM  V_RP_TH_ThuMua_ChuMia WHERE VuTrongID = " + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdCHD.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdCHD.DataSource = null;
            }

        }
        private void Load_Tab_CBDB()
        {

            string sql = "SELECT * FROM  V_RP_TH_ThuMua_CBDB WHERE VuTrongID =" + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdCBDB.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdCBDB.DataSource = null;
            }

        }
        private void Load_Tab_Ben()
        {
            string sql = "SELECT * FROM   V_RP_TH_ThuMua_Ben WHERE VuTrongID =" + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdBen.SetDataBinding(ds.Tables[0], "");
            }
            else
            {
                this.gdBen.DataSource = null;
            }


        }
        private void Load_Tab_Tram()
        {
            string sql = "SELECT * FROM  V_RP_TH_ThuMua_Tram WHERE VuTrongID =" + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdTram.SetDataBinding(ds.Tables[0], "");
            }
            else
            {
                this.gdTram.DataSource = null;
            }

        }
        private void Load_Tab_Xa()
        {
            string sql = "SELECT * FROM  V_RP_TH_ThuMua_Xa WHERE VuTrongID =" + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdXa.SetDataBinding(ds.Tables[0], "");
            }
            else
            {
                this.gdXa.DataSource = null;
            }


        }
        private void Load_Tab_Huyen()
        {
            string sql = "SELECT * FROM  V_RP_TH_ThuMua_Huyen WHERE VuTrongID =" + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdHuyen.SetDataBinding(ds.Tables[0], "");
            }
            else
            {
                this.gdHuyen.DataSource = null;
            }

        }
        private void Load_Tab_Tinh()
        {
            string sql = "SELECT * FROM  V_RP_TH_ThuMua_Tinh WHERE VuTrongID =" + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdTinh.SetDataBinding(ds.Tables[0], "");
            }
            else
            {
                this.gdTinh.DataSource = null;
            }


        }


        private void frm_TongHop_NhapMia_Load(object sender, EventArgs e)
        {
            lblTitle.Text = lblTitle.Text + DACASUCO_App.TenVuTrong;
            //for (int i = 0; i <= this.gdCHD.RootTable.Columns.Count - 1; i++)
            //{
            //    string colName = gdCHD.RootTable.Columns[i].Caption;
            //    if (colName.Contains("DD_Giong"))
            //    {
            //        string Giong_ID = colName.Substring(colName.LastIndexOf('_') + 1);
            //        try
            //        {
            //            gdCHD.RootTable.Columns[i].Caption = DBModule.ExecuteQueryForOneResult("SELECT Ten FROM [tbl_GiongMia] Where ID=" + Giong_ID, null, null);
            //        }
            //        catch { }
            //    }

            //}
            //for (int i = 0; i <= this.gdAp.RootTable.Columns.Count - 1; i++)
            //{
            //    string colName = gdAp.RootTable.Columns[i].Caption;
            //    if (colName.Contains("DD_Giong"))
            //    {
            //        string Giong_ID = colName.Substring(colName.LastIndexOf('_') + 1);
            //        try
            //        {
            //            gdAp.RootTable.Columns[i].Caption = DBModule.ExecuteQueryForOneResult("SELECT Ten FROM [tbl_GiongMia] Where ID=" + Giong_ID, null, null);
            //        }
            //        catch { }
            //    }

            //}
            Load_Tab_CM();
        }

        private void Tab_TRACUU_TONGHOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tab_Tonghop_NhapMia.SelectedIndex == 0)
            {
                Load_Tab_CM();
                iSelect = 0;
            }

            if (Tab_Tonghop_NhapMia.SelectedIndex == 1)
            {
                Load_Tab_CBDB();
                iSelect = 1;
            }
            if (Tab_Tonghop_NhapMia.SelectedIndex == 2)
            {
                Load_Tab_Ben();
                iSelect = 2;
            }
            if (Tab_Tonghop_NhapMia.SelectedIndex == 3)
            {
                Load_Tab_Tram();
                iSelect = 3;
            }
            if (Tab_Tonghop_NhapMia.SelectedIndex == 4)
            {
                Load_Tab_Xa();
                iSelect = 4;
            }
            if (Tab_Tonghop_NhapMia.SelectedIndex == 5)
            {
                Load_Tab_Huyen();
                iSelect = 5;
            }
            if (Tab_Tonghop_NhapMia.SelectedIndex == 6)
            {
                Load_Tab_Tinh();
                iSelect = 6;
            }

        }

        private void cmdXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (iSelect == 0)
                {
                    saveFileDialog.FileName = "DuLieu_TongHop_CM_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                }

                if (iSelect == 1)
                {
                    saveFileDialog.FileName = "DuLieu_TongHop_CBDB_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                }
                if (iSelect == 2)
                {
                    saveFileDialog.FileName = "DuLieu_TongHop_Ben_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                }
                if (iSelect == 3)
                {
                    saveFileDialog.FileName = "DuLieu_TongHop_Tram_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                }
                if (iSelect == 4)
                {
                    saveFileDialog.FileName = "DuLieu_TongHop_Xa_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                }
                if (iSelect == 5)
                {
                    saveFileDialog.FileName = "DuLieu_TongHop_Huyen_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                }
                if (iSelect == 6)
                {
                    saveFileDialog.FileName = "DuLieu_TongHop_Tinh_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                }
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        if (iSelect == 0)
                        {
                            exporter.GridEX = gdCHD;
                        }
                        if (iSelect == 1)
                        {
                            exporter.GridEX = gdCBDB;
                        }
                        if (iSelect == 2)
                        {
                            exporter.GridEX = gdBen;
                        }
                        if (iSelect == 3)
                        {
                            exporter.GridEX = gdTram;
                        }
                        if (iSelect == 4)
                        {
                            exporter.GridEX = gdXa;
                        }
                        if (iSelect == 5)
                        {
                            exporter.GridEX = gdHuyen;
                        }
                        if (iSelect == 6)
                        {
                            exporter.GridEX = gdTinh;
                        }
                        exporter.Export(fs);
                        fs.Close();
                        Excel.Application xlApp;
                        Excel.Workbook xlWorkBook;
                        xlApp = Export2Excel.TryGetExistingExcelApplication();
                        if (xlApp == null)
                        {
                            xlApp = new Excel.Application();
                        }
                        xlWorkBook = xlApp.Workbooks.Open(saveFileDialog.FileName);
                        xlApp.Visible = true;
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi xuất dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gdCBDB_FilterApplied(object sender, EventArgs e)
        {

        }

        private void btn_in_Click(object sender, EventArgs e)
        {


            string PhamVi = "";
            frmShowRP2 frm = new frmShowRP2();
            rpt_TongHop_SL_ThuMua rp = new rpt_TongHop_SL_ThuMua();
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            if (iSelect == 0)
            {
                System.Data.DataTable dt = (System.Data.DataTable)gdCHD.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                PhamVi = "DỰ BÁO THEO CÁC CHỦ MÍA";
            }
            else if (iSelect == 1)
            {
                System.Data.DataTable dt = (System.Data.DataTable)gdCBDB.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                PhamVi = "DỰ BÁO THEO CÁN BỘ ĐỊA BÀN";
            }
            else if (iSelect == 2)
            {
                System.Data.DataTable dt = (System.Data.DataTable)gdBen.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                PhamVi = "DỰ BÁO THEO CÁC BẾN MÍA";
            }
            else if (iSelect == 3)
            {
                System.Data.DataTable dt = (System.Data.DataTable)gdTram.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                PhamVi = "DỰ BÁO THEO CÁC TRẠM NGUYÊN LIỆU";
            }
            else if (iSelect == 4)
            {
                System.Data.DataTable dt = (System.Data.DataTable)gdXa.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                PhamVi = "DỰ BÁO THEO CÁC XÃ VÙNG MÍA";
            }
            else if (iSelect == 5)
            {
                System.Data.DataTable dt = (System.Data.DataTable)gdHuyen.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                PhamVi = "DỰ BÁO THEO CÁC HUYỆN CÓ MÍA";
            }
            else
            {
                System.Data.DataTable dt = (System.Data.DataTable)gdTinh.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                PhamVi = "DỰ BÁO THEO CÁC TỈNH CÓ MÍA";
            }
            rp.SetParameterValue("Ten", TenDV);
            rp.SetParameterValue("PhamVi", PhamVi);
            
            rp.SetParameterValue("NV", DACASUCO_App.TenVuTrong);
            frm.RP = rp;
            
            frm.RPtitle = "Theo dõi dự báo Năng suất - Sản lượng";
            frm.Show();
        }

        }


    }





