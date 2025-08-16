
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using Janus.Windows.GridEX;
using DACASUCO.MDForms;
using DACASUCO.MDReport;

namespace MDSolution
{
    public partial class frmTHTTVanChuyen : Form
    {
        private NodeHopDongVanChuyen nHDVC = new NodeHopDongVanChuyen("-1", "Hợp Đồng Vận Chuyển", HDVCType.Root);
        private DataSet DuLieuTTVC;
        private long SoPhieu=0;
        public frmTHTTVanChuyen()
        {
            InitializeComponent();
            CommonClass.loadTreeHopDongVanChuyen(tvHopDongVanChuyen);
            tvHopDongVanChuyen.Focus();            
        }
        public frmTHTTVanChuyen(string ID)
        {
            InitializeComponent();
            
            CommonClass.loadTreeHopDongVanChuyen(tvHopDongVanChuyen);
            tvHopDongVanChuyen.Focus();
        }
       
      
        private void LoadGVPhieuTT()
        {
           
            string strSQL = "";
            DateTime dTu = dtTuNgay.Value;
            DateTime dDen = dtDenNgay.Value;
            string Tu = dTu.ToString("yyyy-MM-dd") + " 00:00:00";
            string Den = dDen.ToString("yyyy-MM-dd") + " 23:59:59";
            if (nHDVC.HopDongID != "0")
            {
                strSQL = "Select * from tbl_ThanhToanVC where HopDongVCID =" + nHDVC.HopDongID + " And NgayTT>='"+Tu+"' AND NgayTT<='"+Den+"' AND VuTrongID="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
            }
            else
            {
                strSQL = "Select * from tbl_ThanhToanVC Where NgayTT>='"+Tu+"' And NgayTT<='"+Den+"' AND VuTrongID="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
            }
            strSQL = strSQL + " Order by SoPhieu";
            this.DuLieuTTVC = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
            if (this.DuLieuTTVC.Tables.Count > 0)
            {
                this.gdTTVC.SetDataBinding(this.DuLieuTTVC.Tables[0], "");
               
            }
          
        }

      
        private void tvHopDongVanChuyen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nHDVC = (NodeHopDongVanChuyen)tvHopDongVanChuyen.SelectedNode.Tag;
                LoadGVPhieuTT();
            }
        }

        private void tvHopDongVanChuyen_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nHDVC = (NodeHopDongVanChuyen)e.Node.Tag;
            //this.LoadgdVXeVanChuyen();
            LoadGVPhieuTT();
        }

          

      
        private void gdVChiTietUngVatTu_RecordUpdated(object sender, EventArgs e)
        {
            LoadGVPhieuTT();
            this.gdTTVC.Refetch();
        }

      
        private void gdVChiTietUngVatTu_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "XemChiTiet")
            {
                 try
            {
                frmShowRP2 frm = new frmShowRP2();
                rptTTVC rp = new rptTTVC();
                rp.RecordSelectionFormula = "{V_VanChuyenMia.SoXe}='" + this.gdTTVC.GetValue("SoXe").ToString() + "'" + " AND {V_VanChuyenMia.DaThanhToanVC}=" + this.gdTTVC.GetValue("SoPhieu").ToString() + " AND {tbl_ThanhToanVC.SoPhieu}=" + this.gdTTVC.GetValue("SoPhieu").ToString()+" AND {tbl_ThanhToanVC.VuTrongID}=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                frm.RP = rp;
                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.RPtitle = "Thanh toán xe vận chuyển";               
                frm.Show();
           
                }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
            }
           
           }
                    
                    
          }
              
             
       private void tvHopDongVanChuyen_AfterSelect(object sender, TreeViewEventArgs e)
        {
            label1.Text = tvHopDongVanChuyen.SelectedNode.Text;
            nHDVC = (NodeHopDongVanChuyen)e.Node.Tag;
            //this.LoadgdVXeVanChuyen();
        }

       private void cmdIn_Click(object sender, EventArgs e)
       {
           if (gdTTVC.RowCount > 0)
           {
               frmShowRP2 frm = new frmShowRP2();
               rpt_TH_TT_VC rp = new rpt_TH_TT_VC();
               DataTable dt = (DataTable)gdTTVC.DataSource;
               rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
               rp.Database.Tables[0].SetDataSource(dt);
               frm.RP = rp;
               rp.SetParameterValue("TuNgay", dtTuNgay.Value.ToString("dd/MM/yyyy"));
               rp.SetParameterValue("DenNgay", dtDenNgay.Value.ToString("dd/MM/yyyy"));
               rp.SetParameterValue("VuTrong", DACASUCO_App.TenVuTrong);
               if (nHDVC.HopDongID == "0")
               {
                   rp.SetParameterValue("DonVi", "Toàn bộ DACASUCO");
                  // rp.RecordSelectionFormula = "{V_TH_TT_VC.NgayTT}>=#" +dtTuNgay.Value.ToString("yyyy-MM-dd") +"#"+" AND {V_TH_TT_VC.NgayTT}<=#" + dtDenNgay.Value.ToString("yyyy-MM-dd 23:59:59") + "#";
               }
               else
               {
                   rp.SetParameterValue("DonVi",nHDVC.HopDongName);
                   //rp.RecordSelectionFormula =  "{V_TH_TT_VC.HopDongVCID}=" + nHDVC.HopDongID+" AND {V_TH_TT_VC.NgayTT}>=#" + dtTuNgay.Value.ToString("yyyy-MM-dd") + "#" + " AND {V_TH_TT_VC.NgayTT}<=#" + dtDenNgay.Value.ToString("yyyy-MM-dd 23:59:59") + "#";
               }
              
              // rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
               frm.RPtitle = "Kết quả Thanh toán Vận chuyển";
               frm.Show();
           }

       }

       private void cmdExit_Click(object sender, EventArgs e)
       {
           this.Close();
       }

       private void cmdUpdate_Click(object sender, EventArgs e)
       {
           try
           {
               SoPhieu = long.Parse(this.gdTTVC.GetValue("SoPhieu").ToString());
           }
           catch
           {
               return;
           }
           frmSuaTTVC frm = new frmSuaTTVC(SoPhieu.ToString());
           frm.ShowDialog();
           LoadGVPhieuTT();
       }

       private void frmTHTTVanChuyen_Load(object sender, EventArgs e)
       {
           if ((DACASUCO_App.User.RolesID == 0)||(DACASUCO_App.User.RolesID == 2))
           {
               cmdHuy.Enabled = true;
           }
       }

       private void gdTTVC_SelectionChanged(object sender, EventArgs e)
       {
           try
           {
               SoPhieu = long.Parse(this.gdTTVC.GetValue("SoPhieu").ToString());
               if (SoPhieu > 0)
               {
                   cmdUpdate.Enabled = true;
               }
               else
               {
                   cmdUpdate.Enabled =false;
               }
           }
           catch
           {
               return;
           }

       }

       private void cmdHuy_Click(object sender, EventArgs e)
       {
           long UserID = 0;
           try
           {
               SoPhieu = long.Parse(this.gdTTVC.GetValue("SoPhieu").ToString());
           }
           catch
           {
               return;
           }
            try
            {
                UserID = long.Parse(this.gdTTVC.GetValue("UserID").ToString());
            }
            catch
            {
                return;
            }
            if (DACASUCO_App.User.ID != UserID)
            {
                clsUser oUser = new clsUser(UserID);
                oUser.Load(null, null);
                MessageBox.Show("Phiếu thanh toán vận chuyển " + SoPhieu.ToString() + " do " + oUser.HoTen.ToString() + " lập!" + "\nBạn không hủy được phiếu này","DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(MessageBox.Show("Bạn chắc chắn hủy phiếu thanh toán " + SoPhieu.ToString() + "?", "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                try
                {
                    string sql = "Update tbl_NhapMia set DaThanhToanVC=0 where DaThanhToanVC=" + SoPhieu.ToString()+" AND VuTrongID="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    sql = "Select SoCT,XeID from tbl_ThanhtoanVC where SoPhieu=" + SoPhieu.ToString()+" AND VuTrongID="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
                    DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int SoCT = int.Parse(ds.Tables[0].Rows[0]["SoCT"].ToString());
                        long XeID = long.Parse(ds.Tables[0].Rows[0]["XeID"].ToString());
                        if (SoCT > 0)
                        {
                            MDSolutionEntities.DBModule.ExecuteQuery("Delete from tbl_UngVatTuVanChuyen where SoChungTu="+SoCT.ToString()+" And XeID="+XeID.ToString()+" AND VuTrongID="+ MDSolution.DACASUCO_App.VuTrongID.ToString(),null,null);
                        }
                        MDSolutionEntities.DBModule.ExecuteQuery("Delete from tbl_ThanhtoanVC Where SoPhieu=" + SoPhieu.ToString()+" AND VuTrongID="+ MDSolution.DACASUCO_App.VuTrongID.ToString(), null, null);
                    }
                    MessageBox.Show("Đã hủy phiếu thành công!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra khi hủy phiếu!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            }
               LoadGVPhieuTT();
       }

       
            
      
    }
}
