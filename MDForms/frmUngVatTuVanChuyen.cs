
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
using DACASUCO.MDReport;


namespace MDSolution
{
    public partial class frmUngVatTuVanChuyen : Form
    {
        private  NodeHopDongVanChuyen nHDVC = new NodeHopDongVanChuyen("-1", "Hợp Đồng Vận Chuyển", HDVCType.Root);
        private clsXeVanChuyen oXVC = new clsXeVanChuyen();
        private clsUngVatTuVanChuyen oUVTVC = new clsUngVatTuVanChuyen();
        private DataSet gdVXeVanChuyenSource;
        private DataSet gdVChiTietUngVatTuSource;
        private DataSet ddlVatTuVanChuyenSource;

        public frmUngVatTuVanChuyen()
        {
            InitializeComponent();
            LoadDDLVatTuVanChuyen();
            LoadDDLNoiTamUngVatTu();
            CommonClass.loadTreeHopDongVanChuyen(tvHopDongVanChuyen);
            tvHopDongVanChuyen.Focus();
        }
        public frmUngVatTuVanChuyen(string ID)
        {
            InitializeComponent();
            
            CommonClass.loadTreeHopDongVanChuyen(tvHopDongVanChuyen);
            LoadDDLVatTuVanChuyen();
            LoadDDLNoiTamUngVatTu();
            LoadgdVXeVanChuyen1(ID);
            tvHopDongVanChuyen.Focus();
        }
        private void LoadgdVXeVanChuyen1(string ID)
        {
            DataSet ds;
            string strSQL = "SELECT * FROM tbl_XeVanChuyen Where ID = " + ID.ToString();
          ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables.Count > 0)
            {
                this.gdVXeVanChuyen.SetDataBinding(ds.Tables[0], "");
                cmdThem.Enabled = true;
            }
            else
            {
                cmdThem.Enabled = false;
            }
        }
        private void LoadgdVXeVanChuyen()
        {
            string strSQL = "SELECT * FROM V_XeVC_TC Where HopDongVanChuyenID = " + nHDVC.HopDongID;
            this.gdVXeVanChuyenSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gdVXeVanChuyenSource.Tables.Count > 0)
            {
                this.gdVXeVanChuyen.SetDataBinding(this.gdVXeVanChuyenSource.Tables[0], "");
                cmdThem.Enabled = true;
            }
            else
            {
                cmdThem.Enabled = false;
            }
        }
        private void LoadDDLVatTuVanChuyen()
        {
            string strSQL = "SELECT * FROM tbl_VatTuVanChuyen";
            this.ddlVatTuVanChuyenSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            this.gdVChiTietUngVatTu.DropDowns["ddlVatTuVanChuyen"].SetDataBinding(this.ddlVatTuVanChuyenSource.Tables[0], "");
        }
        private void LoadDDLNoiTamUngVatTu()
        {
            string strSQL = "SELECT * FROM tbl_NoiTamUngVatTu";
            this.ddlVatTuVanChuyenSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            this.gdVChiTietUngVatTu.DropDowns["ddlNoiTamUngVatTu"].SetDataBinding(this.ddlVatTuVanChuyenSource.Tables[0], "");
        }
        private void LoadgdVChiTietUngVanChuyen()
        {
            string strSQL = "Select  VatTuID,DonGia,Sum(SoTien) as SoTien,Sum(SoLuong)as Soluong,NgayUng,SoChungTu,HopDongVanChuyenID,NoiTamUngVatTuID,GhiChu  from V_UngVatTuVanChuyen Where HopDongVanChuyenID =" + nHDVC.HopDongID + " And VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString()+
            " Group by NgayUng,SoChungTu,HopDongVanChuyenID,NoiTamUngVatTuID,DonGia,VatTuID,GhiChu Order by VatTuID ASC";
            this.gdVChiTietUngVatTuSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gdVChiTietUngVatTuSource.Tables.Count > 0)
            {
                this.gdVChiTietUngVatTu.SetDataBinding(this.gdVChiTietUngVatTuSource.Tables[0], "");
                cmdSua.Enabled = true;
            }
            else
            {
                cmdSua.Enabled = false;
            }
        }

        private void gdVXeVanChuyen_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.gdVXeVanChuyen.CurrentRow.RowType == Janus.Windows.GridEX.RowType.NewRecord)
                {
                    //lblTB.Text = "Bạn có thể nhập số tiền bằng đơn giá nhân số lượng hoặc nhập trực tiếp vào ô số tiền ";
                    this.gdVChiTietUngVatTu.AllowAddNew = InheritableBoolean.False;
                }
                else
                {
                    //this.gdVChiTietUngVatTu.AllowAddNew = InheritableBoolean.True;
                    this.LoadgdVChiTietUngVanChuyen();
                }
            }
            catch
            {
                this.gdVChiTietUngVatTu.AllowAddNew = InheritableBoolean.False;
            }            
        }

        private void tvHopDongVanChuyen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nHDVC = (NodeHopDongVanChuyen)tvHopDongVanChuyen.SelectedNode.Tag;
                this.LoadgdVXeVanChuyen();
                LoadgdVChiTietUngVanChuyen();
            }
        }

        private void tvHopDongVanChuyen_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nHDVC = (NodeHopDongVanChuyen)e.Node.Tag;
            //this.LoadgdVXeVanChuyen();
            this.LoadgdVChiTietUngVanChuyen();
        }

        private void gdVChiTietUngVatTu_AddingRecord(object sender, CancelEventArgs e)
        {
            if (!SaveUngVatTuVanChuyen(true)) { e.Cancel = true; }
            else
            {
                //MessageBox.Show("Bạn đã lưu lại thành công", "Sơn Dương", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void gdVChiTietUngVatTu_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {
            string message;
            string SoCT = this.gdVChiTietUngVatTu.GetValue("SoChungTu").ToString();
            message = String.Format("Bạn muốn xóa chứng từ "+SoCT+" ?");

            if (MessageBox.Show(message, "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                string sql = "Delete tbl_UngVatTuVanChuyen Where SoChungTu=" + SoCT+" And VuTrongID="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
                MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                LoadgdVChiTietUngVanChuyen();
                LoadgdVXeVanChuyen();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void gdVChiTietUngVatTu_RecordAdded(object sender, EventArgs e)
        {
            this.LoadgdVChiTietUngVanChuyen();
            //this.gdVChiTietUngVatTu.SetValue("ID", oUVTVC.ID);
            this.gdVChiTietUngVatTu.Refetch();
        }

        private void gdVChiTietUngVatTu_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa thành công", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gdVChiTietUngVatTu_RecordUpdated(object sender, EventArgs e)
        {
            this.LoadgdVChiTietUngVanChuyen();
            this.gdVChiTietUngVatTu.Refetch();
        }

        private void gdVChiTietUngVatTu_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!SaveUngVatTuVanChuyen(false)) { e.Cancel = true; }
                else
                {
                    MessageBox.Show("Bạn đã sửa lại thành công", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                LoadgdVChiTietUngVanChuyen();
                e.Cancel = true; }
        }

        private bool SaveUngVatTuVanChuyen(bool isAddNew)
        {
            try
            {
                if (isAddNew)
                {
                    oUVTVC = new clsUngVatTuVanChuyen();
                    oUVTVC.VuTrongID = MDSolution.DACASUCO_App.VuTrongID;
                    oUVTVC.HopDongVanChuyenID = long.Parse(nHDVC.HopDongID);
                    oUVTVC.XeID = long.Parse(this.gdVXeVanChuyen.GetValue("ID").ToString());
                }
                else
                {
                    oUVTVC = new clsUngVatTuVanChuyen(long.Parse(this.gdVChiTietUngVatTu.GetValue("ID").ToString()));
                    oUVTVC.Load(null, null);
                }
                if (string.IsNullOrEmpty(this.gdVChiTietUngVatTu.GetValue("VatTuID").ToString())) throw new Exception("Bạn chưa nhập vật tư ");

                oUVTVC.VatTuID = long.Parse(this.gdVChiTietUngVatTu.GetValue("VatTuID").ToString());
                if (string.IsNullOrEmpty(this.gdVChiTietUngVatTu.GetValue("SoLuong").ToString()))// throw new Exception("Bạn chưa nhập số lượng ");
                { oUVTVC.SoLuong = 0; }
                else
                {
                    oUVTVC.SoLuong = long.Parse(this.gdVChiTietUngVatTu.GetValue("SoLuong").ToString());
                    if (oUVTVC.SoLuong < 0) throw new Exception("Số lượng bạn nhập vào nhỏ hơn 0, kiểm tra lại");
                }
                if (string.IsNullOrEmpty(this.gdVChiTietUngVatTu.GetValue("DonGia").ToString()))// throw new Exception("Bạn chưa nhập đơn giá ");                
                { oUVTVC.DonGia = 0; }
                else
                {
                    oUVTVC.DonGia = long.Parse(this.gdVChiTietUngVatTu.GetValue("DonGia").ToString());
                    if (oUVTVC.DonGia < 0) throw new Exception("Đơn giá bạn nhập vào nhỏ hơn 0, kiểm tra lại");
                }
                if (string.IsNullOrEmpty(this.gdVChiTietUngVatTu.GetValue("SoTien").ToString())) throw new Exception("Bạn chưa nhập số tiền");                
                    oUVTVC.SoTien = long.Parse(this.gdVChiTietUngVatTu.GetValue("SoTien").ToString());
                if (oUVTVC.SoTien<0) throw new Exception("Số tiền bạn nhập vào nhỏ hơn 0, kiểm tra lại");

                decimal tempSoTien = oUVTVC.SoLuong * oUVTVC.DonGia;
                if (tempSoTien > 0 && oUVTVC.SoTien >= 0 && oUVTVC.SoTien != tempSoTien)
                {
                    if (MessageBox.Show("Số tiền " + oUVTVC.SoTien.ToString("### ### ##0") + " nhập vào khác với tổng số lượng * đơn giá : " + oUVTVC.SoLuong.ToString("### ### ##0") + "* " + oUVTVC.DonGia.ToString("### ### ##0") + "\n Bạn muốn lưu giá trị nào? Yes để lưu số tiền được nhập vào, no để lưu tổng tính toán.", "Sơn Dương 2008", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        oUVTVC.SoTien = tempSoTien;
                    }
                }

                if (string.IsNullOrEmpty(this.gdVChiTietUngVatTu.GetValue("NgayUng").ToString())) throw new Exception("Bạn chưa nhập ngày ứng ");

                oUVTVC.NoiTamUngVatTuID= long.Parse(this.gdVChiTietUngVatTu.GetValue("NoiTamUngVatTuID").ToString());
                oUVTVC.NgayUng = DateTime.Parse(this.gdVChiTietUngVatTu.GetValue("NgayUng").ToString());
                //oUVTVC.SoChungTu = this.gdVChiTietUngVatTu.GetValue("SoChungTu").ToString();
                oUVTVC.GhiChu = this.gdVChiTietUngVatTu.GetValue("GhiChu").ToString();
                oUVTVC.Save(null, null);                
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void frmUngVatTuVanChuyen_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

       
       
        private void gdVChiTietUngVatTu_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "XemChiTiet")
            {
                try
                {

                    long SoCT = long.Parse(this.gdVChiTietUngVatTu.GetValue("SoChungTu").ToString());
                    long VatTuID = long.Parse(this.gdVChiTietUngVatTu.GetValue("VatTuID").ToString());
                    double SoTien = Math.Round(double.Parse(this.gdVChiTietUngVatTu.GetValue("SoTien").ToString()), 0); ;
                    long ID = long.Parse(nHDVC.HopDongID);
                    frmShowRP2 frm = new frmShowRP2();
                    if (VatTuID == 1)
                    {
                        string sql = "Update V_TheChanXe Set TienBangChu=N'" + frmShowRP3.DocSo(SoTien).ToString() + "đồng chẵn' Where SoChungTu=" + SoCT.ToString();
                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                        rpt_TienTheChanXe rp = new rpt_TienTheChanXe();
                        rp.RecordSelectionFormula = "{V_TheChanXe.SoChungTu}= " +SoCT.ToString() + " AND {tbl_HopDongVanChuyen.ID}=" + ID.ToString();
                        rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                        frm.RP = rp;
                    }
                    else
                    {
                        string sql = "Update V_TheChanCap Set TienBangChu=N'" + frmShowRP3.DocSo(SoTien).ToString() + "đồng chẵn' Where SoChungTu=" + SoCT.ToString();
                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                        rpt_TheChapCap rp = new rpt_TheChapCap();
                        rp.RecordSelectionFormula = "{V_TheChanCap.SoChungTu}= " + SoCT.ToString()+" AND {tbl_HopDongVanChuyen.ID}=" + ID.ToString();
                        rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                        frm.RP = rp;
                    }
                    
                    
                        frm.RPtitle = "Chứng từ";
                        frm.Show();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
             
            }
        }

        private void tvHopDongVanChuyen_AfterSelect(object sender, TreeViewEventArgs e)
        {
            label1.Text = tvHopDongVanChuyen.SelectedNode.Text;
            nHDVC = (NodeHopDongVanChuyen)e.Node.Tag;
            this.LoadgdVXeVanChuyen();
        }

        

        private void cmdThem_Click(object sender, EventArgs e)
        {
            frmTheChan frm = new frmTheChan(long.Parse(nHDVC.HopDongID), true);
            frm.ShowDialog();
            LoadgdVChiTietUngVanChuyen();
            LoadgdVXeVanChuyen();
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (long.Parse(this.gdVChiTietUngVatTu.GetValue("SoChungTu").ToString()) > 0)
            {
                string message;
                string SoCT = this.gdVChiTietUngVatTu.GetValue("SoChungTu").ToString();
                message = String.Format("Bạn muốn xóa chứng từ " + SoCT + " ?");
                if (MessageBox.Show(message, "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "Delete tbl_UngVatTuVanChuyen Where SoChungTu=" + SoCT+"And VuTrongId="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                }
                LoadgdVChiTietUngVanChuyen();
                LoadgdVXeVanChuyen();
            }
            else
            {
                MessageBox.Show("Bạn phải chọn một chứng từ để xóa", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

      
    }
}
