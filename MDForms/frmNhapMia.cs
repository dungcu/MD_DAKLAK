using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.OleDb;
using MDSolutionEntities;
using MDSolution;

//using SerialPortTerminal.Properties;

namespace DACASUCO.MDForms
{
    public partial class frmNhapMia : Form
    {
        # region Local Variables

        private SerialPort comport = new SerialPort();
        bool kieu_can = true; // Can xe mia; can bi xe
        string VuTrongID = MDSolution.DACASUCO_App.VuTrongID.ToString();


        long TongTL = 0;
        #endregion

        # region Public Variables
        public string MaKVC = "";
        public string MaKhach = "";
        public long KhoiLuongCanGep = 0; // Khoi luong can ghep
        public long SoHDCanGhep = 0;
        public long MaCanID = -1; // Ma can #-1 neu la can bi xe
        public string SoXe = "";
        public long ThuaRuongID = 0;
        public string BanDieuTra = "";
        private long MuaTaiRuong = 0;
        private long MuaTaiBanCan = 0;
        private long MuaTheoCCS = 0;
        private long MuaTheoMiaSach = 0;
        private long BTKID = -1;
        # endregion

        public frmNhapMia()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {

            if (comport.IsOpen) comport.Close();

            base.OnClosed(e);
        }

        private void frmNhapMia_Load(object sender, EventArgs e)
        {


            // Dat ngay gio nhap mia
            lblNgayNhap.Text = "Ngày nhập (*):";
            //lblGioNhap.Text = "Giờ nhập:";


            //lblNgayNhap.Text = "Ngày nhập:" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + " ";
            //lblGioNhap.Text = "Giờ nhập:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + " ";

            //Load Gia Mia
            //load_cbo_gianhapmia("0", VuTrongID);

            try
            {
                if (comport.IsOpen) comport.Close();
                else
                {
                    // Set the port's settings
                    comport.BaudRate = 4800;
                    comport.DataBits = 7;
                    comport.StopBits = StopBits.One;
                    comport.Parity = Parity.Even;
                    comport.PortName = "COM1";
                    // Open the port
                    comport.Open();
                }
            }
            catch
            {
                MessageBox.Show("Không thể kết nối tới thiết bị cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (kieu_can)
            {
                InitControl("Cân mía");
            }
            else
            {
                InitControl("Cân bì");
            }

            cmdXeChuaCan.Text = XeChuaCanBi().ToString() + "-Thiếu bì(F4)";
        }


        # region User Function
        // Load bai tap ket ID
        private void load_cbo_baibocxep(string SelectedID, string BTKID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("TEN");
            DataSet ds = null;
            string[] strInits = new string[] { "0", "--Chọn--" };
            dt.Rows.Add(strInits);
            ds = clsBaiTapKet.GetListbyWhere("ID,TenBai", "ID=" + BTKID, "", null, null);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string strID = dr["ID"].ToString();
                string strTEN = dr["TenBai"].ToString();
                string[] strValues = new string[] { strID, strTEN };
                dt.Rows.Add(strValues);
            }
            cboBaiBocXep.ValueMember = "ID";
            cboBaiBocXep.DisplayMember = "TenBai";
            cboBaiBocXep.DataSource = dt;
            cboBaiBocXep.SelectedValue = SelectedID;

        }
        //End  Load bai tap ket ID
        // Load gia nhap mia
        //private void load_cbo_gianhapmia(string SelectedID, string VuTrongID)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("ID");
        //    dt.Columns.Add("DonGia");
        //    DataSet ds = null;
        //    string[] strInits = new string[] { "0", "--Chọn--" };
        //    dt.Rows.Add(strInits);
        //    ds = clsGiaNhapMia.GetListbyWhere("ID,DonGia", "VuTrongID=" + VuTrongID, "DonGia", null, null);

        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        string strID = dr["ID"].ToString();
        //        string strTEN = dr["DonGia"].ToString();
        //        string[] strValues = new string[] { strID, strTEN };
        //        dt.Rows.Add(strValues);
        //    }
        //    cboGiaMia.DataSource = dt;
        //    //cboGiaMia.SelectedValue = SelectedID;
        //    cboGiaMia.Text = SelectedID;
        //    //cboGiaMia.SelectedText = SelectedID;

        //}
        //End  Load gia nhap mia

        // Load xe van chuyen
        private void load_cbo_xe(string SelectedID, string HopDongCVCID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("SoXe");
            DataSet ds = null;
            string[] strInits = new string[] { "0", "--Chọn--" };
            dt.Rows.Add(strInits);
            ds = clsXeVanChuyen.GetListbyWhere("ID, SoXe", "HopDongVanChuyenID=" + HopDongCVCID, "", null, null);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string strID = dr["ID"].ToString();
                string strTEN = dr["SoXe"].ToString().ToUpper();
                string[] strValues = new string[] { strID, strTEN };
                dt.Rows.Add(strValues);
            }
            cboSoXe.ValueMember = "ID";
            cboSoXe.DisplayMember = "SoXe";
            cboSoXe.DataSource = dt;
            cboSoXe.SelectedValue = SelectedID;

        }


        //End  Load gia nhap mia
        private void Get_KhachVanChuyen(string MaKVC)
        {
            if (MaKVC != "")
            {
                clsHopDongVanChuyen objHDVC = new clsHopDongVanChuyen();
                objHDVC.Load(MaKVC, null, null);
                if (objHDVC.ID > 0)
                {
                    txtHoTenKHVC.Text = objHDVC.TenChuHopDong.ToString();
                    //clsComFunctions.HoTen_Format(objHDVC.TenChuHopDong);
                    txtMaKhachVC.Text = objHDVC.ID.ToString();

                    load_cbo_xe("0", objHDVC.ID.ToString());
                }
                else
                {
                    txtHoTenKHVC.Text = "";
                    txtMaKhachVC.Text = "";
                    DataSet ds = null;
                    cboSoXe.DataSource = ds;
                }

            }
        }
        private void Get_KhachVanChuyen_ByID(string MaKVC)
        {
            if (MaKVC != "")
            {
                clsHopDongVanChuyen objHDVC = new clsHopDongVanChuyen(long.Parse(MaKVC));
                objHDVC.Load(null, null);
                if (objHDVC.ID > 0)
                {

                    txtHoTenKHVC.Text = objHDVC.TenChuHopDong.ToString();
                    //clsComFunctions.HoTen_Format(objHDVC.TenChuHopDong);
                    txtMaKhachVC.Text = objHDVC.ID.ToString();
                    txtHopDongVC.Text = objHDVC.MaHopDong;
                    load_cbo_xe("0", objHDVC.ID.ToString());
                }
                else
                {
                    txtHoTenKHVC.Text = "";
                    txtMaKhachVC.Text = "";
                    DataSet ds = null;
                    cboSoXe.DataSource = ds;
                }

            }
        }
        private void Get_Khach(string MaKhach)
        {
            if (MaKhach != "")
            {
                clsHopDong objHD = new clsHopDong();
                objHD.Load(MaKhach, null, null);
                if (objHD.ID > 0)
                {
                    txtMaKhach.Text = objHD.ID.ToString();
                    txtHoTen.Text = MDSolutionEntities.clsComFunctions.HoTen_Format(objHD.HoTen);

                    //Load CBO Bai boc xep
                    load_cbo_baibocxep("0", objHD.ThonID.ToString());

                }
                else
                {
                    txtMaKhach.Text = "";
                    txtHoTen.Text = "";
                }
            }
        }
        // 
        private void Get_Khach_By_ID(string MaKhach)
        {
            if (MaKhach != "")
            {
                clsHopDong objHD = new clsHopDong(long.Parse(MaKhach));
                objHD.Load(null, null);
                if (objHD.ID > 0)
                {
                    txtMaKhach.Text = objHD.ID.ToString();
                    txtHoTen.Text = MDSolutionEntities.clsComFunctions.HoTen_Format(objHD.HoTen);
                    txtSoHopDong.Text = objHD.MaHopDong;
                    //Load CBO Bai boc xep
                    load_cbo_baibocxep("0", objHD.ThonID.ToString());

                }
                else
                {
                    txtMaKhach.Text = "";
                    txtHoTen.Text = "";
                }
            }
        }

