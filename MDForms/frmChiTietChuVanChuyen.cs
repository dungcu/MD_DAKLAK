using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace MDSolution
{
    public partial class frmChiTietChuVanChuyen : Form
    {
        private DateTime NgayHopDong = DateTime.Now;
        // private long HopDongVanChuyenID = 200125;

        private DataSet dsHopDong;
        //private clsHopDong oHopDong = new clsHopDong();


        public frmChiTietChuVanChuyen()
        {
            InitializeComponent();
            //this.LoadHopDongvan();
        }
        public frmChiTietChuVanChuyen(long mID)
        {
            InitializeComponent();
            this.LoadHopDongVanChuyen(mID);

        }
        private void LoadHopDongVanChuyen(long mHDID)
        {
            try
            {
                LoadHDVC(mHDID);
                LoadXeVanChuyenByHopDongVanChuyenID(mHDID);
                LoadThongTinVanChuyenByHopDongVanChuyenID(mHDID);
                LoadThongTinTamUngByHopDongVanChuyenID(mHDID);
                LoadThongTinThanhToanByHopDongVanChuyenID(mHDID);
            }
            catch
            {

            }
        }
        private void LoadThongTinThanhToanByHopDongVanChuyenID(long mHDID)
        {
            DataSet dsThanhToanVC = clsThanhToanVanChuyen.GetListThanhToanVCByHopDongVanChuyenID( mHDID, "", null, null);
            if (dsThanhToanVC.Tables.Count > 0)
            {
                this.gdvThongtinthanhtoan.SetDataBinding(dsThanhToanVC.Tables[0], "");
            }
        }

        private void LoadThongTinTamUngByHopDongVanChuyenID(long mHDID)
        {
            //DataSet dsThongTinTamUng = clsUngVatTuVanChuyen.GetListThongTinTUByHopDongVanChuyenID(mHDID, "", null, null);
            //DataSet dsThongTinTamUng = clsUngVatTuVanChuyen.GetListbyWhere("","VuTrongID = "+ MDSolution.DACASUCO_App.VuTrongID +" AND HopDongVanChuyenID = "+ mHDID," NgayUng", null, null);
            DataSet dsThongTinTamUng = clsUngVatTuVanChuyen.GetListThongTinTUByHopDongVanChuyenID(MDSolution.DACASUCO_App.VuTrongID, mHDID, "", null, null);
            if (dsThongTinTamUng.Tables.Count > 0)
            {
                this.gdvThongtinTU.SetDataBinding(dsThongTinTamUng.Tables[0], "");
            }
        }

        private void LoadThongTinVanChuyenByHopDongVanChuyenID(long mHDID)
        {
            DataSet dsThongTinVanChuyen = clsNhapMia.GetListThongTinVCByHopDongID(MDSolution.DACASUCO_App.VuTrongID, mHDID, "", null, null);
            if (dsThongTinVanChuyen.Tables.Count > 0)
            {
                this.gdvThongtinVC.SetDataBinding(dsThongTinVanChuyen.Tables[0], "");
            }
        }

        private void LoadXeVanChuyenByHopDongVanChuyenID(long mHDID)
        {
            DataSet dsXeVanChuyen = clsXeVanChuyen.GetListXeVanChuyenByHopDongVanChuyenID( mHDID, "", null, null);
            if (dsXeVanChuyen.Tables.Count > 0)
            {
                this.gdvThongtinxeVC.SetDataBinding(dsXeVanChuyen.Tables[0], "");
            }
        }

        private void LoadHDVC(long mHDID)
        {
            clsHopDongVanChuyen oHDVC = new clsHopDongVanChuyen(mHDID);
            oHDVC.Load(null, null);
            this.lblTenChuHopDong.Text = oHDVC.TenChuHopDong;
            this.lblNgayHopDong.Text = oHDVC.NgayHopDong.ToString("dd/MM/yyyy");
            this.lblDienThoai.Text = oHDVC.DienThoai;
            this.lblDiaChi.Text = oHDVC.DiaChi;
            this.lblGhiChu.Text = oHDVC.GhiChu;
            this.lblMaHopDong.Text = oHDVC.MaHopDong;
        }

        private void uiTab1_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {

        }

        

        //private void frmChiTietChuVanChuyen_Load(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Maximized;
        //}


    }
}