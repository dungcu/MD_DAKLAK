using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace DACASUCO.MDForms
{
    public partial class frmSuaTTVC : Form
    {
       
        double ThuTienTC=0;
        int VAT = 0;
        double TienVC = 0;
        double TienVAT = 0;
        double TienTT = 0;
        int SoPhieu = 0;
        public frmSuaTTVC()
        {
            InitializeComponent();
        }
        public frmSuaTTVC(string SoPhieuTT)
        {
            InitializeComponent();
            SoPhieu = int.Parse(SoPhieuTT);
            string sql = "Select * from tbl_ThanhToanVC where SoPhieu=" + SoPhieuTT+" AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() ;
            DataSet ds=MDSolutionEntities.DBModule.ExecuteQuery(sql,null,null);
            if(ds.Tables[0].Rows.Count>0)
            {
                lblSP.Text=SoPhieuTT;
                txtSoXe.Text=ds.Tables[0].Rows[0]["SoXe"].ToString();
                clsHopDongVanChuyen oHDVC=new clsHopDongVanChuyen(long.Parse(ds.Tables[0].Rows[0]["HopDongVCID"].ToString()));
                oHDVC.Load(null,null);
                txtHDVC.Text=oHDVC.TenChuHopDong.ToString();
                try
                {
                    txtKHHD.Text = ds.Tables[0].Rows[0]["KHHD"].ToString();
                }
                catch
                {
                    txtKHHD.Text = "";
                }
                try
                {
                    cbLoaiHD.Text = ds.Tables[0].Rows[0]["LoaiHD"].ToString();
                }
                catch
                {
                    cbLoaiHD.Text = "Không VAT";
                }
                try
                {
                    txtMST.Text = ds.Tables[0].Rows[0]["MST"].ToString();
                }
                catch
                {
                    txtMST.Text = "";
                }

                try
                {
                    txtDV.Text = ds.Tables[0].Rows[0]["DVCC"].ToString();
                }
                catch
                {
                    txtDV.Text = "";
                }
                try
                {
                    txtDC.Text = ds.Tables[0].Rows[0]["DiaChi"].ToString();
                }
                catch
                {
                    txtDC.Text = "";
                }
                try
                {
                    txtSoHD.Text = ds.Tables[0].Rows[0]["SoHD"].ToString();
                }
                catch
                {
                    txtSoHD.Text = "";
                }
                try
                {
                    dtNgay.Value = DateTime.Parse(ds.Tables[0].Rows[0]["Ngay"].ToString());
                }
                catch
                {
                    dtNgay.Value = DateTime.Now;
                }
                try
                {
                    cbHTTT.Text = ds.Tables[0].Rows[0]["HTTT"].ToString();
                }
                catch
                {
                    cbHTTT.Text="Tiền mặt";
                }
                try
                {
                    VAT = int.Parse(ds.Tables[0].Rows[0]["VAT"].ToString());
                }
                catch
                {
                    VAT = 0;
                }
                try
                {
                    TienVAT = double.Parse(ds.Tables[0].Rows[0]["TienVAT"].ToString());
                }
                catch
                {
                    TienVAT = 0;
                }
                try
                {
                    ThuTienTC = double.Parse(ds.Tables[0].Rows[0]["ThuTienTC"].ToString());
                }
                catch
                {
                   ThuTienTC = 0;
                }
                try
                {
                    TienVC = double.Parse(ds.Tables[0].Rows[0]["TienVC"].ToString());
                }
                catch
                {
                    TienVC = 0;
                }
                try
                {
                   TienTT = double.Parse(ds.Tables[0].Rows[0]["SoTien"].ToString());
                }
                catch
                {
                    TienTT = 0;
                }
                txtTienVC.Text = TienVC.ToString("### ### ##0");
                txtVAT.Text = VAT.ToString();
                txtTienVAT.Text = TienVAT.ToString("### ### ##0");
                txtTC.Text = ThuTienTC.ToString("### ### ##0");
                txtTT.Text = TienTT.ToString("### ### ##0");
                LoadgdvChiTietvanchuyen(SoPhieuTT);
            }
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn cập nhật cho phiếu thanh toán "+SoPhieu.ToString()+"?", "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = "Update tbl_ThanhToanVC set SoHD=N'" + txtSoHD.Text + "',DVCC=N'" + txtDV.Text + "',Ngay=" + MDSolutionEntities.DBModule.RefineDatetime(dtNgay.Value) + ",LoaiHD=N'" + cbLoaiHD.Text + "',DiaChi=N'" + txtDC.Text
                    + "',MST=N'" + txtMST.Text.Trim() + "',HTTT=N'" + cbHTTT.Text + "',ThuTienTC=" + ThuTienTC.ToString() + ",SoTien=" + TienTT.ToString() + ",VAT=" + VAT.ToString() + ",TienVAT=" + TienVAT.ToString() +
                    ",KHHD=N'" + txtKHHD.Text + "',TienVC=" + TienVC.ToString()+",TienBangChu=N'"+frmShowRP3.DocSo(TienTT)+"' Where SoPhieu="+SoPhieu.ToString()+" AND VuTrongID="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    MessageBox.Show("Đã cập nhật thành công", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }

        private void LoadgdvChiTietvanchuyen(string SPTT)
        {
            try
            {

                string strSQL = "SELECT SoPhieuNhap,MiaQuaCan,DonGiaVanChuyen,TienVC FROM V_VanChuyenMia WHERE DaThanhToanVC ="+SPTT+" AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " Order by SoPhieuNhap ASC";
                DataSet DSXE = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                if (DSXE.Tables[0].Rows.Count > 0)
                {
                    int i = DSXE.Tables[0].Rows.Count;
                    this.gdvChitietvanchuyen.SetDataBinding(DSXE.Tables[0], "");

                }
                else
                {
                    gdvChitietvanchuyen.SetDataBinding(null, "");
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load danh sách vận chuyển mía", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtVAT_TextChanged(object sender, EventArgs e)
        {
            if (txtVAT.Text == "") txtVAT.Text = "0";
            VAT = int.Parse(txtVAT.Text);
            TienVAT = (long)(VAT * TienVC / 100);
            txtTienVAT.Text = TienVAT.ToString("### ### ##0");
            TienTT = TienVC + TienVAT -ThuTienTC;
            txtTT.Text = TienTT.ToString("### ### ##0");
        }

      
    }
}
