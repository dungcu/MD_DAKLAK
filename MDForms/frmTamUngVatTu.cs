using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDReport;
using MDSolution.MDForms;
namespace MDSolution.MDForms
{
    public partial class frmTamUngVatTu : Form
    {
        static frmTamUngVatTu _theformTamUngVatTu;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmTamUngVatTu OneInstanceFrm
        {
            get
            {
                if (null == _theformTamUngVatTu || _theformTamUngVatTu.IsDisposed)
                {
                    _theformTamUngVatTu = new frmTamUngVatTu();
                }

                return _theformTamUngVatTu;
            }
        }
        private string strID = "";
        public string MaKVC = "";
        public string MaKhach = "";
        public string SoXe = "";
        public long SCT = 0;       
        private string HDVC_ID = "";
        private string XE_ID = "";
        
        private clsUngVatTuVanChuyen oUVTVC = new clsUngVatTuVanChuyen();
        private DataSet gdVChiTietUngVatTuSource;
        private DataSet ddlVatTuVanChuyenSource;
    
        public frmTamUngVatTu()
        {
            InitializeComponent();
            this.LoadDDLVatTuVanChuyen();
            this.LoadDDLNoiTamUngVatTu();
            LoadgdVChiTietUngVanChuyen();
            
            btnSave.Visible = false;
            btnThoat.Visible = false;
            cboSoXe.Enabled = false;
           // btnInphieu.Visible = false;
            gdVChiTietUngVatTu.AllowAddNew =0;
        }
        public frmTamUngVatTu(string HDVC_ID, string XeID, long ChungTu)
        {
            try
            {    
                InitializeComponent();
                txtHopDongVC.Text = HDVC_ID;
                this.txtsochungtu.Text = ChungTu.ToString();
                cboSoXe.SelectedValue = XeID;
                this.LoadDDLVatTuVanChuyen();
                this.LoadDDLNoiTamUngVatTu();
                //LoadgdVChiTietUngVanChuyen();
                btnSave.Visible = false;
                btnThoat.Visible = false;
                //btnInphieu.Visible = true;
                gdVChiTietUngVatTu.AllowAddNew =0;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Get_KhachVanChuyen(string MaKVC)
        {
            if (MaKVC != "")
            {
                clsHopDongVanChuyen objHDVC = new clsHopDongVanChuyen();
                objHDVC.Load(MaKVC, null, null);
                if (objHDVC.ID > 0)
                {
                    txtHoTenKHVC.Text = clsComFunctions.HoTen_Format(objHDVC.TenChuHopDong);

                    load_cbo_xe("0", objHDVC.ID.ToString());
                }
                else
                {
                    txtHoTenKHVC.Text = "";

                    DataSet ds = null;
                    cboSoXe.DataSource = ds;
                }

            }
        }
        private void Get_KhachVanChuyen_ByID(string MaKVC)
        {
            if (MaKVC != "")
            {
                clsHopDongVanChuyen objHDVC = new clsHopDongVanChuyen(long.Parse(MaKVC));
                objHDVC.Load(null, null);
                if (objHDVC.ID > 0)
                {
                    txtHoTenKHVC.Text = clsComFunctions.HoTen_Format(objHDVC.TenChuHopDong);
                    
                    txtHopDongVC.Text = objHDVC.MaHopDong;
                    load_cbo_xe("0", objHDVC.ID.ToString());
                }
                else
                {
                    txtHoTenKHVC.Text = "";
                   
                    DataSet ds = null;
                    cboSoXe.DataSource = ds;
                }

            }
        }
        private void cmdFindHDVC_Click(object sender, EventArgs e)
        {
            //txtsochungtu.Text = "";
            dlgHopDongVanChuyen dlg = new dlgHopDongVanChuyen();
            dlg.passID = new dlgHopDongVanChuyen.PassID(GetHopDongVC_ID);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                Get_KhachVanChuyen_ByID(MaKVC);
                dlg.Dispose();
            }
            else
            {               
                dlg.Dispose();
            }
        }

        public void GetHopDongVC_ID(string value)
        {
            MaKVC = value;
        }
        private void load_cbo_xe(string SelectedID, string HopDongCVCID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("TEN");
            DataSet ds = null;
            string[] strInits = new string[] { "0", "--Chọn--" };
            dt.Rows.Add(strInits);
            ds = clsXeVanChuyen.GetListbyWhere("ID, SoXe", "HopDongVanChuyenID=" + HopDongCVCID, "", null, null);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                 strID = dr["ID"].ToString();
                string strTEN = dr["SoXe"].ToString().ToUpper();
                string[] strValues = new string[] { strID, strTEN };
                dt.Rows.Add(strValues);
            }
            cboSoXe.DataSource = dt;
            cboSoXe.SelectedValue = SelectedID;

        }

