using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        book_storeEntities10 Context = new book_storeEntities10();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OpenRegister()
        {
            return View();
        }
        public ActionResult SaveRegister(UseModel objUserModel)
        {
            customer Cust = new customer();
            Cust.E_Mail = objUserModel.Email;
            Cust.Name = objUserModel.Name;
            Cust.Password = objUserModel.Password;
            Cust.Phone = objUserModel.Phone;
            Context.customers.Add(Cust);
            Context.SaveChanges();
            Session["CustomerID"] = Cust.customer_id;
            Session["userName"] = Cust.Name;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Authorise(UseModel user)
        {
            var userDetail = Context.customers.Where(x => x.E_Mail == user.Email && x.Password == user.Password).FirstOrDefault();
            var admindetails= Context.admins.Where(x => x.E_Mail == user.Email && x.Password == user.Password).FirstOrDefault();
            if (userDetail == null)
            {
                ViewData["ERoor"] = "Invalid Email or Password";
                ViewData["Email"] = user.Email;
                ViewData["Password"] = user.Password;
                return View("Index");
            }
            else
            {
                Session["CustomerID"] = userDetail.customer_id;
                Session["userName"] = userDetail.Name;
                return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult LogOut()
        {         
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}