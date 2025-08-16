using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DACASUCO.MDForms;
using DACASUCO.MDReport;
using DACASUCO.MDDanhMuc;
using DACASUCO.MDDataSetForms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.SCREventLog;
using CrystalDecisions.Shared;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using System.Threading;
using System.Reflection;
using System.Deployment;
using DACASUCO.MDReport.DakNongReport;
using DACASUCO.MDForms.ThanhToan;
using MDSolution;




namespace MDSolution
{
    public partial class DACASUCO_MAIN : Form
    {

        public static string strVuTrong = "";
        public static long VuTrongID = -1;
        private frmStatus statusF = new frmStatus();
        public DACASUCO_MAIN()
        {

            InitializeComponent();
        }

        void nWaiting()
        {
            statusF.Show();
        }
        void nWaited()
        {
            statusF.Close();
        }
        void Waiting()
        {
            this.toolStripStatusLabelLoading.Image = global::DACASUCO.Properties.Resources.loading;
            this.toolStripStatusLabelLoading.Text = "Loading...";
            for (long cnt = 1; cnt < 100; cnt++)
            {
                Thread.Sleep(10);
                Application.DoEvents();
            }
        }
        void Waited()
        {
            this.toolStripStatusLabelLoading.Image = global::DACASUCO.Properties.Resources.loaded;
            this.toolStripStatusLabelLoading.Text = "Ready";
            //picLoading.Visible = false;
        }

        private void cmdDauTu_Click(object sender, EventArgs e)
        {
            Waiting();
            frmQuanLyDauTuNoCu.OneInstanceFrm.MdiParent = this;
            frmQuanLyDauTuNoCu.OneInstanceFrm.Show();
            Waited();
        }

        private void cmdHoTro_Click(object sender, EventArgs e)
        {
            Waiting();
            frmQLVTHH frm = new frmQLVTHH();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            Waited();
        }

        private void cmdKetThuc_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MDIParent1_MdiChildActivate(object sender, EventArgs e)
        {

            if (this.ActiveMdiChild != null)
                this.panel1.Visible = false;
            else
                this.panel1.Visible = true;
        }


        private void mnuMayChu_Click(object sender, EventArgs e)
        {
            frmDataConnection frm = new frmDataConnection();
            frm.ShowDialog();
        }

        private void mnuHopDongMia_Click(object sender, EventArgs e)
        {
            this.Waiting();
            frmQuanLyHopDongTrongMia.OneInstanceFrm.MdiParent = this;
            //frmQuanLyHopDongTrongMia.OneInstanceFrm.
            frmQuanLyHopDongTrongMia.OneInstanceFrm.Show();
            this.Waited();
        }

        private void cmdHopDongMia_Click(object sender, EventArgs e)
        {
            Waiting();
            frmQuanLyHopDongTrongMia.OneInstanceFrm.MdiParent = this;
            frmQuanLyHopDongTrongMia.OneInstanceFrm.Show();
            Waited();
        }

        private void cmdDienTich_Click(object sender, EventArgs e)
        {
            Waiting();
            //frmDienTichCoCauTrong frm = new frmDienTichCoCauTrong();
            frmDienTichCoCauTrong.OneInstanceFrm.Load_DienTichDangKy = false;
            frmDienTichCoCauTrong.OneInstanceFrm.MdiParent = this;
            frmDienTichCoCauTrong.OneInstanceFrm.Show();
            Waited();

        }

        private void mnuDienTichTrong_Click(object sender, EventArgs e)
        {
            Waiting();
            frmDienTichCoCauTrong.OneInstanceFrm.Load_DienTichDangKy = false;
            frmDienTichCoCauTrong.OneInstanceFrm.MdiParent = this;
            frmDienTichCoCauTrong.OneInstanceFrm.Show();
            //DACASUCO.MDDataSetForms.QuanLyDienTichCoCauTrongV01 frm = new MDDataSetForms.QuanLyDienTichCoCauTrongV01();
            //frm.MdiParent = this;
            //frm.Show();   
            Waited();
        }

        private void mnuNhapDauTu_Click(object sender, EventArgs e)
        {
            Waiting();
            frmQuanLyDauTuNoCu.OneInstanceFrm.MdiParent = this;
            frmQuanLyDauTuNoCu.OneInstanceFrm.Show();
            Waited();
        }

        private void cmdThanhToanMia_Click(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDForms.ThanhToan.frmThanhToan2013 frm = new DACASUCO.MDForms.ThanhToan.frmThanhToan2013();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            Waited();
        }

        private void mnuThanhToanMia_Click(object sender, EventArgs e)
        {
            //Waiting();
            //frmThanhToanGoiY frm = new frmThanhToanGoiY();
            //frm.MdiParent = this;
            //frm.Show();
            //Waited();
        }

        private void mnuHopDongVanChuyen_Click(object sender, EventArgs e)
        {
            Waiting();
            frmHopDongVanChuyen.OneInstanceFrm.MdiParent = this;
            frmHopDongVanChuyen.OneInstanceFrm.Show();
            Waited();

        }

        private void cmdHopDongVanChuyen_Click(object sender, EventArgs e)
        {
            Waiting();
            frmHopDongVanChuyen.OneInstanceFrm.MdiParent = this;
            frmHopDongVanChuyen.OneInstanceFrm.Show();
            Waited();
        }

        private void cmdTamUngVanChuyen_Click(object sender, EventArgs e)
        {
            //Waiting();
            //frmQuanLyUngTienMia.OneInstanceFrm.MdiParent = this;
            //frmQuanLyUngTienMia.OneInstanceFrm.Show();
            //Waited();
        }

