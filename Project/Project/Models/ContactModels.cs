using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class ContactModels
    {
        public int ID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public Nullable<bool> Status { get; set; }
        
    }
}