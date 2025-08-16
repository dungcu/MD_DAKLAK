using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms
{
    public partial class frmChuyenHDVC : Form
    {
        long Xe_ID = 0;
        long HDVC_ID1 = 0;
        long HDVC_ID2 = 0;
        string So_Xe = "";
        string Loai_Xe = "";
        string Ghi_Chu = "";
        DateTime DT = DateTime.Now;
        public frmChuyenHDVC()
        {
            InitializeComponent();
        }
        public frmChuyenHDVC(string SoXe,string LoaiXe,string GhiChu,long XeID,long HDVCID)
        {
            InitializeComponent();
            Xe_ID = XeID;
            HDVC_ID1 = HDVCID;
            So_Xe = SoXe;
            Loai_Xe = LoaiXe;
            Ghi_Chu = GhiChu;
            Load_cbChuHDVC();
            lblSoXe.Text = SoXe;
            clsHopDongVanChuyen oHDVC = new clsHopDongVanChuyen(HDVCID);
            oHDVC.Load(null, null);
            lblHDVC.Text = oHDVC.TenChuHopDong;
        }
        private void Load_cbChuHDVC()
        {
            try
            {
                string sql = "Select ID,TenChuHopDong from tbl_HopDongVanChuyen Order By TenChuHopDong ASC";
                DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                DataRow dr = ds.Tables[0].NewRow();
                dr["ID"] = 0;
                dr["TenChuHopDong"] = "";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cboHDVC.DataSource = ds.Tables[0];
                cboHDVC.ValueMember = "ID";
                cboHDVC.DisplayMember = "TenChuHopDong";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboHDVC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHDVC.SelectedIndex > 0)
            {
                HDVC_ID2 = long.Parse(cboHDVC.SelectedValue.ToString());
                clsHopDongVanChuyen oHDVC = new clsHopDongVanChuyen(HDVC_ID2);
                oHDVC.Load(null, null);
                lblMaHD.Text = oHDVC.MaHopDong;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (cboHDVC.SelectedIndex > 0)
            {
                if (HDVC_ID1 == HDVC_ID2)
                {
                    MessageBox.Show("Xe vẫn thuộc về cùng một hợp đồng, bạn chọn hợp đồng khác để chuyển", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Bạn chắc chắn chuyển hợp đồng cho xe như đã chọn?", "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string sql = "Update tbl_XeVanChuyen Set NKT='" + dtNgay.Value.ToString() + "' Where HopDongVanChuyenID=" + HDVC_ID1.ToString() + " AND ID=" + Xe_ID.ToString();
                        DBModule.ExecuteQuery(sql, null, null);
                        //sql = "Insert into tbl_XeVanChuyen" +
                        //    "(ID,SoXe,LoaiXe,GhiChu,HopDongVanChuyenID,VuTrongID) Values(" + Xe_ID.ToString() + ",N'" + So_Xe + "',N'" + Loai_Xe + "',N'" + Ghi_Chu + "'," + HDVC_ID2.ToString() + "," + MDSolutionApp.VuTrongID.ToString() + ")";
                        //DBModule.ExecuteQuery(sql, null, null);
                        clsXeVanChuyen oXe = new clsXeVanChuyen();
                        oXe.SoXe = So_Xe;
                        oXe.LoaiXe = Loai_Xe;
                        oXe.HopDongVanChuyenID = HDVC_ID2;
                        oXe.GhiChu = Ghi_Chu;
                        oXe.VuTrongID = MDSolutionApp.VuTrongID;
                        oXe.Save(null, null);
                        long XeID=long.Parse(DBModule.ExecuteQueryForOneResult("Select ID from tbl_XeVanchuyen Where SoXe=N'" + So_Xe + "' AND HopDongVanChuyenID="+HDVC_ID2.ToString(),null,null));
                        sql = "Update tbl_NhapMia set HopDongVanChuyenID=" + HDVC_ID2.ToString() + ",XeID=" + XeID.ToString()+
                        " Where DaThanhToanVC=0 AND SoXe=N'" + So_Xe + "' AND NgayVanChuyen>= " + DBModule.RefineDatetime(dtNgay.Value);
                        DBModule.ExecuteQuery(sql, null, null);
                        MessageBox.Show("Bạn đã chuyển thành công!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Đã có lỗi xảy ra!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn một hợp đồng trong Combo box!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboHDVC.Focus();
            }
        }

        private void dtNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtNgay.Value > DT) dtNgay.Value = DT;
        }

        private void frmChuyenHDVC_Load(object sender, EventArgs e)
        {
            DT=DateTime.Parse(DBModule.ExecuteQueryForOneResult("Select GetDate()",null,null));
            dtNgay.Value = DT;
        }
    }
}
