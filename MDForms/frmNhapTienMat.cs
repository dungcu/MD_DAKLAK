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
    public partial class frmNhapTienMat : Form
    {
        private NodeDonVi nDonVi = new NodeDonVi();
        private string mHopDongID = "-1";        
        private DataSet gridDataSource;
        private DataSet gridDataSourceDienTich;
        private DataSet gridThonSource;
        public frmNhapTienMat()
        {
            InitializeComponent();
            this.CreateGridEX2ThuaRuongColumn();
            CommonClass.loadTreeDonVi(treeDonVi);
        }       
        private DataSet LoadHopDong()
        {
            string strSQL = "SELECT * FROM tbl_HopDong WHERE 1=1";
            switch (nDonVi.Type)
            {
                case DonviTypeHD.Xa: strSQL += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviTypeHD.Thon: strSQL += " AND ThonID=" + nDonVi.DonViID; break;
                default: break;
            }
            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                strSQL += " AND (MaHopDong like N'%" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "%' OR HoTen like N'%" + MDSolutionEntities.DBModule.RefineString(edtTimKiem.Text) + "%' )";
            }
            return MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);            
        }
        private void LoadThonSource()
        {
            string strSQL = "SELECT * FROM tbl_Thon";
            switch (nDonVi.Type)
            {
                case DonviTypeHD.Xa: strSQL += " WHERE ID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviTypeHD.Thon: strSQL += " WHERE ID=" + nDonVi.DonViID; break;
                default: break;
            }
            this.gridThonSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridThonSource.Tables.Count > 0)
            {
                this.GridEX1.DropDowns["Thon"].SetDataBinding(this.gridThonSource.Tables[0], "");
            }
        }
        private void LoadDienTich()
        {
            string strSQL = "SELECT * FROM tbl_ThuaRuong Where HopDongID=" + mHopDongID;
            this.gridDataSourceDienTich = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridDataSourceDienTich.Tables.Count > 0)
            {
                this.gridEX2.SetDataBinding(this.gridDataSourceDienTich.Tables[0], "");
            }
        }
        private void CreateGridEX2ThuaRuongColumn()
        {
            gridEX2.AllowAddNew = InheritableBoolean.True;
            gridEX2.AllowDelete = InheritableBoolean.True;
            gridEX2.EmptyRows = true;
            gridEX2.ColumnAutoResize = true;

            //Create a new GridEXTable
            GridEXTable table = new GridEXTable();
            //add columns to the table

            //adding an unbound icon column
            //GridEXColumn iconColumn = table.Columns.Add("Icon", ColumnType.Image, EditType.NoEdit);
            ////set other properties
            //iconColumn.Width = 22;
            //iconColumn.Caption = "";
            //iconColumn.AllowSort = false;
            //iconColumn.AllowGroup = false;
            //iconColumn.AllowSize = false;
            //iconColumn.Selectable = false;
            //iconColumn.BoundMode = ColumnBoundMode.UnboundFetch;
            //iconColumn.ImageKey = "TaskIcon"; //TaskIcon image is defined in ImageList1

            //adding a checkbox column that will be bound to "Complete" DataColumn in the datasource
            GridEXColumn htgtColumn = table.Columns.Add("HienTrangGiaoThong", ColumnType.Text, EditType.TextBox);
            htgtColumn.Width = 150;
            htgtColumn.AllowSize = false;
            htgtColumn.Caption = "HT Giao Thông";

            //adding a text column that will be bound to "Subject" DataColumn in the datasource
            GridEXColumn dientichColumn = table.Columns.Add("DienTich", ColumnType.Text, EditType.TextBox);
            dientichColumn.Width = 50;
            dientichColumn.AllowSize = false;
            dientichColumn.Caption = "Diện tích";

            //once all columns have been added to the GridEXTable, set the table as the RootTable of the grid
            gridEX2.RootTable = table;


        }
        private void CreateDataSourceAndBindGrid()
        {
            gridDataSource = this.LoadHopDong();
            if (gridDataSource.Tables.Count > 0)
            {
                this.GridEX1.SetDataBinding(gridDataSource.Tables[0], "");
            }

        }

        private void treeDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                this.DoLoadGridHopDong();
            }
        }
        private void DoLoadGridHopDong()
        {
            this.LoadThonSource();
            this.CreateDataSourceAndBindGrid();
            this.GridEX1.Focus();
        }

        private void treeDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nDonVi = (NodeDonVi)e.Node.Tag;
            this.DoLoadGridHopDong();
        }

        private void GridEX1_RecordAdded(object sender, EventArgs e)
        {

            //MessageBox.Show("Đã thêm mới thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void GridEX1_AddingRecord(object sender, CancelEventArgs e)
        {
            try
            {

                GridEXRow item = this.GridEX1.CurrentRow;
                DataRowView dr;
                if ((item != null) && (item.DataRow != null))
                {
                    dr = (DataRowView)item.DataRow;
                    clsHopDong oHD = new clsHopDong();
                    oHD.HoTen = dr.Row.ItemArray[14].ToString();
                    oHD.ThonID = long.Parse(dr.Row.ItemArray[6].ToString());
                    oHD.Save(null, null);
                    //Viết code để add vào csdl   
                }
            }
            catch (Exception ex)
            {
                string message;
                message = String.Format("Có lỗi khi thêm mới bản ghi \n\r{0}", ex.Message);
                MessageBox.Show(message, " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }

        }

        private void GridEX1_RecordUpdated(object sender, EventArgs e)
        {
            MessageBox.Show("Select an item to update.");
        }


        private void GridEX1_SelectionChanged(object sender, EventArgs e)
        {
            GridEXRow currentRow = null;
            currentRow = this.GridEX1.GetRow();
            DataRowView dr;
            if ((currentRow != null) && (currentRow.DataRow != null))
            {
                dr = (DataRowView)currentRow.DataRow;
                mHopDongID = dr.Row.ItemArray[0].ToString();
                gridEX2.AllowAddNew = InheritableBoolean.True;
            }
            else
            {
                mHopDongID = "-1";
                gridEX2.AllowAddNew = InheritableBoolean.False;
            }
            this.LoadDienTich();
        }

        private void GridEX1_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {
            string message;

            message = String.Format("Bạn muốn xóa bản ghi này?");

            if (MessageBox.Show(message, " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView dr = (DataRowView)e.Row.DataRow;
                clsHopDong oHD = new clsHopDong(long.Parse(dr.Row.ItemArray[0].ToString()));
                oHD.Delete(null, null);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void GridEX1_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.DoLoadGridHopDong();

        }
    }
}