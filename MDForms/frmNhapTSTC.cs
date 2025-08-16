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
    public partial class frmNhapTSTC : Form
    {
        public frmNhapTSTC()
        {
            InitializeComponent();
        }
        public long _ID = -1;
        public bool Ad=false;
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public frmNhapTSTC(long ID,bool add)
        {
            InitializeComponent();
            Ad = add;
            _ID = ID;
            this.TaoCombo_MaHDDT(ID);
            this.LoadTramNongVu();
            this.LoadLoaiTaiSan();
            string sql = "Select HoTen,DiaChi,SoCMT from tbl_HopDong Where ID=" + _ID.ToString();
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            txtChuMia.Text = ds.Tables[0].Rows[0]["HoTen"].ToString();
            txtDiaChi.Text = ds.Tables[0].Rows[0]["DiaChi"].ToString();
            txtSoCMND.Text = ds.Tables[0].Rows[0]["SoCMT"].ToString();
            if (txtSoCMND.Text == "")
            {
                txtSoCMND.TextAlign = HorizontalAlignment.Center;
                txtSoCMND.ForeColor = Color.Red;
                txtSoCMND.Text = "Chưa nhập";
            }
            txtTinhTrang.Text = "";
        }
        public frmNhapTSTC(string ID, bool add)
        {
            InitializeComponent();
            _ID = long.Parse(ID);
            Ad = add;
            this.LoadTramNongVu();
            this.LoadLoaiTaiSan();
            string sql = "Select * from tbl_TaiSanTheChap where ID=" + ID.ToString();
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            long HDID=long.Parse(ds.Tables[0].Rows[0]["HopDongID"].ToString());
            this.TaoCombo_MaHDDT(HDID);
            cbLoaiTS.SelectedValue = long.Parse(ds.Tables[0].Rows[0]["TaiSanTheChapID"].ToString());
            cbMaHDDT.Text = ds.Tables[0].Rows[0]["MaHDDT"].ToString();
            cbTram.SelectedValue = long.Parse(ds.Tables[0].Rows[0]["TramID"].ToString());
            txtSoTien.Text = ds.Tables[0].Rows[0]["SoTien"].ToString();
            txtTinhTrang.Text = ds.Tables[0].Rows[0]["TinhTrang"].ToString();
            if (txtTinhTrang.Text == "")
            {
                chkThanhLy.Text = "Chưa thanh lý";
                chkThanhLy.Checked = false;
            }
            else
            {
                chkThanhLy.Text = "Đã thanh lý";
                chkThanhLy.Checked = true;
            }
            txtSHTS.Text = ds.Tables[0].Rows[0]["SoHieu"].ToString();
            txtThoiHan.Text = ds.Tables[0].Rows[0]["ThoiHan"].ToString();
            txtChuTS.Text = ds.Tables[0].Rows[0]["NguoiSHTS"].ToString();
            sql = "Select HoTen,DiaChi,SoCMT from tbl_HopDong where ID=" + ds.Tables[0].Rows[0]["HopDongID"].ToString();
            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            txtChuMia.Text = ds.Tables[0].Rows[0]["HoTen"].ToString();
            txtDiaChi.Text = ds.Tables[0].Rows[0]["DiaChi"].ToString();
            txtSoCMND.Text = ds.Tables[0].Rows[0]["SoCMT"].ToString();
            if (txtSoCMND.Text == "")
            {
                txtSoCMND.TextAlign = HorizontalAlignment.Center;
                txtSoCMND.ForeColor = Color.Red;
                txtSoCMND.Text = "Chưa nhập";
            }
            
        }

        private void TaoCombo_MaHDDT(long ID)
        {
            string QR = "SELECT distinct ID, MaHDDT FROM tbl_HopDongDauTu  Where HopdongId=(Select ID from tbl_hopdong where ID=" + ID.ToString() + ")";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(QR, null, null);
            cbMaHDDT.DataSource = ds.Tables[0];
            DataRow oR = ds.Tables[0].NewRow();
            oR["MaHDDT"] = "";
            oR["ID"] = 0;
            ds.Tables[0].Rows.InsertAt(oR, 0);
            cbMaHDDT.DisplayMember = "MaHDDT";
            cbMaHDDT.ValueMember = "ID";
        }
        private void LoadTramNongVu()
        {
            DataSet ds;
            string sql = "Select ID, Ten from tbl_TramNongVu";
            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            this.cbTram.DataSource = ds.Tables[0];
            DataRow oR = ds.Tables[0].NewRow();
            oR["ID"] = 0;
            oR["Ten"] = "";
            ds.Tables[0].Rows.InsertAt(oR, 0);
            this.cbTram.ValueMember = "ID";
            this.cbTram.DisplayMember = "Ten";
        }
        private void LoadLoaiTaiSan()
        {
            DataSet ds;
            string sql = "Select ID, TenGoiTaiSan from tbl_DanhMucTaiSanTheChap";
            ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            this.cbLoaiTS.DataSource = ds.Tables[0];
            this.cbLoaiTS.ValueMember = "ID";
            this.cbLoaiTS.DisplayMember = "TenGoiTaiSan";
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            string sql = "";

            if (chkThanhLy.Checked)
            {
                txtTinhTrang.Text = "Đã thanh lý";
            }
            else
            {
                txtTinhTrang.Text = "";
            }
            if(Ad)
            {
                try
                {
                    sql = "Insert Into tbl_TaiSanTheChap (HopDongID,TaiSanTheChapID,SoHieu,MaHDDT,TramID,TinhTrang,NguoiSHTS,ThoiHan,SoTien)"
                    + " values(" + _ID.ToString() + "," + cbLoaiTS.SelectedValue.ToString() + ",N'" + txtSHTS.Text + "',N'" + cbMaHDDT.Text + "'," + cbTram.SelectedValue.ToString() + ",N'" + txtTinhTrang.Text + "',N'" + txtChuTS.Text + "'," + txtThoiHan.Text+","+txtSoTien.Text+")";
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    MessageBox.Show("Bạn đã thêm mới thành công!","DACASUCO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra khi thêm mới","DACASUCO");
                }
            }
            else
            {
                try
                {
                    sql = "Update tbl_TaiSanTheChap set TaiSanTheChapID=" + cbLoaiTS.SelectedValue.ToString() + ",SoHieu=N'" + txtSHTS.Text + "',MaHDDT=N'" + cbMaHDDT.Text + "',TramID=" + cbTram.SelectedValue.ToString() + ",TinhTrang=N'" + txtTinhTrang.Text + "',NguoiSHTS=N'" + txtChuTS.Text + "',ThoiHan=" + txtThoiHan.Text + ",SoTien=" + txtSoTien.Text
                        + " Where ID=" + _ID.ToString();
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    MessageBox.Show("Bạn đã sửa lại thành công!","DACASUCO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                MessageBox.Show("Đã có lỗi xảy ra khi sửa","DACASUCO");
                }
            }
           
                
                
            }

        private void chkThanhLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThanhLy.Checked)
            {
                chkThanhLy.Text = "Đã thanh lý";
            }
            else
            {
                chkThanhLy.Text = "Chưa thanh lý";
            }
        }
        


       
    }
}
