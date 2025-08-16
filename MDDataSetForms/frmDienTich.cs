using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using MDSolution;

namespace DACASUCO.MDDataSetForms
{
    public partial class frmDienTich : Form
    {
        public Boolean cancel = false;
        public long _ID = 0;
        private int IDTR = 0;
        private long IDCM = 0;
        private Boolean IsAdd = true;
        private string MaHDDT = "";
        private string HoTen = "";
        private string NQL="";
        private string LoaiHD="";
        private string ThoiHan="";
        private string VuTrong="";
        private string MaCM = "";
        public frmDienTich()
        {
            InitializeComponent();
        }
        public frmDienTich(long ID, Boolean IsAddNew,long ID_CM)
        {
            InitializeComponent();
            IDTR=int.Parse(ID.ToString());
            IDCM= ID_CM;
            IsAdd = IsAddNew;
            LoadHDDT();
            txtMaCM.Text = MaCM;
            txtVuTrong.Text = VuTrong;
            txtHDID.Text = IDCM.ToString();
            txtVT.Text = MDSolution.DACASUCO_App.VuTrongID.ToString();
            if (IsAdd)
            {
                txtHoTen.Text = HoTen;
                
            }
            else
            {
                cbMaHDDT.Text = MaHDDT;
                txtNguoiQL.Text = NQL;
                txtThoiHanHD.Text = ThoiHan;
                txtHoTen.Text = HoTen;
                txtLoaiHD.Text = LoaiHD;
                this.tbl_ThuaRuongTableAdapter.FillByID(this.dienTichDataSet.tbl_ThuaRuong, IDTR);
               
            }
           
        }

