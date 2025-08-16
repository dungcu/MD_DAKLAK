using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDDataSetForms
{
    public partial class XeVanChuyen_ThemMoi : Form
    {
        public long _ID1 = 0;
        private string ID = "";
        private string IDHD = "";
        private Boolean Add = true;
        public XeVanChuyen_ThemMoi()
        {
            InitializeComponent();
        }

        private void tbl_XeVanChuyenBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbl_XeVanChuyenBindingSource.EndEdit();
            this.tbl_XeVanChuyenTableAdapter.Update(this.xeVanChuyenDataSet.tbl_XeVanChuyen);

        }
        public XeVanChuyen_ThemMoi(string id,string idHopDong)
        {
            InitializeComponent();
            ID = id;
            IDHD = idHopDong;
            if (ID != "")
            {
                this.tbl_XeVanChuyenTableAdapter.FillBy(this.xeVanChuyenDataSet.tbl_XeVanChuyen, int.Parse(ID));

            }
            else
            {
                this.tbl_XeVanChuyenTableAdapter.Fill(this.xeVanChuyenDataSet.tbl_XeVanChuyen);
                //this.tbl_HopDongVanChuyenBindingSource.AddNew();           

            }
            
        }
       
       
        private void XeVanChuyen_ThemMoi_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'xeVanChuyenDataSet.tbl_HopDongVanChuyen' table. You can move, or remove it, as needed.
            this.tbl_HopDongVanChuyenTableAdapter.Fill(this.xeVanChuyenDataSet.tbl_HopDongVanChuyen);
            //// TODO: This line of code loads data into the 'xeVanChuyenDataSet.tbl_XeVanChuyen' table. You can move, or remove it, as needed.
            //this.tbl_XeVanChuyenTableAdapter.Fill(this.xeVanChuyenDataSet.tbl_XeVanChuyen);
            TruyenDL(false);
           
                if (ID != "")
                {
                    btSua_Click(null,null);
                    //this.tbl_XeVanChuyenTableAdapter.FillBy(this.xeVanChuyenDataSet.tbl_XeVanChuyen, int.Parse(ID));
                    //btGhiNhan.Enabled = true;
                    //btHuyBo.Enabled = true;
                    //btSua.Enabled = false;
                    //btThem.Enabled = false;
                    //btXoa.Enabled = false;
                    //uiGroupBox5.Enabled = false;
                    //Add = false;
                }
                else
                {
                    btThem_Click(null, null);
                    //this.tbl_XeVanChuyenTableAdapter.Fill(this.xeVanChuyenDataSet.tbl_XeVanChuyen);
                    ////this.tbl_XeVanChuyenBindingSource.AddNew();
                    //btGhiNhan.Enabled = true;
                    //btHuyBo.Enabled = true;
                    //btSua.Enabled = false;
                    //btThem.Enabled = false;
                    //btXoa.Enabled = false;
                    uiComboBox1.Enabled = false;
                    uiComboBoxHoTenCHD.Enabled = false;
                    uiComboBox3.Enabled = true;
                    uiComboBox2.Enabled = false;

                    //Add = true;
                }
                //iDTextBox.Text = GetID();
            //if (IDHD != "")
            //{
            //    uiComboBox3.SelectedValue = long.Parse(IDHD);
            //}
            

        }

        private string GetID()
        {

            try
            {
                long MaxID = 0;
                string strMaxID = "";
                string strSQL = "select max([ID]) As Max from tbl_xevanchuyen";
                strMaxID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                MaxID = long.Parse(strMaxID) + 1;
                return MaxID.ToString();
            }
            catch { return ""; }
        }
        private bool IsXeVanChuyenOK(string SoXe)
        {
            string strSQL = "select Count(*) from tbl_XeVanChuyen where 1=1 ";
            //strSQL += " And  (SoXe = " + SoXe + ")";
            strSQL += " And (rTrim(lTrim([SoXe])) = rTrim(lTrim(N'" + SoXe + "')))";
            try
            {
                string ret = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (long.Parse(ret) > 0) return true;
                else return false;
            }
            catch
            {
                return true;
            }

        }
        //private bool IsMaSoXeOK(string MaSoXe)
        //{
        //    string strSQL = "select Count(*) from tbl_XeVanChuyen where 1=1 ";
        //    //strSQL += " And  (SoXe = " + SoXe + ")";
        //    strSQL += " And (rTrim(lTrim([MaSoXe])) = rTrim(lTrim(N'" + MaSoXe + "')))";
        //    try
        //    {
        //        string ret = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
        //        if (long.Parse(ret) > 0) return true;
        //        else return false;
        //    }
        //    catch
        //    {
        //        return true;
        //    }

        //}
        private bool SaveXeVanChuyen()
        {
            try
            {
                float a=0;
                if (string.IsNullOrEmpty(soXeTextBox.Text)) 
                { MessageBox.Show("Bạn chưa nhập biển số xe","Thông báo");
                soXeTextBox.Focus();
                return false;
                }  
                string strSoXeNew = soXeTextBox.Text;
                if (Add)
                {
                    if (IsXeVanChuyenOK(strSoXeNew))
                    {
                        MessageBox.Show("Số xe đã được khai báo trong hệ thống, kiểm tra lại");
                        soXeTextBox.Text = strSoXeNew;
                        soXeTextBox.Focus();
                        return false;
                    }
                }
                
                if (string.IsNullOrEmpty(tenLaiXeTextBox.Text)) 
                {
                    MessageBox.Show("Bạn chưa nhập tên lái xe","Thông báo");
                    tenLaiXeTextBox.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(loaiXeTextBox.Text)) 
                {
                    MessageBox.Show("Bạn chưa nhập loại xe vận chuyển");
                    loaiXeTextBox.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(editBox1.Text)) 
                {
                    MessageBox.Show("Bạn chưa nhập trọng tải của xe vận chuyển");
                    editBox1.Focus();
                    return false;
                }

                if (!float.TryParse(editBox1.Text, out a)) 
                {
                    MessageBox.Show("Bạn phải nhập trọng tải là số ");
                    editBox1.Focus();
                    return false;

                }
                if (float.Parse(editBox1.Text) <= 0) 
                {
                    MessageBox.Show("Trọng tải của xe nhập vào không phù hợp");
                    trongTaiTextBox.Focus();
                    return false;
                }
               
            
                //if (string.IsNullOrEmpty(maSoXeTextBox.Text)) 
                //{
                //    MessageBox.Show("Bạn chưa nhập mã số của xe vận chuyển");
                //    maSoXeTextBox.Focus();
                //    return false;
                //}
                //    string strMaSoXe = maSoXeTextBox.Text;
                //    if (Add)
                //    {
                //        if (IsMaSoXeOK(strMaSoXe))
                //        {
                //            MessageBox.Show("Mã số xe này đã được khai báo trong hệ thống, kiểm tra lại");
                //            maSoXeTextBox.Text = strMaSoXe;
                //            maSoXeTextBox.Focus();
                //            return false;
                //        }
                //    }
                
                TruyenDL(true);
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
            this.tbl_XeVanChuyenBindingSource.EndEdit();
            this.tbl_XeVanChuyenTableAdapter.Update(this.xeVanChuyenDataSet.tbl_XeVanChuyen);
            
        }


        private void btThem_Click(object sender, EventArgs e)
        {
            btThem.Enabled = false;
            btSua.Enabled = false;
            btXoa.Enabled = false;

            btHuyBo.Enabled = true;
            btGhiNhan.Enabled = true;
            this.tbl_XeVanChuyenTableAdapter.Fill(this.xeVanChuyenDataSet.tbl_XeVanChuyen);
            this.tbl_XeVanChuyenBindingSource.AddNew();
            if (!string.IsNullOrEmpty(IDHD))
            { uiComboBox3.SelectedValue = long.Parse(IDHD); }
            editBox1.Text = "";
            iDTextBox.Text = GetID();
            Add = true;
            soXeTextBox.Focus();
        
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Bạn muốn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tbl_XeVanChuyenBindingSource.RemoveCurrent();
            }
        }

        private void btGhiNhan_Click(object sender, EventArgs e)
        {
         
            if (!SaveXeVanChuyen())
                {return;}
                DoSave();
                _ID1 =long.Parse(iDTextBox.Text);
                if (Add)
                {
                    if (MessageBox.Show("Ghi nhận thành công!\nBạn có muốn tiếp tục?\n(Yes-Tiếp tục  No-Đóng cửa sổ làm việc)", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        Close();
                    IDHD = uiComboBox3.SelectedValue.ToString();
                    btThem_Click(null, null);
                }
                else
                {
                    Close();
                }
            
        }

        private void btHuyBo_Click(object sender, EventArgs e)
        {
            soXeTextBox.Text="";
            tenLaiXeTextBox.Text="";
           // maSoXeTextBox.Text="";
            ghiChuTextBox.Text = "";
            trongTaiTextBox.Text = "";
            loaiXeTextBox.Text = "";
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            btThem.Enabled = false;
            btSua.Enabled = false;
            btXoa.Enabled = true;
            btHuyBo.Enabled = true;
            btGhiNhan.Enabled = true;
            Add = false;
            TruyenDL(false);
            _ID1 = long.Parse(iDTextBox.Text);
        }

        private void uiComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            uiComboBox1.SelectedValue = uiComboBox3.SelectedValue;
            uiComboBox2.SelectedValue = uiComboBox3.SelectedValue;
            uiComboBoxHoTenCHD.SelectedValue = uiComboBox3.SelectedValue;
        }
        private void TruyenDL(Boolean Add1)
        {
            try {
                float a = 0;
                if (Add1)
                {
                    if (editBox1.Text != "")
                    {
                        a = float.Parse(editBox1.Text) * 1000;
                        trongTaiTextBox.Text = a.ToString();
                    }
                    else { trongTaiTextBox.Text = ""; }
                }
                else
                {
                    if (trongTaiTextBox.Text != "")
                    {
                        a = float.Parse(trongTaiTextBox.Text) / 1000;
                        editBox1.Text = a.ToString();
                    }
                    else { editBox1.Text = ""; } 
                    
                    //editBox1.Text = trongTaiTextBox.Text;
                }
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

        private void soXeTextBox_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

        private void soXeTextBox_Enter(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.LightGray;
        }

        private void ghiChuTextBox_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            btGhiNhan.Focus();
        }
       
       
    }
}