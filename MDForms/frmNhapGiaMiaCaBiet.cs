using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;
using MDSolution;

namespace DACASUCO.MDForms
{
    public partial class frmNhapGiaMiaCaBiet : Form
    {
        bool kt = false;
        public frmNhapGiaMiaCaBiet()
        {
            InitializeComponent();
        }
        public frmNhapGiaMiaCaBiet(string MaHDDT, bool dk)
        {
            InitializeComponent();
            kt = dk;
            string sql = "";
            if (dk)
        {
             sql = "Select * from V_GiaMia where MaHDDT='"+MaHDDT+"' AND Vu_Trong_ID="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
        }
        else
        {
             sql = "Select * from V_BangGiaCaBiet where ID='" + MaHDDT + "' AND VuTrongID="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
        }
        DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtMaHDDT.Text = ds.Tables[0].Rows[0]["MaHDDT"].ToString();
            txtHoTen.Text = ds.Tables[0].Rows[0]["HoTen"].ToString();
            txtTram.Text = ds.Tables[0].Rows[0]["TenTram"].ToString();
            dtNgay.Value = DateTime.Parse(ds.Tables[0].Rows[0]["Ngay"].ToString());
            txtGio.Text = ds.Tables[0].Rows[0]["Gio"].ToString();
            txtGia.Text = ds.Tables[0].Rows[0]["Gia"].ToString();
            txtTramID.Text = ds.Tables[0].Rows[0]["TramID"].ToString();
            txtHopdongID.Text = ds.Tables[0].Rows[0]["HopDongID"].ToString();
            txtID.Text = ds.Tables[0].Rows[0]["ID"].ToString();
        }

        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhapGiaMiaCaBiet_Load(object sender, EventArgs e)
        {

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (kt)
            {
                if (MessageBox.Show("Bạn sẽ thiết lập giá nhập mía cá biệt cho HĐĐT " + txtMaHDDT.Text + "?", "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        sql = "Insert into tbl_GiaMiaCaBiet (MaHDDT,HopDongID,TramID,NgayApDung,GioApDung,Gia,VuTrongID) Values('" + txtMaHDDT.Text + "','" + txtHopdongID.Text + "'," + txtTramID.Text + "," + MDSolutionEntities.DBModule.RefineDatetime(dtNgay.Value) + "," + txtGio.Text + "," + txtGia.Text + ","+ MDSolution.DACASUCO_App.VuTrongID.ToString()+")";
                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                        MessageBox.Show("Bạn đã thiết lập thành công!", "DACASUCO");
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Đã có lỗi xảy ra khi thêm mới!", "DACASUCO");
                    }

                }
            }
            else
            {
                DialogResult Dlog = MessageBox.Show("HĐĐT " + txtMaHDDT.Text + " đã được thiết lập giá thu mua cá biệt!" + "\n" + "Bạn chọn YES để thêm mới, chọn NO để sửa", "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Dlog == DialogResult.No)
                {
                    try
                    {
                        sql = "Update tbl_GiaMiaCaBiet Set NgayApDung=" + MDSolutionEntities.DBModule.RefineDatetime(dtNgay.Value) + ",GioApDung=" + txtGio.Text + ",Gia=" + txtGia.Text + " Where ID='" + txtID.Text + "' AND VuTrongID="+ MDSolution.DACASUCO_App.VuTrongID.ToString();
                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                        MessageBox.Show("Bạn đã sửa lại thành công!", "DACASUCO");
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Đã có lỗi xảy ra trong khi sửa!", "DACASUCO");
                    }
                }
                else
                {
                    try
                    {
                        sql = "Insert into tbl_GiaMiaCaBiet (MaHDDT,HopDongID,TramID,NgayApDung,GioApDung,Gia,VuTrongID) Values('" + txtMaHDDT.Text + "','" + txtHopdongID.Text + "'," + txtTramID.Text + "," + MDSolutionEntities.DBModule.RefineDatetime(dtNgay.Value) + "," + txtGio.Text + "," + txtGia.Text +","+ MDSolution.DACASUCO_App.VuTrongID.ToString()+ ")";
                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                        MessageBox.Show("Bạn đã thêm mới thành công!", "DACASUCO");
                        this.Close();
                        
                    }
                    catch
                    {
                        MessageBox.Show("Đã có lỗi xảy ra khi thêm mới!", "DACASUCO");
                    }
                }

            }
        }
    }
}
