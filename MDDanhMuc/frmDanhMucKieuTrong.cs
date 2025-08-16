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
    public partial class frmDanhMucKieuTrong : Form
    {
        private long[] themmoi=new long[1000];
        private long i = 0;
        private long a = 0;
        private bool delete = false;
        private DataSet gridDataSource;
        private clsKieuTrong oKT = new clsKieuTrong();
        public frmDanhMucKieuTrong()
        {
            InitializeComponent();
            this.LoadgdDMKT();
            
            
            
        }
        private void LoadgdDMKT()
        {
            string strSQL = "SELECT * FROM tbl_KieuTrong";
            this.gridDataSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdVDMKT.SetDataBinding(this.gridDataSource.Tables[0], "");
            }
        }
                        
        private void gdVDMKT_AddingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                string sql = "";
                DataSet ds;
                if (string.IsNullOrEmpty(this.gdVDMKT.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên kiểu trồng");

                sql = "SELECT count(*) as Dem FROM tbl_KieuTrong Where Ten='" + this.gdVDMKT.GetValue("Ten").ToString() + "'";
                ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                DataRow d13 = ds.Tables[0].Rows[0];

                if (long.Parse(d13["Dem"].ToString()) > 0) throw new Exception("Bạn nhập trùng tên kiểu trồng");

                if (!SaveKieuTrong(true)) { e.Cancel = true; }
                else
                {
                    MessageBox.Show("Bạn đã lưu lại thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.gdVDMKT.SetValue("ID", oKT.ID);
                    themmoi[i] = oKT.ID;

                    i = i + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void gdVDMKT_RecordAdded(object sender, EventArgs e)
        {
            this.gdVDMKT.Refetch();
            
        }

        private void gdVDMKT_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void gdVDMKT_RecordUpdated(object sender, EventArgs e)
        {
            this.gdVDMKT.Refetch();
        }
      
        private void gdVDMKT_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            string message;
            long a = 0;
           
           while (a < themmoi.Length)
           {
               if (themmoi[a] == oKT.ID)
               {
                   message = String.Format("Bạn muốn xóa bản ghi này?");

                   if (MessageBox.Show(message, " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                   {
                       oKT.Delete(null, null);
                       

                   }
                   else
                   {
                       e.Cancel = true;
                   }
                   delete = true;
                   break;
               }
               else {  delete = false; }

               a++;
           }
           if (!delete)
           {
               e.Cancel = true;
               MessageBox.Show("Bạn không được xóa danh mục này ", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
           }
          
        }      

        private void gdVDMKT_UpdatingRecord(object sender, CancelEventArgs e)
        {try
            {
                string sql = "";
                DataSet ds;
                if (string.IsNullOrEmpty(this.gdVDMKT.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên kiểu trồng");

                sql = "SELECT * FROM tbl_KieuTrong Where Ten='" + this.gdVDMKT.GetValue("Ten").ToString() + "'";
                ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow d13 = ds.Tables[0].Rows[0];

                    if (d13["ID"].ToString() != this.gdVDMKT.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên kiểu trồng");
                }
           
            if (!SaveKieuTrong(false)) {  e.Cancel = true; }
            else
            {
                MessageBox.Show("Bạn đã sửa lại thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);             

            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
        }
          
        }
        private bool SaveKieuTrong(bool isAddNew)
        {
            try
            {
                if (isAddNew)
                {
                    oKT = new clsKieuTrong();
                }
                else
                {
                    oKT.Load(null, null);
                }
                if (!string.IsNullOrEmpty(this.gdVDMKT.GetValue("Ten").ToString()))
                {
                    oKT.Ten = this.gdVDMKT.GetValue("Ten").ToString();
                    oKT.Save(null, null);
                    return true;
                }
                else {
                    MessageBox.Show("Bạn chưa nhập tên kiểu trồng", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                                    }
            }
            catch
            {
                return false;
            }
        }

        private void gdVDMKT_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.gdVDMKT.CurrentRow.RowType == Janus.Windows.GridEX.RowType.NewRecord)
                {
                    oKT = new clsKieuTrong();
                }
                else
                {
                    oKT.ID = long.Parse(this.gdVDMKT.GetValue("ID").ToString());
                }
            }
            catch
            {
                oKT = new clsKieuTrong();
            }
        }

       
    }
}