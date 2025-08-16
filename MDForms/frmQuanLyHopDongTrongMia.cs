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

namespace MDSolution
{
    public partial class frmQuanLyHopDongTrongMia : Form
    {
        static frmQuanLyHopDongTrongMia _theformQuanLyHopDongTrongMia;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmQuanLyHopDongTrongMia OneInstanceFrm
        {
            get
            {
                if (null == _theformQuanLyHopDongTrongMia || _theformQuanLyHopDongTrongMia.IsDisposed)
                {
                    _theformQuanLyHopDongTrongMia = new frmQuanLyHopDongTrongMia();
                }

                return _theformQuanLyHopDongTrongMia;
            }
        }

        private clsHopDong oHopDong = new clsHopDong();
        private string strPass = "";
        private DataSet gridDataSource;
        //frm_HopDongTrongMiaEdit frmChiTiet;
        public frmQuanLyHopDongTrongMia()
        {
            InitializeComponent();

        }

        private DataSet LoadHopDong()
        {
            string strSQL = "";
            strSQL = "SELECT ID,MaHopDong,HoTen,NgaySinh,SoCMT,NgayCap,NoiCap,DiaChi,SoDT FROM tbl_HopDong WHERE 1=1 ";
            if ((this.chkTimkiemchinhxac.Checked) && (edtTimKiem.Text != ""))
            {
                strSQL += " AND (MaHopDong = N'" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "' OR HoTen = N'" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "' )";
            }
            else
            {
                strSQL += " AND (MaHopDong like N'%" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "%' OR HoTen like N'%" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "%' )";
            }
            return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
        }

        private void CreateDataSourceAndBindGrid()
        {
            gridDataSource = this.LoadHopDong();
            if (gridDataSource.Tables.Count > 0)
            {
                this.gdCM.SetDataBinding(gridDataSource.Tables[0], "");
            }
        }



        private void DoLoadGridHopDong()
        {
            // this.LoadThonSource();
            this.CreateDataSourceAndBindGrid();
            this.gdCM.Focus();
            gdCM.MoveFirst();
            this.gdCM.Tables[0].Columns["MaHopDong"].DefaultValue = this.GetMaHopDong();
            // this.GridEX1.Tables[0].Columns["NgayKyHopDong"].DefaultValue = DateTime.Now;
        }

