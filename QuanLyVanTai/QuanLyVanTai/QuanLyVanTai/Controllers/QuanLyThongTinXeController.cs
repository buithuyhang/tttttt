using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Test.Models;

namespace Test.Controllers
{
    public class QuanLyThongTinXeController : Controller
    {
        // GET: QuanLyThongTin
        public ActionResult Index()
        {
            try
            {
                var context = new QLVanTai_2017();
                var lstThongTinXe = context.QLVT_ThongTinXe_beta.Select(u => new
                {
                    u.TX_IdXe,
                    u.QLVT_ThongTinXe.TX_BienSoXe,
                    u.QLVT_ThongTinXe.TX_MaSoXe,
                    u.QLVT_ThongTinXe.TS_IdTinh_So,
                    //context.QLVT_ThongTinTinh_SoGiaoThong.FirstOrDefault(c => c.TS_IdTinh_So == u.QLVT_ThongTinXe.TS_IdTinh_So),//u.QLVT_CongTyVanTai.QLVT_ThongTinTinh_SoGiaoThong.TS_TenTinh,
                    u.QLVT_ThongTinXe.CT_IdCongTyVT,
                    u.QLVT_ThongTinXe.QLVT_CongTyVanTai.TenCongTy,
                    u.QLVT_ThongTinXe.TX_TT_IdTrangThaiXe,
                    u.QLVT_ThongTinXe.QLVT_ThongTinXe_TrangThaiXe.TX_TT_IdTenTrangThai,
                    u.TX_BX_SoGiuong,
                    u.TX_BX_SoGhe,
                    u.TX_BX_TongLuotVanChuyen,
                    TX_GioXuatBen = u.TX_GioXuatBen,
                    u.QLVT_ThongTinXe.LT_IdLuongTuyen,
                    TenTuyen = context.QLVT_LuongTuyen.FirstOrDefault(c => c.LT_IdLuongTuyen == u.QLVT_ThongTinXe.LT_IdLuongTuyen).QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01
                     + " - " + context.QLVT_LuongTuyen.FirstOrDefault(c => c.LT_IdLuongTuyen == u.QLVT_ThongTinXe.LT_IdLuongTuyen).QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02,
                }).ToList();
                ViewBag.lstThongTinXe = JsonConvert.SerializeObject(lstThongTinXe);

                var lstTrangThaiThongTinXe = context.QLVT_ThongTinXe_TrangThaiXe
                    .Select(c => new
                    {
                        c.TX_TT_IdTrangThaiXe,
                        c.TX_TT_IdTenTrangThai
                    }).ToList();
                ViewBag.lstTrangThaiThongTinXe = JsonConvert.SerializeObject(lstTrangThaiThongTinXe);

                var lstLuongTuyenThongTinXe = context.QLVT_LuongTuyen
                    .Select(c => new
                    {
                        c.LT_IdLuongTuyen,
                        TenTuyen = c.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01 + " - " +
                                   c.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02
                    }).ToList();
                ViewBag.lstLuongTuyenThongTinXe = JsonConvert.SerializeObject(lstLuongTuyenThongTinXe);

                var lstCongTyVanTaiThongTinXe = context.QLVT_CongTyVanTai
                    .Select(c => new
                    {
                        c.CT_IdCongTyVT,
                        c.TenCongTy
                    }).ToList();
                ViewBag.lstCongTyVanTaiThongTinXe = JsonConvert.SerializeObject(lstCongTyVanTaiThongTinXe);

            }
            catch (Exception e)
            {
                //ViewBag.dataGridLuongTuyen = Json(new { status = false, error = "Lấy dữ liệu không thành công." }, JsonRequestBehavior.AllowGet).ToString();
            }

            return View();
        }

