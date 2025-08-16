using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using MDSolution;

namespace DACASUCO.MDForms
{
    public partial class frmTheChan : Form
    {
        long _HDVCID = 0;
        long ID = -1;
        bool kt = false;
        long SoCT = 0;
        int count = 0;
        public long SoTien = 0;
        public long CanCel = 0;
        List<string> Xe_UnSelect=new List<string>();
        List<string> Xe_Select=new List<string>();
        public frmTheChan()
        {
            InitializeComponent();

        }
        public frmTheChan(long HDVCID, bool add)
        {
            InitializeComponent();
            LoadCBNoiTamUng();
            LoadCBVTVC();


            if (add == true)
            {

                kt = true;
                clsHopDongVanChuyen objHDVC = new clsHopDongVanChuyen(HDVCID);
                objHDVC.Load(null, null);
                txtHoTen.Text = objHDVC.TenChuHopDong;
                _HDVCID = HDVCID;
                LoadCheckListXe();
                for (int i = 0; i < chkListXe.Items.Count; i++) chkListXe.SetItemChecked(i, false);
                string strSQL = "SELECT (Max(SoChungTu)+1) FROM tbl_UngVaTTuVanChuyen";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                int SCT = 1;
                string TG = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (TG != "")
                {
                    SCT = int.Parse(TG);
                }
                txtSCT.Text = SCT.ToString();

            }
            else
            {
                clsUngVatTuVanChuyen objUVT = new clsUngVatTuVanChuyen(HDVCID);
                objUVT.Load(null, null);
                _HDVCID = objUVT.HopDongVanChuyenID;
                clsHopDongVanChuyen objHDVC = new clsHopDongVanChuyen(_HDVCID);
                objHDVC.Load(null, null);
                txtHoTen.Text = objHDVC.TenChuHopDong;
                SoCT =long.Parse(objUVT.SoChungTu);
                LoadCheckListXe();
                for (int i = 0; i < chkListXe.Items.Count; i++)
                {
                    chkListXe.SetItemChecked(i, true);
                   
                }
                txtGia.Text = objUVT.DonGia.ToString();
                txtSCT.Text = objUVT.SoChungTu.ToString();
                txtSL.Text = objUVT.SoLuong.ToString();
                txtSoTien.Text = objUVT.SoTien.ToString();
                cbNoiNhan.SelectedValue = objUVT.NoiTamUngVatTuID;
                cbLoai.SelectedValue = objUVT.VatTuID;
                cldNgay.Value = objUVT.NgayUng;
                rtbGhiChu.Text = objUVT.GhiChu;
                txtSCT.Text = objUVT.SoChungTu.ToString();

                ID = objUVT.ID;
               
              }

        }

        public void cmdExit_Click(object sender, EventArgs e)
        {
            CanCel = 1;
            this.Close();
        }
        public void LoadCBVTVC()
        {
            string strSQL = "SELECT * FROM tbl_VatTuVanChuyen";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            DataRow dr = ds.Tables[0].NewRow();
            dr["ID"] = 0;
            dr["Ten"] = "";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cbLoai.DisplayMember = "Ten";
            cbLoai.ValueMember = "ID";
            cbLoai.DataSource = ds.Tables[0];
            cbLoai.SelectedValue = 0;

        }
        public void LoadCBNoiTamUng()
        {
            string strSQL = "SELECT * FROM tbl_NoiTamUngVatTu";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            DataRow dr = ds.Tables[0].NewRow();
            dr["ID"] = 0;
            dr["Ten"] = "";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cbNoiNhan.DisplayMember = "Ten";
            cbNoiNhan.ValueMember = "ID";
            cbNoiNhan.DataSource = ds.Tables[0];
            cbNoiNhan.SelectedValue = 0;
        }
       public void LoadCheckListXe()
        {
            string strSQL = "SELECT ID,SoXe FROM tbl_XeVanChuyen where HopDongVanChuyenID=" + _HDVCID;
            //string strAND = "";
            //if (kt)
            //{
            //    strAND = " And (TienTheChan=0 OR TienTheChan is Null)";
            //}
            //else
            //{
            //    strAND = " And SoCT=" + SoCT.ToString();
            //}
            //strSQL = strSQL + strAND;
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
          
            if (ds.Tables[0].Rows.Count > 0)
            {
                ((ListBox)chkListXe).DataSource = ds.Tables[0];
                ((ListBox)chkListXe).DisplayMember = "SoXe";
                ((ListBox)chkListXe).ValueMember = "ID";
              
                             
            }

        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            if (txtGia.Text == "") txtGia.Text = "0";

            if (txtSL.Text != "")
            {

                int SL = int.Parse(txtSL.Text);
                int Gia = int.Parse(txtGia.Text);
                txtSoTien.Text = (SL * Gia).ToString();
            }

        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            if (txtSL.Text == "") txtSL.Text = "0";
            if (txtGia.Text != "")
            {
                int SL = int.Parse(txtSL.Text);
                int Gia = int.Parse(txtGia.Text);
                txtSoTien.Text = (SL * Gia).ToString();
            }
        }

