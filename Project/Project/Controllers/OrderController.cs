using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class OrderController : Controller
    {
        /// <summary>
        /// Phan Đình Kiên : Hiển hiển thị danh sách đơn hàng 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            return View();
        }


    }
}