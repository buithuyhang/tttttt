//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class QLVT_ThongTinBenXe
    {
        public int BX_IdBenXe { get; set; }
        public string TenBenXe { get; set; }
        public Nullable<int> MaBen { get; set; }
        public Nullable<int> TS_IdTinh_So { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string CoQuanQuanLy { get; set; }
        public Nullable<double> TongDienTich { get; set; }
        public Nullable<double> DienTich_XeKhach { get; set; }
        public Nullable<double> DienTich_PhuongTienKhac { get; set; }
        public Nullable<double> DienTich_NhaCho { get; set; }
        public Nullable<int> LoaiBenXe { get; set; }
        public Nullable<int> SoTuyenQuyHoach { get; set; }
        public Nullable<int> SoLuotXuatBenQuyHoach { get; set; }
        public Nullable<int> SoLuotXuatBenDangKy { get; set; }
        public string GhiChu { get; set; }
        public Nullable<int> TS_TT_IdTrangThai { get; set; }
    
        public virtual QLVT_ThongTinTinh_SoGiaoThong QLVT_ThongTinTinh_SoGiaoThong { get; set; }
        public virtual QLVT_ThongTinTinh_So_Ben_TrangThai QLVT_ThongTinTinh_So_Ben_TrangThai { get; set; }
    }
}
