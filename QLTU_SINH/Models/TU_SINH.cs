//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLTU_SINH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TU_SINH
    {
        public int ID { get; set; }
        public string SO_THE { get; set; }
        public string HO_TEN { get; set; }
        public Nullable<int> NAM_SINH { get; set; }
        public Nullable<bool> GIOI_TINH { get; set; }
        public string TEN_PHU_HUYNH { get; set; }
        public string SDT { get; set; }
        public string QUE_QUAN { get; set; }
        public Nullable<int> ID_PHONG { get; set; }
        public Nullable<int> ID_KHOA_TU { get; set; }
    
        public virtual KHOA_TU KHOA_TU { get; set; }
        public virtual PHONG_NGU PHONG_NGU { get; set; }
    }
}