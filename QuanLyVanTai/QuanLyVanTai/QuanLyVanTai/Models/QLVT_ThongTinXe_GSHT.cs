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
    
    public partial class QLVT_ThongTinXe_GSHT
    {
        public long TX_GSHT_Id { get; set; }
        public Nullable<long> TX_IdXe { get; set; }
        public string TX_GSHT_TaiKhoan { get; set; }
        public string TX_GSHT_MatKhau { get; set; }
        public string TX_GSHT_Website { get; set; }
    
        public virtual QLVT_ThongTinXe QLVT_ThongTinXe { get; set; }
    }
}
