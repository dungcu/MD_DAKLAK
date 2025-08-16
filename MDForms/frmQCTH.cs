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
    public partial class frmQCTH : Form
    {
        long _MuaCCS = 0;
        decimal _KT=0;
        public frmQCTH()
        {
            InitializeComponent();
        }

        private void frmQCTH_Load(object sender, EventArgs e)
        {
            string sql = "Select * from tbl_CSTH";
            DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            DateTime NgayChot = DateTime.Now;
            long TrongTai = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    NgayChot = DateTime.Parse(ds.Tables[0].Rows[0]["NgayChot"].ToString());
                }
                catch
                {
                    NgayChot = DateTime.Now; ;
                }
                try
                {
                    TrongTai = long.Parse(ds.Tables[0].Rows[0]["TrongTai"].ToString());
                }
                catch
                {
                   TrongTai = 0;
                }
            }
            dtNgayChot.Value = NgayChot;
            nTrongTai.Value = TrongTai;
            Timer tmr = new Timer();
            tmr.Interval = 500;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
            lblStatus.ForeColor = Color.Red;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn chắc chắn thiết lập các tham số Thu hoạch - Vận chuyển như đã chọn lựa?","DACASUCO",  MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
            try
            {
                MDSolutionEntities.DBModule.ExecuteQuery("Update tbl_CSTH set NgayChot='" + dtNgayChot.Value.ToString("yyyy-MM-dd") + "',TrongTai=" + nTrongTai.Value.ToString(), null, null);
                MessageBox.Show("Đã thiết lập thành công!","DACASUCO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
                catch
            {
                     MessageBox.Show("Đã có lỗi xảy ra!","DACASUCO",MessageBoxButtons.OK,MessageBoxIcon.Error);
             }
            }
        

        }

        void tmr_Tick(object sender, EventArgs e)
        {
            if (lblStatus.ForeColor == Color.Red)
            {
                lblStatus.ForeColor = Color.Green;
            }
            else if (lblStatus.ForeColor == Color.Green)
            {
                lblStatus.ForeColor = Color.Red;
            }
        }
    }
}
