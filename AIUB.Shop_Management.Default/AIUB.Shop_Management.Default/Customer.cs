//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AIUB.Shop_Management.Default
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Contact { get; set; }
        public string JoiningDate { get; set; }
        public string Point { get; set; }
    
        public virtual Sell Sell { get; set; }
    }
}
