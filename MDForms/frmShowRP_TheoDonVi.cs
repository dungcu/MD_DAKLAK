using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.SCREventLog;
using CrystalDecisions.Shared;
using MDSolution;
namespace DACASUCO.MDForms
{

    public partial class frmShowRP_TheoDonVi : Form
    {
        void getFoodter()
        {

            for (int i = 1; i < 5; i++)
                try
                {

                    string text = RP.DataDefinition.FormulaFields["A" + i.ToString()].Text;

                    dgvChanTrang.Rows.Add();
                    dgvChanTrang.Rows[i - 1].Cells["ViTri"].Value = text.Replace("\"", "");// RP.DataDefinition.FormulaFields["A" + i.ToString()].Text;
                    RP.DataDefinition.FormulaFields["A" + i.ToString()].Text = "";

                }
                catch { }

        }

        void SetFoodter()
        {
            if (dgvChanTrang.Rows.Count > 0)
                for (int i = 1; i <= dgvChanTrang.Rows.Count; i++)
                {
                    try
                    {
                        RP.DataDefinition.FormulaFields["A" + i.ToString()].Text = "";
                        string s = dgvChanTrang.Rows[i - 1].Cells[1].Value.ToString();
                        if (s == null)
                            s = " ";

                        RP.DataDefinition.FormulaFields["A" + i.ToString()].Text = "'" + s + "'";

                    }
                    catch
                    {
                        //break;
                    }

                }
        }

