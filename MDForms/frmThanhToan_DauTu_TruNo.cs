    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using DACASUCO.MDForms;
using DACASUCO.MDReport;
using MDSolution;
using MDSolutionEntities;


namespace MDSolution
{
    public partial class frmThanhToan_DauTu_TruNo : Form
    {
        private NodeDonVi nDonVi = new NodeDonVi();
        private clsHopDong oHD = new clsHopDong();        
        public frmThanhToan_DauTu_TruNo()
        {
            InitializeComponent();
            //this.CreateGridEX2ThuaRuongColumn();                    
            
        }
        public frmThanhToan_DauTu_TruNo(string HopDongID)
        {
            InitializeComponent();                     
            
            DoLoadHopDongInFo(HopDongID);
        }

        private void DoLoadDauTu_TruNo_ChiTiet(string strChuHopDongID)
        {
            try
            {
                DataSet ds;
                string strSQL = "SELECT * FROM namth_DauTu_TruNo_ChiTiet WHERE HopDongID=" + strChuHopDongID + " AND VuTrongID = " + DACASUCO_App.VuTrongID.ToString() + " ";
                ds = DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables.Count > 0)
                {
                    this.gdVDauTu_TruNo_ChiTiet.SetDataBinding(ds.Tables[0], "");
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load danh sách đầu tư", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        public void DoLoadHopDongInFo(string strChuHopDongID)
        {
            try
            {
                this.oHD.ID = long.Parse(strChuHopDongID);
                this.oHD.Load(null, null);
                DateTime dtNgayTinhCongNo = clsHopDong.GetNgayTinhCongNo(oHD.ID, DACASUCO_App.VuTrongID, null, null);
                labelNgayTinhCongNo.Text = dtNgayTinhCongNo.ToString("dd/MM/yyyy");
                //Hien thi tinh trang cua hop dong
                string strtinhtrang = this.oHD.GetTinhTrangHopDongTrongVu(DACASUCO_App.VuTrongID, null, null);
                if(strtinhtrang[0]=='2')
                {
                    this.lblTinhTrangHopDongTrongVu.Text = "Đã thanh toán, đợt: " + strtinhtrang.Substring(2);
                }
                else if (strtinhtrang[0] == '1')
                {
                    this.lblTinhTrangHopDongTrongVu.Text = "Đang chờ thanh toán, đợt: " + strtinhtrang.Substring(2);
                }
                else {
                    this.lblTinhTrangHopDongTrongVu.Text = "Chưa xác định thanh toán";                    
                }
                //Ket thuc hien thi tinh trang
                this.lblChuHopDong.Text = oHD.MaHopDong + " - " + oHD.HoTen + " - " + oHD.SoCMT;
                this.DoLoadDauTu_TruNo_ChiTiet(strChuHopDongID);                
                GridEXRow gEXR = this.gdVDauTu_TruNo_ChiTiet.GetTotalRow();                
                //decimal  vTienphaitra = 0;
                //decimal vthanhtien = 0;
                //if(gEXR !=null && !string.IsNullOrEmpty(gEXR.Cells["TienPhaiTra"].Value.ToString()))
                //    vTienphaitra = (decimal)gEXR.Cells["TienPhaiTra"].Value;
                
                //if (gEXR1 != null && !string.IsNullOrEmpty(gEXR1.Cells["ThanhTien"].Value.ToString()))
                //    vthanhtien = (decimal)gEXR1.Cells["ThanhTien"].Value;
                //decimal vnhanve = vthanhtien - vTienphaitra;
                //editBoxPhaiTra.Text = vTienphaitra.ToString("### ### ##0");
                //editBoxThuduoc.Text = vthanhtien.ToString("### ### ##0");
                //editLayVe.Text =  vnhanve.ToString("### ### ##0");              

            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin của chủ hợp đồng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void uibTimKiem_Click(object sender, EventArgs e)
        //{
        //    dlgHopDong dlg = new dlgHopDong();            
        //    dlg.passID= new dlgHopDong.PassID(GetHopDongID);
        //    dlg.ShowDialog();
        //    if (dlg.DialogResult == DialogResult.OK)
        //    {
        //        //MessageBox.Show("OK"+oHD.ID.ToString());
        //        DoLoadHopDongInFo(oHD.ID.ToString());
        //        dlg.Dispose();
        //    }
        //    else {
        //        //MessageBox.Show("Cancel" + oHD.ID.ToString());
        //        dlg.Dispose();
        //    }
        //    ////
        //}
        
    }
}