        private void Tinh_Toan()
        {
            // Trong luong xe cho mia
            long TongTrongLuong = 0;
            if (txtCanMia.Text != "")
            {
                try
                {
                    TongTrongLuong = long.Parse(txtCanMia.Text);
                }
                catch
                {
                    TongTrongLuong = 0;
                }
            }
            // Trong luong xe
            long TrongLuongXe = 0;
            if (txtCanXe.Text != "")
            {
                try
                {
                    TrongLuongXe = long.Parse(txtCanXe.Text);
                }
                catch
                {
                    TrongLuongXe = 0;
                }
            }
            if (TongTrongLuong - TrongLuongXe < -10)
            {
               // MessageBox.Show("Kiểm tra lại trọng lượng  cân bì", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // trong luong qua can
                long TrongLuongCan = TongTrongLuong - TrongLuongXe;
                txtTrongLuongCan.Text = TrongLuongCan.ToString();
                if (TrongLuongCan > 0)
                {
                    if (string.IsNullOrEmpty(txt_GiaVanChuyen.Text))
                    {
                        MessageBox.Show("Chưa có giá vận chuyển");
                        return;
                    }
                    txt_TienVanChuyen.Text = (TrongLuongCan * long.Parse(txt_GiaVanChuyen.Text) / 1000).ToString();
                }

                double TiLeTapVat = 0;
                try
                {
                    TiLeTapVat = double.Parse(txtTLTCTT.Text);
                    string TapChatCT = "select Them from tbl_HoTroTC Where Tu <= " + TiLeTapVat.ToString() + " AND Den >=" + TiLeTapVat.ToString();
                    string Them = "0";
                    Them = DBModule.ExecuteQueryForOneResult(TapChatCT, null, null);
                    if (double.Parse(Them) == -1.00)
                    {
                        txtTLTCCC.Text = "0";

                    }
                    else
                    {
                        txtTLTCCC.Text = (double.Parse(Them) + TiLeTapVat).ToString();
                    }
                }
                catch
                {
                    TiLeTapVat = 0;
                }
                double TLTapVat = Math.Round(TrongLuongCan * TiLeTapVat / 100);
                txtTrongLuongTapVat.Text = TLTapVat.ToString();

                if (txtTrongLuongTapVat.Text != "")
                {
                    long TrongLuongTapVat = 0;
                    try
                    {
                        TrongLuongTapVat = long.Parse(txtTrongLuongTapVat.Text);
                    }
                    catch
                    {
                        TrongLuongTapVat = 0;
                    }

                    long TrongLuongMia = TrongLuongCan - TrongLuongTapVat;
                    try
                    {
                        txtTrongLuongMia.Text = TrongLuongMia.ToString();
                    }
                    catch
                    {
                        // txtTrongLuongMia.Text = "0"; 
                    }
                }
            }
        }