        private void txtHopDongVC_TextChanged(object sender, EventArgs e)
        {
           
            if (txtHopDongVC.Text != "")
            {
                MaKVC = txtHopDongVC.Text;
                cboSoXe.Enabled = true;
            }
            else
            {
                txtHoTenKHVC.Text = "";
                cboSoXe.Text = "";
                cboSoXe.Enabled = false; }
            Get_KhachVanChuyen(txtHopDongVC.Text.Trim());
            LoadgdVChiTietUngVanChuyen();
        }
        private void LoadDDLVatTuVanChuyen()
        {
            string strSQL = "SELECT * FROM tbl_VatTuVanChuyen";
            this.ddlVatTuVanChuyenSource = DBModule.ExecuteQuery(strSQL, null, null);
            this.gdVChiTietUngVatTu.DropDowns["ddlVatTuVanChuyen"].SetDataBinding(this.ddlVatTuVanChuyenSource.Tables[0], "");
        }
        private void LoadDDLNoiTamUngVatTu()
        {
            string strSQL = "SELECT * FROM tbl_NoiTamUngVatTu";
            this.ddlVatTuVanChuyenSource = DBModule.ExecuteQuery(strSQL, null, null);
            this.gdVChiTietUngVatTu.DropDowns["ddlNoiTamUngVatTu"].SetDataBinding(this.ddlVatTuVanChuyenSource.Tables[0], "");
        }
        private void LoadgdVChiTietUngVanChuyen()
        {
            string strSQL = "";
            if (cboSoXe.SelectedValue != null)
            {
                if (long.Parse(cboSoXe.SelectedValue.ToString()) > 0)
                {
                    if (txtsochungtu.Text == "")
                    {
                        strSQL = "SELECT * FROM tbl_UngVatTuVanChuyen Where XeID = " + cboSoXe.SelectedValue.ToString();

                    }
                    else
                    {
                        strSQL = "SELECT * FROM tbl_UngVatTuVanChuyen Where XeID = " + cboSoXe.SelectedValue.ToString() + " AND SoChungTu=" + txtsochungtu.Text;

                    }
                }
                else
                {
                    if (txtsochungtu.Text != "")
                    {
                        if (MaKVC != "")
                        {
                            strSQL = "SELECT * FROM tbl_UngVatTuVanChuyen Where SoChungTu = " + txtsochungtu.Text + " AND HopDongVanChuyenID = " + MaKVC.ToString();
                        }
                        else
                        {
                            strSQL = "SELECT * FROM tbl_UngVatTuVanChuyen Where SoChungTu = " + txtsochungtu.Text;
                        }
                    }
                    else
                    {
                        strSQL = "SELECT * FROM tbl_UngVatTuVanChuyen Where HopDongVanChuyenID = " + MaKVC.ToString();

                    }
                }
                this.gdVChiTietUngVatTuSource = DBModule.ExecuteQuery(strSQL, null, null);
                if (this.gdVChiTietUngVatTuSource.Tables.Count > 0)
                {
                    this.gdVChiTietUngVatTu.SetDataBinding(this.gdVChiTietUngVatTuSource.Tables[0], "");
                }
            }
            
        }

