using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using MDSolution;

namespace DACASUCO.MDDataSetForms
{
    public partial class frmDienTichDangKy : Form
    {
        public long _ID = 0;
        private int ID = 0;
        private Boolean IsAdd = true;
        public frmDienTichDangKy()
        {
            InitializeComponent();
        }
        public frmDienTichDangKy(long id, Boolean IsAddNew)
        {
            InitializeComponent();
            ID = int.Parse(id.ToString());
            IsAdd = IsAddNew;
            
            if (IsAdd)
            {
               // this.tbl_ThuaRuongTableAdapter.Fill(this.dienTichDataSet.tbl_ThuaRuong);
                //this.tbl_ThuaRuongBindingSource.AddNew();

            }
            else
            {
                this.tbl_ThuaRuongTableAdapter.FillByID(this.dienTichDataSet.tbl_ThuaRuong, ID);
                string a = dienTichTextBox.Text;
            }
        }
        
        private void frmDienTich_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_KieuTrong' table. You can move, or remove it, as needed.
            //this.tbl_KieuTrongTableAdapter.Fill(this.dienTichDataSet.tbl_KieuTrong);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_HopDong' table. You can move, or remove it, as needed.
            //this.tbl_HopDongTableAdapter.Fill(this.dienTichDataSet.tbl_HopDong);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_GiongMia' table. You can move, or remove it, as needed.
            this.tbl_GiongMiaTableAdapter.Fill(this.dienTichDataSet.tbl_GiongMia);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_TinhTrangThuaRuong' table. You can move, or remove it, as needed.
            this.tbl_TinhTrangThuaRuongTableAdapter.Fill(this.dienTichDataSet.tbl_TinhTrangThuaRuong);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_PheCanh' table. You can move, or remove it, as needed.
            this.tbl_PheCanhTableAdapter.Fill(this.dienTichDataSet.tbl_PheCanh);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_MucDichTrong' table. You can move, or remove it, as needed.
            this.tbl_MucDichTrongTableAdapter.Fill(this.dienTichDataSet.tbl_MucDichTrong);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_VuTrong' table. You can move, or remove it, as needed.
            this.tbl_VuTrongTableAdapter.Fill(this.dienTichDataSet.tbl_VuTrong);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_RaiVu' table. You can move, or remove it, as needed.
            this.tbl_RaiVuTableAdapter.Fill(this.dienTichDataSet.tbl_RaiVu);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_TramNongVu' table. You can move, or remove it, as needed.
            this.tbl_TramNongVuTableAdapter.Fill(this.dienTichDataSet.tbl_TramNongVu);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_LoaiDat' table. You can move, or remove it, as needed.
            this.tbl_LoaiDatTableAdapter.Fill(this.dienTichDataSet.tbl_LoaiDat);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_Thon' table. You can move, or remove it, as needed.
            this.tbl_ThonTableAdapter.Fill(this.dienTichDataSet.tbl_Thon);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_HopDong' table. You can move, or remove it, as needed.
            this.tbl_HopDongTableAdapter.Fill(this.dienTichDataSet.tbl_HopDong);
            tbl_KieuTrongTableAdapter.Fill(this.dienTichDataSet.tbl_KieuTrong);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_ThuaRuong' table. You can move, or remove it, as needed.
            TruyenDuLieu(true);

            if (IsAdd)
            {
                uiButtonNew_Click(null, null);
                HopDongUIDCombobox.Focus();
            }
            else
            {
                string a = dienTichTextBox.Text;
                uiButtonEdit_Click(null, null);
                xuDongTextBox.Focus();
                _ID = long.Parse(iDTextBox.Text);
            }

        }

        private void uiButtonNew_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbl_ThuaRuongBindingSource.AddNew();
                
