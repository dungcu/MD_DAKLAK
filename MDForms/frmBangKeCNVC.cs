using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using System.Runtime.InteropServices;
using SQL = System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using MDSolution;

namespace DACASUCO.MDForms
{
    public partial class frmBangKeCNVC : Form
    {
        double TT = 0;
        static frmBangKeCNVC _thefrmBangKeCNVC;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmBangKeCNVC OneInstanceFrm
        {
            get
            {
                if (null == _thefrmBangKeCNVC || _thefrmBangKeCNVC.IsDisposed)
                {
                    _thefrmBangKeCNVC = new frmBangKeCNVC();
                }

                return _thefrmBangKeCNVC;
            }
        }
      
        
        public frmBangKeCNVC()
        {
            InitializeComponent();
          
        }

        void ReloadGV(System.Data.DataTable dtb)
        {
            gdCongNoHDVC.AutoGenerateColumns = false;
            gdCongNoHDVC.Columns["MaHopDong"].DataPropertyName = "MaHopDong";
            gdCongNoHDVC.Columns["VCDK"].DataPropertyName = "VCDK";
            gdCongNoHDVC.Columns["TTDK"].DataPropertyName = "TTDK";
            gdCongNoHDVC.Columns["VCTK"].DataPropertyName = "VCTK";
            gdCongNoHDVC.Columns["TTTK"].DataPropertyName = "TTTK";
            gdCongNoHDVC.Columns["SDCK"].DataPropertyName = "SDCK";
            if(gdCongNoHDVC.Rows.Count>0)
            gdCongNoHDVC.Rows.RemoveAt(0);
            gdCongNoHDVC.DataSource =dtb;
            gdCongNoHDVC.Show();
            TinhTong();
        }
        void TinhTong()
        {
            double DuDK = 0;
            double TTDK = 0;
            long SoHD = 0;
            double VCTK= 0;
            double TTTK = 0;
            foreach (DataGridViewRow dr in gdCongNoHDVC.Rows)
            {
                   DuDK += double.Parse(dr.Cells["VCDK"].Value.ToString());
                   TTDK += double.Parse(dr.Cells["TTDK"].Value.ToString());
                VCTK += double.Parse(dr.Cells["VCTK"].Value.ToString());
                TTTK += double.Parse(dr.Cells["TTTK"].Value.ToString());
                try
                {
                    SoHD++;
                }
                catch
                {
                    SoHD=0;
                }
             }

            lblDuDK.Text = DuDK.ToString("# ### ### ##0");
            lblTTDK.Text = TTDK.ToString("# ### ### ##0");
            lblPSTK.Text = VCTK.ToString("# ### ### ##0");
            lbl_TTTK.Text = TTTK.ToString("# ### ### ##0");
            tbl_SDCK.Text = (DuDK+VCTK-TTDK-TTTK).ToString("# ### ### ##0");
            lbl_TSHD.Text = SoHD.ToString("# ### ### ##0");
        }
        void loadRoot()
        {
            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd 00:00:00");
            string Den = dtDen.ToString("yyyy-MM-dd 23:59:59");
            string strSQL = "sp_TongHopCongNoVC " + MDSolution.DACASUCO_App.VuTrongID.ToString() + ",'" + Tu + "','" + Den + "'";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            ReloadGV(ds.Tables[0]);
        }
      
        private void cmdIn_Click(object sender, EventArgs e)
        {
            if (gdCongNoHDVC.Rows.Count > 0)
            {
                frmShowRP2 frm = new frmShowRP2();
                 DACASUCO.MDReport.rpt_CongNoVC rp = new DACASUCO.MDReport.rpt_CongNoVC();
                 rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                 System.Data.DataTable dt = (System.Data.DataTable)gdCongNoHDVC.DataSource;
                 //double TC = double.Parse(TT);
                 //string TienChu = frmShowRP3.DocSo(TT);
                 rp.Database.Tables[0].SetDataSource(dt);
                   rp.SetParameterValue("TuNgay", dtTuNgay.Value.ToString("dd/MM/yyyy"));
                   rp.SetParameterValue("DenNgay", dtDenNgay.Value.ToString("dd/MM/yyyy"));
                  // rp.SetParameterValue("TienBangChu", TienChu);
                  // rp.SetParameterValue("HoTen", txt_sophieu.Text);
                   frm.RP = rp;
                   
                   frm.RPtitle = "Bảng kê công nợ chủ HĐVC";
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

        private void frmBangKeCNVC_Load(object sender, EventArgs e)
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

        private void cmd2Exel_Click(object sender, EventArgs e)
        {
            if (gdCongNoHDVC.DataSource != null)
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

                        for (int j = 0; j <= this.gdCongNoHDVC.ColumnCount - 1; j++)
                        {
                            int k = j + 1;
                            string colName = gdCongNoHDVC.Columns[j].HeaderText;
                            xlWorkSheet.Cells[1, k] = colName;

                        }
                        for (int r = 0; r <= gdCongNoHDVC.RowCount - 1; r++)
                        {
                            int hang = r + 1;
                            for (int c = 0; c <= gdCongNoHDVC.ColumnCount - 1; c++)
                            {
                                //        int cot = c + 1;

                                DataGridViewCell cell = gdCongNoHDVC[c, r];
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