using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using Janus.Windows.GridEX;

namespace MDSolution
{
    public partial class frmKhaiBaoXaVanChuyen : Form
    {
        private NodeDonVi nDonVi = new NodeDonVi();      
        private DataSet dsgdVXaSource;

        //string TenDonVi;
        string IDDonVi;

        public frmKhaiBaoXaVanChuyen()
        {
            InitializeComponent();            
            CommonClass.LoadTreeTram(tvDonVi);            
        }

        public frmKhaiBaoXaVanChuyen(string _IDDonviVC,string _TenDVVC)
        {
            InitializeComponent();
            CommonClass.LoadTreeTram(tvDonVi);
            IDDonVi = _IDDonviVC;
            //TenDonVi = _TenDVVC;
            this.Text += _TenDVVC;
        }

        private void frmDanhMucDonVi_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;            
        }
      
        private void tvDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nDonVi = (NodeDonVi)tvDonVi.SelectedNode.Tag;
                this.LoadgdVXa();
            }
        }
        private void tvDonVi_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nDonVi = (NodeDonVi)e.Node.Tag;
            this.LoadgdVXa();
        }

        private void LoadgdVXa()
        {
            if (nDonVi.Type == DonviTypeHD.Cum)
            {
                //dsgdVXaSource = clsXa.GetListbyWhere("", " a.ID=" + nDonVi.DonViID, "", null, null);
                //dsgdVXaSource = clsXa.GetListbyWhere("", "", "", null, null);
                string strSQL = "Select a.*,b.Ten as Cum from tbl_Xa as a inner join tbl_Cum as b ON a.CumID = b.ID Where a.CumID=" + nDonVi.DonViID + " ORDER BY a.ID";
                dsgdVXaSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                if (dsgdVXaSource.Tables.Count > 0)
                {
                    this.gridEX1.SetDataBinding(dsgdVXaSource.Tables[0], "");
                }

                strSQL = "Select a.ID as ID from tbl_Xa as a inner join tbl_Cum as b ON a.CumID = b.ID Where a.CumID=" + nDonVi.DonViID + " AND HopDongVCID=" + IDDonVi + " ORDER BY a.ID";
                DataSet ds = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);

                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (GridEXRow Grx in gridEX1.GetRows())
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                if (Grx.Cells["ID"].Value.ToString() == dr["ID"].ToString())
                                {
                                    Grx.BeginEdit();
                                    Grx.Cells["Chek"].Value = true;
                                    Grx.EndEdit();
                                    break;
                                }
                                else
                                {
                                    Grx.BeginEdit();
                                    Grx.Cells["Chek"].Value = false;
                                    Grx.EndEdit();
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (GridEXRow Grx in gridEX1.GetRows())
                        {
                            Grx.BeginEdit();
                            Grx.Cells["Chek"].Value = false;
                            Grx.EndEdit();
                        }
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            else
            {
                //dsgdVXaSource = clsXa.GetListbyWhere("", "", "", null, null);
                //string strSQL = "Select * from tbl_Xa"; 
                //dsgdVXaSource = MDSolutionEntities.DBModule.ExecuteQuery(strSQL, null, null);
                //if (dsgdVXaSource.Tables.Count > 0)
                //{
                //    this.gdVXa.SetDataBinding(dsgdVXaSource.Tables[0], "");                    
                //}
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {               
                foreach (GridEXRow Gr in gridEX1.GetRows())
                {
                    if (Gr.Cells["Chek"].Value.ToString() == "True")
                    {
                        string strSQL = "Update tbl_Xa SET HopDongVCID =" + IDDonVi + " Where ID=" + Gr.Cells["ID"].Value.ToString();
                        MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null);                        
                    }
                    else
                    {
                        //string strSQL = "Update tbl_Xa SET HopDongVCID =null Where ID=" + Gr.Cells["ID"].Value.ToString();
                        //MDSolutionEntities.DBModule.ExecuteNonQuery(strSQL, null, null); 
                    }
                }
                MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch( Exception ex)
            {
                MessageBox.Show("Có lỗi khi lưu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chek_col_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridEXRow gr in gridEX1.GetRows())
            {
                gr.BeginEdit();
                gr.Cells["Chek"].Value = true;
                gr.EndEdit();
            }
        }
   
       
    }
}