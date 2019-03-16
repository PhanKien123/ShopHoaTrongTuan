using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models.FontEnd
{
    public class GetListProductModels
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string AltImage { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> PromotionPrice { get; set; }
    }
}