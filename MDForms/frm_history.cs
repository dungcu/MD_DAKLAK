using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LD.MD2008.MDForms
{
    public partial class frm_history : Form
    {
        int status = 0;
        int GVhistoryLoaded = 0;
        public frm_history()
        {
            
            InitializeComponent();
        }
        String CurentTable = "";
        int CurentRow= 0;//row tren bang past
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void frm_history_Load(object sender, EventArgs e)
        {
            

        }

        private void GVHistory_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                GVPast.Columns.Clear();
                GVCurent.Columns.Clear();
                string sql = "select * from " + GVHistory.Rows[e.RowIndex].Cells[0].Value.ToString() + "_log where Date_Modify = '" + GVHistory.Rows[e.RowIndex].Cells["Date_Modify"].Value.ToString() + "'";
                DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                GVPast.DataSource = DBModule.ExecuteQuery(sql, null, null).Tables[0];
                GVPast.Show();
                lbPast.Text = "DỮ LIỆU THĂY ĐỔI\n" + GVHistory.Rows[e.RowIndex].Cells["TableName"].Value.ToString();

                CurentTable = GVHistory.Rows[e.RowIndex].Cells["TableName"].Value.ToString();

            }
            catch
            {
                GVPast.DataSource = null;
                GVPast.Show();
                lbPast.Text = "DỮ LIỆU THĂY ĐỔI\n";

            }
            
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"select sys_log.*, sys_log.TableName as [Tên bảng],sys_log.Date_Modify as [Ngày sửa],Sys_User.UserName as [Người sửa],[Tác động]=CASE sys_log.Action WHEN 0 THEN N'Thêm' WHEN 1 THEN N'Sửa'WHEN 2 THEN N'Xóa' END
                from sys_log join Sys_User on Sys_log.UserID=Sys_User.ID where Date_Modify >= '" + DTTuNgay.Value.ToString("MM/dd/yyyy") + " 00:00:00'" + "AND Date_Modify <= '" + dtDenNgay.Value.ToString("MM/dd/yyyy") + " 23:59:59'";
                DataSet ds1 = DBModule.ExecuteQuery(sql, null, null);
                GVHistory.Columns.Clear();
                GVHistory.AutoGenerateColumns = false;
                int i = 0;
                foreach (System.Data.DataColumn col in ds1.Tables[0].Columns)
                {

                    GVHistory.Columns.Add(col.ColumnName, col.ColumnName);
                    GVHistory.Columns[col.ColumnName].DataPropertyName = col.ColumnName;
                    if (i < 4)
                        GVHistory.Columns[col.ColumnName].Visible = false;
                    if (col.ColumnName == "Ngày sửa")
                        GVHistory.Columns[col.ColumnName].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss";
                    i++;
                    

                }
                

                GVHistory.DataSource = ds1.Tables[0];
                GVHistory.Show();
               
            }
            catch
            {
                GVHistory.DataSource = null;
                GVHistory.Show();
            }
        }

        private void GVPast_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (GVhistoryLoaded == 0) return;
            if (e.RowIndex == null || e.RowIndex < 0 || status == 1)
            {
                status = 0;
                return;
            }
            try
            {

                string sql = "select * from " + CurentTable + " where ID = " + GVPast.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                GVCurent.DataSource = ds.Tables[0];
                GVCurent.Show();
                lbcurent.Text = "DỮ LIỆU HIỆN TẠI\n" + CurentTable;
            }
            catch
            {
                GVCurent.DataSource = null;
                GVCurent.Show();
                lbcurent.Text = "DỮ LIỆU HIỆN TẠI\n";
            }
            CurentRow = e.RowIndex;
        }

        private void GVPast_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void GVCurent_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {//Danh dau su thay doi du lieu:
                foreach (DataGridViewTextBoxColumn col in GVCurent.Columns)
                {
                    if (GVCurent.Rows[0].Cells[col.DataPropertyName].Value.ToString() != GVPast.Rows[CurentRow].Cells[col.DataPropertyName].Value.ToString())
                    {
                        GVCurent.Rows[0].Cells[col.DataPropertyName].Style.BackColor = Color.Red;
                    }
                }
            }
            catch { }
        }

        private void GVCurent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                GVPast.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                status = 1;
            }
            catch { }
        }

        private void btShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"select sys_log.*, sys_log.TableName as [Tên bảng],sys_log.Date_Modify as [Ngày sửa],Sys_User.UserName as [Người sửa],[Tác động]=CASE sys_log.Action WHEN 0 THEN N'Thêm' WHEN 1 THEN N'Sửa'WHEN 2 THEN N'Xóa' END
                from sys_log join Sys_User on Sys_log.UserID=Sys_User.ID";
                DataSet ds1 = DBModule.ExecuteQuery(sql, null, null);
                GVHistory.Columns.Clear();
                GVHistory.AutoGenerateColumns = false;
                int i = 0;
                foreach (System.Data.DataColumn col in ds1.Tables[0].Columns)
                {

                    GVHistory.Columns.Add(col.ColumnName, col.ColumnName);
                    GVHistory.Columns[col.ColumnName].DataPropertyName = col.ColumnName;
                    if (i < 4)
                        GVHistory.Columns[col.ColumnName].Visible = false;
                    if (col.ColumnName == "Ngày sửa")
                        GVHistory.Columns[col.ColumnName].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss";
                    i++;


                }


                GVHistory.DataSource = ds1.Tables[0];
                GVHistory.Show();

            }
            catch
            {
                GVHistory.DataSource = null;
                GVHistory.Show();
            }
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            try
            {
                string sql1 = "Delete from " + CurentTable + "_log where ID=" + GVPast.Rows[CurentRow].Cells["ID"].Value.ToString() + " AND Date_Modify='" + GVPast.Rows[CurentRow].Cells["Date_Modify"].Value.ToString() + "'";
                string sql2 = "Delete from sys_log where TableName=N'"+CurentTable+"' AND Date_Modify='" + GVPast.Rows[CurentRow].Cells["Date_Modify"].Value.ToString() + "'";
                if (MessageBox.Show("Ban xoa dữ liệu trong bảng tạm?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DBModule.ExecuteNoneBackup(sql1, null, null);
                    DBModule.ExecuteNoneBackup(sql2, null, null);
                    GVPast.Rows.Remove(GVPast.Rows[CurentRow]);
                    GVHistory.Rows.Remove(GVHistory.SelectedRows[0]);
                }

            }
            catch 
            {
                MessageBox.Show("Có lỗi trong khi xóa!");
            }

        }

        private void GVHistory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            GVhistoryLoaded = 1;

        }

        private void btDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                string sql1 = "Delete from " + CurentTable + "_log";// where ID=" + GVPast.Rows[CurentRow].Cells["ID"].Value.ToString() + " AND Date_Modify='" + GVPast.Rows[CurentRow].Cells["Date_Modify"].Value.ToString() + "'";
                string sql2 = "Delete from sys_log where TableName=N'" + CurentTable + "'";// AND Date_Modify='" + GVPast.Rows[CurentRow].Cells["Date_Modify"].Value.ToString() + "'";
                if (MessageBox.Show("Ban xoa tất cả dữ liệu trong bảng tạm?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DBModule.ExecuteNoneBackup(sql1, null, null);
                    DBModule.ExecuteNoneBackup(sql2, null, null);
                    GVPast.Rows.Clear();
                    foreach (DataGridViewRow dr in GVHistory.Rows)
                    {
                        if(dr.Cells["TableName"].Value.ToString()==CurentTable)
                            GVHistory.Rows.Remove(dr);
                    }
                    
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi trong khi xóa!");
            }


        }

        private void phụcHồiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int k = GVPast.SelectedRows.Count;
                DataGridViewCell dc = GVPast.SelectedCells[0];
                DataGridViewRow dr = GVPast.Rows[dc.RowIndex];
                DataGridViewColumn col = GVPast.Columns[dc.ColumnIndex];
                
                string ID = dr.Cells["ID"].Value.ToString().Trim();
                string FieldName = col.Name.ToString();
                string Value = dc.Value.ToString();
                string sql = "";
                string list_column_name="";
                string list_value="";
                int i = 0;
                switch (dr.Cells["Action"].Value.ToString())
                {
                    case "0"://Them
                        sql = "Delete from "+CurentTable+" Where ID="+ID;
                        break;
                    case "1"://sua
                        sql = "Update "+CurentTable+" Set "+FieldName+" = "+Value+" Where ID="+ID;
                        break;
                    case "2"://Xoa
                        foreach (DataGridViewColumn c in GVPast.Columns)
                        {
                            if (c.Name != "" && c.Name != "UserID" && c.Name != "Date_Modify" && c.Name != "Action")
                            {
                                if (i == 0)
                                {
                                    list_column_name = c.Name;
                                    list_value = DBModule.CreateSqlValue(dr.Cells[c.Name].Value.ToString(), c.ValueType);
                                }
                                else
                                {
                                    list_column_name += "," + c.Name;
                                    list_value += "," + DBModule.CreateSqlValue(dr.Cells[c.Name].Value.ToString(), c.ValueType);
                                }
                                i++;
                            }
                        }
                        sql = "Insert into "+CurentTable+"("+list_column_name+") Values("+list_value+")";
                        break;
                }
                DBModule.ExecuteNoneBackup(sql, null, null);
                
            }
            catch { }
        }
    }
}