//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASPFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BOOK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOOK()
        {
            this.INVENTORY = new HashSet<INVENTORY>();
            this.WROTE = new HashSet<WROTE>();
        }
    
        public string BOOK_CODE { get; set; }
        public string TITLE { get; set; }
        public string PUBLISHER_CODE { get; set; }
        public string TYPE { get; set; }
        public Nullable<decimal> PRICE { get; set; }
        public Nullable<bool> PAPERBACK { get; set; }
    
        public virtual PUBLISHER PUBLISHER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVENTORY> INVENTORY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WROTE> WROTE { get; set; }
    }
}
