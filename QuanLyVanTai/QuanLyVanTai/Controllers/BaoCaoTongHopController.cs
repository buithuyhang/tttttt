using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class BaoCaoTongHopController : Controller
    {
        GetBaoCaoHD bc = new GetBaoCaoHD();
        // GET: BaoCaoTongHop
        #region CONTROLLER
        public ActionResult Index()
        {
            List<object> List_Return = new List<object>();
            int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
            int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
            List_Return = Get_BaoCaoTongHop_ToanQuoc(nam_hientai, thang_hientai);
            ViewBag.BaoCaoTongHop_ToanQuoc = List_Return;
            var bien = new
            {
                Thang = thang_hientai,
                Nam = nam_hientai
            };
            ViewBag.BienSo = bien;
            return View();
        }       
        public ActionResult BaoCaoTongHop_So(int? thang, int? nam, int? so)
        {
            if (thang.HasValue && nam.HasValue && so.HasValue)
            {
                ViewBag.List_SoTongHop = Get_List_So();
                List<object> List_Return = new List<object>();
                int thang_hientai = Convert.ToInt32(thang);
                int nam_hientai = Convert.ToInt32(nam);
                int Id_SO = Convert.ToInt32(so); ;
                List_Return = Get_BaoCaoTongHop_So(nam_hientai, thang_hientai, Id_SO);
                ViewBag.BaoCaoTongHop_So = List_Return;
                var bien = new
                {
                    Id_So = Id_SO,
                    Thang = thang_hientai,
                    Nam = nam_hientai
                };
                ViewBag.BienSo = bien;
                return View();
            }
            else
            {
                ViewBag.List_SoTongHop = Get_List_So();
                List<object> List_Return = new List<object>();
                int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
                int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
                int Id_SO = 55;
                List_Return = Get_BaoCaoTongHop_So(nam_hientai, thang_hientai, Id_SO);
                ViewBag.BaoCaoTongHop_So = List_Return;
                var bien = new
                {
                    Id_So = Id_SO,
                    Thang = thang_hientai,
                    Nam = nam_hientai
                };
                ViewBag.BienSo = bien;
                return View();
            }
        }
        public ActionResult BaoCaoTongHop_Ben()
        {
            ViewBag.List_BenTongHop = Get_List_Ben();
            List<object> List_Return = new List<object>();
            int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
            int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
            int Id_Ben = 1;
            List_Return = Get_BaoCaoTongHop_BenXe(nam_hientai, thang_hientai, Id_Ben);
            ViewBag.BaoCaoTongHop_BenXe = List_Return;
            var bien = new
            {
                Id_Ben = Id_Ben,
                Thang = thang_hientai,
                Nam = nam_hientai
            };
            ViewBag.BienBen = bien;
            return View();
        }
        #endregion
        /*=================================Function Get Báo Cáo - Báo Cáo Tổng Hợp=================================*/
        #region GET LIST
        //BÁO CÁO CHO BẾN
        private List<object> Get_BaoCaoTongHop_BenXe(int nam, int thang, int ben)
        {
            int NAM = Convert.ToInt32(nam);
            int THANG = Convert.ToInt32(thang);
            int BEN = Convert.ToInt32(ben);            
            List<object> list1 = new List<object>();
            List<sp_BaocaoTongHop_BenXe_Result> list = new List<sp_BaocaoTongHop_BenXe_Result>();
            list = bc.Get_BaoCaoTongHopBen(NAM, THANG, BEN);
            foreach (var item in list)
            {
                var ob = new
                {
                    ChenhLech = item.ChenhLech,
                    IdBenDi = item.IdBenDi,
                    NgayXuatBenKeHoach = item.NgayXuatBenKeHoach,
                    SoChuyenKeHoach = item.SoChuyenKeHoach,
                    SoChuyenXuatBenNgay = item.SoChuyenXuatBenNgay,
                    TyLeThucHien = item.TyLeThucHien,
                    Thang = THANG,
                    Nam = NAM,
                    Ben = BEN                    
                };
                list1.Add(ob);
            }
            return list1;         
        }
        //BÁO CÁO CHO SỞ
        private List<object> Get_BaoCaoTongHop_So(int nam, int thang, int so)
        {
            int ngay_hientai = Convert.ToInt32(DateTime.Now.Day);
            int NAM = Convert.ToInt32(nam);
            int THANG = Convert.ToInt32(thang);
            int SO = Convert.ToInt32(so);
            int TUYEN = -1;
            int DVVT = -1;
            //string st1 = ngay_hientai + "/" + THANG + "/" + NAM;
            //string st2 = ngay_hientai + "/" + THANG + "/" + NAM;
            List<object> list1 = new List<object>();
            List<sp_BaoCaoTongHop_So_Result> list = new List<sp_BaoCaoTongHop_So_Result>();
            list = bc.Get_BaoCaoTongHopSo(NAM, THANG, SO);
            foreach (var item in list)
            {
                var ob = new
                {
                    BX_IdBenXe = item.BX_IdBenXe,
                    NgayXuatBenKeHoach = item.NgayXuatBenKeHoach,
                    SoChuyenChenhLech = item.SoChuyenChenhLech,
                    SoChuyenXuatBenNgay = item.SoChuyenXuatBenNgay,
                    SoLuotXuatBenKeHoach = item.SoLuotXuatBenKeHoach,
                    TenBenXe = item.TenBenXe,
                    TyLeXuatBen = item.TyLeXuatBen,
                    Thang = THANG,
                    Nam = NAM,
                    So = SO,
                    URL = "/BaoCaoHoatDong/BaoCaoHoatDong_Ben?name=a&Ben=" + item.BX_IdBenXe + "&dt1=" + item.NgayXuatBenKeHoach + "&dt2=" + item.NgayXuatBenKeHoach + "&Tuyen=" + TUYEN + "&Dvvt=" + DVVT
                };
                list1.Add(ob);
            }
            return list1;
        }
        //BÁO CÁO TOÀN QUỐC
        private List<object> Get_BaoCaoTongHop_ToanQuoc(int nam, int thang)
        {
            int NAM = Convert.ToInt32(nam);
            int THANG = Convert.ToInt32(thang);
            List<object> list1 = new List<object>();
            List<sp_BaoCaoTongHop_ToanQuoc_Result> list = new List<sp_BaoCaoTongHop_ToanQuoc_Result>();
            list = bc.Get_BaoCaoTongHopToanQuoc(NAM, THANG);
            var list2 = list.OrderBy(u => u.NgayXuatBen).Select(x => x);
            foreach (var item in list2)
            {
                var ob = new
                {
                    NgayXuatBen = item.NgayXuatBen,
                    SoChuyenChenhLech = item.SoChuyenChenhLech,
                    SochuyenXuatBen = item.SochuyenXuatBen,
                    SoLuotXuatBenKeHoachNgay = item.SoLuotXuatBenKeHoachNgay,
                    TS_IdTinh_So = item.TS_IdTinh_So,
                    TS_TenTinh = item.TS_TenTinh,
                    TyLeXuatBen = item.TyLeXuatBen,
                    Thang = THANG,
                    Nam = NAM,
                    URL = "/BaoCaoTongHop/BaoCaoTongHop_So?thang=" + THANG + "&nam=" + NAM + "&so=" + item.TS_IdTinh_So
                };
                list1.Add(ob);
            }
            return list1;
        }
        #endregion
        /*=================================Function CLICK Báo Cáo - Báo Cáo Tổng Hợp=================================*/
        #region EVENT CLICK 
        //BÁO CÁO CHO BẾN
        //[HttpPost]
        //public string GetBaoCaoTongHopBen(int nam, int thang, int ben)
        //{
        //    return JsonConvert.SerializeObject(Get_BaoCaoTongHop_BenXe(nam, thang, ben));
        //}
        //[HttpPost]
        ////BÁO CÁO CHO SỞ        
        //private string GetBaoCaoTongHopSo(int nam, int thang, int so)
        //{
        //    return JsonConvert.SerializeObject(Get_BaoCaoTongHop_So(nam, thang, so));
        //}
        //BÁO CÁO TOÀN QUỐC
        [HttpPost]
        public string GetBaoCaoTongHopToanQuoc(int nam, int thang)
        {
            return JsonConvert.SerializeObject(Get_BaoCaoTongHop_ToanQuoc(nam, thang));
        }        
        #endregion
        /*=================================Function CLICK Báo Cáo - Báo Cáo Tổng Hợp - CHỌN NHIỀU=================================*/
        #region CLICK CHO NHIỀU
        //BÁO CÁO CHO NHIỀU SỞ
        [HttpPost]
        public string LayBaoCaoTongHopChoNhieuSo(int nam, int thang, string so)
        {
            List<object> List_TraVe = new List<object>();
            int TUYEN = -1;
            int DVVT = -1;
            if (so.IndexOf("-1") > -1)
            {
                ArrayList mangso = new ArrayList(so.Split(new char[] { ',' }));
                mangso.RemoveAt(0);
                mangso.RemoveAt(mangso.IndexOf("-1"));
                mangso.RemoveAt(mangso.Count - 1);
                for (var i = 0; i < mangso.Count; i++)
                {
                    int idso = Convert.ToInt32(mangso[i]);
                    List<sp_BaoCaoTongHop_So_Result> list = new List<sp_BaoCaoTongHop_So_Result>();
                    list = bc.Get_BaoCaoTongHopSo(nam, thang, idso);
                    foreach (var item in list)
                    {
                        var ob = new
                        {
                            BX_IdBenXe = item.BX_IdBenXe,
                            NgayXuatBenKeHoach = item.NgayXuatBenKeHoach,
                            SoChuyenChenhLech = item.SoChuyenChenhLech,
                            SoChuyenXuatBenNgay = item.SoChuyenXuatBenNgay,
                            SoLuotXuatBenKeHoach = item.SoLuotXuatBenKeHoach,
                            TenBenXe = item.TenBenXe,
                            TyLeXuatBen = item.TyLeXuatBen,
                            Thang = thang,
                            Nam = nam,
                            So = idso,
                            URL = "/BaoCaoHoatDong/BaoCaoHoatDong_Ben?name=a&Ben=" + item.BX_IdBenXe + "&dt1=" + item.NgayXuatBenKeHoach + "&dt2=" + item.NgayXuatBenKeHoach + "&Tuyen=" + TUYEN + "&Dvvt=" + DVVT
                        };
                        List_TraVe.Add(ob);
                    }
                }
            }
            else
            {
                ArrayList mangso = new ArrayList(so.Split(new char[] { ',' }));
                mangso.RemoveAt(0);
                mangso.RemoveAt(mangso.Count - 1);
                for (var i = 0; i < mangso.Count; i++)
                {
                    int idso = Convert.ToInt32(mangso[i]);
                    List<sp_BaoCaoTongHop_So_Result> list = new List<sp_BaoCaoTongHop_So_Result>();
                    list = bc.Get_BaoCaoTongHopSo(nam, thang, idso);
                    foreach (var item in list)
                    {
                        var ob = new
                        {
                            BX_IdBenXe = item.BX_IdBenXe,
                            NgayXuatBenKeHoach = item.NgayXuatBenKeHoach,
                            SoChuyenChenhLech = item.SoChuyenChenhLech,
                            SoChuyenXuatBenNgay = item.SoChuyenXuatBenNgay,
                            SoLuotXuatBenKeHoach = item.SoLuotXuatBenKeHoach,
                            TenBenXe = item.TenBenXe,
                            TyLeXuatBen = item.TyLeXuatBen,
                            Thang = thang,
                            Nam = nam,
                            So = idso,
                            URL = "/BaoCaoHoatDong/BaoCaoHoatDong_Ben?name=a&Ben=" + item.BX_IdBenXe + "&dt1=" + item.NgayXuatBenKeHoach + "&dt2=" + item.NgayXuatBenKeHoach + "&Tuyen=" + TUYEN + "&Dvvt=" + DVVT
                        };
                        List_TraVe.Add(ob);
                    }
                }
            }
            return JsonConvert.SerializeObject(List_TraVe);
        }
        //BÁO CÁO CHO NHIỀU BẾN
        [HttpPost]
        public string LayBaoCaoTongHopChoNhieuBen(int nam, int thang, string ben)
        {
            List<object> List_TraVe = new List<object>();

            if (ben.IndexOf("-1") > -1)
            {
                ArrayList mangben = new ArrayList(ben.Split(new char[] { ',' }));
                mangben.RemoveAt(0);
                mangben.RemoveAt(mangben.IndexOf("-1"));
                mangben.RemoveAt(mangben.Count - 1);
                for (var i = 0; i < mangben.Count; i++)
                {
                    int idben = Convert.ToInt32(mangben[i]);
                    List<sp_BaocaoTongHop_BenXe_Result> list = new List<sp_BaocaoTongHop_BenXe_Result>();
                    list = bc.Get_BaoCaoTongHopBen(nam, thang, idben);
                    foreach (var item in list)
                    {
                        var ob = new
                        {
                            ChenhLech = item.ChenhLech,
                            IdBenDi = item.IdBenDi,
                            NgayXuatBenKeHoach = item.NgayXuatBenKeHoach,
                            SoChuyenKeHoach = item.SoChuyenKeHoach,
                            SoChuyenXuatBenNgay = item.SoChuyenXuatBenNgay,
                            TyLeThucHien = item.TyLeThucHien,
                            Thang = nam,
                            Nam = thang,
                            Ben = idben
                        };
                        List_TraVe.Add(ob);
                    }
                }
            }
            else
            {
                ArrayList mangben = new ArrayList(ben.Split(new char[] { ',' }));
                mangben.RemoveAt(0);
                mangben.RemoveAt(mangben.Count - 1);
                for (var i = 0; i < mangben.Count; i++)
                {
                    int idben = Convert.ToInt32(mangben[i]);
                    List<sp_BaocaoTongHop_BenXe_Result> list = new List<sp_BaocaoTongHop_BenXe_Result>();
                    list = bc.Get_BaoCaoTongHopBen(nam, thang, idben);
                    foreach (var item in list)
                    {
                        var ob = new
                        {
                            ChenhLech = item.ChenhLech,
                            IdBenDi = item.IdBenDi,
                            NgayXuatBenKeHoach = item.NgayXuatBenKeHoach,
                            SoChuyenKeHoach = item.SoChuyenKeHoach,
                            SoChuyenXuatBenNgay = item.SoChuyenXuatBenNgay,
                            TyLeThucHien = item.TyLeThucHien,
                            Thang = nam,
                            Nam = thang,
                            Ben = idben
                        };
                        List_TraVe.Add(ob);
                    }
                }
            }
            return JsonConvert.SerializeObject(List_TraVe);
        }
        #endregion
        /*============================Lấy List=====================================*/
        #region GET LIST OBJECT ON VIEW
        private List<object> Get_List_So()
        {
            List<object> list1 = new List<object>();
            foreach (var item in bc.Get_DanhSachAll_So())
            {
                var ob = new
                {
                    TS_IdTinh_So = item.TS_IdTinh_So,
                    TS_TenTinh = item.TS_TenTinh,
                    TS_IdMaTinh = item.TS_IdMaTinh,
                    TS_TT_IdTrangThai = item.TS_TT_IdTrangThai
                };
                list1.Add(ob);
            }
            return list1;
        }
        private List<object> Get_List_Ben()
        {
            List<object> list1 = new List<object>();
            var obb = new
            {
                BX_IdBenXe = -1,
                TenBenXe = "Tất Cả",
                LoaiBenXe = -1,
                MaBen = -1,
                TS_IdTinh_So = -1
            };
            list1.Add(obb);
            foreach (var item in bc.Get_DanhSachAll_Ben())
            {
                var ob = new
                {
                    BX_IdBenXe = item.BX_IdBenXe,
                    TenBenXe = item.TenBenXe,
                    LoaiBenXe = item.LoaiBenXe,
                    MaBen = item.MaBen,
                    TS_IdTinh_So = item.TS_IdTinh_So
                };
                list1.Add(ob);
            }
            return list1;
        }
        #endregion
    }
}