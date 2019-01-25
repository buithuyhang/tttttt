using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Test.Models;

namespace Test.Controllers
{
    public class BaoCaoHoatDongController : Controller
    {
        GetBaoCaoHD bc = new GetBaoCaoHD();

        // GET: BaoCaoHoatDong      
        /*=================================Controller no param=================================*/
        #region BÁO CÁO HOẠT ĐỘNG TUYẾN
        private ActionResult BaoCaoHoatDongTuyenDefault()
        {
            //default
            int So = 55;
            string name = "a";

            ViewBag.List_So = Get_List_So();

            ViewBag.LstBenXe = GetBenXe(So);
            int idBen = ViewBag.LstBenXe[0].BX_IdBenXe;

            ViewBag.List_Tuyen = Get_List_Tuyen_TheoBen(idBen);
            ViewBag.List_Tuyen.RemoveAt(0);
            long idTuyen = ViewBag.List_Tuyen[0].LT_IdLuongTuyen;

            string dateBatDau = "01/" + DateTime.Now.ToString("MM/yyyy");
            string dateKetThuc = DateTime.Now.ToString("dd/MM/yyyy");

            var lstDVVT = Get_List_DVVT_TheoIDTuyen(idTuyen);
            //Tach lay chuoi don vi
            string stDonVi = "";
            foreach (dynamic v in lstDVVT)
            {
                stDonVi += v.CT_IdCongTyVT + ",";
            }
            char[] arrChar = { ',' };
            string[] arrDonVi = stDonVi.Split(arrChar, StringSplitOptions.RemoveEmptyEntries);
            lstDVVT.Insert(0, new { CT_IdCongTyVT = -1, TenCongTy = "Tất cả" });
            ViewBag.List_DVVT = lstDVVT;
            ViewBag.BaoCaoTongHop_Tuyen = Get_BaoCao_Tuyen(name, dateBatDau, dateKetThuc, idBen, idTuyen, arrDonVi);

            var bien = new
            {
                So,
                Ben = idBen,
                Tuyen = idTuyen,
                dateBatDau,
                dateKetThuc
                
            };
            ViewBag.BienCuaTuyen = bien;
            ViewBag.ThongTinTuyen = ThongTinTuyen(idTuyen);
            return View();
        }
        public ActionResult BaoCaoHoatDong_Tuyen()
        {
            return BaoCaoHoatDongTuyenDefault();
        }
        [HttpGet]
        public ActionResult BaoCaoHoatDong_Tuyen(string name, string Tu, string Den, int? So, int? Ben, long? Tuyen = -1)
        {
            if (Tuyen != -1)
            {
                ViewBag.List_So = Get_List_So();
                ViewBag.LstBenXe = GetBenXe(Convert.ToInt32(So));
                ViewBag.List_Tuyen = Get_List_Tuyen_TheoBen(Convert.ToInt32(Ben));
                ViewBag.List_Tuyen.RemoveAt(0);
                dynamic lstDVVT;
                if (ViewBag.List_Tuyen.Count > 0)
                {
                    lstDVVT = Get_List_DVVT_TheoIDTuyen(Convert.ToInt64(Tuyen));
                }
                else
                {
                    lstDVVT = new List<dynamic>();
                    lstDVVT.Add(new { CT_IdCongTyVT = -1, TenCongTy = "Không có" });
                }

                //Tach lay chuoi don vi
                string stDonVi = "";
                foreach (dynamic v in lstDVVT)
                {
                    stDonVi += v.CT_IdCongTyVT + ",";
                }
                char[] arrChar = { ',' };
                string[] arrDonVi = stDonVi.Split(arrChar, StringSplitOptions.RemoveEmptyEntries);
                lstDVVT.Insert(0, new { CT_IdCongTyVT = -1, TenCongTy = "Tất cả" });
                ViewBag.List_DVVT = lstDVVT;
                ViewBag.BaoCaoTongHop_Tuyen = Get_BaoCao_Tuyen(name, Tu, Den, Convert.ToInt32(Ben), Convert.ToInt64(Tuyen), arrDonVi);

                var bien = new
                {
                    So,
                    Ben,
                    Tuyen,
                    dateKetThuc = Tu,
                    dateBatDau = Den
                };
                ViewBag.BienCuaTuyen = bien;
                ViewBag.ThongTinTuyen = ThongTinTuyen(Convert.ToInt64(Tuyen));
                return View();
            }
            else
            {
                return BaoCaoHoatDongTuyenDefault();
            }
        }
        //BÁO CÁO CHO TUYẾN
        private List<object> Get_BaoCao_Tuyen(string name, string dateBatDau, string dateKetThuc, int idBen, long idTuyen, string[] arrDonVi)
        {
            var ten = Convert.ToString(name);
            List<object> lstDonVi = new List<object>();
            if (ten == null)
            {
                List<sp_HD_BaoCaoTongHop_Tuyen_DonViVanTai_Result> lstResults = new List<sp_HD_BaoCaoTongHop_Tuyen_DonViVanTai_Result>();
                var dbc = new QLVanTai_2017();
                int idDonVi;
                foreach (var v in arrDonVi)
                {
                    idDonVi = Convert.ToInt32(v);
                    lstDonVi.Add(dbc.sp_HD_BaoCaoTongHop_Tuyen_DonViVanTai(dateBatDau, dateKetThuc, idBen, idTuyen, idDonVi).FirstOrDefault());
                }
                return lstDonVi;
            }
            else if (ten == "a")
            {
                List<sp_HD_BaoCaoTongHop_Tuyen_DonViVanTai_Result> lstResults = new List<sp_HD_BaoCaoTongHop_Tuyen_DonViVanTai_Result>();
                var dbc = new QLVanTai_2017();
                int idDonVi;
                foreach (var v in arrDonVi)
                {
                    idDonVi = Convert.ToInt32(v);
                    lstDonVi.Add(dbc.sp_HD_BaoCaoTongHop_Tuyen_DonViVanTai(dateBatDau, dateKetThuc, idBen, idTuyen, idDonVi).FirstOrDefault());
                }
                return lstDonVi;
            }
            return lstDonVi;
        }                
        #endregion

        #region BaoCaoHoatDong_DonViVanTai
        //Get List ben
        private dynamic GetBenXe(int idSo)
        {
            try
            {
                var dbc = new QLVanTai_2017();
                var lstBenXe = dbc.QLVT_ThongTinBenXe
                    .Where(w => w.TS_IdTinh_So == idSo && w.TS_TT_IdTrangThai == 1)
                    .Select(s => new
                    {
                        s.BX_IdBenXe,
                        s.TenBenXe
                    })
                    .ToList();
                return lstBenXe;
            }
            catch
            {
                return null;
            }
        }

