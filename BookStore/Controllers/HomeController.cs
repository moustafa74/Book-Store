using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        book_storeEntities10 Context = new book_storeEntities10();
        public ActionResult Index()
        {
            List<book> newArivals = Context.books.Where(d => d.Stock>0).ToList();
            List<book> newArivals2 = new List<book>();
            for (int i = newArivals.Count-1; i >= newArivals.Count-3; i--)
            {
                if(i>=0)
                newArivals2.Add(newArivals[i]);         
            }           
            return View(newArivals2);
        }
        public ActionResult Orders()
        {
            if(Session["CustomerID"]==null)
                Response.Redirect("/LogIn");
            int cutomer_id = (int)Session["CustomerID"];
            var order1 = Context.orders.Where(d => d.customer_id == cutomer_id).ToList();
            var SortedList = order1.OrderBy(o => o.Order_id).ToList();
            SortedList.Reverse();
            ViewData["suborder"] = Context.sub_order.ToList();
            return View(SortedList);
        }
    }
}