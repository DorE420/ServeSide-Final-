//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATA
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customers()
        {
            this.GreenEvents = new HashSet<GreenEvents>();
        }
    
        public int clientNumber { get; set; }
        public string clientName { get; set; }
        public string clientAddress { get; set; }
        public string clientEmail { get; set; }
        public string clientFirstName { get; set; }
        public string clientLastName { get; set; }
        public string clientPhoneNum { get; set; }
        public string representiveEmail { get; set; }
        public Nullable<bool> isClientActive { get; set; }
        public Nullable<int> employee_id { get; set; }
    
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GreenEvents> GreenEvents { get; set; }
    }
}