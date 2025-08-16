using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using DACASUCO.MDDanhMuc;

namespace MDSolution
{
    public partial class frmDanhMucTuDien : Form
    {
        private long i = 0;
        private DataSet ddlHuyen;
        private DataSet ddlCum;
        private DataSet ddlTinh;
        private DataSet DMTuDien;
        private long[] themmoi = new long[10000];
        private bool delete = false;
        private string strNode="Tinh";
        private string Ten = "";
        private clsGiongMia oGM=new clsGiongMia();
        private clsLoaiDat oLD=new clsLoaiDat();
        private clsNoiDungChamSoc oNDCS=new clsNoiDungChamSoc();
        private clsPheCanh oPC=new clsPheCanh();
        private clsMucDichTrong oMDT = new clsMucDichTrong();
        private clsTramNongVu oTNV=new clsTramNongVu();
        private clsVuTrong oVT=new clsVuTrong();
        private clsVatTuVanChuyen oVTVC=new clsVatTuVanChuyen();
        private clsXa oXa = new clsXa();
        private clsHuyen oHuyen = new clsHuyen();
        private clsCum oCum = new clsCum();
        private clsTinh oTinh = new clsTinh();
        private clsRaiVu oRaiVu = new clsRaiVu();
        private clsHienTrangGiaoThong oHTGT = new clsHienTrangGiaoThong();
        public frmDanhMucTuDien()
        {
            InitializeComponent();
            Load_DMTuDien(strNode);
            LoadddlCum();
            LoadddlHuyen();
            LoadddlTinh();         
                           
        }
        private void LoadddlHuyen()
        {            
            try
            {
                string strSQL = "SELECT * FROM tbl_Huyen";
                this.ddlHuyen = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                this.gdVDMTD.DropDowns["ddlHuyen"].SetDataBinding(this.ddlHuyen.Tables[0], "");
            }
            catch 
            {
                MessageBox.Show("Không load Huyện");
            }

        }
        private void LoadddlCum()
        {

            try
            {
                string strSQL = "SELECT * FROM tbl_Cum";
                this.ddlCum = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                this.gdVDMTD.DropDowns["ddlCum"].SetDataBinding(this.ddlCum.Tables[0], "");
            }
            catch 
            {
                MessageBox.Show("Không thể load Trạm");
            }

        }
        private void LoadddlTinh()
        {

            try
            {
                string strSQL = "SELECT * FROM tbl_Tinh";
                this.ddlTinh = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                this.gdVDMTD.DropDowns["ddlTinh"].SetDataBinding(this.ddlTinh.Tables[0], "");
            }
            catch 
            {
                MessageBox.Show("Không load Tinh");
            }

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            strNode = e.Node.Name;
            Ten = e.Node.Text;
            Load_treeDMTD(strNode,Ten);

            if (e.Node.Name == "Xa")
            {
                //gdVDMTD.Dock = DockStyle.None;
                txtTimXa.Visible = true;
                label1.Visible = true;
            }
            else
            {
                //gdVDMTD.Dock = DockStyle.Fill;
                txtTimXa.Visible = false;
                label1.Visible = false;
            }

        }
        private void Load_DMTuDien(string strNode)
        {
            string strSQL = "SELECT * FROM tbl_" + strNode.ToString();
            this.DMTuDien = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (this.DMTuDien.Tables.Count > 0)
            {
                this.gdVDMTD.SetDataBinding(this.DMTuDien.Tables[0], "");
            }
        }

        private void frmDanhMucTuDien_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void gdVDMTD_AddingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                string sql = "";
                DataSet ds;
                 switch (strNode)
                    {
                        case "GiongMia":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên giống mía");
                        
                           sql = "SELECT count(*) as Dem FROM tbl_GiongMia Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString()+"'";
                         ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                         DataRow d0 = ds.Tables[0].Rows[0];
                         
                             if(long.Parse(d0["Dem"].ToString())>0)throw new Exception("Bạn nhập trùng tên giống mía");
                            break;
                        case "LoaiDat":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên loại đất");
                        
                            sql = "SELECT count(*) as Dem FROM tbl_LoaiDat Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString() +"'";
                         ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                         DataRow d1 = ds.Tables[0].Rows[0];
                         
                             if(long.Parse(d1["Dem"].ToString())>0)throw new Exception("Bạn nhập trùng tên loại đất");
                            break;
                        case "MucDichTrong":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("MucDichTrong").ToString())) throw new Exception("Bạn chưa nhập tên mục đích trồng");

                            sql = "SELECT count(*) as Dem FROM tbl_MucDichTrong Where MucDichTrong='" + this.gdVDMTD.GetValue("MucDichTrong").ToString() + "'";
                         ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                         DataRow d2 = ds.Tables[0].Rows[0];
                         
                             if(long.Parse(d2["Dem"].ToString())>0)throw new Exception("Bạn nhập trùng tên mục đích trồng");
                            break;
                        case "NoiDungChamSoc":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên nội dung chăm sóc");
                        
                            sql = "SELECT count(*) as Dem FROM tbl_NoiDungChamSoc Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString()+"'";
                         ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                         DataRow d3 = ds.Tables[0].Rows[0];
                         
