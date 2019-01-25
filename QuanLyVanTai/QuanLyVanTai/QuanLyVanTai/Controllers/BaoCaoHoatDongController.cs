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
    public class BaoCaoHoatDongController : Controller
    {
        GetBaoCaoHD bc = new GetBaoCaoHD();
        
        // GET: BaoCaoHoatDong      
        /*=================================Controller no param=================================*/
        #region CONTROLLER ROUTING NO PARAM
        public ActionResult Index()
        {
            List<object> List_Return = new List<object>();
            int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
            int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
            var ten = Convert.ToString("a");
            List_Return = Get_BaoCao_ToanQuoc(ten, thang_hientai, nam_hientai);
            ViewBag.BaoCaoTongHop_ToanQuoc = List_Return;
            var bien = new
            {
                Thang = thang_hientai,
                Nam = nam_hientai,
            };
            ViewBag.BienToanQuoc = bien;
            return View();
        }
        public ActionResult BaoCaoHoatDong_So()
        {
            ViewBag.List_So = Get_List_So();
            List<object> List_Return = new List<object>();
            int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
            int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
            int SO = 55; // default Sở
            var ten = Convert.ToString("a"); // default name
            List_Return = Get_BaoCao_So(ten, thang_hientai, nam_hientai, SO);
            ViewBag.BaoCaoTongHop_So = List_Return;
            var bien = new
            {
                Thang = thang_hientai,
                Nam = nam_hientai,
                So = SO
            };
            ViewBag.BienCuaSo = bien;
            return View();
        }
        public ActionResult BaoCaoHoatDong_Tuyen()
        {
            ViewBag.List_So = Get_List_So();
            ViewBag.List_Tuyen = Get_List_Tuyen();
            List<object> List_Return = new List<object>();
            int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
            int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
            int SO = 55; // default Sở
            long TUYEN = 1; // default Tuyến
            var ten = Convert.ToString("a"); // default name
            List_Return = Get_BaoCao_Tuyen(ten, thang_hientai, nam_hientai, SO, TUYEN);
            ViewBag.BaoCaoTongHop_Tuyen = List_Return;
            var bien = new
            {
                Thang = thang_hientai,
                Nam = nam_hientai,
                So = SO,
                Tuyen = TUYEN
            };
            ViewBag.BienCuaTuyen = bien;
            return View();
        }
        public ActionResult BaoCaoHoatDong_DonViVanTai()
        {
            ViewBag.List_So = Get_List_So();
            ViewBag.List_Tuyen = Get_List_Tuyen();
            ViewBag.List_DVVT = Get_List_DVVT();
            List<object> List_Return = new List<object>();
            int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
            int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
            int SO = 55; // default Sở
            long TUYEN = 1; // default Tuyến
            int DVVT = 1; // defaut DVVT
            var ten = Convert.ToString("a"); // default name
            List_Return = Get_BaoCao_DVVT(ten, thang_hientai, nam_hientai, SO, TUYEN, DVVT);
            ViewBag.BaoCaoTongHop_DVVT = List_Return;
            var bien = new
            {
                Thang = thang_hientai,
                Nam = nam_hientai,
                So = SO,
                Tuyen = TUYEN,
                Dvvt = DVVT
            };
            ViewBag.BienCuaDVVT = bien;
            return View();
        }
        public ActionResult BaoCaoHoatDong_Ben()
        {
            ViewBag.List_Ben = Get_List_Ben();
            ViewBag.List_Tuyen = Get_List_Tuyen();
            ViewBag.List_DVVT = Get_List_DVVT();
            List<object> List_Return = new List<object>();
            int ngay_hientai = Convert.ToInt32(DateTime.Now.Day);
            int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
            int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
            DateTime dtStart = new DateTime(nam_hientai, thang_hientai, ngay_hientai);
            DateTime dtEnd = new DateTime(nam_hientai, thang_hientai, ngay_hientai);
            //DateTime dtStart = new DateTime(2017, 10, 01);
            //DateTime dtEnd = new DateTime(2017, 10, 09);
            string D1 = dtStart.ToString();
            string D2 = dtEnd.ToString();
            string[] DT1 = (Convert.ToString(D1)).Split(' ');
            string[] DT2 = (Convert.ToString(D2)).Split(' ');
            string[] DTT1 = DT1[0].Split('/');
            string[] DTT2 = DT2[0].Split('/');
            int intNgayBatDau = Convert.ToInt32(DTT1[1]);
            int intThangBatDau = Convert.ToInt32(DTT1[0]);
            int intNamBatDau = Convert.ToInt32(DTT1[2]);

            int intNgayKetThuc = Convert.ToInt32(DTT2[1]);
            int intThangKetThuc = Convert.ToInt32(DTT2[0]);
            int intNamKetThuc = Convert.ToInt32(DTT2[2]);
            string sdt1 = intNgayBatDau + "/" + intThangBatDau + "/" + intNamBatDau;
            string sdt2 = intNgayKetThuc + "/" + intThangKetThuc + "/" + intNamKetThuc;
            int BEN = 2; //defaut Bến   
            long TUYEN = -1; // default Tuyến
            int DVVT = -1; // defaut DVVT
            var ten = Convert.ToString("a"); //default name
            List_Return = Get_BaoCao_Ben(ten, BEN, sdt1, sdt2, TUYEN, DVVT);
            ViewBag.BaoCaoTongHop_Ben = List_Return;
            var bien = new
            {
                Ben = BEN,
                Tuyen = TUYEN,
                Dvvt = DVVT,
                NgayBatDau = intNgayBatDau,
                ThangBatDau = intThangBatDau,
                NamBatDau = intNamBatDau,
                NgayKetThuc = intNgayKetThuc,
                ThangKetThuc = intThangKetThuc,
                NamKetThuc = intNamKetThuc
            };
            ViewBag.BienCuaBen = bien;
            return View();
        }
        #endregion
        /*=================================Controller has param=================================*/
        #region CONTROLLER ROUTING PARAM
        [HttpGet]
        public ActionResult Index(string name, int? thang , int? nam = 2017)
        {
            thang = thang != null ? thang : DateTime.Now.Month;
            nam = nam != null ? nam : DateTime.Now.Year;
            List<object> List_Return = new List<object>();
            if (!string.IsNullOrEmpty(Convert.ToString(name)))
            {
                var ten = Convert.ToString(name);                
                if (thang.HasValue && nam.HasValue)

                {
                    int THANG = Convert.ToInt32(thang);
                    int NAM = Convert.ToInt32(nam);
                    List_Return = Get_BaoCao_ToanQuoc(ten, THANG, NAM);
                    ViewBag.BaoCaoTongHop_ToanQuoc = List_Return;
                    var bien = new
                    {
                        Thang = THANG,
                        Nam = NAM,
                    };
                    ViewBag.BienToanQuoc = bien;
                    return View();
                }
                else
                {
                    int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
                    int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
                    List_Return = Get_BaoCao_ToanQuoc(ten, thang_hientai, nam_hientai);
                    ViewBag.BaoCaoTongHop_ToanQuoc = List_Return;
                    var bien = new
                    {
                        Thang = thang_hientai,
                        Nam = nam_hientai,
                    };
                    ViewBag.BienToanQuoc = bien;
                    return View();
                }
            }
            return View();
        }        
        [HttpGet]
        public ActionResult BaoCaoHoatDong_So(string name, int? thang, int? nam, int? so)
        {
            ViewBag.List_So = Get_List_So();            
            List<object> List_Return = new List<object>();
            if (!string.IsNullOrEmpty(Convert.ToString(name)))
            {
                var ten = Convert.ToString(name);
                if (thang.HasValue && nam.HasValue && so.HasValue)
                {
                    int THANG = Convert.ToInt32(thang);
                    int NAM = Convert.ToInt32(nam);
                    int SO = Convert.ToInt32(so);
                    List_Return = Get_BaoCao_So(ten, THANG, NAM, SO);
                    ViewBag.BaoCaoTongHop_So = List_Return;
                    var bien = new
                    {
                        Thang = THANG,
                        Nam = NAM,
                        So = SO
                    };
                    ViewBag.BienCuaSo = bien;
                    return View();
                }
                else
                {
                    int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
                    int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
                    int SO = 55; // default Sở
                    List_Return = Get_BaoCao_So(ten, thang_hientai, nam_hientai, SO);
                    ViewBag.BaoCaoTongHop_So = List_Return;
                    var bien = new
                    {
                        Thang = thang_hientai,
                        Nam = nam_hientai,
                        So = SO
                    };
                    ViewBag.BienCuaSo = bien;
                    return View();
                }
            }
            return View();
        }        
        [HttpGet]
        public ActionResult BaoCaoHoatDong_Tuyen(string name, int? thang, int? nam, int? so, long? tuyen)
        {
            ViewBag.List_So = Get_List_So();
            ViewBag.List_Tuyen = Get_List_Tuyen();
            List<object> List_Return = new List<object>();
            if (!string.IsNullOrEmpty(Convert.ToString(name)))
            {
                var ten = Convert.ToString(name);
                if (thang.HasValue && nam.HasValue && so.HasValue && tuyen.HasValue)
                {
                    int THANG = Convert.ToInt32(thang);
                    int NAM = Convert.ToInt32(nam);
                    int SO = Convert.ToInt32(so);
                    long TUYEN = Convert.ToInt64(tuyen);
                    List_Return = Get_BaoCao_Tuyen(ten, THANG, NAM, SO, TUYEN);
                    ViewBag.BaoCaoTongHop_Tuyen = List_Return;
                    var bien = new
                    {
                        Thang = THANG,
                        Nam = NAM,
                        So = SO,
                        Tuyen = TUYEN
                    };
                    ViewBag.BienCuaTuyen = bien;
                    return View();
                }
                else
                {
                    int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
                    int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
                    int SO = 55; // default Sở
                    long TUYEN = 1; // default Tuyến
                    List_Return = Get_BaoCao_Tuyen(ten, thang_hientai, nam_hientai, SO, TUYEN);
                    ViewBag.BaoCaoTongHop_Tuyen = List_Return;
                    var bien = new
                    {
                        Thang = thang_hientai,
                        Nam = nam_hientai,
                        So = SO,
                        Tuyen = TUYEN
                    };
                    ViewBag.BienCuaTuyen = bien;
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult BaoCaoHoatDong_DonViVanTai(string name, int? thang, int? nam, int? so, long? tuyen, int? dvvt)
        {
            ViewBag.List_So = Get_List_So();
            ViewBag.List_Tuyen = Get_List_Tuyen();
            ViewBag.List_DVVT = Get_List_DVVT();
            List<object> List_Return = new List<object>();
            if (!string.IsNullOrEmpty(Convert.ToString(name)))
            {
                var ten = Convert.ToString(name);
                if (thang.HasValue && nam.HasValue && so.HasValue && tuyen.HasValue)
                {
                    int THANG = Convert.ToInt32(thang);
                    int NAM = Convert.ToInt32(nam);
                    int SO = Convert.ToInt32(so);
                    long TUYEN = Convert.ToInt64(tuyen);
                    int DVVT = Convert.ToInt32(dvvt);
                    List_Return = Get_BaoCao_DVVT(ten, THANG, NAM, SO, TUYEN, DVVT);
                    ViewBag.BaoCaoTongHop_DVVT = List_Return;
                    var bien = new
                    {
                        Thang = THANG,
                        Nam = NAM,
                        So = SO,
                        Tuyen = TUYEN,
                        Dvvt = DVVT
                    };
                    ViewBag.BienCuaDVVT = bien;
                    return View();
                }
                else
                {
                    int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
                    int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
                    int SO = 55; // default Sở
                    long TUYEN = 1; // default Tuyến
                    int DVVT = 1; // defaut DVVT
                    List_Return = Get_BaoCao_DVVT(ten, thang_hientai, nam_hientai, SO, TUYEN, DVVT);
                    ViewBag.BaoCaoTongHop_DVVT = List_Return;
                    var bien = new
                    {
                        Thang = thang_hientai,
                        Nam = nam_hientai,
                        So = SO,
                        Tuyen = TUYEN,
                        Dvvt = DVVT
                    };
                    ViewBag.BienCuaDVVT = bien;
                    return View();
                }
            }
            return View();            
        }
        [HttpGet]
        public ActionResult BaoCaoHoatDong_Ben(string name, int? ben, string dt1, string dt2, long? tuyen, int? dvvt)
        {
            ViewBag.List_Ben = Get_List_Ben();
            ViewBag.List_Tuyen = Get_List_Tuyen();
            ViewBag.List_DVVT = Get_List_DVVT();
            List<object> List_Return = new List<object>();
            if (!string.IsNullOrEmpty(Convert.ToString(dt1)) && !string.IsNullOrEmpty(Convert.ToString(dt2)) && !string.IsNullOrEmpty(Convert.ToString(name)))
            {
                var ten = Convert.ToString(name);
                if (ben.HasValue && tuyen.HasValue && dvvt.HasValue)
                {
                    int BEN = Convert.ToInt32(ben);
                    string D1 = Convert.ToString(dt1);
                    string D2 = Convert.ToString(dt2);
                    long TUYEN = Convert.ToInt64(tuyen);
                    int DVVT = Convert.ToInt32(dvvt);
                    List_Return = Get_BaoCao_Ben(ten, BEN, D1, D2, TUYEN, DVVT);

                    //string[] DT1 = (Convert.ToString(D1)).Split(' ');
                    //string[] DT2 = (Convert.ToString(D2)).Split(' ');

                    string[] DTT1 = D1.Split('/');
                    string[] DTT2 = D2.Split('/');
                    int intNgayBatDau = Convert.ToInt32(DTT1[0]);
                    int intThangBatDau = Convert.ToInt32(DTT1[1]);
                    int intNamBatDau = Convert.ToInt32(DTT1[2]);

                    int intNgayKetThuc = Convert.ToInt32(DTT2[0]);
                    int intThangKetThuc = Convert.ToInt32(DTT2[1]);
                    int intNamKetThuc = Convert.ToInt32(DTT2[2]);

                    ViewBag.BaoCaoTongHop_Ben = List_Return;
                    var bien = new
                    {
                        Ben = BEN,                        
                        Tuyen = TUYEN,
                        Dvvt = DVVT,
                        NgayBatDau = intNgayBatDau,
                        ThangBatDau = intThangBatDau,
                        NamBatDau = intNamBatDau,
                        NgayKetThuc = intNgayKetThuc,
                        ThangKetThuc = intThangKetThuc,
                        NamKetThuc = intNamKetThuc
                    };
                    ViewBag.BienCuaBen = bien;
                    return View();
                }
                else
                {
                    int ngay_hientai = Convert.ToInt32(DateTime.Now.Day);
                    int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
                    int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
                    DateTime dtStart = new DateTime(nam_hientai, thang_hientai, ngay_hientai);
                    DateTime dtEnd = new DateTime(nam_hientai, thang_hientai, ngay_hientai);
                    string D1 = dtStart.ToString();
                    string D2 = dtEnd.ToString();

                    int BEN = 2; //defaut Bến   
                    long TUYEN = 55; // default Tuyến
                    int DVVT = 1; // defaut DVVT
                    string[] DT1 = (Convert.ToString(D1)).Split(' ');
                    string[] DT2 = (Convert.ToString(D2)).Split(' ');

                    string[] DTT1 = DT1[0].Split('/');
                    string[] DTT2 = DT2[0].Split('/');
                    int intNgayBatDau = Convert.ToInt32(DTT1[1]);
                    int intThangBatDau = Convert.ToInt32(DTT1[0]);
                    int intNamBatDau = Convert.ToInt32(DTT1[2]);

                    int intNgayKetThuc = Convert.ToInt32(DTT2[1]);
                    int intThangKetThuc = Convert.ToInt32(DTT2[0]);
                    int intNamKetThuc = Convert.ToInt32(DTT2[2]);
                    string sdt1 = intNgayBatDau + "/" + intThangBatDau + "/" + intNamBatDau;
                    string sdt2 = intNgayKetThuc + "/" + intThangKetThuc + "/" + intNamKetThuc;
                    List_Return = Get_BaoCao_Ben(ten, BEN, sdt1, sdt2, TUYEN, DVVT);
                    //List_Return = Get_BaoCao_Ben(ten, BEN, "01/10/2017", "10/10/2017", TUYEN, DVVT);
                    ViewBag.BaoCaoTongHop_Ben = List_Return;
                    var bien = new
                    {
                        Ben = BEN,                        
                        Tuyen = TUYEN,
                        Dvvt = DVVT,
                        NgayBatDau = intNgayBatDau,
                        ThangBatDau = intThangBatDau,
                        NamBatDau = intNamBatDau,
                        NgayKetThuc = intNgayKetThuc,
                        ThangKetThuc = intThangKetThuc,
                        NamKetThuc = intNamKetThuc
                    };
                    ViewBag.BienCuaBen = bien;
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult NhatTrinhXe(string tungay, string denngay, string biensoxe, long? Tuyen, int? Dvvt)
        {
            List<object> List_Return = new List<object>();
            if (!string.IsNullOrEmpty(Convert.ToString(tungay)) && !string.IsNullOrEmpty(Convert.ToString(denngay)) && !string.IsNullOrEmpty(Convert.ToString(biensoxe)))
            {
                if (Tuyen.HasValue && Dvvt.HasValue)
                {
                    long TUYEN = Convert.ToInt64(Tuyen);
                    int DVVT = Convert.ToInt32(Dvvt);
                    List_Return = GetNhatTrinhXe(tungay, denngay, biensoxe, TUYEN, DVVT);
                    ViewBag.BaoCaoNhatTrinhXe_DVVT = List_Return;                    
                    var bien = new
                    {
                        Tuyen = TUYEN,
                        Dvvt = DVVT,
                        TuNgay = tungay,
                        DenNgay = denngay,
                        BienSo = biensoxe
                    };
                    var bb = bc.GetChiTiet(TUYEN, DVVT);
                    ViewBag.BienCuaNTX_DVVT = bien;
                    ViewBag.BienCuaNTX_DVVT1 = bb;
                    return View();
                }
            }
            return View();
        }
        #endregion
        /*=================================Xử Lý Click Events=================================*/
        #region GET BÁO CÁO SỰ KIỆN
        // ==> BÁO CÁO HOẠT ĐỘNG
        //BÁO CÁO TOÀN QUỐC
        [HttpPost]
        public string GetBaoCaoTongHopAll(string name, int thang, int nam)
        {
            return JsonConvert.SerializeObject(Get_BaoCao_ToanQuoc(name, thang, nam));
        }
        //BÁO CÁO CHO SỞ
        [HttpPost]
        public string GetBaoCaoChoSoAll(string name, int thang, int nam, int so)
        {
            return JsonConvert.SerializeObject(Get_BaoCao_So(name, thang, nam, so));
        }
        //BÁO CÁO CHO TUYẾN
        [HttpPost]
        public string GetBaoCaoChoTuyenAll(string name, int thang, int nam, int so, long tuyen)
        {
            return JsonConvert.SerializeObject(Get_BaoCao_Tuyen(name, thang, nam, so, tuyen));
        }
        //BÁO CÁO CHO ĐƠN VỊ VẬN TẢI
        [HttpPost]
        public string GetBaoCaoChoDonViVanTaiAll(string name, int thang, int nam, int so, long tuyen, int dvvt)
        {
            return JsonConvert.SerializeObject(Get_BaoCao_DVVT(name, thang, nam, so, tuyen, dvvt));
        }
        //BÁO CÁO CHO BẾN
        [HttpPost]
        public string GetBaoCaoChoBenAll(string name, int ben, string dt1, string dt2, long tuyen, int dvvt)
        {
            return JsonConvert.SerializeObject(Get_BaoCao_Ben(name, ben, dt1, dt2, tuyen, dvvt));
        }
        #endregion
        /*=================================Function Get Báo Cáo=================================*/
        #region GET BÁO CÁO LIST OBJECT
        //BÁO CÁO TOÀN QUỐC
        private List<object> Get_BaoCao_ToanQuoc(string name, int thang, int nam)
        {
            var ten = Convert.ToString(name);
            int THANG = Convert.ToInt32(thang);
            int NAM = Convert.ToInt32(nam);
            List<object> list1 = new List<object>();
            if (ten == "a")
            {
                List<sp_HD_BaoCaoTongHop_ToanQuoc_Result> list = new List<sp_HD_BaoCaoTongHop_ToanQuoc_Result>();
                list = bc.Get_BaoCaoTongHop_ToanQuoc(THANG, NAM);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        TS_IdTinh_So = item.TS_IdTinh_So,
                        TS_TenTinh = item.TS_TenTinh,
                        TyLeThucHien = item.TyLeThucHien,
                        SoChuenDangKy = item.SoChuenDangKy,
                        SoLuotKhach = item.SoLuotKhach,
                        SoLuotXuatBen = item.SoLuotXuatBen,
                        Thang = THANG,
                        Nam = NAM,
                        URL = "/BaoCaoHoatDong/BaoCaoHoatDong_So?name=a&Thang=" + THANG + "&Nam=" + NAM + "&So=" + item.TS_IdTinh_So
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "b")
            {
                List<sp_HD_BaoCaoXeKhongHoatDong_ToanQuoc_Result> list = new List<sp_HD_BaoCaoXeKhongHoatDong_ToanQuoc_Result>();
                list = bc.Get_BaoCaoXeKhongHoatDong_ToanQuoc(THANG, NAM);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        TS_IdTinh_So = item.TS_IdTinh_So,
                        TS_TenTinh = item.TS_TenTinh,
                        SoChuyenKhongThucHien = item.SoChuyenKhongThucHien,
                        SoChuenDangKy = item.SoChuenDangKy,
                        SoLuotKhach = item.SoLuotKhach,
                        TyLeKhongThucHien = item.TyLeKhongThucHien,
                        Thang = THANG,
                        Nam = NAM,
                        URL = "/BaoCaoHoatDong/BaoCaoHoatDong_So?name=b&Thang=" + THANG + "&Nam=" + NAM + "&So=" + item.TS_IdTinh_So
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "c")
            {
                List<sp_HD_BaoCaoXeChaySaiGio_ToanQuoc_Result> list = new List<sp_HD_BaoCaoXeChaySaiGio_ToanQuoc_Result>();
                list = bc.Get_BaoCaoXeChaySaiGio_ToanQuoc(THANG, NAM);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        TS_IdTinh_So = item.TS_IdTinh_So,
                        TS_TenTinh = item.TS_TenTinh,
                        SoLuotXuatBen = item.SoLuotXuatBen,
                        SoChuenDangKy = item.SoChuenDangKy,
                        SoLuotKhach = item.SoLuotKhach,
                        TyLeThucHien = item.TyLeThucHien,
                        Thang = THANG,
                        Nam = NAM,
                        URL = "/BaoCaoHoatDong/BaoCaoHoatDong_So?name=c&Thang=" + THANG + "&Nam=" + NAM + "&So=" + item.TS_IdTinh_So
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "d")
            {
                List<sp_HD_BaoCaoXeChayNhoHon70_ToanQuoc_Result> list = new List<sp_HD_BaoCaoXeChayNhoHon70_ToanQuoc_Result>();
                list = bc.Get_BaoCaoXeChayNhoHon70_ToanQuoc(THANG, NAM);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        TS_IdTinh_So = item.TS_IdTinh_So,
                        TS_TenTinh = item.TS_TenTinh,
                        SoChuyenThucHien = item.SoChuyenThucHien,
                        SoChuenDangKy = item.SoChuenDangKy,
                        SoLuotKhach = item.SoLuotKhach,
                        TyLeThucHien = item.TyLeThucHien,
                        Thang = THANG,
                        Nam = NAM,
                        URL = "/BaoCaoHoatDong/BaoCaoHoatDong_So?name=d&Thang=" + THANG + "&Nam=" + NAM + "&So=" + item.TS_IdTinh_So
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "e")
            {
                return list1;
            }
            return list1;
        }

        //BÁO CÁO CHO SỞ
        private List<object> Get_BaoCao_So(string name, int thang, int nam, int so)
        {
            var ten = Convert.ToString(name);
            int THANG = Convert.ToInt32(thang);
            int NAM = Convert.ToInt32(nam);
            int SO = Convert.ToInt32(so);
            List<object> list1 = new List<object>();
            if (ten == "a")
            {
                List<sp_HD_BaoCaoTongHop_SoGiaoThong_Result> list = new List<sp_HD_BaoCaoTongHop_SoGiaoThong_Result>();
                list = bc.Get_BaoCaoTongHop_So(THANG, NAM, SO);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                        SoChuyenKeHoach = item.SoChuyenKeHoach,
                        SoChuyenThucHien = item.SoChuyenThucHien,
                        SoLuotKhach = item.SoLuotKhach,
                        TenTuyen = item.TenTuyen,
                        TyLeXuatBen = item.TyLeXuatBen,
                        Thang = THANG,
                        Nam = NAM,
                        So = SO,
                        URL = "/BaoCaoHoatDong/BaoCaoHoatDong_Tuyen?name=a&Thang=" + THANG + "&Nam=" + NAM + "&So=" + SO + "&Tuyen=" + item.LT_IdLuongTuyen
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "b")
            {
                List<sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong_Result> list = new List<sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong_Result>();
                list = bc.Get_BaoCaoXeKhongHoatDong_So(THANG, NAM, SO);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                        SoChuyenKeHoach = item.SoChuyenKeHoach,
                        SoChuyenKhongThucHien = item.SoChuyenKhongThucHien,
                        TyLeKhongXuatBen = item.TyLeKhongXuatBen,
                        TenTuyen = item.TenTuyen,
                        Thang = THANG,
                        Nam = NAM,
                        So = SO,
                        URL = "/BaoCaoHoatDong/BaoCaoHoatDong_Tuyen?name=b&Thang=" + THANG + "&Nam=" + NAM + "&So=" + SO + "&Tuyen=" + item.LT_IdLuongTuyen
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "c")
            {
                List<sp_HD_BaoCaoXeChaySaiGio_SoGiaoThong_Result> list = new List<sp_HD_BaoCaoXeChaySaiGio_SoGiaoThong_Result>();
                list = bc.Get_BaoCaoXeChaySaiGio_So(THANG, NAM, SO);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                        SoChuyenKeHoach = item.SoChuyenKeHoach,
                        SoChuyenThucHien = item.SoChuyenThucHien,
                        SoLuotKhach = item.SoLuotKhach,
                        TenTuyen = item.TenTuyen,
                        TyLeXuatBen = item.TyLeXuatBen,
                        Thang = THANG,
                        Nam = NAM,
                        So = SO,
                        URL = "/BaoCaoHoatDong/BaoCaoHoatDong_Tuyen?name=c&Thang=" + THANG + "&Nam=" + NAM + "&So=" + SO + "&Tuyen=" + item.LT_IdLuongTuyen
                    };
                    list1.Add(ob);
                } 
                return list1;
            }
            else if (ten == "d")
            {
                List<sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong_Result> list = new List<sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong_Result>();
                list = bc.Get_BaoCaoXeChayNhoHon70_So(THANG, NAM, SO);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                        SoChuyenKeHoach = item.SoChuyenKeHoach,
                        SoChuyenThucHien = item.SoChuyenThucHien,
                        SoLuotKhach = item.SoLuotKhach,
                        TenTuyen = item.TenTuyen,
                        TyLeXuatBen = item.TyLeXuatBen,
                        Thang = THANG,
                        Nam = NAM,
                        So = SO,
                        URL = "/BaoCaoHoatDong/BaoCaoHoatDong_Tuyen?name=d&Thang=" + THANG + "&Nam=" + NAM + "&So=" + SO + "&Tuyen=" + item.LT_IdLuongTuyen
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "e")
            {
                return list1;
            }
            return list1;
        }

        //BÁO CÁO CHO TUYẾN
        private List<object> Get_BaoCao_Tuyen(string name, int thang, int nam, int so, long tuyen)
        {
            var ten = Convert.ToString(name);
            int THANG = Convert.ToInt32(thang);
            int NAM = Convert.ToInt32(nam);
            int SO = Convert.ToInt32(so);
            long TUYEN = Convert.ToInt64(tuyen);
            List<object> list1 = new List<object>();
            if (ten == "a")
            {
                List<sp_HD_BaoCaoTongHop_Tuyen_Result> list = new List<sp_HD_BaoCaoTongHop_Tuyen_Result>();
                list = bc.Get_BaoCaoTongHop_Tuyen(THANG, NAM, SO, TUYEN);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        CT_IdCongTyVT = item.CT_IdCongTyVT,
                        SoLuotKhach = item.SoLuotKhach,
                        SoLuotXuatBen = item.SoLuotXuatBen,
                        TenCongTy = item.TenCongTy,
                        TongLuotXuatBen = item.TongLuotXuatBen,
                        TyLeXuatBen = item.TyLeXuatBen,
                        Thang = THANG,
                        Nam = NAM,
                        So = SO,
                        Tuyen = TUYEN,
                        URL = "/BaoCaoHoatDong/BaoCaoHoatDong_DonViVanTai?name=a&Thang=" + THANG + "&Nam=" + NAM + "&So=" + SO + "&Tuyen=" + TUYEN + "&Dvvt=" + item.CT_IdCongTyVT
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "b")
            {
                List<sp_HD_BaoCaoXeKhongHoatDong_Tuyen_Result> list = new List<sp_HD_BaoCaoXeKhongHoatDong_Tuyen_Result>();
                list = bc.Get_BaoCaoXeKhongHoatDong_Tuyen(THANG, NAM, SO, TUYEN);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        CT_IdCongTyVT = item.CT_IdCongTyVT,
                        SoLuotKhongXuatBen = item.SoLuotKhongXuatBen,
                        SoLuotXuatBenKeHoach = item.SoLuotXuatBenKeHoach,
                        TenCongTy = item.TenCongTy,
                        TyLeKhongXuatBen = item.TyLeKhongXuatBen,
                        Thang = THANG,
                        Nam = NAM,
                        So = SO,
                        Tuyen = TUYEN,
                        URL = "/BaoCaoHoatDong/BaoCaoHoatDong_DonViVanTai?name=b&Thang=" + THANG + "&Nam=" + NAM + "&So=" + SO + "&Tuyen=" + TUYEN + "&Dvvt=" + item.CT_IdCongTyVT
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "c")
            {
                List<sp_HD_BaoCaoXeChaySaiGio_Tuyen_Result> list = new List<sp_HD_BaoCaoXeChaySaiGio_Tuyen_Result>();
                list = bc.Get_BaoCaoXeChaySaiGio_Tuyen(THANG, NAM, SO, TUYEN);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        CT_IdCongTyVT = item.CT_IdCongTyVT,
                        SoLuotKhach = item.SoLuotKhach,
                        SoLuotXuatBen = item.SoLuotXuatBen,
                        TenCongTy = item.TenCongTy,
                        TongLuotXuatBen = item.TongLuotXuatBen,
                        TyLeXuatBen = item.TyLeXuatBen,
                        Thang = THANG,
                        Nam = NAM,
                        So = SO,
                        Tuyen = TUYEN,
                        URL = "/BaoCaoHoatDong/BaoCaoHoatDong_DonViVanTai?name=c&Thang=" + THANG + "&Nam=" + NAM + "&So=" + SO + "&Tuyen=" + TUYEN + "&Dvvt=" + item.CT_IdCongTyVT
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "d")
            {
                List<Tuyen_Duoi70_Result> list = new List<Tuyen_Duoi70_Result>();
                list = bc.Get_BaoCaoXeChayNhoHon70_Tuyen(THANG, NAM, SO, TUYEN);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        CT_IdCongTyVT = item.CT_IdCongTyVT,
                        SoLuongXe = item.SoLuongXe,
                        TenCongTy = item.TenCongTy,
                        SoXeDuoi70 = item.SoXeDuoi70,
                        TyLeThucHien = item.TyLeThucHien,
                        TongLuot = item.TongLuot,
                        TongLuotVanChuyen = item.TongLuotVanChuyen,
                        Thang = THANG,
                        Nam = NAM,
                        So = SO,
                        Tuyen = TUYEN,
                        URL = "/BaoCaoHoatDong/BaoCaoHoatDong_DonViVanTai?name=d&Thang=" + THANG + "&Nam=" + NAM + "&So=" + SO + "&Tuyen=" + TUYEN + "&Dvvt=" + item.CT_IdCongTyVT
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "e")
            {
                return list1;
            }
            return list1;
        }

        //BÁO CÁO CHO ĐƠN VỊ VẬN TẢI
        private List<object> Get_BaoCao_DVVT(string name, int thang, int nam, int so, long tuyen, int dvvt)
        {
            var ten = Convert.ToString(name);
            int THANG = Convert.ToInt32(thang);
            int NAM = Convert.ToInt32(nam);
            int SO = Convert.ToInt32(so);
            long TUYEN = Convert.ToInt64(tuyen);
            int DVVT = Convert.ToInt32(dvvt);
            string sdt1 = 1 + "/" + THANG + "/" + NAM;
            string sdt2 = 30 + "/" + THANG + "/" + NAM;
            List<object> list1 = new List<object>();
            if (ten == "a")
            {
                List<sp_HD_BaoCaoTongHop_DonViVanTai_Result> list = new List<sp_HD_BaoCaoTongHop_DonViVanTai_Result>();
                list = bc.Get_BaoCaoTongHop_DVVT(THANG, NAM, SO, TUYEN, DVVT);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        SoLuotKhach = item.SoLuotKhach,
                        SoLuotXuatBen = item.SoLuotXuatBen,
                        TaiTrong = item.TaiTrong,
                        TX_BienSoXe = item.TX_BienSoXe,
                        TX_BX_TongLuotVanChuyen = item.TX_BX_TongLuotVanChuyen,
                        TX_IdXe = item.TX_IdXe,
                        TyLeVanChuyen = item.TyLeVanChuyen,
                        Thang = THANG,
                        Nam = NAM,
                        So = SO,
                        Tuyen = TUYEN,
                        dvvt = DVVT,
                        URL = "/BaoCaoHoatDong/NhatTrinhXe?tungay=" + sdt1 + "&denngay=" + sdt2 + "&biensoxe=" + item.TX_BienSoXe + "&Tuyen=" + TUYEN + "&Dvvt=" + DVVT
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "b")
            {
                List<sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai_Result> list = new List<sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai_Result>();
                list = bc.Get_BaoCaoXeKhongHoatDong_DVVT(THANG, NAM, SO, TUYEN, DVVT);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        SoLuotKhongXuatBen = item.SoLuotKhongXuatBen,
                        TaiTrong = item.TaiTrong,
                        TX_BienSoXe = item.TX_BienSoXe,
                        TX_BX_TongLuotVanChuyen = item.TX_BX_TongLuotVanChuyen,
                        TX_IdXe = item.TX_IdXe,
                        TyLeVanChuyen = item.TyLeVanChuyen,
                        Thang = THANG,
                        Nam = NAM,
                        So = SO,
                        Tuyen = TUYEN,
                        dvvt = DVVT,
                        URL = "/BaoCaoHoatDong/NhatTrinhXe?tungay=" + sdt1 + "&denngay=" + sdt2 + "&biensoxe=" + item.TX_BienSoXe + "&Tuyen=" + TUYEN + "&Dvvt=" + DVVT
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "c")
            {
                List<sp_HD_BaoCaoXeChaySaiGio_DonViVanTai_Result> list = new List<sp_HD_BaoCaoXeChaySaiGio_DonViVanTai_Result>();
                list = bc.Get_BaoCaoXeChaySaiGio_DVVT(THANG, NAM, SO, TUYEN, DVVT);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        SoLuotKhach = item.SoLuotKhach,
                        SoLuotXuatBen = item.SoLuotXuatBen,
                        TaiTrong = item.TaiTrong,
                        TX_BienSoXe = item.TX_BienSoXe,
                        TX_BX_TongLuotVanChuyen = item.TX_BX_TongLuotVanChuyen,
                        TX_IdXe = item.TX_IdXe,
                        TyLeVanChuyen = item.TyLeVanChuyen,
                        Thang = THANG,
                        Nam = NAM,
                        So = SO,
                        Tuyen = TUYEN,
                        dvvt = DVVT,
                        URL = "/BaoCaoHoatDong/NhatTrinhXe?tungay=" + sdt1 + "&denngay=" + sdt2 + "&biensoxe=" + item.TX_BienSoXe + "&Tuyen=" + TUYEN + "&Dvvt=" + DVVT
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "d")
            {
                List<sp_HD_BaoCaoXeChayNhoHon70_DonViVanTai_Result> list = new List<sp_HD_BaoCaoXeChayNhoHon70_DonViVanTai_Result>();
                list = bc.Get_BaoCaoXeChayNhoHon70_DVVT(THANG, NAM, SO, TUYEN, DVVT);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        TongSoKhach = item.TongSoKhach,
                        SoLuotXuatBen = item.SoLuotXuatBen,
                        TaiTrong = item.TaiTrong,
                        TX_BienSoXe = item.TX_BienSoXe,
                        TX_BX_TongLuotVanChuyen = item.TX_BX_TongLuotVanChuyen,
                        TX_IdXe = item.TX_IdXe,
                        TyLeVanChuyen = item.TyLeVanChuyen,
                        Thang = THANG,
                        Nam = NAM,
                        So = SO,
                        Tuyen = TUYEN,
                        dvvt = DVVT,
                        URL = "/BaoCaoHoatDong/NhatTrinhXe?tungay=" + sdt1 + "&denngay=" + sdt2 + "&biensoxe=" + item.TX_BienSoXe + "&Tuyen=" + TUYEN + "&Dvvt=" + DVVT
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "e")
            {
                return list1;
            }
            return list1;
        }

        //BÁO CÁO CHO BẾN
        private List<object> Get_BaoCao_Ben(string name, int ben, string dt1, string dt2, long tuyen, int dvvt)
        {
            var ten = Convert.ToString(name);
            int BEN = Convert.ToInt32(ben);
            long TUYEN = Convert.ToInt64(tuyen);
            int DVVT = Convert.ToInt32(dvvt);

            string D1 = Convert.ToString(dt1);
            string D2 = Convert.ToString(dt2);

            string[] DT1 = (Convert.ToString(dt1)).Split(' ');
            string[] DT2 = (Convert.ToString(dt2)).Split(' ');

            string[] DTT1 = DT1[0].Split('/');
            string[] DTT2 = DT2[0].Split('/');
            int intNgayBatDau = Convert.ToInt32(DTT1[0]);
            int intThangBatDau = Convert.ToInt32(DTT1[1]);
            int intNamBatDau = Convert.ToInt32(DTT1[2]);

            int intNgayKetThuc = Convert.ToInt32(DTT2[0]);
            int intThangKetThuc = Convert.ToInt32(DTT2[1]);
            int intNamKetThuc = Convert.ToInt32(DTT2[2]);
            List<object> list1 = new List<object>();
            if (ten == "a")
            {
                List<sp_HD_BaoCaoTongHopTaiBen_Result> list = new List<sp_HD_BaoCaoTongHopTaiBen_Result>();
                list = bc.Get_BaoCaoTongHop_Ben(BEN, D1, D2, TUYEN, DVVT);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        BienSoDi = item.BienSoDi,
                        GhiChu = item.GhiChu,
                        GioRaBen = item.GioRaBen,
                        GioXuatBenKeHoach = item.GioXuatBenKeHoach,
                        Id = item.Id,
                        IdBenDi = item.IdBenDi,
                        SoKhach = item.SoKhach,
                        TX_BienSoXe = item.TX_BienSoXe,
                        TX_IdXe = item.TX_IdXe,                       

                        Ben = BEN,
                        Tuyen = TUYEN,
                        dvvt = DVVT,

                        TuNgay = intNgayBatDau,
                        TuThang = intThangBatDau,
                        TuNam = intNamBatDau,
                        DenNgay = intNgayKetThuc,
                        DenThang = intThangKetThuc,
                        DenNam = intNamKetThuc
                        //URL = "/BaoCaoHoatDong/BaoCaoHoatDong_DonViVanTai?name=a&Thang=" + THANG + "&Nam=" + NAM + "&So=" + SO + "&Tuyen=" + TUYEN + "&Dvvt=" + item.CT_IdCongTyVT
                    };
                    list1.Add(ob);
                }
                list.OrderBy(u => u.GioRaBen);
                return list1;
            }
            else if (ten == "b")
            {
                List<sp_HD_BaoCaoXeKhongHoatDongTaiBen_Result> list = new List<sp_HD_BaoCaoXeKhongHoatDongTaiBen_Result>();
                list = bc.Get_BaoCaoXeKhongHoatDong_Ben(BEN, D1, D2, TUYEN, DVVT);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        GhiChu = item.GhiChu,
                        GioRaBen = item.GioRaBen,
                        GioXuatBenKeHoach = item.GioXuatBenKeHoach,
                        Id = item.Id,
                        IdBenDi = item.IdBenDi,
                        SoKhach = item.SoKhach,
                        TX_BienSoXe = item.TX_BienSoXe,
                        TX_IdXe = item.TX_IdXe,

                        Ben = BEN,
                        Tuyen = TUYEN,
                        dvvt = DVVT,

                        TuNgay = intNgayBatDau,
                        TuThang = intThangBatDau,
                        TuNam = intNamBatDau,
                        DenNgay = intNgayKetThuc,
                        DenThang = intThangKetThuc,
                        DenNam = intNamKetThuc
                        //URL = "/BaoCaoHoatDong/BaoCaoHoatDong_DonViVanTai?name=a&Thang=" + THANG + "&Nam=" + NAM + "&So=" + SO + "&Tuyen=" + TUYEN + "&Dvvt=" + item.CT_IdCongTyVT
                    };
                    list.OrderBy(u => u.GioRaBen);
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "c")
            {
                List<sp_HD_BaoCaoXeChaySaiGioTaiBen_Result> list = new List<sp_HD_BaoCaoXeChaySaiGioTaiBen_Result>();
                list = bc.Get_BaoCaoXeChaySaiGio_Ben(BEN, D1, D2, TUYEN, DVVT);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        BienSoDi = item.BienSoDi,
                        GhiChu = item.GhiChu,
                        GioRaBen = item.GioRaBen,
                        GioXuatBenKeHoach = item.GioXuatBenKeHoach,
                        Id = item.Id,
                        IdBenDi = item.IdBenDi,
                        SoKhach = item.SoKhach,
                        TX_BienSoXe = item.TX_BienSoXe,
                        TX_IdXe = item.TX_IdXe,

                        Ben = BEN,
                        Tuyen = TUYEN,
                        dvvt = DVVT,

                        TuNgay = intNgayBatDau,
                        TuThang = intThangBatDau,
                        TuNam = intNamBatDau,
                        DenNgay = intNgayKetThuc,
                        DenThang = intThangKetThuc,
                        DenNam = intNamKetThuc
                        //URL = "/BaoCaoHoatDong/BaoCaoHoatDong_DonViVanTai?name=a&Thang=" + THANG + "&Nam=" + NAM + "&So=" + SO + "&Tuyen=" + TUYEN + "&Dvvt=" + item.CT_IdCongTyVT
                    };
                    list.OrderBy(u => u.GioRaBen);
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "d")
            {
                return list1;
            }
            else if (ten == "e")
            {
                return list1;
            }
            return list1;
        }
        //BÁO CÁO NHẬT TRÌNH XE
        public List<object> GetNhatTrinhXe(string tungay, string denngay, string biensoxe, long idtuyen, int idcongty)
        {
            var TUNGAY = Convert.ToString(tungay);
            var DENNGAY = Convert.ToString(denngay);
            var BIENSOXE = Convert.ToString(biensoxe);
            long TUYEN = Convert.ToInt64(idtuyen);
            int DVVT = Convert.ToInt32(idcongty);
            
            List<object> list1 = new List<object>();
            List<sp_NhatTrinhTheoXe_Result> list = new List<sp_NhatTrinhTheoXe_Result>();
            list = bc.GetNhatTrinhXe(tungay, denngay, biensoxe, idtuyen, idcongty);
            foreach (var item in list)
            {
                var ob = new
                {
                    BenDi = item.BenDi,
                    BienSoDi = item.BienSoDi,
                    GhiChu = item.GhiChu,
                    GioRaBen = item.GioRaBen,
                    GioXuatBenKeHoach = item.GioXuatBenKeHoach,
                    IdBenDi = item.IdBenDi,
                    SoKhach = item.SoKhach,
                    TX_BienSoXe = item.TX_BienSoXe,
                    TX_IdXe = item.TX_IdXe,
                    TuNgay = TUNGAY,
                    DenNgay = DENNGAY,
                    BienSoXe = BIENSOXE,
                    IdTuyen = TUYEN,
                    IdCongTy = DVVT,
                };
                list1.Add(ob);
            }
            return list1;
        }        
        #endregion

        #region GET BÁO CÁO LIST OBJECT NHIỀU PARAM
        //BÁO CÁO HOẠT ĐỘNG CHO NHIỀU SỞ
        private List<object> GetBaoCaoSoNhieuSo(string name, int thang, int nam, string so)
        {
            var ten = Convert.ToString(name);
            int THANG = Convert.ToInt32(thang);
            int NAM = Convert.ToInt32(nam);
            List<object> List_TraVe = new List<object>();
            if (ten == "a")
            {
                if (so.IndexOf("-1") > -1)
                {
                    ArrayList mangso = new ArrayList(so.Split(new char[] { ',' }));
                    mangso.RemoveAt(0);
                    mangso.RemoveAt(mangso.IndexOf("-1"));
                    mangso.RemoveAt(mangso.Count - 1);
                    for (var i = 0; i < mangso.Count; i++)
                    {
                        int idso = Convert.ToInt32(mangso[i]);
                        List<sp_HD_BaoCaoTongHop_SoGiaoThong_Result> list = new List<sp_HD_BaoCaoTongHop_SoGiaoThong_Result>();
                        list = bc.Get_BaoCaoTongHop_So(THANG, NAM, idso);
                        foreach (var item in list)
                        {
                            var ob = new
                            {
                                LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                                SoChuyenKeHoach = item.SoChuyenKeHoach,
                                SoChuyenThucHien = item.SoChuyenThucHien,
                                SoLuotKhach = item.SoLuotKhach,
                                TenTuyen = item.TenTuyen,
                                TyLeXuatBen = item.TyLeXuatBen,
                                Thang = THANG,
                                Nam = NAM,
                                So = idso,
                                URL = "/BaoCaoHoatDong/BaoCaoHoatDong_Tuyen?name=a&Thang=" + THANG + "&Nam=" + NAM + "&So=" + idso + "&Tuyen=" + item.LT_IdLuongTuyen
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
                        List<sp_HD_BaoCaoTongHop_SoGiaoThong_Result> list = new List<sp_HD_BaoCaoTongHop_SoGiaoThong_Result>();
                        list = bc.Get_BaoCaoTongHop_So(THANG, NAM, idso);
                        foreach (var item in list)
                        {
                            var ob = new
                            {
                                LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                                SoChuyenKeHoach = item.SoChuyenKeHoach,
                                SoChuyenThucHien = item.SoChuyenThucHien,
                                SoLuotKhach = item.SoLuotKhach,
                                TenTuyen = item.TenTuyen,
                                TyLeXuatBen = item.TyLeXuatBen,
                                Thang = THANG,
                                Nam = NAM,
                                So = idso,
                                URL = "/BaoCaoHoatDong/BaoCaoHoatDong_Tuyen?name=a&Thang=" + THANG + "&Nam=" + NAM + "&So=" + idso + "&Tuyen=" + item.LT_IdLuongTuyen
                            };
                            List_TraVe.Add(ob);
                        }
                    }
                }
                return List_TraVe;
            }
            else if (ten == "b")
            {
                if (so.IndexOf("-1") > -1)
                {
                    ArrayList mangso = new ArrayList(so.Split(new char[] { ',' }));
                    mangso.RemoveAt(0);
                    mangso.RemoveAt(mangso.IndexOf("-1"));
                    mangso.RemoveAt(mangso.Count - 1);
                    for (var i = 0; i < mangso.Count; i++)
                    {
                        int idso = Convert.ToInt32(mangso[i]);
                        List<sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong_Result> list = new List<sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong_Result>();
                        list = bc.Get_BaoCaoXeKhongHoatDong_So(THANG, NAM, idso);
                        foreach (var item in list)
                        {
                            var ob = new
                            {
                                LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                                SoChuyenKeHoach = item.SoChuyenKeHoach,
                                SoChuyenKhongThucHien = item.SoChuyenKhongThucHien,
                                TyLeKhongXuatBen = item.TyLeKhongXuatBen,
                                TenTuyen = item.TenTuyen,
                                Thang = THANG,
                                Nam = NAM,
                                So = idso,
                                URL = "/BaoCaoHoatDong/BaoCaoHoatDong_Tuyen?name=b&Thang=" + THANG + "&Nam=" + NAM + "&So=" + idso + "&Tuyen=" + item.LT_IdLuongTuyen
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
                        List<sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong_Result> list = new List<sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong_Result>();
                        list = bc.Get_BaoCaoXeKhongHoatDong_So(THANG, NAM, idso);
                        foreach (var item in list)
                        {
                            var ob = new
                            {
                                LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                                SoChuyenKeHoach = item.SoChuyenKeHoach,
                                SoChuyenKhongThucHien = item.SoChuyenKhongThucHien,
                                TyLeKhongXuatBen = item.TyLeKhongXuatBen,
                                TenTuyen = item.TenTuyen,
                                Thang = THANG,
                                Nam = NAM,
                                So = idso,
                                URL = "/BaoCaoHoatDong/BaoCaoHoatDong_Tuyen?name=b&Thang=" + THANG + "&Nam=" + NAM + "&So=" + idso + "&Tuyen=" + item.LT_IdLuongTuyen
                            };
                            List_TraVe.Add(ob);
                        }
                    }
                }
                return List_TraVe;
            }
            else if (ten == "c")
            {
                if (so.IndexOf("-1") > -1)
                {
                    ArrayList mangso = new ArrayList(so.Split(new char[] { ',' }));
                    mangso.RemoveAt(0);
                    mangso.RemoveAt(mangso.IndexOf("-1"));
                    mangso.RemoveAt(mangso.Count - 1);
                    for (var i = 0; i < mangso.Count; i++)
                    {
                        int idso = Convert.ToInt32(mangso[i]);
                        List<sp_HD_BaoCaoXeChaySaiGio_SoGiaoThong_Result> list = new List<sp_HD_BaoCaoXeChaySaiGio_SoGiaoThong_Result>();
                        list = bc.Get_BaoCaoXeChaySaiGio_So(THANG, NAM, idso);
                        foreach (var item in list)
                        {
                            var ob = new
                            {
                                LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                                SoChuyenKeHoach = item.SoChuyenKeHoach,
                                SoChuyenThucHien = item.SoChuyenThucHien,
                                SoLuotKhach = item.SoLuotKhach,
                                TenTuyen = item.TenTuyen,
                                TyLeXuatBen = item.TyLeXuatBen,
                                Thang = THANG,
                                Nam = NAM,
                                So = idso,
                                URL = "/BaoCaoHoatDong/BaoCaoHoatDong_Tuyen?name=c&Thang=" + THANG + "&Nam=" + NAM + "&So=" + idso + "&Tuyen=" + item.LT_IdLuongTuyen
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
                        List<sp_HD_BaoCaoXeChaySaiGio_SoGiaoThong_Result> list = new List<sp_HD_BaoCaoXeChaySaiGio_SoGiaoThong_Result>();
                        list = bc.Get_BaoCaoXeChaySaiGio_So(THANG, NAM, idso);
                        foreach (var item in list)
                        {
                            var ob = new
                            {
                                LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                                SoChuyenKeHoach = item.SoChuyenKeHoach,
                                SoChuyenThucHien = item.SoChuyenThucHien,
                                SoLuotKhach = item.SoLuotKhach,
                                TenTuyen = item.TenTuyen,
                                TyLeXuatBen = item.TyLeXuatBen,
                                Thang = THANG,
                                Nam = NAM,
                                So = idso,
                                URL = "/BaoCaoHoatDong/BaoCaoHoatDong_Tuyen?name=c&Thang=" + THANG + "&Nam=" + NAM + "&So=" + idso + "&Tuyen=" + item.LT_IdLuongTuyen
                            };
                            List_TraVe.Add(ob);
                        }
                    }
                }
                return List_TraVe;
            }
            else if (ten == "d")
            {
                if (so.IndexOf("-1") > -1)
                {
                    ArrayList mangso = new ArrayList(so.Split(new char[] { ',' }));
                    mangso.RemoveAt(0);
                    mangso.RemoveAt(mangso.IndexOf("-1"));
                    mangso.RemoveAt(mangso.Count - 1);
                    for (var i = 0; i < mangso.Count; i++)
                    {
                        int idso = Convert.ToInt32(mangso[i]);
                        List<sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong_Result> list = new List<sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong_Result>();
                        list = bc.Get_BaoCaoXeChayNhoHon70_So(THANG, NAM, idso);
                        foreach (var item in list)
                        {
                            var ob = new
                            {
                                LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                                SoChuyenKeHoach = item.SoChuyenKeHoach,
                                SoChuyenThucHien = item.SoChuyenThucHien,
                                SoLuotKhach = item.SoLuotKhach,
                                TenTuyen = item.TenTuyen,
                                TyLeXuatBen = item.TyLeXuatBen,
                                Thang = THANG,
                                Nam = NAM,
                                So = idso,
                                URL = "/BaoCaoHoatDong/BaoCaoHoatDong_Tuyen?name=d&Thang=" + THANG + "&Nam=" + NAM + "&So=" + idso + "&Tuyen=" + item.LT_IdLuongTuyen
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
                        List<sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong_Result> list = new List<sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong_Result>();
                        list = bc.Get_BaoCaoXeChayNhoHon70_So(THANG, NAM, idso);
                        foreach (var item in list)
                        {
                            var ob = new
                            {
                                LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                                SoChuyenKeHoach = item.SoChuyenKeHoach,
                                SoChuyenThucHien = item.SoChuyenThucHien,
                                SoLuotKhach = item.SoLuotKhach,
                                TenTuyen = item.TenTuyen,
                                TyLeXuatBen = item.TyLeXuatBen,
                                Thang = THANG,
                                Nam = NAM,
                                So = idso,
                                URL = "/BaoCaoHoatDong/BaoCaoHoatDong_Tuyen?name=d&Thang=" + THANG + "&Nam=" + NAM + "&So=" + idso + "&Tuyen=" + item.LT_IdLuongTuyen
                            };
                            List_TraVe.Add(ob);
                        }
                    }
                }
                return List_TraVe;
            }
            else if (ten == "e")
            {
                return List_TraVe;
            }
            return List_TraVe;
        }
        #endregion
        /*=================================Function Lấy List Sở/Tuyến/Đơn Vị Vận Tải/Bến=================================*/
        #region GET LIST DANH SÁCH COMBOBOX
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
        private List<object> Get_List_Tuyen()
        {
            return bc.Get_DanhSachAll_Tuyen();
        }
        private List<object> Get_List_Tuyen_TheoSo(int idso)
        {
            return bc.Get_DanhSachAll_Tuyen_CuaSo(idso);
        }        
        private List<object> Get_List_DVVT()
        {
            List<object> list1 = new List<object>();
            var tatca = new {
                CT_IdCongTyVT = -1,
                MaCongTy = -1,
                TenCongTy = "Tất Cả",
                TS_IdTinh_So = -1
            };
            list1.Add(tatca);
            foreach (var item in bc.Get_DanhSachAll_DVVT())
            {
                var ob = new
                {
                    CT_IdCongTyVT = item.CT_IdCongTyVT,
                    MaCongTy = item.MaCongTy,
                    TenCongTy = item.TenCongTy,
                    TS_IdTinh_So = item.TS_IdTinh_So
                };
                list1.Add(ob);
            }
            return list1;
        }
        private List<object> Get_List_DVVT_TheoIDSo(int idso)
        {
            List<object> list1 = new List<object>();            
            foreach (var item in bc.LayDonViVanTaiCuaSo(idso))
            {
                var ob = new
                {
                    CT_IdCongTyVT = item.CT_IdCongTyVT,
                    MaCongTy = item.MaCongTy,
                    TenCongTy = item.TenCongTy,
                    TS_IdTinh_So = item.TS_IdTinh_So
                };
                list1.Add(ob);
            }
            return list1;
        }
        private List<object> Get_List_Ben()
        {            
            List<object> list1 = new List<object>();
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
        /*=================================Xử Lý Click Events CHO NHIỀU=================================*/
        #region CLICK CHO NHIỀU
        //LẤY HOẠT ĐỘNG SỞ NHIỀU SỞ
        [HttpPost]
        public string GetBaoCaoHoatDongSo_NhieuSo(string name, int thang, int nam, string so)
        {
            return JsonConvert.SerializeObject(GetBaoCaoSoNhieuSo(name, thang, nam, so));
        }
        #endregion
    }
}