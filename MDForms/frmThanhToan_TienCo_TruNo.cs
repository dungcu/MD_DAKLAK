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
using MDSolutionEntities;
using MDSolution;

namespace MDSolution
{
    public partial class frmThanhToan_TienCo_TruNo : Form
    {
        private NodeDonVi nDonVi = new NodeDonVi();
        private clsHopDong oHD = new clsHopDong();        
        public frmThanhToan_TienCo_TruNo()
        {
            InitializeComponent();
            //this.CreateGridEX2ThuaRuongColumn();                   
            
        }
        public frmThanhToan_TienCo_TruNo(string HopDongID)
        {
            InitializeComponent();                                 
            DoLoadHopDongInFo(HopDongID);
        }

        private void DoLoadDauTu_TruNo_ChiTiet(string strChuHopDongID)
        {
            try
            {
                DataSet ds;
                string strSQL = "SELECT * FROM namth_CacKhoanCo_ChiTiet_TruNo WHERE HopDongID=" + strChuHopDongID + " AND VuTrongID = " + DACASUCO_App.VuTrongID.ToString() + " ";
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

                long lTongDauTuPhaiTra = clsHopDong.GetTongTienDauTuConLai(long.Parse(strChuHopDongID), DACASUCO_App.VuTrongID, null, null);
                editBoxPhaiTra.Text = lTongDauTuPhaiTra.ToString("# ### ### ##0");
                long lTongTienKhoanCo = clsHopDong.GetTongCacKhoanTienCo(long.Parse(strChuHopDongID), DACASUCO_App.VuTrongID, null, null);
                editBoxThuduoc.Text = lTongTienKhoanCo.ToString("# ### ### ##0");
                long lLayve = lTongTienKhoanCo - lTongDauTuPhaiTra;
                editLayVe.Text = lLayve.ToString("# ### ### ##0");
            }
            catch
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
               


        private void uiTinhlaidautu_Click(object sender, EventArgs e)
        {

        }
        
        private void uibNhaptientrano_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmNhapTienTraNo frm = new frmNhapTienTraNo();
            //    frm.ChuHopDong = this.lblChuHopDong.Text;
            //    frm.ChuHopDongID = oHD.ID;
            //    frm.ShowDialog();
            //    if (frm.DialogResult == DialogResult.OK)
            //    {
            //        //this.DoLoadgdvChiTietThanhToan(oHD.ID.ToString());
            //    }
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }

        private void uibInThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.gdChoThanhToan.CurrentRow == null) throw new Exception("Chưa chọn HĐ ");
                frmShowRP2 frm = new frmShowRP2();
                rp_T_DS_PhieuThanhToanMia rp = new rp_T_DS_PhieuThanhToanMia();
                rp.RecordSelectionFormula = "{tbl_HopDong.ID}=" + this.oHD.ID.ToString();
                frm.RP = rp;
                frm.RPtitle = "Chi tiết hợp đồng";
                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.Show();
                //MessageBox.Show(this.gdChoThanhToan.GetValue("HopDongID").ToString());
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
            }
        }

        private void uibInPhieuChi_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.gdChoThanhToan.CurrentRow == null) throw new Exception("Chưa chọn HĐ ");
                frmShowRP2 frm = new frmShowRP2();
                rp_T_DS_PhieuThanhToanMia rp = new rp_T_DS_PhieuThanhToanMia();
                rp.RecordSelectionFormula = "{tbl_HopDong.ID}=" + this.oHD.ID.ToString();
                frm.RP = rp;
                frm.RPtitle = "Chi tiết hợp đồng";
                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.Show();
                //MessageBox.Show(this.gdChoThanhToan.GetValue("HopDongID").ToString());
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
            }
        }
                
        }

        
    }

