using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class EditCategoryModels
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public Nullable<long> ParentID { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string SeoTitle { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> ShowOnHome { get; set; }
        public string Image { get; set; }
        public string AltImage { get; set; }
    }
}