        private void GridEX1_RecordAdded(object sender, EventArgs e)
        {
            //MessageBox.Show("Đã thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DoLoadGridHopDong();
            this.gdCM.Refetch();
            this.gdCM.Tables[0].Columns["MaHopDong"].DefaultValue = this.GetMaHopDong();
        }
        private bool IsExistingHoTen(bool isAddnew, string strHoTen, long lThonID)
        {
            if (isAddnew)
            {
                string strSQL = "SELECT Count(*) FROM tbl_HopDong WHERE 1=1 And (rTrim(lTrim([HoTen])) = rTrim(lTrim(N'" + strHoTen + "')))";
                strSQL += " AND ThonID =  " + lThonID.ToString();
                string ret = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else
            {
                string strSQL = "SELECT * FROM tbl_HopDong WHERE 1=1 And (rTrim(lTrim([HoTen])) = rTrim(lTrim(N'" + strHoTen + "')))";
                strSQL += " AND ThonID =  " + lThonID.ToString();
                DataSet ds;
                ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow d13 = ds.Tables[0].Rows[0];

                    if (d13["ID"].ToString() != this.gdCM.GetValue("ID").ToString())
                    { return true; }
                    else { return false; }

                }
                else { return false; }

            }
        }
        private bool IsExistingMHD(bool isAddnew, string ContractCode)
        {
            if (isAddnew)
            {
                string SQL = " select Count(*) from tbl_HopDong where MaHopDong = '" + ContractCode + "'";
                string ret = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else
            {
                string SQL = " select * from tbl_HopDong where MaHopDong = '" + ContractCode + "'";
                DataSet ds;
                ds = MDSolutionEntities.DBModule.ExecuteQuery(SQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow d13 = ds.Tables[0].Rows[0];

                    if (d13["ID"].ToString() != this.gdCM.GetValue("ID").ToString())
                    { return true; }
                    else { return false; }
                }
                else { return false; }
            }
        }
        private bool IsExistingCMT(string CMT)
        {
            if (!string.IsNullOrEmpty(CMT))
            {
                string SQL = " select Count(*) from tbl_HopDong where SoCMT = '" + CMT + "'";
                string ret = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else { return false; }
        }
        private void GridEX1_AddingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                GridEX gr = (GridEX)sender;
                long pID = 0;
                if (gr.Name == "GridEX1")
                {
                    pID = 0;
                }
                else
                {
                    pID = long.Parse(gdCM.GetValue("ID").ToString());
                }
                if (!this.SaveHopDong(true, pID))
                {

                    e.Cancel = true;
                    //this.GridEX1.Refetch();
                }
                else
                {
                    if (gr.Name == "GridEX1")
                    {
                        this.gdCM.SetValue("ID", oHopDong.ID);
                    }
                    else
                    {
                        this.gdHDDT.SetValue("ID", oHopDong.ID);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Khi lưu có lỗi,kiểm tra lại");

            }
        }
        private void GridEX1_RecordUpdated(object sender, EventArgs e)
        {
            MessageBox.Show("Đã cập nhật thành công thông tin được thay đổi");
            this.gdCM.Refetch();
        }

        private bool SaveHopDong(bool isAddNew, long ParentID)
        {

            try
            {
                if (isAddNew)
                {
                    oHopDong = new clsHopDong();
                }
                else
                {
                    oHopDong.ID = long.Parse(this.gdCM.GetValue("ID").ToString());
                    oHopDong.Load(null, null);
                }

                if (ParentID == 0)
                {
                    //HopDong:
                    if (string.IsNullOrEmpty(this.gdCM.GetValue("ThonID").ToString())) throw new Exception("Bạn chưa cho biết chủ hợp đồng thuộc thôn nào");

                    oHopDong.ThonID = long.Parse(this.gdCM.GetValue("ThonID").ToString());

                    if (string.IsNullOrEmpty(this.gdCM.GetValue("MaHopDong").ToString())) throw new Exception("Bạn chưa cho biết mã hợp đồng");
                    oHopDong.MaHopDong = this.gdCM.GetValue("MaHopDong").ToString();
                    if (IsExistingMHD(isAddNew, oHopDong.MaHopDong)) throw new Exception("Mã hợp đồng đã có trong đơn vị");
                    if (string.IsNullOrEmpty(this.gdCM.GetValue("HoTen").ToString())) throw new Exception("Bạn chưa cho biết họ tên của chủ hợp đồng");
                    oHopDong.HoTen = this.gdCM.GetValue("HoTen").ToString();
                    if (this.IsExistingHoTen(isAddNew, oHopDong.HoTen, oHopDong.ThonID))
                    {
                        if (MessageBox.Show("Đã có hợp đồng có họ tên như vậy trong thôn này, bạn có muốn tiếp tục không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return false;
                        }
                    }

                    if (string.IsNullOrEmpty(this.gdCM.GetValue("NgaySinh").ToString()))// throw new Exception("Bạn chưa cho biết ngày sinh của chủ hợp đồng");
                    { }
                    else
                    {
                        if (DateTime.Parse(this.gdCM.GetValue("NgaySinh").ToString()) > DateTime.Now) throw new Exception("Bạn không được nhập ngày sinh lớn hơn ngày hiện tại");
                        oHopDong.NgaySinh = (DateTime)this.gdCM.GetValue("NgaySinh");
                    }
                    oHopDong.SoCMT = this.gdCM.GetValue("SoCMT").ToString();
                    if (isAddNew && IsExistingCMT(oHopDong.SoCMT)) throw new Exception("Số chứng minh thư đã có trong đơn vị");

                    if (string.IsNullOrEmpty(this.gdCM.GetValue("NgayCap").ToString()))
                    { }
                    else
                    {// throw new Exception("Bạn chưa cho biết ngày cấp chứng minh thư của chủ hợp đồng");
                        if (DateTime.Parse(this.gdCM.GetValue("NgayCap").ToString()) > DateTime.Now) throw new Exception("Bạn không được nhập ngày cấp CMT lớn hơn ngày hiện tại");
                        oHopDong.NgayCap = (DateTime)this.gdCM.GetValue("NgayCap");
                    }
                    oHopDong.NoiCap = this.gdCM.GetValue("NoiCap").ToString();
                    oHopDong.NguoiThuaKe1Ten = this.gdCM.GetValue("NguoiThuaKe1Ten").ToString();
                    oHopDong.NguoiThuaKe1CMT = this.gdCM.GetValue("NguoiThuaKe1CMT").ToString();
                    oHopDong.NguoiThuaKe1DiaChi = this.gdCM.GetValue("NguoiThuaKe1DiaChi").ToString();
                    //oHopDong.NguoiThuaKe2Ten = this.gdCM.GetValue("NguoiThuaKe2Ten").ToString();
                    //oHopDong.NguoiThuaKe2CMT = this.gdCM.GetValue("NguoiThuaKe2CMT").ToString();
                    //oHopDong.NguoiThuaKe2DiaChi = this.gdCM.GetValue("NguoiThuaKe2DiaChi").ToString();
                    oHopDong.TrangThai = long.Parse(this.gdCM.GetValue("TrangThai").ToString());
                    //oHopDong.ParentID = ParentID;
                    //if (string.IsNullOrEmpty(this.gdCM.GetValue("NgayKyHopDong").ToString())) throw new Exception("Bạn chưa cho biết ngày ký hợp đồng");
                    //oHopDong.NgayKyHopDong = (DateTime)this.gdCM.GetValue("NgayKyHopDong");
                }
                else
                {
                    //Chu ho:
                    if (string.IsNullOrEmpty(this.gdHDDT.GetValue("ThonID").ToString())) throw new Exception("Bạn chưa cho biết chủ hợp đồng thuộc thôn nào");

                    oHopDong.ThonID = long.Parse(this.gdHDDT.GetValue("ThonID").ToString());

                    if (string.IsNullOrEmpty(this.gdHDDT.GetValue("MaHopDong").ToString())) throw new Exception("Bạn chưa cho biết mã hợp đồng");
                    oHopDong.MaHopDong = this.gdHDDT.GetValue("MaHopDong").ToString();
                    if (IsExistingMHD(isAddNew, oHopDong.MaHopDong)) throw new Exception("Mã hợp đồng đã có trong đơn vị");
                    if (string.IsNullOrEmpty(this.gdHDDT.GetValue("HoTen").ToString())) throw new Exception("Bạn chưa cho biết họ tên của chủ hợp đồng");
                    oHopDong.HoTen = this.gdHDDT.GetValue("HoTen").ToString();
                    if (this.IsExistingHoTen(isAddNew, oHopDong.HoTen, oHopDong.ThonID))
                    {
                        if (MessageBox.Show("Đã có hợp đồng có họ tên như vậy trong thôn này, bạn có muốn tiếp tục không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return false;
                        }
                    }

                    if (string.IsNullOrEmpty(this.gdHDDT.GetValue("NgaySinh").ToString()))// throw new Exception("Bạn chưa cho biết ngày sinh của chủ hợp đồng");
                    { }
                    else
                    {
                        if (DateTime.Parse(this.gdHDDT.GetValue("NgaySinh").ToString()) > DateTime.Now) throw new Exception("Bạn không được nhập ngày sinh lớn hơn ngày hiện tại");
                        oHopDong.NgaySinh = (DateTime)this.gdHDDT.GetValue("NgaySinh");
                    }
                    oHopDong.SoCMT = this.gdHDDT.GetValue("SoCMT").ToString();
                    if (isAddNew && IsExistingCMT(oHopDong.SoCMT)) throw new Exception("Số chứng minh thư đã có trong đơn vị");

                    if (string.IsNullOrEmpty(this.gdHDDT.GetValue("NgayCap").ToString()))
                    { }
                    else
                    {// throw new Exception("Bạn chưa cho biết ngày cấp chứng minh thư của chủ hợp đồng");
                        if (DateTime.Parse(this.gdHDDT.GetValue("NgayCap").ToString()) > DateTime.Now) throw new Exception("Bạn không được nhập ngày cấp CMT lớn hơn ngày hiện tại");
                        oHopDong.NgayCap = (DateTime)this.gdHDDT.GetValue("NgayCap");
                    }
                    oHopDong.NoiCap = this.gdHDDT.GetValue("NoiCap").ToString();
                    oHopDong.NguoiThuaKe1Ten = this.gdHDDT.GetValue("NguoiThuaKe1Ten").ToString();
                    oHopDong.NguoiThuaKe1CMT = this.gdHDDT.GetValue("NguoiThuaKe1CMT").ToString();
                    oHopDong.NguoiThuaKe1DiaChi = this.gdHDDT.GetValue("NguoiThuaKe1DiaChi").ToString();
                    //oHopDong.NguoiThuaKe2Ten = this.gdHDDT.GetValue("NguoiThuaKe2Ten").ToString();
                    //oHopDong.NguoiThuaKe2CMT = this.gdHDDT.GetValue("NguoiThuaKe2CMT").ToString();
                    //oHopDong.NguoiThuaKe2DiaChi = this.gdHDDT.GetValue("NguoiThuaKe2DiaChi").ToString();
                    oHopDong.TrangThai = long.Parse(this.gdHDDT.GetValue("TrangThai").ToString());
                    //oHopDong.ParentID = ParentID;
                    //if (string.IsNullOrEmpty(this.gdHDDT.GetValue("NgayKyHopDong").ToString())) throw new Exception("Bạn chưa cho biết ngày ký hợp đồng");
                    //oHopDong.NgayKyHopDong = (DateTime)this.gdHDDT.GetValue("NgayKyHopDong");
                }
                //----Save
                oHopDong.Save(null, null);
                clsHopDong.UpdateHopDongVuTrong(oHopDong.ID, MDSolution.DACASUCO_App.VuTrongID, oHopDong.TrangThai, null, null);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }


        private void GridEX1_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {
            GridEX gr = (GridEX)sender;
            long ID_;
            string message;

            if (gr.Name == "GridEX1")
            {
                ID_ = long.Parse(this.gdCM.GetValue("ID").ToString());
                message = "Bạn muốn xóa HĐ chính đang chọn?";
            }
            else
            {
                ID_ = long.Parse(this.gdHDDT.GetValue("ID").ToString());
                message = "Bạn muốn xóa chủ hộ đang chọn?";
            }


            if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //clsHopDong oHD = new clsHopDong(long.Parse(dr.Row.ItemArray[0].ToString()));
                clsHopDong.Delete(ID_, null, null);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void GridEX1_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.gdCM.Refetch();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

            this.gdCM.DataSource = null;
            DataSet dr;
            string str = "";

            str = "SELECT ID,MaHopDong,HoTen,NgaySinh,SoCMT,NgayCap,NoiCap,DiaChi,SoDT FROM tbl_HopDong WHERE 1=1 ";

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
                    this.gdCM.SetDataBinding(dr.Tables[0], "");
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

        private void edtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                DataSet dr;
                string str = "";

                str = "SELECT ID,MaHopDong,HoTen,NgaySinh,SoCMT,NgayCap,NoiCap,DiaChi,SoDT FROM tbl_HopDong WHERE 1=1 ";

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

                        this.gdCM.SetDataBinding(dr.Tables[0], "");
                    }
                }
            }
        }



        private void GridEX1_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GridEX gr = (GridEX)sender;
                long pID = 0;
                if (gr.Name == "GridEX1")
                {
                    pID = 0;
                }
                else
                {
                    pID = long.Parse(gdCM.GetValue("ID").ToString());
                }
                if (!this.SaveHopDong(false, pID))
                {
                    e.Cancel = true;
                    //this.GridEX1.Refetch();
                }
            }
            else
            {
                this.DoLoadGridHopDong();
                e.Cancel = true;
                //this.GridEX1.Refetch();
            }
        }

