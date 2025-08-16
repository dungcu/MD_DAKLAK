using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using SQL = System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using MDSolutionEntities;
using MDSolution;


//using Microsoft.Office.Interop.Excel.Workbook;
//using Microsoft.Office.Interop.Excel.Worksheet;
namespace DACASUCO.MDForms
{
    public partial class frmQL_NhapMiaTheoNgay : Form
    {
        static frmQL_NhapMiaTheoNgay _theformQLMiaNhapNgay;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmQL_NhapMiaTheoNgay OneInstanceFrm
        {
            get
            {
                if (null == _theformQLMiaNhapNgay || _theformQLMiaNhapNgay.IsDisposed)
                {
                    _theformQLMiaNhapNgay = new frmQL_NhapMiaTheoNgay();
                }

                return _theformQLMiaNhapNgay;
            }
        }

        private NodeDonVi nDonVi = new NodeDonVi();
        public frmQL_NhapMiaTheoNgay()
        {
            InitializeComponent();
           
        }

        private void frmQuanLyMiaNhap_Load(object sender, EventArgs e)
        {
            int widthScreen = Screen.PrimaryScreen.WorkingArea.Width;
            int heightScreen = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = widthScreen;
            this.Height = heightScreen;
            this.WindowState = FormWindowState.Maximized;
            CommonClass.LoadTreeDV(tvDonVi);
            foreach (TreeNode n in tvDonVi.Nodes)
            {
                n.Toggle();
            }

            DateTime dt;

            dt = DateTime.Now;
            dtTuNgay.Value = dt;
            loadRoot();
            lbDV.Text = "DACASUCO";
            lblVT.Text = DACASUCO_App.TenVuTrong;
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
            }
            if (nDonVi.Type == DonviTypeHD.Xa)
            {
                loadBen();
            }
            if (nDonVi.Type == DonviTypeHD.Cum)
            {
                loadTram();
            }

        }

        void ReloadGV(System.Data.DataTable dtb)
        {

            dgvNhapMia.AutoGenerateColumns = false;
            dgvNhapMia.Columns["Ngay"].DataPropertyName = "Ngay";
            dgvNhapMia.Columns["TLCan"].DataPropertyName = "TLCan";
            dgvNhapMia.Columns["TyLeTapVat"].DataPropertyName = "TyLeTapVat";
            dgvNhapMia.Columns["TLThuan"].DataPropertyName = "TLThuan";
            dgvNhapMia.Columns["CCS"].DataPropertyName = "CCS";
            dgvNhapMia.Columns["TL10CCS"].DataPropertyName = "TL10CCS";
            
            if (dgvNhapMia.Rows.Count > 0)
            dgvNhapMia.Rows.RemoveAt(0);
            dgvNhapMia.DataSource = dtb;
            dgvNhapMia.Show();
            TinhTong();
        }
        void TinhTong()
        {
            double TLCan = 0;
            double TCBQ = 0;
            double TLThuan = 0;
            double CCSBQ = 0;
            double TL10CCS = 0;
            long SN = 0;
            double ccs = 0;
            double tc = 0;
            foreach (DataGridViewRow dr in dgvNhapMia.Rows)
            {
                TLCan += double.Parse(dr.Cells["TLCan"].Value.ToString());
                try
                {
                    tc = double.Parse(dr.Cells["TyLeTapVat"].Value.ToString());
                }
                catch
                {
                    tc = 0;
                }
                TLThuan+= double.Parse(dr.Cells["TLThuan"].Value.ToString());
                try
                {
                    ccs= double.Parse(dr.Cells["CCS"].Value.ToString());
                }
                catch
                {
                    ccs = 0;
                }
                TL10CCS += double.Parse(dr.Cells["TL10CCS"].Value.ToString());
             try
                {
                    SN++;
                }
                catch
                {
                    SN = 0;
                }
             CCSBQ = CCSBQ + ccs;
             TCBQ = TCBQ + tc;

            }
            if (SN != 0)
            {
                CCSBQ = Math.Round(CCSBQ / SN, 2);
                TCBQ = Math.Round(TCBQ / SN, 2);
            }
          
                lblCCSBQ.Text = CCSBQ.ToString();
                lblTCBQ.Text = TCBQ.ToString();
                lblQuy10CCS.Text = TL10CCS.ToString("# ### ### ##0");
                lbTLCan.Text = TLCan.ToString("# ### ### ##0");
                lbTLThuan.Text = TLThuan.ToString("# ### ### ##0");
                lblSoNgay.Text = SN.ToString();
            
           
        }
        void loadRoot()
        {
            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd 00:00:00");
            string Den = dtDen.ToString("yyyy-MM-dd 23:59:59");
            string sql = "SELECT Ngay,sum(TLCan)as TLCan,sum(TL10CCS) as TL10CCS,sum(TLThuan) as TLThuan,AVG(ccs) as CCS,round(avg(tyletapvat),2)as TyLeTapVat FROM V_NhapMiaNgay " +
                " Where VutrongID="+ MDSolution.DACASUCO_App.VuTrongID.ToString()+" And Ngayvanchuyen>='"+Tu+"' And NgayVanChuyen<='"+Den+"' Group by Ngay";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            ReloadGV(ds.Tables[0]);
            //TinhTong();
        }


