    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using DACASUCO.MDForms;
using DACASUCO.MDReport;
using MDSolutionEntities;
using MDSolution;

namespace MDSolution
{
    public partial class frmThanhToanCongNo : Form
    {
        private NodeDonVi nDonVi = new NodeDonVi();
        private clsHopDong oHD = new clsHopDong();        
        public frmThanhToanCongNo()
        {
            InitializeComponent();
            //this.CreateGridEX2ThuaRuongColumn();        
            Load_DDLDotThanhToan();            
        }
        public frmThanhToanCongNo(string HopDongID)
        {
            InitializeComponent();                      
            Load_DDLDotThanhToan();
            DoLoadHopDongInFo(HopDongID);
        }             
        
        private void DoLoadgdvChiTietDauTu(string strChuHopDongID)
        {
            try
            {
                DataSet ds;
                string strSQL = "sp_ChiTietDauTu_ChoMotChuHopDong " + strChuHopDongID + "," + DACASUCO_App.VuTrongID.ToString();
                ds = DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables.Count > 0)
                {
                    this.gdvChitietdautu.SetDataBinding(ds.Tables[0], "");
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load danh sách đầu tư", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoLoadgdvChiTietThanhToan(string strChuHopDongID)
        {
            try
            {
                DataSet ds;
                string strSQL = "sp_ChiTietThanhToan_ChoMotChuHopDong " + strChuHopDongID + " ," + DACASUCO_App.VuTrongID.ToString();
                ds = DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables.Count > 0)
                {
                    this.gdvChitietthanhtoan.SetDataBinding(ds.Tables[0], "");
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load danh sách thanh tóan mía", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DoLoadHopDongInFo(string strChuHopDongID)
        {
            try
            {
                this.oHD.ID = long.Parse(strChuHopDongID);
                this.oHD.Load(null, null);
                //Hien thi tinh trang cua hop dong
                DateTime dtNgayTinhCongNo = clsHopDong.GetNgayTinhCongNo(oHD.ID, DACASUCO_App.VuTrongID, null, null);
                labelNgayTinhCongNo.Text = dtNgayTinhCongNo.ToString("dd/MM/yyyy");
                string strtinhtrang = this.oHD.GetTinhTrangHopDongTrongVu(DACASUCO_App.VuTrongID, null, null);
                if(strtinhtrang[0]=='2')
                {
                    this.lblTinhTrangHopDongTrongVu.Text = "Đã thanh toán, đợt: " + strtinhtrang.Substring(2);
                    uibDaThanhToan.Enabled = false;
                    uibChoThanhToan.Enabled = false;
                    uibNhaptientrano.Enabled = false;
                    uibTinhCongNo.Enabled = false;
                    cbDoThanhToan.Enabled = false;
                }
                else if (strtinhtrang[0] == '1')
                {
                    this.lblTinhTrangHopDongTrongVu.Text = "Đang chờ thanh toán, đợt: " + strtinhtrang.Substring(2);                    
                    uibChoThanhToan.Enabled = false;
                    uibNhaptientrano.Enabled = false;
                    uibTinhCongNo.Enabled = false;
                    cbDoThanhToan.Enabled = false;
                }
                else {
                    this.lblTinhTrangHopDongTrongVu.Text = "Chưa xác định thanh toán";
                    this.uibChoThanhToan.Enabled = true;
                    this.uibDaThanhToan.Enabled = true;
                    this.uibTinhCongNo.Enabled = true;
                    this.dtNgayTinhCongNo.Enabled = true;
                    this.uibNhaptientrano.Enabled = true;
                }
                //Ket thuc hien thi tinh trang
                this.lblChuHopDong.Text = oHD.MaHopDong + " - " + oHD.HoTen + " - " + oHD.SoCMT;
                this.DoLoadgdvChiTietDauTu(strChuHopDongID);
                this.DoLoadgdvChiTietThanhToan(strChuHopDongID);

                //GridEXRow gEXR = this.gdvChitietdautu.GetTotalRow();
                //GridEXRow gEXR1 = this.gdvChitietthanhtoan.GetTotalRow();
                //decimal vTienphaitra = 0;
                //decimal vthanhtien = 0;
                //try
                //{
                //    GridEXColumn gdcl =  this.gdvChitietdautu.Tables[0].Columns["TienPhaiTra"];
                //    vTienphaitra =  this.gdvChitietdautu.GetTotal(gdcl,AggregateFunction.Sum);
                //}
                //catch(Exception ex) {
                //    vTienphaitra = 0;
                //}
                //try
                //{
                //    vthanhtien = (decimal)this.gdvChitietthanhtoan.GetTotal(this.gdvChitietthanhtoan.Tables[0].Columns["SoTien"], AggregateFunction.Sum);
                //}
                //catch {
                //    vthanhtien = 0;
                //}
                //if (gEXR != null && !string.IsNullOrEmpty(gEXR.Cells["TienPhaiTra"].Value.ToString()))
                  //  vTienphaitra = (decimal)gEXR.Cells["TienPhaiTra"].Value;

                //if (gEXR1 != null && !string.IsNullOrEmpty(gEXR1.Cells["SoTien"].Value.ToString()))
                //    vthanhtien = (decimal)gEXR1.Cells["SoTien"].Value;
                //decimal vnhanve = vthanhtien - vTienphaitra;
                //editBoxPhaiTra.Text = vTienphaitra.ToString("# ### ### ##0");
                //editBoxThuduoc.Text = vthanhtien.ToString("# ### ### ##0");
                //editLayVe.Text = vnhanve.ToString("# ### ### ##0");

                //string strSQL = "[sp_Get_TongTien_DauTu_ConLai] " + strChuHopDongID + "," + MDSolutionApp.VuTrongID.ToString();
                long lTongDauTuPhaiTra = clsHopDong.GetTongTienDauTuPhaiTra(long.Parse(strChuHopDongID), DACASUCO_App.VuTrongID, null, null);
                editBoxPhaiTra.Text = lTongDauTuPhaiTra.ToString("# ### ### ##0");
                long lTongTienKhoanCo = clsHopDong.GetTongCacKhoanTienCoThuDuoc(long.Parse(strChuHopDongID), DACASUCO_App.VuTrongID, null, null);
                editBoxThuduoc.Text = lTongTienKhoanCo.ToString("# ### ### ##0");
                long lLayve = lTongTienKhoanCo - lTongDauTuPhaiTra;
                editLayVe.Text = lLayve.ToString("# ### ### ##0");
                this.uibInPhieuChi.Enabled = true;
                
                this.uibInThanhToan.Enabled = true;

            }
            catch(Exception ex)
            {
                this.uibInPhieuChi.Enabled = false;
                this.uibNhaptientrano.Enabled = false;
                this.uibInThanhToan.Enabled = false;
                MessageBox.Show("Có lỗi khi lấy thông tin của chủ hợp đồng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void uibTimKiem_Click(object sender, EventArgs e)
        //{
        //    dlgHopDong dlg = new dlgHopDong();            
        //    dlg.passID= new dlgHopDong.PassID(GetHopDongID);
        //    dlg.ShowDialog();
        //    if (dlg.DialogResult == DialogResult.OK)
        //    {
        //        //MessageBox.Show("OK"+oHD.ID.ToString());
        //        DoLoadHopDongInFo(oHD.ID.ToString());
        //        dlg.Dispose();
        //    }
        //    else {
        //        //MessageBox.Show("Cancel" + oHD.ID.ToString());
        //        dlg.Dispose();
        //    }
        //    ////
        //}
               

        public void GetHopDongID(string value)
        {
            oHD.ID = long.Parse(value);
            //DoLoadHopDongInFo(oHD.ThonID.ToString());
        }

        private void uiTinhlaidautu_Click(object sender, EventArgs e)
        {

        }
               

        private void uibNhaptientrano_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmNhapTienTraNo frm = new frmNhapTienTraNo();
            //    frm.ChuHopDong = this.lblChuHopDong.Text;
            //    frm.ChuHopDongID = oHD.ID;
            //    frm.ShowDialog();
            //    if (frm.DialogResult == DialogResult.OK)
            //    {
            //        this.uibTinhCongNo_Click(null, EventArgs.Empty);
            //        //
            //        //this.DoLoadgdvChiTietThanhToan(oHD.ID.ToString());
            //    }
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }

        private void uibInThanhToan_Click(object sender, EventArgs e)
        {
            string IDNhapTien="-1";
            try
            {
               
                frmShowRP2 frm = new frmShowRP2();
                rp_T_DS_PhieuThanhToanMia rp = new rp_T_DS_PhieuThanhToanMia();
                rp.RecordSelectionFormula = "{tbl_HopDong.ID}=" + this.oHD.ID.ToString() + " and {tbl_VuTrong.ID}=" + DACASUCO_App.VuTrongID;// +" and ({tbl_NhapTienTraNo.VuTrongID}=" + MDSolutionApp.VuTrongID + " or {tbl_NhapTienTraNo.VuTrongID} =0)  and {View_T_TongHoTroKoDauTuTheoHD_VTrong.VuTrongID}=" + MDSolutionApp.VuTrongID;
                string sql = "select tbl_dautu_duno.NgayTinh from tbl_dautu_duno inner join tbl_dautu_truno on tbl_dautu_truno.dautuid=tbl_dautu_duno.Dautuid where id= (select max(id) from tbl_dautu_duno inner join tbl_dautu_truno on tbl_dautu_truno.dautuid=tbl_dautu_duno.Dautuid where hopdongid=" + this.oHD.ID.ToString() + " and Vutrongid=" + DACASUCO_App.VuTrongID + ")";
                //DBModule.ExecuteQuery(sql, null, null).Tables[0].Rows[0][0].ToString();
                try
                {
                    //frm.NgayTinh = Convert.ToDateTime(DBModule.ExecuteQuery(sql, null, null).Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    //frm.NgayTinh = dtNgayTinhCongNo.Value;
                }
                long LaiVuTruoc = 0;
                long LaiVuNay = 0;

                try
                {
                    foreach (GridEXRow jr in this.gdvChitietdautu.GetRows())
                    {
                        if (jr.Cells["LaDuNoVuTruoc"].Value.ToString() == "1")
                            LaiVuTruoc += long.Parse(jr.Cells["Lai"].Value.ToString());
                        else
                            LaiVuNay += long.Parse(jr.Cells["Lai"].Value.ToString());
                    }
                }
                catch { }
                //frm.LaiDuNoVuNay = LaiVuNay.ToString();
                //frm.LaiDuNoVuTruoc = LaiVuTruoc.ToString();


                long lTongDauTuPhaiTra = clsHopDong.GetTongTienDauTuPhaiTra(long.Parse(this.oHD.ID.ToString()), DACASUCO_App.VuTrongID, null, null);
                //editBoxPhaiTra.Text = lTongDauTuPhaiTra.ToString("# ### ### ##0");
                long lTongTienKhoanCo = clsHopDong.GetTongCacKhoanTienCoThuDuoc(long.Parse(this.oHD.ID.ToString()), DACASUCO_App.VuTrongID, null, null);
                //editBoxThuduoc.Text = lTongTienKhoanCo.ToString("# ### ### ##0");
                long lLayve = lTongTienKhoanCo - lTongDauTuPhaiTra;
                //editLayVe.Text = lLayve.ToString("# ### ### ##0");
                string sql_Sotien = "delete from tbl_TienBangChu_HopDong";
                DBModule.ExecuteNonQuery(sql_Sotien, null, null);
                if (lLayve > 0)
                {
                    sql_Sotien = "insert into tbl_TienBangChu_HopDong values(" + oHD.ID.ToString() + ",N'Số tiền được nhận (bằng chữ): " + frmShowRP3.DocSo(lLayve) + ".'," + lLayve.ToString() + ")";
                }
                else
                {
                    long ll = 0 - lLayve;
                    sql_Sotien = "insert into tbl_TienBangChu_HopDong values(" + oHD.ID.ToString() + ",N'Số tiền còn nợ (bằng chữ): " + frmShowRP3.DocSo(0 - lLayve) + ".'," + ll.ToString() + ")";
                }
                DBModule.ExecuteNonQuery(sql_Sotien, null, null);
                //long lTongDauTuPhaiTra = clsHopDong.GetTongTienDauTuConLai(long.Parse(this.oHD.ID.ToString()), MDSolutionApp.VuTrongID, null, null);
                ////editBoxPhaiTra.Text = lTongDauTuPhaiTra.ToString("# ### ### ##0");
                //long lTongTienKhoanCo = clsHopDong.GetTongCacKhoanTienCo(long.Parse(this.oHD.ID.ToString()), MDSolutionApp.VuTrongID, null, null);
                ////editBoxThuduoc.Text = lTongTienKhoanCo.ToString("# ### ### ##0");
                //long lLayve = lTongTienKhoanCo - lTongDauTuPhaiTra;
                //frm.SoTienBangChu = lLayve;
                //long[] ar=new long[10];
                //ar[0]=oHD.ID;

                sql = "select  count(*)  from tbl_nhaptientrano where hopdongid=" + oHD.ID.ToString() + " and vutrongid=" + DACASUCO_App.VuTrongID;
                if (Convert.ToInt32(DBModule.ExecuteQuery(sql, null, null).Tables[0].Rows[0][0].ToString()) == 0)
                {
                    IDNhapTien = DBModule.GetNewID(typeof(clsNhapTienTraNo), "tbl_NhapTienTraNo", null, null).ToString();
                    sql = "insert into tbl_nhaptientrano (ID,Sotien,NgayTra,HopDongID,VuTrongID) Values(" + IDNhapTien + ",0,''," + oHD.ID.ToString() + "," + DACASUCO_App.VuTrongID.ToString() + ")";
                    DBModule.ExecuteNonQuery(sql, null, null);
                };
                //frm.IDHopDong = ar;
                frm.RP = rp;
                frm.RPtitle = "Chi tiết hợp đồng";
                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.Show();
                if (IDNhapTien != "-1")
                {
                    sql = "Delete from tbl_NhapTienTraNo where ID=" + IDNhapTien;
                    DBModule.ExecuteNonQuery(sql, null, null);
                }

                //MessageBox.Show(this.gdChoThanhToan.GetValue("HopDongID").ToString());
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
            }
        }

        private void uibInPhieuChi_Click(object sender, EventArgs e)
        {
            try
            {

                frmShowRP2 frm = new frmShowRP2();
                rp_T_PhieuChiThanhToanMia rp = new rp_T_PhieuChiThanhToanMia();
                rp.RecordSelectionFormula = "{tbl_HopDong.ID}=" + this.oHD.ID.ToString() + " and {tbl_VuTrong.ID}=" + DACASUCO_App.VuTrongID;
                string sql = "select tbl_dautu_duno.NgayTinh from tbl_dautu_duno inner join tbl_dautu_truno on tbl_dautu_truno.dautuid=tbl_dautu_duno.Dautuid where id= (select max(id) from tbl_dautu_duno inner join tbl_dautu_truno on tbl_dautu_truno.dautuid=tbl_dautu_duno.Dautuid where hopdongid=" + this.oHD.ID.ToString() + " and Vutrongid=" + DACASUCO_App.VuTrongID + ")";


                long lTongDauTuPhaiTra = clsHopDong.GetTongTienDauTuPhaiTra(long.Parse(this.oHD.ID.ToString()), DACASUCO_App.VuTrongID, null, null);
                //editBoxPhaiTra.Text = lTongDauTuPhaiTra.ToString("# ### ### ##0");
                long lTongTienKhoanCo = clsHopDong.GetTongCacKhoanTienCoThuDuoc(long.Parse(this.oHD.ID.ToString()), DACASUCO_App.VuTrongID, null, null);
                //editBoxThuduoc.Text = lTongTienKhoanCo.ToString("# ### ### ##0");
                long lLayve = lTongTienKhoanCo - lTongDauTuPhaiTra;
                //editLayVe.Text = lLayve.ToString("# ### ### ##0");
                string sql_Sotien = "delete from tbl_TienBangChu_HopDong";
                DBModule.ExecuteNonQuery(sql_Sotien, null, null);
                if (lLayve > 0)
                {
                    sql_Sotien = "insert into tbl_TienBangChu_HopDong values(" + oHD.ID.ToString() + ",N'Số tiền được nhận (bằng chữ): " + frmShowRP3.DocSo(lLayve) + ".'," + lLayve.ToString() + ")";
                }
                else
                {
                    long ll = 0 - lLayve;
                    sql_Sotien = "insert into tbl_TienBangChu_HopDong values(" + oHD.ID.ToString() + ",N'Số tiền còn nợ (bằng chữ): " + frmShowRP3.DocSo(0 - lLayve) + ".'," + ll.ToString() + ")";
                }

                DBModule.ExecuteNonQuery(sql_Sotien, null, null);

                frm.RP = rp;
                frm.RPtitle = "Chi tiết hợp đồng";
                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.Show();
                //MessageBox.Show(this.gdChoThanhToan.GetValue("HopDongID").ToString());
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
            }
        }
        private void Load_DDLDotThanhToan()
        {
            string strSQL = "SELECT ISNULL(Max(DotThanhToan),0) FROM tbl_HopDong_ChoLamThanhToan Where VuTrongID=" + DACASUCO_App.VuTrongID.ToString();
            int ret = int.Parse(DBModule.ExecuteQueryForOneResult(strSQL, null, null));
            ret++;
            for (int i = 0; i <= ret; i++)
            {
                this.cbDoThanhToan.Items.Add(i);
            }
            this.cbDoThanhToan.SelectedItem = ret;
        }
        private void Load_TinhTrangHopDong()
        {
            string strSQL = "SELECT ISNULL(Max(DotThanhToan),0) FROM tbl_HopDong_ChoLamThanhToan Where VuTrongID=" + DACASUCO_App.VuTrongID.ToString();
            int ret = int.Parse(DBModule.ExecuteQueryForOneResult(strSQL, null, null));
            ret++;
            for (int i = 0; i <= ret; i++)
            {
                this.cbDoThanhToan.Items.Add(i);
            }
            this.cbDoThanhToan.SelectedItem = ret;
        }
        private void uibDaThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "sp_TinhToan_ChuyenVu " + this.oHD.ID.ToString() + ", " + DACASUCO_App.VuTrongID.ToString();
                    DBModule.ExecuteNonQuery(strSQL, null, null);
                    this.DoLoadHopDongInFo(this.oHD.ID.ToString());
                    MessageBox.Show("Hợp đồng đã chuyển sang phần đã thanh toán","Thông báo");
                    //uibDaThanhToan.Enabled = false;
                    //uibChoThanhToan.Enabled = false;
                    //uibNhaptientrano.Enabled = false;
                    //uibTinhCongNo.Enabled = false;
                    //cbDoThanhToan.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void uibChoThanhToan_Click(object sender, EventArgs e)
        {
            try
            {                
                    clsHopDong_ChoLamThanhToan cltt = new clsHopDong_ChoLamThanhToan();
                    cltt.HopDongID = this.oHD.ID;
                    cltt.VuTrongID = DACASUCO_App.VuTrongID;
                    cltt.DotThanhToan = long.Parse(cbDoThanhToan.SelectedItem.ToString());
                    cltt.Save(null, null);
                    this.DoLoadHopDongInFo(this.oHD.ID.ToString());
                    MessageBox.Show("Hợp đồng đã được đưa vào danh sách chờ thanh toán của đợt "+cltt.DotThanhToan.ToString(), "Thông báo");
                    //uibChoThanhToan.Enabled = false;
                    //uibNhaptientrano.Enabled = false;
                    //uibTinhCongNo.Enabled = false;
                    //cbDoThanhToan.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void uibTinhCongNo_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtTCN = DateTime.Now;
                dtTCN = (DateTime) dtNgayTinhCongNo.Value;

                string strSQL = "sp_TinhToan_CongNo " + this.oHD.ID.ToString() + ", " + DACASUCO_App.VuTrongID.ToString() + "," + DBModule.RefineDatetime(dtTCN);
                DBModule.ExecuteNonQuery(strSQL, null, null);
                this.DoLoadHopDongInFo(this.oHD.ID.ToString());
                MessageBox.Show("Đã tính toán lại công nợ của hợp đồng đến ngày : "+dtTCN.ToString("dd/MM/yyyy"), "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editLayVe_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
