using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using MDSolution;

namespace DACASUCO.MDForms.ThanhToan
{
    public partial class frmThanhToan_DuToanThu : Form
    {
        //private frmStatus statusF = new frmStatus();
        public frmThanhToan_DuToanThu()
        {
            InitializeComponent();
        }
        DataTable dtList;
        void LoadGrid()
        {
            if (dtList == null)
            {
                dtList = MDSolutionEntities.DBModule.ExecuteQuery("ThanhToan_KeHoachThuHoiDT_GetList " + MDSolution.DACASUCO_App.VuTrongID, null, null).Tables[0];
            }
            
            DataView dv = dtList.DefaultView;
            //dv.RowFilter = "";
            //if (!string.IsNullOrEmpty(txtKey.Text))
            //{
            //    dv.RowFilter = " (MaHDDT LIKE  '%" + txtKey.Text.Replace("'", "") + "%') OR  (MaHopDong LIKE  '%" + txtKey.Text.Replace("'", "") + "%') OR  (HoTen LIKE  '%" + txtKey.Text.Replace("'", "") + "%')";
            //}
            grvDuToanThuList.SetDataBinding(dv, "");
            grvDuToanThuList.Refresh();
        }
        void SaveDB()
        {

        }

        private void frmThanhToan_DuToanThu_Load(object sender, EventArgs e)
        {
            lbl_vutrong.Text = DACASUCO_App.TenVuTrong.ToString();
            LoadGrid();
        }

        private void grvDuToanThuList_CellUpdated(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            if (e.Column == grvDuToanThuList.RootTable.Columns["DuKienThu"])
            {
                string sql = "ThanhToan_KeHoachThuHoiDT_UpdateItem {0},{1},{2},{3}";
                sql = string.Format(sql, MDSolution.DACASUCO_App.VuTrongID, grvDuToanThuList.GetRow().Cells["ID"].Value, grvDuToanThuList.GetRow().Cells["LaNoCu"].Value, grvDuToanThuList.GetRow().Cells["DuKienThu"].Value);
                MDSolutionEntities.DBModule.ExecuteNonQuery(sql, null, null);

            }
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            Janus.Windows.GridEX.GridEXFilterCondition con = new Janus.Windows.GridEX.GridEXFilterCondition();
            con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(grvDuToanThuList.RootTable.Columns["HoTen"], Janus.Windows.GridEX.ConditionOperator.Contains, txtKey.Text));
            con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(grvDuToanThuList.RootTable.Columns["SoHDDT"], Janus.Windows.GridEX.ConditionOperator.Contains, txtKey.Text));
            con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(grvDuToanThuList.RootTable.Columns["MaHopDong"], Janus.Windows.GridEX.ConditionOperator.Contains, txtKey.Text));
            con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(grvDuToanThuList.RootTable.Columns["HoTenKhongDau"], Janus.Windows.GridEX.ConditionOperator.Contains, txtKey.Text));
            
            grvDuToanThuList.RootTable.ApplyFilter(con);
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            //Tinh tu dông
            picLoading.Visible = true;
            cmd_TinhDuToanDT.Enabled = false;
            lbStatus.Text = "Đang tính toán...";
            lbStatus.Refresh();

            foreach (DataRow  gr in dtList.Rows)
            {
                if (true )
                {
                    picLoading.Refresh();
                    if (true)
                    {
                        try
                        {
                            //gr.BeginEdit();
                            //gr.Cells["DuKienThu"].Value = (decimal)gr.Cells["NoGoc"].Value + (decimal)gr.Cells["NoLai"].Value;
                            //gr.EndEdit();

                            string sql = "ThanhToan_KeHoachThuHoiDT_UpdateItem {0},{1},{2},{3}";
                            //decimal dThu = 0;
                            //if(1==1)
                            //{
                            //}
                            //else{
                            //dThu=gr["LoaiHopDong_ID"].ToString().Contains("1") && gr["LaNoCu"].ToString().Equals("0") ? (decimal)gr["NoGoc"] / 2 : (decimal)gr["NoGoc"];
                            //}
                            //MaHopDong


                            int dThu = Convert.ToInt32(gr["NoGoc"]);
                            if (gr["MaHDDT"].ToString().ToLower().StartsWith("12-v") || (gr["LoaiHopDong_ID"].ToString().Contains("1") && gr["MaHDDT"].ToString().ToLower().StartsWith("13-")))
                            {//50%:12-Vxxxx hoac 13-xxx va la dt truc tiep:
                                dThu = dThu / 2;
                            }



                            sql = string.Format(sql, MDSolution.DACASUCO_App.VuTrongID, gr["ID"], gr["LaNoCu"], dThu);
                            MDSolutionEntities.DBModule.ExecuteNonQuery(sql, null, null);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Có lỗi khi tính tự động." + ex.Message);
                        }
                    }
                }

            }

            lbStatus.Text = "Tính toán hoàn tất.";
            lbStatus.Refresh();
            cmd_TinhDuToanDT.Enabled = true ;
            picLoading.Visible = false ;
            dtList = null;
            LoadGrid();
        }

        private void btn_excel_Click(object sender, EventArgs e)
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
                        exporter.GridEX = grvDuToanThuList;
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
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_In_Click(object sender, EventArgs e)
        {            
            Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "@VuTrongID" };
            string[] paraValues = new string[] {  DACASUCO_App.VuTrongID.ToString() };
            CommonClass.ShowReport("ThanhToan\\RPT_CongNoDauTuThuHoi.rpt", "Phiếu đối trừ đầu tư", paramNames, paraValues, null);
        }
    }
}
