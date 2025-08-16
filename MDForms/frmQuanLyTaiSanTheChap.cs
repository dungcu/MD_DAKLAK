using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using Janus.Windows.GridEX;
using DACASUCO.MDForms;

namespace MDSolution
{
    public partial class frmQuanLyTaiSanTheChap : Form
    {
        static frmQuanLyTaiSanTheChap _thefrmQuanLyTaiSanTheChap;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmQuanLyTaiSanTheChap OneInstanceFrm
        {
            get
            {
                if (null == _thefrmQuanLyTaiSanTheChap || _thefrmQuanLyTaiSanTheChap.IsDisposed)
                {
                    _thefrmQuanLyTaiSanTheChap = new frmQuanLyTaiSanTheChap();
                }

                return _thefrmQuanLyTaiSanTheChap;
            }
        }

        //private clsHoTro oHT = new clsHoTro();
        private NodeDonVi nDonVi = new NodeDonVi();
        private DataSet gridDataSourceGridEX2;
        //private clsHopDong oHD = new clsHopDong();
        //private DataSet gridThonSource;
        //private DataSet DVCUVT;
        //private clsDauTu oDT = new clsDauTu();
        //private clsDanhMucDauTu oDMDT = new clsDanhMucDauTu();
        //private clsDanhMucHoTro oDMHT = new clsDanhMucHoTro();
        ////MDDataSetForms.frmDauTu frmChiTiet;
        private string hdID = "";
        //Khai bao cho phan Dau Tu
        //private DataSet ddlThuaRuongSource;        
        public frmQuanLyTaiSanTheChap()
        {
            InitializeComponent();
            
            //this.LoadDVCungUngVT();
            CommonClass.loadTreeDonVi(treeDonVi);
            this.LoadDDLTram();
            this.LoadDDL_LoaiTS();
           
        }
        public frmQuanLyTaiSanTheChap(string ID)
        {
            InitializeComponent();
            CommonClass.loadTreeDonVi(treeDonVi);
            this.LoadDDLTram();
            this.LoadDDL_LoaiTS();
            //LoadHopDong1(ID);
            //LoadThonSource();
            

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
      /*  private DataSet LoadHopDong()
        {
            string strSQL = "SELECT * FROM tbl_HopDong WHERE 1=1";
            switch (nDonVi.Type)
            {
                case DonviTypeHD.Xa: strSQL += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviTypeHD.Thon: strSQL += " AND ThonID=" + nDonVi.DonViID; break;
                default: break;
            }
            if (this.chkTimkiemchinhxac.Checked)
            {

                strSQL += " AND (MaHopDong = N'" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "' OR HoTen = N'" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "' )";
            }
            else
            {

                strSQL += " AND (MaHopDong like N'%" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "%' OR HoTen like N'%" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "%' )";

            }
            return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
        }*/
        //private void LoadThonSource()
        //{
        //    string strSQL = "SELECT * FROM tbl_Thon";
        //    switch (nDonVi.Type)
        //    {
        //        case DonviTypeHD.Xa: strSQL += " WHERE ID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
        //        case DonviTypeHD.Thon: strSQL += " WHERE ID=" + nDonVi.DonViID; break;
        //        default: break;
        //    }
        //    this.gridThonSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
        //    if (this.gridThonSource.Tables.Count > 0)
        //    {
        //        this.grdHopDong.DropDowns["Thon"].SetDataBinding(this.gridThonSource.Tables[0], "");
        //    }
        //}
        private void LoadGrdDauTu()
        {
            try
            {
                if (this.grdHopDong.GetValue("ID").ToString() != "")
                { hdID = this.grdHopDong.GetValue("ID").ToString(); }
            }
            catch { hdID = ""; }
            if (hdID != "")
            {
                this.grdDauTu.SetDataBinding(null, "");
                string strSQL = "SELECT * FROM tbl_TaiSanTheChap  Where HopDongID=" + hdID ;
                this.gridDataSourceGridEX2 = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                if (this.gridDataSourceGridEX2.Tables.Count > 0)
                {
                    this.grdDauTu.SetDataBinding(this.gridDataSourceGridEX2.Tables[0], "");

                }
            }
        }
        private void LoadDDLTram()
        { 
            
            string strSQL = "SELECT * FROM tbl_Cum";
            DataSet DS = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            this.grdDauTu.DropDowns["ddl_Tram"].SetDataBinding(DS.Tables[0], "");
           
        }
        private void LoadDDL_LoaiTS()
        {
            string strSQL = "SELECT * FROM tbl_DanhMucTaiSanTheChap";
            DataSet DS = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            this.grdDauTu.DropDowns["dd_LoaiTS"].SetDataBinding(DS.Tables[0], "");
        }
       
        
        private void CreateDataSourceAndBindGrid(long lID)
        {
            DataSet ds;
            ds = clsHopDong.GetDanhSachDenHopDong(lID, this.edtTimKiem.Text, nDonVi.Type, nDonVi.DonViID, false);
            if (ds.Tables.Count > 0)
            {
                this.grdHopDong.SetDataBinding(ds.Tables[0], "");
            }
           
        }
        private void treeDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                 nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                 if (!nDonVi.HasLoadChildren && nDonVi.Type == DonviTypeHD.Thon)
                 {
                     CommonClass.LoadChildrenHopDong(treeDonVi.SelectedNode);
                     nDonVi.HasLoadChildren = true;
                 }
                this.DoLoadGridHopDong(-1);
            }
        }
        private void DoLoadGridHopDong(long lID)
        {
            //this.LoadThonSource();
            this.CreateDataSourceAndBindGrid(lID);
            this.grdHopDong.Focus();
           
        }
        private void treeDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nDonVi = (NodeDonVi)e.Node.Tag;
            //if (!nDonVi.HasLoadChildren && nDonVi.Type == DonviType.Thon)
            //{
            //    CommonClass.LoadChildrenHopDong(e.Node);
            //    nDonVi.HasLoadChildren = true;
            //}
            this.DoLoadGridHopDong(-1);
        }
        private void grdHopDong_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadGrdDauTu();
                uipDauTu.Text = "Chi tiết Tài sản thế chấp của Chủ mía " + grdHopDong.GetValue(3).ToString();
                
            }
            catch
            {
                //grdThuaRuong.AllowAddNew = InheritableBoolean.False;
            }
        }
        private void uiButton1_Clic(object sender, EventArgs e)
        {

        }
        private void gridEX2_AddingRecord(object sender, CancelEventArgs e)
        {
            //if (!SaveDauTu(true)) { e.Cancel = true; }
            //else
            //{
            //    uiPanel2.Text = "F8-Thêm mới / F9-Sửa / F4-Chi tiết / Delete-Xóa / F6-In danh sách";
            //    //MessageBox.Show("Bạn đã lưu lại thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //this.grdHopDong.SetValue("ID", oHD.ID);
            //}
        }
        private void gridEX2_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {
            string message;
            message = String.Format("Bạn muốn xóa bản ghi này?");

            if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView dr = (DataRowView)e.Row.DataRow;
                clsDauTu oDT = new clsDauTu(long.Parse(dr.Row.ItemArray[0].ToString()));
                oDT.Delete(null, null);
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void gridEX2_RecordAdded(object sender, EventArgs e)
        {
            this.LoadGrdDauTu();
            this.grdDauTu.Refetch();
        }
        private void gridEX2_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa  thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void gridEX2_RecordUpdated(object sender, EventArgs e)
        {
            this.grdDauTu.Refetch();
            this.LoadGrdDauTu();
        }
        
     
        //private void gridEX2_SelectionChanged(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        if (this.grdDauTu.CurrentRow.RowType == Janus.Windows.GridEX.RowType.NewRecord)
        //        {
        //            lblTB.Text = "Bạn có thể nhập số tiền bằng đơn giá nhân số lượng hoặc nhập trực tiếp vào ô số tiền ";
        //            oDT = new clsDauTu();                    
        //        }
        //        else
        //        {
        //            oDT.ID = long.Parse(this.grdDauTu.GetValue("ID").ToString());
        //        }
        //    }
        //    catch
        //    {
        //        oDT = new clsDauTu();
        //    }
        //}
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
        //        MessageBox.Show("Không có hợp đồng nào như vậy ", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
      
        private void treeDonVi_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //label1.Text = treeDonVi.SelectedNode.Text;
            switch (nDonVi.Type)
            {
                case DonviTypeHD.Cum: uiPanel3.Text = "Danh sách Chủ mía trong: " + treeDonVi.SelectedNode.Text + ""; break;
                case DonviTypeHD.Xa: uiPanel3.Text = "Danh sách Chủ mía của: " + treeDonVi.SelectedNode.Text + ""; break;
                //case DonviTypeHD.Thon: label5.Text = "Chủ mía của thôn : " + treeDonVi.SelectedNode.Text + ""; break;
                //case DonviTypeHD.ChuHopDong: uiPanel3.Text = "Chủ hộ của hợp đồng : " + treeDonVi.SelectedNode.Text + ""; break;
                default: uiPanel3.Text = "Danh sách Chủ mía"; break;
            }
           // uiPanel3.Text = "Hợp đồng (" + treeDonVi.SelectedNode.Text +")";
        }

        private void edtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                DataSet dr;
            string str = "";

            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                string Ten = MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text);
                str = "SELECT * FROM tbl_HopDong WHERE dbo.BoDauTiengViet(HoTen) like N'%" + Ten + "%'";
                dr = MDSolutionEntities.DBModule.ExecuteQuery(str, null, null);
                if (dr.Tables[0].Rows.Count > 0)
                {
                    this.grdHopDong.SetDataBinding(dr.Tables[0], "");
                }
            }
            else
            {
                edtTimKiem.Text = null;
                MessageBox.Show("Không có thông tin nào như vậy!", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                edtTimKiem.Focus();
            }

            }
        }

        private void btinchitiet_Click(object sender, EventArgs e)
        {
            try
            {
                frmShowRP2 frm = new frmShowRP2();
                DACASUCO.MDReport.rp_T_ChiTietDauTu rp = new DACASUCO.MDReport.rp_T_ChiTietDauTu();
                                            
                rp.RecordSelectionFormula = "{View_ChiTietDauTu.HopDongID}=" + this.grdHopDong.GetValue("ID").ToString() + " AND {View_ChiTietDauTu.VuTrongID}=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                frm.RP = rp;

                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.RPtitle = "Báo cáo chi tiết đầu tư.";
                frm.Show();

            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn hợp đồng cần xem", "Thông báo");
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

        private void toolQuanlyhotro_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string ID = this.grdHopDong.GetValue("ID").ToString();

            //    frmDanhSachCacKhoanHoTro frm = new frmDanhSachCacKhoanHoTro(ID);
            //    frm.MdiParent = this.MdiParent;
            //    frm.Show();
            //}
            //catch
            //{
            //    MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            //}
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
                    
                    case Keys.F2:
                        //code cho F2                        
                        grdDauTu.MoveNext();
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
                            MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết","Lỗi");
                        }
                        break;                   

                    case Keys.F5:
                        // Code cho phim F5
                        edtTimKiem.Focus();
                        this.AcceptButton = uiButton1;
                        break;

                    case Keys.F6:
                        //code cho F6
                        btinchitiet_Click(null, null);
                        break;

                    case Keys.F8:
                        Boolean i = false;
                        try
                        {
                            if (this.grdHopDong.GetValue("ID").ToString() != "")
                            {
                                i = true;
                                
                            }
                           
                        }
                        catch {
                            i = false;
                        }
                        if (i)
                        {
                            DACASUCO.MDDataSetForms.frmDauTu frm = new DACASUCO.MDDataSetForms.frmDauTu(long.Parse(this.grdHopDong.GetValue("ID").ToString()), true);
                            frm.ShowDialog();
                            LoadGrdDauTu();
                            try
                            {
                                GridEXFilterCondition condi = new GridEXFilterCondition(grdDauTu.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                                grdDauTu.Find(condi, 0, 1);
                            }
                            catch { }
                        }
                        else
                        {
                            DACASUCO.MDDataSetForms.frmDauTu frm = new DACASUCO.MDDataSetForms.frmDauTu(0, true);
                            frm.ShowDialog();
                            LoadGrdDauTu();
                            try
                            {
                                GridEXFilterCondition condi = new GridEXFilterCondition(grdDauTu.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                                grdDauTu.Find(condi, 0, 1);
                            }
                            catch { }
                        }
                        break;

                    case Keys.F9:
                        // Code cho phim F9
                        //grdDauTu.EditMode = EditMode.EditOn;
                       // grdDauTu.MoveFirst();
                        //grdDauTu.Focus();
                        try
                        {
                            if (this.grdDauTu.GetValue("ID").ToString() != "")
                            {
                                DACASUCO.MDDataSetForms.frmDauTu frm = new DACASUCO.MDDataSetForms.frmDauTu(long.Parse(this.grdDauTu.GetValue("ID").ToString()), false);
                                frm.ShowDialog();
                                LoadGrdDauTu();
                                try
                                {
                                    GridEXFilterCondition condi = new GridEXFilterCondition(grdDauTu.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                                    grdDauTu.Find(condi, 0, 1);
                                }
                                catch { }
                            }
                            else { MessageBox.Show("Bạn phải chọn một mục đầu tư để sửa", "Thông báo"); }
                        }
                        catch { MessageBox.Show("Bạn phải chọn một mục đầu tư để sửa", "Thông báo"); }
                        //uiPanel2.Text = "F2-Lưu / Esc-Bỏ qua";
                        break;

                    case Keys.Escape:
                        // Code cho phim Esc
                        grdDauTu.CancelCurrentEdit();
                       // uiPanel2.Text = "F8-Thêm mới / F9-Sửa / F4-Chi tiết / Delete-Xóa / F6-In danh sách";
                        break;

                    case Keys.F12:
                        // Code cho phim F12
                        uiPanel0.Activate();
                        break;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void edtTimKiem_Click(object sender, EventArgs e)
        {
            edtTimKiem.Text = "";
        }

        private void uiButton6_Click(object sender, EventArgs e)
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
                frmNhapTSTC frm = new frmNhapTSTC(long.Parse(this.grdHopDong.GetValue("ID").ToString()),true);
                frm.ShowDialog();
                LoadGrdDauTu();
              
            }
            else 
            {
                
                frmNhapTSTC frm = new frmNhapTSTC(long.Parse(this.grdHopDong.GetValue("ID").ToString()), true);
                frm.ShowDialog();
                LoadGrdDauTu();
               
            }
            
        }

        private void uiButtonSua_Click(object sender, EventArgs e)
        {
            try
            {
                string IDTC = this.grdDauTu.GetValue("ID").ToString();
                if (IDTC != "")
                {
                   
                    frmNhapTSTC frm = new frmNhapTSTC(IDTC, false);
                    frm.ShowDialog();
                    LoadGrdDauTu();
                    
                }
                else { MessageBox.Show("Bạn phải chọn một mục Tài sản thế chấp để sửa", "Thông báo"); }
            }
            catch { MessageBox.Show("Đã có một lỗi ngoại lệ xảy ra", "Thông báo"); }
        }

       

        private void uiButtonXoa_Click(object sender, EventArgs e)
        {try
            {
            string message;
            message = String.Format("Bạn muốn xóa bản ghi Tài sản thế chấp này?");

            if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                long ID = long.Parse(this.grdDauTu.GetValue("ID").ToString());
                if (ID > 0)
                {
                    string sql = "Delete from tbl_TaiSanTheChap where ID=" + ID.ToString();
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    MessageBox.Show("Bạn đã xóa thành công", "DACASUCO");
                }
                LoadGrdDauTu();
            }
            else
            {
                LoadGrdDauTu();
            }
        }
        catch { MessageBox.Show("Bạn phải chọn một mục Tài sản thế chấp để xóa", "Thông báo"); }
        }

        private void uiButtonChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                frmShowRP2 frm = new frmShowRP2();
                DACASUCO.MDReport.rpt_TSTC_Canhan rp = new DACASUCO.MDReport.rpt_TSTC_Canhan();

                rp.RecordSelectionFormula = "{V_TS_TheChap.HopDongID}=" + this.grdHopDong.GetValue("ID").ToString();// +" AND {View_ChiTietDauTu.VuTrongID}=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                frm.RP = rp;

                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.RPtitle = "Báo cáo chi tiết Tài sản thế chấp";
                frm.Show();

            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn mục cần Xem/In", "Thông báo");
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.grdHopDong.DataSource = null;
            DataSet dr;
            string str = "";

            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                string Ten = MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text);
                str = "SELECT * FROM tbl_HopDong WHERE dbo.BoDauTiengViet(HoTen) like N'%" + Ten + "%'";
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

        private void edtTimKiem_TextChanged(object sender, EventArgs e)
        {
             DataSet dr;
            string str = "";

            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                string Ten = MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text);
                str = "SELECT * FROM tbl_HopDong WHERE dbo.BoDauTiengViet(HoTen) like N'%" + Ten + "%'";
                dr = MDSolutionEntities.DBModule.ExecuteQuery(str, null, null);
                if (dr.Tables[0].Rows.Count > 0)
                {
                    this.grdHopDong.SetDataBinding(dr.Tables[0], "");
                }
            }
        }

    }
}