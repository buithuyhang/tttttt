using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Services;
using Newtonsoft.Json.Linq;
using Test.Models;

namespace Test.Controllers
{
    public class QuanLyTinh_SoController : Controller
    {
        // GET: QuanLyTinh_So
        public ActionResult Index()
        {
            try
            {
                using (var context = new QLVanTai_2017())
                {
                    var lstTinhSoDangHoatDong = context.QLVT_ThongTinTinh_SoGiaoThong.Where(u => u.TS_TT_IdTrangThai != null)
                        .Where(c => c.TS_TT_IdTrangThai == 1)
                        .Select(c =>
                       new
                       {
                           c.TS_IdTinh_So,
                           c.TS_IdMaTinh,
                           c.TS_TenTinh,
                           c.TS_TT_IdTrangThai,
                           c.SoDienThoai,
                           c.GiamDocSo,
                           c.Email,
                           c.QLVT_ThongTinTinh_So_Ben_TrangThai.TS_TT_TenTrangThai
                       }).ToList();

                    var lstTinhSoNgungHoatDong = context.QLVT_ThongTinTinh_SoGiaoThong.Where(u => u.TS_TT_IdTrangThai != null)
                        .Where(c => c.TS_TT_IdTrangThai == 2)
                        .Select(c =>
                            new
                            {
                                c.TS_IdTinh_So,
                                c.TS_IdMaTinh,
                                c.TS_TenTinh,
                                c.TS_TT_IdTrangThai,
                                c.SoDienThoai,
                                c.GiamDocSo,
                                c.Email,
                                c.QLVT_ThongTinTinh_So_Ben_TrangThai.TS_TT_TenTrangThai
                            }).ToList();

                    var lstTinhSoNgungHoatDongTamThoi = context.QLVT_ThongTinTinh_SoGiaoThong.Where(u => u.TS_TT_IdTrangThai != null)
                        .Where(c => c.TS_TT_IdTrangThai == 3)
                        .Select(c =>
                            new
                            {
                                c.TS_IdTinh_So,
                                c.TS_IdMaTinh,
                                c.TS_TenTinh,
                                c.TS_TT_IdTrangThai,
                                c.SoDienThoai,
                                c.GiamDocSo,
                                c.Email,
                                c.QLVT_ThongTinTinh_So_Ben_TrangThai.TS_TT_TenTrangThai
                            }).ToList();

                    var jsonLstTinhSo = new
                    {
                        TinhSoDangHoatDong = lstTinhSoDangHoatDong,
                        TinhSoNgungHoatDong = lstTinhSoNgungHoatDong,
                        TinhSoNgungHoatDongTamThoi = lstTinhSoNgungHoatDongTamThoi
                    };

                    ViewBag.dataGrid = JsonConvert.SerializeObject(jsonLstTinhSo);



                    var lstTrangThaiTinhSo = context.QLVT_ThongTinTinh_So_Ben_TrangThai.Select(c => new
                    {
                        c.TS_TT_IdTrangThai,
                        c.TS_TT_TenTrangThai
                    }).ToList();
                    ViewBag.lstTrangThaiTinhSo = JsonConvert.SerializeObject(lstTrangThaiTinhSo);
                }
            }
            catch (Exception e)
            {
                ViewBag.dataGrid = Json(new { status = false, error = "Lấy dữ liệu thất bại." }, JsonRequestBehavior.AllowGet).ToString();
            }


            return View();
        }

        //private string convertToUnSign(string s)
        //{
        //    string stFormD = s.Normalize(NormalizationForm.FormD);
        //    StringBuilder sb = new StringBuilder();
        //    for (int ich = 0; ich < stFormD.Length; ich++)
        //    {
        //        System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
        //        if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
        //        {
        //            sb.Append(stFormD[ich]);
        //        }
        //    }
        //    sb = sb.Replace('Đ', 'D');
        //    sb = sb.Replace('đ', 'd');
        //    return (sb.ToString().Normalize(NormalizationForm.FormD));
        //}

