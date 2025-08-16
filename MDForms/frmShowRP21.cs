using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.SCREventLog;
using CrystalDecisions.Shared;
namespace DACASUCO.MDForms
{
    public partial class frmShowRP2 : Form
    {
        static frmShowRP2 _theformShowRP2;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmShowRP2 OneInstanceFrm
        {
            get
            {
                if (null == _theformShowRP2 || _theformShowRP2.IsDisposed)
                {
                    _theformShowRP2 = new frmShowRP2();
                }

                return _theformShowRP2;
            }
        }
        public frmShowRP2()
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
        
        #region doc so:
        public static string DocSo(double n)
        {

            string strSo = n.ToString();

            int len = (int)strSo.Length / 3;

            if (len * 3 < strSo.Length) len++;

            string[] t = new string[len];

            int i = 0;

            while (strSo != "")
            {

                if (strSo.Length > 3)
                {

                    t[i] = strSo.Substring(strSo.Length - 3, 3);

                    strSo = strSo.Substring(0, strSo.Length - 3);

                }

                else
                {

                    t[i] = strSo;

                    strSo = "";

                }

                i++;

            }

            string str = "";

            string temp;

            for (i = t.Length - 1; i >= 0; i--)
            {

                temp = Doc3(t[i]);

                if (temp.Trim() != "")
                {

                    str += temp.Trim() + " " + DonVi(i + 1) + " ";

                }

            }

            return str.Substring(0, 1).ToUpper() + str.Substring(1);

        }


        public static string DonVi(int n)
        {

            string str = "";

            switch (n.ToString())
            {

                case "0":

                    str = "VN";

                    break;

                case "1":

                    str = "đồng";

                    break;

                case "2":

                    str = "nghìn";

                    break;

                case "3":

                    str = "triệu";

                    break;

                case "4":

                    str = "tỷ";

                    break;

            }

            return str;

        }

        public static string Doc3(string n)
        {

            string tram = string.Empty, chuc = string.Empty, dv = string.Empty;

            if (n.Length == 3)
            {

                tram = n[0].ToString();

                chuc = n[1].ToString();

                dv = n[2].ToString();

            }

            if (n.Length == 2)
            {

                chuc = n[0].ToString();

                dv = n[1].ToString();

            }

            if (n.Length == 1)
            {

                dv = n[0].ToString();

            }

            if (n != "000")
            {

                if (tram != "") tram = So(int.Parse(tram)) + " trăm";

                if (chuc != "")
                {

                    switch (chuc)
                    {

                        case "0":

                            if (dv != "0")
                            {

                                chuc = "lẻ"; dv = So(int.Parse(dv));

                            }
                            else
                            {

                                dv = "";

                                chuc = "";

                            }

                            break;

                        case "1":

                            chuc = " mười";

                            if (dv != "0")
                            {

                                if (dv == "5")
                                {

                                    dv = "lăm";

                                }
                                else
                                {

                                    dv = So(double.Parse(dv));

                                }

                            }
                            else
                            {

                                dv = "";

                            }

                            break;

                        default:

                            chuc = So(int.Parse(chuc)) + " mươi";

                            if (dv == "5")
                            {

                                dv = "lăm";

                            }

                            else
                            {

                                if (dv != "0") dv = So(int.Parse(dv));

                                else dv = "";

                            }

                            //dv = So(int.Parse(dv));

                            break;

                    }

                }

                else
                {

                    if (chuc != "")
                    {

                        switch (chuc)
                        {

                            case "1":

                                chuc = " mươi";

                                if (dv != "0")
                                {

                                    if (dv == "5")
                                    {

                                        dv = "lăm";

                                    }

                                    else
                                    {

                                        dv = So(int.Parse(dv));

                                    }

                                }

                                break;

                            default:

                                chuc = So(int.Parse(chuc)) + " mươi";

                                if (dv == "5")
                                {

                                    dv = "lăm";

                                }

                                else
                                {

                                    dv = So(int.Parse(dv));

                                }

                                break;

                        }


                    }

                    else
                    {

                        dv = So(int.Parse(dv));

                    }

                }

            }

            else
            {

                tram = "";

                chuc = "";

                dv = "";

            }

            return tram + " " + chuc + " " + dv;

        }

