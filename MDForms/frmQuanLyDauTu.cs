using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using Janus.Windows.GridEX;
using DACASUCO.MDForms;
using DACASUCO.MDDataSetForms;
using DACASUCO.MDReport;
using MDSolution;

namespace MDSolution
{
    public partial class frmQuanLyDauTuNoCu : Form
    {
        static frmQuanLyDauTuNoCu _theformQuanLyDauTuNoCu;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmQuanLyDauTuNoCu OneInstanceFrm
        {
            get
            {
                if (null == _theformQuanLyDauTuNoCu || _theformQuanLyDauTuNoCu.IsDisposed)
                {
                    _theformQuanLyDauTuNoCu = new frmQuanLyDauTuNoCu();
                }

                return _theformQuanLyDauTuNoCu;
            }
        }

       // private clsHoTro oHT = new clsHoTro();
        private NodeDonVi nDonVi = new NodeDonVi();
        private DataSet gridDataSourceGridEX2;
        private clsHopDong oHD = new clsHopDong();
       // private DataSet gridThonSource;
        private DataSet DVCUVT;
        private clsDauTu oDT = new clsDauTu();
       // private clsDanhMucDauTu oDMDT = new clsDanhMucDauTu();
       // private clsDanhMucHoTro oDMHT = new clsDanhMucHoTro();
       // MDDataSetForms.frmDauTu frmChiTiet;
        private string hdID = "";
        //Khai bao cho phan Dau Tu
        //private DataSet ddlThuaRuongSource;        
        public frmQuanLyDauTuNoCu()
        {
            InitializeComponent();
            this.LoadDDLHinhThucDauTuGridDauTu();
            this.LoadDVCungUngVT();
            this.LoadDDLLoaiDauTu();
            CommonClass.loadTreeDonVi(treeDonVi);
        }
        public frmQuanLyDauTuNoCu(string ID)
        {
            InitializeComponent();
            CommonClass.loadTreeDonVi(treeDonVi);
            LoadHopDong1(ID);
            //LoadThonSource();
            LoadDDLHinhThucDauTuGridDauTu();

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
                //string strSQL = "SELECT a.*, ISNULL(b.SoTien,0) as TienHoTro FROM tbl_DauTu as a LEFT JOIN tbl_HoTro as b ON b.DauTuID = a.[ID] Where a.HopDongID=" + this.grdHopDong.GetValue("ID").ToString() + " AND a.VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                string strSQL = @"SELECT        dbo.tbl_DanhMucDauTu.Ten AS TenDanhMuc, dbo.tbl_DauTu.*
                            FROM            dbo.tbl_DauTu INNER JOIN
                         dbo.tbl_DanhMucDauTu ON dbo.tbl_DauTu.DanhMucDauTuID = dbo.tbl_DanhMucDauTu.ID  Where HopDongID=" + hdID + " AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                this.gridDataSourceGridEX2 = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                // gridDataSourceGridEX2.Tables[0].Columns.Add(
                if (this.gridDataSourceGridEX2.Tables.Count > 0)
                {
                    this.grdDauTu.SetDataBinding(this.gridDataSourceGridEX2.Tables[0], "");

                }
            }
        }
        private void LoadDVCungUngVT()
        { 
            try
            {
            string strSQL = "SELECT * FROM tbl_DonViCungUngVatTu";
            this.DVCUVT = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            this.grdDauTu.DropDowns["ddlDVCungUngVT"].SetDataBinding(DVCUVT.Tables[0], "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể load đơn vị cung ứng vật tư");
            }
        }
        private void LoadDDLLoaiDauTu()
        {
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery("Select * from tbl_LHDT", null, null);
            this.grdDauTu.DropDowns["DDL_LoaiDT"].SetDataBinding(ds.Tables[0], "");
        }
        private void LoadDDLHinhThucDauTuGridDauTu()
        {
            //Load ddlHinhThucDauTu cho cai GridEX2
            try
            {
                DataSet ds = clsDanhMucDauTu.GetListbyWhere("", " ID in (SELECT DanhMucDauTuID FROM [tbl_DanhMucDauTu_VuTrong] WHERE VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + ")", " ThuTu", null, null);                
                this.grdDauTu.DropDowns["ddlDanhMucDauTu"].SetDataBinding(ds.Tables[0], "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể load danh mục đầu tư");
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
                uipDauTu.Text = "Đầu tư (" + grdHopDong.GetValue(2) + ")";
                
            }
            catch
            {
                //grdThuaRuong.AllowAddNew = InheritableBoolean.False;
            }
        }
      
