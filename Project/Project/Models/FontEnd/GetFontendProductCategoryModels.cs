using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models.FontEnd
{
    public class GetFontendProductCategoryModels
    {
        public long ID { get; set; }
        public string Image { get; set; }
        public string AltImage { get; set; }
        public string Name { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
    }
}