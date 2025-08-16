using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using MDSolution;

namespace DACASUCO.MDReport.FRM_Report
{
    public partial class frmTongHopNhapMia : Form
    {
        public frmTongHopNhapMia()
        {
            InitializeComponent();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Parse(calendarCombo1.Value.ToString()) > DateTime.Now)
                {
                    MessageBox.Show("Bạn chọn ngày xem lớn hơn ngày hiện tại");
                    calendarCombo1.Focus();
                }
                else
                {
                    if (uiComboBox1.Text == "Chọn báo cáo để xem")
                    { MessageBox.Show("Bạn chưa chọn mục báo cáo để xem");
                    uiComboBox1.Focus();
                    }
                    else
                    {
                        string[] paramNames = new string[] { "@VuTrongID", "@Ngay" };
                        string[] paraValues = new string[] { MDSolution.DACASUCO_App.VuTrongID.ToString(), calendarCombo1.Value.ToString() };
                        CommonClass.ShowReport(uiComboBox1.SelectedValue.ToString(), "", paramNames, paraValues, null);
                    }
                }
            }
            catch 
            {
           MessageBox.Show("Bạn chưa chọn báo cáo để xem");
            }

        }

        private void uiComboBox1_Leave(object sender, EventArgs e)
        {
            //calendarCombo1.DateFormat.ToString("Datetime");
        }

       

       
    }
}