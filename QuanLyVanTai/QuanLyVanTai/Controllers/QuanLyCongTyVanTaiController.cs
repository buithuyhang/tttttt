using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Test.Models;

namespace Test.Controllers
{
    public class QuanLyCongTyVanTaiController : Controller
    {
        // GET: QuanLyCongTyVanTai
        public ActionResult Index()
        {
            try
            {
                QLVanTai_2017 context = new QLVanTai_2017();
                var lstCongTyVanTai = context.QLVT_CongTyVanTai.Select(u => new
                {
                    u.CT_IdCongTyVT,
                    u.TenCongTy,
                    u.MaCongTy,
                    u.SoLuongXe,
                    u.DiaChi,
                    u.TS_IdTinh_So,
                    TenTinhSo = u.QLVT_ThongTinTinh_SoGiaoThong.TS_TenTinh
                }).ToList();
                ViewBag.dataGridCongTyVanTai = JsonConvert.SerializeObject(lstCongTyVanTai);

                var lstTinhSo = context.QLVT_ThongTinTinh_SoGiaoThong.Where(u => u.TS_TT_IdTrangThai == 1)
                    .Select(u => new
                    {
                        u.TS_IdTinh_So,
                        u.TS_IdMaTinh,
                        u.TS_TenTinh
                    }).ToList();

                ViewBag.lstTinhSo = JsonConvert.SerializeObject(lstTinhSo);
                
            }
            catch (Exception e)
            {
                //ViewBag.dataGridCongTyVanTai = Json(new { status = false, message = "Lấy dữ liệu thất bại." }, JsonRequestBehavior.AllowGet).ToString();
            }

            return View();
        }

        private string convertToUnSign(string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }

        [HttpPost]
        public ActionResult ThemTTCongTyVanTai(string TenCongTy, string MaCongTy, string DiaChi, string TS_IdTinh_So)
        {
            try
            {
                var context = new QLVanTai_2017();
                int intCongTyVanTai = Convert.ToInt32(MaCongTy);
                int iIdTinhSo = Convert.ToInt32(TS_IdTinh_So);
                var checkCongTyVanTai = context.QLVT_CongTyVanTai
                    .FirstOrDefault(u => (u.MaCongTy == intCongTyVanTai) || (u.TenCongTy.CompareTo(TenCongTy) == 0));

                if (checkCongTyVanTai != null && checkCongTyVanTai.TS_IdTinh_So == Convert.ToInt32(TS_IdTinh_So))
                {
                    if (Convert.ToInt32(intCongTyVanTai) == checkCongTyVanTai.MaCongTy && checkCongTyVanTai.TS_IdTinh_So != iIdTinhSo)
                    {
                        return Json(new { status = false, message = "Trùng mã bến xe" }, JsonRequestBehavior.AllowGet);
                    }
                    if (String.Compare(TenCongTy, checkCongTyVanTai.TenCongTy, StringComparison.Ordinal) == 0)
                    {
                        return Json(new { status = false, message = "Trùng tên bến xe" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {

                    var CongTyVanTai = new QLVT_CongTyVanTai()
                    {
                        TenCongTy = TenCongTy,
                        MaCongTy = Convert.ToInt32(MaCongTy),
                        SoLuongXe = 0,
                        DiaChi = DiaChi,
                        TS_IdTinh_So = Convert.ToInt32(TS_IdTinh_So),
                    };

                    context.QLVT_CongTyVanTai.Add(CongTyVanTai);
                    context.SaveChanges();
                    return Json(new { status = true, message = "Thêm thành công." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { status = false, message = "Thêm thất bại." }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public ActionResult SuaTTCongTyVanTai(string CT_IdCongTyVT, string TenCongTy, string MaCongTy, string DiaChi, string TS_IdTinh_So)
        {
            try
            {
                var context = new QLVanTai_2017();
                int MaCongTyVanTai = Convert.ToInt32(MaCongTy);
                var checkCongTyVanTai = context.QLVT_CongTyVanTai
                    .FirstOrDefault(u => (u.MaCongTy == MaCongTyVanTai) || (u.TenCongTy.CompareTo(TenCongTy) == 0));

                if (checkCongTyVanTai != null && checkCongTyVanTai.CT_IdCongTyVT != Convert.ToInt32(CT_IdCongTyVT)
                    && checkCongTyVanTai.TS_IdTinh_So == Convert.ToInt32(TS_IdTinh_So))
                {
                    if (Convert.ToInt32(MaCongTyVanTai) == checkCongTyVanTai.MaCongTy)
                    {
                        return Json(new { status = false, message = "Trùng mã bến xe" }, JsonRequestBehavior.AllowGet);
                    }
                    if (String.Compare(TenCongTy, checkCongTyVanTai.TenCongTy, StringComparison.Ordinal) == 0)
                    {
                        return Json(new { status = false, message = "Trùng tên bến xe" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    int idCongTyVanTai = Convert.ToInt32(CT_IdCongTyVT);
                    var CongTyVanTai = context.QLVT_CongTyVanTai.FirstOrDefault(u => u.CT_IdCongTyVT == idCongTyVanTai);
                    CongTyVanTai.MaCongTy = Convert.ToInt32(MaCongTy);
                    CongTyVanTai.TenCongTy = TenCongTy;
                    CongTyVanTai.DiaChi = DiaChi;
                    CongTyVanTai.TS_IdTinh_So = Convert.ToInt32(TS_IdTinh_So);

                    context.SaveChanges();
                    return Json(new { status = true, message = "Sửa thành công." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { status = false, message = "Sửa thất bại." }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpPost]
        public ActionResult GetDSCongTyVanTai()
        {
            try
            {
                QLVanTai_2017 context = new QLVanTai_2017();
                var lstCongTyVanTai = context.QLVT_CongTyVanTai.Select(u => new
                {
                    u.CT_IdCongTyVT,
                    u.TenCongTy,
                    u.MaCongTy,
                    u.SoLuongXe,
                    u.DiaChi,
                    u.TS_IdTinh_So,
                    TenTinhSo = u.QLVT_ThongTinTinh_SoGiaoThong.TS_TenTinh
                }).ToList();
                return Json(new { status = true, data = lstCongTyVanTai }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json(new { status = false, message = "Lấy dữ liệu thất bại." }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }


        [HttpPost]
        public ActionResult XoaCongTyVanTai(string idCongTy)
        {
            try
            {
                int cCongTy = Convert.ToInt32(idCongTy);
                var context = new QLVanTai_2017();
                var CongTyVT = context.QLVT_CongTyVanTai.FirstOrDefault(c => c.CT_IdCongTyVT == cCongTy);
                if (CongTyVT.SoLuongXe != 0)
                {
                    
                }
                else
                {
                    var dsCapTuyenChoDn = context.QLVT_DanhSachCapTuyenChoDN
                        .Where(c => c.CT_IdCongTyVT == CongTyVT.CT_IdCongTyVT).ToList();

                    context.QLVT_DanhSachCapTuyenChoDN.RemoveRange(dsCapTuyenChoDn);
                    context.QLVT_CongTyVanTai.Remove(CongTyVT);
                }
                context.SaveChanges();
                return Json(new { status = true, message = "Xóa thành công." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { status = false, message = "Xóa thất bại." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}