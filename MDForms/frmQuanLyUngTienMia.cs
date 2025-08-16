using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDForms;

namespace MDSolution
{
    public partial class frmQuanLyUngTienMia : Form
    {
        static frmQuanLyUngTienMia _theformQuanLyUngTienMia;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmQuanLyUngTienMia OneInstanceFrm
        {
            get
            {
                if (null == _theformQuanLyUngTienMia || _theformQuanLyUngTienMia.IsDisposed)
                {
                    _theformQuanLyUngTienMia = new frmQuanLyUngTienMia();
                }

                return _theformQuanLyUngTienMia;
            }
        }

        private clsHoTro oHT = new clsHoTro();
        private NodeDonVi nDonVi = new NodeDonVi();
        private DataSet gridDataSourceGridEX2;
        private clsHopDong oHD = new clsHopDong();
        private DataSet gridThonSource;
        private DataSet DVCUVT;
        private clsDauTu oDT = new clsDauTu();
        private clsDanhMucDauTu oDMDT = new clsDanhMucDauTu();
        private clsDanhMucHoTro oDMHT = new clsDanhMucHoTro();
        MDDataSetForms.frmDauTu frmChiTiet;
        private string hdID = "";
        //Khai bao cho phan Dau Tu
        //private DataSet ddlThuaRuongSource;        
        public frmQuanLyUngTienMia()
        {
            InitializeComponent();
            //this.LoadDDLHinhThucDauTuGridDauTu();
            //this.LoadDVCungUngVT();
            CommonClass.loadTreeDonVi(treeDonVi);
        }
        public frmQuanLyUngTienMia(string ID)
        {
            InitializeComponent();
            CommonClass.loadTreeDonVi(treeDonVi);
            LoadHopDong1(ID);
            LoadThonSource();
            //LoadDDLHinhThucDauTuGridDauTu();

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
      /*  private DataSet LoadHopDong()
        {
            string strSQL = "SELECT * FROM tbl_HopDong WHERE 1=1";
            switch (nDonVi.Type)
            {
                case DonviType.Xa: strSQL += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviType.Thon: strSQL += " AND ThonID=" + nDonVi.DonViID; break;
                default: break;
            }
            if (this.chkTimkiemchinhxac.Checked)
            {

                strSQL += " AND (MaHopDong = N'" + DBModule.RefineString(edtTimKiem.Text) + "' OR HoTen = N'" + DBModule.RefineString(edtTimKiem.Text) + "' )";
            }
            else
            {

                strSQL += " AND (MaHopDong like N'%" + DBModule.RefineString(edtTimKiem.Text) + "%' OR HoTen like N'%" + DBModule.RefineString(edtTimKiem.Text) + "%' )";

            }
            return DBModule.ExecuteQuery(strSQL, null, null);
        }*/
        private void LoadThonSource()
        {
            string strSQL = "SELECT * FROM tbl_Thon";
            switch (nDonVi.Type)
            {
                case DonviType.Xa: strSQL += " WHERE ID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviType.Thon: strSQL += " WHERE ID=" + nDonVi.DonViID; break;
                default: break;
            }
            this.gridThonSource = DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridThonSource.Tables.Count > 0)
            {
                this.grdHopDong.DropDowns["Thon"].SetDataBinding(this.gridThonSource.Tables[0], "");
            }
        }
        private void LoadGrdTienUng() //LoadGrdDauTu
        {
            try
            {
                if (this.grdHopDong.GetValue("ID").ToString() != "")
                { 
                    hdID = this.grdHopDong.GetValue("ID").ToString(); 
                }
            }
            catch
            {
                hdID = ""; 
            }
            if (hdID != "")
            {
                this.grdUngTien.SetDataBinding(null, "");
                //string strSQL = "SELECT a.*, ISNULL(b.SoTien,0) as TienHoTro FROM tbl_DauTu as a LEFT JOIN tbl_HoTro as b ON b.DauTuID = a.[ID] Where a.HopDongID=" + this.grdHopDong.GetValue("ID").ToString() + " AND a.VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
                string strSQL = "Select ID,NgayUng,TienUng From tbl_UngTienMia Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + " AND HopDongID =" + grdHopDong.GetValue("ID").ToString();
                this.gridDataSourceGridEX2 = DBModule.ExecuteQuery(strSQL, null, null);
                if (this.gridDataSourceGridEX2.Tables.Count > 0)
                {
                    this.grdUngTien.SetDataBinding(this.gridDataSourceGridEX2.Tables[0], "");
                }
            }
        }
        private void LoadDVCungUngVT()
        { 
            try
            {
            string strSQL = "SELECT * FROM tbl_DonViCungUngVatTu";
            this.DVCUVT = DBModule.ExecuteQuery(strSQL, null, null);
            this.grdUngTien.DropDowns["ddlDVCungUngVT"].SetDataBinding(DVCUVT.Tables[0], "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể load đơn vị cung ứng vật tư");
            }
        }
     
