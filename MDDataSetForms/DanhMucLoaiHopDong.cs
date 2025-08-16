using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;
using DACASUCO.MDDataSetForms;
 

namespace DACASUCO.MDDataSetForms
{
    public partial class DanhMucLoaiHopDong : Form
    {
        public DanhMucLoaiHopDong()
        {
            InitializeComponent();
        }

      

        private void DanhMucLoaiHopDong_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hopDongTrongMiaDataSet.LoaiHopDong' table. You can move, or remove it, as needed.
            this.loaiHopDongTableAdapter.Fill(this.hopDongTrongMiaDataSet.LoaiHopDong);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
            this.Validate();
            this.loaiHopDongBindingSource.EndEdit();
            this.loaiHopDongTableAdapter.Update(this.hopDongTrongMiaDataSet.LoaiHopDong);
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
             }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

       
    }
}
