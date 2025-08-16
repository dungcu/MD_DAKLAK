using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace DACASUCO.MDForms.ThanhToan
{
    public partial class frm_ThanhToan2013_TimKiem : Form
    {
        public DataTable  dtDataSearch { get; set; }
        public frm_ThanhToan2013_TimKiem()
        {
            InitializeComponent();
        }
        public void Search()
        {
            DataView dv = dtDataSearch.DefaultView;
            dv.RowFilter = "(1=1) ";
            if(!string.IsNullOrEmpty ( txtMaHD.Text ))
                dv.RowFilter += " AND (MaHopDong LIKE  '%" + txtMaHD.Text.Replace("'","") + "%')";
            if (!string.IsNullOrEmpty(txtTenChuMia.Text))
                dv.RowFilter += " AND ((HoTen LIKE  '%" + txtTenChuMia.Text.Replace("'", "") + "%') OR (HoTenKhongDau LIKE  '%" + txtTenChuMia.Text.Replace("'", "")+ "%'))";
            grvThanhToanTienMia.SetDataBinding(dv.ToTable(), "");
            grvThanhToanTienMia.Refresh();
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
        public string ID { get; set; }
        private void grvThanhToanTienMia_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            MaHD = grvThanhToanTienMia.GetRow().Cells["MaHopDong"].Value.ToString();
            ID = grvThanhToanTienMia.GetRow().Cells["ID"].Value.ToString();
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MaHD = "";
            ID = "";
            try
            {
                MaHD = grvThanhToanTienMia.GetRow().Cells["MaHopDong"].Value.ToString();
                ID = grvThanhToanTienMia.GetRow().Cells["ID"].Value.ToString();
                this.Close();
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MaHD = "";
            ID = "";
            this.Close();

        }

        private void txtMaHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Search();
                if (grvThanhToanTienMia.GetRows().Length > 0)
                    grvThanhToanTienMia.Focus();
            }
        }
    }
}
