using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using DACASUCO.MDDialoge;

namespace MDSolution
{
    public partial class frmEdit_tbl_NhapMia : Form
    {
        public string SoPhieu;
        public string SoXe;
        public string ID;
        public int OK = 0;
        public long MuaTaiBC = 0;
        public long MuaCCS = 0;
        public double DGVC = 0;
        public double DGMia = 0;
        public long SPN = 0;
        private int HopDongID = -1;
        private int XeID = -1;
        public frmEdit_tbl_NhapMia()
        {
            InitializeComponent();
        }

        private void frmEdit_tbl_NhapMia_Load(object sender, EventArgs e)
        {
            if (ID != null)
            {
                clsNhapMia objNhapMia = new clsNhapMia(long.Parse(ID));
                objNhapMia.Load(null, null);
                clsHopDong objHD = new clsHopDong(objNhapMia.HopDongID);
                objHD.Load(null, null);
                txtChuMia.Text = objHD.HoTen.ToString();
                SPN = long.Parse(objNhapMia.SoPhieuNhap);
                txtSPN.Text = objNhapMia.SoPhieuNhap.ToString();
                txtXeVC.Text = objNhapMia.SoXe;
                txtTongTL.Text = objNhapMia.TongTrongLuong.ToString("### ###0");
                txtTLXe.Text = objNhapMia.TrongLuongXe.ToString();
                txtTLQC.Text = (objNhapMia.TongTrongLuong - objNhapMia.TrongLuongXe).ToString("### ##0");
                txtTiLeTapVat.Text = objNhapMia.TyLeTapVat.ToString();
                txtTCBK.Text = objNhapMia.TCBK.ToString();
                txtTLTC.Text = objNhapMia.TrongLuongTapVat.ToString("### ##0");
                DGMia = (Double)objNhapMia.DonGiaMia;
                txtCCS.Text = "0";
                try
                {
                    txtCCS.Text = MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select CCS from tbl_CCS where Sophieucan=" + SPN.ToString() + " And VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString(), null, null);
                }
                catch
                {
                    txtCCS.Text = "0";
                }
                if (txtCCS.Text == "")
                {
                    txtCCS.Text = "0";
                }
                if (objNhapMia.CCS == 1)
                {
                    txtTLMS.Text = (Math.Round(((objNhapMia.TongTrongLuong - objNhapMia.TrongLuongXe - objNhapMia.TrongLuongTapVat) * decimal.Parse(txtCCS.Text) / 10), 0)).ToString();
                }
                else
                {
                    txtTLMS.Text = (objNhapMia.TongTrongLuong - objNhapMia.TrongLuongXe - objNhapMia.TrongLuongTapVat).ToString("### ###0");
                }


                if (objNhapMia.MiaChay == 1)
                {
                    chkMiachay.Checked = true;
                }
                DGVC = (Double)Math.Round(objNhapMia.DonGiaVanChuyen / 1000, 0);

                //DGMia = (Double)objNhapMia.DonGiaMia;
                txtDonGia.Text = DGMia.ToString("### ##0");
                txtDGVC.Text = DGVC.ToString("### ##0");
                txtTienMia.Text = objNhapMia.TienMia.ToString("### ### ### ##0");
                txtTienVC.Text = objNhapMia.TienVanChuyen.ToString("### ### ### ##0");

                if (objNhapMia.CCS == 1)
                {
                    rdBanCan.Checked = true;
                }
                else
                {
                    rdTaiRuong.Checked = true;
                }
                if (objNhapMia.CCS == 1)
                {
                    rdCCS.Checked = true;
                }
                else
                {
                    rdMiaSach.Checked = true;
                }

            }

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Check_MaHD(string IDHD_truyen, string MaChuHD_Nhap)
        {
            clsHopDong objHD = new clsHopDong();
            objHD.Load(MaChuHD_Nhap, null, null);
            if (objHD.ID > 0)
            {
                if (objHD.ID.ToString() == IDHD_truyen)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        private double LamTronLen10(double TrongLuong)
        {
            TrongLuong = Math.Round(TrongLuong);
            // phan lam tron len 10kg
            int sodu = Convert.ToInt16(TrongLuong % 10);
            int KQ;
            if (sodu != 0)
            {
                KQ = Convert.ToInt16(Math.Round(TrongLuong / 10));
                KQ = (KQ) * 10;
            }
            else
            {
                KQ = Convert.ToInt16(TrongLuong);
            }
            return KQ;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn sửa phiếu cân số " + SPN.ToString(), "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int GVC = int.Parse(txtDGVC.Text.Replace(" ", "")) * 1000;
                    string sql = "Update tbl_NhapMia set TrongLuongXe= " + txtTLXe.Text.Replace(" ", "") + " ,TrongLuongTapVat= " + txtTLTC.Text.Replace(" ", "") + ", MuaTaiBanCan=" + MuaTaiBC.ToString() + ",MuaTheoCCS=" + MuaCCS.ToString() + ",DonGiaMia=" + txtDonGia.Text.Replace(" ", "") +
                        ",TienMia=" + txtTienMia.Text.Replace(" ", "") + ",DonGiaVanChuyen=" + GVC.ToString() + ",TienVanChuyen=" + txtTienVC.Text.Replace(" ", "") + ",TyLeTapVat=" + txtTiLeTapVat.Text.Replace(" ", "") + ",TCBK=" + txtTiLeTapVat.Text.Replace(" ", "") + " Where SoPhieuNhap=" + SPN.ToString() + " And VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);


                    if (HopDongID > 0)
                    {
                        string sqlHopDongID = @"Update tbl_NhapMia set HopDongID= " + HopDongID + " Where SoPhieuNhap=" + SPN.ToString() + " And VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                        MDSolutionEntities.DBModule.ExecuteQuery(sqlHopDongID, null, null);
                    }
                    if (XeID > 0)
                    {
                        string sqlHopDongID = @"Update tbl_NhapMia set XeID= " + XeID + ", SoXe= '" + txtXeVC.Text + "' Where SoPhieuNhap=" + SPN.ToString() + " And VuTrongID=" + MDSolution.DACASUCO_App.VuTrongID.ToString();
                        MDSolutionEntities.DBModule.ExecuteQuery(sqlHopDongID, null, null);
                    }

                    MessageBox.Show("Đã sửa thành công!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OK = 1;
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Có lỗi trong khi lưu.Hãy kiểm tra lại dữ liệu!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //txtMaHD.Focus();
                }
            }
        }

        private string XuLyChuoiTien(string TienFomat)
        {
            string[] str = TienFomat.Split(',');
            string strKQ = "";
            foreach (string s in str)
            {
                strKQ += s;
            }
            if (strKQ != "")
                return strKQ;
            else
                return "0";
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Enter:
                        try
                        {
                            SendKeys.Send("{TAB}");
                        }
                        catch { }
                        break;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtDGVC_TextChanged(object sender, EventArgs e)
        {
            if (txtDGVC.Text == "") txtDGVC.Text = "0";
            if (MuaTaiBC == 1) txtDGVC.Text = "0";
            else
                txtTienVC.Text = TienVC(MuaTaiBC).ToString("### ### ### ##0");

        }

        private void rdMiaSach_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMiaSach.Checked)
            {
                MuaCCS = 0;
                txtTLMS.Text = (Math.Round((double.Parse(txtTLQC.Text.Replace(" ", "")) - double.Parse(txtTLTC.Text.Replace(" ", ""))), 0)).ToString();
                txtTienMia.Text = TienMia(MuaCCS).ToString("### ### ### ##0");
            }
        }

