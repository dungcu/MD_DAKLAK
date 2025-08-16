using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using MDSolution;

namespace DACASUCO.MDForms
{
    public partial class frmDM_HDDT : Form
    {
        public frmDM_HDDT()
        {
            InitializeComponent();
        }
        private string MaHD = "";
        private long HD_ID = 0;
        DataSet DS = null;
        long UserID = 0;
        long VuTrongId = 0;
        long LoaiHD = 0;
        long ThoiHan = 0;
        long TramID = 0;
        public long OK = 0;
        DateTime NgayKy = DateTime.Now;
       
        public frmDM_HDDT(string MaHDDT, long HDID)
        {
            InitializeComponent();
            MaHD = MaHDDT;
            HD_ID = HDID;
            clsHopDong objHD = new clsHopDong(HDID);
            objHD.Load(null, null);
            txtMa.Text = objHD.MaHopDong;
            txtHoTen.Text = objHD.HoTen;
            this.LoadCBLoaiHD();
            this.LoadCBUser();
            this.LoadCBVuTrong();
            this.LoadCBTram();
            try
            {
                string sql = "Select * from tbl_HopDongDauTu Where MaHDDT=N'" + MaHD + "' and HopDongID=" + HD_ID.ToString() + " AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                DS = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            }
            catch
            {
                
            }
            if(DS.Tables[0].Rows.Count>0)
            {
                txtMaHDDT.Text = DS.Tables[0].Rows[0]["MaHDDT"].ToString();
                txtThoiHan.Text = DS.Tables[0].Rows[0]["ThoiHanHD"].ToString();
                dtNgay.Value=DateTime.Parse(DS.Tables[0].Rows[0]["NgayKy"].ToString());
                LoaiHD = long.Parse(DS.Tables[0].Rows[0]["LoaiHDDT_ID"].ToString());
                ThoiHan = long.Parse(DS.Tables[0].Rows[0]["ThoiHanHD"].ToString());
                UserID = long.Parse(DS.Tables[0].Rows[0]["UserID"].ToString());
                NgayKy = dtNgay.Value;
                VuTrongId = long.Parse(DS.Tables[0].Rows[0]["VuTrongID"].ToString());
                TramID = long.Parse(DS.Tables[0].Rows[0]["TramID"].ToString());
                cbLoaiHD.SelectedValue = LoaiHD;// long.Parse(DS.Tables[0].Rows[0]["LoaiHDDT_ID"].ToString());
                cbUser.SelectedValue = UserID;// long.Parse(DS.Tables[0].Rows[0]["UserID"].ToString());
                cbVuTrong.SelectedValue = VuTrongId;// long.Parse(DS.Tables[0].Rows[0]["VuTrongID"].ToString());
                cbTram.SelectedValue = TramID;// long.Parse(DS.Tables[0].Rows[0]["TramID"].ToString());
            }
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
            string sql = "Select ID,HoTen from sys_User";
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
            string sql = "Select ID,Ten from tbl_VuTrong where ID=" + MDSolution.DACASUCO_App.VuTrongID.ToString(); //"Select ID,Ten from tbl_VuTrong Order by Ten DESC";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            //DataRow dr = ds.Tables[0].NewRow();
            //dr["ID"] = 0;
            //dr["Ten"] = "";
           // ds.Tables[0].Rows.InsertAt(dr, 0);
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
            if ((txtMaHDDT.Text != "")&&(MaHD!=txtMaHDDT.Text.Replace(" ","")))
            {
                string sMaHD = txtMaHDDT.Text.Replace(" ","");
                string sql = "Select MaHDDT,HopDongID from tbl_HopDongDauTu where MaHDDT=N'" + sMaHD + "'";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    long HDID = long.Parse(ds.Tables[0].Rows[0]["HopDongID"].ToString());
                    clsHopDong objHD = new clsHopDong(HDID);
                    objHD.Load(null, null);
                    MessageBox.Show("Mã HĐĐT " + sMaHD + " đã tồn tại!" + "\n" + "Thuộc về chủ mía " + objHD.HoTen + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHDDT.Focus();
                }

            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (Edited())
            {
                if (Test())
                
                {

                    if (MessageBox.Show("Bạn chắc chắn sửa thông tin HĐĐT như đã khai báo ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string VTID = MDSolution.DACASUCO_App.VuTrongID.ToString();
                        try
                        {
                            string sMaHD = txtMaHDDT.Text.Replace(" ","");
                            string sql = "Select MaHDDT from tbl_ThuaRuong Where MaHDDT=N'" + MaHD + "'  And HopDongID=" + HD_ID+" AND VuTrongID="+VTID;
                            DataSet ds=MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                sql = "Update tbl_ThuaRuong Set MaHDDT=N'" + sMaHD + "',UserID=" + cbUser.SelectedValue.ToString() + ",TramNongVuID=" + cbTram.SelectedValue.ToString() + " Where MaHDDT=N'" + MaHD + "'  And HopDongID=" + HD_ID+" AND VuTrongID="+VTID;
                                MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            }
                            sql = "Select MaHDDT from tbl_DauTu Where MaHDDT=N'" + MaHD + "'  And HopDongID=" + HD_ID;
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                sql = "Update tbl_DauTu Set MaHDDT=N'" + sMaHD + "',LoaiHopDong_ID=" + cbLoaiHD.SelectedValue.ToString() + " Where MaHDDT=N'" + MaHD + "'  And HopDongID=" + HD_ID + " AND VuTrongID=" + VTID;
                                MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            }

                            sql = "Select MaHDDT from tbl_NoCuChuHopDong Where MaHDDT=N'" + MaHD + "'  And HopDongID=" + HD_ID;
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                sql = "Update tbl_NoCuChuHopDong Set MaHDDT=N'" + sMaHD + "',TramID=" + cbTram.SelectedValue.ToString() + " Where MaHDDT=N'" + MaHD + "' And HopDongID=" + HD_ID + " AND VuTrongID=" + VTID;
                                MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            }

                            sql = "Update tbl_HopDongDauTu Set MaHDDT=N'" + sMaHD + "',LoaiHDDT_ID=" + cbLoaiHD.SelectedValue.ToString() + ",NgayKy=" + MDSolutionEntities.DBModule.RefineDatetime(dtNgay.Value) + ",UserID=" + cbUser.SelectedValue.ToString() +
                                ",VuTrongID=" + cbVuTrong.SelectedValue.ToString() + ",ThoiHanHD=" + txtThoiHan.Text + ",TramID=" + cbTram.SelectedValue.ToString() + " Where MaHDDT=N'" + MaHD + "' And HopDongID=" + HD_ID + " AND VuTrongID=" + VTID;
                            MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            sql = "Update tbl_NhapMia set MaHDDT=N'" + sMaHD + "' Where MaHDDT=N'" + MaHD + "' AND VuTrongID=" + VTID;
                            MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            MessageBox.Show("Đã sửa lại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            OK = 1;
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Đã có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
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

       private bool Edited()
        {
            int i = 0;
           if (ThoiHan.ToString() != txtThoiHan.Text)
            {
                i=1;
            }
           if (MaHD != txtMaHDDT.Text.Replace(" ",""))
           {
              i=1;
           }
           if (UserID != long.Parse(cbUser.SelectedValue.ToString()))
           {
               i=1;
           }
           if (LoaiHD != long.Parse(cbLoaiHD.SelectedValue.ToString()))
           {
               i=1;
           }
           if (VuTrongId != long.Parse(cbVuTrong.SelectedValue.ToString()))
           {
               i=1;
           }
           if (NgayKy != dtNgay.Value)
           {
               i=1;
           }
           if (TramID != long.Parse(cbTram.SelectedValue.ToString()))
           {
               i = 1;
           }
           if (i == 0)
           {
               return false;
           }
           else
           {
               return true;
           }
            
        }
   }
}