        private void CreateDataSourceAndBindGrid(long lID)
        {
            DataSet ds;
            ds = clsHopDong.GetDanhSachDenHopDong(lID, this.edtTimKiem.Text, nDonVi.Type, nDonVi.DonViID, this.chkTimkiemchinhxac.Checked);
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
                 //if (!nDonVi.HasLoadChildren && nDonVi.Type == DonviType.Thon)
                 //{
                 //    CommonClass.LoadChildrenHopDong(treeDonVi.SelectedNode);
                 //    nDonVi.HasLoadChildren = true;
                 //}
                this.DoLoadGridHopDong(-1);
            }
        }
        private void DoLoadGridHopDong(long lID)
        {
            this.LoadThonSource();
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
                this.LoadGrdTienUng();
                uipDauTu.Text = "Khoản tạm ứng (" + grdHopDong.GetValue(2) + ")";                
            }
            catch
            {
                //grdThuaRuong.AllowAddNew = InheritableBoolean.False;
            }
        }
        private void uiButton1_Clic(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                if (this.uiCheckBox1.Checked)
                {
                    nDonVi = new NodeDonVi();
                    //nDonVi = (NodeDonVi)treeDonVi.Nodes[0].Tag;
                }
                this.DoLoadGridHopDong(-1);
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu tìm kiếm ", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void gridEX2_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa  thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }        
        
             
        private void frmQuanLyDauTu_Load(object sender, EventArgs e)
        {            
            this.WindowState = FormWindowState.Maximized;
        }  

        private void treeDonVi_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //label1.Text = treeDonVi.SelectedNode.Text;
            switch (nDonVi.Type)
            {
                case DonviType.Cum: label5.Text = "Chủ hợp đồng trong trạm : " + treeDonVi.SelectedNode.Text + ""; break;
                case DonviType.Xa: label5.Text = "Chủ hợp đồng của xã : " + treeDonVi.SelectedNode.Text + ""; break;
                case DonviType.Thon: label5.Text = "Chủ hợp đồng của thôn : " + treeDonVi.SelectedNode.Text + ""; break;
                //case DonviType.ChuHopDong: uiPanel3.Text = "Chủ hộ của hợp đồng : " + treeDonVi.SelectedNode.Text + ""; break;
                default: label5.Text = "Chủ hợp đồng"; break;
            }
           // uiPanel3.Text = "Hợp đồng (" + treeDonVi.SelectedNode.Text +")";
        }

        private void edtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (uiCheckBox1.Checked)
                {
                    nDonVi = (NodeDonVi)treeDonVi.Nodes[0].Tag;
                }
                this.DoLoadGridHopDong(-1);
            }
        }

        private void btinchitiet_Click(object sender, EventArgs e)
        {
            try
            {
                frmShowRP2 frm = new frmShowRP2();
                MDReport.rp_T_ChiTietDauTu rp = new MDSolution.MDReport.rp_T_ChiTietDauTu();
                                            
                rp.RecordSelectionFormula = "{View_ChiTietDauTu.HopDongID}=" + this.grdHopDong.GetValue("ID").ToString() + " AND {View_ChiTietDauTu.VuTrongID}=" + MDSolutionApp.VuTrongID.ToString();
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
            //if (e.Column.Key == "btnMenu")
            //{
            //    this.contextRight.Show(MousePosition);
            //}
        }

        //private void toolChitiethopdong_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(this.grdHopDong.GetValue("ID").ToString()))
        //        {
        //            long oID = long.Parse(this.grdHopDong.GetValue("ID").ToString());

        //            frmViewHopDong aa = new frmViewHopDong(oID);
        //            aa.MdiParent = this.MdiParent;
        //            aa.Show();
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
        //    }
        //}        

        //private void toolThietlapdientich_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string ID = this.grdHopDong.GetValue("ID").ToString();

        //        frmDienTichCoCauTrong frm = new frmDienTichCoCauTrong(ID);
        //        frm.MdiParent = this.MdiParent;
        //        frm.Show();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
        //    }
        //}

        //private void toolQuanlyhotro_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string ID = this.grdHopDong.GetValue("ID").ToString();

        //        frmDanhSachCacKhoanHoTro frm = new frmDanhSachCacKhoanHoTro(ID);
        //        frm.MdiParent = this.MdiParent;
        //        frm.Show();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
        //    }
        //}

        //private void toolLamthanhtoan_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string ID = this.grdHopDong.GetValue("ID").ToString();

        //        frmThanhToanCongNo frm = new frmThanhToanCongNo(ID);
        //        frm.MdiParent = this.MdiParent;
        //        frm.Show();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
        //    }
        //}

        //private void mnuChitiettrunodautu_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        frmThanhToan_DauTu_TruNo frm = new frmThanhToan_DauTu_TruNo(this.grdHopDong.GetValue("ID").ToString());
        //        frm.MdiParent = this.MdiParent;
        //        frm.Show();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
        //    }
        //}

        //private void chitiencoTruNo_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        frmThanhToan_TienCo_TruNo frm = new frmThanhToan_TienCo_TruNo(this.grdHopDong.GetValue("ID").ToString());
        //        frm.MdiParent = this.MdiParent;
        //        frm.Show();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
        //    }
        //}

       
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
                        grdUngTien.MoveNext();
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
                            MDDataSetForms.frmDauTu frm = new MDSolution.MDDataSetForms.frmDauTu(long.Parse(this.grdHopDong.GetValue("ID").ToString()), true);
                            frm.ShowDialog();
                            //LoadGrdDauTu();
                            try
                            {
                                GridEXFilterCondition condi = new GridEXFilterCondition(grdUngTien.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                                grdUngTien.Find(condi, 0, 1);
                            }
                            catch { }
                        }
                        else
                        {
                            MDDataSetForms.frmDauTu frm = new MDSolution.MDDataSetForms.frmDauTu(0, true);
                            frm.ShowDialog();
                            //LoadGrdDauTu();
                            try
                            {
                                GridEXFilterCondition condi = new GridEXFilterCondition(grdUngTien.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                                grdUngTien.Find(condi, 0, 1);
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
                            if (this.grdUngTien.GetValue("ID").ToString() != "")
                            {
                                MDDataSetForms.frmDauTu frm = new MDSolution.MDDataSetForms.frmDauTu(long.Parse(this.grdUngTien.GetValue("ID").ToString()), false);
                                frm.ShowDialog();
                                //LoadGrdDauTu();
                                try
                                {
                                    GridEXFilterCondition condi = new GridEXFilterCondition(grdUngTien.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                                    grdUngTien.Find(condi, 0, 1);
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
                        grdUngTien.CancelCurrentEdit();
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
                //MDDataSetForms.frmNhapUng frm = new MDSolution.MDDataSetForms.frmNhapUng(long.Parse(this.grdHopDong.GetValue("ID").ToString()), true);
                //frmNhapTienTamUng frm = new frmNhapTienTamUng(long.Parse(grdHopDong.GetValue("ID").ToString()), true);
                MDDataSetForms.frmUngTruocTienMia frm = new MDSolution.MDDataSetForms.frmUngTruocTienMia(long.Parse(grdHopDong.GetValue("ID").ToString()), true);
                frm.ShowDialog();
                LoadGrdTienUng();
                try
                {
                    GridEXFilterCondition condi = new GridEXFilterCondition(grdUngTien.Tables[0].Columns["ID"], ConditionOperator.Equal, frm.ID_UngTienMia);
                    grdUngTien.Find(condi, 0, 1);
                }
                catch { }
            }
            else
            {
                //MDDataSetForms.frmNhapUng frm = new MDSolution.MDDataSetForms.frmNhapUng(0, true);
                //frmNhapTienTamUng frm = new frmNhapTienTamUng(0, true);
                MDDataSetForms.frmUngTruocTienMia frm = new MDSolution.MDDataSetForms.frmUngTruocTienMia(0, true);
                frm.ShowDialog();
                LoadGrdTienUng();
                try
                {
                    GridEXFilterCondition condi = new GridEXFilterCondition(grdUngTien.Tables[0].Columns["ID"], ConditionOperator.Equal, frm.ID_UngTienMia);
                    grdUngTien.Find(condi, 0, 1);
                }
                catch { }
            }
        }

        private void uiButtonSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdUngTien.GetValue("ID").ToString() != "")
                {
                    // object objid = grdDauTu.GetValue("ID");
                    //MDDataSetForms.frmNhapUng frm = new MDSolution.MDDataSetForms.frmNhapUng(long.Parse(this.grdUngTien.GetValue("ID").ToString()), false);
                    if (Chek_SuaDLGoc())
                    { }
                    else
                    {
                        return;
                    }
                    //frmNhapTienTamUng frm = new frmNhapTienTamUng(long.Parse(grdUngTien.GetValue("ID").ToString()), false);
                    MDDataSetForms.frmUngTruocTienMia frm = new MDSolution.MDDataSetForms.frmUngTruocTienMia(long.Parse(grdUngTien.GetValue("ID").ToString()), false);
                    frm.ShowDialog();
                    LoadGrdTienUng();
                    try
                    {
                        GridEXFilterCondition condi = new GridEXFilterCondition(grdUngTien.Tables[0].Columns["ID"], ConditionOperator.Equal, frm.ID_UngTienMia);
                        grdUngTien.Find(condi, 0, 1);
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn một mục đầu tư để sửa", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Bạn phải chọn một mục đầu tư để sửa", "Thông báo");
            }
        }

        private bool Chek_SuaDLGoc()
        {
            string _NhapTienTraNoID;
            string  _DotThanhToan;
            string strSQL = "Select ID,DotThanhToan,NhapTienTraNoID From tbl_TruNo_DauTu Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " and DauTuID =" + grdUngTien.GetValue("ID").ToString() + " And ThuTu = '999'";//" and substring(LoaiHinhTruNo,1,1) = '0'";
            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);

            if(ds.Tables[0].Rows.Count == 0) return true;
            if (ds.Tables[0].Rows[0].IsNull("ID")) // chua load khoan nay vao tbl_truNo_dauTu
            {
                return true;
            }
            else
            {
                if (ds.Tables[0].Rows[0].IsNull("DotThanhToan"))  // dot thanh toan = null khoan nay chua dc thanh toan
                {
                    strSQL = "sp_ThanhToan_SuaDLGoc " + MDSolutionApp.VuTrongID.ToString() + "," + grdUngTien.GetValue("ID").ToString() + ",'0'" ;
                    DBModule.ExecuteNoneBackup(strSQL, null, null);
                    return true;
                }
                else //dot thanh toan # null --> khoan nay da dc thanh toan
                {
                    _DotThanhToan = ds.Tables[0].Rows[0]["DotThanhToan"].ToString();
                    if (!ds.Tables[0].Rows[0].IsNull("NhapTienTraNoID"))
                    {
                        _NhapTienTraNoID = ds.Tables[0].Rows[0]["NhapTienTraNoID"].ToString();
                        
                        string sql = "Select NgayTra,SoTien From tbl_NhapTienTraNo Where ID=" + _NhapTienTraNoID;
                        ds = DBModule.ExecuteQuery(sql, null, null);
                        DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["NgayTra"].ToString());
                        string sotien = ds.Tables[0].Rows[0]["SoTien"].ToString();
                        MessageBox.Show("Khoản đầu tư này đã được trừ nợ bằng nhập tiền trả nợ. \nNgày nhập tiền: " + dt.ToString("dd/MM/yyyy") + " \n Số tiền: " + sotien, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Khoản đầu tư này đã được thanh toán trong đợt " + _DotThanhToan + ".\nNếu muốn sửa phải thực hiện huỷ đợt thanh toán thứ " + _DotThanhToan, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return false;
                }
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
                    //clsDauTu oDT = new clsDauTu(long.Parse(this.grdUngTien.GetValue("ID").ToString()));
                    //oDT.Delete(null, null);
                    if (Chek_SuaDLGoc())
                    { }
                    else
                    {
                        return;
                    }
                    string strSQL = "Delete from tbl_UngTienMia Where ID =" + this.grdUngTien.GetValue("ID").ToString();
                    DBModule.ExecuteNoneBackup(strSQL, null, null);
                    LoadGrdTienUng();
                }
                else
                {
                    //LoadGrdTienUng();
                    //e.Cancel = true;
                }
            }
            catch
            {
                MessageBox.Show("Bạn phải chọn một bản ghi để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiButtonChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                frmShowRP2 frm = new frmShowRP2();
                MDReport.rp_T_ChiTietDauTu rp = new MDSolution.MDReport.rp_T_ChiTietDauTu();

                rp.RecordSelectionFormula = "{View_ChiTietDauTu.HopDongID}=" + this.grdHopDong.GetValue("ID").ToString() + " AND {View_ChiTietDauTu.VuTrongID}=" + MDSolutionApp.VuTrongID.ToString();
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

        private void grdUngTien_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }
          

    }
}