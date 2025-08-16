using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDForms;
using MDSolutionEntities;
using MDSolution;

namespace MDSolution
{
    public partial class frmTheoDoiThuHoach : Form
    {

        private clsHoTro oHT = new clsHoTro();
        private NodeDonVi nDonVi = new NodeDonVi();        
        private clsHopDong oHD = new clsHopDong();        
        private clsDauTu oDT = new clsDauTu();
        private clsDanhMucDauTu oDMDT = new clsDanhMucDauTu();
        private clsDanhMucHoTro oDMHT = new clsDanhMucHoTro();
        private string date = "";
        //Khai bao cho phan Dau Tu
        //private DataSet ddlThuaRuongSource;        
        public frmTheoDoiThuHoach()
        {
            InitializeComponent();
            CommonClass.loadTreeDonVi(treeDonVi);
        }
        public frmTheoDoiThuHoach(string ID)
        {
            InitializeComponent();
            CommonClass.loadTreeDonVi(treeDonVi);
            LoadHopDong(ID);
            //LoadThonSource();            

        }
        private void LoadHopDong(string ID )
        {
            DataSet ds;
            string strSQL = "SELECT *, (TongTrongLuong-TrongLuongXe) as MiaQuaCan, (TongTrongLuong-TrongLuongXe-TrongLuongTapVat)as MiaSach FROM V_TheoDoiVanChuyen ";
            switch (nDonVi.Type)
            {
                case DonviTypeHD.Xa: strSQL += " WHERE ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviTypeHD.Thon: strSQL += " WHERE ThonID=" + nDonVi.DonViID; break;                
            }
            if (chk_date.Checked)
            {
                if (nDonVi.Type.ToString() =="Root")
                {
                    strSQL += " Where convert(varchar,ngayvanchuyen,103)='" + (date) + "'";
                }
                else
                {
                    strSQL += "  And convert(varchar,ngayvanchuyen,103)='" + (date) + "'";
                }
            }
            

            ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables.Count > 0)
            {
                this.grdHopDong.SetDataBinding(ds.Tables[0], "");
            }
        }
             

        private void treeDonVi_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nDonVi = (NodeDonVi)e.Node.Tag;
            uiPanel2.Text = nDonVi.DonViName;
            //LoadThonSource();
            LoadHopDong(nDonVi.DonViID);
            grdHopDong.Focus();
        }

        private void frmTheoDoiThuHoach_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            date = pick_date.Text;
            //pick_date.Text = DateTime.Now.Day.ToString();

        }

        private void chk_date_CheckedChanged(object sender, EventArgs e)
        {
            date = pick_date.Text;
            LoadHopDong(nDonVi.DonViID);
        }

        private void pick_date_ValueChanged(object sender, EventArgs e)
        {
            date = pick_date.Text;
            LoadHopDong(nDonVi.DonViID);
        }                       
    }
}