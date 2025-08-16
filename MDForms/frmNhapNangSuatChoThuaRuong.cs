using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using Janus.Windows.GridEX;
using MDSolution;

namespace DACASUCO.MDForms
{
    public partial class frmNhapNangSuatChoThuaRuong : Form
    {
        private string oTRID = "";
        public frmNhapNangSuatChoThuaRuong()
        {
            InitializeComponent();
            LoadChuHo("");
        }
        public frmNhapNangSuatChoThuaRuong(string HDID,string TRID)
        {
            InitializeComponent();
            LoadChuHo(HDID);
            oTRID = TRID;
        }

        // thanh lam constructor nay:
        public frmNhapNangSuatChoThuaRuong(string ThuaRuongID)
        {
            InitializeComponent();
            Load_DaTa_TuBanDieuTra(ThuaRuongID);
        }

        // load du cbo bai boc xep
        private void LoadDLCboBaiBocXep()
        {
            string SQL = "Select ID,TenBai from tbl_BaiTapKet";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(SQL, null, null);
            DataRow dr = ds.Tables[0].NewRow();
            dr["ID"] = 0;
            dr["TenBai"] = "";

            cbo_BaiBocXep.DataSource = ds.Tables[0];
            cbo_BaiBocXep.DisplayMember = "TenBai";
            cbo_BaiBocXep.ValueMember = "ID";
            cbo_BaiBocXep.SelectedValue = 0;
        }
        // thanh lam moi
        private void Load_DaTa_TuBanDieuTra(string ThuaRuongID)
        {
            LoadDLCboBaiBocXep();
            string sql = "Select * from View_TH_SuDungChoNhapNangSuat where ID =" + ThuaRuongID;
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);

            txtThuaRuongID.Text = ThuaRuongID.ToString();
            txtSoBDT.Text = ds.Tables[0].Rows[0]["SoBanDieuTra"].ToString();
            txtMaChuHo.Text = ds.Tables[0].Rows[0]["MaHopDong"].ToString();
            txtChuHo.Text = ds.Tables[0].Rows[0]["HoTen"].ToString();
            txtMaThuaRuong.Text = ds.Tables[0].Rows[0]["MaThuaRuong"].ToString();            
            txtGiongMia.Text = ds.Tables[0].Rows[0]["GiongMia"].ToString();
            txtkieuTrong.Text = ds.Tables[0].Rows[0]["KieuTrong"].ToString();
            txtLoaiDat.Text = ds.Tables[0].Rows[0]["LoaiDat"].ToString();
            txtMucDichTrong.Text = ds.Tables[0].Rows[0]["MucDichTrong"].ToString();
            txtNgayTrong.Text = ds.Tables[0].Rows[0]["NgayTrong"].ToString();
            txtRaiVu.Text = ds.Tables[0].Rows[0]["RaiVu"].ToString();
            txtTramNongVu.Text = ds.Tables[0].Rows[0]["TramNongvu"].ToString();
            xuDongTextBox.Text = ds.Tables[0].Rows[0]["XuDong"].ToString();

            // xu ly bai boc xep
            if (!ds.Tables[0].Rows[0].IsNull("BaiTapKetID"))
            {
                cbo_BaiBocXep.SelectedValue = long.Parse(ds.Tables[0].Rows[0]["BaiTapKetID"].ToString());
            }
            else
            {
                cbo_BaiBocXep.SelectedValue = 0;
            }
            //cbo_BaiBocXep.SelectedValue = long.Parse(ds.Tables[0].Rows[0]["ThonID"].ToString());
            // xu ly dien tich
            float a = 0;
            a = float.Parse(ds.Tables[0].Rows[0]["DienTich"].ToString());
            a = a / 10000;
            txtDienTich.Text = a.ToString();

            //dl dien tich du kien chat giong
            if ((!ds.Tables[0].Rows[0].IsNull("DienTichDuKienChatGiong")) && (ds.Tables[0].Rows[0]["DienTichDuKienChatGiong"].ToString() != "0"))
            {
                float b = 0;
                b = long.Parse(ds.Tables[0].Rows[0]["DienTichDuKienChatGiong"].ToString());
                b = b / 10000;
                editBox_DTDuKienChatGiong.Text = b.ToString();
            }
            else
            {
                editBox_DTDuKienChatGiong.Text = "";
            }

