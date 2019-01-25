using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class GetBaoCaoHD
    {
        /*=================================================Create and use Entity=================================================*/
        //QLVanTai_2017Container1 qlvt = new QLVanTai_2017Container1();
        //QLVanTai_2017Container1 qlvt = new QLVanTai_2017Container1();
        //QLVanTai_2017Entities1 qlvt = new QLVanTai_2017Entities1();
        //VanTai_2017Entities1 qlvt = new VanTai_2017Entities1();
        QLVanTai_2017 qlvt = new QLVanTai_2017();
        /*=================================================Báo Cáo Tổng Hợp=================================================*/
        #region BÁO CÁO TỔNG HỢP
        //Báo Cáo Bến
        public List<sp_BaocaoTongHop_BenXe_Result> Get_BaoCaoTongHopBen(int nam, int thang, int idben)
        {
            List<sp_BaocaoTongHop_BenXe_Result> collection = new List<sp_BaocaoTongHop_BenXe_Result>((IEnumerable<sp_BaocaoTongHop_BenXe_Result>)qlvt.sp_BaocaoTongHop_BenXe(nam, thang, idben));
            return collection;
        }         
        //Báo Cáo Sở
        public List<sp_BaoCaoTongHop_So_Result> Get_BaoCaoTongHopSo(int nam, int thang, int idso)
        {
            List<sp_BaoCaoTongHop_So_Result> collection = new List<sp_BaoCaoTongHop_So_Result>((IEnumerable<sp_BaoCaoTongHop_So_Result>)qlvt.sp_BaoCaoTongHop_So(nam, thang, idso));
            return collection;
        }
        //Báo Cáo Toàn Quốc
        public List<sp_BaoCaoTongHop_ToanQuoc_Result> Get_BaoCaoTongHopToanQuoc(int nam, int thang)
        {
            List<sp_BaoCaoTongHop_ToanQuoc_Result> collection = new List<sp_BaoCaoTongHop_ToanQuoc_Result>((IEnumerable<sp_BaoCaoTongHop_ToanQuoc_Result>)qlvt.sp_BaoCaoTongHop_ToanQuoc(nam, thang));
            return collection;
        }
        #endregion
        /*=================================================Báo Cáo Hoạt Động=================================================*/
        #region BÁO CÁO HOẠT ĐỘNG
        //Báo Cáo Hoạt Động - Báo Cáo Tổng Hợp - Tại Bến - e
        public List<sp_HD_BaoCaoTongHopTaiBen_Result> Get_BaoCaoTongHop_Ben(int id_ben, string dt1, string dt2, long id_tuyen, int id_dvvt)
        {
            List<sp_HD_BaoCaoTongHopTaiBen_Result> collection = new List<sp_HD_BaoCaoTongHopTaiBen_Result>((IEnumerable<sp_HD_BaoCaoTongHopTaiBen_Result>)qlvt.sp_HD_BaoCaoTongHopTaiBen(id_ben, dt1, dt2, id_tuyen, id_dvvt));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Tổng Hợp - Đơn Vị Vận Tải - d
        public List<sp_HD_BaoCaoTongHop_DonViVanTai_Result> Get_BaoCaoTongHop_DVVT(int thang, int nam, int id_so, long id_tuyen, int id_dvvt)
        {
            List<sp_HD_BaoCaoTongHop_DonViVanTai_Result> collection = new List<sp_HD_BaoCaoTongHop_DonViVanTai_Result>((IEnumerable<sp_HD_BaoCaoTongHop_DonViVanTai_Result>)qlvt.sp_HD_BaoCaoTongHop_DonViVanTai(thang, nam, id_so, id_tuyen, id_dvvt));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Tổng Hợp - Tuyến - c
        public List<sp_HD_BaoCaoTongHop_Tuyen_Result> Get_BaoCaoTongHop_Tuyen(int thang, int nam, int id_so, long id_tuyen)
        {
            List<sp_HD_BaoCaoTongHop_Tuyen_Result> collection = new List<sp_HD_BaoCaoTongHop_Tuyen_Result>((IEnumerable<sp_HD_BaoCaoTongHop_Tuyen_Result>)qlvt.sp_HD_BaoCaoTongHop_Tuyen(thang, nam, id_so, id_tuyen));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Tổng Hợp - Sở - b
        public List<sp_HD_BaoCaoTongHop_SoGiaoThong_Result> Get_BaoCaoTongHop_So(int thang, int nam, int id_so)
        {
            List<sp_HD_BaoCaoTongHop_SoGiaoThong_Result> collection = new List<sp_HD_BaoCaoTongHop_SoGiaoThong_Result>((IEnumerable<sp_HD_BaoCaoTongHop_SoGiaoThong_Result>)qlvt.sp_HD_BaoCaoTongHop_SoGiaoThong(thang, nam, id_so));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Tổng Hợp - Toàn Quốc - a
        public List<sp_HD_BaoCaoTongHop_ToanQuoc_Result> Get_BaoCaoTongHop_ToanQuoc(int thang, int nam)
        {
            List<sp_HD_BaoCaoTongHop_ToanQuoc_Result> collection = new List<sp_HD_BaoCaoTongHop_ToanQuoc_Result>((IEnumerable<sp_HD_BaoCaoTongHop_ToanQuoc_Result>)qlvt.sp_HD_BaoCaoTongHop_ToanQuoc(thang, nam));
            return collection;
        }
        #endregion
        /*=================================================Báo Cáo Xe Chạy Sai Giờ=================================================*/
        #region BÁO CÁO XE CHẠY SAI GIỜ
        //Báo Cáo Hoạt Động - Báo Cáo Xe Chạy Sai Giờ - Tại Bến - e
        public List<sp_HD_BaoCaoXeChaySaiGioTaiBen_Result> Get_BaoCaoXeChaySaiGio_Ben(int id_ben, string dt1, string dt2, long id_tuyen, int id_dvvt)
        {
            List<sp_HD_BaoCaoXeChaySaiGioTaiBen_Result> collection = new List<sp_HD_BaoCaoXeChaySaiGioTaiBen_Result>((IEnumerable<sp_HD_BaoCaoXeChaySaiGioTaiBen_Result>)qlvt.sp_HD_BaoCaoXeChaySaiGioTaiBen(id_ben, dt1, dt2, id_tuyen, id_dvvt));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Xe Chạy Sai Giờ - Đơn Vị Vận Tải - d
        public List<sp_HD_BaoCaoXeChaySaiGio_DonViVanTai_Result> Get_BaoCaoXeChaySaiGio_DVVT(int thang, int nam, int id_so, long id_tuyen, int id_dvvt)
        {
            List<sp_HD_BaoCaoXeChaySaiGio_DonViVanTai_Result> collection = new List<sp_HD_BaoCaoXeChaySaiGio_DonViVanTai_Result>((IEnumerable<sp_HD_BaoCaoXeChaySaiGio_DonViVanTai_Result>)qlvt.sp_HD_BaoCaoXeChaySaiGio_DonViVanTai(thang, nam, id_so, id_tuyen, id_dvvt));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Xe Chạy Sai Giờ - Tuyến - c
        public List<sp_HD_BaoCaoXeChaySaiGio_Tuyen_Result> Get_BaoCaoXeChaySaiGio_Tuyen(int thang, int nam, int id_so, long id_tuyen)
        {
            List<sp_HD_BaoCaoXeChaySaiGio_Tuyen_Result> collection = new List<sp_HD_BaoCaoXeChaySaiGio_Tuyen_Result>((IEnumerable<sp_HD_BaoCaoXeChaySaiGio_Tuyen_Result>)qlvt.sp_HD_BaoCaoXeChaySaiGio_Tuyen(thang, nam, id_so, id_tuyen));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Xe Chạy Sai Giờ - Sở - b
        public List<sp_HD_BaoCaoXeChaySaiGio_SoGiaoThong_Result> Get_BaoCaoXeChaySaiGio_So(int thang, int nam, int id_so)
        {
            List<sp_HD_BaoCaoXeChaySaiGio_SoGiaoThong_Result> collection = new List<sp_HD_BaoCaoXeChaySaiGio_SoGiaoThong_Result>((IEnumerable<sp_HD_BaoCaoXeChaySaiGio_SoGiaoThong_Result>)qlvt.sp_HD_BaoCaoXeChaySaiGio_SoGiaoThong(thang, nam, id_so));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Xe Chạy Sai Giờ - Toàn Quốc - a
        public List<sp_HD_BaoCaoXeChaySaiGio_ToanQuoc_Result> Get_BaoCaoXeChaySaiGio_ToanQuoc(int thang, int nam)
        {
            List<sp_HD_BaoCaoXeChaySaiGio_ToanQuoc_Result> collection = new List<sp_HD_BaoCaoXeChaySaiGio_ToanQuoc_Result>((IEnumerable<sp_HD_BaoCaoXeChaySaiGio_ToanQuoc_Result>)qlvt.sp_HD_BaoCaoXeChaySaiGio_ToanQuoc(thang, nam));
            return collection;
        }
        #endregion
        /*=================================================Báo Cáo Xe Không Thực Hiện=================================================*/
        #region BÁO CÁO XE KHÔNG THỰC HIỆN
        //Báo Cáo Hoạt Động - Báo Cáo Xe Không Thực Hiện - Tại Bến - e
        public List<sp_HD_BaoCaoXeKhongHoatDongTaiBen_Result> Get_BaoCaoXeKhongHoatDong_Ben(int id_ben, string dt1, string dt2, long id_tuyen, int id_dvvt)
        {
            List<sp_HD_BaoCaoXeKhongHoatDongTaiBen_Result> collection = new List<sp_HD_BaoCaoXeKhongHoatDongTaiBen_Result>((IEnumerable<sp_HD_BaoCaoXeKhongHoatDongTaiBen_Result>)qlvt.sp_HD_BaoCaoXeKhongHoatDongTaiBen(id_ben, dt1, dt2, id_tuyen, id_dvvt));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Xe Không Thực Hiện - Đơn Vị Vận Tải - d
        public List<sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai_Result> Get_BaoCaoXeKhongHoatDong_DVVT(int thang, int nam, int id_so, long id_tuyen, int id_dvvt)
        {
            List<sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai_Result> collection = new List<sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai_Result>((IEnumerable<sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai_Result>)qlvt.sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai(thang, nam, id_so, id_tuyen, id_dvvt));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Xe Không Thực Hiện - Tại Tuyến - c
        public List<sp_HD_BaoCaoXeKhongHoatDong_Tuyen_Result> Get_BaoCaoXeKhongHoatDong_Tuyen(int thang, int nam, int id_so, long id_tuyen)
        {
            List<sp_HD_BaoCaoXeKhongHoatDong_Tuyen_Result> collection = new List<sp_HD_BaoCaoXeKhongHoatDong_Tuyen_Result>((IEnumerable<sp_HD_BaoCaoXeKhongHoatDong_Tuyen_Result>)qlvt.sp_HD_BaoCaoXeKhongHoatDong_Tuyen(thang, nam, id_so, id_tuyen));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Xe Không Thực Hiện - Tại Sở - b
        public List<sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong_Result> Get_BaoCaoXeKhongHoatDong_So(int thang, int nam, int id_so)
        {
            List<sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong_Result> collection = new List<sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong_Result>((IEnumerable<sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong_Result>)qlvt.sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong(thang, nam, id_so));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Xe Không Thực Hiện - Toàn Quốc - a
        public List<sp_HD_BaoCaoXeKhongHoatDong_ToanQuoc_Result> Get_BaoCaoXeKhongHoatDong_ToanQuoc(int thang, int nam)
        {
            List<sp_HD_BaoCaoXeKhongHoatDong_ToanQuoc_Result> collection = new List<sp_HD_BaoCaoXeKhongHoatDong_ToanQuoc_Result>((IEnumerable<sp_HD_BaoCaoXeKhongHoatDong_ToanQuoc_Result>)qlvt.sp_HD_BaoCaoXeKhongHoatDong_ToanQuoc(thang, nam));
            return collection;
        }
        #endregion
        /*=================================================Báo Cáo Xe Chạy Nhỏ Hơn 70=================================================*/
        #region BÁO CÁO XE CHẠY NHỎ HƠN 70%
        //Báo Cáo Hoạt Động - Báo Cáo Xe Chạy Nhỏ Hơn 70 - Đơn Vị Vận tải - d
        public List<sp_HD_BaoCaoXeChayNhoHon70_DonViVanTai_Result> Get_BaoCaoXeChayNhoHon70_DVVT(int thang, int nam, int id_so, long id_tuyen, int id_dvvt)
        {
            List<sp_HD_BaoCaoXeChayNhoHon70_DonViVanTai_Result> collection = new List<sp_HD_BaoCaoXeChayNhoHon70_DonViVanTai_Result>((IEnumerable<sp_HD_BaoCaoXeChayNhoHon70_DonViVanTai_Result>)qlvt.sp_HD_BaoCaoXeChayNhoHon70_DonViVanTai(thang, nam, id_so, id_tuyen, id_dvvt));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Xe Chạy Nhỏ Hơn 70 - Tuyến - c
        public List<Tuyen_Duoi70_Result> Get_BaoCaoXeChayNhoHon70_Tuyen(int thang, int nam, int id_so, long id_tuyen)
        {
            List<Tuyen_Duoi70_Result> collection = new List<Tuyen_Duoi70_Result>((IEnumerable<Tuyen_Duoi70_Result>)qlvt.Tuyen_Duoi70(thang, nam, id_so, id_tuyen));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Xe Chạy Nhỏ Hơn 70 - Sở - b
        public List<sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong_Result> Get_BaoCaoXeChayNhoHon70_So(int thang, int nam, int id_so)
        {
            List<sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong_Result> collection = new List<sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong_Result>((IEnumerable<sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong_Result>)qlvt.sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong(thang, nam, id_so));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Xe Chạy Nhỏ Hơn 70 - Toàn Quốc - a
        public List<sp_HD_BaoCaoXeChayNhoHon70_ToanQuoc_Result> Get_BaoCaoXeChayNhoHon70_ToanQuoc(int thang, int nam)
        {
            List<sp_HD_BaoCaoXeChayNhoHon70_ToanQuoc_Result> collection = new List<sp_HD_BaoCaoXeChayNhoHon70_ToanQuoc_Result>((IEnumerable<sp_HD_BaoCaoXeChayNhoHon70_ToanQuoc_Result>)qlvt.sp_HD_BaoCaoXeChayNhoHon70_ToanQuoc(thang, nam));
            return collection;
        }
        #endregion
        /*=================================================List Danh Sách ComBoBox=================================================*/
        #region DANH SÁCH CHO COMBOBOX
        public List<QLVT_ThongTinTinh_SoGiaoThong> Get_DanhSachAll_So(){

            return qlvt.QLVT_ThongTinTinh_SoGiaoThong.ToList();
        }
        public List<object> Get_DanhSachAll_Tuyen()
        {
            List<object> list_return = new List<object>();
            var tatca = new
            {
                LT_IdLuongTuyen = -1,
                LT_MaTuyen = -1,
                TuyenDuong = "Tất Cả"
            };
            list_return.Add(tatca);
            var list = (from lt in qlvt.QLVT_LuongTuyen
                        join lt_dc in qlvt.QLVT_LuongTuyen_DiemDauCuoi on lt.LT_IdLuongTuyen equals lt_dc.LT_DC_IdLuongTuyen
                        select new {
                            LT_MaTuyen = lt.LT_MaTuyen,
                            LT_DC_IdBen_01 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01,
                            LT_DC_IdBen_02 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02,
                            LT_DC_TenBen_01 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01,
                            LT_DC_TenBen_02 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02,
                            LT_IdLuongTuyen = lt.LT_IdLuongTuyen
                        }).ToList();
            foreach(var item in list){
                var ob = new
                {
                    LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                    LT_MaTuyen = item.LT_MaTuyen,
                    LT_DC_IdBen_01 = item.LT_DC_IdBen_01,
                    LT_DC_IdBen_02 = item.LT_DC_IdBen_02,
                    LT_DC_TenBen_01 = item.LT_DC_TenBen_01,
                    LT_DC_TenBen_02 = item.LT_DC_TenBen_02,
                    TuyenDuong = item.LT_DC_TenBen_01 + " - " + item.LT_DC_TenBen_02 + '(' + item.LT_MaTuyen + ')'
                };
                list_return.Add(ob);
            };
            //return qlvt.QLVT_LuongTuyen.ToList();
            return list_return;
        }
        public List<QLVT_CongTyVanTai> Get_DanhSachAll_DVVT()
        {
            return qlvt.QLVT_CongTyVanTai.ToList();
        }
        public List<QLVT_ThongTinBenXe> Get_DanhSachAll_Ben()
        {
            return qlvt.QLVT_ThongTinBenXe.ToList();
        }
        #endregion
        /*=================================================Lấy Nhật Trình Xe=================================================*/
        #region NHẬT TRÌNH XE
        public List<sp_NhatTrinhTheoXe_Result> GetNhatTrinhXe(string tungay, string denngay, string biensoxe, long idtuyen, int idcongty)
        {
            List<sp_NhatTrinhTheoXe_Result> collection = new List<sp_NhatTrinhTheoXe_Result>((IEnumerable<sp_NhatTrinhTheoXe_Result>)qlvt.sp_NhatTrinhTheoXe(tungay, denngay, biensoxe, idtuyen, idcongty));
            return collection;
        }
        #endregion
        /*=================================================Lấy Thông Tin Chi Tiết=================================================*/
        #region GET INFORMATION THEO ID
        public Object GetChiTiet(long? id_Tuyen, int? id_Dvvt)
        {
            Object ob = new Object();
            if(id_Tuyen.HasValue && id_Dvvt.HasValue)
            {
                long ID_TUYEN = Convert.ToInt64(id_Tuyen);
                int ID_DVVT = Convert.ToInt32(id_Dvvt);
                var congty = qlvt.QLVT_CongTyVanTai.FirstOrDefault(u => u.CT_IdCongTyVT == ID_DVVT);
                var tuyen = qlvt.QLVT_LuongTuyen.FirstOrDefault(u => u.LT_IdLuongTuyen == ID_TUYEN);
                ob = new
                {
                    TenCongTy = congty.TenCongTy,
                    TenTuyen = tuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01 + " - " + tuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02
                };
                return ob;
            }
            else if(id_Tuyen.HasValue)
            {
                long ID_TUYEN = Convert.ToInt64(id_Tuyen);
                var tuyen = qlvt.QLVT_LuongTuyen.FirstOrDefault(u => u.LT_IdLuongTuyen == ID_TUYEN);
                ob = new
                {
                    TenTuyen = tuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01 + " - " + tuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02
                };
                return ob;
            }
            else if(id_Dvvt.HasValue)
            {
                int ID_DVVT = Convert.ToInt32(id_Dvvt);
                var congty = qlvt.QLVT_CongTyVanTai.FirstOrDefault(u => u.CT_IdCongTyVT == ID_DVVT);
                ob = new
                {
                    TenCongTy = congty.TenCongTy
                };
                return ob;
            }
            return ob;
        }
        public List<QLVT_CongTyVanTai> LayDonViVanTaiCuaSo(int idso){
            return qlvt.QLVT_CongTyVanTai.Where(u => u.TS_IdTinh_So == idso).ToList();
        }
        public List<object> Get_DanhSachAll_Tuyen_CuaSo(int idso)
        {
            List<object> list_return = new List<object>();
            var tatca = new
            {
                LT_IdLuongTuyen = -1,
                LT_MaTuyen = -1,
                TuyenDuong = "Tất Cả"
            };
            int IDSO = Convert.ToInt32(idso);
            list_return.Add(tatca);
            var list = (from lt in qlvt.QLVT_LuongTuyen
                        join lt_dc in qlvt.QLVT_LuongTuyen_DiemDauCuoi on lt.LT_IdLuongTuyen equals lt_dc.LT_DC_IdLuongTuyen
                        join lt_ddc in qlvt.QLVT_CapTuyenChoTinh_So on lt.LT_IdLuongTuyen equals lt_ddc.LT_IdLuongTuyen
                        where lt_ddc.TS_IdTinh_So == IDSO
                        select new
                        {
                            LT_MaTuyen = lt.LT_MaTuyen,
                            LT_DC_IdBen_01 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01,
                            LT_DC_IdBen_02 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02,
                            LT_DC_TenBen_01 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01,
                            LT_DC_TenBen_02 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02,
                            LT_IdLuongTuyen = lt.LT_IdLuongTuyen,
                            IDTinh = lt_ddc.TS_IdTinh_So
                        }).ToList();
            foreach (var item in list)
            {
                var ob = new
                {
                    LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                    LT_MaTuyen = item.LT_MaTuyen,
                    LT_DC_IdBen_01 = item.LT_DC_IdBen_01,
                    LT_DC_IdBen_02 = item.LT_DC_IdBen_02,
                    LT_DC_TenBen_01 = item.LT_DC_TenBen_01,
                    LT_DC_TenBen_02 = item.LT_DC_TenBen_02,
                    IdTinhSo = item.IDTinh,
                    TuyenDuong = item.LT_DC_TenBen_01 + " - " + item.LT_DC_TenBen_02 + '(' + item.LT_MaTuyen + ')'
                };
                list_return.Add(ob);
            };
            //return qlvt.QLVT_LuongTuyen.ToList();
            return list_return;
        }
        #endregion
    }
}