using PagedList;
using Project.App_Start;
using Project.Data;
using Project.Models;
using Project.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class SlideController : Controller
    {
        /// <summary>
        /// Phan Đình Kiên : Hiển thị danh sách slide 
        /// </summary>
        /// <returns></returns>
        [AuthenticationFilter]
        public ActionResult Index()
        {

            return View();
        }
        Dbconnection con = new Dbconnection();



        /// <summary>
        /// Phan Đình Kiên : Tìm Kiếm Thông Tin slide Theo Trang
        /// </summary>
        /// <param name="Page"></param>
        /// <returns></returns>
        [AuthenticationFilter]
        public PartialViewResult Seach(int Page)
        {
            try
            {

                var query = from Slide in con.Slides select Slide;
                if (query != null && query.Count() > 0)
                {
                    List<GetSlideModels> list = new List<GetSlideModels>();
                    foreach (Slide data in query)
                    {
                        GetSlideModels SlideModels = new GetSlideModels();
                        SlideModels.Image = data.Image;
                        SlideModels.DisplayOrder = data.DisplayOrder;
                        SlideModels.Link = data.Link;
                        SlideModels.Description = data.Description;
                        SlideModels.CreatedDate = data.CreatedDate;
                        SlideModels.CreatedBy = data.CreatedBy;
                        SlideModels.ModifiedDate = data.ModifiedDate;
                        SlideModels.ModifiedBy = data.ModifiedBy;
                        SlideModels.Status = data.Status;
                        list.Add(SlideModels);
                    }
                    return PartialView("_List", list.ToPagedList(Page, Constants.MAX_ROW_IN_LIST));
                }
                else
                {
                    return PartialView("_List", new List<GetSlideModels>().ToPagedList(1, 1));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Phan Đình Kiên : Thêm mới thông tin slide 
        /// </summary>
        /// <param name="Slide">Thông tin slide sau khi được thêm mới</param>
        /// <returns></returns>
        [AuthenticationFilter]
        public int AddSlide(AddSlideModels Slide)
        {
            try
            {
                LoginUserModels LoginUserModels = Session["Login"] as LoginUserModels;
                Slide Us = new Slide()
                {
                    Image = Slide.Image,
                    Description = Slide.Description,
                    DisplayOrder = Slide.DisplayOrder,
                    Status = true,
                    Link = Slide.Link,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = LoginUserModels.Name,
                    CreatedBy = LoginUserModels.Name,
                };
                con.Slides.Add(Us);
                con.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        /// <summary>
        /// Phan Đình Kiên : Lấy thông tin slide theo id
        /// </summary>
        /// <param name="Id">id của slide cần lấy thông tin </param>
        /// <returns></returns>
        [AuthenticationFilter]
        public JsonResult GetSlideById(long Id)
        {
            try
            {
                var query = con.Slides.Find(Id);

                if (query != null)
                {
                    GetSlideModels SlideModels = new GetSlideModels()
                    {
                        Image = query.Image,
                        DisplayOrder = query.DisplayOrder,
                        Link = query.Link,
                        Description = query.Description,
                        CreatedDate = query.CreatedDate,
                        CreatedBy = query.CreatedBy,
                        ModifiedDate = query.ModifiedDate,
                        ModifiedBy = query.ModifiedBy,
                        Status = query.Status,
                        ID = query.ID,
                    };
                    return Json(SlideModels, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new GetSlideModels(), JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new GetSlideModels(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Phan Đình Kiên : Cập nhập thông tin slide 
        /// </summary>
        /// <param name="editSlideModels">Thông tin slide sau khi được cập nhập</param>
        /// <returns></returns>
        [AuthenticationFilter]
        public int EditSlide(EditSlideModels editSlideModels)
        {
            try
            {
                LoginUserModels LoginUserModels = Session["Login"] as LoginUserModels;
                Slide Slide = con.Slides.Find(editSlideModels.ID);

                if (Slide != null)
                {
                    Slide.Image = editSlideModels.Image;
                    Slide.DisplayOrder = editSlideModels.DisplayOrder;
                    Slide.Status = editSlideModels.Status;
                    Slide.Link = editSlideModels.Link;
                    Slide.Description = editSlideModels.Description;
                    con.SaveChanges();
                    return Constants.RETURN_TRUE;
                }
                else
                {
                    return Constants.RETURN_FALSE;
                }
            }
            catch
            {
                return Constants.RETURN_FALSE;
            }
        }

       
        /// <summary>
        /// Phan Đình Kiên : Xóa thông tin slide 
        /// </summary>
        /// <param name="Id">Mã Slide cần xoa</param>
        /// <returns></returns>
        [AuthenticationFilter]
        public int DeleteSlide(long Id)
        {
            try
            {
                Slide Slide = con.Slides.Find(Id);
                if (Slide != null)
                {
                    con.Slides.Remove(Slide); 
                    con.SaveChanges();
                    return Constants.RETURN_TRUE;

                }
                return Constants.RETURN_FALSE;

            }
            catch
            {
                return Constants.RETURN_FALSE;
            }
        }
    }
}