using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using DACASUCO.MDForms;
using MDSolution;

namespace DACASUCO.MDDanhMuc
{
    public partial class frm_Gia_Mia_Theo_Tram_Nong_Vu : Form
    {
        private DataSet gridDataSource;
        private clsGiaMiaTheoTramNongVu clsGiaMia;
        public frm_Gia_Mia_Theo_Tram_Nong_Vu()
        {
            InitializeComponent();

            this.Load_ddlTramNongVu();
            this.LoadMainGrid();
            this.Load_GiaMiaCaBiet();
            cboTram.SelectedIndex = 0;

        }
        private void LoadMainGrid()
        {
            string strSQL = "SELECT * FROM [tbl_Gia_Mia_Theo_Tram_Nong_Vu] WHERE vu_trong_id=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            if (chkTram.Checked)
            {
                if (long.Parse(cboTram.SelectedIndex.ToString()) > 0)
                {
                    strSQL += " AND tram_nong_vu_id=" + cboTram.SelectedValue.ToString();
                }

            }

            this.gridDataSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdMainGrid.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");
            }
        }
        private void Load_GiaMiaCaBiet()
        {
            string sql = "";

            {
                if (rdCabiet.Checked)
                {
                    sql = "Select * from V_BangGiaCaBiet Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                    if (chkTram.Checked)
                    {
                        if (long.Parse(cboTram.SelectedIndex.ToString()) > 0)
                        {
                            sql = "Select * from V_BangGiaCaBiet where TramID=" + cboTram.SelectedValue.ToString() + " AND VutrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                        }
                    }
                    this.grdGiaCaBiet.DataSource = null;
                    this.grpGia.Text = "Giá mía cá biệt theo HĐĐT";
                }
                else
                {
                    sql = "Select * from V_GiaMia Where vu_trong_id =" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " AND MaHDDT Not In (Select MaHDDT from V_BangGiaCaBiet Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + ")";
                    if (chkTram.Checked)
                    {
                        if (long.Parse(cboTram.SelectedIndex.ToString()) > 0)
                        {
                            sql = "Select * from V_GiaMia Where vu_trong_id =" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " AND MaHDDT Not In (Select MaHDDT from V_BangGiaCaBiet Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + ") AND TramID=" + cboTram.SelectedValue.ToString();
                        }
                    }
                    this.grdGiaCaBiet.DataSource = null;
                    this.grpGia.Text = "Chi tiết giá mía phổ dụng theo Trạm";
                }
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.grdGiaCaBiet.SetDataBinding(ds.Tables[0], "");
                }
            }
        }
        private void Load_ddlTramNongVu()
        {
            DataSet ds;
            string sql = "Select ID, Ten from tbl_TramNongVu";
            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            this.gdMainGrid.DropDowns["ddlTramNongVu"].SetDataBinding(ds.Tables[0], "");
            this.cboTram.DataSource = ds.Tables[0];
            DataRow oR = ds.Tables[0].NewRow();
            oR["ID"] = 0;
            oR["Ten"] = "";
            ds.Tables[0].Rows.InsertAt(oR, 0);
            this.cboTram.ValueMember = "ID";
            this.cboTram.DisplayMember = "Ten";

        }
        private bool doSave()
        {
            clsGiaMia = new clsGiaMiaTheoTramNongVu();
            clsGiaMia.vu_trong_id = MDSolution.DACASUCO_App.VuTrongID;
            long.TryParse(this.gdMainGrid.GetValue("ID").ToString(), out clsGiaMia.ID);
            if (clsGiaMia.ID > 0) clsGiaMia.Load(null, null);
            try
            {
                long.TryParse(this.gdMainGrid.GetValue("tram_nong_vu_id").ToString(), out clsGiaMia.tram_nong_vu_id);
                long.TryParse(this.gdMainGrid.GetValue("gio_ap_dung").ToString(), out clsGiaMia.gio_ap_dung);
                if (clsGiaMia.gio_ap_dung < 0 || clsGiaMia.gio_ap_dung > 23) clsGiaMia.gio_ap_dung = 0;
                DateTime.TryParse(this.gdMainGrid.GetValue("ngay_ap_dung").ToString(), out clsGiaMia.ngay_ap_dung);
                long.TryParse(this.gdMainGrid.GetValue("gia_mua_mia").ToString(), out clsGiaMia.gia_mua_mia);
                //long.TryParse(this.gdMainGrid.GetValue("ho_tro_gia_mia").ToString(), out clsGiaMia.ho_tro_gia_mia);
                //clsGiaMia.gia_thanh_toan = clsGiaMia.gia_mua_mia + clsGiaMia.ho_tro_gia_mia;
                //long.TryParse(this.gdMainGrid.GetValue("gia_thanh_toan_css").ToString(), out clsGiaMia.gia_thanh_toan_css);
                //clsGiaMia.ghi_chu = gdMainGrid.GetValue("ghi_chu").ToString();
                clsGiaMia.Save(null, null);
                //gdMainGrid.SetValue("gia_thanh_toan", clsGiaMia.gia_thanh_toan);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


        }

        private void gdMainGrid_AddingRecord(object sender, CancelEventArgs e)
        {
            if (!this.doSave())
            {

                //string message;
                //message = String.Format("Có lỗi khi thêm mới bản ghi,bạn có muốn tiếp tục");
                //if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    e.Cancel = true;
                //}
                //else
                //{
                //    gdVUser.CancelCurrentEdit();
                //}
                ////MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                this.gdMainGrid.SetValue("ID", clsGiaMia.ID);
            }
        }

        private void gdMainGrid_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            string message;
            message = String.Format("Bạn muốn xóa bản ghi này?");
            if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView dr = (DataRowView)e.Row.DataRow;
                clsGiaMia = new clsGiaMiaTheoTramNongVu();
                //clsGiaMia.vu_trong_id = MDSolution.DACASUCO_App.VuTrongID;
                long.TryParse(this.gdMainGrid.GetValue("ID").ToString(), out clsGiaMia.ID);
                clsGiaMia.Delete(null, null);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void gdMainGrid_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.doSave();
            }
            else
            {
                e.Cancel = true;
                gdMainGrid.CancelCurrentEdit();
                //SendKeys.SendWait("{ESC}");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdTimKiem_Click(object sender, EventArgs e)
        {
            DataSet ds;
            string sql = "";
            if (rdPhodung.Checked)
            {
                sql = "SELECT * FROM V_GiaMia WHERE Vu_Trong_ID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " And MaHDDT Not In (Select MaHDDT from V_BangGiaCaBiet Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + ")";
            }
            else
            {
                sql = "SELECT * FROM V_BangGiaCaBiet WHERE VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            }

            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {


                {
                    sql += " AND (MaHDDT like N'%" + MDSolutionEntities.DBModule.RefineString(txtTimKiem.Text) + "%' OR dbo.BoDauTiengViet(HoTen) like N'%" + MDSolutionEntities.DBModule.RefineString(txtTimKiem.Text.Trim()) + "%' )";
                }



                ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    this.grdGiaCaBiet.SetDataBinding(ds.Tables[0], "");

                }

                else
                {
                    txtTimKiem.Text = null;
                    MessageBox.Show("Không có thông tin nào như vậy!", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTimKiem.Focus();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTimKiem.Focus();
            }
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (rdPhodung.Checked)
            {
                try
                {
                    frmNhapGiaMiaCaBiet frm = new frmNhapGiaMiaCaBiet(this.grdGiaCaBiet.GetValue("MaHDDT").ToString(), true);
                    frm.ShowDialog();
                    this.Load_GiaMiaCaBiet();
                }
                catch
                {
                    MessageBox.Show("Chưa có hợp đồng được chọn");
                }
            }
            else
            {
                try
                {
                frmNhapGiaMiaCaBiet frm = new frmNhapGiaMiaCaBiet(this.grdGiaCaBiet.GetValue("ID").ToString(), false);
                frm.ShowDialog();
                this.Load_GiaMiaCaBiet();
                 }
                catch
                {
                    MessageBox.Show("Chưa có hợp đồng được chọn");
                }
            }
        }

        private void rdPhodung_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadMainGrid();
            this.Load_GiaMiaCaBiet();
            cmdXoa.Enabled = false;

        }

        private void rdCabiet_CheckedChanged(object sender, EventArgs e)
        {

            this.LoadMainGrid();
            this.Load_GiaMiaCaBiet();
            if (this.grdGiaCaBiet.DataSource != null)
            {
                cmdXoa.Enabled = true;
            }

        }

        private void cboTram_SelectedValueChanged(object sender, EventArgs e)
        {
            this.LoadMainGrid();
            this.Load_GiaMiaCaBiet();
            if (rdCabiet.Checked)
            {
                if (this.grdGiaCaBiet.DataSource != null)
                {
                    cmdXoa.Enabled = true;
                }
                else
                {
                    cmdXoa.Enabled = false;
                }
            }
            else
            {
                if (this.grdGiaCaBiet.DataSource != null)
                {
                    cmdXoa.Enabled = false;
                }

            }


        }

        private void chkTram_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTram.Checked)
            {
                cboTram.Enabled = true;
            }
            else
            {
                cboTram.Enabled = false;
                cboTram.SelectedIndex = 0;
            }
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa sự thiết lập giá mía cá biệt của HĐĐT " + this.grdGiaCaBiet.GetValue("MaHDDT").ToString(), "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = "Delete from tbl_GiaMiaCaBiet where ID=" + this.grdGiaCaBiet.GetValue("ID").ToString();
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    MessageBox.Show("Bạn đã xóa thành công", "DACASUCO");
                    this.Load_GiaMiaCaBiet();
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi tring khi thực hiện việc xóa", "DACASUCO");
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            DataSet ds;
            string sql = "";
            if (rdPhodung.Checked)
            {
                sql = "SELECT * FROM V_GiaMia WHERE Vu_Trong_ID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " And MaHDDT Not In (Select MaHDDT from V_BangGiaCaBiet Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + ")";
            }
            else
            {
                sql = "SELECT * FROM V_BangGiaCaBiet WHERE VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            }

            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {


                {
                    sql += " AND (MaHDDT like N'%" + MDSolutionEntities.DBModule.RefineString(txtTimKiem.Text) + "%' OR dbo.BoDauTiengViet(HoTen) like N'%" + MDSolutionEntities.DBModule.RefineString(txtTimKiem.Text.Trim()) + "%' )";
                }



                ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    this.grdGiaCaBiet.SetDataBinding(ds.Tables[0], "");

                }
            }
        }

        private void frm_Gia_Mia_Theo_Tram_Nong_Vu_Load(object sender, EventArgs e)
        {
            clsVuTrong oVT = new clsVuTrong(MDSolution.DACASUCO_App.VuTrongID);
            oVT.Load(null, null);
            VT.Text = oVT.Ten;
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
        }


    }
}
