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
    
    public partial class QLVT_ThongTinTinh_SoGiaoThong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QLVT_ThongTinTinh_SoGiaoThong()
        {
            this.QLVT_CapTuyenChoTinh_So = new HashSet<QLVT_CapTuyenChoTinh_So>();
            this.QLVT_CongTyVanTai = new HashSet<QLVT_CongTyVanTai>();
            this.QLVT_ThongTinBenXe = new HashSet<QLVT_ThongTinBenXe>();
        }
    
        public int TS_IdTinh_So { get; set; }
        public Nullable<int> TS_IdMaTinh { get; set; }
        public string TS_TenTinh { get; set; }
        public Nullable<int> TS_TT_IdTrangThai { get; set; }
        public string GiamDocSo { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QLVT_CapTuyenChoTinh_So> QLVT_CapTuyenChoTinh_So { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QLVT_CongTyVanTai> QLVT_CongTyVanTai { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QLVT_ThongTinBenXe> QLVT_ThongTinBenXe { get; set; }
        public virtual QLVT_ThongTinTinh_So_Ben_TrangThai QLVT_ThongTinTinh_So_Ben_TrangThai { get; set; }
    }
}
