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
using Janus.Windows.GridEX;
using DACASUCO.MDReport;

namespace DACASUCO.MDForms
{
    public partial class frm_ThanhLyHDVC : Form
    {
        private long HDVC_ID = 0;
        int DaTL = 0;
        long TienTC = 0;
        long TienCap = 0;
        long TienC = 0;
        long TienT = 0;
        long SoSoi = 0;
        long SS = 0;
        public frm_ThanhLyHDVC()
        {
            InitializeComponent();
        }
        public frm_ThanhLyHDVC(long HDVCID)
        {
            InitializeComponent();
            HDVC_ID = HDVCID;
            clsHopDongVanChuyen oHD = new clsHopDongVanChuyen(HDVC_ID);
            oHD.Load(null, null);
            txtMaHD.Text = oHD.MaHopDong;
            txtChuHD.Text = oHD.TenChuHopDong;
            DaTL = oHD.DaTL;
            TienTC = oHD.TienTC;
            TienCap = oHD.TienCap;
            SoSoi = oHD.SoSoi;
            this.LoadTienTheChan(HDVC_ID);
            this.LoadTienTheChapCap(HDVC_ID);
           
        }
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadTTC()
        {
            GridEXRow gexr = this.gdTheChan.GetTotalRow();
            if (gexr != null && !string.IsNullOrEmpty(gexr.Cells["DonGia"].Value.ToString()))
            {
                long TTChan = long.Parse(gexr.Cells["DonGia"].Value.ToString());
                txtTheChan.Text = TTChan.ToString("### ### ##0");
            }
            else
            {
                txtTheChan.Text = "0";
            }
            GridEXRow gexry = this.grCap.GetTotalRow();
            if (gexry != null && !string.IsNullOrEmpty(gexry.Cells["SoTien"].Value.ToString()))
            {
                long TTChap = long.Parse(gexry.Cells["SoTien"].Value.ToString());
                txtCap.Text = TTChap.ToString("### ### ##0");
            }
            else
            {
                txtCap.Text = "0";
            }
            GridEXRow gexrz = this.grCap.GetTotalRow();
            if (gexrz != null && !string.IsNullOrEmpty(gexrz.Cells["SoLuong"].Value.ToString()))
            {
                long SoSoi = long.Parse(gexrz.Cells["SoLuong"].Value.ToString());
                txtSoSoi.Text = SoSoi.ToString("### ### ##0");
            }
            else
            {
                txtSoSoi.Text = "0";
            }
        }
        private void LoadTienTheChan(long HDVCID)
        {
            try
            {

                string strSQL = "SELECT SoChungTu,SoXe,NgayUng,DonGia FROM V_TheChanXe WHERE VatTuID=1 AND HopDongVanChuyenID =" + HDVCID.ToString() + " AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " Order by SoChungTu ASC";
                DataSet DSXE = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                if (DSXE.Tables[0].Rows.Count>0)
                {
                   
                    this.gdTheChan.SetDataBinding(DSXE.Tables[0], "");

                }
                else
                {
                    gdTheChan.SetDataBinding(null, "");
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load dữ liệu tiền thế chân của xe vận chuyển", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTienTheChapCap(long HDVCID)
        {
            try
            {

                string strSQL = "SELECT SoChungTu,SoLuong,NgayUng,DonGia,SoTien FROM V_TheChanCap WHERE VatTuID=2 AND HopDongVanChuyenID =" + HDVCID.ToString() + " AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " Order by SoChungTu ASC";
                DataSet DSCAP = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
             
                if (DSCAP.Tables[0].Rows.Count>0)
                {

                    this.grCap.SetDataBinding(DSCAP.Tables[0], "");

                }
                else
                {
                    grCap.SetDataBinding(null, "");
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load dữ liệu cáp thế chấp của hợp đồng vận chuyển", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_ThanhLyHDVC_Load(object sender, EventArgs e)
        {
            if (DaTL == 1)
            {
                txtCap.Text = TienCap.ToString("### ### ##0");
                txtTheChan.Text = TienTC.ToString("### ### ##0");
                txtSoSoi.Text=SoSoi.ToString("### ### ##0");
                txtCap.ReadOnly = true;
                txtTheChan.ReadOnly = true;
                txtSoSoi.ReadOnly = true;
                cmdOK.Text = "Hủy thanh lý";
                cmdIn.Enabled = true; ;
            }
            else
            {
                this.LoadTTC();
                txtCap.ReadOnly = false;
                txtTheChan.ReadOnly = false;
                txtSoSoi.ReadOnly = false;
                cmdOK.Text = "Làm thanh lý";
                cmdIn.Enabled = false;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (DaTL == 1)
            {
                if (MessageBox.Show("Bạn chắc chắn hủy thanh lý của hợp đồng này?", "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "Update tbl_HopDongVanchuyen Set Ghichu=N'',DaTL=0,TienTC=0,TienCap=0,SoSoi=0 Where ID=" + HDVC_ID.ToString();
                    try
                    {
                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                        MessageBox.Show("Đã hủy thanh lý hợp đồng thành công!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmdOK.Text = "Làm thanh lý";
                        cmdIn.Enabled = false;
                        DaTL = 0;
                        txtCap.ReadOnly = false;
                        txtTheChan.ReadOnly = false;
                        txtSoSoi.ReadOnly = false;
                        LoadTTC();
                    }
                    catch
                    {
                        MessageBox.Show("Đã có lỗi xảy ra!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn làm thanh lý cho hợp đồng này?", "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "Update tbl_HopDongVanchuyen Set Ghichu=N'Đã làm thanh lý',DaTL=1,TienTC="+txtTheChan.Text.Replace(" ","")+",TienCap="+txtCap.Text.Replace(" ","")+",SoSoi="+txtSoSoi.Text.Replace(" ","")+" Where ID=" + HDVC_ID.ToString();
                    try
                    {
                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                        MessageBox.Show("Đã làm thanh lý hợp đồng thành công!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmdOK.Text = "Hủy thanh lý";
                        cmdIn.Enabled = true; ;
                        DaTL = 1;
                        txtCap.ReadOnly = true;
                        txtTheChan.ReadOnly = true;
                        txtSoSoi.ReadOnly = true;
                    }
                    catch
                    {
                        MessageBox.Show("Đã có lỗi xảy ra!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

        }

        private void txtTheChan_TextChanged(object sender, EventArgs e)
        {
            if (txtTheChan.Text == "") txtTheChan.Text = "0";
        }

        private void txtCap_TextChanged(object sender, EventArgs e)
        {
            if (txtCap.Text == "") txtCap.Text = "0";
        }

        private void txtCap_Leave(object sender, EventArgs e)
        {
            TienC=long.Parse(txtCap.Text.Replace(" ",""));
            txtCap.Text=TienC.ToString("### ### ##0");
        }

        private void txtTheChan_Leave(object sender, EventArgs e)
        {
            TienT=long.Parse(txtTheChan.Text.Replace(" ",""));
            txtTheChan.Text=TienT.ToString("### ### ##0");
        }

        private void txtSoSoi_TextChanged(object sender, EventArgs e)
        {
            if (txtSoSoi.Text == "") txtSoSoi.Text = "0";
        }

        private void txtSoSoi_Leave(object sender, EventArgs e)
        {
            SS = long.Parse(txtSoSoi.Text.Replace(" ", ""));
            txtSoSoi.Text = SS.ToString("### ### ##0");
        }

        private void cmdIn_Click(object sender, EventArgs e)
        {
            TienC = long.Parse(txtCap.Text.Replace(" ", ""));
            TienT = long.Parse(txtTheChan.Text.Replace(" ", ""));
            SS = long.Parse(txtSoSoi.Text.Replace(" ", ""));
            frmShowRP2 frm = new frmShowRP2();
            rpt_ThanhLyHDVC rp = new rpt_ThanhLyHDVC();
            frm.RP = rp;
            rp.SetParameterValue("NienVu", DACASUCO_App.TenVuTrong);
            rp.SetParameterValue("SoSoi", SS.ToString());
            string TienCap = TienC.ToString("# ### ### ##0");
            rp.SetParameterValue("TienCap", TienCap);
            string TienTC = TienT.ToString("# ### ### ##0");
            rp.SetParameterValue("TienTC", TienTC);
            double TT = TienC + TienT;
            string TongTien = TT.ToString("# ### ### ##0");
            string BC = frmShowRP3.DocSo(TT);
            rp.SetParameterValue("TT", TongTien);
            rp.SetParameterValue("BC", BC);
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thanh lý Hợp đồng vận chuyển";
            frm.Show();
        }

    }
}