        void loadBen()
        {
            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd 00:00:00");
            string Den = dtDen.ToString("yyyy-MM-dd 23:59:59");
            string sql = "SELECT Ngay,sum(TLCan)as TLCan,sum(TL10CCS) as TL10CCS,sum(TLThuan) as TLThuan,AVG(ccs) as CCS,round(avg(tyletapvat),2)as TyLeTapVat FROM V_NhapMiaNgay " +
                " Where VutrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " And Ngayvanchuyen>='" + Tu + "' And NgayVanChuyen<='" + Den + "' And BaiTapKetID="+nDonVi.DonViID.ToString()+" Group by Ngay";
          
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            ReloadGV(ds.Tables[0]);

        }

        void loadTram()
        {
            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd 00:00:00");
            string Den = dtDen.ToString("yyyy-MM-dd 23:59:59");
            string sql = "SELECT Ngay,sum(TLCan)as TLCan,sum(TL10CCS) as TL10CCS,sum(TLThuan) as TLThuan,AVG(ccs) as CCS,round(avg(tyletapvat),2)as TyLeTapVat FROM V_NhapMiaNgay " +
                " Where VutrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " And Ngayvanchuyen>='" + Tu + "' And NgayVanChuyen<='" + Den + "' And TramID=" + nDonVi.DonViID.ToString() + " Group by Ngay";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            ReloadGV(ds.Tables[0]);
        }


        private void tvDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (tvDonVi.SelectedNode != null)
            {
                nDonVi = (NodeDonVi)tvDonVi.SelectedNode.Tag;
                txt_sophieu.Text = "";
                load_GV();
            }
        }

   
        private void cmdIn_Click(object sender, EventArgs e)
        {
            if (dgvNhapMia.Rows.Count > 0)
            {
                frmShowRP2 frm = new frmShowRP2();
                DACASUCO.MDReport.rpt_THSL_Theo_Tung_Ngay rp= new DACASUCO.MDReport.rpt_THSL_Theo_Tung_Ngay();
                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                System.Data.DataTable dt = (System.Data.DataTable)dgvNhapMia.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                rp.SetParameterValue("TuNgay", dtTuNgay.Value.ToString("dd/MM/yyyy"));
                rp.SetParameterValue("DenNgay", dtDenNgay.Value.ToString("dd/MM/yyyy"));
                rp.SetParameterValue("NienVu", DACASUCO_App.TenVuTrong);
             
                if (txt_sophieu.Text != "")
                {
                    if (cbChuMia.SelectedIndex > 0)
                    {
                        {
                            rp.SetParameterValue("DonVi", "Chủ mía: " + this.cbChuMia.Text.ToUpper());
                        }
                    }

                }
                else
                {
                    if (nDonVi.Type == DonviTypeHD.Xa)
                    {
                        rp.SetParameterValue("DonVi", "Vùng nguyên liệu Bến mía: " + nDonVi.DonViName.ToString().ToUpper());
                    }
                    else
                    {
                        if (nDonVi.Type == DonviTypeHD.Cum)
                        {

                            rp.SetParameterValue("DonVi", "Vùng nguyên liệu: " + nDonVi.DonViName.ToString().ToUpper());
                        }

                        else
                        {
                             rp.SetParameterValue("DonVi", "TOÀN VÙNG NGUYÊN LIỆU DACASUCO");
                        }
                    }
                }

                frm.RP = rp;
                
                frm.RPtitle = "Tổng hợp nhập mía theo ngày " + nDonVi.DonViName.ToString();
                frm.Show();
            }
      }
        

        private void txt_sophieu_TextChanged(object sender, EventArgs e)
        {
            if (txt_sophieu.Text == "")
            {
                cbChuMia.DataSource=null;
                load_GV();
                TinhTong();
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

     
        private void txt_sophieu_Click(object sender, EventArgs e)
        {
            txt_sophieu.Text = "";
        }


        private void Load_ComboChumia()
        {
            string sql = "Select ID,HoTen from tbl_HopDong where dbo.BoDauTiengViet(HoTen) like N'%" + txt_sophieu.Text + "%'";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["ID"] = 0;
                dr["HoTen"] = "";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cbChuMia.DataSource = ds.Tables[0];
                cbChuMia.ValueMember = "ID";
                cbChuMia.DisplayMember = "HoTen";
            }
        }
        private void cmdTim_Click(object sender, EventArgs e)
        {
            if (txt_sophieu.Text.Trim() != "")
            {
                cbChuMia.DataSource = null;
                Load_ComboChumia();
            }
           
        }

        private void txt_sophieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            { 
                if (txt_sophieu.Text.Trim() != "")
            {
                cbChuMia.DataSource = null;
                Load_ComboChumia();
            }
            }

        }

       private void cmd2Exel_Click(object sender, EventArgs e)
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

        private void cbChuMia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChuMia.SelectedIndex > 0)
            {
                DateTime dtTu = dtTuNgay.Value;
                DateTime dtDen = dtDenNgay.Value;
                string Tu = dtTu.ToString("yyyy-MM-dd 00:00:00");
                string Den = dtDen.ToString("yyyy-MM-dd 23:59:59");
                string sql = "SELECT Ngay,sum(TLCan)as TLCan,sum(TL10CCS) as TL10CCS,sum(TLThuan) as TLThuan,round(AVG(ccs),2) as CCS,round(avg(tyletapvat),2)as TyLeTapVat FROM V_NhapMiaNgay " +
                    " Where VutrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " And Ngayvanchuyen>='" + Tu + "' And NgayVanChuyen<='" + Den + "' And HopDongID=" + cbChuMia.SelectedValue.ToString() + " Group by Ngay";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                lbDV.Text = "Sản lượng của chủ mía";
                ReloadGV(ds.Tables[0]);
            }
        }

    }
}