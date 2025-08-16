using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using System.Data.OleDb;
using MDSolution;

namespace DACASUCO.MDDataSetForms
{
    public partial class frmDauTu : Form
    {
        public long _ID = 0;
        private int ID = 0;
        
        private Boolean IsAdd = true;
        public frmDauTu()
        {
            InitializeComponent();

        }
        public frmDauTu(long id, Boolean IsAddNew)
        {
             InitializeComponent();       
             ID = int.Parse(id.ToString());
            _ID = long.Parse(ID.ToString());
            IsAdd = IsAddNew;
            LoadCBLoaiDT();
            if (IsAdd)
            {
                this.tbl_DauTuTableAdapter.Fill(this.dauTuDataSet.tbl_DauTu);

                string QR = "SELECT distinct dbo.tbl_HopDongDauTu.MaHDDT,dbo.tbl_Hopdong.MaHopdong,dbo.tbl_hopdong.HoTen FROM dbo.tbl_HopDong INNER JOIN dbo.tbl_HopDongDauTu ON dbo.tbl_HopDong.ID = dbo.tbl_HopDongDauTu.HopDongID Where tbl_hopdong.ID=" + ID.ToString() + " AND tbl_HopDongDauTu.VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                    DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(QR, null, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtChuMia.Text = ds.Tables[0].Rows[0]["MaHopdong"].ToString();
                        txtHoVaTen.Text = ds.Tables[0].Rows[0]["HoTen"].ToString();
                        TaoCombo_MaHDDT(ID);
                    }
                    else
                {
                    MessageBox.Show("Chưa nhập Hợp đồng đầu tư nào cho Chủ mía trong vụ trồng này!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                
            }
            else
            {                
                this.tbl_DauTuTableAdapter.FillByID(this.dauTuDataSet.tbl_DauTu, ID);
                SetDataSource_CboChungLoaiDT();
                string SQL = "Select LoaiHinhDauTuID from tbl_DanhMucDauTu Where ID=(Select DanhMucDauTuID from tbl_DauTu Where ID =" + id.ToString() + ")";
                string str = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if (str !="")
                    uiCboChungLoaiDauTu.SelectedValue = long.Parse(str);
                string qr = "Select mahddt,SoChungTu,LoaiDT from tbl_dautu where id= " + id.ToString();
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(qr, null, null);
                cbMaHDDT.Text=ds.Tables[0].Rows[0]["MaHDDT"].ToString();
                soChungTuTextBox.Text = ds.Tables[0].Rows[0]["SoChungTu"].ToString();
                try
                {
                    cbLoaiDT.SelectedValue = long.Parse(ds.Tables[0].Rows[0]["LoaiDT"].ToString());
                }
                catch
                {
                    cbLoaiDT.Text = "";
                }
                //string sql = "select ID from tbl_Hopdong where MaHopDong=" + "'"+txtChuMia.Text+"'";
                //DataSet ma = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                //ID = int.Parse(ma.Tables[0].Rows[0]["ID"].ToString());
            }
           
                  
        }
        private void LoadCBLoaiDT()
        {
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery("Select * from tbl_LHDT", null, null);
            cbLoaiDT.DataSource = ds.Tables[0];
            cbLoaiDT.ValueMember = "ID";
            cbLoaiDT.DisplayMember = "TenGoi";
        }
        private void TaoCombo_MaHDDT(int ID)
        {
                string QR = "SELECT distinct HopdongID, MaHDDT FROM tbl_HopDongDauTu  Where HopdongId=(Select ID from tbl_hopdong where ID=" + ID.ToString() + ") AND VuTrongID="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(QR, null, null);
                cbMaHDDT.DataSource = ds.Tables[0];
                cbMaHDDT.DisplayMember = "MaHDDT";
                cbMaHDDT.ValueMember = "HopDongID";
         }

        private void SetDataSource_CboChungLoaiDT()
        {
            string SQL = "Select ID,Ten from tbl_LoaiHinhDauTu";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(SQL, null, null);
            uiCboChungLoaiDauTu.DataSource = ds.Tables[0];
            uiCboChungLoaiDauTu.DisplayMember = "Ten";
            uiCboChungLoaiDauTu.ValueMember = "ID";
        }
       public string GetSCT()
        {
            string sql = "Select (MAX(SoChungTu)+1) from tbl_DauTu";
            return MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null);
        }