        private bool Check_Error(int Type)
        {
            string strError = "";

            if (txt_SoPhieu.Text == "")
                strError = "Bạn chưa nhập số hợp đồng trồng mía! \n";

            if ((cboBaiBocXep.SelectedValue == null) || (cboBaiBocXep.Text == ""))
                strError = "Bạn chưa chọn bãi bốc xếp! \n";

            if ((cboSoXe.SelectedValue == null) || (cboSoXe.Text == ""))
                strError = "Bạn chưa chọn xe vận chuyển! \n";

            //if ((cboGiaMia.SelectedValue == null) || (cboGiaMia.SelectedValue.ToString() == "0"))
            //    strError = "Bạn chưa chọn đơn giá nhập mía! \n";

            if (txtSoHopDong.Text == "")
                strError = "Bạn chưa nhập số hợp đồng trồng mía! \n";


            if (txtCanXe.Text == "")
                strError = "Bạn chưa nhập trọng lượng xe! \n";
            if (txt_CCS.Text == "")
                strError = "Bạn chưa nhập CCS! \n";
            if (txtTLTCTT.Text == "")
                strError = "Bạn chưa nhập tỉ lệ tạp chất! \n";
            if (txtTLTCCC.Text == "")
                strError = "Bạn chưa nhập tỉ lệ cải chính! \n";
            if (dtNgayNhap.Text == "")
                strError = "Bạn chưa nhập ngày vào nhập mía! \n";
            if (dtNgayra.Text == "")
                strError = "Bạn chưa nhập ngày ra nhập mía! \n";



            if (txtHopDongVC.Text == "")
                strError = "Bạn chưa nhập số hợp đồng trồng mía! \n";

            long TLMia = 0;
            if (txtCanMia.Text == "")
                //strError = "Bạn chưa nhập khối lượng xe mía! \n";
            {
                try { TLMia = long.Parse(txtCanMia.Text); }
                catch { TLMia = 0; }
                if (TLMia <= 0)
                {
                    strError = "Trọng lượng xe mía phải lớn hơn 0!\n";
                    }
            }

            if (Type > 0)
            {
                if (txtCCS.Text == "")
                    strError = "Bạn chưa nhập tỉ lệ tạp vật! \n";

                long TLXe = 0;
                if (txtCanXe.Text == "")
                    strError = "Bạn chưa nhập khối lượng bì xe! \n";
                else
                {
                    try { TLXe = long.Parse(txtCanXe.Text); }
                    catch { TLXe = 0; }
                    if (TLXe < 0)
                        strError = "Trọng lượng xe phải lớn hơn 0!\n";
                    else
                        if (TLXe > TLMia)
                            strError = "Trọng lượng bì xe lớn hơn trọng lượng xe mía 0!\n";
                }
            }

            if (strError == "")
                return true;
            else
            {
                MessageBox.Show(strError, "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void InitControl(string type)
        {
            switch (type)
            {
                case "Cân mía":
                    txtCan.ReadOnly = false;
                    txtCanMia.ReadOnly = true;
                    txtCanXe.ReadOnly = false;
                    cmdCanXe.Visible = false;
                    cmdCanMia.Visible = false;
                    cboBaiBocXep.Enabled = false;
                    cboSoXe.Enabled = false;
                    //cboGiaMia.Enabled = true;
                    txtSoHopDong.ReadOnly = true;
                    txtHopDongVC.ReadOnly = true;
                    //cmdAddHopDong.Visible = false;
                    cmdInPhieu.Visible = false;
                    cmdFindHopDong.Visible = true;
                    cmdFindHDVC.Visible = true;
                    cmdNext.Visible = false;
                    lbl_kieucan.Text = "CÂN MÍA NHẬP DỮ LIỆU";
                    break;
                case "Cân bì":
                    cmdFindHopDong.Visible = false;
                    cmdFindHDVC.Visible = false;
                    txtSoHopDong.ReadOnly = true;
                    txtHopDongVC.ReadOnly = true;
                    //cmdAddHopDong.Visible = true;
                    txtCan.ReadOnly = false;
                    txtCanMia.ReadOnly = true;
                    txtCanXe.ReadOnly = false;
                    cboBaiBocXep.Enabled = false;
                    cboSoXe.Enabled = false;
                    //cboGiaMia.Enabled = false;
                    cmdCanMia.Visible = false;
                    cmdCanXe.Visible = false;
                    cmdInPhieu.Visible = false;
                    cmdNext.Visible = true;
                    lbl_kieucan.Text = "CÂN MÍA NHẬP DỮ LIỆU";
                    break;
                case "admin":
                    cmdFindHopDong.Visible = true;
                    cmdFindHDVC.Visible = true;
                    txtSoHopDong.ReadOnly = true;
                    txtHopDongVC.ReadOnly = true;
                    //cmdAddHopDong.Visible = false;
                    txtCan.ReadOnly = false;
                    txtCanMia.ReadOnly = false;
                    txtCanXe.ReadOnly = false;
                    cboBaiBocXep.Enabled = false;
                    cboSoXe.Enabled = false;
                    //cboGiaMia.Enabled = true;
                    cmdCanMia.Visible = false;
                    cmdCanXe.Visible = true;
                    cmdInPhieu.Enabled = false;
                    cmdNext.Visible = true;
                    break;
                case "print":
                    cmdFindHopDong.Visible = false;
                    cmdFindHDVC.Visible = false;
                    txtSoHopDong.ReadOnly = true;
                    txtHopDongVC.ReadOnly = true;
                    //cmdAddHopDong.Visible = false;
                    txtCan.ReadOnly = true;
                    txtCanMia.ReadOnly = true;
                    txtCanXe.ReadOnly = false;
                    cboBaiBocXep.Enabled = false;
                    cboSoXe.Enabled = false;
                    //cboGiaMia.Enabled = false;
                    cmdCanMia.Visible = false;
                    cmdCanXe.Visible = false;
                    cmdInPhieu.Visible = true;
                    cmdNext.Visible = true;
                    lbl_kieucan.Text = "IN PHIẾU CÂN";
                    break;
            }


        }
        private void SetNullControl()
        {
            txtSoHopDong.Text = "";
            txtHopDongVC.Text = "";
            txtHoTen.Text = "";
            txtHoTenKHVC.Text = "";
            txtMaKhach.Text = "";
            txtMaKhachVC.Text = "";
            txtThanhTien.Text = "";


            load_cbo_baibocxep("0", "0");
            //load_cbo_gianhapmia("0", VuTrongID);
            load_cbo_xe("0", "0");

            txtCanXe.Text = "0";
            txtCCS.Text = "";
            txtCan.Text = "0";
            txtCanMia.Text = "0";

            txtTrongLuongMia.Text = "0";
            txtTrongLuongCan.Text = "0";
        }

        private int XeChuaCanBi()
        {
            int iResult = 0;
            DataSet ds = null;
            ds = clsNhapMia.GetListbyWhere("Count(*) as TongXe", "MaCanGhepID=-1 AND TrongLuongXe<=0 AND VuTrongID=" + VuTrongID, "", null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    iResult = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    iResult = 0;
                }
            }
            return iResult;
        }

        private void Load_PhieuCan()
        {
            clsNhapMia objNhapMia = new clsNhapMia(MaCanID);
            if (MaCanID > 0)
            {
                objNhapMia.Load(null, null);
                if (objNhapMia.ID > 0)
                {
                    kieu_can = false;
                    MaCanID = objNhapMia.ID;
                    txtCanMia.Text = objNhapMia.TongTrongLuong.ToString();
                    txtCanMia.ReadOnly = true;
                    txtCanXe.Text = txtCan.Text;
                    clsHopDong objHD = new clsHopDong(objNhapMia.HopDongID);
                    objHD.Load(null, null);
                    txtMaKhach.Text = objHD.ID.ToString();
                    txtSoHopDong.Text = objHD.MaHopDong;
                    txtHoTen.Text = objHD.HoTen;

                    //Load CBO Bai boc xep
                    load_cbo_baibocxep(objNhapMia.BaiTapKetID.ToString(), objHD.ThonID.ToString());

                    //Load CBO gia nhap mia
                    //load_cbo_gianhapmia(objNhapMia.GiaMia.ToString(), VuTrongID);
                    InitControl("Cân bì");
                    KhoiLuongCanGep = frmGhepMaCan.TongCanGhep(MaCanID.ToString());
                    SoHDCanGhep = frmGhepMaCan.SoHDCanGhep(MaCanID.ToString());
                }
            }
        }

        private void Load_XeChuaCanBi(string SoXe)
        {
            clsNhapMia objNhapMia = new clsNhapMia();
            objNhapMia.Load(SoXe, null, null);
            if (objNhapMia.ID > 0)
            {
                kieu_can = false;
                MaCanID = objNhapMia.ID;

                //Load thong tin chu van chuyen
                clsHopDongVanChuyen objVC = new clsHopDongVanChuyen();
                objVC.ID = objNhapMia.HopDongVanChuyenID;
                objVC.Load(null, null);
                txtHopDongVC.Text = objVC.MaHopDong;
                txtHoTenKHVC.Text = objVC.TenChuHopDong;
                //load_cbo_xe(SoXe, objVC.ID.ToString());
                clsXeVanChuyen objXe = new clsXeVanChuyen(long.Parse(SoXe));
                objXe.Load(null, null);
                cboSoXe.Text = objXe.SoXe;

                //Load thong tin can
                txtCanMia.Text = objNhapMia.TongTrongLuong.ToString();
                txtCanMia.ReadOnly = true;
                txtCanXe.Text = txtCan.Text;

                //Load thong tin Hop dong
                clsHopDong objHD = new clsHopDong(objNhapMia.HopDongID);
                objHD.Load(null, null);
                txtMaKhach.Text = objHD.ID.ToString();
                txtSoHopDong.Text = objHD.MaHopDong;
                txtHoTen.Text = objHD.HoTen;
                //Load CBO Bai boc xep
                load_cbo_baibocxep(objNhapMia.BaiTapKetID.ToString(), objHD.ThonID.ToString());

                //Load CBO gia nhap mia
                //load_cbo_gianhapmia(objNhapMia.GiaMia.ToString(), VuTrongID);

                //Set control
                InitControl("Cân bì");
                KhoiLuongCanGep = frmGhepMaCan.TongCanGhep(MaCanID.ToString());
                SoHDCanGhep = frmGhepMaCan.SoHDCanGhep(MaCanID.ToString());
                lblTongTL.Text = "Tổng TL ghép:" + KhoiLuongCanGep.ToString();
                lblSoHDGhep.Text = "Số HĐ ghép:" + SoHDCanGhep.ToString();
            }
        }
        private void PhieuTrang()
        {
            txt_SoPhieu.Text = "0";
            txtCan.Text = "0";
            txtGiaMia.Text = "0";
            lbl_HinhThuc.Text = "0";
            lbl_HinhThuc.Text = "0";
            lbl_PhuongThuc.Text = "0";
            txt_MaHDDT.Text = "0";
            txtMaKhach.Text = "0";
            txtSoHopDong.Text = "0";
            txtHoTen.Text = "0";
            txtCanMia.Text = "0";
            // load xa
            txt_Xa.Text = "";
            // bai tap ket
            cboBaiBocXep.Text = "0";
            txt_KhoangCach.Text = "0";
            txt_GiaVanChuyen.Text = "0";
            // tram nong vu
            txt_Tram.Text = "0";
            //Load thong tin chu van chuyen
            txtHopDongVC.Text = "0";
            txtHoTenKHVC.Text = "0";
            //load_cbo_xe(SoXe, objVC.ID.ToString());
            cboSoXe.Text = "0";
            txtCanXe.Text = "0";
            txtTrongLuongCan.Text = "0";
            txt_CCS.Text = "0";
            txtTrongLuongTapVat.Text = "0";
            txtTrongLuongMia.Text = "0";
            txtGiaMia.Text = "0";
            txtCCS.Text = "0";
            txtThanhTien.Text = "0";
        }

        private void Load_SoPhieu(string SoPhieu)
        {
            DataSet dtsophieu;
            DataRow drsophieu;

            clsNhapMia objNhapMia = new clsNhapMia();
            //objNhapMia.Load(SoXe, null, null);

            string sqlsophieu = "Select * from BarCode WHERE VuTrongID = " + DACASUCO_App.VuTrongID + " AND ID = " + SoPhieu + " AND DaCan = 0";
            try
            {
                dtsophieu = DBModule.ExecuteQuery(sqlsophieu, null, null);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại số phiếu nhập");
                return;
            }

            if (dtsophieu.Tables[0].Rows.Count > 0)
            {
                drsophieu = dtsophieu.Tables[0].Rows[0];
                //kieu_can = false;
                //MaCanID = objNhapMia.ID;
                // load thửa ruộng
                ThuaRuongID = long.Parse(drsophieu["ThuaRuongID"].ToString());

                clsThuaRuong objTR = new clsThuaRuong(long.Parse(drsophieu["ThuaRuongID"].ToString()));
                objTR.Load(null, null);

                long HopDongID = long.Parse(objTR.HopDongID.ToString());
                BTKID = long.Parse(objTR.BaiTapKetID.ToString());
                long TramID = long.Parse(objTR.TramNongVuID.ToString());
                long XaID = long.Parse(objTR.ThonID.ToString());
                BanDieuTra = objTR.SoBanDieuTra;


                txtGiaMia.Text = drsophieu["GiaMia"].ToString();

                if (long.Parse(drsophieu["MuaTaiBanCan"].ToString()) == 1)
                {
                    lbl_HinhThuc.Text = "Mua tại bàn cân";
                    MuaTaiBanCan = 1;
                }
                else
                {
                    lbl_HinhThuc.Text = "Mua tại ruộng";
                    MuaTaiRuong = 1;
                }

                if (long.Parse(drsophieu["MuaCCS"].ToString()) == 1)
                {

                    lbl_PhuongThuc.Text = "Mua theo CCS";
                    MuaTheoCCS = 1;
                }
                else
                {
                    lbl_PhuongThuc.Text = "Mua theo TL Mía sạch";
                    MuaTheoMiaSach = 1;
                }

                txt_MaHDDT.Text = objTR.MaHDDT;

                //Load thong tin Hop dong
                clsHopDong objHD = new clsHopDong(HopDongID);
                objHD.Load(null, null);
                txtMaKhach.Text = objHD.ID.ToString();
                txtSoHopDong.Text = objHD.MaHopDong;
                txtHoTen.Text = objHD.HoTen;
                // load xa
                clsXa objXa = new clsXa(XaID);
                objXa.Load(null, null);
                txt_Xa.Text = objXa.Ten;
                // bai tap ket
                clsBaiTapKet objBTK = new clsBaiTapKet(BTKID);
                objBTK.Load(null, null);
                cboBaiBocXep.Text = objBTK.TenBai;
                txt_KhoangCach.Text = objBTK.KhoangCach.ToString();

                if (objBTK.DonGia < 0)
                {
                    MessageBox.Show("Chưa có giá vận chuyển");
                    return;
                }
                {
                    txt_GiaVanChuyen.Text = objBTK.DonGia.ToString();
                }
                // tram nong vu
                clsTramNongVu objTram = new clsTramNongVu(TramID);
                objTram.Load(null, null);
                txt_Tram.Text = objTram.Ten;




                //Load thong tin chu van chuyen
                clsHopDongVanChuyen objVC = new clsHopDongVanChuyen(long.Parse(drsophieu["HopDongVanChuyenID"].ToString()));
                //objVC.ID = objNhapMia.HopDongVanChuyenID;
                objVC.Load(null, null);
                txtHopDongVC.Text = objVC.MaHopDong;
                txtHoTenKHVC.Text = objVC.TenChuHopDong;
                //load_cbo_xe(SoXe, objVC.ID.ToString());
                clsXeVanChuyen objXe = new clsXeVanChuyen(long.Parse(drsophieu["XeID"].ToString()));
                objXe.Load(null, null);
                cboSoXe.Text = objXe.SoXe;

                //Load thong tin can
                //txtCanMia.Text = objNhapMia.TongTrongLuong.ToString();
                txtCanMia.ReadOnly = true;
                //txtCanXe.Text = txtCan.Text;


                //Load CBO Bai boc xep
                //load_cbo_baibocxep(objNhapMia.BaiTapKetID.ToString(), objHD.ThonID.ToString());

                //Load CBO gia nhap mia
                //load_cbo_gianhapmia(objNhapMia.GiaMia.ToString(), VuTrongID);

            }
            else
            {
                MessageBox.Show("Xem lại số phiếu nhập");

            }



            ////Set control
            //InitControl("Cân bì");
            //KhoiLuongCanGep = frmGhepMaCan.TongCanGhep(MaCanID.ToString());
            //SoHDCanGhep = frmGhepMaCan.SoHDCanGhep(MaCanID.ToString());
            //lblTongTL.Text = "Tổng TL ghép:" + KhoiLuongCanGep.ToString();
            //lblSoHDGhep.Text = "Số HĐ ghép:" + SoHDCanGhep.ToString();

        }
        # endregion


        # region EventArgs
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.F2:
                    //Code cho F1
                    //dlgHopDongVanChuyen frm = new dlgHopDongVanChuyen();
                    //frm.ShowDialog();
                    //DACASUCO.MDDialoge.dlgHopDongVanChuyen dlg = new MDDialoge.dlgHopDongVanChuyen();
                    //dlg.passID = new MDDialoge.dlgHopDongVanChuyen.PassID(GetHopDongVC_ID);
                    //dlg.ShowDialog();
                    //if (dlg.DialogResult == DialogResult.OK)
                    //{
                    //    Get_KhachVanChuyen_ByID(MaKVC);
                    //    dlg.Dispose();
                    //}
                    //else
                    //{
                    //    //MessageBox.Show("Cancel" + oHD.ID.ToString());
                    //    dlg.Dispose();
                    //}
                    //break;

                    case Keys.F4:
                    //Code cho F4
                    //MDDialoge.dlgXeChuaCanBi dlg1 = new MDDialoge.dlgXeChuaCanBi();
                    //dlg1.passID = new MDDialoge.dlgXeChuaCanBi.PassID(Get_XeChuaCanBi);
                    //dlg1.ShowDialog();
                    //if (dlg1.DialogResult == DialogResult.OK)
                    //{

                    //    Load_XeChuaCanBi(SoXe);
                    //    dlg1.Dispose();
                    //}
                    //else
                    //{
                    //    //MessageBox.Show("Cancel" + oHD.ID.ToString());
                    //    dlg1.Dispose();
                    //}
                    //break;
                    case Keys.F3:
                    // Code cho phim F3
                    //MDDialoge.dlgHopDong dlg2 = new MDDialoge.dlgHopDong();
                    //dlg2.passID = new MDDialoge.dlgHopDong.PassID(GetHopDongID);
                    //dlg2.ShowDialog();
                    //if (dlg2.DialogResult == DialogResult.OK)
                    //{
                    //    //MessageBox.Show("OK"+oHD.ID.ToString());
                    //    Get_Khach_By_ID(MaKhach);
                    //    dlg2.Dispose();
                    //}
                    //else
                    //{
                    //    //MessageBox.Show("Cancel" + oHD.ID.ToString());
                    //    dlg2.Dispose();
                    //}
                    //break;
                    case Keys.F10:
                    // Code cho phim F5
                    //frmGhepMaCan dlg3 = new frmGhepMaCan();
                    //dlg3.MaCanGhep = MaCanID;
                    //dlg3.ShowDialog();
                    //if (dlg3.DialogResult == DialogResult.OK)
                    //{
                    //    KhoiLuongCanGep = frmGhepMaCan.TongCanGhep(MaCanID.ToString());
                    //    SoHDCanGhep = frmGhepMaCan.SoHDCanGhep(MaCanID.ToString());
                    //    if (KhoiLuongCanGep > 0)
                    //    {
                    //        lblTongTL.Text = "Tổng TL ghép:" + KhoiLuongCanGep.ToString();
                    //        lblSoHDGhep.Text = "Số HĐ ghép:" + SoHDCanGhep.ToString();
                    //        clsNhapMia obj = new clsNhapMia(MaCanID);
                    //        obj.Load(null, null);
                    //        txtCanMia.Text = obj.TongTrongLuong.ToString();
                    //        long TongTL = 0;
                    //        try
                    //        {
                    //            TongTL = long.Parse(txtCanMia.Text);
                    //        }
                    //        catch
                    //        {
                    //            TongTL = 0;
                    //        }
                    //        if (TongTL > 0) TongTL = TongTL - KhoiLuongCanGep;
                    //        txtCanMia.Text = TongTL.ToString();
                    //        Tinh_Toan();
                    //    }
                    //}
                    //else
                    //{
                    //    dlg3.Dispose();
                    //}
                    //break;
                    case Keys.F8:
                        // Code cho phim F8
                        clsNhapMia objNhapMia = new clsNhapMia();
                        if (MaCanID > 0)
                        {
                            objNhapMia.ID = MaCanID;
                            objNhapMia.Load(null, null);
                        }

                        if (Check_Error(0))
                        {
                            objNhapMia.HopDongID = long.Parse(txtMaKhach.Text);
                            objNhapMia.HopDongVanChuyenID = long.Parse(txtMaKhachVC.Text);
                            objNhapMia.TongTrongLuong = long.Parse(txtCanMia.Text);
                            TongTL = Convert.ToInt64(Math.Round(objNhapMia.TongTrongLuong));
                            objNhapMia.XeVanChuyenID = long.Parse(cboSoXe.SelectedValue.ToString());
                            objNhapMia.NgayGioCan = DateTime.Now;
                            //objNhapMia.GioNhap = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                            objNhapMia.BaiTapKetID = long.Parse(cboBaiBocXep.SelectedValue.ToString());
                            objNhapMia.GiaMia = 0;
                            //long.Parse(cboGiaMia.Text);
                            objNhapMia.VuTrongID = long.Parse(VuTrongID);
                            objNhapMia.Save(null, null);
                            MaCanID = objNhapMia.ID;
                            MessageBox.Show("Đã cập nhật số lượng cân xe chở mía", "Thông báo", MessageBoxButtons.OK);
                            //kieu_can = false;
                            //txtCan.Text = "0";
                            //InitControl("Cân bì");
                            //Cap nhat xe chua can bi

                            kieu_can = true;
                            MaCanID = 0;
                            KhoiLuongCanGep = 0;
                            SoHDCanGhep = 0;

                            lbl_kieucan.Text = "CÂN MÍA NHẬP DỮ LIỆU";
                            SetNullControl();
                            InitControl("Cân mía");
                            txtHopDongVC.Focus();

                            cmdXeChuaCan.Text = XeChuaCanBi().ToString() + "-Thiếu bì(F4)";
                        }
                        break;
                    case Keys.F9:
                    // Code cho phim F9
                    //if (Check_Error(1))
                    //{
                    //    clsNhapMia objNhapMia1 = new clsNhapMia(MaCanID);
                    //    objNhapMia1.Load(null, null);
                    //    //txtCanMia.Text = objNhapMia.TongTrongLuong.ToString();
                    //    objNhapMia1.NgayGioCanRa = DateTime.Now;
                    //    //objNhapMia1.GioRa = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                    //    objNhapMia1.TrongLuongXe = long.Parse(txtCanXe.Text);
                    //    objNhapMia1.GiaMia = 0;
                    //    //long.Parse(cboGiaMia.Text);
                    //    objNhapMia1.TyLeTapVat = decimal.Parse(txtCCS.Text);
                    //    objNhapMia1.TongTrongLuong = long.Parse(txtCanMia.Text);
                    //    objNhapMia1.TrongLuongTapVat = Convert.ToDecimal((objNhapMia1.TongTrongLuong - objNhapMia1.TrongLuongXe) * objNhapMia1.TyLeTapVat / 100);

                    //    clsBaiTapKet objBTK = new clsBaiTapKet(objNhapMia1.BaiTapKetID);
                    //    objBTK.Load(null, null);
                    //    objNhapMia1.GiaMia = objBTK.DonGia;

                    //    objNhapMia1.TienMia = (objNhapMia1.TongTrongLuong - objNhapMia1.TrongLuongXe - objNhapMia1.TrongLuongTapVat) * objNhapMia1.GiaMia;
                    //    objNhapMia1.TienVanChuyen = (objNhapMia1.TongTrongLuong - objNhapMia1.TrongLuongXe - objNhapMia1.TrongLuongTapVat) * objNhapMia1.GiaVanChuyen;

                    //    OleDbConnection cn = DBModule.CreateDBConnection();
                    //    OleDbTransaction trans = cn.BeginTransaction();
                    //    try
                    //    {
                    //        objNhapMia1.Save(null, null);
                    //        if (SoHDCanGhep > 0)
                    //        {
                    //            DataSet ds = clsNhapMia.GetListbyWhere("ID", "MaCanGhepID=" + objNhapMia1.ID.ToString(), "", cn, trans);
                    //            foreach (DataRow dr in ds.Tables[0].Rows)
                    //            {
                    //                long MaCan = -1;
                    //                try
                    //                {
                    //                    MaCan = long.Parse(dr[0].ToString());
                    //                }
                    //                catch { MaCan = -1; };
                    //                if (MaCan > 0)
                    //                {
                    //                    clsNhapMia obj = new clsNhapMia(MaCan);
                    //                    obj.Load(cn, trans);
                    //                    obj.TyLeTapVat = objNhapMia1.TyLeTapVat;
                    //                    obj.TrongLuongTapVat = Convert.ToInt32(obj.TongTrongLuong * obj.TyLeTapVat / 100);
                    //                    obj.GiaMia = objNhapMia1.GiaMia;
                    //                    obj.VuTrongID = long.Parse(VuTrongID);
                    //                    obj.MaGhepCanID = objNhapMia1.ID;
                    //                    obj.HopDongVanChuyenID = objNhapMia1.HopDongVanChuyenID;
                    //                    obj.BaiTapKetID = objNhapMia1.BaiTapKetID;
                    //                    obj.XeVanChuyenID = objNhapMia1.XeVanChuyenID;
                    //                    obj.GiaVanChuyen = objNhapMia1.GiaVanChuyen;
                    //                    obj.TienMia = (obj.TongTrongLuong - obj.TrongLuongXe - obj.TrongLuongTapVat) * obj.GiaMia;
                    //                    obj.TienVanChuyen = (obj.TongTrongLuong - obj.TrongLuongXe - obj.TrongLuongTapVat) * obj.GiaVanChuyen;
                    //                    obj.Save(cn, trans);
                    //                }
                    //            }
                    //        }
                    //        if (trans != null) trans.Commit();
                    //        MessageBox.Show("Đã cập nhật số lượng cân bì xe", "Thông báo", MessageBoxButtons.OK);
                    //        //txtCan.Text = "0";
                    //        InitControl("print");
                    //    }
                    //    catch
                    //    {
                    //        if (trans != null) trans.Rollback();
                    //    }
                    //    finally
                    //    {
                    //        DBModule.CloseDBConnection(cn);
                    //    }
                    //}
                    //break;
                    case Keys.F11:
                        // Code cho phim F11
                        MDForms.frmShowRP2 frm = new MDForms.frmShowRP2();
                        MDReport.rp_PhieuNhapMia rp = new MDReport.rp_PhieuNhapMia();

                        //rp.RecordSelectionFormula = "{V_VanChuyenMia.ID} = " + MaCanID.ToString();
                        string strSQL = "";
                        strSQL = "Select * from V_VanChuyenMia Where ID = " + MaCanID.ToString() + " OR MaCanGhepID=" + MaCanID.ToString();
                        DataSet ds1 = DBModule.ExecuteQuery(strSQL, null, null);
                        //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                        rp.Database.Tables[0].SetDataSource(ds1.Tables[0]);
                        frm.RP = rp;
                        frm.RPtitle = "In phiếu nhập mía nguyên liệu";
                        frm.Show();
                        break;
                    case Keys.F12:
                    // Code cho phim F12
                    //kieu_can = true;
                    //MaCanID = 0;
                    //KhoiLuongCanGep = 0;
                    //SoHDCanGhep = 0;

                    //lbl_kieucan.Text = "CÂN MÍA NHẬP DỮ LIỆU";
                    //lblTongTL.Text = "Tổng TL ghép:";
                    //lblSoHDGhep.Text = "Số HĐ ghép:";
                    //SetNullControl();
                    //InitControl("Cân mía");
                    //cmdXeChuaCan.Text = XeChuaCanBi().ToString() + "-Thiếu bì(F4)";
                    //txtHopDongVC.Focus();
                    //break;
                    case Keys.F6:
                        // Code cho phim F6
                        txtCCS.Focus();
                        break;
                    case Keys.F7:
                        // Code cho phim F7
                        //cboGiaMia.Focus();
                        break;
                    case Keys.F1:
                        // Code cho phim F6
                        txtHopDongVC.Focus();
                        break;
                    case Keys.F5:
                        // Code cho phim F7
                        txtSoHopDong.Focus();
                        break;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void cmdAddHopDong_Click(object sender, EventArgs e)
        {
            //frmGhepMaCan frm = new frmGhepMaCan();
            //frmGhepMaCan.MaCanGhep = MaCanID;
            //frm.ShowDialog();
            frmGhepMaCan dlg = new frmGhepMaCan();
            dlg.MaCanGhep = MaCanID;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                KhoiLuongCanGep = frmGhepMaCan.TongCanGhep(MaCanID.ToString());
                SoHDCanGhep = frmGhepMaCan.SoHDCanGhep(MaCanID.ToString());
                if (KhoiLuongCanGep > 0)
                {
                    lblTongTL.Text = "Tổng TL ghép:" + KhoiLuongCanGep.ToString();
                    lblSoHDGhep.Text = "Số HĐ ghép:" + SoHDCanGhep.ToString();
                    clsNhapMia obj = new clsNhapMia(MaCanID);
                    obj.Load(null, null);
                    txtCanMia.Text = obj.TongTrongLuong.ToString();
                    long TongTL = 0;
                    try
                    {
                        TongTL = long.Parse(txtCanMia.Text);
                    }
                    catch
                    {
                        TongTL = 0;
                    }
                    if (TongTL > 0) TongTL = TongTL - KhoiLuongCanGep;
                    txtCanMia.Text = TongTL.ToString();
                    Tinh_Toan();
                }
            }
            else
            {
                dlg.Dispose();
            }
        }

        private void cmdFindHDVC_Click(object sender, EventArgs e)
        {
            //dlgHopDongVanChuyen frm = new dlgHopDongVanChuyen();
            //frm.ShowDialog();
            MDDialoge.dlgHopDongVanChuyen dlg = new MDDialoge.dlgHopDongVanChuyen();
            dlg.passID = new MDDialoge.dlgHopDongVanChuyen.PassID(GetHopDongVC_ID);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                Get_KhachVanChuyen_ByID(MaKVC);
                dlg.Dispose();
            }
            else
            {
                //MessageBox.Show("Cancel" + oHD.ID.ToString());
                dlg.Dispose();
            }
        }
        public void GetHopDongVC_ID(string value)
        {
            MaKVC = value;
        }
        private void cmdFindHopDong_Click(object sender, EventArgs e)
        {
            MDDialoge.dlgHopDong dlg = new MDDialoge.dlgHopDong();
            dlg.passID = new MDDialoge.dlgHopDong.PassID(GetHopDongID);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                //MessageBox.Show("OK"+oHD.ID.ToString());
                Get_Khach_By_ID(MaKhach);
                dlg.Dispose();
            }
            else
            {
                //MessageBox.Show("Cancel" + oHD.ID.ToString());
                dlg.Dispose();
            }
        }
        public void GetHopDongID(string value)
        {
            MaKhach = value;
        }

