using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms
{
    public partial class checkDL : Form
    {
        public checkDL()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (calendarComboTuNgay.Value > calendarComboDenNgay.Value)
                {
                    MessageBox.Show("Bạn chọn sai ngày muốn xem");
                    calendarComboTuNgay.Focus();
                }
                else
                {
                    if (uiComboBox1.SelectedValue.ToString() != "Chọn danh mục kiểm tra")
                    {
                        string[] paramNames = new string[] { "@VuTrongID", "@DenNgay", "@TuNgay" };
                        string[] paraValues = new string[] { MDSolutionApp.VuTrongID.ToString(), calendarComboDenNgay.Value.ToString(), calendarComboTuNgay.Value.ToString() };
                        
                        CommonClass.ShowReport(uiComboBox1.SelectedValue.ToString(), "", paramNames, paraValues, null);
                    }
                    else { 
                        MessageBox.Show("Bạn chưa chọn danh mục");
                    uiComboBox1.Focus();
                    }
                
                }
            }
            catch { MessageBox.Show("có lỗi khi load báo cáo"); }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}