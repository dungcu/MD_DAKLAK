using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MDSolutionEntities;

namespace DACASUCO.MDForms
{
    public partial class frmGhepMaCan : Form
    {
        public long MaCanGhep = 0; // Ma can ghep
        public string MaKhach = "";

        long MaCan = 0;
        double DonGia = 0;
        double TiLeTapVat = 0;
        public frmGhepMaCan()
        {
            InitializeComponent();
        }

       
        private void txtSoHopDong_TextChanged(object sender, EventArgs e)
        {
            if (txtSoHopDong.Text != "")
            {
                clsHopDong objHD = new clsHopDong();
                objHD.Load(txtSoHopDong.Text, null, null);
                if (objHD.ID > 0)
                {
                    txtHoTen.Text =  clsComFunctions.HoTen_Format(objHD.HoTen);
                    lblMaKH.Text = objHD.ID.ToString();
                }
                else
                {
                    txtHoTen.Text = "";
                    lblMaKH.Text = "";
                }

            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin chủ hợp đồng mía", "Lỗi nhập số liệu", MessageBoxButtons.OK);            
            }
            else
                if (!clsComFunctions.isNumber(txtKhoiLuong.Text.Trim()))
                {
                    MessageBox.Show("Khối lượng nhập phải là số", "Lỗi nhập số liệu", MessageBoxButtons.OK);
                }
                else
                {
                    clsNhapMia obj = new clsNhapMia(MaCanGhep);
                    obj.Load(null, null);

                    clsNhapMia objNhapMia = new clsNhapMia(MaCan);
                    objNhapMia.Load(null, null);

                    if ((frmGhepMaCan.TongCanGhep(MaCanGhep.ToString()) + long.Parse(txtKhoiLuong.Text) - objNhapMia.TongTrongLuong) > obj.TongTrongLuong)
                    {
                        MessageBox.Show("Khối lượng nhập ghép lớn hơn tổng khối lượng mã cân", "Lỗi nhập số liệu", MessageBoxButtons.OK);
                    }
                    else
                    {
                        objNhapMia.HopDongID = long.Parse(lblMaKH.Text);
                        objNhapMia.TrongLuongXe = 0;
                        objNhapMia.MaGhepCanID = MaCanGhep;
                        objNhapMia.TongTrongLuong = long.Parse(txtKhoiLuong.Text);
                        objNhapMia.NgayGioCan = DateTime.Now;
                        //objNhapMia.NgayGioCanVao = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                        //objNhapMia.NgayRa = DateTime.Now;
                        //objNhapMia.GioRa = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                        objNhapMia.GiaMia = (decimal)DonGia;
                        objNhapMia.Save(null, null);
                        MessageBox.Show("Đã cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
                        txtHoTen.Text = "";
                        txtKhoiLuong.Text = "";
                        txtSoHopDong.Text = "";
                        Load_dgList(MaCanGhep);
                    }
                }
        }

        private void frmGhepMaCan_Load(object sender, EventArgs e)
        {
            Load_dgList(MaCanGhep);
            clsNhapMia objNhapMia = new clsNhapMia(MaCanGhep);
            objNhapMia.Load(null, null);
            DonGia = (double)objNhapMia.GiaMia;
            TiLeTapVat = (double)objNhapMia.TyLeTapVat;
        }

        private void Load_dgList(long MaCanID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("MaKH");
            dt.Columns.Add("SoHD");
            dt.Columns.Add("HoTen");
            dt.Columns.Add("KhoiLuong");
            
            DataSet ds = null;
            ds = clsNhapMia.GetListbyWhere("ID,HopDongID,TongTrongLuong", "MaCanGhepID=" + MaCanID.ToString(),"",null,null );
            clsHopDong objHopDong = new clsHopDong();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string ID = dr[0].ToString();
                string MaKH = dr[1].ToString();
                string KhoiLuong = dr[2].ToString();
                objHopDong.ID = long.Parse(MaKH);
                objHopDong.Load(null, null);
                string HoTen = objHopDong.HoTen;
                string SoDH = objHopDong.MaHopDong;                

                string[] strValues = new string[] {ID, MaKH, SoDH, HoTen,KhoiLuong };
                dt.Rows.Add(strValues);
            }
            dgList.DataSource = dt;
                    
        }

        private void dgList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //txtHoTen.Text = dgList.Rows[dgList.CurrentCell.RowIndex].Cells["HoTen"].ToString();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void dgList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgList.CurrentCell.Value != null)
            {
                txtHoTen.Text = dgList.Rows[dgList.CurrentCell.RowIndex].Cells["HoTen"].Value.ToString();
                lblMaKH.Text = dgList.Rows[dgList.CurrentCell.RowIndex].Cells["MaKH"].Value.ToString();
                txtSoHopDong.Text = dgList.Rows[dgList.CurrentCell.RowIndex].Cells["SoHD"].Value.ToString();
                txtKhoiLuong.Text = dgList.Rows[dgList.CurrentCell.RowIndex].Cells["KhoiLuong"].Value.ToString();                
                MaCan = long.Parse(dgList.Rows[dgList.CurrentCell.RowIndex].Cells["ID"].Value.ToString());
            }
        }

        public static long TongCanGhep(string MaCan)
        {
            DataSet ds = null;
            ds = clsNhapMia.GetListbyWhere("sum(TongTrongLuong) as TongCanGhep ", "MaCanGhepID=" + MaCan.ToString(), "", null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    return long.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch { };

            }
            return 0;
        }

        public static long SoHDCanGhep(string MaCan)
        {
            DataSet ds = null;
            ds = clsNhapMia.GetListbyWhere("count(*) as SoHDCanGhep ", "MaCanGhepID=" + MaCan.ToString(), "", null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    return long.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch { };

            }
            return 0;
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {
            if (MaCan > 0)
            {
                clsNhapMia objNhapMia = new clsNhapMia(MaCan);
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    objNhapMia.Delete(null, null);
                    MaCan = 0;
                    Load_dgList(MaCanGhep);
                }
            }
        }
        private void Get_Khach_By_ID(string MaKhach)
        {
            if (MaKhach != "")
            {
                clsHopDong objHD = new clsHopDong(long.Parse(MaKhach));
                objHD.Load(null, null);
                if (objHD.ID > 0)
                {
                    lblMaKH.Text = objHD.ID.ToString();
                    txtHoTen.Text = clsComFunctions.HoTen_Format(objHD.HoTen);
                    txtSoHopDong.Text = objHD.MaHopDong;
                }
                else
                {
                    lblMaKH.Text = "";
                    txtHoTen.Text = "";
                    txtSoHopDong.Text = "";
                }
            }
        }
        private void cmdFindHopDong_Click(object sender, EventArgs e)
        {
            DACASUCO.MDDialoge.dlgHopDong dlg = new MDDialoge.dlgHopDong();
            dlg.passID = new MDDialoge.dlgHopDong.PassID(GetHopDongID);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                //MessageBox.Show("OK"+oHD.ID.ToString());
                Get_Khach_By_ID(MaKhach);
                dlg.Dispose();
            }
            else
            {
                //MessageBox.Show("Cancel" + oHD.ID.ToString());
                dlg.Dispose();
            }
        }
        public void GetHopDongID(string value)
        {
            MaKhach = value;
        }

        protected override void OnClosed(EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            base.OnClosed(e);
        }
 
    }
}