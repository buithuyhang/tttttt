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
    
    public partial class QLVT_LuongTuyen_DiemDauCuoi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QLVT_LuongTuyen_DiemDauCuoi()
        {
            this.QLVT_LuongTuyen = new HashSet<QLVT_LuongTuyen>();
        }
    
        public long LT_DC_IdLuongTuyen { get; set; }
        public Nullable<int> LT_DC_IdBen_01 { get; set; }
        public Nullable<int> LT_DC_IdBen_02 { get; set; }
        public string LT_DC_TenBen_01 { get; set; }
        public string LT_DC_TenBen_02 { get; set; }
        public Nullable<int> LT_DC_TT_IdTrangThai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QLVT_LuongTuyen> QLVT_LuongTuyen { get; set; }
        public virtual QLVT_LuongTuyen_DiemDauCuoi_TrangThai QLVT_LuongTuyen_DiemDauCuoi_TrangThai { get; set; }
    }
}
