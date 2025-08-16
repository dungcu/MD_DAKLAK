using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace DACASUCO.MDForms
{
    public partial class frmDM_HDDT_ADD : Form
    {
        public frmDM_HDDT_ADD()
        {
            InitializeComponent();
        }
        private long HD_ID = 0;
        public long OK=0;
            
        public frmDM_HDDT_ADD(long HDID)
        {
            InitializeComponent();
            HD_ID = HDID;
            clsHopDong objHD = new clsHopDong(HDID);
            objHD.Load(null, null);
            txtMa.Text = objHD.MaHopDong;
            txtHoTen.Text = objHD.HoTen;
            LoadCBLoaiHD();
            LoadCBUser();
            LoadCBVuTrong();
            LoadCBTram();
            cbVuTrong.SelectedValue = MDSolution.DACASUCO_App.VuTrongID;
           
        }
        private void LoadCBTram()
        {
            string sql = "Select ID,Ten from tbl_TramNongVu";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            DataRow dr = ds.Tables[0].NewRow();
            dr["ID"] = 0;
            dr["Ten"] = "";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cbTram.DataSource = ds.Tables[0];
            cbTram.ValueMember = "ID";
            cbTram.DisplayMember = "Ten";
        }
        private void LoadCBUser()
        {
            string sql = "Select ID,HoTen from sys_User order by RolesID";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            DataRow dr = ds.Tables[0].NewRow();
            dr["ID"] = 0;
            dr["HoTen"] = "";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cbUser.DataSource = ds.Tables[0];
            cbUser.ValueMember = "ID";
            cbUser.DisplayMember = "HoTen";
        }
        private void LoadCBLoaiHD()
        {
            string sql = "Select ID,Ten from LoaiHopDong";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            DataRow dr = ds.Tables[0].NewRow();
            dr["ID"] = 0;
            dr["Ten"] = "";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cbLoaiHD.DataSource = ds.Tables[0];
            cbLoaiHD.ValueMember = "ID";
            cbLoaiHD.DisplayMember = "Ten";
        }
        private void LoadCBVuTrong()
        {
            string sql = "Select ID,Ten from tbl_VuTrong where ID="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            cbVuTrong.DataSource = ds.Tables[0];
            cbVuTrong.ValueMember = "ID";
            cbVuTrong.DisplayMember = "Ten";
        }


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (cmdCancel.Focused)
            {
                this.Close();
            }
        }

        private void txtMaHDDT_Leave(object sender, EventArgs e)
        {
            if (txtMaHDDT.Text != "")
            {
                string sMaHD = txtMaHDDT.Text.Replace(" ","");
                string sql = "Select MaHDDT,HopDongID from tbl_HopDongDauTu where MaHDDT=N'" + sMaHD + "' And VuTrongID="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    long HDID = long.Parse(ds.Tables[0].Rows[0]["HopDongID"].ToString());
                    clsHopDong objHD = new clsHopDong(HDID);
                    objHD.Load(null, null);
                    MessageBox.Show("Mã HĐĐT " + sMaHD + " trong vụ trồng này đã tồn tại!" + "\n" + "Thuộc về chủ mía " + objHD.HoTen + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHDDT.Focus();
                }

            }
        }
       
        private void cmdOK_Click(object sender, EventArgs e)
        {
          if (Test())
                
                {
                        try
                        {
                            string sMaHD = txtMaHDDT.Text.Replace(" ","");
                            string sql = "Insert Into tbl_HopDongDauTu (HopDongID,MaHDDT,LoaiHDDT_id,NgayKy,UserID,VuTrongID,ThoiHanHD,TramID) Values(" +
                                HD_ID.ToString() + ",N'" + sMaHD + "'," + cbLoaiHD.SelectedValue.ToString() + "," + MDSolutionEntities.DBModule.RefineDatetime(dtNgay.Value) + "," + cbUser.SelectedValue.ToString() + "," +
                                cbVuTrong.SelectedValue.ToString() + "," + txtThoiHan.Text + ","+cbTram.SelectedValue.ToString()+")";
                            MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                           
                            MessageBox.Show("Bạn đã thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            OK = 1;
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Đã có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
               }
           
         }

        private bool Test()
        {
            if (txtMaHDDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã Hợp đồng đầu tư", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHDDT.Focus();
                return false;
            }

            if ((cbVuTrong.SelectedValue.ToString() == "0") || (cbVuTrong.SelectedValue == null))
            {
                MessageBox.Show("Bạn chưa chọn Vụ trồng", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbVuTrong.Focus();
                return false;
            }
            if (cbUser.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn Người quản lý hợp đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbUser.Focus();
                return false;
            } 
            if (cbLoaiHD.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn Loại Hợp đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLoaiHD.Focus();
                return false;
            }
            if (txtThoiHan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Thời hạn HĐ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtThoiHan.Focus();
                return false;
            }
            if (cbTram.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn Trạm quản lý HĐ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbTram.Focus();
                return false;
            }
            return true;
        }

    }
}