        //Get DV VT
        private dynamic GetDonViVanTai(int idBen, long idLuongTuyen)
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
        //BaoCaoHoatDong_DonViVanTai
        public ActionResult BaoCaoHoatDong_DonViVanTai()
        {
            ViewBag.List_So = Get_List_So();
            int SO = 55; //Của Thái Nguyên
            ViewBag.List_Ben = Get_List_Ben_TheoIDSo(SO);

            int BEN = bc.Get_DanhSachBenXe_CuaSoGiaoThong(SO).FirstOrDefault().BX_IdBenXe; //defaut Bến   
            long TUYEN = bc.Get_Id_TuyenDauTien_CuaBen(BEN); // default Tuyến
            int idcongtyfirst = bc.Get_Id_DonViDauTin_CuaTuyen(TUYEN);

            ViewBag.List_Tuyen = Get_List_Tuyen_TheoBen(BEN);
            ViewBag.List_DVVT = Get_List_DVVT_TheoIDTuyen(TUYEN);

            List<object> List_Return = new List<object>();
            int ngay_hientai = Convert.ToInt32(DateTime.Now.Day);
            int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
            int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
            string dt = ngay_hientai + "/" + thang_hientai + "/" + nam_hientai;
            var ten = Convert.ToString("a"); // default name

            List_Return = Get_BaoCao_DVVT(ten, dt, dt, BEN, TUYEN, idcongtyfirst);
            ViewBag.BaoCaoTongHop_DVVT = List_Return;
            var bien = new
            {
                Ngay = ngay_hientai,
                Thang = thang_hientai,
                Nam = nam_hientai,
                So = SO,
                Ben = BEN,
                Tuyen = TUYEN,
                Dvvt = idcongtyfirst
            };
            ViewBag.BienCuaDVVT = bien;
            ViewBag.ThongTinBenTheoID = ThongTinBenXe(BEN);
            return View();
        }
        [HttpPost]
        public ActionResult GetDonViVanTai(string stDonVi, string idBen, string idTuyen, string dateBatDau, string dateKetThuc)
        {
            try
            {
                var dbc = new QLVanTai_2017();
                stDonVi = stDonVi.Remove(stDonVi.IndexOf("-1"));
                char[] arrChar = { ',' };
                string[] arrDonVi = stDonVi.Split(arrChar, StringSplitOptions.RemoveEmptyEntries);
                int mIdDonVi;
                foreach (var v in arrDonVi)
                {
                    mIdDonVi = Convert.ToInt32(v);
                    var donVi = dbc.sp_HD_BaoCaoTongHop_Tuyen(dateBatDau, dateKetThuc, Convert.ToInt32(idBen),
                        Convert.ToInt64(idTuyen)).ToList();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region TỔNG HỢP && NHẬT TRÌNH XE
        [Route("~/BaoCaoHoatDong/")]
        [Route("~/BaoCaoHoatDong/Index")]
        public ActionResult Index()
        {
            ViewBag.List_So = Get_List_So();
            List<object> List_Return = new List<object>();
            int ngay_hientai = Convert.ToInt32(DateTime.Now.Day);
            int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
            int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
            var ten = Convert.ToString("a");
            string d = 1 + "/" + thang_hientai + "/" + nam_hientai;
            string dt = ngay_hientai + "/" + thang_hientai + "/" + nam_hientai;
            List_Return = Get_BaoCao_ToanQuoc(ten, d, dt);
            ViewBag.BaoCaoTongHop_ToanQuoc = List_Return;
            var bien1 = new
            {
                Ngay = 1,
                Thang = thang_hientai,
                Nam = nam_hientai,
                Ngay1 = ngay_hientai,
                Thang1 = thang_hientai,
                Nam1 = nam_hientai,
                SoSoGet = "Tất Cả"
            };
            ViewBag.BienToanQuoc = bien1;
            return View();
        }
        [HttpGet]
        public ActionResult Index(string name, string dt1, string dt2)
        {
            ViewBag.List_So = Get_List_So();
            List<object> List_Return = new List<object>();
            if (!string.IsNullOrEmpty(Convert.ToString(name)))
            {
                var ten = Convert.ToString(name);
                if (!string.IsNullOrEmpty(Convert.ToString(dt1)) && !string.IsNullOrEmpty(Convert.ToString(dt2)))
                {
                    string TU = Convert.ToString(dt1); string[] TU1 = TU.Split('/');
                    string DEN = Convert.ToString(dt2); string[] DEN1 = DEN.Split('/');
                    List_Return = Get_BaoCao_ToanQuoc(ten, TU, DEN);
                    ViewBag.BaoCaoTongHop_ToanQuoc = List_Return;
                    var bien = new
                    {
                        Ngay = TU1[0],
                        Thang = TU1[1],
                        Nam = TU1[2],
                        Ngay1 = DEN1[0],
                        Thang1 = DEN1[0],
                        Nam1 = DEN1[0],
                        SoSoGet = "Tất Cả"
                    };
                    ViewBag.BienToanQuoc = bien;
                    return View();
                }
                else
                {
                    int ngay_hientai = Convert.ToInt32(DateTime.Now.Day);
                    int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
                    int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
                    string d = 1 + "/" + thang_hientai + "/" + nam_hientai;
                    string dt = ngay_hientai + "/" + thang_hientai + "/" + nam_hientai;
                    List_Return = Get_BaoCao_ToanQuoc(ten, d, dt);
                    ViewBag.BaoCaoTongHop_ToanQuoc = List_Return;
                    var bien = new
                    {
                        Ngay = 1,
                        Thang = thang_hientai,
                        Nam = nam_hientai,
                        Ngay1 = ngay_hientai,
                        Thang1 = thang_hientai,
                        Nam1 = nam_hientai,
                        SoSoGet = "Tất Cả"
                    };
                    ViewBag.BienToanQuoc = bien;
                    return View();
                }
            }
            else
            {
                var ten = Convert.ToString("a");
                int ngay_hientai = Convert.ToInt32(DateTime.Now.Day);
                int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
                int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
                string d = 1 + "/" + thang_hientai + "/" + nam_hientai;
                string dt = ngay_hientai + "/" + thang_hientai + "/" + nam_hientai;
                List_Return = Get_BaoCao_ToanQuoc(ten, dt, dt);
                ViewBag.BaoCaoTongHop_ToanQuoc = List_Return;
                var bien = new
                {
                    Ngay = 1,
                    Thang = thang_hientai,
                    Nam = nam_hientai,
                    Ngay1 = ngay_hientai,
                    Thang1 = thang_hientai,
                    Nam1 = nam_hientai,
                    SoSoGet = "Tất Cả"
                };
                ViewBag.BienToanQuoc = bien;
                return View();
            }
        }
        //BÁO CÁO TOÀN QUỐC
        private List<object> Get_BaoCao_ToanQuoc(string name, string tu, string den)
        {
            var ten = Convert.ToString(name);
            string TU = Convert.ToString(tu);
            string DEN = Convert.ToString(den);
            List<object> list1 = new List<object>();
            if (ten == null)
            {
                List<sp_HD_BaoCaoTongHop_ToanQuoc_Result> list = new List<sp_HD_BaoCaoTongHop_ToanQuoc_Result>();
                list = bc.Get_BaoCaoTongHop_ToanQuoc(TU, DEN);
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
                        SoBen = item.SoBen,
                        SoXe = item.SoXe,
                        TongCongSuat = item.TongCongSuat,
                        TongSoTuyen = item.TongSoTuyen,
                        TrangThaiTruyenDan = item.TrangThaiTruyenDan,
                        Tu = TU,
                        Den = DEN,
                        URL = Url.Action("BaoCaoHoatDong_So", "BaoCaoHoatDong") + "?name=a&Tu=" + TU + "&Den=" + DEN + "&So=" + item.TS_IdTinh_So
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "a")
            {
                List<sp_HD_BaoCaoTongHop_ToanQuoc_Result> list = new List<sp_HD_BaoCaoTongHop_ToanQuoc_Result>();
                list = bc.Get_BaoCaoTongHop_ToanQuoc(TU, DEN);
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
                        SoBen = item.SoBen,
                        SoXe = item.SoXe,
                        TongCongSuat = item.TongCongSuat,
                        TongSoTuyen = item.TongSoTuyen,
                        TrangThaiTruyenDan = item.TrangThaiTruyenDan,
                        Tu = TU,
                        Den = DEN,
                        URL = Url.Action("BaoCaoHoatDong_So", "BaoCaoHoatDong") + "?name=a&Tu=" + TU + "&Den=" + DEN + "&So=" + item.TS_IdTinh_So
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            return list1;
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
        /*=================================Xử Lý Click Events=================================*/
        #region GET BÁO CÁO SỰ KIỆN
        // ==> BÁO CÁO HOẠT ĐỘNG
        //Lấy nhiều bến
        [HttpPost]
        public string GetNhieuBenXe(string idSo)
        {
            try
            {
               
                int mIdSo = Convert.ToInt32(idSo);
                var dbc = new QLVanTai_2017();
                var lstBen = dbc.QLVT_ThongTinBenXe.Where(u => u.TS_IdTinh_So == mIdSo).Select(c => new
                {
                    c.BX_IdBenXe,
                    c.TenBenXe
                }).ToList();
                lstBen.Insert(0, new { BX_IdBenXe = -1, TenBenXe = "Tất cả" });
                return JsonConvert.SerializeObject(lstBen);
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region BÁO CÁO CHO TUYẾN
        //BÁO CÁO CHO TUYẾN
        [HttpPost]
        public string GetBaoCaoChoTuyenAll(string name, string dateBatDau, string dateKetThuc, int idBen, long idTuyen, string stDonVi)
        {
            stDonVi = stDonVi.Replace("-1", "");
            char[] arrChar = { ',' };
            string[] arrDonVi = stDonVi.Split(arrChar, StringSplitOptions.RemoveEmptyEntries);
            var ob = new
            {
                Tuyen = ThongTinTuyen(idTuyen),
                List_Return = Get_BaoCao_Tuyen(name, dateBatDau, dateKetThuc, idBen, idTuyen, arrDonVi)
            };
            return JsonConvert.SerializeObject(ob);
        }

        [HttpPost]
        public string GetListBenXe(int idSo)
        {
            return JsonConvert.SerializeObject(GetBenXe(idSo));
        }

        [HttpPost]
        public string GetListTuyen(int idBenXe)
        {
            return JsonConvert.SerializeObject(Get_List_Tuyen_TheoBen_KhongTatCa(idBenXe));
        }

        [HttpPost]
        public string GetListDonVi(string idBenXe, string idLuongTuyen)
        {       //undefined
            var a = GetDonViVanTai(Convert.ToInt32(idBenXe), Convert.ToInt64(idLuongTuyen));
            if (a.Count > 0)
            {
                a.Insert(0, new { CT_IdCongTyVT = -1, TenCongTy = "Tất cả" });
            }
            var ob = new
            {
                List = a,
                ThongTinTuyen = ThongTinTuyen(Convert.ToInt64(idLuongTuyen))
            };
            return JsonConvert.SerializeObject(ob);
        }
        #endregion
        /*=================================Function Lấy List Sở/Tuyến/Đơn Vị Vận Tải/Bến=================================*/
        #region GET LIST DANH SÁCH COMBOBOX && INFORMATION BY ID
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
        private List<object> Get_List_Tuyen_TheoBen(int idben)
        {
            return bc.Get_DanhSachAll_Tuyen_CuaBen(idben);
        }
        private List<object> Get_List_Tuyen_TheoBen_KhongTatCa(int idben)
        {
            return bc.Get_DanhSachAll_Tuyen_CuaBen_KhongTatCa(idben);
        }        
        private List<object> Get_List_DVVT()
        {
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
            return bc.Get_DanhSachCongTyVanTai_TrenTuyen_TheoIdTuyen(idtuyen);
        }
        private List<object> Get_List_DVVT_TheoIDTuyen1(long idtuyen)
        {
            return bc.Get_DanhSachCongTyVanTai_TrenTuyen_TheoIdTuyen1(idtuyen);
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
        private List<object> Get_List_Ben_TheoIDSo(int idso)
        {
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
        private object ThongTinDVVT(int dvvt)
        {
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
        private object ThongTinTuyen(long idtuyen)
        {
            var ob = new {
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
            var ooo = bc.Get_ThongTinTuyen_TheoId(idtuyen);
            if (ooo == null || idtuyen == -1)
            {
                return ob;
            } 
            else           
                return ooo;
        }
        #endregion
        /*=================================Xử Lý Click Events CHO NHIỀU=================================*/
        //NHIỀU
        #region GET BÁO CÁO LIST OBJECT NHIỀU PARAM
        //BÁO CÁO HOẠT ĐỘNG BẾN NHIỀU
        private object GetBaoCaoHoatDongBen(string name, int so, int ben, string dt1, string dt2, string tuyen)
        {
            List<object> List_TraVe = new List<object>();
            var ten = Convert.ToString(name);
            int BEN = Convert.ToInt32(ben);
            int SO = Convert.ToInt32(so);
            if (tuyen == "")
            {
                List_TraVe = Get_BaoCao_Ben(name, BEN, dt1, dt2, SO);
                string TU = Convert.ToString(dt1); string[] TU1 = TU.Split('/');
                string DEN = Convert.ToString(dt2); string[] DEN1 = DEN.Split('/');
                var bien = new
                {
                    Ngay = TU1[0],
                    Thang = TU1[1],
                    Nam = TU1[2],
                    Ngay1 = DEN1[0],
                    Thang1 = DEN1[0],
                    Nam1 = DEN1[0],
                    Tu = TU,
                    Den = DEN,
                    So = SO,
                    Ben = BEN,
                    Tuyen = "Tất Cả"
                };
                var oo = new
                {
                    ListTraVe = List_TraVe,
                    BienToanQuoc = bien,
                    ThongTinBen = ThongTinBenXe(BEN)
                };
                return oo;
            }
            if (ten == null)
            {
                if (tuyen == null)
                {
                    List_TraVe = Get_BaoCao_Ben(name, BEN, dt1, dt2, SO);
                    string TU = Convert.ToString(dt1); string[] TU1 = TU.Split('/');
                    string DEN = Convert.ToString(dt2); string[] DEN1 = DEN.Split('/');
                    var bien = new
                    {
                        Ngay = TU1[0],
                        Thang = TU1[1],
                        Nam = TU1[2],
                        Ngay1 = DEN1[0],
                        Thang1 = DEN1[0],
                        Nam1 = DEN1[0],
                        Tu = TU,
                        Den = DEN,
                        So = SO,
                        Ben = BEN,
                        Tuyen = "Tất Cả"
                    };
                    var oo = new
                    {
                        ListTraVe = List_TraVe,
                        BienToanQuoc = bien,
                        ThongTinBen = ThongTinBenXe(BEN)
                    };
                    return oo;
                }
                else if (tuyen.IndexOf("-1") > -1)
                {
                    List_TraVe = Get_BaoCao_Ben(name, BEN, dt1, dt2, SO);
                    string TU = Convert.ToString(dt1); string[] TU1 = TU.Split('/');
                    string DEN = Convert.ToString(dt2); string[] DEN1 = DEN.Split('/');
                    var bien = new
                    {
                        Ngay = TU1[0],
                        Thang = TU1[1],
                        Nam = TU1[2],
                        Ngay1 = DEN1[0],
                        Thang1 = DEN1[0],
                        Nam1 = DEN1[0],
                        Tu = TU,
                        Den = DEN,
                        So = SO,
                        Ben = BEN,
                        Tuyen = "Tất Cả"
                    };
                    var oo = new
                    {
                        ListTraVe = List_TraVe,
                        BienToanQuoc = bien,
                        ThongTinBen = ThongTinBenXe(BEN)
                    };
                    return oo;
                }
                else
                {
                    if (tuyen == "")
                    {
                        List_TraVe = Get_BaoCao_Ben(name, BEN, dt1, dt2, SO);
                        string TU = Convert.ToString(dt1); string[] TU1 = TU.Split('/');
                        string DEN = Convert.ToString(dt2); string[] DEN1 = DEN.Split('/');
                        var bien = new
                        {
                            Ngay = TU1[0],
                            Thang = TU1[1],
                            Nam = TU1[2],
                            Ngay1 = DEN1[0],
                            Thang1 = DEN1[0],
                            Nam1 = DEN1[0],
                            Tu = TU,
                            Den = DEN,
                            So = SO,
                            Ben = BEN,
                            Tuyen = "Tất Cả"
                        };
                        var oo = new
                        {
                            ListTraVe = List_TraVe,
                            BienToanQuoc = bien,
                            ThongTinBen = ThongTinBenXe(BEN)
                        };
                        return oo;
                    }
                    else
                    {
                        ArrayList mangtuyen = new ArrayList(tuyen.Split(new char[] { ',' }));
                        mangtuyen.RemoveAt(0);
                        mangtuyen.RemoveAt(mangtuyen.Count - 1);
                        long[] mang1 = new long[1000];
                        List<sp_HD_BaoCaoTongHopTaiBen_Result> list = new List<sp_HD_BaoCaoTongHopTaiBen_Result>();
                        list = bc.Get_BaoCaoTongHop_Ben(dt1, dt2, BEN);
                        for (var i = 0; i < mangtuyen.Count; i++)
                        {
                            long idtuyen = Convert.ToInt32(mangtuyen[i]);
                            mang1[i] = idtuyen;
                            sp_HD_BaoCaoTongHopTaiBen_Result LuongTuyen = list.Where(u => u.LT_IdLuongTuyen == idtuyen).FirstOrDefault();
                            if (LuongTuyen != null)
                            {
                                var ob = new
                                {
                                    LT_IdLuongTuyen = LuongTuyen.LT_IdLuongTuyen,
                                    LT_MaTuyen = LuongTuyen.LT_MaTuyen,
                                    SoChuyenKeHoach = LuongTuyen.SoChuyenKeHoach,
                                    SoChuyenQuyHoach = LuongTuyen.SoChuyenQuyHoach,
                                    SoChuyenThucHien = LuongTuyen.SoChuyenThucHien,
                                    SoLuotKhach = LuongTuyen.SoLuotKhach,
                                    TenTuyen = LuongTuyen.TenTuyen,
                                    TyLeXuatBen = LuongTuyen.TyLeXuatBen,
                                    Tu = dt1,
                                    Den = dt2,
                                    URL = Url.Action("BaoCaoHoatDong_Tuyen", "BaoCaoHoatDong") + "?name=a&Tu=" + dt1 + "&Den=" + dt2 + "&So=" + SO + "&Ben=" + BEN + "&Tuyen=" + LuongTuyen.LT_IdLuongTuyen
                                };
                                List_TraVe.Add(ob);
                            }
                        }
                        string TU = Convert.ToString(dt1); string[] TU1 = TU.Split('/');
                        string DEN = Convert.ToString(dt2); string[] DEN1 = DEN.Split('/');
                        var bien = new
                        {
                            Ngay = TU1[0],
                            Thang = TU1[1],
                            Nam = TU1[2],
                            Ngay1 = DEN1[0],
                            Thang1 = DEN1[0],
                            Nam1 = DEN1[0],
                            Tu = TU,
                            Den = DEN,
                            So = SO,
                            Ben = BEN,
                            Tuyen = mangtuyen.Count,
                            //TenTuyen = LayTenCacTuyenCuaBen_TheoIdBen(BEN, mang1)
                        };
                        var oo = new
                        {
                            ListTraVe = List_TraVe,
                            BienToanQuoc = bien,
                            ThongTinBen = ThongTinBenXe(BEN)
                        };
                        return oo;
                    }
                }
            }
            else if (ten == "a")
            {
                if (tuyen == null)
                {
                    List_TraVe = Get_BaoCao_Ben(name, BEN, dt1, dt2, SO);
                    string TU = Convert.ToString(dt1); string[] TU1 = TU.Split('/');
                    string DEN = Convert.ToString(dt2); string[] DEN1 = DEN.Split('/');
                    var bien = new
                    {
                        Ngay = TU1[0],
                        Thang = TU1[1],
                        Nam = TU1[2],
                        Ngay1 = DEN1[0],
                        Thang1 = DEN1[0],
                        Nam1 = DEN1[0],
                        Tu = TU,
                        Den = DEN,
                        So = SO,
                        Ben = BEN,
                        Tuyen = "Tất Cả"
                    };
                    var oo = new
                    {
                        ListTraVe = List_TraVe,
                        BienToanQuoc = bien,
                        ThongTinBen = ThongTinBenXe(BEN)
                    };
                    return oo;
                }
                else if (tuyen.IndexOf("-1") > -1)
                {
                    List_TraVe = Get_BaoCao_Ben(name, BEN, dt1, dt2, SO);
                    string TU = Convert.ToString(dt1); string[] TU1 = TU.Split('/');
                    string DEN = Convert.ToString(dt2); string[] DEN1 = DEN.Split('/');
                    var bien = new
                    {
                        Ngay = TU1[0],
                        Thang = TU1[1],
                        Nam = TU1[2],
                        Ngay1 = DEN1[0],
                        Thang1 = DEN1[0],
                        Nam1 = DEN1[0],
                        Tu = TU,
                        Den = DEN,
                        So = SO,
                        Ben = BEN,
                        Tuyen = "Tất Cả"
                    };
                    var oo = new
                    {
                        ListTraVe = List_TraVe,
                        BienToanQuoc = bien,
                        ThongTinBen = ThongTinBenXe(BEN)
                    };
                    return oo;
                }
                else
                {
                    if (tuyen == "")
                    {
                        List_TraVe = Get_BaoCao_Ben(name, BEN, dt1, dt2, SO);
                        string TU = Convert.ToString(dt1); string[] TU1 = TU.Split('/');
                        string DEN = Convert.ToString(dt2); string[] DEN1 = DEN.Split('/');
                        var bien = new
                        {
                            Ngay = TU1[0],
                            Thang = TU1[1],
                            Nam = TU1[2],
                            Ngay1 = DEN1[0],
                            Thang1 = DEN1[0],
                            Nam1 = DEN1[0],
                            Tu = TU,
                            Den = DEN,
                            So = SO,
                            Ben = BEN,
                            Tuyen = "Tất Cả"
                        };
                        var oo = new
                        {
                            ListTraVe = List_TraVe,
                            BienToanQuoc = bien,
                            ThongTinBen = ThongTinBenXe(BEN)
                        };
                        return oo;
                    }
                    else
                    {
                        ArrayList mangtuyen = new ArrayList(tuyen.Split(new char[] { ',' }));
                        mangtuyen.RemoveAt(0);
                        mangtuyen.RemoveAt(mangtuyen.Count - 1);
                        long[] mang1 = new long[1000];
                        List<sp_HD_BaoCaoTongHopTaiBen_Result> list = new List<sp_HD_BaoCaoTongHopTaiBen_Result>();
                        list = bc.Get_BaoCaoTongHop_Ben(dt1, dt2, BEN);
                        for (var i = 0; i < mangtuyen.Count; i++)
                        {
                            long idtuyen = Convert.ToInt32(mangtuyen[i]);
                            mang1[i] = idtuyen;
                            sp_HD_BaoCaoTongHopTaiBen_Result LuongTuyen = list.Where(u => u.LT_IdLuongTuyen == idtuyen).FirstOrDefault();
                            if (LuongTuyen != null)
                            {
                                var ob = new
                                {
                                    LT_IdLuongTuyen = LuongTuyen.LT_IdLuongTuyen,
                                    LT_MaTuyen = LuongTuyen.LT_MaTuyen,
                                    SoChuyenKeHoach = LuongTuyen.SoChuyenKeHoach,
                                    SoChuyenQuyHoach = LuongTuyen.SoChuyenQuyHoach,
                                    SoChuyenThucHien = LuongTuyen.SoChuyenThucHien,
                                    SoLuotKhach = LuongTuyen.SoLuotKhach,
                                    TenTuyen = LuongTuyen.TenTuyen,
                                    TyLeXuatBen = LuongTuyen.TyLeXuatBen,
                                    Tu = dt1,
                                    Den = dt2,
                                    URL = Url.Action("BaoCaoHoatDong_Tuyen", "BaoCaoHoatDong") + "?name=a&Tu=" + dt1 + "&Den=" + dt2 + "&So=" + SO + "&Ben=" + BEN + "&Tuyen=" + LuongTuyen.LT_IdLuongTuyen
                                };
                                List_TraVe.Add(ob);
                            }
                        }
                        string TU = Convert.ToString(dt1); string[] TU1 = TU.Split('/');
                        string DEN = Convert.ToString(dt2); string[] DEN1 = DEN.Split('/');
                        var bien = new
                        {
                            Ngay = TU1[0],
                            Thang = TU1[1],
                            Nam = TU1[2],
                            Ngay1 = DEN1[0],
                            Thang1 = DEN1[0],
                            Nam1 = DEN1[0],
                            Tu = TU,
                            Den = DEN,
                            So = SO,
                            Ben = BEN,
                            Tuyen = mangtuyen.Count,
                            //TenTuyen = LayTenCacTuyenCuaBen_TheoIdBen(BEN, mang1)
                        };
                        var oo = new
                        {
                            ListTraVe = List_TraVe,
                            BienToanQuoc = bien,
                            ThongTinBen = ThongTinBenXe(BEN)
                        };
                        return oo;
                    }
                }
            }
            return List_TraVe;
        }
        //BÁO CÁO HOẠT ĐỘNG TỔNG HỢP TOÀN QUỐC CHO NHIỀU SỞ
        private object GetBaoCaoToanQuocNhieuSo(string name, string dt1, string dt2, string so)
        {
            List<object> List_TraVe = new List<object>();
            var ten = Convert.ToString(name);
            if (so == "")
            {
                List_TraVe = Get_BaoCao_ToanQuoc(name, dt1, dt2);
                string TU = Convert.ToString(dt1); string[] TU1 = TU.Split('/');
                string DEN = Convert.ToString(dt2); string[] DEN1 = DEN.Split('/');
                var bien = new
                {
                    Ngay = TU1[0],
                    Thang = TU1[1],
                    Nam = TU1[2],
                    Ngay1 = DEN1[0],
                    Thang1 = DEN1[0],
                    Nam1 = DEN1[0],
                    SoSoGet = "Tất Cả"
                };
                var oo = new
                {
                    ListTraVe = List_TraVe,
                    BienToanQuoc = bien
                };
                return oo;
            }            
            if (ten == null)
            {
                if (so.IndexOf("-1") > -1)
                {
                    List_TraVe = Get_BaoCao_ToanQuoc(name, dt1, dt2);
                    string TU = Convert.ToString(dt1); string[] TU1 = TU.Split('/');
                    string DEN = Convert.ToString(dt2); string[] DEN1 = DEN.Split('/');
                    var bien = new
                    {
                        Ngay = TU1[0],
                        Thang = TU1[1],
                        Nam = TU1[2],
                        Ngay1 = DEN1[0],
                        Thang1 = DEN1[0],
                        Nam1 = DEN1[0],
                        SoSoGet = "Tất Cả"
                    };
                    var oo = new
                    {
                        ListTraVe = List_TraVe,
                        BienToanQuoc = bien
                    };
                    return oo;
                }
                else
                {
                    ArrayList mangso = new ArrayList(so.Split(new char[] { ',' }));
                    mangso.RemoveAt(0);
                    mangso.RemoveAt(mangso.Count - 1);
                    List<sp_HD_BaoCaoTongHop_ToanQuoc_Result> list = new List<sp_HD_BaoCaoTongHop_ToanQuoc_Result>();
                    list = bc.Get_BaoCaoTongHop_ToanQuoc(dt1, dt2);
                    for (var i = 0; i < mangso.Count; i++)
                    {
                        int idso = Convert.ToInt32(mangso[i]);
                        sp_HD_BaoCaoTongHop_ToanQuoc_Result TinhSo = list.Where(u => u.TS_IdTinh_So == idso).FirstOrDefault();
                        if (TinhSo != null)
                        {
                            var ob = new
                            {
                                TS_IdTinh_So = TinhSo.TS_IdTinh_So,
                                TS_TenTinh = TinhSo.TS_TenTinh,
                                TyLeThucHien = TinhSo.TyLeThucHien,
                                SoChuenDangKy = TinhSo.SoChuenDangKy,
                                SoLuotKhach = TinhSo.SoLuotKhach,
                                SoLuotXuatBen = TinhSo.SoLuotXuatBen,
                                SoBen = TinhSo.SoBen,
                                SoXe = TinhSo.SoXe,
                                TongCongSuat = TinhSo.TongCongSuat,
                                TongSoTuyen = TinhSo.TongSoTuyen,
                                TrangThaiTruyenDan = TinhSo.TrangThaiTruyenDan,
                                Tu = dt1,
                                Den = dt2,
                                URL = Url.Action("BaoCaoHoatDong_So", "BaoCaoHoatDong") + "?name=a&Tu=" + dt1 + "&Den=" + dt2 + "&So=" + TinhSo.TS_IdTinh_So
                            };
                            List_TraVe.Add(ob);
                        }
                    }
                    string TU = Convert.ToString(dt1); string[] TU1 = TU.Split('/');
                    string DEN = Convert.ToString(dt2); string[] DEN1 = DEN.Split('/');
                    var bien = new
                    {
                        Ngay = TU1[0],
                        Thang = TU1[1],
                        Nam = TU1[2],
                        Ngay1 = DEN1[0],
                        Thang1 = DEN1[0],
                        Nam1 = DEN1[0],
                        SoSoGet = mangso.Count
                    };
                    var oo = new
                    {
                        ListTraVe = List_TraVe,
                        BienToanQuoc = bien
                    };
                    return oo;
                }
            }
            else if (ten == "a")
            {
                if (so.IndexOf("-1") > -1)
                {
                    List_TraVe = Get_BaoCao_ToanQuoc(name, dt1, dt2);
                    string TU = Convert.ToString(dt1); string[] TU1 = TU.Split('/');
                    string DEN = Convert.ToString(dt2); string[] DEN1 = DEN.Split('/');
                    var bien = new
                    {
                        Ngay = TU1[0],
                        Thang = TU1[1],
                        Nam = TU1[2],
                        Ngay1 = DEN1[0],
                        Thang1 = DEN1[0],
                        Nam1 = DEN1[0],
                        SoSoGet = "Tất Cả"
                    };
                    var oo = new
                    {
                        ListTraVe = List_TraVe,
                        BienToanQuoc = bien
                    };
                    return oo;
                }
                else
                {
                    ArrayList mangso = new ArrayList(so.Split(new char[] { ',' }));
                    mangso.RemoveAt(0);
                    mangso.RemoveAt(mangso.Count - 1);
                    List<sp_HD_BaoCaoTongHop_ToanQuoc_Result> list = new List<sp_HD_BaoCaoTongHop_ToanQuoc_Result>();
                    list = bc.Get_BaoCaoTongHop_ToanQuoc(dt1, dt2);
                    for (var i = 0; i < mangso.Count; i++)
                    {
                        int idso = Convert.ToInt32(mangso[i]);
                        sp_HD_BaoCaoTongHop_ToanQuoc_Result TinhSo = list.Where(u => u.TS_IdTinh_So == idso).FirstOrDefault();
                        if (TinhSo != null)
                        {
                            var ob = new
                            {
                                TS_IdTinh_So = TinhSo.TS_IdTinh_So,
                                TS_TenTinh = TinhSo.TS_TenTinh,
                                TyLeThucHien = TinhSo.TyLeThucHien,
                                SoChuenDangKy = TinhSo.SoChuenDangKy,
                                SoLuotKhach = TinhSo.SoLuotKhach,
                                SoLuotXuatBen = TinhSo.SoLuotXuatBen,
                                SoBen = TinhSo.SoBen,
                                SoXe = TinhSo.SoXe,
                                TongCongSuat = TinhSo.TongCongSuat,
                                TongSoTuyen = TinhSo.TongSoTuyen,
                                TrangThaiTruyenDan = TinhSo.TrangThaiTruyenDan,
                                Tu = dt1,
                                Den = dt2,
                                URL = Url.Action("BaoCaoHoatDong_So", "BaoCaoHoatDong") + "?name=a&Tu=" + dt1 + "&Den=" + dt2 + "&So=" + TinhSo.TS_IdTinh_So
                            };
                            List_TraVe.Add(ob);
                        }
                    }
                    string TU = Convert.ToString(dt1); string[] TU1 = TU.Split('/');
                    string DEN = Convert.ToString(dt2); string[] DEN1 = DEN.Split('/');
                    var bien = new
                    {
                        Ngay = TU1[0],
                        Thang = TU1[1],
                        Nam = TU1[2],
                        Ngay1 = DEN1[0],
                        Thang1 = DEN1[0],
                        Nam1 = DEN1[0],
                        SoSoGet = mangso.Count
                    };
                    var oo = new
                    {
                        ListTraVe = List_TraVe,
                        BienToanQuoc = bien
                    };
                    return oo;
                }
            }            
            return List_TraVe;
        }
        #endregion

        #region COMBOBOX SỞ BẾN TUYẾN
        //COMBOBOX SỞ CHỌN RA BẾN CỦA SỞ
        [HttpPost]
        public string GetBaoCaoHoatDongBen_SoRaBen(int idso)
        {
            return JsonConvert.SerializeObject(Get_List_Ben_TheoIDSo(idso));
        }
        //COMBOBOX BẾN CHỌN RA TUYẾN
        [HttpPost]
        public string GetBaoCaoHoatDongBen_ChonBen_RaTuyen(int idben)
        {
            if (idben == -2)
            {
                var oo = new
                {
                    ListTraVe = "",
                    ThongTinBen = ""
                };
                return JsonConvert.SerializeObject(oo);
            }
            else
            {
                var oo = new
                {
                    ListTraVe = Get_List_Tuyen_TheoBen(idben),
                    ThongTinBen = ThongTinBenXe(idben)
                };
                return JsonConvert.SerializeObject(oo);
            }
        }
        [HttpPost]
        public string GetBaoCaoHoatDongBen_ChonBen_RaTuyen1(int idben)
        {
            if (idben == -2)
            {
                var oo = new
                {
                    ListTraVe = "Không Có",
                    ThongTinBen = ""
                };
                return JsonConvert.SerializeObject(oo);
            }
            else
            {
                List<object> li = Get_List_Tuyen_TheoBen(idben);
                if (li != null)
                {
                    li.RemoveAt(0);
                    var oo = new
                    {
                        ListTraVe = li,
                        ThongTinBen = ThongTinBenXe(idben)
                    };
                    return JsonConvert.SerializeObject(oo);
                }
                else
                {
                    var oo = new
                    {
                        ListTraVe = "Không Có",
                        ThongTinBen = ThongTinBenXe(idben)
                    };
                    return JsonConvert.SerializeObject(oo);
                }
            }
        }
        [HttpPost]
        public string GetBaoCaoHoatDongBen_ChonBen_RaTuyen2(int idben)
        {
            if (idben == -2)
            {
                var oo = new
                {
                    ListTraVe = "Không Có",
                    ThongTinTuyen = ""
                };
                return JsonConvert.SerializeObject(oo);
            }
            else
            {
                int BEN = Convert.ToInt32(idben);
                long TUYEN = bc.Get_Id_TuyenDauTien_CuaBen(BEN);
                List<object> li = Get_List_Tuyen_TheoBen(BEN);
                if (li != null)
                {
                    li.RemoveAt(0);
                    var oo = new
                    {
                        ListTraVe = li,
                        ThongTinTuyen = ThongTinTuyen(TUYEN)
                    };
                    return JsonConvert.SerializeObject(oo);
                }
                else
                {
                    var oo = new
                    {
                        ListTraVe = "Không Có",
                        ThongTinTuyen = ThongTinTuyen(TUYEN)
                    };
                    return JsonConvert.SerializeObject(oo);
                }
            }
        }
        [HttpPost]
        public string GetDanhSachCongTyVanTai_TrenTuyen_TheoIdTuyen(long idtuyen)
        {
            return JsonConvert.SerializeObject(Get_List_DVVT_TheoIDTuyen(idtuyen));
        }
        [HttpPost]
        public string GetDanhSachCongTyVanTai_TrenTuyen_TheoIdTuyen1(long idtuyen)
        {
            var ob = new
            {
                List_DVVT = Get_List_DVVT_TheoIDTuyen1(idtuyen),
                ThongTinTuyen = ThongTinTuyen(idtuyen)
            };
            return JsonConvert.SerializeObject(ob);
        }
        [HttpPost]
        public string GetCongTyVanTai_TheoIdDVVT(int idDvvt)
        {
            return JsonConvert.SerializeObject(ThongTinDVVT(idDvvt));
        }
        [HttpPost]
        public string GetTuyen_TheoIdTuyen(long idtuyen)
        {
            return JsonConvert.SerializeObject(ThongTinTuyen(idtuyen));
        }
        #endregion

        #region CLICK CHO NHIỀU
        //HOẠT ĐỘNG TOÀN QUỐC
        [HttpPost]
        public string GetBaoCaoHoatDongToanQuoc_NhieuSo(string name, string dt1, string dt2, string so)
        {
            return JsonConvert.SerializeObject(GetBaoCaoToanQuocNhieuSo(name, dt1, dt2, so));
        }
        //HOẠT ĐỘNG BẾN 
        [HttpPost]
        public string GetBaoCaoHoatDongben_NhieuTuyen(string name, int so, int ben, string dt1, string dt2, string tuyen)
        {
            return JsonConvert.SerializeObject(GetBaoCaoHoatDongBen(name, so, ben, dt1, dt2, tuyen));
        }
        //GetBaoCaoHoatDongSo_NhieuBen
        private Dictionary<string, int> GetSoLuot_KhachXuatBen(int mIdBenXe, DateTime mDateBatDau, DateTime mDateKetThuc)
        {
            try
            {
                var dbc = new QLVanTai_2017();
                mDateBatDau.AddDays(-1);
                mDateKetThuc.AddDays(1);
                var lstNhatTrinh = dbc.NhatTrinhXes
                    .Where(c => c.GioCapXuatBen > mDateBatDau && c.GioCapXuatBen < mDateKetThuc && c.IdBenDi == mIdBenXe)
                    .Select(s => s.SoKhach)
                    .ToList();
                Dictionary<string, int> lst = new Dictionary<string, int>();
                lst.Add("SoLuotXuatBen", lstNhatTrinh.Count);
                lst.Add("SoKhach", Convert.ToInt32(lstNhatTrinh.Sum()));
                return lst;
            }
            catch
            {
                throw new Exception("Tính số lượt bến thất bại.");
            }
        }

        private int GetSoChuyenDangKy(int mIdBenXe, int soNgay)
        {
            try
            {
                var dbc = new QLVanTai_2017();

                var lstXe = (from ttXeBeta in dbc.QLVT_ThongTinXe_beta
                             join ttXe in dbc.QLVT_ThongTinXe on ttXeBeta.TX_IdXe equals ttXe.TX_IdXe
                             join luongTuyen in dbc.QLVT_LuongTuyen on ttXe.LT_IdLuongTuyen equals luongTuyen.LT_IdLuongTuyen
                             join diemDauCuoi in dbc.QLVT_LuongTuyen_DiemDauCuoi on luongTuyen.LT_IdLuongTuyen equals diemDauCuoi
                                 .LT_DC_IdLuongTuyen
                             where diemDauCuoi.LT_DC_IdBen_01 == mIdBenXe
                             select ttXeBeta.TX_TanXuatNgay * soNgay
                ).Sum();
                return Convert.ToInt32(lstXe);
            }
            catch
            {
                throw new Exception("Tính số chuyến đăng bến thất bại.");
            }
        }       

        [HttpPost]
        public string GetBaoCaoHoatDongSo_NhieuBen(string lstBen, string dateBatDau, string dateKetThuc, int idso)
        {
            try
            {
                var lstBenXe = GetNhieuBen(lstBen, dateBatDau, dateKetThuc, idso);
                if (lstBenXe.Count < 1)
                {
                    lstBenXe = null;
                }

                return JsonConvert.SerializeObject(lstBenXe);
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region BÁO CÁO SỞ
        private ActionResult BaoCaoHoatDong_SoDefault()
        {
            ViewBag.List_So = Get_List_So();
            ViewBag.List_Ben = Get_List_Ben_TheoIDSo(55);
            ViewBag.List_Ben.Insert(0, new { BX_IdBenXe = "-1", TenBenXe = "Tất cả" });
            string dateBatDau = "01/" + DateTime.Now.ToString("MM/yyyy");
            string dateKetThuc = DateTime.Now.ToString("dd/MM/yyyy");

            int So = 55; // default Sở
            string name = "a"; // default name

            string stBen = ",";
            foreach (var v in ViewBag.List_Ben)
            {
                stBen += v.BX_IdBenXe + ",";
            }

            ViewBag.BaoCaoTongHop_So = GetNhieuBen(stBen, dateBatDau, dateKetThuc, 55);
            var bien = new
            {
                name,
                dateBatDau,
                dateKetThuc,
                So
            };
            ViewBag.BienCuaSo = bien;
            return View();
        }

        public ActionResult BaoCaoHoatDong_So()
        {
            return BaoCaoHoatDong_SoDefault();
        }

        [HttpGet]
        public ActionResult BaoCaoHoatDong_So(string name, string Tu, string Den, int? So = -1)
        {
            if (So != -1)
            {
                ViewBag.List_So = Get_List_So();
                ViewBag.List_Ben = Get_List_Ben_TheoIDSo(Convert.ToInt32(So));
                ViewBag.List_Ben.Insert(0, new { BX_IdBenXe = "-1", TenBenXe = "Tất cả" });
                int SO = Convert.ToInt32(So);
                string stBen = ",";
                foreach (var v in ViewBag.List_Ben)
                {
                    stBen += v.BX_IdBenXe + ",";
                }

                ViewBag.BaoCaoTongHop_So = GetNhieuBen(stBen, Tu, Den, SO);
                var bien = new
                {
                    name,
                    dateBatDau = Tu,
                    dateKetThuc = Den,
                    So
                };
                ViewBag.BienCuaSo = bien;
            }
            else
            {
                return BaoCaoHoatDong_SoDefault();
            }

            return View();
        }
        private List<object> GetNhieuBen(string lstBen, string dateBatDau, string dateKetThuc, int idso)
        {
            List<object> list_return = new List<object>();
            List<sp_HD_BaoCaoTongHop_SoGiaoThong_Result> list = new List<sp_HD_BaoCaoTongHop_SoGiaoThong_Result>();
            list = bc.Get_BaoCaoTongHop_So(dateBatDau, dateKetThuc, idso, lstBen);
            if(list != null){
                foreach(var item in list){
                    var ob = new
                    {
                        item.BX_IdBenXe,
                        item.LoaiBenXe,
                        item.SoChuyenDangKy,
                        item.SoChuyenThucHien,
                        item.SoLuotXuatBenQuyHoach,
                        item.TenBenXe,
                        item.TongSoTuyen,
                        item.TongSoXe,
                        item.TongTaiTrong,
                        item.TrangThaiTruyenDan,
                        item.TyLeThucHien
                    };
                    list_return.Add(ob);
                }
            }
            return list_return;
        }
        #endregion

        #region BÁO CÁO ĐƠN VỊ VẬN TẢI
        //BÁO CÁO CHO ĐƠN VỊ VẬN TẢI
        private List<object> Get_BaoCao_DVVT(string name, string tu, string den, int ben, long tuyen, int dvvt)
        {
            var ten = Convert.ToString(name);
            string TU = Convert.ToString(tu);
            string DEN = Convert.ToString(den);
            int BEN = Convert.ToInt32(ben);
            long TUYEN = Convert.ToInt64(tuyen);
            int DVVT = Convert.ToInt32(dvvt);
            List<object> list1 = new List<object>();
            if (ten == "")
            {
                List<sp_HD_BaoCaoTongHop_DonViVanTai_Result> list = new List<sp_HD_BaoCaoTongHop_DonViVanTai_Result>();
                list = bc.Get_BaoCaoTongHop_DVVT(TU, DEN, BEN, TUYEN, DVVT);
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
                        Thang = TU,
                        Nam = DEN,
                        Ben = BEN,
                        Tuyen = TUYEN,
                        dvvt = DVVT,
                        URL = Url.Action("NhatTrinhXe", "BaoCaoHoatDong") + "?tungay=" + TU + "&denngay=" + DEN + "&biensoxe=" + item.TX_BienSoXe + "&Tuyen=" + TUYEN + "&Dvvt=" + DVVT
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "a")
            {
                List<sp_HD_BaoCaoTongHop_DonViVanTai_Result> list = new List<sp_HD_BaoCaoTongHop_DonViVanTai_Result>();
                list = bc.Get_BaoCaoTongHop_DVVT(TU, DEN, BEN, TUYEN, DVVT);
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
                        Thang = TU,
                        Nam = DEN,
                        Ben = BEN,
                        Tuyen = TUYEN,
                        dvvt = DVVT,
                        URL = Url.Action("NhatTrinhXe", "BaoCaoHoatDong") + "?tungay=" + TU + "&denngay=" + DEN + "&biensoxe=" + item.TX_BienSoXe + "&Tuyen=" + TUYEN + "&Dvvt=" + DVVT
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            //else if (ten == "b")
            //{
            //    List<sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai_Result> list = new List<sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai_Result>();
            //    list = bc.Get_BaoCaoXeKhongHoatDong_DVVT(THANG, NAM, SO, TUYEN, DVVT);
            //    foreach (var item in list)
            //    {
            //        var ob = new
            //        {
            //            SoLuotKhongXuatBen = item.SoLuotKhongXuatBen,
            //            TaiTrong = item.TaiTrong,
            //            TX_BienSoXe = item.TX_BienSoXe,
            //            TX_BX_TongLuotVanChuyen = item.TX_BX_TongLuotVanChuyen,
            //            TX_IdXe = item.TX_IdXe,
            //            TyLeVanChuyen = item.TyLeVanChuyen,
            //            Thang = THANG,
            //            Nam = NAM,
            //            So = SO,
            //            Tuyen = TUYEN,
            //            dvvt = DVVT,
            //            URL = "/BaoCaoHoatDong/NhatTrinhXe?tungay=" + sdt1 + "&denngay=" + sdt2 + "&biensoxe=" + item.TX_BienSoXe + "&Tuyen=" + TUYEN + "&Dvvt=" + DVVT
            //        };
            //        list1.Add(ob);
            //    }
            //    return list1;
            //}
            //else if (ten == "d")
            //{
            //    List<sp_HD_BaoCaoXeChayNhoHon70_DonViVanTai_Result> list = new List<sp_HD_BaoCaoXeChayNhoHon70_DonViVanTai_Result>();
            //    list = bc.Get_BaoCaoXeChayNhoHon70_DVVT(THANG, NAM, SO, TUYEN, DVVT);
            //    foreach (var item in list)
            //    {
            //        var ob = new
            //        {
            //            TongSoKhach = item.TongSoKhach,
            //            SoLuotXuatBen = item.SoLuotXuatBen,
            //            TaiTrong = item.TaiTrong,
            //            TX_BienSoXe = item.TX_BienSoXe,
            //            TX_BX_TongLuotVanChuyen = item.TX_BX_TongLuotVanChuyen,
            //            TX_IdXe = item.TX_IdXe,
            //            TyLeVanChuyen = item.TyLeVanChuyen,
            //            Thang = THANG,
            //            Nam = NAM,
            //            So = SO,
            //            Tuyen = TUYEN,
            //            dvvt = DVVT,
            //            URL = "/BaoCaoHoatDong/NhatTrinhXe?tungay=" + sdt1 + "&denngay=" + sdt2 + "&biensoxe=" + item.TX_BienSoXe + "&Tuyen=" + TUYEN + "&Dvvt=" + DVVT
            //        };
            //        list1.Add(ob);
            //    }
            //    return list1;
            //}
            return list1;
        }
        //BÁO CÁO CHO ĐƠN VỊ VẬN TẢI CLICK EVENT
        [HttpPost]
        public string GetBaoCaoChoDonViVanTaiAll(string name, string tu, string den, int ben, long tuyen, int dvvt)
        {
            var ob = new
            {
                Name = name,
                Tu = tu,
                Den = den,
                Ben = ben,
                Tuyen = tuyen,
                DVVT = dvvt
            };
            var oo = new
            {
                ListTraVe = Get_BaoCao_DVVT(name, tu, den, ben, tuyen, dvvt),
                BienToanQuoc = ob,
                ThongTinBen = ThongTinBenXe(ben),
                ThongTinDVVT = ThongTinDVVT(dvvt)
            };
            return JsonConvert.SerializeObject(oo);
        }
        [HttpGet]
        public ActionResult BaoCaoHoatDong_DonViVanTai(int? idSo, int? idBen, int? idDonVi, long? idTuyen, string dateBatDau, string dateKetThuc)
        {
            List<object> List_Return = new List<object>();
            if (idSo.HasValue)
            {
                ViewBag.List_So = bc.Get_DanhSachAll_So_KhongChon();//Get_List_So();
                int SO = Convert.ToInt32(idSo); //Của Thái Nguyên
                ViewBag.List_Ben = Get_List_Ben_TheoIDSo(SO);

                int BEN = Convert.ToInt32(idBen);//bc.Get_DanhSachBenXe_CuaSoGiaoThong(SO).FirstOrDefault().BX_IdBenXe; //defaut Bến   
                long TUYEN = Convert.ToInt64(idTuyen);//bc.Get_Id_TuyenDauTien_CuaBen(BEN); // default Tuyến
                int idcongtyfirst = Convert.ToInt32(idDonVi); ;
                ViewBag.List_Tuyen = bc.Get_DanhSachAll_Tuyen_CuaBen_KhongTatCa(BEN);
                ViewBag.List_DVVT = Get_List_DVVT_TheoIDTuyen(TUYEN);

                //int ngay_hientai = Convert.ToInt32(DateTime.Now.Day);
                //int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
                //int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
                //string dt = ngay_hientai + "/" + thang_hientai + "/" + nam_hientai;
                var ten = Convert.ToString("a"); // default name
                string[] dt1 = dateBatDau.Split('/');
                string[] dt2 = dateKetThuc.Split('/');
                List_Return = Get_BaoCao_DVVT(ten, dateBatDau, dateKetThuc, BEN, TUYEN, idcongtyfirst);
                ViewBag.BaoCaoTongHop_DVVT = List_Return;
                var bien = new
                {
                    Ngay = dt1[0],
                    Thang = dt1[1],
                    Nam = dt1[2],
                    Ngay1 = dt2[0],
                    Thang1 = dt2[1],
                    Nam1 = dt2[2],
                    So = SO,
                    Ben = BEN,
                    Tuyen = TUYEN,
                    Dvvt = idcongtyfirst
                };
                ViewBag.BienCuaDVVT = bien;
                ViewBag.ThongTinBenTheoID = ThongTinBenXe(BEN);
                ViewBag.ThongTinDVTTTheoID = ThongTinDVVT(idcongtyfirst);
                return View();
            }
            else
            {
                ViewBag.List_So = bc.Get_DanhSachAll_So_KhongChon();//Get_List_So();
                int SO = 55; //Của Thái Nguyên
                ViewBag.List_Ben = Get_List_Ben_TheoIDSo(SO);

                int BEN = bc.Get_DanhSachBenXe_CuaSoGiaoThong(SO).FirstOrDefault().BX_IdBenXe; //defaut Bến   
                long TUYEN = bc.Get_Id_TuyenDauTien_CuaBen(BEN); // default Tuyến
                int idcongtyfirst = bc.Get_Id_DonViDauTin_CuaTuyen(TUYEN);

                ViewBag.List_Tuyen = bc.Get_DanhSachAll_Tuyen_CuaBen_KhongTatCa(BEN); ;//Get_List_Tuyen_TheoBen(BEN);
                ViewBag.List_DVVT = Get_List_DVVT_TheoIDTuyen(TUYEN);

                int ngay_hientai = Convert.ToInt32(DateTime.Now.Day);
                int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
                int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
                string d = 1 + "/" + thang_hientai + "/" + nam_hientai;
                string dt = ngay_hientai + "/" + thang_hientai + "/" + nam_hientai;
                var ten = Convert.ToString("a"); // default name

                List_Return = Get_BaoCao_DVVT(ten, d, dt, BEN, TUYEN, idcongtyfirst);
                ViewBag.BaoCaoTongHop_DVVT = List_Return;
                var bien = new
                {
                    Ngay = 1,
                    Thang = thang_hientai,
                    Nam = nam_hientai,
                    Ngay1 = ngay_hientai,
                    Thang1 = thang_hientai,
                    Nam1 = nam_hientai,
                    So = SO,
                    Ben = BEN,
                    Tuyen = TUYEN,
                    Dvvt = idcongtyfirst
                };
                ViewBag.BienCuaDVVT = bien;
                ViewBag.ThongTinBenTheoID = ThongTinBenXe(BEN);
                ViewBag.ThongTinDVTTTheoID = ThongTinDVVT(idcongtyfirst);
                return View();
            }
        }
        #endregion

        #region BÁO CÁO BẾN
        //BÁO CÁO CHO BẾN
        private List<object> Get_BaoCao_Ben(string name, int ben, string dt1, string dt2, int so)
        {
            var ten = Convert.ToString(name);
            int BEN = Convert.ToInt32(ben);
            int SO = Convert.ToInt32(so);
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
            if (ten == null)
            {
                List<sp_HD_BaoCaoTongHopTaiBen_Result> list = new List<sp_HD_BaoCaoTongHopTaiBen_Result>();
                list = bc.Get_BaoCaoTongHop_Ben(D1, D2, BEN);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        LT_CuLy = item.LT_CuLy,
                        LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                        LT_MaTuyen = item.LT_MaTuyen,
                        SoChuyenKeHoach = item.SoChuyenKeHoach,
                        SoChuyenQuyHoach = item.SoChuyenQuyHoach,
                        SoChuyenThucHien = item.SoChuyenThucHien,
                        SoLuotKhach = item.SoLuotKhach,
                        TenTuyen = item.TenTuyen,
                        TongSoDonVi = item.TongSoDonVi,
                        TrangThaiTruyenDan = item.TrangThaiTruyenDan,
                        TyLeXuatBen = item.TyLeXuatBen,        
                        Ben = BEN,
                        So = SO,
                        TuNgay = intNgayBatDau,
                        TuThang = intThangBatDau,
                        TuNam = intNamBatDau,
                        DenNgay = intNgayKetThuc,
                        DenThang = intThangKetThuc,
                        DenNam = intNamKetThuc,
                        URL = Url.Action("BaoCaoHoatDong_Tuyen", "BaoCaoHoatDong") + "?nam=a&Tu=" + D1 + "&Den=" + D2 + "&So=" + SO + "&Ben=" + BEN + "&Tuyen=" + item.LT_IdLuongTuyen
                    };
                    list1.Add(ob);
                }
                return list1;
            }
            else if (ten == "a")
            {
                List<sp_HD_BaoCaoTongHopTaiBen_Result> list = new List<sp_HD_BaoCaoTongHopTaiBen_Result>();
                list = bc.Get_BaoCaoTongHop_Ben(D1, D2, BEN);
                foreach (var item in list)
                {
                    var ob = new
                    {
                        LT_CuLy = item.LT_CuLy,
                        LT_IdLuongTuyen = item.LT_IdLuongTuyen,
                        LT_MaTuyen = item.LT_MaTuyen,
                        SoChuyenKeHoach = item.SoChuyenKeHoach,
                        SoChuyenQuyHoach = item.SoChuyenQuyHoach,
                        SoChuyenThucHien = item.SoChuyenThucHien,
                        SoLuotKhach = item.SoLuotKhach,
                        TenTuyen = item.TenTuyen,
                        TongSoDonVi = item.TongSoDonVi,
                        TrangThaiTruyenDan = item.TrangThaiTruyenDan,
                        TyLeXuatBen = item.TyLeXuatBen,
                        Ben = BEN,
                        So = SO,
                        TuNgay = intNgayBatDau,
                        TuThang = intThangBatDau,
                        TuNam = intNamBatDau,
                        DenNgay = intNgayKetThuc,
                        DenThang = intThangKetThuc,
                        DenNam = intNamKetThuc,
                        URL = Url.Action("BaoCaoHoatDong_Tuyen", "BaoCaoHoatDong") + "?name=a&Tu=" + D1 + "&Den=" + D2 + "&So=" + SO + "&Ben=" + BEN + "&Tuyen=" + item.LT_IdLuongTuyen
                    };
                    list1.Add(ob);
                }
                return list1;
            }            
            return list1;
        }
        public string LayTenCacTuyenCuaBen_TheoIdBen(int idben, long[] array)
        {
            int BEN = Convert.ToInt32(idben);
            string chuoiTuyen = bc.Get_DanhSachAll_TenTuyen_CuaBen_KhongTatCa(BEN, array);
            return chuoiTuyen;
        }
        public ActionResult BaoCaoHoatDong_Ben()
        {
            List<object> List_Return = new List<object>();
            int ngay_hientai = Convert.ToInt32(DateTime.Now.Day);
            int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
            int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
            DateTime dtStart = new DateTime(nam_hientai, thang_hientai, 1);
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

            int SO = 55; // defaut Sở
            int BEN = bc.Get_DanhSachBenXe_CuaSoGiaoThong(SO).FirstOrDefault().BX_IdBenXe; //defaut Bến   
            long TUYEN = bc.Get_Id_TuyenDauTien_CuaBen(BEN); // default Tuyến
            var ten = Convert.ToString("a"); //default name
            List_Return = Get_BaoCao_Ben(ten, BEN, sdt1, sdt2, SO);
            ViewBag.BaoCaoTongHop_Ben = List_Return;
            ViewBag.List_So = Get_List_So();
            ViewBag.List_Ben = Get_List_Ben_TheoIDSo(55);
            ViewBag.List_Tuyen = Get_List_Tuyen_TheoBen(BEN);
            var bien = new
            {
                So = SO,
                Ben = BEN,
                Tuyen = TUYEN,
                Ngay = intNgayBatDau,
                Thang = intThangBatDau,
                Nam = intNamBatDau,
                Ngay1 = intNgayKetThuc,
                Thang1 = intThangKetThuc,
                Nam1 = intNamKetThuc
            };
            ViewBag.BienCuaBen = bien;
            ViewBag.ThongTinBenTheoID = ThongTinBenXe(BEN);
            return View();
        }
        [HttpGet]
        public ActionResult BaoCaoHoatDong_Ben(string name, int? ben, string dt1, string dt2, int? So = -1)
        {
            List<object> List_Return = new List<object>();
            if (So != -1)
            {
                var ten = Convert.ToString(name);
                int BEN = Convert.ToInt32(ben);
                string D1 = Convert.ToString(dt1);
                string D2 = Convert.ToString(dt2);
                int SO = Convert.ToInt32(So);
                List_Return = Get_BaoCao_Ben(ten, BEN, D1, D2, SO);

                string[] DTT1 = D1.Split('/');
                string[] DTT2 = D2.Split('/');
                int intNgayBatDau = Convert.ToInt32(DTT1[0]);
                int intThangBatDau = Convert.ToInt32(DTT1[1]);
                int intNamBatDau = Convert.ToInt32(DTT1[2]);

                int intNgayKetThuc = Convert.ToInt32(DTT2[0]);
                int intThangKetThuc = Convert.ToInt32(DTT2[1]);
                int intNamKetThuc = Convert.ToInt32(DTT2[2]);
                long TUYEN = bc.Get_Id_TuyenDauTien_CuaBen(BEN);
                ViewBag.List_So = Get_List_So();
                ViewBag.List_Ben = Get_List_Ben_TheoIDSo(SO);
                ViewBag.List_Tuyen = Get_List_Tuyen_TheoBen(BEN);
                ViewBag.BaoCaoTongHop_Ben = List_Return;
                var bien = new
                {
                    So = SO,
                    Ben = BEN,
                    Tuyen = "Tất Cả",
                    Ngay = intNgayBatDau,
                    Thang = intThangBatDau,
                    Nam = intNamBatDau,
                    Ngay1 = intNgayKetThuc,
                    Thang1 = intThangKetThuc,
                    Nam1 = intNamKetThuc
                };
                ViewBag.BienCuaBen = bien;
                ViewBag.ThongTinBenTheoID = ThongTinBenXe(BEN);
                return View();
            }
            else
            {
                int ngay_hientai = Convert.ToInt32(DateTime.Now.Day);
                int thang_hientai = Convert.ToInt32(DateTime.Now.Month);
                int nam_hientai = Convert.ToInt32(DateTime.Now.Year);
                DateTime dtStart = new DateTime(nam_hientai, thang_hientai, 1);
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

                int SO = 55; // defaut Sở
                int BEN = bc.Get_DanhSachBenXe_CuaSoGiaoThong(SO).FirstOrDefault().BX_IdBenXe; //defaut Bến   
                long TUYEN = bc.Get_Id_TuyenDauTien_CuaBen(BEN); // default Tuyến
                var ten = Convert.ToString("a"); //default name
                List_Return = Get_BaoCao_Ben(ten, BEN, sdt1, sdt2, SO);
                ViewBag.BaoCaoTongHop_Ben = List_Return;
                ViewBag.List_So = Get_List_So();
                ViewBag.List_Ben = Get_List_Ben_TheoIDSo(55);
                ViewBag.List_Tuyen = Get_List_Tuyen_TheoBen(BEN);
                var bien = new
                {
                    So = SO,
                    Ben = BEN,
                    Tuyen = "Tất Cả",
                    Ngay = 1,
                    Thang = intThangBatDau,
                    Nam = intNamBatDau,
                    Ngay1 = intNgayKetThuc,
                    Thang1 = intThangKetThuc,
                    Nam1 = intNamKetThuc
                };
                ViewBag.BienCuaBen = bien;
                ViewBag.ThongTinBenTheoID = ThongTinBenXe(BEN);
            }
            return View();
        }        
        #endregion

        #region HOẠT ĐỘNG THƯỜNG XUYÊN CHI TIẾT
        private ActionResult BaoCaoHoatDongThuongXuyenDefault()
        {
            try
            {
                int So = 55;
                int Ben = 1;
                string Ngay = DateTime.Now.ToString("dd/MM/yyy");
                ViewBag.LstSo = Get_List_So();
                ViewBag.LstBen = Get_List_Ben_TheoIDSo(Convert.ToInt32(So));
                var dbc = new QLVanTai_2017();
                ViewBag.LstXe = dbc.sp_BaoCaoHoatDongThuongXuyen_Ben(Ngay, Convert.ToInt32(Ben));

                dynamic DateDefault = new
                {
                    So,
                    Ben,
                    Ngay
                };

                ViewBag.DataDefault = DateDefault;
            }
            catch (Exception e)
            {
                return View();
            }
            return View();
        }

        public ActionResult BaoCaoHoatDongBenChiTiet()
        {
            return BaoCaoHoatDongThuongXuyenDefault();
        }

        [HttpGet]
        public ActionResult BaoCaoHoatDongBenChiTiet(int? So, int? Ben, string Ngay = "")
        {
            if (!Ngay.IsEmpty())
            {
                try
                {
                    ViewBag.LstSo = Get_List_So();
                    ViewBag.LstBen = Get_List_Ben_TheoIDSo(Convert.ToInt32(So));
                    var dbc = new QLVanTai_2017();
                    ViewBag.LstXe = dbc.sp_BaoCaoHoatDongThuongXuyen_Ben(Ngay, Convert.ToInt32(Ben));

                    var DataDefault = new
                    {
                        So,
                        Ben,
                        Ngay
                    };

                    ViewBag.DataDefault = DataDefault;
                }
                catch (Exception e)
                {
                    return View();
                }

            }
            else
            {
                return BaoCaoHoatDongBenChiTiet();
            }

            return View();
        }

        [HttpPost]
        public string GetBaoCaoHoatDongBenChiTiet(int? idBen, string Ngay)
        {
            var dbc = new QLVanTai_2017();
            return JsonConvert.SerializeObject(dbc.sp_BaoCaoHoatDongThuongXuyen_Ben(Ngay, Convert.ToInt32(idBen)));
        }
        #endregion
    }
}