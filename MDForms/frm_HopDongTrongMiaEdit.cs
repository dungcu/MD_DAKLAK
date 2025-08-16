using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using MDSolution;

namespace MDSolution
{
    public partial class frm_HopDongTrongMiaEdit : Form
    {
        public bool Themmoi_Click = false;
        public long _PerentID = 0;
        public long _ID = 0;
        public long _ThonID = 0;
        public bool isChuHo = false;
        private NodeDonVi nDonVi;
        bool Addnew = false;
        bool onAddnew = false;
       //public bool kt = false;
        public frm_HopDongTrongMiaEdit()
        {
            InitializeComponent();
           // LoadDDLXa();
        }

        private void tbl_HopDongBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbl_HopDongBindingSource.EndEdit();
            this.tbl_HopDongTableAdapter.Update(this.hopDongTrongMiaDataSet.tbl_HopDong);

        }

        private void frm_HopDongTrongMiaEdit_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hopDongTrongMiaDataSet.tbl_HopDong' table. You can move, or remove it, as needed.
            this.tbl_HopDongTableAdapter.Fill(this.hopDongTrongMiaDataSet.tbl_HopDong);

        }

        private void tbl_HopDongBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.tbl_HopDongBindingSource.EndEdit();
            this.tbl_HopDongTableAdapter.Update(this.hopDongTrongMiaDataSet.tbl_HopDong);

        }

        private void frm_HopDongTrongMiaEdit_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_Xa' table. You can move, or remove it, as needed.
            this.tbl_XaTableAdapter1.Fill(this.dienTichDataSet.tbl_Xa);
            // TODO: This line of code loads data into the 'hopDongTrongMiaDataSet.LoaiHopDong' table. You can move, or remove it, as needed.
            this.loaiHopDongTableAdapter.Fill(this.hopDongTrongMiaDataSet.LoaiHopDong);

            // TODO: This line of code loads data into the 'hopDongTrongMiaDataSet.tbl_Thon' table. You can move, or remove it, as needed.
            this.tbl_ThonTableAdapter1.Fill(this.hopDongTrongMiaDataSet.tbl_Thon);
            // TODO: This line of code loads data into the 'hopDongTrongMiaDataSet.tbl_NganHang' table. You can move, or remove it, as needed.
            this.tbl_NganHangTableAdapter.Fill(this.hopDongTrongMiaDataSet.tbl_NganHang);
            // TODO: This line of code loads data into the 'mDSolutionDataSet.tbl_Thon' table. You can move, or remove it, as needed.
            //this.tbl_ThonTableAdapter.Fill(this.mDSolutionDataSet.tbl_Thon);
            // TODO: This line of code loads data into the 'hopDongTrongMiaDataSet.tbl_HopDong' table. You can move, or remove it, as needed.
            this.tbl_HopDongTableAdapter.FillByID(this.hopDongTrongMiaDataSet.tbl_HopDong, int.Parse(_ID.ToString()));
            // TODO: This line of code loads data into the 'hopDongTrongMiaDataSet.tbl_HopDong' table. You can move, or remove it, as needed.
            //this.tbl_HopDongTableAdapter.Fill(this.hopDongTrongMiaDataSet.tbl_HopDong);
                       
            if (Themmoi_Click == true)
            {
                //tbl_HopDongBindingSource.Filter = "0=1";
                btThem_Click(null, null);
                btDau.Enabled = false;
                btTruoc.Enabled = false;
                trangThaiCheckBox.Checked = true;
            }
            //Set cation theo chu ho hoac hopdong
            if (isChuHo)
            {
                lbTitle.Text = "CHI TIẾT CHỦ HỘ TRỒNG MÍA";
                uiGroupBoxChuHDDaiDien.Visible = true;
                uiGroupBoxThongTin.Text = "Thông tin về chủ hộ";

            }
            else
            {
                //lbTitle.Text = "CHI TIẾT CHỦ HỢP ĐỒNG TRỒNG MÍA";
                lbTitle.Text = "CHI TIẾT CHỦ MÍA";
                uiGroupBoxChuHDDaiDien.Visible = false;
                uiGroupBoxThongTin.Text = "Thông tin về chủ mía";
            }

        }

        private void tbl_HopDongBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.tbl_HopDongBindingSource.EndEdit();
            this.tbl_HopDongTableAdapter.Update(this.hopDongTrongMiaDataSet.tbl_HopDong);

        }
        /*
        private void uiRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (uiRadioButton2.Checked == true)
            {
                //uiRadioButton1.Checked = false;
                uiButtonThietLapDHChinh.Visible = true;
                uiButtonThietLapDHChinh.Focus();
                if (_PerentID != 0)
                    parentIDTextBox.Text = _PerentID.ToString();
            }
            else
            {
                //uiRadioButton1.Checked = true;
                uiButtonThietLapDHChinh.Visible = false;
                //parentIDTextBox.Text = _PerentID.ToString();
            }
        }
        */
        private void uiButtonThietLapDHChinh_Click(object sender, EventArgs e)
        {
            //Frm_ChonHDChinh frm = new Frm_ChonHDChinh();
            //frm.ShowDialog();
            //parentIDTextBox.Text = frm.HDChinhID.ToString();
        }

        private void uiButtonThietLapDHChinh_Leave(object sender, EventArgs e)
        {
            //if ((parentIDTextBox.Text == "0" || parentIDTextBox.Text == "") && (uiRadioButton2.Checked == true))
            //{
            //    MessageBox.Show("Bạn chưa thiết lập hợp đồng chính cho chủ hộ này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    uiButtonThietLapDHChinh.Focus();
            //}
        }

        private void bindingNavigatorMoveFirstItem_EnabledChanged(object sender, EventArgs e)
        {
            btDau.Enabled = bindingNavigatorMoveFirstItem.Enabled;
        }

        private void bindingNavigatorMovePreviousItem_EnabledChanged(object sender, EventArgs e)
        {
            btTruoc.Enabled = bindingNavigatorMovePreviousItem.Enabled;
        }

        private void bindingNavigatorMoveNextItem_EnabledChanged(object sender, EventArgs e)
        {
            btSau.Enabled = bindingNavigatorMoveNextItem.Enabled;
        }

        private void bindingNavigatorMoveLastItem_EnabledChanged(object sender, EventArgs e)
        {
            btCuoi.Enabled = bindingNavigatorMoveLastItem.Enabled;
        }

        private void bindingNavigatorAddNewItem_EnabledChanged(object sender, EventArgs e)
        {
            btThem.Enabled = bindingNavigatorAddNewItem.Enabled;
        }

        private void bindingNavigatorDeleteItem_EnabledChanged(object sender, EventArgs e)
        {
            btXoa.Enabled = bindingNavigatorDeleteItem.Enabled;
        }

        private void tbl_HopDongBindingNavigatorSaveItem_EnabledChanged(object sender, EventArgs e)
        {
            btGhiNhan.Enabled = tbl_HopDongBindingNavigatorSaveItem.Enabled;
        }

        private void btDau_Click(object sender, EventArgs e)
        {
            tbl_HopDongBindingSource.MoveFirst();

        }

        private void btTruoc_Click(object sender, EventArgs e)
        {
            tbl_HopDongBindingSource.MovePrevious();
        }

        private void btSau_Click(object sender, EventArgs e)
        {
            tbl_HopDongBindingSource.MoveNext();
        }

        private void btCuoi_Click(object sender, EventArgs e)
        {
            tbl_HopDongBindingSource.MoveLast();
        }

        public void btThem_Click(object sender, EventArgs e)
        {
            //tbl_HopDongBindingSource.Filter = "1=0";
            tbl_HopDongBindingSource.AddNew();
            maHopDongEditBox.Focus();
            parentIDTextBox.Text = "0";
            Addnew = true;
            onAddnew = true;

            trangThaiCheckBox.CheckState = CheckState.Checked;
            trangThaiCheckBox.Checked = true;

            //string sql = "select max(ID) as IDMax from tbl_hopdong";
            //string strMaxID = DBModule.ExecuteQueryForOneResult(sql, null, null);
            //long lMaxID = long.Parse(strMaxID);
            //lMaxID++;
            //iDEditBox.Text = lMaxID.ToString();
            //uiRadioButton1.Checked = true;
            thonIDUIComboBox.SelectedIndex = 0;
            if (_ThonID != 0)
            {
                try
                {
                    thonIDUIComboBox.SelectedValue = _ThonID;
                }
                catch
                {
                    thonIDUIComboBox.SelectedIndex = 0;
                }
            }
            btThem.Enabled = false;
            btXoa.Enabled = false;
            if (isChuHo)
            {
                parentIDTextBox.Text = _PerentID.ToString();
            }
            else
            {
                parentIDTextBox.Text = "0";
            }
            trangThaiCheckBox.Checked = true;

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tbl_HopDongBindingSource.RemoveCurrent();
                //string sql = "Delete from tbl_HopDong where ID=" + iDEditBox.Text;
                //DBModule.ExecuteNonQuery(sql, null, null);
                //frm_HopDongTrongMiaEdit_Load_1(null, null);
            }
        }

        private void tbl_HopDongBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("");
        }

        private void btGhiNhan_Click(object sender, EventArgs e)
        {
            try//Truyen cac thong so phu:
            {
                if (string.IsNullOrEmpty(createdByTextBox.Text))//Them moi
                {
                    createdByTextBox.Text = DACASUCO_App.User.ID.ToString();
                    dateAddDateTimePicker.Value = DateTime.Now;
                    trangThaiCheckBox.CheckState = CheckState.Checked;
                    trangThaiCheckBox.Checked = true;
                }
                else
                {
                    modifyByTextBox.Text = DACASUCO_App.User.ID.ToString();
                    dataModifyDateTimePicker.Value = DateTime.Now;
                    trangThaiCheckBox.CheckState = CheckState.Checked;
                    trangThaiCheckBox.Checked = true;
                }
            }
            catch { }
            this.Validate();
            if (!validate_form())
                return;
            try
            {
                
                this.tbl_HopDongBindingSource.EndEdit();
                
                this.tbl_HopDongTableAdapter.Update(this.hopDongTrongMiaDataSet.tbl_HopDong);
                
                btThem.Enabled = true;
                btSua.Enabled = true;
                btXoa.Enabled = true;
                onAddnew = false;
                if (Addnew)
                {
                    Addnew = false;
                    string sql = "insert into tbl_HopDongVuTrong values(" + iDEditBox.Text + "," + DACASUCO_App.VuTrongID.ToString() + ")";
                    DBModule.ExecuteNoneBackup(sql, null, null);
                    //if (MessageBox.Show("Ghi nhận thành công!\nBạn có muốn tiếp tục thêm mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                    //    btThem_Click(null, null);
                    //}
                    //else
                    //{
                    //    Close();// _Click(null, null);
                    //}
                    MessageBox.Show("Bạn đã thêm mới thành công", "Thông báo", MessageBoxButtons.OK);
                    btThem_Click(null, null);
                }
                else
                {
                    //string sql = "insert into tbl_HopDongVuTrong values(" + iDEditBox.Text + "," + MDSolutionApp.VuTrongID.ToString() + ")";
                    //DBModule.ExecuteNoneBackup(sql, null, null);
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật.\n"+ex.ToString(), "Lỗi", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
     bool checkMHD()
        {
            if (maHopDongEditBox.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã Chủ Hợp Đồng", "Thông báo");
                maHopDongEditBox.Focus();
                return false;
            }
            //Tam thoi remove theo yeu cau daknong
            //if (maHopDongEditBox.Text.Trim().Length > 6)
            //{
            //    MessageBox.Show("Mã hợp đồng không được quá 6 ký tự", "Thông báo");
            //    maHopDongEditBox.Focus();
            //    return false;

            //}
            //if (maHopDongEditBox.Text.Trim().Length < 6)
            //{
            //    MessageBox.Show("Mã hợp đồng không được nhỏ hơn 6 ký tự", "Thông báo");
            //    maHopDongEditBox.Focus();
            //    return false;

            //}
            if (IsExistingMHD(Addnew, maHopDongEditBox.Text.ToString()))
            {
                MessageBox.Show("Mã Chủ Hợp Đồng đã tồn tại\nBạn phải chọn mã khác", "Thông báo");
                maHopDongEditBox.Focus();
                return false;
            }
            return true;
        }
        bool validate_form()
        {
           
           
            if (hoTenEditBox.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập họ tên", "Thông báo");
                hoTenEditBox.Focus();
                return false;
            }
            //if (soCMTEditBox.Text.Trim() == "")
            //{
            //    MessageBox.Show("Bạn chưa nhập số CMT", "Thông báo");
            //    soCMTEditBox.Focus();
            //    return false;
            //}
            if (Addnew && IsExistingCMT(soCMTEditBox.Text.ToString()))
            {
                MessageBox.Show("Số CMT đã được đăng ký bởi HĐ(chủ hộ) khác\nVui lòng kiểm tra lại", "Thông báo");
                soCMTEditBox.Focus();
                return false;
            }
            if (thonIDUIComboBox.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn thôn", "Thông báo");
                thonIDUIComboBox.Focus();
                return false;
            }
            if (isChuHo && (parentIDTextBox.Text.Trim() == "0") || parentIDTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn HĐ chính cho chủ hộ", "Thông báo");
                uiButtonThietLapDHChinh.Focus();
                return false;
            }
            return true;
        }
        private bool IsExistingMHD(bool isAddnew, string ContractCode)
        {
            if (isAddnew)
            {
                string SQL = " select Count(*) from tbl_HopDong where MaHopDong = '" + ContractCode + "'";
                string ret = DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else
            {
                string SQL = " select * from tbl_HopDong where MaHopDong = '" + ContractCode + "'";
                DataSet ds;
                ds = DBModule.ExecuteQuery(SQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow d13 = ds.Tables[0].Rows[0];

                    if (d13["ID"].ToString() != this.iDEditBox.Text.ToString())
                    { return true; }
                    else { return false; }
                }
                else { return false; }
            }
        }
        private bool IsExistingCMT(string CMT)
        {
            if (!string.IsNullOrEmpty(CMT))
            {
                string SQL = " select Count(*) from tbl_HopDong where SoCMT = '" + CMT + "'";
                string ret = DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else { return false; }
        }
        private void btHuyBo_Click(object sender, EventArgs e)
        {
            //frm_HopDongTrongMiaEdit_Load_1(null, null);
            tbl_HopDongBindingSource.CancelEdit();
            if (Addnew)
            {
                Addnew = false;
                tbl_HopDongBindingSource.Filter = "0=2";
            }
            btThem.Enabled = true;
            btSua.Enabled = true;
        }

        private void parentIDTextBox_TextChanged(object sender, EventArgs e)
        {
            //if(!Themmoi_Click)
            if (parentIDTextBox.Text.Trim() != "0")
            {

                //uiRadioButton2.Checked = true;
                //uiRadioButton1.Checked = false;
                lbHDParent.Text = "";
                try
                {
                    string sql = "select MaHopDong,HoTen from tbl_hopdong where id=" + parentIDTextBox.Text.Trim();
                    DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                    lbHDParent.Text = "   Tên Chủ HĐ chính:" + ds.Tables[0].Rows[0]["HoTen"].ToString();
                    editBoxMaHDChinh.Text = ds.Tables[0].Rows[0]["MaHopDong"].ToString();
                }
                catch
                {
                    //lbHDParent = "";
                }
            }
            else
            {
                lbHDParent.Text = "(Chưa chọn HĐ đại diện)";
                editBoxMaHDChinh.Text = "";
                //uiRadioButton2.Checked = false;
                //uiRadioButton1.Checked = true;
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            btSua.Enabled = false;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /*
        private void uiRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (uiRadioButton1.Checked == true)
                parentIDTextBox.Text = "0";
        }
        */
        private void thonIDUIComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadDDLXa();
            Load_Form();
            //Dien dia chi theo thon xa...:

//            try
//            {
//                //if (onAddnew)
//                {
//                    string sql = @"SELECT     b.Ten + N' - ' + c.Ten AS DiaChi
//                                FROM        
//                                dbo.tbl_Thon as b INNER JOIN
//                                dbo.tbl_Xa as c ON b.XaID = c.ID
//                               where b.ID=" + thonIDUIComboBox.SelectedValue.ToString();
//                    string DiaChi = DBModule.ExecuteQueryForOneResult(sql, null, null);
//                    diachiTextBox.Text = DiaChi;
//                }
//            }
//            catch { }
            //try
            //{
            //    if (onAddnew)
            //    {
            //        maHopDongEditBox.Text = GetMaHopDong();
            //    }
            //}
            //catch { }
        }
        //private string GetMaHopDong()
        //{
        //    try
        //    {
        //        string strXaID = "";
        //        nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;

        //        clsThon oThon = new clsThon(long.Parse(thonIDUIComboBox.SelectedValue.ToString()));
        //        oThon.Load(null, null);
        //        strXaID = oThon.XaID.ToString();

        //        string strSQL = "SELECT [MaXa] FROM tbl_Xa Where [ID]=" + strXaID;
        //        string maXa = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
        //        string strMaxID = "";
        //        int batdau = maXa.Trim().Length + 1;
        //        try
        //        {
        //            strSQL = "SELECT max(cast(ltrim(rtrim(substring(mahopdong," + batdau.ToString() + ", 10))) as numeric(10))) FROM tbl_HopDong WHERE ThonID in (SELECT [id] FROM tbl_Thon WHERE XaID =" + strXaID + ") ";
        //            strMaxID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
        //        }
        //        catch { }
        //        if (strMaxID == "") strMaxID = "0";
        //        int intMaxID = int.Parse(strMaxID);
        //        intMaxID++;
        //        while (IsExistingMHD(true, maXa + intMaxID.ToString()))
        //        {
        //            intMaxID++;
        //        }
        //        return maXa + intMaxID.ToString();
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(parentIDTextBox.Text);
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            //kt = true;
            this.Close();
        }

        private void iDEditBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void editBoxMaHDChinh_Leave(object sender, EventArgs e)
        {

            try
            {
                string sql = "select ID,MaHopDong,HoTen from tbl_hopdong where parentid=0 and MaHopDong like N'" + editBoxMaHDChinh.Text.Trim()+"'";
                DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                lbHDParent.Text = "   Tên Chủ HĐ chính:" + ds.Tables[0].Rows[0]["HoTen"].ToString();
                parentIDTextBox.Text = ds.Tables[0].Rows[0]["ID"].ToString();
            }
            catch
            {
                lbHDParent.Text = " (Mã hợp đồng không tồn tại)";
                parentIDTextBox.Text = "0";

            }
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

        private void frm_HopDongTrongMiaEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            tbl_HopDongBindingSource.CancelEdit();
            try
            {
                _ID = long.Parse(iDEditBox.Text.Trim());
            }
            catch { }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Enter:
                        try
                        {
                            SendKeys.Send("{TAB}");
                            //   btGhiNhan_Click(null, null);
                        }
                        catch { }
                        break;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ngayKyHopDongCalendarCombo_Leave(object sender, EventArgs e)
        {
            nguoiThuaKe1TenEditBox.Focus();
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

        private void editBoxMaHDChinh_Enter(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.SkyBlue;
            //textbox.Text = Color.White;
        }

        private void maHopDongEditBox_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            if (uiButton1.Focused) return;
            if (btHuyBo.Focused) return;
            //foreach (Control ctl in this.Controls)
            //{
            //    if (ctl.RectangleToScreen(ctl.ClientRectangle).Contains(Cursor.Position))
            //    {
            //        //MessageBox.Show(ctl.Name);
            //        if (ctl.Name == "uiButton1") return;
            //    }
            //}
           // if (kt) return;
            checkMHD();

        }
      
        public void Load_Form()
        {

            DataSet ds;

            string strSQL = "select * from tbl_thon where XaID= " + thonIDUIComboBox.SelectedValue.ToString();
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            
          
          
        }

        private void hoTenEditBox_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            
            //validate_form();
        }

        private void ngayKyHopDongCalendarCombo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if(e.KeyChar == '\r')
            //{
            //    nguoiThuaKe1TenEditBox.Focus();
            //}
        }

        private void uiGroupBox4_Click(object sender, EventArgs e)
        {

        }

        private void uiGroupBoxThongTin_Click(object sender, EventArgs e)
        {

        }

       
       

       
       
    }
}