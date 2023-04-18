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
    
    public partial class PriceOffer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PriceOffer()
        {
            this.InventoryItems = new HashSet<InventoryItems>();
        }
    
        public int offerSerialNum { get; set; }
        public string offerFirstname { get; set; }
        public string offerLastName { get; set; }
        public string offerPhoneNum { get; set; }
        public string offerClientName { get; set; }
        public string offerclientNum { get; set; }
        public string offercompanyAddress { get; set; }
        public string offerEmail { get; set; }
        public string offerEventCity { get; set; }
        public string offerEventAddress { get; set; }
        public Nullable<System.DateTime> offerEventDate { get; set; }
        public Nullable<System.TimeSpan> offerEventStartTime { get; set; }
        public Nullable<System.TimeSpan> offerEventEndTime { get; set; }
        public Nullable<bool> offerPickUpOrDelivery { get; set; }
        public string offerNotes { get; set; }
        public Nullable<int> employee_id { get; set; }
        public Nullable<int> eventSerialNum { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual GreenEvents GreenEvents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryItems> InventoryItems { get; set; }
    }
}
