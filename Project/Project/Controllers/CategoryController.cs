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
    public class CategoryController : Controller
    {
        //chuỗi connect
        Dbconnection con = new Dbconnection();

        /// <summary>
        /// Nguyễn Nam Anh : Hiển thi trang chuyên mục bài viết 
        /// </summary>
        /// <returns></returns>
        [AuthenticationFilter]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Nguyễn Nam Anh : Tìm kiếm thông tin chuyên mục bài viết 
        /// </summary>
        /// <param name="Page">Trang </param>
        /// <param name="CategoryName">Tên chuyên mục bài viết</param>
        /// <param name="GroupCategoryId">Nhóm chuyên mục </param>
        /// <returns></returns>
        [HttpGet]
        [AuthenticationFilter]
        public PartialViewResult Seach(int Page, string CategoryName, long GroupCategoryId)
        {

            try
            {

                var query = from data in con.Categories
                            where data.Active == true
                            select data;

                if (CategoryName != null)
                {
                    if (CategoryName.Trim() != "")
                    {
                        query = query.Where(u => u.Name.Contains(CategoryName));
                    }
                }

                if (GroupCategoryId != 0)
                {
                    query = query.Where(u => u.ParentID == GroupCategoryId);

                }

                if (query != null && query.Count() > 0)
                {
                    List<GetCategoryModels> List = new List<GetCategoryModels>();

                    foreach (Category data in query)
                    {
                        GetCategoryModels getCategoryModels = new GetCategoryModels();

                        getCategoryModels.Name = data.Name;
                        getCategoryModels.MetaTitle = data.MetaTitle;
                        //getCategoryModels.ParentID = (long)data.ParentID;
                        getCategoryModels.DisplayOrder = (int)data.DisplayOrder;
                        //getCategoryModels.SeoTitle = data.SeoTitle;
                        getCategoryModels.CreatedDate = (DateTime)data.CreatedDate;
                        getCategoryModels.CreatedBy = data.CreatedBy;
                        getCategoryModels.ModifiedDate = (DateTime)data.ModifiedDate;
                        getCategoryModels.ModifiedBy = data.ModifiedBy;

                        //getCategoryModels.MetaKeywords = data.MetaKeywords;
                        //getCategoryModels.MetaDescriptions = data.MetaDescriptions;
                        getCategoryModels.ShowOnHome = (bool)data.ShowOnHome;
                        getCategoryModels.Image = data.Image;
                        getCategoryModels.AltImage = data.AltImage;

                        Category categoryParent = con.Categories.Find(data.ParentID);

                        if (categoryParent != null)
                        {
                            getCategoryModels.ParentName = categoryParent.Name;
                        }
                        List.Add(getCategoryModels);
                    }
                    return PartialView("_List", List.ToPagedList(Page, Constants.MAX_ROW_IN_LIST));
                }
                else
                {
                    return PartialView("_List", new List<GetCategoryModels>().ToPagedList(1, 1));
                }
            }
            catch
            {
                return PartialView("_List", new List<GetCategoryModels>().ToPagedList(1, 1));
            }
        }


        /// <summary>
        /// Nguyễn Nam Anh : cập nhập thông tin của chuyên mục bài viết 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public ActionResult Update(long categoryId)
        {
            try
            {

                var query = con.Categories.Find(categoryId);
                if (query != null)
                {
                    GetCategoryModels getCategoryModels = new GetCategoryModels()
                    {
                        Name = query.Name,
                        MetaTitle = query.MetaTitle,
                        ParentID = query.ParentID,
                        DisplayOrder = query.DisplayOrder,
                        SeoTitle = query.SeoTitle,
                        CreatedBy = query.CreatedBy,
                        CreatedDate = query.CreatedDate,
                        ModifiedBy = query.ModifiedBy,
                        MetaKeywords = query.MetaKeywords,
                        MetaDescriptions = query.MetaDescriptions,
                        Status = query.Status,
                        ShowOnHome = query.ShowOnHome,
                        Image = query.Image,
                        AltImage = query.AltImage,
                        Active = query.Active

                    };
                    return View(getCategoryModels);
                }
                else
                {
                    return View(new GetCategoryModels());
                }

            }
            catch
            {

                return View(new GetCategoryModels());
            }


        }

        /// <summary>
        /// Nguyễn Nam Anh : Hiển thị trang cập nhập chuyên mục bài viết 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// Nguyễn Nam Anh : lấy thông tin chuyên mục bài viết đưa vào select 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetSelectCategory()
        {
            try
            {
                var query = from data in con.Categories
                            where data.Active == true
                            select new GetCategoryModels
                            {
                                Name = data.Name,
                                ID = data.ID
                            };
                if (query != null)
                {
                    return Json(query, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new List<GetCategoryModels>(), JsonRequestBehavior.AllowGet);
                }

            }

            catch
            {
                return Json(new List<GetCategoryModels>(), JsonRequestBehavior.AllowGet);
            }
        }

        
        /// <summary>
        /// Nguyễn Nam anh : Thêm mới thông tin chuyên mục 
        /// </summary>
        /// <param name="addCategory">Thông tin chuyên mục được thêm</param>
        /// <returns></returns>
        [ValidateInput(false)]
        [HttpPost]
        public int AddCategory(AddCategoryModels addCategory)
        {
            try
            {
                LoginUserModels loginUserModels = Session["Login"] as LoginUserModels;
                Category category = new Category()
                {
                    Name = addCategory.Name,
                    MetaTitle = addCategory.MetaTitle,
                    ParentID = addCategory.ParentID,
                    DisplayOrder = addCategory.DisplayOrder,
                    SeoTitle = addCategory.SeoTitle,
                    MetaKeywords = addCategory.MetaKeywords,
                    MetaDescriptions = addCategory.MetaDescriptions,
              
                    ShowOnHome = addCategory.ShowOnHome,
                    Image = addCategory.Image,
                    AltImage = addCategory.AltImage,
                    Active = addCategory.Active

                };
                con.Categories.Add(category);
                con.SaveChanges();
                return Constants.RETURN_TRUE;


            }
            catch
            {
                return Constants.RETURN_FALSE;
            }
        }

        
        /// <summary>
        /// Nguyễn Nam Anh : Xóa thông tin chuyên mục bài đăng 
        /// </summary>
        /// <param name="categoryId"> Mã của thông tin chuyên mục bài đăng</param>
        /// <returns></returns>
        public int DeleteCategory(long categoryId)
        {
            try
            {
                // Lấy danh sách các bải viết của chuyên mục 
                var ListContent = from content in con.Contents
                                  where content.IsActive == Util.Constants.ACTIVE && content.CategoryID == categoryId
                                  select content; 
                if(ListContent!= null&& ListContent.Count() > 0)
                {
                    foreach(Content content in ListContent)
                    {
                        var ListContentTag = from contentTag in con.ContentTags
                                             where contentTag.ContentID == content.ID
                                             select contentTag;
                        foreach(ContentTag contentTag in ListContentTag)
                        {
                            // Tiến hành xóa các thẻ của bài viết 
                            con.ContentTags.Remove(contentTag); 

                        }

                        // Tiến hành xóa các thẻ của bài viết 
                        content.IsActive = Util.Constants.ACTIVE_FLASE; 
                    }
                }

                

                
                var data = con.Categories.Find(categoryId);
                
                if (data != null)
                {
                    data.Active = false;
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
        /// Phan Đình  Kiên : Cập Nhập thông tin của chuyên mục bài viết 
        /// </summary>
        /// <param name="editCategoryModels">Thông tin của chuyên mục bài viết sau khi được cập nhập</param>
        /// <returns></returns>
        public int EditCategory(EditCategoryModels editCategoryModels)
        {
            try
            {
                LoginUserModels loginUserModels = Session["Login"] as LoginUserModels;
                var Data = con.Categories.Find(editCategoryModels.ParentID);
                if(Data!= null)
                {
                    Data.Name = editCategoryModels.Name;
                    Data.MetaTitle = editCategoryModels.MetaTitle;
                    Data.ParentID = editCategoryModels.ParentID;
                    Data.DisplayOrder = editCategoryModels.DisplayOrder;
                    Data.SeoTitle = editCategoryModels.SeoTitle;
                    Data.ModifiedBy = loginUserModels.Name;
                    Data.ModifiedDate = DateTime.Now;
                    Data.MetaKeywords = editCategoryModels.MetaKeywords;
                    Data.MetaDescriptions = editCategoryModels.MetaDescriptions;
                    Data.Status = editCategoryModels.Status;
                    Data.ShowOnHome = editCategoryModels.ShowOnHome;
                    Data.Image = editCategoryModels.Image;
                    Data.AltImage = editCategoryModels.AltImage;
                    con.SaveChanges(); 
                }
                return Constants.RETURN_TRUE;
            }
            catch
            {
                return Constants.RETURN_FALSE;
            }
        }
    }
}