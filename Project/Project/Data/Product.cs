//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string AltImage { get; set; }
        public string MoreImages { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Percent { get; set; }
        public Nullable<decimal> PromotionPrice { get; set; }
        public int Quantity { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public string DescriptionIdDetail { get; set; }
        public Nullable<int> Warranty { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> TopHot { get; set; }
        public Nullable<int> Sale { get; set; }
        public Nullable<int> ViewCount { get; set; }
        public Nullable<int> IsActive { get; set; }
        public string SeoTitle { get; set; }
    }
}
