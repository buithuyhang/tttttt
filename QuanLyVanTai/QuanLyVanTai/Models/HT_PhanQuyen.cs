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
    
    public partial class HT_PhanQuyen
    {
        public string Nhom { get; set; }
        public long IDQuyen { get; set; }
    
        public virtual HT_Quyen HT_Quyen { get; set; }
    }
}