        private void cboSoXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSoXe.SelectedValue != null)
            {//txtsochungtu.Text = "";   
                if (btnTaoMoi.Visible)
                {
                    LoadgdVChiTietUngVanChuyen();
                }
            }
        }
        
        private void gdVChiTietUngVatTu_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            string message;

            message = String.Format("Bạn muốn xóa thông tin ứng vật tư này?");

            if (MessageBox.Show(message, MDSolutionApp.MessageCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsUngVatTuVanChuyen.Delete(long.Parse(this.gdVChiTietUngVatTu.GetValue("ID").ToString()), null, null);
            }
            else
            {
                e.Cancel = true;
            }
        }
            
        private void gdVChiTietUngVatTu_RecordsDeleted(object sender, EventArgs e)
        {
            txtsochungtu.Text = "";
            MessageBox.Show("Đã xóa thành công", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
           txtsochungtu_Leave(null, null);
        }

        private void gdVChiTietUngVatTu_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.gdVChiTietUngVatTu.CurrentRow.RowType == Janus.Windows.GridEX.RowType.NewRecord)
                {
                    oUVTVC = new clsUngVatTuVanChuyen();
                }
                else
                {
                    oUVTVC.ID = long.Parse(this.gdVChiTietUngVatTu.GetValue("ID").ToString());
                }
            }
            catch
            {
                oUVTVC = new clsUngVatTuVanChuyen();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                long i = 0;
                if (MaKVC == "")
                {
                    if (HDVC_ID.ToString() == "") throw new Exception("Bạn chưa chọn chủ hợp đồng ");

                    MaKVC = HDVC_ID;
                }
                else
                {
                    if (long.Parse(cboSoXe.SelectedValue.ToString()) > 0)
                    {
                        XE_ID = cboSoXe.SelectedValue.ToString();                    }

                    else { XE_ID = "0"; }
                }

                clsHopDongVanChuyen objHDVC = new clsHopDongVanChuyen(long.Parse(MaKVC));
                objHDVC.Load(MaKVC, null, null);
                
                foreach (GridEXRow jr in this.gdVChiTietUngVatTu.GetRows())
                {
                    if (string.IsNullOrEmpty(jr.Cells["ID"].Value.ToString()))
                    {
                        txtsochungtu.Text = SCT.ToString();
                        oUVTVC.ID = -1;
                        oUVTVC.VuTrongID = MDSolutionApp.VuTrongID;
                        oUVTVC.HopDongVanChuyenID = long.Parse(objHDVC.ID.ToString());
                        //if (long.Parse(XE_ID) <= 0) throw new Exception("Bạn chưa chọn xe vận chuyển ");

                        oUVTVC.XeID = long.Parse(XE_ID);
                        if (string.IsNullOrEmpty(jr.Cells["VatTuID"].Value.ToString())) throw new Exception("Bạn chưa nhập vật tư ");

                        oUVTVC.VatTuID = long.Parse(jr.Cells["VatTuID"].Value.ToString());

                        if (string.IsNullOrEmpty(jr.Cells["NoiTamUngVatTuID"].Value.ToString())) throw new Exception("Bạn chưa chọn đơn vị cung ứng vật tư ");
                        oUVTVC.NoiTamUngVatTuID = long.Parse(jr.Cells["NoiTamUngVatTuID"].Value.ToString());

                        if (string.IsNullOrEmpty(jr.Cells["SoLuong"].Value.ToString())) throw new Exception("Bạn chưa nhập số lượng ");
                        oUVTVC.SoLuong = long.Parse(jr.Cells["SoLuong"].Value.ToString());
                        if (oUVTVC.SoLuong < 0) throw new Exception("Số lượng bạn nhập vào nhỏ hơn 0, kiểm tra lại");

                        if (string.IsNullOrEmpty(jr.Cells["DonGia"].Value.ToString())) throw new Exception("Bạn chưa nhập đơn giá ");
                        oUVTVC.DonGia = long.Parse(jr.Cells["DonGia"].Value.ToString());
                        if (oUVTVC.DonGia < 0) throw new Exception("Đơn giá bạn nhập vào nhỏ hơn 0, kiểm tra lại");

                        if (string.IsNullOrEmpty(jr.Cells["SoTien"].Value.ToString())) throw new Exception("Bạn chưa nhập số tiền");
                        oUVTVC.SoTien = long.Parse(jr.Cells["SoTien"].Value.ToString());
                        if (oUVTVC.SoTien < 0) throw new Exception("Số tiền bạn nhập vào nhỏ hơn 0, kiểm tra lại");

                        long tempSoTien = oUVTVC.SoLuong * oUVTVC.DonGia;
                        if (tempSoTien > 0 && oUVTVC.SoTien >= 0 && oUVTVC.SoTien != tempSoTien)
                        {
                            if (MessageBox.Show("Số tiền " + oUVTVC.SoTien.ToString("### ### ##0") + " nhập vào khác với tổng số lượng * đơn giá : " + oUVTVC.SoLuong.ToString("### ### ##0") + "* " + oUVTVC.DonGia.ToString("### ### ##0") + "\n Bạn muốn lưu giá trị nào? Yes để lưu số tiền được nhập vào, no để lưu tổng tính toán.", MDSolutionApp.MessageCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                oUVTVC.SoTien = tempSoTien;
                            }
                        }

                        if ((oUVTVC.SoLuong == 0) && (oUVTVC.DonGia == 0) && (oUVTVC.SoTien == 0)) throw new Exception("Bạn phải nhập số tiền hoặc số lượng cùng đơn giá ");
                        if (oUVTVC.SoTien == 0)
                        {
                            if (oUVTVC.SoLuong == 0 || oUVTVC.DonGia == 0) throw new Exception("Bạn phải nhập số tiền hoặc số lượng cùng đơn giá ");
                        }
                        if (!string.IsNullOrEmpty(jr.Cells["NoiTamUngVatTuID"].Value.ToString()))
                        {
                            oUVTVC.NoiTamUngVatTuID = long.Parse(jr.Cells["NoiTamUngVatTuID"].Value.ToString());
                        }
                        else { oUVTVC.NoiTamUngVatTuID = 0; } 
                        oUVTVC.NgayUng = DateTime.Parse(clcNgayung.Value.ToString());
                        //oUVTVC.SoChungTu = txtsochungtu.Text;
                        oUVTVC.Save(null, null);
                        i = i + 1;
                    }

                }
                if (i == 0) throw new Exception("Bạn chưa nhập dữ liệu để lưu lại ");
                  
                //if (oUVTVC.SoChungTu == SCT.ToString())
                {
                    LoadgdVChiTietUngVanChuyen();                
                  // MessageBox.Show("Bạn đã nhập thành công", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                   gdVChiTietUngVatTu.AllowAddNew = 0;
                    btnTaoMoi.Visible = true;
                   btnThoat.Visible = false;
                   btnSave.Visible = false;
                   btnsua.Visible = true;
                   btnInphieu.Visible = true;
                   txtsochungtu.ReadOnly = false;
                   cmdFindHDVC.Enabled = true;
                  // txtHopDongVC.Enabled = true;
                  // cboSoXe.Enabled = true;
                   this.gdVChiTietUngVatTu.Tables[0].Columns["SoChungTu"].Visible = true;
                   this.gdVChiTietUngVatTu.Tables[0].Columns["NgayUng"].Visible = true;
  
                } this.gdVChiTietUngVatTu.Refetch();
            }
            catch (Exception ex)
            {               
                MessageBox.Show(ex.Message, MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            
                if (string.IsNullOrEmpty(txtsochungtu.Text))
                {                   
                    MessageBox.Show("Bạn chưa nhập số chứng từ", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {                   
                    LoadgdVChiTietUngVanChuyen(); }
            }
                       
        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                long i = 0;
                if (MaKVC == "")
                {
                    MaKVC = HDVC_ID;

                }
                else
                {
                    if (long.Parse(cboSoXe.SelectedValue.ToString()) > 0) 
                    XE_ID = cboSoXe.SelectedValue.ToString(); 
                }

                clsHopDongVanChuyen objHDVC = new clsHopDongVanChuyen();
                objHDVC.Load(MaKVC, null, null);
                foreach (GridEXRow jr in this.gdVChiTietUngVatTu.GetRows())
                {
                    
                    if (!string.IsNullOrEmpty(jr.Cells["ID"].Value.ToString()))
                    {
                        oUVTVC.ID = long.Parse(jr.Cells["ID"].Value.ToString());
                        oUVTVC.Load(null, null);

                        if (oUVTVC.HopDongVanChuyenID == long.Parse(jr.Cells["HopDongVanChuyenID"].Value.ToString()) && oUVTVC.VatTuID == long.Parse(jr.Cells["VatTuID"].Value.ToString()) && oUVTVC.XeID == long.Parse(XE_ID) && oUVTVC.SoTien == long.Parse(jr.Cells["SoTien"].Value.ToString()) && oUVTVC.NgayUng == DateTime.Parse(jr.Cells["NgayUng"].Value.ToString()) /*&& oUVTVC.NoiTamUngVatTuID == long.Parse(jr.Cells["NoiTamUngVatTuID"].Value.ToString())*/)
                        {
                            if (!string.IsNullOrEmpty(jr.Cells["NoiTamUngVatTuID"].Value.ToString()))
                            {
                                if (oUVTVC.NoiTamUngVatTuID == long.Parse(jr.Cells["NoiTamUngVatTuID"].Value.ToString()))
                                {}
                                else { i = i + 1; }
                            }
                            else
                            {
                                if (oUVTVC.NoiTamUngVatTuID<1)
                                { }
                                else { i = i + 1; }
                            }
                        }
                        else
                        {
                            i = i + 1;
                        }
                            if(i>0)
                            {
                            oUVTVC.VuTrongID = MDSolutionApp.VuTrongID;
                            oUVTVC.HopDongVanChuyenID = long.Parse(jr.Cells["HopDongVanChuyenID"].Value.ToString());

                            if (XE_ID.ToString() == "") throw new Exception("Bạn chưa chọn xe vận chuyển ");
                            oUVTVC.XeID = long.Parse(XE_ID);
                            if (string.IsNullOrEmpty(jr.Cells["VatTuID"].Value.ToString())) throw new Exception("Bạn chưa nhập vật tư ");

                            oUVTVC.VatTuID = long.Parse(jr.Cells["VatTuID"].Value.ToString());
                            if (string.IsNullOrEmpty(jr.Cells["SoLuong"].Value.ToString())) throw new Exception("Bạn chưa nhập số lượng ");
                            oUVTVC.SoLuong = long.Parse(jr.Cells["SoLuong"].Value.ToString());
                            if (oUVTVC.SoLuong < 0) throw new Exception("Số lượng bạn nhập vào nhỏ hơn 0, kiểm tra lại");

                            if (string.IsNullOrEmpty(jr.Cells["DonGia"].Value.ToString())) throw new Exception("Bạn chưa nhập đơn giá ");
                            oUVTVC.DonGia = long.Parse(jr.Cells["DonGia"].Value.ToString());
                            if (oUVTVC.DonGia < 0) throw new Exception("Đơn giá bạn nhập vào nhỏ hơn 0, kiểm tra lại");

                            if (string.IsNullOrEmpty(jr.Cells["SoTien"].Value.ToString())) throw new Exception("Bạn chưa nhập số tiền");
                            oUVTVC.SoTien = long.Parse(jr.Cells["SoTien"].Value.ToString());
                            if (oUVTVC.SoTien < 0) throw new Exception("Số tiền bạn nhập vào nhỏ hơn 0, kiểm tra lại");

                            long tempSoTien = oUVTVC.SoLuong * oUVTVC.DonGia;
                            if (tempSoTien > 0 && oUVTVC.SoTien >= 0 && oUVTVC.SoTien != tempSoTien)
                            {
                                if (MessageBox.Show("Số tiền " + oUVTVC.SoTien.ToString("### ### ##0") + " nhập vào khác với tổng số lượng * đơn giá : " + oUVTVC.SoLuong.ToString("### ### ##0") + "* " + oUVTVC.DonGia.ToString("### ### ##0") + "\n Bạn muốn lưu giá trị nào? Yes để lưu số tiền được nhập vào, no để lưu tổng tính toán.", MDSolutionApp.MessageCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    oUVTVC.SoTien = tempSoTien;
                                }
                            }
                            if ((oUVTVC.SoLuong == 0) && (oUVTVC.DonGia == 0) && (oUVTVC.SoTien == 0)) throw new Exception("Bạn phải nhập số tiền hoặc số lượng cùng đơn giá ");
                            if (oUVTVC.SoTien == 0)
                            {
                                if (oUVTVC.SoLuong == 0 || oUVTVC.DonGia == 0) throw new Exception("Bạn phải nhập số tiền hoặc số lượng cùng đơn giá ");
                            }
                            if (!string.IsNullOrEmpty(jr.Cells["NoiTamUngVatTuID"].Value.ToString()))
                            {
                                oUVTVC.NoiTamUngVatTuID = long.Parse(jr.Cells["NoiTamUngVatTuID"].Value.ToString());
                            }
                            else { oUVTVC.NoiTamUngVatTuID = 0; }                            
                             oUVTVC.NgayUng = DateTime.Parse(jr.Cells["NgayUng"].Value.ToString());
                            //oUVTVC.SoChungTu = jr.Cells["SoChungTu"].Value.ToString();
                            oUVTVC.Save(null, null);                           
                        }
                    }
                }
                
                LoadgdVChiTietUngVanChuyen();
                if (i > 0)
                {
                    MessageBox.Show("Bạn đã sửa thành công", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                   // MessageBox.Show("Không có dữ liệu để ghi lại", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                } this.gdVChiTietUngVatTu.Refetch();
                btnInphieu.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void btnInphieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gdVChiTietUngVatTu.RecordCount <= 0) throw new Exception("Không có vật tư nào để in phiếu");
                if (HDVC_ID.ToString() == "")
                {
                    if (MaKVC == "") throw new Exception("Bạn chưa chọn chủ hợp đồng");
                }
                else { MaKVC = HDVC_ID.ToString(); }
                clsHopDongVanChuyen objHDVC = new clsHopDongVanChuyen(long.Parse(MaKVC));
                objHDVC.Load(MaKVC, null, null);

                long ID = objHDVC.ID;
                frmShowRP2 frm = new frmShowRP2();
                if (long.Parse(cboSoXe.SelectedValue.ToString()) > 0)
                    XE_ID = cboSoXe.SelectedValue.ToString();
                string ii = cboSoXe.SelectedValue.ToString();
                if (txtsochungtu.Text == "")
                {
                    rp_T_PhieuUngVatTuVanChuyen2 rp = new rp_T_PhieuUngVatTuVanChuyen2();
                    rp.RecordSelectionFormula = "{tbl_HopDongVanChuyen.ID}=" + ID.ToString() + " and {tbl_XeVanChuyen.ID}=" + XE_ID.ToString();
                    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                    frm.RP = rp;
                }
                else
                {

                    rp_T_PhieuUngVatTuVanChuyen3 rp1 = new rp_T_PhieuUngVatTuVanChuyen3();
                    rp1.RecordSelectionFormula = "{tbl_HopDongVanChuyen.ID}=" + ID.ToString() + " and {tbl_XeVanChuyen.ID}=" + XE_ID.ToString() + " and {tbl_UngVatTuVanChuyen.SoChungTu}= '" + txtsochungtu.Text + "'"; ;
                    rp1.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                    frm.RP = rp1;

                }
                GridEXRow ex = this.gdVChiTietUngVatTu.GetTotalRow();

                frm.TongTien = Convert.ToInt64(ex.Cells["SoTien"].Value.ToString());

                frm.RPtitle = "Phiếu tạm ứng vật tư vận chuyển";
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtsochungtu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtsochungtu.Text))
                {
                    long test = long.Parse(txtsochungtu.Text);
                }               
            }
            catch
            {
                MessageBox.Show("Số chứng từ chỉ được nhập kiểu số ", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsochungtu.Text = "";
            }
        }
       private void txtsochungtu_Leave(object sender, EventArgs e)
        {
            if (txtsochungtu.Text != "")
            {
                string strSQL = "";
                DataSet dem;
                strSQL = "SELECT Count(*) as Dem FROM tbl_UngVatTuVanChuyen Where SoChungTu=" + txtsochungtu.Text;
                dem = DBModule.ExecuteQuery(strSQL, null, null);
                if (dem.Tables[0].Rows.Count > 0)
                {
                    DataRow d1 = dem.Tables[0].Rows[0];
                    if (long.Parse(d1["Dem"].ToString()) > 0)
                    {                        
                        MaKVC = "";
                        cboSoXe.SelectedValue = 0;
                       // txtHopDongVC.Enabled = false;
                       // cboSoXe.Enabled = false;
                        cmdFindHDVC.Enabled = false;
                        btnInphieu.Visible = true;
                        DataSet ds;

                        strSQL = "select  top 1 HopDongVanChuyenID, XeID, NgayUng from tbl_UngVatTuVanChuyen where SoChungTu=" + txtsochungtu.Text + " group by HopDongVanChuyenID, XeID , NgayUng";
                        ds = DBModule.ExecuteQuery(strSQL, null, null);

                        DataRow dr = ds.Tables[0].Rows[0];
                        if (!dr.IsNull("HopDongVanChuyenID"))
                        {
                            HDVC_ID = dr["HopDongVanChuyenID"].ToString();
                            clsHopDongVanChuyen objHDVC = new clsHopDongVanChuyen(long.Parse(dr["HopDongVanChuyenID"].ToString()));
                            objHDVC.Load(null, null);
                            if (objHDVC.ID > 0)
                            {
                                txtHoTenKHVC.Text = clsComFunctions.HoTen_Format(objHDVC.TenChuHopDong);

                                txtHopDongVC.Text = objHDVC.MaHopDong;
                            }
                            else
                            {
                                txtHoTenKHVC.Text = "";
                                txtHopDongVC.Text = "";

                            }

                        }
                        if (!dr.IsNull("XeID"))
                        {
                            clsXeVanChuyen oXVC = new clsXeVanChuyen();
                            oXVC.ID = long.Parse(dr["XeID"].ToString());
                            XE_ID = oXVC.ID.ToString();
                            oXVC.Load(null, null);
                            cboSoXe.Text = oXVC.SoXe.ToString();
                        }
                        else { cboSoXe.Text = ""; }
                        if (!dr.IsNull("NgayUng"))
                            clcNgayung.Text = dr["NgayUng"].ToString();
                        strSQL = "SELECT * FROM tbl_UngVatTuVanChuyen Where SoChungTu=" + txtsochungtu.Text;
                        DataSet dd;
                        dd = DBModule.ExecuteQuery(strSQL, null, null);
                        this.gdVChiTietUngVatTu.SetDataBinding(dd.Tables[0], "");
                         }

                    else
                    {
                        LoadgdVChiTietUngVanChuyen();
                        XE_ID = "0";
                        HDVC_ID = "";
                        btnInphieu.Visible = false;
                        cmdFindHDVC.Enabled = true;
                        //txtHopDongVC.Enabled = true;
                        //cboSoXe.Enabled = true;
                        txtHoTenKHVC.Text = "";
                        txtHopDongVC.Text = "";
                        cboSoXe.Text = "";
                        clcNgayung.Value = DateTime.Now;
                            }
                }
            }
            else {
                if (cboSoXe.SelectedValue != null)
                {   
                    if (long.Parse(cboSoXe.SelectedValue.ToString()) > 0)
                    {if(HDVC_ID!="")                        
                        LoadgdVChiTietUngVanChuyen();
                    }
                }
                //btnSave.Visible = true;
                //btnsua.Visible = false;
                //btnInphieu.Visible = false;
                //LoadgdVChiTietUngVanChuyen();
                cmdFindHDVC.Enabled = true;
                txtHopDongVC.Enabled = true;
                //cboSoXe.Enabled = true;
                btnInphieu.Visible = true;
            }
            
        }
        
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            this.clcNgayung.Focus();
            string s1 = "SELECT max(convert(int,[SoChungTu])) AS Max FROM tbl_UngVatTuvanChuyen";
            DataSet d1;
            d1 = DBModule.ExecuteQuery(s1, null, null);
            DataRow d2 = d1.Tables[0].Rows[0];
            
            if (!d2.IsNull("Max"))
            {
                SCT = (long.Parse(d2["Max"].ToString()) + 1);
            }
            else { SCT = 1; }
            txtsochungtu.Text = SCT.ToString();
            cmdFindHDVC.Enabled = true;
            //txtHopDongVC.Enabled = true;
           // cboSoXe.Enabled = true;
            gdVChiTietUngVatTu.AllowAddNew = InheritableBoolean.True;
            txtsochungtu.ReadOnly = true;
            clcNgayung.Value = DateTime.Now;
            LoadgdVChiTietUngVanChuyen();
            btnTaoMoi.Visible = false;
            btnThoat.Visible = true;
            btnSave.Visible = true;
            btnsua.Visible = false;
            btnInphieu.Visible = false;
            this.gdVChiTietUngVatTu.Tables[0].Columns["SoChungTu"].Visible = false;
            this.gdVChiTietUngVatTu.Tables[0].Columns["NgayUng"].Visible = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            try
            {
                gdVChiTietUngVatTu.AllowAddNew = 0;
                txtsochungtu.Text = "";
                txtsochungtu.ReadOnly = false;
                clcNgayung.Value = DateTime.Now;
                //LoadgdVChiTietUngVanChuyen();
                btnTaoMoi.Visible = true;
                btnThoat.Visible = false;
                btnSave.Visible = false;
                btnsua.Visible = true;
                btnInphieu.Visible = true;
                cmdFindHDVC.Enabled = true;
                //txtHopDongVC.Enabled = true;
                //cboSoXe.Enabled = true;
                this.gdVChiTietUngVatTu.Tables[0].Columns["SoChungTu"].Visible = true;
                this.gdVChiTietUngVatTu.Tables[0].Columns["NgayUng"].Visible = true;
                LoadgdVChiTietUngVanChuyen();
            }
            catch
            { }

        }

        private void gdVChiTietUngVatTu_UpdatingCell(object sender, UpdatingCellEventArgs e)
        {
            long i = 0;
            if (e.Column.Key == "SoLuong" || e.Column.Key == "DonGia")
            {
                long ST;
                try
                {
                    ST = long.Parse(gdVChiTietUngVatTu.GetValue("SoLuong").ToString()) * long.Parse(gdVChiTietUngVatTu.GetValue("DonGia").ToString());
                }
                catch
                {
                    ST = 0;
                }
                this.gdVChiTietUngVatTu.SetValue("SoTien", ST);
            }
                foreach (GridEXRow jr in this.gdVChiTietUngVatTu.GetRows())
                {

                    if (!string.IsNullOrEmpty(jr.Cells["ID"].Value.ToString()))
                    {
                        oUVTVC.ID = long.Parse(jr.Cells["ID"].Value.ToString());
                        oUVTVC.Load(null, null);

                        if (oUVTVC.HopDongVanChuyenID == long.Parse(jr.Cells["HopDongVanChuyenID"].Value.ToString()) && oUVTVC.VatTuID == long.Parse(jr.Cells["VatTuID"].Value.ToString()) && oUVTVC.XeID == long.Parse(XE_ID) && oUVTVC.SoTien == long.Parse(jr.Cells["SoTien"].Value.ToString()) && oUVTVC.NgayUng == DateTime.Parse(jr.Cells["NgayUng"].Value.ToString()) /*&& oUVTVC.NoiTamUngVatTuID == long.Parse(jr.Cells["NoiTamUngVatTuID"].Value.ToString())*/)
                        {
                            if (!string.IsNullOrEmpty(jr.Cells["NoiTamUngVatTuID"].Value.ToString()))
                            {
                                if (oUVTVC.NoiTamUngVatTuID == long.Parse(jr.Cells["NoiTamUngVatTuID"].Value.ToString()))
                                {
                                    i = i;
                                }
                                else { i = i + 1; }
                            }
                        }
                        else
                        {
                            i = i + 1;
                        }
                    }
                }
            
        }

        private void txtsochungtu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.txtsochungtu_Leave(null, null);
                this.txtHopDongVC.Focus();

            }
        }

        private void txtHopDongVC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {                
                this.txtHoTenKHVC.Focus();

            }
        }

        private void txtHoTenKHVC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.cboSoXe.Focus();
            }
        }

        private void cboSoXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.gdVChiTietUngVatTu.Focus();

            }
        }

        private void clcNgayung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.txtHopDongVC.Focus();

            }
        }
        
    }
}