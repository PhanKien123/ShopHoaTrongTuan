using Project.Data;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class ContactController : Controller
    {
        
        DbConnection con = new DbConnection();

        /// <summary>
        /// Phan Đình Kiên : Hiển thị thông tin liên hệ 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            try
            {
                var query = from data in con.Contacts
                            select data;

                if (query != null && query.Count() > 0)
                {
                    Contact contact = query.SingleOrDefault();
                    ContactModels contactModels = new ContactModels();
                    contactModels.Content = contact.Content;
                    contactModels.Status = contact.Status;
                    contactModels.Email = contact.Email;
                    contactModels.Phone = contact.Phone;
                    contactModels.ID = contact.ID; 

                    return View(contactModels);
                }
                return View(new ContactModels());
            }
            catch
            {
                return View(new ContactModels());
            }
        }

        /// <summary>
        /// Phan Đình Kiên : Cập nhập thông tin liên hệ của cửa hàng 
        /// </summary>
        /// <param name="data"> Thông tin liên hệ của cửa hàng sau khi được cập nhập</param>
        /// <returns></returns>
        public int UpdateContact(ContactModels data)
        {
            try
            {
                var query = from Contact in con.Contacts
                            select Contact;

                if (query != null && query.Count() > 0)
                {
                    var EditContact = con.Contacts.Find(data.ID);
                    EditContact.Content = data.Content;
                    EditContact.Status = true;
                    EditContact.Phone = data.Phone;
                    EditContact.Email = data.Email; 
                    con.SaveChanges();
                    return 1;
                }
                else
                {
                    Contact contact = new Contact()
                    {
                        Content = data.Content,
                        Status = true,
                        Phone = data.Phone, 
                        Email = data.Email
                    };
                    con.Contacts.Add(contact);
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