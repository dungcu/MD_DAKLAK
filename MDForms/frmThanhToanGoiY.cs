using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDReport;

namespace MDSolution.MDForms
{
    public partial class frmThanhToanGoiY : Form
    {
        private int xaselected = 0;

        public frmThanhToanGoiY()
        {
            InitializeComponent();
            Load_DDLDotThanhToan();
            LoadccbXa();
            this.cbXa.SelectedIndexChanged += new System.EventHandler(this.cbXa_SelectedIndexChanged);
            this.cbXa.SelectedIndex = xaselected;
            this.cbDoThanhToan.SelectedIndexChanged += new System.EventHandler(this.cbDotThanhToan3_SelectedIndexChanged);
        }
        public void Load_DanhSachGoiY()
        {
            try
            {
                string thonid = "-1";
                if (cbThon.SelectedValue != null) thonid = cbThon.SelectedValue.ToString();
                DataSet ds;
                string strTimChinhXac = chkTimkiemchinhxac.Checked ? "1" : "0";
                string dk = "0";
                if (cbDieuKien.SelectedIndex > -1) dk = cbDieuKien.SelectedIndex.ToString();
                string strSQL = "sp_DanhSach_GoiY_ThanhToan " + dk + ',' + MDSolutionApp.VuTrongID.ToString() + "," + cbXa.SelectedValue.ToString() + "," + thonid + ",N'" + DBModule.RefineString(edtTimKiem.Text) + "'," + strTimChinhXac;
                ds = DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables.Count > 0)
                {
                    //this.gdDanhSach.e
                    this.gdDanhSach.SetDataBinding(ds.Tables[0], "");
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi load danh sách gợi ý", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Load_DanhSachChoLamThanhToan()
        {
            try
            {
                string thonid = "-1";
                if (cbThon.SelectedValue != null) thonid = cbThon.SelectedValue.ToString();
                string strTimChinhXac = chkTimkiemchinhxac.Checked ? "1" : "0";
                DataSet ds;
                string strSQL = "sp_DanhSach_Cho_ThanhToanMoi " + MDSolutionApp.VuTrongID.ToString() + "," + cbDoThanhToan.SelectedItem.ToString() + "," + cbXa.SelectedValue.ToString() + "," + thonid + ",N'" + DBModule.RefineString(edtTimKiem.Text) + "'," + strTimChinhXac;
                ds = DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables.Count > 0)
                {
                    this.gdChoThanhToan.SetDataBinding(ds.Tables[0], "");
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load danh sách chờ thanh toán bị lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Load_DanhSachDaLamThanhToan()
        {
            try
            {
                string strThonID = "-1";
                if (cbThon.SelectedValue != null) strThonID = cbThon.SelectedValue.ToString();
                string strTimChinhXac = chkTimkiemchinhxac.Checked ? "1" : "0";
                DataSet ds;                
                string strXaID = cbXa.SelectedValue.ToString();
                if (!chkTimkiemchinhxac.Checked)
                {
                    strThonID = "-1";
                    strXaID = "-1";
                }
                string strSQL = "sp_DanhSach_Da_ThanhToanMoi " + MDSolutionApp.VuTrongID.ToString() + "," + cbDoThanhToan.SelectedItem.ToString() + "," + strXaID + "," + strThonID + ",N'" + DBModule.RefineString(edtTimKiem.Text) + "'," + strTimChinhXac;

                ds = DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables.Count > 0)
                {
                    this.gdDaLamThanhToan.SetDataBinding(ds.Tables[0], "");
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load danh sách đã làm thanh toán bị lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void uiButton1_Click(object sender, EventArgs e)
        {
            int i = 0;
            pnTrangThai.Visible = true;
            //uiTab1.Enabled = false;
            try
            {
                foreach (GridEXRow jr in this.gdDanhSach.GetCheckedRows())
                {
                    GridEXCell jc = jr.Cells["HopDongID"];
                    //clsHopDong_ChoLamThanhToan cltt = new clsHopDong_ChoLamThanhToan();
                    //cltt.HopDongID = long.Parse(jc.Value.ToString());
                    //cltt.VuTrongID = MDSolutionApp.VuTrongID;
                    //cltt.DotThanhToan = long.Parse(cbDoThanhToan.SelectedItem.ToString());
                    //cltt.Save(null, null);
                    DateTime dtTCN = DateTime.Now;
                    dtTCN = (DateTime)dtNgayTinhCongNo.Value;

                    string strSQL = "sp_TinhToan_CongNo " + jc.Value.ToString() + ", " + MDSolutionApp.VuTrongID.ToString() + "," + DBModule.RefineDatetime(dtTCN);
                    DBModule.ExecuteNonQuery(strSQL, null, null);
                    i++;
                    lbTrangThai.Text = "Đang tính...(" + i.ToString() + ")";
                    this.Refresh();
                }
                pnTrangThai.Enabled = true;
                lbTrangThai.Text = "Đã xong! Có " + i.ToString() + " hợp đồng đã được tính công nợ.";
                this.Refresh();
                this.Load_DanhSachGoiY();
                this.Load_DanhSachChoLamThanhToan();
                //this.uiTab1.TabPages["tabChoThanhToan"].Selected = true; ;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                uiTab1.Enabled = true;
            }
        }
        private void Load_DDLDotThanhToan()
        {
            string strSQL = "SELECT ISNULL(Max(DotThanhToan),0) FROM tbl_HopDong_ChoLamThanhToan Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
            int ret = int.Parse(DBModule.ExecuteQueryForOneResult(strSQL, null, null));
            ret++;
            for (int i = 0; i <= ret; i++)
            {
                this.cbDoThanhToan.Items.Add(i);
            }
            this.cbDoThanhToan.SelectedItem = ret;
        }

        private void cbDotThanhToan3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Load_DanhSachChoLamThanhToan();
            this.Load_DanhSachDaLamThanhToan();
        }


        private void uiButton3_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridEXRow jr in this.gdChoThanhToan.GetCheckedRows())
                {
                    GridEXCell jc = jr.Cells["ID"];
                    clsHopDong_ChoLamThanhToan.Delete(long.Parse(jc.Value.ToString()), null, null);
                }
                this.Load_DanhSachChoLamThanhToan();
                this.Load_DanhSachGoiY();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void gdDanhSach_RowDoubleClick(object sender, RowActionEventArgs e)
        //{
        //    frmThanhToanCongNo frm = new frmThanhToanCongNo(this.gdDanhSach.GetValue("HopDongID").ToString());
        //    frm.ShowDialog();
        //}

        private void gdChoThanhToan_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            frmThanhToanCongNo frm = new frmThanhToanCongNo(this.gdDanhSach.GetValue("HopDongID").ToString());
            frm.ShowDialog();
        }

        private void gdDaLamThanhToan_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            frmThanhToanCongNo frm = new frmThanhToanCongNo(this.gdDanhSach.GetValue("HopDongID").ToString());
            frm.ShowDialog();
        }

        private string GetHopDongID()
        {
            long HopDongID = -1;
            if (this.uiTab1.SelectedIndex == 1)
            {
                //this.Load_DanhSachChoLamThanhToan();
                long.TryParse(this.gdChoThanhToan.GetValue("HopDongID").ToString(), out HopDongID);
            }
            else if (this.uiTab1.SelectedIndex == 2)
            {
                long.TryParse(this.gdDaLamThanhToan.GetValue("HopDongID").ToString(), out HopDongID);
            }
            else
            { long.TryParse(this.gdDanhSach.GetValue("HopDongID").ToString(), out HopDongID); }
            return HopDongID.ToString();
        }
        private void tsView_Click(object sender, EventArgs e)
        {
            try
            {
                frmThanhToanCongNo frm = new frmThanhToanCongNo(this.GetHopDongID());
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }
        private void tsNhapTienTraNo_Click(object sender, EventArgs e)
        {
            try
            {
                frmThanhToan_DauTu_TruNo frm = new frmThanhToan_DauTu_TruNo(this.GetHopDongID());
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }
        private void LoadccbXa()
        {
            try
            {
                DataSet ds;
                clsXa.GetList("", out ds, null, null);
                if (ds.Tables.Count > 0)
                {
                    //DataRow oR = ds.Tables[0].NewRow();
                    //oR["ID"] = -1;
                    //oR["Ten"] = "-- Xã  --";
                    //ds.Tables[0].Rows.InsertAt(oR,0);
                    this.cbXa.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void LoadccbThon()
        {
            try
            {
                DataSet ds;
                ds = clsThon.GetListbyWhere("ID, Ten", " XaID =" + cbXa.SelectedValue.ToString(), "", null, null);
                if (ds.Tables.Count > 0)
                {
                    //DataRow dr = new DataRow();
                    DataRow oR = ds.Tables[0].NewRow();
                    oR["ID"] = -1;
                    oR["Ten"] = "-- Thôn --";
                    ds.Tables[0].Rows.InsertAt(oR, 0);
                    this.cbThon.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void cbXa_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadccbThon();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            try
            {
                frmShowRP2 frm = new frmShowRP2();
                rp_DanhSachLamThanhToanHDTrongMia rp = new rp_DanhSachLamThanhToanHDTrongMia();
                string RecordSelect = "";
                int CountCell = 1;



                foreach (GridEXRow jr in this.gdDanhSach.GetCheckedRows())
                {
                    GridEXCell jc = jr.Cells["HopDongID"];
                    if (CountCell == 1)
                        RecordSelect += " {tbl_HopDong.ID}=" + jc.Value.ToString();
                    else
                        RecordSelect += " or {tbl_HopDong.ID}=" + jc.Value.ToString();
                    CountCell++;
                    //clsHopDong_ChoLamThanhToan.Delete(long.Parse(jc.Value.ToString()), null, null);
                }
                //this.Load_DanhSachChoLamThanhToan();
                //MessageBox.Show(RecordSelect);
                if (CountCell > 1)
                {

                    rp.RecordSelectionFormula = RecordSelect;
                    frm.RP = rp;
                    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                    frm.RPtitle = "Danh sách làm thanh toán hợp đồng trồng mía ";
                    //frm.MdiParent = this;
                    frm.Show();
                }
                else
                    MessageBox.Show("Bạn chưa chọn hợp đồng nào làm thanh toán!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void tsMLoaiKhoiDanhSachChoLamThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                clsHopDong_ChoLamThanhToan.Delete(long.Parse(this.gdChoThanhToan.GetValue("ID").ToString()), null, null);
                this.Load_DanhSachChoLamThanhToan();
                this.Load_DanhSachGoiY();

            }
            catch
            {
                MessageBox.Show("Xác định rõ hợp đồng cần loại bỏ", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gdChoThanhToan.CurrentRow == null) throw new Exception("Chưa chọn HĐ ");
                frmShowRP2 frm = new frmShowRP2();
                rp_T_DS_PhieuThanhToanMia rp = new rp_T_DS_PhieuThanhToanMia();
                rp.RecordSelectionFormula = "{tbl_HopDong.ID}=" + this.gdChoThanhToan.GetValue("HopDongID").ToString();
                frm.RP = rp;
                frm.RPtitle = "Chi tiết hợp đồng";
                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.Show();
                //MessageBox.Show(this.gdChoThanhToan.GetValue("HopDongID").ToString());
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
            }
        }

        private void uibChuyenSangDaThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridEXRow jr in this.gdChoThanhToan.GetCheckedRows())
                {
                    GridEXCell jc = jr.Cells["HopDongID"];
                    string strSQL = "sp_TinhToan_ChuyenVu " + jc.Value.ToString() + ", " + MDSolutionApp.VuTrongID.ToString();
                    DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                //this.Load_DanhSachGoiY();
                this.Load_DanhSachDaLamThanhToan();
                this.Load_DanhSachChoLamThanhToan();
                this.uiTab1.TabPages["tabDaThanhToan"].Selected = true; ;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void uibHuyBoThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridEXRow jr in this.gdDaLamThanhToan.GetCheckedRows())
                {
                    GridEXCell jc = jr.Cells["ID"];
                    clsHopDong_DaLamThanhToan.Delete(long.Parse(jc.Value.ToString()), null, null);
                }
                this.Load_DanhSachChoLamThanhToan();
                this.Load_DanhSachDaLamThanhToan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void uibInDanhSachDaLamThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                frmShowRP2 frm = new frmShowRP2();
                rp_DanhSachLamThanhToanHDTrongMia rp = new rp_DanhSachLamThanhToanHDTrongMia();
                string RecordSelect = "";
                int CountCell = 1;
                foreach (GridEXRow jr in this.gdDaLamThanhToan.GetCheckedRows())
                {
                    GridEXCell jc = jr.Cells["HopDongID"];
                    if (CountCell == 1)
                        RecordSelect += " {tbl_HopDong.ID}=" + jc.Value.ToString();
                    else
                        RecordSelect += " or {tbl_HopDong.ID}=" + jc.Value.ToString();
                    CountCell++;
                }
                if (CountCell > 1)
                {
                    rp.RecordSelectionFormula = RecordSelect;
                    frm.RP = rp;
                    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                    frm.RPtitle = "Danh sách đã làm thanh toán hợp đồng trồng mía ";
                    //frm.MdiParent = this;
                    frm.Show();
                }
                else
                    MessageBox.Show("Bạn chưa chọn hợp đồng nào xem!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void uiInPhieuChiTiet_Click(object sender, EventArgs e)
        {


            try
            {
                string sql_Sotien = "delete from tbl_TienBangChu_HopDong";
                DBModule.ExecuteNonQuery(sql_Sotien, null, null);
                frmShowRP2 frm = new frmShowRP2();
                rp_T_DS_PhieuThanhToanMia rp = new rp_T_DS_PhieuThanhToanMia();
                string RecordSelect = "";
                int CountCell = 1;
                foreach (GridEXRow jr in this.gdChoThanhToan.GetCheckedRows())
                {
                    GridEXCell jc = jr.Cells["HopDongID"];
                    if (CountCell == 1)
                    {
                        RecordSelect += " {tbl_HopDong.ID}=" + jc.Value.ToString();
                        long lTongDauTuPhaiTra = clsHopDong.GetTongTienDauTuPhaiTra(long.Parse(jc.Value.ToString()), MDSolutionApp.VuTrongID, null, null);
                        long lTongTienKhoanCo = clsHopDong.GetTongCacKhoanTienCoThuDuoc(long.Parse(jc.Value.ToString()), MDSolutionApp.VuTrongID, null, null);
                        long lLayve = lTongTienKhoanCo - lTongDauTuPhaiTra;


                        if (lLayve > 0)
                        {
                            sql_Sotien = "insert into tbl_TienBangChu_HopDong values(" + jc.Value.ToString() + ",N'Số tiền được nhận (bằng chữ): " + frmShowRP3.DocSo(lLayve) + ".'," + lLayve.ToString() + ")";
                        }
                        else
                        {
                            long ll = 0 - lLayve;
                            sql_Sotien = "insert into tbl_TienBangChu_HopDong values(" + jc.Value.ToString() + ",N'Số tiền còn nợ (bằng chữ): " + frmShowRP3.DocSo(0 - lLayve) + ".'," + ll.ToString() + ")";
                        }
                        DBModule.ExecuteNonQuery(sql_Sotien, null, null);
                    }
                    else
                    {
                        RecordSelect += " or {tbl_HopDong.ID}=" + jc.Value.ToString();
                        //RecordSelect += " {tbl_HopDong.ID}=" + jc.Value.ToString();
                        long lTongDauTuPhaiTra = clsHopDong.GetTongTienDauTuPhaiTra(long.Parse(jc.Value.ToString()), MDSolutionApp.VuTrongID, null, null);
                        long lTongTienKhoanCo = clsHopDong.GetTongCacKhoanTienCoThuDuoc(long.Parse(jc.Value.ToString()), MDSolutionApp.VuTrongID, null, null);
                        long lLayve = lTongTienKhoanCo - lTongDauTuPhaiTra;


                        if (lLayve > 0)
                        {
                            sql_Sotien = "insert into tbl_TienBangChu_HopDong values(" + jc.Value.ToString() + ",N'Số tiền được nhận (bằng chữ): " + frmShowRP3.DocSo(lLayve) + ".'," + lLayve.ToString() + ")";
                        }
                        else
                        {
                            long ll = 0 - lLayve;
                            sql_Sotien = "insert into tbl_TienBangChu_HopDong values(" + jc.Value.ToString() + ",N'Số tiền còn nợ (bằng chữ): " + frmShowRP3.DocSo(0 - lLayve) + ".'," + ll.ToString() + ")";
                        }
                        DBModule.ExecuteNonQuery(sql_Sotien, null, null);
                    }
                    CountCell++;
                }
                if (CountCell > 1)
                {

                    rp.RecordSelectionFormula = RecordSelect;

                    frm.RP = rp;
                    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                    frm.RPtitle = "Phiếu thanh toán chi tiết ";
                    //frm.MdiParent = this;
                    frm.ShowDialog();
                }
                else
                    MessageBox.Show("Bạn chưa chọn hợp đồng nào xem!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //------------------------
            //if (MessageBox.Show("Bạn muốn chuyển các hợp đồng sang làm thanh toán?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    try
            //    {
            //        foreach (GridEXRow jr in this.gdChoThanhToan.GetCheckedRows())
            //        {
            //            GridEXCell jc = jr.Cells["HopDongID"];
            //            string strSQL = "sp_TinhToan_ChuyenVu " + jc.Value.ToString() + ", " + MDSolutionApp.VuTrongID.ToString();
            //            DBModule.ExecuteNonQuery(strSQL, null, null);
            //        }
            //        //this.Load_DanhSachGoiY();
            //        this.Load_DanhSachDaLamThanhToan();
            //        this.Load_DanhSachChoLamThanhToan();
            //        //this.uiTab1.TabPages["tabDaThanhToan"].Selected = true; ;

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //-----------------------

        }

        private void cbDieuKien_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Load_DanhSachGoiY();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                frmThanhToan_DauTu_TruNo frm = new frmThanhToan_DauTu_TruNo(this.gdDaLamThanhToan.GetValue("HopDongID").ToString());
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (this.uiTab1.SelectedIndex == 1)
            {
                this.Load_DanhSachChoLamThanhToan();
            }
            else if (this.uiTab1.SelectedIndex == 2)
            {
                this.Load_DanhSachDaLamThanhToan();
            }
            else
            { this.Load_DanhSachGoiY(); }



        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void mnu123_Click(object sender, EventArgs e)
        {
            try
            {
                frmThanhToan_TienCo_TruNo frm = new frmThanhToan_TienCo_TruNo(this.GetHopDongID());
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem");
            }

        }

        private void gdDanhSach_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "clMenu")
            {
                this.contextRight.Show(MousePosition);
            }
        }

        private void frmThanhToanGoiY_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void edtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void edtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.Load_DanhSachGoiY();
                this.Load_DanhSachChoLamThanhToan();
                this.Load_DanhSachChoLamThanhToan();

            }

        }

        private void gdDanhSach_CellEdited(object sender, ColumnActionEventArgs e)
        {

        }

        private void gdDanhSach_UpdatingCell(object sender, UpdatingCellEventArgs e)
        {
            try
            {
                if (e.Column.Key == "NhapTienTraNo")
                {
                    if (e.Value != null)//  ! string.IsNullOrEmpty(gdDanhSach.GetValue(e.Column.Key).ToString()) && (gdDanhSach.GetValue(e.Column.Key).ToString().Trim().Length > 0))
                    {
                        DialogResult dr = MessageBox.Show("Bạn muốn nhập tiền trả nợ cho HĐ này?", "Thông báo", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {

                            clsNhapTienTraNo oNTTN = new clsNhapTienTraNo();
                            //if (string.IsNullOrEmpty(clcNgayTra.Text)) throw new Exception("Cho biết ngày trả nợ");
                            oNTTN.NgayTra = DateTime.Now;
                            if (string.IsNullOrEmpty(gdDanhSach.GetValue(e.Column.Key).ToString())) throw new Exception("Cho biết số tiền trả nợ");
                            oNTTN.Sotien = long.Parse(gdDanhSach.GetValue(e.Column.Key).ToString());
                            oNTTN.HopDongID = long.Parse(gdDanhSach.GetValue("HopDongID").ToString());
                            oNTTN.VuTrongID = MDSolutionApp.VuTrongID;
                            oNTTN.Save(null, null);


                            DateTime dtTCN = DateTime.Now;
                            dtTCN = (DateTime)dtNgayTinhCongNo.Value;

                            string strSQL = "sp_TinhToan_CongNo " + oNTTN.HopDongID.ToString() + ", " + MDSolutionApp.VuTrongID.ToString() + "," + DBModule.RefineDatetime(oNTTN.NgayTra);
                            DBModule.ExecuteNonQuery(strSQL, null, null);

                            Load_DanhSachGoiY();
                            //clsNhapTienTraNo oNTTN = new clsNhapTienTraNo();
                            //oNTTN.HopDongID = long.Parse(gdDanhSach.GetValue("HopDongID").ToString());
                            //oNTTN.Load(null, null) ;
                            //oNTTN.Sotien = long.Parse(gdDanhSach.GetValue(e.Column.Key).ToString());
                            //oNTTN.NgayTra = DateTime.Now;
                            //oNTTN.VuTrongID = MDSolutionApp.VuTrongID;

                            //oNTTN.Save(null, null);

                        }
                    }
                }
            }
            catch { e.Cancel = true; }
        }

        private void gdDanhSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == '0')
            //{
            //    if (gdDanhSach.CurrentColumn.Key == "TienTraNo")
            //    {
            //        try
            //        {
            //            frmNhapTienTraNo frm = new frmNhapTienTraNo();
            //            frm.ChuHopDong = gdDanhSach.GetValue("HoTen").ToString();
            //            frm.ChuHopDongID = long.Parse(gdDanhSach.GetValue("HopDongID").ToString());
            //            frm.ShowDialog();
            //            if (frm.DialogResult == DialogResult.OK)
            //            {
            //               // this.DoLoadgdvChiTietThanhToan(oHD.ID.ToString());
            //            }
            //        }
            //        catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnTrangThai.Visible = false;
            uiTab1.Enabled = true;
        }

        private void btChuyen_Click(object sender, EventArgs e)
        {
            int i = 0;
            pnTrangThai.Visible = true;
            //uiTab1.Enabled = false;
            try
            {
                foreach (GridEXRow jr in this.gdDanhSach.GetCheckedRows())
                {
                    GridEXCell jc = jr.Cells["HopDongID"];
                    clsHopDong_ChoLamThanhToan cltt = new clsHopDong_ChoLamThanhToan();
                    cltt.HopDongID = long.Parse(jc.Value.ToString());
                    cltt.VuTrongID = MDSolutionApp.VuTrongID;
                    cltt.DotThanhToan = long.Parse(cbDoThanhToan.SelectedItem.ToString());
                    cltt.Save(null, null);
                    DateTime dtTCN = DateTime.Now;
                    dtTCN = (DateTime)dtNgayTinhCongNo.Value;
                    if (jr.Cells["NgayTinhCongNo"].Value.ToString().Trim().Length == 0)
                    {
                        string strSQL = "sp_TinhToan_CongNo " + cltt.HopDongID.ToString() + ", " + MDSolutionApp.VuTrongID.ToString() + "," + DBModule.RefineDatetime(dtTCN);
                        DBModule.ExecuteNonQuery(strSQL, null, null);
                    }
                    i++;
                    lbTrangThai.Text = "Đang chuyển...(" + i.ToString() + ")";
                    this.Refresh();
                }
                pnTrangThai.Enabled = true;
                lbTrangThai.Text = "Đã xong! Có " + i.ToString() + " hợp đồng đã được chuyển.";
                this.Refresh();
                this.Load_DanhSachGoiY();
                this.Load_DanhSachChoLamThanhToan();
                //this.uiTab1.TabPages["tabChoThanhToan"].Selected = true; ;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                uiTab1.Enabled = true;
            }
        }

        private void gdDanhSach_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }

        private void btInPhieuChi_Click(object sender, EventArgs e)
        {


            try
            {
                string sql_Sotien = "delete from tbl_TienBangChu_HopDong";
                DBModule.ExecuteNonQuery(sql_Sotien, null, null);
                frmShowRP2 frm = new frmShowRP2();
                rp_T_PhieuChiThanhToanMia rp = new rp_T_PhieuChiThanhToanMia();
                string RecordSelect = "";
                int CountCell = 1;
                foreach (GridEXRow jr in this.gdChoThanhToan.GetCheckedRows())
                {
                    GridEXCell jc = jr.Cells["HopDongID"];
                    if (CountCell == 1)
                    {
                        RecordSelect += " {tbl_HopDong.ID}=" + jc.Value.ToString();
                        long lTongDauTuPhaiTra = clsHopDong.GetTongTienDauTuPhaiTra(long.Parse(jc.Value.ToString()), MDSolutionApp.VuTrongID, null, null);
                        long lTongTienKhoanCo = clsHopDong.GetTongCacKhoanTienCoThuDuoc(long.Parse(jc.Value.ToString()), MDSolutionApp.VuTrongID, null, null);
                        long lLayve = lTongTienKhoanCo - lTongDauTuPhaiTra;


                        if (lLayve > 0)
                        {
                            sql_Sotien = "insert into tbl_TienBangChu_HopDong values(" + jc.Value.ToString() + ",N'Số tiền được nhận (bằng chữ): " + frmShowRP3.DocSo(lLayve) + ".'," + lLayve.ToString() + ")";
                        }
                        else
                        {
                            long ll = 0 - lLayve;
                            sql_Sotien = "insert into tbl_TienBangChu_HopDong values(" + jc.Value.ToString() + ",N'Số tiền còn nợ (bằng chữ): " + frmShowRP3.DocSo(0 - lLayve) + ".'," + ll.ToString() + ")";
                        }
                        DBModule.ExecuteNonQuery(sql_Sotien, null, null);
                    }
                    else
                    {
                        RecordSelect += " or {tbl_HopDong.ID}=" + jc.Value.ToString();
                        //RecordSelect += " {tbl_HopDong.ID}=" + jc.Value.ToString();
                        long lTongDauTuPhaiTra = clsHopDong.GetTongTienDauTuPhaiTra(long.Parse(jc.Value.ToString()), MDSolutionApp.VuTrongID, null, null);
                        long lTongTienKhoanCo = clsHopDong.GetTongCacKhoanTienCoThuDuoc(long.Parse(jc.Value.ToString()), MDSolutionApp.VuTrongID, null, null);
                        long lLayve = lTongTienKhoanCo - lTongDauTuPhaiTra;


                        if (lLayve > 0)
                        {
                            sql_Sotien = "insert into tbl_TienBangChu_HopDong values(" + jc.Value.ToString() + ",N'Số tiền được nhận (bằng chữ): " + frmShowRP3.DocSo(lLayve) + ".'," + lLayve.ToString() + ")";
                        }
                        else
                        {
                            long ll = 0 - lLayve;
                            sql_Sotien = "insert into tbl_TienBangChu_HopDong values(" + jc.Value.ToString() + ",N'Số tiền còn nợ (bằng chữ): " + frmShowRP3.DocSo(0 - lLayve) + ".'," + ll.ToString() + ")";
                        }
                        DBModule.ExecuteNonQuery(sql_Sotien, null, null);
                    }
                    CountCell++;
                }
                if (CountCell > 1)
                {

                    rp.RecordSelectionFormula = RecordSelect;

                    frm.RP = rp;
                    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                    frm.RPtitle = "Phiếu chi ";
                    //frm.MdiParent = this;
                    frm.ShowDialog();
                }
                else
                    MessageBox.Show("Bạn chưa chọn hợp đồng nào xem!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //------------------------
            if (MessageBox.Show("Bạn muốn chuyển các hợp đồng sang làm thanh toán?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    foreach (GridEXRow jr in this.gdChoThanhToan.GetCheckedRows())
                    {
                        GridEXCell jc = jr.Cells["HopDongID"];
                        string strSQL = "sp_TinhToan_ChuyenVu " + jc.Value.ToString() + ", " + MDSolutionApp.VuTrongID.ToString();
                        DBModule.ExecuteNonQuery(strSQL, null, null);
                    }
                    //this.Load_DanhSachGoiY();
                    this.Load_DanhSachDaLamThanhToan();
                    this.Load_DanhSachChoLamThanhToan();
                    //this.uiTab1.TabPages["tabDaThanhToan"].Selected = true; ;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //-----------------------
        }

        private void cbXa_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.Load_DanhSachGoiY();
            this.Load_DanhSachChoLamThanhToan();
            this.Load_DanhSachChoLamThanhToan();
        }

        private void cbThon_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Load_DanhSachGoiY();
            this.Load_DanhSachChoLamThanhToan();
            this.Load_DanhSachChoLamThanhToan();
        }

        private void chkDaTinhCongNo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //this.Load_DanhSachChoLamThanhToan();gdDanhSach
                if (chkDaTinhCongNo.Checked == true)
                {
                    foreach (GridEXRow jr in this.gdDanhSach.GetDataRows())
                    {
                        GridEXCell jc = jr.Cells["NgayTinhCongNo"];
                        if (jc.Value.ToString().Trim().Length > 0)
                            jr.CheckState = RowCheckState.Checked;

                    }
                    gdDanhSach.Refresh();
                }
                else
                {
                    foreach (GridEXRow jr in this.gdDanhSach.GetDataRows())
                    {
                        GridEXCell jc = jr.Cells["NgayTinhCongNo"];
                        if (jc.Value.ToString().Trim().Length > 0)
                            jr.CheckState = RowCheckState.Unchecked;
                    }
                    gdDanhSach.Refresh();
                }
                //this.Load_DanhSachGoiY();
                //this.Load_DanhSachDaLamThanhToan();

                //this.uiTab1.TabPages["tabDaThanhToan"].Selected = true; ;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkConNoLai_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //this.Load_DanhSachChoLamThanhToan();gdDanhSach
                if (chkConNoLai.Checked == true)
                {
                    foreach (GridEXRow jr in this.gdDanhSach.GetDataRows())
                    {
                        GridEXCell jc = jr.Cells["TongNoLai"];
                        if (long.Parse(jc.Value.ToString()) > 0)
                            jr.CheckState = RowCheckState.Checked;

                    }
                    gdDanhSach.Refresh();
                }
                else
                {
                    foreach (GridEXRow jr in this.gdDanhSach.GetDataRows())
                    {
                        GridEXCell jc = jr.Cells["TongNoLai"];
                        if (long.Parse(jc.Value.ToString()) > 0)
                            jr.CheckState = RowCheckState.Unchecked;
                    }
                    gdDanhSach.Refresh();
                }
                //this.Load_DanhSachGoiY();
                //this.Load_DanhSachDaLamThanhToan();

                //this.uiTab1.TabPages["tabDaThanhToan"].Selected = true; ;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gdDaLamThanhToan_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "clMenu")
            {
                this.contextRight.Show(MousePosition);
            }
        }

        private void gdChoThanhToan_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "clMenu")
            {
                this.contextRight.Show(MousePosition);
            }
        }


    }
}