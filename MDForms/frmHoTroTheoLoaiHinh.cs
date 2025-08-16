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
    public partial class frmHoTroTheoLoaiHinh : Form
    {
        static frmHoTroTheoLoaiHinh _theformHoTroTheoLoaiHinh;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmHoTroTheoLoaiHinh OneInstanceFrm
        {
            get
            {
                if (null == _theformHoTroTheoLoaiHinh || _theformHoTroTheoLoaiHinh.IsDisposed)
                {
                    _theformHoTroTheoLoaiHinh = new frmHoTroTheoLoaiHinh();
                }

                return _theformHoTroTheoLoaiHinh;
            }
        }
        clsDanhMucHoTro oDMHT = new clsDanhMucHoTro();
        public frmHoTroTheoLoaiHinh()
        {
            InitializeComponent();
            LoadcbbHoTro();
            LoadccbXa();
            //LoadccbThon();
            //Load_gdVLoaiHinh();
        }

        public void Load_gdVLoaiHinh()
        {
            DataSet ds;
            ds = clsHoTroTheoLoaiHinh.GetListbyWhere("", " DanhMucHoTroID= " + cbbHoTro.SelectedValue.ToString() + " AND VuTrongID=" + MDSolutionApp.VuTrongID.ToString(), " NgayLamHoTro", null, null);
            if (ds.Tables.Count > 0)
            {
                gdVLoaiHinh.SetDataBinding(ds.Tables[0], "");
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
        private void LoadcbbHoTro()
        {
            try
            {
                DataSet ds;
                ds = clsDanhMucHoTro.GetListbyWhere("ID, Ten", " TuongUngDanhMucDauTu <>1", "", null, null);
                if (ds.Tables.Count > 0)
                {
                    this.cbbHoTro.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Load_HopDong_Grid(long ThonID)
        {
            DataSet ds;
            ds = clsHopDong.GetDanhSachHopDongTheoDieuKien(-1, "", DonviType.Thon, ThonID.ToString(), false);
            if (ds.Tables.Count > 0)
            {
                gdVHopDong.SetDataBinding(ds.Tables[0], "");
            }

        }
        private void cbXa_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadccbThon();
        }
        private void cbThon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbThon.SelectedValue != null)
            {
                this.Load_HopDong_Grid(long.Parse(cbThon.SelectedValue.ToString()));
            }
        }
        private void cbnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                clsHoTroTheoLoaiHinh oHTTLH = new clsHoTroTheoLoaiHinh();
                GridEXRow[] gdRChked = this.gdVHopDong.GetCheckedRows();
                if (gdRChked.Length <= 0) throw new Exception("Bạn chưa chọn hợp đồng nào để áp dụng");
                if (txtSoTien.Text == "") throw new Exception("Bạn chưa nhập giá trị đầu vào");
                if (!SaveLoaiHinhHoTro(true, gdRChked.Length, out oHTTLH)) throw new Exception("Có lỗi khi lưu thông tin hỗ trợ loại hình");
                foreach (GridEXRow jr in gdRChked)
                {
                    clsHoTro.HoTro_TheoLoaiHinh(long.Parse(jr.Cells["ID"].Value.ToString()),MDSolutionApp.VuTrongID, oHTTLH.ID, oHTTLH.DanhMucHoTroID, oHTTLH.NgayLamHoTro, oHTTLH.DonGia, oDMHT.TinhTheo, null, null);                                
                }
                Load_gdVLoaiHinh();
                MessageBox.Show("Bạn đã lưu lại thành công", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.gdVLoaiHinh.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool SaveLoaiHinhHoTro(bool isAddNew, int tongso, out clsHoTroTheoLoaiHinh oHTTLH)
        {
            oHTTLH = new clsHoTroTheoLoaiHinh();
            try
            {                
                oHTTLH.DonGia = long.Parse(txtSoTien.Text);
                if (oHTTLH.DonGia < 0) throw new Exception("Bạn nhập số tiền nhỏ hơn 0");
                oHTTLH.NgayLamHoTro = dtpNgayLam.Value;
                if (oHTTLH.NgayLamHoTro > DateTime.Now) throw new Exception("Bạn chọn ngày làm không đúng");
                oHTTLH.DanhMucHoTroID = oDMHT.ID;
                oHTTLH.GhiChu = ">> " + cbXa.Text + " - " + cbThon.Text + " - Tổng số hợp đồng được áp dụng: " + tongso.ToString() + " - " + oDMHT.GhiChu;
                oHTTLH.VuTrongID = MDSolutionApp.VuTrongID;
                oHTTLH.Save(null, null);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

        }

        private void gdVLoaiHinh_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            string message;

            message = String.Format("Bạn sẽ xóa cả các bản ghi liên quan trong bảng hỗ trợ.Bạn có muốn xóa không ?");

            if (MessageBox.Show(message, MDSolutionApp.MessageCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                long oID = long.Parse(this.gdVLoaiHinh.GetValue("ID").ToString());
                clsHoTro.DeleteLoaiHinh(oID, null, null);
                DataRowView dr = (DataRowView)e.Row.DataRow;
                clsHoTroTheoLoaiHinh oHTTLH = new clsHoTroTheoLoaiHinh(long.Parse(dr.Row.ItemArray[0].ToString()));

                oHTTLH.Delete(null, null);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void gdVLoaiHinh_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa thành công", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.gdVLoaiHinh.Refetch();
        }

        private void gdVLoaiHinh_RecordUpdated(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã sửa thành công", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.gdVLoaiHinh.Refetch();
        }

        private void gdVLoaiHinh_UpdatingRecord(object sender, CancelEventArgs e)
        {
            ////try
            ////{
            ////    if (!SaveLoaiHinhHoTro(false)) throw new Exception("Có lỗi khi lưu thông tin hỗ trợ loại hình");
            ////    string strSQL = "";
            ////    strSQL = "Select * from tbl_HoTro where HoTroTheoLoaiHinhID=" + oHTTLH.ID.ToString();
            ////    DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);

            ////    for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            ////    {
            ////        DataRow dr = ds.Tables[0].Rows[i];
            ////        if (!dr.IsNull("ID"))
            ////            oHoTro.ID = long.Parse(dr["ID"].ToString());

            ////        if (!dr.IsNull("HopDongID"))
            ////            oHoTro.HopDongID = long.Parse(dr["HopDongID"].ToString());

            ////        if (!dr.IsNull("NgayLamHoTro"))
            ////            oHoTro.NgayLamHoTro = DateTime.Parse(dr["NgayLamHoTro"].ToString());
            ////        if (!dr.IsNull("DanhMucHoTroID"))
            ////            oHoTro.DanhMucHoTroID = long.Parse(dr["DanhMucHoTroID"].ToString());
            ////        if (!dr.IsNull("VuTrongID"))
            ////            oHoTro.VuTrongID = long.Parse(dr["VuTrongID"].ToString());

            ////        if (!dr.IsNull("SoLuong"))
            ////            oHoTro.SoLuong = long.Parse(dr["SoLuong"].ToString());

            ////        if (!dr.IsNull("HoTroTheoLoaiHinhID"))
            ////            oHoTro.HoTroTheoLoaiHinhID = long.Parse(dr["HoTroTheoLoaiHinhID"].ToString());
            ////        if (TinhTheo == 0)
            ////        {
            ////            oHoTro.DonGia = 0;
            ////            oHoTro.SoTien = long.Parse(this.gdVLoaiHinh.GetValue("DonGia").ToString());
            ////        }
            ////        else
            ////        {
            ////            oHoTro.DonGia = float.Parse(this.gdVLoaiHinh.GetValue("DonGia").ToString());
            ////            oHoTro.SoTien = oHoTro.SoLuong * long.Parse(oHoTro.DonGia.ToString());
            ////        } oHoTro.Save(null, null);

            ////    }


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}
        }

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSoTien.Text))
                {
                    long test = long.Parse(txtSoTien.Text);

                }
            }
            catch
            {
                MessageBox.Show("Tiền không được nhập chữ", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTien.Text = "";
            }
        }

        private void gdVLoaiHinh_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "XemHoTro")
            {
                try
                {
                    long ID = long.Parse(this.gdVLoaiHinh.GetValue("ID").ToString());
                    frmDanhSachHoTroLoaiHinh aa = new frmDanhSachHoTroLoaiHinh(ID);
                    aa.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Có lỗi khi xem danh sách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cbbHoTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            oDMHT.ID = long.Parse(cbbHoTro.SelectedValue.ToString());
            oDMHT.Load(null, null);
            lblDonViTinh.Text = oDMHT.DonViTinh;
            lblLoaiHinhHoTro.Text = oDMHT.Ten + "  Ghi chú:" + oDMHT.GhiChu;
            Load_gdVLoaiHinh();
        }

        private void cbbHoTro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.cbXa.Focus();
            }
        }

        private void cbXa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.cbThon.Focus();
            }
        }

        private void cbThon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.dtpNgayLam.Focus();
            }
        }

        private void dtpNgayLam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.txtSoTien.Focus();
            }
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.cbnNhap_Click(null, null);
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            DataSet dr;
            string strSQL1 = "";

            strSQL1 = "SELECT * FROM View_HopDong WHERE 1=1 ";



            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {
                if (this.chkTimkiemchinhxac.Checked)
                {
                    strSQL1 += " AND (MaHopDong = N'" + DBModule.RefineString(txtTimKiem.Text) + "' OR HoTen = N'" + DBModule.RefineString(txtTimKiem.Text) + "' )";
                }
                else
                {
                    strSQL1 += " AND (MaHopDong like N'%" + DBModule.RefineString(txtTimKiem.Text) + "%' OR HoTen like N'%" + DBModule.RefineString(txtTimKiem.Text) + "%' )";
                }
                dr = DBModule.ExecuteQuery(strSQL1, null, null);
                if (dr.Tables.Count > 0)
                {
                    this.gdVHopDong.SetDataBinding(dr.Tables[0], "");

                } if (dr.Tables[0].Rows.Count > 0)
                { }
                else
                {
                    txtTimKiem.Text = null;
                    MessageBox.Show("Không có hợp đồng nào như vậy", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTimKiem.Focus();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTimKiem.Focus();
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {

                this.btnTimkiem_Click(null, null);
                this.gdVHopDong.Focus();
            }
        }

      

    }   
}