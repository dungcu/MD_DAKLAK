using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using Janus.Windows.GridEX;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.SCREventLog;
using CrystalDecisions.Shared;
using System.Globalization;
using System.Threading;
using DACASUCO.MDForms;
namespace MDSolution
{
    public partial class frmThuHoach : Form
    {

        static frmThuHoach _theformThuHoach;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmThuHoach OneInstanceFrm
        {
            get
            {
                if (null == _theformThuHoach || _theformThuHoach.IsDisposed)
                {
                    _theformThuHoach = new frmThuHoach();
                }

                return _theformThuHoach;
            }
        }
        //string[] arr_list = { "Vụ trồng", "Giống mía", "Tuổi ruộng mía", "Loại đất", "Đường vận chuyển" };
        //string[] arr_u_list = { "ut_VuTrong", "ut_GiongMia", "NgayTrong", "ut_LoaiDat", "ut_DuongVanChuyen" };

        int InGia = 1;
        int MuaTaiBanCan = 0;
        int MuaCCS = 0;
        int GiaMia = 0;
        int MiaChay = 0;
        int KhauTru = 0;
        string ThoiGian = "";
        string NgayGio = "";
        string[] arr_list = { "Gốc mía", "Giống mía", "Loại đất", "Vụ trồng" };
        string[] arr_u_list = { "ut_GocMia", "ut_GiongMia", "ut_LoaiDat", "ut_VuTrong" };

        string VuTrongID = MDSolution.DACASUCO_App.VuTrongID.ToString();

        // Dieu kien uu tien----------------
        string ThonID = "";
        string XaID = "";
        string TramID = "";

        string PhanQuyen_CacTramID = "";

        DataSet ds = null;
        //DataTable  rpt_dt = new DataTable();


        //----------------------------------
        public frmThuHoach()
        {
            InitializeComponent();
            LoadTramID_ForUserTram(); // phan quyen theo tram


        }

