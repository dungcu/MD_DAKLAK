using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using Janus.Windows.GridEX;

namespace DACASUCO.MDDataSetForms
{
    public partial class frmDonViCungUngVT : Form
    {
        public frmDonViCungUngVT()
        {
            InitializeComponent();
        }

        private void frmDonViCungUngVT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dVCungUngDataSet.tbl_DonViCungUngVatTu' table. You can move, or remove it, as needed.
            this.tbl_DonViCungUngVatTuTableAdapter.Fill(this.dVCungUngDataSet.tbl_DonViCungUngVatTu);

        }

        private void gridEX1_UpdatingRecord(object sender, CancelEventArgs e)
        {
            //this.Validate();
            if (SaveDonViUVT(false))
            {
                try
                {

                    this.tblDonViCungUngVatTuBindingSource.EndEdit();
                    this.tbl_DonViCungUngVatTuTableAdapter.Update(this.dVCungUngDataSet.tbl_DonViCungUngVatTu);
                    //MessageBox.Show("Đã sửa lại thành công",MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi khi lưu lại", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
            else { e.Cancel = true; }
        }
        private bool SaveDonViUVT(bool isAddNew)
        {
            try
            {
                if (string.IsNullOrEmpty(this.gridEX1.GetValue("MaNhaCC").ToString())) throw new Exception("Bạn chưa nhập mã nhà cung cấp");
                if (IsExistingMaNhaCC(isAddNew, this.gridEX1.GetValue("MaNhaCC").ToString())) throw new Exception("Mã nhà cung cấp đã có trong đơn vị");
                if (string.IsNullOrEmpty(this.gridEX1.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên nhà cung cấp");
                if (string.IsNullOrEmpty(this.gridEX1.GetValue("DienThoai").ToString())) throw new Exception("Bạn chưa nhập số điện thoại nhà cung cấp");
                if (string.IsNullOrEmpty(this.gridEX1.GetValue("DiaChi").ToString())) throw new Exception("Bạn chưa nhập địa chỉ nhà cung cấp");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void gridEX1_AddingRecord(object sender, CancelEventArgs e)
        {
            if (SaveDonViUVT(true))
            {                
            }
            else
            { e.Cancel = true; 
            }
        }

        private void gridEX1_DeletingRecords(object sender, CancelEventArgs e)
        {
            string message = String.Format("Bạn muốn xóa bản ghi này?", "Thông báo");
            long dvID = long.Parse(this.gridEX1.GetValue("ID").ToString());
            if (dvID == 1)
            {
                MessageBox.Show("Đây là đơn vị cung ứng trực tiếp,bạn không được xóa đợn vị cung ứng này", "Thông báo");
                e.Cancel = true;
            }
            else
            {
                if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int pos = tblDonViCungUngVatTuBindingSource.Position;
                    dVCungUngDataSet.Tables[0].Rows[pos].Delete();
                    tbl_DonViCungUngVatTuTableAdapter.Update(this.dVCungUngDataSet.tbl_DonViCungUngVatTu);
                    clsDanhMucDT_DonViCU.Delete_DonVi(dvID, null, null);
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void gridEX1_RecordAdded(object sender, EventArgs e)
        {
            try
                {
                    this.Validate();
                    this.tblDonViCungUngVatTuBindingSource.EndEdit();
                    this.tbl_DonViCungUngVatTuTableAdapter.Update(this.dVCungUngDataSet.tbl_DonViCungUngVatTu);
                    MessageBox.Show("Đã tạo mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi khi lưu lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
            
        }
        private bool IsExistingMaNhaCC(bool isAddnew, string strMaNhaCC)
        {
            if (isAddnew)
            {
                string SQL = " select Count(*) from tbl_DonViCungUngVatTu where MaNhaCC = '" + strMaNhaCC + "'";
                string ret = DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else
            {
                string SQL = " select * from tbl_DonViCungUngVatTu where MaNhaCC = '" + strMaNhaCC + "'";
                DataSet ds;
                ds = DBModule.ExecuteQuery(SQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow d13 = ds.Tables[0].Rows[0];

                    if (d13["ID"].ToString() != this.gridEX1.GetValue("ID").ToString())
                    { return true; }
                    else { return false; }
                }
                else { return false; }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {

                    case Keys.F2:
                        //code cho F2                        
                        gridEX1.MoveNext();
                        break;

                    case Keys.F8:
                        //Code cho F8
                        gridEX1.EditMode = EditMode.EditOn;
                        gridEX1.MoveToNewRecord();
                        gridEX1.Focus();
                       // uiPanel2.Text = "F2-Lưu / Esc-Bỏ qua";
                        break;

                    case Keys.Escape:
                        // Code cho phim Esc
                        gridEX1.CancelCurrentEdit();
                       // uiPanel2.Text = "F8-Thêm mới / F9-Sửa / F4-Chi tiết / Delete-Xóa / F6-In danh sách";
                        break;

                    #region
                    //case Keys.F4:
                    //    //Code cho F4
                    //    try
                    //    {
                    //        if (!string.IsNullOrEmpty(this.grdHopDong.GetValue("ID").ToString()))
                    //        {
                    //            long oID = long.Parse(this.grdHopDong.GetValue("ID").ToString());

                    //            frmViewHopDong aa = new frmViewHopDong(oID);
                    //            aa.MdiParent = this.MdiParent;
                    //            aa.Show();
                    //        }
                    //    }
                    //    catch
                    //    {
                    //        MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết", "Lỗi");
                    //    }
                    //    break;

                    //case Keys.F5:
                    //    // Code cho phim F5
                    //    edtTimKiem.Focus();
                    //    this.AcceptButton = uiButton1;
                    //    break;

                    //case Keys.F6:
                    //    //code cho F6
                    //    btinchitiet_Click(null, null);
                    //    break;                  

                    //case Keys.F9:
                    //    // Code cho phim F9
                    //    grdDauTu.EditMode = EditMode.EditOn;
                    //    grdDauTu.MoveFirst();
                    //    grdDauTu.Focus();
                    //    uiPanel2.Text = "F2-Lưu / Esc-Bỏ qua";
                    //    break;                   

                    //case Keys.F12:
                    //    // Code cho phim F12
                    //    uiPanel0.Activate();
                    //    break;
               #endregion
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void gridEX1_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }

        private void buttThietLapDanhMucDT_Click(object sender, EventArgs e)
        {
            try
            {
                long id = 0;
                id = long.Parse(gridEX1.CurrentRow.Cells["ID"].Value.ToString());
                frmChonDanhMucVatTuChoDonVi frm = new frmChonDanhMucVatTuChoDonVi(id.ToString());
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Bạn chưa chọn đơn vị cung ứng!", MDSolutionApp.MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}