        public static string So(double n)
        {

            string str = "";

            switch (n.ToString())
            {

                case "0":

                    str = "không";

                    break;

                case "1":

                    str = "một";

                    break;

                case "2":

                    str = "hai";

                    break;

                case "3":

                    str = "ba";

                    break;

                case "4":

                    str = "bốn";

                    break;

                case "5":

                    str = "năm";

                    break;

                case "6":

                    str = "sáu";

                    break;

                case "7":

                    str = "bẩy";

                    break;

                case "8":

                    str = "tám";

                    break;

                case "9":

                    str = "chín";

                    break;

            }

            return str;

        }
        #endregion
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
        /// Nếu được thiết lập,Report sẽ lọc theo vụ trồng
        /// </summary>
        public string VuTrongIDName;
        public string ThonIDName;
        public string DienTichToiThieu;
        public string DinhMucToiThieu;
        public string NgayLocName;
        public long TongTien;
        /// <summary>
        /// Các báo cáo cần lọc dữ liệu trong ngày thì set TrongNgay=1 và ParameterOn=1 
        /// </summary>
        public int TrongNgay;
        public int DieuKienLocEnable;
        public int ParameterOn=0;
        public string DotThanhToanName;
        int portback=0;
        void reload()
        {
            
            

            if (RPtitle != null)
            {
                this.Text ="Báo cáo: "+ RPtitle;
                label1.Text = this.Text;
            }
            if (NgayLocName == null)
            {
                pnNgayThang.Visible = false;


            }
            if (DotThanhToanName != null) 
                pnDotThanhToan.Visible = true;
            else
            if (DienTichToiThieu == null && DinhMucToiThieu==null)
            {
                pnDienTichToiThieu.Visible = false;


                if (RP != null)
                {
                    if (VuTrongIDName != null)
                        RP.RecordSelectionFormula = VuTrongIDName + "=" + comboBox1.SelectedValue;
                    else
                        panel2.Visible = false;
                    try
                    {
                        RP.DataDefinition.FormulaFields["TongSoTienBangChu"].Text = "'" + DocSo(TongTien) + "'";
                    }
                    catch { }
                    if (ParameterOn != 0)
                            if (CheckDieuKien.Checked == true)
                            {
                                SetParameter();
                            }
                            else
                            {
                                SetParameterDefau();
                            }
                            //if (RP.RecordSelectionFormula != null && RP.RecordSelectionFormula.ToString().Length>0)
                            //    RP.RecordSelectionFormula += " and " + RP_RecordSelectFor;
                       try
                       {
                        if (RP.Rows!=null)
                        {     

                            crystalReportViewer1.ReportSource = RP;
                            portback = 1;
                        }
                        }
                    catch
                       {
                    //else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu cho báo cáo", "Thông báo");
                        crystalReportViewer1.ReportSource = null;
                    }
                    }
                    //crystalReportViewer1.ReportSource = RP;
                }
                else
                {
                    MessageBox.Show("Form chưa thiết lập report cần show", "Cảnh báo lỗi");
                    //this.sho
                    crystalReportViewer1.Visible = false;
                }
            }
           


            
        }
        DateTime PaTuNgay=DateTime.MinValue;
        DateTime PaDenNgay=DateTime.MaxValue;
        DateTime[] PaValueDefau;
        
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
                pr1.AddValue(PaDenNgay.ToString("dd/MM/yyyy" + " 23:59:59"));
                RP.DataDefinition.ParameterFields["DenNgay"].ApplyCurrentValues(pr1);
                //RP.SetParameterValue("TuNgay", PaTuNgay);
                //RP.SetParameterValue("DenNgay", PaDenNgay);
                //RP.Refresh();
                SetDefau = 0;


            }
            catch { }

        }
        int SetDefau = 0;
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
                SetDefau = 1;
            }
            catch { }

        }
        string RP_RecordSelectFor;
        int y;
        private void frmShowRP2_Load(object sender, EventArgs e)
        {
            txtDienTichToiThieu.Text = "0";
            y=btTuyChonChanTrang.Top;
            //MessageBox.Show(RP.RecordSelectionFormula.ToString());
            if (RP.RecordSelectionFormula != null && RP.RecordSelectionFormula.ToString().Trim().Length>0)
                RP_RecordSelectFor = RP.RecordSelectionFormula.ToString();
            else
                RP_RecordSelectFor = "1=1";

            
            picLoading.Visible = true;
            this.Refresh();
            if (ParameterOn == 0)
            {
                CheckDieuKien.Visible = false;

            }
            else
            {
                CheckDieuKien.Visible = true;
                
                if (TrongNgay == 1)
                {
                    CheckDieuKien.Text = "Trong ngày :";
                    lbTuNgay.Text = "";
                    lbDenNgay.Text = "";
                    CheckDieuKien.Checked = true;
                }
            }
            
            //DataSet ds=RP.Database.Tables
            comboBox1.DataSource = MDSolutionEntities.DBModule.ExecuteQuery("SELECT * FROM tbl_VuTrong", null, null).Tables[0];
            comboBox1.DisplayMember = "Ten";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedValue = MDSolution.DACASUCO_App.VuTrongID;//
            this.WindowState = FormWindowState.Maximized;        
            this.Text = "Báo cáo: ";
            reload();

            getFoodter();
            


            //crystalReportViewer1.ReportRefresh();
           // this.reportViewer1.RefreshReport();
            if (panel2.Visible == false)
            {
                btTuyChonChanTrang.Top = y - panel2.Height;
                pnTuyChon.Top -= panel2.Height;
            }
            if (DinhMucToiThieu != null)
                lbDienTichToiThieu.Text = "Định mức tối thiểu:";
            picLoading.Visible = false;
            //crystalReportViewer1.Select();
            crystalReportViewer1.Focus();
            
        }
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
            if (dgvChanTrang.RowCount > 0)
                btTuyChonChanTrang.Visible = true;
            else
                btTuyChonChanTrang.Visible = false;

        }
        
        void SetFoodter()
        {
            if(dgvChanTrang.Rows.Count>0)
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
        void loc()
        {


           
            RP.Load();

            
           

            picLoading.Visible = true;
            this.Refresh();
            string strFormula = VuTrongIDName + "=" + comboBox1.SelectedValue;
            //crystalReportViewer1.RefreshReport();
            //if (CheckDieuKien.Checked == true)
                strFormula +=" and " + RP_RecordSelectFor;
            
            

            if (ParameterOn != 0)

            {
                if (CheckDieuKien.Checked == true)
                    SetParameter();
                else
                {
                    SetParameterDefau();
                }
            }
            if (DinhMucToiThieu != null)
            {
                //strFormula += " and " + DienTichToiThieu + ">=" + txtDienTichToiThieu.Text;
                try
                {
                    int i = 0;
                    try { i = int.Parse(txtDienTichToiThieu.Text); }
                    catch { i = 0; }
                    ParameterValues pr = new ParameterValues();
                    pr.AddValue(i);
                    RP.DataDefinition.ParameterFields["DinhMucToiThieu"].ApplyCurrentValues(pr);
                }
                catch { }
            }
            if (DienTichToiThieu != null)
            {
                //strFormula += " and " + DienTichToiThieu + ">=" + txtDienTichToiThieu.Text;
                try
                {
                    ParameterValues pr = new ParameterValues();
                    int i = 0;
                    try { i = int.Parse(txtDienTichToiThieu.Text); }
                    catch { i=0;}
                    pr.AddValue(i);
                    RP.DataDefinition.ParameterFields["DienTichToiThieu"].ApplyCurrentValues(pr);
                }
                catch {}
            }
            else
                if (NgayLocName != null)
                {
                    strFormula += " and " + NgayLocName + " = #" + dtNgayLoc.Value.ToString("MM/dd/yyyy") + "#";
                }
            if (DotThanhToanName != null) strFormula += " and " + DotThanhToanName + "=" + nudDotThanhToan.Value.ToString();
            
            RP.RecordSelectionFormula = strFormula;
            //MessageBox.Show(RP.RecordSelectionFormula.ToString());
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
                MessageBox.Show("Không tìm thấy dữ liệu cho báo cáo", "Thông báo");
                crystalReportViewer1.ReportSource = null;
            }
            //crystalReportViewer1.RefreshReport();
          
            picLoading.Visible = false;

        }
        private void btHienThi_Click(object sender, EventArgs e)
        {
            
            pnTuyChon.Visible = false;
            loc();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btDieuKienThem_Click(object sender, EventArgs e)
        {
           
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Control | Keys.P:
                        crystalReportViewer1.PrintReport();

                        break;
                }
            }
            return false;
        }
        
        private void btTuyChonChanTrang_Click(object sender, EventArgs e)
        {
            pnTuyChon.Visible = true;
        }

        private void btok_Click(object sender, EventArgs e)
        {
            
            //for (int i = 1; i <=dgvChanTrang.Rows.Count;i++ )
            //{
            //    try
            //    {
            //        RP.DataDefinition.FormulaFields["A" + i.ToString()].Text ="'"+ dgvChanTrang.Rows[i - 1].Cells[1].Value.ToString()+"'";
                   
            //    }
            //    catch
            //    {
            //    }
            //}

            pnTuyChon.Visible = false;
            if (portback == 1)
            {
                SetFoodter();
                reload();
            }
            else
                loc();
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            pnTuyChon.Visible = false;
        }

        private void dgvChanTrang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            

        }

        private void dgvChanTrang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            //if (txtTen.Text.ToString().Trim().Length > 0)
            //    btadd.Enabled = true;
            //else
            //    btadd.Enabled = false;
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            //dgvChanTrang.Rows[curenR].Cells[1].Value = txtTen;

        }

        private void CheckDieuKien_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckDieuKien.Checked == true)
            {
               
                pnTuNgayDenNgay.Visible = true;
                if (TrongNgay == 1)
                {
                    dtDenNgay.Visible = false;
                }
            }
            else
            {
                pnTuNgayDenNgay.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void pnTuyChon_MouseLeave(object sender, EventArgs e)
        {
            //pnTuyChon.Visible=false;
        }

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            
            dtDenNgay.MinDate = dtTuNgay.Value;
            if (dtDenNgay.Value < dtTuNgay.Value)
                dtDenNgay.Value = dtTuNgay.Value;
            if (TrongNgay == 1)
            {
                dtDenNgay.Value=dtTuNgay.Value;
            }
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

        private void txtDienTichToiThieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b' || e.KeyChar == '\r')
            { }
            else
                if ((e.KeyChar < 48 || e.KeyChar > 57))
                {

                    {
                        e.KeyChar = '\0';
                        //txtDienTichToiThieu.Text = "0";
                        MessageBox.Show("Nhập sai dữ liệu", "Lỗi nhập liệu");
                    }

                }
        }

    }
}