     private void frmDauTu_Load(object sender, EventArgs e)
     {
         // TODO: This line of code loads data into the 'dienTichDataSet.sys_User' table. You can move, or remove it, as needed.
       //  this.sys_UserTableAdapter.Fill(this.dienTichDataSet.sys_User);
         // TODO: This line of code loads data into the 'dauTuDataSet.tbl_HopDongDauTu' table. You can move, or remove it, as needed.
        // this.tbl_HopDongDauTuTableAdapter.Fill(this.dauTuDataSet.tbl_HopDongDauTu);
         // TODO: This line of code loads data into the 'dauTuDataSet.LoaiHopDong' table. You can move, or remove it, as needed.
      //   this.loaiHopDongTableAdapter.Fill(this.dauTuDataSet.LoaiHopDong);
         // TODO: This line of code loads data into the 'dauTuDataSet.tbl_LoaiHinhDauTu' table. You can move, or remove it, as needed.
            this.tbl_LoaiHinhDauTuTableAdapter.Fill(this.dauTuDataSet.tbl_LoaiHinhDauTu);
         

            // TODO: This line of code loads data into the 'dauTuDataSet.tbl_HopDong' table. You can move, or remove it, as needed.
             //this.tbl_HopDongTableAdapter.Fill(this.dauTuDataSet.tbl_HopDong);            
            // TODO: This line of code loads data into the 'dauTuDataSet.tbl_VuTrong' table. You can move, or remove it, as needed.
            //this.tbl_VuTrongTableAdapter.Fill(this.dauTuDataSet.tbl_VuTrong);            
            // TODO: This line of code loads data into the 'dauTuDataSet.tbl_DonViCungUngVatTu' table. You can move, or remove it, as needed.
            this.tbl_DonViCungUngVatTuTableAdapter.Fill(this.dauTuDataSet.tbl_DonViCungUngVatTu);
            // TODO: This line of code loads data into the 'dauTuDataSet.tbl_DanhMucDauTu' table. You can move, or remove it, as needed.
            this.tbl_DanhMucDauTuTableAdapter.Fill(this.dauTuDataSet.tbl_DanhMucDauTu);
            // TODO: This line of code loads data into the 'dauTuDataSet.tbl_DauTu' table. You can move, or remove it, as needed.
            
            TruyenDuLieu(true);
            if (IsAdd)
            {
                uiButtonNew_Click(null, null);
               // HopDongUIDCombobox.Focus();
               // soChungTuTextBox.Text = GetSCT();
            }
            else
            {
                _ID = long.Parse(iDTextBox.Text);       
                uiButtonEdit_Click(null, null);
                //donViCungUngVatTuUIDComboBox.Focus();

                //SetDataSource_CboChungLoaiDT();

                //string SQL = "Select LoaiHinhDauTuID from tbl_DanhMucDauTu Where ID=(Select DanhMucDauTuID from tbl_DauTu Where ID =" + ID.ToString() + ")";
                //string str = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(SQL, null, null);
                //uiCboChungLoaiDauTu.SelectedValue = long.Parse(str);
            }
            
        }

        private void uiButtonClose_Click(object sender, EventArgs e)
        {
            this.tbl_DauTuBindingSource.EndEdit();
            this.tbl_DauTuBindingSource.CancelEdit();
            this.Hide();
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                uiButtonNew.Enabled = false;
                uiButtonEdit.Enabled = false;
                uiButtonSave.Enabled = true;
                uiButtonCancel.Enabled = true;
                uiButtonDelete.Enabled = true;
                uiGroupBox1.Enabled = true;
                uiGroupBox2.Enabled = true;
                
                if (IsAdd)
                {
                    this.tbl_DauTuBindingSource.CancelEdit();
                    uiButtonNew_Click(null, null); 
                }
                else
                { this.tbl_DauTuBindingSource.CancelEdit();
                    this.tbl_DauTuTableAdapter.FillByID(this.dauTuDataSet.tbl_DauTu, ID); 
                }            
                
               
            }
            catch {
            
            }
        }