        [HttpPost]
        public ActionResult ThemThongTinXe(string TX_MaSoXe, string TX_BienSoXe
            , string CT_IdCongTyVT, string soGhe, string soGiuong, string gioXuatBen
            , string tongLuotVanChuyen, string TX_TT_IdTrangThaiXe, string LT_IdLuongTuyen)
        {
            try
            {
                var context = new QLVanTai_2017();
                int maSoXe = Convert.ToInt32(TX_MaSoXe);
                var checkThongTinXe = context.QLVT_ThongTinXe
                    .FirstOrDefault(u => u.TX_MaSoXe == maSoXe || u.TX_BienSoXe.CompareTo(TX_BienSoXe) == 0);

                if (checkThongTinXe != null)
                {
                    if (checkThongTinXe.TX_MaSoXe == maSoXe)
                    {
                        return Json(new { status = false, error = "Mã số xe đã tồn tại" }, JsonRequestBehavior.AllowGet);
                    }
                    if (checkThongTinXe.TX_BienSoXe.CompareTo(TX_BienSoXe) == 0)
                    {
                        return Json(new { status = false, error = "Biển số xe đã tồn tại" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {

                    var ThongTinXe = new QLVT_ThongTinXe()
                    {
                        TX_MaSoXe = Convert.ToInt32(TX_MaSoXe),
                        TX_BienSoXe = TX_BienSoXe,
                        //TS_IdTinh_So = Convert.ToInt32(TS_IdTinh_So),
                        CT_IdCongTyVT = Convert.ToInt32(CT_IdCongTyVT),
                        TX_TT_IdTrangThaiXe = Convert.ToInt32(TX_TT_IdTrangThaiXe),
                        LT_IdLuongTuyen = Convert.ToInt64(LT_IdLuongTuyen),

                    };
                    context.QLVT_ThongTinXe.Add(ThongTinXe);
                    context.SaveChanges();

                    var ThongTinXeBeta = new QLVT_ThongTinXe_beta()
                    {
                        TX_IdXe = ThongTinXe.TX_IdXe,
                        TX_BX_TongLuotVanChuyen = Convert.ToInt32(tongLuotVanChuyen),
                        TX_GioXuatBen = gioXuatBen,
                        TX_BX_SoGhe = Convert.ToInt32(soGhe) != 0 ? Convert.ToInt32(soGhe) : 0,
                        TX_BX_SoGiuong = Convert.ToInt32(soGiuong) != 0 ? Convert.ToInt32(soGiuong) : 0
                    };

                    context.QLVT_ThongTinXe_beta.Add(ThongTinXeBeta);
                    context.SaveChanges();

                    int IdCongTyVanTai = Convert.ToInt32(CT_IdCongTyVT);
                    var CongTyVanTai = context.QLVT_CongTyVanTai.FirstOrDefault(u => u.CT_IdCongTyVT == IdCongTyVanTai);
                    CongTyVanTai.SoLuongXe++;
                    context.SaveChanges();
                    
                    //Cấp tuyến cho DN
                    long idLuongTuyen = Convert.ToInt64(LT_IdLuongTuyen);
                    var checkCapTuyen = context.QLVT_DanhSachCapTuyenChoDN.FirstOrDefault(c =>
                        c.LT_IdLuongTuyen == idLuongTuyen && c.CT_IdCongTyVT == IdCongTyVanTai);
                    if (checkCapTuyen == null)
                    {
                        var CapTuyen = new QLVT_DanhSachCapTuyenChoDN
                        {
                            CT_IdCongTyVT = IdCongTyVanTai,
                            LT_IdLuongTuyen = idLuongTuyen
                        };

                        context.QLVT_DanhSachCapTuyenChoDN.Add(CapTuyen);
                        context.SaveChanges();
                    }

                    return Json(new { status = true, message = "Thêm thành công." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { status = false, error = "Thêm không thành công." }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpPost]
        public ActionResult SuaThongTinXe(string idXe, string TX_MaSoXe, string TX_BienSoXe
            , string CT_IdCongTyVT, string soGhe, string soGiuong, string gioXuatBen
            , string tongLuotVanChuyen, string TX_TT_IdTrangThaiXe, string LT_IdLuongTuyen)
        {
            try
            {
                var context = new QLVanTai_2017();
                int intIdXe = Convert.ToInt32(idXe);
                int maSoXe = Convert.ToInt32(TX_MaSoXe);
                var checkThongTinXe = context.QLVT_ThongTinXe
                    .FirstOrDefault(u => (u.TX_MaSoXe == maSoXe || u.TX_BienSoXe.CompareTo(TX_BienSoXe) == 0)
                    && u.TX_IdXe != intIdXe);

                if (checkThongTinXe != null)
                {
                    if (checkThongTinXe.TX_MaSoXe == maSoXe)
                    {
                        return Json(new { status = false, error = "Mã số xe đã tồn tại" }, JsonRequestBehavior.AllowGet);
                    }
                    if (checkThongTinXe.TX_BienSoXe.CompareTo(TX_BienSoXe) == 0)
                    {
                        return Json(new { status = false, error = "Biển số xe đã tồn tại" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var ThongTinXe = context.QLVT_ThongTinXe.FirstOrDefault(c => c.TX_IdXe == intIdXe);
                    int idCongTyVTCu = Convert.ToInt32(ThongTinXe.CT_IdCongTyVT);
                    int idCongTyVTMoi = Convert.ToInt32(CT_IdCongTyVT);


                    //Khi đổi DN
                    if (idCongTyVTMoi != idCongTyVTCu)
                    {
                        var CongTyVanTaiCu = context.QLVT_CongTyVanTai.FirstOrDefault(u => u.CT_IdCongTyVT == ThongTinXe.CT_IdCongTyVT);
                        if (CongTyVanTaiCu != null)
                        {
                            CongTyVanTaiCu.SoLuongXe--;
                        }
                        else
                        {
                            return Json(new { status = false, error = "Thêm không thành công." }, JsonRequestBehavior.AllowGet);
                        }

                        var CongTyVanTaiMoi = context.QLVT_CongTyVanTai.FirstOrDefault(u => u.CT_IdCongTyVT == idCongTyVTMoi);
                        if (CongTyVanTaiMoi != null)
                        {
                            CongTyVanTaiMoi.SoLuongXe++;
                        }
                        else
                        {
                            return Json(new { status = false, error = "Thêm không thành công." }, JsonRequestBehavior.AllowGet);
                        }

                        //Xóa tuyến cũ nếu trong CTy VT ko còn xe chạy trong tuyến
                        int countXe = CongTyVanTaiCu.QLVT_ThongTinXe.Count(c => c.LT_IdLuongTuyen == ThongTinXe.LT_IdLuongTuyen);
                        if (countXe <= 1)
                        {
                            var capTuyen = context.QLVT_DanhSachCapTuyenChoDN.FirstOrDefault(c =>
                                c.LT_IdLuongTuyen == ThongTinXe.LT_IdLuongTuyen);
                            context.QLVT_DanhSachCapTuyenChoDN.Remove(capTuyen);
                            context.SaveChanges();
                        }

                        //Cấp tuyến mới khi đổi DN
                        long idLuongTuyen = Convert.ToInt64(LT_IdLuongTuyen);
                        var checkCapTuyen = context.QLVT_DanhSachCapTuyenChoDN.FirstOrDefault(c =>
                            c.LT_IdLuongTuyen == idLuongTuyen && c.CT_IdCongTyVT == CongTyVanTaiMoi.CT_IdCongTyVT);
                        if (checkCapTuyen == null)
                        {
                            var CapTuyen = new QLVT_DanhSachCapTuyenChoDN
                            {
                                CT_IdCongTyVT = CongTyVanTaiMoi.CT_IdCongTyVT,
                                LT_IdLuongTuyen = idLuongTuyen
                            };

                            context.QLVT_DanhSachCapTuyenChoDN.Add(CapTuyen);
                            context.SaveChanges();
                        }

                    }

                    long idTuyenCu = ThongTinXe.LT_IdLuongTuyen;
                    long idTuyenMoi = Convert.ToInt64(LT_IdLuongTuyen);

                    ThongTinXe.TX_MaSoXe = Convert.ToInt32(TX_MaSoXe);
                    ThongTinXe.TX_BienSoXe = TX_BienSoXe;
                    //TS_IdTinh_So = Convert.ToInt32(TS_IdTinh_So);
                    ThongTinXe.CT_IdCongTyVT = Convert.ToInt32(CT_IdCongTyVT);
                    ThongTinXe.TX_TT_IdTrangThaiXe = Convert.ToInt32(TX_TT_IdTrangThaiXe);
                    ThongTinXe.LT_IdLuongTuyen = idTuyenMoi;

                    var ThongTinXeBeta = context.QLVT_ThongTinXe_beta.FirstOrDefault(c => c.TX_IdXe == intIdXe);
                    ThongTinXeBeta.TX_BX_TongLuotVanChuyen = Convert.ToInt32(tongLuotVanChuyen);
                    ThongTinXeBeta.TX_GioXuatBen = gioXuatBen;
                    ThongTinXeBeta.TX_BX_SoGhe = Convert.ToInt32(soGhe) != 0 ? Convert.ToInt32(soGhe) : 0;
                    ThongTinXeBeta.TX_BX_SoGiuong = Convert.ToInt32(soGiuong) != 0 ? Convert.ToInt32(soGiuong) : 0;
                    
                    context.SaveChanges();

                    //Update tuyến
                    if (idTuyenCu != idTuyenMoi)
                    {
                        var updateTuyen =
                            context.QLVT_DanhSachCapTuyenChoDN.FirstOrDefault(c =>
                                c.CT_IdCongTyVT == ThongTinXe.CT_IdCongTyVT);
                        updateTuyen.LT_IdLuongTuyen = idTuyenMoi;
                    }
                    
                    return Json(new { status = true, message = "Thêm thành công." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { status = false, error = "Thêm không thành công." }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpPost]
        public ActionResult xoaThongTinXe(string idXe)
        {
            try
            {
                var context = new QLVanTai_2017();
                int iIdXe = Convert.ToInt32(idXe);
                var Xe = context.QLVT_ThongTinXe.FirstOrDefault(c => c.TX_IdXe == iIdXe);
                var Xe_beta = context.QLVT_ThongTinXe_beta.FirstOrDefault(c => c.TX_IdXe == Xe.TX_IdXe);
                context.QLVT_ThongTinXe_beta.Remove(Xe_beta);
                context.QLVT_ThongTinXe.Remove(Xe);
                context.SaveChanges();
                return Json(new { status = true, error = "Xóa thành công." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { status = false, error = "Xóa thất bại." }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetDSThongTinXe()
        {
            try
            {
                var context = new QLVanTai_2017();
                var lstThongTinXe = context.QLVT_ThongTinXe_beta.Select(u => new
                {
                    u.TX_IdXe,
                    u.QLVT_ThongTinXe.TX_BienSoXe,
                    u.QLVT_ThongTinXe.TX_MaSoXe,
                    u.QLVT_ThongTinXe.TS_IdTinh_So,
                    //context.QLVT_ThongTinTinh_SoGiaoThong.FirstOrDefault(c => c.TS_IdTinh_So == u.QLVT_ThongTinXe.TS_IdTinh_So),//u.QLVT_CongTyVanTai.QLVT_ThongTinTinh_SoGiaoThong.TS_TenTinh,
                    u.QLVT_ThongTinXe.CT_IdCongTyVT,
                    u.QLVT_ThongTinXe.QLVT_CongTyVanTai.TenCongTy,
                    u.QLVT_ThongTinXe.TX_TT_IdTrangThaiXe,
                    u.QLVT_ThongTinXe.QLVT_ThongTinXe_TrangThaiXe.TX_TT_IdTenTrangThai,
                    u.TX_BX_SoGiuong,
                    u.TX_BX_SoGhe,
                    u.TX_BX_TongLuotVanChuyen,
                    TX_GioXuatBen = u.TX_GioXuatBen,
                    u.QLVT_ThongTinXe.LT_IdLuongTuyen,
                    TenTuyen = context.QLVT_LuongTuyen_DiemDauCuoi.FirstOrDefault(c => c.LT_DC_IdLuongTuyen == u.QLVT_ThongTinXe.LT_IdLuongTuyen).LT_DC_TenBen_01
                               + " - " + context.QLVT_LuongTuyen_DiemDauCuoi.FirstOrDefault(c => c.LT_DC_IdLuongTuyen == u.QLVT_ThongTinXe.LT_IdLuongTuyen).LT_DC_TenBen_02,
                }).ToList();
                return Json(new { status = true, data = lstThongTinXe }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json(new { status = false, error = "Lấy dữ liệu không thành công." }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}