using Project.Util;
using Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project.Models;
using Project.App_Start;


namespace Project.Controllers
{
    public class FeedbackController : Controller
    {

        DbConnection con = new DbConnection();

        /// <summary>
        /// Cao Xuân Tuấn : Hiển thị danh sách liên hệ của khách hàng 
        /// </summary>
        /// <returns></returns>
        [AuthenticationFilter]
        public ActionResult Index() 
        {
            return View();
        }

        /// <summary>
        /// Cao Xuân Tuấn : Tìm kiếm thông tin liên hệ của khách hàng 
        /// </summary>
        /// <param name="Page">Trang </param>
        /// <param name="name">Tên khách hàng liên hệ </param>
        /// <param name="phone">số điện thoại của khách hàng</param>
        /// <param name="address"> địa chỉ của khách hàng </param>
        /// <returns></returns>
        [AuthenticationFilter]
        public PartialViewResult Seach(int Page,  string name="", string phone="", string address="")
        //PartialViewResult: Trả về 1 trang con
        {
            try
            {

                var query = from data in con.Feedbacks select data;

                if (name != null)
                {
                    if (name.Trim() != "")
                    {
                        query = query.Where(u => u.Name.Contains(name));
                    }
                }

                if (phone != null)
                {
                    if (phone.Trim() != "")
                    {
                        query = query.Where(u => u.Phone.Contains(phone));
                    }
                }

                if (address != null)
                {
                    if (address.Trim() != "")
                    {
                        query = query.Where(u => u.Address.Contains(address));
                    }
                }

                if (query != null && query.Count() > 0)
                {
                    List<GetFeedbackModel> listUser = new List<GetFeedbackModel>();
                    foreach (Feedback data in query)
                    {
                        GetFeedbackModel feedbackModels = new GetFeedbackModel();
                        feedbackModels.Name = data.Name;
                        feedbackModels.ID = data.ID;
                        feedbackModels.Phone = data.Phone;
                        feedbackModels.Address = data.Address;
                        feedbackModels.Email = data.Email;
                        feedbackModels.Content = data.Content;
                        feedbackModels.Status = data.Status;
                        feedbackModels.CreatedDate = data.CreatedDate;
                        listUser.Add(feedbackModels);
                    }
                    return PartialView("_List", listUser.ToPagedList(Page, Constants.MAX_ROW_IN_LIST));
                }
                else
                {
                    return PartialView("_List", new List<GetFeedbackModel>().ToPagedList(1, 1));
                }
            }
            catch
            {
                return PartialView("_List", new List<GetFeedbackModel>().ToPagedList(1, 1));
            }
        }
       

        /// <summary>
        /// Cao Xuân Tuân : hiển thị thông tin liên hệ của khách hàng theo id 
        /// </summary>
        /// <param name="Id">id của khách hàng liên hệ tới cửa hàng</param>
        /// <returns></returns>
        [AuthenticationFilter]
        public JsonResult GetFeedbackById(long Id)      
        {
            try
            {
                var query = con.Feedbacks.Find(Id);
                if(query != null)
                {
                    GetFeedbackModel getFeedbackModel = new GetFeedbackModel()
                    {
                        ID = query.ID,
                        Name = query.Name,
                        Status = (bool)query.Status,
                        Address = query.Address,
                        Email = query.Email,
                        Phone = query.Phone,
                        Content= query.Content,
                        CreatedDate =query.CreatedDate, 
                        
                    };
                    return Json(getFeedbackModel, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new GetFeedbackModel(), JsonRequestBehavior.AllowGet);
                }
            }
            catch 
            {
                return Json(new GetFeedbackModel(), JsonRequestBehavior.AllowGet);
            }
        }


        /// <summary>
        /// Cao Xuân Tuấn : Trang Thái của thông tin liên hệ 
        /// </summary>
        /// <param name="Id"></param>
        /// 
        public void UpdateStatus(long Id)
        {
            try
            {
                var query = con.Feedbacks.Find(Id);
                query.Status = false;
                con.SaveChanges(); 
            }
            catch { 
            }
        }
    }
}