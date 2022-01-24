using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class PublisherController : Controller
    {
        book_storeEntities10 Context = new book_storeEntities10();
        // GET: Publisher
        public ActionResult Index()
        {
            if (Session["AdminID"] == null)
            {
                Response.Redirect("/AdminLogin");
            }
            var P1 = Context.publishers.ToList();
            return View("ShowPublisher", P1);
        }
        public ActionResult Open_Add_publisher()
        {
            return View();
        }
        public ActionResult Save_Add_publisher(publisher publisher1)
        {
            
            Context.publishers.Add(publisher1);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete_Publisher(int? id)
        {
            publisher p1 = Context.publishers.Where(d => d.Publisher_id == id).FirstOrDefault();
            Context.publishers.Remove(p1);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}