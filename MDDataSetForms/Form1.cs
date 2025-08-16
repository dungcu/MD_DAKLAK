using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace DACASUCO.MDDataSetForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tbl_HopDongBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbl_HopDongBindingSource.EndEdit();
            this.tbl_HopDongTableAdapter.Update(this.hopDongTrongMiaDataSet.tbl_HopDong);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hopDongTrongMiaDataSet.tbl_HopDong' table. You can move, or remove it, as needed.
            this.tbl_HopDongTableAdapter.Fill(this.hopDongTrongMiaDataSet.tbl_HopDong);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }
    }
}