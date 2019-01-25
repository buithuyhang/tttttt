﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QLVanTai_2017Entities : DbContext
    {
        public QLVanTai_2017Entities()
            : base("name=QLVanTai_2017Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BC_CapDonViVanTai> BC_CapDonViVanTai { get; set; }
        public virtual DbSet<BC_HoatDongCapSo> BC_HoatDongCapSo { get; set; }
        public virtual DbSet<BC_HoatDongCapTuyen> BC_HoatDongCapTuyen { get; set; }
        public virtual DbSet<BC_TongHop_Ben> BC_TongHop_Ben { get; set; }
        public virtual DbSet<HT_DonVi> HT_DonVi { get; set; }
        public virtual DbSet<HT_Quyen> HT_Quyen { get; set; }
        public virtual DbSet<HT_TaiKhoan> HT_TaiKhoan { get; set; }
        public virtual DbSet<HT_ThongTinTaiKhoan> HT_ThongTinTaiKhoan { get; set; }
        public virtual DbSet<NhatTrinhXe> NhatTrinhXes { get; set; }
        public virtual DbSet<QLVT_CapTuyenChoTinh_So> QLVT_CapTuyenChoTinh_So { get; set; }
        public virtual DbSet<QLVT_CongTyVanTai> QLVT_CongTyVanTai { get; set; }
        public virtual DbSet<QLVT_DanhSachCapTuyenChoDN> QLVT_DanhSachCapTuyenChoDN { get; set; }
        public virtual DbSet<QLVT_LuongTuyen> QLVT_LuongTuyen { get; set; }
        public virtual DbSet<QLVT_LuongTuyen_DiemDauCuoi> QLVT_LuongTuyen_DiemDauCuoi { get; set; }
        public virtual DbSet<QLVT_LuongTuyen_DiemDauCuoi_TrangThai> QLVT_LuongTuyen_DiemDauCuoi_TrangThai { get; set; }
        public virtual DbSet<QLVT_LuongTuyen_PhanLoai> QLVT_LuongTuyen_PhanLoai { get; set; }
        public virtual DbSet<QLVT_LuongTuyen_TrangThai> QLVT_LuongTuyen_TrangThai { get; set; }
        public virtual DbSet<QLVT_ThongTinBenXe> QLVT_ThongTinBenXe { get; set; }
        public virtual DbSet<QLVT_ThongTinTinh_So_Ben_TrangThai> QLVT_ThongTinTinh_So_Ben_TrangThai { get; set; }
        public virtual DbSet<QLVT_ThongTinTinh_SoGiaoThong> QLVT_ThongTinTinh_SoGiaoThong { get; set; }
        public virtual DbSet<QLVT_ThongTinXe> QLVT_ThongTinXe { get; set; }
        public virtual DbSet<QLVT_ThongTinXe_beta> QLVT_ThongTinXe_beta { get; set; }
        public virtual DbSet<QLVT_ThongTinXe_GSHT> QLVT_ThongTinXe_GSHT { get; set; }
        public virtual DbSet<QLVT_ThongTinXe_KEY_TABLE> QLVT_ThongTinXe_KEY_TABLE { get; set; }
        public virtual DbSet<QLVT_ThongTinXe_LichSuThayDoiHopDong> QLVT_ThongTinXe_LichSuThayDoiHopDong { get; set; }
        public virtual DbSet<QLVT_ThongTinXe_meta> QLVT_ThongTinXe_meta { get; set; }
        public virtual DbSet<QLVT_ThongTinXe_NhatTrinhXe> QLVT_ThongTinXe_NhatTrinhXe { get; set; }
        public virtual DbSet<QLVT_ThongTinXe_TrangThaiXe> QLVT_ThongTinXe_TrangThaiXe { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    
        public virtual ObjectResult<sp_HD_BaoCaoTongHop_DonViVanTai_Result> sp_HD_BaoCaoTongHop_DonViVanTai(Nullable<int> thang, Nullable<int> nam, Nullable<int> id_So, Nullable<long> id_Tuyen, Nullable<int> id_DonVi)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            var id_SoParameter = id_So.HasValue ?
                new ObjectParameter("Id_So", id_So) :
                new ObjectParameter("Id_So", typeof(int));
    
            var id_TuyenParameter = id_Tuyen.HasValue ?
                new ObjectParameter("Id_Tuyen", id_Tuyen) :
                new ObjectParameter("Id_Tuyen", typeof(long));
    
            var id_DonViParameter = id_DonVi.HasValue ?
                new ObjectParameter("Id_DonVi", id_DonVi) :
                new ObjectParameter("Id_DonVi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoTongHop_DonViVanTai_Result>("sp_HD_BaoCaoTongHop_DonViVanTai", thangParameter, namParameter, id_SoParameter, id_TuyenParameter, id_DonViParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoTongHop_SoGiaoThong_Result> sp_HD_BaoCaoTongHop_SoGiaoThong(Nullable<int> thang, Nullable<int> nam, Nullable<int> id_So)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            var id_SoParameter = id_So.HasValue ?
                new ObjectParameter("Id_So", id_So) :
                new ObjectParameter("Id_So", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoTongHop_SoGiaoThong_Result>("sp_HD_BaoCaoTongHop_SoGiaoThong", thangParameter, namParameter, id_SoParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoTongHop_ToanQuoc_Result> sp_HD_BaoCaoTongHop_ToanQuoc(Nullable<int> thang, Nullable<int> nam)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoTongHop_ToanQuoc_Result>("sp_HD_BaoCaoTongHop_ToanQuoc", thangParameter, namParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoTongHop_Tuyen_Result> sp_HD_BaoCaoTongHop_Tuyen(Nullable<int> thang, Nullable<int> nam, Nullable<int> id_So, Nullable<long> id_Tuyen)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            var id_SoParameter = id_So.HasValue ?
                new ObjectParameter("Id_So", id_So) :
                new ObjectParameter("Id_So", typeof(int));
    
            var id_TuyenParameter = id_Tuyen.HasValue ?
                new ObjectParameter("Id_Tuyen", id_Tuyen) :
                new ObjectParameter("Id_Tuyen", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoTongHop_Tuyen_Result>("sp_HD_BaoCaoTongHop_Tuyen", thangParameter, namParameter, id_SoParameter, id_TuyenParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoTongHopTaiBen_Result> sp_HD_BaoCaoTongHopTaiBen(Nullable<int> id_BenXe, string tuNgay, string denNgay, Nullable<long> lT_IdLuongTuyen, Nullable<int> cT_IdCongTyVT)
        {
            var id_BenXeParameter = id_BenXe.HasValue ?
                new ObjectParameter("Id_BenXe", id_BenXe) :
                new ObjectParameter("Id_BenXe", typeof(int));
    
            var tuNgayParameter = tuNgay != null ?
                new ObjectParameter("TuNgay", tuNgay) :
                new ObjectParameter("TuNgay", typeof(string));
    
            var denNgayParameter = denNgay != null ?
                new ObjectParameter("DenNgay", denNgay) :
                new ObjectParameter("DenNgay", typeof(string));
    
            var lT_IdLuongTuyenParameter = lT_IdLuongTuyen.HasValue ?
                new ObjectParameter("LT_IdLuongTuyen", lT_IdLuongTuyen) :
                new ObjectParameter("LT_IdLuongTuyen", typeof(long));
    
            var cT_IdCongTyVTParameter = cT_IdCongTyVT.HasValue ?
                new ObjectParameter("CT_IdCongTyVT", cT_IdCongTyVT) :
                new ObjectParameter("CT_IdCongTyVT", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoTongHopTaiBen_Result>("sp_HD_BaoCaoTongHopTaiBen", id_BenXeParameter, tuNgayParameter, denNgayParameter, lT_IdLuongTuyenParameter, cT_IdCongTyVTParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoXeChayNhoHon70_DonViVanTai_Result> sp_HD_BaoCaoXeChayNhoHon70_DonViVanTai(Nullable<int> thang, Nullable<int> nam, Nullable<int> id_So, Nullable<long> id_Tuyen, Nullable<int> id_DonVi)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            var id_SoParameter = id_So.HasValue ?
                new ObjectParameter("Id_So", id_So) :
                new ObjectParameter("Id_So", typeof(int));
    
            var id_TuyenParameter = id_Tuyen.HasValue ?
                new ObjectParameter("Id_Tuyen", id_Tuyen) :
                new ObjectParameter("Id_Tuyen", typeof(long));
    
            var id_DonViParameter = id_DonVi.HasValue ?
                new ObjectParameter("Id_DonVi", id_DonVi) :
                new ObjectParameter("Id_DonVi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoXeChayNhoHon70_DonViVanTai_Result>("sp_HD_BaoCaoXeChayNhoHon70_DonViVanTai", thangParameter, namParameter, id_SoParameter, id_TuyenParameter, id_DonViParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong_Result> sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong(Nullable<int> thang, Nullable<int> nam, Nullable<int> id_So)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            var id_SoParameter = id_So.HasValue ?
                new ObjectParameter("Id_So", id_So) :
                new ObjectParameter("Id_So", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong_Result>("sp_HD_BaoCaoXeChayNhoHon70_SoGiaoThong", thangParameter, namParameter, id_SoParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoXeChayNhoHon70_ToanQuoc_Result> sp_HD_BaoCaoXeChayNhoHon70_ToanQuoc(Nullable<int> thang, Nullable<int> nam)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoXeChayNhoHon70_ToanQuoc_Result>("sp_HD_BaoCaoXeChayNhoHon70_ToanQuoc", thangParameter, namParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoXeChayNhoHon70_Tuyen_Result> sp_HD_BaoCaoXeChayNhoHon70_Tuyen(Nullable<int> thang, Nullable<int> nam, Nullable<int> id_So, Nullable<long> id_Tuyen)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            var id_SoParameter = id_So.HasValue ?
                new ObjectParameter("Id_So", id_So) :
                new ObjectParameter("Id_So", typeof(int));
    
            var id_TuyenParameter = id_Tuyen.HasValue ?
                new ObjectParameter("Id_Tuyen", id_Tuyen) :
                new ObjectParameter("Id_Tuyen", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoXeChayNhoHon70_Tuyen_Result>("sp_HD_BaoCaoXeChayNhoHon70_Tuyen", thangParameter, namParameter, id_SoParameter, id_TuyenParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoXeChaySaiGio_DonViVanTai_Result> sp_HD_BaoCaoXeChaySaiGio_DonViVanTai(Nullable<int> thang, Nullable<int> nam, Nullable<int> id_So, Nullable<long> id_Tuyen, Nullable<int> id_DonVi)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            var id_SoParameter = id_So.HasValue ?
                new ObjectParameter("Id_So", id_So) :
                new ObjectParameter("Id_So", typeof(int));
    
            var id_TuyenParameter = id_Tuyen.HasValue ?
                new ObjectParameter("Id_Tuyen", id_Tuyen) :
                new ObjectParameter("Id_Tuyen", typeof(long));
    
            var id_DonViParameter = id_DonVi.HasValue ?
                new ObjectParameter("Id_DonVi", id_DonVi) :
                new ObjectParameter("Id_DonVi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoXeChaySaiGio_DonViVanTai_Result>("sp_HD_BaoCaoXeChaySaiGio_DonViVanTai", thangParameter, namParameter, id_SoParameter, id_TuyenParameter, id_DonViParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoXeChaySaiGio_SoGiaoThong_Result> sp_HD_BaoCaoXeChaySaiGio_SoGiaoThong(Nullable<int> thang, Nullable<int> nam, Nullable<int> id_So)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            var id_SoParameter = id_So.HasValue ?
                new ObjectParameter("Id_So", id_So) :
                new ObjectParameter("Id_So", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoXeChaySaiGio_SoGiaoThong_Result>("sp_HD_BaoCaoXeChaySaiGio_SoGiaoThong", thangParameter, namParameter, id_SoParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoXeChaySaiGio_ToanQuoc_Result> sp_HD_BaoCaoXeChaySaiGio_ToanQuoc(Nullable<int> thang, Nullable<int> nam)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoXeChaySaiGio_ToanQuoc_Result>("sp_HD_BaoCaoXeChaySaiGio_ToanQuoc", thangParameter, namParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoXeChaySaiGio_Tuyen_Result> sp_HD_BaoCaoXeChaySaiGio_Tuyen(Nullable<int> thang, Nullable<int> nam, Nullable<int> id_So, Nullable<long> id_Tuyen)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            var id_SoParameter = id_So.HasValue ?
                new ObjectParameter("Id_So", id_So) :
                new ObjectParameter("Id_So", typeof(int));
    
            var id_TuyenParameter = id_Tuyen.HasValue ?
                new ObjectParameter("Id_Tuyen", id_Tuyen) :
                new ObjectParameter("Id_Tuyen", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoXeChaySaiGio_Tuyen_Result>("sp_HD_BaoCaoXeChaySaiGio_Tuyen", thangParameter, namParameter, id_SoParameter, id_TuyenParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoXeChaySaiGioTaiBen_Result> sp_HD_BaoCaoXeChaySaiGioTaiBen(Nullable<int> id_BenXe, string tuNgay, string denNgay, Nullable<long> lT_IdLuongTuyen, Nullable<int> cT_IdCongTyVT)
        {
            var id_BenXeParameter = id_BenXe.HasValue ?
                new ObjectParameter("Id_BenXe", id_BenXe) :
                new ObjectParameter("Id_BenXe", typeof(int));
    
            var tuNgayParameter = tuNgay != null ?
                new ObjectParameter("TuNgay", tuNgay) :
                new ObjectParameter("TuNgay", typeof(string));
    
            var denNgayParameter = denNgay != null ?
                new ObjectParameter("DenNgay", denNgay) :
                new ObjectParameter("DenNgay", typeof(string));
    
            var lT_IdLuongTuyenParameter = lT_IdLuongTuyen.HasValue ?
                new ObjectParameter("LT_IdLuongTuyen", lT_IdLuongTuyen) :
                new ObjectParameter("LT_IdLuongTuyen", typeof(long));
    
            var cT_IdCongTyVTParameter = cT_IdCongTyVT.HasValue ?
                new ObjectParameter("CT_IdCongTyVT", cT_IdCongTyVT) :
                new ObjectParameter("CT_IdCongTyVT", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoXeChaySaiGioTaiBen_Result>("sp_HD_BaoCaoXeChaySaiGioTaiBen", id_BenXeParameter, tuNgayParameter, denNgayParameter, lT_IdLuongTuyenParameter, cT_IdCongTyVTParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai_Result> sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai(Nullable<int> thang, Nullable<int> nam, Nullable<int> id_So, Nullable<long> id_Tuyen, Nullable<int> id_DonVi)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            var id_SoParameter = id_So.HasValue ?
                new ObjectParameter("Id_So", id_So) :
                new ObjectParameter("Id_So", typeof(int));
    
            var id_TuyenParameter = id_Tuyen.HasValue ?
                new ObjectParameter("Id_Tuyen", id_Tuyen) :
                new ObjectParameter("Id_Tuyen", typeof(long));
    
            var id_DonViParameter = id_DonVi.HasValue ?
                new ObjectParameter("Id_DonVi", id_DonVi) :
                new ObjectParameter("Id_DonVi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai_Result>("sp_HD_BaoCaoXeKhongHoatDong_DonViVanTai", thangParameter, namParameter, id_SoParameter, id_TuyenParameter, id_DonViParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong_Result> sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong(Nullable<int> thang, Nullable<int> nam, Nullable<int> id_So)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            var id_SoParameter = id_So.HasValue ?
                new ObjectParameter("Id_So", id_So) :
                new ObjectParameter("Id_So", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong_Result>("sp_HD_BaoCaoXeKhongHoatDong_SoGiaoThong", thangParameter, namParameter, id_SoParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoXeKhongHoatDong_ToanQuoc_Result> sp_HD_BaoCaoXeKhongHoatDong_ToanQuoc(Nullable<int> thang, Nullable<int> nam)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoXeKhongHoatDong_ToanQuoc_Result>("sp_HD_BaoCaoXeKhongHoatDong_ToanQuoc", thangParameter, namParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoXeKhongHoatDong_Tuyen_Result> sp_HD_BaoCaoXeKhongHoatDong_Tuyen(Nullable<int> thang, Nullable<int> nam, Nullable<int> id_So, Nullable<long> id_Tuyen)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            var id_SoParameter = id_So.HasValue ?
                new ObjectParameter("Id_So", id_So) :
                new ObjectParameter("Id_So", typeof(int));
    
            var id_TuyenParameter = id_Tuyen.HasValue ?
                new ObjectParameter("Id_Tuyen", id_Tuyen) :
                new ObjectParameter("Id_Tuyen", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoXeKhongHoatDong_Tuyen_Result>("sp_HD_BaoCaoXeKhongHoatDong_Tuyen", thangParameter, namParameter, id_SoParameter, id_TuyenParameter);
        }
    
        public virtual ObjectResult<sp_HD_BaoCaoXeKhongHoatDongTaiBen_Result> sp_HD_BaoCaoXeKhongHoatDongTaiBen(Nullable<int> id_BenXe, string tuNgay, string denNgay, Nullable<long> lT_IdLuongTuyen, Nullable<int> cT_IdCongTyVT)
        {
            var id_BenXeParameter = id_BenXe.HasValue ?
                new ObjectParameter("Id_BenXe", id_BenXe) :
                new ObjectParameter("Id_BenXe", typeof(int));
    
            var tuNgayParameter = tuNgay != null ?
                new ObjectParameter("TuNgay", tuNgay) :
                new ObjectParameter("TuNgay", typeof(string));
    
            var denNgayParameter = denNgay != null ?
                new ObjectParameter("DenNgay", denNgay) :
                new ObjectParameter("DenNgay", typeof(string));
    
            var lT_IdLuongTuyenParameter = lT_IdLuongTuyen.HasValue ?
                new ObjectParameter("LT_IdLuongTuyen", lT_IdLuongTuyen) :
                new ObjectParameter("LT_IdLuongTuyen", typeof(long));
    
            var cT_IdCongTyVTParameter = cT_IdCongTyVT.HasValue ?
                new ObjectParameter("CT_IdCongTyVT", cT_IdCongTyVT) :
                new ObjectParameter("CT_IdCongTyVT", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_HD_BaoCaoXeKhongHoatDongTaiBen_Result>("sp_HD_BaoCaoXeKhongHoatDongTaiBen", id_BenXeParameter, tuNgayParameter, denNgayParameter, lT_IdLuongTuyenParameter, cT_IdCongTyVTParameter);
        }
    }
}
