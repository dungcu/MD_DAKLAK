using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolution;
using MDSolutionEntities;

namespace MDSolution.MDForms
{
    public partial class frmNhapTienTraNo : Form
    {
        public bool addNew;
        public string _ID;
        public frmNhapTienTraNo()
        {
            InitializeComponent();
        }

        //public bool AddNew;
        public frmNhapTienTraNo(string _IDNhapTienTraNo,bool _addNew)
        {
            InitializeComponent();

            addNew = _addNew;
            if (addNew)
            {
                //hopDongIDUIComboBox.SelectedValue = long.Parse(_IDNhapTienTraNo);
                _ID = _IDNhapTienTraNo;
                calendarCombo1.Value = DateTime.Now;
                Get_DuNo();
                //vuTrongIDUIComboBox.SelectedValue = long.Parse(MDSolutionApp.VuTrongID.ToString());
            }
            else
            {
                //iDTextBox.Text = _IDNhapTienTraNo;
                //this.tbl_NhapTienTraNoTableAdapter.FillByID(this.nhapTienTraNo.tbl_NhapTienTraNo, int.Parse(_IDNhapTienTraNo));
                _ID = _IDNhapTienTraNo;
            }
        }

        private void tbl_HopDongBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();
            //this.tbl_HopDongBindingSource.EndEdit();
            //this.tbl_HopDongTableAdapter.Update(this.nhapTienTraNo.tbl_HopDong);
        }

        private void frmNhapTienTraNo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nhapTienTraNo1.tbl_VuTrong' table. You can move, or remove it, as needed.
            this.tbl_VuTrongTableAdapter.Fill(this.nhapTienTraNo1.tbl_VuTrong);
            // TODO: This line of code loads data into the 'nhapTienTraNo1.tbl_HopDong' table. You can move, or remove it, as needed.
            this.tbl_HopDongTableAdapter.Fill(this.nhapTienTraNo1.tbl_HopDong);
            // TODO: This line of code loads data into the 'nhapTienTraNo1.tbl_NhapTienTraNo' table. You can move, or remove it, as needed.
            //this.tbl_NhapTienTraNoTableAdapter.Fill(this.nhapTienTraNo1.tbl_NhapTienTraNo);
            //// TODO: This line of code loads data into the 'nhapTienTraNo1.tbl_NhapTienTraNo' table. You can move, or remove it, as needed.
            //this.tbl_NhapTienTraNoTableAdapter.Fill(this.nhapTienTraNo1.tbl_NhapTienTraNo);
            //// TODO: This line of code loads data into the 'nhapTienTraNo1.tbl_NhapTienTraNo' table. You can move, or remove it, as needed.
            //this.tbl_NhapTienTraNoTableAdapter.Fill(this.nhapTienTraNo1.tbl_NhapTienTraNo);
            //// TODO: This line of code loads data into the 'nhapTienTraNo1.tbl_NhapTienTraNo' table. You can move, or remove it, as needed.
            //this.tbl_NhapTienTraNoTableAdapter1.Fill(this.nhapTienTraNo1.tbl_NhapTienTraNo);

