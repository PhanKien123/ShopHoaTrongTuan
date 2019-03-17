using Project.Data;
using Project.Models.FontEnd;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class FontEndController : Controller
    {
        DbConnection con = new DbConnection(); 
        // GET: FontEnd
        public ActionResult Index()
        {
            // lấy ra danh sách các chuyên mục sản phẩm 
            var listProductCategory = from data in con.ProductCategories
                                      where data.Active == true
                                      select data;
            List<GetFontendProductCategoryModels> list = new List<GetFontendProductCategoryModels>();
            if(listProductCategory != null && listProductCategory.Count() > 0)
            {
                foreach(var data in listProductCategory)
                {
                    GetFontendProductCategoryModels GetFontendProductCategoryModels = new GetFontendProductCategoryModels();
                    GetFontendProductCategoryModels.Name = data.Name;
                    GetFontendProductCategoryModels.AltImage = data.AltImage;
                    GetFontendProductCategoryModels.Image = data.Image;
                    GetFontendProductCategoryModels.DisplayOrder = data.DisplayOrder;
                    GetFontendProductCategoryModels.ID = data.ID;
                    list.Add(GetFontendProductCategoryModels); 
                }
                
                ViewBag.ListProductCategory = list;
            }
            else
            {
                ViewBag.ListProductCategory = new List<GetFontendProductCategoryModels>();
            }
            
            return View();
        }

        public ActionResult ProductDetails()
        {
            return View(); 
        }
    }
}