        private void cmdCanMia_Click(object sender, EventArgs e)
        {
            clsNhapMia objNhapMia = new clsNhapMia();
            if (MaCanID > 0)
            {
                objNhapMia.ID = MaCanID;
                objNhapMia.Load(null, null);
            }

            if (Check_Error(0))
            {
                objNhapMia.HopDongID = long.Parse(txtMaKhach.Text);
                objNhapMia.HopDongVanChuyenID = long.Parse(txtMaKhachVC.Text);
                objNhapMia.TongTrongLuong = long.Parse(txtCanMia.Text);
                TongTL = Convert.ToInt64(Math.Round(objNhapMia.TongTrongLuong));
                objNhapMia.XeVanChuyenID = long.Parse(cboSoXe.SelectedValue.ToString());
                objNhapMia.NgayGioCan = DateTime.Now;
                //objNhapMia.GioNhap = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                objNhapMia.BaiTapKetID = long.Parse(cboBaiBocXep.SelectedValue.ToString());
                objNhapMia.GiaMia = long.Parse(txtGiaMia.Text);
                //long.Parse(cboGiaMia.Text);
                objNhapMia.VuTrongID = long.Parse(VuTrongID);
                objNhapMia.SoPhieuNhap = txt_SoPhieu.Text;
                objNhapMia.ThuaRuongID = ThuaRuongID;
                objNhapMia.SoXe = cboSoXe.Text;
                //objNhapMia.TongTrongLuong = long.Parse(txtCanMia.Text);
                //objNhapMia.DonGiaMia = long.Parse(txtGiaMia.Text);
                //ban dieu tra
                objNhapMia.LenhDon = txt_SoPhieu.Text;
                objNhapMia.MaHDDT = txt_MaHDDT.Text;
                // lenh don
                objNhapMia.SoBanDieuTra = BanDieuTra;





                objNhapMia.Save(null, null);
                MaCanID = objNhapMia.ID;
                MessageBox.Show("Đã cập nhật số lượng cân xe chở mía", "Thông báo", MessageBoxButtons.OK);
                //kieu_can = false;
                //txtCan.Text = "0";
                //InitControl("Cân bì");
                //Cap nhat xe chua can bi

                kieu_can = true;
                MaCanID = 0;
                KhoiLuongCanGep = 0;
                SoHDCanGhep = 0;

                lbl_kieucan.Text = "CÂN MÍA NHẬP DỮ LIỆU";
                SetNullControl();
                InitControl("Cân mía");
                txtHopDongVC.Focus();

                cmdXeChuaCan.Text = XeChuaCanBi().ToString() + "-Thiếu bì(F4)";
            }
        }