        private string GetMaHopDong()
        {
            //try
            //{
            //    string strXaID = "";
            //    // nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
            //    if (nDonVi.Type == DonviType.Xa)
            //    {
            //        strXaID = nDonVi.DonViID;
            //    }
            //    else if (nDonVi.Type == DonviType.Thon)
            //    {
            //        clsThon oThon = new clsThon(long.Parse(nDonVi.DonViID));
            //        oThon.Load(null, null);
            //        strXaID = oThon.XaID.ToString();
            //    }
            //    string strSQL = "SELECT [MaXa] FROM tbl_Xa Where [ID]=" + strXaID;
            //    string maXa = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
            //    string strMaxID = "";
            //    int batdau = maXa.Trim().Length +1;
            //    strSQL = "SELECT max(cast(ltrim(rtrim(substring(mahopdong,"+batdau.ToString()+", 10))) as numeric(10))) FROM tbl_HopDong WHERE ThonID in (SELECT [id] FROM tbl_Thon WHERE XaID =" + strXaID + ") ";
            //    strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
            //    if (strMaxID == "") strMaxID = "0";
            //    int intMaxID = int.Parse(strMaxID);
            //    intMaxID++;
            //    return maXa + intMaxID.ToString();
            //}
            //catch
            //{
            //    return "";
            //}
            return "";

        }

