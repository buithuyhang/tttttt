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
    
    public partial class QLVT_LuongTuyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QLVT_LuongTuyen()
        {
            this.QLVT_CapTuyenChoTinh_So = new HashSet<QLVT_CapTuyenChoTinh_So>();
            this.QLVT_DanhSachCapTuyenChoDN = new HashSet<QLVT_DanhSachCapTuyenChoDN>();
        }
    
        public long LT_IdLuongTuyen { get; set; }
        public string LT_MaTuyen { get; set; }
        public string LT_HanhTrinhChay { get; set; }
        public Nullable<double> LT_CuLy { get; set; }
        public Nullable<int> LT_LuuLuongQuyDinh { get; set; }
        public Nullable<int> TT_IdTrangThaiTuyen { get; set; }
        public Nullable<int> LT_PL_IdLuongTuyen { get; set; }
        public Nullable<long> LT_DC_IdLuongTuyen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QLVT_CapTuyenChoTinh_So> QLVT_CapTuyenChoTinh_So { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QLVT_DanhSachCapTuyenChoDN> QLVT_DanhSachCapTuyenChoDN { get; set; }
        public virtual QLVT_LuongTuyen_DiemDauCuoi QLVT_LuongTuyen_DiemDauCuoi { get; set; }
        public virtual QLVT_LuongTuyen_PhanLoai QLVT_LuongTuyen_PhanLoai { get; set; }
        public virtual QLVT_LuongTuyen_TrangThai QLVT_LuongTuyen_TrangThai { get; set; }
    }
}
