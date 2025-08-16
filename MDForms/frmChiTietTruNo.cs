using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace DACASUCO.MDForms
{
    public partial class frmChiTietTruNo : Form
    {
        long NhapTienTraNoID;
        bool LaNhapTienTraNo;
        public frmChiTietTruNo()
        {
            InitializeComponent();

        }

        // su dung ham tao cho nhap tien tra no
        public frmChiTietTruNo(long _IDTraNo)
        {
            InitializeComponent();
            NhapTienTraNoID = _IDTraNo;
            LaNhapTienTraNo = true;
            //LaNhapTienTraNo = _LaNhapTienTraNo;
        }

        // su dung ham tao cho thanh toan mia
        long HopDongID;
        long DotThanhToan;
        public frmChiTietTruNo(long _hopdongID, long _DotThanhToan)
        {
            InitializeComponent();
            //NhapTienTraNoID = _IDTraNo;
            HopDongID = _hopdongID;
            DotThanhToan = _DotThanhToan;
            LaNhapTienTraNo = false;
            //LaNhapTienTraNo = _LaNhapTienTraNo;
        }

        private void frmChiTietTruNo_Load(object sender, EventArgs e)
        {
            DataSet ds;
            if (LaNhapTienTraNo == true)
            {
                gridEX1.BoundMode = Janus.Windows.GridEX.BoundMode.Unbound;
                string sql = "sp_ChiTietTruNo_NhapTienTraNo " + MDSolution.DACASUCO_App.VuTrongID.ToString() + "," + NhapTienTraNoID.ToString();
                ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            }
            else
            {
                gridEX1.BoundMode = Janus.Windows.GridEX.BoundMode.Unbound;
                string sql = "sp_ChiTietTruNo_ThanhToanMia " + MDSolution.DACASUCO_App.VuTrongID.ToString() + "," + DotThanhToan.ToString() + "," + HopDongID.ToString();
                ds = MDSolutionEntities.DBModule.ExecuteQuery(sql, null, null);
            }

            int a = ds.Tables[0].Rows.Count;
            double[] obj = new double[a];
            int i = 0;
            DataTable dt = new DataTable();
            DataRow drr = dt.NewRow();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                gridEX1.Tables[0].Columns.Add(dr["LoaiTien"].ToString());
                gridEX1.Tables[0].Columns[dr["LoaiTien"].ToString()].DataMember = dr["LoaiTien"].ToString();

                dt.Columns.Add(dr["LoaiTien"].ToString());
                obj[i] = new double();
                obj[i] = double.Parse(dr["SoTien"].ToString());
                drr[i] = obj[i];
                i++;
            }
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    dt.Columns.Add(dr["LoaiTien"].ToString());
            //    obj[i] = new double();
            //    obj[i] = double.Parse(dr["SoTien"].ToString());
            //    i++;
            //    //gridEX1.Tables[0].Columns[dr["LoaiTien"].ToString()].DataMember;
            //}
            
            //i = 0;
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    drr[i] = obj[i];
            //    i++;
            //}
            gridEX1.BoundMode = Janus.Windows.GridEX.BoundMode.Bound;
            dt.Rows.Add(drr);
            
            gridEX1.DataSource = dt;
        }
    }
}