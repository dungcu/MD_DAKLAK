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
    public partial class frmQCMC : Form
    {
        long _MuaCCS = 0;
        decimal _KT=0;
        public frmQCMC()
        {
            InitializeComponent();
        }

        private void frmQCMC_Load(object sender, EventArgs e)
        {
            string sql = "Select * from QuyCheMiaChay";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            long KT = 0;
            long MuaCCS = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    KT = long.Parse(ds.Tables[0].Rows[0]["KhauTru"].ToString());
                }
                catch
                {
                    KT = 0;
                }
                try
                {
                    MuaCCS = long.Parse(ds.Tables[0].Rows[0]["MuaCCS"].ToString());
                }
                catch
                {
                   MuaCCS = 0;
                }
            }

            if (MuaCCS == 1)
            {
                chkCCS.Checked = true;
            }
            if (KT >= 0)
            {
                chkKT.Checked = true;
                nKhauTru.Value = KT;
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkCCS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCCS.Checked)
            {
                _MuaCCS = 1;
            }
            else
            {
                _MuaCCS = 0;
            }
        }

        private void chkKT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKT.Checked)
            {
                _KT = nKhauTru.Value;
            }
            {
                nKhauTru.Value = 0;
                _KT = 0;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn chắc chắn thiết lập phương thức mua Mía cháy như đã chọn lựa?","DACASUCO",  MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
            try
            {
            MDSolutionEntities.DBModule.ExecuteQuery("Update QuyCheMiaChay set MuaCCS="+_MuaCCS.ToString()+",KhauTru="+nKhauTru.Value.ToString(),null,null);
                MessageBox.Show("Đã thiết lập thành công!","DACASUCO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
                catch
            {
                     MessageBox.Show("Đã có lỗi xảy ra!","DACASUCO",MessageBoxButtons.OK,MessageBoxIcon.Error);
             }
            }
        

        }
    }
}