            if (addNew)
            {
                uiButtonNew_Click(null, null);
                if (_ID != "0")
                    hopDongIDUIComboBox.SelectedValue = long.Parse(_ID);

                vuTrongIDUIComboBox.SelectedValue = long.Parse(DACASUCO_App.VuTrongID.ToString());                
            }
            else
            {
                //iDTextBox.Text = _IDNhapTienTraNo;
                this.tbl_NhapTienTraNoTableAdapter.FillBy(this.nhapTienTraNo1.tbl_NhapTienTraNo, int.Parse(_ID));
                _ID = iDTextBox.Text;
                uiButtonEdit_Click(null, null);
            }
        }

        private void uiButtonNew_Click(object sender, EventArgs e)
        {
            this.tblNhapTienTraNoBindingSource.AddNew();

            sotienTextBox.Text = "";
            ghiChuTextBox.Text = "";
            ThonTextBox.Text = "";
            TramTextBox.Text = "";
            //ngayTraDateTimePicker.Value = null;
            uiButtonEdit.Enabled = false;
            uiButtonNew.Enabled = false;
            //uiButtonSave.Enabled = true;
            hopDongIDUIComboBox.Focus();
            hopDongIDUIComboBox.SelectedValue = null;
            hopDongIDUIComboBox1.SelectedValue = null;
            vuTrongIDUIComboBox.SelectedValue = long.Parse(DACASUCO_App.VuTrongID.ToString());
        }

        private void hopDongIDUIComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (hopDongIDUIComboBox.Text != "")
                {
                    hopDongIDUIComboBox1.SelectedValue = hopDongIDUIComboBox.SelectedValue;

                    string strSQL = "SELECT tbl_TramNongVu.Ten AS Tram, tbl_Thon.Ten AS Thon FROM tbl_HopDong INNER JOIN ";
                    strSQL += "tbl_Thon ON tbl_HopDong.ThonID = tbl_Thon.ID INNER JOIN ";
                    strSQL += " tbl_Xa ON tbl_Thon.XaID = tbl_Xa.ID INNER JOIN";
                    strSQL += " tbl_TramNongVu ON tbl_Xa.CumID = tbl_TramNongVu.ID";
                    strSQL += " WHERE (tbl_HopDong.ID =" + hopDongIDUIComboBox.SelectedValue.ToString() + ")";

                    DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
                    ThonTextBox.Text = ds.Tables[0].Rows[0]["Thon"].ToString();
                    TramTextBox.Text = ds.Tables[0].Rows[0]["Tram"].ToString();
                }
            }
            catch
            { }
        }

        private void uiButtonEdit_Click(object sender, EventArgs e)
        {
            hopDongIDUIComboBox.ReadOnly = true;
            //ngayTraDateTimePicker.Focus();
            hopDongIDUIComboBox.TabStop = false;
            ngayTraCalendarCombo.Focus();
        }

        private bool Chek_SoTienConLai()
        {
            //long TongTien = long.Parse(XuLyChuoiTien(NoDauTuTxt.Text)) + long.Parse(XuLyChuoiTien(NoLaiTxt.Text)) + long.Parse(XuLyChuoiTien(NoUngTxt.Text)) + long.Parse(XuLyChuoiTien(NoKhacTxt.Text)) + long.Parse(XuLyChuoiTien(NoCuTxt.Text));
            long TongTien = long.Parse(XuLyChuoiTien(NoTongTxt.Text));

            long SoTienTra = long.Parse(XuLyChuoiTien(sotienTextBox.Text));

            if (SoTienTra > TongTien)
            {
                MessageBox.Show("Số tiền trả lớn hơn số nợ của CHĐ!\nHãy kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
            //string sql = "Select Count(ID) From tbl_TruNo_DauTu Where HopDongID =" + hopDongIDUIComboBox.SelectedValue.ToString() + " And vuTrongID =" + MDSolutionApp.VuTrongID.ToString();
            //sql = DBModule.ExecuteQueryForOneResult(sql, null, null);
            //if (string.IsNullOrEmpty(sql) || sql == "0") // chua co dl cua hd trong tbl_truNo
            //{
            //    sql = "Select ISNULL(Sum(TienUng),0) From tbl_UngTienMia Where HopDongID =" + hopDongIDUIComboBox.SelectedValue.ToString() + " And VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + " And DaThanhToan is Null";
            //    long SoTienConNo = 0;
            //    string strSoTien = DBModule.ExecuteQueryForOneResult(sql, null, null);
            //    SoTienConNo = long.Parse(strSoTien);

            //    sql = "Select ISNULL(SUM(SoTien),0) From tbl_DauTu Where HopDongID =" + hopDongIDUIComboBox.SelectedValue.ToString() + " And vuTrongID =" + MDSolutionApp.VuTrongID.ToString() + " And DaThanhToan is null And DonViCungUngVatTuID = 1";
            //    strSoTien = DBModule.ExecuteQueryForOneResult(sql, null, null);
            //    SoTienConNo = SoTienConNo + long.Parse(strSoTien);

            //    sql = "Select ISNULL(SUM(SoTien),0) From tbl_NoTienMuaVatTuCuaCongTy Where HopdongID =" + hopDongIDUIComboBox.SelectedValue.ToString() + " And vuTrongID =" + MDSolutionApp.VuTrongID.ToString() + " And DaThanhToan is Null";
            //    strSoTien = DBModule.ExecuteQueryForOneResult(sql, null, null);
            //    SoTienConNo = SoTienConNo + long.Parse(strSoTien);

            //    sql = "Select ISNULL(SUM(NoGoc + NoLai + Phat),0) From tbl_NoCuChuHopDong Where HopDongID =" + hopDongIDUIComboBox.SelectedValue.ToString() + " And VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
            //    strSoTien = DBModule.ExecuteQueryForOneResult(sql, null, null);
            //    SoTienConNo = SoTienConNo + long.Parse(strSoTien);

            //    long SoTienTra = long.Parse(XuLyChuoiTien(sotienTextBox.Text));
            //    if (SoTienTra > SoTienConNo)
            //    {
            //        MessageBox.Show("Số tiền trả lớn hơn số nợ của CHĐ!\nHãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        sotienTextBox.Focus();
            //        return false;
            //    }
            //}
            //else
            //{
            //    sql = "Select ISNULL(Sum(SoTien),0) From tbl_TruNo_DauTu Where HopDongID =" + hopDongIDUIComboBox.SelectedValue.ToString() +
            //        " And DotThanhToan is Null And VuTrongID = " + MDSolutionApp.VuTrongID.ToString() + " And ThuTu <> '009' And ThuTu <> '008' And ThuTu <> '007' And ThuTu <> '006' And ThuTu <> '005'";
            //    sql = DBModule.ExecuteQueryForOneResult(sql, null, null);
            //    long SoTienConLai = long.Parse(sql);
            //    long SoTienTra = long.Parse(XuLyChuoiTien(sotienTextBox.Text));
            //    if (SoTienTra > SoTienConLai)
            //    {
            //        MessageBox.Show("Số tiền trả lớn hơn số nợ của CHĐ!\nHãy kiểm tra lại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        sotienTextBox.Focus();
            //        return false;
            //    }
            //}
            //return true;
        }

        private bool Chek_NgayTraNo()
        {
            string sql = "Select Max(NgayTra) as Max From tbl_NhapTienTraNo Where HopDongID =" + hopDongIDUIComboBox.SelectedValue.ToString() + " And VuTrongId =" + DACASUCO_App.VuTrongID.ToString();
            DateTime dtNgayTra;
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (!ds.Tables[0].Rows[0].IsNull(0))
                dtNgayTra = Convert.ToDateTime(ds.Tables[0].Rows[0]["Max"].ToString());
            else
            {
                dtNgayTra = ngayTraCalendarCombo.Value;
            }
            TimeSpan a = ngayTraCalendarCombo.Value - dtNgayTra;
            if (a.Days < 0)
            {
                //MessageBox.Show("Ngày trả tiền cho hợp đồng này nhỏ hơn ngày trả tiền lần trước!\nBạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                sotienTextBox1.Text = XuLyChuoiTien(sotienTextBox.Text);
                if (Chek_err())
                {}
                  else
                {//iDTextBox.Text = GetID();
                    return;
                }

                if (Chek_NgayTraNo())
                { }
                else
                {
                    MessageBox.Show("Ngày trả tiền cho hợp đồng này nhỏ hơn ngày trả tiền lần trước!\nBạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Chek_SoTienConLai())
                { }
                else
                {

                    return;
                }

                if (addNew)
                {
                    iDTextBox.Text = GetID();
                }
                Dosave();

                if (addNew)
                {

                    hopDongIDUIComboBox.Focus();
                    uiButtonNew_Click(null, null);
                    _ID = iDTextBox.Text;
                    MessageBox.Show("Bạn đã lưu lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bạn đã sửa lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Có lỗi khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ////return false;
            }
        }

        private void Chek_SoTienTra()
        {
            string strSQL = "sp_ThanhToan_NhapTienTraNo " + DACASUCO_App.VuTrongID.ToString() + ","
                + "'" + ngayTraCalendarCombo.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," + hopDongIDUIComboBox.SelectedValue.ToString() + "," + iDTextBox.ToString();
            //string strSQL = "Select NgayChotTinhLai From tbl_VuTrong Where ID =" + MDSolutionApp.VuTrongID.ToString();
            //DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            //DateTime NgayChotLai;
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //    NgayChotLai = Convert.ToDateTime(ds.Tables[0].Rows[0]["NgayChotTinhLai"].ToString());

            //    string str = "sp_ThanhToan_NhapTienTraNo " + MDSolutionApp.VuTrongID.ToString() + ","
            //        + ngayTraCalendarCombo.Value.ToString("yyyy-MM-dd HH:mm:ss") + "," + hopDongIDUIComboBox.SelectedValue.ToString();

            //    DBModule.ExecuteNoneBackup("sp_ThanhToan_NhapTienTraNo " + MDSolutionApp.VuTrongID.ToString() + ","
            //        + ngayTraCalendarCombo.Value.ToString("yyyy-MM-dd HH:mm:ss") + "," + hopDongIDUIComboBox.SelectedValue.ToString(), null, null);
            //}
            //else
            //{
            //    string str = "sp_ThanhToan_NhapTienTraNo " + MDSolutionApp.VuTrongID.ToString() + ","
            //        + ngayTraCalendarCombo.Value.ToString("yyyy-MM-dd HH:mm:ss") + "," + hopDongIDUIComboBox.SelectedValue.ToString();

            //    DBModule.ExecuteNoneBackup("sp_ThanhToan_NhapTienTraNo " + MDSolutionApp.VuTrongID.ToString() + ","
            //        + ngayTraCalendarCombo.Value.ToString("yyyy-MM-dd HH:mm:ss") + "," + hopDongIDUIComboBox.SelectedValue.ToString(), null, null);
            //}
        }

        private string GetID()
        {
            string strSQL = "Select Max(ID) from tbl_NhapTienTraNo";
            string strMaxID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
            long maxID = 0;
            if (!string.IsNullOrEmpty(strMaxID))
            {
                maxID = long.Parse(strMaxID) + 1;
            }
            else
            {
                maxID = 1;
            }
            return maxID.ToString();
        }

        private void Dosave()
        {
            //try
            //{
            //iDTextBox.Text = "6";
            this.tblNhapTienTraNoBindingSource.EndEdit();
            //iDTextBox.Text = "6";
            this.tbl_NhapTienTraNoTableAdapter.Update(this.nhapTienTraNo1.tbl_NhapTienTraNo);

            // Store thực hiện trừ nợ
            string strSQL = "sp_ThanhToan_NhapTienTraNo " + DACASUCO_App.VuTrongID.ToString() + ","
                + "'" + ngayTraCalendarCombo.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'" + "," + hopDongIDUIComboBox.SelectedValue.ToString() + "," + iDTextBox.Text;

            //string strSQL = "sp_ThanhToan_TinhCongNo_NhapTienTraNo " + MDSolutionApp.VuTrongID.ToString() + "," + hopDongIDUIComboBox.SelectedValue.ToString() 
            //    + "," + iDTextBox.Text + "," + "'" + ngayTraCalendarCombo.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            DBModule.ExecuteNonQuery(strSQL, null, null);
            //}
            //catch
            //{
            //    //MessageBox.Show("Có lỗi khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }



        private bool Chek_err()
        {
            if (hopDongIDUIComboBox.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã chủ hợp đồng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hopDongIDUIComboBox.Focus();
                return false;
            }

            if (ngayTraCalendarCombo.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày trả tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ngayTraCalendarCombo.Focus();
                return false;
            }

            if (ngayTraCalendarCombo.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Ngày trả nợ bạn nhập lớn hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ngayTraCalendarCombo.Focus();
                return false;
            }

            if (sotienTextBox.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tiền trả nợ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sotienTextBox.Focus();
                return false;
            }
            else
            {
                try
                {
                    string str = XuLyChuoiTien(sotienTextBox.Text);
                    long a = long.Parse(str);
                    if (a < 0)
                    {
                        MessageBox.Show("Số tiền nhập vào phải là số dương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sotienTextBox.Focus();
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("Số tiền nhập vào phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sotienTextBox.Focus();
                    return false;
                }
            }
            return true;
        }

        private void hopDongIDUIComboBox_Enter(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.GetType().ToString());
            Control text = (Control)sender;
            text.BackColor = Color.SkyBlue;
        }

        private void hopDongIDUIComboBox_Leave(object sender, EventArgs e)
        {
            Control text = (Control)sender;
            text.BackColor = Color.White;

            if (hopDongIDUIComboBox.Text != "")
            {
                string strSQL = "Select ID from tbl_HopDong Where MaHopDong=N'" + hopDongIDUIComboBox.Text + "'";
                string str = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (!string.IsNullOrEmpty(str))
                {
                    hopDongIDUIComboBox.SelectedValue = long.Parse(str);
                    hopDongIDUIComboBox_SelectedValueChanged(null, null);
                    Get_DuNo();
                }
                else
                {
                    MessageBox.Show("Bạn nhập sai mã chủ hợp đồng!\nHãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hopDongIDUIComboBox.Focus();
                }
            }
        }

        private void ngayTraCalendarCombo_Leave(object sender, EventArgs e)
        {
            Control text = (Control)sender;
            text.BackColor = Color.White;
        }

        private void sotienTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                Control text = (Control)sender;
                text.BackColor = Color.White;

                if (sotienTextBox.Text != "" && sotienTextBox.Text != "0" )
                    {
                    long a;
                    string str = XuLyChuoiTien(sotienTextBox.Text);
                    if (long.TryParse(str,out a))
                        sotienTextBox.Text = a.ToString("###,###,###");
                    else
                    {
                        MessageBox.Show("số tiền nhập vào phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sotienTextBox.Focus();
                    }
                }
                else
                {
                    sotienTextBox.Text = "0";
                }
            }
            catch
            {
                MessageBox.Show("số tiền nhập vào phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string XuLyChuoiTien(string TienFomat)
        {
            string[] str = TienFomat.Split(',');
            string strKQ = "";
            foreach (string s in str)
            {
                strKQ += s;
            }
            if (strKQ != "")
                return strKQ;
            else
                return "0";
        }

        private void sotienTextBox1_TextChanged(object sender, EventArgs e)
        {
            //sotienTextBox.Text = sotienTextBox1.Text;
            long a = long.Parse(sotienTextBox1.Text);
            sotienTextBox.Text = a.ToString("###,###,###");
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
                            
                        }
                        catch { }
                        break;
                }                
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {

        }

        private void tbl_NhapTienTraNoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();
            //this.tblNhapTienTraNoBindingSource.EndEdit();
            //this.tbl_NhapTienTraNoTableAdapter.Update(this.nhapTienTraNo1.tbl_NhapTienTraNo);

        }

        private void tbl_NhapTienTraNoBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            //this.Validate();
            //this.tblNhapTienTraNoBindingSource.EndEdit();
            //this.tbl_NhapTienTraNoTableAdapter.Update(this.nhapTienTraNo1.tbl_NhapTienTraNo);

        }

        private void calendarCombo1_ValueChanged(object sender, EventArgs e)
        {
            Get_DuNo();
        }

        private void Get_DuNo()
        {
            try
            {
                string strSQL = "sp_NhapTienTraNo_ChiTietNoPhaiTra " + DACASUCO_App.VuTrongID.ToString() + "," + hopDongIDUIComboBox.SelectedValue.ToString() + ",'" + calendarCombo1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                DataSet ds;
                ds = DBModule.ExecuteQuery(strSQL, null, null);
                NoUngTxt.Text = long.Parse(ds.Tables[0].Rows[0]["NoUng"].ToString()).ToString("###,###,###,##0");
                NoDauTuTxt.Text = long.Parse(ds.Tables[0].Rows[0]["NoGoc"].ToString()).ToString("###,###,###,##0");
                NoLaiTxt.Text = long.Parse(ds.Tables[0].Rows[0]["NoLai"].ToString()).ToString("###,###,###,##0");
                NoKhacTxt.Text = long.Parse(ds.Tables[0].Rows[0]["NoKhac"].ToString()).ToString("###,###,###,##0");
                NoCuTxt.Text = long.Parse(ds.Tables[0].Rows[0]["NoCu"].ToString()).ToString("###,###,###,##0");
                NoTongTxt.Text = long.Parse(ds.Tables[0].Rows[0]["Tong"].ToString()).ToString("###,###,###,##0");
            }
            catch
            { }
        }
    }
}