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
    
    public partial class RecommandPurchaseItems
    {
        public int serialRecommandNum { get; set; }
        public string recommandItemName { get; set; }
        public Nullable<int> recommandedAmount { get; set; }
        public Nullable<System.DateTime> recommandDate { get; set; }
        public Nullable<int> itemSerialNum { get; set; }
    
        public virtual InventoryItems InventoryItems { get; set; }
    }
}