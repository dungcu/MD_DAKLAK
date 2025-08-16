using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms
{
    public partial class frmNhapNangSuatDuKienTheoThon : Form
    {
        static frmNhapNangSuatDuKienTheoThon _theformNhapNangSuatDuKienTheoThon;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmNhapNangSuatDuKienTheoThon OneInstanceFrm
        {
            get
            {
                if (null == _theformNhapNangSuatDuKienTheoThon || _theformNhapNangSuatDuKienTheoThon.IsDisposed)
                {
                    _theformNhapNangSuatDuKienTheoThon = new frmNhapNangSuatDuKienTheoThon();
                }

                return _theformNhapNangSuatDuKienTheoThon;
            }
        }
        private clsThuaRuong oThuaRuong = new clsThuaRuong();
        private clsThonNangSuatDuKienApDung oTNSDKAD = new clsThonNangSuatDuKienApDung();
        private DataSet ddlThon;
        public frmNhapNangSuatDuKienTheoThon()
        {
            InitializeComponent();
            LoadccbXa();
            LoadccbThon();
            LoadddlThon();
            Load_GridApDung();

        }
        public void Load_GridApDung()
        {
            try
            {
                string xaid = "-1";
                string strSQL = "";
                DataSet ds;
                xaid = cbXa.SelectedValue.ToString();
                strSQL = "select * from tbl_ThonNangSuatDuKienApDung WHERE VuTrongID=" + MDSolutionApp.VuTrongID + " AND ThonID in (Select ID FROM tbl_Thon WHERE XaID =" + xaid.ToString() + ")";
                //if (cbThon.SelectedValue != null) thonid = cbThon.SelectedValue.ToString();             

                ds = DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables.Count > 0)
                {
                    this.gridDanhSachNangSuatDuKienDaApDung.SetDataBinding(ds.Tables[0], "");
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadddlThon()
        {
            string SQL = "SELECT * FROM tbl_Thon";
            this.ddlThon = DBModule.ExecuteQuery(SQL, null, null);
            this.gridDanhSachNangSuatDuKienDaApDung.DropDowns["ddlThon"].SetDataBinding(this.ddlThon.Tables[0], "");
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
                this.cbXa.SelectedIndexChanged += new System.EventHandler(this.cbXa_SelectedIndexChanged);
                this.cbXa.SelectedIndex = 0;

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
                ds = clsThon.GetListbyWhere("ID, Ten", " XaID =" + cbXa.SelectedValue.ToString() + " AND [ID] not in (SELECT ThonID FROM tbl_ThonNangSuatDuKienApDung WHERE VuTrongID="+MDSolutionApp.VuTrongID+")", "", null, null);
                if (ds.Tables.Count > 0)
                {                    
                    ds.Tables[0].Rows.Add(new object[] { -1, "-- Thôn --" });
                    this.cbThon.DataSource = ds.Tables[0];
                    this.cbThon.SelectedIndex = ds.Tables[0].Rows.Count - 1;
                }

                string a = cbThon.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void cbXa_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadccbThon();
            Load_GridApDung();
        }
                

        private void cbnNhap_Click(object sender, EventArgs e)
        {
            try{
                string thonid = "-1";
                thonid = cbThon.SelectedValue.ToString();
                if (long.Parse(thonid) <= 0) throw new Exception("Bạn chưa chọn thôn");
                if (txtNangSuat.Text == "") throw new Exception("Bạn chưa nhập năng suất dự kiến ");

                oTNSDKAD.ID = 0;
                oTNSDKAD.NgayThucHien = DateTime.Parse(dtpNgayLam.Value.ToString());
                if (oTNSDKAD.NgayThucHien > DateTime.Now) throw new Exception("Bạn chọn ngày thực hiện lớn hơn ngày hiện tại");
                oTNSDKAD.ThonID = long.Parse(thonid);
                oTNSDKAD.VuTrongID = MDSolutionApp.VuTrongID;
                oTNSDKAD.NangSuatDuKien = float.Parse(txtNangSuat.Text);
                if (oTNSDKAD.NangSuatDuKien > 10000) throw new Exception("Bạn nhập năng suất lớn quá");
                oTNSDKAD.Save(null, null);
                txtNangSuat.Text = "";
                LoadccbThon();
                Load_GridApDung();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridDanhSachNangSuatDuKienDaApDung_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            string message;
            message = String.Format("Bạn muốn xóa năng suất dự kiến đã nhập cho thôn này?");

            if (MessageBox.Show(message, MDSolutionApp.MessageCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView dr = (DataRowView)e.Row.DataRow;
                clsThonNangSuatDuKienApDung oTNSDKAD = new clsThonNangSuatDuKienApDung(long.Parse(dr.Row.ItemArray[0].ToString()));
                oTNSDKAD.Delete(null, null);
                LoadccbThon();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void gridDanhSachNangSuatDuKienDaApDung_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa thành công", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtNangSuat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNangSuat.Text))
                {
                    long test = long.Parse(txtNangSuat.Text);
                }
            }
            catch
            {
                MessageBox.Show("Năng suất chỉ đuợc nhập số ", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNangSuat.Text = "";
            }

        }

        private void gridDanhSachNangSuatDuKienDaApDung_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            long ThonID = long.Parse(this.gridDanhSachNangSuatDuKienDaApDung.GetValue("TenThon").ToString());
            long ID = long.Parse(this.gridDanhSachNangSuatDuKienDaApDung.GetValue("ID").ToString());
            frmDanhSachNangSuatDuKien frm = new frmDanhSachNangSuatDuKien(ThonID,ID);
            frm.ShowDialog();

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
            this.txtNangSuat.Focus();
        }

        private void txtNangSuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                cbnNhap_Click(null, null);
                this.gridDanhSachNangSuatDuKienDaApDung.Focus();
            }
        }


    }
}