using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using Janus.Windows.GridEX;

namespace MDSolution
{
    public partial class frmDanhMucLinhVucDauTu : Form
    {
        private string[] DVCU = new string[10];
        private DataSet ddlApDung;     
        private DataSet gridDataSource;
        private clsDanhMucDauTu oDMDT = new clsDanhMucDauTu();
        private clsDanhMucHoTro oDMHT = new clsDanhMucHoTro();
        public frmDanhMucLinhVucDauTu()
        {
            InitializeComponent();
            this.LoadgdLVDT();
            this.Load_ddlHinhThucDauTu();
            this.Load_ddlloaihinhThucDauTu();
            this.Load_ddlApDung();
            
        }
        private void LoadgdLVDT()
        {
            string strSQL = "SELECT * FROM tbl_DanhMucDauTu";
            this.gridDataSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdVLVDauTu.SetDataBinding(this.gridDataSource.Tables[0], "");
            }
        }
        private void Load_ddlHinhThucDauTu()
        {

            DataSet ds;
            ds = clsHinhThucDauTu.GetListbyWhere("", "", "", null, null);
            this.gdVLVDauTu.DropDowns["ddl_Hinhthucdautu"].SetDataBinding(ds.Tables[0], "");

        }
        private void Load_ddlloaihinhThucDauTu()
        {

            DataSet ds;
            ds = clsLoaiHinhDauTu.GetListbyWhere("", "", "", null, null);
            this.gdVLVDauTu.DropDowns["ddl_loaihinhdautu"].SetDataBinding(ds.Tables[0], "");
        }
        private void Load_ddlApDung()
        { 
            try 
            {
                string strSQL = "SELECT * FROM tbl_ApDung";
                this.ddlApDung = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                this.gdVLVDauTu.DropDowns["ddlApDung"].SetDataBinding(this.ddlApDung.Tables[0], "");
            }
            catch 
            {
                MessageBox.Show("Can't load Danh Muc Dau Tu");
            } 
        }
        private void gdVLVDauTu_RecordAdded(object sender, EventArgs e)
        {
            this.gdVLVDauTu.Refetch();
            
        }

