using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; using MDSolutionEntities;
using MDSolution;
using DACASUCO.MDReport;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace MDSolution
{
    public partial class frm_RP_TheoDoi_NS_SL : Form
    {

        int iSelect=0;
        string TenDV = "";
        public frm_RP_TheoDoi_NS_SL()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Load_Tab_Tram()
        {
            
            string sql = "Select * from V_RP_DuBao_NS_SL_Tram Where VuTrongID="+DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdTram.SetDataBinding(ds.Tables[0], "");
            }
         
        }
        private void Load_Tab_CBDB()
        {
            string sql = "Select * from V_RP_DuBao_NS_SL_CBDB Where VuTrongID=" + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdCBDB.SetDataBinding(ds.Tables[0], "");
            }

        }
        private void Load_Tab_Xa()
        {
            string sql = "Select * from V_RP_DuBao_NS_SL_Xa Where VuTrongID=" + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdXa.SetDataBinding(ds.Tables[0], "");
            }

        }
        private void Load_Tab_CM()
        {
            string sql = "Select * from V_RP_DuBao_NS_SL_CM Where VuTrongID=" + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdCM.SetDataBinding(ds.Tables[0], "");
            }

        }
        private void Load_Tab_Huyen()
        {
            string sql = "Select * from V_RP_DuBao_NS_SL_Huyen Where VuTrongID=" + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdHuyen.SetDataBinding(ds.Tables[0], "");
            }

        }
        private void Load_Tab_Ben()
        {
            string sql = "Select * from V_RP_DuBao_NS_SL_Ben Where VuTrongID=" + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdBen.SetDataBinding(ds.Tables[0], "");
            }

        }
        private void Load_Tab_Tinh()
        {
            string sql = "Select * from V_RP_DuBao_NS_SL_Tinh Where VuTrongID=" + DACASUCO_App.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                gdTinh.SetDataBinding(ds.Tables[0], "");
            }

        }
        private void frm_RP_TheoDoi_NS_SL_Load(object sender, EventArgs e)
        {
            lblNV.Text = DACASUCO_App.TenVuTrong;
            Tab_DB_NSSL.SelectedIndex = 3;
            Load_Tab_Tram();
            //txtLoc.Focus();
        }

        private void Tab_DB_NSSL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tab_DB_NSSL.SelectedIndex == 0)
            {
                TenDV = "Họ tên Chủ mía";
               
                Load_Tab_CM();
                gdCM.RootTable.RemoveFilter();
               
                iSelect = 0;
            }
            if (Tab_DB_NSSL.SelectedIndex == 1)
            {
                TenDV = "Họ tên CBĐB";
               
                Load_Tab_CBDB();
                gdCBDB.RootTable.RemoveFilter();
               
                iSelect = 1;
            }
            if (Tab_DB_NSSL.SelectedIndex == 2)
            {
                TenDV = "Tên Bến";
               
                Load_Tab_Ben();
                gdBen.RootTable.RemoveFilter();
               
                iSelect = 2;
            }
            if (Tab_DB_NSSL.SelectedIndex == 3)
            {
                TenDV = "Tên Trạm";
               
                Load_Tab_Tram();
                gdTram.RootTable.RemoveFilter();
               
                iSelect = 3;
            }
            if (Tab_DB_NSSL.SelectedIndex == 4)
            {
                TenDV = "Tên Xã";
               
                Load_Tab_Xa();
                gdXa.RootTable.RemoveFilter();
               
                iSelect = 4;
            }
            if (Tab_DB_NSSL.SelectedIndex == 5)
            {

                TenDV = "Tên Huyện";
                
                Load_Tab_Huyen();
                gdHuyen.RootTable.RemoveFilter();
                
                iSelect = 5;
            }
            if (Tab_DB_NSSL.SelectedIndex == 6)
            {
                TenDV = "Tên Tỉnh";
                
                Load_Tab_Tinh();
                gdTinh.RootTable.RemoveFilter();
                
                iSelect = 6;
            }
        }

        //private void txtLoc_Click(object sender, EventArgs e)
        //{
        //    txtLoc.Text = "";
        //}

        //private void txtLoc_TextChanged(object sender, EventArgs e)
        //{
        //   if (txtLoc.Text != "")
        //    {
        //        cmdPrint.Enabled = false;
        //   }
        //   else
        //   {
        //       cmdPrint.Enabled = true;
        //   }

        //    Janus.Windows.GridEX.GridEXFilterCondition con = new Janus.Windows.GridEX.GridEXFilterCondition();
        //    if (Tab_DB_NSSL.SelectedIndex==0)
        //    {
        //        con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(gdCM.RootTable.Columns["HTKD"], Janus.Windows.GridEX.ConditionOperator.Contains, txtLoc.Text));
        //        gdCM.RootTable.ApplyFilter(con);
        //     }
        //    if (Tab_DB_NSSL.SelectedIndex==1)
        //    {
        //        con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(gdCBDB.RootTable.Columns["HTKD"], Janus.Windows.GridEX.ConditionOperator.Contains, txtLoc.Text));
        //        gdCBDB.RootTable.ApplyFilter(con);
        //    }
        //    if (Tab_DB_NSSL.SelectedIndex == 2)
        //    {
        //        con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(gdBen.RootTable.Columns["HTKD"], Janus.Windows.GridEX.ConditionOperator.Contains, txtLoc.Text));
        //        gdBen.RootTable.ApplyFilter(con);
        //    }
        //    if (Tab_DB_NSSL.SelectedIndex == 3)
        //    {
        //        con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(gdTram.RootTable.Columns["HTKD"], Janus.Windows.GridEX.ConditionOperator.Contains, txtLoc.Text));
        //        gdTram.RootTable.ApplyFilter(con);
        //    }
        //    if (Tab_DB_NSSL.SelectedIndex == 4)
        //    {
        //        con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(gdXa.RootTable.Columns["HTKD"], Janus.Windows.GridEX.ConditionOperator.Contains, txtLoc.Text));
        //        gdXa.RootTable.ApplyFilter(con);
        //    }
        //    if (Tab_DB_NSSL.SelectedIndex == 5)
        //    {
        //        con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(gdHuyen.RootTable.Columns["HTKD"], Janus.Windows.GridEX.ConditionOperator.Contains, txtLoc.Text));
        //        gdHuyen.RootTable.ApplyFilter(con);
        //    }
        //    if (Tab_DB_NSSL.SelectedIndex == 6)
        //    {
        //        con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(gdTinh.RootTable.Columns["HTKD"], Janus.Windows.GridEX.ConditionOperator.Contains, txtLoc.Text));
        //        gdTinh.RootTable.ApplyFilter(con);
        //    }
                        
        //}

        private void cmdPrint_Click(object sender, EventArgs e)
        {
           
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
                            exporter.GridEX = gdCM;
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

        private void cmdPrint_Click_1(object sender, EventArgs e)
        {
            string PhamVi = "";
            frmShowRP2 frm = new frmShowRP2();
            rpt_TongHop_DuBao_NSSL rp = new rpt_TongHop_DuBao_NSSL();
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            if (iSelect == 0)
            {
                System.Data.DataTable dt = (System.Data.DataTable)gdCM.DataSource;
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

        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

    }
}