        private bool Test()
        {
           
            if ((cbLoai.SelectedValue.ToString() == "0") || (cbLoai.SelectedValue == null))
            {
                MessageBox.Show("Bạn chưa chọn loại!", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLoai.Focus();
                return false;
            }
            if (cbNoiNhan.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn nơi nhận!", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbNoiNhan.Focus();
                return false;
            }
           
            if (txtGia.Text == ""||txtGia.Text == "0")
            {
                MessageBox.Show("Bạn chưa nhập giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGia.Focus();
                return false;
            }
            if (txtSL.Text == "" || txtSL.Text == "0")
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGia.Focus();
                return false;
            }
            if (txtSoTien.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoTien.Focus();
                return false;
            }
            return true;
        }

        public void cmdLuu_Click(object sender, EventArgs e)
        {
            if (Test())
            {
                clsUngVatTuVanChuyen objUVT;
                if (kt)
                {
                    objUVT = new clsUngVatTuVanChuyen();

                }
                else
                {
                    objUVT = new clsUngVatTuVanChuyen(ID);
                }
                objUVT.Load(null, null);
                objUVT.NoiTamUngVatTuID = long.Parse(cbNoiNhan.SelectedValue.ToString());
                objUVT.VuTrongID = MDSolution.DACASUCO_App.VuTrongID;
                objUVT.VatTuID = long.Parse(cbLoai.SelectedValue.ToString());
                objUVT.HopDongVanChuyenID = _HDVCID;
                objUVT.NgayUng = cldNgay.Value;
                objUVT.SoChungTu = txtSCT.Text;
                objUVT.NgayUng = cldNgay.Value;
                objUVT.GhiChu = rtbGhiChu.Text;
                objUVT.SoLuong = long.Parse(txtSL.Text);
                objUVT.DonGia = long.Parse(txtGia.Text);
                objUVT.SoTien = long.Parse(txtSoTien.Text);

                try
                {


                    if (cbLoai.SelectedIndex == 1)
                    {
                        for (int i = 0; i < Xe_Select.Count; i++)
                        {


                            ID = MDSolutionEntities.DBModule.GetNewID(typeof(clsUngVatTuVanChuyen), "tbl_UngVatTuVanChuyen", null, null);
                            string sql = "Insert Into tbl_UngVatTuVanChuyen (ID,HopDongVanChuyenID,VatTuID,SoLuong,DonGia,NgayUng,SoChungTu,VuTrongID,SoTien,GhiChu,NoiTamUngVatTuID,XeID)" +
                                " Values(" + ID.ToString() + "," + _HDVCID.ToString() + "," + cbLoai.SelectedValue.ToString() + "," + "1" + "," + txtGia.Text + "," + MDSolutionEntities.DBModule.RefineDatetime(cldNgay.Value) + "," +
                                txtSCT.Text + "," + MDSolution.DACASUCO_App.VuTrongID.ToString() + "," + txtGia.Text + ",N'" + rtbGhiChu.Text + "'," + cbNoiNhan.SelectedValue.ToString() + "," + GetXeID(Xe_Select[i].ToString()) + ")";
                            MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                        }
                        //for (int i = 0; i < Xe_UnSelect.Count; i++)
                        //{

                        //    string sql = "Update tbl_XeVanChuyen set SoCT=0,TienTheChan=0 Where Soxe=N'" + Xe_UnSelect[i].ToString() + "'";
                        //    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                        //}
                    }
                    else
                    {
                        objUVT.Save(null, null);
                    }
                    MessageBox.Show("Bạn đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SoTien = long.Parse(txtSoTien.Text);
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Đã có lỗi khi lưu dữ liệu! \n Hãy kiểm tra lại dữ liệu đầu vào", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
        private long GetXeID(string SoXe)
        {
            string sql="Select ID from tbl_XeVanChuyen Where SoXe=N'"+SoXe+"'";
            return long.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sql,null,null));
        }

        private void chkListXe_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
            {
                if (!Xe_UnSelect.Contains(chkListXe.GetItemText(chkListXe.Items[e.Index])))
                {
                    Xe_UnSelect.Add(chkListXe.GetItemText(chkListXe.Items[e.Index]));
                    Xe_Select.Remove(chkListXe.GetItemText(chkListXe.Items[e.Index]));
                }
                    
                    count = count - 1;
        }
            else
            {
                if (!Xe_Select.Contains(chkListXe.GetItemText(chkListXe.Items[e.Index])))
                {
                    Xe_Select.Add(chkListXe.GetItemText(chkListXe.Items[e.Index]));
                    Xe_UnSelect.Remove(chkListXe.GetItemText(chkListXe.Items[e.Index]));
                }
                   
                    count = count + 1;
             }
            txtSL.Text = count.ToString();
         
        }

        private void cbLoai_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbLoai.SelectedIndex == 1)
            {
                txtSL.ReadOnly = true;
                txtSL.BackColor = Color.White;
                chkListXe.Enabled = true;
                lblDV.Text = "(xe)";
            }
            else
            {
                txtSL.ReadOnly = false;
                chkListXe.Enabled = false;
                lblDV.Text = "(sợi)";
            }
            txtGia.Text = "";
            txtSL.Text = "";
            txtSoTien.Text = "";
        }

        private void frmTheChan_Load(object sender, EventArgs e)
        {
            cbLoai.SelectedIndex = 1;
        }
    }

}