        private void gdVLVDauTu_AddingRecord(object sender, CancelEventArgs e)
        { try
            {
                string sql = "";
                DataSet ds;
                if (string.IsNullOrEmpty(this.gdVLVDauTu.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên đầu tư");

                sql = "SELECT count(*) as Dem FROM tbl_DanhMucDauTu Where Ten='" + this.gdVLVDauTu.GetValue("Ten").ToString() + "'";
                ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                DataRow d13 = ds.Tables[0].Rows[0];

                if (long.Parse(d13["Dem"].ToString()) > 0) throw new Exception("Bạn nhập trùng tên đầu tư");


            if (!SaveLinhVucDauTu(true)) {  e.Cancel = true; }
            else
            {
                long oDT_ID = oDMDT.ID;
                oDMHT.Save(oDT_ID, null, null);
                //MessageBox.Show("Bạn đã lưu lại thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                this.gdVLVDauTu.SetValue("ID", oDMDT.ID);
               
                LoadgdLVDT();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
        }
        }

        private void gdVLVDauTu_RecordUpdated(object sender, EventArgs e)
        {
            this.gdVLVDauTu.Refetch();
        }

        private void gdVLVDauTu_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {
            string sql = "";
            string message;
            DataSet ds;
            sql = "SELECT count(*) as Dem FROM tbl_DauTu Where DanhMucDauTuID='" + this.gdVLVDauTu.GetValue("ID").ToString() + "'";
            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            DataRow d13 = ds.Tables[0].Rows[0];
            if (long.Parse(d13["Dem"].ToString()) > 0)
            {
                MessageBox.Show("Bạn không được xóa danh mục đầu tư này", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                    message = String.Format("Bạn muốn xóa bản ghi này?");

                    if (MessageBox.Show(message, " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oDMHT.ID = oDMDT.ID;
                        oDMDT.Delete(null, null);
                        oDMHT.Delete(null,null);

                    }
                    else
                    {
                        e.Cancel = true;
                    }                  
                    
                }   
        }

        private void gdVLVDauTu_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
   
        }
      
        private void gdVLVDauTu_UpdatingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                string sql = "";
                DataSet ds;
                 if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(this.gdVLVDauTu.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên đầu tư");

                sql = "SELECT * FROM tbl_DanhMucDauTu Where Ten='" + this.gdVLVDauTu.GetValue("Ten").ToString() + "'";
                ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow d13 = ds.Tables[0].Rows[0];

                    if (d13["ID"].ToString() != this.gdVLVDauTu.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên đầu tư");
                }

                if (!SaveLinhVucDauTu(false)) { e.Cancel = true; }
                else
                {
                    oDMHT.ID = oDMDT.ID;
                    oDMHT.Save(0, null, null);
                    MessageBox.Show("Bạn đã sửa lại thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadgdLVDT();
                }
            }
            else
            {
                LoadgdLVDT(); ;
                e.Cancel = true;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }      
        }

        private bool SaveLinhVucDauTu(bool isAddNew)
        {
            try
            {
                if (isAddNew)
                {
                    oDMDT = new clsDanhMucDauTu();
                    oDMHT = new clsDanhMucHoTro();
                    
                }
                else
                {
                    oDMDT.Load(null, null);
                    oDMHT.Load(null, null);
                }

                if (string.IsNullOrEmpty(this.gdVLVDauTu.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập danh mục đầu tư ");
              
                    oDMDT.Ten = this.gdVLVDauTu.GetValue("Ten").ToString();
                    oDMHT.Ten = this.gdVLVDauTu.GetValue("Ten").ToString();
                 
                if (string.IsNullOrEmpty(this.gdVLVDauTu.GetValue("DonViTinh").ToString())) throw new Exception("Bạn chưa nhập đơn vị tính ");
               
                    oDMDT.DonViTinh = this.gdVLVDauTu.GetValue("DonViTinh").ToString();
                    oDMHT.GhiChu = this.gdVLVDauTu.GetValue("DonViTinh").ToString();
                    oDMDT.HinhThucDauTu = long.Parse( this.gdVLVDauTu.GetValue("HinhThucDauTu").ToString());
                    oDMDT.LoaiHinhDauTuID =long.Parse( this.gdVLVDauTu.GetValue("LoaiHinhDauTuID").ToString());
                    if (string.IsNullOrEmpty(this.gdVLVDauTu.GetValue("ApDungNhieu").ToString())) throw new Exception("Bạn chưa nhập có áp dụng nhiều hay không ");
                 
                    oDMDT.ApDungNhieu = long.Parse( this.gdVLVDauTu.GetValue("ApDungNhieu").ToString());

                    //if (!string.IsNullOrEmpty(this.gdVLVDauTu.GetValue("ThuTu").ToString())) //throw new Exception("Bạn chưa nhập thứ tự ");
                    //{
                    //    oDMDT.ThuTu = long.Parse(this.gdVLVDauTu.GetValue("ThuTu").ToString());
                    //}
                    //else
                    //{
                    //    string s1 = "SELECT max(convert(int,[ThuTu])) AS Max FROM tbl_DanhMucDauTu";
                    //    DataSet d1;
                    //    d1 = MDSolutionEntities.DBModule.ExecuteQuery(s1, null, null);
                    //    DataRow d2 = d1.Tables[0].Rows[0];

                    //    if (!d2.IsNull("Max"))
                    //    {
                    //        oDMDT.ThuTu = (long.Parse(d2["Max"].ToString()) + 1);
                    //    }
                    //    else { oDMDT.ThuTu = 1; }
                    //}
                    oDMDT.IsActive = long.Parse(this.gdVLVDauTu.GetValue("TrangThai").ToString());
                oDMDT.Save(null, null);
                clsDanhMucDauTu.UpdateDanhMucDauTuVuTrong(oDMDT.ID, MDSolution.DACASUCO_App.VuTrongID, oDMDT.IsActive, null, null);
                if (!string.IsNullOrEmpty(DVCU[0]))
                {
                    clsDanhMucDT_DonViCU.DeleteDanhMucDauTu_DonVi(oDMDT.ID, null, null);
                }
                foreach (string d in DVCU)
                {
                    Console.WriteLine(d);
                    if (!string.IsNullOrEmpty(d))
                    {
                        clsDanhMucDT_DonViCU.UpdateDanhMucDauTu_DonVi(oDMDT.ID, long.Parse(d), 1, null, null);
                    }
                }
                
               
                oDMHT.LoaiHoTro = 1 ;
                oDMHT.TuongUngDanhMucDauTu = 1;
                oDMHT.TinhTheo = 0;
                        
                return true;
                     
                     
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void gdVLVDauTu_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.gdVLVDauTu.CurrentRow.RowType == Janus.Windows.GridEX.RowType.NewRecord)
                {
                    oDMDT = new clsDanhMucDauTu();
                }
                else
                {
                    oDMDT.ID = long.Parse(this.gdVLVDauTu.GetValue("ID").ToString());
                }
            }
            catch
            {
                oDMDT = new clsDanhMucDauTu();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                clsDanhMucDauTu.UpdateAllCurrentDanhMucDauTuChoVuTrong(MDSolution.DACASUCO_App.VuTrongID, null, null);
                MessageBox.Show("Các danh mục đầu tư được lựa chọn đã được thiết lập cho vụ trồng hiện tại thành công");
            }
            catch
            {
                MessageBox.Show("Các lỗi, thông báo lại cho đội hỗ trợ ");
            }
        }

        private void gdVLVDauTu_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "btnDVCU")
            {
                try
                {
                    if (this.gdVLVDauTu.GetValue("ID").ToString() != "")
                    {
                        MDDialoge.dlgChonDonViCungUng frm = new MDSolution.MDDialoge.dlgChonDonViCungUng(this.gdVLVDauTu.GetValue("ID").ToString());
                        frm.ShowDialog();
                        DVCU = frm.a;
                        if (frm.Test)
                        {
                            this.gdVLVDauTu.SetValue("btnDVCU", "a");
                        }
                    }
                    else
                    {
                        MDDialoge.dlgChonDonViCungUng frm = new MDSolution.MDDialoge.dlgChonDonViCungUng("");
                        frm.ShowDialog();
                        DVCU = frm.a;
                        if (frm.Test)
                        {
                            this.gdVLVDauTu.SetValue("btnDVCU", "a");
                        }
                    }
                    
                }
                catch {
                    MDDialoge.dlgChonDonViCungUng frm = new MDSolution.MDDialoge.dlgChonDonViCungUng(""); 
                    frm.ShowDialog();
                    DVCU = frm.a;
                    if (frm.Test)
                    {
                        this.gdVLVDauTu.SetValue("btnDVCU", "a");
                    }
                }
            }
        }
      
    }
}