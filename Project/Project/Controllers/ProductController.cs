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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }


        DbConnection con = new DbConnection();

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
        public PartialViewResult Seach(int page, string name, decimal price, int quantity, long categoryId)
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

                if (price != 0)
                {
                    query = query.Where(u => u.Price <= price);
                }

                if (quantity != 0)
                {
                    query = query.Where(u => u.Quantity <= quantity);
                }

                if (categoryId != 0)
                {
                    query = query.Where(u => u.CategoryID == categoryId);
                }

                if (query != null && query.Count() > 0)
                {
                    List<GetProductModels> listProduct = new List<GetProductModels>();
                    foreach (Product us in query)
                    {
                        GetProductModels productModels = new GetProductModels();
                        productModels.Name = us.Name;
                        productModels.Price = us.Price;
                        productModels.Quantity = us.Quantity;
                        productModels.CategoryID = us.CategoryID;
                        ProductCategory productCategory = con.ProductCategories.Find(us.CategoryID);
                        if (productCategory != null)
                        {
                            productModels.Name = productCategory.Name;
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

            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// thêm mới thông tin của sản phẩm
        /// </summary>
        /// <param name="product">Thông tin của sản phẩm sau khi được thêm mới</param>
        /// <returns></returns>
        [AuthenticationFilter]
        public int AddProduct(AddProductModels product)
        {
            try
            {
                // kiểm tra có trung Product 
                var query = (from data in con.Products
                             where data.IsActive == 1
                             select data);


                Product us = new Product()
                {

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
                    MetaDescriptions = product.MetaDescriptions

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
                    product.Sale = editProductModels.Sale;
                    product.ViewCount = editProductModels.ViewCount;
                    product.IsActive = editProductModels.IsActive;
                  
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

     
    }
}