                IsAdd = true;
                iDTextBox.Text = GetID();
                if (ID > 0)
                {
                    HopDongUIDCombobox.SelectedValue = long.Parse(ID.ToString());
                    //maThuaRuongTextBox.Text = GetMaThuaRuong();
                    LayXa();
                }
                uiComboBoxVuTrong.SelectedValue = MDSolution.DACASUCO_App.VuTrongID.ToString();
                TruyenDuLieu(true);
                uiButtonDelete.Enabled = false;
                uiButtonNew.Enabled = false;
                uiButtonEdit.Enabled = false;
                uiButtonSave.Enabled = true;
                uiButtonCancel.Enabled = true;
                uiGroupBox1.Enabled = true;
                uiGroupBox2.Enabled = true;
                uiGroupBox3.Enabled = true;
                HopDongUIDCombobox.Enabled = true;                
                HopDongUIDCombobox.Focus();

                soBanDieuTraTextBox.Text = "0";
                trangThaiDangKyTextBox.Text = "1"; // la thua ruong dang ky    
                
            }
            catch
            {}
            
        }
        private string GetID()
        {
            try
            {
                long MaxID = 0;
                string strMaxID = "";
                string strSQL = "select max([ID])+1 As Max from tbl_ThuaRuong";
                strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (strMaxID != "")
                    MaxID = long.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null));
                else
                    MaxID = 1;
                return MaxID.ToString();
            }
            catch 
            {
                return ""; 
            }
        }
        private void TruyenDuLieu(Boolean Truyen)
        {
            if (Truyen)
            {
                float a = 0;
                if (dienTichTextBox.Text != "")
                { 
                    a = float.Parse(dienTichTextBox.Text)/10000; 
                }
                editBoxDienTich.Text = a.ToString();
                editBoxNSDKLan1.Text = nangSuatDuKienTextBox.Text;
                editBoxNSDKLan2.Text = nangSuatDuKien1TextBox.Text;
                editBoxSLDKLan1.Text = sanLuongDuKienTextBox.Text;
                editBoxSLDKLan2.Text = sanLuongDuKien1TextBox.Text;
                // editBoxDTChatGiong.Text = dienTichChatGiongTextBox.Text;
                //editBoxDTPheCanh.Text = dienTichPheCanhTextBox.Text;
                //editBoxSLChatGiong.Text = sanLuongChatGiongTextBox.Text;
            }
            else
            {
                float a = 0;
                if (editBoxDienTich.Text != "")
                { a = float.Parse(editBoxDienTich.Text) * 10000; }

                dienTichTextBox.Text = a.ToString();
                nangSuatDuKienTextBox.Text = editBoxNSDKLan1.Text;
                nangSuatDuKien1TextBox.Text = editBoxNSDKLan2.Text;
                sanLuongDuKienTextBox.Text = editBoxSLDKLan1.Text;
                sanLuongDuKien1TextBox.Text = editBoxSLDKLan2.Text;
                //sanLuongChatGiongTextBox.Text = editBoxSLChatGiong.Text;
                //dienTichPheCanhTextBox.Text = editBoxDTPheCanh.Text;
                //dienTichChatGiongTextBox.Text = editBoxDTChatGiong.Text;

            }
        }

        private void uiButtonEdit_Click(object sender, EventArgs e)
        {
            uiButtonNew.Enabled = false;
            uiButtonEdit.Enabled = false;
            uiButtonSave.Enabled = true;
            uiButtonCancel.Enabled = true;
            uiButtonDelete.Enabled = true;
            uiGroupBox1.Enabled = true;
            uiGroupBox2.Enabled = true;
            uiGroupBox3.Enabled = true;
            HopDongUIDCombobox.Enabled = false;
            //soBanDieuTraTextBox.Focus();
            IsAdd = false;
        }

        private void uiButtonDelete_Click(object sender, EventArgs e)
        {
            string message;
            if (iDTextBox.Text != "")
            {
                message = String.Format("Bạn có chắc chắn muốn xóa thửa ruộng này ?");

                if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.tbl_ThuaRuongBindingSource.RemoveCurrent();
                    DoSave();
                    //this.tbl_DauTuTableAdapter.Fill(this.dauTuDataSet.tbl_DauTu);
                }
            }
            else
            {
                MessageBox.Show("Thửa ruộng này chưa có nên không xóa được !");

            }
        }
        private void DoSave()
        {
            try
            {
                //this.Validate();
                //string a = dienTichTextBox.Text;
                this.tbl_ThuaRuongBindingSource.EndEdit();
                //dienTichTextBox.Text = a.ToString();
                this.tbl_ThuaRuongTableAdapter.Update(this.dienTichDataSet.tbl_ThuaRuong);
            }
            catch 
            { 
                MessageBox.Show("Có lỗi khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            //if tabControl1.SelectedTab == tabPage1)
            //{
            //}
            maThuaRuongTextBox.Text = "1";
            soBanDieuTraTextBox.Text = "0";
            trangThaiDangKyTextBox.Text = "1";
            //trangThaiTextBox.Text = "";
            try
            {
                try//Truyen cac thong so phu:
                {
                    if (string.IsNullOrEmpty(createdByTextBox.Text))//Them moi
                    {
                        createdByTextBox.Text = DACASUCO_App.User.ID.ToString();
                        dateAddDateTimePicker.Value = DateTime.Now;
                        
                    }
                    else
                    {
                        modifyByTextBox.Text = DACASUCO_App.User.ID.ToString();
                        dataModifyDateTimePicker.Value = DateTime.Now;
                    }
                }
                catch 
                {
                    
                }
                //this.Validate();

                
                    if (!SaveThuaRuong())
                    { 
                        return; 
                    }

                    if (IsAdd == true)
                    {
                        iDTextBox.Text = GetID();
                    }
                    DoSave();

                    uiButtonNew.Enabled = true;
                    uiButtonEdit.Enabled = true;
                    uiButtonSave.Enabled = false;
                    uiButtonCancel.Enabled = false;
                    uiGroupBox1.Enabled = false;
                    uiGroupBox2.Enabled = false;
                    uiGroupBox3.Enabled = false;
                    uiButtonDelete.Enabled = true;
                    _ID = long.Parse(iDTextBox.Text);
                    if (IsAdd)
                    {
                        ID = int.Parse(HopDongUIDCombobox.SelectedValue.ToString());
                        MessageBox.Show("Bạn đã lưu lại thành công !", "Thông báo");
                        uiButtonNew_Click(null, null);
                        HopDongUIDCombobox.SelectedValue = null;
                        uiComboBox1.SelectedValue = null;
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã sửa lại thành công !", "Thông báo");
                        this.Close();
                    }

                
            }
            catch 
            {
                MessageBox.Show("Đã có lỗi khi lưu dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
        }

        private void uiButtonClose_Click(object sender, EventArgs e)
        {
            this.tbl_ThuaRuongBindingSource.CancelEdit();         
            this.Hide();
        }
        private bool SaveThuaRuong()
        {
            try
            {
                float Test = 0;                   
                    
                
                if (string.IsNullOrEmpty(HopDongUIDCombobox.Text))
                {
                    MessageBox.Show("Cho biết mã chủ hợp đồng", "Thông báo");
                    HopDongUIDCombobox.Focus();
                    return false;
                }
                //if (string.IsNullOrEmpty(soBanDieuTraTextBox.Text) && tabControl1.SelectedIndex==0)
                //{
                //    MessageBox.Show("Cho biết số bản điều tra", "Thông báo");
                //    soBanDieuTraTextBox.Focus();
                //    return false;}
                //else{
                //    if (IsExistingSBDT(IsAdd, soBanDieuTraTextBox.Text))
                //    {
                //        MessageBox.Show("Nhập trùng số bản điều tra", "Thông báo");
                //        soBanDieuTraTextBox.Focus();
                //        return false;
                //    }
                //}
               
                if (string.IsNullOrEmpty(TramNongVu.Text))
                {
                    MessageBox.Show("Cho biết thửa ruộng thuộc trạm nông vụ nào", "Thông báo");
                    TramNongVu.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(editBoxDienTich.Text))
                {
                    MessageBox.Show("Bạn chưa nhập diện tích", "Thông báo");
                    editBoxDienTich.Focus();
                    return false;
                }
                else
                {
                    if (!float.TryParse(editBoxDienTich.Text, out Test))
                    {
                        MessageBox.Show("Diện tích phải nhập kiểu số", "Thông báo");
                        editBoxDienTich.Focus();
                        return false;
                    }
                    else
                    {
                        if (float.Parse(editBoxDienTich.Text) <= 0)
                        {
                            MessageBox.Show("Diện tích phải lớn hơn 0", "Thông báo");
                            editBoxDienTich.Focus();
                            return false;
                        }
                    }
                }
                if (string.IsNullOrEmpty(uiComboBoxLoaiDat.Text))
                {
                    MessageBox.Show("Bạn chưa nhập loại đất", "Thông báo");
                    uiComboBoxLoaiDat.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(uiComboBoxGiongMia.Text))
                {
                    MessageBox.Show("Cho biết giống mía trồng", "Thông báo");
                    uiComboBoxGiongMia.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(uiComboBoxRaiVu.Text))
                {
                    MessageBox.Show("Cho biết mía rải vụ nào", "Thông báo");
                    uiComboBoxRaiVu.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(uiComboBoxMucDich.Text))
                {
                    MessageBox.Show("Xác định rõ mục đích trồng", "Thông báo");
                    uiComboBoxMucDich.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(ngayTrongCalendarCombo.Text))
                {
                    MessageBox.Show("Cho biết ngày trồng", "Thông báo");
                    ngayTrongCalendarCombo.Focus();
                    return false;
                }
                //else
                //{
                  // if (DateTime.Now > DateTime.Parse(ngayTrongCalendarCombo.Value))
                //    {
                //        MessageBox.Show("Ngày trồng phải lớn hơn ngày hiện tại !", "Thông báo");
                //        ngayTrongCalendarCombo.Focus();
                //        return false;
                //    }
                //}
                //if (string.IsNullOrEmpty(uiComboBoxTinhtrang.Text) && tabControl1.SelectedIndex == 0)
                //{
                //    MessageBox.Show("Bạn chưa nhập tình trạng thửa ruộng", "Thông báo");
                //    uiComboBoxTinhtrang.Focus();
                //    return false;
                //}
                //if (string.IsNullOrEmpty(editBoxDTChatGiong.Text))
                //{
                //    editBoxDTChatGiong.Text = "0";
                //}
                //else
                //{
                //    if (!float.TryParse(editBoxDTChatGiong.Text, out Test))
                //    {
                //        MessageBox.Show("Diện tích chặt giống phải nhập kiểu số", "Thông báo");
                //        editBoxDTChatGiong.Focus();
                //        return false;
                //    }
                //    else
                //    {
                //        if (float.Parse(editBoxDTChatGiong.Text) < 0)
                //        {
                //            MessageBox.Show("Diện tích chặt giống phải nhập lớn hơn 0", "Thông báo");
                //            editBoxDTChatGiong.Focus();
                //            return false;
                //        }
                //    }
                //}
               
                //if (string.IsNullOrEmpty(editBoxSLChatGiong.Text))
                //{
                //    editBoxSLChatGiong.Text = "0";
                //}
                //else
                //{
                    //if (!float.TryParse(editBoxSLChatGiong.Text, out Test))
                    //{
                    //    MessageBox.Show("Sản lượng chặt giống phải nhập kiểu số", "Thông báo");
                    //    editBoxSLChatGiong.Focus();
                    //    return false;
                    //}
                    //else
                    //{
                    //    if (float.Parse(editBoxSLChatGiong.Text) < 0)
                    //    {
                    //        MessageBox.Show("Sản lượng chặt giống phải nhập lớn hơn 0", "Thông báo");
                    //        editBoxSLChatGiong.Focus();
                    //        return false;
                    //    }
                    //}
                //}
                //if (string.IsNullOrEmpty(editBoxDTPheCanh.Text))
                //{
                //    editBoxDTPheCanh.Text = "0";
                //}
                //else
                //{
                //    if (!float.TryParse(editBoxDTPheCanh.Text, out Test))
                //    {
                //        MessageBox.Show("Diện tích phế canh phải nhập kiểu số", "Thông báo");
                //        editBoxDTPheCanh.Focus();
                //        return false;
                //    }
                //    else
                //    {
                //        if (float.Parse(editBoxDTPheCanh.Text) < 0)
                //        {
                //            MessageBox.Show("Diện tích phế canh phải nhập lớn hơn 0", "Thông báo");
                //            editBoxDTPheCanh.Focus();
                //            return false;
                //        }
                //    }
                //}

                if (string.IsNullOrEmpty(editBoxNSDKLan1.Text))
                {
                    editBoxNSDKLan1.Text = "0";
                }
                else
                {
                    if (!float.TryParse(editBoxNSDKLan1.Text, out Test))
                    {
                        MessageBox.Show("Năng suất dự kiến lần 1 phải nhập kiểu số", "Thông báo");
                        editBoxNSDKLan1.Focus();
                        return false;
                    }
                    else
                    {
                        if (float.Parse(editBoxNSDKLan1.Text) < 0)
                        {
                            MessageBox.Show("Năng suất dự kiến lần 1 phải nhập lớn hơn 0", "Thông báo");
                            editBoxNSDKLan1.Focus();
                            return false;
                        }
                    }
                }
                float SL = float.Parse(editBoxNSDKLan1.Text) * float.Parse(editBoxDienTich.Text);
                editBoxSLDKLan1.Text = SL.ToString();    
                
                if (string.IsNullOrEmpty(editBoxNSDKLan2.Text))
                {
                    editBoxNSDKLan2.Text = "0";
                }
                else
                {
                    if (!float.TryParse(editBoxNSDKLan2.Text,out Test))
                    {
                        MessageBox.Show("Năng suất dự kiến lần 2 phải nhập kiểu số", "Thông báo");
                        editBoxNSDKLan2.Focus();
                        return false;
                    }
                    else
                    {
                        if (float.Parse(editBoxNSDKLan2.Text) < 0)
                        {
                            MessageBox.Show("Năng suất dự kiến lần 2 phải nhập lớn hơn 0", "Thông báo");
                            editBoxNSDKLan2.Focus();
                            return false;
                        }
                    }
                    
                }
                SL = float.Parse(editBoxNSDKLan2.Text) * float.Parse(editBoxDienTich.Text);
                editBoxSLDKLan2.Text = SL.ToString();
                //if (!trangThaiCheckBox.Checked)
                //{ //trangThaiCheckBox.Checked = false;
                //trangThaiCheckBox.Text = "0";
                //}
                trangThaiTextBox.Text = "1";
                TruyenDuLieu(false);                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            try
            {             
                uiButtonNew.Enabled = true;
                uiButtonEdit.Enabled = true;
                uiButtonSave.Enabled = false;
                uiButtonCancel.Enabled = false;
                uiButtonDelete.Enabled = true;
                uiGroupBox1.Enabled = false;
                uiGroupBox2.Enabled = false;
                uiGroupBox3.Enabled = false;
                
              
                if (IsAdd)
                {
                    this.tbl_ThuaRuongBindingSource.CancelEdit();
                    uiButtonNew_Click(null, null);
                }
                else
                {
                    this.tbl_ThuaRuongBindingSource.CancelEdit();
                   
                     this.tbl_ThuaRuongTableAdapter.FillByID(this.dienTichDataSet.tbl_ThuaRuong, ID); 
                }
            }
            catch
            {

            }
        }

        private void HopDongUIDCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void iDTextBox_TextChanged(object sender, EventArgs e)
        {
        //    //TruyenDuLieu(true);
        //    uiButtonNew.Enabled = true;
        //    uiButtonDelete.Enabled = true;
        //    uiButtonEdit.Enabled = true;
        //    uiButtonSave.Enabled = false;
        //    uiButtonCancel.Enabled = false;
        //    uiGroupBox1.Enabled = false;
        //    uiGroupBox2.Enabled = false;
        //    uiGroupBox3.Enabled = false;
        //    //IsAdd = false;
        //   // tbl_ThuaRuongBindingNavigator.Enabled = true;
        }
        //private string GetMaThuaRuong()
        //{
        //    try
        //    {
        //        //string strXaID = "";

        //        string strSQL;
        //        string strMaxID = "";
        //        if (HopDongUIDCombobox.Text != "")
        //        {
        //            strSQL = "SELECT Count(ID) FROM tbl_ThuaRuong WHERE HopDongID=" + HopDongUIDCombobox.SelectedValue + " AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
        //            strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
        //            if (strMaxID == "") strMaxID = "0";
        //            int intMaxID = int.Parse(strMaxID);
        //            intMaxID++;
        //            return HopDongUIDCombobox.Text + "-" + intMaxID.ToString();
        //        }
        //        else { return ""; }
        //    }
        //    catch
        //    {
        //        return "";
        //    }


        //}
        private bool IsExistingMTR(bool isAddnew, string ContractCode)
        {
            if (isAddnew)
            {
                string SQL = " select Count(*) from tbl_ThuaRuong where MaThuaRuong = '" + ContractCode + "'";
                string ret = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else
            {
                string SQL = " select * from tbl_ThuaRuong where MaThuaRuong = '" + ContractCode + "'";
                DataSet ds;
                ds = MDSolutionEntities.DBModule.ExecuteQuery(SQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow d13 = ds.Tables[0].Rows[0];

                    if (d13["ID"].ToString() != iDTextBox.Text)
                    { return true; }
                    else { return false; }
                }
                else { return false; }
            }
        }
        private bool IsExistingSBDT(bool isAddnew, string ContractCode)
        {
            if (isAddnew)
            {
                string SQL = " select Count(*) from tbl_ThuaRuong where SoBanDieuTra = N'" + ContractCode + "' and vutrongid =" + MDSolution.DACASUCO_App.VuTrongID;
                string ret = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else
            {
                string SQL = " select * from tbl_ThuaRuong where SoBanDieuTra = N'" + ContractCode + "' and vutrongid =" + MDSolution.DACASUCO_App.VuTrongID;
                DataSet ds;
                ds = MDSolutionEntities.DBModule.ExecuteQuery(SQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow d13 = ds.Tables[0].Rows[0];

                    if (d13["ID"].ToString() != iDTextBox.Text)
                    { return true; }
                    else { return false; }
                }
                else { return false; }
            }
        }

        private void editBoxNSDKLan1_TextChanged(object sender, EventArgs e)
        {
            //float Test = 0;
            //if (string.IsNullOrEmpty(editBoxNSDKLan1.Text))
            //{
            //    editBoxNSDKLan1.Text = "0";
            //}
            //else
            //{
            //    if (!float.TryParse(editBoxNSDKLan1.Text, out Test))
            //    {
            //        MessageBox.Show("Năng suất dự kiến lần 1 phải nhập kiểu số", "Thông báo");
            //        editBoxNSDKLan1.Focus();
            //        //return false;
            //    }
            //    else
            //    {
            //        if (float.Parse(editBoxNSDKLan1.Text) < 0)
            //        {
            //            MessageBox.Show("Năng suất dự kiến lần 1 phải nhập lớn hơn 0", "Thông báo");
            //            editBoxNSDKLan1.Focus();
            //            //return false;
            //        }
            //    }
            //}
            //float SL = float.Parse(editBoxNSDKLan1.Text) * float.Parse(editBoxDienTich.Text);
            //editBoxSLDKLan1.Text = SL.ToString();
        }

        private void editBoxNSDKLan2_TextChanged(object sender, EventArgs e)
        {
            //float Test = 0;
            //if (string.IsNullOrEmpty(editBoxNSDKLan2.Text))
            //{
            //    editBoxNSDKLan2.Text = "0";
            //}
            //else
            //{
            //    if (!float.TryParse(editBoxNSDKLan2.Text, out Test))
            //    {
            //        MessageBox.Show("Năng suất dự kiến lần 2 phải nhập kiểu số", "Thông báo");
            //        editBoxNSDKLan2.Focus();
            //        //return false;
            //    }
            //    else
            //    {
            //        if (float.Parse(editBoxNSDKLan2.Text) < 0)
            //        {
            //            MessageBox.Show("Năng suất dự kiến lần 2 phải nhập lớn hơn 0", "Thông báo");
            //            editBoxNSDKLan2.Focus();
            //            //return false;
            //        }
            //    }
            //}
            //float SL = float.Parse(editBoxNSDKLan2.Text) * float.Parse(editBoxDienTich.Text);
            //editBoxSLDKLan2.Text = SL.ToString();
        }

        private void HopDongUIDCombobox_TextChanged(object sender, EventArgs e)
        {
            if (HopDongUIDCombobox.Text.Length == 6)
            {
                uiComboBox1.SelectedValue = HopDongUIDCombobox.SelectedValue;
                if (IsAdd && HopDongUIDCombobox.Text != "")
                {
                    //maThuaRuongTextBox.Text = GetMaThuaRuong();
                    LayXa();

                }
            }
            //if (HopDongUIDCombobox.Text.Length > 6)
            //    MessageBox.Show("Mã hợp đồng chỉ có 6 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (uiButtonSave.Enabled)
                        {
                            uiButtonSave_Click(null, null);
                        }
                        break;

                    case Keys.F8:
                        if (uiButtonNew.Enabled)
                        { uiButtonNew_Click(null, null); }

                        break;

                    case Keys.F9:
                        if (uiButtonEdit.Enabled)
                        { uiButtonEdit_Click(null, null); }
                        break;
                    case Keys.Enter:
                        try
                        {
                            SendKeys.Send("{TAB}");
                            
                            //   btGhiNhan_Click(null, null);
                        }
                        catch { }
                        break;   
                    case Keys.Escape:
                        if (uiButtonCancel.Enabled)
                        {
                            uiButtonCancel_Click(null, null);
                        }
                        break;
                    case Keys.Delete:
                        if (uiButtonDelete.Enabled)
                        {
                            uiButtonDelete_Click(null, null);
                        }
                        break;
                    case Keys.F10:
                        uiButtonClose_Click(null, null);
                        break;

                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void HopDongUIDCombobox_Leave(object sender, EventArgs e)
        {
            if (HopDongUIDCombobox.Text != "")
            {
                try
                {
                    string strSQL;
                    string strMaxID = "";
                    if (HopDongUIDCombobox.Text.Length == 6)
                    {
                        strSQL = "SELECT Count(ID) FROM tbl_HopDong WHERE ParentID=0 AND MaHopDong=N'" + HopDongUIDCombobox.Text + "'";
                        strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                        if (strMaxID == "0")
                        {
                            MessageBox.Show("Mã chủ hợp đồng không đúng", "Thông báo");
                            HopDongUIDCombobox.Focus();
                        }
                        else
                        {
                            string str;
                            strSQL = "SELECT ID FROM tbl_HopDong WHERE ParentID=0 AND MaHopDong=N'" + HopDongUIDCombobox.Text + "'";
                            strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);

                            strSQL = "Select Count(ID) From tbl_Thuaruong Where HopDongID =" + strMaxID + " AND TrangThaiDangKy =1";
                            str = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                            if (str == "0")
                            {

                                //maThuaRuongTextBox.Text = GetMaThuaRuong();
                                //soBanDieuTraTextBox.Focus(); 
                                //xuDongTextBox.Focus();
                                uiComboBox1.SelectedValue = long.Parse(strMaxID);
                                HopDongUIDCombobox.SelectedValue = long.Parse(strMaxID);
                            }
                            else
                            {
                                if (MessageBox.Show("Chủ hợp đồng này đã đăng ký diện tích hợp đồng " + str + " lần!\nChọn OK để tiếp tục hoặc Cancel để thoát ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                                {
                                    //maThuaRuongTextBox.Text = GetMaThuaRuong();
                                    //soBanDieuTraTextBox.Focus(); 
                                    //xuDongTextBox.Focus();
                                    uiComboBox1.SelectedValue = long.Parse(strMaxID);
                                    HopDongUIDCombobox.SelectedValue = long.Parse(strMaxID);
                                }
                                else
                                {
                                    HopDongUIDCombobox.SelectedValue = null;
                                    uiComboBox1.SelectedValue = null;
                                    HopDongUIDCombobox.Focus();
                                }

                                //HopDongUIDCombobox.Focus();
                            }
                        }
                        if (IsAdd)
                        {
                            LayXa();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã chủ hợp đồng phải đúng 6 ký tự\nBạn hãy kiểm tra lại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        HopDongUIDCombobox.Focus();
                    }

                }
                catch { }
            }
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

        //private void trangThaiCheckBox_Leave(object sender, EventArgs e)
        //{
        //    Control textbox = (Control)sender;
        //    textbox.BackColor = Color.White;
        //    editBoxDTChatGiong.Focus();
        //}

        private void editBoxNSDKLan2_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            uiButtonSave.Focus();
        }
        private void LayXa()
        {
            try
            {
                string strSQL;
                string strTenXa = "";
                string strTramid = "";
                if (HopDongUIDCombobox.Text != "")
                {
                    // load ra xứ đồng
                    strSQL = "SElect Ten from tbl_Xa where ID IN (Select XaID from tbl_thon where ID In (SELECT ThonID FROM tbl_HopDong WHERE ID=" + HopDongUIDCombobox.SelectedValue + "))";
                    strTenXa = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                    
                    if (strTenXa != "")
                    { xuDongTextBox.Text = strTenXa; }

                    // load ra trạm nông vụ
                    strSQL = "select id from tbl_tramnongvu where id in (select cumid from tbl_xa where id in (select xaid from tbl_thon where id in (select thonid from tbl_hopdong where id ="+ HopDongUIDCombobox.SelectedValue +")))";
                    strTramid = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);

                    if (strTramid != "")
                    { TramNongVu.SelectedValue = strTramid; }
                }
            }
            catch { }
        
        }

        private void editBoxDienTich_Enter(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.SkyBlue;
        }

        private void editBoxDienTich_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;

            
            if (textbox.GetType().ToString() == "Janus.Windows.EditControls.UIComboBox")
            {
                long a = 0;
                bool bol = false;
                try
                {
                    bol = long.TryParse(textbox.Text, out a);
                }
                catch
                {
                    bol = false;
                }

                if (bol == true)
                {
                    MessageBox.Show("Bạn đã nhập sai dữ liệu này,hãy nhập lại!", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textbox.Focus();
                }
            }

            //if (soBanDieuTraTextBox.Text != "")
            //{
                //if (IsExistingSBDT(IsAdd, soBanDieuTraTextBox.Text))
                //{
                //    MessageBox.Show("Nhập trùng số bản điều tra", "Thông báo");
                //    soBanDieuTraTextBox.Focus();
                //    //return false;
                //}
            //}
        }
        private void editBox_Enter(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.SkyBlue;
            //textbox.Text = Color.White;
        }

        private void uiComboBoxTinhtrang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
            //   // dienTichChatGiongTextBox.Focus();
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");

            //    //editBoxDTChatGiong
            }
        }

        private void kieuTrongDangKyIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kieuTrongDangKyIDUIComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void uiComboBoxKieuTrong_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            
            //if ((uiComboBoxKieuTrong.SelectedValue.ToString() == "0") || (uiComboBoxKieuTrong.SelectedValue == null))
            //    MessageBox.Show("");
            //long KieuTrongID = long.Parse(uiComboBoxKieuTrong.SelectedValue.ToString());
            if (uiComboBoxKieuTrong.Text != "")
            {
                string strSQL = "Select * from tbl_KieuTrong where Ten =N'" + uiComboBoxKieuTrong.Text.Trim() + "'";
                try
                {
                    DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Bạn nhập sai kiểu trồng!", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        uiComboBoxKieuTrong.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Bạn nhập sai kiểu trồng!", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    uiComboBoxKieuTrong.Focus();
                }
            }
        }

        private void soBanDieuTraTextBox_Leave(object sender, EventArgs e)
        {
            //Control textbox = (Control)sender;
            //textbox.BackColor = Color.White;

            //if (soBanDieuTraTextBox.Text != "")
            //{
            //    if (IsExistingSBDT(IsAdd, soBanDieuTraTextBox.Text))
            //    {
            //        MessageBox.Show("Nhập trùng số bản điều tra", "Thông báo");
            //        soBanDieuTraTextBox.Focus();
            //        //return false;
            //    }
            //}
        }

        private void uiComboBoxGiongMia_Enter(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.SkyBlue;
            maThuaRuongTextBox.BackColor = Color.SkyBlue;
        }

        private void uiComboBoxGiongMia_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            maThuaRuongTextBox.BackColor = Color.White;
        }

       
    }
}