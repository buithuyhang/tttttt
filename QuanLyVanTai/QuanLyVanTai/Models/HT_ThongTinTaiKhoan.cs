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
    
    public partial class HT_ThongTinTaiKhoan
    {
        public long IDTaiKhoan { get; set; }
        public string GhiChu { get; set; }
    
        public virtual HT_TaiKhoan HT_TaiKhoan { get; set; }
    }
}