            //dl dien tich tinh toan
            if (!ds.Tables[0].Rows[0].IsNull("DienTichTinhToan"))
            {
                try
                {
                    float b = 0;
                    b = long.Parse(ds.Tables[0].Rows[0]["DienTichTinhToan"].ToString());
                    b = b / 10000;
                    txtDienTichTinhToan.Text = b.ToString();
                }
                catch
                {
                    txtDienTichTinhToan.Text = "0";
                }
            }
            else
            {
                txtDienTichTinhToan.Text = "0";
            }

            // dl nang suat du kien neu co
            if ((!ds.Tables[0].Rows[0].IsNull("NS1")) && (ds.Tables[0].Rows[0]["NS1"].ToString() != "0"))
            {
                float b = 0;
                b = long.Parse(ds.Tables[0].Rows[0]["NS1"].ToString());
                b = b / 1000;
                editBoxNSDKLan1.Text = b.ToString();
            }
            else
            {
                editBoxNSDKLan1.Text = "";
            }

            // dl san luong du kien neu co
            if ((!ds.Tables[0].Rows[0].IsNull("SL1")) && (ds.Tables[0].Rows[0]["SL1"].ToString() != "0"))
            {
                float b = 0;
                b = long.Parse(ds.Tables[0].Rows[0]["SL1"].ToString());
                b = b / 1000;
                editBoxSLDKLan1.Text = b.ToString();
            }
            else
            {
                editBoxSLDKLan1.Text = "0";
            }

            // dl nang suat lan 2 neu co
            if ((!ds.Tables[0].Rows[0].IsNull("NS2")) && (ds.Tables[0].Rows[0]["NS2"].ToString() != "0"))
            {
                float b = 0;
                b = long.Parse(ds.Tables[0].Rows[0]["NS2"].ToString());
                b = b / 1000;
                editBoxNSDKLan2.Text = b.ToString();
            }
            else
            {
                editBoxNSDKLan2.Text = "";
            }