        private void gridEX2_AddingRecord(object sender, CancelEventArgs e)
        {
            if (!SaveDauTu(true)) { e.Cancel = true; }
            else
            {
                uiPanel2.Text = "F8-Thêm mới / F9-Sửa / F4-Chi tiết / Delete-Xóa / F6-In danh sách";
                //MessageBox.Show("Bạn đã lưu lại thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.grdHopDong.SetValue("ID", oHD.ID);
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
        private void gridEX2_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!SaveDauTu(false)) { e.Cancel = true; }
                else
                {
                    uiPanel2.Text = "F8-Thêm mới / F9-Sửa / F4-Chi tiết / Delete-Xóa / F6-In danh sách";
                    MessageBox.Show("Bạn đã sửa lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.gdVLVDauTu.SetValue("ID", oDMDT.ID);
                }
            }
            else
            {
                e.Cancel = true;
                LoadGrdDauTu();
            }
        }
        private bool SaveDauTu(bool isAddNew)
        {
            try
            {
                if (isAddNew)
                {
                    oDT = new clsDauTu();
                    oDT.HopDongID = long.Parse(this.grdHopDong.GetValue("ID").ToString());
                    oDT.VuTrongID = MDSolution.DACASUCO_App.VuTrongID;
                }
                else
                {
                    oDT.Load(null, null);
                }


                if (string.IsNullOrEmpty(this.grdDauTu.GetValue("LaiSuat").ToString())) throw new Exception("Bạn cho biết lãi xuất đầu tư?");
                if (float.Parse(this.grdDauTu.GetValue("LaiSuat").ToString()) < 0) throw new Exception("Lãi suất phải lớn hơn không hoặc bằng không");
                oDT.LaiSuat = decimal.Parse(this.grdDauTu.GetValue("LaiSuat").ToString());

                if (string.IsNullOrEmpty(this.grdDauTu.GetValue("NgayDauTu").ToString())) throw new Exception("Bạn cho biết ngày đầu tư?");
                oDT.NgayDauTu = (DateTime)this.grdDauTu.GetValue("NgayDauTu");
                oDT.GhiChu = this.grdDauTu.GetValue("GhiChu").ToString();
                oDT.DanhMucDauTuID = long.Parse(this.grdDauTu.GetValue("DanhMucDauTuID").ToString());

                //if (!string.IsNullOrEmpty(this.grdDauTu.GetValue("DotDauTu").ToString()))
                //{
                //    oDT.DotDauTu = long.Parse(this.grdDauTu.GetValue("DotDauTu").ToString());
                //}
                //else
                //{
                //    oDT.DotDauTu = 0;
                //}
                if (string.IsNullOrEmpty(this.grdDauTu.GetValue("SoTien").ToString()) && string.IsNullOrEmpty(this.grdDauTu.GetValue("SoLuong").ToString()) && string.IsNullOrEmpty(this.grdDauTu.GetValue("DonGia").ToString())) throw new Exception("Bạn phải nhập số lượng và đơn giá hoặc số tiền ");
                if (long.Parse(this.grdDauTu.GetValue("SoTien").ToString()) <= 0 && long.Parse(this.grdDauTu.GetValue("SoLuong").ToString()) <= 0 && long.Parse(this.grdDauTu.GetValue("DonGia").ToString()) <= 0) throw new Exception("Bạn phải nhập số lượng và đơn giá hoặc số tiền ");
                if (string.IsNullOrEmpty(this.grdDauTu.GetValue("SoTien").ToString())) throw new Exception("Kiểm tra lại số tiền nhập vào ");
                oDT.SoTien = decimal.Parse(this.grdDauTu.GetValue("SoTien").ToString());
                if (oDT.SoTien < 0) throw new Exception("Số tiền bạn nhập vào nhỏ hơn 0, kiểm tra lại");
                if (!string.IsNullOrEmpty(this.grdDauTu.GetValue("SoLuong").ToString()))
                    oDT.SoLuong = long.Parse(this.grdDauTu.GetValue("SoLuong").ToString());
                if (oDT.SoLuong < 0) throw new Exception("Số lượng bạn nhập vào nhỏ hơn 0, kiểm tra lại");
                if (!string.IsNullOrEmpty(this.grdDauTu.GetValue("DonGia").ToString()))
                    oDT.DonGia = long.Parse(this.grdDauTu.GetValue("DonGia").ToString());
                if (oDT.DonGia < 0) throw new Exception("Đơn giá bạn nhập vào nhỏ hơn 0, kiểm tra lại");
                decimal tempSoTien = oDT.SoLuong * oDT.DonGia;
                if (tempSoTien > 0 && oDT.SoTien >= 0 && oDT.SoTien != tempSoTien)
                {
                    if (MessageBox.Show("Số tiền " + oDT.SoTien.ToString("### ### ##0") + " nhập vào khác với tổng số lượng * đơn giá : " + oDT.SoLuong.ToString("### ### ##0") + "* " + oDT.DonGia.ToString("### ### ##0") + "\n Bạn muốn lưu giá trị nào? Yes để lưu số tiền được nhập vào, no để lưu tổng tính toán.", " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        oDT.SoTien = tempSoTien;
                    }
                }
                if (oDT.SoTien == 0)
                {
                    if (oDT.SoLuong == 0 || oDT.DonGia == 0) throw new Exception("Bạn phải nhập số tiền hoặc số lượng cùng đơn giá ");
                }
                if (string.IsNullOrEmpty(this.grdDauTu.GetValue("DonViCungUngVatTuID").ToString()))throw new Exception("Bạn chưa chọn đơn vị ứng vật tư ");
                 //oDT.DonViCungUngVatTuID = long.Parse(this.grdDauTu.GetValue("DonViCungUngVatTuID").ToString());
                               
                oDT.Save(null, null);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void gridEX2_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                if (this.grdDauTu.CurrentRow.RowType == Janus.Windows.GridEX.RowType.NewRecord)
                {
                    //lblTB.Text = "Bạn có thể nhập số tiền bằng đơn giá nhân số lượng hoặc nhập trực tiếp vào ô số tiền ";
                    oDT = new clsDauTu();                    
                }
                else
                {
                    oDT.ID = long.Parse(this.grdDauTu.GetValue("ID").ToString());
                }
            }
            catch
            {
                oDT = new clsDauTu();
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
        //        MessageBox.Show("Không có hợp đồng nào như vậy ", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}      
        private void frmQuanLyDauTu_Load(object sender, EventArgs e)
        {            
            this.WindowState = FormWindowState.Maximized;
            clsVuTrong oVT=new clsVuTrong(MDSolution.DACASUCO_App.VuTrongID);
            oVT.Load(null,null);
            lblInfor.Text = lblInfor.Text + " VỤ TRỒNG " + oVT.Ten;
        }   

        private void grdDauTu_UpdatingCell(object sender, UpdatingCellEventArgs e)
        {
            if (e.Column.Key == "DonGia")
            {
                long soluong;
                long dongia;
                try
                {
                    soluong = long.Parse(this.grdDauTu.GetValue("SoLuong").ToString());
                }
                catch
                {
                    soluong = 0;
                }
                try
                {
                    dongia = long.Parse(this.grdDauTu.GetValue("DonGia").ToString());
                }
                catch
                {
                    dongia = 0;
                }
                long sotien = dongia * soluong;
                this.grdDauTu.SetValue("SoTien", sotien);
            }
        }

        private void grdDauTu_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            //if (e.Column.Key == "TienHoTro")
            //{
            //    try {
            //        frmNhapTienHoTro frm = new frmNhapTienHoTro();
            //        frm.ChuHopDong = this.grdHopDong.GetValue("HoTen").ToString();
            //        frm.ChuHopDongID = long.Parse(this.grdHopDong.GetValue("ID").ToString());
            //        frm.DMDTID = long.Parse(this.grdDauTu.GetValue("DanhMucDauTuID").ToString());
            //        frm.DauTuID = long.Parse(this.grdDauTu.GetValue("ID").ToString());
            //        DateTime temp = DateTime.Parse(this.grdDauTu.GetValue("NgayDauTu").ToString());
            //        frm.NgayHoTro = temp;
            //        decimal tiendautu = (decimal)this.grdDauTu.GetValue("SoTien");
            //        frm.TienDauTu = tiendautu.ToString("### ### ##0");
            //        frm.LoadInfo();
            //        int Wherex = MousePosition.X;
            //        int Wherey = MousePosition.Y;
            //        if (Wherey + frm.Height > 768) Wherey = 768 - frm.Height;
            //        frm.SetDesktopLocation(Wherex, Wherey);
            //        frm.ShowDialog();

            //        if (frm.DialogResult == DialogResult.OK)
            //        {
            //            MessageBox.Show("Tiền hỗ trợ cho khoản mục đầu tư đã được cập nhật");
            //            this.LoadGrdDauTu();
            //        }
            //    }
            //    catch {
            //        //MessageBox.Show("Có lỗi khi nhập tiền hỗ trợ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }

            //}

            if (e.Column.Key == "AddNew")
            {
                DACASUCO.MDDataSetForms.frmDauTu frm = new DACASUCO.MDDataSetForms.frmDauTu(long.Parse(this.grdHopDong.GetValue("ID").ToString()), true);
                frm.ShowDialog();
                LoadGrdDauTu();
            }
            if (e.Column.Key == "Edit")
            {
                if (this.grdDauTu.GetValue("ID").ToString() != "")
                {
                    DACASUCO.MDDataSetForms.frmDauTu frm = new DACASUCO.MDDataSetForms.frmDauTu(long.Parse(this.grdDauTu.GetValue("ID").ToString()), false);
                    frm.ShowDialog();
                    LoadGrdDauTu();
                }
            }
        }

        private void treeDonVi_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //label1.Text = treeDonVi.SelectedNode.Text;
            switch (nDonVi.Type)
            {
                case DonviTypeHD.Cum: label5.Text = "Chủ mía trong trạm : " + treeDonVi.SelectedNode.Text + ""; break;
                case DonviTypeHD.Xa: label5.Text = "Chủ mía của xã : " + treeDonVi.SelectedNode.Text + ""; break;
                case DonviTypeHD.Thon: label5.Text = "Chủ mía của thôn : " + treeDonVi.SelectedNode.Text + ""; break;
                //case DonviTypeHD.ChuHopDong: uiPanel3.Text = "Chủ hộ của hợp đồng : " + treeDonVi.SelectedNode.Text + ""; break;
                default: label5.Text = "Chủ mía"; break;
            }
           // uiPanel3.Text = "Hợp đồng (" + treeDonVi.SelectedNode.Text +")";
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
            
        }

        private void uiButtonSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdDauTu.GetValue("ID").ToString() != "")
                {
                   
                    if (Chek_SuaDLGoc())
                    { }
                    else
                    {
                        return;
                    }
                   // object objid = grdDauTu.GetValue("ID");
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
        }

