using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace MDSolution.MDForms
{
    public partial class frm_LamThanhToan : Form
    {
        static frm_LamThanhToan _theformLamThanhToan;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_LamThanhToan OneInstanceFrm
        {
            get
            {
                if (null == _theformLamThanhToan || _theformLamThanhToan.IsDisposed)
                {
                    _theformLamThanhToan = new frm_LamThanhToan();
                }

                return _theformLamThanhToan;
            }
        }
        DateTime DateThanhToanDotTruoc;
        string HopDongID = "";
        public frm_LamThanhToan()
        {
            InitializeComponent();
        }

        private void gdDanhSach_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            //gdDanhSach.Controls[e.Row.Cells["TTQuaNganHang"].Column.Key].Enabled = false;
        }

        private void frm_LamThanhToan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nganHangDataSet.tbl_NganHang' table. You can move, or remove it, as needed.
        // phần cũ ...
            //this.tbl_NganHangTableAdapter.Fill(this.nganHangDataSet.tbl_NganHang);
            string strSQL;

            strSQL = strSQL = "SELECT NgayChotTinhLaiDauTu From tbl_VuTrong Where ID =" + MDSolutionApp.VuTrongID.ToString();
            string strNgayChot = DBModule.ExecuteQueryForOneResult(strSQL, null, null);

            if (string.IsNullOrEmpty(strNgayChot))
            {
                // chua chon ngay chot tinh lai
                MessageBox.Show("Bạn chưa nhập ngày chốt tính lãi đầu tư nên không thể thực hiện thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.WindowState = FormWindowState.Maximized;
                //this.Enabled = false;
                this.uiGroupBox1.Enabled = false;
                //this.Close();
            }
            else
            {
                lbNgayTT.Text = "";
                strSQL = "SELECT Max(NgayThanhToan)	FROM tbl_ThanhToanMia_TheoNhieuDot Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + " AND (DotThanhToan <> 0) ";
                string strNgayThanhToanTruoc = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                try
                {   // da co dot thanh toan trc do
                    DateThanhToanDotTruoc = DateTime.Parse(strNgayThanhToanTruoc);
                    //calendarComboChonNgay.MinDate = DateThanhToanDotTruoc;
                }
                catch
                { // neu chua co dot thanh toan nao dc thuc hien
                    //strSQL = "SELECT NgayChotTinhLaiDauTu From tbl_VuTrong Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString();
                    //DateTime dt = Convert.ToDateTime(strNgayChot);
                    //calendarComboChonNgay.MinDate = dt;
                }

                if (strNgayThanhToanTruoc != "")
                {
                    lblNgayThanhToanDotTruoc.Text = DateTime.Parse(strNgayThanhToanTruoc).ToString("dd/MM/yyyy");
                }
                else
                {
                    lblNgayThanhToanDotTruoc.Text = "Chưa có";
                }

                calendarComboChonNgay.MaxDate = DateTime.Now;
                calendarComboChonNgay.Value = DateTime.Now;

                // lay dot thanh toan lon nhat
                strSQL = "Select Max(DotThanhToan) From tbl_ThanhToanMia_TheoNhieuDot Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString();
                string strMax = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (string.IsNullOrEmpty(strMax))
                {
                    txtDotTT.Text = "1";
                }
                else
                {
                    long Max_DotTT = long.Parse(strMax) + 1;
                    txtDotTT.Text = Max_DotTT.ToString();
                }
                Load_DanhSach_ThanhToan();

                uiComboBoxDotTT.Enabled = false;
                uiButtonXem.Enabled = false;
                uiButtonHuyBo.Enabled = false;
                uiButtonInDS2.Enabled = false;
                XemChiTiet_uiButton1.Enabled = false;

                LoadDSNganHang();
                //gdDanhSach.Tables[0].Columns["TTQuaNganHang"].Visible = false;
                //try
                //{
                //    //load_DotTT();
                //    load_DanhSach(int.Parse(uiComboBoxDotTT.SelectedValue.ToString()));
                //}
                //catch { load_DanhSach(0); }
                this.WindowState = FormWindowState.Maximized;                
            }
        }

        private void Load_DanhSach_ThanhToan()
        {
            string strSQL = "SELECT tbl_NhapMia.HopDongID, tbl_HopDong.MaHopDong, tbl_HopDong.HoTen, "
               + " IsNuLL(SUM((tbl_NhapMia.TongTrongLuong - tbl_NhapMia.TrongLuongXe)*TiLeCanGhep/100),0) AS TrongLuongMia, "
               + " IsNuLL(SUM((tbl_NhapMia.TongTrongLuong - tbl_NhapMia.TrongLuongXe)*TiLeCanGhep/100 - tbl_NhapMia.TrongLuongTapVat),0) AS TrongLuongMiaSach, "
               + " ISNuLL(SUM(tbl_NhapMia.TrongLuongTapVat),0) AS TrongLuongTV, tbl_Cum.Ten AS TenTram, IsNuLL(SUM(tbl_NhapMia.TienMia),0) AS ThanhTien, "
               + " IsNuLL(SUM(tbl_NhapMia.PhatHD),0) AS TruPhat, tbl_HopDong.SoTaiKhoan, tbl_HopDong.NganHangID as NganHang"
               + " FROM  tbl_NhapMia INNER JOIN"
               + " tbl_HopDong ON tbl_NhapMia.HopDongID = tbl_HopDong.ID INNER JOIN"
               + " tbl_VuTrong ON tbl_NhapMia.VuTrongID = tbl_VuTrong.ID INNER JOIN"
               + " tbl_Thon ON tbl_HopDong.ThonID = tbl_Thon.ID INNER JOIN"
               + " tbl_Xa ON tbl_Thon.XaID = tbl_Xa.ID INNER JOIN"
               + " tbl_Cum ON tbl_Xa.CumID = tbl_Cum.ID"
               + " WHERE (tbl_NhapMia.VuTrongID = " + MDSolutionApp.VuTrongID.ToString() + ") AND (tbl_NhapMia.DaThanhToan = 0 OR tbl_NhapMia.DaThanhToan is null "
               + ") AND (tbl_NhapMia.TrongLuongXe <> 0 ) AND (tbl_NhapMia.NgayMia <= '" + calendarComboChonNgay.Value.ToString("yyyy-MM-dd") + "')"
               + " GROUP BY tbl_NhapMia.HopDongID, tbl_HopDong.MaHopDong, tbl_HopDong.HoTen, tbl_Cum.Ten, tbl_HopDong.SoTaiKhoan, tbl_HopDong.NganHangID";

            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables.Count > 0)
                gdDanhSach.SetDataBinding(ds.Tables[0], "");
            else
                gdDanhSach.DataSource = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                uiButtonThanhToan.Enabled = true;
            }
            else
            {
                uiButtonThanhToan.Enabled = false;
            }
        }

        private void Load_DanhSach_ThanhToan(string TextTimKiem)
        {
            string strSQL = "SELECT tbl_NhapMia.HopDongID, tbl_HopDong.MaHopDong, tbl_HopDong.HoTen, "
               + " IsNuLL(SUM((dbo.tbl_NhapMia.TongTrongLuong - dbo.tbl_NhapMia.TrongLuongXe)TiLeCanGhep/100),0) AS TrongLuongMia, "
               + " IsNuLL(SUM((dbo.tbl_NhapMia.TongTrongLuong - dbo.tbl_NhapMia.TrongLuongXe)TiLeCanGhep/100 - dbo.tbl_NhapMia.TrongLuongTapVat),0) AS TrongLuongMiaSach, "
               + " ISNuLL(SUM(dbo.tbl_NhapMia.TrongLuongTapVat),0) AS TrongLuongTV, dbo.tbl_Cum.Ten AS TenTram, IsNuLL(SUM(dbo.tbl_NhapMia.TienMia),0) AS ThanhTien, "
               + " IsNuLL(SUM(dbo.tbl_NhapMia.PhatHD),0) AS TruPhat, tbl_HopDong.SoTaiKhoan, tbl_HopDong.NganHangID as NganHang "
               + " FROM  tbl_NhapMia INNER JOIN"
               + " tbl_HopDong ON tbl_NhapMia.HopDongID = tbl_HopDong.ID INNER JOIN"
               + " tbl_VuTrong ON tbl_NhapMia.VuTrongID = tbl_VuTrong.ID INNER JOIN"
               + " tbl_Thon ON tbl_HopDong.ThonID = tbl_Thon.ID INNER JOIN"
               + " tbl_Xa ON tbl_Thon.XaID = tbl_Xa.ID INNER JOIN"
               + " tbl_Cum ON tbl_Xa.CumID = tbl_Cum.ID"
               + " WHERE (tbl_NhapMia.VuTrongID = " + MDSolutionApp.VuTrongID.ToString() + ") AND (tbl_NhapMia.DaThanhToan = 0 OR tbl_NhapMia.DaThanhToan is null "
               + ") AND (tbl_NhapMia.TrongLuongXe <> 0 ) AND (tbl_NhapMia.NgayMia <= '" + calendarComboChonNgay.Value.ToString("yyyy-MM-dd") + "') And (tbl_HopDong.MaHopDong = N'" + TextTimKiem + "')"
               + " GROUP BY tbl_NhapMia.HopDongID, tbl_HopDong.MaHopDong, tbl_HopDong.HoTen, tbl_Cum.Ten, tbl_HopDong.SoTaiKhoan, tbl_HopDong.NganHangID";

            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables.Count > 0)
                gdDanhSach.SetDataBinding(ds.Tables[0], "");
            else
                gdDanhSach.DataSource = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                uiButtonThanhToan.Enabled = true;
            }
            else
            {
                uiButtonThanhToan.Enabled = false;
            }
        }

        private void load_DanhSachDaThanhToan(int dotTT)
        {
            //DataSet ds = DBModule.ExecuteQuery("sp_LamThanhToanNhieuDot "+MDSolutionApp.VuTrongID.ToString()+", "+dotTT.ToString(), null, null);

            //gdDanhSach.DataSource = ds.Tables[0];
            string strSQL = "SELECT tbl_ThanhToanMia_TheoNhieuDot.ID,tbl_ThanhToanMia_TheoNhieuDot.HopDongID, tbl_HopDong.MaHopDong, tbl_HopDong.HoTen, tbl_Cum.Ten AS TenTram, "
               + " tbl_ThanhToanMia_TheoNhieuDot.TienDuocThanhToan AS TienLinh, tbl_ThanhToanMia_TheoNhieuDot.TrongLuongMia, "
               + " tbl_ThanhToanMia_TheoNhieuDot.TrongLuongTapVat AS TrongLuongTV, tbl_ThanhToanMia_TheoNhieuDot.TrongLuongMiaSach, "
               + " tbl_ThanhToanMia_TheoNhieuDot.ThanhTien, tbl_ThanhToanMia_TheoNhieuDot.TruPhat, tbl_ThanhToanMia_TheoNhieuDot.TruNoCu, "
               + " tbl_ThanhToanMia_TheoNhieuDot.TruNoTrucTiep AS TruNoTrucTiepVu, tbl_ThanhToanMia_TheoNhieuDot.TruNoLai, "
               + " tbl_ThanhToanMia_TheoNhieuDot.TruNoUng AS TruUng, tbl_ThanhToanMia_TheoNhieuDot.TruNoGianTiep, "
               + " tbl_ThanhToanMia_TheoNhieuDot.TruKhac, tbl_HopDong.SoTaiKhoan, tbl_HopDong.NganHangID as NganHang,tbl_ThanhToanMia_TheoNhieuDot.ThanhToanQuaNganHang"
               + " FROM  tbl_ThanhToanMia_TheoNhieuDot INNER JOIN"
               + " tbl_HopDong ON tbl_ThanhToanMia_TheoNhieuDot.HopDongID = tbl_HopDong.ID INNER JOIN"
               + " tbl_Thon ON dbo.tbl_HopDong.ThonID = tbl_Thon.ID INNER JOIN"
               + " tbl_Xa ON dbo.tbl_Thon.XaID = tbl_Xa.ID INNER JOIN"
               + " tbl_Cum ON dbo.tbl_Xa.CumID = tbl_Cum.ID"
               + " WHERE (tbl_ThanhToanMia_TheoNhieuDot.DotThanhToan = " + dotTT.ToString() + ") AND tbl_ThanhToanMia_TheoNhieuDot.VuTrongID=" + MDSolutionApp.VuTrongID.ToString();

            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables.Count > 0)
                gdDanhSach.DataSource = ds.Tables[0];
            else
                gdDanhSach.DataSource = null;

            if (dotTT != 0)
            {
                uiGroupBox3.Text = "Bảng thanh toán đợt " + dotTT.ToString();
            }
            else
            {
                uiGroupBox3.Text = "Bảng thanh toán";
            }

            // set thanh toan qua ngan hang cho cac hop dong
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (ds.Tables[0].Rows[i]["ThanhToanQuaNganHang"].ToString() == "1")
            //    {
            //        gdDanhSach.GetRow(i).CheckState = RowCheckState.Checked;
            //    }
            //    else
            //    {
            //        gdDanhSach.GetRow(i).CheckState = RowCheckState.Unchecked;
            //    }
            //}


        }
            
        private void load_DanhSachDaThanhToan(int dotTT, string TextTimKiem)
        {
            //DataSet ds = DBModule.ExecuteQuery("sp_LamThanhToanNhieuDot "+MDSolutionApp.VuTrongID.ToString()+", "+dotTT.ToString(), null, null);

            //gdDanhSach.DataSource = ds.Tables[0];
            string strSQL = "SELECT tbl_ThanhToanMia_TheoNhieuDot.ID, tbl_ThanhToanMia_TheoNhieuDot.HopDongID, tbl_HopDong.MaHopDong, tbl_HopDong.HoTen, tbl_Cum.Ten AS TenTram, "
               + " tbl_ThanhToanMia_TheoNhieuDot.TienDuocThanhToan AS TienLinh, tbl_ThanhToanMia_TheoNhieuDot.TrongLuongMia, "
               + " tbl_ThanhToanMia_TheoNhieuDot.TrongLuongTapVat AS TrongLuongTV, tbl_ThanhToanMia_TheoNhieuDot.TrongLuongMiaSach, "
               + " tbl_ThanhToanMia_TheoNhieuDot.ThanhTien, tbl_ThanhToanMia_TheoNhieuDot.TruPhat, tbl_ThanhToanMia_TheoNhieuDot.TruNoCu, "
               + " tbl_ThanhToanMia_TheoNhieuDot.TruNoTrucTiep AS TruNoTrucTiepVu, tbl_ThanhToanMia_TheoNhieuDot.TruNoLai, "
               + " tbl_ThanhToanMia_TheoNhieuDot.TruNoUng AS TruUng, tbl_ThanhToanMia_TheoNhieuDot.TruNoGianTiep, "
               + " tbl_ThanhToanMia_TheoNhieuDot.TruKhac ,tbl_HopDong.SoTaiKhoan, tbl_HopDong.NganHangID as NganHang"
               + " FROM  tbl_ThanhToanMia_TheoNhieuDot INNER JOIN"
               + " tbl_HopDong ON tbl_ThanhToanMia_TheoNhieuDot.HopDongID = tbl_HopDong.ID INNER JOIN"
               + " tbl_Thon ON dbo.tbl_HopDong.ThonID = tbl_Thon.ID INNER JOIN"
               + " tbl_Xa ON dbo.tbl_Thon.XaID = tbl_Xa.ID INNER JOIN"
               + " tbl_Cum ON dbo.tbl_Xa.CumID = tbl_Cum.ID"
               + " WHERE (tbl_ThanhToanMia_TheoNhieuDot.DotThanhToan = " + dotTT.ToString() + ") AND (tbl_HopDong.MaHopDong = N'" + TextTimKiem + "')";

            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables.Count > 0)
                gdDanhSach.DataSource = ds.Tables[0];
            else
                gdDanhSach.DataSource = null;

            if (dotTT != 0)
            {
                uiGroupBox3.Text = "Bảng thanh toán đợt " + dotTT.ToString();
            }
            else
            {
                uiGroupBox3.Text = "Bảng thanh toán";
            }
            // set thanh toan qua ngan hang cho cac hop dong
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (ds.Tables[0].Rows[i]["ThanhToanQuaNganHang"].ToString() == "1")
            //    {
            //        gdDanhSach.GetRow(i).CheckState = RowCheckState.Checked;
            //    }
            //    else
            //    {
            //        gdDanhSach.GetRow(i).CheckState = RowCheckState.Unchecked;
            //    }
            //}

            //foreach (GridEXRow gr in gdDanhSach.GetDataRows())
            //{
            //    if (gr.Cells["SoTaiKhoan"].Value.ToString() != "" && gr.Cells["NganHang"].Value.ToString() != "")
            //    {
            //        gr.CheckState = RowCheckState.Checked;
            //        string sql = "Update tbl_ThanhToanMia_TheoNhieuDot SET ThanhToanQuaNganHang = 1 Where ID =" + gdDanhSach.GetValue("IDThanhToanNhieuDot").ToString();
            //        DBModule.ExecuteNonQuery(sql, null, null);
            //        //MessageBox.Show(gr.CheckState.ToString());
            //    }
            //    else
            //    {
            //        gr.CheckState = RowCheckState.Unchecked;
            //        string sql = "Update tbl_ThanhToanMia_TheoNhieuDot SET ThanhToanQuaNganHang = 0 Where ID =" + gdDanhSach.GetValue("IDThanhToanNhieuDot").ToString();
            //        DBModule.ExecuteNonQuery(sql, null, null);
            //    }
            //}
        }        

        void load_DotTT()
        {
            // phần cũ
            string strSQL = "select distinct Dotthanhtoan  from tbl_ThanhToanMia_TheoNhieuDot Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " And DotThanhToan <> 0 And DotThanhToan is not null order by Dotthanhtoan desc";

            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            uiComboBoxDotTT.DataSource = ds.Tables[0];
            uiComboBoxDotTT.DisplayMember = "Dotthanhtoan";
            uiComboBoxDotTT.ValueMember = "Dotthanhtoan";
            try
            {
                uiComboBoxDotTT.SelectedIndex = 0;
            }
            catch { }
        }

        void lock_control(bool islock)
        {
            uiGroupBoxLamTT.Enabled = islock;
            uiGroupBoxTraCuu.Enabled = islock;
            gdDanhSach.Enabled = islock;
        }
        private void uiButtonThanhToan_Click(object sender, EventArgs e)
        {
            if (DateThanhToanDotTruoc != null)
            {
                if (calendarComboChonNgay.Value < DateThanhToanDotTruoc)
                {
                    MessageBox.Show("Ngày này đã được thanh toán, bạn phải chọn ngày khác.", "Thông báo");
                    return;
                }
            }
            uiGroupBoxThanhToan.Visible = true;
            uiGroupBoxThanhToan.Top = (uiGroupBox3.Height - uiGroupBoxThanhToan.Height) / 2;
            uiGroupBoxThanhToan.Left = (uiGroupBox3.Width - uiGroupBoxThanhToan.Width) / 2;
            editBox1.Focus();
            uiButtonOK.Enabled = false;
            lock_control(false);
            long i = 0;
            try
            {
                string str = "sp_ThanhToan_Thu " + MDSolutionApp.VuTrongID.ToString();
                DBModule.ExecuteNoneBackup("sp_ThanhToan_Thu " + MDSolutionApp.VuTrongID.ToString(), null, null);
                foreach (GridEXRow jr in this.gdDanhSach.GetDataRows())
                {
                    GridEXCell jc = jr.Cells["HopDongID"];
                    string TTNganHang = "0";
                    if (jr.CheckState == RowCheckState.Checked)
                        TTNganHang = "1";
                    //GridEXCell jc2 = jr.Cells["TTQuaNganHang"];
                    //DBModule.ExecuteNoneBackup("sp_TinhToan_ThanhToan_NhieuDot " + jc.Value.ToString().Trim() + "," + MDSolutionApp.VuTrongID.ToString() +
                    //    ",'" + calendarComboChonNgay.Value.ToString("yyyy-MM-dd") + "'," + TTNganHang, null, null);

                    //string strSQL = "sp_ThanhToan_TinhCongNo_ChuHD " + MDSolutionApp.VuTrongID.ToString() + "," + jc.Value.ToString()
                    //    + "," + txtDotTT.Text + ",'" + calendarComboChonNgay.Value.ToString("yyyy-MM-dd") + " " + DateTime.Now.TimeOfDay.ToString() + "'";

                    DBModule.ExecuteNoneBackup("sp_ThanhToan_TinhCongNo_ChuHD " + MDSolutionApp.VuTrongID.ToString() + "," + jc.Value.ToString()
                        + "," + txtDotTT.Text + ",'" + calendarComboChonNgay.Value.ToString("yyyy-MM-dd") + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":00" + "'" , null, null);
                    i++;
                    lbDangTinh.Text = "Đang thanh toán(" + i.ToString() + ")";
                    this.Refresh();
                }                

                lbDangTinh.Text = "Hoàn thành tính thanh toán";
                uiButtonOK.Enabled = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Có lỗi trong quá trình làm thanh toán", "Lỗi");
                uiButtonOK.Enabled = true;
            }
            uiButtonOK.Focus();
            uiButtonThanhToan.Enabled = false;
            calendarComboChonNgay.Enabled = false;
            uiButtonHuyBo.Enabled = false;
            uiButtonInDS.Enabled = true;
        }

        private void gdDanhSach_RowCheckStateChanging(object sender, RowCheckStateChangingEventArgs e)
        {
            if (this.gdDanhSach.GetValue("SoTaiKhoan").ToString().Trim() == "") // chua co tai khoan
            {               
                if (e.CheckState == RowCheckState.Checked)
                {
                    if (MessageBox.Show("Hợp đồng này chưa có số tài khoản.\nBạn có muốn thiết lập tài khoản ngân hàng cho hợp đồng này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else // thiet lap tai khoan ngan hang
                    {
                        //MDDialoge.frmNganHang frm = new MDSolution.MDDialoge.frmNganHang(
                        uiGroupBoxTTNganHang.Visible = true;
                        uiGroupBoxTTNganHang.Top = (uiGroupBox3.Height - uiGroupBoxThanhToan.Height) / 2;
                        uiGroupBoxTTNganHang.Left = (uiGroupBox3.Width - uiGroupBoxThanhToan.Width) / 2;
                    }
                }
                else
                {
                    string sql = "Update tbl_ThanhToanMia_TheoNhieuDot SET ThanhToanQuaNganHang = 0 Where ID =" + gdDanhSach.GetValue("IDThanhToanNhieuDot");
                    DBModule.ExecuteNonQuery(sql, null, null);
                }
            }
            else // da co so tai khoan
            {
                if (e.CheckState == RowCheckState.Checked)
                {
                    string sql = "Update tbl_ThanhToanMia_TheoNhieuDot SET ThanhToanQuaNganHang = 1 Where ID =" + gdDanhSach.GetValue("IDThanhToanNhieuDot").ToString();
                    DBModule.ExecuteNonQuery(sql, null, null);
                }
                else
                {
                    string sql = "Update tbl_ThanhToanMia_TheoNhieuDot SET ThanhToanQuaNganHang = 0 Where ID =" + gdDanhSach.GetValue("IDThanhToanNhieuDot").ToString();
                    DBModule.ExecuteNonQuery(sql, null, null);
                }
            }
        }

        private void editBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
            {
            }
        }

        private void uiButtonOK_Leave(object sender, EventArgs e)
        {
            uiButtonOK.Focus();
        }

        private void uiButtonOK_Click(object sender, EventArgs e)
        {
            uiGroupBoxThanhToan.Visible = false;
            lbDangTinh.Text = "Đang thanh toán(0)";
            lock_control(true);
            try
            {
                load_DotTT();
                load_DanhSachDaThanhToan(int.Parse(uiComboBoxDotTT.SelectedValue.ToString()));
            }
            catch 
            { 
                load_DanhSachDaThanhToan(0); 
            }
        }

        private void uiComboBoxDotTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = " select top 1 NgayThanhtoan from tbl_ThanhToanMia_TheoNhieuDot where dotthanhtoan=" + uiComboBoxDotTT.SelectedValue.ToString();
            try
            {
                string ngaytt=DBModule.ExecuteQueryForOneResult(sql, null, null);
                lbNgayTT.Text="("+DateTime.Parse(ngaytt).ToString("dd/MM/yyyy")+")";
            }
            catch 
            {
                lbNgayTT.Text = "";
            }
        }

        private void uiButtonHuyBo_Click(object sender, EventArgs e)
        {
            string strSQL = "select Max(Dotthanhtoan) as Max from tbl_ThanhToanMia_TheoNhieuDot Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " And DotThanhToan <> 0 And DotThanhToan is not null";
            strSQL = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
            if (strSQL == uiComboBoxDotTT.Text.Trim())
            { }
            else
            {
                MessageBox.Show("Bạn chỉ có thể xoá đợt thanh toán lớn nhất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //int a = uiComboBoxDotTT.MaxDropDownItems;
            if (MessageBox.Show("Bạn muốn xoá đợt thanh toán số " + uiComboBoxDotTT.Text + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    //string sql = "delete from tbl_ThanhToanMia_TheoNhieuDot where NgayThanhToan='" + calendarComboChonNgay.Value.ToString("yyyy-MM-dd") + "'";
                    string sql = "sp_ThanhToan_Huy " + MDSolutionApp.VuTrongID.ToString() + ", " + uiComboBoxDotTT.Text;
                    DBModule.ExecuteNonQuery(sql, null, null);

                    load_DotTT();
                    load_DanhSachDaThanhToan(int.Parse(uiComboBoxDotTT.SelectedValue.ToString()));

                    uiButtonThanhToan.Enabled = true;
                    calendarComboChonNgay.Enabled = true;
                    uiButtonHuyBo.Enabled = false;
                    uiButtonInDS.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("đã có lỗi khi xoá đợt thanh toán!\nBạn đóng Form vào và thực hiện lại thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    uiGroupBox1.Enabled = false;
                }
            }
        }

        private void uiButtonInDS2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] paramNames = new string[] { "@VuTrongID", "@DotTT" };
                string[] paraValues = new string[] { MDSolutionApp.VuTrongID.ToString(), uiComboBoxDotTT.SelectedValue.ToString()};
                CommonClass.ShowReport("ThanhToan\\rp_TongHopThanhToanTienMiaNguyenLieuTheoHopDong.rpt", "", paramNames, paraValues, null);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi in báo cáo:\n" + ex.Message, "Lỗi");
            }
        }

        private void uiButtonXem_Click(object sender, EventArgs e)
        {
            try
            {
                load_DanhSachDaThanhToan(int.Parse(uiComboBoxDotTT.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xem DS:\n" + ex.Message, "Loi");
            }
        }

        private void LoadDSNganHang()
        {
            string sql = "Select ID,Ten From tbl_NganHang";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);

            NganHanguiComboBox1.DataSource = ds.Tables[0];
            NganHanguiComboBox1.ValueMember = "ID";
            NganHanguiComboBox1.DisplayMember = "Ten";

            gdDanhSach.DropDowns["DDLNganHang"].SetDataBinding(ds.Tables[0], "");
        }
                
        private void uiButtonOKNH_Click(object sender, EventArgs e)
        {
            //Update vào database và Gridview:
            //--Lay thong tin tu Grid:
            //string HopDongID = gdDanhSach.GetValue("HopDongID").ToString();
            if (NganHanguiComboBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn ngân hàng", "Thông báo");
                NganHanguiComboBox1.Focus();
            }
            else
            {
                if (editBoxSTK.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số tài khoản", "Thông báo");
                    editBoxSTK.Focus();
                }
                else
                {
                    string sql = "Update tbl_hopdong set SoTaikhoan=N'" + editBoxSTK.Text + "',NganHangID=" + NganHanguiComboBox1.SelectedValue.ToString() +//multiColum+
                        " Where ID=" + gdDanhSach.GetValue("HopDongID").ToString();
                    DBModule.ExecuteNoneBackup(sql, null, null);
                    sql = "Update tbl_ThanhToanMia_TheoNhieuDot SET ThanhToanQuaNganHang = 1 Where ID =" + gdDanhSach.GetValue("IDThanhToanNhieuDot").ToString();
                    gdDanhSach.SetValue("SoTaiKhoan", editBoxSTK.Text.ToString());
                    gdDanhSach.SetValue("NganHang", NganHanguiComboBox1.SelectedValue);
                    uiGroupBoxTTNganHang.Visible = false;
                }
            }
        }


        private void TaoDotThanhToan()
        {
            long Max_DotTT = 0;
            string strSQL = "Select Max(DotThanhToan) as DotTT,Max(NgayThanhToan) as NgayTT From tbl_ThanhToanMia_TheoNhieuDot Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            DateTime NgayTT;
            if (ds.Tables[0].Rows.Count > 0)
            {
                Max_DotTT = long.Parse(ds.Tables[0].Rows[0]["DotTT"].ToString()) + 1;
                //txtDotTT.Text = Max_DotTT.ToString();

                NgayTT = Convert.ToDateTime(ds.Tables[0].Rows[0]["NgayTT"].ToString());
                lblNgayThanhToanDotTruoc.Text = NgayTT.ToString("dd/MM/yyyy");
            }
            else
            {
                Max_DotTT = 1;                
                lblNgayThanhToanDotTruoc.Text = "Chưa có";
            }

            txtDotTT.Text = Max_DotTT.ToString();
            calendarComboChonNgay.MaxDate = DateTime.Now;
        }

        private void TraCuuDotTT_uiButton1_Click(object sender, EventArgs e)
        {
            if (TraCuuDotTT_uiButton1.Text == "Thanh toán") // chuyen sang thanh toan
            {
                TraCuuDotTT_uiButton1.Text = "Tra cứu";
                uiGroupBoxLamTT.Enabled = true;
                                
                uiComboBoxDotTT.DataSource = null;
                uiComboBoxDotTT.Enabled = false;
                uiButtonXem.Enabled = false;
                uiButtonHuyBo.Enabled = false;
                uiButtonInDS2.Enabled = false;
                XemChiTiet_uiButton1.Enabled = false;

                // load thanh toan
                frm_LamThanhToan_Load(null, null);
                //string strSQL = "Select Max(DotThanhToan) From tbl_ThanhToanMia_TheoNhieuDot Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString();
                //string strMax = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                //if (string.IsNullOrEmpty(strMax))
                //{
                //    txtDotTT.Text = "1";
                //}
                //else
                //{
                //    long Max_DotTT = long.Parse(strMax) + 1;
                //    txtDotTT.Text = Max_DotTT.ToString();
                //}
                //Load_DanhSach_ThanhToan();
                
            }
            else // chuyen sang tra cuu
            {
                TraCuuDotTT_uiButton1.Text = "Thanh toán";
                uiGroupBoxLamTT.Enabled = false;

                uiComboBoxDotTT.Enabled = true;
                uiButtonXem.Enabled = true;
                uiButtonHuyBo.Enabled = true;
                uiButtonInDS2.Enabled = true;
                XemChiTiet_uiButton1.Enabled = true;

                gdDanhSach.DataSource = null;
                load_DotTT();
                //gdDanhSach.Tables[0].Columns["TTQuaNganHang"].Visible = true;
            }
        }

        private void calendarComboChonNgay_ValueChanged(object sender, EventArgs e)
        {
            Load_DanhSach_ThanhToan();
        }

        private void XemChiTiet_uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                frmChiTietTruNo frm = new frmChiTietTruNo(long.Parse(gdDanhSach.GetValue("HopDongID").ToString()), long.Parse(uiComboBoxDotTT.Text));
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Bạn chưa chọn khoản tiền nào!", "Thông báo");
            }
        }

        private void TimKiemtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void TimKiemtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { 
                //GridEXFilterCondition con = new GridEXFilterCondition(gdDanhSach.Tables[0].Columns["MaHopDong"], ConditionOperator.Equal, TimKiemtxt.Text);
                //gdDanhSach.Find(con, 0, 1);
                if (TraCuuDotTT_uiButton1.Text == "Thanh toán") // tra cuu dot thanh tona
                {
                    if (uiComboBoxDotTT.Text != "")
                    {
                        load_DanhSachDaThanhToan(int.Parse(uiComboBoxDotTT.Text), TimKiemtxt.Text);
                    }
                }
                else // thanh toan
                {
                    Load_DanhSach_ThanhToan(TimKiemtxt.Text);
                }
            }
        }

        private void uiButtonCancelNH_Click(object sender, EventArgs e)
        {
            uiGroupBoxTTNganHang.Visible = false;
            gdDanhSach.GetRow().CheckState = RowCheckState.Unchecked;
            string sql = "Update tbl_ThanhToamMia_TheoNhieuDot SET ThanhToanQuaNganHang = 0 Where ID=" + gdDanhSach.GetValue("IDThanhToanNhieuDot").ToString();
            //gdDanhSach.FindAll(
        }
    }
}