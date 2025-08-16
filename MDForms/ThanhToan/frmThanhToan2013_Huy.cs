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
    public partial class frmThanhToan2013_Huy : Form
    {
        public DataTable dtLichSuTT { get; set; }
        public frmThanhToan2013_Huy()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLyDoHuy.Text))
                {
                    MessageBox.Show("Bạn phải nhập lý do hủy phiếu thanh toán.");
                    txtLyDoHuy.Focus();
                    return;
                }
                foreach (DataRow dr in dtLichSuTT.Rows)
                {
                    string sThanhToan_HuyTruNoDauTu = "[ThanhToan_HuyTruNoDauTu] {0},{1},{2},{3},{4}";
                    sThanhToan_HuyTruNoDauTu = string.Format(sThanhToan_HuyTruNoDauTu, MDSolution.DACASUCO_App.VuTrongID, HopDongID, SoPhieu, dr["HopDongDTID"], dr["LaNoCu"]);
                    MDSolutionEntities.DBModule.ExecuteNonQuery(sThanhToan_HuyTruNoDauTu, null, null);
                }
                string sThanhToan_TruNoDauTu = "[ThanhToan_HuyPhieuTT] {0},{1},{2},N'{3}'";
                sThanhToan_TruNoDauTu = string.Format(sThanhToan_TruNoDauTu, MDSolution.DACASUCO_App.VuTrongID, HopDongID, SoPhieu, txtLyDoHuy.Text.Replace("'", "")+"|"+ DACASUCO_App.User.HoTen +"|"+DateTime.Now.ToString());
                MDSolutionEntities.DBModule.ExecuteNonQuery(sThanhToan_TruNoDauTu, null, null);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch(Exception ex) {
                MessageBox.Show("Có lỗi khi hủy:" +ex.Message , "Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        public int HopDongID { get; set; }
        public int SoPhieu { get; set; }

       
    }
}
