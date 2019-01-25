using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThongTinVanTai.Data;
using TramTiepNhan.Models;

namespace TramTiepNhan.Controllers
{
    [RoutePrefix("~/BenXe")]
    public class BenXeController : ApiController
    {
        protected HeThongDataContext DB
        {
            get
            {
                return new HeThongDataContext();
            }
        }

        protected void Log (string data, string type = "Nhật ký trạm tiếp nhận")
        {
            try
            {
                var DB = this.DB;
                HT_NhatKy nk = new HT_NhatKy();
                nk.TenNhatKy = "Giao tiếp trạm tiếp nhận...";
                nk.LoaiNhatKy = type;
                nk.MoTa = data;

                nk.ThoiGianTao = DateTime.Now;

                DB.HT_NhatKies.InsertOnSubmit(nk);
                DB.SubmitChanges();
            }
            catch
            {

            }
        }

        public string Index ()
        {
            return "1.0.0";
        }

        public bool XeXuatBen ([FromBody] ThongTinXeXuatBen XeXuatBen)
        {
            string raw = Request.Content.ReadAsStringAsync().Result;
            if (XeXuatBen == null)
            {
                return false;
            }
            try
            {
                var DB = this.DB;
                var Xe = DB.QLVT_ThongTinXes.First(xe => xe.TX_BienSoXe == XeXuatBen.BienSoXe);
                var Tuyen = DB.QLVT_LuongTuyens.First(tuyen => tuyen.LT_IdLuongTuyen == Xe.LT_IdLuongTuyen);
                var DVVT = DB.QLVT_CongTyVanTais.First(dvvt => dvvt.CT_IdCongTyVT == Xe.CT_IdCongTyVT);

                DateTime? GioVaoBen = XeXuatBen.GioVaoBen != null && XeXuatBen.GioVaoBen.TotalMinutes > 0 ? new Nullable<DateTime>(DateTime.Today.Add(XeXuatBen.GioVaoBen)) : null;
                DateTime? GioXuatBenKeHoach = XeXuatBen.GioXuatBenKeHoach != null && XeXuatBen.GioXuatBenKeHoach.TotalMinutes > 0 ? new Nullable<DateTime>(DateTime.Today.Add(XeXuatBen.GioXuatBenKeHoach)) : null;
                DateTime? GioCapXuatBen = XeXuatBen.GioCapXuatBen != null && XeXuatBen.GioCapXuatBen.TotalMinutes > 0 ? new Nullable<DateTime>(DateTime.Today.Add(XeXuatBen.GioCapXuatBen)) : null;
                DateTime? GioRaBen = XeXuatBen.GioXuatBen != null && XeXuatBen.GioXuatBen.TotalMinutes > 0 ? new Nullable<DateTime>(DateTime.Today.Add(XeXuatBen.GioXuatBen)) : null;

                DB.NhatTrinhXes.InsertOnSubmit(new NhatTrinhXe()
                {
                    TX_IdXe = Xe.TX_IdXe,
                    IdBenDi = 1,
                    LT_IdLuongTuyen = Tuyen.LT_IdLuongTuyen,
                    CT_IdCongTyVT = DVVT.CT_IdCongTyVT,
                    BienSoDi = XeXuatBen.BienSoXe,
                    GioVaoBen = GioVaoBen,
                    GioXuatBenKeHoach = GioXuatBenKeHoach,
                    GioCapXuatBen = GioCapXuatBen,
                    GioRaBen = GioRaBen,
                    SoKhach = XeXuatBen.SoKhach,
                    XeXepKhach = XeXuatBen.XeXepKhach,
                    XeKhongDuDieuKien = XeXuatBen.XeKhongDuDieuKien,
                    XeTangCuong = XeXuatBen.XeTangCuong,
                    XeVeDonVi = XeXuatBen.XeVeDonViVanTai,
                    GhiChu = XeXuatBen.GhiChu,
                });

                DB.SubmitChanges();

                Log(raw);
            }
            catch (Exception ex)
            {
                Log(raw + "\n\n\n" + ex, "Exception");
                return false;
            }
            return true;
        }

        public bool XeDenBen([FromBody] ThongTinXeDenBen XeDenBen)
        {
            string raw = Request.Content.ReadAsStringAsync().Result;
            if (XeDenBen == null)
            {
                return false;
            }
            try
            {
                var DB = this.DB;
                var Xe = DB.QLVT_ThongTinXes.First(xe => xe.TX_BienSoXe == XeDenBen.BienSoXe);
                var Tuyen = DB.QLVT_LuongTuyens.First(tuyen => tuyen.LT_IdLuongTuyen == Xe.LT_IdLuongTuyen);
                var DVVT = DB.QLVT_CongTyVanTais.First(dvvt => dvvt.CT_IdCongTyVT == Xe.CT_IdCongTyVT);

                var NTX = DB.NhatTrinhXes.Where(
                    ntx => 
                        ntx.TX_IdXe == Xe.TX_IdXe
                        &&
                        ntx.LT_IdLuongTuyen == Tuyen.LT_IdLuongTuyen
                        &&
                        ntx.CT_IdCongTyVT == DVVT.CT_IdCongTyVT
                        &&
                        ntx.GioDenBen == null
                        &&
                        ntx.GioRaBen < DateTime.Now.Date + XeDenBen.GioDenBen
                ).OrderBy(ntx => ntx.Id).First();

                DateTime? GioDenBen = XeDenBen.GioDenBen != null && XeDenBen.GioDenBen.TotalMinutes > 0 ? new Nullable<DateTime>(DateTime.Today.Add(XeDenBen.GioDenBen)) : null;

                NTX.IdBenDen = 1;
                NTX.GioDenBen = GioDenBen;
                NTX.GhiChu += string.IsNullOrEmpty(XeDenBen.GhiChu) ? "" : "\n\n" + XeDenBen.GhiChu;

                DB.SubmitChanges();

                Log(raw);
            }
            catch (Exception ex)
            {
                Log(raw + "\n\n\n" + ex, "Exception");
                return false;
            }
            return true;
        }
    }
}
