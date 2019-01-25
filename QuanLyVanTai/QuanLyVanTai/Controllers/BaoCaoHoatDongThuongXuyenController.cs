using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class BaoCaoHoatDongThuongXuyenController : Controller
    {
        GetBaoCaoHD bc = new GetBaoCaoHD();
        // GET: BaoCaoHoatDongThuongXuyen
        #region METHOD
        public ActionResult Index()
        {
            int SO = 55;
            int ngay_hientai = Convert.ToInt32(DateTime.Now.Day);
            int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
            int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
            string dt = ngay_hientai + "/" + thang_hientai + "/" + nam_hientai;
            int BEN = bc.Get_DanhSachBenXe_CuaSoGiaoThong(SO).FirstOrDefault().BX_IdBenXe;
            List<object> List_Return = new List<object>();
            List_Return = ListHoatDongThuongXuyen(dt, SO, BEN);
            string tenben = bc.Get_ThongTinBenXe_TheoId(BEN).TenBenXe;
            var bien = new
            {
                Ben = BEN,
                TenBen = tenben,
                Dt1 = dt,
                Dt2 = dt,
                Ngay = ngay_hientai,
                Thang = thang_hientai,
                Nam = nam_hientai,
                So = SO,
                URL = Url.Action("BaoCaoHoatDongBenChiTiet", "BaoCaoHoatDong") + "?So=" + SO + "&Ben=" + BEN + "&Ngay=" + dt 
            };
            ViewBag.List_So = bc.Get_DanhSachAll_So_KhongChon(); ;//Get_List_So();
            ViewBag.List_Ben = Get_List_Ben_TheoIDSo(SO);
            ViewBag.BaoCaoHoatDongThuongXuyen = List_Return;
            ViewBag.BienCuaBen = bien;
            return View();
        }
        #endregion
        //=======================================================================================================================//
        #region LIST
        //GET LIST HOẠT ĐỘNG THƯỜNG XUYÊN
        private List<object> ListHoatDongThuongXuyen(string ngay, int so, int ben)
        {
            string NGAY = Convert.ToString(ngay);
            int SO = Convert.ToInt32(so);
            int BEN = Convert.ToInt32(ben);
            List<object> List_Return = new List<object>();
            List<sp_BaoCaoHoatDongThuongXuyen_Result> list = new List<sp_BaoCaoHoatDongThuongXuyen_Result>();
            list = bc.Get_BaoCaoHoatDongThuongXuyen(NGAY, BEN);
            foreach (var item in list)
            {
                var ob = new
                {
                    BenDen = item.BenDen,
                    LT_CuLy = item.LT_CuLy,
                    LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                    LT_MaTuyen = item.LT_MaTuyen,
                    SoChuyenDangKy = item.SoChuyenDangKy,
                    SoDonVi = item.SoDonVi,
                    SoLuotXuatBen = item.SoLuotXuatBen,
                    SoXe = item.SoXe,
                    TenTuyen = item.TenTuyen,
                    So = SO,
                    Ben = BEN,
                    KiTu = "&#35;",
                    URL = Url.Action("BaoCaoHoatDong_Tuyen", "BaoCaoHoatDong") + "?name=a&Tu=" + NGAY + "&Den=" + NGAY + "&So=" + SO + "&Ben=" + BEN + "&Tuyen=" + item.LT_IdLuongTuyen,
                    URL1 = "GetChiTietTuyen(event)",
                    URL2 = "GetDanhSachDonViVanTai(event)",
                    URL3 = "GetDanhSachThongTinXe(event)",
                };
                List_Return.Add(ob);
            };
            return List_Return;
        }
        //GET LIST ĐƠN VỊ VẬN TẢI
        private List<object> ListHoatDongThuongXuyen_DonViVanTai(string ngay, int so, int ben, long tuyen)
        {
            string NGAY = Convert.ToString(ngay);
            int SO = Convert.ToInt32(so);
            int BEN = Convert.ToInt32(ben);
            long TUYEN = Convert.ToInt64(tuyen);
            List<object> List_Return = new List<object>();
            List<sp_BaoCaoHoatDongThuongXuyen_DanhSachDonVi_Result> list = new List<sp_BaoCaoHoatDongThuongXuyen_DanhSachDonVi_Result>();
            list = bc.Get_BaoCaoHoatDongThuongXuyen_DonViVanTai(NGAY, BEN, TUYEN);            
            foreach (var item in list)
            {
                int IdDonVi = Convert.ToInt32(item.CT_IdCongTyVT);
                string TenDonVi = bc.Get_ThongTinDVVT_TheoIdDVVT(IdDonVi).TenCongTy;
                var ob = new
                {
                    CT_IdCongTyVT = item.CT_IdCongTyVT,
                    TenCongTy = TenDonVi,
                    SoChuyen = item.SoChuyen,
                    SoLuotXuatBen = item.SoLuotXuatBen,
                    SoXe = item.SoXe,
                    So = SO,
                    Ben = BEN,
                    Tuyen = TUYEN,
                    URL = Url.Action("BaoCaoHoatDong_DonViVanTai", "BaoCaoHoatDong") + "?idSo=" + SO + "&idBen=" + BEN + "&idDonVi=" + IdDonVi + "&idTuyen=" + TUYEN + "&dateBatDau=" + NGAY + "&dateKetThuc=" + NGAY
                };
                List_Return.Add(ob);
            };
            return List_Return;
        }
        //GET LIST THÔNG TIN XE
        private List<object> ListHoatDongThuongXuyen_ThongTinXe(string ngay, int so, int ben, long tuyen)
        {
            string NGAY = Convert.ToString(ngay);
            int SO = Convert.ToInt32(so);
            int BEN = Convert.ToInt32(ben);
            long TUYEN = Convert.ToInt64(tuyen);
            List<object> List_Return = new List<object>();
            List<sp_BaoCaoHoatDongThuongXuyen_DanhSachXe_Result> list = new List<sp_BaoCaoHoatDongThuongXuyen_DanhSachXe_Result>();
            list = bc.Get_BaoCaoHoatDongThuongXuyen_ThongTinXe(NGAY, BEN, TUYEN);

            foreach (var item in list)
            {
                var ob = new
                {
                    TX_IdXe = item.TX_IdXe,
                    TX_BienSoXe = item.TX_BienSoXe,
                    SoChuyen = item.SoChuyen,
                    SoLuotXuatBen = item.SoLuotXuatBen,
                    So = SO,
                    Ben = BEN,
                    Tuyen = TUYEN,
                    CT_IdCongTyVT = item.CT_IdCongTyVT,
                    TenCongTy = item.TenCongTy
                };
                List_Return.Add(ob);
            };
            return List_Return;
        }
        #endregion
        //=======================================================================================================================//
        #region EVENTS
        //EVENT CLICK
        [HttpPost]
        public string EventClickBaoCaoHoatDongThuongXuyen(string dt, int So, int Ben)
        {
            int SO = Convert.ToInt32(So);
            int BEN = Convert.ToInt32(Ben);
            string DT = Convert.ToString(dt);
            string[] Ngay = DT.Split('/');
            string tenben = bc.Get_ThongTinBenXe_TheoId(BEN).TenBenXe;
            var bien = new
            {
                Ben = BEN,
                TenBen = tenben,
                Dt1 = dt,
                Dt2 = dt,
                Ngay = Ngay[0],
                Thang = Ngay[1],
                Nam = Ngay[2],
                So = SO,
                URL = Url.Action("BaoCaoHoatDongBenChiTiet", "BaoCaoHoatDong") + "?So=" + SO + "&Ben=" + BEN + "&Ngay=" + dt
            };
            List<object> List_TraVe = new List<object>();
            List_TraVe = ListHoatDongThuongXuyen(DT, SO, BEN);
            var ooo = new
            {
                List_TraVe = List_TraVe,
                Bien = bien
            };
            return JsonConvert.SerializeObject(ooo);
        }
        //EVENT CLICK ROW GRID
        [HttpPost]
        public string EventClickRowBaoCaoHoatDongThuongXuyen_ChiTietTuyen(long IdTuyen)
        {
            long TUYEN = Convert.ToInt64(IdTuyen);
            return JsonConvert.SerializeObject(ChiTietTuyen_TheoId(TUYEN));
        }
        //EVENT CLICK SỐ ĐƠN VỊ VẬN TẢI
        [HttpPost]
        public string EventClickBaoCaoHoatDongThuongXuyen_DonViVanTai(string dt, int So, int Ben, long Tuyen)
        {
            int SO = Convert.ToInt32(So);
            int BEN = Convert.ToInt32(Ben);
            long TUYEN = Convert.ToInt64(Tuyen);
            string DT = Convert.ToString(dt);
            string[] Ngay = DT.Split('/');
            string tenben = bc.Get_ThongTinBenXe_TheoId(BEN).TenBenXe;
            var bien = new
            {
                Tuyen = TUYEN,
                Ben = BEN,
                So = SO,
                TenBen = tenben,
                Dt1 = dt,
                Dt2 = dt,
                Ngay = Ngay[0],
                Thang = Ngay[1],
                Nam = Ngay[2]                
            };
            List<object> List_TraVe = new List<object>();
            List_TraVe = ListHoatDongThuongXuyen_DonViVanTai(DT, SO, BEN, TUYEN);
            var ooo = new
            {
                List_TraVe = List_TraVe,
                Bien = bien
            };
            return JsonConvert.SerializeObject(ooo);            
        }
        //EVENT CLICK SỐ XE
        [HttpPost] 
        public string EventClickBaoCaoHoatDongThuongXuyen_ThongTinXe(string dt, int So, int Ben, long Tuyen)
        {
            int SO = Convert.ToInt32(So);
            int BEN = Convert.ToInt32(Ben);
            long TUYEN = Convert.ToInt64(Tuyen);
            string DT = Convert.ToString(dt);
            string[] Ngay = DT.Split('/');
            string tenben = bc.Get_ThongTinBenXe_TheoId(BEN).TenBenXe;
            var bien = new
            {
                Tuyen = TUYEN,
                Ben = BEN,
                So = SO,
                TenBen = tenben,
                Dt1 = dt,
                Dt2 = dt,
                Ngay = Ngay[0],
                Thang = Ngay[1],
                Nam = Ngay[2]
            };
            List<object> List_TraVe = new List<object>();
            List_TraVe = ListHoatDongThuongXuyen_ThongTinXe(DT, SO, BEN, TUYEN);
            var ooo = new
            {
                List_TraVe = List_TraVe,
                Bien = bien
            };
            return JsonConvert.SerializeObject(ooo);
        }
        #endregion
        //=======================================================================================================================//
        #region LIST COMBOBOX
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
        private List<object> Get_List_Ben_TheoIDSo(int idso)
        {
            List<object> list1 = new List<object>();
            List<QLVT_ThongTinBenXe> qlbx = bc.Get_DanhSachBenXe_CuaSoGiaoThong(idso);
            foreach (var item in qlbx)
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
        //=======================================================================================================================//
        #region INFORMATION OF OBJECT FROM ID
        private object ChiTietTuyen_TheoId(long idtuyen)
        {
            return bc.Get_ThongTinTuyen_TheoId(idtuyen);
        }
        #endregion
    }
}