        private string GetHDDT()
        {
            string sql = "Select MaHDDT from tbl_ThuaRuong Where ID=" + IDTR.ToString();
            return MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null);
        }
        private void LoadHDDT()
        {
            string sql = "Select * from V_HDDT Where HopDongID=" + IDCM.ToString() +"AND VuTrongID="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null,null);
            if (ds.Tables[0].Rows.Count>0)
            {
                HoTen = ds.Tables[0].Rows[0]["HoTen"].ToString();
                MaCM = ds.Tables[0].Rows[0]["MaHopDong"].ToString();
                VuTrong = ds.Tables[0].Rows[0]["VuTrong"].ToString();
                DataRow dr = ds.Tables[0].NewRow();
                dr["ID"] = 0;
                dr["MaHDDT"] = "";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cbMaHDDT.DataSource = ds.Tables[0];
                cbMaHDDT.ValueMember = "ID";
                cbMaHDDT.DisplayMember = "MaHDDT";
                if (!IsAdd)
                {
                    MaHDDT = GetHDDT();
                    sql = "Select * from V_HDDT Where MaHDDT=N'" + MaHDDT + "'";
                    ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    NQL = ds.Tables[0].Rows[0]["NQL"].ToString();
                    ThoiHan = ds.Tables[0].Rows[0]["ThoiHanHD"].ToString();
                    LoaiHD = ds.Tables[0].Rows[0]["LoaiHD"].ToString();
                }
            }
            else
            {
                return;
            }
          
        }
        
        private void frmDienTich_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_HopDongDauTu' table. You can move, or remove it, as needed.
            //this.tbl_HopDongDauTuTableAdapter.Fill(this.dienTichDataSet.tbl_HopDongDauTu);
            // TODO: This line of code loads data into the 'dienTichDataSet.LoaiHopDong' table. You can move, or remove it, as needed.
           // this.loaiHopDongTableAdapter.Fill(this.dienTichDataSet.LoaiHopDong);
            // TODO: This line of code loads data into the 'dienTichDataSet.sys_User' table. You can move, or remove it, as needed.
           // this.sys_UserTableAdapter.Fill(this.dienTichDataSet.sys_User);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_Xa' table. You can move, or remove it, as needed.
            this.tbl_XaTableAdapter.Fill(this.dienTichDataSet.tbl_Xa);
            
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
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_Thon' table. You can move, or remove it, as needed.          
           this.tbl_ThonTableAdapter.Fill(this.dienTichDataSet.tbl_Thon);          
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_BaiTapKet' table. You can move, or remove it, as needed.
           this.tbl_BaiTapKetTableAdapter.Fill(this.dienTichDataSet.tbl_BaiTapKet);
            
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_LoaiDat' table. You can move, or remove it, as needed.
            this.tbl_LoaiDatTableAdapter.Fill(this.dienTichDataSet.tbl_LoaiDat);
    
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_HopDong' table. You can move, or remove it, as needed.
            this.tbl_HopDongTableAdapter.Fill(this.dienTichDataSet.tbl_HopDong);
            tbl_KieuTrongTableAdapter.Fill(this.dienTichDataSet.tbl_KieuTrong);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_ThuaRuong' table. You can move, or remove it, as needed.
            TruyenDuLieu(true);
            
            //_MaHDDT = cbMaHDDT.Text;
            if (IsAdd)
            {
                uiButtonNew_Click(null, null);
           
            }
            else
            {
                uiButtonEdit_Click(null, null);
                //xuDongTextBox.Focus();
                _ID = long.Parse(iDTextBox.Text);

            }
        }

        private void uiButtonNew_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_hddt.Text = "";
                
                this.tbl_ThuaRuongBindingSource.AddNew();
                
                IsAdd = true;
                iDTextBox.Text = GetID();
                txtHDID.Text = IDCM.ToString();
                ckBenkhac.Checked = false;
                ///textBoxMaHDDT.Text = "";
                if (IDTR > 0)
                {
                   // HopDongUIDCombobox.SelectedValue = long.Parse(ID.ToString());
                    maThuaRuongTextBox.Text = GetMaThuaRuong();
                    //Thon.ReadOnly = true;
                    //uiCbo_BaiBocXep.ReadOnly = true;
                    //string strXaID = "";
                    //strXaID = LayXa();
                    //loadCboBaiBocXep(strXaID
                }
                //cbVuTrong.SelectedValue = MDSolution.DACASUCO_App.VuTrongID.ToString();
                //textBoxMaHDDT.Text = DACASUCO_App.strMaHDDT;
                TruyenDuLieu(true);
                uiButtonDelete.Enabled = false;
                uiButtonNew.Enabled = false;
                uiButtonEdit.Enabled = false;
                uiButtonSave.Enabled = true;
                uiButtonCancel.Enabled = true;
                uiGroupBox1.Enabled = true;
                uiGroupBox2.Enabled = true;
                uiGroupBox3.Enabled = true;
              
            }catch{}
            
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
                    MaxID = long.Parse(strMaxID);
                else
                    MaxID = 1;
                
                return MaxID.ToString();
            }
            catch { return ""; }
        }
        private string GetID_HDDT()
        {

            try
            {
                long MaxID = 0;
                string strMaxID = "";
                string strSQL = "select * As Max from tbl_HopDongDauTu";
                strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (strMaxID != "")
                    MaxID = long.Parse(strMaxID);
                else
                    MaxID = 1;

                return MaxID.ToString();
            }
            catch { return ""; }
        }
        private int ThuaRuong_HDDT(string MaHDDT)
        {
            int count = 0;
            try
            {
               
                string strCount = "";
                string strSQL = "select count(*)  from tbl_ThuaRuong where MaHDDT='" + MaHDDT +"'";
                strCount = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (strCount != "")
                    count = int.Parse(strCount);
                else
                    count = 0;
                return count;
            }
            catch { return 0; }
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
                txtHDID.Text = IDCM.ToString();
               // editBoxNSDKLan1.Text = nangSuatDuKienTextBox.Text;
               // editBoxNSDKLan2.Text = nangSuatDuKien1TextBox.Text;
              //  editBoxSLDKLan1.Text = sanLuongDuKienTextBox.Text;
               // editBoxSLDKLan2.Text = sanLuongDuKien1TextBox.Text;
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
                //nangSuatDuKienTextBox.Text = editBoxNSDKLan1.Text;
                //nangSuatDuKien1TextBox.Text = editBoxNSDKLan2.Text;
               // sanLuongDuKienTextBox.Text = editBoxSLDKLan1.Text;
                //sanLuongDuKien1TextBox.Text = editBoxSLDKLan2.Text;
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
           // HopDongUIDCombobox.Enabled = false;
            soBanDieuTraTextBox.Focus();
            IsAdd = false;
        }

        private void uiButtonDelete_Click(object sender, EventArgs e)
        {
            string message;
            if (iDTextBox.Text != "")
            {

                if (ThuaRuong_HDDT(cbMaHDDT.Text) == 1)
                {
                    if (MessageBox.Show("Đây là thửa ruộng duy nhất trong Hợp đồng đầu tư! Bạn có muốn Xóa cả hợp đồng đầu tư không?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.tbl_HopDongDauTubindingSource.RemoveCurrent();
                        this.tbl_ThuaRuongBindingSource.RemoveCurrent();
                        DoSave();
                    }
                    else
                    {
                        this.tbl_ThuaRuongBindingSource.RemoveCurrent();
                        DoSave();
                    }
                }
                else
                {
                    message = String.Format("Bạn có chắc chắn muốn xóa thửa ruộng này ?");

                    if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.tbl_ThuaRuongBindingSource.RemoveCurrent();
                        DoSave();
                        //this.tbl_DauTuTableAdapter.Fill(this.dauTuDataSet.tbl_DauTu);
                    }
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
                string a = dienTichTextBox.Text;
                //if (IsAdd)
                //{
                //    this.tbl_ThuaRuongBindingSource.EndEdit();
                //    this.tbl_ThuaRuongTableAdapter.InsertQuery(int.
                //}
                this.tbl_ThuaRuongBindingSource.EndEdit();
                this.tbl_ThuaRuongTableAdapter.Update(this.dienTichDataSet.tbl_ThuaRuong);
                
            }
            catch 
            { 
                MessageBox.Show("Có lỗi khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
           // uiComboBoxMaHDDT.TextChanged +=new EventHandler(uiComboBoxMaHDDT_TextChanged);
            if (tabControl1.SelectedTab == tabPage1)
            {
                trangThaiDangKyTextBox.Text = "0";
                uiComboBoxTinhtrang.SelectedValue = 4;
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

                    if (tabControl1.SelectedTab == tabPage1)
                    {
                         
                        if (!SaveHDDT())
                        {
                            return;
                        }
                        if (!SaveThuaRuong())
                        {
                            return;
                        }

                        if (IsAdd == true) // truyen ID
                        {
                            iDTextBox.Text = GetID();
                        }
                        txtHDID.Text = IDCM.ToString();
                        DoSave();
                        //DACASUCO_App.strMaHDDT = textBoxMaHDDT.Text;
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
                            //ID = int.Parse(HopDongUIDCombobox.SelectedValue.ToString());
                            MessageBox.Show("Bạn đã thêm mới thành công !", "DACSUCO");
                            //uiButtonNew_Click(null, null);
                            //HopDongUIDCombobox.SelectedValue = (long)this.ID.ToString();
                            //uiComboBox1.SelectedValue = null;
                            this.Close();
                        }
                        else
                        {
                            if (!cancel)
                            {
                                MessageBox.Show("Bạn đã sửa lại thành công !", "DACASUCO");
                                this.Close();
                            }
                        }

                    }
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi khi lưu dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void uiButtonClose_Click(object sender, EventArgs e)
        {
            this.tbl_HopDongDauTubindingSource.CancelEdit();
            this.tbl_ThuaRuongBindingSource.CancelEdit();         
            this.Hide();
        }
        private bool SaveThuaRuong()
        {
            try
            {
                float Test = 0;                   
                    
                
                //if (string.IsNullOrEmpty(HopDongUIDCombobox.Text))
                //{
                //    MessageBox.Show("Cho biết mã chủ mía", "Thông báo");
                //    HopDongUIDCombobox.Focus();
                //    return false;
                //}
                if (string.IsNullOrEmpty(soBanDieuTraTextBox.Text) && tabControl1.SelectedIndex==0)
                {
                    MessageBox.Show("Cho biết số bản điều tra", "Thông báo");
                    soBanDieuTraTextBox.Focus();
                    return false;}
                else{
                    if (IsExistingSBDT(IsAdd, soBanDieuTraTextBox.Text))
                    {
                        MessageBox.Show("Nhập trùng số bản điều tra", "Thông báo");
                        soBanDieuTraTextBox.Focus();
                        return false;
                    }
                }
               
                if (string.IsNullOrEmpty(TramNongVu.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Cho biết thửa ruộng thuộc trạm Nguyên liệu nào", "Thông báo");
                    TramNongVu.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(editBoxDienTich.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Bạn chưa nhập diện tích", "Thông báo");
                    editBoxDienTich.Focus();
                    return false;
                }
                else
                {
                    if (!float.TryParse(editBoxDienTich.Text, out Test) && tabControl1.SelectedIndex == 0)
                    {
                        MessageBox.Show("Diện tích phải nhập kiểu số", "Thông báo");
                        editBoxDienTich.Focus();
                        return false;
                    }
                    else
                    {
                        if (float.Parse(editBoxDienTich.Text) <= 0 && tabControl1.SelectedIndex == 0)
                        {
                            MessageBox.Show("Diện tích phải lớn hơn 0", "Thông báo");
                            editBoxDienTich.Focus();
                            return false;
                        }
                    }
                }
                if (string.IsNullOrEmpty(uiComboBoxLoaiDat.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Bạn chưa nhập loại đất", "Thông báo");
                    uiComboBoxLoaiDat.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(uiComboBoxGiongMia.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Cho biết giống mía trồng", "Thông báo");
                    uiComboBoxGiongMia.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(uiComboBoxRaiVu.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Cho biết mía rải vụ nào", "Thông báo");
                    uiComboBoxRaiVu.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(uiComboBoxMucDich.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Xác định rõ mục đích trồng", "Thông báo");
                    uiComboBoxMucDich.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(ngayTrongCalendarCombo.Text) && tabControl1.SelectedIndex == 0)
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
                if (string.IsNullOrEmpty(uiComboBoxTinhtrang.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Bạn chưa nhập tình trạng thửa ruộng", "Thông báo");
                    uiComboBoxTinhtrang.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(uiCbo_BaiBocXep.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Bạn chưa chọn Bến mía", "Thông báo");
                    uiCbo_BaiBocXep.Focus();
                    return false;
                }



                float nsdk1 = 1;
                float.TryParse(editBoxNSDKLan1.Text, out nsdk1);
                float SL = nsdk1* float.Parse(editBoxDienTich.Text);
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

        private bool SaveHDDT()
        {
            try
            {
                if (string.IsNullOrEmpty(cbMaHDDT.Text.Trim()))
                {
                    MessageBox.Show("Cho biết mã Hợp đồng đầu tư", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    cbMaHDDT.Focus();
                    return false;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
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
                    this.tbl_HopDongDauTubindingSource.CancelEdit();
                    this.tbl_ThuaRuongBindingSource.CancelEdit();
                    uiButtonNew_Click(null, null);
                }
                else
                {
                    this.tbl_HopDongDauTubindingSource.CancelEdit();
                    this.tbl_ThuaRuongBindingSource.CancelEdit();

                    this.tbl_HopDongDauTuTableAdapter.FillByHopDongID(this.dienTichDataSet.tbl_HopDongDauTu,int.Parse(txtMaCM.Text));
                    this.tbl_ThuaRuongTableAdapter.FillByID(this.dienTichDataSet.tbl_ThuaRuong, IDTR); 
                }
            }
            catch
            {

            }
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
        private string GetMaThuaRuong()
        {
            try
            {
                //string strXaID = "";

                string strSQL;
                string strMaxID = "";
                if (txtMaCM.Text != "")
                {
                    strSQL = "SELECT Count(ID) FROM tbl_ThuaRuong WHERE (HopDongID=" + IDCM.ToString() + " AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + ") AND (TrangThaiDangKy =0 Or TrangThaiDangKy is Null)";
                    strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                    if (strMaxID == "") strMaxID = "0";
                    int intMaxID = int.Parse(strMaxID);
                    intMaxID++;
                    return txtMaCM.Text + "-" + intMaxID.ToString();
                }
                else { return ""; }
            }
            catch
            {
                return "";
            }


        }
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
                string SQL = " select ID from tbl_ThuaRuong where MaThuaRuong = '" + ContractCode + "'";
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
        private bool IsExistingHDDT(string MaHDDT)
        {
                string SQL = " select Count(*) from tbl_HopDongDauTu where MaHDDT = '" + MaHDDT + "'";
                string ret = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
        }
        private bool IsExistingSBDT(bool isAddnew, string ContractCode)
        {
            if (isAddnew)
            {
                string SQL = " select Count(*) from tbl_ThuaRuong where SoBanDieuTra = N'" + ContractCode + "' and vutrongid =" +  MDSolution.DACASUCO_App.VuTrongID;
                string ret = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else
            {
                string SQL = " select ID from tbl_ThuaRuong where SoBanDieuTra = N'" + ContractCode + "' and vutrongid =" + MDSolution.DACASUCO_App.VuTrongID;
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

        private string Load_PhanQuyen_CacTramID()
        {
            string strSQL = "Select CumID From sys_Roles_User_Cum Where UserID=" + DACASUCO_App.User.ID.ToString();
            DataSet ds1 = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            string str = "";
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                        str += ds1.Tables[0].Rows[i]["CumID"].ToString();
                    else
                        str += "," + ds1.Tables[0].Rows[i]["CumID"].ToString();
                }
            }
            return str;
        }

       

        private void loadCboBaiBocXep(string XaID, bool them)
        {
            if (XaID!="")
            {
                string strSQL = "";
                if (!them)
                {
                     strSQL = "Select ID,TenBai from tbl_BaiTapKet Where XaID =" + XaID;
                }
                else
                {
                     strSQL = "Select ID,TenBai from tbl_BaiTapKet";
                }
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                uiCbo_BaiBocXep.DataSource = ds.Tables[0];
                uiCbo_BaiBocXep.DisplayMember = "TenBai";
                uiCbo_BaiBocXep.ValueMember = "ID";
            }
        }

       
        private void editBoxNSDKLan2_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            uiButtonSave.Focus();
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

            //cbVuTrong.Tag = cbVuTrong.SelectedValue;

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

       
       
        private void uiComboBoxKieuTrong_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
          
        }

        private void soBanDieuTraTextBox_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;

            if (soBanDieuTraTextBox.Text != "")
            {
                if (IsExistingSBDT(IsAdd, soBanDieuTraTextBox.Text))
                {
                    MessageBox.Show("Nhập trùng số bản điều tra", "Thông báo");
                    soBanDieuTraTextBox.Focus();
                    //return false;
                }
            }
        }

      

        private void baiTapKetIDEditBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (baiTapKetIDEditBox.Text != "")
                {
                    uiCbo_BaiBocXep.SelectedValue = long.Parse(baiTapKetIDEditBox.Text);
                }
                else
                {
                    uiCbo_BaiBocXep.SelectedValue = null;
                }
            }
            catch
            { }
        }
        
       

        private void TramNongVu_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Thon.ReadOnly = false;
            //if (TramNongVu.SelectedIndex>0)
            //{
            //    this.tbl_XaTableAdapter.FillByTramNongVu(this.dienTichDataSet.tbl_Xa, (int)TramNongVu.SelectedValue);
            //}
            //string qr = "select ID,Ten,Maxa from tbl_Xa where CumID=" + TramNongVu.SelectedIndex.ToString();
            //DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(qr, null, null);
            //Thon.DataSource = ds.Tables[0];
            //Thon.DisplayMember = "Ten";
            //Thon.ValueMember = "MaXa";
            
        }

        private void Thon_SelectedIndexChanged(object sender, EventArgs e)
        {
           loadCboBaiBocXep(Thon.SelectedValue.ToString(),ckBenkhac.Checked);
        }
      
        private void TramNongVu_Leave(object sender, EventArgs e)
        {
            Thon.ReadOnly = false;
        }

        private void Thon_Leave(object sender, EventArgs e)
        {
            uiCbo_BaiBocXep.ReadOnly = false;
        }

             

        private void uiButtonDeleteHDDT_Click(object sender, EventArgs e)
        {
            if (ThuaRuong_HDDT(cbMaHDDT.Text) > 0)
            {
                if (MessageBox.Show("Hợp đồng đầu tư đang có thửa ruộng. Nếu xóa sẽ xóa cả thửa ruộng - Đầu tư - Công nợ!"+"\n"+" Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    //this.tbl_ThuaRuongTableAdapter.DeleteQueryByHDDT(uiComboBoxMaHDDT.Text);
                    //this.tbl_HopDongDauTubindingSource.RemoveCurrent();
                    //Xoa Nợ cũ
                    string sql = "select MAHDDT from tbl_NoCuChuHopDong where MaHDDT='" + cbMaHDDT.Text + "'";
                    DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        sql = "Delete tbl_NoCuChuHopDong set MaHDDT='" + cbMaHDDT.Text + "'";
                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    }
                    //Xóa Đầu tư
                    sql = "select MAHDDT from tbl_DauTu where MaHDDT='" + cbMaHDDT.Text + "'";
                   ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        sql = "Delete tbl_DauTu set MaHDDT='" + cbMaHDDT.Text + "'";
                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    }
                    //DoSave();
                }
            }
        }

        private void TramNongVu_SelectedValueChanged(object sender, EventArgs e)
        {
            string qr = "select ID, Ten from tbl_Xa where CumID=" + TramNongVu.SelectedValue.ToString();
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(qr, null, null);
            Thon.DataSource = ds.Tables[0];
            Thon.DisplayMember = "Ten";
            Thon.ValueMember = "ID";
        }

        private void ckBenkhac_CheckedChanged(object sender, EventArgs e)
        {
            if(Thon.Text!="")
            {
            loadCboBaiBocXep(Thon.SelectedValue.ToString(), ckBenkhac.Checked);
            }
        }

        private void cbMaHDDT_Enter(object sender, EventArgs e)
        {

            cbMaHDDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
        }

        private void cbMaHDDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaHDDT.SelectedIndex > 0)
            {
                string sql = "Select * from V_HDDT Where ID=" + cbMaHDDT.SelectedValue.ToString();
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                txtLoaiHD.Text = ds.Tables[0].Rows[0]["LoaiHD"].ToString();
                txtNguoiQL.Text = ds.Tables[0].Rows[0]["NQL"].ToString();
                txtThoiHanHD.Text = ds.Tables[0].Rows[0]["ThoiHanHD"].ToString();
                txtMaHDDT.Text = ds.Tables[0].Rows[0]["MaHDDT"].ToString();
                txtHDID.Text = IDCM.ToString();
                txtUser.Text = ds.Tables[0].Rows[0]["UserID"].ToString();
                txtVT.Text = ds.Tables[0].Rows[0]["VuTrongID"].ToString();
            }
        }        

         
    }
}