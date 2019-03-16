using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class GetOrderDetailModels
    {
        public long ProductID { get; set; }
        public long OrderID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}