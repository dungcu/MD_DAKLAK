using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; using MDSolutionEntities;
using Janus.Windows.GridEX;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using MDSolution.MDForms;
using MDSolution.MDCommonClass;
using MDSolution;


namespace DACASUCO.MDForms.HeThong
{
    public partial class frmComputerControls : Form
    {

        private DataSet dsComputer;
        static frmComputerControls _frmComputerControls;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmComputerControls OneInstanceFrm
        {
            get
            {
                if (null == _frmComputerControls || _frmComputerControls.IsDisposed)
                {
                    _frmComputerControls = new frmComputerControls();
                }

                return _frmComputerControls;
            }
        }

        public frmComputerControls()
        {
            try
            {
                InitializeComponent();
                LoadgdComputer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadgdComputer()
        {
            string sql = "Select * from sys_Computers";
            this.dsComputer = DBModule.ExecuteQuery(sql, null, null);

            if (this.dsComputer.Tables.Count > 0)
            {
                this.gdComputer.SetDataBinding(this.dsComputer.Tables[0], "");
            }           
        }

        private void gdVUser_RecordsDeleted(object sender, EventArgs e)
        {

            MessageBox.Show("Đã xóa thành công", DACASUCO_App.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gdVUser_RecordUpdated(object sender, EventArgs e)
        {
            //MessageBox.Show("Đã sửa thành công", SoSuCo_App.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

      
        private bool SaveOject()
        {
            //string str = gdComputer.GetValue("DonVi").ToString();

          
            try
            {
                 string iFingerPrint = gdComputer.GetValue("FingerPrint").ToString();
                 string iMDVersion = gdComputer.GetValue("MDVersion").ToString();
                 SysComputer.Update(iFingerPrint, iMDVersion, null, null);
                //oUser.Save(null, null);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void gdVUser_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {

            string message;

            message = String.Format("Bạn muốn xóa bản ghi này?");

            if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //DataRowView dr = (DataRowView)e.Row.DataRow;              
                //clsUser oUS = new clsUser(long.Parse(dr.Row.ItemArray[0].ToString()));
                string iFingerPrint = gdComputer.GetValue("FingerPrint").ToString();
                SysComputer.Delete(iFingerPrint, null, null);
                //oUS.Delete(null, null);
            }
            else
            {
                e.Cancel = true;
            }
         
        }
     
        private void gdVUser_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!SaveOject()) { e.Cancel = true; }
                else
                {
                    MessageBox.Show("Bạn đã sửa lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.gdVLVDauTu.SetValue("ID", oDMDT.ID);
                }
            }
            else
            {
                e.Cancel = true;

                gdComputer.CancelCurrentEdit();
                SendKeys.SendWait("{ESC}");
            }
        }

    
        private void uiButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}