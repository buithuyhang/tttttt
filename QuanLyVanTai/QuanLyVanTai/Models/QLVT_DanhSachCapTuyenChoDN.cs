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
    
    public partial class QLVT_DanhSachCapTuyenChoDN
    {
        public long DS_IdCapTuyenDN { get; set; }
        public Nullable<long> LT_IdLuongTuyen { get; set; }
        public Nullable<int> CT_IdCongTyVT { get; set; }
    
        public virtual QLVT_CongTyVanTai QLVT_CongTyVanTai { get; set; }
        public virtual QLVT_LuongTuyen QLVT_LuongTuyen { get; set; }
    }
}
