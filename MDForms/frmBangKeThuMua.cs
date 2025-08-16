using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using MDSolution;

namespace MDSolution
{
    public partial class frmBangKeThuMua : Form
    {
        double TT = 0;
        static frmBangKeThuMua _thefrmBangKeThuMua;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmBangKeThuMua OneInstanceFrm
        {
            get
            {
                if (null == _thefrmBangKeThuMua || _thefrmBangKeThuMua.IsDisposed)
                {
                   _thefrmBangKeThuMua = new frmBangKeThuMua();
                }

                return _thefrmBangKeThuMua;
            }
        }
      
        private string sql = "";
        public frmBangKeThuMua()
        {
            InitializeComponent();
          
        }

        private void frmBangKeThuMua_Load(object sender, EventArgs e)
        {
            int widthScreen = Screen.PrimaryScreen.WorkingArea.Width;
            int heightScreen = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = widthScreen;
            this.Height = heightScreen;
            this.WindowState = FormWindowState.Maximized;
            lblVT.Text = DACASUCO_App.TenVuTrong;            
            loadRoot();
            TinhTong();            
        }
     
     
        void ReloadGV(DataTable dtb)
        {
            
            dgvNhapMia.AutoGenerateColumns = false;
            dgvNhapMia.Columns["SoPhieuNhap"].DataPropertyName = "SoPhieuNhap";
            dgvNhapMia.Columns["HoTen"].DataPropertyName = "HoTen";
            dgvNhapMia.Columns["SoCMT"].DataPropertyName = "SoCMT";
            dgvNhapMia.Columns["NgayVanChuyen"].DataPropertyName = "NgayVanChuyen";
            dgvNhapMia.Columns["TrongLuongMiaSach"].DataPropertyName = "TrongLuongMiaSach";
            dgvNhapMia.Columns["TienMia"].DataPropertyName = "TienMia";
            dgvNhapMia.Columns["DonGiaMia"].DataPropertyName = "DonGiaMia";
            dgvNhapMia.Columns["DiaChi"].DataPropertyName = "DiaChi";
            if(dgvNhapMia.Rows.Count>0)
            dgvNhapMia.Rows.RemoveAt(0);
            dgvNhapMia.DataSource =dtb;
            dgvNhapMia.Show();
            TinhTong();
        }
        void TinhTong()
        {
            double ThanhTien = 0;
            double TLMiaSach = 0;
            long tong_xe = 0;
            double DGBQ = 0;
            double DonGia = 0;
            foreach (DataGridViewRow dr in dgvNhapMia.Rows)
            {
                double tlms = 0;
                try
                {
                    tlms += double.Parse(dr.Cells["TrongLuongMiaSach"].Value.ToString());
                }
                catch
                {
                tlms=0;
                }
                TLMiaSach += tlms;
                ThanhTien += double.Parse(dr.Cells["TienMia"].Value.ToString());
                DonGia += double.Parse(dr.Cells["DonGiaMia"].Value.ToString());
                try
                {
                    tong_xe++;
                }
                catch
                {
                    tong_xe=0;
                }
             }
            TT = ThanhTien;      
           if (tong_xe == 0)
           {
              DGBQ = 0;
           }
           else
           {
              DGBQ= Math.Round(DonGia / tong_xe, 2);
           }
            lblDGBQ.Text = DGBQ.ToString();
            lbThanhTien.Text = TT.ToString("# ### ### ##0");
            lbTLMiaSach.Text = TLMiaSach.ToString("# ### ### ##0");
            lbl_tongxe.Text = tong_xe.ToString();
           
        }
        void loadRoot()
        {
            DateTime dtTu = dtTuNgay.Value;
            DateTime dtDen = dtDenNgay.Value;
            string Tu = dtTu.ToString("yyyy-MM-dd 00:00:00");
            string Den = dtDen.ToString("yyyy-MM-dd 23:59:59");
                sql = "SELECT SoPhieuNhap,HoTen,SoCMT,DiaChi,NgayVanChuyen,TrongLuongMiaSach,DonGiaMia,TienMia FROM View_KetQuaCanNhapMiaNguyenLieuXe Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                sql += " And NgayVanChuyen >='" + Tu + "' AND NgayVanChuyen <='" + Den +"'";
                sql += " Order by SoPhieuNhap";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            ReloadGV(ds.Tables[0]);
        }
      
        private void cmdIn_Click(object sender, EventArgs e)
        {
            if (dgvNhapMia.Rows.Count > 0)
            {
                if (txt_sophieu.Text == "")
                {
                    MessageBox.Show("Tên người thu mua không được để trống!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_sophieu.Focus();
                    return;
                }
                frmShowRP2 frm = new frmShowRP2();
                DACASUCO.MDReport.rpt_BangKeMH rp = new DACASUCO.MDReport.rpt_BangKeMH();
                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                 DataTable dt = (DataTable)dgvNhapMia.DataSource;
                 //double TC = double.Parse(TT);

                 string TienChu = frmShowRP2.DocSo(TT);
                 //string TienChu = frmShowRP3.DocSo(TT);
                 rp.Database.Tables[0].SetDataSource(dt);
                   rp.SetParameterValue("TuNgay", dtTuNgay.Value.ToString("dd/MM/yyyy"));
                   rp.SetParameterValue("DenNgay", dtDenNgay.Value.ToString("dd/MM/yyyy"));
                   rp.SetParameterValue("TienBangChu", TienChu);
                   rp.SetParameterValue("HoTen", txt_sophieu.Text);
                   frm.RP = rp;
                   //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                   frm.RPtitle = "Kết quả thu mua mía ";
                   frm.Show();
            }
        }
      
        private void txt_sophieu_Enter(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            text.BackColor = Color.SkyBlue;
        }

        private void txt_sophieu_Leave(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            text.BackColor = Color.White;
        }

    
        private void txt_sophieu_Click(object sender, EventArgs e)
        {
            txt_sophieu.Text = "";
        }

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                dtTuNgay.Value = dtDenNgay.Value;
            }
            loadRoot();
           
        }

        private void dtDenNgay_ValueChanged(object sender, EventArgs e)
        {

            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                 dtDenNgay.Value=dtTuNgay.Value;
            }
            loadRoot();
           
        }
   
    }
}