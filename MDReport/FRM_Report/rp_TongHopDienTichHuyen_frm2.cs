using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDReport.NoDauTu
{
    public partial class rp_TongNoTruocKhiTru_frm2 : Form
    {
        //Test time execute:
        DateTime dts, dte;
        public rp_TongNoTruocKhiTru_frm2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btXem_Click(object sender, EventArgs e)
        {

            dts = DateTime.Now;
            string[] spParamName = new string[] { 
               "@ID"};
            string[] spParaValue = new string[] { 
               textBox2.Text
            };
            DataSet ds;
            string spName = "sp_RP_Test_HoDong";
            ds = CommonClass.ExecuteSP(spName, spParamName, spParaValue);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu theo điều kiện lọc hiện tại.Xin mời bạn chọn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            dte = DateTime.Now;
            TimeSpan tg=dte-dts;
            textBox1.Text = "e_S:" + tg.ToString();
            //In báo cáo
            dts = DateTime.Now;
            MDReport.Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "@ID"};
            string[] paraValues = new string[] { textBox2.Text };
            CommonClass.ShowReport("CrystalReport1.rpt", "", paramNames, paraValues, null);
            dte = DateTime.Now;
            tg = dte - dts;
            textBox1.Text += "e_RP:" + tg.ToString();
            //this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rp_TongNoTruocKhiTru_frm_Load(object sender, EventArgs e)
        {
            //load comboVutrong:
            try
            {
                DataSet ds = new DataSet();
                clsVuTrong.GetList("", out ds, null, null);
                ComboVuTrong.DataSource = ds.Tables[0];
                ComboVuTrong.DisplayMember = "Ten";
                ComboVuTrong.ValueMember= "ID";

            }
            catch { }
            
        }
    }
}