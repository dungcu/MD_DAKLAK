using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDSolutionEntities;

namespace MDSolution
{
    public partial class frm_NhapTB_GiaVC : Form
    {
        static frm_NhapTB_GiaVC _frm_NhapTB_GiaVC;
        public int OK = 0;
        public long ID_TB = -1;
        public long ApDungTheoGioCan = 1;
        public long MaxID = -1;
        public long IDTinh = -1;
        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_NhapTB_GiaVC OneInstanceFrm
        {
            get
            {
                if (null == _frm_NhapTB_GiaVC || _frm_NhapTB_GiaVC.IsDisposed)
                {
                    _frm_NhapTB_GiaVC = new frm_NhapTB_GiaVC();
                }

                return _frm_NhapTB_GiaVC;
            }
        }
        public frm_NhapTB_GiaVC()
        {
            InitializeComponent();
        }
        public frm_NhapTB_GiaVC(long TinhID, string TenTinh)
        {
            InitializeComponent();
            IDTinh = TinhID;
            lblTitle.Text = "THIẾT LẬP THÔNG BÁO GIÁ TỈNH " + TenTinh.ToUpper();
        }

        public frm_NhapTB_GiaVC(long ID)
        {
            InitializeComponent();
            ID_TB = ID;
            cls_VanChuyen_ThongBao oGM = new cls_VanChuyen_ThongBao(ID_TB);
            oGM.Load(null, null);
            txtTenThongBao.Text = oGM.TenThongBao;
            dtNgay.Value = oGM.NgayApDung;
            dtHetNgay.Value = oGM.DenNgayApDung;            
            nGia.Value = oGM.TuGiaHoTro;
            nTapChat.Value = oGM.TuTapChat;           
            cmdOK.Text = "Lưu sửa";
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Load_Sua(long ID)
        {
            cls_VanChuyen_ThongBao oGM = new cls_VanChuyen_ThongBao(ID);
            oGM.Load(null, null);
            txtTenThongBao.Text = oGM.TenThongBao;
            dtNgay.Value = oGM.NgayApDung;
            dtHetNgay.Value = oGM.DenNgayApDung;
            nGia.Value = oGM.TuGiaHoTro;
            nTapChat.Value = oGM.TuTapChat;
            cmdOK.Text = "Lưu sửa";
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            OK = 1;
            if (ID_TB < 0)
            {
                try
                {
                    cls_VanChuyen_ThongBao oGM = new cls_VanChuyen_ThongBao();
                    oGM.TenThongBao = txtTenThongBao.Text;
                    oGM.NgayApDung = dtNgay.Value;
                    oGM.TuGiaHoTro = nGia.Value;
                    oGM.TuTapChat = nTapChat.Value;
                    oGM.DenNgayApDung = dtHetNgay.Value;                   
                    oGM.ApDungTheoGioCan = ApDungTheoGioCan;
                    oGM.TinhID = IDTinh;
                    oGM.Save(null, null);
                    MaxID = oGM.FindMaxID();
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra!", "SOSUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Close();
            }
            else
            {
                try
                {
                    cls_VanChuyen_ThongBao oGM = new cls_VanChuyen_ThongBao(ID_TB);
                    oGM.Load(null, null);
                    oGM.TenThongBao = txtTenThongBao.Text;
                    oGM.NgayApDung = dtNgay.Value;
                    oGM.TuGiaHoTro = nGia.Value;
                    oGM.TuTapChat = nTapChat.Value;
                    oGM.DenNgayApDung = dtHetNgay.Value;                    
                    oGM.ApDungTheoGioCan = ApDungTheoGioCan;
                    oGM.Save(null, null);
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra!", "SOSUCO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                gdvHoTroVanChuyen_LayoutLoad(null, null);
                this.Close();
            }

        }

        private void rdGioCan_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdGioCan.Checked)
            //{
            //    ApDungTheoGioCan = 1;
            //}
            //else
            //{
            //    ApDungTheoGioCan = 0;
            //}
        }

        private void rdGioDangTai_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdGioDangTai.Checked)
            //{
            //    ApDungTheoGioCan = 0;
            //}
            //else
            //{
            //    ApDungTheoGioCan = 1;
            //}
        }


        private void frm_NhapTB_GiaVC_Load(object sender, EventArgs e)
        {
            //if (SoSuCo_App.User.ID != 1)
            //{
            //    clsComFunctions.checkControlsPermission(this, this.Name.ToString());
            //}  
        }

        private void gdvHoTroVanChuyen_LayoutLoad(object sender, EventArgs e)
        {
            DataSet dsgia;
            string sql = "select * from tbl_VanChuyen_ThongBao where VuTrongID= " + DACASUCO_App.VuTrongID + " order by ID desc";
            dsgia = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            if (dsgia.Tables[0].Rows.Count > 0)
            {
                this.gdvHoTroVanChuyen.SetDataBinding(dsgia.Tables[0], "");
            }
            else
            {
                gdvHoTroVanChuyen.SetDataBinding(null, "");
            }
        }

        private void gdvHoTroVanChuyen_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            long ID = 0;
            try
            {
                ID = long.Parse(this.gdvHoTroVanChuyen.GetValue("ID").ToString());
            }
            catch
            {
                ID = 0;
            }
            if (ID > 0)
            {
                if (e.Column.Key == "Sua")
                {
                    string strIDmax = "Select Max(ID) from tbl_VanChuyen_ThongBao";
                    int IDMAX = int.Parse(DBModule.ExecuteQueryForOneResult(strIDmax, null, null));

                    if (ID == IDMAX)
                    {
                        Load_Sua(IDMAX);
                        ID_TB = IDMAX;
                    }
                    else
                    {
                        MessageBox.Show("Bạn không được sửa vì đã có thông báo mới hơn");

                    }
                }

            }
        }


    }
}
