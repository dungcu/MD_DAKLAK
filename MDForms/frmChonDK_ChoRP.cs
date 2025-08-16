using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.SCREventLog;
using CrystalDecisions.Shared;
using DACASUCO.MDReport;
using MDSolution;
using MDSolutionEntities;

namespace DACASUCO.MDForms
{

    public partial class frmChonDK_ChoRP : Form
    {
        #region Biến toàn cục
        public string RPName;
        public TableLogOnInfo tblogon;
        #endregion
        void getFoodter()
        {

            //for (int i = 1; i < 5; i++)
            //    try
            //    {

            //        string text = RP.DataDefinition.FormulaFields["A" + i.ToString()].Text;

            //        dgvChanTrang.Rows.Add();
            //        dgvChanTrang.Rows[i - 1].Cells["ViTri"].Value = text.Replace("\"", "");// RP.DataDefinition.FormulaFields["A" + i.ToString()].Text;
            //        RP.DataDefinition.FormulaFields["A" + i.ToString()].Text = "";

            //    }
            //    catch { }

        }

        void SetFoodter()
        {
            //if (dgvChanTrang.Rows.Count > 0)
            //    for (int i = 1; i <= dgvChanTrang.Rows.Count; i++)
            //    {
            //        try
            //        {
            //            RP.DataDefinition.FormulaFields["A" + i.ToString()].Text = "";
            //            string s = dgvChanTrang.Rows[i - 1].Cells[1].Value.ToString();
            //            if (s == null)
            //                s = " ";

            //            RP.DataDefinition.FormulaFields["A" + i.ToString()].Text = "'" + s + "'";

            //        }
            //        catch
            //        {
            //            //break;
            //        }

            //    }
        }

        private NodeDonVi nDonVi = new NodeDonVi();
        private NodeHopDongVanChuyen nChuHDVCID;
        DateTime PaTuNgay = DateTime.MinValue;
        DateTime PaDenNgay = DateTime.MaxValue;
        private string TitleParent;
        public int ParameterOn = 0;
        public int SecssionSuppress;
        public frmChonDK_ChoRP()
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
        }
        
        private void frmShowRP2_Load(object sender, EventArgs e)
        {
            //if (RPToanVung.RecordSelectionFormula != null && RPToanVung.RecordSelectionFormula.ToString().Trim().Length > 0)
            //    RPToanVung_RecordSelectFor = RPToanVung.RecordSelectionFormula.ToString();
            //else
            //    RPToanVung_RecordSelectFor = "1=1";

            CommonClass.loadTreeDonVi(tvDonVi);

            comboBox1.DataSource = MDSolutionEntities.DBModule.ExecuteQuery("SELECT * FROM tbl_VuTrong", null, null).Tables[0];
            comboBox1.DisplayMember = "Ten";
            comboBox1.ValueMember = "ID";


            foreach (TreeNode n in tvDonVi.Nodes)
            {
                n.Toggle();
            }
        }
        private void tvDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                    nDonVi = (NodeDonVi)tvDonVi.SelectedNode.Tag;
            }

        }

        private void tvDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (tvDonVi.SelectedNode != null)
            {
                nDonVi = (NodeDonVi)tvDonVi.SelectedNode.Tag;
            }
        }
        //protected override bool Load(char charCode);
        void SetParameterWith_CheckDK(ReportClass R)
        {
            //if (CheckDieuKien.Checked == true)
            //    SetParameter(R);
            //else
            //    SetParameterDefau(R);
        }
        #region Load RP Function
        void SetParameter(ReportClass RP)
        {

            try
            {
                if (rdToanVu.Checked == false)
                {
                    PaTuNgay = dtTuNgay.Value;
                    PaDenNgay = dtDenNgay.Value;
                }
                else
                {
                    PaTuNgay = DateTime.MinValue;
                    PaDenNgay = DateTime.MaxValue;
                }
                ParameterValues pr = new ParameterValues();
                //MessageBox.Show(PaValue[i]);
                pr.AddValue(PaTuNgay.ToString("dd/MM/yyyy"));
                RP.DataDefinition.ParameterFields["TuNgay"].ApplyCurrentValues(pr);
                ParameterValues pr1 = new ParameterValues();

                //MessageBox.Show(PaValue[i].ToString());
                pr1.AddValue(PaDenNgay.ToString("dd/MM/yyyy" + " 23:59:59"));
                RP.DataDefinition.ParameterFields["DenNgay"].ApplyCurrentValues(pr1);
                //if (PaTuNgay == DateTime.MinValue)
                //{
                //    RP.DataDefinition.FormulaFields[].Text="''";
                //}
                //RP.SetParameterValue("TuNgay", PaTuNgay);
                //RP.SetParameterValue("DenNgay", PaDenNgay);
                //RP.Refresh();



            }
            catch { }

        }
        void ShowRP(ReportClass R)
        {
            SetParameter(R);
            R.Database.Tables[0].ApplyLogOnInfo(tblogon);
            frmShowRP frm = new frmShowRP();
            frm.RP = R;
            frm.Show();
        }
        void loadDTThuHoi()
        {
            if (rdBCChiTiet.Checked == true)
            {
                rp_T_BCTongHopKetQuaThuHoiVonDauTuVungChiTiet rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuVungChiTiet();
                string SelectFormu = rp.RecordSelectionFormula;
                if (rdToanVu.Checked == true)
                {
                    rp.RecordSelectionFormula = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}=" + comboBox1.SelectedValue.ToString();
                    if (nDonVi.Type == DonviTypeHD.Root)
                    {
                        ShowRP(rp);
                    }
                    else
                        if (nDonVi.Type == DonviTypeHD.Xa)
                    {
                        rp.RecordSelectionFormula += " and {View_T_RPTongHopThuHoiVonDauTu.IDXa}=" + nDonVi.DonViName;
                        ShowRP(rp);
                    }
                }
                else
                {

                }
                
            }
        }
        #endregion

        void load_RP()
        {
           switch (RPName)
           {
               case "DTThuHoi":
                   loadDTThuHoi();
                   break;

           }
        }
        void LoadReportSource()
        {
            
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

       

        

        Image img;
        private void btTuyChonChanTrang_MouseEnter(object sender, EventArgs e)
        {
            //img = btTuyChonChanTrang.BackgroundImage;
            //btTuyChonChanTrang.BackgroundImage = button1.BackgroundImage;
            

        }

        private void btTuyChonChanTrang_MouseLeave(object sender, EventArgs e)
        {
            //btTuyChonChanTrang.BackgroundImage = img;
        }

        private void CheckDieuKien_CheckedChanged(object sender, EventArgs e)
        {
            //if (CheckDieuKien.Checked == true)
            //    pnTuNgayDenNgay.Enabled = true;
            //else
            //    pnTuNgayDenNgay.Enabled = false;
        }

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            dtDenNgay.MinDate = dtTuNgay.Value;
            if (dtDenNgay.Value < dtTuNgay.Value)
                dtDenNgay.Value = dtTuNgay.Value;
        }

        private void cmdChon_Click(object sender, EventArgs e)
        {
            if (nDonVi != null)
            {
                load_RP();
            }
        }

        private void cmdHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNgay.Checked == true)
                pnTuNgayDenNgay.Enabled = true;
            else
                pnTuNgayDenNgay.Enabled = false;
        }

        private void rdThang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdThang.Checked == true)
                pnThang.Enabled = true;
            else
                pnThang.Enabled = false;
        }
        
       
        

    }
}