        private void LoadTramID_ForUserTram()
        {
            string strSQL = "Select CumID From sys_Roles_User_Cum Where UserID=" + DACASUCO_App.User.ID.ToString();
            DataSet ds2 = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                        PhanQuyen_CacTramID += ds2.Tables[0].Rows[i]["CumID"].ToString();
                    else
                        PhanQuyen_CacTramID += "," + ds2.Tables[0].Rows[i]["CumID"].ToString();
                }
            }
        }

        private void frmThuHoach_Load(object sender, EventArgs e)
        {
            //if ((DACASUCO_App.User.RolesID == 0) || (DACASUCO_App.User.RolesID == 2))
            //{
            //    cmdThem.Enabled = true;
            //}
            int widthScreen = Screen.PrimaryScreen.WorkingArea.Width;
            int heightScreen = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = widthScreen;
            this.Height = heightScreen;
            this.WindowState = FormWindowState.Maximized;
            Set_List(0);
            Load_List(5, false);
            //bgrWorker.RunWorkerAsync();
            Load_Tram();
            //LoadComboXe(TramUIComBo.Text);
            this.gridEX1.SetDataBinding(ds.Tables[0], "");
            dtNgay.Value = DateTime.Now;

        }


        private void Load_List(int TrangThai, bool TrangThaiKhac) // sử dụng để load thửa ruộng có trạng thái khác trạg thái khai báo
        {

            // Built Select and Table data souce
            string strSQL = "Select HoTen,MaHDDT,ID,DienTich,MiaVu,TenBai,TenGoi,TenXa,XaID,Tram,SoBanDieuTra,TenGiongMia,TenLoaiDat,DienTichPheCanh,NangSuatDuKien1,SanLuongDuKien1,NangSuatDuKien2,SanLuongDuKien2,SLLK,SCLK,NQL,HTKD,HTKDNQL,UserID,Stock FROM V_LenhChatMia  ";

            string strWhere = "WHERE VuTrongID= " + VuTrongID;

            if (XaID != "")
            {
                if (long.Parse(XaID) > 0)
                    strWhere += " AND XaID=" + XaID;
            }


            if (PhanQuyen_CacTramID != "")
            {
                strWhere += " And TramID in (" + PhanQuyen_CacTramID + ")";
            }

            if (TramID != "")
            {
                if (long.Parse(TramID) > 0)
                    strWhere += " AND TramID =" + TramID;
            }

            if (TrangThai > 0)
            {
                if (TrangThaiKhac == true)
                    strWhere += " AND TinhTrang=" + TrangThai;
                else
                    strWhere += " And TinhTrang<>" + TrangThai;
            }
            // Built Sort order by
            string strOrder = " order by ";

            for (int i = 0; i < arr_u_list.Length - 1; i++)
            {
                if (strOrder != " order by ")
                    strOrder += " DESC,";

                strOrder += arr_u_list[i];
            }

            strSQL = strSQL + strWhere + strOrder + " DESC";

            ds = null;
            try
            {
                ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            }
            catch
            {
                ds = null;
            }
            lblLoad.Visible = true;
            lblXong.Visible = true;
            prgBar2.Visible = true;
            prgBar.Visible = true;
            if (bgrWorker.IsBusy)
            {
                bgrWorker.CancelAsync();
            }
            else
            {
                bgrWorker.RunWorkerAsync();
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.dgList.DataSource = ds.Tables[0];
                this.gridEX1.DataSource = ds.Tables[0];
            }
            else
            {

                return;
            }

        }


        private void Set_List(int move)
        {
            int current_pos = list.SelectedIndex;
            if (move > 0)
            {
                if (current_pos >= 1)
                {
                    swap(current_pos, current_pos - 1);
                    list.SelectedIndex = current_pos - 1;
                }
            }
            else
                if (move < 0)
                {
                    if (current_pos < 3)
                    {
                        swap(current_pos, current_pos + 1);
                        list.SelectedIndex = current_pos + 1;
                    }
                    else
                    {
                        swap(current_pos, 0);
                        list.SelectedIndex = 0;
                    }
                }
            list.DataSource = null;
            list.DataSource = arr_list;

        }
        private void swap(int i, int j)
        {
            string temp = "";
            temp = arr_list[i];
            arr_list[i] = arr_list[j];
            arr_list[j] = temp;

            temp = arr_u_list[i];
            arr_u_list[i] = arr_u_list[j];
            arr_u_list[j] = temp;
        }

        private void cmdUp_Click(object sender, EventArgs e)
        {
            Set_List(1);
            Load_List(5, false);
            gridEX1.DataSource = ds.Tables[0];
            dgList.DataSource = ds.Tables[0];
        }

        private void cmdDown_Click(object sender, EventArgs e)
        {
            Set_List(-1);
            Load_List(5, false);
            gridEX1.DataSource = ds.Tables[0];
            dgList.DataSource = ds.Tables[0];
        }

        private void cmdDatTruoc_Click(object sender, EventArgs e)
        {
            //frmDinhMucSanLuong frm = new frmDinhMucSanLuong();
            //frm.ShowDialog();
        }



        private void cbXa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.LoadccbThon();
            XaID = cbXa.SelectedValue.ToString();
        }

        private void chkFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFilter.Checked)
            {
                cbXa.Visible = true;
                cbThon.Visible = true;

            }
            else
            {
                cbXa.Visible = false;
                cbThon.Visible = false;
                XaID = "";
                ThonID = "";

            }
        }

        private void cmdConfig_Click(object sender, EventArgs e)
        {
            string lselected = "";
            lselected = list.SelectedItem.ToString();
            switch (lselected)
            {
                case "Vụ trồng":
                    DACASUCO.MDDanhMuc.frmRaiVu frm1 = new DACASUCO.MDDanhMuc.frmRaiVu();
                    frm1.gdVDMTD.AllowEdit = InheritableBoolean.False; ;
                    frm1.gdVDMTD.AllowDelete = InheritableBoolean.False; ;
                    frm1.gdVDMTD.AllowAddNew = InheritableBoolean.False; ;
                    frm1.ShowDialog();
                    break;
                case "Giống mía":
                    DACASUCO.MDDanhMuc.frmGiongMia frm2 = new DACASUCO.MDDanhMuc.frmGiongMia();
                    frm2.gdVDMTD.AllowAddNew = InheritableBoolean.False; ;
                    frm2.gdVDMTD.AllowDelete = InheritableBoolean.False; ;
                    frm2.gdVDMTD.AllowEdit = InheritableBoolean.False; ;
                    frm2.ShowDialog();
                    break;

                case "Loại đất":
                    DACASUCO.MDDanhMuc.frmLoaiDat frm3 = new DACASUCO.MDDanhMuc.frmLoaiDat();
                    frm3.gdVDMTD.AllowAddNew = InheritableBoolean.False; ;
                    frm3.gdVDMTD.AllowDelete = InheritableBoolean.False;
                    frm3.gdVDMTD.AllowEdit = InheritableBoolean.False;
                    frm3.ShowDialog();
                    break;
                case "Gốc mía":
                    DACASUCO.MDDanhMuc.frmLoaiGoc frm4 = new DACASUCO.MDDanhMuc.frmLoaiGoc();
                    frm4.gdVDMTD.AllowAddNew = InheritableBoolean.False; ;
                    frm4.gdVDMTD.AllowDelete = InheritableBoolean.False;
                    frm4.gdVDMTD.AllowEdit = InheritableBoolean.False;
                    frm4.ShowDialog();
                    break;
                default:
                    MessageBox.Show("Điều kiện này không có thiết lập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }


        private void cmdChon_Click(object sender, EventArgs e)
        {
            // lay dinh muc cua tung don vi .
            frmStatus frmstatus = new frmStatus();
            frmstatus.TopMost = true;
            frmstatus.Show();
            frmstatus.Refresh();

            DataSet ds = null;
            string strSQL = "";
            //strSQL = "Select ThonID,Sum(sanluongdukien1) From tbl_ThuaRuong group by ThonID Having sum(sanluongdukien1)>0";
            strSQL = "Select tbl_hopdong.ThonID,Sum(sanluongdukien1) From tbl_ThuaRuong inner join tbl_hopdong on tbl_ThuaRuong.hopdongID = tbl_hopdong.ID group by tbl_hopdong.ThonID Having sum(sanluongdukien1)>0";
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                int items = ds.Tables[0].Rows.Count;
                //strSQL = "Select count(ID) from tbl_thon";
                //items = Convert.ToInt16(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null));
                double[] DinhMuc = new double[items];
                double[] TongDV = new double[items];

                // Kiem tra dinh muc voi san luong cua tung don vi.
                // pre-oder bugets
                if (optDatTruoc.Checked)
                {
                    //strSQL = "Select DinhMuc From tbl_Thon where ThonID in ( Select ThonID From tbl_ThuaRuong group by ThonID Having sum(sanluongdukien1)>0) order by ThonID";
                    strSQL = "Select DinhMuc From tbl_Thon where ThonID in (Select tbl_hopdong.ThonID From tbl_ThuaRuong inner join tbl_hopdong on tbl_ThuaRuong.hopdongID = tbl_hopdong.ID group by tbl_hopdong.ThonID Having sum(sanluongdukien1)>0) order by ThonID";
                    //DataSet ds = null;
                    ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                    items = ds.Tables[0].Rows.Count;
                    if (items > 0)
                    {
                        int i = 0;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            double dDM = 0;
                            try
                            {
                                dDM = double.Parse(dr["DinhMuc"].ToString());
                            }
                            catch
                            {
                                dDM = 0;
                            }
                            DinhMuc[i] = dDM;
                            i++;
                        }
                    }
                }

                // Phan bo deu
                if (optDeu.Checked)
                {
                    double lDinhMuc = 0;
                    try
                    {
                        lDinhMuc = long.Parse(txtDinhMuc.Text);
                    }
                    catch
                    {
                        lDinhMuc = 0;
                    }
                    for (int i = 0; i < items; i++)
                        DinhMuc[i] = lDinhMuc / items;
                }
                // If has any item selected then remove it

                dgList.UnCheckAllRecords();
                dgList.MoveFirst();
                // list field will break down
                string Thon = dgList.GetValue("ThonID").ToString();
                int arr_index = 0;
                for (int i = 0; i < dgList.RowCount; i++)
                {
                    long lSanLuong = 0;
                    try
                    {
                        lSanLuong = Convert.ToInt64(Math.Round(Convert.ToDouble(dgList.GetValue("SanLuongDuKien1").ToString())));
                    }
                    catch
                    {
                        lSanLuong = long.MaxValue;
                    }
                    if (dgList.GetValue("ThonID").ToString() != Thon)
                    {
                        arr_index++;
                        Thon = dgList.GetValue("ThonID").ToString();
                    }

                    if (lSanLuong + TongDV[arr_index] <= DinhMuc[arr_index] * 1000)
                    {
                        TongDV[arr_index] = lSanLuong + TongDV[arr_index];
                        dgList.SetValue("check", true);
                    }
                    dgList.MoveNext();
                }
            }
            frmstatus.Close();
        }

        private void uiTab1_Click(object sender, EventArgs e)
        {


            switch (uiTab1.SelectedTab.Index)
            {
                case 1:
                    // Dang thu hoach.
                    lblLoad.Visible = true;

                    XaUIComBo.Enabled = true;
                    Load_List(5, false);

                    gridEX1.DataSource = ds.Tables[0];
                    break;
                case 2:
                    // Da thu hoach xong.
                    lblXong.Visible = true;
                    XaUIComBo.Enabled = true;
                    Load_List(5, true);
                    gridEX2.DataSource = ds.Tables[0];

                    break;
                case 3:
                    XaUIComBo.Enabled = false;
                    chkChonNgay.Checked = true;
                    Load_PhieuDon();
                    break;
                default:
                    //Cho thu hoach
                    Load_List(3, true);
                    dgList.DataSource = ds.Tables[0];
                    break;
            }
        }

        private void chkFilter_Click(object sender, EventArgs e)
        {
            switch (uiTab1.SelectedTab.Index)
            {
                case 1:
                    // Dang thu hoach.

                    Load_List(5, false);
                    gridEX1.DataSource = ds.Tables[0];
                    break;
                case 2:
                    // Da thu hoach xong.
                    Load_List(5, true);
                    gridEX2.DataSource = ds.Tables[0];
                    break;
                default:
                    //Cho thu hoach
                    Load_List(1, true);
                    dgList.DataSource = ds.Tables[0];
                    break;
            }
        }

        private void cmd_doithuhoach_Click(object sender, EventArgs e)
        {
            int maxSoPhieu = 0;
            string strSQL = "SELECT max(SoPhieuChat) FROM tbl_ThuaRuong";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    maxSoPhieu = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    maxSoPhieu = 0;
                }
            }
            dgList.MoveFirst();
            for (int i = 0; i < dgList.RecordCount; i++)
            {

                if (dgList.GetValue("check").ToString() == "True")
                {
                    maxSoPhieu = maxSoPhieu + i;
                    string ID = dgList.GetValue("ID").ToString();
                    strSQL = "UPDATE tbl_ThuaRuong set SoPhieuChat = '" + maxSoPhieu.ToString() + "' ,TinhTrang=4 WHERE ID =" + ID;
                    MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                dgList.SetValue("SoPhieuChat", maxSoPhieu.ToString());
                dgList.MoveNext();
            }
            Load_List(3, true);
            gridEX1.DataSource = ds.Tables[0];
        }

        private void cmd_dathuhoach_Click(object sender, EventArgs e)
        {
            frmStatus frmstatus = new frmStatus();
            frmstatus.TopMost = true;
            frmstatus.Show();
            frmstatus.Refresh();

            //gridEX1.MoveFirst();
            //for (int i = 0; i < gridEX1.RecordCount; i++)
            //{
            //    if (gridEX1.GetValue("check").ToString() == "True")
            //    {
            //        string ID = gridEX1.GetValue("ID").ToString();
            //        string strSQL = "UPDATE tbl_ThuaRuong set TinhTrang=5 WHERE ID =" + ID;
            //        MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
            //    }
            //    gridEX1.MoveNext();
            //}
            string strSQL = "";
            foreach (GridEXRow jr in this.gridEX1.GetCheckedRows())
            {
                GridEXCell jc = jr.Cells["ID"];
                string ID = jc.Value.ToString();
                strSQL += "UPDATE tbl_ThuaRuong set TinhTrang=5 WHERE ID =" + ID;
            }
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
            Load_List(5, false);
            gridEX1.DataSource = ds.Tables[0];
            frmstatus.Close();
        }

        private void cmd_chuathuhoach_Click(object sender, EventArgs e)
        {
            frmStatus frmstatus = new frmStatus();
            frmstatus.TopMost = true;
            frmstatus.Show();
            frmstatus.Refresh();

            //gridEX1.MoveFirst();
            string strSQL = "";
            foreach (GridEXRow jr in this.gridEX1.GetCheckedRows())
            {
                GridEXCell jc = jr.Cells["ID"];
                string ID = jc.Value.ToString();
                strSQL += "UPDATE tbl_ThuaRuong set TinhTrang=3 WHERE ID =" + ID;
            }
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
            //for (int i = 0; i < gridEX1.RecordCount; i++)
            //{
            //    if (gridEX1.GetValue("check").ToString() == "True")
            //    {
            //        string ID = gridEX1.GetValue("ID").ToString();
            //        string strSQL = "UPDATE tbl_ThuaRuong set TinhTrang=3 WHERE ID =" + ID;

            //    }
            //    gridEX1.MoveNext();
            //}
            Load_List(5, true);
            gridEX1.DataSource = ds.Tables[0];
            frmstatus.Close();
        }

        private void cmdDoiThuHoach_Click(object sender, EventArgs e)
        {
            frmStatus frmstatus = new frmStatus();
            frmstatus.TopMost = true;
            frmstatus.Show();
            frmstatus.Refresh();
            string strSQL = "";
            foreach (GridEXRow jr in this.gridEX2.GetCheckedRows())
            {
                GridEXCell jc = jr.Cells["ID"];
                string ID = jc.Value.ToString();
                strSQL += "UPDATE tbl_ThuaRuong set TinhTrang=4 WHERE ID =" + ID;
            }
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
            Load_List(5, true);
            gridEX2.DataSource = ds.Tables[0];
            frmstatus.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long ID = 0;
            try
            {
                ID = long.Parse(this.gridEX1.GetValue("ID").ToString());
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn thửa ruộng để in phiếu đốn!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gridEX1.CurrentRow.IsChecked)
            {
                long PhieuDon = 0;
                try
                {
                    PhieuDon = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select Count(ThuaRuongID)  from BarCode where ThuaRuongID=" + ID.ToString() + " AND VutrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString(), null, null));
                }
                catch
                {
                    PhieuDon = 0;
                }
                double Stock = 0;
                try
                {
                    Stock = Math.Round(double.Parse(this.gridEX1.GetValue("Stock").ToString()), 0);
                }
                catch
                {
                    Stock = 0;
                }
                if (Stock <= PhieuDon)
                {
                    MessageBox.Show("Thửa ruộng đã cấp hết số lượng phiếu được phép!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cboXeVC.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn xe vận chuyển!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    cboXeVC.Focus();
                    return;
                }
                string HinhThuc = "";
                if (MuaTaiBanCan == 1) HinhThuc = "Mua tại bàn cân"; else HinhThuc = "Mua tại ruộng";
                string PhuongThuc = "";
                if (MuaCCS == 1) PhuongThuc = "Mua theo Chữ đường CCS"; else PhuongThuc = "Mua theo trọng lượng Mía sạch";
                string TT = "";
                if (MiaChay == 1) TT = "Mía cháy"; else TT = "Mía bình thường";
                frmConfirm frmOK = new frmConfirm(this.gridEX1.GetValue("HoTen").ToString(), HinhThuc, PhuongThuc, cboXeVC.Text, TT, txtGiaMia.Text);
                frmOK.ShowDialog();
                long OK = frmOK.OK;
                frmOK.Close();
                if (OK == 0)
                {
                    try
                    {

                        string sql = "Select Year(Getdate())";
                        string nam = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null);
                        sql = "Select datediff(s,'" + nam + "/01/01'" + ",convert(char(20),getdate(),120)) as TG,convert(char(20),GetDate(),120) as NgayThang";
                        DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                        ThoiGian = ds.Tables[0].Rows[0]["TG"].ToString();
                        NgayGio = ds.Tables[0].Rows[0]["NgayThang"].ToString();
                        int Chieudai = (8 - ThoiGian.Length);
                        for (int j = 0; j < Chieudai; j++)
                        {
                            ThoiGian = "0" + ThoiGian;
                        }

                        sql = "Select HopDongVanChuyenID from tbl_XeVanChuyen Where ID= " + cboXeVC.SelectedValue.ToString() + " AND NKT is NULL";
                        int HDVCID = int.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null));
                        sql = "Insert Into BarCode (ThuaRuongID,ThoiGian,UserID,VuTrongID,SoXe,MuaTaiBanCan,InGia,DaCan,GiaMia,MuaCCS,HopDongVanChuyenID,XeID,NgayGio,MiaChay) Values(" +
                        ID.ToString() + ",N'" + ThoiGian + "'," + DACASUCO_App.User.ID.ToString() + "," + MDSolution.DACASUCO_App.VuTrongID.ToString() +
                        ",N'" + cboXeVC.Text + "'," + MuaTaiBanCan.ToString() + "," + InGia.ToString() + ",0," + txtGiaMia.Text + "," + MuaCCS.ToString() + "," + HDVCID.ToString() + "," + cboXeVC.SelectedValue.ToString() + ",'" + NgayGio + "'," + MiaChay.ToString() + ")";

                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    }
                    catch
                    {
                        MessageBox.Show("Đã có lỗi xảy ra! Bạn thực hiện lại lệnh In phiếu!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string rptitle = "";
                    DACASUCO.MDForms.frmShowRP2 frm = new DACASUCO.MDForms.frmShowRP2();
                    DACASUCO.MDReport.PhieuChatMia rp = new DACASUCO.MDReport.PhieuChatMia();

                    rp.RecordSelectionFormula = "{ V_PhieuChatMia.ThuaRuongID}=" + this.gridEX1.GetValue("ID").ToString() + " AND { V_PhieuChatMia.ThoiGian}='" + ThoiGian + "' AND { V_PhieuChatMia.VuTrongID}=" + MDSolution.DACASUCO_App.VuTrongID.ToString(); //RecordSelect;
                    if (MiaChay == 1)
                    {
                        rp.SetParameterValue("TT", "Ghi chú: MÍA CHÁY");
                    }
                    else
                    {
                        rp.SetParameterValue("TT", "");
                    }
                    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                    frm.RP = rp;

                    frm.RPtitle = rptitle;
                    frm.Show();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn thửa ruộng cần in phiếu!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void optDatTruoc_CheckedChanged(object sender, EventArgs e)
        {
            if (optDatTruoc.Checked) cmdDatTruoc.Visible = true;
            else cmdDatTruoc.Visible = false;
        }

        private void optDeu_CheckedChanged(object sender, EventArgs e)
        {
            if (optDatTruoc.Checked) cmdDatTruoc.Visible = true;
            else cmdDatTruoc.Visible = false;
        }



        private void cmd_ViewAll_Click(object sender, EventArgs e)
        {
            // lay dinh muc cua tung don vi .
            DataSet ds = null;
            string strSQL = "";

            strSQL = " Select id ,HoTen, MaHopDong,ID,DienTich,SanLuongDuKien1,MiaVu, DiaDiem, Thon,ThonID, XaID,tt,SoPhieuChat" +
                         " FROM V_LenhChatMia " +
                         " Where SanLuongDuKien1 > 0 and TinhTrang = 3";


            // Built Sort order by
            string strOrder = " order by ";

            for (int i = 0; i < arr_u_list.Length - 1; i++)
            {
                if (strOrder != " order by ")
                    strOrder += ",";

                strOrder += arr_u_list[i];
            }

            strSQL = strSQL + strOrder;

            ds = null;
            try
            {
                ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            }
            catch
            {
                ds = null;
            }

            dgList.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmStatus frmstatus = new frmStatus();
            frmstatus.TopMost = true;
            frmstatus.Show();
            frmstatus.Refresh();

            int maxSoPhieu = 0;
            string strSQL = "SELECT max(SoPhieuChat) FROM tbl_ThuaRuong";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    maxSoPhieu = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    maxSoPhieu = 0;
                }
            }
            strSQL = "";
            int i = 1;
            foreach (GridEXRow jr in this.dgList.GetCheckedRows())
            {
                GridEXCell jc = jr.Cells["ID"];
                maxSoPhieu = maxSoPhieu + i;
                string ID = jc.Value.ToString();
                strSQL += " UPDATE tbl_ThuaRuong set SoPhieuChat = '" + maxSoPhieu.ToString() + "' ,TinhTrang=4 WHERE ID =" + ID;
                dgList.SetValue("SoPhieuChat", maxSoPhieu.ToString());
            }
            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);

            double TongSanLuong = clsThuaRuong.TongSanLuong1(VuTrongID, null, null) / 1000;
            double TongSanLuongConLai = clsThuaRuong.TongSanLuongConLai1(VuTrongID, null, null) / 1000;
            double DaThu = TongSanLuong - TongSanLuongConLai;
            double curBar = 100;
            if (TongSanLuong > 0)
            {
                curBar = ((TongSanLuong - TongSanLuongConLai) / TongSanLuong) * 100;
            }
            prgSanLuong.Maximum = 100;
            prgSanLuong.Value = 100 - int.Parse(Math.Floor(curBar).ToString());
            lblTongSL.Text = "Tổng dự kiến:" + TongSanLuong.ToString() + "(Tấn)";
            lblTiLe.Text = "Tỉ lệ thu:" + int.Parse(Math.Floor(curBar).ToString()).ToString() + "%";
            calenDenNgay.Value = calenTuNgay.Value.AddDays(7);
            Load_List(3, true);
            frmstatus.Close();

        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblLoad.Visible = true;
                lblXong.Visible = true;
                if (TramUIComBo.SelectedValue != null)
                    Load_Xa(TramUIComBo.SelectedValue.ToString());
                cboXeVC.Text = "";
                LoadComboXe(TramUIComBo.Text);

                TramID = TramUIComBo.SelectedValue.ToString();
                XaID = "";
                //ThonID = "";
                if (uiTabPage2.Selected == true)
                {
                    Load_List(5, false);
                    gridEX1.DataSource = ds.Tables[0];
                }
                else if (uiTabPage3.Selected == true)
                {
                    Load_List(5, true);
                    gridEX2.DataSource = ds.Tables[0];
                }
                else if (uiTabPage4.Selected == true)
                {
                    Load_PhieuDon();
                }
            }
            catch
            { }
        }

        private void LoadComboXe(string Tram)
        {
            string sql = "Select ID,SoXe from tbl_XeVanChuyen Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            if (Tram != "")
            {
                sql = "Select ID,SoXe from tbl_XeVanChuyen where NKT is NULL AND TramID=(Select ID from tbl_Cum where Ten=N'" + Tram + "') AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " Order by SoXe";
            }
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboXeVC.DataSource = ds.Tables[0];
                DataRow oR = ds.Tables[0].NewRow();
                oR["ID"] = 0;
                oR["SoXe"] = "";
                ds.Tables[0].Rows.InsertAt(oR, 0);
                cboXeVC.ValueMember = "ID";
                cboXeVC.DisplayMember = "SoXe";

            }
            else
            {
                cboXeVC.DataSource = null;
            }
        }
        private void Load_Tram()
        {
            string sql = "Select ID,Ten From tbl_TramNongVu Where 1= 1";
            if (PhanQuyen_CacTramID != "")
                sql += " And ID in(" + PhanQuyen_CacTramID + ")";

            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            TramUIComBo.DisplayMember = "Ten";
            TramUIComBo.ValueMember = "ID";
            TramUIComBo.DataSource = ds.Tables[0];
        }

        private void Load_Xa(string tramID)
        {
            string sql = "Select ID,Ten From tbl_Xa Where CumID =" + tramID;
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);

            XaUIComBo.DisplayMember = "Ten";
            XaUIComBo.ValueMember = "ID";
            XaUIComBo.DataSource = ds.Tables[0];
        }

        private void XaUIComBo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblLoad.Visible = true;
            lblXong.Visible = true;
            XaID = XaUIComBo.SelectedValue.ToString();
            TramID = "";
            if (uiTabPage2.Selected == true)
            {
                Load_List(5, false);
                if (ds != null)
                {
                    gridEX1.DataSource = ds.Tables[0];
                }
            }
            else if (uiTabPage3.Selected == true)
            {
                Load_List(5, true);
                if (ds != null)
                {
                    gridEX2.DataSource = ds.Tables[0];
                }
            }
            else if (uiTabPage4.Selected)
            {
                Load_PhieuDon();
            }
        }


        private void gridEX1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gridEX1.DataSource != null)
            {
                try
                {
                    long ID = long.Parse(this.gridEX1.GetValue("ID").ToString());
                    if (ID > 0)
                    {
                        gridEX1.UnCheckAllRecords();
                        gridEX1.CurrentRow.IsChecked = true;
                        GiaMia = int.Parse(LoadGiaMia(this.gridEX1.GetValue("MaHDDT").ToString()).ToString());
                        txtGiaMia.Text = GiaMia.ToString();
                        rdSo.Checked = true;
                        rdSo.Enabled = true;
                        rdCCS.Checked = false;
                        rdCCS.Enabled = true;
                        rdTaiRuong.Checked = true;
                        chkMiachay.Checked = false;
                        KhauTru = 0;
                        MiaChay = 0;
                        txtKhauTru.Text = KhauTru.ToString();
                        //string sql = "Select Tram from V_LenhChatMia where ID=" + ID.ToString();
                        //DataSet ds1 = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                        LoadComboXe(this.gridEX1.GetValue("Tram").ToString());
                        cboXeVC.SelectedIndex = 0;
                        chkGia.Checked = true;
                    }
                }
                catch
                {
                }
            }
        }



        private void chkGia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGia.Checked)
            {
                InGia = 1;
            }
            else
            {
                InGia = 0;
            }
        }

        private void rdTaiRuong_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTaiRuong.Checked)
            {
                MuaTaiBanCan = 0;
            }
            else
            {
                MuaTaiBanCan = 1;
            }
        }

        private void rdBanCan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBanCan.Checked)
            {
                MuaTaiBanCan = 1;
            }
            else
            {
                MuaTaiBanCan = 0;
            }
        }
        private int LoadGiaMia(string MaHDDT)
        {
            int Gia = 0;
            if (MaHDDT != "")
            {
                string sql = "Select MaHDDT,NgayApDung,GioApDung,Gia from tbl_GiaMiaCaBiet Where LTrim(RTrim(MaHDDT))='" + MaHDDT + "' AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " Order by NgayApDung DESC";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string ngay = MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select Convert(char(20),GetDate(),120)", null, null);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DateTime st = DateTime.Parse(dr["NgayApDung"].ToString());
                        string ngay2 = String.Format("{0:MM/dd/yyyy}", st);
                        string sr = "Select datediff(hh,'" + ngay + "',dateadd(hh," + dr["GioApDung"].ToString() + ",convert(char(10),'" + ngay2 + "',121)))";
                        int TG = int.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sr, null, null));
                        if (TG <= 0)
                        {
                            Gia = int.Parse(dr["Gia"].ToString());
                            break;
                        }
                    }
                }
                else
                {


                    sql = "Select Ngay_Ap_Dung,Gio_Ap_Dung,Gia_Mua_Mia from tbl_Gia_Mia_Theo_Tram_Nong_Vu Where Tram_Nong_Vu_ID= (Select TramNongVuID from tbl_ThuaRuong  where ID=" + this.gridEX1.GetValue("ID").ToString() + ") AND vu_trong_id=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " Order by Ngay_Ap_Dung DESC";
                    ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string ngay = MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select Convert(char(20),GetDate(),120)", null, null);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            DateTime st = DateTime.Parse(dr["Ngay_Ap_Dung"].ToString());
                            string ngay2 = String.Format("{0:MM/dd/yyyy}", st);
                            string sr = "Select datediff(hh,'" + ngay + "',dateadd(hh," + dr["Gio_Ap_Dung"].ToString() + ",convert(char(10),'" + ngay2 + "',121)))";
                            int TG = int.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sr, null, null));
                            if (TG <= 0)
                            {
                                Gia = int.Parse(dr["Gia_Mua_Mia"].ToString());
                                break;
                            }
                        }
                    }
                }

            }
            return Gia;

        }

        private void rdSo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSo.Checked)
            {
                MuaCCS = 0;
            }
            else
            {
                MuaCCS = 1;
            }
        }

        private void rdCCS_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCCS.Checked)
            {
                MuaCCS = 1;
            }
            else
            {
                MuaCCS = 0;
            }
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
        }

        private void gridEX1_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "Status")
            {
                long UserID = long.Parse(this.gridEX1.GetValue("UserID").ToString());
                if (DACASUCO_App.User.ID != UserID)
                {
                    if ((DACASUCO_App.User.RolesID != 0) && (DACASUCO_App.User.RolesID != 2))
                    {
                        clsUser oU = new clsUser(UserID);
                        oU.Load(null, null);
                        MessageBox.Show("Thửa ruộng này do " + oU.HoTen + " quản lý!" + "\nBạn không được quyền thiết lập hiện trạng cho thửa ruộng này", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if ((DACASUCO_App.User.ID == UserID) || (DACASUCO_App.User.RolesID == 0) || (DACASUCO_App.User.RolesID == 2))
                {
                    if (MessageBox.Show("Bạn chắc chắn thiết lập cho thửa ruộng này đã thu hoạch xong?", "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            MDSolutionEntities.DBModule.ExecuteQuery("Update tbl_ThuaRuong Set TinhTrang=5 Where ID=" + this.gridEX1.GetValue("ID").ToString(), null, null);
                            MessageBox.Show("Đã thiết lập thành công!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Load_List(5, false);

                        }

                        catch
                        {
                            MessageBox.Show("Đã có lỗi xảy ra!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void gridEX2_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {

            if (e.Column.Key == "Status")
            {
                if ((DACASUCO_App.User.RolesID == 0) || (DACASUCO_App.User.RolesID == 2))
                {
                    if (MessageBox.Show("Bạn chắc chắn thiết lập cho thửa ruộng này được tiếp tục thu hoạch?", "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            string sql = "Update tbl_ThuaRuong Set TinhTrang=4 Where ID=" + this.gridEX2.GetValue("ID").ToString();
                            MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            MessageBox.Show("Đã thiết lập thành công!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Load_List(5, true);
                            gridEX2.DataSource = ds.Tables[0];
                        }

                        catch
                        {
                            MessageBox.Show("Đã có lỗi xảy ra!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn không được quyền sử dụng chức năng này", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (uiTabPage2.Selected == true)
            {
                Janus.Windows.GridEX.GridEXFilterCondition con = new Janus.Windows.GridEX.GridEXFilterCondition();
                if (rdChuMia.Checked)
                {
                    con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(gridEX1.RootTable.Columns["HTKD"], Janus.Windows.GridEX.ConditionOperator.Contains, txtTimKiem.Text));

                }
                if (rdNQL.Checked)
                {
                    con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(gridEX1.RootTable.Columns["HTKDNQL"], Janus.Windows.GridEX.ConditionOperator.Contains, txtTimKiem.Text));
                }

                gridEX1.RootTable.ApplyFilter(con);
            }
            else if (uiTabPage3.Selected == true)
            {
                Janus.Windows.GridEX.GridEXFilterCondition con = new Janus.Windows.GridEX.GridEXFilterCondition();
                if (rdChuMia.Checked)
                {
                    con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(gridEX2.RootTable.Columns["HTKD"], Janus.Windows.GridEX.ConditionOperator.Contains, txtTimKiem.Text));

                }
                if (rdNQL.Checked)
                {
                    con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(gridEX2.RootTable.Columns["HTKDNQL"], Janus.Windows.GridEX.ConditionOperator.Contains, txtTimKiem.Text));
                }

                gridEX2.RootTable.ApplyFilter(con);
            }
            else if (uiTabPage4.Selected == true)
            {
                Janus.Windows.GridEX.GridEXFilterCondition con = new Janus.Windows.GridEX.GridEXFilterCondition();
                if (rdChuMia.Checked)
                {
                    con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(grdLenhDon.RootTable.Columns["HTKD"], Janus.Windows.GridEX.ConditionOperator.Contains, txtTimKiem.Text));

                }
                if (rdNQL.Checked)
                {
                    con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(grdLenhDon.RootTable.Columns["HTKDNQL"], Janus.Windows.GridEX.ConditionOperator.Contains, txtTimKiem.Text));
                }

                grdLenhDon.RootTable.ApplyFilter(con);
            }

        }
        private void Load_PhieuDon()
        {
            string Ngay = "'" + dtNgay.Value.ToString("yyyy-MM-dd") + "'";
            string CuoiNgay = "'" + dtNgay.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
            string Nam = dtNgay.Value.Year.ToString();
            string sql = "SELECT dbo.sys_User.ID as UserID,dbo.BarCode.ID, dbo.BarCode.MiaChay,dbo.BarCode.NgayGio, dbo.sys_User.HoTen AS NQL, dbo.tbl_HopDong.HoTen AS ChuMia, " +
                     "dbo.BarCode.MuaTaiBanCan, dbo.BarCode.SoXe, dbo.BarCode.MuaCCS, dbo.BarCode.GiaMia, dbo.BoDauTiengViet(dbo.sys_User.HoTen) AS HTKDNQL, dbo.BoDauTiengViet(dbo.tbl_HopDong.HoTen) AS HTKD, dbo.BarCode.DaCan, dbo.tbl_BaiTapKet.TenBai" +
                       " FROM  dbo.sys_User INNER JOIN  dbo.BarCode ON dbo.sys_User.ID = dbo.BarCode.UserID INNER JOIN  dbo.tbl_ThuaRuong ON dbo.BarCode.ThuaRuongID = dbo.tbl_ThuaRuong.ID INNER JOIN dbo.tbl_HopDong ON dbo.tbl_ThuaRuong.HopDongID = dbo.tbl_HopDong.ID INNER JOIN " +
                     " dbo.tbl_BaiTapKet ON dbo.tbl_ThuaRuong.BaiTapKetID = dbo.tbl_BaiTapKet.ID Where dbo.BarCode.VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            if (chkChonNgay.Checked)
            {
                sql += " AND dbo.BarCode.NgayGio>=" + Ngay + " AND dbo.BarCode.NgayGio<=" + CuoiNgay;
            }
            if (XaID != "")
            {
                if (long.Parse(XaID) > 0)
                    sql += " AND dbo.tbl_ThuaRuong.ThonID=" + XaID;
            }


            if (PhanQuyen_CacTramID != "")
            {
                sql += " And dbo.tbl_ThuaRuong.TramNongVuID in (" + PhanQuyen_CacTramID + ")";
            }

            if (TramID != "")
            {
                if (long.Parse(TramID) > 0)
                    sql += " AND dbo.tbl_ThuaRuong.TramNongVuID =" + TramID;
            }
            prgBar3.Visible = true;
            lblLoadding.Visible = true;
            if (bgrWorker.IsBusy)
            {
                bgrWorker.CancelAsync();
            }
            else
            {
                bgrWorker.RunWorkerAsync();
            }
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.grdLenhDon.DataSource = ds.Tables[0];
                //this.gridEX1.DataSource = ds.Tables[0];
            }
            else
            {
                this.grdLenhDon.DataSource = null;
            }
        }

        private void dtNgay_ValueChanged(object sender, EventArgs e)
        {
            chkChonNgay.Checked = true;
            Load_PhieuDon();
        }

        private void grdLenhDon_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "Cancel")
            {
                if (long.Parse(this.grdLenhDon.GetValue("DaCan").ToString()) == 0)
                {
                    if ((DACASUCO_App.User.ID) != long.Parse(this.grdLenhDon.GetValue("UserID").ToString()))
                    {
                        MessageBox.Show("Bạn không thể hủy lệnh đốn!" + "\nLệnh đốn này do " + this.grdLenhDon.GetValue("NQL").ToString() + " lập", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    long Lenh = long.Parse(this.grdLenhDon.GetValue("ID").ToString());
                    if (MessageBox.Show("Bạn chắc chắn hủy lệnh đốn số " + Lenh.ToString() + " ?", "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            string sql = "Delete from BarCode Where ID=" + Lenh.ToString();
                            MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            MessageBox.Show("Đã hủy phiếu thành công!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Load_PhieuDon();
                        }

                        catch
                        {
                            MessageBox.Show("Đã có lỗi xảy ra!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Phiếu đã cân không hủy được!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            if (e.Column.Key == "Print")
            {
                string ID = this.grdLenhDon.GetValue("ID").ToString();
                if (ID != "")
                {
                    string rptitle = "In lệnh đốn";
                    DACASUCO.MDForms.frmShowRP2 frm = new DACASUCO.MDForms.frmShowRP2();
                    DACASUCO.MDReport.PhieuChatMia rp = new DACASUCO.MDReport.PhieuChatMia();
                    rp.RecordSelectionFormula = "{V_PhieuChatMia.ID}=" + ID + " AND {V_PhieuChatMia.VuTrongID}=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                    long ChayMia = 0;
                    try
                    {
                         ChayMia = long.Parse(this.grdLenhDon.GetValue("MiaChay").ToString());
                    }
                    catch { }

                    if (ChayMia == 1)
                    {
                        rp.SetParameterValue("TT", "Ghi chú: MÍA CHÁY");
                    }
                    else
                    {
                        rp.SetParameterValue("TT", "");
                    }
                    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                    frm.RP = rp;
                    frm.RPtitle = rptitle;
                    frm.Show();
                }
            }            
            
        }


        private void bgrWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (uiTab1.SelectedTab.Index == 3)
                {
                    Thread.Sleep(10);
                }
                else
                {
                    Thread.Sleep(20);
                }
                bgrWorker.ReportProgress(i);

            }
        }

        private void bgrWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgBar.Value = e.ProgressPercentage;
            prgBar2.Value = e.ProgressPercentage;
            prgBar3.Value = e.ProgressPercentage;
            if (prgBar.Value == 100)
            {

                lblLoad.Visible = false;
                prgBar.Visible = false;
            }
            if (prgBar2.Value == 100)
            {

                lblXong.Visible = false;
                prgBar2.Visible = false;
            }
            if (prgBar3.Value == 100)
            {
                prgBar3.Visible = false;
                lblLoadding.Visible = false;
            }

        }

        private void chkMiachay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMiachay.Checked)
            {
                MiaChay = 1;
                string sql = "Select * from QuyCheMiaChay";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                int kt = 0;
                int theoccs = 0;
                try
                {
                    kt = int.Parse(ds.Tables[0].Rows[0]["KhauTru"].ToString());
                }
                catch
                {
                    kt = 0;
                }
                try
                {
                    theoccs = int.Parse(ds.Tables[0].Rows[0]["MuaCCS"].ToString());
                }
                catch
                {
                    theoccs = 0;
                }
                int GiaThuc = GiaMia - kt;
                if (GiaThuc < 0) GiaThuc = 0;
                txtKhauTru.Text = kt.ToString();
                txtGiaMia.Text = GiaThuc.ToString();
                if (theoccs == 1)
                {
                    rdCCS.Checked = true;
                    rdCCS.Enabled = false;
                    rdSo.Enabled = false;
                }

            }
            else
            {
                MiaChay = 0;
                txtKhauTru.Text = "0";
                txtGiaMia.Text = GiaMia.ToString();
                rdCCS.Checked = false;
                rdCCS.Enabled = true;
                rdSo.Checked = true;
                rdSo.Enabled = true; ;
            }
        }

        private void chkChonNgay_CheckedChanged(object sender, EventArgs e)
        {
            Load_PhieuDon();
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            long ID = 0;
            try
            {
                ID = long.Parse(this.gridEX1.GetValue("ID").ToString());
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn thửa ruộng cần thêm phiếu", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ID > 0)
            {
                double DT = 0;
                try
                {
                    DT = Math.Round(double.Parse(this.gridEX1.GetValue("DienTich").ToString()), 1);
                }
                catch
                {
                    DT = 0;
                }

                double SLDK = 0;
                try
                {
                    SLDK = Math.Round(double.Parse(this.gridEX1.GetValue("SanLuongDuKien2").ToString()), 1);
                }
                catch
                {
                    SLDK = 0;
                }
                double Stock = 0;
                try
                {
                    Stock = Math.Round(double.Parse(this.gridEX1.GetValue("Stock").ToString()), 0);
                }
                catch
                {
                    Stock = 0;
                }
                double SLLK = 0;
                try
                {
                    SLLK = Math.Round(double.Parse(this.gridEX1.GetValue("SLLK").ToString()), 1);
                }
                catch
                {
                    SLLK = 0;
                }
                frmAdd_Phieu frm = new frmAdd_Phieu(this.gridEX1.GetValue("HoTen").ToString(), DT.ToString(), SLDK.ToString(), Stock.ToString(), SLLK.ToString());
                frm.ID = ID;
                frm.ShowDialog();
                if (frm.OK == 1)
                {
                    Load_List(5, false);
                }
            }

        }

        private void cmdInfor_Click(object sender, EventArgs e)
        {
            long ID = 0;
            try
            {
                ID = long.Parse(this.gridEX1.GetValue("ID").ToString());
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn thửa ruộng cần xem thông tin", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ID > 0)
            {
                double DT = 0;
                try
                {
                    DT = Math.Round(double.Parse(this.gridEX1.GetValue("DienTich").ToString()), 1);
                }
                catch
                {
                    DT = 0;
                }

                int SPThem = 0;
                try
                {
                    SPThem = int.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select PhieuThem from tbl_ThuaRuong Where ID=" + ID.ToString(), null, null));
                }
                catch
                {
                    SPThem = 0;
                }
                double Stock = 0;
                try
                {
                    Stock = Math.Round(double.Parse(this.gridEX1.GetValue("Stock").ToString()), 0);
                }
                catch
                {
                    Stock = 0;
                }
                double SPKH = Stock - SPThem;
                int SPDaCap = 0;
                try
                {
                    SPDaCap = int.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select count(ID) from BarCoDe Where ThuaRuongID=" + ID.ToString(), null, null));
                }
                catch
                {
                    SPDaCap = 0;
                }
                int SPSuDung = 0;
                try
                {
                    SPSuDung = int.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select count(ID) from BarCoDe Where ThuaRuongID=" + ID.ToString() + " And DaCan=1", null, null));
                }
                catch
                {
                    SPSuDung = 0;
                }
                frmAdd_Phieu_Infor frm = new frmAdd_Phieu_Infor(this.gridEX1.GetValue("HoTen").ToString(), DT.ToString(), SPKH.ToString(), SPThem.ToString(), SPDaCap.ToString(), SPSuDung.ToString());
                frm.ShowDialog();
            }
        }

        private void cmdInforTHX_Click(object sender, EventArgs e)
        {
            long ID = 0;
            try
            {
                ID = long.Parse(this.gridEX2.GetValue("ID").ToString());
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn thửa ruộng cần xem thông tin", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ID > 0)
            {
                double DT = 0;
                try
                {
                    DT = Math.Round(double.Parse(this.gridEX2.GetValue("DienTich").ToString()), 1);
                }
                catch
                {
                    DT = 0;
                }

                int SPThem = 0;
                try
                {
                    SPThem = int.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select PhieuThem from tbl_ThuaRuong Where ID=" + ID.ToString(), null, null));
                }
                catch
                {
                    SPThem = 0;
                }
                double Stock = 0;
                try
                {
                    Stock = Math.Round(double.Parse(this.gridEX2.GetValue("Stock").ToString()), 0);
                }
                catch
                {
                    Stock = 0;
                }
                double SPKH = Stock - SPThem;
                int SPDaCap = 0;
                try
                {
                    SPDaCap = int.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select count(ID) from BarCoDe Where ThuaRuongID=" + ID.ToString(), null, null));
                }
                catch
                {
                    SPDaCap = 0;
                }
                int SPSuDung = 0;
                try
                {
                    SPSuDung = int.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select count(ID) from BarCoDe Where ThuaRuongID=" + ID.ToString() + " And DaCan=1", null, null));
                }
                catch
                {
                    SPSuDung = 0;
                }
                frmAdd_Phieu_Infor frm = new frmAdd_Phieu_Infor(this.gridEX2.GetValue("HoTen").ToString(), DT.ToString(), SPKH.ToString(), SPThem.ToString(), SPDaCap.ToString(), SPSuDung.ToString());
                frm.ShowDialog();
            }
        }

        private void cboXeVC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




    }
}