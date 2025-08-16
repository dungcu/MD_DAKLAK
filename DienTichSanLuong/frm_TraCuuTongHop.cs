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
    public partial class frm_TraCuuTongHop : Form
    {
        static frm_TraCuuTongHop _frm_TraCuuTongHop;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        ///         
        static public frm_TraCuuTongHop OneInstanceFrm
        {
            get
            {
                if (null == _frm_TraCuuTongHop || _frm_TraCuuTongHop.IsDisposed)
                {
                    _frm_TraCuuTongHop = new frm_TraCuuTongHop();
                }

                return _frm_TraCuuTongHop;
            }
        }
        int iSelect=0;        
        string TenDV = "";
        public frm_TraCuuTongHop()
        {
            InitializeComponent();
        }

       
        private void Load_Tab_CBDB()
        {

            string sql = "sp_TongHop_DuLieu_CBDB " + DACASUCO_App.VuTrongID.ToString();
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
        private void Load_Tab_Xa()
        {
            string sql = "sp_TongHop_DuLieu_Xa " + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdXa.SetDataBinding(ds.Tables[0], "");
            }

        }
        private void Load_Tab_Ap()
        {
            string sql = "sp_TongHop_DuLieu_Ap " + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdAp.SetDataBinding(ds.Tables[0], "");
            }
            else
            {
                this.gdAp.DataSource = null;
            }

        }
        private void Load_Tab_Huyen()
        {
            string sql = "sp_TongHop_DuLieu_Huyen " + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdHuyen.SetDataBinding(ds.Tables[0], "");
            }

        }
      

        private void frm_TraCuuTongHop_Load(object sender, EventArgs e)
        {
            lblTitle.Text = lblTitle.Text + DACASUCO_App.TenVuTrong;
            for (int i = 0; i <= this.gdCBDB.RootTable.Columns.Count - 1; i++)
            {
                string colName = gdCBDB.RootTable.Columns[i].Caption;
                if (colName.Contains("DD_Giong"))
                {
                    string Giong_ID = colName.Substring(colName.LastIndexOf('_') + 1);
                    try
                    {
                        gdCBDB.RootTable.Columns[i].Caption = DBModule.ExecuteQueryForOneResult("SELECT Ten FROM [tbl_GiongMia] Where ID=" + Giong_ID, null, null);
                    }
                    catch { }
                }

            }
            for (int i = 0; i <= this.gdAp.RootTable.Columns.Count - 1; i++)
            {
                string colName = gdAp.RootTable.Columns[i].Caption;
                if (colName.Contains("DD_Giong"))
                {
                    string Giong_ID = colName.Substring(colName.LastIndexOf('_') + 1);
                    try
                    {
                        gdAp.RootTable.Columns[i].Caption = DBModule.ExecuteQueryForOneResult("SELECT Ten FROM [tbl_GiongMia] Where ID=" + Giong_ID, null, null);
                    }
                    catch { }
                }

            }
            Load_Tab_CBDB();
        }

        private void Tab_TRACUU_TONGHOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tab_TRACUU_TONGHOP.SelectedIndex == 0)
            {
                Load_Tab_CBDB();
                iSelect = 0;
            }
          
            if (Tab_TRACUU_TONGHOP.SelectedIndex == 1)
            {
                Load_Tab_Ap();
                iSelect = 1;
            }
            if (Tab_TRACUU_TONGHOP.SelectedIndex == 2)
            {
                Load_Tab_Xa();
                iSelect = 2;
            }
            if (Tab_TRACUU_TONGHOP.SelectedIndex == 3)
            {
                Load_Tab_Huyen();
                iSelect = 3;
            }
          
        }

        private void cmdXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (iSelect == 0)
                {
                    saveFileDialog.FileName = "DuLieu_TongHop_CBDB_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                }
              
                if (iSelect == 1)
                {
                    saveFileDialog.FileName = "DuLieu_TongHop_Ap_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                }
                if (iSelect == 2)
                {
                    saveFileDialog.FileName = "DuLieu_TongHop_Xa_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                }
                if (iSelect == 3)
                {
                    saveFileDialog.FileName = "DuLieu_TongHop_Huyen_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                }
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        if (iSelect == 0)
                        {
                            exporter.GridEX = gdCBDB;
                        }
                        if (iSelect == 1)
                        {
                            exporter.GridEX = gdAp;
                        }
                         if (iSelect == 2)
                        {
                            exporter.GridEX = gdXa;
                        }
                         if (iSelect == 3)
                        {
                            exporter.GridEX = gdHuyen;
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
                System.Data.DataTable dt = (System.Data.DataTable)gdCBDB.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                PhamVi = "DỰ BÁO THEO TRẠM";
            }
            else if (iSelect == 1)
            {
                System.Data.DataTable dt = (System.Data.DataTable)gdAp.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                PhamVi = "DỰ BÁO THEO ẤP";
            }
            else if (iSelect == 2)
            {
                System.Data.DataTable dt = (System.Data.DataTable)gdXa.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                PhamVi = "DỰ BÁO THEO XÃ";
            }
            else if (iSelect == 3)
            {
                System.Data.DataTable dt = (System.Data.DataTable)gdHuyen.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                PhamVi = "DỰ BÁO THEO CÁC HUYỆN";
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