            // dl san luong du kien neu co
            if ((!ds.Tables[0].Rows[0].IsNull("SL2")) && (ds.Tables[0].Rows[0]["SL2"].ToString() != "0"))
            {
                float b = 0;
                b = long.Parse(ds.Tables[0].Rows[0]["SL2"].ToString());
                b = b / 1000;
                editBoxSLDKLan2.Text = b.ToString();
            }
            else
            {
                editBoxSLDKLan2.Text = "0";
            }                        
            
        }

       
        private void LoadChuHo(string HDID)
        {
            try
            {
                DataSet ds;
                if (HDID != "")
                {

                    ds = clsHopDong.GetListbyWhere("ID,MaHopDong AS Ten", "ID=" + HDID, "", null, null);
                }
                else
                {
                    ds = clsHopDong.GetListbyWhere("ID,MaHopDong AS Ten", "ParentID>0", "", null, null);

                }

                if (ds.Tables.Count > 0)
                {
                    this.cbChuHo.DataSource = ds.Tables[0];                    
                }
                cbChuHo.SelectedValue = HDID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadMaThuaRuong(string CHID)
        {
            try
            {
                DataSet ds;
                ds = clsThuaRuong.GetListbyWhere("ID,MaThuaRuong AS Ten", "HopDongID=" + CHID + " AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString(), "", null, null);
                if (ds.Tables.Count > 0)
                {                
                    this.uiCbbMaThuaRuong.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      

        private void uiCbbChuHo_Leave(object sender, EventArgs e)
        {
            try
            {
                string strSQL;
                string strMaxID = "";
                if (cbChuHo.Text != "")
                {
                    strSQL = "SELECT Count(ID) FROM tbl_HopDong WHERE ParentID>0 AND MaHopDong=N'" + cbChuHo.Text + "'";
                    strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                    if (strMaxID == "0")
                    {
                        MessageBox.Show("Mã chủ hộ không đúng", "Thông báo");
                        cbChuHo.Focus();
                    }
                    else
                    {
                        strSQL = "SELECT HoTen FROM tbl_HopDong WHERE ParentID>0 AND MaHopDong=N'" + cbChuHo.Text + "'";
                        strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                        txtChuHo.Text = strMaxID.ToString();
                        LoadMaThuaRuong(cbChuHo.SelectedValue.ToString());
                        if (oTRID != "")
                        {
                            uiCbbMaThuaRuong.SelectedValue = oTRID; 
                        }
                        uiCbbMaThuaRuong.Focus();
                    }

                }             

            }
            catch { }
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

        private void editBoxNSDKLan1_Enter(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.SkyBlue;
        }

        private void uiCbbMaThuaRuong_Leave(object sender, EventArgs e)
        {
            try
            {
                string strSQL;
                string strMaxID = "";
                if (uiCbbMaThuaRuong.Text != "")
                {
                    strSQL = "SELECT Count(ID) FROM tbl_ThuaRuong WHERE MaThuaRuong=N'" + uiCbbMaThuaRuong.Text + "'";
                    strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                    if (strMaxID == "0")
                    {
                        MessageBox.Show("Mã thửa ruộng không đúng", "Thông báo");
                        uiCbbMaThuaRuong.Focus();
                    }
                    else
                    {
                        //LoadThuaRuong(uiCbbMaThuaRuong.Text);
                        editBoxNSDKLan1.Focus();
                    }

                }
              

            }
            catch { }
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }
        private void LoadThuaRuong(string MaThuaRuong)
        {
            try
            {
                string strSQL = "";
                strSQL = "SELECT tbl_ThuaRuong.ID, tbl_ThuaRuong.SoBanDieuTra, tbl_Thon.Ten AS Thon, (tbl_ThuaRuong.DienTich/10000) AS DienTich, tbl_ThuaRuong.XuDong,";
                strSQL += "tbl_GiongMia.Ten AS GiongMia, tbl_RaiVu.Ten AS KieuTrong, tbl_VuTrong.Ten AS VuTrong, tbl_MucDichTrong.MucDichTrong,";
                strSQL += "tbl_PheCanh.LyDoPheCanh AS HienTrang, tbl_LoaiDat.Ten AS LoaiDat, tbl_TramNongVu.Ten AS TramNongVu,tbl_ThuaRuong.NgayTrong,tbl_TinhTrangThuaRuong.Ten AS TTThuaRuong";
                strSQL += ",tbl_ThuaRuong.NangSuatDuKien,tbl_ThuaRuong.SanLuongDuKien,tbl_ThuaRuong.NangSuatDuKien1,tbl_ThuaRuong.SanLuongDuKien1 ";
                strSQL += "FROM tbl_PheCanh RIGHT OUTER JOIN tbl_TinhTrangThuaRuong RIGHT OUTER JOIN ";
                strSQL += "tbl_ThuaRuong ON tbl_TinhTrangThuaRuong.ID = tbl_ThuaRuong.TinhTrang ON ";
                strSQL += "tbl_PheCanh.ID = tbl_ThuaRuong.PheCanhID LEFT OUTER JOIN ";
                strSQL += "tbl_VuTrong ON tbl_ThuaRuong.VuTrongID = tbl_VuTrong.ID LEFT OUTER JOIN ";
                strSQL += "tbl_RaiVu ON tbl_ThuaRuong.RaiVuID = tbl_RaiVu.ID LEFT OUTER JOIN ";
                strSQL += "tbl_Thon ON tbl_ThuaRuong.ThonID = tbl_Thon.ID LEFT OUTER JOIN ";
                strSQL += "tbl_LoaiDat ON tbl_ThuaRuong.LoaiDatID = tbl_LoaiDat.ID LEFT OUTER JOIN ";
                strSQL += "tbl_GiongMia ON tbl_ThuaRuong.GiongMiaID = tbl_GiongMia.ID LEFT OUTER JOIN ";
                strSQL += "tbl_TramNongVu ON tbl_ThuaRuong.TramNongVuID = tbl_TramNongVu.ID LEFT OUTER JOIN ";
                strSQL += "tbl_MucDichTrong ON tbl_ThuaRuong.MucDichID = tbl_MucDichTrong.ID WHERE tbl_ThuaRuong.MaThuaRuong=N'" + MaThuaRuong + "'";

                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    txtDienTich.Text = dr["DienTich"].ToString();
                    txtGiongMia.Text = dr["GiongMia"].ToString();
                    txtHienTrang.Text = dr["HienTrang"].ToString();
                    txtkieuTrong.Text = dr["KieuTrong"].ToString();
                    txtLoaiDat.Text = dr["LoaiDat"].ToString();
                    txtMucDichTrong.Text = dr["MucDichTrong"].ToString();
                    txtNgayTrong.Text = dr["NgayTrong"].ToString();
                    txtSoBDT.Text = dr["SoBanDieuTra"].ToString();
                    txtThon.Text = dr["Thon"].ToString();
                    txtTramNongVu.Text = dr["TramNongVu"].ToString();
                    txtTTThuaRuong.Text = dr["TTThuaRuong"].ToString();
                    xuDongTextBox.Text = dr["XuDong"].ToString();
                    txtVuTrong.Text = dr["VuTrong"].ToString();
                    editBoxNSDKLan1.Text = dr["NangSuatDuKien"].ToString();
                    editBoxSLDKLan1.Text = dr["SanLuongDuKien"].ToString();
                    editBoxNSDKLan2.Text = dr["NangSuatDuKien1"].ToString();
                    editBoxSLDKLan2.Text = dr["SanLuongDuKien1"].ToString();
                }
            }
            catch { }
        }

        private void editBoxNSDKLan1_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            // load dl từ số bản điều tra
            
        }

        private void editBoxNSDKLan2_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            //uiButtonSave.Focus();
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
                //if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
                //{
                //    switch (keyData)
                //    {
                //        case Keys.Enter:
                //            try
                //            {
                //                SendKeys.Send("{TAB}");

                //                //   btGhiNhan_Click(null, null);
                //            }
                //            catch { }
                //            break;
                //    }
                //}

                return base.ProcessCmdKey(ref msg, keyData);
            //}
        }

        private void uiCbbMaThuaRuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThuaRuong(uiCbbMaThuaRuong.Text);
        }

        private void cbChuHo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                string strSQL;
                string strMaxID = "";
                strSQL = "SELECT HoTen FROM tbl_HopDong WHERE ParentID>0 AND MaHopDong=N'" + cbChuHo.Text + "'";
                strMaxID = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                txtChuHo.Text = strMaxID.ToString();
                LoadMaThuaRuong(cbChuHo.SelectedValue.ToString());
            }
            catch { }
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtDienTichTinhToan.GetType().ToString());
            MessageBox.Show(label2.GetType().ToString());
            //if (uiCbbMaThuaRuong.Text != "")
            //{
            //    LoadThuaRuong(uiCbbMaThuaRuong.Text);
            //}
            //if (txtThuaRuongID.Text !="")
            //try
            //{
            //    Load_DaTa_TuBanDieuTra(txtThuaRuongID.Text);
            //}
            //catch
            //{ 
            //}

        }

