using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using DACASUCO.MDForms;
using DACASUCO.MDDataSetForms;
using MDSolution;
using MDSolutionEntities;


namespace MDSolution
{
    public partial class frmDanhSachCacKhoanHoTro : Form
    {
        static frmDanhSachCacKhoanHoTro _theformDanhSachCacKhoanHoTro;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmDanhSachCacKhoanHoTro OneInstanceFrm
        {
            get
            {
                if (null == _theformDanhSachCacKhoanHoTro || _theformDanhSachCacKhoanHoTro.IsDisposed)
                {
                    _theformDanhSachCacKhoanHoTro = new frmDanhSachCacKhoanHoTro();
                }

                return _theformDanhSachCacKhoanHoTro;
            }
        }
        
        MDDataSetForms.frmNhapHoTro frmNhaphotro;
        private NodeDonVi nDonVi = new NodeDonVi();
        
        private DataSet gridDataSource;

        private DataSet gridDataSourceGridEX2;

        private DataSet gridThonSource;


        private DataSet DDLTram;
        private DataSet DDLGiong;
        private DataSet DDLLoaiDat;
        private DataSet DDLRaiVu;
        private DataSet DDLMucDichTrong;

        private string ThuaRuongID_ = "";
        private clsHoTro oHT = new clsHoTro();
        private DataSet ddlDanhMucHoTroSource;
        public frmDanhSachCacKhoanHoTro()
        {
            InitializeComponent();
                     
            this.LoadDDLDanhMucHoTroGridHoTro();
            CommonClass.loadTreeDonVi(treeDonVi);
            LoadDDLDanhMucHoTroGridHoTro();
            LoadThonSource();
            LoadDropDownTram();
            loadDDLLoaiDat();
            LoadDDLGiong();
            LoadDDLMucDichTrong();
            //LoadDDLRaiVu();
            LoadKieuTrong();
        }
        public frmDanhSachCacKhoanHoTro(string ID)
        {
            InitializeComponent();
            CommonClass.loadTreeDonVi(treeDonVi);
            LoadHopDong1(ID);
            LoadDDLDanhMucHoTroGridHoTro();

            LoadThonSource();
            LoadDropDownTram();
            loadDDLLoaiDat();
            LoadDDLGiong();
            LoadDDLMucDichTrong();
            //LoadDDLRaiVu();
            LoadKieuTrong();

        }

        private void loadDDLLoaiDat()
        {
            string strSQL = "Select * from tbl_LoaiDat";
            DDLLoaiDat = DBModule.ExecuteQuery(strSQL, null, null);
            this.grdHopDong.DropDowns["DDLLoaiDat"].SetDataBinding(DDLLoaiDat.Tables[0], "");
        }

        private void LoadDropDownTram()
        {
            string strSQL = "SELECT * from tbl_TramNongVu";
            DDLTram = DBModule.ExecuteQuery(strSQL, null, null);
            this.grdHopDong.DropDowns["DDLTram"].SetDataBinding(DDLTram.Tables[0], "");
        }

        private void LoadDDLGiong()
        {
            string strSQL = "Select * from tbl_GiongMia";
            DDLGiong = DBModule.ExecuteQuery(strSQL, null, null);
            this.grdHopDong.DropDowns["DDLGiong"].SetDataBinding(DDLGiong.Tables[0], "");
        }

        //private void LoadDDLRaiVu()
        //{
        //    //string str = "Select * from tbl_RaiVu";
        //    DataSet ds;
        //    ds = clsRaiVu.GetListbyWhere("", "", "", null, null);
        //    this.grdHopDong.DropDowns["DDLRaiVu"].SetDataBinding(ds, "");
        //}

        private void LoadDDLMucDichTrong()
        {
            DataSet ds;
            ds = clsMucDichTrong.GetListbyWhere("", "", "", null, null);
            this.grdHopDong.DropDowns["DDLMucDich"].SetDataBinding(ds.Tables[0], "");
        }

        private void LoadKieuTrong()
        {
            DataSet ds;
            ds = clsKieuTrong.GetListbyWhere("", "", "", null, null);
            this.grdHopDong.DropDowns["DDLKieuTrong"].SetDataBinding(ds.Tables[0], "");
        }