        private void uiButtonDelete_Click(object sender, EventArgs e)
        {
            string message;
            if (iDTextBox.Text != "")
            {
                message = String.Format("Bạn có chắc chắn muốn xóa đầu tư này ?");

                if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.tbl_DauTuBindingSource.RemoveCurrent();
                    DoSave();
                    //this.tbl_DauTuTableAdapter.Fill(this.dauTuDataSet.tbl_DauTu);
                }
            }
            else { MessageBox.Show("Đầu tư này chưa có nên không xóa được !");
           
            }
        }
        private bool SaveDauTu()
        {
            try
            {
                float Test=0;
                long test1 = 0;
                //uiComboBoxVuTrong.SelectedValue = MDSolution.DACASUCO_App.VuTrongID.ToString();
                //if (string.IsNullOrEmpty(HopDongUIDCombobox.Text))
                //{
                //    MessageBox.Show("Bạn chưa chọn chủ hợp đồng", "Thông báo");
                //    HopDongUIDCombobox.Focus();
                //    return false;
                //}
                if (string.IsNullOrEmpty(cbLoaiDT.Text))
                {
                    MessageBox.Show("Bạn chưa chọn khoản đầu tư của HĐĐT! ", "Thông báo");
                    cbLoaiDT.Focus();
                    return false;
                }
                if(string.IsNullOrEmpty(cbMaHDDT.Text))
                {
                 MessageBox.Show("Bạn chưa chọn Mã hợp đồng đầu tư! ","Thông báo");
                    cbMaHDDT.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(donViCungUngVatTuUIDComboBox.Text))
                {
                    MessageBox.Show("Bạn chưa chọn đơn vị ứng vật tư ","Thông báo");
                    donViCungUngVatTuUIDComboBox.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(danhMucDauTuUIDComboBox.Text))
                {
                    MessageBox.Show("Bạn chưa chọn danh mục đầu tư", "Thông báo");
                    danhMucDauTuUIDComboBox.Focus();
                    return false;
                }
                else
                {
                    if (danhMucDauTuUIDComboBox.SelectedValue==null)
                    {
                        MessageBox.Show("Bạn chưa chọn danh mục đầu tư", "Thông báo");
                        danhMucDauTuUIDComboBox.Focus();
                        return false;
                    }
                }
                if (!string.IsNullOrEmpty(editBoxDotDauTu.Text))
                {
                    if (!long.TryParse(editBoxDotDauTu.Text, out test1))
                    {
                        MessageBox.Show("Đợt đầu tư phải nhập kiểu số");
                        editBoxDotDauTu.Focus();
                        return false;
                    }
                }
                else
                {
                    editBoxDotDauTu.Text = "0";
                }
                if (string.IsNullOrEmpty(ngayDauTuCalendarCombo.Text))
                {
                    MessageBox.Show("Bạn cho biết ngày đầu tư?");
                    ngayDauTuCalendarCombo.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(editBoxSoTien.Text) && string.IsNullOrEmpty(editBoxSoLuong.Text) && string.IsNullOrEmpty(editBoxDonGia.Text)) throw new Exception("Bạn phải nhập số lượng và đơn giá hoặc số tiền ");
                if (string.IsNullOrEmpty(editBoxSoTien.Text) && string.IsNullOrEmpty(editBoxSoLuong.Text) && string.IsNullOrEmpty(editBoxDonGia.Text))
                {
                    MessageBox.Show("Bạn phải nhập số lượng và đơn giá hoặc số tiền", "Thông báo");
                    editBoxSoLuong.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(editBoxSoTien.Text))
                { editBoxSoTien.Text = "0"; }
                else{
                    if (!float.TryParse(editBoxSoTien.Text, out Test))
                    {
                        MessageBox.Show("Số tiền phải nhập kiểu số", "Thông báo");
                        editBoxSoTien.Focus();
                        return false;
                    } 
                }
                
                if (string.IsNullOrEmpty(editBoxSoLuong.Text))
                { editBoxSoLuong.Text = "0"; }
                else
                {
                    if (!float.TryParse(editBoxSoLuong.Text, out Test))
                    {
                        MessageBox.Show("Số lượng phải nhập kiểu số", "Thông báo");
                        editBoxSoLuong.Focus();
                        return false;
                    }                         
                }
                if (float.Parse(editBoxSoLuong.Text) < 0)
                {
                    MessageBox.Show("Số lượng bạn nhập vào nhỏ hơn 0, kiểm tra lại", "Thông báo");
                    editBoxSoLuong.Focus();
                    return false;
                } 
                   
                if (string.IsNullOrEmpty(editBoxDonGia.Text))
                { editBoxDonGia.Text = "0"; }
                else {
                    if (!float.TryParse(editBoxDonGia.Text, out Test))
                    {
                        MessageBox.Show("Đơn giá phải nhập kiểu số", "Thông báo");
                        editBoxDonGia.Focus();
                        return false;
                    }                         
                }
                if (float.Parse(editBoxSoTien.Text) <= 0 && float.Parse(editBoxSoLuong.Text) <= 0 && float.Parse(editBoxDonGia.Text) <= 0)
                {
                    MessageBox.Show("Bạn phải nhập số lượng và đơn giá hoặc số tiền", "Thông báo");
                    editBoxSoLuong.Focus();
                    return false;
                }
                    
                if (float.Parse(editBoxDonGia.Text) < 0)
                {
                    MessageBox.Show("Đơn giá bạn nhập vào nhỏ hơn 0, kiểm tra lại", "Thông báo");
                    editBoxDonGia.Focus();
                    return false;
                }   
                    
                if (float.Parse(editBoxSoTien.Text) < 0)
                {
                    MessageBox.Show("Số tiền bạn nhập vào nhỏ hơn 0, kiểm tra lại", "Thông báo");
                    editBoxSoTien.Focus();
                    return false;
                }
                if (float.Parse(editBoxSoTien.Text) == 0)
                {
                    MessageBox.Show("Số tiền bạn nhập vào nhỏ bằng 0, kiểm tra lại", "Thông báo");
                    editBoxSoTien.Focus();
                    return false;
                } 
                //float tempSoTien = float.Parse(editBoxSoLuong.Text) * float.Parse(editBoxDonGia.Text);
                //if (tempSoTien > 0 && float.Parse(editBoxSoLuong.Text) >= 0 && float.Parse(editBoxSoTien.Text) != tempSoTien)
                //{
                //    if (MessageBox.Show("Số tiền " + editBoxSoTien.Text + " nhập vào khác với tổng số lượng * đơn giá : " + editBoxSoLuong.Text + "* " + editBoxDonGia.Text + "\n Bạn muốn lưu giá trị nào? Yes để lưu số tiền được nhập vào, no để lưu tổng tính toán.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //    {
                //        editBoxSoTien.Text = tempSoTien.ToString();
                //    }
                //}
                if (float.Parse(editBoxSoTien.Text) == 0)
                {
                    if (float.Parse(editBoxSoLuong.Text) == 0 )
                    {
                        MessageBox.Show("Bạn phải nhập số tiền hoặc số lượng cùng đơn giá");
                        editBoxSoLuong.Focus();
                        return false;
                    }
                    else
                    {
                        if (float.Parse(editBoxDonGia.Text) == 0)
                        {
                            MessageBox.Show("Bạn phải nhập số tiền hoặc số lượng cùng đơn giá");
                            editBoxDonGia.Focus();
                            return false;
                        }
                        }                        
                }
                if (string.IsNullOrEmpty(editBoxLaiSuat.Text))
                { editBoxLaiSuat.Text = "0"; }
                else
                {
                    if (!float.TryParse(editBoxLaiSuat.Text,out Test))
                    {
                        MessageBox.Show("Lãi suất phải nhập kiểu số");
                        editBoxLaiSuat.Focus();
                        return false;
                    } 
                }
                if ((float.Parse(editBoxLaiSuat.Text) < 0) || float.Parse(editBoxLaiSuat.Text) > 100)
                {
                    MessageBox.Show("Lãi suất phải lớn hơn không hoặc bằng không");
                    editBoxLaiSuat.Focus();
                    return false;
                } 
                if (string.IsNullOrEmpty(ngayDauTuCalendarCombo.Text))
                {
                    MessageBox.Show("Bạn cho biết ngày đầu tư?");
                    ngayDauTuCalendarCombo.Focus();
                    return false;
                } 
                    
                if (!string.IsNullOrEmpty(editBoxDotDauTu.Text))
                {
                    if (!long.TryParse(editBoxDotDauTu.Text, out test1))
                    {
                        MessageBox.Show("Đợt đầu tư phải nhập kiểu số");
                        editBoxDotDauTu.Focus();
                        return false;
                    }                           
                }
                else
                {
                    editBoxDotDauTu.Text = "0";
                }
                
                TruyenDuLieu(false);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void DoSave()
        {
            try
            {                
                this.tbl_DauTuBindingSource.EndEdit();
                              
                //MDDataSet.HopDongTrongMiaDataSet.tbl_HopDongDataTable changes = (MDDataSet.HopDongTrongMiaDataSet.tbl_HopDongDataTable)this.hopDongTrongMiaDataSet.tbl_HopDong.GetChanges();
                //if (changes != null)
                //{
                //    //Fill default value;
                //    foreach (MDDataSet.HopDongTrongMiaDataSet.tbl_HopDongRow detail in changes.Rows)
                //    {
                //        DataRowState dstate = detail.RowState;
                //        if (detail.RowState == DataRowState.Deleted)
                //        {
                //        }
                //        else if (detail.RowState == DataRowState.Added)
                //        {
                //            //detail.ID = System.Convert.ToInt32(MDSolutionEntities.DBModule.GetNewID(typeof(clsHopDong), "tbl_HopDong", null, null));                        
                //            detail.MaHopDong = maHopDongEditBox.Text;
                //            detail.CreatedBy = System.Convert.ToInt32(DACASUCO_App.iUser.ID);
                //            detail.ModifyBy = System.Convert.ToInt32(DACASUCO_App.iUser.ID);
                //            detail.DataModify = DateTime.Now;
                //            detail.ModifyBy = System.Convert.ToInt32(DACASUCO_App.iUser.ID);
                //        }
                //        else if (detail.RowState == DataRowState.Modified)
                //        {
                //            if (detail.MaHopDong != maHopDongEditBox.Text)
                //                detail.MaHopDong = maHopDongEditBox.Text;
                //            detail.DataModify = DateTime.Now;
                //            detail.ModifyBy = System.Convert.ToInt32(DACASUCO_App.iUser.ID);
                //        }
                //    }
                this.tbl_DauTuTableAdapter.Update(this.dauTuDataSet.tbl_DauTu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Có lỗi khi lưu","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }       
        }


        private bool Chek_SuaDLGoc() // sử dụng để sửa tbl_truNo_DauTu khi thay doi DL goc
        {                            // = true --> cho phep sua; = false --> da dc thanh toan -->ko dc sua
            try
            {
                string _DotThanhToan = "";
                string _NhapTienTraNoID = "";

                string strSQL = "SELECT tbl_DauTu.DonViCungUngVatTuID, tbl_DanhMucDauTu.LoaiHinhDauTuID"
                    + " FROM  tbl_DanhMucDauTu INNER JOIN "
                    + " tbl_DauTu ON tbl_DanhMucDauTu.ID = tbl_DauTu.DanhMucDauTuID Where tbl_DauTu.ID=" + iDTextBox.Text;
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                
                string donvi;
                string LoaiDauTu;
                donvi = ds.Tables[0].Rows[0]["DonViCungUngVatTuID"].ToString();
                LoaiDauTu = ds.Tables[0].Rows[0]["LoaiHinhDauTuID"].ToString();

                long ThuTu;
                if (donvi == "1")
                {
                    ThuTu = 1;
                }
                else
                {
                    switch (LoaiDauTu)
                    {
                        case "1":
                            ThuTu = 7;
                            break;
                        case "4":
                            ThuTu = 8;
                            break;
                        case "2":
                            ThuTu = 9;
                            break;
                        case "5":
                            ThuTu = 10;
                            break;
                        case "3":
                            ThuTu = 11;
                            break;
                        default:
                            ThuTu = 11;
                            break;
                    }
                }

                strSQL = "Select ID, DotThanhToan, NhapTienTraNoID From tbl_TruNo_DauTu Where VuTrongID =" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " and DauTuID=" + iDTextBox.Text + " and ThuTu =" + ThuTu.ToString();
                DataSet ds1 = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);

                if (ds1.Tables[0].Rows.Count == 0) return true;
                if (ds1.Tables[0].Rows[0].IsNull("ID")) // khoan dau tu chua dc load vao
                {
                    return true;
                }
                else
                {
                    if (ds1.Tables[0].Rows[0].IsNull("DotThanhToan")) // co khoan dtu va dot thanh toan = null
                    {
                        strSQL = "sp_ThanhToan_SuaDLGoc " + MDSolution.DACASUCO_App.VuTrongID.ToString() + "," + iDTextBox.Text + "," + ThuTu.ToString();
                        MDSolutionEntities.DBModule.ExecuteNoneBackup(strSQL, null, null);
                        return true;
                    }
                    else // khoan dau tu da dc thanh toan
                    {
                        _DotThanhToan = ds1.Tables[0].Rows[0]["DotThanhToan"].ToString();
                        if (!ds1.Tables[0].Rows[0].IsNull("NhapTienTraNoID"))
                        {
                            _NhapTienTraNoID = ds1.Tables[0].Rows[0]["NhapTienTraNoID"].ToString();
                            string sql = "Select NgayTra,SoTien From tbl_NhapTienTraNo Where ID=" + _NhapTienTraNoID;
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["NgayTra"].ToString());
                            string sotien = ds.Tables[0].Rows[0]["SoTien"].ToString();
                            MessageBox.Show("Khoản đầu tư này đã được trừ nợ bằng nhập tiền trả nợ. \nNgày nhập tiền: " + dt.ToString("dd/MM/yyyy") + " \n Số tiền: " + sotien, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Khoản đầu tư này đã được thanh toán trong đợt " + _DotThanhToan + ".\nNếu muốn sửa phải thực hiện huỷ đợt thanh toán thứ " + _DotThanhToan, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        { 
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
                catch { }
                this.Validate();
                if (!SaveDauTu())
                { 
                    return; 
                }

                if (IsAdd == true)
                {
                    iDTextBox.Text = GetID();
                }
                else
                {   // chek xem khoan đầu tư đã đc thanh toán chưa??
                    if (Chek_SuaDLGoc())
                    { }
                    else
                    {
                        return;
                    }
                }
                string a = danhMucDauTuUIDComboBox.Text;
                //DoSave();
                uiButtonNew.Enabled = true;
                uiButtonEdit.Enabled = true;
                uiButtonSave.Enabled = false;
                uiButtonCancel.Enabled = false;
                uiGroupBox1.Enabled = false;
                uiGroupBox2.Enabled = false;
                uiButtonDelete.Enabled = true;
                _ID = long.Parse(iDTextBox.Text);

                MDSolutionEntities.clsDauTu oDT = new MDSolutionEntities.clsDauTu();
                if(IsAdd==false)
                {
                    oDT.ID = _ID;
                    }
                oDT.HopDongID = long.Parse(ID.ToString());
                oDT.DanhMucDauTuID = long.Parse(danhMucDauTuUIDComboBox.SelectedValue.ToString());
                oDT.SoLuong = long.Parse(editBoxSoLuong.Text.ToString());
                oDT.DonGia = long.Parse(editBoxDonGia.Text.ToString());
                oDT.SoTien = Decimal.Parse(editBoxSoTien.Text.ToString());
                oDT.LaiSuat =decimal.Parse(editBoxLaiSuat.Text.ToString());
                oDT.NgayDauTu = DateTime.Parse(ngayDauTuCalendarCombo.Value.ToString());
                
                oDT.GhiChu = ghiChuTextBox.Text;
                oDT.DotDauTu = long.Parse(editBoxDotDauTu.Text.ToString());
               
                //string qr = "select ID from tbl_Vutrong where Ten=" + "N'"+txtVuTrong.Text+"'";
                //DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(qr, null, null);
                oDT.VuTrongID = MDSolution.DACASUCO_App.VuTrongID;//long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                string qr1 = "SELECT LoaiHDDT_id FROM LoaiHopDong INNER JOIN "+
                      "tbl_HopDongDauTu ON LoaiHopDong.ID = tbl_HopDongDauTu.LoaiHDDT_id where Ten=" + "N'"+txtLoaiHD.Text+"'";
                DataSet ds1 = MDSolutionEntities.DBModule.ExecuteQuery(qr1, null, null);
                //oDT.LoaiHDDT_ID = long.Parse(ds1.Tables[0].Rows[0]["LoaiHDDT_ID"].ToString());
                oDT.MaHDDT = cbMaHDDT.Text;
                oDT.SoChungTu = soChungTuTextBox.Text.ToString();
                //oDT.DonViCungUngVatTuID = long.Parse(donViCungUngVatTuUIDComboBox.SelectedValue.ToString());
                oDT.LoaiDT = long.Parse(cbLoaiDT.SelectedValue.ToString());
                oDT.Save(null, null);
                
                if (IsAdd)
                {
                    //ID = int.Parse(HopDongUIDCombobox.SelectedValue.ToString());
                    MessageBox.Show("Bạn đã lưu lại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    uiButtonNew_Click(null, null);
                
                }
                else
                {
                    MessageBox.Show("Bạn đã sửa lại thành công !", "Thông báo");
                    this.Close();

                }


            }
            
            catch 
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu đầu tư!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetID()
        {
           
            try
            {
                long MaxID = 0;
                string strMaxID = "";
                string strSQL = "select max([ID]) As Max from tbl_dautu";
                strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (strMaxID != "")
                    MaxID = long.Parse(strMaxID) + 1;
                else
                    MaxID = 1;

                return MaxID.ToString();
            }
            catch { return ""; }
        }
        private void uiButtonNew_Click(object sender, EventArgs e)
        {            
            
            this.tbl_DauTuBindingSource.AddNew();
            if (ID > 0)
            {
                //HopDongUIDCombobox.SelectedValue = long.Parse(ID.ToString());
            }
            IsAdd = true;
           // textBoxMaHDDT.Text = DACASUCO_App.strMaHDDT;
            //uiComboBoxLoaiHopDong.SelectedValue = DACASUCO_App.longLoaiHopDong_ID.ToString();
            iDTextBox.Text = GetID();
            //uiComboBoxVuTrong.SelectedValue = MDSolution.DACASUCO_App.VuTrongID.ToString();
            soChungTuTextBox.Text = GetSCT();
            TruyenDuLieu(true);
            donGiaTextBox.Text = "0";
            dotDauTuTextBox.Text = "0";
            laiSuatTextBox.Text = "0";
            soLuongTextBox.Text = "0";
            soTienTextBox.Text = "0";
            uiButtonNew.Enabled = false;
            uiButtonEdit.Enabled = false;
            uiButtonSave.Enabled = true;
            uiButtonCancel.Enabled = true;
            uiButtonDelete.Enabled = false;
            uiGroupBox1.Enabled = true;
            uiGroupBox2.Enabled = true;
            //HopDongUIDCombobox.Enabled = true;            
            //HopDongUIDCombobox.Focus();

            //uiCboChungLoaiDauTu.DataSource = null;
            SetDataSource_CboChungLoaiDT();
            uiCboChungLoaiDauTu.SelectedValue = null;

        }
        private void TruyenDuLieu(Boolean Truyen)
        {
            if (Truyen)
            {
                editBoxDonGia.Text = donGiaTextBox.Text;
                editBoxDotDauTu.Text = dotDauTuTextBox.Text;
                editBoxLaiSuat.Text = laiSuatTextBox.Text;
                float a = 0;
                if (soLuongTextBox.Text != "")
                {
                    a = float.Parse(soLuongTextBox.Text);
                }
                editBoxSoLuong.Text = a.ToString();
                editBoxSoTien.Text = soTienTextBox.Text;
            }
            else
            {
                donGiaTextBox.Text = editBoxDonGia.Text;
                dotDauTuTextBox.Text = editBoxDotDauTu.Text;
                laiSuatTextBox.Text = editBoxLaiSuat.Text;
                float a = 0;
                a = float.Parse(editBoxSoLuong.Text);
                soLuongTextBox.Text = a.ToString();
                soTienTextBox.Text = editBoxSoTien.Text;
            
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
            //HopDongUIDCombobox.Enabled = false;
            IsAdd = false;
            danhMucDauTuUIDComboBox.Enabled = true;
            donViCungUngVatTuUIDComboBox.Focus();
            
        }

        private void iDTextBox_TextChanged(object sender, EventArgs e)
        {
            TruyenDuLieu(true);
            uiButtonNew.Enabled = true;
            uiButtonEdit.Enabled = true;
            uiButtonSave.Enabled = false;
            uiButtonCancel.Enabled = false;
            uiButtonDelete.Enabled = true;
            uiGroupBox1.Enabled = false;
            uiGroupBox2.Enabled = false;
            //IsAdd = false;
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
               
        private void ghiChuTextBox_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            uiButtonSave.Focus();
        }

        private void donViCungUngVatTuUIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (donViCungUngVatTuUIDComboBox.Text != "")
            //{ LoadDanhMucDauTu(donViCungUngVatTuUIDComboBox.SelectedValue.ToString()); }
        }

        private void donViCungUngVatTuUIDComboBox_Leave(object sender, EventArgs e)
        {
            try
            {
                string strSQL;
                string strMaxID = "";
                if (donViCungUngVatTuUIDComboBox.Text != "")
                {
                    strSQL = "SELECT Count(ID) FROM tbl_DonViCungUngVatTu WHERE Ten=N'" + donViCungUngVatTuUIDComboBox.Text + "'";
                    strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                    if (strMaxID == "0")
                    {
                        MessageBox.Show("Tên đơn vị cung ứng vật tư không đúng", "Thông báo");
                        donViCungUngVatTuUIDComboBox.Focus();
                    }
                    else
                    {
                        if (uiCboChungLoaiDauTu.Text != "")
                        {
                            uiCboChungLoaiDauTu_Leave(sender,e); 
                        }
                        else
                        {
                            uiCboChungLoaiDauTu.Focus();
                        }
                        //strSQL = "SELECT ID FROM tbl_DonViCungUngVatTu WHERE Ten=N'" + donViCungUngVatTuUIDComboBox.Text + "'";
                        //strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                        //LoadDanhMucDauTu(strMaxID);
                        //danhMucDauTuUIDComboBox.Focus();
                    }
                }

            }
            catch 
            {
                MessageBox.Show("Bạn chưa nhập đơn vị cung ứng vật tư", "Thông báo");
            }
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

        private void LoadDanhMucDauTu( string DVDT_ID,string LoaiHinhDauTu_ID)
        {
            try
            {
                if ((!string.IsNullOrEmpty(DVDT_ID)) &&(!string.IsNullOrEmpty(LoaiHinhDauTu_ID)))
                {
                    DataSet ds;
                    ds = MDSolutionEntities.clsDanhMucDauTu.GetListbyWhere("ID,Ten", "ID in(select DanhMucDauTuID from tbl_DanhMucDT_DonViCU where DonvicungungID=" + DVDT_ID + ") and ID in( Select ID from tbl_DanhMucDauTu Where LoaiHinhDauTuID=" + LoaiHinhDauTu_ID + ")", "", null, null);
                    if (ds.Tables.Count > 0)
                    {
                        DataRow oR = ds.Tables[0].NewRow();
                        //int i = ds.Tables[0].Rows.Count;
                        this.danhMucDauTuUIDComboBox.DataSource = ds.Tables[0];
                        danhMucDauTuUIDComboBox.Enabled = true;
                    }
                }              
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void editBoxSoTien_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;

            //Control textbox = (Control)sender;
            //textbox.BackColor = Color.White;

            try
            {
                long a = 0;
                if (long.TryParse(editBoxSoTien.Text,out a))
                {
                    editBoxSoTien.Text = a.ToString();
                }
                else
                {
                    //MessageBox.Show("Bạn đã nhập sai dữ liệu!");
                    //editBoxSoTien.Focus();
                }
            }
            catch
            {

            }
        }

        private void editBoxSoTien_Enter(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.SkyBlue;
        }

        private void editBoxSoLuong_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;

            try
            {
                double a = 0;
                if (double.TryParse(editBoxSoLuong.Text,out a))
                {
                    editBoxSoLuong.Text = a.ToString();
                }
                else
                {
                    //MessageBox.Show("Bạn đã nhập sai dữ liệu!");
                    //editBoxSoLuong.Focus();
                }
            }
            catch
            { 

            }

            try
            {
                double dongia = 0;
                double SL = 0;
                if ((double.TryParse(editBoxSoLuong.Text,out SL)) && (double.TryParse(editBoxDonGia.Text,out dongia)))
                {
                    double sotien = Math.Round(SL * dongia,0);
                    sotien = Math.Round(sotien,0);
                    editBoxSoTien.Text = sotien.ToString();
                }
            }
            catch
            {
            }
        }

        private void editBoxDonGia_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;

            try
            {
                long a = 0;
                if (long.TryParse(editBoxDonGia.Text,out a))
                {
                    editBoxDonGia.Text = a.ToString();
                }
                else
                {
                    //MessageBox.Show("Bạn đã nhập sai dữ liệu!");
                    //editBoxDonGia.Focus();
                }
            }
            catch
            {

            }

            try
            {
                double dongia = 0;
                double SL = 0;
                if ((double.TryParse(editBoxSoLuong.Text,out SL)) && (double.TryParse(editBoxDonGia.Text,out dongia)))
                {
                    double sotien = Math.Round(SL * dongia,0);
                    editBoxSoTien.Text = sotien.ToString();
                }
            }
            catch
            { 
            }

        }
        
        private void editBoxDotDauTu_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

        private void danhMucDauTuUIDComboBox_Leave(object sender, EventArgs e)
        {
            try
            {
                string StrSQL = "Select DonViTinh from tbl_tbl_DanhMucDauTu Where id =" + danhMucDauTuUIDComboBox.SelectedValue;
                lb_DonViTinh.Text = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(StrSQL, null, null);
            }
            catch
            {
                lb_DonViTinh.Text = "";
            }   
        }

        private void txtMaHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtMaHD.Text.Length == 6)
                {
                    string SQL = "Select ID from tbl_hopdong Where MaHopDong=N'" + txtMaHD.Text+"'";
                    string strkq = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(SQL, null, null);
                    if (strkq != "")
                    {
                        //HopDongUIDCombobox.SelectedValue = long.Parse(strkq);
                    }
                    else
                    {
                        MessageBox.Show("Không có mã hợp đồng nào như vậy\n Hãy Kiểm tra lại mã hợp đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã hợp đồng phải đúng 6 ký tự", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

      
        private void uiComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string strSQL;
            string strMaxID = "";
            string strChungLoaiID = "";
            if (uiCboChungLoaiDauTu.Text != "")
            {
                strSQL = "SELECT Count(ID) FROM tbl_LoaiHinhDauTu WHERE Ten=N'" + uiCboChungLoaiDauTu.Text + "'";
                strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (strMaxID == "0")
                {
                    MessageBox.Show("Tên chủng loại vật tư không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    uiCboChungLoaiDauTu.Focus();
                }
                else
                {
                    strSQL = "SELECT ID FROM tbl_DonViCungUngVatTu WHERE Ten=N'" + donViCungUngVatTuUIDComboBox.Text + "'";
                    strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);

                    strSQL = "Select ID from tbl_LoaiHinhDauTu Where Ten=N'" + uiCboChungLoaiDauTu.Text + "'";
                    strChungLoaiID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);

                    LoadDanhMucDauTu(strMaxID, strChungLoaiID);
                    if (IsAdd)
                        danhMucDauTuUIDComboBox.Focus();
                }
            }
            else
            {
                //MessageBox.Show("Bạn chưa nhập chủng loại vật tư", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //uiCboChungLoaiDauTu.Focus();
            }
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

        private void uiCboChungLoaiDauTu_Leave(object sender, EventArgs e)
        {
            //string strSQL;
            //string strMaxID = "";
            //string strChungLoaiID = "";
            //if (uiCboChungLoaiDauTu.Text != "")
            //{
            //    strSQL = "SELECT Count(ID) FROM tbl_LoaiHinhDauTu WHERE Ten=N'" + uiCboChungLoaiDauTu.Text + "'";
            //    strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
            //    if (strMaxID == "0")
            //    {
            //        MessageBox.Show("Tên chủng loại vật tư không đúng", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //        uiCboChungLoaiDauTu.Focus();
            //    }
            //    else
            //    {
            //        strSQL = "SELECT ID FROM tbl_DonViCungUngVatTu WHERE Ten=N'" + donViCungUngVatTuUIDComboBox.Text + "'";
            //        strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);

            //        strSQL = "Select ID from tbl_LoaiHinhDauTu Where Ten=N'" + uiCboChungLoaiDauTu.Text +"'";
            //        strChungLoaiID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL,null,null);
                                        
            //        LoadDanhMucDauTu(strMaxID,strChungLoaiID);
            //        if (IsAdd)
            //            danhMucDauTuUIDComboBox.Focus();                    
            //    }
            //}
            //else
            //{
            //    //MessageBox.Show("Bạn chưa nhập chủng loại vật tư", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //uiCboChungLoaiDauTu.Focus();
            //}
            //Control textbox = (Control)sender;
            //textbox.BackColor = Color.White;
        }

        private void danhMucDauTuUIDComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (danhMucDauTuUIDComboBox.Text != "")
            {
                try
                {
                    string SQL = "Select DonViTinh from tbl_DanhMucDauTu Where ID =(Select ID from tbl_DanhMucDauTu Where Ten=N'" + danhMucDauTuUIDComboBox.Text + "')";

                    lb_DonViTinh.Text = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(SQL, null, null);
                    label5.Text = "(Đồng/" + lb_DonViTinh.Text + ")";
                }
                catch
                {
                    lb_DonViTinh.Text = "";
                }
                //lb_DonViTinh.Text = str;
            }
            else
            {

            }
        }

        private void soChungTuTextBox_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

        private void danhMucDauTuUIDComboBox_Leave_1(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            if (danhMucDauTuUIDComboBox.Text != "")
            {
                string strSQL = "Select ID from tbl_DanhMucDauTu Where Ten =N'" + danhMucDauTuUIDComboBox.Text + "'";
                string str = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (String.IsNullOrEmpty(str) || str == "")
                {
                    MessageBox.Show("Không có danh mục đầu tư nào như trên\nHãy Kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    danhMucDauTuUIDComboBox.Focus();
                }
                else
                {
                    danhMucDauTuUIDComboBox.SelectedValue = long.Parse(str);
                }
            }
        }

        private void cbMaHDDT_TextChanged(object sender, EventArgs e)
        {
            string maHD = cbMaHDDT.Text;
            string QR = "SELECT distinct dbo.tbl_HopDong.MaHopDong,dbo.tbl_HopDong.ID as ID, dbo.tbl_HopDong.HoTen, dbo.LoaiHopDong.Ten AS LoaiHopDong," +
                      "dbo.sys_User.HoTen AS Nguoidung, dbo.tbl_HopDongDauTu.NgayKy,dbo.tbl_HopDongDauTu.ThoiHanHD " +
                      "FROM dbo.sys_User INNER JOIN  dbo.LoaiHopDong INNER JOIN  dbo.tbl_HopDong INNER JOIN " +
                      "dbo.tbl_HopDongDauTu ON dbo.tbl_HopDong.ID = dbo.tbl_HopDongDauTu.HopDongID ON " +
                      "dbo.LoaiHopDong.ID = dbo.tbl_HopDongDauTu.LoaiHDDT_id ON dbo.sys_User.ID = dbo.tbl_HopDongDauTu.UserID Where  dbo.tbl_HopDongDauTu.MaHDDT=" + "N'"+maHD+"' AND tbl_HopDongDauTu.VuTrongID="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(QR, null, null);
            ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
            txtChuMia.Text = ds.Tables[0].Rows[0]["MaHopDong"].ToString();
            txtHoVaTen.Text = ds.Tables[0].Rows[0]["HoTen"].ToString();
            txtLoaiHD.Text =ds.Tables[0].Rows[0]["LoaiHopDong"].ToString();
            txtNguoiQL.Text = ds.Tables[0].Rows[0]["Nguoidung"].ToString();
            calendarNgayKy.Value = DateTime.Parse(ds.Tables[0].Rows[0]["NgayKy"].ToString());
            txtThoiHanHD.Text = ds.Tables[0].Rows[0]["ThoiHanHD"].ToString();
            MDSolutionEntities.clsVuTrong oVT = new MDSolutionEntities.clsVuTrong(MDSolution.DACASUCO_App.VuTrongID);
            oVT.Load(null, null);
            txtVuTrong.Text = oVT.Ten; //ds.Tables[0].Rows[0]["TenVuTrong"].ToString();
            
        }

       
        

        

       
    }
}