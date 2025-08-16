using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace DACASUCO.MDReport.DakNongReport
{
    public partial class TimKiemHopDongVanChuyen : Form
    {
        public DataTable dtDataSearch { get; set; }
        public TimKiemHopDongVanChuyen()
        {
            InitializeComponent();
        }

        public void Search()
        {
            DataView dv = dtDataSearch.DefaultView;
            dv.RowFilter = "(1=1) ";
            if (!string.IsNullOrEmpty(txtMaHD.Text))
                dv.RowFilter += " AND (ID LIKE '%" + txtMaHD.Text.Replace("'", "") + "%')";
            if (!string.IsNullOrEmpty(txtTenChuMia.Text))
                dv.RowFilter += " AND ((TenChuHopDong LIKE  '%" + txtTenChuMia.Text.Replace("'", "") + "%') OR (HoTenKhongDau LIKE  '%" + txtTenChuMia.Text.Replace("'", "") + "%'))";
            grvCongNoVanChuyenMia.SetDataBinding(dv.ToTable(), "");
            grvCongNoVanChuyenMia.Refresh();
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void txtTenChuMia_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        public string MaHD { get; set; }
        private void grvCongNoVanChuyenMia_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            MaHD = grvCongNoVanChuyenMia.GetRow().Cells["ID"].Value.ToString();
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MaHD = "";
            try
            {
                MaHD = grvCongNoVanChuyenMia.GetRow().Cells["ID"].Value.ToString();
                this.Close();
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MaHD = "";
            this.Close();
        }

        private void txtMaHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Search();
                if (grvCongNoVanChuyenMia.GetRows().Length > 0)
                    grvCongNoVanChuyenMia.Focus();
            }
        }
    }
}
