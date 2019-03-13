using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class AddSlideModels
    {
        public string Image { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Status { get; set; }

    }
}