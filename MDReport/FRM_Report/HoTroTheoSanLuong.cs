using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDReport.FRM_Report
{
    public partial class HoTroTheoSanLuong : Form
    {
        public HoTroTheoSanLuong()
        {
            InitializeComponent();
        }

        private void HoTroTheoSanLuong_Load(object sender, EventArgs e)
        {
            //load comboVutrong:
            try
            {
                DataSet ds = new DataSet();
                clsVuTrong.GetList("", out ds, null, null);
                ComboVuTrong.Items.Clear();
                ComboVuTrong.DataSource = ds.Tables[0];
                ComboVuTrong.DisplayMember = "Ten";
                ComboVuTrong.ValueMember = "ID";

                DateTime dt = dateTimePicker1.Value;
               // string str = dateTimePicker1.Value.Date.ToString("dd/MM/yyyy");
            }
            catch { }
            //load comboVutrong:
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            //In báo cáo   
            long a;
            if (long.TryParse(textBox1.Text,out a))
            { }
            else
            {
                MessageBox.Show("Số tiền phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (uiComboBoxChonBC.SelectedIndex == -1)
            {
                labelLoi.Text = "Bạn phải chọn báo cáo";
            }
            else
            {
            labelLoi.Text = "";
            MDReport.Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paraNames = new string[] { "@VuTrongID", "@NgayHoTro", "@TienHoTro" };
            string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString(), dateTimePicker1.Value.Date.ToString("MM/dd/yyyy"), textBox1.Text };
            CommonClass.ShowReport(uiComboBoxChonBC.SelectedValue.ToString(), "", paraNames, paraValues, null);
            }
          
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}