        private void cmdCanXe_Click(object sender, EventArgs e)
        {
            if (Check_Error(1))
            {
                //    clsNhapMia objNhapMia = new clsNhapMia(MaCanID);
                //    objNhapMia.Load(null, null);
                //    //txtCanMia.Text = objNhapMia.TongTrongLuong.ToString();
                //    objNhapMia.NgayGioCanRa = DateTime.Now;
                //    //objNhapMia.GioRa = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                //    objNhapMia.TrongLuongXe = long.Parse(txtCanXe.Text);
                //    objNhapMia.GiaMia = 0;
                //    //long.Parse(cboGiaMia.Text);
                //    objNhapMia.TyLeTapVat = decimal.Parse(txtCCS.Text);
                //    objNhapMia.TongTrongLuong = long.Parse(txtCanMia.Text);
                //    objNhapMia.TrongLuongTapVat = Convert.ToDecimal((objNhapMia.TongTrongLuong - objNhapMia.TrongLuongXe) * objNhapMia.TyLeTapVat / 100);

                //    clsBaiTapKet objBTK = new clsBaiTapKet(objNhapMia.BaiTapKetID);
                //    objBTK.Load(null, null);
                //    objNhapMia.GiaVanChuyen = objBTK.DonGia;

                //    objNhapMia.TienMia = (objNhapMia.TongTrongLuong - objNhapMia.TrongLuongXe - objNhapMia.TrongLuongTapVat) * objNhapMia.GiaMia;
                //    objNhapMia.TienVanChuyen = (objNhapMia.TongTrongLuong - objNhapMia.TrongLuongXe - objNhapMia.TrongLuongTapVat) * objNhapMia.GiaVanChuyen;


                //    OleDbConnection cn = DBModule.CreateDBConnection();
                //    OleDbTransaction trans = cn.BeginTransaction();
                //    try
                //    {
                //        objNhapMia.Save(null, null);
                //        if (SoHDCanGhep > 0)
                //        {
                //            DataSet ds = clsNhapMia.GetListbyWhere("ID", "MaCanGhepID=" + objNhapMia.ID.ToString(), "", cn, trans);
                //            foreach (DataRow dr in ds.Tables[0].Rows)
                //            {
                //                long MaCan = -1;
                //                try
                //                {
                //                    MaCan = long.Parse(dr[0].ToString());
                //                }
                //                catch { MaCan = -1; };
                //                if (MaCan > 0)
                //                {
                //                    clsNhapMia obj = new clsNhapMia(MaCan);
                //                    obj.Load(cn, trans);
                //                    obj.TyLeTapVat = objNhapMia.TyLeTapVat;
                //                    obj.TrongLuongTapVat = Convert.ToInt32(obj.TongTrongLuong * obj.TyLeTapVat / 100);
                //                    obj.GiaMia = objNhapMia.GiaMia;
                //                    obj.VuTrongID = long.Parse(VuTrongID);
                //                    obj.MaGhepCanID = objNhapMia.ID;
                //                    obj.HopDongVanChuyenID = objNhapMia.HopDongVanChuyenID;
                //                    obj.BaiTapKetID = objNhapMia.BaiTapKetID;
                //                    obj.XeVanChuyenID = objNhapMia.XeVanChuyenID;
                //                    obj.GiaVanChuyen = objNhapMia.GiaVanChuyen;
                //                    obj.TienMia = (obj.TongTrongLuong - obj.TrongLuongXe - obj.TrongLuongTapVat) * obj.GiaMia;
                //                    obj.TienVanChuyen = (obj.TongTrongLuong - obj.TrongLuongXe - obj.TrongLuongTapVat) * obj.GiaVanChuyen;
                //                    obj.Save(cn, trans);
                //                }
                //            }
                //        }
                //        if (trans != null) trans.Commit();
                //        MessageBox.Show("Đã cập nhật số lượng cân bì xe", "Thông báo", MessageBoxButtons.OK);
                //        //txtCan.Text = "0";
                //        InitControl("print");
                //    }
                //    catch
                //    {
                //        if (trans != null) trans.Rollback();
                //    }
                //    finally
                //    {
                //        DBModule.CloseDBConnection(cn);
                //    }
            }
        }