        private void frmQuanLyHopDongTrongMia_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            lblNienVu.Text = DACASUCO_App.TenVuTrong;
        }
        public void GetThonID(string strPassValue)
        {
            strPass = strPassValue;
        }
        //private void GridEX1_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        //{

        //    GridEX gr = (GridEX)sender;
        //    bool isGridEX1 = true;
        //    if (gr.Name == "GridEX1")
        //    {
        //        isGridEX1 = true;
        //    }
        //    else
        //    {
        //        isGridEX1 = false;
        //    }

        //    if (e.Column.Key == "TenThon")
        //    {

        //        //NodeDonVi TnDonVi  = (NodeDonVi)treeDonVi.SelectedNode.Tag;

        //        dlgChonThonChoThuaRuong frm = new dlgChonThonChoThuaRuong(nDonVi.DonViName, nDonVi.DonViID, nDonVi.Type);
        //        frm.passID = new dlgChonThonChoThuaRuong.PassID(GetThonID);
        //        int Wherex = MousePosition.X;
        //        int Wherey = MousePosition.Y;
        //        if (Wherey + frm.Height > 768) Wherey = 768 - frm.Height;
        //        if (Wherex + frm.Width > 1024) Wherex = 1024 - frm.Width;
        //        frm.SetDesktopLocation(Wherex, Wherey);
        //        frm.ShowDialog();

