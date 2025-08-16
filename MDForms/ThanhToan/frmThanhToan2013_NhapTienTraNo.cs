using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using MDSolution;

namespace DACASUCO.MDForms.ThanhToan
{
    public partial class frmThanhToan2013_NhapTienTraNo : Form
    {
        public frmThanhToan2013_NhapTienTraNo()
        {
            InitializeComponent();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int HopDongID { get; set; }

        public int SoPhieu { get; set; }

        private void grvNoDauTu_CellEdited(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                string sThanhToan_TruNoDauTu = "[ThanhToan_NhapTienTraNo] {0},{1},N'{2}',{3},{4}";
                sThanhToan_TruNoDauTu = string.Format(sThanhToan_TruNoDauTu, MDSolution.DACASUCO_App.VuTrongID, HopDongID, grvNoDauTu.GetRow().Cells["SoHDDT"].Value, SoPhieu, grvNoDauTu.GetRow().Cells["NhapTienTraNo"].Value);
                MDSolutionEntities.DBModule.ExecuteNonQuery(sThanhToan_TruNoDauTu, null, null);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi hủy:" + ex.Message, "Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