        private void txtCan_TextChanged(object sender, EventArgs e)
        {
            if (kieu_can)
            {
                txtCanMia.Text = txtCan.Text;
            }
            else
            {
                try
                {
                    txtCanXe.Text = txtCan.Text;
                    long TrongLuong = long.Parse(txtCanMia.Text) - long.Parse(txtCanXe.Text);
                    txtTrongLuongCan.Text = TrongLuong.ToString();
                }
                catch { };
            }
        }

        private void txtCanMia_TextChanged(object sender, EventArgs e)
        {
            Tinh_Toan();
        }

        private void txtCanXe_TextChanged(object sender, EventArgs e)
        {
            Tinh_Toan();
        }

        private void txtTiLeTapVat_TextChanged(object sender, EventArgs e)
        {
            double TiLeTapVat = 0;
            try
            {
                TiLeTapVat = double.Parse(txtCCS.Text);
            }
            catch
            {
                TiLeTapVat = 0;
            }
            if ((TiLeTapVat < 0) || (TiLeTapVat > 100))
            {
                MessageBox.Show("Kiểm tra lại tỉ lệ tạp vật", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCCS.Text = "";
            }
            else
            {
                Tinh_Toan();
            }

        }

        private void cboSoXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboSoXe.SelectedValue != null)
            //{
            //    Load_XeChuaCanBi(cboSoXe.SelectedValue.ToString());
            //}
            //else
            //{
            //    kieu_can = true;
            //    InitControl("Cân mía");
            //    MaCanID = -1;
            //    txtCanMia.Text = txtCan.Text;
            //    txtCanXe.Text = "0";
            //    txtCanMia.ReadOnly = false;
            //}
        }

        private void txtHopDongVC_TextChanged(object sender, EventArgs e)
        {
            Get_KhachVanChuyen(txtHopDongVC.Text.Trim());
        }

        private void txtSoHopDong_TextChanged(object sender, EventArgs e)
        {
            Get_Khach(txtSoHopDong.Text);
        }

        private void txtTrongLuongMia_TextChanged(object sender, EventArgs e)
        {
            if (long.Parse(txtCanMia.Text) > 0)
            {

                double ThanhTien = double.Parse(txtTrongLuongMia.Text) * double.Parse(txtGiaMia.Text);
                //double.Parse(cboGiaMia.Text);
                txtThanhTien.Text = ThanhTien.ToString("### ### ###");
            }
        }

        private void time_Tick(object sender, EventArgs e)
        {

            //if (comport.IsOpen)
            //{
            //    string dataIn = comport.ReadExisting();
            //    int index;
            //    String StringIn = "";
            //    if (dataIn.Length > 10)
            //    {
            //        while (dataIn.Length > 0 && ((index = dataIn.IndexOf("\r")) > 0 || (index = dataIn.IndexOf("\n")) > 0))
            //        {
            //            StringIn = dataIn.Substring(0, index);
            //            if (StringIn.Length >= 6)
            //            {
            //                StringIn = StringIn.Substring(4, 6);
            //                dataIn = "0";
            //            }
            //            else
            //                break;
            //        }
            //    }

            //    if (StringIn.Length == 6)
            //    {
            //        long TL = 0;
            //        try
            //        {
            //            TL = long.Parse(StringIn);
            //        }
            //        catch
            //        {
            //            TL = 0;
            //        }
            //        txtCan.Text = TL.ToString();
            //    }
            //}
            //cmdXeChuaCan.Text = XeChuaCanBi().ToString() + "-Thiếu bì(F4)";
            // lblSoHDGhep.Text = "Số HĐ ghép:"+ SoHDCanGhep.ToString();
            // lblTongTL.Text = "Tổng TL ghép:"+ KhoiLuongCanGep.ToString();
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            //kieu_can = true;
            //MaCanID = 0;
            //KhoiLuongCanGep = 0;
            //SoHDCanGhep = 0;
            //lbl_kieucan.Text = "CÂN XE MÍA";
            //lblTongTL.Text = "Tổng TL ghép:";
            //lblSoHDGhep.Text = "Số HĐ ghép:";
            //SetNullControl();
            //InitControl("Cân mía");
            //txtHopDongVC.Focus();
            //cmdXeChuaCan.Text = XeChuaCanBi().ToString() + "-Thiếu bì(F4)";

            // Code cho phim F8

            clsNhapMia objNhapMia = new clsNhapMia();
            if (MaCanID > 0)
            {
                objNhapMia.ID = MaCanID;
                objNhapMia.Load(null, null);
            }

            if (Check_Error(0))
            {
                objNhapMia.HopDongID = long.Parse(txtMaKhach.Text);
                objNhapMia.HopDongVanChuyenID = long.Parse(txtMaKhachVC.Text);
                objNhapMia.TongTrongLuong = long.Parse(txtCanMia.Text);
                TongTL = Convert.ToInt64(Math.Round(objNhapMia.TongTrongLuong));
                objNhapMia.XeVanChuyenID = long.Parse(cboSoXe.SelectedValue.ToString());
                objNhapMia.NgayGioCan = dtNgayNhap.Value;
                // objNhapMia.NgayGioCanRa = dtNgayra.Value;
                //objNhapMia.GioNhap = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                objNhapMia.BaiTapKetID = BTKID;
                objNhapMia.GiaMia = long.Parse(txtGiaMia.Text);
                //long.Parse(cboGiaMia.Text);
                objNhapMia.VuTrongID = long.Parse(VuTrongID);
                objNhapMia.NgayGioCanRa = dtNgayra.Value;
                objNhapMia.DonGiaVanChuyen = long.Parse(txt_GiaVanChuyen.Text);

                objNhapMia.TCBK = decimal.Parse(txtTLTCCC.Text);
                objNhapMia.CCS = decimal.Parse(txtTLTCCC.Text);
                //objNhapMia1.GioRa = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                objNhapMia.TrongLuongXe = long.Parse(txtCanXe.Text);
                //long.Parse(cboGiaMia.Text);
                long TrongLTV = Convert.ToInt32(((objNhapMia.TongTrongLuong - objNhapMia.TrongLuongXe) * objNhapMia.TCBK) / 100);
                objNhapMia.TyLeTapVat = decimal.Parse(txtTLTCTT.Text);
               
                objNhapMia.TrongLuongTapVat = Convert.ToDecimal(((objNhapMia.TongTrongLuong - objNhapMia.TrongLuongXe)*objNhapMia.TCBK)/100);
                 objNhapMia.TrongLuongMiaSach = (objNhapMia.TongTrongLuong - objNhapMia.TrongLuongXe - objNhapMia.TrongLuongTapVat);
                objNhapMia.TienMia = objNhapMia.TrongLuongMiaSach * objNhapMia.GiaMia;
                objNhapMia.TienVanChuyen = (objNhapMia.TongTrongLuong - objNhapMia.TrongLuongXe) * objNhapMia.DonGiaVanChuyen;
                try
                {
                    string sqlGetSoPhieu = "Select Max(SoPhieuNhap) from tbl_NhapMia where VuTrongID=" + DACASUCO_App.VuTrongID.ToString();
                    string sSoPhieu = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sqlGetSoPhieu, null, null);
                    int iSoPhieu = 1;
                    if (!string.IsNullOrEmpty(sSoPhieu))
                    {
                        iSoPhieu = int.Parse(sSoPhieu) + 1;
                    }
                    else
                    {


                    }
                    objNhapMia.SoPhieuNhap = iSoPhieu.ToString();
                }
                catch { }



                objNhapMia.NgayRa = dtNgayra.Value;
                objNhapMia.ThuaRuongID = ThuaRuongID;
                objNhapMia.SoBanDieuTra = BanDieuTra;
               
                objNhapMia.SoXe = cboSoXe.Text;

                objNhapMia.MuaTheoCCS = MuaTheoCCS;
                if (MuaTheoCCS == 1)
                {
                    objNhapMia.TienMia = (objNhapMia.TongTrongLuong - objNhapMia.TrongLuongXe - TrongLTV) * objNhapMia.GiaMia * decimal.Parse(txt_CCS.Text) / 10;

                }

                objNhapMia.MuaTaiBanCan = MuaTaiBanCan;

                if (chkMiachay.Checked == true)
                {
                    objNhapMia.MiaChay = 1;
                }


                objNhapMia.TienVanChuyen = long.Parse(txt_TienVanChuyen.Text);
                objNhapMia.MaHDDT = txt_MaHDDT.Text.Trim();
                objNhapMia.TienBangChu = Utils.DocSo(double.Parse(txtThanhTien.Text.Replace(" ", "")));
                objNhapMia.LenhDon = txt_SoPhieu.Text.Trim();
                objNhapMia.CCS = decimal.Parse(txt_CCS.Text);
                objNhapMia.TienVanChuyen = long.Parse(txt_TienVanChuyen.Text);


                objNhapMia.Save(null, null);
                MaCanID = objNhapMia.ID;
                string sql_BarCode = "Update BarCode set DaCan= 1 where ID=" + txt_SoPhieu.Text.Trim();
                DBModule.ExecuteNoneBackup(sql_BarCode, null, null);
                //ExecuteQueryForOneResult(sql_BarCode, null, null);



                MessageBox.Show("Xe mía đã cân tay", "Thông báo", MessageBoxButtons.OK);
                //txt_SoPhieu.Text = "";
                //Load_SoPhieu(txt_SoPhieu.Text);
                //kieu_can = false;
                //txtCan.Text = "0";
                //InitControl("Cân bì");
                //Cap nhat xe chua can bi

                //kieu_can = true;
                //MaCanID = 0;
                //KhoiLuongCanGep = 0;
                //SoHDCanGhep = 0;

                lbl_kieucan.Text = "CÂN MÍA NHẬP DỮ LIỆU";
                PhieuTrang();
                //SetNullControl();
                //InitControl("Cân mía");
                //txtHopDongVC.Focus();

                //cmdXeChuaCan.Text = XeChuaCanBi().ToString() + "-Thiếu bì(F4)";
            }

            // báo cáo

            // Code cho phim F11
            //MDForms.frmShowRP2 frm = new MDForms.frmShowRP2();
            //MDReport.rp_PhieuNhapMia rp = new MDReport.rp_PhieuNhapMia();

            ////rp.RecordSelectionFormula = "{V_VanChuyenMia.ID} = " + MaCanID.ToString();
            //string strSQL = "";
            //strSQL = "Select * from V_VanChuyenMia Where ID = " + MaCanID.ToString();
            //DataSet ds1 = DBModule.ExecuteQuery(strSQL, null, null);
            ////rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //rp.Database.Tables[0].SetDataSource(ds1.Tables[0]);
            //frm.RP = rp;
            //frm.RPtitle = "In phiếu nhập mía nguyên liệu";
            //frm.Show();







        }
        # endregion

        //private void cmdXeChuaCan_Click(object sender, EventArgs e)
        //{
        //    MDDialoge.dlgXeChuaCanBi dlg = new MDDialoge.dlgXeChuaCanBi();
        //    dlg.passID = new MDDialoge.dlgXeChuaCanBi.PassID(Get_XeChuaCanBi);
        //    dlg.ShowDialog();
        //    if (dlg.DialogResult == DialogResult.OK)
        //    {

        //        Load_XeChuaCanBi(SoXe);
        //        dlg.Dispose();
        //    }
        //    else
        //    {
        //        //MessageBox.Show("Cancel" + oHD.ID.ToString());
        //        dlg.Dispose();
        //    }
        //}

        //public void Get_XeChuaCanBi(string value)
        //{
        //    SoXe = value;
        //}

        private void cmdInPhieu_Click(object sender, EventArgs e)
        {

            DACASUCO.MDForms.frmShowRP2 frm = new DACASUCO.MDForms.frmShowRP2();
            DACASUCO.MDReport.rp_PhieuNhapMia rp = new DACASUCO.MDReport.rp_PhieuNhapMia();

            //rp.RecordSelectionFormula = "{V_VanChuyenMia.ID} = " + MaCanID.ToString();
            string strSQL = "";
            strSQL = "Select * from V_VanChuyenMia Where ID = " + MaCanID.ToString() + " OR MaCanGhepID=" + MaCanID.ToString();
            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            rp.Database.Tables[0].SetDataSource(ds.Tables[0]);
            frm.RP = rp;
            frm.RPtitle = "In phiếu nhập mía nguyên liệu";
            frm.Show();
        }

        private void txtTrongLuongCan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void cboBaiBocXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load_cbo_gianhapmia(cboBaiBocXep.SelectedValue.ToString(), DACASUCO_App.VuTrongID.ToString());
        }

        private void txt_SoPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Load_SoPhieu(txt_SoPhieu.Text);
                cmdNext.Visible = true;
            }
        }

        private void chk_MiaChay_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkMiachay.Checked)
            //{
            //   int MiaChay = 1;
            //    string sql = "Select * from QuyCheMiaChay";
            //    DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            //    int kt = 0;
            //    int theoccs = 0;
            //    try
            //    {
            //        kt = int.Parse(ds.Tables[0].Rows[0]["KhauTru"].ToString());
            //    }
            //    catch
            //    {
            //        kt = 0;
            //    }
            //    try
            //    {
            //        theoccs = int.Parse(ds.Tables[0].Rows[0]["MuaCCS"].ToString());
            //    }
            //    catch
            //    {
            //        theoccs = 0;
            //    }

            //    txtGiaMia.Text = (int.Parse(txtGiaMia.Text) - kt).ToString();

            //    //int GiaThuc = GiaMia - kt;
            //    //if (GiaThuc < 0) GiaThuc = 0;
            //    //txtKhauTru.Text = kt.ToString();
            //    //txtGiaMia.Text = GiaThuc.ToString();
            //    //if (theoccs == 1)
            //    //{
            //    //    rdCCS.Checked = true;
            //    //    rdCCS.Enabled = false;
            //    //    rdSo.Enabled = false;
            //    //}

            //}
            //else
            //{
            //    Load_SoPhieu(txt_SoPhieu.Text);

            //    //MiaChay = 0;
            //    //txtKhauTru.Text = "0";
            //    //txtGiaMia.Text = GiaMia.ToString();
            //    //rdCCS.Checked = false;
            //    //rdCCS.Enabled = true;
            //    //rdSo.Checked = true;
            //    //rdSo.Enabled = true; ;
            //}
        }

        private void txtTLTCTT_TextChanged(object sender, EventArgs e)
        {
            Tinh_Toan();
        }



    }
}