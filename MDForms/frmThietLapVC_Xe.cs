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
    public partial class frmThietLapVC_Xe : Form
    {
        public int OK = 0;
        long IDXe=0;
        int St=0;
        public frmThietLapVC_Xe()
        {
            InitializeComponent();
        }
        public frmThietLapVC_Xe(string SoXe,string HDVC,string ThongTin,string ThongBao,string Ngay,long XeID,int Status)
        {
            InitializeComponent();
            lblSoXe.Text = SoXe;
            lblHDVC.Text = HDVC;
            lblThongtin.Text = ThongTin;
            lblThongbao.Text = ThongBao;

            if (string.IsNullOrEmpty(Ngay))
            {

                dtNgay.Value = DateTime.Now;
            }
            else {
                dtNgay.Value = DateTime.Parse(Ngay.ToString());
            }
            IDXe=XeID;
            St=Status;
        }
       
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("Bạn chắc chắn thiết lập cho xe như đã chọn?", "DACASUCO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if(St==0)
                        {
                        string sql = "Update tbl_XeVanChuyen Set NKT='" + dtNgay.Value.ToString() + "' Where  ID=" + IDXe.ToString();
                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
                        }
                        else
                        {
                        string sql = "Update tbl_XeVanChuyen Set NKT=Null Where  ID=" + IDXe.ToString();
                        MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);  
                        }
                      
                        MessageBox.Show("Bạn đã thiết lập thành công!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Đã có lỗi xảy ra!", "DACASUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }
                OK = 1;
                this.Close();
            }
          
        
    }
}