                             if(long.Parse(d3["Dem"].ToString())>0)throw new Exception("Bạn nhập trùng tên nội dung chăm sóc");
                            break;
                        case "PheCanh":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("LyDoPheCanh").ToString())) throw new Exception("Bạn chưa nhập lý do phế canh");

                            sql = "SELECT count(*) as Dem FROM tbl_PheCanh Where LyDoPheCanh='" + this.gdVDMTD.GetValue("LyDoPheCanh").ToString() + "'";
                         ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                         DataRow d4 = ds.Tables[0].Rows[0];
                         
                             if(long.Parse(d4["Dem"].ToString())>0)throw new Exception("Bạn nhập trùng tên lý do phế canh");
                            break;
                        case "TramNongVu":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên trạm nông vụ");
                        
                            sql = "SELECT count(*) as Dem FROM tbl_TramNongVu Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString()+"'";
                         ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                         DataRow d5 = ds.Tables[0].Rows[0];
                         
                             if(long.Parse(d5["Dem"].ToString())>0)throw new Exception("Bạn nhập trùng tên trạm nông vụ");
                            break;
                        case "VuTrong":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên vụ trồng");
                        
                            sql = "SELECT count(*) as Dem FROM tbl_VuTrong Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString()+"'";
                         ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                         DataRow d6 = ds.Tables[0].Rows[0];
                         
                             if(long.Parse(d6["Dem"].ToString())>0)throw new Exception("Bạn nhập trùng tên vụ trồng");
                            break;
                        case "VatTuVanChuyen":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("MaVatTu").ToString())) throw new Exception("Bạn chưa nhập mã vật tư ứng vận chuyển");
                            sql = "SELECT count(*) as Dem FROM tbl_VatTuVanChuyen Where MaVatTu='" + this.gdVDMTD.GetValue("MaVatTu").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            DataRow dMVT = ds.Tables[0].Rows[0];

                            if (long.Parse(dMVT["Dem"].ToString()) > 0) throw new Exception("Bạn nhập trùng tên mã vật tư ");
                           
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên vật tư");
                        
                            sql = "SELECT count(*) as Dem FROM tbl_VatTuVanChuyen Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString()+"'";
                         ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                         DataRow d7 = ds.Tables[0].Rows[0];
                         
                             if(long.Parse(d7["Dem"].ToString())>0)throw new Exception("Bạn nhập trùng tên vật tư");
                            break;
                     case "HienTrangGiaoThong":
                         if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Muc").ToString())) throw new Exception("Bạn chưa nhập tên mục hiện trạng giao thông");

                         sql = "SELECT count(*) as Dem FROM tbl_HienTrangGiaoThong Where Muc='" + this.gdVDMTD.GetValue("Muc").ToString() + "'";
                         ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                         DataRow d8 = ds.Tables[0].Rows[0];

                         if (long.Parse(d8["Dem"].ToString()) > 0) throw new Exception("Bạn nhập trùng tên mục hiện trạng giao thông");
                           
                         break;
                     case "RaiVu":
                         if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên rải vụ");
                        
                         sql = "SELECT count(*) as Dem FROM tbl_RaiVu Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString()+"'";
                         ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                         DataRow d9 = ds.Tables[0].Rows[0];

                         if (long.Parse(d9["Dem"].ToString()) > 0) throw new Exception("Bạn nhập trùng tên rải vụ");
                           
                         break;
                     case "Xa":
                         if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("MaXa").ToString())) throw new Exception("Bạn chưa nhập mã xã");
                         sql = "SELECT count(*) as Dem FROM tbl_Xa Where MaXa='" + this.gdVDMTD.GetValue("MaXa").ToString() + "'";
                         ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                         DataRow dMX = ds.Tables[0].Rows[0];

                         if (long.Parse(dMX["Dem"].ToString()) > 0) throw new Exception("Bạn nhập trùng mã xã");
                           
                         if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên xã");
                        
                         sql = "SELECT count(*) as Dem FROM tbl_Xa Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString()+"'";
                         ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                         DataRow d10 = ds.Tables[0].Rows[0];

                         if (long.Parse(d10["Dem"].ToString()) > 0) throw new Exception("Bạn nhập trùng tên xã");
                           
                         break;
                     case "Huyen":
                         if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên huyện");
                        
                         sql = "SELECT count(*) as Dem FROM tbl_Huyen Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString()+"'";
                         ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                         DataRow d11 = ds.Tables[0].Rows[0];

                         if (long.Parse(d11["Dem"].ToString()) > 0) throw new Exception("Bạn nhập trùng tên huyện");
                           
                         break;
                     case "Cum":
                         if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên cụm");
                         oCum.DienTichTrienVong = long.Parse(this.gdVDMTD.GetValue("DienTichKieuTrong").ToString());
                        
                         sql = "SELECT count(*) as Dem FROM tbl_Cum Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString()+"'";
                         ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                         DataRow d12 = ds.Tables[0].Rows[0];

                         if (long.Parse(d12["Dem"].ToString()) > 0) throw new Exception("Bạn nhập trùng tên cụm");
                         
                           
                         break;
                     case "Tinh":
                         if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên tỉnh");
                        
                         sql = "SELECT count(*) as Dem FROM tbl_Tinh Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString()+"'";
                         ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                         DataRow d13 = ds.Tables[0].Rows[0];

                         if (long.Parse(d13["Dem"].ToString()) > 0) throw new Exception("Bạn nhập trùng tỉnh");
                           
                         break;

                    }
                

                if (!SaveDanhMucTuDien(true)) { e.Cancel = true; }
                else
                {
                    //MessageBox.Show("Bạn đã lưu lại thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    long them = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                    themmoi[i] = them;
                    i = i + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void gdVDMTD_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {           
                string message;
                long a = 0;          
       
       while (a < themmoi.Length)
       {
           long xoa = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
           if (themmoi[a] == xoa)
           {

                message = String.Format("Bạn muốn xóa bản ghi này?");

                if (MessageBox.Show(message, " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataRowView dr = (DataRowView)e.Row.DataRow;
                    switch (strNode)
                    {
                        case "GiongMia":
                            clsGiongMia oGM = new clsGiongMia(long.Parse(dr.Row.ItemArray[0].ToString()));
                            oGM.Delete(null, null);
                            break;
                        case "LoaiDat":
                            clsLoaiDat oLD = new clsLoaiDat(long.Parse(dr.Row.ItemArray[0].ToString()));
                            oLD.Delete(null, null); break;
                        case "MucDichTrong":
                            clsMucDichTrong oMDT = new clsMucDichTrong(long.Parse(dr.Row.ItemArray[0].ToString()));
                            oMDT.Delete(null, null); break;
                        case "NoiDungChamSoc":
                            clsNoiDungChamSoc oNDCS = new clsNoiDungChamSoc(long.Parse(dr.Row.ItemArray[0].ToString()));
                            oNDCS.Delete(null, null); break;
                        case "PheCanh":
                            clsPheCanh oPC = new clsPheCanh(long.Parse(dr.Row.ItemArray[0].ToString()));
                            oPC.Delete(null, null); break;
                            
                        case "TramNongVu":
                            clsTramNongVu oTNV = new clsTramNongVu(long.Parse(dr.Row.ItemArray[0].ToString()));
                            oTNV.Delete(null, null);
                            //delete cum tuong ung
                            clsCum oCum = new clsCum(long.Parse(dr.Row.ItemArray[0].ToString()));
                            oCum.Delete(null, null);
                            break;
                        case "VuTrong":
                            clsVuTrong oVT = new clsVuTrong(long.Parse(dr.Row.ItemArray[0].ToString()));
                            oVT.Delete(null, null); break;
                        case "VatTuVanChuyen":
                            clsVatTuVanChuyen oVTVC = new clsVatTuVanChuyen(long.Parse(dr.Row.ItemArray[0].ToString()));
                            oVTVC.Delete(null, null);
                            break;
                        case "HienTrangGiaoThong":
                            clsHienTrangGiaoThong oHTDT = new clsHienTrangGiaoThong(long.Parse(dr.Row.ItemArray[0].ToString()));
                            oHTGT.Delete(null,null);
                            break;
                        case "RaiVu":
                            clsRaiVu oRaiVu = new clsRaiVu(long.Parse(dr.Row.ItemArray[0].ToString()));
                            oRaiVu.Delete(null,null);

                            break;
                        case "Xa":
                            clsXa oXa = new clsXa(long.Parse(dr.Row.ItemArray[0].ToString()));
                            oXa.Delete(null,null);

                            // xoa record tuong ung o tbl_thon
                            clsThon objThon = new clsThon(long.Parse(dr.Row.ItemArray[0].ToString()));
                            objThon.Delete(null, null);
                            //string strSQL = "Delete from tbl_thon Where ID =" + dr.Row.ItemArray[0].ToString();

                            break;
                        case"Huyen":
                            clsHuyen oHuyen = new clsHuyen(long.Parse(dr.Row.ItemArray[0].ToString()));
                            oHuyen.Delete(null,null);
                            break;
                        case "Cum":
                            //clsCum oCum = new clsCum(long.Parse(dr.Row.ItemArray[0].ToString()));
                            //oCum.Delete(null,null);

                            break;
                        case "Tinh":
                            clsTinh oTinh = new clsTinh(long.Parse(dr.Row.ItemArray[1].ToString()));
                            oTinh.Delete(null,null);
                            break;

                    }

              }
              else
              {
                  e.Cancel = true;
              }
              delete = true;
              break;
            
       }
        else {  delete = false; }

        a++;
   }
   if (!delete)
   {
       e.Cancel = true;
       MessageBox.Show("Bạn không được xóa danh mục này ", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);

   }
                    
        }

        private void gdVDMTD_RecordAdded(object sender, EventArgs e)
        {
            //this.Load_DMTuDien(strNode);
            this.gdVDMTD.Refetch();
        }

        private void gdVDMTD_RecordsDeleted(object sender, EventArgs e)
        {
            //this.Load_DMTuDien(strNode);
            MessageBox.Show("Bạn đã xóa thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
   
        }

        private void gdVDMTD_RecordUpdated(object sender, EventArgs e)
        {
           // this.Load_DMTuDien(strNode);
            this.gdVDMTD.Refetch();
        }

        private void gdVDMTD_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                if (this.gdVDMTD.CurrentRow.RowType == Janus.Windows.GridEX.RowType.NewRecord)
                {
                    switch (strNode)
                    {
                        case "GiongMia":
                            oGM = new clsGiongMia();
                            break;
                        case "LoaiDat":
                            oLD = new clsLoaiDat();
                            break;
                        case "MucDichTrong":
                            oMDT = new clsMucDichTrong();
                            break;
                        case "NoiDungChamSoc":
                            oNDCS = new clsNoiDungChamSoc();
                            break;
                        case "PheCanh":
                            oPC = new clsPheCanh();
                            break;
                        case "TramNongVu":
                            oTNV = new clsTramNongVu();
                            break;
                        case "VuTrong":
                            oVT = new clsVuTrong();
                            break;
                        case "VatTuVanChuyen":
                            oVTVC = new clsVatTuVanChuyen();
                            break;
                        case "HienTrangGiaoThong":
                            oHTGT = new clsHienTrangGiaoThong();
                            break;
                        case "RaiVu":
                            oRaiVu = new clsRaiVu();
                            break;
                        case "Xa":
                            oXa = new clsXa();
                            break;
                        case "Huyen":
                            oHuyen = new clsHuyen();
                            break;
                        case "Cum":
                            oCum = new clsCum();

                            break;
                        case "Tinh":
                            oTinh = new clsTinh();
                            break;

                    }

                }
                else
                {
                    switch (strNode)
                    {
                        case "GiongMia":
                            oGM.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            break;
                        case "LoaiDat":
                            oLD.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            break;
                        case "MucDichTrong":
                            oMDT.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            break;
                        case "NoiDungChamSoc":
                            oNDCS.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            break;
                        case "PheCanh":
                            oPC.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            break;
                        case "TramNongVu":
                            oTNV.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString()); ;
                            break;
                        case "VuTrong":
                            oVT.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            break;
                        case "HienTrangGiaoThong":
                            oHTGT.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            break;
                        case "RaiVu":
                            oRaiVu.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            break;
                        case "Xa":
                            oXa.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            break;
                        case "Huyen":
                            oHuyen.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            break;
                        case "Cum":
                            oCum.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());

                            break;
                        case "Tinh":
                            oTinh.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            break;

                    }

                }
                LoadddlCum();
                LoadddlHuyen();
                LoadddlTinh();
            }
            catch
            {
                switch (strNode)
                {
                    case "GiongMia":
                        oGM = new clsGiongMia();
                        break;
                    case "LoaiDat":
                        oLD = new clsLoaiDat();
                        break;
                    case "MucDichTrong":
                        oMDT = new clsMucDichTrong();
                        break;
                    case "NoiDungChamSoc":
                        oNDCS = new clsNoiDungChamSoc();
                        break;
                    case "PheCanh":
                        oPC = new clsPheCanh();
                        break;
                    case "TramNongVu":
                        oTNV = new clsTramNongVu();
                        break;
                    case "VuTrong":
                        oVT = new clsVuTrong();
                        break;
                    case "HienTrangGiaoThong":
                        oHTGT = new clsHienTrangGiaoThong();
                        break;
                    case "RaiVu":
                        oRaiVu = new clsRaiVu();
                        break;
                    case "Xa":
                        oXa = new clsXa();
                        break;
                    case "Huyen":
                        oHuyen = new clsHuyen();
                        break;
                    case "Cum":
                        oCum = new clsCum();

                        break;
                    case "Tinh":
                        oTinh = new clsTinh();
                        break;

                }
            }
        }

        private void gdVDMTD_UpdatingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                string sql = "";
                DataSet ds;
                if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", " DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    switch (strNode)
                    {
                        case "GiongMia":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên giống mía");

                            sql = "SELECT * FROM tbl_GiongMia Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow d0 = ds.Tables[0].Rows[0];
                                if (d0["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên giống mía");
                            }
                            break;
                        case "LoaiDat":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên loại đất");

                            sql = "SELECT * FROM tbl_LoaiDat Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow d1 = ds.Tables[0].Rows[0];

                                if (d1["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên loại đất");
                            } break;
                        case "MucDichTrong":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("MucDichTrong").ToString())) throw new Exception("Bạn chưa nhập tên mục đích trồng");

                            sql = "SELECT * FROM tbl_MucDichTrong Where MucDichTrong='" + this.gdVDMTD.GetValue("MucDichTrong").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow d2 = ds.Tables[0].Rows[0];

                                if (d2["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên mục đích trồng");
                            } break;
                        case "NoiDungChamSoc":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên nội dung chăm sóc");

                            sql = "SELECT * FROM tbl_NoiDungChamSoc Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow d3 = ds.Tables[0].Rows[0];

                                if (d3["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên nội dung chăm sóc");
                            } break;
                        case "PheCanh":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("LyDoPheCanh").ToString())) throw new Exception("Bạn chưa nhập lý do phế canh");

                            sql = "SELECT * FROM tbl_PheCanh Where LyDoPheCanh='" + this.gdVDMTD.GetValue("LyDoPheCanh").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow d4 = ds.Tables[0].Rows[0];

                                if (d4["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên lý do phế canh");
                            } break;
                        case "TramNongVu":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên trạm nông vụ");

                            sql = "SELECT * FROM tbl_TramNongVu Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow d5 = ds.Tables[0].Rows[0];

                                if (d5["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên trạm nông vụ");
                            } break;
                        case "VuTrong":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên vụ trồng");

                            sql = "SELECT * FROM tbl_VuTrong Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow d6 = ds.Tables[0].Rows[0];

                                if (d6["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên vụ trồng");
                            } break;
                        case "VatTuVanChuyen":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("MaVatTu").ToString())) throw new Exception("Bạn chưa nhập mã vật tư ứng vận chuyển");
                            sql = "SELECT * FROM tbl_VatTuVanChuyen Where MaVatTu='" + this.gdVDMTD.GetValue("MaVatTu").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow dMVT = ds.Tables[0].Rows[0];

                                if (dMVT["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên mã vật tư ");
                            }
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên vật tư");

                            sql = "SELECT * FROM tbl_VatTuVanChuyen Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow d7 = ds.Tables[0].Rows[0];

                                if (d7["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên vật tư");
                            } break;
                        case "HienTrangGiaoThong":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Muc").ToString())) throw new Exception("Bạn chưa nhập tên mục hiện trạng giao thông");

                            sql = "SELECT * FROM tbl_HienTrangGiaoThong Where Muc='" + this.gdVDMTD.GetValue("Muc").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow d8 = ds.Tables[0].Rows[0];

                                if (d8["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên mục hiện trạng giao thông");

                            } break;
                        case "RaiVu":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên rải vụ");

                            sql = "SELECT * FROM tbl_RaiVu Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow d9 = ds.Tables[0].Rows[0];

                                if (d9["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên rải vụ");

                            } break;
                        case "Xa":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("MaXa").ToString())) throw new Exception("Bạn chưa nhập mã xã");
                            sql = "SELECT * FROM tbl_Xa Where MaXa='" + this.gdVDMTD.GetValue("MaXa").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow dMX = ds.Tables[0].Rows[0];

                                if (dMX["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng mã xã");
                            }
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên xã");

                            sql = "SELECT * FROM tbl_Xa Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow d10 = ds.Tables[0].Rows[0];

                                if (d10["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên xã");

                            } break;
                        case "Huyen":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên huyện");

                            sql = "SELECT * FROM tbl_Huyen Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow d11 = ds.Tables[0].Rows[0];

                                if (d11["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên huyện");

                            } break;
                        case "Cum":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên cụm");

                            sql = "SELECT * FROM tbl_Cum Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow d12 = ds.Tables[0].Rows[0];

                                if (d12["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tên cụm");

                            } break;
                        case "Tinh":
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên tỉnh");

                            sql = "SELECT * FROM tbl_Tinh Where Ten='" + this.gdVDMTD.GetValue("Ten").ToString() + "'";
                            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow d13 = ds.Tables[0].Rows[0];

                                if (d13["ID"].ToString() != this.gdVDMTD.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng tỉnh");

                            } break;

                    }

                    if (!SaveDanhMucTuDien(false)) { e.Cancel = true; }
                    else
                    {
                        MessageBox.Show("Bạn đã sửa lại thành công", " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    Load_DMTuDien(strNode.ToString());
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
        private bool SaveDanhMucTuDien(bool isAddNew)
        {
            try
            {
                
               switch (strNode)

                {

                    case "GiongMia":
                        if (isAddNew)
                        {
                            oGM = new clsGiongMia();
                        }
                        else
                        {
                            oGM.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            oGM.Load(null, null);
                        }
                        
                        if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập giống mía");
                        
                        oGM.Ten = this.gdVDMTD.GetValue("Ten").ToString();
                        if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("SoNgay").ToString())) throw new Exception("Bạn chưa nhập số ngày");
                        if (long.Parse(this.gdVDMTD.GetValue("SoNgay").ToString()) <= 0) throw new Exception("Bạn nhập số ngày chưa đúng");
                        if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("GiaMia").ToString())) throw new Exception("Bạn chưa nhập giá mía");
                        //if (!float.TryParse(this.gdVDMTD.GetValue("GiaMia").ToString(), out oGM.GiaMia)) throw new Exception("Giá mía bạn phải nhập kiểu số");
                        //oGM.SoNgay = long.Parse(this.gdVDMTD.GetValue("SoNgay").ToString());
                        if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("UuTien").ToString()))// throw new Exception("Bạn chưa nhập ưu tiên");
                        { }
                        else
                        {
                            if (long.Parse(this.gdVDMTD.GetValue("UuTien").ToString()) <= 0) throw new Exception("Bạn nhập ưu tiên nhỏ hơn 0");

                            oGM.UuTien = int.Parse(this.gdVDMTD.GetValue("UuTien").ToString());
                        }
                        //oGM.GhiChu = this.gdVDMTD.GetValue("GhiChu").ToString();
                      
                        oGM.Save(null, null);

                        this.gdVDMTD.SetValue("ID", oGM.ID);
                        ;                        
                        break;
                    case "LoaiDat":

                        if (isAddNew)
                        {
                            oLD = new clsLoaiDat();
                        }
                        else
                        {
                            oLD.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            oLD.Load(null, null);
                        }
                        if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập loại đất");

                            oLD.Ten = this.gdVDMTD.GetValue("Ten").ToString();
                            if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("UuTien").ToString()))// throw new Exception("Bạn chưa nhập ưu tiên");
                            { }
                            else
                            {
                                if (long.Parse(this.gdVDMTD.GetValue("UuTien").ToString()) <= 0) throw new Exception("Bạn nhập ưu tiên nhỏ hơn 0");

                                oLD.UuTien = int.Parse(this.gdVDMTD.GetValue("UuTien").ToString());
                            }
                        oLD.GhiChu = this.gdVDMTD.GetValue("GhiChu").ToString();
                            oLD.Save(null, null);                   
                            this.gdVDMTD.SetValue("ID", oLD.ID);
                        break;
                    case "MucDichTrong":

                        if (isAddNew)
                        {
                            oMDT = new clsMucDichTrong();
                        }
                        else
                        {
                            oMDT.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            oMDT.Load(null, null);
                        }
                        if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("MucDichTrong").ToString())) throw new Exception("Bạn chưa tên mục đích trồng");
                            oMDT.MucDichTrong = this.gdVDMTD.GetValue("MucDichTrong").ToString();                        
                            oMDT.GhiChu = this.gdVDMTD.GetValue("GhiChu").ToString();
                            oMDT.Save(null, null);                     
                            this.gdVDMTD.SetValue("ID", oMDT.ID);

                        break;
                    case "NoiDungChamSoc":

                        if (isAddNew)
                        {
                            oNDCS = new clsNoiDungChamSoc();
                        }
                        else
                        {
                            oNDCS.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            oNDCS.Load(null, null);
                        }
                        if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên nội dung chăm sóc");
                            oNDCS.Ten = this.gdVDMTD.GetValue("Ten").ToString();
                            oNDCS.Save(null, null);                      
                            this.gdVDMTD.SetValue("ID", oNDCS.ID);

                        break;
                    case "PheCanh":
                        if (isAddNew)
                        {
                            oPC = new clsPheCanh();
                        }
                        else
                        {
                            oPC.ID=long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            oPC.Load(null, null);
                        }
                        if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("LyDoPheCanh").ToString())) throw new Exception("Bạn chưa nhập lý do phế canh");

                            oPC.LyDoPheCanh = this.gdVDMTD.GetValue("LyDoPheCanh").ToString();
                            oPC.GhiChu = this.gdVDMTD.GetValue("GhiChu").ToString();
                            oPC.Save(null, null);                       
                            this.gdVDMTD.SetValue("ID", oPC.ID);


                        break;
                    case "TramNongVu":
                        if (isAddNew)
                        {
                            oTNV = new clsTramNongVu();
                        }
                        else
                        {
                            oTNV.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            oTNV.Load(null, null);

                            oCum.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            oCum.Load(null, null);
                        }
                        if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên trạm nông vụ");
                                               
                        oTNV.Ten = this.gdVDMTD.GetValue("Ten").ToString();
                        oTNV.MaTram = this.gdVDMTD.GetValue("MaTram").ToString(); 
                        oTNV.Save(null, null);                        
                        this.gdVDMTD.SetValue("ID", oTNV.ID);
                       // them moi cum vao bang cum tung ung:
                       /* đã thêm fần cập nhật cụm trong clsTramNongVu
                        if (isAddNew)
                        {
                            string strSQL = "Insert into tbl_Cum (ID,Ten,DinhMuc,ThuTu,DienTichTrienVong) values(" + oTNV.ID.ToString() + ",N'" + oTNV.Ten + "',0,0,0)";
                            MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
                        }
                        else
                        {
                            oCum.Ten = this.gdVDMTD.GetValue("Ten").ToString();
                            oCum.Save(null, null);
                        }
                        //oCum.Ten = this.gdVDMTD.GetValue("Ten").ToString();
                        //oCum.Save(null, null);
                       */
                        break;
                    case "VuTrong":
                        if (isAddNew)
                        {
                            oVT = new clsVuTrong();
                        }
                        else
                        {
                            oVT.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            oVT.Load(null, null);
                        }
                        if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên vụ trồng");

                            oVT.Ten = this.gdVDMTD.GetValue("Ten").ToString();
                        if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("NgayBatDau").ToString())) throw new Exception("Bạn chưa nhập ngày bắt đầu");

                            oVT.NgayBatDau = DateTime.Parse(this.gdVDMTD.GetValue("NgayBatDau").ToString());
                        if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("NgayKetThuc").ToString())) throw new Exception("Bạn chưa nhập ngày kết thúc");
                            oVT.NgayKetThuc = DateTime.Parse(this.gdVDMTD.GetValue("NgayKetThuc").ToString());
                            oVT.VuTruoc = long.Parse(this.gdVDMTD.GetValue("VuTruoc").ToString());
                            oVT.Save(null, null);
                            this.gdVDMTD.SetValue("ID", oVT.ID);


                        break;
                    case "VatTuVanChuyen":
                        if (isAddNew)
                        {
                            oVTVC = new clsVatTuVanChuyen();
                        }
                        else
                        {
                            oVTVC.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                            oVTVC.Load(null, null);
                        }
                        if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("MaVatTu").ToString())) throw new Exception("Bạn chưa nhập mã vật tư ứng vận chuyển");

                        oVTVC.MaVatTu = this.gdVDMTD.GetValue("MaVatTu").ToString();
                        if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên vật tư ứng vận chuyển");

                            oVTVC.Ten = this.gdVDMTD.GetValue("Ten").ToString();
                        if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("DonViTinh").ToString())) throw new Exception("Bạn chưa nhập đơn vị tính");


                             oVTVC.DonViTinh = this.gdVDMTD.GetValue("DonViTinh").ToString();
                             if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("TienMat").ToString())) //throw new Exception("Bạn chưa nhập tiền mặt");
                             { oVTVC.TienMat = 0; }
                             else
                             {
                                 if (long.Parse(this.gdVDMTD.GetValue("TienMat").ToString()) < 0) throw new Exception("Bạn nhập tiền mặt nhỏ hơn 0");

                                 oVTVC.TienMat = long.Parse(this.gdVDMTD.GetValue("TienMat").ToString());
                             }
                        oVTVC.GhiChu = this.gdVDMTD.GetValue("GhiChu").ToString();
                            oVTVC.Save(null, null);
                            this.gdVDMTD.SetValue("ID", oVTVC.ID);
                          

                        break;
                   case "HienTrangGiaoThong":
                       if (isAddNew)
                       {
                           oHTGT = new clsHienTrangGiaoThong();
                       }
                       else
                       {
                           oHTGT.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                           oHTGT.Load(null, null);
                       }
                       if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Muc").ToString())) throw new Exception("Bạn chưa nhập mức hiện trạng giao thông");

                       oHTGT.Muc = this.gdVDMTD.GetValue("Muc").ToString();

                       if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("UuTien").ToString()))// throw new Exception("Bạn chưa nhập ưu tiên");
                       { }
                       else
                       {
                           if (long.Parse(this.gdVDMTD.GetValue("UuTien").ToString()) <= 0) throw new Exception("Bạn nhập ưu tiên nhỏ hơn 0");
                           oHTGT.UuTien = long.Parse(this.gdVDMTD.GetValue("UuTien").ToString());
                       }
                       oHTGT.Save(null, null);
                       this.gdVDMTD.SetValue("ID", oHTGT.ID);
                       break;
                   case "RaiVu":
                       if (isAddNew)
                       {
                           oRaiVu = new clsRaiVu();
                       }
                       else
                       {
                           oRaiVu.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                           oRaiVu.Load(null, null);
                       }
                       if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên rải vụ");
                       oRaiVu.MaRaiVu = this.gdVDMTD.GetValue("MaRaiVu").ToString();
                       oRaiVu.Ten = this.gdVDMTD.GetValue("Ten").ToString();

                       if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("UuTien").ToString()))// throw new Exception("Bạn chưa nhập ưu tiên");
                       { }
                       else
                       {
                           if (long.Parse(this.gdVDMTD.GetValue("UuTien").ToString()) <= 0) throw new Exception("Bạn nhập ưu tiên nhỏ hơn 0");

                           oRaiVu.UuTien = long.Parse(this.gdVDMTD.GetValue("UuTien").ToString());
                       } oRaiVu.Save(null, null);
                       this.gdVDMTD.SetValue("ID", oRaiVu.ID);
                       break;
                   case "Xa":
                       if (isAddNew)
                       {
                           oXa= new clsXa();
                       }
                       else
                       {
                           oXa.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                           oXa.Load(null, null); 
                       }

                       if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("MaXa").ToString())) throw new Exception("Bạn chưa nhập mã xã");
                       //if (this.gdVDMTD.GetValue("MaXa").ToString().Length > 5) throw new Exception("Mã xã không được dài quá 5 kí tự");
                           oXa.MaXa = this.gdVDMTD.GetValue("MaXa").ToString();
                       if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên xã");

                       oXa.Ten = this.gdVDMTD.GetValue("Ten").ToString();

                       if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("DinhMuc").ToString()))// throw new Exception("Bạn chưa nhập định mức");
                       {
                           oXa.DinhMuc = 0;
                       }
                       else
                       {
                           try
                           {
                               oXa.DinhMuc = long.Parse(this.gdVDMTD.GetValue("DinhMuc").ToString());
                           }
                           catch
                           {
                               oXa.DinhMuc = 0;
                           }
                       }
                      // if (long.Parse(this.gdVDMTD.GetValue("DinhMuc").ToString()) <= 0) throw new Exception("Bạn nhập định mức chưa đúng");
                           
                       //if ((this.gdVDMTD.Tables[0].Columns["CuaDonVi"].CheckBoxTriState))
                       //{
                       //    oXa.CuaDonVi = 1;
                       //}
                       //else { oXa.CuaDonVi = 0; }
                           if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("HuyenID").ToString()) && string.IsNullOrEmpty(this.gdVDMTD.GetValue("CumID").ToString())) throw new Exception("Bạn phải nhập huyện hoặc cụm cho xã ");

                           if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("HuyenID").ToString()))
                           {
                               oXa.HuyenID = 0;
                           }

                           else
                           {
                               oXa.HuyenID = long.Parse(this.gdVDMTD.GetValue("HuyenID").ToString());
                           }
                           if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("CumID").ToString()))
                           {
                               MessageBox.Show("Bạn phải cho biết xã thuộc cụm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                               return false;
                           }
                           else
                           {
                               oXa.CumID = long.Parse(this.gdVDMTD.GetValue("CumID").ToString());
                           }
                           oXa.Save(null, null);
                           this.gdVDMTD.SetValue("ID", oXa.ID);

                       // them moi thon tuong ung vơi xa:
                           if (isAddNew)
                           {
                               string strSQL = "Insert into tbl_thon (ID,Ten,XaID,DinhMuc,tt) values (" + oXa.ID + ",N'" + oXa.Ten + "'," + oXa.ID + ",0,0)";
                               MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
                           }
                           else
                           {
                               string strSQL = "Update tbl_thon SET Ten =N'" + oXa.Ten + "' Where ID =" + oXa.ID;
                               MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);
                           }
                       
                       break;
                   case "Huyen":
                       if (isAddNew)
                       {
                           oHuyen= new clsHuyen();
                       }
                       else
                       {
                           oHuyen.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                           oHuyen.Load(null, null);
                       }
                       if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên huyện");

                       oHuyen.Ten = this.gdVDMTD.GetValue("Ten").ToString();
                       oHuyen.TinhID = long.Parse(this.gdVDMTD.GetValue("TinhID").ToString());
                       
                       oHuyen.Save(null, null);
                       this.gdVDMTD.SetValue("ID", oHuyen.ID);
                       break;
                   case "Cum":
                       if (isAddNew)
                       {
                           oCum = new clsCum();
                       }
                       else
                       {
                           oCum.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                           oCum.Load(null, null);
                       }
                       if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên cụm");

                       oCum.Ten = this.gdVDMTD.GetValue("Ten").ToString();
                       oCum.DienTichTrienVong = long.Parse(this.gdVDMTD.GetValue("DienTichTrienVong").ToString());

                       if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("DinhMuc").ToString()))
                       { oCum.DinhMuc = 0; }
                       else
                       {
                           if (long.Parse(this.gdVDMTD.GetValue("DinhMuc").ToString()) <0) throw new Exception("Bạn nhập định mức chưa đúng");

                           oCum.DinhMuc = long.Parse(this.gdVDMTD.GetValue("DinhMuc").ToString());
                       } oCum.Save(null, null);
                       this.gdVDMTD.SetValue("ID", oCum.ID);
                       break;
                   case"Tinh":
                       if (isAddNew)
                       {
                           oTinh = new clsTinh();
                       }
                       else
                       {
                           oTinh.ID = long.Parse(this.gdVDMTD.GetValue("ID").ToString());
                           oTinh.Load(null, null);
                       }
                       if (string.IsNullOrEmpty(this.gdVDMTD.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên tỉnh");

                       oTinh.Ten = this.gdVDMTD.GetValue("Ten").ToString();
                       oTinh.Save(null, null);
                       this.gdVDMTD.SetValue("ID", oTinh.ID);
                       break;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Load_treeDMTD(string strNode,string Ten)
        {
            lblTen.Text = "Danh Mục " + Ten.ToString();
            switch (strNode)
            {
                case "GiongMia":

                    
                    this.gdVDMTD.Tables[0].Columns["MaVatTu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Ten"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["SoNgay"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["GiaMia"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["UuTien"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["GhiChu"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["NgayBatDau"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayKetThuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["VuTruoc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["LyDoPheCanh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DonViTinh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TienMat"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MucDichTrong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Muc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["HuyenID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CumID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DinhMuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaXa"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CuaDonVi"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TinhID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DienTichTrienVong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaRaiVu"].Visible = false;
                    Load_DMTuDien(strNode);

                    break;
                case "LoaiDat":

                    
                    this.gdVDMTD.Tables[0].Columns["MaVatTu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Ten"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["SoNgay"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["UuTien"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["GiaMia"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GhiChu"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["NgayBatDau"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayKetThuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["VuTruoc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["LyDoPheCanh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DonViTinh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TienMat"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MucDichTrong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Muc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["HuyenID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CumID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DinhMuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaXa"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CuaDonVi"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TinhID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DienTichTrienVong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaRaiVu"].Visible = false;
                    Load_DMTuDien(strNode);

                    break;
                case "MucDichTrong":

                   
                    this.gdVDMTD.Tables[0].Columns["MaVatTu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MucDichTrong"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["Ten"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["SoNgay"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GiaMia"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["UuTien"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GhiChu"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["NgayBatDau"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayKetThuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["VuTruoc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["LyDoPheCanh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DonViTinh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TienMat"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Muc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["HuyenID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CumID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DinhMuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaXa"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CuaDonVi"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TinhID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DienTichTrienVong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaRaiVu"].Visible = false;
                    Load_DMTuDien(strNode);

                    break;
                case "NoiDungChamSoc":

                   
                    this.gdVDMTD.Tables[0].Columns["MaVatTu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MucDichTrong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Ten"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["SoNgay"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GiaMia"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["UuTien"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GhiChu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayBatDau"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayKetThuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["VuTruoc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["LyDoPheCanh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DonViTinh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TienMat"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Muc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["HuyenID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CumID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DinhMuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaXa"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CuaDonVi"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TinhID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DienTichTrienVong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaRaiVu"].Visible = false;
                    Load_DMTuDien(strNode);

                    break;
                case "PheCanh":

                   
                    this.gdVDMTD.Tables[0].Columns["MaVatTu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MucDichTrong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Ten"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["SoNgay"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GiaMia"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["UuTien"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GhiChu"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["NgayBatDau"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayKetThuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["VuTruoc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["LyDoPheCanh"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["DonViTinh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TienMat"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Muc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["HuyenID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CumID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DinhMuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaXa"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CuaDonVi"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TinhID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DienTichTrienVong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaRaiVu"].Visible = false;
                    Load_DMTuDien(strNode);

                    break;
                case "TramNongVu":

                  
                    this.gdVDMTD.Tables[0].Columns["MaVatTu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MucDichTrong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Ten"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["SoNgay"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GiaMia"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["UuTien"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GhiChu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayBatDau"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayKetThuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["VuTruoc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["LyDoPheCanh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DonViTinh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TienMat"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Muc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["HuyenID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CumID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DinhMuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaXa"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CuaDonVi"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TinhID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DienTichTrienVong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaRaiVu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaTram"].Visible = true;
                    Load_DMTuDien(strNode);

                    break;
                case "VuTrong":

                   
                    this.gdVDMTD.Tables[0].Columns["MaVatTu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MucDichTrong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Ten"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["SoNgay"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GiaMia"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["UuTien"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GhiChu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayBatDau"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["NgayKetThuc"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["VuTruoc"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["LyDoPheCanh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DonViTinh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TienMat"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Muc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["HuyenID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CumID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DinhMuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaXa"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CuaDonVi"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TinhID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DienTichTrienVong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaRaiVu"].Visible = false;
                    Load_DMTuDien(strNode);

                    break;
                case "VatTuVanChuyen":

                    
                    this.gdVDMTD.Tables[0].Columns["MaVatTu"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["MucDichTrong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Ten"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["SoNgay"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GiaMia"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["UuTien"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GhiChu"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["NgayBatDau"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayKetThuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["VuTruoc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["LyDoPheCanh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DonViTinh"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["TienMat"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["Muc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["HuyenID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CumID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DinhMuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaXa"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CuaDonVi"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TinhID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DienTichTrienVong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaRaiVu"].Visible = false;
                    Load_DMTuDien(strNode);

                    break;
                case "HienTrangGiaoThong":
                    
                    this.gdVDMTD.Tables[0].Columns["MaVatTu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MucDichTrong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Ten"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["SoNgay"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GiaMia"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["UuTien"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["GhiChu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayBatDau"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayKetThuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["VuTruoc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["LyDoPheCanh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DonViTinh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TienMat"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Muc"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["HuyenID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CumID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DinhMuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaXa"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CuaDonVi"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TinhID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DienTichTrienVong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaRaiVu"].Visible = false;
                    Load_DMTuDien(strNode);
                    break;
                case "RaiVu":
                    
                    this.gdVDMTD.Tables[0].Columns["MaVatTu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MucDichTrong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Ten"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["SoNgay"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GiaMia"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["UuTien"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["GhiChu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayBatDau"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayKetThuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["VuTruoc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["LyDoPheCanh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DonViTinh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TienMat"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Muc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["HuyenID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CumID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DinhMuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaXa"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CuaDonVi"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TinhID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DienTichTrienVong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaRaiVu"].Visible = true;
                    Load_DMTuDien(strNode);
                    break;
                case "Xa":
                   
                    this.gdVDMTD.Tables[0].Columns["MaVatTu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MucDichTrong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Ten"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["SoNgay"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GiaMia"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["UuTien"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GhiChu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayBatDau"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayKetThuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["VuTruoc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["LyDoPheCanh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DonViTinh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TienMat"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Muc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["HuyenID"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["CumID"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["DinhMuc"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["MaXa"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["CuaDonVi"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TinhID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DienTichTrienVong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaRaiVu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DinhMuc"].Visible = false;
                    //DinhMuc
                    Load_DMTuDien(strNode);
                    break;
                case "Huyen":
                   
                    this.gdVDMTD.Tables[0].Columns["MaVatTu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MucDichTrong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Ten"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["SoNgay"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GiaMia"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["UuTien"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GhiChu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayBatDau"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayKetThuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["VuTruoc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["LyDoPheCanh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DonViTinh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TienMat"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Muc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["HuyenID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CumID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DinhMuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaXa"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CuaDonVi"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TinhID"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["DienTichTrienVong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaRaiVu"].Visible = false;
                    Load_DMTuDien(strNode);
                    break;
                case "Cum":
                   
                    this.gdVDMTD.Tables[0].Columns["MaVatTu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MucDichTrong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Ten"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["SoNgay"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GiaMia"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["UuTien"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GhiChu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayBatDau"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayKetThuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["VuTruoc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["LyDoPheCanh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DonViTinh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TienMat"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Muc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["HuyenID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CumID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DinhMuc"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["MaXa"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CuaDonVi"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TinhID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DienTichTrienVong"].Visible =true;
                    this.gdVDMTD.Tables[0].Columns["MaRaiVu"].Visible = false;
                    Load_DMTuDien(strNode);
                    break;
                case "Tinh":
                   
                    this.gdVDMTD.Tables[0].Columns["MaVatTu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MucDichTrong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Ten"].Visible = true;
                    this.gdVDMTD.Tables[0].Columns["SoNgay"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GiaMia"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["UuTien"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["GhiChu"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayBatDau"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["NgayKetThuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["VuTruoc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["LyDoPheCanh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DonViTinh"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TienMat"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["Muc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["HuyenID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CumID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DinhMuc"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaXa"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["CuaDonVi"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["TinhID"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["DienTichTrienVong"].Visible = false;
                    this.gdVDMTD.Tables[0].Columns["MaRaiVu"].Visible = false;
                    Load_DMTuDien(strNode);
                    break;

                default:
                    Load_DMTuDien(strNode);
                    break;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Ten = e.Node.Text;
            strNode = e.Node.Name;
            Load_treeDMTD(strNode,Ten);
        }

        private void txtTimXa_TextChanged(object sender, EventArgs e)
        {
            if (treeView1.Nodes["Xa"].IsSelected == true)
            {
                //gdVDMTD.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                string strSQL = "Select * from tbl_Xa where Ten like N'%" + txtTimXa.Text + "%' OR Maxa like '%" + txtTimXa.Text + "%'";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                //gdVDMTD.DataSource
                gdVDMTD.SetDataBinding(ds.Tables[0], "");
                gdVDMTD.Refetch();
            }
        }
        
        
       
    }
}