using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class GetSlideModels
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> Status { get; set; }


        /// <summary>
        /// Phan Đình Kiên : định dạng lại ngày tháng khởi tạo 
        /// </summary>
        /// <returns></returns>
        public  string GetStringCreateDate()
        {
            if(CreatedDate == null)
            {
                DateTime date = (DateTime)this.CreatedDate;
                return date.ToString("dd/MM/yyyy"); 
            }
            else
            {
                return "00/00/0000"; 
            }
        }


        /// <summary>
        /// Phan Đình Kiên : Định dạng lại ngày tháng cập nhập 
        /// </summary>
        /// <returns></returns>
        public string GetStringModifieDate()
        {
            if (ModifiedDate == null)

            {
                DateTime date = (DateTime)this.ModifiedDate;
                return date.ToString("dd/MM/yyyy");
            }
            else
            {
                return "00/00/0000";
            }
        }

        /// <summary>
        /// Phan Đình Kiên : Cắt chuổi mô tả về slide 
        /// </summary>
        /// <returns></returns>
        public string SubTringDescription()
        {
            if(this.Description!= null)
            {
                if (Description.Trim().Count() > 20)
                {
                    return Description.Substring(20) + "...."; 
                }
                else
                {
                    return Description; 
                }
            }
            else
            {
                return Util.Constants.STRING_NULL; 
            }
        }
    }
}