        private void rdCCS_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCCS.Checked)
            {
                MuaCCS = 1;
                txtTLMS.Text = (Math.Round(((double.Parse(txtTLQC.Text.Replace(" ", "")) - double.Parse(txtTLTC.Text.Replace(" ", ""))) * double.Parse(txtCCS.Text) / 10), 0)).ToString();
                txtTienMia.Text = TienMia(MuaCCS).ToString("### ### ### ##0");

            }
            else
            {
                txtTLMS.Text = (Math.Round((double.Parse(txtTLQC.Text.Replace(" ", "")) - double.Parse(txtTLTC.Text.Replace(" ", ""))), 0)).ToString();
            }
        }

        private void rdTaiRuong_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTaiRuong.Checked) MuaTaiBC = 0;
            txtDGVC.Text = DGVC.ToString("### ### ##0");
            txtTienVC.Text = TienVC(MuaTaiBC).ToString("### ### ### ##0");
        }

        private void rdBanCan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBanCan.Checked) MuaTaiBC = 1;
            txtDGVC.Text = "0";
            txtTienVC.Text = "0";// TienVC(MuaTaiBC).ToString("### ### ### ##0");
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if (txtDonGia.Text == "") txtDonGia.Text = "0";
            txtTienMia.Text = TienMia(MuaCCS).ToString("### ### ### ##0");
        }
        private double TienMia(long HT)
        {
            double TM = 0;
            double DonGia = 0;
            double TLMiaSach = 0;
            if (HT == 0 && txtDonGia.Text != "")
            {

                DonGia = double.Parse(txtDonGia.Text.Replace(" ", ""));
                TLMiaSach = double.Parse(txtTLMS.Text.Replace(" ", ""));
                TM = Math.Round(DonGia * TLMiaSach, 0);
            }
            else
            {
                if (txtDonGia.Text != "")
                {
                    DonGia = double.Parse(txtDonGia.Text.Replace(" ", ""));
                    TM = Math.Round(double.Parse(txtDonGia.Text.Replace(" ", "")) * double.Parse(txtTLMS.Text.Replace(" ", "")), 0);
                }
            }
            return TM;
        }
        private double TienVC(long HT)
        {
            double TVC = 0;
            if (HT == 0 && txtDGVC.Text != "")
            {
                double DonGiaVC = 0;
                double TLQC = 0;
                DonGiaVC = double.Parse(txtDGVC.Text.Replace(" ", ""));
                TLQC = double.Parse(txtTLQC.Text.Replace(" ", ""));
                TVC = Math.Round(DonGiaVC * TLQC, 0);
            }
            else
            {
                TVC = 0;
            }
            return TVC;
        }
        private void Get_Khach_By_ID(string MaKhach)
        {
            if (MaKhach != "")
            {
                clsHopDong objHD = new clsHopDong(long.Parse(MaKhach));
                objHD.Load(null, null);
                if (objHD.ID > 0)
                {
                    txtChuMia.Text = clsComFunctions.HoTen_Format(objHD.HoTen);
                }
                else
                {
                    txtChuMia.Text = "";
                }
            }
        }
        private void Get_Xe_By_ID(string Xe)
        {
            if (Xe != "")
            {

                clsXeVanChuyen objXe = new clsXeVanChuyen(long.Parse(Xe));
                objXe.Load(null, null);
                if (objXe.ID > 0)
                {
                    txtXeVC.Text = objXe.SoXe;
                }
                else
                {
                    txtXeVC.Text = "";
                }
            }
        }
        public void GetHopDongID(string value)
        {
            ID = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DACASUCO.MDDialoge.dlgHopDong dlg = new DACASUCO.MDDialoge.dlgHopDong();
            dlg.passID = new DACASUCO.MDDialoge.dlgHopDong.PassID(GetHopDongID);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                Get_Khach_By_ID(ID);
                HopDongID = int.Parse(ID);
                dlg.Dispose();
            }
            else
            {
                dlg.Dispose();
            }

        }
        public void GetXeID(string value)
        {
            ID = value;
        }
        private void cmd_Xe_Click(object sender, EventArgs e)
        {
            DACASUCO.MDDialoge.dlgXeChuaCanBi dlgxe = new DACASUCO.MDDialoge.dlgXeChuaCanBi();
            dlgxe.passID = new DACASUCO.MDDialoge.dlgXeChuaCanBi.PassID(GetXeID);
            dlgxe.ShowDialog();
            if (dlgxe.DialogResult == DialogResult.OK)
            {
                Get_Xe_By_ID(ID);
                XeID = int.Parse(ID);
                dlgxe.Dispose();
            }
            else
            {
                dlgxe.Dispose();
            }
        }

        private void txtTLXe_TextChanged(object sender, EventArgs e)
        {
            if (txtTLXe.Text == "") txtTLXe.Text = "0";
            if (txtTLTC.Text == "") txtTLTC.Text = "0";
            else
            {
                double TongLT = 0;
                double TrongLXe = 0;
                double TongLTC = 0;
                double TLTV = 0;
                double TLTVT = 0;
                TLTVT = double.Parse(txtTiLeTapVat.Text.Replace(" ", ""));
                TongLT = double.Parse(txtTongTL.Text.Replace(" ", ""));
                TrongLXe = double.Parse(txtTLXe.Text.Replace(" ", ""));
                TLTV = Math.Round((TongLT - TrongLXe) * TLTVT / 100, 0);
                txtTLQC.Text = (TongLT - TrongLXe).ToString();
                txtTLTC.Text = TLTV.ToString();
                txtTienVC.Text = TienVC(MuaTaiBC).ToString("### ### ### ##0");
                txtTLMS.Text = Math.Round((TongLT - TrongLXe - TLTV), 0).ToString();
                txtTienMia.Text = TienMia(MuaCCS).ToString("### ### ### ##0");

            }
            if (MuaTaiBC == 1) txtDGVC.Text = "0";

        }

        private void txtTiLeTapVat_TextChanged(object sender, EventArgs e)
        {
            if (txtTiLeTapVat.Text == "") txtTiLeTapVat.Text = "0";
            else
            {
                double TongLT = 0;
                double TrongLXe = 0;
                double TLTV = 0;
                double TLTVT = 0;
                TLTVT = double.Parse(txtTiLeTapVat.Text.Replace(" ", ""));
                TongLT = double.Parse(txtTongTL.Text.Replace(" ", ""));
                TrongLXe = double.Parse(txtTLXe.Text.Replace(" ", ""));
                TLTV = Math.Round((TongLT - TrongLXe) * TLTVT / 100, 0);
                txtTLQC.Text = (TongLT - TrongLXe).ToString();
                txtTLTC.Text = TLTV.ToString();
                txtTienVC.Text = TienVC(MuaTaiBC).ToString("### ### ### ##0");
                txtTLMS.Text = Math.Round((TongLT - TrongLXe - TLTV), 0).ToString();
                txtTienMia.Text = TienMia(MuaCCS).ToString("### ### ### ##0");
            }
        }



    }
}