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
    public partial class frmDanhMucHoTro : Form
    {
        private clsDanhMucHoTro oDMHT = new clsDanhMucHoTro();
        private DataSet gridDataSource;
        public frmDanhMucHoTro()
        {
            InitializeComponent();
            Load_ddlloaihinhhotro();
            LoadgdLVHoTro();
            Load_ddlTinhTheo();
        }
        private void LoadgdLVHoTro()
        {
            string strSQL = "SELECT * FROM tbl_DanhMucHoTro Where TuongUngDanhMucDauTu =0";
            this.gridDataSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdVLVHoTro.SetDataBinding(this.gridDataSource.Tables[0], "");
            }
        }
        private void Load_ddlloaihinhhotro()
        {
            DataSet ds;
            ds = clsHinhThucDauTu.GetListbyWhere("", "", "", null, null);
            this.gdVLVHoTro.DropDowns["ddl_loaihinhhotro"].SetDataBinding(ds.Tables[0], "");
        }
        private void Load_ddlTinhTheo()
        {
            DataSet ds;
            string sql = "SELECT * FROM tbl_DanhMucHoTro_TinhTheo";
            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            this.gdVLVHoTro.DropDowns["ddl_TinhTheo"].SetDataBinding(ds.Tables[0], "");
        }
        private bool SaveLinhVucHoTro(bool isAddNew)
        {
            try
            {
                if (isAddNew)
                {                  
                    oDMHT = new clsDanhMucHoTro();

                }
                else
                {                    
                    oDMHT.Load(null, null);
                }

                if (string.IsNullOrEmpty(this.gdVLVHoTro.GetValue("Ten").ToString())) //throw new Exception("Bạn chưa nhập danh mục hỗ trợ ");
                {
                    MessageBox.Show("Bạn chưa nhập tên danh mục hỗ trợ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    oDMHT.Ten = this.gdVLVHoTro.GetValue("Ten").ToString();
                    
                    oDMHT.GhiChu = this.gdVLVHoTro.GetValue("GhiChu").ToString();
                }
                if (string.IsNullOrEmpty(this.gdVLVHoTro.GetValue("LoaiHoTro").ToString())) //throw new Exception("Bạn chưa chọn loại hỗ trợ ");
                {
                    oDMHT.LoaiHoTro = 0;
                    oDMHT.TuongUngDanhMucDauTu = 0;
                }
                else
                {
                    oDMHT.LoaiHoTro = long.Parse(this.gdVLVHoTro.GetValue("LoaiHoTro").ToString());
                    oDMHT.TuongUngDanhMucDauTu = 0;
                }
                if (string.IsNullOrEmpty(this.gdVLVHoTro.GetValue("TinhTheo").ToString())) //throw new Exception("Bạn chưa chọn cách tính ");                
                {
                    oDMHT.TinhTheo = 0;
                }
                else
                {
                    oDMHT.TinhTheo = long.Parse(this.gdVLVHoTro.GetValue("TinhTheo").ToString());
                }
                 
                if (string.IsNullOrEmpty(this.gdVLVHoTro.GetValue("DonViTinh").ToString()))// throw new Exception("Bạn chưa nhập đơn vị tính");
                {
                    MessageBox.Show("Bạn chưa nhập đơn vị tính", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    
                    oDMHT.DonViTinh = this.gdVLVHoTro.GetValue("DonViTinh").ToString();
                    oDMHT.Save(null, null);
                }
                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void gdVLVHoTro_AddingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                string sql = "";
                DataSet ds;
                if (string.IsNullOrEmpty(this.gdVLVHoTro.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên lĩnh vực hỗ trợ");

                sql = "SELECT count(*) as Dem FROM tbl_DanhMucHoTro Where Ten='" + this.gdVLVHoTro.GetValue("Ten").ToString() + "'";
                ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                DataRow d13 = ds.Tables[0].Rows[0];

                if (long.Parse(d13["Dem"].ToString()) > 0) throw new Exception("Bạn nhập trùng tên lĩnh vực hỗ trợ");


                if (!SaveLinhVucHoTro(true)) { e.Cancel = true; }
                else
                {
                    
                   // MessageBox.Show("Bạn đã lưu lại thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.gdVLVHoTro.SetValue("ID", oDMHT.ID);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void gdVLVHoTro_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            string sql = "";
            DataSet ds;
            sql = "SELECT count(*) as Dem FROM tbl_HoTro Where DanhMucHoTroID='" + this.gdVLVHoTro.GetValue("ID").ToString() + "'";
            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            DataRow d13 = ds.Tables[0].Rows[0];
            if (long.Parse(d13["Dem"].ToString()) > 0)
            {
                MessageBox.Show("Bạn không được xóa danh mục hỗ trợ này", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
               string message = String.Format("Bạn muốn xóa bản ghi này?");

                if (MessageBox.Show(message, " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oDMHT.Delete(null, null);

                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void gdVLVHoTro_RecordAdded(object sender, EventArgs e)
        {
            this.gdVLVHoTro.Refetch();
        }

        private void gdVLVHoTro_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
   
        }

        private void gdVLVHoTro_RecordUpdated(object sender, EventArgs e)
        {
            this.gdVLVHoTro.Refetch();
        }

        private void gdVLVHoTro_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.gdVLVHoTro.CurrentRow.RowType == Janus.Windows.GridEX.RowType.NewRecord)
                {
                    oDMHT = new clsDanhMucHoTro();
                }
                else
                {
                    oDMHT.ID = long.Parse(this.gdVLVHoTro.GetValue("ID").ToString());
                }
            }
            catch
            {
                oDMHT = new clsDanhMucHoTro();
            }
        }

        private void gdVLVHoTro_UpdatingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                long i = 1;
                 string sql = "";
                DataSet ds1;
                  if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "SELECT count(*) as Dem FROM tbl_HoTro Where DanhMucHoTroID='" + this.gdVLVHoTro.GetValue("ID").ToString() + "'";
                ds1 = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                DataRow d1 = ds1.Tables[0].Rows[0];
                if (long.Parse(d1["Dem"].ToString()) > 0)
                {
                    if (MessageBox.Show("Danh mục này đã được xử dụng,bạn có muốn thay đổi không ?", " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        i = 1;
                        
                    }
                    else
                    {
                        i = 0; 
                        e.Cancel = true;
                    LoadgdLVHoTro();}
                }
                if (i > 0)
                {
                    DataSet ds;
                    if (string.IsNullOrEmpty(this.gdVLVHoTro.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên lĩnh vực hỗ trợ ");

                    sql = "SELECT * FROM tbl_DanhMucHoTro Where Ten='" + this.gdVLVHoTro.GetValue("Ten").ToString() + "'";
                    ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow d2 = ds.Tables[0].Rows[0];

                        if (d2["ID"].ToString() != this.gdVLVHoTro.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên lĩnh vực hỗ trợ");
                    }

                    if (!SaveLinhVucHoTro(false)) { e.Cancel = true; }
                    else
                    {
                        MessageBox.Show("Bạn đã sửa lại thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } 
               
                }
                else
                {
                    LoadgdLVHoTro();
                    e.Cancel = true;
                }  
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }      
        }

        private void frmDanhMucHoTro_Load(object sender, EventArgs e)
        {

        }
    }
}