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
    
    public partial class GreenEvents
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GreenEvents()
        {
            this.InventoryItems = new HashSet<InventoryItems>();
            this.PriceOffer = new HashSet<PriceOffer>();
            this.VehicleList = new HashSet<VehicleList>();
        }
    
        public int eventSerialNum { get; set; }
        public string event_name { get; set; }
        public string event_address { get; set; }
        public Nullable<System.DateTime> event_startdate { get; set; }
        public Nullable<System.DateTime> event_enddate { get; set; }
        public Nullable<bool> isEventActive { get; set; }
        public string event_notes { get; set; }
        public Nullable<int> employee_id { get; set; }
        public Nullable<int> clientNumber { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryItems> InventoryItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PriceOffer> PriceOffer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleList> VehicleList { get; set; }
    }
}
