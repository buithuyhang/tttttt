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
    
    public partial class QLVT_ThongTinXe_LichSuThayDoiHopDong
    {
        public long LSCN_IdLS { get; set; }
        public Nullable<long> TX_IdXe { get; set; }
        public Nullable<int> CT_IdCongTyVT { get; set; }
        public Nullable<long> LT_IdLuongTuyen { get; set; }
        public Nullable<System.DateTime> LSCN_ThoiGianChuyen { get; set; }
        public string LSCN_LyDoChuyen { get; set; }
    
        public virtual QLVT_ThongTinXe QLVT_ThongTinXe { get; set; }
    }
}