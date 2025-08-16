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
    public partial class HoTroTapChat : Form
    {
        public HoTroTapChat()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HoTroTapChat_Load(object sender, EventArgs e)
        {
            string sql = "Select * from tbl_HoTroTC";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int ID = int.Parse(dr["ID"].ToString());
                if(ID==1)
                {
                rdKTTu.Value = decimal.Parse(dr["Tu"].ToString());
                rdKTDen.Value = decimal.Parse(dr["Den"].ToString());
                }
                else if (ID == 2)
                {
                    rdTTTu.Value = decimal.Parse(dr["Tu"].ToString());
                    rdTTDen.Value = decimal.Parse(dr["Den"].ToString());
                }
                else if (ID == 3)
                {
                    int DuocTinh = 0;
                    rdAdd1Tu.Value = decimal.Parse(dr["Tu"].ToString());
                    rdAdd1Den.Value = decimal.Parse(dr["Den"].ToString());
                    rdAdd1.Value = decimal.Parse(dr["Them"].ToString());
                    DuocTinh = int.Parse(dr["DuocTinh"].ToString());
                    if (DuocTinh == 0) rdThem.Checked = true; else rdTinhLa.Checked = true;
                    
                }
                else
                {
                    int DuocTinh = 0;
                    rdNgoaiRaTu.Value = decimal.Parse(dr["Tu"].ToString());
                    rdAdd2.Value = decimal.Parse(dr["Them"].ToString());
                    DuocTinh = int.Parse(dr["DuocTinh"].ToString());
                    if (DuocTinh == 0) rdThem1.Checked = true; else rdTinhLa1.Checked = true;
                }
                   
            }
            Timer tmr = new Timer();
            tmr.Interval = 300;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
            lblStatus.ForeColor = Color.Chocolate;
            //rdKTTu.Value = ds.Tables[0].Rows["Tu"].ToString();
            //rdKTDen.Value = ds.Tables[0].Rows["Den"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery("Select convert(char(8),GetDate(),114) as Gio,convert(char(20),GetDate(),103) as Ngay", null, null);
            string Gio = ds.Tables[0].Rows[0]["Gio"].ToString();
            string Ngay = ds.Tables[0].Rows[0]["Ngay"].ToString();
            frmCF1 frm= new frmCF1(Gio,Ngay);
            frm.ShowDialog();
            long OK = frm.OK;
            frm.Close();
            if (OK == 0)
            {
                
                try
                {
                    sql = "Update tbl_HoTroTC set Tu=" + rdKTTu.Value.ToString() + ",Den=" + rdKTDen.Value.ToString() + ",Them=-1  Where ID=1";
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    sql = "Update tbl_HoTroTC set Tu=" + rdTTTu.Value.ToString() + ",Den=" + rdTTDen.Value.ToString() + " Where ID=2";
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    int DuocTinh = 0;
                    if (rdThem.Checked) DuocTinh = 0; else if(rdTinhLa.Checked) DuocTinh = 1;
                    sql = "Update tbl_HoTroTC set Tu=" + rdAdd1Tu.Value.ToString() + ",Den=" + rdAdd1Den.Value.ToString() + ",Them=" + rdAdd1.Value.ToString() +",DuocTinh="+DuocTinh.ToString()+ " Where ID=3";
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    DuocTinh = 0;
                    if (rdThem1.Checked) DuocTinh = 0; else if(rdTinhLa1.Checked)DuocTinh = 1;
                    sql = "Update tbl_HoTroTC set Tu=" + rdNgoaiRaTu.Value.ToString() + ",Den=100" + ",Them=" + rdAdd2.Value.ToString() + ",DuocTinh= "+DuocTinh.ToString()+" Where ID=4";
                    MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                    MessageBox.Show("Bạn đã cập nhật thành công!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                this.Close();
            }
           
        }
        
        void tmr_Tick(object sender, EventArgs e)
        {
            if (lblStatus.ForeColor == Color.Chocolate)
            {
                lblStatus.ForeColor = Color.Green;
            }
            else if (lblStatus.ForeColor == Color.Green)
            {
                lblStatus.ForeColor = Color.Chocolate;
            }
        }

       
    }
}