        //        if (frm.DialogResult == DialogResult.OK)
        //        {
        //            try
        //            {
        //                int Post = strPass.IndexOf("$");
        //                string str = strPass.Substring(0, Post);
        //                if (isGridEX1 == true)
        //                {
        //                    this.GridEX1.SetValue("ThonID", long.Parse(str));
        //                    this.GridEX1.SetValue("TenThon", strPass.Substring(Post + 1));
        //                }
        //                else
        //                {
        //                    this.gridEX2.SetValue("ThonID", long.Parse(str));
        //                    this.gridEX2.SetValue("TenThon", strPass.Substring(Post + 1));
        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //                if (isGridEX1 == true)
        //                {
        //                    this.GridEX1.SetValue("ThonID", -1);
        //                    this.GridEX1.SetValue("TenThon", "");
        //                }
        //                else
        //                {
        //                    this.gridEX2.SetValue("ThonID", -1);
        //                    this.gridEX2.SetValue("TenThon", "");
        //                }
        //            }

        //        }
        //    }
        //    if (e.Column.Key == "btnmenu")
        //    {
        //        if (isGridEX1 == true)
        //        {
        //            ToolStripMenuItemThemChuHoDaCo.Enabled = true;
        //            ToolStripMenuItemChuyenThanhHD.Enabled = false;
        //            ToolStripMenuItemChuyenHDChinhKhac.Enabled = false;
        //            if (GridEX1.SelectedItems[0].RowType == RowType.NewRecord) return;
        //        } 
        //        else
        //        {
        //            ToolStripMenuItemThemChuHoDaCo.Enabled = false;
        //            ToolStripMenuItemChuyenThanhHD.Enabled = true;
        //            ToolStripMenuItemChuyenHDChinhKhac.Enabled = true;
        //            if (gridEX2.SelectedItems[0].RowType == RowType.NewRecord) return;
        //        }


