using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using System.Reflection;
using System.Runtime.InteropServices;
using SQL = System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using MDSolution;

namespace DACASUCO.MDForms
{
    public partial class frmBangKeCCS : Form
    {
        double TT = 0;
        static frmBangKeCCS _thefrmBangKeCCS;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmBangKeCCS OneInstanceFrm
        {
            get
            {
                if (null == _thefrmBangKeCCS|| _thefrmBangKeCCS.IsDisposed)
                {
                   _thefrmBangKeCCS = new frmBangKeCCS();
                }

                return _thefrmBangKeCCS;
            }
        }
      
        private string sql = "";
        public frmBangKeCCS()
        {
            InitializeComponent();
          
        }

        private void frmBangKeThuMua_Load(object sender, EventArgs e)
        {
            int widthScreen = Screen.PrimaryScreen.WorkingArea.Width;
            int heightScreen = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = widthScreen;
            this.Height = heightScreen;
            this.WindowState = FormWindowState.Maximized;
            lblVT.Text = DACASUCO_App.TenVuTrong;
            loadRoot();
            TinhTong();            
        }
     
     
        void ReloadGV(System.Data.DataTable dtb)
        {
            dgvNhapMia.AutoGenerateColumns = false;
            dgvNhapMia.Columns["SoPhieuNhap"].DataPropertyName = "SoPhieuNhap";
            dgvNhapMia.Columns["HoTen"].DataPropertyName = "HoTen";
            dgvNhapMia.Columns["DiaChi"].DataPropertyName = "DiaChi";
            dgvNhapMia.Columns["NgayVanChuyen"].DataPropertyName = "NgayVanChuyen";
            dgvNhapMia.Columns["DienTich"].DataPropertyName = "DienTich";
            dgvNhapMia.Columns["LoaiGiong"].DataPropertyName = "LoaiGiong";
            dgvNhapMia.Columns["TenGoi"].DataPropertyName = "TenGoi";
            dgvNhapMia.Columns["TenBai"].DataPropertyName = "TenBai";
            dgvNhapMia.Columns["TrongLuongMiaSach"].DataPropertyName = "TrongLuongMiaSach";
            dgvNhapMia.Columns["CCS"].DataPropertyName = "CCS";
            dgvNhapMia.Columns["Tram"].DataPropertyName = "Tram";
            
            if(dgvNhapMia.Rows.Count>0)
            dgvNhapMia.Rows.RemoveAt(0);
            dgvNhapMia.DataSource =dtb;
            dgvNhapMia.Show();
            TinhTong();
        }
        void TinhTong()
        {
            double TLMiaSach = 0;
            long tong_xe = 0;
            long tongxeccs = 0;
            double CCS = 0;
            
            foreach (DataGridViewRow dr in dgvNhapMia.Rows)
            {
                double tlms = 0;
                try
                {
                    tlms += double.Parse(dr.Cells["TrongLuongMiaSach"].Value.ToString());
                }
                catch
                {
                tlms=0;
                }
                TLMiaSach += tlms;
               
                try
                {
                    tong_xe++;
                }
                catch
                {
                    tong_xe=0;
                }
                double chuduong = 0;
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
                
             }
            if (tongxeccs > 0)
            {
                CCS = Math.Round(CCS / tongxeccs, 2);
            }
            else
            {
                CCS = 0;
            }
            lblCCSBQ.Text = CCS.ToString();
            lbTLMiaSach.Text = TLMiaSach.ToString("# ### ### ##0");
            lbl_tongxe.Text = tong_xe.ToString();
           
        }
        void loadRoot()
        {
            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd 00:00:00");
            string Den = dtDen.ToString("yyyy-MM-dd 23:59:59");
                sql = "SELECT SoPhieuNhap,HoTen,DiaChi,NgayVanChuyen,TrongLuongMiaSach,TenBai,LoaiGiong,DienTich,CCS,TenGoi,Tram FROM V_BangKeCCS Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                sql += " And NgayVanChuyen >='" + Tu + "' AND NgayVanChuyen <='" + Den +"'";
                
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            ReloadGV(ds.Tables[0]);
        }
      
