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
    public partial class frmHopDongVanChuyen : Form
    {
        static frmHopDongVanChuyen _theformHopDongVanChuyen;
        private DataSet dsHopDongVanChuyen;
        private DataSet dsXeVanChuyen;
        private clsHopDongVanChuyen oHDVC = new clsHopDongVanChuyen();
        private clsXeVanChuyen oXeVC = new clsXeVanChuyen();
        public frmHopDongVanChuyen()
        {
            InitializeComponent();
            this.LoadHopDongVanChuyen();
            //this.LoadXeVanChuyen();

        }

        static public frmHopDongVanChuyen OneInstanceFrm
        {
            get
            {
                if (null == _theformHopDongVanChuyen || _theformHopDongVanChuyen.IsDisposed)
                {
                    _theformHopDongVanChuyen = new frmHopDongVanChuyen();
                }

                return _theformHopDongVanChuyen;
            }
        }
        public void LoadHopDongVanChuyen()    
        {

            string sql = "Select * from V_HDVC Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
            this.dsHopDongVanChuyen = MDSolutionEntities.DBModule.ExecuteQuery(sql,null,null);
            
            if (this.dsHopDongVanChuyen.Tables.Count > 0)
            {
                this.gdVHopDongVanChuyen.SetDataBinding(this.dsHopDongVanChuyen.Tables[0], "");
            }
        }
        public void LoadXeVanChuyen()
        {
            this.dsXeVanChuyen = clsXeVanChuyen.GetListbyWhereNKT("", "HopDongVanChuyenID =" + oHDVC.ID.ToString(), "SoXe", null, null);
            if (this.dsXeVanChuyen.Tables.Count > 0)
            {
                this.gdVXeVanChuyen.SetDataBinding(this.dsXeVanChuyen.Tables[0], "");
            }
        }

        private void gdVHopDongVanChuyen_AddingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                string sql = "";
                DataSet ds;
                if (string.IsNullOrEmpty(this.gdVHopDongVanChuyen.GetValue("MaHopDong").ToString())) throw new Exception("Bạn chưa nhập mã hợp đồng");

                sql = "SELECT count(*) as Dem FROM tbl_HopDongVanChuyen Where MaHopDong='" + this.gdVHopDongVanChuyen.GetValue("MaHopDong").ToString() + "' AND VuTrongID = " + MDSolution.DACASUCO_App.VuTrongID;
                ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                DataRow d13 = ds.Tables[0].Rows[0];

                if (long.Parse(d13["Dem"].ToString()) > 0) throw new Exception("Bạn nhập trùng mã hợp đồng");

                if (!SaveHopDongVanChuyen(true)) { e.Cancel = true; }
                else
                {
                    this.gdVHopDongVanChuyen.SetValue("ID", oHDVC.ID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); e.Cancel = true;
            }
        }

        private void gdVHopDongVanChuyen_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gdVHopDongVanChuyen.CurrentRow.RowType == Janus.Windows.GridEX.RowType.NewRecord)
            {
                oHDVC = new clsHopDongVanChuyen();
            }
            else
            {
                oHDVC.ID = long.Parse(this.gdVHopDongVanChuyen.GetValue("ID").ToString());
                lblXe.Text = "Các xe của HĐVC " + this.gdVHopDongVanChuyen.GetValue("TenChuHopDong").ToString();
                this.LoadXeVanChuyen();
            }
        }

        private void gdVHopDongVanChuyen_RecordUpdated(object sender, EventArgs e)
        {
            //oHDVC.Load(null, null);

            //oHDVC.Save(null, null);
        }
        private void gdVXeVanChuyen_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {
            string sql = "Select XeID from tbl_NhapMia Where XEID=" + this.gdVXeVanChuyen.GetValue("ID").ToString();
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Xe đang có dữ liệu vận chuyển!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            string message;
            sql = "SELECT count(*) as Dem FROM tbl_UngVatTuVanChuyen Where XeID='" + this.gdVXeVanChuyen.GetValue("ID").ToString() + "'";
            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            DataRow d13 = ds.Tables[0].Rows[0];
            if (long.Parse(d13["Dem"].ToString()) > 0)
            {
                MessageBox.Show("Xe vận chuyển này đã đươc sử dụng.Bạn không được xóa xe vận chuyển này", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {

                message = String.Format("Bạn muốn xóa xe vận chuyển này?");
                if (MessageBox.Show(message, "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oXeVC.Delete(null, null);
                    //jj
                    this.LoadXeVanChuyen();
                }
                else
                {
                    e.Cancel = true;
                }

            }
            
        }
             
        private bool SaveXeVanChuyen(bool isAddNew)
        {
            try
            {
                if (isAddNew)
                {                    
                    oXeVC = new clsXeVanChuyen();
                    oXeVC.HopDongVanChuyenID = long.Parse(this.gdVHopDongVanChuyen.GetValue("ID").ToString());
                }
                else
                {
                    oXeVC.ID = long.Parse(this.gdVXeVanChuyen.GetValue("ID").ToString());
                    oXeVC.Load(null, null);
                }

                if (string.IsNullOrEmpty(this.gdVXeVanChuyen.GetValue("SoXe").ToString())) throw new Exception("Bạn chưa nhập số Xe vận chuyển");
                {
                    string strSoXeNew = this.gdVXeVanChuyen.GetValue("SoXe").ToString();
                    string strSoXe = "";
                    string sqlSoXe="SELECT  [SoXe]  FROM [dbo].[tbl_XeVanChuyen] Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID;
                    strSoXe=MDSolutionEntities.DBModule.ExecuteQueryForOneResult(sqlSoXe,null,null);

                    if (strSoXe != null)
                    {

                        strSoXe = strSoXe.Trim();
                    }
                    strSoXeNew = strSoXeNew.Trim();
                    


                    if(isAddNew || oXeVC.SoXe != strSoXeNew)

                        if (strSoXe == strSoXeNew)
                        {
                            MessageBox.Show("Số xe đã có trong hệ thống", "DACASUCO",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        
                        if (IsXeVanChuyenOK(strSoXeNew)) throw new Exception("Số xe đã được khai báo trong hệ thống, kiểm tra lại");
                    oXeVC.SoXe = strSoXeNew;
                }
                
                //if (string.IsNullOrEmpty(this.gdVXeVanChuyen.GetValue("TenLaiXe").ToString())) throw new Exception("Bạn chưa nhập tên người lái xe");
                //oXeVC.TenLaiXe = this.gdVXeVanChuyen.GetValue("TenLaiXe").ToString();
                if (string.IsNullOrEmpty(this.gdVXeVanChuyen.GetValue("LoaiXe").ToString())) throw new Exception("Bạn chưa nhập tên loại xe");
                oXeVC.LoaiXe = this.gdVXeVanChuyen.GetValue("LoaiXe").ToString();
                //if (string.IsNullOrEmpty(this.gdVXeVanChuyen.GetValue("TrongTai").ToString())) throw new Exception("Bạn chưa nhập trọng tải của xe");
                //oXeVC.TrongTai = long.Parse(this.gdVXeVanChuyen.GetValue("TrongTai").ToString());
                //if (oXeVC.TrongTai <= 0) throw new Exception("Trọng tải của xe nhập vào không phù hợp");
                oXeVC.GhiChu = this.gdVXeVanChuyen.GetValue("GhiChu").ToString();
                oXeVC.VuTrongID = MDSolution.DACASUCO_App.VuTrongID;
                
                oXeVC.Save(null, null);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private bool SaveHopDongVanChuyen(bool isAddNew)
        {
            try
            {
                if (isAddNew)
                {
                    oHDVC = new clsHopDongVanChuyen();
                }
                else
                {
                    oHDVC = new clsHopDongVanChuyen(long.Parse(this.gdVHopDongVanChuyen.GetValue("ID").ToString()));
                    oHDVC.Load(null, null);
                }
                if (string.IsNullOrEmpty(this.gdVHopDongVanChuyen.GetValue("MaHopDong").ToString())) throw new Exception("Bạn chưa nhập Mã Hợp Đồng");
                oHDVC.MaHopDong = this.gdVHopDongVanChuyen.GetValue("MaHopDong").ToString();
                if (string.IsNullOrEmpty(this.gdVHopDongVanChuyen.GetValue("TenChuHopDong").ToString())) throw new Exception("Bạn chưa nhập tên người chủ Hợp Đồng");
                oHDVC.TenChuHopDong = this.gdVHopDongVanChuyen.GetValue("TenChuHopDong").ToString();
                if (string.IsNullOrEmpty(this.gdVHopDongVanChuyen.GetValue("NgayHopDong").ToString()))// throw new Exception("Bạn chưa nhập ngày làm hợp đồng");
                { }
                else
                {
                    oHDVC.NgayHopDong = DateTime.Parse(this.gdVHopDongVanChuyen.GetValue("NgayHopDong").ToString());
                    if (oHDVC.NgayHopDong > DateTime.Now) throw new Exception("Bạn nhập ngày làm hợp đồng lớn hơn ngày hiện tại");
                }
                oHDVC.DienThoai = this.gdVHopDongVanChuyen.GetValue("DienThoai").ToString();
                oHDVC.DiaChi = this.gdVHopDongVanChuyen.GetValue("DiaChi").ToString();
                oHDVC.GhiChu = this.gdVHopDongVanChuyen.GetValue("GhiChu").ToString();
                //oHDVC.TramID = DACASUCO_App.User.TramID;
                oHDVC.VuTrongID = MDSolution.DACASUCO_App.VuTrongID;
                oHDVC.Save(null, null);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void gdVXeVanChuyen_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!SaveXeVanChuyen(false)) { e.Cancel = true; }
                else
                {
                    try
                    {
                        oXeVC.Load(null, null);
                        string sql = "Update tbl_NhapMia set SoXe=N'" + oXeVC.SoXe + "' Where XeID=" + oXeVC.ID.ToString();
                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                        sql = "Update tbl_ThanhToanVC set SoXe=N'" + oXeVC.SoXe + "' Where XeID=" + oXeVC.ID.ToString();
                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    }
                    catch
                    {
                        MessageBox.Show("Đã có lỗi trong việc cập nhật dữ liệu", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                LoadXeVanChuyen();
                e.Cancel = true;
            }
        }
        private bool IsXeVanChuyenOK(string SoXe)
        {
            string strSQL = "select Count(*) from tbl_XeVanChuyen where SoXe <>'-' AND VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID;
            //strSQL += " And  (SoXe = " + SoXe + ")";
            strSQL += " And (rTrim(lTrim([SoXe])) = rTrim(lTrim(N'" + SoXe + "')))";
            try
            {
                string ret = MDSolutionEntities.DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (long.Parse(ret) > 0) return true;
                else return false;
            }
            catch
            {
                return true;
            }

        }

        private void gdVXeVanChuyen_AddingRecord(object sender, CancelEventArgs e)
        {
            if (!SaveXeVanChuyen(true)) { e.Cancel = true; }
            else
            {
               this.gdVXeVanChuyen.SetValue("ID", oXeVC.ID);
            }
        }

        private void gdVXeVanChuyen_RecordAdded(object sender, EventArgs e)
        {
            this.LoadXeVanChuyen();
            this.gdVXeVanChuyen.Refetch();
        }

        private void frmHopDongVanChuyen_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            clsVuTrong oVT = new clsVuTrong(MDSolution.DACASUCO_App.VuTrongID);
            oVT.Load(null, null);
            lblInfor.Text = oVT.Ten;
        }

        private void gdVHopDongVanChuyen_UpdatingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                string sql = "";
                DataSet ds;
                if (string.IsNullOrEmpty(this.gdVHopDongVanChuyen.GetValue("MaHopDong").ToString())) throw new Exception("Bạn chưa nhập mã hợp đồng");

                sql = "SELECT * FROM tbl_HopDongVanCHuyen Where MaHopDong='" + this.gdVHopDongVanChuyen.GetValue("MaHopDong").ToString() + "'";
                ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow d13 = ds.Tables[0].Rows[0];

                    if (d13["ID"].ToString() != this.gdVHopDongVanChuyen.GetValue("ID").ToString()) throw new Exception("Bạn nhập trùng mã hợp đồng");
                }
                if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!SaveHopDongVanChuyen(false)) { e.Cancel = true; }
                }
                else
                {
                    this.LoadHopDongVanChuyen();
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void gdVHopDongVanChuyen_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {
            string sql = "Select HopDongVanChuyenID,ID,SoXe from tbl_XeVanChuyen Where HopDongVanChuyenID=" + this.gdVHopDongVanChuyen.GetValue("ID").ToString();
            DataSet ds=MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Hợp đồng vận chuyển đang có dữ liệu của xe VC","DACASUCO",MessageBoxButtons.OK,MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            int i = 0;
            try
            {
                string message;
                message = String.Format("Bạn muốn xóa chủ hợp đồng vận chuyển này?");

                if (MessageBox.Show(message, "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oHDVC.Delete(null, null);
                    i = 1;                   
                }
                else { e.Cancel = true; }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi xóa chủ hợp đồng vận chuyển");
                e.Cancel = true;
            }
            if (i == 1)
            {
                LoadHopDongVanChuyen();
                e.Cancel = true;
            }
        }

        private void gdVHopDongVanChuyen_RecordAdded(object sender, EventArgs e)
        {
          //  MessageBox.Show("Thông báo đã lưu thành công ");
            this.gdVHopDongVanChuyen.Refetch();
        }

        private void gdVHopDongVanChuyen_FormattingRow(object sender, RowLoadEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Row.Cells["NgayHopDong"].Text))
                {
                    DateTime dt;
                    dt = DateTime.Parse(e.Row.Cells["NgayHopDong"].Text);
                    e.Row.Cells["NgayHopDong"].Text = dt.ToShortDateString();
                }
            }
            catch
            {
                e.Row.Cells["NgayHopDong"].Text = "";
            }
        }

        private void gdVXeVanChuyen_RecordUpdated(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã sửa lại thành công", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //this.LoadXeVanChuyen();
            this.gdVXeVanChuyen.Refetch();
        }

        private void gdVHopDongVanChuyen_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "ThanhLyHD")
            {
                long HDVC = 0;
                try
                {
                    HDVC = long.Parse(this.gdVHopDongVanChuyen.GetValue("ID").ToString());
                }
                catch
                {
                    return;
                }
                if (HDVC > 0)
                {
                    frm_ThanhLyHDVC frm = new frm_ThanhLyHDVC(HDVC);
                    frm.ShowDialog();
                    this.LoadHopDongVanChuyen();
                }
            }

        }

        private void gdVXeVanChuyen_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if ((DACASUCO_App.User.RolesID != 0)&&(DACASUCO_App.User.RolesID != 2))
            {
                MessageBox.Show("Bạn không được sử dụng chức năng này!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (e.Column.Key == "Chuyen")
            {
                long ID = 0;
                try
                {
                    ID = long.Parse(this.gdVXeVanChuyen.GetValue("ID").ToString());
                }
                catch
                {
                    ID = 0;
                }
                if (ID > 0)
                {
                   
                        string DT = MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select convert(char(10),GetDate(),121)", null, null);
                        clsXeVanChuyen objXeVC = new clsXeVanChuyen(ID);
                        objXeVC.Load(null, null);
                        long HDVC_ID = objXeVC.HopDongVanChuyenID;
                        string So_Xe = objXeVC.SoXe;
                        string NKT = objXeVC.NoteModify;
                        clsHopDongVanChuyen oHDVC = new clsHopDongVanChuyen(HDVC_ID);
                        oHDVC.Load(null, null);
                        string TenHDVC = oHDVC.TenChuHopDong;
                        int OK = 0;
                        if (NKT == null)
                        {
                            frmThietLapVC_Xe frm = new frmThietLapVC_Xe(So_Xe, TenHDVC, "Sẽ dừng vận chuyển ", "Bạn chắc chắn thiết lập như trên?", DT, ID, 0);
                            frm.ShowDialog();
                            OK = frm.OK;
                        }
                        else
                        {
                            //string DTs = MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select convert(char(10),NKT,121) from tbl_XeVanChuyen Where ID="+ID.ToString(), null, null);
                            frmThietLapVC_Xe frm = new frmThietLapVC_Xe(So_Xe, TenHDVC, "Đã dừng vận chuyển ", "Bạn chắc chắn thiết lập cho xe được tiếp tục chạy?", NKT, ID, 1);
                            frm.ShowDialog();
                            OK = frm.OK;
                        }
                        if (OK == 1)
                        {
                            this.LoadXeVanChuyen();
                        }
                    
                }
            }
        }

        private void txtTim_Click(object sender, EventArgs e)
        {
            txtTim.Text = "";
            //LoadHopDongVanChuyen();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (rdHDVC.Checked)
            {
                Janus.Windows.GridEX.GridEXFilterCondition con = new Janus.Windows.GridEX.GridEXFilterCondition();
                con.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(gdVHopDongVanChuyen.RootTable.Columns["HTKD"], Janus.Windows.GridEX.ConditionOperator.Contains, txtTim.Text));
                gdVHopDongVanChuyen.RootTable.ApplyFilter(con);
            }
            if (txtTim.Text == "")
            {
                LoadHopDongVanChuyen();
            }
        }

        private void cmdIn_Click(object sender, EventArgs e)
        {
           // Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rpt_HDVC_XeVC rp= new rpt_HDVC_XeVC();
            frm.RP = rp;
            rp.SetParameterValue("VT", MDSolution.DACASUCO_App.VuTrongID);
            rp.SetParameterValue("NienVu",DACASUCO_App.TenVuTrong);
            rp.SetParameterValue("User", DACASUCO_App.User.HoTen);
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Chi tiết Hợp đồng vận chuyển DACASUCO";
            //frm.MdiParent = this;
            frm.Show();
        }

        private void gdVXeVanChuyen_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.gdVXeVanChuyen.CurrentRow.RowType == Janus.Windows.GridEX.RowType.NewRecord)
                {
                    oXeVC = new clsXeVanChuyen();
                }
                else
                {
                    oXeVC.ID = long.Parse(this.gdVXeVanChuyen.GetValue("ID").ToString());
                }
            }
            catch
            {
                oXeVC = new clsXeVanChuyen();
            }
        }

        private void gdVHopDongVanChuyen_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã xóa thành công HĐVC", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmdTim_Click(object sender, EventArgs e)
        {
            if (rdXeVC.Checked)
            {
                string sql = "Select * from V_HDVC Where VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString() + " AND ID In (Select HopDongVanChuyenID from tbl_XeVanChuyen Where SoXe Like N'%" + txtTim.Text + "%')";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    this.gdVHopDongVanChuyen.SetDataBinding(ds.Tables[0], "");

                }
            }

        }

        private void txtTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rdXeVC.Checked)
            {
                if (e.KeyChar == '\r')
                {
                    cmdTim_Click(null, null);
                }
            }
        }
        

      
      
    }
} 