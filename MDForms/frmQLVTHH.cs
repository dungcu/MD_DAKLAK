using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using SQL = System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using MDSolution;
using MDSolutionEntities;

namespace DACASUCO.MDForms
{
    public partial class frmQLVTHH : Form
    {
        private NodeHangHoa nDonVi = new NodeHangHoa();
        long IDVatTu = 0;
        DataSet ds;
        public frmQLVTHH()
        {
            InitializeComponent();
        }

        private void frmQLVTHH_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            CommonClass.LoadTreeHangHoa(tvDonVi);
            foreach (TreeNode n in tvDonVi.Nodes)
            {
                n.Toggle();
            }
            //tvDonVi.SelectedNode

            load_GV();

            TinhTong();
            if (DACASUCO_App.User.RolesAdd[5] == '1')
            {
                cmdSua.Enabled = true;
            }

        }
        private void tvDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nDonVi = (NodeHangHoa)tvDonVi.SelectedNode.Tag;
                if (nDonVi != null)
                    load_GV();
            }
        }

        void load_GV()
        {

            if (nDonVi.Type == HangHoaType.Root)
            {
                //loadRoot();
            }
            if (nDonVi.Type == HangHoaType.Hang)
            {
                loadHang();
            }


        }
        string sql;

        void ReloadGV(System.Data.DataTable dtb)
        {
            dgvVatTu.AutoGenerateColumns = false;
            dgvVatTu.Columns["SoPhieu"].DataPropertyName = "SoPhieuNhap";
            dgvVatTu.Columns["SoXe"].DataPropertyName = "SoXe";
            dgvVatTu.Columns["KhachHang"].DataPropertyName = "HoTen";
            dgvVatTu.Columns[4].DataPropertyName = "LoaiHang";
            dgvVatTu.Columns[5].DataPropertyName = "TongTrongLuong";
            dgvVatTu.Columns[6].DataPropertyName = "TrongLuongBiXe";
            dgvVatTu.Columns[7].DataPropertyName = "TrongLuongVatTu";
            dgvVatTu.Columns[8].DataPropertyName = "GioNhap";
            dgvVatTu.Columns[9].DataPropertyName = "NgayVao";
            dgvVatTu.Columns[10].DataPropertyName = "GioRa";
            dgvVatTu.Columns[11].DataPropertyName = "NgayRa";
            if (dgvVatTu.Rows.Count > 0) dgvVatTu.Rows.RemoveAt(0);

            dgvVatTu.DataSource = dtb;
            dgvVatTu.Show();
            TinhTong();
        }
        void TinhTong()
        {
            long TongTL = 0;
            long TLXe = 0;
            long TLVT = 0;

            int tong_xe = 0;
            foreach (DataGridViewRow dr in dgvVatTu.Rows)
            {

                TongTL += long.Parse(dr.Cells[5].Value.ToString());
                TLXe += long.Parse(dr.Cells[6].Value.ToString());
                TLVT += long.Parse(dr.Cells[7].Value.ToString());

                tong_xe++;
            }

            lbTlMia.Text = TLVT.ToString("# ### ### ##0");
            lbTongTL.Text = TongTL.ToString("# ### ### ##0");
            lbTongTLXe.Text = TLXe.ToString("# ### ### ##0");
            lbl_tongxe.Text = tong_xe.ToString();
        }
        void loadRoot()
        {

            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd");
            string Den = dtDen.ToString("yyyy-MM-dd");
            decimal dTu = GioTu.Value;
            decimal dDen = GioDen.Value;
            if (GioDen.Value > 1)
            {
                dDen = GioDen.Value - 1;
            }
            if (GioTu.Value > 23)
            {
                dTu = GioTu.Value - 1;
            }

            sql = "SELECT * FROM V_CanVatTu where 1=1 ";
            sql += " and NgayVao >='" + Tu + " " + dTu.ToString() + " :00:00' AND NgayVao <='" + Den + " " + dDen.ToString() + " :59:59'";

            sql += " Order by SoPhieuNhap";
            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count == 0) IDVatTu = 0;
            ReloadGV(ds.Tables[0]);
            TinhTong();

        }


        void loadHang()
        {
            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            decimal dTu = GioTu.Value;
            decimal dDen = GioDen.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd");
            string Den = dtDen.ToString("yyyy-MM-dd");

            sql = "SELECT * FROM V_CanVatTu where  LoaiVatTu=" + nDonVi.ID.ToString();
            if (GioDen.Value > 1)
            {
                dDen = GioDen.Value - 1;
            }
            if (GioTu.Value > 23)
            {
                dTu = GioTu.Value - 1;
            }

            sql += " and NgayVao >='" + Tu + " " + dTu.ToString() + " :00:00' AND NgayVao <='" + Den + " " + dDen.ToString() + " :59:59'";
            sql += " Order by SoPhieuNhap";
            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            ReloadGV(ds.Tables[0]);
            TinhTong();
            if (ds.Tables[0].Rows.Count == 0) IDVatTu = 0;
        }




        private void tvDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            //MessageBox.Show("dclick");
            if (tvDonVi.SelectedNode != null)
            {
                nDonVi = (NodeHangHoa)tvDonVi.SelectedNode.Tag;

                load_GV();
            }
        }

        private void cmdIn_Click(object sender, EventArgs e)
        {
            if (dgvVatTu.Rows.Count > 0)
            {
                frmShowRP2 frm = new frmShowRP2();
                MDReport.RP_CanMiaCanVatTu rp = new MDReport.RP_CanMiaCanVatTu();
                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                System.Data.DataTable dt = (System.Data.DataTable)dgvVatTu.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);


                rp.SetParameterValue("TuGio", GioTu.Value.ToString());
                rp.SetParameterValue("DenGio", GioDen.Value.ToString());
                rp.SetParameterValue("TuNgay", dtTuNgay.Value.ToString("dd/MM/yyyy"));
                rp.SetParameterValue("DenNgay", dtDenNgay.Value.ToString("dd/MM/yyyy"));
                rp.SetParameterValue("TenNguoi", DACASUCO_App.User.HoTen);
                //if (nDonVi.Type == HangHoaType.Root)
                //{
                //    rp.SetParameterValue("TenHang", "Tất cả vật tư hàng hóa");
                //}
                //else
                //{
                rp.SetParameterValue("TenHang", nDonVi.Name.ToString());
                //}
                frm.RP = rp;
                frm.RPtitle = "Tổng hợp cân vật tư hàng hóa";
                frm.Show();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Stop);


            }
        }
        private void chkChonNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (tvDonVi.SelectedNode != null)
            {
                nDonVi = (NodeHangHoa)tvDonVi.SelectedNode.Tag;
                if (nDonVi != null)
                    load_GV();
            }
        }

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                dtTuNgay.Value = dtDenNgay.Value;
            }
            else
            {
                if (GioTu.Value > GioDen.Value)
                {
                    GioTu.Value = 0;
                    GioDen.Value = 24;
                }
            }
            if (tvDonVi.SelectedNode != null)
            {
                nDonVi = (NodeHangHoa)tvDonVi.SelectedNode.Tag;
                if (nDonVi != null)
                    load_GV();
            }
        }




        private void GioTu_ValueChanged(object sender, EventArgs e)
        {

            if (tvDonVi.SelectedNode != null)
            {
                nDonVi = (NodeHangHoa)tvDonVi.SelectedNode.Tag;
                if (nDonVi != null)
                    load_GV();
            }
        }

        private void GioDen_ValueChanged(object sender, EventArgs e)
        {

            if (tvDonVi.SelectedNode != null)
            {
                nDonVi = (NodeHangHoa)tvDonVi.SelectedNode.Tag;
                if (nDonVi != null)
                    load_GV();
            }
        }

        private void dtDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtDenNgay.Value < dtTuNgay.Value)
            {
                dtDenNgay.Value = dtTuNgay.Value;
            }
            else
            {
                if (GioDen.Value < GioTu.Value)
                {
                    GioDen.Value = 24;
                    GioTu.Value = 0;
                }
            }
            if (tvDonVi.SelectedNode != null)
            {
                nDonVi = (NodeHangHoa)tvDonVi.SelectedNode.Tag;
                if (nDonVi != null)
                    load_GV();
            }
        }

        private void dgvVatTu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    IDVatTu = long.Parse(dgvVatTu.CurrentRow.Cells["ID"].Value.ToString());
                }

            }
            catch { }

        }


        private void dgvVatTu_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                IDVatTu = long.Parse(dgvVatTu.CurrentRow.Cells["ID"].Value.ToString());
            }
            catch
            {
                return;
            }

        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            decimal dTu = GioTu.Value;
            decimal dDen = GioDen.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd");
            string Den = dtDen.ToString("yyyy-MM-dd");

            sql = "SELECT * FROM V_CanVatTu where  LoaiVatTu=" + nDonVi.ID.ToString();
            if (GioDen.Value > 1)
            {
                dDen = GioDen.Value - 1;
            }
            if (GioTu.Value > 23)
            {
                dTu = GioTu.Value - 1;
            }

            sql += " and NgayVao >='" + Tu + " " + dTu.ToString() + " :00:00' AND NgayVao <='" + Den + " " + dDen.ToString() + " :59:59'";
            sql += " and  dbo.BoDauTiengViet(HoTen)like  N'%" + txtTimKiem.Text + "%'";
            sql += " Order by SoPhieuNhap";
            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            ReloadGV(ds.Tables[0]);
            TinhTong();
            if (ds.Tables[0].Rows.Count == 0)
            {
                IDVatTu = 0;
            }

        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (IDVatTu != 0)
            {

                try
                {

                    frm_SuaDuLieuCan frmSuaCan = new frm_SuaDuLieuCan();
                    frmSuaCan.ID = IDVatTu;
                    frmSuaCan.ShowDialog();
                    load_GV();
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn được phiếu cân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        private void cmd2Exel_Click(object sender, EventArgs e)
        {
            if (dgvVatTu.DataSource != null)
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

                        for (int j = 0; j <= this.dgvVatTu.ColumnCount - 1; j++)
                        {
                            int k = j + 1;
                            string colName = dgvVatTu.Columns[j].HeaderText;
                            xlWorkSheet.Cells[1, k] = colName;

                        }
                        for (int r = 0; r <= dgvVatTu.RowCount - 1; r++)
                        {
                            int hang = r + 1;
                            for (int c = 0; c <= dgvVatTu.ColumnCount - 1; c++)
                            {
                                //        int cot = c + 1;

                                DataGridViewCell cell = dgvVatTu[c, r];
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