        private void mnuNhapHoTro_Click(object sender, EventArgs e)
        {
            //Waiting();
            //frmDanhSachCacKhoanHoTro.OneInstanceFrm.MdiParent = this;
            //frmDanhSachCacKhoanHoTro.OneInstanceFrm.Show();
            //Waited();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            lblVuTrong.Text = "NIÊN VỤ: " + DACASUCO_MAIN.strVuTrong.ToUpper();
            toolStripStatusLabelVuTrong.Text = "NIÊN VỤ: " + DACASUCO_MAIN.strVuTrong.ToUpper();
            this.tabKetQua.Hide();
            //clsUser oU = new clsUser();
            //oU.Load(          
            toolStripStatusLabelLogin.Text = "Người dùng: " + DACASUCO_App.User.HoTen;
            lblNguoiDung.Text = "Người dùng: " + DACASUCO_App.User.HoTen;
            this.toolStripStatusLabelNgayLamViec.Text = Application.ProductVersion; //DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

            toolStripStatusLabelDatabaseServer.Text = MDSolutionEntities.DBModule.ServerName + "/" + MDSolutionEntities.DBModule.DatabaseName;
            lblDatabaseServer.Text = MDSolutionEntities.DBModule.ServerName + "/" + MDSolutionEntities.DBModule.DatabaseName;

            //clsUser oU = new clsUser(DACASUCO_App.User.ID);
            //oU.Load(null, null);
            //if ((oU.RolesID == 0) || (oU.RolesID == 2))
            //{
            //    btUngVC.Enabled = true;
            //    btThanhToanVC.Enabled = true;
            //    mnuBangKeThuMua.Enabled = true;
            //    mnuBangKeCCS.Enabled = true;
            //    thiếtLậpThamSốThuHoạchVậnChuyểnToolStripMenuItem.Enabled = true;
            //}
            //if ((oU.RolesID == 3) || (oU.RolesID == 4) || (oU.RolesID == 5))
            //{
            //    MessageBox.Show("Bạn là nhân viên DACASUCO nhưng chưa được sử dụng phần mềm này", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    Application.Exit();
            //}
            //if (oU.RolesID != 0)
            //{
            //    thiếtLậpTỷLệMíaXơToolStripMenuItem.Enabled = false;
            //    tạpChấtBiểuKiếnToolStripMenuItem.Enabled = false;
            //    mnuUsers.Enabled = false;
            //    thiếtLậpGiáVàPhươngThứcThuMuaMíaCháyToolStripMenuItem.Enabled = false;
            //}
            ////if (oU.RolesID == 1)
            ////{
            ////    mnu_Thanhtoan.Enabled = false;
            ////    mnuBaoCao.Enabled = true;
            ////    mnu_VanChuyen.Enabled = false;
            ////    MNU_DienTich.Enabled = false;
            ////    MNU_DauTu.Enabled = false;
            ////    mnuUsers.Enabled = false;
            ////    mnuDanhMuc.Enabled = false;
            ////    mnuPhanQuyenTram.Enabled = false;
            ////    Menu_undo.Visible = false;
            ////    mnuTienIch.Enabled = true;
            ////    mnuHoTroTuXa.Enabled = true;
            ////    mnuDoiMatKhau.Enabled = true;
            ////    mnuThoat.Enabled = true;

            ////    mnuDanhMucDonVi.Enabled = false;
            ////    đơnVịCungỨngVậtTưToolStripMenuItem.Enabled = false;
            ////    mnuDanhMucLinhVucDauTu.Enabled = false;
            ////    mnuDanhMucBaiBocXep.Enabled = false;
            ////    nhậpGiáMíaToolStripMenuItem1.Enabled = false;
            ////    tưĐiênDanhMucToolStripMenuItem.Enabled = false;
            ////    mnuVuTrong.Enabled = false;
            ////    toolStripMenuItemDanhMucLoaiHopDong.Enabled = false;
            ////    nơiTạmỨngVậtTưVậnChuyểnToolStripMenuItem.Enabled = false;
            ////    thiếtLậpDanhMụcHàngHóaToolStripMenuItem.Enabled = false;
            ////    mnuTheoDoiCanHang.Enabled = false;

            ////    cmdDauTu.Enabled = false;
            ////    cmdHopDongMia.Enabled = false;
            ////    cmdDienTich.Enabled = false;
            ////    cmdCanHang.Enabled = false;
            ////    cmdTTVanChuyen.Enabled = false;
            ////    cmdHopDongVanChuyen.Enabled = false;
            ////    cmdThanhToanMia.Enabled = false;
            ////    cmdGiaMia.Enabled = false;
            ////    cmdQLSL.Enabled = false;

            ////    tạpChấtBiểuKiếnToolStripMenuItem.Enabled = false;
            ////}
            ////if (oU.RolesID == 6)
            ////{
            ////    mnu_Thanhtoan.Enabled = false;
            ////    mnuBaoCao.Enabled = true;
            ////    mnu_VanChuyen.Enabled = false;
            ////    MNU_DienTich.Enabled = false;
            ////    MNU_DauTu.Enabled = false;
            ////    mnuUsers.Enabled = false;
            ////    mnuDanhMuc.Enabled = false;
            ////    mnuPhanQuyenTram.Enabled = false;
            ////    Menu_undo.Visible = false;
            ////    mnuTienIch.Enabled = true;
            ////    mnuHoTroTuXa.Enabled = true;
            ////    mnuDoiMatKhau.Enabled = true;
            ////    mnuThoat.Enabled = true;

            ////    mnuDanhMucDonVi.Enabled = false;
            ////    đơnVịCungỨngVậtTưToolStripMenuItem.Enabled = false;
            ////    mnuDanhMucLinhVucDauTu.Enabled = false;
            ////    mnuDanhMucBaiBocXep.Enabled = false;
            ////    nhậpGiáMíaToolStripMenuItem1.Enabled = false;
            ////    tưĐiênDanhMucToolStripMenuItem.Enabled = false;
            ////    mnuVuTrong.Enabled = false;
            ////    toolStripMenuItemDanhMucLoaiHopDong.Enabled = false;
            ////    nơiTạmỨngVậtTưVậnChuyểnToolStripMenuItem.Enabled = false;
            ////    thiếtLậpDanhMụcHàngHóaToolStripMenuItem.Enabled = false;
            ////    mnuTheoDoiCanHang.Enabled = true;

            ////    cmdDauTu.Enabled = false;
            ////    cmdHopDongMia.Enabled = false;
            ////    cmdDienTich.Enabled = false;
            ////    cmdCanHang.Enabled = true;
            ////    cmdTTVanChuyen.Enabled = false;
            ////    cmdHopDongVanChuyen.Enabled = false;
            ////    cmdThanhToanMia.Enabled = false;
            ////    cmdGiaMia.Enabled = false;
            ////    cmdQLSL.Enabled = false;

            ////    mnuThanhToanVanChuyen.Enabled = false;
            ////    xemChiTiếtTạmỨngToolStripMenuItem.Enabled = false;
            ////    tạpChấtBiểuKiếnToolStripMenuItem.Enabled = false;
            ////    mnuChamSocMiaNguyenLieu.Enabled = false;
            ////    cmdChamSoc.Enabled = false;
            ////}
            //if (oU.RolesID == 7)
            //{
            //    //mnu_Thanhtoan.Enabled = false;
            //    //mnuBaoCao.Enabled = true;
            //    //mnu_VanChuyen.Enabled = false;
            //    //MNU_DienTich.Enabled = false;
            //    //MNU_DauTu.Enabled = true;
            //    //mnuUsers.Enabled = false;
            //    //mnuDanhMuc.Enabled = false;
            //    //mnuPhanQuyenTram.Enabled = false;
            //    //Menu_undo.Visible = false;
            //    //mnuTienIch.Enabled = true;
            //    //mnuHoTroTuXa.Enabled = true;
            //    //mnuDoiMatKhau.Enabled = true;
            //    //mnuThoat.Enabled = true;
            //    //mnuTheoDoiNhapMia.Enabled = true;

            //    //mnuDanhMucDonVi.Enabled = false;
            //    //đơnVịCungỨngVậtTưToolStripMenuItem.Enabled = false;
            //    //mnuDanhMucLinhVucDauTu.Enabled = false;
            //    //mnuDanhMucBaiBocXep.Enabled = false;
            //    //nhậpGiáMíaToolStripMenuItem1.Enabled = false;
            //    //tưĐiênDanhMucToolStripMenuItem.Enabled = false;
            //    //mnuVuTrong.Enabled = false;
            //    //toolStripMenuItemDanhMucLoaiHopDong.Enabled = false;
            //    //nơiTạmỨngVậtTưVậnChuyểnToolStripMenuItem.Enabled = false;
            //    //thiếtLậpDanhMụcHàngHóaToolStripMenuItem.Enabled = false;
            //    //mnuTheoDoiCanHang.Enabled = true;
            //    //mnuBangKeThuMua.Enabled = true;
            //    //mnuBangKeCCS.Enabled = true;

            //    //mnuQuanLyTheChap.Enabled = true;
            //    //mnuNhapDauTu.Enabled = false;
            //    //mnuTraCuuNoCu.Enabled = false;
            //    //mnKeHoachThuHoiNoDT.Enabled = true;
            //    ////mẫuBáoCáoĐakNôngToolStripMenuItem.Enabled = true;

            //    //cmdDauTu.Enabled = false;
            //    //cmdHopDongMia.Enabled = false;
            //    //cmdDienTich.Enabled = false;
            //    //cmdCanHang.Enabled = true;
            //    //cmdTTVanChuyen.Enabled = false;
            //    //cmdHopDongVanChuyen.Enabled = false;
            //    //cmdThanhToanMia.Enabled = false;
            //    //cmdGiaMia.Enabled = false;
            //    //cmdQLSL.Enabled = true;
            //    //cmdChamSoc.Enabled = false;
            //    //mnuLenhThuHoach.Enabled = false;
            //    //cmdLenhThuHoach.Enabled = false;
            //    //mnuChamSocMiaNguyenLieu.Enabled = false;

            //    //string RolAdd = DACASUCO_App.User.RolesAdd;
            //    //char DauTu = RolAdd[0];
            //    //char DienTich = RolAdd[1];
            //    //char NoCu = RolAdd[2];
            //    //char ThuHoach = RolAdd[3];
            //    if (DACASUCO_App.User.RolesID == 7)
            //    {
            //        //if (DauTu == '0')
            //        //{
            //        //    mnuNhapDauTu.Enabled = false;
            //        //    cmdDauTu.Enabled = false;
            //        //}
            //        //else
            //        //{
            //        //    mnuNhapDauTu.Enabled = true;
            //        //    cmdDauTu.Enabled = true;
            //        //}
            //        //if (DienTich == '0')
            //        //{
            //        //    cmdDienTich.Enabled = false;
            //        //    mnuDienTichTrong.Enabled = false;
            //        //}
            //        //else
            //        //{
            //        //    MNU_DienTich.Enabled = true;
            //        //    mnuHopDongMia.Enabled = false;
            //        //    mnuThietLapTinhTrangChoThuaRuong.Enabled = false;
            //        //    cmdDienTich.Enabled = true;
            //        //    mnuDienTichTrong.Enabled = true;
            //        //}
            //        //if (NoCu == '0')
            //        //{
            //        //    mnuTraCuuNoCu.Enabled = false;
            //        //}
            //        //else
            //        //{
            //        //    mnuTraCuuNoCu.Enabled = true;
            //        //}
            //        //if (ThuHoach == '0')
            //        //{
            //        //    mnuLenhThuHoach.Enabled = false;
            //        //    cmdLenhThuHoach.Enabled = false;
            //        //}
            //        //else
            //        //{
            //        //    mnuLenhThuHoach.Enabled = true;
            //        //    cmdLenhThuHoach.Enabled = false;
            //        //}
            //    }
            //}
            ////if (DACASUCO_App.User != null)
            ////{

            ////    if (DACASUCO_App.User.ID != 1)
            ////    {
            ////        clsComFunctions.checkControlsPermission(this, this.Name.ToString());                   
            ////    }
            ////    else
            ////    {
            ////        //qlmtToolStripMenuItem.Visible = true;
            ////    }
            ////    clsUser oUControl = new clsUser(DACASUCO_App.User.ID);
            ////    oUControl.Load(null, null);
            ////    string[] role = oUControl.Roles.Trim('&').Split('&');
            ////}

            // kiểm tra phân quyền
            if (DACASUCO_App.User.ID != 1)
            {
                clsComFunctions.checkControlsPermission(this, this.Name.ToString());
                //qlmtToolStripMenuItem.Visible = false;
            }
            else
            {
                //qlmtToolStripMenuItem.Visible = true;
            }
            clsUser oU = new clsUser(DACASUCO_App.User.ID);
            oU.Load(null, null);
            string[] role = oU.Roles.Trim('&').Split('&');




        }

