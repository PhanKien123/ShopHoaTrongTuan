using Project.Data;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer
        DbConnection con = new DbConnection();

        /// <summary>
        /// Phan Đình Kiên : tiến hành lấy ra thông tin của footer 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            try
            {
                var query = from data in con.Footers
                            select data;

                if (query != null && query.Count() > 0)
                {
                    Footer footer = query.SingleOrDefault();

                    FooterModels footerModels = new FooterModels();
                    footerModels.Content = footer.Content;
                    footerModels.Status = footer.Status;
                    return View(footerModels);
                }
                return View(new FooterModels());
            }
            catch
            {
                return View(new FooterModels());
            }
           
        }

        /// <summary>
        /// Phan Đình Kiên : Cập nhập thông tin của footer 
        /// </summary>
        /// <param name="data">Thông tin footer sau khi được cập nhập</param>
        /// <returns></returns>
        public int UpdateFooter( FooterModels data)
        {
            try
            {
                var query = from Footer in con.Footers
                            select Footer;

                if (query != null && query.Count() > 0)
                {
                    var EditFooter = con.Footers.Find(data.ID);
                    EditFooter.Content = data.Content;
                    EditFooter.Status = data.Status;
                    con.SaveChanges();
                    return 1;
                }
                else
                {
                    Footer AddFooter = new Footer()
                    {
                        Content = data.Content,
                        Status = true,
                    };
                    con.Footers.Add(AddFooter);
                    return 1;

                }
            }
            catch
            {
                return 0; 
            }
           
        }
    }
}