//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AUCTIONonlineWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale
    {
        public int SaleId { get; set; }
        public string ProductName { get; set; }
        public string ProductDiscription { get; set; }
        public string Category { get; set; }
        public double InitialAmount { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
        public Nullable<double> FinalAmount { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
    
        public virtual User User { get; set; }
        public virtual Sale Sales1 { get; set; }
        public virtual Sale Sale1 { get; set; }
    }
}
