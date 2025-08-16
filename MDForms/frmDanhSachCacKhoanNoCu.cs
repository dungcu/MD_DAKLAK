using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using MDSolution;
using Janus.Windows.GridEX;
using DACASUCO.MDForms;


namespace MDSolution
{
    public partial class frmDanhSachCacKhoanNoCu : Form
    {
        static frmDanhSachCacKhoanNoCu _theformDanhSachCacKhoanNoCu;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmDanhSachCacKhoanNoCu OneInstanceFrm
        {
            get
            {
                if (null == _theformDanhSachCacKhoanNoCu || _theformDanhSachCacKhoanNoCu.IsDisposed)
                {
                    _theformDanhSachCacKhoanNoCu = new frmDanhSachCacKhoanNoCu();
                }

                return _theformDanhSachCacKhoanNoCu;
            }
        }

        private NodeDonVi nDonVi = new NodeDonVi();
        
        private DataSet gridDataSource;

        private DataSet gridDataSourceGridEX2;

        private DataSet gridThonSource;

        private string hdID = "";

        private clsNoCuChuHopDong oHT = new clsNoCuChuHopDong();

        private DataSet ddlDanhMucHoTroSource;

        public frmDanhSachCacKhoanNoCu()
        {
            InitializeComponent();
                     
            this.LoadDDLDanhMucHoTroGridHoTro();
            CommonClass.loadTreeDonVi(treeDonVi);
            LoadDDLDanhMucHoTroGridHoTro();
            LoadDDL_LoaiNo();
            LoadDDL_Tram();
            LoadThonSource();
        }
        public frmDanhSachCacKhoanNoCu(string ID)
        {
            InitializeComponent();
            CommonClass.loadTreeDonVi(treeDonVi);
            LoadHopDong1(ID);
            LoadDDLDanhMucHoTroGridHoTro();
            LoadDDL_LoaiNo();
            LoadDDL_Tram();
            LoadThonSource();

        }
        private void LoadHopDong1(string ID)
        {
            DataSet ds;
            string strSQL = "SELECT * FROM tbl_HopDong WHERE ParentID=0 AND ID=" + ID.ToString();
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables.Count > 0)
            {
                this.grdHopDong.SetDataBinding(ds.Tables[0], "");
            }
        }
        private DataSet LoadHopDong()
        {
            string strSQL = "";
            strSQL = @"SELECT a.*,b.Ten as TenThon 
                        FROM tbl_HopDong as a LEFT JOIN tbl_Thon as b ON a.ThonID=b.ID 
                        WHERE parentid=0 ";
            switch (nDonVi.Type)
            {
                case DonviTypeHD.Xa: strSQL += " AND a.ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviTypeHD.Thon: strSQL += " AND a.ThonID=" + nDonVi.DonViID; break;
                case DonviTypeHD.Cum: strSQL += "AND a.ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID In (Select ID From tbl_Xa Where CumID =" + nDonVi.DonViID + "))"; break;
                default: break;
            }
            if ((this.chkTimkiemchinhxac.Checked) && (edtTimKiem.Text != ""))
            {
                strSQL += " AND (a.MaHopDong = N'" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "' OR a.HoTen = N'" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "' )";
            }
            else
            {

                strSQL += " AND (a.MaHopDong like N'%" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "%' OR a.HoTen like N'%" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "%' )";
            }
            return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
        }

        private void LoadDDLDanhMucHoTroGridHoTro()
        {
            string strSQL = "SELECT * FROM tbl_DanhMucHoTro";
            this.ddlDanhMucHoTroSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            this.grdHoTro.DropDowns["ddlDanhMucHoTro"].SetDataBinding(this.ddlDanhMucHoTroSource.Tables[0], "");
        }
        private void LoadDDL_Tram()
        {
            string sql="Select ID,Ten from tbl_Cum";
            DataSet ds=MDSolutionEntities.DBModule.ExecuteQuery(sql,null,null);
            this.grdHoTro.DropDowns["DDL_Tram"].SetDataBinding(ds.Tables[0],"");
        }
        private void LoadDDLDanhMucDauTu()
        {
            DataSet ds;
            string strSQL = "SELECT a.ID, a.DanhMucDauTuID, b.Ten as DanhMucDauTu, a.SoLuong, a.DonGia, a.SoTien, a.LaiSuat, a.NgayDauTu ";
            strSQL += " FROM tbl_DauTu as a LEFT JOIN tbl_DanhMucDauTu as b ON a.DanhMucDauTuID = b.[ID]";
            strSQL  += " Where HopDongID=" + this.grdHopDong.GetValue("ID").ToString() + " AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            strSQL += " UNION Select -1,-1,N'Không tương ứng mục đầu tư nào',0,0,0,0,null";
            ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            this.grdHoTro.DropDowns["ddlDauTu"].SetDataBinding(ds.Tables[0], "");
        } 
        void LoadDDL_LoaiNo()
        {
        string sql="Select ID,Ten from tbl_LoaiNo";
            DataSet ds =MDSolutionEntities.DBModule.ExecuteQuery(sql,null,null);
            this.grdHoTro.DropDowns["DDL_LoaiNo"].SetDataBinding(ds.Tables[0],"");
        }

        
        private void LoadThonSource()
        {
            string strSQL = "SELECT * FROM tbl_Thon";
            switch (nDonVi.Type)
            {
                case DonviTypeHD.Xa: strSQL += " WHERE ID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviTypeHD.Thon: strSQL += " WHERE ID=" + nDonVi.DonViID; break;
                default: break;
            }
            this.gridThonSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
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
                { hdID = this.grdHopDong.GetValue("ID").ToString(); }
            }
            catch { hdID = ""; }
           
