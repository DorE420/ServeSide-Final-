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
    
    public partial class GreenConstraints
    {
        public int constraintSerialNum { get; set; }
        public string constraintName { get; set; }
        public Nullable<System.DateTime> constraintStartDate { get; set; }
        public Nullable<System.DateTime> constraintEndDate { get; set; }
        public string constraintNotes { get; set; }
        public Nullable<int> employee_id { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}