        private bool Chek_SuaDLGoc()
        {
            string _DotThanhToan = "";
            string _NhapTienTraNoID = "";

            try
            {
                string strSQL = "SELECT tbl_DauTu.DonViCungUngVatTuID, tbl_DanhMucDauTu.LoaiHinhDauTuID"
                    + " FROM  tbl_DanhMucDauTu INNER JOIN "
                    + " tbl_DauTu ON tbl_DanhMucDauTu.ID = tbl_DauTu.DanhMucDauTuID Where tbl_DauTu.ID=" + grdDauTu.GetValue("ID").ToString();
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);

                string donvi;
                string LoaiDauTu;
                donvi = ds.Tables[0].Rows[0]["DonViCungUngVatTuID"].ToString();
                LoaiDauTu = ds.Tables[0].Rows[0]["LoaiHinhDauTuID"].ToString();

                long ThuTu;
                if (donvi == "1")
                {
                    ThuTu = 1;
                }
                else
                {
                    switch (LoaiDauTu)
                    {
                        case "1":
                            ThuTu = 7;
                            break;
                        case "4":
                            ThuTu = 8;
                            break;
                        case "2":
                            ThuTu = 9;
                            break;
                        case "5":
                            ThuTu = 10;
                            break;
                        case "3":
                            ThuTu = 11;
                            break;
                        default:
                            ThuTu = 11;
                            break;
                    }

                }
                if (ThuTu != 10 && ThuTu != 11)
                    strSQL = "Select ID, DotThanhToan, NhapTienTraNoID From tbl_TruNo_DauTu Where VuTrongID =" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " and DauTuID=" + grdDauTu.GetValue("ID").ToString() + " and substring(LoaiHinhTruNo,1,1) ='" + ThuTu.ToString() + "'";
                else
                    strSQL = "Select ID, DotThanhToan, NhapTienTraNoID From tbl_TruNo_DauTu Where VuTrongID =" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " and DauTuID=" + grdDauTu.GetValue("ID").ToString() + " and substring(LoaiHinhTruNo,1,2) ='" + ThuTu.ToString() + "'";
                
                DataSet ds1 = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                if (ds1.Tables[0].Rows.Count == 0) return true;
                if (ds1.Tables[0].Rows[0].IsNull("ID")) // khoan dau tu chua dc load vao
                {
                    return true;
                }
                else
                {
                    if (ds1.Tables[0].Rows[0].IsNull("DotThanhToan")) // co khoan dtu va dot thanh toan = null
                    {
                        strSQL = "sp_ThanhToan_SuaDLGoc " + MDSolution.DACASUCO_App.VuTrongID.ToString() + "," + grdDauTu.GetValue("ID").ToString() + ",'" + ThuTu.ToString() + "'";
                        MDSolutionEntities.DBModule.ExecuteNoneBackup(strSQL, null, null);
                        return true;
                    }
                    else // khoan dau tu da dc thanh toan
                    {
                        _DotThanhToan = ds1.Tables[0].Rows[0]["DotThanhToan"].ToString();
                        if (!ds1.Tables[0].Rows[0].IsNull("NhapTienTraNoID"))
                        {
                            _NhapTienTraNoID = ds1.Tables[0].Rows[0]["NhapTienTraNoID"].ToString();
                            string sql = "Select NgayTra,SoTien From tbl_NhapTienTraNo Where ID=" + _NhapTienTraNoID;
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void uiButtonXoa_Click(object sender, EventArgs e)
        {try
            {
            string message;
            message = String.Format("Bạn muốn xóa bản ghi này?");

            if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //DataRowView dr = (DataRowView).Row.DataRow;
                if (Chek_SuaDLGoc())
                { }
                else
                {
                    return;
                }
                clsDauTu oDT = new clsDauTu(long.Parse(this.grdDauTu.GetValue("ID").ToString()));
                oDT.Delete(null, null);

                LoadGrdDauTu();
            }
            else
            {
                LoadGrdDauTu();
                //e.Cancel = true;
            }
        }
        catch { MessageBox.Show("Bạn phải chọn một mục đầu tư để xóa", "Thông báo"); }
        }

        private void uiButtonChiTiet_Click(object sender, EventArgs e)
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

        private void edtTimKiem_TextChanged(object sender, EventArgs e)
        {
            //this.grdHopDong.DataSource = null;
            //DataSet dr;
            //string str = "";

            //str = "SELECT * FROM tbl_HopDong WHERE 1=1 ";

            //if (!string.IsNullOrEmpty(edtTimKiem.Text))
            //{
            //    string Ten = MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text);
            //    if (this.chkTimkiemchinhxac.Checked)
            //    {
            //        str += " AND  HoTen = N'" + Ten + "'";
            //    }
            //    else
            //    {
            //        str += " AND  dbo.BoDauTiengViet(HoTen) like N'%" + Ten + "%'";
            //    }

            //    dr = MDSolutionEntities.DBModule.ExecuteQuery(str, null, null);
            //    if (dr.Tables[0].Rows.Count > 0)
            //    {
            //        this.grdHopDong.SetDataBinding(dr.Tables[0], "");
            //    }

            //}
        }

    }
}