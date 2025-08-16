using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace MDSolution
{
    public partial class Frm_NoiUngVatTu : Form
    {
        DataSet gridDataSource = new DataSet();
        public Frm_NoiUngVatTu()
        {
            InitializeComponent();
            LoadVTVC();
        }
        private void LoadVTVC()
        {
            
            string strSQL = "SELECT * FROM tbl_NoiTamUngVatTu";
            this.gridDataSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdVDMTD.SetDataBinding(this.gridDataSource.Tables[0], "");
            }
        }
        private int GetID()
        {
            string sql = "Select Max(ID) from tbl_NoiTamUngVatTu";
            int ID=int.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql,null,null));
            return ID + 1;
        }

        private void gdVDMTD_AddingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                string sql = "Insert into tbl_NoiTamUngVatTu(ID,Ten,GhiChu) Values("+GetID().ToString()+",N'" + gdVDMTD.GetValue("Ten").ToString() + "',N'" + gdVDMTD.GetValue("GhiChu").ToString()+"')";
                MDSolutionEntities.DBModule.ExecuteNoneBackup(sql, null, null);
                LoadVTVC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm mới!\n" + ex.Message, "Thông báo lỗi");
            }
        }

        private void gdVDMTD_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn đồng ý xóa? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = "Delete from tbl_NoiTamUngVatTu Where ID=" + gdVDMTD.GetValue("ID").ToString();
                    MDSolutionEntities.DBModule.ExecuteNoneBackup(sql, null, null);
                    LoadVTVC();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Có lỗi khi xóa\n" + ex.Message, "Thông báo lỗi");
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void gdVDMTD_UpdatingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                string sql = "Update tbl_NoiTamUngVatTu "+
                    "Set Ten=N'" + gdVDMTD.GetValue("Ten").ToString()+"',"+
                    "GhiChu=N'" + gdVDMTD.GetValue("GhiChu").ToString() + "'" +
                    " Where ID=" + gdVDMTD.GetValue("ID").ToString();
                MDSolutionEntities.DBModule.ExecuteNoneBackup(sql, null, null);
                LoadVTVC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xóa\n" + ex.Message, "Thông báo lỗi");
                e.Cancel = true;
            }
        }

        private void Frm_NoiUngVatTu_Load(object sender, EventArgs e)
        {

        }
        
    }
}