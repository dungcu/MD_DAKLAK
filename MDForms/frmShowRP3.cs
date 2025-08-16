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
    public partial class frmShowRP3 : Form
    {
        public frmShowRP3()
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

                    str = "sắu";

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
        public string DienTichToiThieu;
        public string NgayLocName;
        public long SoTienBangChu;
        public DateTime NgayTinh;
        public string LaiDuNoVuNay;
        public string LaiDuNoVuTruoc;
        public long[] IDHopDong;
        private void frmShowRP2_Load(object sender, EventArgs e)
        {
            picLoading.Visible = true;
            this.Refresh();
            //RP = new MDReport.rp_T_DS_PhieuThanhToanMia();
            //DataSet ds=RP.Database.Tables
            comboBox1.DataSource = MDSolutionEntities.DBModule.ExecuteQuery("SELECT * FROM tbl_VuTrong", null, null).Tables[0];
            comboBox1.DisplayMember = "Ten";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedValue = MDSolution.DACASUCO_App.VuTrongID;//
            this.WindowState = FormWindowState.Maximized;        
            this.Text = "Báo cáo: ";
            if (RPtitle != null)
            {
                this.Text += RPtitle;
                label1.Text = this.Text;
            }
            getFoodter();
            loc();
            
            //crystalReportViewer1.ReportRefresh();
           // this.reportViewer1.RefreshReport();
            
        }
        void loc()
        {
            picLoading.Visible = true;
            if (NgayLocName == null)
            {
                pnNgayThang.Visible = false;


            }
            if (DienTichToiThieu == null)
            {
                pnDienTichToiThieu.Visible = false;


                if (RP != null)
                {
                    if (VuTrongIDName != null)
                        RP.RecordSelectionFormula = VuTrongIDName + "=" + comboBox1.SelectedValue;
                    else
                        panel2.Visible = false;
                    //RP.DataDefinition.FormulaFields["ThanhToan_NoDauTuVuNay_Lai"].Text = LaiDuNoVuNay;
                    //RP.DataDefinition.FormulaFields["ThanhToan_NoDauTuVuTruoc_Lai"].Text = LaiDuNoVuTruoc;
                    RP.DataDefinition.FormulaFields["NgayThang"].Text = "'ngày " + NgayTinh.Day.ToString() + " tháng " + NgayTinh.Month.ToString() + " năm " + NgayTinh.Year.ToString() + "'";
                    if (SoTienBangChu > 0)
                    {
                        RP.DataDefinition.FormulaFields["SoTienBangChu"].Text = "'Số tiền được nhận (bằng chữ): " + DocSo(SoTienBangChu) + ".'";
                        RP.DataDefinition.FormulaFields["Array"].Text = "shared stringvar array SoTien;shared numbervar array IDHopDong;redim IDHopDong[100];redim SoTien[100];'';"
                            + "SoTien[1]:='Số tiền được nhận (bằng chữ): " + DocSo(SoTienBangChu) + ".'; IDHopDong[1]=" + IDHopDong[0] + ";";

                    }
                    else
                    {
                        RP.DataDefinition.FormulaFields["SoTienBangChu"].Text = "'Số tiền còn nợ (bằng chữ): " + DocSo(0 - SoTienBangChu) + ".'";
                        RP.DataDefinition.FormulaFields["Array"].Text = "shared stringvar array SoTien;shared numbervar array IDHopDong;redim IDHopDong[100];redim SoTien[100];'';"
                            + "SoTien[1]:='Số tiền còn nợ (bằng chữ): " + DocSo(0 - SoTienBangChu) + ".'; IDHopDong[1]=" + IDHopDong[0] + ";";
                    }

                    crystalReportViewer1.ReportSource = RP;
                }
                else
                {
                    MessageBox.Show("Form chưa thiết lập report cần show", "Cảnh báo lỗi");
                    //this.sho
                    crystalReportViewer1.Visible = false;
                }
            }

            panel2.Visible = true;
            btHienThi.Visible = false;
            comboBox1.Enabled = false;
            picLoading.Visible = false;
        }
        private void btHienThi_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btTuyChonChanTrang_Click(object sender, EventArgs e)
        {
            pnTuyChon.Visible = true;
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            pnTuyChon.Visible = false;

        }

        private void btok_Click(object sender, EventArgs e)
        {
            pnTuyChon.Visible = false;
            SetFoodter();
            loc();
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
    }
}