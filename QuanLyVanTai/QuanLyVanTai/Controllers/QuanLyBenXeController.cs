using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class QuanLyBenXeController : Controller
    {
        // GET: QuanLyBenXe
        public ActionResult Index()
        {
            try
            {
                QLVanTai_2017 context = new QLVanTai_2017();
                var lstBenXe = context.QLVT_ThongTinBenXe.Select(u => new
                {
                    BX_IdBenXe = u.BX_IdBenXe,
                    TenBenXe = u.TenBenXe,
                    MaBen = u.MaBen,
                    TS_IdTinh_So = u.TS_IdTinh_So,
                    TenTinhSo = u.QLVT_ThongTinTinh_SoGiaoThong.TS_TenTinh,
                    DiaChi = u.DiaChi,
                    SDT = u.SDT,
                    CoQuanQuanLy = u.CoQuanQuanLy,
                    TongDienTich = u.TongDienTich,
                    DienTich_XeKhach = u.DienTich_XeKhach,
                    DienTich_PhuongTienKhac = u.DienTich_PhuongTienKhac,
                    DienTich_NhaCho = u.DienTich_NhaCho,
                    LoaiBenXe = u.LoaiBenXe,
                    SoTuyenQuyHoach = u.SoTuyenQuyHoach,
                    SoLuotXuatBenQuyHoach = u.SoLuotXuatBenQuyHoach,
                    GhiChu = u.GhiChu,
                    TS_TT_IdTrangThai = u.TS_TT_IdTrangThai,
                    TrangThai = u.QLVT_ThongTinTinh_So_Ben_TrangThai.TS_TT_TenTrangThai
                }).ToList();
                ViewBag.dataGridBenXe = JsonConvert.SerializeObject(lstBenXe);

                var lstTinhSo = context.QLVT_ThongTinTinh_SoGiaoThong.Where(u => u.TS_TT_IdTrangThai == 1)
                    .Select(u => new
                    {
                        u.TS_IdTinh_So,
                        u.TS_IdMaTinh,
                        u.TS_TenTinh
                    }).ToList();

                ViewBag.lstTinhSo = JsonConvert.SerializeObject(lstTinhSo);

                var lstTrangThaiBenXe = context.QLVT_ThongTinTinh_So_Ben_TrangThai
                    .Select(u => new
                    {
                        u.TS_TT_IdTrangThai,
                        u.TS_TT_TenTrangThai
                    }).ToList();
                ViewBag.lstTrangThaiBenXe = JsonConvert.SerializeObject(lstTrangThaiBenXe);
            }
            catch (Exception e)
            {
                //ViewBag.dataGridBenXe = Json(new { status = false, error = "Lấy dữ liệu thất bại." }, JsonRequestBehavior.AllowGet).ToString();
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult ThemTTBenXe(string TenBenXe, string MaBen, string TS_IdTinh_So, string DiaChi,
            string SDT, string CoQuanQuanLy, string TongDienTich, string DienTich_XeKhach, string DienTich_PhuongTienKhac,
            string DienTich_NhaCho, string LoaiBenXe, string SoTuyenQuyHoach, string SoLuotXuatBenQuyHoach,
            string TS_TT_IdTrangThai, string GhiChu)
        {
            try
            {
                var context = new QLVanTai_2017();
                int intMaBen = Convert.ToInt32(MaBen);
                var checkBenXe = context.QLVT_ThongTinBenXe
                    .FirstOrDefault(u => (u.TenBenXe.CompareTo(TenBenXe) == 0));

                if (checkBenXe != null)
                {
                    //if (Convert.ToInt32(MaBen) == checkBenXe.MaBen)
                    //{
                    //    return Json(new { status = false, error = "Trùng mã bến xe" }, JsonRequestBehavior.AllowGet);
                    //}
                    if (String.Compare(TenBenXe, checkBenXe.TenBenXe, StringComparison.Ordinal) == 0)
                    {
                        return Json(new { status = false, error = "Trùng tên bến xe" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    
                    var benxe = new QLVT_ThongTinBenXe()
                    {
                        TenBenXe = TenBenXe,
                        MaBen = Convert.ToInt32(MaBen),
                        TS_IdTinh_So = Convert.ToInt32(TS_IdTinh_So),
                        DiaChi = DiaChi,
                        SDT = SDT,
                        CoQuanQuanLy = CoQuanQuanLy,
                        TongDienTich = (float)Convert.ToDouble(TongDienTich),
                        DienTich_XeKhach = (float)Convert.ToDouble(DienTich_XeKhach),
                        DienTich_PhuongTienKhac = (float)Convert.ToDouble(DienTich_PhuongTienKhac),
                        DienTich_NhaCho = (float)Convert.ToDouble(DienTich_NhaCho),
                        LoaiBenXe = Convert.ToInt32(LoaiBenXe),
                        SoTuyenQuyHoach = Convert.ToInt32(SoTuyenQuyHoach),
                        SoLuotXuatBenQuyHoach = Convert.ToInt32(SoLuotXuatBenQuyHoach),
                        GhiChu = GhiChu,
                        TS_TT_IdTrangThai = Convert.ToInt32(TS_TT_IdTrangThai)
                    };

                    context.QLVT_ThongTinBenXe.Add(benxe);
                    context.SaveChanges();
                    return Json(new { status = true, message = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { status = false, error = "Thêm thất bại" }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public ActionResult SuaTTBenXe(string BX_IdBenXe, string TenBenXe, string MaBen, string TS_IdTinh_So, string DiaChi,
            string SDT, string CoQuanQuanLy, string TongDienTich, string DienTich_XeKhach, string DienTich_PhuongTienKhac,
            string DienTich_NhaCho, string LoaiBenXe, string SoTuyenQuyHoach, string SoLuotXuatBenQuyHoach,
            string GhiChu, string TS_TT_IdTrangThai)
        {
            try
            {
                var context = new QLVanTai_2017();
                int intMaBen = Convert.ToInt32(MaBen);
                var checkBenXe = context.QLVT_ThongTinBenXe
                    .FirstOrDefault(u => (String.Compare(u.TenBenXe, TenBenXe, StringComparison.Ordinal) == 0));

                if (checkBenXe != null && Convert.ToInt32(BX_IdBenXe) != checkBenXe.BX_IdBenXe)
                {
                    //if (Convert.ToInt32(MaBen) == checkBenXe.MaBen)
                    //{
                    //    return Json(new { status = false, error = "Trùng mã bến xe" }, JsonRequestBehavior.AllowGet);
                    //}
                    if (String.Compare(TenBenXe, checkBenXe.TenBenXe, StringComparison.Ordinal) == 0)
                    {
                        return Json(new { status = false, error = "Trùng tên bến xe" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    int idBenXe = Convert.ToInt32(BX_IdBenXe);
                    var benXe = context.QLVT_ThongTinBenXe.FirstOrDefault(u => u.BX_IdBenXe == idBenXe);

                    benXe.TenBenXe = TenBenXe;
                    benXe.MaBen = Convert.ToInt32(MaBen);
                    benXe.TS_IdTinh_So = Convert.ToInt32(TS_IdTinh_So);
                    benXe.DiaChi = DiaChi;
                    benXe.SDT = SDT;
                    benXe.CoQuanQuanLy = CoQuanQuanLy;
                    benXe.TongDienTich = Convert.ToDouble(TongDienTich);
                    benXe.DienTich_XeKhach = Convert.ToDouble(DienTich_XeKhach);
                    benXe.DienTich_PhuongTienKhac = Convert.ToDouble(DienTich_PhuongTienKhac);
                    benXe.DienTich_NhaCho = Convert.ToDouble(DienTich_NhaCho);
                    benXe.LoaiBenXe = Convert.ToInt32(LoaiBenXe);
                    benXe.SoTuyenQuyHoach = Convert.ToInt32(SoTuyenQuyHoach);
                    benXe.SoLuotXuatBenQuyHoach = Convert.ToInt32(SoLuotXuatBenQuyHoach);
                    benXe.GhiChu = GhiChu;
                    benXe.TS_TT_IdTrangThai = Convert.ToInt32(TS_TT_IdTrangThai);

                    context.SaveChanges();
                    return Json(new { status = true, message = "Sửa thành công." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { status = false, error = "Sửa thất bại." }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = true }, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public ActionResult XoaTTBenXe(string id)
        //{
        //    if (true)
        //    {
        //        return Json(new { status = true, error = "Mật khẩu không đúng" }, JsonRequestBehavior.AllowGet);
        //    }

        //    return Json(new { status = true }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public ActionResult KhoiPhucTTBenXe(string id)
        //{
        //    return Json(new { status = true }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public ActionResult GetDSKhoiPhucBenXe()
        //{
        //    List<dynamic> lstGrid = new List<dynamic>();
        //    dynamic temp = new
        //    {
        //        maBenXe = "BX20",
        //        tenBenXe = "TT TP Nam Định",
        //        tenTinhSo = "Nam Định",
        //        diaChi = "Nam Định",
        //        sdt = "02566712133"
        //    };
        //    lstGrid.Add(temp);

        //    temp = new
        //    {
        //        maBenXe = "BX20",
        //        tenBenXe = "Tuyên Quang",
        //        tenTinhSo = "Tuyên Quang",
        //        diaChi = "Tuyên Quang",
        //        sdt = "02566712133"
        //    };
        //    lstGrid.Add(temp);


        //    return Json(new { status = true, data = lstGrid }, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult GetDSBenXe()
        {
            try
            {
                QLVanTai_2017 context = new QLVanTai_2017();
                var lstBenXe = context.QLVT_ThongTinBenXe.Select(u => new
                {
                    BX_IdBenXe = u.BX_IdBenXe,
                    TenBenXe = u.TenBenXe,
                    MaBen = u.MaBen,
                    TS_IdTinh_So = u.TS_IdTinh_So,
                    TenTinhSo = u.QLVT_ThongTinTinh_SoGiaoThong.TS_TenTinh,
                    DiaChi = u.DiaChi,
                    SDT = u.SDT,
                    CoQuanQuanLy = u.CoQuanQuanLy,
                    TongDienTich = u.TongDienTich,
                    DienTich_XeKhach = u.DienTich_XeKhach,
                    DienTich_PhuongTienKhac = u.DienTich_PhuongTienKhac,
                    DienTich_NhaCho = u.DienTich_NhaCho,
                    LoaiBenXe = u.LoaiBenXe,
                    SoTuyenQuyHoach = u.SoTuyenQuyHoach,
                    SoLuotXuatBenQuyHoach = u.SoLuotXuatBenQuyHoach,
                    GhiChu = u.GhiChu,
                    TS_TT_IdTrangThai = u.TS_TT_IdTrangThai,
                    TrangThai = u.QLVT_ThongTinTinh_So_Ben_TrangThai.TS_TT_TenTrangThai
                }).ToList();
                return Json(new { status = true, data = lstBenXe }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json(new { status = false, error = "Lấy dữ liệu thất bại." }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}