using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms
{
    public partial class Frm_ChonHDChinh : Form
    {
        public Frm_ChonHDChinh()
        {
            InitializeComponent();
        }
        public long HDChinhID=0;
        public string HDChinhMa="";
        public string HDChinhHoTen = "";
        private void LoadccbXa()
        {
            try
            {
                DataSet ds;
                clsXa.GetList("",out ds, null, null);
                if (ds.Tables.Count > 0)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr[0] = -1;
                    dr[1] = "-- Tất cả --";
                    ds.Tables[0].Rows.InsertAt(dr,0);
                    this.cbXa.DataSource = ds.Tables[0];
                    this.cbXa.ValueMember = "ID";
                    this.cbXa.DisplayMember = "Ten";
                    
                }
//                this.cbXa.Items.Insert(0, new object[] { -1, "-- Tất cả --" });
                this.cbXa.SelectedIndex = 0;
                //this.cbXa.SelectedIndexChanged += new System.EventHandler(this.cbXa_SelectedIndexChanged);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void LoadccbThon()
        {
            try
            {
                DataSet ds;
                ds = clsThon.GetListbyWhere("ID, Ten", " XaID =" + cbXa.SelectedValue.ToString(), "", null, null);
                if (ds.Tables.Count > 0)
                {


                    //ds.Tables[0].Rows.InsertAt(new object[] { -1, "-- Tất cả --" },0);
                    DataRow dr = ds.Tables[0].NewRow();
                    dr[0] = -1;
                    dr[1] = "-- Tất cả --";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    this.cbThon.DataSource = ds.Tables[0];
                    cbThon.ValueMember = "ID";
                    cbThon.DisplayMember = "Ten";
                   

                }
                //this.cbThon.Items.Insert(0, new object[] { -1, "-- Tất cả --" });
                this.cbThon.SelectedIndex = 0;
                //string a = cbThon.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        public void Load_GV()
        {
            try
            {
                string thonid = "-1";
                string strSQL;
                DataSet ds;
                if (cbThon.SelectedValue != null) thonid = cbThon.SelectedValue.ToString();
                if (thonid == "-1")
                {
                    strSQL = "SELECT * FROM cung_HopDong_DienTich Where XaID= " + cbXa.SelectedValue.ToString() + " AND VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
                }
                else
                {
                    strSQL = "SELECT * FROM cung_HopDong_DienTich Where ThonID= " + thonid + " AND VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
                }
                ds = DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables.Count > 0)
                {
                    this.gridEX1.SetDataBinding(ds.Tables[0], "");

                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbThon_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load_GV();
        }

        private void cbXa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadccbThon();
        }

        private void Frm_ChonHDChinh_Load(object sender, EventArgs e)
        {
            LoadccbXa();

        }

        private void uiButtonXem_Click(object sender, EventArgs e)
        {
            string sql = "select ID,MaHopDong,HoTen,SoCMT from tbl_Hopdong where parentID=0 ";

            if (editBoxMaHD.Text.Trim() == "" && editBoxTenChuHD.Text.Trim() == "")
            {

                if (cbThon.SelectedIndex != 0)
                {
                    sql += " AND ThonID =" + cbThon.SelectedValue.ToString();
                }
                else
                {
                    if (cbXa.SelectedIndex != 0)
                        sql += " AND ThonID in (select Thonid from tbl_xa where id=" + cbXa.SelectedValue.ToString() + ")";
                }
            }
            else
            {
                if (editBoxMaHD.Text.Trim()!= "")
                    sql += " AND MaHopDong like N'%"+editBoxMaHD.Text+"%'";
                if (editBoxTenChuHD.Text.Trim() != "")
                    sql += " AND HoTen like N'%" + editBoxTenChuHD.Text + "%'";
            }
            try
            {
                DataSet ds = new DataSet();
                ds = DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    gridEX1.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả theo điều kiện thiết lập", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridEX1.DataSource = null;
                }
            }
            catch 
            {
                MessageBox.Show("Không tìm thấy kết quả theo điều kiện thiết lập", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridEX1.DataSource = null;
            }
        }

        private void uiButtonGhiNhan_Click(object sender, EventArgs e)
        {
            try
            {
                HDChinhID = long.Parse(gridEX1.GetValue("ID").ToString());
                HDChinhMa = gridEX1.GetValue("MaHopDong").ToString();
                HDChinhHoTen = gridEX1.GetValue("HoTen").ToString();
                Close();
            }
            catch 
            {
                MessageBox.Show("Bạn chưa chọn HĐ chính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void uiButtonHuyBo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridEX1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                HDChinhID = long.Parse(gridEX1.GetValue("ID").ToString());
                Close();
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn HĐ chính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

}