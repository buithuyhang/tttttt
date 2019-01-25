using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class BaoCaoKhongThucHienController : Controller
    {
        /*=================================Function Lấy List Sở/Tuyến/Đơn Vị Vận Tải/Bến=================================*/
        #region [Dùng chung]
        private List<object> Get_List_So()
        {
            GetBaoCaoHD bc = new GetBaoCaoHD();
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
            GetBaoCaoHD bc = new GetBaoCaoHD();
            return bc.Get_DanhSachAll_Tuyen();
        }
        private List<object> Get_List_Tuyen_TheoBen(int idBen)
        {
            QLVanTai_2017 dbc = new QLVanTai_2017();
            var LstBenXe = (from lt in dbc.QLVT_LuongTuyen
                            where lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01 == idBen || lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02 == idBen
                            select new
                            {
                                LT_MaTuyen = lt.LT_MaTuyen,
                                LT_DC_IdBen_01 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_01,
                                LT_DC_IdBen_02 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_IdBen_02,
                                LT_DC_TenBen_01 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_01,
                                LT_DC_TenBen_02 = lt.QLVT_LuongTuyen_DiemDauCuoi.LT_DC_TenBen_02,
                                LT_IdLuongTuyen = lt.LT_IdLuongTuyen
                            }).ToList();
            LstBenXe.GroupBy(u => u.LT_IdLuongTuyen);

            List<object> LstReturn = new List<object>();
            foreach (var item in LstBenXe)
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
                LstReturn.Add(ob);
            };

            return LstReturn;
        }
        private List<object> Get_List_DVVT()
        {
            GetBaoCaoHD bc = new GetBaoCaoHD();
            List<object> list1 = new List<object>();
            var tatca = new
            {
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
            GetBaoCaoHD bc = new GetBaoCaoHD();
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
        private List<object> Get_List_DVVT_TheoIDTuyen(long idtuyen)
        {
            GetBaoCaoHD bc = new GetBaoCaoHD();
            return bc.Get_DanhSachCongTyVanTai_TrenTuyen_TheoIdTuyen(idtuyen);
        }
        private List<object> Get_List_Ben()
        {
            GetBaoCaoHD bc = new GetBaoCaoHD();
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
        private List<object> Get_List_Ben_TheoIDSo(int idso)
        {
            GetBaoCaoHD bc = new GetBaoCaoHD();

            List<object> list1 = new List<object>();
            foreach (var item in bc.Get_DanhSachBenXe_CuaSoGiaoThong(idso))
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
        private object ThongTinBenXe(int idben)
        {
            GetBaoCaoHD bc = new GetBaoCaoHD();

            var ooo = bc.Get_ThongTinBenXe_TheoIdBen(idben);
            var ob = new
            {
                ooo.BX_IdBenXe,
                ooo.CoQuanQuanLy,
                ooo.DiaChi,
                ooo.DienTich_NhaCho,
                ooo.DienTich_PhuongTienKhac,
                ooo.DienTich_XeKhach,
                ooo.GhiChu,
                ooo.LoaiBenXe,
                ooo.MaBen,
                ooo.SDT,
                ooo.SoLuotXuatBenDangKy,
                ooo.SoLuotXuatBenQuyHoach,
                ooo.SoTuyenQuyHoach,
                ooo.TenBenXe,
                ooo.TongDienTich,
                ooo.TS_IdTinh_So,
                ooo.TS_TT_IdTrangThai
            };
            return ob;
        }

        private object GetThongTinTuyen_TheoID(long idTuyen)
        {
            QLVanTai_2017 dbc = new QLVanTai_2017();
            QLVT_LuongTuyen ltt = dbc.QLVT_LuongTuyen.Where(u => u.LT_IdLuongTuyen == idTuyen).FirstOrDefault();
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

        private object ThongTinDVVT(int dvvt)
        {
            GetBaoCaoHD bc = new GetBaoCaoHD();
            var ooo = bc.Get_ThongTinDVVT_TheoIdDVVT(dvvt);
            var ob = new
            {
                ooo.CT_IdCongTyVT,
                ooo.CT_TT_IdTrangThai,
                ooo.DiaChi,
                ooo.MaCongTy,
                ooo.SoLuongXe,
                ooo.TenCongTy,
                ooo.TS_IdTinh_So
            };
            return ob;
        }

        private dynamic GetDonViVanTai(long idLuongTuyen)
        {
            try
            {
                var dbc = new QLVanTai_2017();
                var lstDV = (from donViVanTai in dbc.QLVT_CongTyVanTai
                             join capTuyen in dbc.QLVT_DanhSachCapTuyenChoDN on donViVanTai.CT_IdCongTyVT equals capTuyen.CT_IdCongTyVT
                             where capTuyen.LT_IdLuongTuyen == idLuongTuyen
                             select new
                             {
                                 donViVanTai.CT_IdCongTyVT,
                                 donViVanTai.TenCongTy
                             }).ToList();
                return lstDV;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách bến xe theo sở
        /// </summary>
        /// <param name="idSo"></param>
        /// <returns>JsonResult</returns>
        [HttpPost]
        public JsonResult GetListBenXe(int? idSo)
        {
            try
            {
                return Json(new
                {
                    status = true,
                    message = "Lấy dữ liệu thành công",
                    data = Get_List_Ben_TheoIDSo(Convert.ToInt32(idSo))
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Lấy dữ liệu thất bại", data = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Lấy danh sách tuyến theo idBenXe
        /// </summary>
        /// <param name="idBenXe"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetListTuyen(int? idBenXe)
        {
            try
            {
                var Tuyen = Get_List_Tuyen_TheoBen(Convert.ToInt32(idBenXe));
                var ThongTinTuyen =
                    Tuyen.Count > 0 ?
                     GetThongTinTuyen_TheoID(Convert.ToInt32(idBenXe)) : new
                     {
                         LT_IdLuongTuyen = "",
                         LT_MaTuyen = "",
                         LT_DC_IdBen_01 = "",
                         LT_DC_IdBen_02 = "",
                         LT_DC_TenBen_01 = "",
                         LT_DC_TenBen_02 = "",
                         TuyenDuong = "",
                         LT_DC_IdLuongTuyen = "",
                         LT_HanhTrinhChay = "",
                         LT_LuuLuongQuyDinh = "",
                         LT_PL_IdLuongTuyen = "",
                         TT_IdTrangThaiTuyen = ""
                     };
                return Json(new
                {
                    status = true,
                    message = "Lấy dữ liệu thành công",
                    data = new
                    {
                        Tuyen,
                        ThongTinTuyen
                    }
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Lấy dữ liệu thất bại", data = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetListTuyenDN(int? idBenXe)
        {
            try
            {
                return Json(new
                {
                    status = true,
                    message = "Lấy dữ liệu thành công",
                    data = Get_List_Tuyen_TheoBen(Convert.ToInt32(idBenXe))
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Lấy dữ liệu thất bại", data = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetListDonVi(long? Tuyen)
        {
            try
            {
                return Json(new
                {
                    status = true,
                    message = "Lấy dữ liệu thành công",
                    data = GetDonViVanTai(Convert.ToInt64(Tuyen))
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Lấy dữ liệu thất bại", data = "" }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult GetThongTinDonVi(int? DonVi)
        {
            try
            {
                QLVanTai_2017 dbc = new QLVanTai_2017();
                return Json(new { status = true, messeage = "Lấy dữ liệu thành công", data = ThongTinBenXe(Convert.ToInt32(DonVi)) });
            }
            catch (Exception e)
            {
                return Json(new { status = false, messeage = "Lấy dữ liệu thất bại", data = "" });
            }
        }
        #endregion
        // GET: BaoCaoKhongHoatDong

        #region [Báo cáo toàn quốc]

        private ActionResult BaoCaoToanQuocDefault()
        {
            try
            {
                //Default value
                int So = 55;
                string TuNgay = "01/" + DateTime.Now.ToString("MM/yyyy");
                string DenNgay = DateTime.Now.ToString("dd/MM/yyyy");
                //////
                var dbc = new QLVanTai_2017();
                ViewBag.LstSo = Get_List_So();

                var DataDefault = new
                {
                    So,
                    TuNgay,
                    DenNgay
                };
                ViewBag.DataDefault = DataDefault;
                var DataGrid = dbc.sp_HD_BaoCaoXeKhongHoatDong_ToanQuoc(TuNgay, DenNgay, "-1").ToList();
                ViewBag.DataGrid = DataGrid;
            }
            catch (Exception e)
            {
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return BaoCaoToanQuocDefault();
        }

        [HttpPost]
        public JsonResult GetBCKhongThucHienTQ(string LstSo, string TuNgay, string DenNgay)
        {
            try
            {
                QLVanTai_2017 dbc = new QLVanTai_2017();
                LstSo = "," + LstSo;
                var BC = dbc.sp_HD_BaoCaoXeKhongHoatDong_ToanQuoc(TuNgay, DenNgay, LstSo).ToList();
                return Json(new { status = true, messeage = "Lấy dữ liệu thành công", data = BC });
            }
            catch (Exception e)
            {
                return Json(new { status = false, messeage = "Lấy dữ liệu thất bại", data = "" });
            }
        }

        #endregion

        #region [Báo cáo sở]
        private ActionResult BaoCaoSoDefault()
        {
            try
            {
                QLVanTai_2017 dbc = new QLVanTai_2017();
                //DataDefault
                var DataDefault = new
                {
                    So = 55,
                    TuNgay = "01/" + DateTime.Now.ToString("MM/yyyy"),
                    DenNgay = DateTime.Now.ToString("dd/MM/yyyy")
                };
                ViewBag.DataDefault = DataDefault;

                ViewBag.LstSo = Get_List_So();
                ViewBag.List_Ben = Get_List_Ben_TheoIDSo(DataDefault.So);
                ViewBag.List_Ben.Insert(0, new { BX_IdBenXe = -1, TenBenXe = "Tất cả" });

                string lstBen = ",";
                foreach (var v in ViewBag.List_Ben)
                {
                    lstBen += v.BX_IdBenXe + ",";
                }

                var DataGrid = dbc.sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong(DataDefault.TuNgay, DataDefault.DenNgay, DataDefault.So, lstBen).ToList();
                ViewBag.DataGrid = DataGrid;
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }
        
        public ActionResult BaoCaoSo()
        {
            return BaoCaoSoDefault();
        }

        [HttpGet]
        public ActionResult BaoCaoSo(int? So, string TuNgay, string DenNgay)
        {
            if (string.IsNullOrEmpty(DenNgay))
            {
                return BaoCaoSoDefault();
            }
            else
            {
                QLVanTai_2017 dbc = new QLVanTai_2017();
                //DataDefault
                var DataDefault = new
                {
                    So = Convert.ToInt32(So),
                    TuNgay,
                    DenNgay
                };
                ViewBag.DataDefault = DataDefault;

                ViewBag.LstSo = Get_List_So();
                ViewBag.List_Ben = Get_List_Ben_TheoIDSo(DataDefault.So);
                ViewBag.List_Ben.Insert(0, new { BX_IdBenXe = -1, TenBenXe = "Tất cả" });

                string lstBen = ",";
                foreach (var v in ViewBag.List_Ben)
                {
                    lstBen += v.BX_IdBenXe + ",";
                }

                var DataGrid = dbc.sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong(DataDefault.TuNgay, DataDefault.DenNgay, DataDefault.So, lstBen).ToList();
                ViewBag.DataGrid = DataGrid;
                return View();
            }
        }

        [HttpPost]
        public JsonResult GetNhieuBenXe(int? idSo)
        {
            try
            {
                var data = Get_List_Ben_TheoIDSo(Convert.ToInt32(idSo));
                if (data.Count > 0)
                {
                    data.Insert(0, new { BX_IdBenXe = -1, TenBenXe = "Tất cả" });
                }
                else
                {
                    data.Insert(0, new { BX_IdBenXe = -2, TenBenXe = "Không có" });
                }
                return Json(new { status = true, message = "Lấy dữ liệu thành công", data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { status = false, message = "Lấy dữ liệu thất bại", data = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetBaoCaoSo(int? So, string LstBen, string TuNgay, string DenNgay)
        {
            try
            {
                QLVanTai_2017 dbc = new QLVanTai_2017();
                LstBen = "," + LstBen + ",";
                var DataGrid = dbc.sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong(TuNgay, DenNgay, So, LstBen).ToList();
                var DataDefault = new
                {
                    TuNgay,
                    DenNgay,
                    So
                };
                return Json(new
                {
                    status = true,
                    message = "Lấy dữ liệu thành công",
                    data = new { DataGrid, DataDefault }
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { status = false, message = "Lấy dữ liệu thất bại", data = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region [Báo cáo bến]


        private ActionResult BaoCaoBenDefault()
        {
            int Id_So = 55; // mặc định
            int Id_Ben = 1;
            // lấy danh sách sở
            var lstSo = _.DB.QLVT_ThongTinTinh_SoGiaoThong.Select(
                s => new
                {
                    s.TS_IdTinh_So,
                    s.TS_TenTinh
                }).ToList();
            ViewBag.lstSo = lstSo;

            string dateBatDau = "01/" + DateTime.Now.ToString("MM/yyyy");
            string dateKetThuc = DateTime.Now.ToString("dd/MM/yyyy");

            // lấy danh sách tuyến
            var lstTuyen = _.DB.GetThongTinTuyen_IdSo(Id_So).Select(
                s => new
                {
                    LT_IdLuongTuyen = s.LT_IdLuongTuyen,
                    TuyenDuong = s.TenTuyenn
                }).ToList();
            lstTuyen.Insert(0, new { LT_IdLuongTuyen = (long)-1, TuyenDuong = "Tất cả" });
            ViewBag.lstTuyen = lstTuyen;
            ViewBag.lstBen = Get_List_Ben_TheoIDSo(Convert.ToInt32(Id_So));
            // lấy báo cáo
            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;
            var lstBCSoDuoi70 = _.DBC.sp_HD_BaoCaoXeKhongHoatDongTaiBen(dateBatDau, dateKetThuc, Id_Ben, "-1").ToList();
            ViewBag.dataGrid = lstBCSoDuoi70;

            // khởi tạo mặc định
            dynamic dataDefault = new
            {
                Id_So,
                Id_Ben,
                dateBatDau,
                dateKetThuc,
            };
            ViewBag.dataDefault = dataDefault;

            return View();
        }

        public ActionResult BaoCaoBen()
        {
            return BaoCaoBenDefault();
        }

        [HttpGet]
        public ActionResult BaoCaoBen(int? Ben, int? So, string TuNgay, string DenNgay)
        {
            if (string.IsNullOrEmpty(DenNgay))
            {
                return BaoCaoBenDefault();
            }
            else
            {
                // lấy danh sách sở
                var lstSo = _.DB.QLVT_ThongTinTinh_SoGiaoThong.Select(
                    s => new
                    {
                        s.TS_IdTinh_So,
                        s.TS_TenTinh
                    }).ToList();
                ViewBag.lstSo = lstSo;

                // lấy danh sách tuyến
                var lstTuyen = _.DB.GetThongTinTuyen_IdSo(So).Select(
                    s => new
                    {
                        LT_IdLuongTuyen = s.LT_IdLuongTuyen,
                        TuyenDuong = s.TenTuyenn
                    }).ToList();
                lstTuyen.Insert(0, new { LT_IdLuongTuyen = (long)-1, TuyenDuong = "Tất cả" });
                ViewBag.lstTuyen = lstTuyen;
                ViewBag.lstBen = Get_List_Ben_TheoIDSo(Convert.ToInt32(So));
                // lấy báo cáo
                int thang = DateTime.Now.Month;
                int nam = DateTime.Now.Year;
                ViewBag.dataGrid = _.DBC.sp_HD_BaoCaoXeKhongHoatDongTaiBen(TuNgay, DenNgay, Convert.ToInt32(Ben), "-1").ToList();

                // khởi tạo mặc định
                dynamic dataDefault = new
                {
                    So = Convert.ToInt32(So),
                    Id_Ben = Convert.ToInt32(Ben),
                    dateBatDau = TuNgay,
                    dateKetThuc = DenNgay
                };
                ViewBag.dataDefault = dataDefault;

                return View();
            }
        }

        [HttpPost]
        public JsonResult GetBaoCaoBen(string TuNgay, string DenNgay, int? So, int? Ben, string lstTuyen)
        {
            try
            {
                var DataGrid = _.DBC.sp_HD_BaoCaoXeKhongHoatDongTaiBen(TuNgay, DenNgay, Convert.ToInt32(Ben), lstTuyen).ToList();

                var dataDefault = new
                {
                    So = Convert.ToInt32(So),
                    Id_Ben = Convert.ToInt32(Ben),
                    dateBatDau = TuNgay,
                    dateKetThuc = DenNgay
                };
                return Json(new { status = true, message = "Lấy dữ liệu thành công", data = new {DataGrid, dataDefault}}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Lấy dữ liệu thất bại", data = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region [Báo cáo tuyến không thực hiện]
        private ActionResult BaoCaoTuyenDefault()
        {
            //default
            QLVanTai_2017 dbc = new QLVanTai_2017();
            Dictionary<string, dynamic> DataDefault = new Dictionary<string, dynamic>();
            DataDefault["So"] = 55;
            DataDefault["TuNgay"] = "01/" + DateTime.Now.ToString("MM/yyyy");
            DataDefault["DenNgay"] = DateTime.Now.ToString("dd/MM/yyyy");

            ViewBag.LstSo = Get_List_So();

            ViewBag.LstBenXe = Get_List_Ben_TheoIDSo(DataDefault["So"]);
            DataDefault["Ben"] = ViewBag.LstBenXe[0].BX_IdBenXe;

            ViewBag.LstTuyen = Get_List_Tuyen_TheoBen(DataDefault["Ben"]);
            DataDefault["Tuyen"] = ViewBag.LstTuyen[0].LT_IdLuongTuyen;

            ViewBag.LstDVTT = Get_List_DVVT_TheoIDTuyen(DataDefault["Tuyen"]); ;
            string lstCongTy = "";
            foreach (var v in ViewBag.LstDVTT)
            {
                lstCongTy += v.CT_IdCongTyVT;
            }
            ViewBag.LstDVTT.Insert(0, new { CT_IdCongTyVT = -1, TenCongTy = "Tất cả" });

            ViewBag.DataGrid = dbc.sp_HD_BaoCaoXeKhongHoatDong_Tuyen(DataDefault["TuNgay"],
                DataDefault["DenNgay"], DataDefault["Ben"], DataDefault["Tuyen"], lstCongTy);
            ViewBag.DataDefault = DataDefault;
            ViewBag.ThongTinTuyen = GetThongTinTuyen_TheoID(DataDefault["Tuyen"]);
            return View();
        }

        public ActionResult BaoCaoTuyen()
        {
            return BaoCaoTuyenDefault();
        }

        [HttpPost]
        public JsonResult GetBaoCaoTuyen(long? Tuyen, int? Ben, string LstCongTy, string TuNgay, string DenNgay)
        {
            try
            {
                QLVanTai_2017 dbc = new QLVanTai_2017();
                LstCongTy = "," + LstCongTy + ",";
                var DataGrid = dbc.sp_HD_BaoCaoXeKhongHoatDong_Tuyen(TuNgay,
                DenNgay, Convert.ToInt32(Ben), Convert.ToInt64(Tuyen), LstCongTy);
                var DataDefault = new
                {
                    So = 0,
                    Ben = Convert.ToInt32(Ben),
                    Tuyen = Convert.ToInt64(Tuyen),
                    TuNgay,
                    DenNgay
                };

                return Json(new { status = true, message = "Lấy dữ liệu thành công", data = new { DataGrid, DataDefault } }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Lấy dữ liệu thất bại", data = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region [Báo cáo doanh nghiệp]
        private ActionResult BaoCaoDoanhNghiepDefault()
        {
            QLVanTai_2017 dbc = new QLVanTai_2017();
            Dictionary<string, dynamic> DataDefault = new Dictionary<string, dynamic>();
            DataDefault["So"] = 55;
            DataDefault["TuNgay"] = "01/" + DateTime.Now.ToString("MM/yyyy");
            DataDefault["DenNgay"] = DateTime.Now.ToString("dd/MM/yyyy");

            ViewBag.LstSo = Get_List_So();

            ViewBag.LstBen = Get_List_Ben_TheoIDSo(DataDefault["So"]);
            DataDefault["Ben"] = ViewBag.LstBen[0].BX_IdBenXe;

            ViewBag.LstTuyen = Get_List_Tuyen_TheoBen(DataDefault["Ben"]);
            DataDefault["Tuyen"] = ViewBag.LstTuyen[0].LT_IdLuongTuyen;

            ViewBag.LstDonVi = Get_List_DVVT_TheoIDTuyen(DataDefault["Tuyen"]); ;
            DataDefault["DonVi"] = ViewBag.LstDonVi[0].CT_IdCongTyVT;
            ViewBag.DataGrid = dbc.sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai(DataDefault["TuNgay"], DataDefault["DenNgay"], DataDefault["Ben"], DataDefault["Tuyen"], DataDefault["DonVi"]);
            ViewBag.DataDefault = DataDefault;
            ViewBag.ThongTinTuyen = GetThongTinTuyen_TheoID(DataDefault["Tuyen"]);
            ViewBag.ThongTinBenXe = ThongTinBenXe(DataDefault["Ben"]);
            return View();
        }

        public ActionResult BaoCaoDoanhNghiep()
        {
            return BaoCaoDoanhNghiepDefault();
        }

        [HttpGet]
        public ActionResult BaoCaoDoanhNghiep(int? So, int? Ben, int? DonVi, long? Tuyen, string TuNgay, string DenNgay)
        {
            if (string.IsNullOrEmpty(DenNgay))
            {
                return BaoCaoDoanhNghiepDefault();
            }
            else
            {
                QLVanTai_2017 dbc = new QLVanTai_2017();
                Dictionary<string, dynamic> DataDefault = new Dictionary<string, dynamic>();
                DataDefault["So"] = Convert.ToInt32(So);
                DataDefault["TuNgay"] = TuNgay;
                DataDefault["DenNgay"] = DenNgay;

                ViewBag.LstSo = Get_List_So();

                ViewBag.LstBen = Get_List_Ben_TheoIDSo(DataDefault["So"]);
                DataDefault["Ben"] = Convert.ToInt32(Ben);

                ViewBag.LstTuyen = Get_List_Tuyen_TheoBen(DataDefault["Ben"]);
                DataDefault["Tuyen"] = Convert.ToInt64(Tuyen);

                ViewBag.LstDonVi = Get_List_DVVT_TheoIDTuyen(DataDefault["Tuyen"]); ;
                DataDefault["DonVi"] = Convert.ToInt32(DonVi);
                ViewBag.DataGrid = dbc.sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai(DataDefault["TuNgay"], DataDefault["DenNgay"], DataDefault["Ben"], DataDefault["Tuyen"], DataDefault["DonVi"]);
                ViewBag.DataDefault = DataDefault;
                ViewBag.ThongTinTuyen = GetThongTinTuyen_TheoID(DataDefault["Tuyen"]);
                ViewBag.ThongTinBenXe = ThongTinBenXe(DataDefault["Ben"]);
                return View();
            }

        }

        [HttpPost]
        public JsonResult GetBaoCaoDoanhNghiep(string TuNgay, string DenNgay, int? Ben, long? Tuyen, int? DonVi)
        {
            try
            {
                QLVanTai_2017 dbc = new QLVanTai_2017();
                var DataGrid = dbc.sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai(TuNgay, DenNgay, Ben,
                    Tuyen, DonVi);
                var ThongTinBen = ThongTinBenXe(Convert.ToInt32(Ben));
                var ThongTinDonVi = ThongTinDVVT(Convert.ToInt32(DonVi));
                var DataDefault = new
                {
                    TuNgay,
                    DenNgay,
                    Ben = Convert.ToInt32(Ben),
                    Tuyen = Convert.ToInt64(Tuyen),
                    DonVi = Convert.ToInt32(DonVi)
                };
                var data = new
                {
                    DataGrid,
                    ThongTinBen,
                    ThongTinDonVi,
                    DataDefault
                };
                return Json(new { status = true, message = "Lấy dữ liệu thành công", data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Lấy dữ liệu thất bại", data = "" }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion
    }
}