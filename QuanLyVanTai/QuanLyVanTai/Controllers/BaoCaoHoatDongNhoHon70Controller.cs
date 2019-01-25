using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class BaoCaoHoatDongNhoHon70Controller : Controller
    {
        GetBaoCaoHD getBC = new GetBaoCaoHD();
        // GET: BaoCaoHoatDongNhoHon70
        public ActionResult BaoCaoToanQuoc()
        {
            QLVanTai_2017 en = new QLVanTai_2017();

            int Id_So = 55; // mặc định
            // lấy danh sách sở
            List<QLVT_ThongTinTinh_SoGiaoThong> lstSo = en.QLVT_ThongTinTinh_SoGiaoThong.ToList();
            ViewBag.lstSo = lstSo;

            // lấy danh sách tuyến
            var lstTuyen = en.GetThongTinTuyen_IdSo(Id_So).ToList();
            ViewBag.lstTuyen = lstTuyen;

            // lấy báo cáo
            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;
            var lstBCSoDuoi70 = en.sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong(thang, nam, Id_So);
            ViewBag.dataGrid = lstBCSoDuoi70;

            // khởi tạo mặc định
            dynamic dataDefault = new
            {
                Id_So,
                thang,
                nam,
            };
            ViewBag.dataDefault = dataDefault;

            return View();
        }

        #region [Báo cáo Sở]

        /// <summary>
        /// Báo cáo mặc định
        /// </summary>
        /// <returns></returns>
        public ActionResult BaoCaoTaiSo()
        {
            QLVanTai_2017 en = new QLVanTai_2017();

            int Id_So = 55; // mặc định
                            // lấy danh sách sở
            var lstSo = en.QLVT_ThongTinTinh_SoGiaoThong
                .Select(s => new
                {
                    s.TS_IdTinh_So,
                    s.TS_TenTinh
                }).ToList();
            ViewBag.lstSo = lstSo;

            // lấy danh sách tuyến
            var lstTuyen = en.GetThongTinTuyen_IdSo(Id_So).ToList();
            lstTuyen.Insert(0, new GetThongTinTuyen_IdSo_Result { LT_IdLuongTuyen = -1, TenTuyenn = "Tất cả" });
            ViewBag.lstTuyen = lstTuyen;

            // lấy báo cáo
            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;
            try
            {
                var lstBCSoDuoi70 = en.sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong(thang, nam, Id_So).ToList();
                ViewBag.dataGrid = lstBCSoDuoi70;
            }
            catch (Exception ex)
            {
                string ss = ex.ToString();
            }


            // khởi tạo mặc định
            dynamic dataDefault = new
            {
                Id_So,
                thang,
                nam,
            };
            ViewBag.dataDefault = dataDefault;
            return View();
        }

        [HttpPost]
        public JsonResult GetBaoCaoSo(int? Id_So, string lstTuyen,string Thang)
        {
            lstTuyen = ","+lstTuyen + ",";
            string[] strNam = Thang.Split('/');
            int thang = Convert.ToInt32(strNam[0]);
            int nam = Convert.ToInt32(strNam[1]);
            try
            {
                QLVanTai_2017 en = new QLVanTai_2017();
                var lstBCSoDuoi70 = en.sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong_NhieuTuyen(thang, nam, Id_So,lstTuyen).ToList();
              return Json(new { status = true, message = "Đang tải dữ liệu.",data = lstBCSoDuoi70 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "Thất bại.", data = "" }, JsonRequestBehavior.AllowGet);
            }
            
        }

        #endregion

        public ActionResult BaoCaoTrenTuyen()
        {
            return View();
        }

    }
}