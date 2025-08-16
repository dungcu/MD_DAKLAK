using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Windows.Forms;
using System.Collections;
using System.Drawing; 
using System.Collections.Generic;
using System.Text;
using MDSolutionEntities;
using DACASUCO.MDReport;

namespace MDSolution
{
    public class CommonClass
    {
        public static void loadTreeDonVi(System.Windows.Forms.TreeView tv)
        {            
            TreeNode node, node1, node2;
            node = tv.Nodes.Add("Root", "DACASUCO");
            NodeDonVi RootNode = new NodeDonVi("0", "DACASUCO", DonviTypeHD.Root);
            node.Tag = RootNode; 
            node.ExpandAll();
            DataSet ds, ds1;
            string strSQL = "Select * from tbl_Cum order by Ten";
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                node1 = node.Nodes.Add(dr["ID"].ToString(), dr["Ten"].ToString());
                node1.ImageIndex = 1;
                node1.SelectedImageIndex = 4;
                NodeDonVi nDonVi = new NodeDonVi(dr["ID"].ToString(), dr["Ten"].ToString(),DonviTypeHD.Cum);
                
                string strSQL1 = "Select * from tbl_Xa Where CumID=" + dr["ID"].ToString()+"Order by MaXa";
                ds1 = DBModule.ExecuteQuery(strSQL1, null, null);
                foreach (DataRow dr1 in ds1.Tables[0].Rows)
                {
                    node2 = node1.Nodes.Add(dr1["ID"].ToString(), dr1["Ten"].ToString());
                    node2.ImageIndex = 2;
                    node2.SelectedImageIndex = 5;
                    NodeDonVi nDonVi1 = new NodeDonVi(dr1["ID"].ToString(), dr1["Ten"].ToString(), DonviTypeHD.Xa);                    
                    node2.Tag = nDonVi1;                    
                }
                node1.Tag = nDonVi;
            }
        }
        public static void LoadTreeDV(System.Windows.Forms.TreeView tv)
        {
            TreeNode node, node1, node2;
            node = tv.Nodes.Add("Root", "DACASUCO");
            NodeDonVi RootNode = new NodeDonVi("0", "DACASUCO", DonviTypeHD.Root);
            node.Tag = RootNode;
            node.ExpandAll();
            DataSet ds, ds1;
            string strSQL = "Select * from tbl_Cum order by Ten";
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string nodeIDTram = dr["ID"].ToString();
                string nodeTenTram = dr["Ten"].ToString();
                node1 = node.Nodes.Add(nodeIDTram, nodeTenTram);
                node1.ImageIndex = 1;
                node1.SelectedImageIndex = 4;
                NodeDonVi nDonVi = new NodeDonVi(nodeIDTram, nodeTenTram, DonviTypeHD.Cum);

                string strSQL1 = "Select ID,TenBai from V_TreeDV Where CumID=" + nodeIDTram + " Order by TenBai";
                ds1 = DBModule.ExecuteQuery(strSQL1, null, null);
                foreach (DataRow dr1 in ds1.Tables[0].Rows)
                {
                    node2 = node1.Nodes.Add(dr1["ID"].ToString(), dr1["TenBai"].ToString());
                    node2.ImageIndex = 2;
                    node2.SelectedImageIndex = 5;
                    NodeDonVi nDonVi1 = new NodeDonVi(dr1["ID"].ToString(), dr1["TenBai"].ToString(), DonviTypeHD.Xa);
                    node2.Tag = nDonVi1;
                }
                node1.Tag = nDonVi;
            }
        }
        public static void loadTreeDonVi(System.Windows.Forms.TreeView tv,string UserID) // su dung de load tree view theo tram
        {
            string strSQL = "Select CumID From sys_Roles_User_Cum Where UserID=" + UserID;
            DataSet ds2 = DBModule.ExecuteQuery(strSQL, null, null);
            string CumID = "";
            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                        CumID += ds2.Tables[0].Rows[i]["CumID"].ToString();
                    else
                        CumID += "," + ds2.Tables[0].Rows[i]["CumID"].ToString();
                }
            }
            else
            {
                loadTreeDonVi(tv);
                return;
            }

            TreeNode node, node1, node2;
            node = tv.Nodes.Add("Root", "DACASUCO");
            NodeDonVi RootNode = new NodeDonVi("0", "DACASUCO", DonviTypeHD.Root);
            node.Tag = RootNode;
            node.ExpandAll();
            DataSet ds, ds1;            

            strSQL = "Select * from tbl_Cum Where ID in("+ CumID +") order by Ten";
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                node1 = node.Nodes.Add(dr["ID"].ToString(), dr["Ten"].ToString());
                node1.ImageIndex = 1;
                node1.SelectedImageIndex = 4;
                NodeDonVi nDonVi = new NodeDonVi(dr["ID"].ToString(), dr["Ten"].ToString(), DonviTypeHD.Cum);

                string strSQL1 = "Select * from tbl_Xa Where CumID=" + dr["ID"].ToString() + "Order by MaXa";
                ds1 = DBModule.ExecuteQuery(strSQL1, null, null);
                foreach (DataRow dr1 in ds1.Tables[0].Rows)
                {
                    node2 = node1.Nodes.Add(dr1["ID"].ToString(), dr1["Ten"].ToString());
                    node2.ImageIndex = 2;
                    node2.SelectedImageIndex = 5;
                    NodeDonVi nDonVi1 = new NodeDonVi(dr1["ID"].ToString(), dr1["Ten"].ToString(), DonviTypeHD.Xa);
                    node2.Tag = nDonVi1;
                }
                node1.Tag = nDonVi;
            }
        }
        public static void LoadTreeHangHoa(System.Windows.Forms.TreeView tv)
        {
            TreeNode node, node1;
            node = tv.Nodes.Add("Root", "Hàng Hóa");
            NodeHangHoa RootNode = new NodeHangHoa("0", "Hang Hoa", HangHoaType.Root);
            node.Tag = RootNode;
            node.ExpandAll();
            DataSet ds;
            string strSQL = "Select ID, LoaiHang from tbl_HangHoa order by ID";
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                node1 = node.Nodes.Add(dr["ID"].ToString(), dr["LoaiHang"].ToString());
                node1.ImageIndex = 0;
                node1.SelectedImageIndex = 4;
                NodeHangHoa nHD = new NodeHangHoa(dr["ID"].ToString(), dr["LoaiHang"].ToString(), HangHoaType.Hang);
                node1.Tag = nHD;
            }
        }

        public static void loadTreeHopDongVanChuyen(System.Windows.Forms.TreeView tv)
        {
            TreeNode node, node1;
            node = tv.Nodes.Add("Root", "DACASUCO");
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            NodeHopDongVanChuyen RootNode = new NodeHopDongVanChuyen("0", "DACASUCO", HDVCType.Root);
            node.Tag = RootNode;
            node.ExpandAll();
            DataSet ds;
            string strSQL = "Select ID, TenChuHopDong as Ten from tbl_HopDongVanChuyen where VuTrongID =" + DACASUCO_App.VuTrongID.ToString() +" order by TenChuHopDong";
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                node1 = node.Nodes.Add(dr["ID"].ToString(), dr["Ten"].ToString());
                node1.ImageIndex = 1;
                node1.SelectedImageIndex = 3;
                NodeHopDongVanChuyen nHD = new NodeHopDongVanChuyen(dr["ID"].ToString(), dr["Ten"].ToString(),HDVCType.HDVC);
                node1.Tag = nHD;
            }
        }
        public static void loadTreeNoiTamUngVatTu(System.Windows.Forms.TreeView tv)
        {
            //TreeNode node, node1;
            //node = tv.Nodes.Add("Root", "DACASUCO");
            //NodeNoiTamUngVatTu RootNode = new NodeNoiTamUngVatTu("0", "Đơn Vị");
            //node.Tag = RootNode;
            //node.ExpandAll();
            //DataSet ds;
            //string strSQL = "Select ID, Ten from tbl_NoiTamUngVatTu order by ID";
            //ds = DBModule.ExecuteQuery(strSQL, null, null);
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    node1 = node.Nodes.Add(dr["ID"].ToString(), dr["Ten"].ToString());
            //    node1.ImageIndex = 0;
            //    //node1.SelectedImageIndex = 4;
            //    NodeNoiTamUngVatTu nHD = new NodeNoiTamUngVatTu(dr["ID"].ToString(), dr["Ten"].ToString());
            //    node1.Tag = nHD;
            //}
        }
        //public static void LoadChildRen(System.Windows.Forms.TreeNode tn)
        //{
        //    if((tn!=null)&&(tn.Tag!=null))
        //    {
        //        NodeDonVi nDonVi = (NodeDonVi)tn.Tag;
        //        switch (nDonVi.Type)
        //        {
        //            case DonviTypeHD.Xa: CommonClass.LoadChildrenThon(tn, nDonVi);  break;;
        //            case DonviTypeHD.Thon: CommonClass.LoadChildrenHopDong(tn, nDonVi); break;
        //            default: break;
        //        }
        //        nDonVi.HasLoadChildren = true; 
        //        tn.Tag = nDonVi;
        //    } 
        //}
        public static void loadTreeXa(System.Windows.Forms.TreeView tv)
        {
            TreeNode node, node1;
            node = tv.Nodes.Add("Root", "DACASUCO");
            NodeDonVi RootNode = new NodeDonVi("0", "DACASUCO", DonviTypeHD.Root);
            node.Tag = RootNode;
            node.ExpandAll();
            DataSet ds ;
            string strSQL = "Select a.*,b.ThuTu from tbl_Xa as a LEFT JOIN tbl_Cum as b ON a.CumID = b.ID order by b.ThuTu, a.ID";
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                node1 = node.Nodes.Add(dr["ID"].ToString(), dr["Ten"].ToString());
                node1.ImageIndex = 1;
                node1.SelectedImageIndex = 4;
                NodeDonVi nDonVi = new NodeDonVi(dr["ID"].ToString(), dr["Ten"].ToString(), DonviTypeHD.Xa);                
                node1.Tag = nDonVi;
            }
        }

        public static void LoadTreeTram(System.Windows.Forms.TreeView treeView_)
        {
            TreeNode node, node1;
            node = treeView_.Nodes.Add("Root", "DACASUCO");
            NodeDonVi rootNode = new NodeDonVi("0", "DACASUCO", DonviTypeHD.Root);
            node.Tag = rootNode;

            string strSQL = "Select * from tbl_Cum Order By Ten";
            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                node1 = node.Nodes.Add(dr["ID"].ToString(), dr["Ten"].ToString());
                node1.ImageIndex = 1;
                node1.SelectedImageIndex = 4;
                NodeDonVi nDonvi = new NodeDonVi(dr["ID"].ToString(), dr["Ten"].ToString(), DonviTypeHD.Cum);
                node1.Tag = nDonvi;
            }
        }
        public static  void LoadChildrenHopDong(System.Windows.Forms.TreeNode tn)
        {
            TreeNode node2;
            NodeDonVi nDonVi = (NodeDonVi)tn.Tag;
            string strSQL1 = "Select ID, MaHopDong+' '+HoTen as Ten from tbl_HopDong Where ThonID=" + nDonVi.DonViID;
            DataSet ds1 = DBModule.ExecuteQuery(strSQL1, null, null);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                node2 = tn.Nodes.Add(dr1["ID"].ToString(), dr1["Ten"].ToString());
                node2.ImageIndex = 3;
                node2.SelectedImageIndex = 6;
                NodeDonVi nDonVi1 = new NodeDonVi(dr1["ID"].ToString(), dr1["Ten"].ToString(), DonviTypeHD.ChuHopDong);
                node2.Tag = nDonVi1;
            }
        }
        public static void LoadChildrenThon(System.Windows.Forms.TreeNode tn)
        {
            TreeNode node2;
            NodeDonVi nDonVi = (NodeDonVi)tn.Tag;
            string strSQL1 = "Select * from tbl_Thon Where XaID=" + nDonVi.DonViID;
            DataSet ds1 = DBModule.ExecuteQuery(strSQL1, null, null);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                node2 = tn.Nodes.Add(dr1["ID"].ToString(), dr1["Ten"].ToString());
                node2.ImageIndex = 2;
                node2.SelectedImageIndex = 5;
                NodeDonVi nDonVi1 = new NodeDonVi(dr1["ID"].ToString(), dr1["Ten"].ToString(), DonviTypeHD.Thon);                
                node2.Tag = nDonVi1;
            }             
        }
        public static void LoadChildrenXe(System.Windows.Forms.TreeNode tn)
        {
            TreeNode node2;            
            NodeHopDongVanChuyen nHDVC = (NodeHopDongVanChuyen)tn.Tag;
            string strSQL1 = "Select ID, SoXe+' - '+TenLaiXe as Ten from tbl_XeVanChuyen Where HopDongVanChuyenID=" + nHDVC.HopDongID;
            DataSet ds1 = DBModule.ExecuteQuery(strSQL1, null, null);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                node2 = tn.Nodes.Add(dr1["ID"].ToString(), dr1["Ten"].ToString());
                node2.ImageIndex = 2;
                node2.SelectedImageIndex = 4;
                NodeHopDongVanChuyen nHDVC1= new NodeHopDongVanChuyen(dr1["ID"].ToString(), dr1["Ten"].ToString(), HDVCType.XeVC);
                node2.Tag = nHDVC1;
            }
        }
        static public void ShowReport(string rptFileName, string rptTitle, string[] paraNames, object [] paraValues, Form frmParent)
        {

            Frm_ReportViewer frm = new Frm_ReportViewer();
            frm.bHasPara = true;
            frm.ParaNames = paraNames;
            frm.ParaValues = paraValues;
            frm.rptFileName = rptFileName;
            frm.rptTitle = rptTitle;
            
            if (frmParent != null)
            {
                frm.MdiParent = frmParent;
            }
            frm.Show();
        }
        static public void KhoiTaoReport(string rptFileName, string rptTitle, string[] paraNames, object[] paraValues, Form frmParent)
        {

            Frm_ReportViewer frm = new Frm_ReportViewer();
            frm.bHasPara = true;
            frm.ParaNames = paraNames;
            frm.ParaValues = paraValues;
            frm.rptFileName = rptFileName;
            frm.rptTitle = rptTitle;
            if (frmParent != null)
            {
                frm.MdiParent = frmParent;
            }
            frm.Show();
            frm.Close();
        }
        static public DataSet ExecuteSP(string spName, string[] spParaName, string[] spParaValue)
        {
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbConnection cn = new OleDbConnection(DBModule.strConnString);
            OleDbCommand myCom = new OleDbCommand(spName, cn);
            myCom.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < spParaName.Length; i++)
            {
                myCom.Parameters.Add(spParaName[i], spParaValue[i]);
            }

            da.SelectCommand = myCom;
            da.Fill(ds);
            cn.Close();
            cn = null;
            return ds;
        }
    }
}
