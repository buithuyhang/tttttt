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
    public class QuanLyLuongTuyenController : Controller
    {
        // GET: LuongTuyen
        public ActionResult Index()
        {
            try
            {
                QLVanTai_2017 context = new QLVanTai_2017();
                //var lstLuongTuyen = context.QLVT_LuongTuyen.Select(u => new
                //{
                //    LT_IdLuongTuyen = u.LT_IdLuongTuyen,
                //    LT_MaTuyen = u.LT_MaTuyen,
                //    LT_HanhTrinhChay = u.LT_HanhTrinhChay,
                //    LT_CuLy = u.LT_CuLy,
                //    LT_LuuLuongQuyDinh = u.LT_LuuLuongQuyDinh,
                //    TT_IdTrangThaiTuyen = u.TT_IdTrangThaiTuyen,
                //    TrangThaiTuyen = u.QLVT_LuongTuyen_TrangThai.TT_TenTrangThai,
                //    LT_PL_IdLuongTuyen = u.LT_PL_IdLuongTuyen,
                //    PhanLoaiLuongTuyen = u.QLVT_LuongTuyen_PhanLoai.LT_PL_TenLoai,
                //    LT_DC_IdLuongTuyen = u.LT_DC_IdLuongTuyen,
                //    LT_DC_IdBen_01 = u.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01,
                //    LT_DC_IdBen_02 = u.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02,
                //    LT_DC_TenBen_01 = u.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01,
                //    LT_DC_TenBen_02 = u.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02,
                //    IdTinhSoDi = context.QLVT_ThongTinBenXe.FirstOrDefault(c => c.BX_IdBenXe == u.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01).TS_IdTinh_So,
                //    IdTinhSoDen = context.QLVT_ThongTinBenXe.FirstOrDefault(c => c.BX_IdBenXe == u.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02).TS_IdTinh_So,
                //}).ToList();

                var lstLuongTuyen = context.QLVT_CapTuyenChoTinh_So.Where(u => (u.TS_IdTinh_So == 55) || (u.TS_IdTinh_So == 55)).Select(c =>
                new {
                    c.QLVT_LuongTuyen.LT_IdLuongTuyen,
                    c.QLVT_LuongTuyen.LT_MaTuyen,
                    c.QLVT_LuongTuyen.LT_HanhTrinhChay,
                    c.QLVT_LuongTuyen.LT_CuLy,
                    c.QLVT_LuongTuyen.LT_LuuLuongQuyDinh,
                    c.QLVT_LuongTuyen.TT_IdTrangThaiTuyen,
                    c.QLVT_LuongTuyen.QLVT_LuongTuyen_TrangThai.TT_TenTrangThai,
                    c.QLVT_LuongTuyen.LT_PL_IdLuongTuyen,
                    c.QLVT_LuongTuyen.QLVT_LuongTuyen_PhanLoai.LT_PL_TenLoai,
                    c.QLVT_LuongTuyen.LT_DC_IdLuongTuyen,
                    c.QLVT_LuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01,
                    c.QLVT_LuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02,
                    c.QLVT_LuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01,
                    c.QLVT_LuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02,
                    IdTinhSoDi = context.QLVT_ThongTinBenXe.FirstOrDefault(d => d.BX_IdBenXe == c.QLVT_LuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01).TS_IdTinh_So,
                    IdTinhSoDen = context.QLVT_ThongTinBenXe.FirstOrDefault(d => d.BX_IdBenXe == c.QLVT_LuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02).TS_IdTinh_So,
                }).ToList();
                ViewBag.dataGridLuongTuyen = JsonConvert.SerializeObject(lstLuongTuyen);

                var lstTinhSoLuongTuyen = context.QLVT_ThongTinTinh_SoGiaoThong
                    .Where(u => u.TS_TT_IdTrangThai == 1)
                    .Select(u => new
                    {
                        u.TS_IdTinh_So,
                        u.TS_TenTinh
                    }).ToList();
                ViewBag.lstTinhSoLuongTuyen = JsonConvert.SerializeObject(lstTinhSoLuongTuyen);

                var lstTrangThaiLuongTuyen = context.QLVT_LuongTuyen_TrangThai
                    .Select(u => new
                    {
                        u.TT_IdTrangThaiTuyen,
                        u.TT_TenTrangThai
                    }).ToList();

                ViewBag.lstTrangThaiLuongTuyen = JsonConvert.SerializeObject(lstTrangThaiLuongTuyen);

                //var lstPhanLoaiLuongTuyen = context.QLVT_LuongTuyen_PhanLoai
                //    .Select(u => new
                //    {
                //        u.LT_PL_IdLuongTuyen,
                //        u.LT_PL_TenLoai
                //    }).ToList();
                //ViewBag.lstPhanLoaiLuongTuyen = JsonConvert.SerializeObject(lstPhanLoaiLuongTuyen);
            }
            catch (Exception e)
            {
                //ViewBag.dataGridLuongTuyen = Json(new { status = false, error = "Lấy dữ liệu không thành công." }, JsonRequestBehavior.AllowGet).ToString();
            }

            return View();
        }

        [HttpPost]
        public ActionResult ThemTTLuongTuyen(string benDi, string benDen, string maTuyen,
            string hanhTrinhChay, string cuLy, string luuLuong, string idTrangThai,
            string idPhanLoai)
        {
            try
            {
                var context = new QLVanTai_2017();
                var checkLuongTuyen = context.QLVT_LuongTuyen
                    .FirstOrDefault(u => (u.LT_HanhTrinhChay.CompareTo(hanhTrinhChay) == 0) || u.LT_MaTuyen.CompareTo(maTuyen) == 0);

                if (checkLuongTuyen != null)
                {
                    if (checkLuongTuyen.LT_HanhTrinhChay.CompareTo(hanhTrinhChay) == 0)
                    {
                        return Json(new { status = false, error = "Hành trình chạy đã tồn tại" }, JsonRequestBehavior.AllowGet);
                    }
                    if (checkLuongTuyen.LT_MaTuyen.CompareTo(maTuyen) == 0)
                    {
                        return Json(new { status = false, error = "Mã tuyến đã tồn tại" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    int idBenDi = Convert.ToInt32(benDi);
                    int idBenDen = Convert.ToInt32(benDen);

                    var diemDauCuoi = context.QLVT_LuongTuyen_DiemDauCuoi
                        .FirstOrDefault(u => u.LT_DC_IdBen_01 == idBenDi && u.LT_DC_IdBen_02 == idBenDen);
                    if (diemDauCuoi == null)
                    {
                        var objDiemCuoi = new QLVT_LuongTuyen_DiemDauCuoi()
                        {
                            LT_DC_IdBen_01 = idBenDi,
                            LT_DC_IdBen_02 = idBenDen,
                            LT_DC_TenBen_01 = context.QLVT_ThongTinBenXe.FirstOrDefault(u => u.BX_IdBenXe == idBenDi)
                                .TenBenXe,
                            LT_DC_TenBen_02 = context.QLVT_ThongTinBenXe.FirstOrDefault(u => u.BX_IdBenXe == idBenDen)
                                .TenBenXe,
                            LT_DC_TT_IdTrangThai = 1,
                        };

                        context.QLVT_LuongTuyen_DiemDauCuoi.Add(objDiemCuoi);
                        context.SaveChanges();

                        diemDauCuoi = context.QLVT_LuongTuyen_DiemDauCuoi
                            .FirstOrDefault(u => u.LT_DC_IdBen_01 == idBenDi && u.LT_DC_IdBen_02 == idBenDen);
                    }

                    var LuongTuyen = new QLVT_LuongTuyen()
                    {
                        LT_MaTuyen = maTuyen,
                        LT_HanhTrinhChay = hanhTrinhChay,
                        LT_CuLy = Convert.ToInt32(cuLy),
                        LT_LuuLuongQuyDinh = Convert.ToInt32(luuLuong),
                        TT_IdTrangThaiTuyen = Convert.ToInt32(idTrangThai),
                        LT_PL_IdLuongTuyen = Convert.ToInt32(idPhanLoai),
                        LT_DC_IdLuongTuyen = diemDauCuoi.LT_DC_IdLuongTuyen
                    };
                    context.QLVT_LuongTuyen.Add(LuongTuyen);
                    context.SaveChanges();

                    var TinhSo1 = context.QLVT_ThongTinBenXe
                        .FirstOrDefault(c => c.BX_IdBenXe == LuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01)
                        .TS_IdTinh_So;
                    var TinhSo2 = context.QLVT_ThongTinBenXe
                        .FirstOrDefault(c => c.BX_IdBenXe == LuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02)
                        .TS_IdTinh_So;

                    var CapTuyen1 = new QLVT_CapTuyenChoTinh_So()
                    {
                        LT_IdLuongTuyen = LuongTuyen.LT_IdLuongTuyen,
                        TS_IdTinh_So = TinhSo1
                    };

                    var CapTuyen2 = new QLVT_CapTuyenChoTinh_So()
                    {
                        LT_IdLuongTuyen = LuongTuyen.LT_IdLuongTuyen,
                        TS_IdTinh_So = TinhSo2
                    };

                    context.QLVT_CapTuyenChoTinh_So.Add(CapTuyen1);
                    if (CapTuyen1.TS_IdTinh_So != CapTuyen2.TS_IdTinh_So)
                    {
                        context.QLVT_CapTuyenChoTinh_So.Add(CapTuyen2);
                    }

                    context.SaveChanges();
                    return Json(new { status = true, message = "Thêm thành công." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { status = false, error = "Thêm không thành công." }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SuaTTLuongTuyen(string idLuongTuyen, string benDi, string benDen, string maTuyen,
            string hanhTrinhChay, string cuLy, string luuLuong, string idTrangThai,
            string idPhanLoai)
        {
//            return Json(new { status = false, error = "Sửa đang bảo trì." }, JsonRequestBehavior.AllowGet);

            try
            {
                var context = new QLVanTai_2017();
                long lIdLuongTuyen = Convert.ToInt64(idLuongTuyen);
                var checkLuongTuyen = context.QLVT_LuongTuyen
                    .FirstOrDefault(u => (u.LT_HanhTrinhChay.CompareTo(hanhTrinhChay) == 0) || u.LT_MaTuyen.CompareTo(maTuyen) == 0);

                if (checkLuongTuyen != null && checkLuongTuyen.LT_IdLuongTuyen != lIdLuongTuyen)
                {
                    if (checkLuongTuyen.LT_HanhTrinhChay.CompareTo(hanhTrinhChay) == 0)
                    {
                        return Json(new { status = false, error = "Hành trình chạy đã tồn tại" }, JsonRequestBehavior.AllowGet);
                    }
                    if (checkLuongTuyen.LT_MaTuyen.CompareTo(maTuyen) == 0)
                    {
                        return Json(new { status = false, error = "Mã tuyến đã tồn tại" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    int idBenDi = Convert.ToInt32(benDi);
                    int idBenDen = Convert.ToInt32(benDen);

                    var diemDauCuoi = context.QLVT_LuongTuyen_DiemDauCuoi
                        .FirstOrDefault(u => u.LT_DC_IdBen_01 == idBenDi && u.LT_DC_IdBen_02 == idBenDen);
                    if (diemDauCuoi == null)
                    {
                        diemDauCuoi = new QLVT_LuongTuyen_DiemDauCuoi()
                        {
                            LT_DC_IdBen_01 = idBenDi,
                            LT_DC_IdBen_02 = idBenDen,
                            LT_DC_TenBen_01 = context.QLVT_ThongTinBenXe.FirstOrDefault(u => u.BX_IdBenXe == idBenDi)
                                .TenBenXe,
                            LT_DC_TenBen_02 = context.QLVT_ThongTinBenXe.FirstOrDefault(u => u.BX_IdBenXe == idBenDen)
                                .TenBenXe,
                            LT_DC_TT_IdTrangThai = 1,
                        };

                        context.QLVT_LuongTuyen_DiemDauCuoi.Add(diemDauCuoi);
                        context.SaveChanges();

                    }
                    var objLuongTuyen = context.QLVT_LuongTuyen.FirstOrDefault(i => i.LT_IdLuongTuyen == lIdLuongTuyen);
                    
                    if (objLuongTuyen != null)
                    {
                        var idDCLuongTuyen = objLuongTuyen.LT_DC_IdLuongTuyen;

                        objLuongTuyen.LT_MaTuyen = maTuyen;
                        objLuongTuyen.LT_HanhTrinhChay = hanhTrinhChay;
                        objLuongTuyen.LT_CuLy = Convert.ToInt32(cuLy);
                        objLuongTuyen.LT_LuuLuongQuyDinh = Convert.ToInt32(luuLuong);
                        objLuongTuyen.TT_IdTrangThaiTuyen = Convert.ToInt32(idTrangThai);
                        objLuongTuyen.LT_PL_IdLuongTuyen = Convert.ToInt32(idPhanLoai);
                        objLuongTuyen.LT_DC_IdLuongTuyen = diemDauCuoi.LT_DC_IdLuongTuyen;


                        if (idDCLuongTuyen != diemDauCuoi.LT_DC_IdLuongTuyen)
                        {
                            ///
                            var TinhSo1 = context.QLVT_ThongTinBenXe
                                .FirstOrDefault(c => c.BX_IdBenXe == objLuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01)
                                .TS_IdTinh_So;
                            var TinhSo2 = context.QLVT_ThongTinBenXe
                                .FirstOrDefault(c => c.BX_IdBenXe == objLuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02)
                                .TS_IdTinh_So;

                            var CapTuyen1 = context.QLVT_CapTuyenChoTinh_So.FirstOrDefault(c =>
                                c.QLVT_LuongTuyen.LT_DC_IdLuongTuyen == objLuongTuyen.LT_IdLuongTuyen && c.TS_IdTinh_So == TinhSo1);

                            var CapTuyen2 = context.QLVT_CapTuyenChoTinh_So.FirstOrDefault(c =>
                                c.QLVT_LuongTuyen.LT_DC_IdLuongTuyen == objLuongTuyen.LT_IdLuongTuyen && c.TS_IdTinh_So == TinhSo2);

                            if (TinhSo1 == TinhSo2 && CapTuyen1!=CapTuyen2 && CapTuyen2!=null)
                            {
                                context.QLVT_CapTuyenChoTinh_So.Remove(CapTuyen2);
                                CapTuyen1.TS_IdTinh_So = TinhSo1;
                            }

                            if (TinhSo1 != TinhSo2)
                            {
                                if (CapTuyen1 == null)
                                {
                                    CapTuyen1 = new QLVT_CapTuyenChoTinh_So
                                    {
                                        TS_IdTinh_So = TinhSo1,
                                        LT_IdLuongTuyen = objLuongTuyen.LT_IdLuongTuyen
                                    };
                                    context.QLVT_CapTuyenChoTinh_So.Add(CapTuyen1);
                                }

                                if (CapTuyen2 == null)
                                {
                                    CapTuyen2 = new QLVT_CapTuyenChoTinh_So
                                    {
                                        TS_IdTinh_So = TinhSo2,
                                        LT_IdLuongTuyen = objLuongTuyen.LT_IdLuongTuyen
                                    };
                                    context.QLVT_CapTuyenChoTinh_So.Add(CapTuyen2);
                                }
                            }
                        }

                        context.SaveChanges();

                        return Json(new { status = true, message = "Sửa thành công." }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { status = false, error = "Sửa thất bại." }, JsonRequestBehavior.AllowGet);
                    }

                }
            }
            catch (Exception e)
            {
                return Json(new { status = false, error = "Sửa thất bại." }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
        
        [HttpPost]
        public ActionResult GetLstBenXe(string TS_IdTinh_So)
        {
            try
            {
                var context = new QLVanTai_2017();
                int idTinhSo = Convert.ToInt32(TS_IdTinh_So);
                var lstBenXe = context.QLVT_ThongTinBenXe
                    .Where(c => c.TS_IdTinh_So == idTinhSo)
                    .Select(u => new
                    {
                        u.BX_IdBenXe,
                        u.TenBenXe
                    }).ToArray();
                if (lstBenXe.Length == 0)
                {
                    var notFound = new List<dynamic>();
                    notFound.Add(new { BX_IdBenXe = -1, TenBenXe = "Không có" });
                    return Json(new { status = true, data = notFound }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { status = true, data = lstBenXe }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { status = true, error = "Lấy danh sách bến thất bại" }, JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpPost]
        public ActionResult GetDSLuongTuyen(string idTinhSo)
        {
            int iIdTinhSoDi = Convert.ToInt32(idTinhSo);
            try
            {
                QLVanTai_2017 context = new QLVanTai_2017();
                var lstLuongTuyen = context.QLVT_CapTuyenChoTinh_So.Where(u => u.TS_IdTinh_So == iIdTinhSoDi).Select(c =>
                new {
                    c.QLVT_LuongTuyen.LT_IdLuongTuyen,
                    c.QLVT_LuongTuyen.LT_MaTuyen,
                    c.QLVT_LuongTuyen.LT_HanhTrinhChay,
                    c.QLVT_LuongTuyen.LT_CuLy,
                    c.QLVT_LuongTuyen.LT_LuuLuongQuyDinh,
                    c.QLVT_LuongTuyen.TT_IdTrangThaiTuyen,
                    c.QLVT_LuongTuyen.QLVT_LuongTuyen_TrangThai.TT_TenTrangThai,
                    c.QLVT_LuongTuyen.LT_PL_IdLuongTuyen,
                    c.QLVT_LuongTuyen.QLVT_LuongTuyen_PhanLoai.LT_PL_TenLoai,
                    c.QLVT_LuongTuyen.LT_DC_IdLuongTuyen,
                    c.QLVT_LuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01,
                    c.QLVT_LuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02,
                    c.QLVT_LuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01,
                    c.QLVT_LuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02,
                    IdTinhSoDi = context.QLVT_ThongTinBenXe.FirstOrDefault(d => d.BX_IdBenXe == c.QLVT_LuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01).TS_IdTinh_So,
                    IdTinhSoDen = context.QLVT_ThongTinBenXe.FirstOrDefault(d => d.BX_IdBenXe == c.QLVT_LuongTuyen.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02).TS_IdTinh_So,
                }).ToList();
                //var lstLuongTuyen = context.QLVT_LuongTuyen.Select(u => new
                //{
                //    LT_IdLuongTuyen = u.LT_IdLuongTuyen,
                //    LT_MaTuyen = u.LT_MaTuyen,
                //    LT_HanhTrinhChay = u.LT_HanhTrinhChay,
                //    LT_CuLy = u.LT_CuLy,
                //    LT_LuuLuongQuyDinh = u.LT_LuuLuongQuyDinh,
                //    TT_IdTrangThaiTuyen = u.TT_IdTrangThaiTuyen,
                //    TrangThaiTuyen = u.QLVT_LuongTuyen_TrangThai.TT_TenTrangThai,
                //    LT_PL_IdLuongTuyen = u.LT_PL_IdLuongTuyen,
                //    PhanLoaiLuongTuyen = u.QLVT_LuongTuyen_PhanLoai.LT_PL_TenLoai,
                //    LT_DC_IdLuongTuyen = u.LT_DC_IdLuongTuyen,
                //    LT_DC_IdBen_01 = u.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01,
                //    LT_DC_IdBen_02 = u.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02,
                //    LT_DC_TenBen_01 = u.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01,
                //    LT_DC_TenBen_02 = u.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02,
                //    IdTinhSoDi = context.QLVT_ThongTinBenXe.FirstOrDefault(c => c.BX_IdBenXe == u.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01).TS_IdTinh_So,
                //    IdTinhSoDen = context.QLVT_ThongTinBenXe.FirstOrDefault(c => c.BX_IdBenXe == u.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02).TS_IdTinh_So,
                //}).ToList();
                return Json(new { status = true, data = lstLuongTuyen }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json(new { status = false, error = "Lấy dữ liệu thất bại" }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}