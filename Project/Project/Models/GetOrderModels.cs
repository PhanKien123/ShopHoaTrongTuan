using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class GetOrderModels
    {
        public long ID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> CustomerID { get; set; }
        public string ShipName { get; set; }
        public string ShipMobile { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<decimal> SunPrice { get; set; }

        /// <summary>
        /// Phan Đình kiên : Cập hiển thị danh sách sản phẩm cần mua trong hóa đơn 
        /// </summary>
        public List<GetOrderDetailModels> ListOderDetai
        {
            get;
            set; 
        }

        /// <summary>
        /// Phan Đình Kiên : Hiển thị ngày tháng dạng chuỗi 
        /// </summary>
        /// <returns></returns>
        public string GetStringCreateDate()
        {
            if(CreatedDate!= null)
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
        /// Phan Đình Kiên : Cập nhập trang thái cho hóa đơn 
        /// </summary>
        /// <returns></returns>
        public string GetStringStatus()
        {
            if(this.Status == 0)
            {
                return "Đơn hàng mới"; 
            }
            else if(this.Status == 1)
            {
                return "Đã xác nhận đơn"; 
            }

            else if(this.Status == 2)
            {
                return "Đang vận chuyển đơn";
            }

            else if(this.Status == 3)
            {
                return "Giao đơn thành công"; 
            }
            else if(this.Status == 4)
            {
                return "Khách hủy đơn"; 
            }
            return "";
        }


    }
}