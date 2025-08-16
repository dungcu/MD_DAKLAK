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
    public partial class frmAdd_Phieu : Form
    {

       public long ID = 0;
       public long OK = 0;
        public frmAdd_Phieu()
        {
            InitializeComponent();
        }
       public frmAdd_Phieu(string CM, string DT, string SLDK, string SPDT, string SLLK)
        {
            InitializeComponent(); 
           this.lblChumia.Text = CM.ToString();
            this.lblDT.Text=DT.ToString();
            this.lblSLDK.Text = SLDK.ToString();
            this.lblSLLK.Text = SLLK.ToString();
            this.lblSPDT.Text = SPDT;
        }
       
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn chắc chắn thêm "+nThem.Value+" phiếu cho thửa ruộng?","DACASUCO",  MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
            try
            {
                decimal PhieuThem = 0;
                try
                {
                    PhieuThem = int.Parse(MDSolutionEntities.DBModule.ExecuteQueryForOneResult("Select PhieuThem from tbl_ThuaRuong where ID=" + ID.ToString(), null, null));
                }
                catch
                {
                    PhieuThem = 0;
                }
                PhieuThem = PhieuThem + nThem.Value;
                MDSolutionEntities.DBModule.ExecuteQuery("Update tbl_ThuaRuong set PhieuThem="+PhieuThem.ToString()+"Where ID="+ID.ToString(),null,null);
                MessageBox.Show("Đã thêm phiếu thành công!","DACASUCO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                OK = 1;
                this.Close();
            }
                catch
            {
                     MessageBox.Show("Đã có lỗi xảy ra!","DACASUCO",MessageBoxButtons.OK,MessageBoxIcon.Error);
             }
            }
        

        }

        private void frmAdd_Phieu_Load(object sender, EventArgs e)
        {
            Timer tmr = new Timer();
            tmr.Interval = 500;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
            lblStatus.ForeColor = Color.Red;
            cmdOK.Enabled = false;
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

        private void nThem_ValueChanged(object sender, EventArgs e)
        {
            if (nThem.Value != 0)
            {
                cmdOK.Enabled = true;
            }
            else
            {
                cmdOK.Enabled = false;
            }
        }


      
    }
}