        private void LoadHopDong1(string ID)
        {
            DataSet ds;
            string strSQL = "SELECT * FROM tbl_HopDong WHERE ParentID=0 AND ID=" + ID.ToString();
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables.Count > 0)
            {
                this.grdHopDong.SetDataBinding(ds.Tables[0], "");
            }
        }
        private DataSet LoadBanDieuTra()
        {
            string strSQL = "";
            strSQL = @"SELECT a.*,a.DienTich/10000 as DienTich1,b.MaHopDong as MaHD,b.HoTen as HoTen, b.ThonID as ThonID,c.Ten as TenThon 
                        FROM tbl_thuaruong as a LEFT JOIN tbl_HopDong as b ON a.HopDongID = b.ID LEFT JOIN tbl_Thon as c ON b.ThonID=c.ID 
                        WHERE (a.VuTrongID = " + DACASUCO_App.VuTrongID.ToString() + ") AND (a.TrangThaiDangKy = 0 OR a.TrangThaiDangKY IS NULL)";
            switch (nDonVi.Type)
            {
                case DonviTypeHD.Cum: strSQL += " AND b.ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID IN (SELECT ID FROM tbl_Xa WHERE CumID =" + nDonVi.DonViID + "))"; break;
                case DonviTypeHD.Xa: strSQL += " AND b.ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviTypeHD.Thon: strSQL += " AND a.ThonID=" + nDonVi.DonViID; break;
                default: break;
            }
            if ((this.chkTimkiemchinhxac.Checked) && (edtTimKiem.Text != ""))
            {
                strSQL += " AND (b.MaHopDong = N'" + DBModule.RefineString(edtTimKiem.Text) + "' OR b.HoTen = N'" + DBModule.RefineString(edtTimKiem.Text) + "' OR a.SoBanDieuTra =N'" + DBModule.RefineString(edtTimKiem.Text) + "')";
            }
            else
            {
                strSQL += " AND (b.MaHopDong like N'%" + DBModule.RefineString(edtTimKiem.Text) + "%' OR b.HoTen like N'%" + DBModule.RefineString(edtTimKiem.Text) + "%' OR a.SoBanDieuTra =N'%" + DBModule.RefineString(edtTimKiem.Text) + "%')";
            }
            return DBModule.ExecuteQuery(strSQL, null, null);
        }

        private void LoadDDLDanhMucHoTroGridHoTro()
        {
            string strSQL = "SELECT * FROM tbl_DanhMucHoTro";
            this.ddlDanhMucHoTroSource = DBModule.ExecuteQuery(strSQL, null, null);
            this.grdHoTro.DropDowns["ddlDanhMucHoTro"].SetDataBinding(this.ddlDanhMucHoTroSource.Tables[0], "");
        }