        private void cmdIn_Click(object sender, EventArgs e)
        {
            if (dgvNhapMia.Rows.Count > 0)
            {
               
                frmShowRP2 frm = new frmShowRP2();
                 DACASUCO.MDReport.rpt_BangKeCCS rp = new DACASUCO.MDReport.rpt_BangKeCCS();
                 rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                 System.Data.DataTable dt = (System.Data.DataTable)dgvNhapMia.DataSource;
                   rp.Database.Tables[0].SetDataSource(dt);
                   rp.SetParameterValue("TuNgay", dtTuNgay.Value.ToString("dd/MM/yyyy"));
                   rp.SetParameterValue("DenNgay", dtDenNgay.Value.ToString("dd/MM/yyyy"));
                   rp.SetParameterValue("TienBangChu", lblCCSBQ.Text);
                   rp.SetParameterValue("HoTen", DACASUCO_App.TenVuTrong);
                   frm.RP = rp;
                   
                   frm.RPtitle = "Bảng kê Chữ đường ";
                   frm.Show();
            }
        }
      
     

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                dtTuNgay.Value = dtDenNgay.Value;
            }
            loadRoot();
           
        }

        private void dtDenNgay_ValueChanged(object sender, EventArgs e)
        {

            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                 dtDenNgay.Value=dtTuNgay.Value;
            }
            loadRoot();
           
        }

        private void rdSP_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSP.Checked)
            {
                string sqlStr = sql+" Order by SoPhieuNhap";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sqlStr, null, null);
                ReloadGV(ds.Tables[0]);
            }
        }

        private void rdCM_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCM.Checked)
            {
                string sqlStr = sql + " Order by HoTen";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sqlStr, null, null);
                ReloadGV(ds.Tables[0]);
            }
        }

        private void rdTram_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTram.Checked)
            {
                string sqlStr = sql + " Order by Tram";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sqlStr, null, null);
                ReloadGV(ds.Tables[0]);
            }
        }

        private void rdBen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBen.Checked)
            {
                string sqlStr = sql + " Order by TenBai";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sqlStr, null, null);
                ReloadGV(ds.Tables[0]);
            }
        }

        private void rdGiong_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGiong.Checked)
            {
                string sqlStr = sql + " Order by LoaiGiong DESC";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sqlStr, null, null);
                ReloadGV(ds.Tables[0]);
            }
        }

        private void rdLuuGoc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdLuuGoc.Checked)
            {
                string sqlStr = sql + " Order by TenGoi DESC";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sqlStr, null, null);
                ReloadGV(ds.Tables[0]);
            }
        }

        private void ToExcel_Click(object sender, EventArgs e)
        {
             if (dgvNhapMia.DataSource != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.FileName.Length > 0)
                    {
                        Excel.Application xlApp;
                        Excel.Workbook xlWorkBook;
                        Excel.Worksheet xlWorkSheet;
                        object misValue = System.Reflection.Missing.Value;

                        xlApp = new Excel.Application();
                        xlWorkBook = xlApp.Workbooks.Add(misValue);
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                        for (int j = 0; j <= this.dgvNhapMia.ColumnCount - 1; j++)
                        {
                            int k = j + 1;
                            string colName = dgvNhapMia.Columns[j].HeaderText;
                            xlWorkSheet.Cells[1, k] = colName;

                        }
                        for (int r = 0; r <= dgvNhapMia.RowCount - 1; r++)
                        {
                            int hang = r + 1;
                            for (int c = 0; c <= dgvNhapMia.ColumnCount - 1; c++)
                            {
                                //        int cot = c + 1;

                                DataGridViewCell cell = dgvNhapMia[c, r];
                                xlWorkSheet.Cells[hang + 1, c + 1] = cell.Value;

                            }
                        }

                        xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        xlWorkBook.Close(true, misValue, misValue);
                        xlApp.Quit();
                        MessageBox.Show("Đã export dữ liệu ra định dạng file Excel thành công", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);
                    }

                }
                }
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

       
    }
}