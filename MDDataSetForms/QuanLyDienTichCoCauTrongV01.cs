using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDDataSetForms
{
    public partial class QuanLyDienTichCoCauTrongV01 : Form
    {
        public QuanLyDienTichCoCauTrongV01()
        {
            InitializeComponent();
        }


        private void QuanLyDienTichCoCauTrongV01_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hopDongTrongMiaDataSet.tbl_HopDong' table. You can move, or remove it, as needed.
            //this.tbl_HopDongTableAdapter.Fill(this.hopDongTrongMiaDataSet.tbl_HopDong);

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.tbl_HopDongTableAdapter.FillByMaChuMia(this.hopDongTrongMiaDataSet.tbl_HopDong, textBoxChuMiaFilter.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void tbl_HopDongDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxChuMiaFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                case (char)Keys.Tab:
                    if (this.tbl_HopDongDataGridView.RowCount > 0) this.tbl_HopDongDataGridView.Focus();
                    break;
            }
        }
     

    }
}
