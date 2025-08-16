using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace MDSolution.MDForms
{
    public partial class Export_DLTheoNgay : Form
    {
        public Export_DLTheoNgay()
        {
            InitializeComponent();
        }

        private void uiButtonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (calendarComboTuNgay.Value > calendarComboDenNgay.Value)
                {
                    MessageBox.Show("Bạn chọn sai ngày muốn xem");
                }
                else {
                    if (calendarComboTuNgay.Value == calendarComboDenNgay.Value)
                    {
                        LayDL("",calendarComboDenNgay.Value.ToString());
                    }
                    else {
                        LayDL(calendarComboTuNgay.Value.ToString(), calendarComboDenNgay.Value.ToString());
                       
                    }
                }
            }
            catch { }
        }
        private void LayDL(string tungay, string denngay)
        {
            string TenFile = "./Export/ExportTuNgay" + calendarComboTuNgay.Text + "_DenNgay" + calendarComboDenNgay.Text+"_Ngay(" +DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")+ ").sql";
            try
            {
                FileStream fs = new FileStream(TenFile, FileMode.Create);
                StreamWriter w = new StreamWriter(fs, Encoding.UTF8);
                if (tungay != "")
                {
                    string SQL = "";
                    //Lay dl tu bang hop dong
                    try
                    {                      
                        SQL = "Select * from tbl_HopDong_log Where Date_Modify >='" + calendarComboTuNgay.Value.ToString() + "' And Date_Modify<'" + calendarComboDenNgay.Value.AddDays(1).ToString() + "'";
                        DataSet ds = DBModule.ExecuteQuery(SQL, null, null);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                DateTime NgaySinh = DateTime.Now;
                                DateTime NgayCap = DateTime.Now;
                                DateTime NgayKy = DateTime.Now;
                                if (dr["NgaySinh"].ToString() != "")
                                {
                                    NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString());
                                }

                                if (dr["NgayCap"].ToString() != "")
                                {
                                    NgayCap = DateTime.Parse(dr["NgayCap"].ToString());
                                }

                                if (dr["NgayKyHopDong"].ToString() != "")
                                {
                                    NgayKy = DateTime.Parse(dr["NgayKyHopDong"].ToString());
                                }

                                if (dr["Action"].ToString() != "0")
                                {
                                    w.Write(" Update tbl_HopDong set MaHopDong=N'" + DBModule.RefineString(dr["MaHopDong"].ToString()) + "'," + "NgaySinh=" + DBModule.RefineDatetime(NgaySinh, true) + "," + "SoCMT=" + "N'" + DBModule.RefineString(dr["SoCMT"].ToString()) + "'" + "," + "NgayCap=" + DBModule.RefineDatetime(NgayCap, true) + "," + "NoiCap=" + "N'" + DBModule.RefineString(dr["NoiCap"].ToString()) + "'" + "," + "ThonID=" + dr["ThonID"].ToString() + "," + "NguoiThuaKe1Ten=" + "N'" + DBModule.RefineString(dr["NguoiThuaKe1Ten"].ToString()) + "'" + "," + "NguoiThuaKe1DiaChi=" + "N'" + DBModule.RefineString(dr["NguoiThuaKe1DiaChi"].ToString()) + "'" + "," + "NguoiThuaKe1CMT=" + "N'" + DBModule.RefineString(dr["NguoiThuaKe1CMT"].ToString()) + "'" + "," + "NguoiThuaKe2Ten=" + "N'" + DBModule.RefineString(dr["NguoiThuaKe2Ten"].ToString()) + "'" + "," + "NguoiThuaKe2DiaChi=" + "N'" + DBModule.RefineString(dr["NguoiThuaKe2DiaChi"].ToString()) + "'" + "," + "NguoiThuaKe2CMT=" + "N'" + DBModule.RefineString(dr["NguoiThuaKe2CMT"].ToString()) + "'" + "," + "TrangThai=" + dr["TrangThai"].ToString() + "," + "HoTen=" + "N'" + DBModule.RefineString(dr["HoTen"].ToString()) + "'" + "," + "NgayKyHopDong=" + DBModule.RefineDatetime(NgayKy, true) + ", DataModify = getdate() " + " Where ID = " + dr["ID"].ToString());
                                }
                                else
                                {
                                    w.Write(" Insert into tbl_HopDong" + "(ID,MaHopDong,NgaySinh,SoCMT,NgayCap,NoiCap,ThonID,NguoiThuaKe1Ten,NguoiThuaKe1DiaChi,NguoiThuaKe1CMT,NguoiThuaKe2Ten,NguoiThuaKe2DiaChi,NguoiThuaKe2CMT,TrangThai,HoTen,NgayKyHopDong,DateAdd) Values(" + dr["ID"].ToString() + "," + "N'" + DBModule.RefineString(dr["MaHopDong"].ToString()) + "'" + "," + DBModule.RefineDatetime(NgaySinh, true) + "," + "N'" + DBModule.RefineString(dr["SoCMT"].ToString()) + "'" + "," + DBModule.RefineDatetime(NgayCap, true) + "," + "N'" + DBModule.RefineString(dr["NoiCap"].ToString()) + "'" + "," + dr["ThonID"].ToString() + "," + "N'" + DBModule.RefineString(dr["NguoiThuaKe1Ten"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["NguoiThuaKe1DiaChi"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["NguoiThuaKe1CMT"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["NguoiThuaKe2Ten"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["NguoiThuaKe2DiaChi"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["NguoiThuaKe2CMT"].ToString()) + "'" + "," + dr["TrangThai"].ToString() + "," + "N'" + DBModule.RefineString(dr["HoTen"].ToString()) + "'" + "," + DBModule.RefineDatetime(NgayKy, true) + ",getdate())");
                                }
                            }

                        }
                    }
                    catch { MessageBox.Show("Đã có lỗi khi lấy dữ liệu ở bảng hợp đồng"); }
                    //lay dl tu bang dau tu
                    try
                    {
                        SQL = "Select * from tbl_DauTu_log Where Date_Modify >='" + calendarComboTuNgay.Value.ToString() + "' And Date_Modify<'" + calendarComboDenNgay.Value.AddDays(1).ToString() + "'";
                        DataSet ds1 = DBModule.ExecuteQuery(SQL, null, null);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds1.Tables[0].Rows)
                            {
                                DateTime NgayDauTu = DateTime.Now;
                                DateTime NgayTinhLai = DateTime.Now;
                                if (dr["NgayDauTu"].ToString() != "")
                                {
                                    NgayDauTu = DateTime.Parse(dr["NgayDauTu"].ToString());
                                }
                                if (dr["NgayBatDauTinhLai"].ToString() != "")
                                {
                                    NgayTinhLai = DateTime.Parse(dr["NgayBatDauTinhLai"].ToString());
                                }
                                if (dr["Action"].ToString() != "0")
                                {
                                    w.Write(" Update tbl_DauTu set " + "HopDongID=" + dr["HopDongID"].ToString() + "," + "DanhMucDauTuID=" + dr["DanhMucDauTuID"].ToString() + "," + "SoLuong=" + dr["SoLuong"].ToString() + "," + "DonGia=" + dr["DonGia"].ToString() + "," + "SoTien=" + dr["SoTien"].ToString() + "," + "LaiSuat=" + dr["LaiSuat"].ToString() + "," + "NgayDauTu=" + DBModule.RefineDatetime(NgayDauTu) + "," + "GhiChu=" + "N'" + DBModule.RefineString(dr["GhiChu"].ToString()) + "'" + "," + "DotDauTu=" + dr["DotDauTu"].ToString() + "," + "DuNo=" + dr["DuNo"].ToString() + "," + "NgayBatDauTinhLai=" + DBModule.RefineDatetime(NgayTinhLai) + "," + "DaThanhToan=" + "N'" + DBModule.RefineString(dr["DaThanhToan"].ToString()) + "'" + "," + "VuTrongID=" + dr["VuTrongID"].ToString() + "," + "VuTruoc=" + dr["VuTruoc"].ToString() + "," + "LaDuNoVuTruoc=" + dr["LaDuNoVuTruoc"].ToString() + "," + "QuanLyVaKhauHaoID=" + dr["QuanLyVaKhauHaoID"].ToString() + "," + "DonViCungUngVatTuID=" + dr["DonViCungUngVatTuID"].ToString() + ", ModifyBy = " + MDSolutionApp.User.ID.ToString() + ", DataModify = getdate() " + ", NoteModify = '" + DBModule.RefineString(dr["NoteModify"].ToString()) + "'" + " Where ID = " + dr["ID"].ToString());
                                }
                                else
                                {
                                    w.Write(" Insert into tbl_DauTu" + "(ID,HopDongID,DanhMucDauTuID,SoLuong,DonGia,SoTien,LaiSuat,NgayDauTu,GhiChu,DotDauTu,DuNo,NgayBatDauTinhLai,DaThanhToan,VuTrongID,VuTruoc,LaDuNoVuTruoc,QuanLyVaKhauHaoID,DonViCungUngVatTuID, CreatedBy, ModifyBy, DateAdd, DataModify, NoteModify) Values(" + dr["ID"].ToString() + "," + dr["HopDongID"].ToString() + "," + dr["DanhMucDauTuID"].ToString() + "," + dr["SoLuong"].ToString() + "," + dr["DonGia"].ToString() + "," + dr["SoTien"].ToString() + "," + dr["LaiSuat"].ToString() + "," + DBModule.RefineDatetime(NgayDauTu) + "," + "N'" + DBModule.RefineString(dr["GhiChu"].ToString()) + "'" + "," + dr["DotDauTu"].ToString() + "," + dr["DuNo"].ToString() + "," + DBModule.RefineDatetime(NgayTinhLai) + "," + "N'" + DBModule.RefineString(dr["DaThanhToan"].ToString()) + "'" + "," + dr["VuTrongID"].ToString() + "," + dr["VuTruoc"].ToString() + "," + dr["LaDuNoVuTruoc"].ToString() + "," + dr["QuanLyVaKhauHaoID"].ToString() + "," + dr["DonViCungUngVatTuID"].ToString() + ", " + MDSolutionApp.User.ID.ToString() + ", " + MDSolutionApp.User.ID.ToString() + ", getdate()" + ", getdate() " + ", N'" + DBModule.RefineString(dr["NoteModify"].ToString()) + "')");
                                }

                            }
                        }
                    }
                    catch { MessageBox.Show("Đã có lỗi khi lấy dữ liệu ở bảng đầu tư"); }
                    try
                    {
                        SQL = "Select * from tbl_ThuaRuong_log Where Date_Modify >='" + calendarComboTuNgay.Value.ToString() + "' And Date_Modify<'" + calendarComboDenNgay.Value.AddDays(1).ToString() + "'";
                        DataSet ds2 = DBModule.ExecuteQuery(SQL, null, null);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds2.Tables[0].Rows)
                            {
                                DateTime NgayTrong = DateTime.Now;
                                DateTime NgayThuHoach = DateTime.Now;
                                if (dr["NgayTrong"].ToString() != "")
                                {
                                    NgayTrong = DateTime.Parse(dr["NgayTrong"].ToString());
                                }
                                if (dr["NgayThuHoachDuKien"].ToString() != "")
                                {
                                    NgayThuHoach = DateTime.Parse(dr["NgayThuHoachDuKien"].ToString());
                                }
                                if (dr["Action"].ToString() != "0")
                                {
                                    w.Write(" Update tbl_ThuaRuong set " + "SoBanDieuTra=" + "N'" + DBModule.RefineString(dr["SoBanDieuTra"].ToString()) + "'" + "," + "MaThuaRuong=" + "N'" + DBModule.RefineString(dr["MaThuaRuong"].ToString()) + "'" + "," + "HopDongID=" + dr["HopDongID"].ToString() + "," + "ThonID=" + dr["ThonID"].ToString() + "," + "HienTrangGiaoThong=" + dr["HienTrangGiaoThong"].ToString() + "," + "DienTich=" + dr["DienTich"].ToString() + "," + "LoaiDatID=" + dr["LoaiDatID"].ToString() + "," + "TramNongVuID=" + dr["TramNongVuID"].ToString() + "," + "SoHieuKeUoc=" + "N'" + DBModule.RefineString(dr["SoHieuKeUoc"].ToString()) + "'" + "," + "XuDong=" + "N'" + DBModule.RefineString(dr["XuDong"].ToString()) + "'" + "," + "DuongVanChuyenID=" + dr["DuongVanChuyenID"].ToString() + "," + "RaiVuID=" + dr["RaiVuID"].ToString() + "," + "VuTrongID=" + dr["VuTrongID"].ToString() + "," + "GiongMiaID=" + dr["GiongMiaID"].ToString() + "," + "NgayTrong=" + DBModule.RefineDatetime(NgayTrong) + "," + "NgayThuHoachDuKien=" + DBModule.RefineDatetime(NgayThuHoach) + "," + "NangSuatDuKien=" + dr["NangSuatDuKien"].ToString() + "," + "SanLuongDuKien=" + dr["SanLuongDuKien"].ToString() + "," + "NangSuatDuKien1=" + dr["NangSuatDuKien1"].ToString() + "," + "SanLuongDuKien1=" + dr["SanLuongDuKien1"].ToString() + "," + "MucDichID=" + dr["MucDichID"].ToString() + "," + "PheCanhID=" + dr["PheCanhID"].ToString() + "," + "TrangThai=" + dr["TrangThai"].ToString() + "," + "TinhTrang=" + dr["TinhTrang"].ToString() + ", ModifyBy = " + MDSolutionApp.User.ID.ToString() + ", DataModify = getdate() " + ", NoteModify = '" + DBModule.RefineString(dr["NoteModify"].ToString()) + "'" + " Where ID = " + dr["ID"].ToString());
                                }
                                else
                                {
                                    w.Write(" Insert into tbl_ThuaRuong" + "(ID,SoBanDieuTra,MaThuaRuong,HopDongID,ThonID,HienTrangGiaoThong,DienTich,LoaiDatID,TramNongVuID,SoHieuKeUoc,XuDong,DuongVanChuyenID,RaiVuID,VuTrongID,GiongMiaID,NgayTrong,NgayThuHoachDuKien,NangSuatDuKien,SanLuongDuKien,NangSuatDuKien1,SanLuongDuKien1,MucDichID,PheCanhID,TrangThai,TinhTrang , CreatedBy, ModifyBy, DateAdd, DataModify, NoteModify) Values(" + dr["ID"].ToString() + "," + "N'" + DBModule.RefineString(dr["SoBanDieuTra"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["MaThuaRuong"].ToString()) + "'" + "," + dr["HopDongID"].ToString() + "," + dr["ThonID"].ToString() + "," + dr["HienTrangGiaoThong"].ToString() + "," + dr["DienTich"].ToString() + "," + dr["LoaiDatID"].ToString() + "," + dr["TramNongVuID"].ToString() + "," + "N'" + DBModule.RefineString(dr["SoHieuKeUoc"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["XuDong"].ToString()) + "'" + "," + dr["DuongVanChuyenID"].ToString() + "," + dr["RaiVuID"].ToString() + "," + dr["VuTrongID"].ToString() + "," + dr["GiongMiaID"].ToString() + "," + DBModule.RefineDatetime(NgayTrong) + "," + DBModule.RefineDatetime(NgayThuHoach) + "," + dr["NangSuatDuKien"].ToString() + "," + dr["SanLuongDuKien"].ToString() + "," + dr["NangSuatDuKien1"].ToString() + "," + dr["SanLuongDuKien1"].ToString() + "," + dr["MucDichID"].ToString() + "," + dr["PheCanhID"].ToString() + "," + dr["TrangThai"].ToString() + "," + dr["TinhTrang"].ToString() + ", " + MDSolutionApp.User.ID.ToString() + ", " + MDSolutionApp.User.ID.ToString() + ", getdate()" + ", getdate() " + ", N'" + DBModule.RefineString(dr["NoteModify"].ToString()) + "')");
                                }

                            }
                        }
                    }
                    catch { MessageBox.Show("Đã có lỗi khi lấy dữ liệu ở bảng thửa ruộng"); }
                    //Lay tu bang nhap mia                   
                    try
                    {
                        SQL = "Select * from tbl_NhapMia_log Where Date_Modify >='" + calendarComboTuNgay.Value.ToString() + "' And Date_Modify<'" + calendarComboDenNgay.Value.AddDays(1).ToString() + "'";
                        DataSet ds3 = DBModule.ExecuteQuery(SQL, null, null);
                        if (ds3.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds3.Tables[0].Rows)
                            {
                                DateTime NgayVanChuyen = DateTime.Now;
                                DateTime NgayRa = DateTime.Now;
                                if (dr["NgayVanChuyen"].ToString() != "")
                                {
                                    NgayVanChuyen = DateTime.Parse(dr["NgayVanChuyen"].ToString());
                                }
                                if (dr["NgayRa"].ToString() != "")
                                {
                                    NgayRa = DateTime.Parse(dr["NgayRa"].ToString());
                                }
                                if (dr["Action"].ToString() != "0")
                                {
                                    w.Write(" Update tbl_NhapMia set " + "XeID=" + dr["XeID"].ToString() + "," + "BaiTapKetID=" + dr["BaiTapKetID"].ToString() + "," + "HopDongID=" + dr["HopDongID"].ToString() + "," + "TongTrongLuong=" + dr["TongTrongLuong"].ToString() + "," + "TrongLuongXe=" + dr["TrongLuongXe"].ToString() + "," + "TyLeTapVat=" + dr["TyLeTapVat"].ToString() + "," + "TrongLuongTapVat=" + dr["TrongLuongTapVat"].ToString() + "," + "DonGiaMia=" + dr["DonGiaMia"].ToString() + "," + "NgayVanChuyen=" + DBModule.RefineDatetime(NgayVanChuyen) + "," + "HopDongVanChuyenID=" + dr["HopDongVanChuyenID"].ToString() + "," + "SoPhieuNhap=" + dr["SoPhieuNhap"].ToString() + " ," + "DaThanhToan=" + dr["DaThanhToan"].ToString() + "," + "VuTrongID=" + dr["VuTrongID"].ToString() + "," + "CaNhap=" + dr["CaNhap"].ToString() + "," + "KhoID=" + dr["KhoID"].ToString() + "," + "DaThanhToanVC=" + dr["DaThanhToanVC"].ToString() + "," + "GioNhap=" + "N'" + DBModule.RefineString(dr["GioNhap"].ToString()) + "'" + "," + "GioRa=" + "N'" + DBModule.RefineString(dr["GioRa"].ToString()) + "'" + "," + "NgayRa=" + DBModule.RefineDatetime(NgayRa) + "," + "ThuaRuongID=" + dr["ThuaRuongID"].ToString() + "," + "MaCanGhepID=" + dr["MaCanGhepID"].ToString() + "," + "DonGiaVanChuyen=" + dr["DonGiaVanChuyen"].ToString() + "," + "TienMia=" + dr["TienMia"].ToString() + "," + "TienVanChuyen=" + dr["TienVanChuyen"].ToString() + "," + "SoXe=N'" + DBModule.RefineString(dr["SoXe"].ToString()) + "'" + ",TiLeCanGhep=" + dr["TiLeCanGhep"].ToString() + ",MaHoTrongMiaID=" + dr["MaHoTrongMiaID"].ToString() + ",PhatHD=" + dr["PhatHD"].ToString() + "," + "LyDoPhayHD=N'" + DBModule.RefineString(dr["LyDoPhayHD"].ToString()) + "'" + ",PhatXeMia=" + dr["PhatXeMia"].ToString() + "," + "LyDoPhayXeMia=N'" + DBModule.RefineString(dr["LyDoPhayXeMia"].ToString()) + "'" + "," + "SoBanDieuTra=N'" + DBModule.RefineString(dr["SoBanDieuTra"].ToString()) + "'" + ",GiongMiaID=" + dr["GiongMiaID"].ToString() + " Where ID = " + dr["ID"].ToString());
                                }
                                else
                                {
                                    w.Write(" Insert into tbl_NhapMia" + "(ID,XeID,BaiTapKetID,HopDongID,TongTrongLuong,TrongLuongXe,TyLeTapVat,TrongLuongTapVat,DonGiaMia,NgayVanChuyen,HopDongVanChuyenID,SoPhieuNhap,DaThanhToan,VuTrongID,CaNhap,KhoID,DaThanhToanVC,GioNhap,GioRa,NgayRa,ThuaRuongID,MaCanGhepID,DonGiaVanChuyen,TienMia,TienVanChuyen,SoXe,TiLeCanGhep,MaHoTrongMiaID,PhatHD,LyDoPhatHD,PhatXeMia,LyDoPhatXeMia,SoBanDieuTra,GiongMiaID) Values(" + dr["ID"].ToString() + "," + dr["XeID"].ToString() + "," + dr["BaiTapKetID"].ToString() + "," + dr["HopDongID"].ToString() + "," + dr["TongTrongLuong"].ToString() + "," + dr["TrongLuongXe"].ToString() + "," + dr["TyLeTapVat"].ToString() + "," + dr["TrongLuongTapVat"].ToString() + "," + dr["DonGiaMia"].ToString() + "," + DBModule.RefineDatetime(NgayVanChuyen) + "," + dr["HopDongVanChuyenID"].ToString() + "," + dr["SoPhieuNhap"].ToString() + "," + dr["DaThanhToan"].ToString() + "," + dr["VuTrongID"].ToString() + "," + dr["CaNhap"].ToString() + "," + dr["KhoID"].ToString() + "," + dr["DaThanhToanVC"].ToString() + "," + "N'" + DBModule.RefineString(dr["GioNhap"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["GioRa"].ToString()) + "'" + "," + DBModule.RefineDatetime(NgayRa) + "," + dr["ThuaRuongID"].ToString() + "," + dr["MaCanGhepID"].ToString() + "," + dr["DonGiaVanChuyen"].ToString() + "," + dr["TienMia"].ToString() + "," + dr["TienVanChuyen"].ToString() + "," + "N'" + DBModule.RefineString(dr["SoXe"].ToString()) + "'" + "," + dr["TiLeCanGhep"].ToString() + "," + dr["MaHoTrongMiaID"].ToString() + "," + dr["PhatHD"].ToString() + "," + "N'" + DBModule.RefineString(dr["LyDoPhayHD"].ToString()) + "'" + "," + dr["PhatXeMia"].ToString() + "," + "N'" + DBModule.RefineString(dr["LyDoPhayXeMia"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["SoBanDieuTra"].ToString()) + "'" + "," + dr["GiongMiaID"].ToString() + ")");
                                }

                            }
                        }
                    }
                    catch { MessageBox.Show("Đã có lỗi khi lấy dữ liệu ở bảng nhập mía"); }
                }
                else {
                    string SQL = "";
                    //Lay dl tu bang hop dong
                    try
                    {                       
                        SQL = "Select * from tbl_HopDong_log Where Date_Modify >='"+calendarComboDenNgay.Value.ToString()+"' And Date_Modify<'"+calendarComboDenNgay.Value.AddDays(1).ToString()+"'";
                        DataSet ds = DBModule.ExecuteQuery(SQL, null, null);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                DateTime NgaySinh = DateTime.Now;
                                DateTime NgayCap = DateTime.Now;
                                DateTime NgayKy = DateTime.Now;
                                if (dr["NgaySinh"].ToString() != "")
                                {
                                    NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString());
                                }
                               
                                if (dr["NgayCap"].ToString() != "")
                                {
                                    NgayCap = DateTime.Parse(dr["NgayCap"].ToString());
                                }
                                
                                if (dr["NgayKyHopDong"].ToString() != "")
                                {
                                    NgayKy = DateTime.Parse(dr["NgayKyHopDong"].ToString());
                                }
                                
                                if (dr["Action"].ToString() != "0")
                                {
                                    w.Write(" Update tbl_HopDong set MaHopDong=N'" + DBModule.RefineString(dr["MaHopDong"].ToString()) + "'," + "NgaySinh=" + DBModule.RefineDatetime(NgaySinh, true) + "," + "SoCMT=" + "N'" + DBModule.RefineString(dr["SoCMT"].ToString()) + "'" + "," + "NgayCap=" + DBModule.RefineDatetime(NgayCap, true) + "," + "NoiCap=" + "N'" + DBModule.RefineString(dr["NoiCap"].ToString()) + "'" + "," + "ThonID=" + dr["ThonID"].ToString() + "," + "NguoiThuaKe1Ten=" + "N'" + DBModule.RefineString(dr["NguoiThuaKe1Ten"].ToString()) + "'" + "," + "NguoiThuaKe1DiaChi=" + "N'" + DBModule.RefineString(dr["NguoiThuaKe1DiaChi"].ToString()) + "'" + "," + "NguoiThuaKe1CMT=" + "N'" + DBModule.RefineString(dr["NguoiThuaKe1CMT"].ToString()) + "'" + "," + "NguoiThuaKe2Ten=" + "N'" + DBModule.RefineString(dr["NguoiThuaKe2Ten"].ToString()) + "'" + "," + "NguoiThuaKe2DiaChi=" + "N'" + DBModule.RefineString(dr["NguoiThuaKe2DiaChi"].ToString()) + "'" + "," + "NguoiThuaKe2CMT=" + "N'" + DBModule.RefineString(dr["NguoiThuaKe2CMT"].ToString()) + "'" + "," + "TrangThai=" + dr["TrangThai"].ToString() + "," + "HoTen=" + "N'" + DBModule.RefineString(dr["HoTen"].ToString()) + "'" + "," + "NgayKyHopDong=" + DBModule.RefineDatetime(NgayKy, true) + ", DataModify = getdate() " + " Where ID = " + dr["ID"].ToString());
                                }
                                else
                                {                                    
                                    w.Write(" Insert into tbl_HopDong" + "(ID,MaHopDong,NgaySinh,SoCMT,NgayCap,NoiCap,ThonID,NguoiThuaKe1Ten,NguoiThuaKe1DiaChi,NguoiThuaKe1CMT,NguoiThuaKe2Ten,NguoiThuaKe2DiaChi,NguoiThuaKe2CMT,TrangThai,HoTen,NgayKyHopDong,DateAdd) Values(" + dr["ID"].ToString() + "," + "N'" + DBModule.RefineString(dr["MaHopDong"].ToString()) + "'" + "," + DBModule.RefineDatetime(NgaySinh, true) + "," + "N'" + DBModule.RefineString(dr["SoCMT"].ToString()) + "'" + "," + DBModule.RefineDatetime(NgayCap, true) + "," + "N'" + DBModule.RefineString(dr["NoiCap"].ToString()) + "'" + "," + dr["ThonID"].ToString() + "," + "N'" + DBModule.RefineString(dr["NguoiThuaKe1Ten"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["NguoiThuaKe1DiaChi"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["NguoiThuaKe1CMT"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["NguoiThuaKe2Ten"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["NguoiThuaKe2DiaChi"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["NguoiThuaKe2CMT"].ToString()) + "'" + "," + dr["TrangThai"].ToString() + "," + "N'" + DBModule.RefineString(dr["HoTen"].ToString()) + "'" + "," + DBModule.RefineDatetime(NgayKy, true) + ",getdate())");
                                }
                            }

                        }
                    }
                    catch { MessageBox.Show("Đã có lỗi khi lấy dữ liệu ở bảng hợp đồng"); }
                    //lay dl tu bang dau tu
                    try {
                        SQL = "Select * from tbl_DauTu_log Where Date_Modify >='" + calendarComboDenNgay.Value.ToString() + "' And Date_Modify<'" + calendarComboDenNgay.Value.AddDays(1).ToString() + "'";
                         DataSet ds1 = DBModule.ExecuteQuery(SQL, null, null);
                         if (ds1.Tables[0].Rows.Count > 0)
                         {
                             foreach (DataRow dr in ds1.Tables[0].Rows)
                             {
                                 DateTime NgayDauTu = DateTime.Now;
                                 DateTime NgayTinhLai = DateTime.Now;
                                 if (dr["NgayDauTu"].ToString() != "")
                                 {
                                     NgayDauTu = DateTime.Parse(dr["NgayDauTu"].ToString());
                                 }
                                 if (dr["NgayBatDauTinhLai"].ToString() != "")
                                 {
                                     NgayTinhLai = DateTime.Parse(dr["NgayBatDauTinhLai"].ToString());
                                 }
                                 if (dr["Action"].ToString() != "0")
                                 {
                                     w.Write(" Update tbl_DauTu set " +"HopDongID=" + dr["HopDongID"].ToString() + "," + "DanhMucDauTuID=" + dr["DanhMucDauTuID"].ToString() + "," + "SoLuong=" + dr["SoLuong"].ToString() + "," + "DonGia=" + dr["DonGia"].ToString() + "," + "SoTien=" + dr["SoTien"].ToString() + "," + "LaiSuat=" + dr["LaiSuat"].ToString() + "," + "NgayDauTu=" + DBModule.RefineDatetime(NgayDauTu) + "," + "GhiChu=" + "N'" + DBModule.RefineString(dr["GhiChu"].ToString()) + "'" + "," + "DotDauTu=" + dr["DotDauTu"].ToString() + "," + "DuNo=" + dr["DuNo"].ToString() + "," + "NgayBatDauTinhLai=" + DBModule.RefineDatetime(NgayTinhLai) + "," + "DaThanhToan=" + "N'" + DBModule.RefineString(dr["DaThanhToan"].ToString()) + "'" + "," + "VuTrongID=" + dr["VuTrongID"].ToString() + "," + "VuTruoc=" + dr["VuTruoc"].ToString() + "," + "LaDuNoVuTruoc=" + dr["LaDuNoVuTruoc"].ToString() + "," + "QuanLyVaKhauHaoID=" + dr["QuanLyVaKhauHaoID"].ToString() + "," + "DonViCungUngVatTuID=" + dr["DonViCungUngVatTuID"].ToString() +", ModifyBy = " + MDSolutionApp.User.ID.ToString() +", DataModify = getdate() " +", NoteModify = '" + DBModule.RefineString(dr["NoteModify"].ToString()) +"'"+ " Where ID = " + dr["ID"].ToString());
                                 }
                                 else
                                 {
                                     w.Write(" Insert into tbl_DauTu" +"(ID,HopDongID,DanhMucDauTuID,SoLuong,DonGia,SoTien,LaiSuat,NgayDauTu,GhiChu,DotDauTu,DuNo,NgayBatDauTinhLai,DaThanhToan,VuTrongID,VuTruoc,LaDuNoVuTruoc,QuanLyVaKhauHaoID,DonViCungUngVatTuID, CreatedBy, ModifyBy, DateAdd, DataModify, NoteModify) Values(" +dr["ID"].ToString() + "," + dr["HopDongID"].ToString() + "," + dr["DanhMucDauTuID"].ToString() + "," + dr["SoLuong"].ToString() + "," + dr["DonGia"].ToString() + "," + dr["SoTien"].ToString() + "," + dr["LaiSuat"].ToString() + "," + DBModule.RefineDatetime(NgayDauTu) + "," + "N'" + DBModule.RefineString(dr["GhiChu"].ToString()) + "'" + "," + dr["DotDauTu"].ToString() + "," + dr["DuNo"].ToString() + "," + DBModule.RefineDatetime(NgayTinhLai) + "," + "N'" + DBModule.RefineString(dr["DaThanhToan"].ToString()) + "'" + "," + dr["VuTrongID"].ToString() + "," + dr["VuTruoc"].ToString() + "," + dr["LaDuNoVuTruoc"].ToString() + "," + dr["QuanLyVaKhauHaoID"].ToString() + "," + dr["DonViCungUngVatTuID"].ToString() + ", " + MDSolutionApp.User.ID.ToString() +", " + MDSolutionApp.User.ID.ToString() +", getdate()" +", getdate() " +", N'" + DBModule.RefineString(dr["NoteModify"].ToString()) + "')" );
                                 }

                             }
                         }
                    }
                    catch { MessageBox.Show("Đã có lỗi khi lấy dữ liệu ở bảng đầu tư"); }
                    //lay dl tu bang Thua ruong
                    try {
                        SQL = "Select * from tbl_ThuaRuong_log Where Date_Modify >='" + calendarComboDenNgay.Value.ToString() + "' And Date_Modify<'" + calendarComboDenNgay.Value.AddDays(1).ToString() + "'";
                        DataSet ds2 = DBModule.ExecuteQuery(SQL, null, null);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds2.Tables[0].Rows)
                            {
                                DateTime NgayTrong = DateTime.Now;
                                DateTime NgayThuHoach = DateTime.Now;
                                if (dr["NgayTrong"].ToString() != "")
                                {
                                    NgayTrong = DateTime.Parse(dr["NgayTrong"].ToString());
                                }
                                if (dr["NgayThuHoachDuKien"].ToString() != "")
                                {
                                    NgayThuHoach = DateTime.Parse(dr["NgayThuHoachDuKien"].ToString());
                                }
                                if (dr["Action"].ToString() != "0")
                                {
                                    w.Write(" Update tbl_ThuaRuong set " +"SoBanDieuTra=" + "N'" + DBModule.RefineString(dr["SoBanDieuTra"].ToString()) + "'" + "," + "MaThuaRuong=" + "N'" + DBModule.RefineString(dr["MaThuaRuong"].ToString()) + "'" + "," + "HopDongID=" + dr["HopDongID"].ToString() + "," + "ThonID=" + dr["ThonID"].ToString() + "," + "HienTrangGiaoThong=" + dr["HienTrangGiaoThong"].ToString() + "," + "DienTich=" + dr["DienTich"].ToString() + "," + "LoaiDatID=" + dr["LoaiDatID"].ToString() + "," + "TramNongVuID=" + dr["TramNongVuID"].ToString() + "," + "SoHieuKeUoc=" + "N'" + DBModule.RefineString(dr["SoHieuKeUoc"].ToString()) + "'" + "," + "XuDong=" + "N'" + DBModule.RefineString(dr["XuDong"].ToString()) + "'" + "," + "DuongVanChuyenID=" + dr["DuongVanChuyenID"].ToString() + "," + "RaiVuID=" + dr["RaiVuID"].ToString() + "," + "VuTrongID=" + dr["VuTrongID"].ToString() + "," + "GiongMiaID=" + dr["GiongMiaID"].ToString() + "," + "NgayTrong=" + DBModule.RefineDatetime(NgayTrong) + "," + "NgayThuHoachDuKien=" + DBModule.RefineDatetime(NgayThuHoach) + "," + "NangSuatDuKien=" + dr["NangSuatDuKien"].ToString() + "," + "SanLuongDuKien=" + dr["SanLuongDuKien"].ToString() + "," + "NangSuatDuKien1=" + dr["NangSuatDuKien1"].ToString() + "," + "SanLuongDuKien1=" + dr["SanLuongDuKien1"].ToString() + "," + "MucDichID=" + dr["MucDichID"].ToString() + "," + "PheCanhID=" + dr["PheCanhID"].ToString() + "," + "TrangThai=" + dr["TrangThai"].ToString() + "," + "TinhTrang=" + dr["TinhTrang"].ToString() +", ModifyBy = " + MDSolutionApp.User.ID.ToString() +", DataModify = getdate() " +", NoteModify = '" + DBModule.RefineString(dr["NoteModify"].ToString()) + "'" +" Where ID = " + dr["ID"].ToString());                                }
                                else
                                {
                                    w.Write(" Insert into tbl_ThuaRuong" +"(ID,SoBanDieuTra,MaThuaRuong,HopDongID,ThonID,HienTrangGiaoThong,DienTich,LoaiDatID,TramNongVuID,SoHieuKeUoc,XuDong,DuongVanChuyenID,RaiVuID,VuTrongID,GiongMiaID,NgayTrong,NgayThuHoachDuKien,NangSuatDuKien,SanLuongDuKien,NangSuatDuKien1,SanLuongDuKien1,MucDichID,PheCanhID,TrangThai,TinhTrang , CreatedBy, ModifyBy, DateAdd, DataModify, NoteModify) Values(" +dr["ID"].ToString() + "," + "N'" + DBModule.RefineString(dr["SoBanDieuTra"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["MaThuaRuong"].ToString()) + "'" + "," + dr["HopDongID"].ToString() + "," + dr["ThonID"].ToString() + "," + dr["HienTrangGiaoThong"].ToString() + "," + dr["DienTich"].ToString() + "," + dr["LoaiDatID"].ToString() + "," + dr["TramNongVuID"].ToString() + "," + "N'" + DBModule.RefineString(dr["SoHieuKeUoc"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["XuDong"].ToString()) + "'" + "," + dr["DuongVanChuyenID"].ToString() + "," + dr["RaiVuID"].ToString() + "," + dr["VuTrongID"].ToString() + "," + dr["GiongMiaID"].ToString() + "," + DBModule.RefineDatetime(NgayTrong) + "," + DBModule.RefineDatetime(NgayThuHoach) + "," + dr["NangSuatDuKien"].ToString() + "," + dr["SanLuongDuKien"].ToString() + "," + dr["NangSuatDuKien1"].ToString() + "," + dr["SanLuongDuKien1"].ToString() + "," + dr["MucDichID"].ToString() + "," + dr["PheCanhID"].ToString() + "," + dr["TrangThai"].ToString() + "," + dr["TinhTrang"].ToString() +", " + MDSolutionApp.User.ID.ToString() +", " + MDSolutionApp.User.ID.ToString() +", getdate()" +", getdate() " +", N'" + DBModule.RefineString(dr["NoteModify"].ToString()) + "')");
                                }

                            }
                        }
                    }
                    catch { MessageBox.Show("Đã có lỗi khi lấy dữ liệu ở bảng thửa ruộng"); }
                    //Lay tu bang nhap mia                   
                    try
                    {
                        SQL = "Select * from tbl_NhapMia_log Where Date_Modify >='" + calendarComboDenNgay.Value.ToString() + "' And Date_Modify<'" + calendarComboDenNgay.Value.AddDays(1).ToString() + "'";
                        DataSet ds3 = DBModule.ExecuteQuery(SQL, null, null);
                        if (ds3.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds3.Tables[0].Rows)
                            {
                                DateTime NgayVanChuyen = DateTime.Now;
                                DateTime NgayRa = DateTime.Now;
                                if (dr["NgayVanChuyen"].ToString() != "")
                                {
                                    NgayVanChuyen = DateTime.Parse(dr["NgayVanChuyen"].ToString());
                                }
                                if (dr["NgayRa"].ToString() != "")
                                {
                                    NgayRa = DateTime.Parse(dr["NgayRa"].ToString());
                                }
                                if (dr["Action"].ToString() != "0")
                                {
                                    w.Write(" Update tbl_NhapMia set " +"XeID=" + dr["XeID"].ToString() + "," + "BaiTapKetID=" + dr["BaiTapKetID"].ToString() + "," + "HopDongID=" + dr["HopDongID"].ToString() + "," + "TongTrongLuong=" + dr["TongTrongLuong"].ToString() + "," + "TrongLuongXe=" + dr["TrongLuongXe"].ToString() + "," + "TyLeTapVat=" + dr["TyLeTapVat"].ToString() + "," + "TrongLuongTapVat=" + dr["TrongLuongTapVat"].ToString() + "," + "DonGiaMia=" + dr["DonGiaMia"].ToString() + "," + "NgayVanChuyen=" + DBModule.RefineDatetime(NgayVanChuyen) + "," + "HopDongVanChuyenID=" + dr["HopDongVanChuyenID"].ToString() + "," + "SoPhieuNhap=" + dr["SoPhieuNhap"].ToString() + " ," + "DaThanhToan=" + dr["DaThanhToan"].ToString() + "," + "VuTrongID=" + dr["VuTrongID"].ToString() + "," + "CaNhap=" + dr["CaNhap"].ToString() + "," + "KhoID=" + dr["KhoID"].ToString() + "," + "DaThanhToanVC=" + dr["DaThanhToanVC"].ToString() + "," + "GioNhap=" + "N'" + DBModule.RefineString(dr["GioNhap"].ToString()) + "'" + "," + "GioRa=" + "N'" + DBModule.RefineString(dr["GioRa"].ToString()) + "'" + "," + "NgayRa=" + DBModule.RefineDatetime(NgayRa) + "," + "ThuaRuongID=" + dr["ThuaRuongID"].ToString() + "," + "MaCanGhepID=" + dr["MaCanGhepID"].ToString() + "," + "DonGiaVanChuyen=" + dr["DonGiaVanChuyen"].ToString() + "," + "TienMia=" + dr["TienMia"].ToString() + "," + "TienVanChuyen=" + dr["TienVanChuyen"].ToString() +"," + "SoXe=N'" + DBModule.RefineString(dr["SoXe"].ToString()) + "'" + ",TiLeCanGhep=" + dr["TiLeCanGhep"].ToString() + ",MaHoTrongMiaID=" + dr["MaHoTrongMiaID"].ToString() + ",PhatHD=" + dr["PhatHD"].ToString() + "," + "LyDoPhayHD=N'" + DBModule.RefineString(dr["LyDoPhayHD"].ToString()) + "'" + ",PhatXeMia=" + dr["PhatXeMia"].ToString() + "," + "LyDoPhayXeMia=N'" + DBModule.RefineString(dr["LyDoPhayXeMia"].ToString()) + "'" + "," + "SoBanDieuTra=N'" + DBModule.RefineString(dr["SoBanDieuTra"].ToString()) + "'" + ",GiongMiaID=" + dr["GiongMiaID"].ToString()+ " Where ID = " + dr["ID"].ToString());
                                }
                                else
                                {
                                    w.Write(" Insert into tbl_NhapMia" +"(ID,XeID,BaiTapKetID,HopDongID,TongTrongLuong,TrongLuongXe,TyLeTapVat,TrongLuongTapVat,DonGiaMia,NgayVanChuyen,HopDongVanChuyenID,SoPhieuNhap,DaThanhToan,VuTrongID,CaNhap,KhoID,DaThanhToanVC,GioNhap,GioRa,NgayRa,ThuaRuongID,MaCanGhepID,DonGiaVanChuyen,TienMia,TienVanChuyen,SoXe,TiLeCanGhep,MaHoTrongMiaID,PhatHD,LyDoPhatHD,PhatXeMia,LyDoPhatXeMia,SoBanDieuTra,GiongMiaID) Values(" +dr["ID"].ToString() + "," + dr["XeID"].ToString() + "," + dr["BaiTapKetID"].ToString() + "," + dr["HopDongID"].ToString() + "," + dr["TongTrongLuong"].ToString() + "," + dr["TrongLuongXe"].ToString() + "," + dr["TyLeTapVat"].ToString() + "," + dr["TrongLuongTapVat"].ToString() + "," + dr["DonGiaMia"].ToString() + "," + DBModule.RefineDatetime(NgayVanChuyen) + "," + dr["HopDongVanChuyenID"].ToString() + "," + dr["SoPhieuNhap"].ToString() + "," + dr["DaThanhToan"].ToString() + "," + dr["VuTrongID"].ToString() + "," + dr["CaNhap"].ToString() + "," + dr["KhoID"].ToString() + "," + dr["DaThanhToanVC"].ToString() + "," + "N'" + DBModule.RefineString(dr["GioNhap"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["GioRa"].ToString()) + "'" + "," + DBModule.RefineDatetime(NgayRa) + "," + dr["ThuaRuongID"].ToString() + "," + dr["MaCanGhepID"].ToString() + "," + dr["DonGiaVanChuyen"].ToString() + "," + dr["TienMia"].ToString() + "," + dr["TienVanChuyen"].ToString() + "," + "N'" + DBModule.RefineString(dr["SoXe"].ToString()) + "'" + "," + dr["TiLeCanGhep"].ToString() + "," + dr["MaHoTrongMiaID"].ToString() + "," + dr["PhatHD"].ToString() + "," + "N'" + DBModule.RefineString(dr["LyDoPhayHD"].ToString()) + "'" + "," + dr["PhatXeMia"].ToString() + "," + "N'" + DBModule.RefineString(dr["LyDoPhayXeMia"].ToString()) + "'" + "," + "N'" + DBModule.RefineString(dr["SoBanDieuTra"].ToString()) + "'" + "," + dr["GiongMiaID"].ToString() + ")");
                                }

                            }
                        }
                    }
                    catch { MessageBox.Show("Đã có lỗi khi lấy dữ liệu ở bảng nhập mía"); }
                
                }
                w.Flush();

                // Đóng file.
                w.Close();
                fs.Close();              
               
                
            }
            catch { }
        }
    }
}