        private void editBoxNSDKLan1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                    float a = 0;
                float b = 0;
                if (editBoxNSDKLan1.Text != "")
                {
                    if (float.TryParse(editBoxNSDKLan1.Text, out a))
                    {
                        b = a * float.Parse(txtDienTichTinhToan.Text);
                    }
                    else
                    {
                        MessageBox.Show("Năng suất phải nhập kiểu số");
                    }
                }
                editBoxSLDKLan1.Text = b.ToString();
            }
            catch { }

        }

        private void editBoxNSDKLan2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float a = 0;
                float b = 0;
                if (editBoxNSDKLan2.Text != "")
                {
                    if (float.TryParse(editBoxNSDKLan2.Text, out a))
                    {
                        b = a * float.Parse(txtDienTichTinhToan.Text);
                    }
                    else
                    {
                        MessageBox.Show("Năng suất phải nhập kiểu số");
                    }
                }
                editBoxSLDKLan2.Text = b.ToString();
            }
            catch { }

        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            //if (editBoxNSDKLan1.Text != "")
            //{
                clsThuaRuong oTR = new clsThuaRuong();
                try
                {
                    //if (uiCbbMaThuaRuong.Text != "")
                    //{
                    //oTR.ID = long.Parse(uiCbbMaThuaRuong.SelectedValue.ToString());
                    oTR.ID = long.Parse(txtThuaRuongID.Text);
                    oTR.Load(null, null);
                    if (editBoxNSDKLan1.Text == "")
                    {
                        oTR.NangSuatDuKien = 0;
                    }
                    else
                    {
                        oTR.NangSuatDuKien = decimal.Parse(editBoxNSDKLan1.Text) * 1000;
                    }
                    if (editBoxNSDKLan2.Text == "")
                    {
                        oTR.NangSuatDuKien1 = 0;
                    }
                    else
                    {
                        oTR.NangSuatDuKien1 = decimal.Parse(editBoxNSDKLan2.Text) * 1000;
                    }

                    //if (editBox_DTDuKienChatGiong.Text == "")
                    //{
                    //    oTR.DienTichDuKienChatGiong = 0;
                    //}
                    //else
                    //{
                    //    try
                    //    {
                    //        oTR.DienTichDuKienChatGiong = float.Parse(editBox_DTDuKienChatGiong.Text) * 10000;// luu lai bang m2
                    //    }
                    //    catch
                    //    {
                    //        MessageBox.Show("Diện tích dự kiến chặt giống nhập vào phải là số!", "Lỗi nhập dữ liêu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        editBox_DTDuKienChatGiong.Focus();
                    //        return;
                    //    }
                    //}
                    // san luong luu vao csdl là kg/ha
                    if (editBoxNSDKLan1.Text != "")
                        oTR.SanLuongDuKien = decimal.Parse(editBoxSLDKLan1.Text) * 1000;
                    else
                        oTR.SanLuongDuKien = 0;

                    if (editBoxNSDKLan2.Text != "")
                        oTR.SanLuongDuKien1 = decimal.Parse(editBoxSLDKLan2.Text) * 1000;
                    else
                        oTR.SanLuongDuKien1 = 0;

                    oTR.Save(null, null);

                    DateTime DT = oTR.NgayTrong;

                    // xu ly bai tap ket
                    if (cbo_BaiBocXep.SelectedValue != null || cbo_BaiBocXep.SelectedValue.ToString() != "0")
                    {
                        try
                        {
                            string strSQL = "Update tbl_ThuaRuong SET BaiTapKetID =" + cbo_BaiBocXep.SelectedValue.ToString() + " Where ID=" + txtThuaRuongID.Text;
                            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
                        }
                        catch
                        {
                            MessageBox.Show("Đã có lỗi khi lưu Bãi tập kết!\nHãy kiểm tra lại dữ liệu nhập vào", "Lỗi nhập dữ liêu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            string strSQL ="Update tbl_ThuaRuong SET BaiTapKetID =null Where ID=" + txtThuaRuongID.Text;
                            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
                            cbo_BaiBocXep.Focus();
                            return;
                        }
                    }

                    MessageBox.Show("Đã lưu lại thành công");
                    this.ClearTextBox();
                    cbo_BaiBocXep.SelectedValue = 0;
                    txtSoBDT.Focus();
                    //}
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi khi lưu!", "Lỗi nhập dữ liêu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            //}
            //else
            //{
            //    MessageBox.Show("Bạn chưa nhập năng suất lần 1!", "Lỗi nhập dữ liêu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void ClearTextBox()
        {
            //txtSoBDT.Text = "";
            //MessageBox.Show( editBox_DTDuKienChatGiong.GetType().ToString());
            foreach (Control ctr in uiGroupBox5.Controls)
            {
                if ((ctr.GetType().ToString() == "System.Windows.Forms.TextBox") || (ctr.GetType().ToString() == "Janus.Windows.GridEX.EditControls.EditBox"))
                {
                    //MessageBox.Show(ctr.Name);
                    
                    ctr.Text = "";
                }
            }
            foreach (Control ctr in uiGroupBox2.Controls)
            {
                if (ctr.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    ctr.Text = "";
                }
            }
           
        }

        private void cbChuHo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtThon_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoBDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || e.KeyChar == (char)Keys.Tab)
            {
                try
                {
                    string sql = "Select ID from tbl_ThuaRuong Where SoBanDieuTra = N'" + txtSoBDT.Text + "' And VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                    string IDThuaRuong = "";
                    IDThuaRuong = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null);
                    if (IDThuaRuong != "")
                    {
                        Load_DaTa_TuBanDieuTra(IDThuaRuong);
                        //editBoxNSDKLan1.Focus();
                        //
                    }
                    else
                    {
                        MessageBox.Show("Không có số bản điều tra như trên \n" + "Hãy kiểm tra lại số bản điều tra!", "Lỗi nhập dữ liêu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSoBDT.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Hãy kiểm tra lại số bản điều tra!", "Lỗi nhập dữ liêu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoBDT.Focus();
                    return;
                }
                
            }
        }

        private void txtSoBDT_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            //uiButtonSave.Focus();

            //try
            //{
            //    string sql = "Select ID from tbl_ThuaRuong Where SoBanDieuTra = N'" + txtSoBDT.Text + "'";
            //    string IDThuaRuong = "";
            //    IDThuaRuong = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql, null, null);
            //    if (IDThuaRuong != "")
            //    {
            //        Load_DaTa_TuBanDieuTra(IDThuaRuong);
            //        //editBoxNSDKLan1.Focus();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không có thửa ruộng nào có số bản điều tra như trên \n" + "Hãy kiểm tra lại số bản điều tra!", "Lỗi nhập dữ liêu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        //txtSoBDT.Focus();
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Hãy kiểm tra lại số bản điều tra!", "Lỗi nhập dữ liêu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //txtSoBDT.Focus();
            //}
        }

        private void uiButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoBDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void editBox_DTDuKienChatGiong_TextChanged(object sender, EventArgs e)
        {            
            if (editBox_DTDuKienChatGiong.Text != "")
            {
                float b = 0;
                if (float.TryParse(editBox_DTDuKienChatGiong.Text, out b))
                {
                    // san luong lan 1
                    if ((editBoxNSDKLan1.Text != "") && (editBoxSLDKLan1.Text != ""))
                    {
                        try
                        {
                            float dientichtinhtoan = 0;
                            float sanluong = 0;
                            dientichtinhtoan = float.Parse(txtDienTichTinhToan.Text) - b;
                            //dientichtinhtoan = dientichtinhtoan - b;
                            sanluong = dientichtinhtoan * float.Parse(editBoxNSDKLan1.Text);
                            editBoxSLDKLan1.Text = sanluong.ToString();
                        }
                        catch
                        {
                            editBoxSLDKLan1.Text = "";
                        }
                    }
                    // san luong lan 2
                    if ((editBoxNSDKLan2.Text != "") && (editBoxSLDKLan2.Text != ""))
                    {
                        try
                        {
                            float dientichtinhtoan = 0;
                            float sanluong = 0;
                            dientichtinhtoan = float.Parse(txtDienTichTinhToan.Text) - b;
                            //dientichtinhtoan = dientichtinhtoan - b;
                            sanluong = dientichtinhtoan * float.Parse(editBoxNSDKLan1.Text);
                            editBoxSLDKLan2.Text = sanluong.ToString();
                        }
                        catch
                        {
                            editBoxSLDKLan2.Text = "";
                        }
                    }
                }
            }           
        }

        private void cbo_BaiBocXep_Enter(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.SkyBlue;
        }

        private void cbo_BaiBocXep_TextChanged(object sender, EventArgs e)
        {
            //DataSet ds = clsBaiTapKet.GetListbyWhere("ID", "TenBai =" + cbo_BaiBocXep.Text, "", null, null);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    cbo_BaiBocXep.SelectedValue = long.Parse(ds.Tables[0].Rows[0][0].ToString());
            //}
            //else
            //{
            //    MessageBox.Show("Bãi bốc xếp này không đúng!\nHãy chọn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cbo_BaiBocXep.Focus();
            //}
        }

        private void cbo_BaiBocXep_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;

            if (cbo_BaiBocXep.Text != "")
            {
                DataSet ds = clsBaiTapKet.GetListbyWhere("ID", "TenBai =N'" + cbo_BaiBocXep.Text + "'", "", null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbo_BaiBocXep.SelectedValue = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                    //uiButtonSave.Focus();
                }
                else
                {
                    MessageBox.Show("Bãi bốc xếp này không đúng!\nHãy chọn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbo_BaiBocXep.Focus();
                    return;
                }
            }
            //uiButtonSave.Focus();
        }

        private void frmNhapNangSuatChoThuaRuong_Load(object sender, EventArgs e)
        {

        }

        private void cbo_BaiBocXep_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void editBoxNSDKLan1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter || e.KeyChar==(char)Keys.Tab)
            //{
            //    editBoxNSDKLan2.Focus();
            //}
        }

        private void editBoxNSDKLan2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if(e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            //{
            //    editBox_DTDuKienChatGiong.Focus();
            //}
        }

        private void editBox_DTDuKienChatGiong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if(e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            //{
            //    cbo_BaiBocXep.Focus();
            //}
        }

        private void cbo_BaiBocXep_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            //{
            //    uiButtonSave.Focus();
            //}
        }
        
    }
}