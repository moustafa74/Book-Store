using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class AdminLoginController : Controller
    {
        book_storeEntities10 Context = new book_storeEntities10();
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View("AdminLogin");
        }
        public ActionResult Authorise(AdminModel admin)
        {
            var admindetails = Context.admins.Where(x => x.E_Mail == admin.Email && x.Password == admin.Password).FirstOrDefault();
            if (admindetails == null)
            {
                ViewData["adminERoor"] = "Invalid Email or Password";
                ViewData["adminEmail"] = admin.Email;
                ViewData["adminPassword"] = admin.Password;
                return View("AdminLogin");
            }
            else
            {
                Session["AdminID"] = admindetails.Admin_id;
                Session["AdminName"] = admindetails.Name;
                return RedirectToAction("Index", "Dashboard");
            }
        }
    }
}