        [HttpPost]
        public ActionResult ThemTTTinhSo(string maTinh, string tenTinh, string trangThai, string giamDoc
            , string sdt, string email)
        {
            try
            {
                var context = new QLVanTai_2017();
                int intMaTinh = Convert.ToInt32(maTinh);
                var checkTinhSo = context.QLVT_ThongTinTinh_SoGiaoThong
                    .FirstOrDefault(u => (u.TS_IdMaTinh == intMaTinh) || (u.TS_TenTinh == tenTinh));

                if (checkTinhSo != null)
                {
                    if (Convert.ToInt32(maTinh) == checkTinhSo.TS_IdMaTinh)
                    {
                        return Json(new { status = false, error = "Trùng mã tỉnh" }, JsonRequestBehavior.AllowGet);
                    }
                    if (String.Compare(tenTinh, checkTinhSo.TS_TenTinh, StringComparison.Ordinal) == 0)
                    {
                        return Json(new { status = false, error = "Trùng tên tỉnh" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var tinhSo = new QLVT_ThongTinTinh_SoGiaoThong
                    {
                        TS_IdMaTinh = Convert.ToInt32(maTinh),
                        TS_TenTinh = tenTinh,
                        TS_TT_IdTrangThai = Convert.ToInt32(trangThai),
                        GiamDocSo = giamDoc,
                        SoDienThoai = sdt,
                        Email = email
                    };

                    context.QLVT_ThongTinTinh_SoGiaoThong.Add(tinhSo);
                    context.SaveChanges();
                    return Json(new { status = true, message = "Thêm thành công." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { status = false, error = "Thêm thất bại." }, JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpPost]
        public ActionResult SuaTTTinhSo(string idTinhSo, string maTinh, string tenTinh, string trangThai, string giamDoc
            , string sdt, string email)
        {
            //Chua check pass
            try
            {
                var context = new QLVanTai_2017();
                int intMaTinh = Convert.ToInt32(maTinh);
                var checkTinhSo = context.QLVT_ThongTinTinh_SoGiaoThong
                    .FirstOrDefault(u => u.TS_IdMaTinh == intMaTinh || u.TS_TenTinh == tenTinh);

                if (checkTinhSo != null && checkTinhSo.TS_IdTinh_So != Convert.ToInt32(idTinhSo))
                {
                    if (Convert.ToInt32(maTinh) == checkTinhSo.TS_IdMaTinh)
                    {
                        return Json(new { status = false, error = "Trùng mã tỉnh" }, JsonRequestBehavior.AllowGet);
                    }
                    if (String.Compare(tenTinh, checkTinhSo.TS_TenTinh, StringComparison.Ordinal) == 0)
                    {
                        return Json(new { status = false, error = "Trùng tên tỉnh" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    int intIdTinhSo = Convert.ToInt32(idTinhSo);
                    var tinhSo = context.QLVT_ThongTinTinh_SoGiaoThong.FirstOrDefault(u =>
                            u.TS_IdTinh_So == intIdTinhSo);

                    tinhSo.TS_IdMaTinh = Convert.ToInt32(maTinh);
                    tinhSo.TS_TenTinh = tenTinh;
                    tinhSo.TS_TT_IdTrangThai = Convert.ToInt32(trangThai);
                    tinhSo.GiamDocSo = giamDoc;
                    tinhSo.SoDienThoai = sdt;
                    tinhSo.Email = email;
                    context.SaveChanges();
                    return Json(new { status = true, message = "Sửa thành công." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { status = false, error = "Sửa thất bại." }, JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpPost]
        public ActionResult XoaTinhSo(string idTinhSo)
        {
            try
            {
                int cTinhSo = Convert.ToInt32(idTinhSo);
                var context = new QLVanTai_2017();
                var TinhSo = context.QLVT_ThongTinTinh_SoGiaoThong.FirstOrDefault(c => c.TS_IdTinh_So == cTinhSo);
                context.QLVT_ThongTinTinh_SoGiaoThong.Remove(TinhSo);
                context.SaveChanges();
                return Json(new { status = true, message = "Xóa thành công." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { status = false, message = "Xóa thất bại." }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetDSTinhSo()
        {
            try
            {
                var context = new QLVanTai_2017();

                var lstTinhSoDangHoatDong = context.QLVT_ThongTinTinh_SoGiaoThong.Where(u => u.TS_TT_IdTrangThai != null)
                        .Where(c => c.TS_TT_IdTrangThai == 1)
                        .Select(c =>
                       new
                       {
                           c.TS_IdTinh_So,
                           c.TS_IdMaTinh,
                           c.TS_TenTinh,
                           c.TS_TT_IdTrangThai,
                           c.SoDienThoai,
                           c.GiamDocSo,
                           c.Email,
                           c.QLVT_ThongTinTinh_So_Ben_TrangThai.TS_TT_TenTrangThai
                       }).ToList();

                var lstTinhSoNgungHoatDong = context.QLVT_ThongTinTinh_SoGiaoThong.Where(u => u.TS_TT_IdTrangThai != null)
                    .Where(c => c.TS_TT_IdTrangThai == 2)
                    .Select(c =>
                        new
                        {
                            c.TS_IdTinh_So,
                            c.TS_IdMaTinh,
                            c.TS_TenTinh,
                            c.TS_TT_IdTrangThai,
                            c.SoDienThoai,
                            c.GiamDocSo,
                            c.Email,
                            c.QLVT_ThongTinTinh_So_Ben_TrangThai.TS_TT_TenTrangThai
                        }).ToList();

                var lstTinhSoNgungHoatDongTamThoi = context.QLVT_ThongTinTinh_SoGiaoThong.Where(u => u.TS_TT_IdTrangThai != null)
                    .Where(c => c.TS_TT_IdTrangThai == 3)
                    .Select(c =>
                        new
                        {
                            c.TS_IdTinh_So,
                            c.TS_IdMaTinh,
                            c.TS_TenTinh,
                            c.TS_TT_IdTrangThai,
                            c.SoDienThoai,
                            c.GiamDocSo,
                            c.Email,
                            c.QLVT_ThongTinTinh_So_Ben_TrangThai.TS_TT_TenTrangThai
                        }).ToList();

                return Json(new
                {
                    status = true,
                    TinhSoDangHoatDong = lstTinhSoDangHoatDong,
                    TinhSoNgungHoatDong = lstTinhSoNgungHoatDong,
                    TinhSoNgungHoatDongTamThoi = lstTinhSoNgungHoatDongTamThoi
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { status = false, error = "Lấy danh sách thất bại." }, JsonRequestBehavior.AllowGet);
            }


        }
    }
}