        private NodeDonVi nDonVi = new NodeDonVi();
        private NodeHopDongVanChuyen nChuHDVCID;
        private string TitleParent;
        public int ParameterOn = 0;
        public int SecssionSuppress;
        public frmShowRP_TheoDonVi()
        {
            #region set auto logon:
            ConnectionInfo ci = new ConnectionInfo();
            ci.ServerName = MDSolutionEntities.DBModule.ServerName;
            ci.UserID = MDSolutionEntities.DBModule.UserID;
            ci.Password = MDSolutionEntities.DBModule.Password;
            ci.DatabaseName = MDSolutionEntities.DBModule.DatabaseName;
            TableLogOnInfo ti = new TableLogOnInfo();
            ti.ConnectionInfo = ci;
            tblogon = ti;
            #endregion

            

            InitializeComponent();
            //CommonClass.loadTreeXa(tvDonVi);
            
        }
        /// <summary>
        /// Thiết lập reportsoure của crystalviewer
        /// </summary>
        public ReportClass RP;
        /// <summary>
        /// Thiết lập tiêu đề báo cáo
        /// </summary>
        public string RPtitle;
        /// <summary>
        /// Lấy thông tin logon vào database
        /// </summary>
        public TableLogOnInfo tblogon;
        /// <summary>
        /// Thiết lập tên của trường XaID
        /// </summary>
        public string XaIDName;
        //cưa hàng vận chuyển CuaHangID
        public string CuaHangIDName;
        /// <summary>
        /// Thiết lập tên của trường Thôn ID
        /// </summary>
        public string ThonIDName;
        public string VuTrongIDName;
        public string HopDongVC_ID_Name;
        public int DonViEnable = 0;
        DateTime PaTuNgay = DateTime.MinValue;
        DateTime PaDenNgay = DateTime.MaxValue;
        DateTime[] PaValueDefau;
        string RP_RecordSelectFor;
        void SetParameter()
        {

            try
            {

                PaTuNgay = dtTuNgay.Value;
                PaDenNgay = dtDenNgay.Value;
                ParameterValues pr = new ParameterValues();
                //MessageBox.Show(PaValue[i]);
                pr.AddValue(PaTuNgay.ToString("dd/MM/yyyy"));
                RP.DataDefinition.ParameterFields["TuNgay"].ApplyCurrentValues(pr);
                ParameterValues pr1 = new ParameterValues();

                //MessageBox.Show(PaValue[i].ToString());
                pr1.AddValue(PaDenNgay.ToString("dd/MM/yyyy"+" 23:59:59"));
                RP.DataDefinition.ParameterFields["DenNgay"].ApplyCurrentValues(pr1);
                //RP.SetParameterValue("TuNgay", PaTuNgay);
                //RP.SetParameterValue("DenNgay", PaDenNgay);
                //RP.Refresh();
               


            }
            catch { }

        }
        void SetParameterDefau()
        {
            try
            {
                ParameterValues pr = new ParameterValues();
                //MessageBox.Show(PaValue[i]);
                DateTime dt; dt = System.DateTime.MinValue;
                pr.AddValue(dt.ToString("dd/MM/yyyy"));
                RP.DataDefinition.ParameterFields["TuNgay"].ApplyCurrentValues(pr);
                ParameterValues pr1 = new ParameterValues();

                //MessageBox.Show(PaValue[i].ToString());
                dt = DateTime.MaxValue;
                pr1.AddValue(dt.ToString("dd/MM/yyyy"));
                RP.DataDefinition.ParameterFields["DenNgay"].ApplyCurrentValues(pr1);
                //RP.RecordSelectionFormula.Replace(RP_RecordSelectFor, "1=1");
            }
            catch { }

        }
        private void frmShowRP2_Load(object sender, EventArgs e)
        {
            if (RP.RecordSelectionFormula != null && RP.RecordSelectionFormula.ToString().Trim().Length > 0)
                RP_RecordSelectFor = RP.RecordSelectionFormula.ToString();
            else
                RP_RecordSelectFor = "1=1";

            if (ParameterOn == 1)
            {
                CheckDieuKien.Visible = true;
            }
            else
                CheckDieuKien.Visible = false;

            getFoodter();
            this.Text = "Vui lòng chờ...";
            this.WindowState = FormWindowState.Maximized;
            if (HopDongVC_ID_Name == null)
            {
                if (ThonIDName != null)
                    CommonClass.loadTreeDonVi(tvDonVi);
                else
                    CommonClass.loadTreeXa(tvDonVi);
            }
            else
            {
                //comboBox1.Visible = false;
                CommonClass.loadTreeHopDongVanChuyen(tvDonVi);
            }

                comboBox1.DataSource = MDSolutionEntities.DBModule.ExecuteQuery("SELECT * FROM tbl_VuTrong", null, null).Tables[0];
                comboBox1.DisplayMember = "Ten";
                comboBox1.ValueMember = "ID";
                comboBox1.SelectedValue = Convert.ToInt16(MDSolution.DACASUCO_App.VuTrongID);
         
            this.Text = "Báo cáo: ";
            if (RPtitle != null)
            {
                this.Text += RPtitle;
                label1.Text = this.Text;
            }

            foreach (TreeNode n in tvDonVi.Nodes)
            {
                n.Toggle();
            }
            crystalReportViewer1.Focus();
            

        }
        private void tvDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (HopDongVC_ID_Name == null)
                    nDonVi = (NodeDonVi)tvDonVi.SelectedNode.Tag;
                else
                    nChuHDVCID = (NodeHopDongVanChuyen)tvDonVi.SelectedNode.Tag;
                load_RP();
                //Thiet lap
                //MessageBox.Show(nDonVi.DonViID.ToString());
                //nDonVi.Type = DonviTypeHD.Xa;
            }

        }

        private void tvDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (tvDonVi.SelectedNode != null)
            {

                if (HopDongVC_ID_Name == null)
                {
                   
                    nDonVi = (NodeDonVi)tvDonVi.SelectedNode.Tag;
                }
                else
                    nChuHDVCID = (NodeHopDongVanChuyen)tvDonVi.SelectedNode.Tag;

                load_RP();
            }
        }
        void load_RP()
        {
            if (tvDonVi.SelectedNode != null)
            {
                RP.Load();
                picLoading.Visible = true;
                this.Refresh();
                if (HopDongVC_ID_Name == null)
                {
                    
                    string DieuKienLoc = "";
                    //load report vao viewer;
                    //RP.Database.Tables[0].ApplyLogOnInfo(tblogon);
                    Text = nDonVi.DonViName.ToString();

                    if (nDonVi.Type == DonviTypeHD.Xa)
                    {

                        if (XaIDName != null)
                            DieuKienLoc = XaIDName + "=" + nDonVi.DonViID.ToString();
                    }
                    if ((nDonVi.Type == DonviTypeHD.Thon) && (ThonIDName != null))
                    {
                        DieuKienLoc = ThonIDName + "=" + nDonVi.DonViID.ToString();
                        //MessageBox.Show(nDonVi.DonViID.ToString());
                    }
                    if (nDonVi.Type == DonviTypeHD.CuaHang)
                        {
                            if (CuaHangIDName != null)
                                DieuKienLoc = CuaHangIDName + "=" + nDonVi.DonViID.ToString();
 
                        }
                    if ((nDonVi.Type == DonviTypeHD.Root) && (DonViEnable == 1))
                    {
                        DieuKienLoc = "1=1";// ThonIDName + "=" + nDonVi.DonViID.ToString();

                    }
                    //if (CheckDieuKien.Checked == true)
                    //    DieuKienLoc += " and " + RP_RecordSelectFor;

                    if (DieuKienLoc != "")
                    {
                        if (ParameterOn != 0)
                            if (CheckDieuKien.Checked == true)
                            {
                                DieuKienLoc += " and " + RP_RecordSelectFor;
                            }
                            else
                            {
                                //SetParameterDefau();
                            }
                        
                        if (VuTrongIDName != null)
                            RP.RecordSelectionFormula = DieuKienLoc + " and " + VuTrongIDName + "=" + comboBox1.SelectedValue.ToString();
                        else
                            RP.RecordSelectionFormula = DieuKienLoc;

                        if (DonViEnable == 1)
                        {
                            try
                            {
                                if (nDonVi.Type != DonviTypeHD.Root)
                                    RP.DataDefinition.FormulaFields["DonVi"].Text = "'" + nDonVi.DonViName.ToUpper() + "'";
                                else
                                {
                                    RP.DataDefinition.FormulaFields["DonVi"].Text = "'TOÀN VÙNG'";
                                    //if (VuTrongIDName != null)
                                    //DieuKienLoc = VuTrongIDName + "=" + comboBox1.SelectedValue.ToString();
                                }
                            }
                            catch
                            {
                            }
                            if(SecssionSuppress!=null)
                            try
                            {
                                if ((nDonVi.Type == DonviTypeHD.Thon) && (SecssionSuppress>0))
                                {

                                    RP.ReportDefinition.Sections[SecssionSuppress].SectionFormat.EnableSuppress=true;//FormulaFields["DonVi"].Text = "'TOÀN VÙNG'";
                                    //if (VuTrongIDName != null)
                                    //DieuKienLoc = VuTrongIDName + "=" + comboBox1.SelectedValue.ToString();
                                }
                            }
                            catch
                            {
                                
                            }


                        }
                        LoadReportSource();


                    }


                }
                else
                {
                    //if (nDonVi.Type != DonviTypeHD.ChuHopDong)
                    {
                        if (CheckDieuKien.Checked == true)
                            RP.RecordSelectionFormula = RP_RecordSelectFor + " and ";
                        if (VuTrongIDName == null)
                            RP.RecordSelectionFormula += HopDongVC_ID_Name + " = " + nChuHDVCID.HopDongID.ToString();
                        else
                            if (nChuHDVCID.HopDongID.ToString() == "0")

                            {
                                RP.SetParameterValue("TenCHD", "Toàn bộ DACASUCO");
                                RP.RecordSelectionFormula += VuTrongIDName + " = " + comboBox1.SelectedValue.ToString();
                            }
                            else
                            {
                                RP.SetParameterValue("TenCHD", "Chủ HĐVC: " + nChuHDVCID.HopDongName);
                                RP.RecordSelectionFormula += HopDongVC_ID_Name + " = " + nChuHDVCID.HopDongID.ToString() + " and " + VuTrongIDName + " = " + comboBox1.SelectedValue.ToString();
                            }
                        //crystalReportViewer1.ReportSource = RP;
                        //crystalReportViewer1.RefreshReport();
                        LoadReportSource();
                    }

                }

                picLoading.Visible = false;



            }

        }
        void LoadReportSource()
        {
            if (ParameterOn != 0)
                if (CheckDieuKien.Checked == true)
                {
                    SetParameter();
                }
                else
                {
                    SetParameterDefau();
                }
            RP.Database.Tables[0].ApplyLogOnInfo(tblogon);
            try
            {
                if (RP.Rows[0] != null)
                {
                    SetFoodter();
                    crystalReportViewer1.ReportSource = RP;
                    crystalReportViewer1.Refresh();
                }
            }
            catch
            {
               
                {
                    //MDReport.rp_T_ReportNull rpnull = new DACASUCO.MDReport.rp_T_ReportNull();
                    if (HopDongVC_ID_Name == null)
                        MessageBox.Show("Không tìm thấy dữ liệu trong đơn vị: " + nDonVi.DonViName, "Thông báo");
                    else
                        MessageBox.Show("Không tìm thấy thông tin về chủ hợp đồng: " + nChuHDVCID.HopDongName, "Thông báo");

                    crystalReportViewer1.ReportSource = null;
                    crystalReportViewer1.Refresh();
                }
            }
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tvDonVi.SelectedNode != null)
            //{
            //    if (HopDongVC_ID_Name == null)
            //        nDonVi = (NodeDonVi)tvDonVi.SelectedNode.Tag;
            //    else

            //        nChuHDVCID = (NodeHopDongVanChuyen)tvDonVi.SelectedNode.Tag;

            //    //MessageBox.Show("nDonVi.DonViID.ToString()");
            //    load_RP();
            //}
        }

        private void btok_Click(object sender, EventArgs e)
        {

                load_RP();
                pnTuyChon.Visible = false;
    
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            pnTuyChon.Visible = false;
        }

        private void btTuyChonChanTrang_Click(object sender, EventArgs e)
        {
            pnTuyChon.Visible = true;
        }
        Image img;
        private void btTuyChonChanTrang_MouseEnter(object sender, EventArgs e)
        {
            img = btTuyChonChanTrang.BackgroundImage;
            btTuyChonChanTrang.BackgroundImage = button1.BackgroundImage;
            

        }

        private void btTuyChonChanTrang_MouseLeave(object sender, EventArgs e)
        {
            btTuyChonChanTrang.BackgroundImage = img;
        }

        private void CheckDieuKien_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckDieuKien.Checked == true)
            {
                pnTuNgayDenNgay.Visible = true;
                panel2.Height = 109;
            }
            else
            {
                pnTuNgayDenNgay.Visible = false;
                panel2.Height = 48;
            }
        }

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            dtDenNgay.MinDate = dtTuNgay.Value;
            if (dtDenNgay.Value < dtTuNgay.Value)
                dtDenNgay.Value = dtTuNgay.Value;
        }
        
       
        

    }
}