        //        this.contextRight.Show(MousePosition);
        //    }
        //}



        private DataSet LoadHDDT(long HDID)
        {
            string strSQL = "";
            if (HDID > 0)
            {
                strSQL = @"SELECT * from V_HDDT Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " AND HopDongID=" + HDID.ToString();
            }
            else
            {
                strSQL = @"SELECT * from V_HDDT Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            }

            return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
        }

        private void GridEX1_SelectionChanged(object sender, EventArgs e)
        {
            gdHDDT.SetDataBinding(null, "");
            try
            {
                DataTable dt = LoadHDDT(long.Parse(this.gdCM.GetValue("ID").ToString())).Tables[0];

                {
                    gdHDDT.SetDataBinding(dt, "");

                }
            }
            catch { gdHDDT.SetDataBinding(null, ""); }
        }


        private void btThem_Click(object sender, EventArgs e)
        {
            frm_HopDongTrongMiaEdit frmChiTiet = new frm_HopDongTrongMiaEdit();
            frmChiTiet.Themmoi_Click = true;// Them_Click(null, null);
            //try
            //{
            //    nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
            //    if (nDonVi.Type == DonviType.Xa)
            //        frmChiTiet._ThonID = long.Parse(nDonVi.DonViID);
            //}
            //catch { }
            //try
            //{
            //    frmChiTiet._ThonID = long.Parse(GridEX1.GetValue("ThonID").ToString());
            //}
            //catch { }
            frmChiTiet.ShowDialog();
            try
            {
                //nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                this.DoLoadGridHopDong();
            }
            catch { }
            try
            {
                GridEXFilterCondition condi = new GridEXFilterCondition(gdCM.Tables[0].Columns["ID"], ConditionOperator.Equal, frmChiTiet._ID);
                gdCM.Find(condi, 0, 1);
            }
            catch { }
        }

        private void btSua_Click(object sender, EventArgs e)
        {

            try
            {
                frm_HopDongTrongMiaEdit frmChiTiet = new frm_HopDongTrongMiaEdit();
                object objid = gdCM.GetValue("ID");
                //frmChiTiet.tbl_HopDongBindingSource.Filter = "ID=" + GridEX1.GetValue("ID").ToString();
                frmChiTiet._ID = long.Parse(gdCM.GetValue("ID").ToString());
                frmChiTiet._PerentID = 0;
                try
                {
                    //    nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                    //    if (nDonVi.Type == DonviType.Thon)
                    //        frmChiTiet._ThonID = long.Parse(nDonVi.DonViID);
                }
                catch { }
                try
                {
                    // frmChiTiet._ThonID = long.Parse(GridEX1.GetValue("ThonID").ToString());
                }
                catch { }
                frmChiTiet.ShowDialog();

                try
                {
                    // nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                    this.DoLoadGridHopDong();
                }
                catch { }
                GridEXFilterCondition condi = new GridEXFilterCondition(gdCM.Tables[0].Columns["ID"], ConditionOperator.Equal, objid);
                gdCM.Find(condi, 0, 1);
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn hđ cần sửa", "Thông báo");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            long HDID = 0;
            try
            {
                HDID = long.Parse(this.gdCM.GetValue("ID").ToString());
            }
            catch
            {
                MessageBox.Show("Bạn phải chọn Chủ mía để Xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (HDID > 0)
            {
                clsHopDong oHD = new clsHopDong(HDID);
                oHD.Load(null, null);
                string HT = oHD.HoTen;
                string SoCMT = oHD.SoCMT;
                string DC = oHD.DiaChi;
                string SDT = oHD.SoDT;
                string SLHD = "";
                string sql = "";
                long SoHD = 0;
                //Số lượng HĐ ĐT của chủ mía
                sql = "Select IsNull(Count(MaHDDT),0) from tbl_HopDongDauTu Where HopDongID=" + HDID.ToString();
                try
                {
                    SoHD = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null).ToString());
                }
                catch
                {
                    SoHD = 0;
                }
                if (SoHD == 0)
                {
                    SLHD = "Không có HĐĐT nào";
                }
                else
                {
                    SLHD = "Tồn tại HĐĐT trong các niên vụ";
                }
                frmXoaCM_CF frm = new frmXoaCM_CF(HT, SoCMT, DC, SDT, SLHD);
                frm.ShowDialog();
                if (frm.OK == 1)
                {
                    try
                    {

                        MDSolutionEntities.DBModule.ExecuteQuery("Delete from tbl_hopdong where id=" + HDID.ToString(), null, null);
                        MessageBox.Show("Đã xoá Chủ mía " + oHD.HoTen + " !", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DoLoadGridHopDong();
                    }
                    catch
                    {
                        MessageBox.Show("Đã có lỗi khi xoá Chủ mía!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.gdCM.GetValue("ID").ToString()))
                {
                    long oID = long.Parse(this.gdCM.GetValue("ID").ToString());

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


        private void cmdEditHDDT_Click(object sender, EventArgs e)
        {
            string MaHD = "";
            long HDID = 0;
            try
            {
                MaHD = this.gdHDDT.GetValue("MaHDDT").ToString();
                HDID = long.Parse(this.gdHDDT.GetValue("HopDongID").ToString());
            }
            catch
            {
                MessageBox.Show("Bạn phải chọn HĐĐT để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            if ((MaHD != "") && (HDID > 0))
            {
                frmDM_HDDT frm = new frmDM_HDDT(MaHD, HDID);
                frm.ShowDialog();
                if (frm.OK == 1)
                {
                    DataTable dt = LoadHDDT(HDID).Tables[0];
                    gdHDDT.SetDataBinding(dt, "");

                }
            }
        }

        private void cmdDeleteHDDT_Click(object sender, EventArgs e)
        {
            string MaHDDT = "";
            long HDID = 0;
            try
            {
                MaHDDT = this.gdHDDT.GetValue("MaHDDT").ToString();
                HDID = long.Parse(this.gdHDDT.GetValue("HopDongID").ToString());
            }
            catch
            {
                MessageBox.Show("Bạn phải chọn HĐĐT để Xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if ((MaHDDT != "") && (HDID > 0))
            {
                long VTID = MDSolution.DACASUCO_App.VuTrongID;
                string NienVu = DACASUCO_App.TenVuTrong;
                string DT = "0";
                string NoCu = "0";
                string DauTu = "0";
                string ThuMua = "0";
                string sql = "";
                //Dien Tich
                sql = "Select IsNull(Sum(DienTich),0) from tbl_ThuaRuong Where MaHDDT=N'" + MaHDDT + "' AND VuTrongID=" + VTID;
                try
                {
                    DT = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null);
                }
                catch
                {
                    DT = "0";
                }
                //Nợ cũ
                sql = "Select IsNull(Sum(NoGoc),0) from tbl_NoCuChuHopDong Where MaHDDT=N'" + MaHDDT + "' AND VuTrongID=" + VTID;
                try
                {
                    NoCu = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null);
                }
                catch
                {
                    NoCu = "0";
                }
                //Đầu tư
                sql = "Select IsNull(Sum(SoTien),0) from tbl_DauTu Where MaHDDT=N'" + MaHDDT + "' AND VuTrongID=" + VTID;
                try
                {
                    DauTu = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null);
                }
                catch
                {
                    DauTu = "0";
                }
                //Thu mua
                sql = "Select IsNull(Sum(TongTrongLuong-TrongLuongXe-TrongLuongTapVat),0) from tbl_NhapMia Where MaHDDT=N'" + MaHDDT + "' AND VuTrongID=" + VTID;
                try
                {
                    ThuMua = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null);
                }
                catch
                {
                    ThuMua = "0";
                }
                frmXoaHDDT_CF frm = new frmXoaHDDT_CF(MaHDDT, DT, NoCu, DauTu, ThuMua, NienVu);
                frm.ShowDialog();
                if (frm.OK == 1)
                {
                    try
                    {
                        MDSolutionEntities.DBModule.ExecuteQuery("Delete from tbl_HopDongDauTu Where MaHDDT=N'" + MaHDDT + "' And VuTrongID=" + VTID, null, null);
                        MDSolutionEntities.DBModule.ExecuteQuery("Delete from tbl_ThuaRuong Where MaHDDT=N'" + MaHDDT + "' And VuTrongID=" + VTID, null, null);
                        MDSolutionEntities.DBModule.ExecuteQuery("Delete from tbl_NoCuChuHopDong Where MaHDDT=N'" + MaHDDT + "' And VuTrongID=" + VTID, null, null);
                        MDSolutionEntities.DBModule.ExecuteQuery("Delete from tbl_DauTu Where MaHDDT=N'" + MaHDDT + "' And VuTrongID=" + VTID, null, null);
                        MessageBox.Show("Đã xoá HĐĐT " + MaHDDT + " !", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataTable dt = LoadHDDT(HDID).Tables[0];
                        gdHDDT.SetDataBinding(dt, "");
                    }
                    catch
                    {
                        MessageBox.Show("Đã có lỗi khi xoá HĐĐT!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.gdHDDT.GetValue("ID").ToString()))
                {
                    long oID = long.Parse(this.gdHDDT.GetValue("ID").ToString());

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

        private void GridEX1_DoubleClick(object sender, EventArgs e)
        {
            btSua_Click(null, null);
        }


        private void edtTimKiem_Click(object sender, EventArgs e)
        {
            edtTimKiem.Text = "";
        }


        private void cmdAllCM_Click(object sender, EventArgs e)
        {
            chkTimkiemchinhxac.Checked = false;
            edtTimKiem.Text = "";
            this.gdCM.SetDataBinding(LoadHopDong().Tables[0], "");
        }

        private void cmdAllHD_Click(object sender, EventArgs e)
        {

            this.gdHDDT.SetDataBinding(LoadHDDT(-1).Tables[0], "");
        }

        private void cmdAddHDDT_Click(object sender, EventArgs e)
        {
            long HDID = 0;
            try
            {
                HDID = long.Parse(this.gdCM.GetValue("ID").ToString());
            }
            catch
            {
                MessageBox.Show("Bạn phải chọn Chủ mía để thêm HĐĐT!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            if (HDID > 0)
            {
                frmDM_HDDT_ADD frm = new frmDM_HDDT_ADD(HDID);
                frm.ShowDialog();
                if (frm.OK == 1)
                {
                    DataTable dt = LoadHDDT(HDID).Tables[0];
                    gdHDDT.SetDataBinding(dt, "");

                }
            }
        }

        private void btn_excel_chumia_Click(object sender, EventArgs e)
        {
            try
            {

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.IncludeFormatStyle = true;
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        // exporter.SheetName = "";
                        exporter.GridEX = gdCM;
                        exporter.Export(fs);
                        fs.Close();
                        MessageBox.Show("Đã export ra file excel!", "SOSUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "SOSUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_excelChumia_Click(object sender, EventArgs e)
        {
            try
            {

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.IncludeFormatStyle = true;
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        // exporter.SheetName = "";
                        exporter.GridEX = gdHDDT;
                        exporter.Export(fs);
                        fs.Close();
                        MessageBox.Show("Đã export ra file excel!", "SOSUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "SOSUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

}