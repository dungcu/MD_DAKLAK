using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution
{
    public partial class frm_DatNgayMia : Form
    {
        public frm_DatNgayMia()
        {
            InitializeComponent();
            dt_NgayMia.Text = DateTime.Now.ToShortDateString();
        }

        private void cmd_TaoMoi_Click(object sender, EventArgs e)
        {
            string strSQL = "Select max(NgayMia) From tbl_NgayMia";
            DataSet ds = null;
            DateTime ngay1, ngay2;
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    ngay1 = DateTime.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    ngay1 = DateTime.Now.Date.AddDays(-1);
                }
                ngay2 = (dt_NgayMia.Value);
                if (ngay2 <= ngay1)
                {
                    MessageBox.Show("Ngày này đã được thiết lập rồi. Mời chọn ngày khác!");
                }
                else
                {
                    strSQL = "Insert into tbl_NgayMia(NgayMia,MaCan) Values('" + (dt_NgayMia.Value.ToString("MM/dd/yyyy HH:mm:ss")) + "',0)";
                    
                    DBModule.ExecuteNonQuery(strSQL, null, null);
                    MessageBox.Show("Đã thiết lập thành công ngày nhập mía!");
                }
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_DatNgayMia_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmXemNgayCan frm = new frmXemNgayCan();
            frm.ShowDialog(); ;
        }
    }
}