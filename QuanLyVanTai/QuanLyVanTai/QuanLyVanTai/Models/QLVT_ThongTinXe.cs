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
    
    public partial class QLVT_ThongTinXe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QLVT_ThongTinXe()
        {
            this.QLVT_ThongTinXe_beta = new HashSet<QLVT_ThongTinXe_beta>();
            this.QLVT_ThongTinXe_GSHT = new HashSet<QLVT_ThongTinXe_GSHT>();
            this.QLVT_ThongTinXe_LichSuThayDoiHopDong = new HashSet<QLVT_ThongTinXe_LichSuThayDoiHopDong>();
        }
    
        public long TX_IdXe { get; set; }
        public string TX_BienSoXe { get; set; }
        public Nullable<int> TX_MaSoXe { get; set; }
        public int TS_IdTinh_So { get; set; }
        public Nullable<int> CT_IdCongTyVT { get; set; }
        public Nullable<int> TX_TT_IdTrangThaiXe { get; set; }
        public long LT_IdLuongTuyen { get; set; }
    
        public virtual QLVT_CongTyVanTai QLVT_CongTyVanTai { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QLVT_ThongTinXe_beta> QLVT_ThongTinXe_beta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QLVT_ThongTinXe_GSHT> QLVT_ThongTinXe_GSHT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QLVT_ThongTinXe_LichSuThayDoiHopDong> QLVT_ThongTinXe_LichSuThayDoiHopDong { get; set; }
        public virtual QLVT_ThongTinXe_TrangThaiXe QLVT_ThongTinXe_TrangThaiXe { get; set; }
    }
}