        private void mnuDanhMucDonVi_Click(object sender, EventArgs e)
        {
            Waiting();
            //dlgDonVi frm = new dlgDonVi();
            //frm.MdiParent = this;
            //frm.Show();
            frmDanhMucDonVi frm = new frmDanhMucDonVi();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void mnuDanhMucBaiBocXep_Click(object sender, EventArgs e)
        {
            Waiting();
            frmBaiTapKet frm = new frmBaiTapKet();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            Waited();
        }

        private void mnuDanhMucKieuTrong_Click(object sender, EventArgs e)
        {
            Waiting();
            frmDanhMucKieuTrong frm = new frmDanhMucKieuTrong();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void mnuDanhMucLinhVucDauTu_Click(object sender, EventArgs e)
        {
            Waiting();
            frmDanhMucLinhVucDauTu frm = new frmDanhMucLinhVucDauTu();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void tưĐiênDanhMucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmDanhMucTuDien frm = new frmDanhMucTuDien();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void cmdBaoCao_Click(object sender, EventArgs e)
        {
            //frmTheoDoiThuHoach frm = new frmTheoDoiThuHoach();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void bangKêChiTiêtCacHĐĐaNhâpDiênTichToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void diênTichVaCơCâuGiôngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuDTTheoVuTrongVun_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoVuTrongVung rp = new BCDienTichTheoVuTrongVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo vụ trồng toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void sfsadfToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuDanhSachKhachHang_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_DSKH rp = new rp_DSKH();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            frm.ThonIDName = "{tbl_thon.id}";
            frm.XaIDName = "{tbl_Xa.id}";
            frm.VuTrongIDName = "{tbl_VuTrong.id}";
            frm.SecssionSuppress = 8;
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Danh sách khách hàng";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void mnuBCDienTichTrongMiaChiTietThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTrongMiaChiTietThon rp = new BCDienTichTrongMiaChiTietThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo chi tiết diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }


        private void mnuDienTichTheoCoCauDatThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauDatThon rp = new BCDienTichTheoCoCauDatThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo chi tiết diện tích trồng mía theo cơ cấu loại đất.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }



        private void mnuBCThuHoiVonDuNoTheoThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuThon rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuThon();
            frm.RP = rp;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = " Tổng hớp Đầu tư vốn - Thu hồi vốn - Dư nợ vốn văy trồng mía";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuBCThuHoiVonDuNoTheoXa_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuXa rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuXa();
            frm.RP = rp;
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thu hồi vốn dư nợ theo xã";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuBCThuHoiVonDuNoToanVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVung rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thu hồi vốn dư nợ toàn vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuThuHoiVonTheoGTDTVaNoThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuThon rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuThon();
            frm.RP = rp;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía theo thôn";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void toolStripSeparator13_Click(object sender, EventArgs e)
        {

        }

        private void mnuDuNoXa_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuXa rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuXa();
            frm.RP = rp;
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía theo xã";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void mnuDuNoVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuVung rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía toàn vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }





        private void mnuUsers_Click(object sender, EventArgs e)
        {
            Waiting();
            frmQuanLyUser frm = new frmQuanLyUser();
            frm.ShowDialog();
            Waited();
        }

        private void mnKhachVanChuyenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHopDongVanChuyen frm = new frmHopDongVanChuyen();
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDanhMucHopDong_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_DSKH rp = new rp_DSKH();
            frm.RP = rp;

            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Danh sách khách hàng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }


        private void mnuThanhToanVanChuyen_Click(object sender, EventArgs e)
        {
            Waiting();
            frmThanhToanVanChuyen.OneInstanceFrm.MdiParent = this;
            frmThanhToanVanChuyen.OneInstanceFrm.Show();
            Waited();
        }


        private void mnuThanhToanChuHDVanChuyen_Click(object sender, EventArgs e)
        {
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoThanhToanChuHopDongVanChuyen rp = new rp_BaoCaoThanhToanChuHopDongVanChuyen();
            rp.RecordSelectionFormula = "{View_BaoCaoTongHopChuHopDongVanChuyen.VuTrongID}=2 AND {View_BaoCaoTongHopChuHopDongVanChuyen.}";
            frm.RP = rp;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thanh toán chủ hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTienDoThuHoachMia_Click(object sender, EventArgs e)
        {
            frmShowRP2 frm = new frmShowRP2();
            rp_TienDoThuHoachMiaNguyenLieu rp = new rp_TienDoThuHoachMiaNguyenLieu();
            frm.RP = rp;

            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ thu hoạch mía";
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuKetKetQuaVCMia_Click(object sender, EventArgs e)
        {
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoKetQuaVanChuyenMiaToanVung rp = new rp_BaoCaoKetQuaVanChuyenMiaToanVung();
            //rp.RecordSelectionFormula = "{View_KetQuaVanChuyenMia.Ten}='vu 2008'";
            frm.RP = rp;

            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả vận chuyển mía";
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDTTheoVuTrongXa_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoVuTrongXa rp = new BCDienTichTheoVuTrongXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía theo vụ trồng.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDTTheoVuTrongThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoVuTrongThon rp = new BCDienTichTheoVuTrongThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích theo cơ cấu vụ trồng.";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void mnuDienTichTheoCoCauDatXa_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauDatXa rp = new BCDienTichTheoCoCauDatXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatXa.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía theo cơ cấu loại đất.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDienTichTheoCoCauDatVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoCoCauDatVung rp = new BCDienTichTheoCoCauDatVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatVung.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía theo cơ cấu loại đất toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void cmdThanhToanVanChuyen_Click(object sender, EventArgs e)
        {
            frmThanhToanVanChuyen frm = new frmThanhToanVanChuyen();
            frm.MdiParent = this;
            frm.Show();


            //Waiting();
            //frmDanhSachMuaVatTuCty.OneInstanceFrm.MdiParent = this;
            //frmDanhSachMuaVatTuCty.OneInstanceFrm.Show();
            //Waited();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmThuHoach frm = new frmThuHoach();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmShowRP2 frm = new frmShowRP2();

            rp_DSKH rp = new rp_DSKH();
            //
            rp.SetParameterValue("XaID", 25);

            frm.RP = rp;

            frm.RPtitle = "Diện tích theo cơ cấu đất của toàn vùng";
            // rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);

            frm.MdiParent = this;
            frm.Show();
        }

        private void mnQuanLyPhiKhauHao_Click(object sender, EventArgs e)
        {
            frmQuanLyKhauHao frm = new frmQuanLyKhauHao();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnTimKiemHopDong_Click(object sender, EventArgs e)
        {
            //frmTimKiemHopDong frm = new frmTimKiemHopDong();
            // frm.MdiParent = this;
            //frm.Show();
            Waiting();
            frmTimKiemHopDong.OneInstanceFrm.MdiParent = this;
            frmTimKiemHopDong.OneInstanceFrm.Show();
            Waited();

        }


        private void mnTimKiemXeVanChuyen_Click(object sender, EventArgs e)
        {

            Waiting();
            frmTimKiemXeVanChuyen frm = new frmTimKiemXeVanChuyen();
            //frmTimKiemXeVanChuyen.OneInstanceFrm.Show();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            Waited();


        }

        private void mnuDienTichTheoTieuChuan_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoTieuChuan rp = new BCDienTichTheoTieuChuan();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatVung.VuTrongID}";
            frm.DienTichToiThieu = "{View_BCDienTichTheoCoCauDatVung.DienTich}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía theo xã";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDienTichTheoCoCauDatTongHop_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauDatTongHop rp = new BCDienTichTheoCoCauDatTongHop();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo cơ cấu loại đất.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuTongHopDienTichTrongMiaXa_Click_1(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTrongMiaChiTietThonXa rp = new BCDienTichTrongMiaChiTietThonXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuTongHopDienTichTrongMiaVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTrongMiaTongHopVung rp = new BCDienTichTrongMiaTongHopVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo chi ti?t di?n tích tr?ng mía theo co c?u lo?i d?t.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDTTheoCoCauGiongThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauGiongThon rp = new BCDienTichTheoCoCauGiongThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo cơ cấu giống.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDTTheoCoCauGiongXa_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauGiongXaMoi rp = new BCDienTichTheoCoCauGiongXaMoi();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo cơ cấu giống xã.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDTTheoCoCauGiongVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoCoCauGiongVung rp = new BCDienTichTheoCoCauGiongVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo cơ cấu giống.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void vToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_ThanhToanChuHopDongVanChuyenVung rp = new rp_ThanhToanChuHopDongVanChuyenVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_ThanhToanChuHopDongVanChuyen.IDVuTrong}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thanh toán chủ hợp đồng vận chuyển vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }



        private void vùngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoKetQuaVanChuyenMiaToanVung rp = new rp_BaoCaoKetQuaVanChuyenMiaToanVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_VanChuyenMiaVung.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả vận chuyển mía vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void mnuKetQuaVCTheoThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_BaoCaoTamUngCuaChuHopDongVanChuyen rp = new rp_BaoCaoTamUngCuaChuHopDongVanChuyen();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_UngVatTuChuHopDong.IDVuTrong}";
            frm.HopDongVC_ID_Name = "{View_UngVatTuChuHopDong.HopDongVanChuyenID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tạm ứng chủ hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();


        }

        private void mnuKetQuaVCTheoXa_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoTamUngVanChuyenVuMia rp = new rp_BaoCaoTamUngVanChuyenVuMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_UngVatTuChuHopDong.IDVuTrong}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tạm ứng vận chuyển toàn vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();


        }


        private void mnuNhapMiaQuaCan_Click(object sender, EventArgs e)
        {
            //frmNhapMia frm = new frmNhapMia();
            ////frm.MdiParent = this;
            //frm.ShowDialog();
        }

        private void tưĐiênDanhMucToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDanhMucTuDien frm = new frmDanhMucTuDien();
            frm.MdiParent = this;
            frm.Show();
        }




        private void xemChiTiếtTạmỨngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Waiting();
            frmUngVatTuVanChuyen frm = new frmUngVatTuVanChuyen();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void kếtQủaThuHoạchMíaNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe rp = new rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_KetQuaVanChuyenMiaNgay.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả vận chuyển mía nguyên liệu";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void đâuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kếtQuảCânNhậpMíaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cânNhậpNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Waiting();
            //frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            //rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe rp = new rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe();
            //frm.RP = rp;


            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe rp = new rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe();

            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_KetQuaCanNhapMiaNguyenLieuXe.VuTrongID}";
            //frm.ThonIDName = "{View_KetQuaCanNhapMiaNguyenLieuXe.ThonID}";
            //frm.NgayLocName = "{View_KetQuaCanNhapMiaNguyenLieuXe.NgayVanChuyen}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả vận chuyển mía Chủ hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void cânNhậpVùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rpt_KetQuaCanNhapMiaNguyenLieu rp = new rpt_KetQuaCanNhapMiaNguyenLieu();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_ThuHoachMiaNguyenLieu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả cân nhập mía vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }



        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void cmdTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiemHopDong frm = new frmTimKiemHopDong();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTongHopDienTichTrongMiaVung_Click_1(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTrongMiaTongHopVungMoi rp = new BCDienTichTrongMiaTongHopVungMoi();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía toàn vùng.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void mnuDienTichTheoTieuChuan_Click_1(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoTieuChuan rp = new BCDienTichTheoTieuChuan();
            frm.RP = rp;
            frm.DienTichToiThieu = "co";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatVung.VuTrongID}";
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo diện tích theo tiêu chuẩn.";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void mnuDienTichTheoCoCauDatTongHop_Click_1(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauDatTongHop rp = new BCDienTichTheoCoCauDatTongHop();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích theo cơ cấu đất.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }



        private void mnuHuongDan_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("huongdansudung.pdf");
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void mnuDanhMucHoTroKhongTuongUngDauTu_Click(object sender, EventArgs e)
        {
            frmDanhMucHoTro frm = new frmDanhMucHoTro();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuVuTrong_Click(object sender, EventArgs e)
        {
            frmVuTrong frm = new frmVuTrong();
            frm.ShowDialog();
        }

        private void MenuTongHopDuNoDauTu_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCTongHopThuHoiDuNoDauTuMia rp = new BCTongHopThuHoiDuNoDauTuMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BCThuHoiDuNoDauTu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp thu hồi dư nợ đầu tư mía.";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void MenuCacHoNoDauTu_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDSCacHoNoDauTu rp = new BCDSCacHoNoDauTu();
            frm.RP = rp;
            frm.XaIDName = "{View_BCThuHoiDuNoDauTu.XaID}";
            frm.VuTrongIDName = "{View_BCThuHoiDuNoDauTu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void MenuTongHopDauTuVaThuHoi_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCTongHopDauTuVaThuHoiVung rp = new BCTongHopDauTuVaThuHoiVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp đầu tư và thu hồi theo lĩnh vực đầu tư toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }


        private void MenuSoChiTietDauTu_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_SoChiTietDauTu rp = new rp_T_SoChiTietDauTu();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            frm.ThonIDName = "{View_T_SoChiTietDauTu.ThonID}";
            frm.XaIDName = "{View_T_SoChiTietDauTu.XaID}";
            frm.VuTrongIDName = "{View_T_SoChiTietDauTu.VuTrongID}";
            frm.SecssionSuppress = 8;
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Sổ chi tiết đầu tư.";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void MenuSoInChiTietDienTich_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCSoInChiTietDienTichTrongMia rp = new BCSoInChiTietDienTichTrongMia();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Sổ in chi tiết diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }




        private void mnuTheoDoiThuHoach_Click(object sender, EventArgs e)
        {
            //frmTheoDoiThuHoach frm = new frmTheoDoiThuHoach();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void mnuLenhThuHoach_Click(object sender, EventArgs e)
        {
            Waiting();
            frmThuHoach frm = new frmThuHoach();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void cmdTroGiup_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("HuongdanSudungSD.chm");
        }

        private void MenuDSCacHoDauTuVuotDinhMuc_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDSCacHoDauTuVuotDinhMuc rp = new BCDSCacHoDauTuVuotDinhMuc();
            frm.RP = rp;
            frm.DinhMucToiThieu = "Co";
            //frm.DinhMucToiThieu = "co";
            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Danh sách các hộ đầu tư vượt định mức.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void mnuThuHoiVonDuNoChiTietToanVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuVungChiTiet rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuVungChiTiet();
            frm.RP = rp;
            frm.DonViEnable = 1;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void mnuThuHoiVonChiTietToanVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVungChiTiet rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVungChiTiet();
            frm.RP = rp;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.DonViEnable = 1;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = " Tổng hớp Đầu tư vốn - Thu hồi vốn - Dư nợ vốn văy trồng mía";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }



        private void tônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoTongHopNhapMia rp = new rp_BaoCaoTongHopNhapMia();
            frm.RP = rp;
            frm.ParameterOn = 1;

            frm.VuTrongIDName = "{View_TongHopNhapMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp nhập mía toàn vụ";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }



        private void bảngKêTổngHợpSảnLượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Waiting();
            //frmShowRP2 frm = new frmShowRP2();
            //rp_BaoCaoTongHopSanLuong rp = new rp_BaoCaoTongHopSanLuong();
            //frm.RP = rp;
            //frm.ParameterOn = 1;
            ////frm.DinhMucToiThieu = "co";
            //frm.VuTrongIDName = "{View_BangKeTongHopSanLuong.VuTrongID}";
            ////rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //frm.RPtitle = "Bảng Kê tổng hợp sản lượng";
            //frm.MdiParent = this;
            //frm.Show();
            //Waited();



            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoTongHopSanLuong rp = new rp_BaoCaoTongHopSanLuong();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BangKeTongHopSanLuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Bảng Kê tổng hợp sản lượng";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void tongHopNhapMiaToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //Waiting();
            //frmShowRP2 frm = new frmShowRP2();
            //rp_BaoCaoTongHopNhapMia rp = new rp_BaoCaoTongHopNhapMia();
            //frm.ParameterOn = 1;
            //frm.RP = rp;
            //frm.VuTrongIDName = "{View_TongHopNhapMia.VuTrongID}";
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //frm.RPtitle = "Tổng hợp nhập mía";
            //frm.MdiParent = this;
            //frm.Show();
            //Waited();

            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_BaoCaoTongHopNhapMia rp = new rp_BaoCaoTongHopNhapMia();
            frm.ParameterOn = 1;
            frm.RP = rp;
            frm.ThonIDName = "{View_TongHopNhapMia.ThonID}";
            frm.VuTrongIDName = "{View_TongHopNhapMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp nhập mía";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }



        private void phânQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhanQuyen_Cum frm = new frmPhanQuyen_Cum();
            frm.ShowDialog();
        }

        private void mnuThietLapTinhTrangChoThuaRuong_Click(object sender, EventArgs e)
        {


            Waiting();
            frmThietLapTinhTrangThuaRuong frm = new frmThietLapTinhTrangThuaRuong();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            Waited();
            
            
            ////frmThietLapTinhTrangThuaRuong frm = new frmThietLapTinhTrangThuaRuong();
            ////frm.ShowDialog();
            //Waiting();
            //frmThietLapTinhTrangThuaRuong.OneInstanceFrm.MdiParent = this;
            //frmThietLapTinhTrangThuaRuong.OneInstanceFrm.Show();
            //Waited();
        }

        private void quảnLýThanhToánTiềnMíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmThanhToan2013 frm = new frmThanhToan2013();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            Waited();
        }

        private void dTTrồngMíaChiTiếtthônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTrongMiaChiTietThon rp = new BCDienTichTrongMiaChiTietThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo chi tiết diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void tổngHợpDTTrồngMíaxãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTrongMiaTongHopXa rp = new BCDienTichTrongMiaTongHopXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void tổngHợpDTTrồngMíavùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTrongMiaTongHopVung rp = new BCDienTichTrongMiaTongHopVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía toàn vùng.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void dTTheoCơCấuĐấtthônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauDatThon rp = new BCDienTichTheoCoCauDatThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo chi tiết diện tích trồng mía theo cơ cấu loại đất.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoCơCấuĐấtxãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauDatXa rp = new BCDienTichTheoCoCauDatXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatXa.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía theo cơ cấu loại đất.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoCơCấuĐấtvùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoCoCauDatVung rp = new BCDienTichTheoCoCauDatVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatVung.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía theo cơ cấu loại đất toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoTiêuChuẩnvùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoTieuChuan rp = new BCDienTichTheoTieuChuan();
            frm.RP = rp;
            frm.DienTichToiThieu = "co";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatVung.VuTrongID}";
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo diện tích theo tiêu chuẩn.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void tổngHợpTheoCơCấuĐâtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauDatTongHop rp = new BCDienTichTheoCoCauDatTongHop();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích theo cơ cấu đất.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void dTTheoCơCấuGiốngthônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauGiongThon rp = new BCDienTichTheoCoCauGiongThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo cơ cấu giống.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoCơCấuGiốngxãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauGiongXa rp = new BCDienTichTheoCoCauGiongXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo cơ cấu giống.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoCơCấuGiốngvùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoCoCauGiongVung rp = new BCDienTichTheoCoCauGiongVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo cơ cấu giống.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoVụTrồngthônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoVuTrongThon rp = new BCDienTichTheoVuTrongThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích theo cơ cấu vụ trồng.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoVụTrồngxãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoVuTrongXa rp = new BCDienTichTheoVuTrongXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía theo vụ trồng.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoVụTrồngvùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoVuTrongVung rp = new BCDienTichTheoVuTrongVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo vụ trồng toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void sổInChiTiếtDiệnTíchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCSoInChiTietDienTichTrongMia rp = new BCSoInChiTietDienTichTrongMia();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Sổ in chi tiết diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void sổChiTiếtĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_SoChiTietDauTu rp = new rp_T_SoChiTietDauTu();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            frm.SecssionSuppress = 8;
            frm.ThonIDName = "{View_T_SoChiTietDauTu.ThonID}";
            frm.XaIDName = "{View_T_SoChiTietDauTu.XaID}";
            frm.VuTrongIDName = "{View_T_SoChiTietDauTu.VuTrongID}";

            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Sổ chi tiết đầu tư.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void dSCácHộĐầuTưVượtĐịnhMứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDSCacHoDauTuVuotDinhMuc rp = new BCDSCacHoDauTuVuotDinhMuc();
            frm.RP = rp;
            //frm.DinhMucToiThieu = "co";
            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            frm.DinhMucToiThieu = "co";
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Danh sách các hộ đầu tư vượt định mức.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }


        private void tổngHợpDưNợĐầuTưToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCTongHopThuHoiDuNoDauTuMia rp = new BCTongHopThuHoiDuNoDauTuMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BCThuHoiDuNoDauTu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp thu hồi dư nợ đầu tư mía.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void cácHộNợĐầuTưToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDSCacHoNoDauTu rp = new BCDSCacHoNoDauTu();
            frm.RP = rp;
            frm.XaIDName = "{View_BCThuHoiDuNoDauTu.XaID}";
            frm.VuTrongIDName = "{View_BCThuHoiDuNoDauTu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void tổngHợpĐầuTưVàThuHồiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCTongHopDauTuVaThuHoiVung rp = new BCTongHopDauTuVaThuHoiVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp đầu tư và thu hồi theo lĩnh vực đầu tư toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }


        private void theoThônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuThon rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuThon();
            frm.RP = rp;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = " Tổng hớp Đầu tư vốn - Thu hồi vốn - Dư nợ vốn văy trồng mía";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void theoXãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuXa rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuXa();
            frm.RP = rp;
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thu hồi vốn dư nợ theo xã";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void theoVùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVung rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thu hồi vốn dư nợ toàn vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void chiTiếtToànVùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVungChiTiet rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVungChiTiet();
            frm.RP = rp;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.DonViEnable = 1;
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = " Tổng hớp Đầu tư vốn - Thu hồi vốn - Dư nợ vốn văy trồng mía";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void theoThônToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuThon rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuThon();
            frm.RP = rp;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía theo thôn";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void theoXãToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuXa rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuXa();
            frm.RP = rp;
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía theo xã";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void toànVùngToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuVung rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía toàn vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void chiTiếtToànVùngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuVungChiTiet rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuVungChiTiet();
            frm.RP = rp;
            frm.DonViEnable = 1;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";

            frm.ParameterOn = 1;//rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }


        private void cânNhậpNgàyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe rp = new rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_KetQuaCanNhapMiaNguyenLieuXe.VuTrongID}";
            frm.NgayLocName = "{View_KetQuaCanNhapMiaNguyenLieuXe.NgayVanChuyen}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả vận chuyển mía Chủ hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void cânNhậpVùngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rpt_KetQuaCanNhapMiaNguyenLieu rp = new rpt_KetQuaCanNhapMiaNguyenLieu();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_ThuHoachMiaNguyenLieu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả cân nhập mía vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void tổngHợpNhậpMíaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoTongHopNhapMia rp = new rp_BaoCaoTongHopNhapMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_TongHopNhapMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp nhập mía";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }






        private void toànVùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoThanhToanChuHopDongVanChuyenVung rp = new rp_BaoCaoThanhToanChuHopDongVanChuyenVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BaoCaoTongHopChuHopDongVanChuyen.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thanh toán chủ hợp đồng vận chuyển vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void toànVùngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoKetQuaVanChuyenMiaToanVung rp = new rp_BaoCaoKetQuaVanChuyenMiaToanVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_VanChuyenMiaVung.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả vận chuyển mía vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void chủHợpĐồngToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_BaoCaoTamUngCuaChuHopDongVanChuyen rp = new rp_BaoCaoTamUngCuaChuHopDongVanChuyen();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_UngVatTuChuHopDong.IDVuTrong}";
            frm.HopDongVC_ID_Name = "{View_UngVatTuChuHopDong.HopDongVanChuyenID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tạm ứng chủ hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void toànVùngToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoTamUngVanChuyenVuMia rp = new rp_BaoCaoTamUngVanChuyenVuMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_UngVatTuChuHopDong.IDVuTrong}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tạm ứng vận chuyển toàn vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }




        private void danhMucKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_DSKH rp = new rp_DSKH();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            frm.SecssionSuppress = 8;
            frm.ThonIDName = "{tbl_thon.id}";
            frm.XaIDName = "{tbl_Xa.id}";
            frm.VuTrongIDName = "{tbl_VuTrong.id}";

            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Danh sách khách hàng";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void mnuMayTinhCaNhan_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
            //System.Diagnostics.Process.Start("osk.exe");
        }

        private void mnuUniKey_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("UniKey\\UniKeyNT.exe");
        }

        private void nhậpGiáMíaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmNhapGiaMia frm = new frmNhapGiaMia();
            frm_Gia_Mia_Theo_Tram_Nong_Vu frm = new frm_Gia_Mia_Theo_Tram_Nong_Vu();
            frm.ShowDialog();
        }

        private void chiTiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Waiting();
            MDSolution.frmQuanLyMiaNhap.OneInstanceFrm.MdiParent = this;
            MDSolution.frmQuanLyMiaNhap.OneInstanceFrm.Show();
            Waited();
            //frm.ShowDialog();
        }





        private void mnuVonDauTuTheoLoaiHinhDauTu_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_TongHopDauTuCacXaTheoLinhVucDT rp = new rp_T_TongHopDauTuCacXaTheoLinhVucDT();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            //frm.ThonIDName = "{tbl_thon.id}";
            frm.XaIDName = "{tbl_Xa.id}";
            frm.VuTrongIDName = "{tbl_VuTrong.id}";
            //frm.SecssionSuppress = 8;
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp đầu tư theo loại hình";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }


        int iKetQuaTimHD;
        int iKetQuaTimHDVC;

        void OpenKetQua()
        {
            groupBox4.Height = 248;
           // btKetQua.Visible = true;
        }
        void CloseKetQua()
        {

            groupBox4.Height = 70;
            //btKetQua.Visible = false;

        }
        void TimKiem()
        {
            if (tbTimKiem.Text.ToString().Trim().Length > 0)
            {
                TimKiemHopDong();
                TimKiemHopDongVC();
            }
            else
            {
                GVHopDong.DataSource = null;
                tab_HopDong.Text = "Hợp đồng(0)";
                GVHopDongVC.DataSource = null;
                tab_HopDongVC.Text = "Hợp đồng VC(0)";
            }

        }
        void TimKiemHopDong()
        {
            GVHopDong.AutoGenerateColumns = false;
            try
            {
                string str = "SELECT * FROM tbl_HopDong WHERE 1=1 ";
                string Sql_order = "";
                //if (rdMa.Checked == true)
                //{
                //    str += " AND MaHopDong like N'%" + MDSolutionEntities.DBModule.RefineString(tbTimKiem.Text) + "%'";
                //    Sql_order = " Order by MaHopDong";
                //}
                //else
                //{
                str += " AND  dbo.BoDauTiengViet(HoTen) like N'%" + MDSolutionEntities.DBModule.RefineString(tbTimKiem.Text) + "%'";
                Sql_order = " Order by HoTen";
                //}

                str = str + Sql_order;
                DataSet dr = MDSolutionEntities.DBModule.ExecuteQuery(str, null, null);
                if (dr.Tables[0] != null)
                {
                    GVHopDong.DataSource = dr.Tables[0];
                    GVHopDong.Show();
                    tab_HopDong.Text = "Hợp Đồng(" + dr.Tables[0].Rows.Count + ")";
                    iKetQuaTimHD = dr.Tables[0].Rows.Count;
                }
            }
            catch { }

        }
        void TimKiemHopDongVC()
        {
            GVHopDongVC.AutoGenerateColumns = false;
            try
            {
                string str = "SELECT * FROM tbl_HopDongVanChuyen WHERE 1=1 ";
                string Sql_order = "";
                //if (rdMa.Checked == true)
                //{
                //    str += " AND MaHopDong like N'%" + MDSolutionEntities.DBModule.RefineString(tbTimKiem.Text) + "%'";
                //    Sql_order = " Order by MaHopDong";
                //}
                //else
                //{
                str += " AND  dbo.BoDauTiengViet(TenChuHopDong) like N'%" + MDSolutionEntities.DBModule.RefineString(tbTimKiem.Text) + "%'";
                Sql_order = " Order by TenChuHopDong";
                //}
                str = str + Sql_order;
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(str, null, null);
                if (ds.Tables[0] != null)
                {

                    GVHopDongVC.DataSource = ds.Tables[0];
                    GVHopDongVC.Show();
                    tab_HopDongVC.Text = "Hợp Đồng VC(" + ds.Tables[0].Rows.Count + ")";
                    iKetQuaTimHDVC = ds.Tables[0].Rows.Count;
                }
            }
            catch { }
        }

        private void rdMa_CheckedChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void btThongTinNN_Click(object sender, EventArgs e)
        {
            try
            {
                tbTimKiem.Text = "";
                this.GVHopDong.DataSource = null;
                this.GVHopDongVC.DataSource = null;
                tab_HopDong.Text = "Hợp Đồng(0)";
                tab_HopDongVC.Text = "Hợp Đồng VC(0)";
                this.tabKetQua.Hide();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.GVHopDong.SelectedRows[0].ToString()))
                {
                    string s = this.GVHopDong.SelectedRows[0].Cells["ID"].Value.ToString();
                    long oID = long.Parse(s);
                    frmViewHopDong aa = new frmViewHopDong(oID);
                    //aa.uiTab1.SelectedIndex = 1;
                    aa.MdiParent = this.MdiParent;
                    aa.Show();
                }
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.GVHopDong.SelectedRows[0].ToString()))
                {
                    string s = this.GVHopDong.SelectedRows[0].Cells["ID"].Value.ToString();
                    long oID = long.Parse(s);
                    frmViewHopDong aa = new frmViewHopDong(oID);
                   // aa.TabTimKiem.SelectedIndex = 2;
                    aa.MdiParent = this.MdiParent;
                    aa.Show();
                }
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.GVHopDong.SelectedRows[0].ToString()))
                {
                    string s = this.GVHopDong.SelectedRows[0].Cells["ID"].Value.ToString();
                    long oID = long.Parse(s);
                    frmViewHopDong aa = new frmViewHopDong(oID);
                    //aa.TabTimKiem.SelectedIndex = 1;
                    aa.MdiParent = this.MdiParent;
                    aa.Show();
                }
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }

        }

        private void GVHopDong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.GVHopDong.SelectedRows[0].ToString()))
                {
                    string s = this.GVHopDong.SelectedRows[0].Cells["ID"].Value.ToString();
                    long oID = long.Parse(s);
                    frmViewHopDong aa = new frmViewHopDong(oID);

                    aa.MdiParent = this.MdiParent;
                    aa.Show();
                }
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void btUngVC_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = GVHopDongVC.SelectedRows[0].Cells["IDVC"].Value.ToString();
                frmUngVatTuVanChuyen frm = new frmUngVatTuVanChuyen(ID);
                frm.tvHopDongVanChuyen.SelectedNode = frm.tvHopDongVanChuyen.Nodes["Root"].Nodes[ID];
                frm.uiPanel0.AutoHide = true;
                frm.tvHopDongVanChuyen.Enabled = false;
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void btThanhToanVC_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = GVHopDongVC.SelectedRows[0].Cells["IDVC"].Value.ToString();

                //frmThanhToanVanChuyen frm = new frmThanhToanVanChuyen(ID);
                //frm.treeDonVi.SelectedNode = frm.treeDonVi.Nodes["Root"].Nodes[ID];
                //frm.treeDonVi.Enabled = false;
                //frm.uiPanel0.AutoHide = true;
                //frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void GVHopDongVC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string ID = GVHopDongVC.SelectedRows[0].Cells["IDVC"].Value.ToString();
                frmChiTietChuVanChuyen frm = new frmChiTietChuVanChuyen(long.Parse(ID));

                frm.Show();

            }
            catch { MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết"); }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            tbTimKiem.Text = "";
            this.GVHopDong.DataSource = null;
            this.GVHopDongVC.DataSource = null;
            tab_HopDong.Text = "Hợp Đồng(0)";
            tab_HopDongVC.Text = "Hợp Đồng VC(0)";
            this.tabKetQua.Hide();
        }

        private void ngânHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    DACASUCO.MDDataSetForms.frmNganHang frm = new DACASUCO.MDDataSetForms.frmNganHang();
            //    frm.ShowDialog();
        }


        private void hợpĐồngVậnChuyểnVDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDDataSetForms.frmHopDongVanChuyen frm = new DACASUCO.MDDataSetForms.frmHopDongVanChuyen();
            frm.ShowDialog();
        }


        private void tổngHợpDiệnTíchTrồngMíaHuyệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.THOP frm = new DACASUCO.MDReport.FRM_Report.THOP();
            frm.Show();
        }

        private void đơnVịCungỨngVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDDataSetForms.frmDonViCungUngVT frm = new DACASUCO.MDDataSetForms.frmDonViCungUngVT();
            frm.ShowDialog();
        }


        private void cmdTrongLai_Click_1(object sender, EventArgs e)
        {
            frmTHTTVanChuyen frm = new frmTHTTVanChuyen();           
            frm.MdiParent = this;
            frm.Show();
        }

        private void cmdTrongMoi_Click_1(object sender, EventArgs e)
        {
            DACASUCO.MDDataSetForms.DangKyDauTu frm = new DACASUCO.MDDataSetForms.DangKyDauTu();
            frm.ShowDialog();
        }

        private void insertMenuItem()
        {
            foreach (ToolStripItem mitem in mnuHeThong.DropDownItems)
            {
                try
                {
                    string strSQL = "insert into sys_Chucnang(Tenhienthi,Tenmenu) values(N'" + mitem.Text + "','" + mitem.Name + "')";
                    MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                catch { }
            }
            foreach (ToolStripItem mitem in MNU_DienTich.DropDownItems)
            {
                try
                {
                    string strSQL = "insert into sys_Chucnang(Tenhienthi,Tenmenu) values(N'" + mitem.Text + "','" + mitem.Name + "')";
                    MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                catch { }
            }
            foreach (ToolStripItem mitem in MNU_DauTu.DropDownItems)
            {
                try
                {
                    string strSQL = "insert into sys_Chucnang(Tenhienthi,Tenmenu) values(N'" + mitem.Text + "','" + mitem.Name + "')";
                    MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                catch { }
            }
            foreach (ToolStripItem mitem in MNU_DuLieu.DropDownItems)
            {
                try
                {
                    string strSQL = "insert into sys_Chucnang(Tenhienthi,Tenmenu) values(N'" + mitem.Text + "','" + mitem.Name + "')";
                    MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                catch { }
            }
            foreach (ToolStripItem mitem in mnu_Thanhtoan.DropDownItems)
            {
                try
                {
                    string strSQL = "insert into sys_Chucnang(Tenhienthi,Tenmenu) values(N'" + mitem.Text + "','" + mitem.Name + "')";
                    MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                catch { }
            }
            foreach (ToolStripItem mitem in mnu_VanChuyen.DropDownItems)
            {
                try
                {
                    string strSQL = "insert into sys_Chucnang(Tenhienthi,Tenmenu) values(N'" + mitem.Text + "','" + mitem.Name + "')";
                    MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                catch { }
            }
        }

        private void caaToolStripMenuItem_Click(object sender, EventArgs e)
        {


            string strSQL = "delete from sys_Chucnang";
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);

            //this.Loadmenu();
            insertMenuItem();
            MessageBox.Show("Bạn đã cập nhật lại tên menu thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.TongHopNguyenLieu frm = new DACASUCO.MDReport.FRM_Report.TongHopNguyenLieu();
            frm.Show();

        }

        private void tổngHợpVềĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.BieuTongHopGiongMia frm = new DACASUCO.MDReport.FRM_Report.BieuTongHopGiongMia();
            frm.Show();
        }


        private void vancToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void biểuInĐốiChiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đốiChiếuHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Waiting();
            //frmShowRP2 frm = new frmShowRP2();
            //VietDai_KiemTraHop rp = new VietDai_KiemTraHop();
            //frm.RP = rp;
            //frm.ParameterOn = 1;
            //frm.VuTrongIDName = "{View_VietDai-DienTichNghiemThuTheBanDieuTra.VuTrongID}";
            //// frm.DotThanhToanName = "{View_MoiUngDauVanChuyenMoi.DotThanhToan}";
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //frm.RPtitle = "Kiểm tra hợp đồng nhập vào hệ thống";
            //frm.MdiParent = this;
            //frm.Show();
            //Waited();
        }

        private void nhậpNợCũChủHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapNoCuChuHopDong frm = new frmNhapNoCuChuHopDong();
            frm.ShowDialog();
        }

        private void đốiChiếuTrạmXãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Waiting();
            //frmShowRP2 frm = new frmShowRP2();
            //VietDai_DanhMucMaXaTramHuyen rp = new VietDai_DanhMucMaXaTramHuyen();
            //frm.RP = rp;
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //frm.RPtitle = "Kiểm tra danh muc xa tram huyen";
            //frm.MdiParent = this;
            //frm.Show();
            //Waited();

        }

        private void đốiChiếuNợCũToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            NoCuChuHopDong rp = new NoCuChuHopDong();
            frm.RP = rp;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kiểm tra danh muc xa tram huyen";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void nợCũChủHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmDanhSachCacKhoanNoCu.OneInstanceFrm.MdiParent = this;
            frmDanhSachCacKhoanNoCu.OneInstanceFrm.Show();
            Waited();
        }

        private void cmdChamSoc_Click_1(object sender, EventArgs e)
        {
            Waiting();
            frmQL_ChamSoc frm = new frmQL_ChamSoc();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void tổngHợpĐầuTưToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDReport.FRM_Report.TongHopDauTu frm = new DACASUCO.MDReport.FRM_Report.TongHopDauTu();
            frm.Show();
            Waited();
        }

        private void đầuTưTheoĐợtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDReport.FRM_Report.TongHopDauTuTheoDot frm = new DACASUCO.MDReport.FRM_Report.TongHopDauTuTheoDot();
            frm.Show();
            Waited();
        }

        private void nhậpTiềnMặtTrảNợCôngTyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Waiting();
            //frmQuanLyTienTraNo.OneInstanceFrm.MdiParent = this;
            //frmQuanLyTienTraNo.OneInstanceFrm.Show();
            //Waited();
        }

        private void ngàyChốtTínhLãiĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Waiting();
            //frmNgayChotTinhLai frm = new frmNgayChotTinhLai();
            //frm.ShowDialog();
            //Waited();
        }

        private void tạmỨngTiềnMíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Waiting();
            //frmQuanLyUngTienMia.OneInstanceFrm.MdiParent = this;
            //frmQuanLyUngTienMia.OneInstanceFrm.Show();
            //Waited();
        }

        private void muaVậtTưCủaCôngTyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Waiting();
            //frmDanhSachMuaVatTuCty.OneInstanceFrm.MdiParent = this;
            //frmDanhSachMuaVatTuCty.OneInstanceFrm.Show();
            //Waited();

        }

        private void biểuTổngHợpDiệnTíchTrồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.THOP frm = new DACASUCO.MDReport.FRM_Report.THOP();
            frm.Show();
        }

        private void biểuTổngHợpNguyênLiệuVàMíaGiốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.TongHopNguyenLieu frm = new DACASUCO.MDReport.FRM_Report.TongHopNguyenLieu();
            frm.Show();

        }

        private void biểuTổngHợpTheoCơCấuGiốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.BieuTongHopGiongMia frm = new DACASUCO.MDReport.FRM_Report.BieuTongHopGiongMia();
            frm.Show();
        }

        private void biểuTổngHợpĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tổngHợpDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDReport.FRM_Report.TongHopDauTu frm = new DACASUCO.MDReport.FRM_Report.TongHopDauTu();
            frm.Show();
            Waited();
        }

        private void chiTiếtĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDReport.FRM_Report.ChiTietDauTuTungTram frm = new DACASUCO.MDReport.FRM_Report.ChiTietDauTuTungTram();
            frm.Show();
            Waited();
        }

        private void đầuTưTheoĐợtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDReport.FRM_Report.TongHopDauTuTheoDot frm = new DACASUCO.MDReport.FRM_Report.TongHopDauTuTheoDot();
            frm.Show();
            Waited();
        }

        private void xeVậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.DoiChieuXeVanChuyen frm = new DACASUCO.MDReport.FRM_Report.DoiChieuXeVanChuyen();
            frm.Show();
        }

        private void chủHợpĐồngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.DoiChieuChuHopDong frm = new DACASUCO.MDReport.FRM_Report.DoiChieuChuHopDong();
            frm.Show();
        }

        private void mẫuQuyếtToánNhàCânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.BieuTongHopVanChuyenNgay frm = new DACASUCO.MDReport.FRM_Report.BieuTongHopVanChuyenNgay();
            frm.Show();

        }

        private void mẫuKiểuTraSốLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.BieuDoiChieuNhaCan frm = new DACASUCO.MDReport.FRM_Report.BieuDoiChieuNhaCan();
            frm.Show();
        }

        private void đơnVịĐầuTưGiánTiếpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.TongHopDauTuGianTiep frm = new DACASUCO.MDReport.FRM_Report.TongHopDauTuGianTiep();
            frm.Show();
        }

        private void nợCũHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            NoCuTheoVuTrong rp = new NoCuTheoVuTrong();
            frm.RP = rp;
            //frm.ParameterOn = 1;
            //frm.VuTrongIDName = "{View_MoiTienDoThuHoachMia.VuTrongID}";
            // frm.DotThanhToanName = "{View_MoiUngDauVanChuyenMoi.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kiểm tra hợp đồng nhập vào hệ thống";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void biểuChínhSáchGiốngMíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.BieuTongHopTheoGiongMia frm = new DACASUCO.MDReport.FRM_Report.BieuTongHopTheoGiongMia();
            frm.Show();

        }

        private void tổngHợpThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.BieuTongHopThanhToan frm = new DACASUCO.MDReport.FRM_Report.BieuTongHopThanhToan();
            frm.Show();

        }

        private void thanhToaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.BieuTongHopThanhToanTheoDot frm = new DACASUCO.MDReport.FRM_Report.BieuTongHopThanhToanTheoDot();
            frm.Show();

        }

        private void biểuTổngHợpPhếCanhChặtGiốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.BieuTongHopPheCanhChatGiong frm = new DACASUCO.MDReport.FRM_Report.BieuTongHopPheCanhChatGiong();
            frm.Show();
        }

        private void đốiChiếuHợpĐồngĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    Waiting();
            //    frmShowRP2 frm = new frmShowRP2();
            //    VietDai_KiemTraHopDanhKy rp = new VietDai_KiemTraHopDanhKy();
            //    frm.RP = rp;
            //    frm.ParameterOn = 1;
            //    frm.VuTrongIDName = "{View_VietDai-DienTichNghiemThuTheBanDieuTra.VuTrongID}";
            //    // frm.DotThanhToanName = "{View_MoiUngDauVanChuyenMoi.DotThanhToan}";
            //    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //    frm.RPtitle = "Kiểm tra hợp đồng đăng ký nhập vào hệ thống";
            //    frm.MdiParent = this;
            //    frm.Show();
            //    Waited();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.TongHopThanhToan frm = new DACASUCO.MDReport.FRM_Report.TongHopThanhToan();
            frm.Show();

        }



        private void biểuTổngHợpDiêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.BieuTongHopDienTichNguyenLieuMotTram frm = new DACASUCO.MDReport.FRM_Report.BieuTongHopDienTichNguyenLieuMotTram();
            frm.Show();
        }

        private void biểu3QuyếtToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.BieuDoiChieuNhaCanBieu3 frm = new DACASUCO.MDReport.FRM_Report.BieuDoiChieuNhaCanBieu3();
            frm.Show();

        }



        private void biểuChămSócTổngHợpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đônĐốcChămSócToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.ChamSocDonDoc frm = new DACASUCO.MDReport.FRM_Report.ChamSocDonDoc();
            frm.Show();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.ChamSoc frm = new DACASUCO.MDReport.FRM_Report.ChamSoc();
            frm.Show();

        }

        private void biểuXemNhậpMíaNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.CanMiaNgay frm = new DACASUCO.MDReport.FRM_Report.CanMiaNgay();
            frm.Show();

        }

        private void traCứuNợCũToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapNoCuChuHopDong frm = new frmNhapNoCuChuHopDong();
            frm.ShowDialog();
        }

        private void tổngHợpThanhToánToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.BieuTongHopThanhToan frm = new DACASUCO.MDReport.FRM_Report.BieuTongHopThanhToan();
            frm.Show();
        }

        private void thanhToánTheoĐợtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.BieuTongHopThanhToanTheoDot frm = new DACASUCO.MDReport.FRM_Report.BieuTongHopThanhToanTheoDot();
            frm.Show();
        }

        private void chuyểnVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChuyenVu frm = new frmChuyenVu();
            frm.ShowDialog();
        }

        private void nơiTạmỨngVậtTưVậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_NoiUngVatTu frm = new Frm_NoiUngVatTu();
            frm.ShowDialog();
        }

        private void chuyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DACASUCO.MDDataSetForms.frmHopDongChuyenVu frm = new DACASUCO.MDDataSetForms.frmHopDongChuyenVu();
            frm.ShowDialog();
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Support\\TeamViewerQS_vi-ckq.exe");
            }
            catch { }
        }

        private void mnuThongTin_Click(object sender, EventArgs e)
        {
            //frmAbout frm = new frmAbout();
            //frm.ShowDialog();
        }

        private void saoLưuDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "INNO_MDSolution_" + DateTime.Now.ToString("yyyy_MM_dd_hhmmss_tt") + ".BAK";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Waiting();
                try
                {

                    string strSQL = "BACKUP DATABASE " + MDSolutionEntities.DBModule.DatabaseName + " TO DISK = '" + saveFileDialog1.FileName.ToString() + "' WITH COMPRESSION";
                    MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                    MessageBox.Show("Sao lưu dữ liệu thành công!", "BACKUP COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Có lỗi khi thực hiện", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Waited();
            }
            else
                return;
        }



        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("huongdansudung.pdf");
            }
            catch { }

        }



        private void toolStripMenuItemDanhMucLoaiHopDong_Click(object sender, EventArgs e)
        {
            DACASUCO.MDDataSetForms.DanhMucLoaiHopDong frm = new DACASUCO.MDDataSetForms.DanhMucLoaiHopDong();
            frm.ShowDialog();
        }

        private void mnuChamSocMiaNguyenLieu_Click(object sender, EventArgs e)
        {
            Waiting();
            frmQL_ChamSoc frm = new frmQL_ChamSoc();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void gánĐịaBànChoXeVậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiabanVC frm = new frmDiabanVC();
            frm.ShowDialog();
        }

        private void thiếtLậpTỷLệMíaXơToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXoMia frm = new frmXoMia();
            frm.ShowDialog();
        }

        private void quảnLýTàiSảnThếChấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmQuanLyTaiSanTheChap frm = new frmQuanLyTaiSanTheChap();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            Waited();
        }

        private void cmdQLTSTC_Click(object sender, EventArgs e)
        {
            this.Waiting();
            frmNangSuatSanLuong.OneInstanceFrm.MdiParent = this;
            frmNangSuatSanLuong.OneInstanceFrm.Show();
            this.Waited();
        }

        private void cmdGiaMia_Click(object sender, EventArgs e)
        {
            frm_Gia_Mia_Theo_Tram_Nong_Vu frm = new frm_Gia_Mia_Theo_Tram_Nong_Vu();
            frm.ShowDialog();

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDReport.FRM_Report.ChiTietDauTuTungCBDB frm = new DACASUCO.MDReport.FRM_Report.ChiTietDauTuTungCBDB();
            frm.Show();
            Waited();
        }

        private void mnKeHoachThuHoiNoDT_Click(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDForms.ThanhToan.frmThanhToan_DuToanThu frm = new DACASUCO.MDForms.ThanhToan.frmThanhToan_DuToanThu();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            Waited();
        }

        private void diệnTíchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowRP2 frm = new frmShowRP2();
            DACASUCO.MDReport.TestDienTich rp = new DACASUCO.MDReport.TestDienTich();

            // rp.RecordSelectionFormula = "{TestdienTich.Tram}";// +" AND {View_ChiTietDauTu.VuTrongID}=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            frm.RP = rp;

            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //frm.RPtitle = "Báo cáo chi tiết Tài sản thế chấp";
            frm.Show();

        }

        private void danhMụcHĐĐTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowRP2 frm = new frmShowRP2();
            DACASUCO.MDReport.TestHDDT rp = new DACASUCO.MDReport.TestHDDT();

            // rp.RecordSelectionFormula = "{TestdienTich.Tram}";// +" AND {View_ChiTietDauTu.VuTrongID}=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            frm.RP = rp;

            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //frm.RPtitle = "Báo cáo chi tiết Tài sản thế chấp";
            frm.Show();
        }

        private void tbTimKiem_Click(object sender, EventArgs e)
        {
            tbTimKiem.Text = "";
        }

        private void tổngHợpĐầuTưTheoNàyThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDReport.FRM_Report.TongHopDauTuTheoNgayThang frm = new DACASUCO.MDReport.FRM_Report.TongHopDauTuTheoNgayThang();
            frm.Show();
            Waited();
        }

        private void bảngTínhLãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDForms.ThanhToan.frm_ThanhToan2013_BangTinhLaiCongNoDauTu frm = new DACASUCO.MDForms.ThanhToan.frm_ThanhToan2013_BangTinhLaiCongNoDauTu();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            Waited();
        }

        private void tiềnThếChânXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_BaoCaoTheChan rp = new rp_BaoCaoTheChan();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_UngVatTuChuHopDong.IDVuTrong}";
            frm.HopDongVC_ID_Name = "{View_UngVatTuChuHopDong.HopDongVanChuyenID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiền thế chân hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void tiềnThếChấpCápToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rpt_BaoCaoTheChapCap rp = new rpt_BaoCaoTheChapCap();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_UngVatTuChuHopDong_TCC.IDVuTrong}";
            frm.HopDongVC_ID_Name = "{View_UngVatTuChuHopDong_TCC.HopDongVanChuyenID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiền thế chấp cáp vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void tổngHợpThanhToánVậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTHTTVanChuyen frm = new frmTHTTVanChuyen();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            Waited();
        }

        private void thiếtLậpDanhMụcHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DMVTHH frm = new frm_DMVTHH();
            frm.Show();
        }

        private void tạpChấtBiểuKiếnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoTroTapChat frm = new HoTroTapChat();
            frm.ShowDialog();
        }

        private void theoDõiCânHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLVTHH frm = new frmQLVTHH();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            Waited();
        }

        private void cmdTim_Click(object sender, EventArgs e)
        {
            iKetQuaTimHD = 0;
            iKetQuaTimHDVC = 0;
            TimKiem();
            if (iKetQuaTimHDVC + iKetQuaTimHD > 0)
            {
                OpenKetQua();
                this.tabKetQua.Show();
            }
            else
            {
                MessageBox.Show("Không thấy hợp đồng bạn tìm", "Kiểm tra thông tin");
                CloseKetQua();
            }
        }

        private void tbTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                iKetQuaTimHD = 0;
                iKetQuaTimHDVC = 0;
                TimKiem();
                if (iKetQuaTimHDVC + iKetQuaTimHD > 0)
                {
                    OpenKetQua();
                    this.tabKetQua.Show();
                }
                else
                {
                    CloseKetQua();
                }
            }
        }

        private void thiếtLậpGiáVàPhươngThứcThuMuaMíaCháyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQCMC frm = new frmQCMC();
            frm.ShowDialog();
        }

        private void bảngKêThuMuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmBangKeThuMua.OneInstanceFrm.MdiParent = this;
            frmBangKeThuMua.OneInstanceFrm.Show();
            Waited();
        }

        private void bảngKêCCSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmBangKeCCS.OneInstanceFrm.MdiParent = this;
            frmBangKeCCS.OneInstanceFrm.Show();
            Waited();
        }

        private void tổngHợpĐầuTưTheoDanhMụcĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDReport.FRM_Report.TongHopDauTuTheoDMDT frm = new DACASUCO.MDReport.FRM_Report.TongHopDauTuTheoDMDT();
            frm.Show();
            Waited();
        }

        private void tooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.TongHopCongNoVanChuyenMia frm = new DACASUCO.MDReport.FRM_Report.TongHopCongNoVanChuyenMia();
            frm.Show();
        }

        private void bảngTổngHợpThuTiềnMặtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDForms.ThanhToan.RPT_BangTongHopThuBangTM frm = new DACASUCO.MDForms.ThanhToan.RPT_BangTongHopThuBangTM();
            frm.ShowDialog();
            Waited();
        }

        private void bảngTổngHợpThanhToánTiênMíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDForms.ThanhToan.RPT_TongHopCongNo frm = new DACASUCO.MDForms.ThanhToan.RPT_TongHopCongNo();
            frm.ShowDialog();
            Waited();
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDForms.ThanhToan.RPT_TongHopCongNoConThieuKeHoach frm = new DACASUCO.MDForms.ThanhToan.RPT_TongHopCongNoConThieuKeHoach();
            frm.ShowDialog();
            Waited();
        }

        private void tổngHợpThanhToánTiềnMíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDForms.ThanhToan.RPT_TongHopThanhToanTienMia frm = new DACASUCO.MDForms.ThanhToan.RPT_TongHopThanhToanTienMia();
            frm.ShowDialog();
            Waited();
        }

        private void bảngKêCôngNợVậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmBangKeCNVC.OneInstanceFrm.MdiParent = this;
            frmBangKeCNVC.OneInstanceFrm.Show();
            Waited();
        }

        private void bảngKêNhậpMíaTheoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Waiting();
            frmQL_NhapMiaTheoNgay.OneInstanceFrm.MdiParent = this;
            frmQL_NhapMiaTheoNgay.OneInstanceFrm.Show();
            Waited();
        }

        private void biểuTổngHợpCôngNợSảnLượngMíaĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            RPT_TongHopCongNoSanLuongMiaDauTu frm = new RPT_TongHopCongNoSanLuongMiaDauTu();
            frm.ShowDialog();
            Waited();
        }

        private void tổngHợpCNSLMíaMuaNgoàiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            RPT_TongHopCongNoSanLuongMiaMuaNgoai frm = new RPT_TongHopCongNoSanLuongMiaMuaNgoai();
            frm.ShowDialog();
            Waited();
        }

        private void sổChiTiếtCNThuMuaMíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            RPT_SoChiTietCongNoThuMuaMia frm = new RPT_SoChiTietCongNoThuMuaMia();
            frm.ShowDialog();
            Waited();
        }

        private void tổngHợpGiáMíaGiáVậnChuyểnBìnhQuânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            RPT_BinhQuanGia frm = new RPT_BinhQuanGia();
            frm.ShowDialog();
            Waited();
        }

        private void chiTiếtCôngNợVậnChuyểnMíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            ChiTietCongNoVanChuyenMia frm = new ChiTietCongNoVanChuyenMia();
            frm.ShowDialog();
            Waited();
        }

        private void lậpKếHoạchThuNợĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsVuTrong oVT = new clsVuTrong(MDSolution.DACASUCO_App.VuTrongID);
            oVT.Load(null, null);
            Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "@VuTrongID", "TenVu" };
            string[] paraValues = new string[] { MDSolution.DACASUCO_App.VuTrongID.ToString(), oVT.Ten };

            CommonClass.ShowReport("RPDakNong\\RPT_LapKeHoachThuNoDauTu.rpt", "Lập kế hoạch thu nợ đầu tư", paramNames, paraValues, null);
        }

        private void bảngKêMãCânTrongNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Waiting();
            MDSolution.frmQuanLyMiaNhap.OneInstanceFrm.MdiParent = this;
            MDSolution.frmQuanLyMiaNhap.OneInstanceFrm.Show();
            Waited();
        }

        private void tổngHợpCNThuMuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPT_TongHopCongNoThuMua frm = new RPT_TongHopCongNoThuMua();
            frm.ShowDialog();
            Waited();
        }

        private void tổngHợpThuNợBằngTiềnMặtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            DACASUCO.MDForms.ThanhToan.RPT_BangTongHopThuBangTM frm = new DACASUCO.MDForms.ThanhToan.RPT_BangTongHopThuBangTM();
            frm.ShowDialog();
            Waited();
        }

        private void chiTiếtVậnChuyểnMíaĐãCóThuếToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            RPT_SoChiTietVanChuyenMiaDaCoThue frm = new RPT_SoChiTietVanChuyenMiaDaCoThue();
            frm.ShowDialog();
            Waited();
        }

        private void thuTiềnThếChânToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_BaoCaoTheChan rp = new rp_BaoCaoTheChan();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_UngVatTuChuHopDong.IDVuTrong}";
            frm.HopDongVC_ID_Name = "{View_UngVatTuChuHopDong.HopDongVanChuyenID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiền thế chân hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void cápVậnChuyểnChủHĐVCToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rpt_BaoCaoTheChapCap rp = new rpt_BaoCaoTheChapCap();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_UngVatTuChuHopDong_TCC.IDVuTrong}";
            frm.HopDongVC_ID_Name = "{View_UngVatTuChuHopDong_TCC.HopDongVanChuyenID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiền thế chấp cáp vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void tổngHợpCôngNợVậnChuyểnMíaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DACASUCO.MDReport.FRM_Report.TongHopCongNoVanChuyenMia frm = new DACASUCO.MDReport.FRM_Report.TongHopCongNoVanChuyenMia();
            frm.Show();
        }

        private void thiếtLậpThamSốThuHoạchVậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQCTH frm = new frmQCTH();
            frm.ShowDialog();
        }

        private void chuyểnXePhiếuCânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChuyenXe frm = new frmChuyenXe();
            frm.ShowDialog();
        }

        private void theoCBĐBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.frmBC_THSL_CBDB f = new DACASUCO.MDReport.FRM_Report.frmBC_THSL_CBDB();
            f.ShowDialog();
        }

        private void theoTrạmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.frmBC_THSL_Tram f = new DACASUCO.MDReport.FRM_Report.frmBC_THSL_Tram();
            f.ShowDialog();
        }

        private void theoBếnMíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DACASUCO.MDReport.FRM_Report.frmBC_THSL_Ben f = new DACASUCO.MDReport.FRM_Report.frmBC_THSL_Ben();
            f.ShowDialog();
        }

        private void hooToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trừVậnChuyểnTheoTạpChấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_NhapTB_GiaVC frm = new frm_NhapTB_GiaVC();
            frm.ShowDialog();
        }

        private void mnuTamUngVanChuyen_Click(object sender, EventArgs e)
        {

        }

        private void nToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void biểuTổngHợpThanhToánToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frm_RP_TheoDoi_NS_SL frm = new frm_RP_TheoDoi_NS_SL();
            frm.MdiParent = this;
            frm.Show();
            //this.Waiting();
            //frm_TraCuuTongHop.OneInstanceFrm.MdiParent = this;
            //frm_TraCuuTongHop.OneInstanceFrm.Show();
            //this.Waited();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //this.Waiting();

            frm_TongHop_NhapMia.OneInstanceFrm.MdiParent = this;
            frm_TongHop_NhapMia.OneInstanceFrm.Show();

            //frm_TongHop_NhapMia frm = new frm_TongHop_NhapMia();
            //frm.MdiParent = this;            
            //frm.Show();


            //frm_TongHop_NhapMia.OneInstanceFrm.MdiParent = this;
            //frm_TongHop_NhapMia.OneInstanceFrm.Show();
            //this.Waited();
        }

        private void mnuDanhSachXe_Click(object sender, EventArgs e)
        {
            Waiting();
            frmHopDongVanChuyen.OneInstanceFrm.MdiParent = this;
            frmHopDongVanChuyen.OneInstanceFrm.Show();
            Waited();
        }

        private void mnuTongTTVC_Click(object sender, EventArgs e)
        {
            frmTHTTVanChuyen frm = new frmTHTTVanChuyen();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            Waited();
        }

        private void mnuCongNoVanChuyen_Click(object sender, EventArgs e)
        {

            frmBangKeCNVC frm = new frmBangKeCNVC();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            Waited();
        }

        private void mnuDuBaoNangSuatSanLuong_Click(object sender, EventArgs e)
        {

            frm_RP_TheoDoi_NS_SL frm = new frm_RP_TheoDoi_NS_SL();
            frm.MdiParent = this;
            frm.Show();


            //Waiting();
            //frm_TraCuuTongHop.OneInstanceFrm.MdiParent = this;
            //frm_TraCuuTongHop.OneInstanceFrm.Show();
            //Waited();
        }

        private void mnuThuMua_Click(object sender, EventArgs e)
        {
            frm_TongHop_NhapMia.OneInstanceFrm.MdiParent = this;
            frm_TongHop_NhapMia.OneInstanceFrm.Show();
        }

        private void mnuNangSuatSanLuong_Click(object sender, EventArgs e)
        {
            this.Waiting();
            frmNangSuatSanLuong.OneInstanceFrm.MdiParent = this;
            frmNangSuatSanLuong.OneInstanceFrm.Show();
            this.Waited();
        }

        private void mnuCongNoDauTuThanhToan_Click(object sender, EventArgs e)
        {
            this.Waiting();
            frm_TongHop_TheoDoi_CongNo.OneInstanceFrm.MdiParent = this;
            frm_TongHop_TheoDoi_CongNo.OneInstanceFrm.Show();
            this.Waited();
        }

        private void mnuTienIch_Click(object sender, EventArgs e)
        {

        }

        private void trừVậnChuyểnTheoTạpChấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frm_NhapTB_GiaVC frm = new frm_NhapTB_GiaVC();
            frm.ShowDialog();
        }



    }
}