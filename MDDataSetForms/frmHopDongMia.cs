using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace DACASUCO.MDDataSetForms
{
    public partial class frmHopDongMia : Form
    {
        private int iHopDongID=-1;
        public frmHopDongMia()
        {
            InitializeComponent();
        }

        private void frmHopDongMia_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hopDongTrongMiaDataSet1.TreeHopDong' table. You can move, or remove it, as needed.
            this.treeHopDongTableAdapter.Fill(this.hopDongTrongMiaDataSet1.TreeHopDong);            
        }
        private void DoSelected_HopDong(int iHopDongID)
        {  
            try
            {
                if (int.TryParse(treeHopDongGridEX.GetValue("ID").ToString(), out iHopDongID))
                {
                    uiPanelHopDongWork.Enabled = true;
                    uiPanelHopDongWork.Text = treeHopDongGridEX.GetValue("Ma").ToString() + " - " + treeHopDongGridEX.GetValue("HoTen").ToString();
                    //Load_Rig();
                }
                else
                {
                    uiPanelHopDongWork.Enabled = false;
                }
            }
            catch
            {
                uiPanelHopDongWork.Enabled = false;
            }
        }

        private void treeHopDongGridEX_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}