using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class GetBaoCaoHD
    {
        /*=================================================Create and use Entity=================================================*/
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
        public List<sp_HD_BaoCaoTongHopTaiBen_Result> Get_BaoCaoTongHop_Ben(string dt1, string dt2, int id_ben)
        {
            List<sp_HD_BaoCaoTongHopTaiBen_Result> collection = new List<sp_HD_BaoCaoTongHopTaiBen_Result>((IEnumerable<sp_HD_BaoCaoTongHopTaiBen_Result>)qlvt.sp_HD_BaoCaoTongHopTaiBen(dt1, dt2, id_ben));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Tổng Hợp - Đơn Vị Vận Tải - d
        public List<sp_HD_BaoCaoTongHop_DonViVanTai_Result> Get_BaoCaoTongHop_DVVT(string tuNgay, string denNgay, int id_ben, long id_tuyen, int id_dvvt)
        {
            List<sp_HD_BaoCaoTongHop_DonViVanTai_Result> collection = new List<sp_HD_BaoCaoTongHop_DonViVanTai_Result>((IEnumerable<sp_HD_BaoCaoTongHop_DonViVanTai_Result>)qlvt.sp_HD_BaoCaoTongHop_DonViVanTai(tuNgay, denNgay, id_ben, id_tuyen, id_dvvt));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Tổng Hợp - Tuyến - c
        public List<sp_HD_BaoCaoTongHop_Tuyen_Result> Get_BaoCaoTongHop_Tuyen(string tungay, string denngay, int idben, long id_tuyen)
        {
            List<sp_HD_BaoCaoTongHop_Tuyen_Result> collection = new List<sp_HD_BaoCaoTongHop_Tuyen_Result>((IEnumerable<sp_HD_BaoCaoTongHop_Tuyen_Result>)qlvt.sp_HD_BaoCaoTongHop_Tuyen(tungay, denngay, idben, id_tuyen));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Tổng Hợp - Sở - b
        public List<sp_HD_BaoCaoTongHop_SoGiaoThong_Result> Get_BaoCaoTongHop_So(string tungay, string denngay, int idso, string lstben)
        {
            List<sp_HD_BaoCaoTongHop_SoGiaoThong_Result> collection = new List<sp_HD_BaoCaoTongHop_SoGiaoThong_Result>((IEnumerable<sp_HD_BaoCaoTongHop_SoGiaoThong_Result>)qlvt.sp_HD_BaoCaoTongHop_SoGiaoThong(tungay, denngay, idso, lstben));
            return collection;
        }
        //Báo Cáo Hoạt Động - Báo Cáo Tổng Hợp - Toàn Quốc - a
        public List<sp_HD_BaoCaoTongHop_ToanQuoc_Result> Get_BaoCaoTongHop_ToanQuoc(string tu, string den)
        {
            List<sp_HD_BaoCaoTongHop_ToanQuoc_Result> collection = new List<sp_HD_BaoCaoTongHop_ToanQuoc_Result>((IEnumerable<sp_HD_BaoCaoTongHop_ToanQuoc_Result>)qlvt.sp_HD_BaoCaoTongHop_ToanQuoc(tu, den));
            return collection;
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
        /*=================================================List Danh Sách ComBoBox=================================================*/
        #region DANH SÁCH CHO COMBOBOX
        public List<QLVT_ThongTinTinh_SoGiaoThong> Get_DanhSachAll_So()
        {
            return qlvt.QLVT_ThongTinTinh_SoGiaoThong.ToList();
        }
        public List<object> Get_DanhSachAll_So_KhongChon()
        {
            List<object> List_return = new List<object>();
            List<QLVT_ThongTinTinh_SoGiaoThong> listTinh = qlvt.QLVT_ThongTinTinh_SoGiaoThong.ToList(); listTinh.RemoveAt(0);
            foreach(var item in listTinh){
                var ob = new
                {
                    TS_IdMaTinh = item.TS_IdMaTinh,
                    TS_IdTinh_So = item.TS_IdTinh_So,
                    TS_TenTinh = item.TS_TenTinh,
                    TS_TT_IdTrangThai = item.TS_TT_IdTrangThai,
                    SoDienThoai = item.SoDienThoai,
                    GiamDocSo = item.GiamDocSo
                };
                List_return.Add(ob);
            };
            return List_return;
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
                        select new
                        {
                            LT_MaTuyen = lt.LT_MaTuyen,
                            LT_DC_IdBen_01 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01,
                            LT_DC_IdBen_02 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02,
                            LT_DC_TenBen_01 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01,
                            LT_DC_TenBen_02 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02,
                            LT_IdLuongTuyen = lt.LT_IdLuongTuyen
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
        public List<object> Get_DanhSachAll_Tuyen_CuaBen(int idBen)
        {
            List<object> list_return = new List<object>();
            var tatca = new
            {
                LT_IdLuongTuyen = -1,
                LT_MaTuyen = -1,
                TuyenDuong = "Tất Cả"
            };
            list_return.Add(tatca);
            int IDBEN = Convert.ToInt32(idBen);
            var list = (from lt in qlvt.QLVT_LuongTuyen
                        where lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01 == IDBEN || lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02 == IDBEN
                        select new
                        {
                            LT_MaTuyen = lt.LT_MaTuyen,
                            LT_DC_IdBen_01 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01,
                            LT_DC_IdBen_02 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02,
                            LT_DC_TenBen_01 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01,
                            LT_DC_TenBen_02 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02,
                            LT_IdLuongTuyen = lt.LT_IdLuongTuyen,
                        }).ToList();
            list.GroupBy(u => u.LT_IdLuongTuyen);
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
                    TuyenDuong = item.LT_DC_TenBen_01 + " - " + item.LT_DC_TenBen_02 + '(' + item.LT_MaTuyen + ')'
                };
                list_return.Add(ob);
            };
            return list_return;
        }
        public List<object> Get_DanhSachAll_Tuyen_CuaBen_KhongTatCa(int idBen)
        {
            List<object> list_return = new List<object>();            
            int IDBEN = Convert.ToInt32(idBen);
            var list = (from lt in qlvt.QLVT_LuongTuyen
                        where lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01 == IDBEN || lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02 == IDBEN
                        select new
                        {
                            LT_MaTuyen = lt.LT_MaTuyen,
                            LT_DC_IdBen_01 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01,
                            LT_DC_IdBen_02 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02,
                            LT_DC_TenBen_01 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01,
                            LT_DC_TenBen_02 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02,
                            LT_IdLuongTuyen = lt.LT_IdLuongTuyen,
                        }).ToList();
            list.GroupBy(u => u.LT_IdLuongTuyen);
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
                    TuyenDuong = item.LT_DC_TenBen_01 + " - " + item.LT_DC_TenBen_02 + '(' + item.LT_MaTuyen + ')'
                };
                list_return.Add(ob);
            };
            //return qlvt.QLVT_LuongTuyen.ToList();
            return list_return;
        }
        public string Get_DanhSachAll_TenTuyen_CuaBen_KhongTatCa(int idBen, long[] array)
        {
            QLVT_LuongTuyen ltt = new QLVT_LuongTuyen();
            string string_return = "";
            int IDBEN = Convert.ToInt32(idBen);
            var list = (from lt in qlvt.QLVT_LuongTuyen
                        where lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01 == IDBEN || lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02 == IDBEN
                        select new
                        {
                            LT_IdLuongTuyen = lt.LT_IdLuongTuyen,
                        }).ToList();            
            if (array != null)
            {
                if (array.Length <= 3)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        long idtuyen = array[i];
                        ltt = qlvt.QLVT_LuongTuyen.Where(u => u.LT_IdLuongTuyen == idtuyen).FirstOrDefault();
                        string_return += ltt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01 + " - " + ltt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02;
                    }
                    string_return += ".";
                }else{
                    int i = 3;
                    for (int j = 0; j < i; j++)
                    {
                        ltt = qlvt.QLVT_LuongTuyen.Where(u => u.LT_IdLuongTuyen == array[j]).FirstOrDefault();
                        string_return += ltt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01 + " - " + ltt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02;
                    };
                    string_return += ", ...";
                }
            }
            return string_return;
        }
        public long Get_Id_TuyenDauTien_CuaBen(int idBen)
        {
            long idTuyen;
            int IDBEN = Convert.ToInt32(idBen);
            var list = (from lt in qlvt.QLVT_LuongTuyen
                        where lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01 == IDBEN || lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02 == IDBEN
                        select new
                        {
                            LT_MaTuyen = lt.LT_MaTuyen,
                            LT_DC_IdBen_01 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01,
                            LT_DC_IdBen_02 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02,
                            LT_DC_TenBen_01 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01,
                            LT_DC_TenBen_02 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02,
                            LT_IdLuongTuyen = lt.LT_IdLuongTuyen,
                        }).FirstOrDefault();
            if (list == null)
            {
                idTuyen = -1;
            }
            else
            {
                idTuyen = list.LT_IdLuongTuyen;
            }
            return idTuyen;
        }
        public List<QLVT_ThongTinBenXe> Get_DanhSachBenXe_CuaSoGiaoThong(int idso)
        {
            return qlvt.QLVT_ThongTinBenXe.Where(u => u.TS_IdTinh_So == idso).ToList();
        }
        public QLVT_ThongTinBenXe Get_ThongTinBenXe_TheoIdBen(int idben)
        {
            return qlvt.QLVT_ThongTinBenXe.Where(u => u.BX_IdBenXe == idben).FirstOrDefault();
        }
        public List<object> Get_DanhSachCongTyVanTai_TrenTuyen_TheoIdTuyen(long idtuyen)
        {
            List<object> list_return = new List<object>();
            var list1 = (from lt in qlvt.QLVT_DanhSachCapTuyenChoDN 
                         join tt in qlvt.QLVT_CongTyVanTai on lt.CT_IdCongTyVT equals tt.CT_IdCongTyVT
                                            where lt.LT_IdLuongTuyen == idtuyen
                                            select new {
                                                CT_IdCongTyVT = lt.CT_IdCongTyVT,
                                                TenCongTy = tt.TenCongTy
                                            });
            foreach (var item in list1)
            {
                var ob = new
                {
                    CT_IdCongTyVT = item.CT_IdCongTyVT,
                    TenCongTy = item.TenCongTy
                };
                list_return.Add(ob);
            };
            return list_return;
        }
        public List<object> Get_DanhSachCongTyVanTai_TrenTuyen_TheoIdTuyen1(long idtuyen)
        {
            List<object> list_return = new List<object>();
            var list1 = (from lt in qlvt.QLVT_DanhSachCapTuyenChoDN
                         join tt in qlvt.QLVT_CongTyVanTai on lt.CT_IdCongTyVT equals tt.CT_IdCongTyVT
                         where lt.LT_IdLuongTuyen == idtuyen
                         select new
                         {
                             CT_IdCongTyVT = lt.CT_IdCongTyVT,
                             TenCongTy = tt.TenCongTy
                         });
            var tatca = new
            {
                CT_IdCongTyVT = -1,
                TenCongTy = "Tất Cả"
            };
            list_return.Add(tatca);
            foreach (var item in list1)
            {
                var ob = new
                {
                    CT_IdCongTyVT = item.CT_IdCongTyVT,
                    TenCongTy = item.TenCongTy
                };
                list_return.Add(ob);
            };
            return list_return;
        }
        public int Get_Id_DonViDauTin_CuaTuyen(long idtuyen)
        {
            int idDVVT;
            List<object> list_return = new List<object>();
            var list1 = (from lt in qlvt.QLVT_DanhSachCapTuyenChoDN
                         join tt in qlvt.QLVT_CongTyVanTai on lt.CT_IdCongTyVT equals tt.CT_IdCongTyVT
                         where lt.LT_IdLuongTuyen == idtuyen
                         select new
                         {
                             CT_IdCongTyVT = lt.CT_IdCongTyVT,
                             TenCongTy = tt.TenCongTy
                         }).FirstOrDefault();
            return idDVVT = Convert.ToInt32(list1.CT_IdCongTyVT);
        }
        public QLVT_ThongTinBenXe Get_ThongTinBenXe_TheoId(int idben)
        {
            return qlvt.QLVT_ThongTinBenXe.Where(u => u.BX_IdBenXe == idben).FirstOrDefault();
        }
        public object Get_ThongTinTuyen_TheoId(long idtuyen)
        {
            long TUYEN = Convert.ToInt64(idtuyen);
            QLVT_LuongTuyen ltt = qlvt.QLVT_LuongTuyen.Where(u => u.LT_IdLuongTuyen == TUYEN).FirstOrDefault();
            if (ltt != null)
            {
                var ob = new
                {
                    LT_IdLuongTuyen = ltt.LT_IdLuongTuyen,
                    LT_MaTuyen = ltt.LT_MaTuyen,
                    LT_DC_IdBen_01 = ltt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01,
                    LT_DC_IdBen_02 = ltt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02,
                    LT_DC_TenBen_01 = ltt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01,
                    LT_DC_TenBen_02 = ltt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02,
                    TuyenDuong = ltt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01 + " - " + ltt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02,
                    LT_DC_IdLuongTuyen = ltt.LT_DC_IdLuongTuyen,
                    LT_HanhTrinhChay = ltt.LT_HanhTrinhChay,
                    LT_LuuLuongQuyDinh = ltt.LT_LuuLuongQuyDinh,
                    LT_PL_IdLuongTuyen = ltt.LT_PL_IdLuongTuyen,
                    TT_IdTrangThaiTuyen = ltt.TT_IdTrangThaiTuyen
                };
                return ob;
            }
            return null;    
        }
        public string TenTuyen_TheoId(long idtuyen)
        {
            long TUYEN = Convert.ToInt64(idtuyen);
            QLVT_LuongTuyen ltt = qlvt.QLVT_LuongTuyen.Where(u => u.LT_IdLuongTuyen == TUYEN).FirstOrDefault();
            string st = ltt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01 + " - " + ltt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02;
            return st;
        }
        public QLVT_CongTyVanTai Get_ThongTinDVVT_TheoIdDVVT(int iddvvt)
        {
            return qlvt.QLVT_CongTyVanTai.Where(u => u.CT_IdCongTyVT == iddvvt).FirstOrDefault();
        }
        #endregion
        /*=================================================Báo Cáo Hoạt Động Thường Xuyên=================================================*/
        #region BÁO CÁO HOẠT ĐỘNG THƯỜNG XUYÊN
        //BÁO CÁO HOẠT ĐỘNG THƯỜNG XUYÊN INDEX
        public List<sp_BaoCaoHoatDongThuongXuyen_Result> Get_BaoCaoHoatDongThuongXuyen(string ngay, int idben)
        {
            List<sp_BaoCaoHoatDongThuongXuyen_Result> collection = new List<sp_BaoCaoHoatDongThuongXuyen_Result>((IEnumerable<sp_BaoCaoHoatDongThuongXuyen_Result>)qlvt.sp_BaoCaoHoatDongThuongXuyen(ngay, idben));
            return collection;
        }
        //BÁO CÁO HOẠT ĐỘNG THƯỜNG XUYÊN - DANH SÁCH ĐƠN VỊ VẬN TẢI TUYẾN
        public List<sp_BaoCaoHoatDongThuongXuyen_DanhSachDonVi_Result> Get_BaoCaoHoatDongThuongXuyen_DonViVanTai(string ngay, int idben, long idtuyen)
        {
            List<sp_BaoCaoHoatDongThuongXuyen_DanhSachDonVi_Result> collection = new List<sp_BaoCaoHoatDongThuongXuyen_DanhSachDonVi_Result>((IEnumerable<sp_BaoCaoHoatDongThuongXuyen_DanhSachDonVi_Result>)qlvt.sp_BaoCaoHoatDongThuongXuyen_DanhSachDonVi(ngay, idben, idtuyen));
            return collection;
        }
        //BÁO CÁO HOẠT ĐỘNG THƯỜNG XUYÊN - DANH SÁCH THÔNG TIN XE 
        public List<sp_BaoCaoHoatDongThuongXuyen_DanhSachXe_Result> Get_BaoCaoHoatDongThuongXuyen_ThongTinXe(string ngay, int idben, long idtuyen)
        {
            List<sp_BaoCaoHoatDongThuongXuyen_DanhSachXe_Result> collection = new List<sp_BaoCaoHoatDongThuongXuyen_DanhSachXe_Result>((IEnumerable<sp_BaoCaoHoatDongThuongXuyen_DanhSachXe_Result>)qlvt.sp_BaoCaoHoatDongThuongXuyen_DanhSachXe(ngay, idben, idtuyen));
            return collection;
        }
        #endregion
    }
}