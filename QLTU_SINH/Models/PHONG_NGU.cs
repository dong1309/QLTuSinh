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
    
    public partial class PHONG_NGU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONG_NGU()
        {
            this.TU_SINH = new HashSet<TU_SINH>();
        }
    
        public int ID { get; set; }
        public string MA_PHONG { get; set; }
        public string TEN_PHONG { get; set; }
        public Nullable<bool> LOAI_PHONG { get; set; }
        public Nullable<int> KICH_THUOC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TU_SINH> TU_SINH { get; set; }
    }
}