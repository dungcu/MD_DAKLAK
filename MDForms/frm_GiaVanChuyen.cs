using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; using MDSolutionEntities;
using MDSolution.MDForms;
using Janus.Windows.GridEX;

namespace MDSolution
{
    public partial class frm_GiaVanChuyen : Form
    {
        private DataSet gridDataSource;
        long IDTinh = 1;
        static frm_GiaVanChuyen _thefrm_GiaVanChuyen;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_GiaVanChuyen OneInstanceFrm
        {
            get
            {
                if (null == _thefrm_GiaVanChuyen || _thefrm_GiaVanChuyen.IsDisposed)
                {
                    _thefrm_GiaVanChuyen = new frm_GiaVanChuyen();
                }

                return _thefrm_GiaVanChuyen;
            }
        }
        public frm_GiaVanChuyen()
        {
            InitializeComponent();
        }
        private void Load_CB_Tinh()
        {
            string sql = "Select ID,Ten from tbl_Tinh order by ID";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cbTinh.DataSource = ds.Tables[0];
                cbTinh.ValueMember = "ID";
                cbTinh.DisplayMember = "Ten";
            }
            else
            {
                cbTinh.DataSource = null;

            }
        }
        private void LoadMainGrid(long TinhID)
        {
            if (TinhID > 0)
            {

                string strSQL = "SELECT * FROM tbl_GiaMia_ThongBao WHERE VuTrongID=" + DACASUCO_App.VuTrongID.ToString() + " And TinhID=" + IDTinh.ToString() + " Order By NgayApDung DESC";
                this.gridDataSource = DBModule.ExecuteQuery(strSQL, null, null);
                if (this.gridDataSource.Tables.Count > 0)
                {
                    this.gdThongBaoGia.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");
                }
                else
                {
                    this.gdThongBaoGia.DataSource = null;
                }
            }
        }


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void cmdThem_Click(object sender, EventArgs e)
        {
            frm_NhapTB_GiaVC frm = new frm_NhapTB_GiaVC(IDTinh, cbTinh.Text);
            frm.ShowDialog(this);
            int iOK = frm.OK;
            long ID = frm.MaxID;
            if (iOK == 1)
            {
                LoadMainGrid(IDTinh);
                GridEXFilterCondition condi = new GridEXFilterCondition(gdThongBaoGia.Tables[0].Columns["ID"], ConditionOperator.Equal, ID);
                gdThongBaoGia.Find(condi, 0, 1);
            }
        }


        private void gdMainGrid_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            long ID = 0;
            try
            {
                ID = long.Parse(this.gdThongBaoGia.GetValue("ID").ToString());
            }
            catch
            {
                ID = 0;
            }
            if (ID > 0)
            {
                if (e.Column.Key == "Sua")
                {
                    frm_NhapTB_GiaVC frm = new frm_NhapTB_GiaVC(ID);
                    frm.ShowDialog();
                    if (frm.OK == 1)
                    {
                        LoadMainGrid(IDTinh);
                        GridEXFilterCondition condi = new GridEXFilterCondition(gdThongBaoGia.Tables[0].Columns["ID"], ConditionOperator.Equal, ID);
                        gdThongBaoGia.Find(condi, 0, 1);
                    }
                }
                if (e.Column.Key == "CapNhat")
                {
                    // string TenTram = this.gdThongBaoGia.GetValue("TenTram").ToString();
                    string TenThongBao = this.gdThongBaoGia.GetValue("TenThongBao").ToString();
                    DateTime NgayApDung = DateTime.Parse(this.gdThongBaoGia.GetValue("NgayApDung").ToString());
                    int ApDungTheoGioCan = int.Parse(this.gdThongBaoGia.GetValue("ApDungTheoGioCan").ToString());

                    //frm_GiaVanChuyen_UpdateBack frm = new frm_GiaVanChuyen_UpdateBack(IDTinh, cbTinh.Text, TenThongBao, NgayApDung, ApDungTheoGioCan);
                    //frm.ShowDialog();


                }
            }
        }

        private void cmdChiTetTB_Click(object sender, EventArgs e)
        {
            long IDThongBao = 0;
            string TenTB = "";
            try
            {
                TenTB = this.gdThongBaoGia.GetValue("TenThongBao").ToString();
                IDThongBao = long.Parse(this.gdThongBaoGia.GetValue("ID").ToString());
            }
            catch
            {
                IDThongBao = 0;
                TenTB = "";
            }
            if (IDThongBao > 0)
            {
                //frm_NhapTB_Gia_ChiTiet frm = new frm_NhapTB_Gia_ChiTiet(IDThongBao, TenTB);
                //frm.ShowDialog();
                //if (frm.OK == 1)
                //{
                //    this.Load_ChiTiet_TB(IDThongBao);
                //    GridEXFilterCondition condi = new GridEXFilterCondition(gdChiThietThongBaoGia.Tables[0].Columns["ID"], ConditionOperator.Equal, frm.MaxID);
                //    gdChiThietThongBaoGia.Find(condi, 0, 1);
                //}
            }
        }

     
      

        private void frm_GiaVanChuyen_Load(object sender, EventArgs e)
        {
            if (DACASUCO_App.User.ID != 1)
            {
                clsComFunctions.checkControlsPermission(this, this.Name.ToString());
            }
            
            Load_CB_Tinh();
            cbTinh.SelectedIndex = 0;
            lblTitle.Text = lblTitle.Text + DACASUCO_App.TenVuTrong;
            grTB.Text = "Thông báo giá tỉnh " + cbTinh.Text;
            //grChitietTB_Gia.Text = "Chi tiết thông báo giá tỉnh " + cbTinh.Text;
         }

      

     

        private void cbTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                IDTinh = long.Parse(cbTinh.SelectedValue.ToString());
            }
            catch
            {
                return;
            }
            LoadMainGrid(IDTinh);
            grTB.Text =  "Thông báo giá tỉnh " + cbTinh.Text;
           // grChitietTB_Gia.Text =  "Chi tiết thông báo giá tỉnh " + cbTinh.Text;
        }

       
    }
}
