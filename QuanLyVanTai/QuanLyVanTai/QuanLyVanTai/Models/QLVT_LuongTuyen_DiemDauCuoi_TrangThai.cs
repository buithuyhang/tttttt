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
    
    public partial class QLVT_LuongTuyen_DiemDauCuoi_TrangThai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QLVT_LuongTuyen_DiemDauCuoi_TrangThai()
        {
            this.QLVT_LuongTuyen_DiemDauCuoi = new HashSet<QLVT_LuongTuyen_DiemDauCuoi>();
        }
    
        public int LT_DC_TT_IdTrangThai { get; set; }
        public string TenTrangThai { get; set; }
        public string GhiChu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QLVT_LuongTuyen_DiemDauCuoi> QLVT_LuongTuyen_DiemDauCuoi { get; set; }
    }
}
