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
    
    public partial class QLVT_CongTyVanTai_TrangThai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QLVT_CongTyVanTai_TrangThai()
        {
            this.QLVT_CongTyVanTai = new HashSet<QLVT_CongTyVanTai>();
        }
    
        public int CT_TT_IdTrangThai { get; set; }
        public string CT_TT_TenTrangThai { get; set; }
        public string CT_TT_GhiChu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QLVT_CongTyVanTai> QLVT_CongTyVanTai { get; set; }
    }
}