            if (hdID != "")
            {
               // this.LoadDDLDanhMucDauTu();
                string strSQL = "select ID,(select ten from tbl_vutrong where id=tbl_NoCuChuHopDong.LaDuNoVuTrong) as VuTrongName,NoGoc,NoLai,Phat,LaiSuat,NgayTinhLai,MaHDDT,GhiChu,LoaiNoID,TramID from tbl_NoCuChuHopDong where HopDongID=" + hdID + " AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID;
                this.gridDataSourceGridEX2 = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                if (this.gridDataSourceGridEX2.Tables[0].Rows.Count > 0)
                {
                    this.grdHoTro.SetDataBinding(this.gridDataSourceGridEX2.Tables[0], "");
                }
                else this.grdHoTro.SetDataBinding(null, "");
            }
        }

        private void CreateDataSourceAndBindGrid()
        {
            gridDataSource = this.LoadHopDong();
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

        }


        private void treeDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nDonVi = (NodeDonVi)e.Node.Tag;
            this.DoLoadGridHopDong();
        }
        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.grdHopDong.DataSource = null;
            DataSet dr;
            string str = "";

            str = "SELECT * FROM tbl_HopDong WHERE 1=1 ";

            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                string Ten = MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text);
                if (this.chkTimkiemchinhxac.Checked)
                {
                    str += " AND  HoTen = N'" + Ten + "'";
                }
                else
                {
                    str += " AND  dbo.BoDauTiengViet(HoTen) like N'%" + Ten + "%'";
                }

                dr = MDSolutionEntities.DBModule.ExecuteQuery(str, null, null);
                if (dr.Tables[0].Rows.Count > 0)
                {
                    this.grdHopDong.SetDataBinding(dr.Tables[0], "");
                }

                else
                {
                    edtTimKiem.Text = null;
                    MessageBox.Show("Không có thông tin nào như vậy!", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    edtTimKiem.Focus();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                edtTimKiem.Focus();
            }
        }

        private void gridEX2_AddingRecord(object sender, CancelEventArgs e)
        {
            if (!SaveHoTro(true)) { e.Cancel = true; }
            else
            {
               //MessageBox.Show("Bạn đã lưu lại thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }
        }

        private void gridEX2_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {
            string message;

            message = String.Format("Bạn muốn xóa bản ghi này?");

            if (MessageBox.Show(message, " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            MessageBox.Show("Đã xóa thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void gridEX2_RecordUpdated(object sender, EventArgs e)
        {
            this.LoadGridEX2();
            this.grdHoTro.Refetch();
        }

        private void frmDanhSachCacKhoanNoCu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void gridEX2_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    clsNoCuChuHopDong oHT = new clsNoCuChuHopDong();
                    oHT.HopdongID = long.Parse(this.grdHopDong.GetValue("ID").ToString());
                    oHT.VuTrongID = MDSolution.DACASUCO_App.VuTrongID;
                }
                else
                {
                    oHT.ID = long.Parse(this.grdHoTro.GetValue("ID").ToString());
                    oHT.Load(null, null);
                }

                if (string.IsNullOrEmpty(this.grdHoTro.GetValue("VuTrongID").ToString())) throw new Exception("Bạn chưa cho biết Vụ trồng");
                oHT.VuTrongID = long.Parse(this.grdHoTro.GetValue("DanhMucHoTroID").ToString());

                if (string.IsNullOrEmpty(this.grdHoTro.GetValue("NoGoc").ToString())) throw new Exception("Bạn chưa cho biết số tiền nợ gốc");

                oHT.NoGoc = long.Parse(this.grdHoTro.GetValue("NoGoc").ToString());

                //if (!float.TryParse(this.grdHoTro.GetValue("NoGoc").ToString(), out oHT.NoGoc)) oHT.NoGoc = 0;

                if (string.IsNullOrEmpty(this.grdHoTro.GetValue("NoLai").ToString())) throw new Exception("Bạn chưa cho biết số tiền nợ lãi");

                oHT.NoLai = long.Parse(this.grdHoTro.GetValue("NoLai").ToString());

               // if (!float.TryParse(this.grdHoTro.GetValue("NoLai").ToString(), out oHT.NoLai)) oHT.NoLai = 0;

                if (string.IsNullOrEmpty(this.grdHoTro.GetValue("Phat").ToString())) throw new Exception("Bạn chưa cho biết số tiền phạt");

                oHT.Phat = long.Parse(this.grdHoTro.GetValue("Phat").ToString());

                //if (!float.TryParse(this.grdHoTro.GetValue("Phat").ToString(), out oHT.NoLai)) oHT.NoLai = 0;

               // oHT.SoTien = long.Parse(this.grdHoTro.GetValue("SoTien").ToString());

                //oHT.DauTuID = long.Parse(this.grdHoTro.GetValue("DauTuID").ToString());
                oHT.Save(null, null);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
       
        private void grdHopDong_SelectionChanged(object sender, EventArgs e)
        {
            try {
                if (this.grdHopDong.CurrentRow.RowType != RowType.NewRecord)
                {                    
                    this.LoadGridEX2();
                    this.grdHoTro.Refetch();
                }
                
            }
            catch {
                grdHoTro.SetDataBinding(null, "");
                this.grdHoTro.Refetch();
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

            }
            label5.Text = TenDonvi + "    ";
        }

        private void edtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                 this.grdHopDong.DataSource = null;
            DataSet dr;
            string str = "";

            str = "SELECT * FROM tbl_HopDong WHERE 1=1 ";

            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                string Ten = MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text);
                if (this.chkTimkiemchinhxac.Checked)
                {
                    str += " AND  HoTen = N'" + Ten + "'";
                }
                else
                {
                    str += " AND  dbo.BoDauTiengViet(HoTen) like N'%" + Ten + "%'";
                }

                dr = MDSolutionEntities.DBModule.ExecuteQuery(str, null, null);
                if (dr.Tables[0].Rows.Count > 0)
                {
                    this.grdHopDong.SetDataBinding(dr.Tables[0], "");
                }

                else
                {
                    edtTimKiem.Text = null;
                    MessageBox.Show("Không có thông tin nào như vậy!", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    edtTimKiem.Focus();
                }
            }
           
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
            //try
            //{
            //    string ID = this.grdHopDong.GetValue("ID").ToString();

            //    frmThanhToanCongNo frm = new frmThanhToanCongNo(ID);
            //    frm.MdiParent = this.MdiParent;
            //    frm.Show();
            //}
            //catch
            //{
            //    MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            //}
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
                        this.AcceptButton = uiButton1;
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
                if (this.grdHoTro.GetValue("ID").ToString() != "")
                {
                    frmChiTietTruNoCu frm = new frmChiTietTruNoCu(long.Parse(grdHoTro.GetValue("ID").ToString()), 0);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                    LoadGridEX2();
                    //try
                    //{
                    //    GridEXFilterCondition condi = new GridEXFilterCondition(grdHoTro.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                    //    grdHoTro.Find(condi, 0, 1);
                    //}
                    //catch { }
                }
                else { MessageBox.Show("Bạn phải chọn một mục để Xem chi tiết trả nợ", "Thông báo"); }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Bạn phải chọn một mục Xem chi tiết trả nợ", "Thông báo"); 
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
                    clsNoCuChuHopDong oHT = new clsNoCuChuHopDong(long.Parse(this.grdHoTro.GetValue("ID").ToString()));
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
                DACASUCO.MDForms.frmNhapNoCuChuHopDong frm = new DACASUCO.MDForms.frmNhapNoCuChuHopDong(long.Parse(this.grdHopDong.GetValue("ID").ToString()), true);
                //frm.IsAddNew = true;
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
                DACASUCO.MDForms.frmNhapNoCuChuHopDong frm = new DACASUCO.MDForms.frmNhapNoCuChuHopDong(0, true);
                frm.ShowDialog();
                LoadGridEX2();
            }
            

        }

        private void uiButtonSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdHoTro.GetValue("ID").ToString() != "")
                {
                    long a = long.Parse(this.grdHoTro.GetValue("ID").ToString());
                    DACASUCO.MDForms.frmNhapNoCuChuHopDong frm = new DACASUCO.MDForms.frmNhapNoCuChuHopDong(a, false);
                    frm.ShowDialog();
                    LoadGridEX2();
                    try
                    {
                        GridEXFilterCondition condi = new GridEXFilterCondition(grdHoTro.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                        grdHoTro.Find(condi, 0, 1);
                    }
                    catch { }
                }
                else { MessageBox.Show("Bạn phải chọn một mục Nợ cũ để sửa", "Thông báo"); }
            }
            catch { MessageBox.Show("Bạn phải chọn một mục Nợ cũ để sửa", "Thông báo"); }
        }

        private void edtTimKiem_TextChanged(object sender, EventArgs e)
        {

            DataSet dr;
            string str = "";

            str = "SELECT * FROM tbl_HopDong WHERE 1=1 ";

            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                string Ten = MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text);
                if (this.chkTimkiemchinhxac.Checked)
                {
                    str += " AND  HoTen = N'" + Ten + "'";
                }
                else
                {
                    str += " AND  dbo.BoDauTiengViet(HoTen) like N'%" + Ten + "%'";
                }

                dr = MDSolutionEntities.DBModule.ExecuteQuery(str, null, null);
                if (dr.Tables[0].Rows.Count > 0)
                {
                    this.grdHopDong.SetDataBinding(dr.Tables[0], "");
                }

            }
        }

        private void edtTimKiem_Click(object sender, EventArgs e)
        {
            edtTimKiem.Text = "";
        }
          

    }
}