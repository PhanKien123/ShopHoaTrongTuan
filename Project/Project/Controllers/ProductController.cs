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
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace Project.Controllers
{
    public class ProductController : Controller
    {
        /// <summary>
        /// Phan Đình Kiên : Hiển thị danh sách sản phẩm 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Phan Đình Kiên : Thêm mới thông tin sản phẩm 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// Phan Đình Kiên : Cập nhập thông tin sản phẩm
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(long Id)
        {
            var data = con.Products.Find(Id); 
            if(data!= null)
            {
                var dataCategory = from CatePro in con.ProductCategories
                                   where CatePro.Active == true 
                                   select CatePro;

                EditProductModels editProductModels = new EditProductModels()
                {
                    ID = data.ID,
                    Name = data.Name,
                    CreatedDate = data.CreatedDate,
                    CreatedBy = data.CreatedBy,
                    ModifiedDate = data.ModifiedDate,
                    SeoTitle = data.SeoTitle,
                    ModifiedBy = data.ModifiedBy,
                    MetaTitle = data.MetaTitle,
                    MetaKeywords = data.MetaKeywords,
                    MetaDescriptions = data.MetaDescriptions,
                    Warranty = data.Warranty,
                    Status = data.Status,
                    TopHot = data.TopHot,
                    Sale = data.Sale,
                    ViewCount = data.ViewCount,
                    Image = data.Image,
                    AltImage = data.AltImage,
                    CategoryID = data.CategoryID,
                    Price = data.Price,
                    Description = data.Description,
                    DescriptionIdDetail = data.DescriptionIdDetail,
                    MoreImages = data.MoreImages,
                    Percent = data.Percent,
                    PromotionPrice = data.PromotionPrice,
                    Quantity = data.Quantity
                   
                };

                var query = con.ProductCategories.Find(data.CategoryID); 
                if(query!= null)
                {
                    editProductModels.CategoryName = query.Name; 
                }
                
                return View(editProductModels); 
            }
            return View(new EditProductModels());
        }


        Dbconnection con = new Dbconnection();

        /// <summary>
        /// Phan Đình Kiên : Tìm kiếm thông tin của sản phẩm 
        /// </summary>
        /// <param name="page">Thông tin trang </param>
        /// <param name="name">Tên của sản Phẩm</param>
        /// <param name="price">Giá bán</param>
        /// <param name="quantity">Số lượng</param>
        /// <param name="categoryId">Loại doanh mục sản phẩm</param>
        /// <returns></returns>
        [AuthenticationFilter]
        public PartialViewResult Seach(int page, string name, int? price, int? quantity, long? categoryId)
        {
            try
            {
                var query = from data in con.Products
                            where data.IsActive == 1
                            select data;
                if (name != null)
                {
                    if (name.Trim() != "")
                    {
                        query = query.Where(u => u.Name.Contains(name));
                    }
                }

                // tìm kiếm theo mức giá 
                if (price != 0)
                {
                    if (price == 1)
                    {
                        query = query.Where(u => u.Price >=0 &&  u.Price < 500000);
                    }
                    if (price == 2)
                    {
                        query = query.Where(u => u.Price >= 500000 && u.Price < 1000000);
                    }
                    if (price == 3)
                    {
                        query = query.Where(u => u.Price >= 1000000 && u.Price < 1500000);
                    }
                    if (price == 4)
                    {
                        query = query.Where(u => u.Price >= 1500000 && u.Price < 2000000);
                    }
                    if (price == 5)
                    {
                        query = query.Where(u => u.Price >= 2000000 && u.Price < 2500000);
                    }
                    if (price == 6)
                    {
                        query = query.Where(u => u.Price >= 2500000 && u.Price < 3000000);
                    }
                    if (price == 7)
                    {
                        query = query.Where(u => u.Price >= 3000000 && u.Price < 3500000);
                    }
                    if (price == 8)
                    {
                        query = query.Where(u => u.Price >= 3500000 && u.Price < 4000000);
                    }
                    if (price == 9)
                    {
                        query = query.Where(u => u.Price >= 4000000 && u.Price < 4500000);
                    }
                    if (price == 10)
                    {
                        query = query.Where(u => u.Price >= 4500000 && u.Price < 5000000);
                    }
                    if (price == 11)
                    {
                        query = query.Where(u => u.Price >= 5000000 && u.Price < 5500000);
                    }
                    if (price == 12)
                    {
                        query = query.Where(u => u.Price >= 5500000 && u.Price < 6000000);
                    }
                    if (price == 13)
                    {
                        query = query.Where(u => u.Price >= 6000000 && u.Price < 6500000);
                    }
                    if (price == 14)
                    {
                        query = query.Where(u => u.Price >= 6500000 && u.Price < 7000000);
                    }
                    if (price == 15)
                    {
                        query = query.Where(u => u.Price >= 7000000 && u.Price < 7500000);
                    }
                    if (price == 16)
                    {
                        query = query.Where(u => u.Price >= 7500000 && u.Price < 8000000);
                    }
                    if (price == 17)
                    {
                        query = query.Where(u => u.Price >= 8000000 && u.Price < 8500000);
                    }
                    if (price == 18)
                    {
                        query = query.Where(u => u.Price >= 8500000 && u.Price < 9000000);
                    }
                    if (price == 19)
                    {
                        query = query.Where(u => u.Price >= 9000000 && u.Price < 9500000);
                    }
                    if (price == 20)
                    {
                        query = query.Where(u => u.Price >= 9500000 && u.Price < 10000000);
                    }
                    if (price == 21)
                    {
                        query = query.Where(u => u.Price > 10000000);
                    }

                }

                if (quantity != 0)
                {
                    // tìm kiếm thông tin theo số số lượng sản phẩm
                    if (quantity == 1)
                    {
                        query = query.Where(u => u.Quantity >= 0 && u.Quantity < 10);

                    }

                    if (quantity == 2)
                    {
                        query = query.Where(u => u.Quantity >= 10 && u.Quantity < 20);

                    }

                    if (quantity == 3)
                    {
                        query = query.Where(u => u.Quantity >= 20 && u.Quantity < 30);

                    }
                    if (quantity == 4)
                    {
                        query = query.Where(u => u.Quantity >= 30 && u.Quantity < 40);

                    }
                    if (quantity == 5)
                    {
                        query = query.Where(u => u.Quantity >= 40 && u.Quantity < 50);

                    }
                    if (quantity == 6)
                    {
                        query = query.Where(u => u.Quantity >= 50 && u.Quantity < 60);

                    }
                    if (quantity == 7)
                    {
                        query = query.Where(u => u.Quantity >= 60 && u.Quantity < 70);

                    }
                    if (quantity == 8)
                    {
                        query = query.Where(u => u.Quantity >= 70 && u.Quantity < 80);

                    }
                    if (quantity == 9)
                    {
                        query = query.Where(u => u.Quantity >= 80 && u.Quantity < 90);

                    }
                    if (quantity == 10)
                    {
                        query = query.Where(u => u.Quantity >= 90 && u.Quantity < 100);

                    }

                    if (quantity == 11)
                    {
                        query = query.Where(u => u.Quantity >100);

                    }
                    
                }

                if (categoryId != 0)
                {
                    query = query.Where(u => u.CategoryID == categoryId);
                }

                if (query != null && query.Count() > 0)
                {
                    List<GetProductModels> listProduct = new List<GetProductModels>();
                    foreach (Product data in query)
                    {
                        GetProductModels productModels = new GetProductModels();
                        productModels.ID = data.ID; 
                        productModels.Name = data.Name;
                        productModels.PromotionPrice = data.PromotionPrice;
                        productModels.Quantity = data.Quantity;
                        productModels.Image = data.Image; 
                        productModels.CategoryID = data.CategoryID;
                        ProductCategory productCategory = con.ProductCategories.Find(data.CategoryID);
                        if (productCategory != null)
                        {
                            productModels.CategoryName = productCategory.Name;
                        }
                        listProduct.Add(productModels);
                    }
                    return PartialView("_List", listProduct.ToPagedList(page, Constants.MAX_ROW_IN_LIST));
                }
                else
                {
                    return PartialView("_List", new List<GetProductModels>().ToPagedList(1, 1));
                }
            }

            catch 
            {
                return PartialView("_List", new List<GetProductModels>().ToPagedList(1, 1));
            }
        }


        /// <summary>
        /// Phan Đình Kiên : Thêm mới thông tin sản phẩm 
        /// </summary>
        /// <param name="product">Thông tin của sản phẩm sau khi được thêm mới</param>
        /// <returns></returns>
        [AuthenticationFilter]
        [ValidateInput(false)]
        [HttpPost]
        public int AddProduct(AddProductModels product)
        {
            try
            {

                LoginUserModels loginUserModels = Session["Login"] as LoginUserModels;
                Product us = new Product()
                {
                    SeoTitle = product.SeoTitle,

                    Name = product.Name,
                    MetaTitle = product.MetaTitle,
                    Description = product.Description,
                    Image = product.Image,
                    AltImage = product.AltImage,
                    Price = product.Price,
                    Percent = product.Percent,
                    PromotionPrice = product.PromotionPrice,
                    Quantity = product.Quantity,
                    CategoryID = product.CategoryID,
                    DescriptionIdDetail = product.DescriptionIdDetail,
                    Warranty = product.Warranty,
                    MetaKeywords = product.MetaKeywords,
                    MetaDescriptions = product.MetaDescriptions,
                    CreatedDate = DateTime.Now,
                    CreatedBy = loginUserModels.Name,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = loginUserModels.Name,
                    IsActive = 1,
                    ViewCount = 1,
                    TopHot = product.TopHot,
                    Status = true
                };
                con.Products.Add(us);
                con.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        /// <summary>
        /// Phan Đình Kiên : Lấy thông tin của sản phẩm theo Id 
        /// </summary>
        /// <param name="Id">mã của sản phẩm cần lây thông tin </param>
        /// <returns></returns>
        [AuthenticationFilter]
        public JsonResult GetProductById(long Id)
        {
            try
            {
                var query = con.Products.Find(Id);

                if (query != null)
                {
                    GetProductModels productModels = new GetProductModels()
                    {
                        ID = query.ID,
                        Name = query.Name,
                        MetaTitle = query.MetaTitle,
                        Description = query.Description,
                        Image = query.Image,
                        AltImage = query.AltImage,
                        MoreImages = query.MoreImages,
                        Price = query.Price,
                        Percent = query.Percent,
                        PromotionPrice = query.PromotionPrice,
                        Quantity = query.Quantity,
                        CategoryID = query.CategoryID,
                        //  CategoryName = query.ca
                        DescriptionIdDetail = query.DescriptionIdDetail,
                        Warranty = query.Warranty,
                        CreatedDate = query.CreatedDate,
                        CreatedBy = query.CreatedBy,
                        ModifiedDate = query.ModifiedDate,
                        ModifiedBy = query.ModifiedBy,
                        MetaKeywords = query.MetaKeywords,
                        MetaDescriptions = query.MetaDescriptions,
                        Status = query.Status,
                        TopHot = query.TopHot,
                        Sale = query.Sale,
                        ViewCount = query.ViewCount,
                        IsActive = query.IsActive
                    };
                    return Json(productModels, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new GetProductModels(), JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new GetProductModels(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Phan Đình Kiên : Cập Nhập thông tin của sản phẩm
        /// </summary>
        /// <param name="editProductModels">Thông tin của loại sản phẩm sau khi được cập nhập</param>
        /// <returns></returns>
        [AuthenticationFilter]
        [ValidateInput(false)]
        [HttpPost]
        public int EditProduct(EditProductModels editProductModels)
        {
            try
            {
                //LoginProductModels loginProductModels = Session["Login"] as LoginProductModels;
                Product product = con.Products.Find(editProductModels.ID);

                if (product != null)
                {
                    product.Name = editProductModels.Name;
                    product.MetaTitle = editProductModels.MetaTitle;
                    product.Description = editProductModels.Description;
                    product.Image = editProductModels.Image;
                    product.AltImage = editProductModels.AltImage;
                    product.MoreImages = editProductModels.MoreImages;
                    product.Price = editProductModels.Price;
                    product.Percent = editProductModels.Percent;
                    product.PromotionPrice = editProductModels.PromotionPrice;
                    product.Quantity = editProductModels.Quantity;
                    product.CategoryID = editProductModels.CategoryID;
                    product.DescriptionIdDetail = editProductModels.DescriptionIdDetail;
                    product.Warranty = editProductModels.Warranty;
                    product.CreatedDate = editProductModels.CreatedDate;
                    product.CreatedBy = editProductModels.CreatedBy;
                    product.ModifiedDate = editProductModels.ModifiedDate;
                    product.ModifiedBy = editProductModels.ModifiedBy;
                    product.MetaKeywords = editProductModels.MetaKeywords;
                    product.MetaDescriptions = editProductModels.MetaDescriptions;
                    product.Status = editProductModels.Status;
                    product.TopHot = editProductModels.TopHot;
                    product.SeoTitle = editProductModels.SeoTitle; 
                  
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
        /// Phan Đình Kiên : Xóa thông tin của loại sản phẩm
        /// </summary>
        /// <param name="Id">M</param>
        /// <returns></returns>
        [AuthenticationFilter]
        public int DeleteProduct(long Id)
        {

            try
            {
                Product product = con.Products.Find(Id);
                if (product != null)
                {
                    product.IsActive = 0;
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

        /// <summary>
        /// Phan Đình Kiên 
        /// </summary>
        /// <param name="id">Hiển Thị danh sách ảnh chi tiết</param>
        /// <returns></returns>
        public JsonResult LoadListImage(long Id)
        {
            try
            {
                Product product = con.Products.Find(Id); 
                if(product!= null)
                {
                    var images = product.MoreImages;
                    XElement xElement = XElement.Parse(images);
                    List<string> List = new List<string>(); 
                    foreach(XElement data in xElement.Elements())
                    {
                        List.Add(data.Value); 
                    }
                    return Json(List, JsonRequestBehavior.AllowGet);
                   
                }
                return Json(new List<string>(), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new List<string>(), JsonRequestBehavior.AllowGet);
            }
        }


        /// <summary>
        /// Phan Đình Kiên : Thêm mới danh sách ảnh chi tiết
        /// </summary>
        /// <param name="image"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int AddListProduct(string image,long Id)
        {
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                var listimage = javaScriptSerializer.Deserialize<List<string>>(image);
                XElement xElement = new XElement("Images");
                foreach (var item in listimage)
                {
                    if(item!= null&& item.Length>20)
                    {
                        string strisubs = item.Substring(22);
                        xElement.Add(new XElement("Image", strisubs));
                    }
                    else
                    {
                        xElement.Add(new XElement("Image", item));
                    }
                }
                Product product = con.Products.Find(Id);
                if (product != null)
                {
                    product.MoreImages = xElement.ToString();
                    con.SaveChanges(); 
                }
                return 1; 
            }
            catch
            {
                return 0; 
            }
            
        }



    }
}