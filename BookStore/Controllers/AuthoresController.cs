using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{

    public class AuthoresController : Controller
    {
        book_storeEntities10 Context = new book_storeEntities10();
        // GET: Authores
        public ActionResult Index()
        {
            if (Session["AdminID"] == null)
            {
                Response.Redirect("/AdminLogin");
            }
            var A1 = Context.authors.ToList();
            return View("ShowAuthore", A1);
        }
        public ActionResult Open_Add_Authore()
        {
            return View();
        }
        public ActionResult Save_Add_Authore(author Authore1)
        {

            Context.authors.Add(Authore1);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete_Authore(int? id)
        {
            author a1 = Context.authors.Where(d => d.Author_id == id).FirstOrDefault();
            Context.authors.Remove(a1);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}