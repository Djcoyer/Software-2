//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Software2
{
    using System;
    using System.Collections.Generic;
    
    public partial class customer
    {

        public customer()
        {
            createDate = DateTime.Now;
            lastUpdate = DateTime.Now;
            active = true;
        }

        public int customerId { get; set; }
        public string customerName { get; set; }
        public int addressId { get; set; }
        public bool active { get; set; }
        public System.DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public System.DateTime lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }
    }
}
