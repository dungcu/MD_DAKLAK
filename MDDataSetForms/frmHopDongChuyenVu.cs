using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using DACASUCO.MDForms.ThanhToan;
using MDSolution;

namespace DACASUCO.MDDataSetForms
{
    public partial class frmHopDongChuyenVu : Form
    {
        public DataTable dtHopDong { get; set; }
        public string HopDongID = "";
        public string MaHDDT = "";
        public frmHopDongChuyenVu()
        {
            InitializeComponent();
        }
        frm_ThanhToan2013_TimKiem frmSearch = new frm_ThanhToan2013_TimKiem();
        private void LoadccbVuTrong()
        {
            try
            {
                DataSet ds;
                ds = clsVuTrong.GetListbyWhere("", "", "", null, null);
                if (ds.Tables.Count > 0)
                {
                    this.VuTrongUIDCombobox.DataSource = ds.Tables[0];
                }
                int VTID = clsVuTrong.GetDefaultVuTrongTen(null, null);
                this.VuTrongUIDCombobox.SelectedValue = VTID;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadccbHDDT(string HopDongID)
        {
            if (HopDongID != "")
            {

                try
                {

                    string sqlHDDTVT = "select HopDongID,MaHDDT from tbl_HopDongDauTu where VuTrongID= " + (DACASUCO_App.VuTrongID - 1).ToString() + " AND HopDongID = " + HopDongID;
                    MaHopDongUIDCombobox.DataSource = MDSolutionEntities.DBModule.ExecuteQuery(sqlHDDTVT, null, null).Tables[0];
                    MaHopDongUIDCombobox.DisplayMember = "MaHDDT";
                    MaHopDongUIDCombobox.ValueMember = "HopDongID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btGhiNhan_Click(object sender, EventArgs e)
        {
            try
            {

                string sqlkiemtrma = " select * from tbl_hopdongdautu where MaHDDT ='" + MaHDDT + "' AND VuTrongID =" + DACASUCO_App.VuTrongID.ToString();
                string kiemtra = DBModule.ExecuteQueryForOneResult(sqlkiemtrma, null, null);

                if (kiemtra == null || kiemtra == "")
                {
                    string sqlhddt = "Insert into tbl_hopdongdautu(HopDongID,MaHDDT,LoaiHDDT_id,NgayKy,UserID,VuTrongID,ThoiHanHD,TramID) select HopDongID,MaHDDT,LoaiHDDT_id,NgayKy,UserID," + DACASUCO_App.VuTrongID.ToString() + " AS VuTrongID,ThoiHanHD,TramID from tbl_hopdongdautu   where MaHDDT = '" + MaHDDT + "' AND VuTrongID =" + (DACASUCO_App.VuTrongID - 1).ToString();
                    DBModule.ExecuteNoneBackup(sqlhddt, null, null);
                }
                else
                {
                    MessageBox.Show("Hợp đồng đã được chuyển rồi", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message.ToString(), "Kiểm tra lại hợp đồng");
            }

        }



        private void frmHopDongChuyenVu_Load(object sender, EventArgs e)
        {
            try
            {
                LoadccbHDDT(HopDongID);
                LoadccbVuTrong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message.ToString(), "Không có hợp đồng này");
            }

        }

        private void uiButtonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        void SearchHD()
        {
            if (dtHopDong == null)
            {
                dtHopDong = MDSolutionEntities.DBModule.ExecuteQuery("select ID, MaHopDong ,HoTen,isnull(Diachi,'') as Diachi,dbo.BoDauTiengViet(HoTen) as HoTenKhongDau from tbl_HopDong ", null, null).Tables[0];

            }

            DataView dv = dtHopDong.DefaultView;
            dv.RowFilter = "MaHopDong ='" + txtMaHD.Text + "'";
            if (dv.Count == 1)
            {
                txtTenChuMia.Text = dv[0]["HoTen"].ToString();
                txtDiaChi.Text = dv[0]["Diachi"].ToString();
                HopDongID = dv[0]["ID"].ToString();
                LoadccbHDDT(HopDongID);
            }
            else
            {
                //ReLoad();
            }

        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            SearchHD();
        }

        private void txtMaHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SearchHD();
            }
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            if (dtHopDong == null)
            {
                dtHopDong = MDSolutionEntities.DBModule.ExecuteQuery("select ID, MaHopDong ,HoTen,isnull(Diachi,'') as Diachi,dbo.BoDauTiengViet(HoTen) as HoTenKhongDau from tbl_HopDong ", null, null).Tables[0];

            }
            frmSearch.dtDataSearch = dtHopDong;
            frmSearch.txtMaHD.Text = "";
            frmSearch.txtTenChuMia.Text = "";
            frmSearch.txtMaHD.Focus();
            frmSearch.Search();
            frmSearch.StartPosition = FormStartPosition.CenterScreen;
            frmSearch.ShowDialog();
            this.txtMaHD.Text = frmSearch.MaHD;
            this.SearchHD();
        }

        private void txtMaHD_Leave(object sender, EventArgs e)
        {
            SearchHD();
            LoadccbHDDT(HopDongID);
        }

        private void MaHopDongUIDCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlTTHDDT = "select NgayKy,ThoiHanHD,HopDongID,MaHDDT from tbl_HopDongDauTu where VuTrongID= " + (DACASUCO_App.VuTrongID - 1).ToString() + " AND HopDongID = " + HopDongID;
            DataTable dtHopDongDT = DBModule.ExecuteQuery(sqlTTHDDT, null, null).Tables[0];
            DataView dv = dtHopDongDT.DefaultView;
            dv.RowFilter = "MaHDDT='" + MaHopDongUIDCombobox.Text + "'";
            if (dv.Count == 1)
            {
                lbl_NgayKyHDDT.Text = dv[0]["NgayKy"].ToString();
                lbl_ThoiHanKyHDDT.Text = dv[0]["ThoiHanHD"].ToString();

                MaHDDT = MaHopDongUIDCombobox.Text;
            }
        }
    }
}