using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace MDSolution
{
    public partial class frm_DMVTHH: Form
    {
        DataSet gridDataSource = new DataSet();
        public frm_DMVTHH()
        {
            InitializeComponent();
            LoadVTHH();
        }
        private void LoadVTHH()
        {

            string strSQL = "SELECT * FROM tbl_HangHoa";
            this.gridDataSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdVDMTD.SetDataBinding(this.gridDataSource.Tables[0], "");
            }
        }
        private int GetID()
        {
            string sql = "Select Max(ID) from tbl_HangHoa";
            int ID=int.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql,null,null));
            return ID + 1;
        }

        private void gdVDMTD_AddingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                string sql = "Insert into  tbl_HangHoa(ID,LoaiHang) Values(" + GetID().ToString() + ",N'" + gdVDMTD.GetValue("LoaiHang").ToString() + "')";
                MDSolutionEntities.DBModule.ExecuteNoneBackup(sql, null, null);
                LoadVTHH();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm mới!\n" + ex.Message, "Thông báo lỗi");
            }
        }

        private void gdVDMTD_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            if (MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select LoaiVatTu from tbl_CanVatTu where LoaiVatTu=" + this.gdVDMTD.GetValue("ID").ToString(), null, null) != "")
            {
                MessageBox.Show("Bạn không được xóa loại Hàng hóa này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //return;
            }
            else
            {
                if (MessageBox.Show("Bạn đồng ý xóa? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string sql = "Delete from tbl_HangHoa Where ID=" + gdVDMTD.GetValue("ID").ToString();
                        MDSolutionEntities.DBModule.ExecuteNoneBackup(sql, null, null);
                        LoadVTHH();
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
            LoadVTHH();
        }

        private void gdVDMTD_UpdatingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                string sql = "Update tbl_HangHoa " +
                    "Set LoaiHang=N'" + gdVDMTD.GetValue("LoaiHang").ToString()+"'"+
                    " Where ID=" + gdVDMTD.GetValue("ID").ToString();
                MDSolutionEntities.DBModule.ExecuteNoneBackup(sql, null, null);
                LoadVTHH();
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

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}