        private void LoadDDLDanhMucDauTu()
        {
            DataSet ds;
            string strSQL = "SELECT a.ID, a.DanhMucDauTuID, b.Ten as DanhMucDauTu, a.SoLuong, a.DonGia, a.SoTien, a.LaiSuat, a.NgayDauTu ";
            strSQL += " FROM tbl_DauTu as a LEFT JOIN tbl_DanhMucDauTu as b ON a.DanhMucDauTuID = b.[ID]";
            strSQL += " Where HopDongID=" + this.grdHopDong.GetValue("ID").ToString() + " AND VuTrongID=" + DACASUCO_App.VuTrongID.ToString();
            strSQL += " UNION Select -1,-1,N'Không tương ứng mục đầu tư nào',0,0,0,0,null";
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            this.grdHoTro.DropDowns["ddlDauTu"].SetDataBinding(ds.Tables[0], "");
        }
        private void LoadThonSource()
        {
            string strSQL = "SELECT * FROM tbl_Thon";
            switch (nDonVi.Type)
            {
                //case DonviTypeHD.Cum: strSQL += " Where ID IN (SELECT ID FROM tbl_Thon WHERE XaID="
                case DonviTypeHD.Xa: strSQL += " WHERE ID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviTypeHD.Thon: strSQL += " WHERE ID=" + nDonVi.DonViID; break;
                default: break;
            }
            this.gridThonSource = DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridThonSource.Tables.Count > 0)
            {
                this.grdHopDong.DropDowns["Thon"].SetDataBinding(this.gridThonSource.Tables[0], "");
            }
        }       

        private void LoadGridEX2()
        {
            try
            {
                if (this.grdHopDong.GetValue("ID").ToString() != "")
                { ThuaRuongID_ = this.grdHopDong.GetValue("ID").ToString(); }
            }
            catch { ThuaRuongID_ = ""; }
           
            if (ThuaRuongID_ != "")
            {
                //this.LoadDDLDanhMucDauTu();
                string strSQL = "SELECT *,(Case When tbl_HoTro.DanhMucHoTroID = 1 Then Soluong/1000 else SoLuong/10000 END) AS SoLuong1 FROM tbl_HoTro Where ThuaRuongID=" + ThuaRuongID_ + " AND VuTrongID=" + DACASUCO_App.VuTrongID.ToString();
                this.gridDataSourceGridEX2 = DBModule.ExecuteQuery(strSQL, null, null);
                if (this.gridDataSourceGridEX2.Tables.Count > 0)
                {
                    this.grdHoTro.SetDataBinding(this.gridDataSourceGridEX2.Tables[0], "");
                }
            }
        }

        private void CreateDataSourceAndBindGrid()
        {
            gridDataSource = this.LoadBanDieuTra();
            if (gridDataSource.Tables.Count > 0)
            {
                this.grdHopDong.SetDataBinding(gridDataSource.Tables[0], "");
            }

        }

        private void treeDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                this.DoLoadGridHopDong();
            }
        }
        private void DoLoadGridHopDong()
        {
            this.LoadThonSource();
            this.CreateDataSourceAndBindGrid();
            this.grdHopDong.Focus();
            grdHopDong.MoveFirst();
        }
        private void treeDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nDonVi = (NodeDonVi)e.Node.Tag;
            this.DoLoadGridHopDong();
        }
        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                if (this.uiCheckBox1.Checked)
                {
                    nDonVi = new NodeDonVi();
                }
                this.DoLoadGridHopDong();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu tìm kiếm ", DACASUCO_App.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridEX2_AddingRecord(object sender, CancelEventArgs e)
        {
            if (!SaveHoTro(true)) { e.Cancel = true; }
            else
            {
               //MessageBox.Show("Bạn đã lưu lại thành công", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }
        }

        private void gridEX2_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {
            string message;

            message = String.Format("Bạn muốn xóa bản ghi này?");

            if (MessageBox.Show(message, DACASUCO_App.MessageCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView dr = (DataRowView)e.Row.DataRow;
                clsHoTro oHD = new clsHoTro(long.Parse(dr.Row.ItemArray[0].ToString()));
                oHD.Delete(null, null);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void gridEX2_RecordAdded(object sender, EventArgs e)
        {
            this.LoadGridEX2();
            this.grdHoTro.Refetch();

        }

        private void gridEX2_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa thành công", DACASUCO_App.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void gridEX2_RecordUpdated(object sender, EventArgs e)
        {
            this.LoadGridEX2();
            this.grdHoTro.Refetch();
        }

        private void frmDanhSachCacKhoanHoTro_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void gridEX2_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", DACASUCO_App.MessageCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (!SaveHoTro(false)) { e.Cancel = true; }
            }
            else { e.Cancel = true; LoadGridEX2(); }
        }
              
        private bool SaveHoTro(bool isAddNew)
        {
            try
            {
                if (isAddNew)
                {
                    oHT = new clsHoTro();
                    oHT.HopDongID = long.Parse(this.grdHopDong.GetValue("ID").ToString());
                    oHT.VuTrongID = DACASUCO_App.VuTrongID;
                }
                else
                {
                    oHT.ID = long.Parse(this.grdHoTro.GetValue("ID").ToString());
                    oHT.Load(null, null);
                }

                //if (string.IsNullOrEmpty(this.grdHoTro.GetValue("DanhMucHoTroID").ToString())) throw new Exception("Bạn chưa cho biết loại hình hỗ trợ");
                //oHT.DanhMucHoTroID = long.Parse(this.grdHoTro.GetValue("DanhMucHoTroID").ToString());
                if (string.IsNullOrEmpty(this.grdHoTro.GetValue("SoTien").ToString())) throw new Exception("Bạn chưa cho biết số tiền được hỗ trợ");
                if (!decimal.TryParse(this.grdHoTro.GetValue("SoLuong").ToString(), out oHT.SoLuong)) oHT.SoLuong = 0;
                if (!decimal.TryParse(this.grdHoTro.GetValue("DonGia").ToString(), out oHT.DonGia)) oHT.DonGia = 0;
                oHT.SoTien = long.Parse(this.grdHoTro.GetValue("SoTien").ToString());
                if (string.IsNullOrEmpty(this.grdHoTro.GetValue("NgayLamHoTro").ToString())) throw new Exception("Bạn chưa cho biết ngày làm hỗ trợ");
                //oHT.NgayLamHoTro = (DateTime)this.grdHoTro.GetValue("NgayLamHoTro");
                //oHT.DauTuID = long.Parse(this.grdHoTro.GetValue("DauTuID").ToString());
                oHT.Save(null, null);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, DACASUCO_App.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        //private void grdHopDong_RowDoubleClick(object sender, RowActionEventArgs e)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(this.grdHopDong.GetValue("ID").ToString()))
        //        {
        //            long oID = long.Parse(this.grdHopDong.GetValue("ID").ToString());
        //            frmViewHopDong aa = new frmViewHopDong(oID);

        //            aa.ShowDialog();
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Không có hợp đồng nào như vậy ", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

        private void grdHopDong_SelectionChanged(object sender, EventArgs e)
        {
            grdHoTro.SetDataBinding(null, "");
          
            try {
                if (this.grdHopDong.CurrentRow.RowType != RowType.NewRecord)
                {                    
                    this.LoadGridEX2();

                }
                
            }
            catch {
                grdHoTro.SetDataBinding(null, "");
            }
        }

        private void tsViewHopDong_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.grdHopDong.GetValue("ID").ToString()))
                {
                    long oID = long.Parse(this.grdHopDong.GetValue("ID").ToString());
                    frmViewHopDong aa = new frmViewHopDong(oID);

                    aa.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }
        private void grdHoTro_UpdatingCell(object sender, UpdatingCellEventArgs e)
        {
            if (e.Column.Key == "DonGia" || e.Column.Key=="SoLuong")
            {
                long soluong;
                long dongia;
                try
                {
                    soluong = long.Parse(this.grdHoTro.GetValue("SoLuong").ToString());
                }
                catch
                {
                    soluong = 0;
                }
                try
                {
                    dongia = long.Parse(this.grdHoTro.GetValue("DonGia").ToString());
                }
                catch
                {
                    dongia = 0;
                }
                long sotien = dongia * soluong;
                this.grdHoTro.SetValue("SoTien", sotien);
            }
        }

        private void treeDonVi_AfterSelect(object sender, TreeViewEventArgs e)
        {
           // label5.Text = "Đơn vị :" + treeDonVi.SelectedNode.Text;
           // uiPanel2.Text = "Đơn vị: " + treeDonVi.SelectedNode.Text.ToUpper();
            //uiPanel5Container.Text = "Đơn vị: " + treeDonVi.SelectedNode.Text.ToUpper();
            // lblSelectNode.Text = treeDonVi.SelectedNode.Text;
            NodeDonVi ndv = (NodeDonVi)treeDonVi.SelectedNode.Tag;
            string TenDonvi = "";
            switch (ndv.Type)
            {
                case DonviTypeHD.Root:
                    TenDonvi = "Đơn vị"; break;
                case DonviTypeHD.Xa:
                    TenDonvi = "Xã: " + treeDonVi.SelectedNode.Text.ToUpper().Replace("XÃ", "").Trim(); break;
                case DonviTypeHD.Thon:
                    TenDonvi = "Xã: " + treeDonVi.SelectedNode.Parent.Text.ToUpper().Replace("XÃ", "").Trim() + "  Thôn: " + treeDonVi.SelectedNode.Text.ToUpper().Replace("THÔN", "").Trim();
                    break;
                case DonviTypeHD.Cum:
                    TenDonvi = "Trạm: " + treeDonVi.SelectedNode.Text.ToUpper();
                    break;

            }
            label5.Text = TenDonvi + "    ";
        }

        private void edtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (uiCheckBox1.Checked)
                {
                    nDonVi = (NodeDonVi)treeDonVi.Nodes[0].Tag;
                }
                this.DoLoadGridHopDong();
            }
        }

        private void grdHopDong_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "btnMenu")
            {
                this.contextRight.Show(MousePosition);
            }
        }
        private void toolChitiethopdong_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.grdHopDong.GetValue("ID").ToString()))
                {
                    long oID = long.Parse(this.grdHopDong.GetValue("ID").ToString());

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

        private void toolQuanlydautu_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = this.grdHopDong.GetValue("ID").ToString();

                frmQuanLyDauTuNoCu frm = new frmQuanLyDauTuNoCu(ID);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void toolThietlapdientich_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = this.grdHopDong.GetValue("ID").ToString();

                frmDienTichCoCauTrong frm = new frmDienTichCoCauTrong(ID);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }     

        private void toolLamthanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = this.grdHopDong.GetValue("ID").ToString();

                frmThanhToanCongNo frm = new frmThanhToanCongNo(ID);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void mnuChitiettrunodautu_Click(object sender, EventArgs e)
        {
            try
            {
                frmThanhToan_DauTu_TruNo frm = new frmThanhToan_DauTu_TruNo(this.grdHopDong.GetValue("ID").ToString());
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void chitiencoTruNo_Click(object sender, EventArgs e)
        {
            try
            {
                frmThanhToan_TienCo_TruNo frm = new frmThanhToan_TienCo_TruNo(this.grdHopDong.GetValue("ID").ToString());
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }    

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.F8:
                        


                        //this.DoLoadGridHopDong();

                        //btThem_Click(null, null);

                        uiButtonThem_Click(null,null);
                        break;

                    case Keys.F4:
                        //Code cho F4
                        try
                        {
                            if (!string.IsNullOrEmpty(this.grdHopDong.GetValue("ID").ToString()))
                            {
                                long oID = long.Parse(this.grdHopDong.GetValue("ID").ToString());

                                frmViewHopDong aa = new frmViewHopDong(oID);
                                aa.MdiParent = this.MdiParent;
                                aa.Show();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
                        }
                        break;
                    case Keys.F9:
                        try { uiButtonSua_Click(null, null); }
                        catch { }
                        break;
                    case Keys.Escape:
                        // Code cho phim Esc
                        grdHopDong.CancelCurrentEdit();
                        //gridEX2.CancelCurrentEdit();
                        uiPanel3.Text = "F8-Cập nhật hỗ trợ cho hợp đồng / F4-Chi tiết  / F6-In danh sách";

                        break;

                    case Keys.F5:
                        // Code cho phim F6
                        edtTimKiem.Focus();
                        this.AcceptButton = btnSearch;
                        break;
                    case Keys.F12:
                        // Code cho phim F7
                        uiPanel0.Activate();
                        break;
                    case Keys.Delete:
                        uiButtonXoa_Click(null,null);
                        break;

                   
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.grdHopDong.GetValue("ID").ToString()))
                {
                    long oID = long.Parse(this.grdHopDong.GetValue("ID").ToString());

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

        private void uiButtonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string message;
                message = String.Format("Bạn muốn xóa bản ghi này?");

                if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //DataRowView dr = (DataRowView).Row.DataRow;
                    clsHoTro oHT = new clsHoTro(long.Parse(this.grdHoTro.GetValue("ID").ToString()));
                    oHT.Delete(null, null);
                    LoadGridEX2();
                }
                else
                {
                    LoadGridEX2();
                    //e.Cancel = true;
                }
            }
            catch { MessageBox.Show("Bạn phải chọn một mục đầu tư để xóa", "Thông báo"); }
        }

        private void uiButtonThem_Click(object sender, EventArgs e)
        {
            Boolean i = false;
            try
            {
                if (this.grdHopDong.GetValue("ID").ToString() != "")
                {
                    i = true;
                }

            }
            catch
            {
                i = false;
            }
            if (i)
            {
                MDDataSetForms.frmNhapHoTro frm = new MDSolution.MDDataSetForms.frmNhapHoTro(long.Parse(this.grdHopDong.GetValue("ID").ToString()), true);
                frm.ShowDialog();
                LoadGridEX2();
                try
                {
                    GridEXFilterCondition condi = new GridEXFilterCondition(grdHoTro.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                    grdHoTro.Find(condi, 0, 1);
                }
                catch { }
            }
            else
            {
                MDDataSetForms.frmNhapHoTro frm = new MDSolution.MDDataSetForms.frmNhapHoTro(0, true);
                frm.ShowDialog();
                LoadGridEX2();
                //try
                //{
                //    GridEXFilterCondition condi = new GridEXFilterCondition(grdHoTro.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                //    grdHoTro.Find(condi, 0, 1);
                //}
                //catch { }
            }
            

        }

        private void uiButtonSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdHoTro.GetValue("ID").ToString() != "")
                {
                    string a = this.grdHoTro.GetValue("ID").ToString();           
                    MDDataSetForms.frmNhapHoTro frm = new MDSolution.MDDataSetForms.frmNhapHoTro(long.Parse(this.grdHoTro.GetValue("ID").ToString()), false);
                    frm.ShowDialog();
                    LoadGridEX2();
                    try
                    {
                        GridEXFilterCondition condi = new GridEXFilterCondition(grdHoTro.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                        grdHoTro.Find(condi, 0, 1);
                    }
                    catch { }
                }
                else { MessageBox.Show("Bạn phải chọn một mục hỗ trợ để sửa", "Thông báo"); }
            }
            catch { MessageBox.Show("Bạn phải chọn một mục hỗ trợ để sửa", "Thông báo"); }
        }

          

    }
}