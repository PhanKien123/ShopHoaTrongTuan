using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class GetFeedbackModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> Status { get; set; }

        public string GetStringCreateDate()
        {
            if(CreatedDate!= null)
            {
                DateTime date = (DateTime)CreatedDate;
                return date.ToString("dd/MM/yyyy");
            }
            else
            {
                return ""; 
            }
        }

        public string SubTringContent()
        {
            if(this.Content.Length >= 20)
            {
                return Content.Substring(20)+"..."; 
            }
            else
            {
                return Content; 
            }
        }

    }

}